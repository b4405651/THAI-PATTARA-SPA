using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using SPA_MANAGEMENT_SYSTEM.RESERVATION;

namespace SPA_MANAGEMENT_SYSTEM
{
    public class KEYCARD
    {
        const string prefix = "0000";
        static string[] response = new String[21]{"OK", "NO CARD", "NO ENCODER FOUND", "INVALID CARD", "CARD TYPE ERROR", "CARD READ/WRITE ERROR",
                                      "COM PORT IS NOT OPEN", "READ QUERY CARD OK", "INVALID PARAMETER", "OPERATING NOT SUPPORT",
                                      "OTHER ERROR", "PORT IS IN-USE", "COMMUNICATION ERROR", "CARD IS NOT EMPTY", "UNKNOWN CARD ENCRYPTION",
                                      "OPERATING FAILED", "UNKNOWN ERROR", "THE ROOM IS OCCUPIED", "INVALID ROOM NUMBER", "", "CARD IS BLANK"};
        static string operation_code = "";
        static string packet_string = "";
        const string card_type = "04";
        const string sep = "|";

        static TcpClient TCPsocket = null;

        public static void executeCommand(Form Owner, string MODE, string room_no = "", string start_datetime = "", string end_datetime = "")
        {
            try
            {
                TCPsocket = new TcpClient(Properties.Settings.Default.encoder_ip, 7800);

                NetworkStream stream;
                using (stream = TCPsocket.GetStream())
                {

                    switch (MODE)
                    {
                        case "ISSUE":
                            DateTime thisTime = DateTime.Now;
                            // get Denmark Standard Time zone - not sure about that
                            TimeZoneInfo tst = TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time");
                            bool isDST = tst.IsDaylightSavingTime(thisTime);

                            operation_code = "0I";
                            packet_string = prefix + operation_code + sep + "R" + room_no + sep + "T" + card_type + sep + "D" + reFormatDateTime(start_datetime, isDST) + sep + "O" + reFormatDateTime(end_datetime, isDST);
                            break;
                        case "REVOKE":
                            operation_code = "0B";
                            packet_string = prefix + operation_code;
                            break;
                        case "VERIFY":
                            operation_code = "0E";
                            packet_string = prefix + operation_code;
                            break;
                    }

                    byte[] bySend = { };

                    Array.Resize<byte>(ref bySend, packet_string.Length + 2);

                    byte[] byTemp = new byte[packet_string.Length * sizeof(char)];
                    System.Buffer.BlockCopy(packet_string.ToCharArray(), 0, byTemp, 0, byTemp.Length);

                    for (int i = 0; i < packet_string.Length; i++)
                    {
                        bySend[1 + i] = byTemp[i * 2];
                    }

                    bySend[0] = 2;
                    bySend[packet_string.Length + 1] = 3;
                    GF.doDebug("******************** [KEYCARD] PACKET = " + packet_string);

                    stream.Write(bySend, 0, bySend.Length);

                    byte[] data = new byte[4096];
                    String responseData = String.Empty;
                    Int32 bytes = stream.Read(data, 0, data.Length);
                    responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes).Trim();
                    responseData = responseData.Substring(1, responseData.Length - 1);

                    GF.doDebug("******************** [KEYCARD] RESPONSE = " + responseData.ToString());

                    int statusCode = Convert.ToInt32(responseData.ToString().Substring(4, 2));

                    if (statusCode != 0) MessageBox.Show(response[statusCode] + " !!", "ENCODER ERROR");

                    if (Owner.Name == "reservation_manage") ((reservation_manage)Owner).returnCode = statusCode;

                    if (MODE == "VERIFY")
                    {
                        if (responseData.Length > 13)
                        {
                            if (responseData.Substring(11, 2) == "04")
                                ((reservation)Owner).isMasterCard = false;
                            else
                                ((reservation)Owner).isMasterCard = true;
                        }
                    }
                    stream.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                GF.doDebug("******************** [KEYCARD] ****** " + e.Message);
            }
            finally
            {
                TCPsocket.Close();
                TCPsocket = null;
            }
        }

        private static string reFormatDateTime(string datetime, bool isDST = false)
        {
            string[] tmp = datetime.Split(' ');
            string[] date = tmp[0].Split('/');
            string[] time = tmp[1].Split(':');

            if (!isDST)
                return date[2] + date[1] + date[0] + time[0] + time[1];
            else
            {
                int hr = Convert.ToInt32(time[0]);
                if (hr - 1 < 0) time[0] = (24 - hr - 1).ToString();
                return date[2] + date[1] + date[0] + time[0] + time[1];
            }
        }
    }
}
