using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM
{
    public class DB
    {
        static SqlConnection conn;
        static SqlCommand command;
        static SqlTransaction trans = null;

        public static string localIP = "";
        public static string errorMsg;
        public static string lastQuery;
        public static string orderBy = "";
        //public static string DataSource = ((Properties.Settings.Default.db_ip == "") ? "localhost" : Properties.Settings.Default.db_ip) + "\\SQLEXPRESS";
        public static string UserID = "SMS_APP";
        public static string Password = "SMS_APP";
        public static string DBName = "SpaManagementSystem";
        static string DataSource = "";

        public static bool skipFileCheck = false;
        static bool useLocalHost = false;

        public static bool open()
        {
            if (localIP == "")
            {
                System.Net.IPHostEntry host;
                host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
                foreach (System.Net.IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        localIP = ip.ToString();
                        break;
                    }
                }
            }
            GF.doDebug("opening connection ...");
            errorMsg = "";

            if (localIP == "192.168.1.251" || Environment.MachineName == "SPA01-PC") DataSource = "localhost";
            else if (Properties.Settings.Default.db_ip == "") DataSource = DataSource = "85.30.232.165";//"192.168.1.251";
            else DataSource = Properties.Settings.Default.db_ip;

            if(useLocalHost) DataSource = "localhost";

            DataSource += "\\SQLEXPRESS,25529";

            SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder();
            connectionString.UserID = UserID;
            connectionString.Password = Password;
            connectionString.DataSource = DataSource;
            connectionString.InitialCatalog = DBName;
            connectionString.ConnectTimeout = 15;
            GF.doDebug("\r\n" + connectionString.ConnectionString + "\r\n");

            if (conn == null || conn.State == ConnectionState.Closed)
            {
                conn = new SqlConnection(connectionString.ConnectionString);
                try
                {
                    GF.doDebug("CREATING NEW SQL CONNECTION ...");
                    conn.Open();

                    GF.doDebug("SQL CONNECTION IS CREATED !!");
                }
                catch (Exception e)
                {
                    if (conn != null) conn.Dispose();
                    errorMsg = e.ToString();
                    MessageBox.Show("CANNOT CONNECT TO DATABASE.\r\n\r\nPLEASE TRY AGAIN A FEW MINUTES LATER ...", "ERROR");
                    GF.doDebug("could not open connection ... \r\n\r\n" + errorMsg);
                    System.Environment.Exit(0);
                    return false;
                }
                GF.doDebug("connection opened ...");
                return true;
            }

            GF.doDebug("CONNECTION STATE :: " + conn.State.ToString());
            
            return true;
        }

        public static bool beginTrans()
        {
            GF.doDebug("[TRANSACTION] ESTABLISHING TRANSACTION ...");
            try
            {
                if (conn == null)
                {
                    if (!open()) return false;
                }
                else if (conn.State == ConnectionState.Closed)
                {
                    if (!open()) return false;
                }
                GF.doDebug("[TRANSACTION] NULL CONNECTION IS NULL ? : " + (conn == null).ToString());
                GF.doDebug("[TRANSACTION] CONNECTION IS CLOSED ? : " + (conn.State == ConnectionState.Closed).ToString());
                if (conn.State == ConnectionState.Closed) conn.Close();
                if (trans != null) trans.Dispose();
                trans = conn.BeginTransaction(IsolationLevel.ReadUncommitted);
                GF.doDebug("[TRANSACTION] TRANSACTION IS ESTABLISHED");
                return true;
            }
            catch (Exception e)
            {
                if (conn != null) conn.Dispose();
                GF.doDebug("COULD NOT ESTABLISH TRANSACTION ... " + e.Message);
                return false;
            }
        }

        public static void rollbackTrans()
        {
            GF.doDebug("[TRANSACTION] Rollbacking ...");
            if (trans != null)
            {
                trans.Rollback();
                trans.Dispose();
                trans = null;
            }
            close();
            GF.doDebug("[TRANSACTION] Rollback complete ...");
        }

        public static bool close()
        {
            try
            {
                GF.doDebug("closing connection ...");
                String[] tmpStr = command.CommandText.Split(' ');
                GF.doDebug("trans == null[" + (trans == null).ToString() + "]");
                //GF.doDebug(">>>>> " + command.CommandText);
                if (tmpStr[0] == "SELECT")
                {
                    if (trans == null)
                    {
                        if (conn != null)
                        {
                            conn.Close();
                            conn.Dispose();
                            conn = null;
                            GF.doDebug("connection closed ...");
                        }
                    }
                }
                else
                {
                    GF.doDebug("[TRANSACTION] COMMITTING TRANSACTION ...");
                    GF.doDebug("[TRANSACTION] NULL TRANSACTION ? " + (trans == null).ToString());
                    if (trans != null)
                    {
                        trans.Commit();
                        trans.Dispose();
                        trans = null;
                        GF.doDebug("[TRANSACTION] TRANSACTION IS COMMITTED ...");
                    }
                    if (conn != null)
                    {
                        conn.Close();
                        conn.Dispose();
                        conn = null;
                        GF.doDebug("connection closed ...");
                    }
                    if (command != null) command.Dispose();
                }
            }
            catch (Exception e)
            {
                errorMsg = e.ToString();
                GF.doDebug("could not close connection ... " + errorMsg);
                if (trans != null) trans.Rollback();
                return false;
            }
            return true;
        }

        /*public static DataTable get(string Query, string logMsg, bool paging = true)
        {
            //if (!open("GET"))
            if (!open())
            {
                //RAISE ERROR
                return null;
            }
            else
            {
                GF.doDebug("[GET] getting data ... [ " + logMsg + " ]");
                GF.doDebug("[GET] >>> " + modifySelect(Query, paging));

                try
                {
                    using (command = new SqlCommand(modifySelect(Query, paging), conn, trans))
                    {
                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                        {
                            using (DataSet myDS = new DataSet())
                            {
                                //GF.closeLoading();
                                dataAdapter.Fill(myDS);
                                GF.doDebug("got data ...");
                                lastQuery = modifySelect(Query, paging);
                                GF.doDebug("HAS " + myDS.Tables[0].Rows.Count.ToString() + " DATA");
                                return myDS.Tables[0];
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    errorMsg = e.ToString();
                    GF.doDebug("could not get data ... \r\n\r\n" + errorMsg + "\r\n\r\n");
                    GF.doDebug(modifySelect(Query, paging));

                    MessageBox.Show("COULD NOT GET DATA ...\r\nPLEASE TRY AGAIN LATER :)", "ERROR");

                    return null;
                }
                finally
                {
                    close();
                }
            }
        }*/

        public static DataTable getS(string Query, Dictionary<string, string> Params, string logMsg, bool paging = true)
        {
            //if (!open("GET"))
            if (!open())
            {
                //RAISE ERROR
                return null;
            }
            else
            {
                GF.doDebug("[GET] getting data ... [ " + logMsg + " ]");
                GF.doDebug("[GET] >>> " + modifySelect(Query, paging));

                try
                {
                    using (command = new SqlCommand(modifySelect(Query, paging), conn, trans))
                    {
                        if (Params != null)
                        {
                            if (Params.Count > 0)
                            {
                                SqlParameter param;
                                foreach (KeyValuePair<string, string> entry in Params)
                                {
                                    param = new SqlParameter();
                                    Console.WriteLine(entry.Key + " : " + entry.Value);
                                    param.ParameterName = entry.Key;
                                    param.Value = entry.Value.Trim();
                                    command.Parameters.Add(param);
                                }
                            }
                        }

                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                        {
                            using (DataSet myDS = new DataSet())
                            {
                                //GF.closeLoading();

                                dataAdapter.Fill(myDS);
                                GF.doDebug("got data ...");
                                lastQuery = modifySelect(Query, paging);
                                GF.doDebug("HAS " + myDS.Tables[0].Rows.Count.ToString() + " DATA");
                                return myDS.Tables[0];
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    errorMsg = e.ToString();
                    Console.WriteLine(Query);
                    GF.doDebug("could not get data ... \r\n\r\n" + errorMsg + "\r\n\r\n");
                    GF.doDebug(modifySelect(Query, paging));

                    MessageBox.Show("COULD NOT GET DATA ...\r\nPLEASE TRY AGAIN LATER :)", "ERROR");

                    return null;
                }
                finally
                {
                    close();
                }
            }
        }

        public static Boolean executeSP(string queryString, String stringParams, String stringValues)
        {
            // BEGIN SET
            if (conn.State != ConnectionState.Open)
            {
                //RAISE ERROR
                /*errorMsg = "Connection is not opened !!";
                MessageBox.Show(errorMsg);*/
                if (!open()) return false;
            }
            if (trans == null)
            {
                //RAISE ERROR
                /*errorMsg = "Transaction is not established !!";
                MessageBox.Show(errorMsg);*/
                beginTrans();
            }
            
            // EXECUTE QUERY
            GF.doDebug("SETTING DATA ...");
            GF.doDebug("[EXECUTE SP] >>> " + queryString);

            try
            {
                using (command = new SqlCommand(queryString, conn, trans))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    String[] Values = stringValues.Split(',');
                    int index = -1;
                    foreach (String param in stringParams.Split(','))
                    {
                        //"@FirstName", SqlDbType.VarChar
                        index++;
                        command.Parameters.Add(param, SqlDbType.Int).Value = Values[index];
                    }
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                errorMsg = e.ToString();
                GF.doDebug("[SET] could not set data ... " + errorMsg);
                GF.doDebug(queryString);
                trans.Rollback();
                trans.Dispose();
                trans = null;
                GF.doDebug("[SET] TRANSACTION IS ROLLBACKED !!");
                return false;
            }
            GF.doDebug("[SET] data is set ...");
            lastQuery = queryString;
            saveLog(queryString, "EXECUTE SP " + queryString);

            return true;
        }

        public static Boolean set(string queryString, string logMsg, bool fromLog = false)
        {
            // BEGIN SET
            if (conn == null)
            {
                if (!open()) return false;
            }
            if (conn.State != ConnectionState.Open)
            {
                //RAISE ERROR
                /*errorMsg = "Connection is not opened !!";
                MessageBox.Show(errorMsg);
                return false;*/
                GF.doDebug("*** CONNECTION IS NOT OPENED !! ***");
                if (!open()) return false;
            }
            if (trans == null) beginTrans();
            
            // EXECUTE QUERY
            GF.doDebug("SETTING DATA ...");
            GF.doDebug("[SET] >>> " + queryString);

            try
            {
                using (command = new SqlCommand(queryString, conn, trans))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                errorMsg = e.ToString();
                GF.doDebug("could not set data ... " + errorMsg);
                GF.doDebug(queryString);
                trans.Rollback();
                trans.Dispose();
                trans = null;
                GF.doDebug("TRANSACTION IS ROLLBACKED !!");
                return false;
            }
            GF.doDebug("data is set ...");
            lastQuery = queryString;
            //saveLog(queryString, logMsg);

            return true;
        }

        public static DataRow getDataFromCode(TextBox sender)
        {
            string queryString = "";
            Dictionary<string, string> Params;
            switch (sender.Name.Trim().ToUpper())
            {
                case "ITEM_CODE":
                    queryString = @"SELECT
                A.ITEM_ID, A.ITEM_NAME, B.ITEM_TYPE_NAME, C.PRICE, C.APPLY_DISCOUNT, C.ITEM_PRICE_ID
                FROM ITEM A
                INNER JOIN ITEM_TYPE B ON A.ITEM_TYPE_ID = B.ITEM_TYPE_ID
                LEFT OUTER JOIN ITEM_PRICE C ON A.ITEM_ID = C.ITEM_ID
                WHERE ITEM_CODE LIKE @item_code";

                    Params = new Dictionary<string,string>();
                    Params.Add("@item_code", sender.Text);

                    using (DataTable myDT = getS(queryString, Params, "GET ITEM DATA FROM CODE", false))
                    {
                        if (myDT.Rows.Count == 0) return null;
                        else return myDT.Rows[0];
                    }
                case "EMPLOYEE_CODE":
                    queryString = @"SELECT * FROM EMPLOYEE WHERE CODE LIKE @emp_code";

                    Params = new Dictionary<string,string>();
                    Params.Add("@emp_code", sender.Text);

                    using (DataTable myDT = getS(queryString, Params, "GET EMPLOYEE DATA FROM CODE", false))
                    {
                        if (myDT.Rows.Count == 0) return null;
                        else return myDT.Rows[0];
                    }
                default:
                    return null;
            }
        }

        public static int getSellingPrice(int itemID)
        {
            String queryString = "SELECT PRICE FROM ITEM_PRICE WHERE ITEM_ID = " + itemID.ToString();

            Dictionary<string, string> Params = new Dictionary<string, string>();
            //Params.Add("@item_id", itemID.ToString());

            using (DataTable DT = getS(queryString, Params, "GET SELLING PRICE[" + itemID.ToString() + "]", false))
            {
                if (DT.Rows.Count == 0)
                {
                    MessageBox.Show("NO SELLING PRICE FOR THIS ITEM !!", "ERROR");
                    return -1;
                }
                else return Int32.Parse(DT.Rows[0]["PRICE"].ToString());
            }
        }

        public static int insertReturnID(string Query, string logMsg)
        {
            int returnValue = -1;
            // BEGIN SET
            if (conn == null)
            {
                if (!open()) return -1;
            }
            if (conn.State != ConnectionState.Open)
            {
                //RAISE ERROR
                errorMsg = "[insertReturnID] SET Connection is not opened !!";
                MessageBox.Show(errorMsg);
                return -1;
            }
            else if (trans == null)
            {
                //RAISE ERROR
                errorMsg = "[insertReturnID] SET Transaction is not established !!";
                MessageBox.Show(errorMsg);
                return -1;
            }
            else
            {
                // EXECUTE QUERY
                GF.doDebug("[insertReturnID] SETTING DATA ...");
                GF.doDebug("[INSERT RETURN ID] >>> " + Query);
                try
                {
                    using (command = new SqlCommand(Query + ";SELECT CAST(scope_identity() AS int)", conn, trans))
                    {
                        returnValue = (int)command.ExecuteScalar();
                    }
                }
                catch (Exception e)
                {
                    errorMsg = e.ToString();
                    GF.doDebug("[insertReturnID] could not set data ... " + errorMsg);
                    GF.doDebug(Query);
                    trans.Rollback();
                    trans.Dispose();
                    trans = null;
                    return returnValue;
                }
                GF.doDebug("[insertReturnID] data is set ...");
                lastQuery = Query;
                saveLog(Query, logMsg);

                return returnValue;
            }
        }

        private static void saveLog(String Query, String logMsg)
        {
            GF.doDebug("saving log ...");
            try
            {
                String logQueryString = @"INSERT INTO LOG (
                                            subject, query, log_datetime, user_id, emp_id, old_value
                                        ) VALUES (
                                            '" + logMsg + @"', 
                                            '" + Query.Replace("'", "''") + @"', 
                                            CURRENT_TIMESTAMP, 
                                            " + GF.user_id + @", 
                                            ";
                if (GF.emp_id == 0)
                {
                    logQueryString += "NULL";
                }
                else
                {
                    logQueryString += GF.emp_id;
                }
                logQueryString += @", '" + GF.old_value + @"'
                        )
                    ";
                GF.doDebug("[LOG] >>> " + logQueryString);
                //command = new SqlCommand(logQueryString, conn, trans);
                //command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                errorMsg = e.ToString();
                trans.Rollback();
                GF.doDebug("could not save log ... " + errorMsg);
                return;
            }
            GF.doDebug("log saved ...");
        }

        public static void logout()
        {
            GF.doDebug("LOGGING OUT ...");
            if (!beginTrans())
            {
                MessageBox.Show("COULD NOT BEGIN DATABASE TRANSACTION !!");
                return;
            }
            else
            {
                if (!set("UPDATE USERS SET last_login = CURRENT_TIMESTAMP WHERE user_id = " + GF.user_id.ToString(), "LOGOUT SUCCESS, UPDATE LAST LOGIN"))
                {
                    GF.doDebug("[ERROR] " + errorMsg);
                    MessageBox.Show("ERROR : " + errorMsg);
                }
                else
                {
                    GF.is_logged_in = false;
                    close();
                    GF.doDebug("LOG OUT COMPLETED.");
                }
            }
        }

        private static string modifySelect(string queryString, bool paging = true)
        {
            //queryString = queryString.Replace("'", "''");
            if (paging)
            {
                int rowStart = ((GF.currentPage - 1) * GF.recordPerPage) + 1;
                int rowEnd = ((GF.currentPage - 1) * GF.recordPerPage) + GF.recordPerPage;

                return "SELECT * FROM ( " + queryString + " ) AS RESULT WHERE RESULT.RowNum between " + rowStart.ToString() + " and " + rowEnd.ToString() + " " + orderBy;
            }
            else
            {
                return queryString;
            }
        }

        public static string insertRowNum(string pkColName, string queryString, bool paging = true)
        {
            orderBy = "";
            if (paging)
            {
                /*string rowNumString = " ROW_NUMBER() OVER (ORDER BY " + pkColName + ") as RowNum, ";
                string head = queryString.Substring(0, queryString.IndexOf("SELECT") + "SELECT".Length);
                string tail = queryString.Substring(queryString.IndexOf("SELECT") + "SELECT".Length);
                return head + rowNumString + tail*//* + ((orderBy != "") ? orderBy : "")*/;

                return "SELECT ROW_NUMBER() OVER (ORDER BY " + pkColName + ") as RowNum, * FROM (" + queryString + ") A";
            }
            else
            {
                return queryString;
            }
        }

        public static void initLocalVars()
        {
            try // INIT LOCAL VARS
            {
                using (DataTable myDT = DB.getS("SELECT * FROM APP_CONFIG", null, "GET CONFIG", false))
                {
                    DataRow myDR = myDT.Rows[0];

                    Properties.Settings.Default.db_ip = myDR["server_ip"].ToString();
                    Properties.Settings.Default.webserver_url = myDR["webserver_url"].ToString();
                    //Properties.Settings.Default.webserver_url = "http://" + myDR["server_ip"].ToString() + "/index.php/";
                    Properties.Settings.Default.ftp_ip = myDR["ftp_ip"].ToString();
                    Properties.Settings.Default.encoder_ip = myDR["encoder_ip"].ToString();
                    if (Properties.Settings.Default.attachment_path == @"C:\") Properties.Settings.Default.attachment_path = myDR["attachment_path"].ToString();
                    Properties.Settings.Default.money_unit = myDR["money_unit"].ToString();
                    Properties.Settings.Default.barcode_printer_name = myDR["barcode_printer_name"].ToString();
                    Properties.Settings.Default.card_printer_name = myDR["card_printer_name"].ToString();
                    Properties.Settings.Default.pdf_printer = myDR["pdf_printer_name"].ToString();
                    Properties.Settings.Default.invoice_printer_name = myDR["invoice_printer_name"].ToString();

                    foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                    {
                        if (printer.ToUpper().IndexOf(myDR["card_printer_name"].ToString().ToUpper()) != -1) Properties.Settings.Default.card_printer_name = printer;
                        if (printer.ToUpper().IndexOf(myDR["attachment_printer_name"].ToString().ToUpper()) != -1) Properties.Settings.Default.attachment_printer_name = printer;
                        if (printer.ToUpper().IndexOf(myDR["photo_printer_name"].ToString().ToUpper()) != -1) Properties.Settings.Default.photo_printer_name = printer;
                        if (printer.ToUpper().IndexOf(myDR["invoice_printer_name"].ToString().ToUpper()) != -1) Properties.Settings.Default.invoice_printer_name = printer;
                        if (printer.ToUpper().IndexOf(myDR["barcode_printer_name"].ToString().ToUpper()) != -1) Properties.Settings.Default.barcode_printer_name = printer;
                    }
                    if (Environment.MachineName.ToUpper().IndexOf("CLOUD") != -1) Properties.Settings.Default.card_printer_name = "Bullzip PDF Printer";
                }
            }
            catch (Exception e_)
            {
                MessageBox.Show(e_.Message);
                Application.Exit();
            }
        }
    }
}
