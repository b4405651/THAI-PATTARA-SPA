using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace SPA_MANAGEMENT_SYSTEM
{
    public class GF
    {
        static SmtpClient client;
        static MailMessage message;

        [DllImport("user32.dll")]
        public static extern short GetKeyState(Keys key);

        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr i);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        private static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "GetWindowText", CharSet = CharSet.Auto)]
        private static extern IntPtr GetWindowCaption(IntPtr hwnd, StringBuilder lpString, int maxCount);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        // A delegate which is used by EnumChildWindows to execute a callback method.
        public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);

        [DllImport("user32.dll")]
        public static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        public struct LASTINPUTINFO
        {
            public uint cbSize;

            public uint dwTime;
        }
        
        // AUTOCOMPLETE
        

        public static string[] BillPrefix = {"SH","TP","MC","RT"};

        public const string SAapproveCode = "4120100028651";

        public const int recordPerPage = 25;
        public static int currentPage = 1;
        public static loading loadingPage;
        public static Color disableColor = Color.FromArgb(204, 204, 204);
        public static Color enableColor = Color.FromArgb(194, 169, 239);
        public static int bottomBound = -1;

        public static int user_id = 0;
        public static String username = "";
        public static int emp_id = 0;
        public static bool can_approve = false;
        public static int selected_id = 0;
        public static bool is_logged_in = false;
        public static string old_value = "";
        public static string only_path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\";
        //public static string only_path = "\\\\192.168.1.1\\file_server\\SMS_APP_DEBUG\\" + System.Environment.MachineName;
        public static string path = only_path + "SMS_DEBUG.txt";
        public static string localCardPath = @"C:\SMS_CARDS\";
        public const double vatValue = 0.18;
        public static Regex validTime = new Regex(@"^(?:[01]?[0-9]|2[0-3]):[0-5][0-9]$");
        public static int pageTop = 15;
        public static int[] maxDay = new int[] { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        public static bool printDone = true;
        public static main_page mainPage = null;
        public static int minutesAfterMassage = 15;
        public static int reservePeriod = 15;
        public static int itemDiscount = 10;

        public static string[] oilList = { "WATER", "EARTH", "WOOD", "FIRE", "METAL", "COCONUT" };
        public static string[] scrubList = { "WATER", "EARTH", "WOOD", "FIRE", "METAL", "CHOCOLATE", "COFFEE", "THAI HERB" };
        public static string dateSep = "";
        public static string thousandSep = "";
        public static string decimalSep = "";
        public static string currResDate = "";
        public static bool allowMinimize = false;
        public static Timer clock = null;
        public static string tmpText = "";

        public static Excel.Application oXL;
        public static Excel._Workbook oWB;
        public static Excel._Worksheet oSheet;
        public static Excel.Range oRng;
        public static Object oDocument;

        public static Form form;

        public static StreamWriter sw;
        
        public static void doDebug(string debugText)
        {
            sw = new StreamWriter(path, true);
            sw.WriteLine("[ " + NOW() + " ] " + debugText);
            sw.Close();
        }

        public static void initLoading()
        {
            loadingPage = new loading();
        }
        public static void showLoading(Form sender = null)
        {
            if (loadingPage == null || loadingPage.IsDisposed)
                loadingPage = new loading(sender);

            loadingPage.loadingSender = sender;
            loadingPage.loadingContent.Visible = true;
            //loadingPage.loadingContent.animated_loading_box.Update();
            loadingPage.Visible = true;
        }

        public static void closeLoading()
        {
            if (loadingPage != null)
            {
                loadingPage.loadingContent.Visible = false;
                loadingPage.Visible = false;
            }
        }

        public static void closeChildren(main_page mainPage)
        {
            foreach (Form child in mainPage.MdiChildren)
            {
                child.Close();
                child.Dispose();
            }
            selected_id = 0;
            File.WriteAllText(GF.path, String.Empty);

            //resetPagingState();
        }

        public static void initPage(Form childPage, main_page mainPage)
        {
            GF.closeChildren(mainPage);
            GF.showLoading(mainPage);

            GF.doDebug("========== MAIN FORM :: " + childPage.Name + " ==========");
            GF.selected_id = 0;

            childPage.MdiParent = mainPage;
            if (childPage.Name.IndexOf("report_") != -1) childPage.Dock = DockStyle.Fill;
            else
            {
                childPage.Size = childPage.MdiParent.ClientSize;
                childPage.StartPosition = FormStartPosition.Manual;
            }
            childPage.WindowState = FormWindowState.Maximized;
            
            GF.addKeyUp(childPage);

            childPage.Load += (s, e) =>
            {
                //((Form)s).Visible = true;
            };
            childPage.LocationChanged += (s, e) =>
            {
                if (childPage.Left != 0) childPage.Left = -5;
                if (childPage.Top != 0) childPage.Top = 0;
            };
            if(!childPage.IsDisposed) childPage.Show();

            GF.closeLoading();
        }

        public static void resetPagingState()
        {
            currentPage = 1;

            /*dgvPaging.first_btn.Enabled = false;
            dgvPaging.prev_btn.Enabled = false;
            dgvPaging.page_txt.Text = currentPage.ToString();
            dgvPaging.next_btn.Enabled = true;
            dgvPaging.last_btn.Enabled = true;*/
        }

        public static string SHA256_encode(string ClearString)
        {
            UnicodeEncoding uEncode = new UnicodeEncoding();
            
            byte[] bytClearString = uEncode.GetBytes(ClearString);
            System.Security.Cryptography.SHA256Managed sha;
            using (sha = new System.Security.Cryptography.SHA256Managed())
            {
                byte[] hash = sha.ComputeHash(bytClearString);
                return Convert.ToBase64String(hash);
            }
        }

        public static void enableButton(Button btn)
        {
            btn.Enabled = true; btn.BackColor = enableColor;
        }

        public static void disableButton(Button btn)
        {
            btn.Enabled = false; btn.BackColor = disableColor;
        }

        public static void getTotalPage(btn_dgv btn_dgv, string queryString, Dictionary<string, string> Params)
        {
            DataTable totalDT;
            //queryString = queryString.Substring(queryString.IndexOf("FROM"));
            //if (queryString.LastIndexOf("ORDER BY") != -1) queryString = queryString.Substring(0, queryString.LastIndexOf("ORDER BY"));
            using (totalDT = DB.getS("SELECT COUNT(*) AS TOTAL FROM (" + queryString + ") TMP", Params, "GET TOTAL RECORDS", false))
            {
                int total_records = Convert.ToInt32(totalDT.Rows[0]["TOTAL"].ToString());
                int pageNum = total_records / recordPerPage;
                int recordsLeft = total_records % recordPerPage;
                if (recordsLeft > 0) pageNum++;

                btn_dgv.paging_panel.Controls["total_lbl"].Text = pageNum.ToString();
                btn_dgv.paging_panel.Controls["total_record_lbl"].Text = "TOTAL RECORD" + (total_records > 1 ? "S" : "") + " : " + GF.formatNumber(total_records);
                if (pageNum <= 1)
                {
                    if (pageNum == 0)
                    {
                        btn_dgv.paging_panel.Controls["page_txt"].Enabled = false;
                        btn_dgv.paging_panel.Controls["page_txt"].Text = "0";
                    }
                    else
                    {
                        btn_dgv.paging_panel.Controls["page_txt"].Text = currentPage.ToString();
                        btn_dgv.paging_panel.Controls["page_txt"].Enabled = true;
                    }

                    btn_dgv.paging_panel.Controls["next_btn"].Enabled = false;
                    btn_dgv.paging_panel.Controls["next_btn"].BackColor = disableColor;

                    btn_dgv.paging_panel.Controls["last_btn"].Enabled = false;
                    btn_dgv.paging_panel.Controls["last_btn"].BackColor = disableColor;
                }
                else
                {
                    btn_dgv.paging_panel.Controls["page_txt"].Text = currentPage.ToString();
                    btn_dgv.paging_panel.Controls["page_txt"].Enabled = true;
                }
            }
        }

        public static void bringToFront(ac_data myAC)
        {
            Form pForm;
            using (pForm = myAC.ParentForm)
            {
                if (pForm != null)
                {
                    foreach (Control ctrl in pForm.Controls)
                    {
                        if (ctrl.GetType() == typeof(autocomplete) || ctrl.GetType() == typeof(ac_data))
                        {
                            if (ctrl.Name != myAC.Name) ctrl.SendToBack();
                        }

                    }
                    myAC.BringToFront();
                }
            }
        }

        public static void resetAC(Form f)
        {
            foreach (Control c in f.Controls)
            {
                if (c.GetType() == typeof(autocomplete))
                {
                    if (((autocomplete)c).acTxt.Text.Trim() == "") ((autocomplete)c).value = -1;
                }
            }
        }

        public static string TODAY()
        {
            string day = DateTime.Now.Day.ToString("00");
            string month = DateTime.Now.Month.ToString("00");
            string year = DateTime.Now.Year.ToString("00");

            return day + "/" + month + "/" + year;
        }

        public static string NOW()
        {
            string hour = DateTime.Now.Hour.ToString("00");
            string min = DateTime.Now.Minute.ToString("00");
            string sec = DateTime.Now.Second.ToString("00");

            return TODAY() + " " + hour + ":" + min + ":" + sec;
        }

        public static string modDate(string dt, int mode = 103)
        {
            if(mode == 103)
                return "CONVERT(DATE, '" + dt + "', " + mode.ToString() + ")";
            else
                return "CONVERT(DATETIME, '" + dt + "', " + mode.ToString() + ")";
        }

        public static string modDateTime(string dt, int mode = 120)
        {
            string[] tmp = dt.Split(' ');
            String[] tmpDate;
            string newDateTime;
            if (tmp[0].IndexOf('/') != -1)
            {
                tmpDate = tmp[0].Split('/');
                newDateTime = tmpDate[2] + "-" + tmpDate[1] + "-" + tmpDate[0] + " " + tmp[1];
            }
            else
                newDateTime = dt;
            return "CONVERT(DATETIME, '" + newDateTime + "', " + mode.ToString() + ")";
        }

        public static void loadAttachmentPage(Form owner, int id, bool viewOnly = false)
        {
            attachments attachmentPage;
            using (attachmentPage = new attachments())
            {
                attachmentPage.Owner = owner;
                attachmentPage.id = id;
                attachmentPage.viewOnly = viewOnly;
                attachmentPage.ShowDialog();
            }
        }

        public static void addKeyUp(Form form)
        {
            foreach (Control ctrl in form.Controls)
            {
                if (ctrl.GetType() == typeof(TextBox) || ctrl.GetType() == typeof(ComboBox))
                {
                    ctrl.KeyUp += new KeyEventHandler(escKeyEvent);
                }

                if (ctrl.GetType() == typeof(ac_data))
                {
                    ((ac_data)ctrl).myAC.acTxt.KeyUp += new KeyEventHandler(escKeyEvent);
                }
            }
        }

        static void escKeyEvent(object sender, KeyEventArgs e)
        {
            /*if (e.KeyCode == Keys.Escape)
            {
                Control Parent;
                using (Parent = ((Control)sender).Parent)
                {
                    if (Parent.Name == "myAC") Parent = Parent.Parent.Parent;
                    foreach (Control ctrl in Parent.Controls)
                    {
                        if (ctrl.Tag != null)
                        {
                            if (ctrl.Tag.ToString() == "barcode")
                            {
                                if (ctrl.Name == ((Control)sender).Name) ((TextBox)sender).Text = "";
                                else ctrl.Focus();
                                return;
                            }
                        }
                    }
                }
            }*/
        }

        public static string formatNumber(int number)
        {
            return number.ToString("#,##0");
        }
        public static string removeThousandAndDecimal(String number)
        {
            //MessageBox.Show(number + "\r\n" + number.Trim() + "\r\n" + number.Trim().Replace(GF.decimalSep + "00", "") + "\r\n" + number.Trim().Replace(GF.decimalSep + "00", "").Replace(GF.thousandSep, ""));
            return number.Trim().Replace(GF.decimalSep + "00", "").Replace(GF.thousandSep, "");
        }
        public static string formatDate(string inputDate)
        {
            if (inputDate.Trim() == "") return "";

            string[] tmp = inputDate.Split(' ');
            string[] tmpDate = tmp[0].Split('/');

            return Convert.ToInt32(tmpDate[0]).ToString("00") + "/" + Convert.ToInt32(tmpDate[1]).ToString("00") + "/" + tmpDate[2];
        }
        public static string formatDateTime(string inputDateTime)
        {
            if (inputDateTime.Trim() == "") return "";

            string[] data = inputDateTime.Split(' ');
            string[] tmpDate = data[0].Split('/');
            string[] tmpTime = data[1].Split(':');

            return Convert.ToInt32(tmpDate[0]).ToString("00") + "/" + Convert.ToInt32(tmpDate[1]).ToString("00") + "/" + tmpDate[2] + " " + Convert.ToInt32(tmpTime[0]).ToString("00") + ":" + Convert.ToInt32(tmpTime[1]).ToString("00") + ":" + Convert.ToInt32(tmpTime[2]).ToString("00");
        }
        public static string formatDecimal(double number)
        {
            return number.ToString("#" + GF.thousandSep + "##0" + GF.decimalSep + "00");
        }
        public static void genID(ref int _id, ref bool _gen)
        {
            string queryString = "";
            int rowCount = 0;
            do
            {
                _id = new Random().Next(1, 1000000000);
                queryString = "SELECT * FROM ATTACHMENT WHERE OWNER_ID = " + _id.ToString();
                DataTable myDT;
                using (myDT = DB.getS(queryString, null, "CHECK IF GEN OWNER ID IS EXISTED IN DB", false))
                {
                    rowCount = myDT.Rows.Count;
                }
            } while (rowCount > 0);
            _gen = true;
        }
        public static void resizeComboBox(ComboBox cb)
        {
            int temp = 0;
            int maxWidth = 0;

            foreach (var obj in cb.Items)
            {
                temp = TextRenderer.MeasureText(obj.ToString(), cb.Font).Width;
                if (temp > maxWidth)
                {
                    maxWidth = temp;
                }
            }
            if(maxWidth > 0) cb.DropDownWidth = maxWidth;
        }
        public static void updateRowNum(DataGridView DGV, bool paging = false)
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                if (!paging) row.HeaderCell.Value = (row.Index + 1).ToString();
                else
                {
                    Console.Write((((GF.currentPage - 1) * GF.recordPerPage) + row.Index + 1).ToString());
                    row.HeaderCell.Value = (((GF.currentPage - 1) * GF.recordPerPage) + row.Index + 1).ToString();
                }
            }
        }

        public static void deleteTempAttachment(int owner_id, string owner_form)
        {
            GF.showLoading();
            DataTable DT;
            String queryString = "SELECT FILE_NAME FROM ATTACHMENT WHERE OWNER_ID = " + owner_id.ToString() + " AND OWNER_FORM = " + owner_form;

            Dictionary<string, string> Params = new Dictionary<string, string>();
            /*Params.Add("@owner_id", owner_id.ToString());
            Params.Add("@owner_form", owner_form);*/

            using (DT = DB.getS(queryString, Params, "GET TEMP ATTACHMENT[OWNER_ID=" + owner_id.ToString() + " : OWNER_FORM=" + owner_form + "]", false))
            {
                foreach (DataRow row in DT.Rows)
                {
                    string fileName = row["file_name"].ToString();
                    //MessageBox.Show(fileName);
                    if (FTP.delete(fileName, "ATTACHMENT"))
                    {
                        queryString = "DELETE FROM ATTACHMENT WHERE FILE_NAME LIKE '" + fileName + "'";
                        DB.beginTrans();
                        if (DB.set(queryString, "DELETE ATTACHMENT[" + fileName + "]"))
                        {
                            DB.close();
                        }
                        else
                        {
                            MessageBox.Show("ERROR DELETE ATTACHMENT FROM DATABASE !!", "ERROR");
                            GF.closeLoading();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("CANNOT DELETE ATTACHMENT FILE via FTP !!", "ERROR");
                        GF.closeLoading();
                        return;
                    }
                }
                GF.closeLoading();
                return;
            }
        }

        public static void resizeMgmtForm(Form frm)
        {
            if (frm.Controls.Find("cancel_btn", true).Length > 0)
            {
                Button cancel_btn;
                using (cancel_btn = (Button)frm.Controls.Find("cancel_btn", true)[0])
                {
                    frm.Height = cancel_btn.Top + cancel_btn.Height + 35;
                    frm.Width = cancel_btn.Left + cancel_btn.Width + 12;
                }
            }
        }

        public static bool emptyDate(string date)
        {
            if (date.Replace(GF.dateSep, "").Replace("-", "").Trim() == "") return true;
            else return false;
        }

        public static string getNickname(string fullname)
        {
            if(fullname.IndexOf('(') != -1 && fullname.IndexOf(')') != -1) return fullname.Substring(fullname.IndexOf('(') + 1, (fullname.IndexOf(')') - fullname.IndexOf('(') - 1)).Trim();
            return fullname;
        }

        public static bool isValidDate(string date)
        {
            if (date.Trim().Length != 10) return false;
            if (date.Trim().Replace(" ", "") == "//" || date.Trim().Replace(" ", "") == "--" || date.Trim().Replace(" ", "") == "..") return false;

            /*int day = Convert.ToInt32(date.Trim().Split(GF.dateSep[0])[0]);
            int month = Convert.ToInt32(date.Trim().Split(GF.dateSep[0])[1]);
            int year = Convert.ToInt32(date.Trim().Split(GF.dateSep[0])[2]);*/

            int day = 0;
            int month = 0;
            int year = 0;

            if (!Int32.TryParse(date.Trim().Substring(0, 2), out day)) return false;
            if (!Int32.TryParse(date.Trim().Substring(3, 2), out month)) return false;
            if (!Int32.TryParse(date.Trim().Substring(6, 4), out year)) return false;

            GF.doDebug("CHECK DaysInMonth(" + year.ToString("0000") + ", " + month.ToString("00") + ")");

            if (month <= 0 || month > 12)
            {
                MessageBox.Show("MONTH MUST BE 1 - 12 !! (" + month.ToString("00") + ")", "ERROR");
                return false;
            }

            if (year <= 0)
            {
                MessageBox.Show("YEAR MUST BE GREATER THAN 0 !! (" + year.ToString("0000") + ")", "ERROR");
                return false;
            }

            if (day <= 0 || day > DateTime.DaysInMonth(year, month)) return false;
            else return true;
        }

        public static DataRow validateCards(String card_type, String card_no, String code_check = "")
        {
            try
            {
                string original_card_type = card_type;
                GF.doDebug("VALIDATE CARD : " + original_card_type);
                if (card_type == "MONEY_COUPON") card_type = "COUPON";
                String queryString = "SELECT " + card_type + @".*, ";

                if (card_type == "MEMBERCARD" || card_type == "VIP_CARD") queryString += "NULL PROGRAM_NAME, NULL PROGRAM_CODE, ";
                else queryString += "SPA_PROGRAM.PROGRAM_NAME PROGRAM_NAME, SPA_PROGRAM.CODE PROGRAM_CODE, ";

                if (card_type == "MEMBERCARD") queryString += "MEMBERCARD_TYPE.DISCOUNT DISCOUNT, 0 DISCOUNT_UNIT, ";
                else if (card_type == "VIP_CARD") queryString += "VIP_CARD.DISCOUNT DISCOUNT, 0 DISCOUNT_UNIT, ";
                else if (card_type == "CROSS_PROMOTION") queryString += "CROSS_PROMOTION.DISCOUNT DISCOUNT, 0 DISCOUNT_UNIT, ";
                else if (card_type == "COUPON") queryString += "COUPON.DISCOUNT_AMOUNT DISCOUNT, COUPON.DISCOUNT_UNIT, ";
                else queryString += "NULL DISCOUNT, NULL DISCOUNT_UNIT, ";

                if (card_type == "MEMBERCARD") queryString += "MEMBERCARD_TYPE.DISCOUNT_FOOD, MEMBERCARD_TYPE.DISCOUNT_FOOD_UNIT, ";
                else queryString += itemDiscount.ToString() + " DISCOUNT_FOOD, 0 DISCOUNT_FOOD_UNIT, ";

                if (card_type != "MEMBERCARD" && card_type != "GIFT_CERTIFICATE" && card_type != "COUPON") queryString += "NULL BALANCE, ";

                queryString = queryString.Substring(0, queryString.Length - 2) + " ";

                queryString += "FROM " + card_type + " ";
                if (card_type == "MEMBERCARD") queryString += "INNER JOIN MEMBERCARD_TYPE ON MEMBERCARD.MEMBERCARD_TYPE_ID = MEMBERCARD_TYPE.MEMBERCARD_TYPE_ID ";
                else if (card_type != "VIP_CARD")
                {
                    queryString += "LEFT OUTER JOIN SPA_PROGRAM ON " + card_type + @".SPA_PROGRAM_ID = SPA_PROGRAM.SPA_PROGRAM_ID ";
                }

                queryString += "WHERE RTRIM(LTRIM(CARD_NO)) = '" + card_no + "' AND " + card_type + ".IS_USE = 1 ";

                Dictionary<string, string> Params = new Dictionary<string, string>();
                //Params.Add("@card_no", card_no);

                if (card_type == "VIP_CARD" || card_type == "COUPON") queryString += "AND IS_VOID = 0 ";

                DataTable DT;
                using (DT = DB.getS(queryString, Params, "GET " + original_card_type + "[" + card_no + "]", false))
                {
                    if (DT.Rows.Count == 0)
                    {
                        if (card_type != "CROSS_PROMOTION")
                        {
                            String error_msg = "NO " + card_type.Replace('_', ' ') + " WITH THIS CODE !!";
                            if (card_type == "VIP_CARD" || card_type == "COUPON")
                            {
                                queryString = @"
                                SELECT TOP 1 " + card_type + @".*, EMPLOYEE.FULLNAME VOIDER 
                                FROM " + card_type + @"
                                LEFT OUTER JOIN EMPLOYEE ON " + card_type + @".VOIDED_BY = EMPLOYEE.EMP_ID
                                WHERE RTRIM(LTRIM(CARD_NO)) = '" + card_no + "' AND " + card_type + ".IS_VOID = 1 ORDER BY " + card_type + ".VOIDED_DATETIME DESC";

                                DataTable tmpDT;
                                using (tmpDT = DB.getS(queryString, Params, "GET VOIDED LATEST REASON", false))
                                {
                                    if (tmpDT.Rows.Count == 1)
                                    {
                                        error_msg = "THIS " + card_type.Replace('_', ' ') + " WAS VOIDED !!\r\nREASON : " + tmpDT.Rows[0]["VOIDED_REASON"].ToString() + "\r\nVOIDED BY : " + (tmpDT.Rows[0]["VOIDED_BY"].ToString() == "0" ? "S.A." : tmpDT.Rows[0]["VOIDER"].ToString()) + "\r\nVOIDED ON : " + GF.formatDateTime(tmpDT.Rows[0]["VOIDED_DATETIME"].ToString());
                                    }
                                }

                            }
                            GF.doDebug(error_msg);
                            MessageBox.Show(error_msg, "ERROR");
                        }
                        else
                        {
                            GF.doDebug("NOT FOUND !!");
                            MessageBox.Show("NOT FOUND !!", "ERROR");
                        }
                        GF.closeLoading();
                        return null;
                    }
                    else if (DT.Rows.Count > 1)
                    {
                        GF.doDebug("DUPLICATE CARDS WITH THIS CODE !!");
                        MessageBox.Show("DUPLICATE CARDS WITH THIS CODE !!", "ERROR");
                        GF.closeLoading();
                        return null;
                    }
                    else if (DT.Rows.Count == 1)
                    {
                        String expireColName = "";
                        if (card_type == "MEMBERCARD") expireColName = "EXPIRE_DATE";
                        else expireColName = "EXPIRY_DATE";

                        if (DT.Rows[0][expireColName].ToString() != "NULL" && DT.Rows[0][expireColName].ToString() != "")
                        {
                            DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                            dtfi.ShortDatePattern = "d" + GF.dateSep + "M" + GF.dateSep + "yyyy";
                            dtfi.DateSeparator = GF.dateSep;

                            DateTime today = Convert.ToDateTime(DateTime.Today.ToString("d" + GF.dateSep + "M" + GF.dateSep + "yyyy"), dtfi);
                            DateTime expire = Convert.ToDateTime(DT.Rows[0][expireColName].ToString().Split(' ')[0], dtfi);
                            if (DateTime.Compare(today, expire) > 0)
                            {
                                GF.doDebug("THIS CARD IS EXPIRED !!");
                                MessageBox.Show("THIS CARD IS EXPIRED !!", "ERROR");
                                GF.closeLoading();
                                return null;
                            }
                        }

                        if (DT.Rows[0]["IS_USE"].ToString() == "0")
                        {
                            GF.doDebug("THIS " + card_type.Replace('_', ' ') + " WAS ALREADY USED OR MIGHT BE VOIDED !!");
                            MessageBox.Show("THIS " + card_type.Replace('_', ' ') + " WAS ALREADY USED OR MIGHT BE VOIDED !!", "ERROR");
                            GF.closeLoading();
                            return null;
                        }

                        if (card_type == "MEMBERCARD" || card_type == "GIFT_CERTIFICATE" || card_type == "COUPON")
                        {
                            if (DT.Rows[0]["BALANCE"].ToString() != "" && DT.Rows[0]["BALANCE"].ToString() != "NULL")
                            {
                                if (card_type == "MEMBERCARD")
                                {
                                    queryString = "SELECT * FROM MEMBERCARD_TYPE WHERE MEMBERCARD_TYPE_ID = " + DT.Rows[0]["MEMBERCARD_TYPE_ID"].ToString();
                                    DataTable tmpDT;
                                    using (tmpDT = DB.getS(queryString, null, "CHECK IF MEMBERCARD CAN USE AFTER NO CREDIT ?", false))
                                    {
                                        if (Convert.ToInt32(tmpDT.Rows[0]["CAN_USE_NO_CREDIT"].ToString()) == 0 && Convert.ToInt32(DT.Rows[0]["BALANCE"].ToString()) == 0)
                                        {
                                            GF.doDebug("NO CREDIT LEFT !!");
                                            MessageBox.Show("NO CREDIT LEFT !!", "ERROR");
                                            GF.closeLoading();
                                            return null;
                                        }
                                        else
                                        {
                                            GF.doDebug("CREDIT LEFT : " + DT.Rows[0]["BALANCE"].ToString() + " " + Properties.Settings.Default.money_unit);
                                            MessageBox.Show("CREDIT LEFT : " + DT.Rows[0]["BALANCE"].ToString() + " " + Properties.Settings.Default.money_unit);
                                            GF.closeLoading();
                                        }
                                    }
                                }
                                else
                                {
                                    int balance_left = 0;
                                    if (Int32.TryParse(DT.Rows[0]["BALANCE"].ToString(), out balance_left))
                                    {
                                        if (balance_left == 0)
                                        {
                                            GF.doDebug("NO CREDIT LEFT !!");
                                            MessageBox.Show("NO CREDIT LEFT !!", "ERROR");
                                            GF.closeLoading();
                                            return null;
                                        }
                                    }
                                    else
                                    {
                                        if (original_card_type == "MONEY_COUPON")
                                        {
                                            GF.closeLoading();
                                            GF.doDebug("THIS IS NOT 'MONEY COUPON' !!\r\n\r\nPLEASE MAKE SURE YOU CLICKED THE CORRECT COUPON TYPE !!");
                                            MessageBox.Show("THIS IS NOT 'MONEY COUPON' !!\r\n\r\nPLEASE MAKE SURE YOU CLICKED THE CORRECT COUPON TYPE !!", "ERROR");
                                            return null;
                                        }
                                    }
                                }
                            }
                        }
                        GF.doDebug("CARD IS OK !!");
                        return DT.Rows[0];
                    }
                    else return null;
                }
            }
            catch (Exception e)
            {
                GF.closeLoading();
                GF.doDebug("CARD VALIDATION ERROR !!\r\n\r\nPLEASE CONTACT SOFTWARE DEVELOPER !!\r\n\r\n" + e.Message);
                MessageBox.Show("CARD VALIDATION ERROR !!\r\n\r\nPLEASE CONTACT SOFTWARE DEVELOPER !!\r\n\r\n" + e.Message, "ERROR !!");
                return null;
            }
        }

        public static void createTimer()
        {
            clock = new Timer();
            clock.Enabled = true;
            clock.Interval = (5 * 60 * 1000);
        }

        public static void destroyTimer()
        {
            if (clock != null) clock.Stop();
            clock.Dispose();
            //clock = null;
        }

        public static void initExcel()
        {
            //Start Excel and get Application object.
            oXL = new Excel.Application();
            oXL.Visible = false;

            //Get a new workbook.
            oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
            oSheet = (Excel._Worksheet)oWB.ActiveSheet;
        }

        private static bool EnumChildWindowsCallback(IntPtr handle, IntPtr pointer)
        {
            const uint WM_LBUTTONDOWN = 0x0201;
            const uint WM_LBUTTONUP = 0x0202;

            var sb = new StringBuilder(256);
            // Get the control's text.
            GetWindowCaption(handle, sb, 256);
            var text = sb.ToString();

            // If the text on the control == &OK send a left mouse click to the handle.
            if (text.Trim() == "OK")
            {
                PostMessage(handle, WM_LBUTTONDOWN, IntPtr.Zero, IntPtr.Zero);
                PostMessage(handle, WM_LBUTTONUP, IntPtr.Zero, IntPtr.Zero);
            }

            return true;
        }

        // This method accepts a string which represents the title name of the window you're looking for the controls on.
        public static void ClickButtonLabeledOK(string windowTitle)
        {
            try
            {
                //GF.doDebug(">>>>> LOOK FOR MESSAGE BOX ...");
                // Find the main window's handle by the title.
                IntPtr windowHWnd = FindWindowByCaption(IntPtr.Zero, windowTitle);
                if (!(windowHWnd == IntPtr.Zero))
                {
                    // Loop though the child windows, and execute the EnumChildWindowsCallback method
                    EnumChildWindows(windowHWnd, EnumChildWindowsCallback, IntPtr.Zero);
                    //if (mainPage != null) mainPage.BringToFront();
                    //GF.doDebug(">>>>> CLICKED !!");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public static void submitErrorLog()
        {
            return;
            Boolean halt = false;
            try
            {
                //GF.doDebug("========== SEND EMAIL ==========");

                client = new SmtpClient("smtp.yandex.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("info@thaipattaraspa.com", "abc1234567890");

                client.Timeout = 10000;

                MailAddress from = new MailAddress("info@thaipattaraspa.com", "Error Log", System.Text.Encoding.UTF8);
                MailAddress to = new MailAddress("cloud_live@windowslive.com");

                /*GF.doDebug("INIT SMTP CLIENT");
                GF.doDebug("HOST : " + client.Host);
                GF.doDebug("PORT : " + client.Port.ToString());
                GF.doDebug("USERNAME : " + ((NetworkCredential)client.Credentials).UserName);
                GF.doDebug("PASSWORD : " + ((NetworkCredential)client.Credentials).Password);
                GF.doDebug("SSL : " + client.EnableSsl.ToString());

                GF.doDebug("SETUP MESSAGE");*/
                message = new MailMessage(from, to);
                message.Body = "System Error on " + GF.NOW() + Environment.NewLine;
                message.Body += Environment.NewLine;

                string[] lines = File.ReadAllLines(GF.path);
                foreach (string line in lines)
                {
                    if (line.IndexOf("0x80004005") != -1 && (line.ToLower().IndexOf("превышен таймаут семафора") != -1 || line.ToLower().IndexOf("semaphore timeout period has expired") != -1))
                    {
                        halt = true;
                        break;
                    }
                    message.Body += line + Environment.NewLine;
                }

                if (halt)
                {
                    message.Dispose();
                    client.Dispose();
                    return;
                }

                message.Body += Environment.NewLine;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.Subject = "SMS ERROR !!";
                message.SubjectEncoding = System.Text.Encoding.UTF8;

                GF.doDebug("SENDING E-MAIL");

                client.SendCompleted += (ss, ee) =>
                {
                    GF.doDebug("E-MAIL SENT");
                    //MessageBox.Show("E-MAIL SENT !!");
                    Program.waitHandle.Set();

                    // CLEAN UP
                    GF.doDebug("========== CLEAN UP ===========");
                    message.Dispose();
                    client.Dispose();
                };

                client.SendAsync(message, "SEND E-MAIL");
                //client.Send(message);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "SEND EMAIL ERROR");
            }
        }

        public static bool isValidInt32(String inStr)
        {
            int tmp;
            if (!Int32.TryParse(inStr, out tmp))
            {
                MessageBox.Show("Value must be Number\r\nAND\r\nValue must be between -2,147,483,648 and 2,147,483,647 !!", "ERROR !!");
                return false;
            }
            else return true;
        }
    }
}
