using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Threading;

namespace SPA_MANAGEMENT_SYSTEM
{
    public partial class progress : Form
    {
        static List<String> FTPFiles, LOCALFiles, FilesToDownload, FilesToDelete;
        static long[] bytesTotal;
        int index = 0;
        int Mode = 0; // 0 = GET FILE SIZE ; 1 = DOWNLOAD
        string folderName = "SMS_CARDS";
        NetworkCredential credential = new NetworkCredential("SMS_FTP", "SMS_FTP");
        int currentFile = 1;
        public Boolean isOpening = true;

        delegate void SetTextCallback(string text);

        String remoteAddr = Properties.Settings.Default.ftp_ip;

        public progress()
        {
            InitializeComponent();
            GF.doDebug("===== MAIN FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== MAIN FORM :: " + this.Name + " IS CLOSED =====");
            };
            //remoteAddr = "localhost";
            //credential = new NetworkCredential("anonymous", "abc@def.ghi");
        }

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.file_no.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.file_no.Text = text;
            }
        }

        private void progress_Load(object sender, EventArgs e)
        {
            /*String[] test = FTP.GetDetailForAllFiles();
            foreach (String txt in test)
            {
                GF.doDebug(txt);
            }
            MessageBox.Show("FINISH");
            GF.doDebug("\r\n\r\n\r\n");*/
            backgroundTask.RunWorkerAsync();
        }

        private void backgroundTask_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!Directory.Exists(GF.localCardPath))
            {
                Directory.CreateDirectory(GF.localCardPath);
            }
            versionCheck();
        }

        private void backgroundTask_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (FilesToDownload.Count > 0 && Mode == 1) this.SetText("FILE : " + (index + 1).ToString() + "/" + FilesToDownload.Count);
            progressBar.Value = e.ProgressPercentage;
        }

        private void backgroundTask_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (FilesToDownload != null && FilesToDownload.Count > 0)
            {
                bool halt = false;
                this.Close();
                if (currentFile < FilesToDownload.Count)
                {
                    MessageBox.Show("ERROR DOWNLOAD FILE !!", "ERROR");
                    halt = true;
                }
                if (isOpening)
                {
                    using (login loginPage = new login())
                    {
                        loginPage.Owner = this;
                        if (!halt) loginPage.ShowDialog();
                        else loginPage.exit_btn.PerformClick();
                    }
                }
            }
            else
            {
                this.Close();
                if (isOpening)
                {
                    using (login loginPage = new login())
                    {
                        loginPage.Owner = this;
                        loginPage.ShowDialog();
                    }
                }
            }
        }

        void versionCheck()
        {
           this.SetText("getting local file list ...");
            // GET LOCAL FILE LIST
            GF.doDebug("========== LOCAL FILE @ " + GF.localCardPath + "==========");
            String[] tmp = Directory.GetFiles(GF.localCardPath);
            LOCALFiles = new List<string>();

            if (tmp.Length == 0) GF.doDebug("!!! NO LOCAL FILE !!!");
            else
            {
                foreach (String tmpStr in tmp)
                {
                    String tmp2 = tmpStr;
                    tmp2 = tmp2.Replace(GF.localCardPath, "");
                    LOCALFiles.Add(tmp2);
                    GF.doDebug("- " + tmp2);
                }
            }

            // GET FTP FILE LIST
            this.SetText("getting ftp file list ...");
            getFTPFileList();

            this.SetText("comparing files ...");
            GF.doDebug("========== COMPARE FTP FILE WITH LOCAL :: FOR DOWNLOAD OR UPDATE LOCAL ==========");
            FilesToDownload = new List<string>();
            foreach (String fileName in FTPFiles) // LOOP THROUGH ALL FTP FILE LIST ==> CHECK WHICH FILE IS NEEDED TO BE DOWNLOADED.
            {
                String debugStr = "[" + fileName + "] ";
                if (LOCALFiles.Count == 0)
                {
                    GF.doDebug(debugStr + "EMPTY LOCAL FILE ==> DOWNLOAD.");
                    FilesToDownload.Add(fileName); // IF NO LOCAL FILE ==> JUST EMPTY FOLDER ==> DOWNLOAD IT
                }
                else // NOT EMPTY FOLDER
                {
                    bool foundFile = false;
                    foreach (String file in LOCALFiles) // LOOP THROUGHT LOCAL FILE
                    {
                        if (fileName == file)
                        {
                            foundFile = true;
                            break;
                        }
                    }
                    if (!foundFile)
                    {
                        GF.doDebug(debugStr + "NOT FOUND LOCAL FILE ==> DOWNLOAD.");
                        FilesToDownload.Add(fileName); // IF FTP FILE IS NOT IN LOCAL FOLDER ==> DOWNLOAD IT
                    }
                    else // FTP FILE IS IN LOCAL FOLDER
                    {
                        // COMPARE LAST MODIFIED
                        FileInfo targetLocalfile = new FileInfo(GF.localCardPath + fileName);
                        DateTime lastModLocalFile = targetLocalfile.LastWriteTime;
                        DateTime lastModFTPFile;

                        FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + remoteAddr + "/" + folderName + "/" + fileName));
                        reqFTP.Credentials = credential;
                        reqFTP.KeepAlive = true;
                        reqFTP.Method = WebRequestMethods.Ftp.GetDateTimestamp;
                        reqFTP.UseBinary = true;
                        reqFTP.Proxy = null;
                        reqFTP.UsePassive = true;

                        using (FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse())
                        {
                            lastModFTPFile = response.LastModified;
                        }

                        // IF LAST MODIFIED OF FTP FILE IS NEWER THAN LOCAL FILE ==> DOWNLOAD IT.
                        if (lastModFTPFile > lastModLocalFile)
                        {
                            GF.doDebug(debugStr + "NEED UPDATE !! ==> DOWNLOAD");
                            GF.doDebug("FTP : " + lastModFTPFile.ToString() + " // LOCAL : " + lastModLocalFile.ToString());
                            FilesToDownload.Add(fileName);
                        }
                        else
                        {
                            // SAME LAST MODIFIED
                            // CHECK FILE SIZE. JUST IN CASE OF BROKEN FILE
                            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + remoteAddr + "/" + folderName + "/" + fileName));
                            reqFTP.Credentials = credential;
                            reqFTP.KeepAlive = true;
                            reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;
                            reqFTP.UseBinary = true;
                            reqFTP.Proxy = null;
                            reqFTP.UsePassive = true;
                            
                            using (FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse())
                            {
                                if (response.ContentLength != targetLocalfile.Length)
                                {
                                    GF.doDebug(debugStr + "SIZE IS NOT EQUAL !! ==> DOWNLOAD");
                                    GF.doDebug("FTP : " + response.ContentLength.ToString() + " // LOCAL : " + targetLocalfile.Length.ToString());
                                    FilesToDownload.Add(fileName);
                                }
                            }
                        }
                    }
                }
            }

            GF.doDebug("========== COMPARE LOCAL FILE WITH FTP :: FOR DELETE IF NO FILE ON FTP ==========");
            FilesToDelete = new List<string>();
            /*foreach (String fileName in LOCALFiles) // LOOP THROUGHT LOCAL FILE LIST ==> IF LOCAL FILE NOT ON FTP SERVER ==> DELETE IT.
            {
                bool foundFile = false;
                foreach (String file in FTPFiles)
                {
                    if (fileName == file)
                    {
                        foundFile = true;
                        break;
                    }
                }

                if (!foundFile)
                {
                    GF.doDebug("[ QUEUE FILE TO DELETE ] " + fileName);
                    FilesToDelete.Add(fileName);
                }
            }

            this.SetText("deleting unused local file ...");
            // DELETE LOCAL FILES
            foreach (String fileName in FilesToDelete)
            {
                System.IO.File.Delete(GF.localCardPath + fileName);
                GF.doDebug("[DELETED] " + GF.localCardPath + fileName);
            }*/

            this.SetText("connecting to server ...");
            syncFile();

            /*string old_version = "0";
            if (File.Exists(@"C:\" + folderName + @"\version.txt")) old_version = System.IO.File.ReadAllText(@"C:\" + folderName + @"\version.txt").Trim().Split('\n')[0];
            FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + remoteAddr + "/" + folderName + "/version.txt"));
            reqFTP.Credentials = credential;
            reqFTP.KeepAlive = true;
            reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
            reqFTP.UseBinary = true;
            reqFTP.Proxy = null;
            reqFTP.UsePassive = true;
            //reqFTP.UsePassive = false;

            using (FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    int Length = 2048;
                    Byte[] buffer = new Byte[Length];
                    int bytesRead = 0;
                    long allRead = 0;
                    //GF.doDebug("[ TEMP PATH ] >>> " + Path.GetTempPath());
                    using (FileStream writeStream = new FileStream(Path.GetTempPath() + "version.txt", FileMode.Create))
                    {
                        allRead += bytesRead = responseStream.Read(buffer, 0, buffer.Length);
                        while (bytesRead > 0)
                        {
                            writeStream.Write(buffer, 0, bytesRead);
                            allRead += bytesRead = responseStream.Read(buffer, 0, Length);
                        }
                        writeStream.Close();
                    }
                    response.Close();
                }
            }

            string version = System.IO.File.ReadAllText(Path.GetTempPath() + "version.txt").Replace("\r", "").Split('\n')[0];
            version = version.Trim();
            //GF.doDebug(Convert.ToInt32(version).ToString() + " : " + Convert.ToInt32(old_version).ToString());
            if (old_version == "0" || old_version == "")
            {
                GF.doDebug("NO FILE or FILES WAS NOT COMPLETE !! HAVE TO DOWNLOAD ALL FILES !!");
                getFileList();
                syncFile();
            }
            else if ((Convert.ToInt32(version) < Convert.ToInt32(old_version)))
            {
                GF.doDebug("FILES ARE NEEDED TO BE UPDATED !!");
                fileList = System.IO.File.ReadAllText(Path.GetTempPath() + "version.txt").Trim().Replace("\r", "").Split('\n');
                String[] tmp = new String[fileList.Length - 1];
                for (int index = 1; index < fileList.Length; index++)
                {
                    tmp[index - 1] = fileList[index];
                }
                fileList = new String[tmp.Length];
                for (int index = 0; index < tmp.Length; index++)
                {
                    Array.Copy(tmp, index, fileList, index, 1);
                }
                File.Delete(Path.GetTempPath() + "version.txt");
                syncFile();
            }
            else
            {
                GF.doDebug("FILES ARE UP TO DATE ^_^");
                is_updated_version = true;
            }
             * */
        }

        void syncFile()
        {
            if (FilesToDownload.Count > 0)
            {
                GF.doDebug("[ FILE LIST :: BEGIN ] TOTAL : " + FilesToDownload.Count.ToString() + " FILE" + (FilesToDownload.Count > 1 ? "S" : ""));
                int count = 1;
                foreach (String file in FilesToDownload)
                {
                    GF.doDebug(count.ToString() + ". " + file);
                    count++;
                }
                GF.doDebug("[ FILE LIST :: END ]");
                backgroundTask.ReportProgress(0);

                bytesTotal = new long[FilesToDownload.Count];

                foreach (String file in FilesToDownload)
                {
                    FtpWebRequest fileSizeFTP;
                    fileSizeFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + remoteAddr + "/" + folderName + "/" + file));
                    fileSizeFTP.Credentials = credential;
                    fileSizeFTP.KeepAlive = false;
                    fileSizeFTP.Method = WebRequestMethods.Ftp.GetFileSize;
                    fileSizeFTP.UseBinary = true;
                    fileSizeFTP.Proxy = null;
                    fileSizeFTP.UsePassive = true;

                    using (FtpWebResponse fileSizeResponse = (FtpWebResponse)fileSizeFTP.GetResponse())
                    {
                        bytesTotal[index] = fileSizeResponse.ContentLength;
                        fileSizeResponse.Close();
                    }
                            
                    index++;
                }

                // START DOWNLOAD FILE
                Mode = 1;
                index = 0;
                foreach (String file in FilesToDownload)
                {
                    backgroundTask.ReportProgress(0);
                    //GF.doDebug("FILE " + (index + 1).ToString() + " : " + file);
                    string uri = "ftp://" + remoteAddr + "/" + folderName + "/" + file;
                    Uri serverUri = new Uri(uri);
                    if (serverUri.Scheme != Uri.UriSchemeFtp)
                    {
                        return;
                    }

                    FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + remoteAddr + "/" + folderName + "/" + file));
                    reqFTP.Credentials = credential;
                    reqFTP.KeepAlive = true;
                    reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                    reqFTP.UseBinary = true;
                    reqFTP.Proxy = null;
                    reqFTP.UsePassive = true;

                    using (FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse())
                    {
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            int Length = 2048;
                            Byte[] buffer = new Byte[Length];
                            int bytesRead = 0;
                            long allRead = 0;
                            using (FileStream writeStream = new FileStream(@"C:\" + folderName + @"\" + file, FileMode.Create))
                            {
                                GF.doDebug("[ DOWNLOAD FILE ] " + "ftp://" + remoteAddr + "/" + folderName + "/" + file);
                                allRead += bytesRead = responseStream.Read(buffer, 0, buffer.Length);
                                //GF.doDebug("[" + file + "] " + ((int)(((float)allRead / (float)bytesTotal[index]) * 100.0)).ToString() + "% " + allRead.ToString() + "/" + bytesTotal[index].ToString());
                                backgroundTask.ReportProgress((int)(((float)allRead / (float)bytesTotal[index]) * 100.0));
                                while (bytesRead > 0)
                                {
                                    writeStream.Write(buffer, 0, bytesRead);
                                    allRead += bytesRead = responseStream.Read(buffer, 0, Length);
                                    backgroundTask.ReportProgress((int)(((float)allRead / (float)bytesTotal[index]) * 100.0));
                                    //GF.doDebug("[" + file + "] " + ((int)(((float)allRead / (float)bytesTotal[index]) * 100.0)).ToString() + "% " + allRead.ToString() + "/" + bytesTotal[index].ToString());
                                }
                                GF.doDebug("[ DOWNLOAD COMPLETED ] " + file);
                                writeStream.Close();
                            }
                            response.Close();
                        }
                    }
                    
                    while (true)
                    {
                        if (progressBar.Value == progressBar.Maximum)
                        {
                            Thread.Sleep(1000);
                            break;
                        }
                    }
                    index++;
                    //if (index == 2) return;
                    currentFile++;
                }
                        
                //GF.doDebug("PROGRESS CLOSE !!");
            }
        }

        void getFTPFileList()
        {
            FTPFiles = new List<string>();
            using (DataTable myDT = DB.getS("SELECT FRONT_CARD, BACK_CARD, ATTACH_PAPER FROM MEMBERCARD_TYPE WHERE IS_USE = 1", null, "GET MEMBERCARD FILES", false))
            {
                foreach (DataRow myDR in myDT.Rows)
                {
                    FTPFiles.Add(myDR["FRONT_CARD"].ToString());
                    FTPFiles.Add(myDR["BACK_CARD"].ToString());
                    FTPFiles.Add(myDR["ATTACH_PAPER"].ToString());
                }
            }

            using (DataTable myDT = DB.getS("SELECT CARD1, CARD2 FROM GIFT_CERTIFICATE_CONFIG", null, "GET GIFT_CERTIFICATE FILES", false))
            {
                foreach (DataRow myDR in myDT.Rows)
                {
                    FTPFiles.Add(myDR["CARD1"].ToString());
                    FTPFiles.Add(myDR["CARD2"].ToString());
                }
            }

            foreach (String tmpStr in FTPFiles)
            {
                GF.doDebug("- " + tmpStr);
            }

            /*StringBuilder result = new StringBuilder();
            WebResponse response = null;
            StreamReader reader = null;
            try
            {
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + remoteAddr + "/SMS_CARDS/"));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = credential;
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                reqFTP.Proxy = null;
                reqFTP.KeepAlive = true;
                reqFTP.UsePassive = true;
                using (response = reqFTP.GetResponse())
                {
                    using (reader = new StreamReader(response.GetResponseStream()))
                    {
                        string line = reader.ReadLine();
                        while (line != null)
                        {
                            result.Append(line);
                            result.Append("\n");
                            line = reader.ReadLine();
                        }
                        // to remove the trailing '\n'
                        result.Remove(result.ToString().LastIndexOf('\n'), 1);
                        result.Replace("version.txt\n", "");
                        String[] tmp = result.ToString().Split('\n');
                        GF.doDebug("\r\n========== FTP FILE ==========");
                        FTPFiles = new List<string>();
                        foreach (String tmpStr in tmp) {
                            FTPFiles.Add(tmpStr);
                            GF.doDebug("- " + tmpStr);
                        }
                        GF.doDebug("\r\n");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
                FTPFiles = null;
                GF.doDebug("[ GET FILE LIST :: ERROR ] >>> " + ex.Message);
                return false;
            }*/
        }
    }
}
