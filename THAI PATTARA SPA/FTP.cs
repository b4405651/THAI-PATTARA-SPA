using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Globalization;

namespace SPA_MANAGEMENT_SYSTEM
{
    public class FTP
    {
        public struct FileStruct
        {
            public string Flags;
            public string Owner;
            public string Group;
            public bool IsDirectory;
            public DateTime CreateTime;
            public long Size;
            public string Name;
        }
        public enum FileListStyle
        {
            UnixStyle,
            WindowsStyle,
            Unknown
        }
        static FtpWebRequest open(string Method, string fileName, string folderName)
        {
            GF.doDebug("OPENING CONNECTION TO ftp://" + Properties.Settings.Default.ftp_ip + "/" + folderName + "/" + fileName);
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + Properties.Settings.Default.ftp_ip + "/" + folderName + "/" + fileName);
            request.Method = Method;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential("SMS_FTP", "SMS_FTP");
            return request;
        }

        public static bool upload(string file_path, string new_fileName, string folderName)
        {
            GF.doDebug("UPLOADING " + new_fileName + " TO " + folderName);
            String card_front_ext = new_fileName.Substring(new_fileName.LastIndexOf("."));
            if (card_front_ext.Trim().ToLower().IndexOf("jpg") == -1 && card_front_ext.Trim().ToLower().IndexOf("png") == -1)
            {
                MessageBox.Show("FILE UPLOADING ACCEPTS ONLY .JPG OR .PNG !!", "ERROR");
                return false;
            }
            bool boolReturn = false;
            FtpWebRequest request = open(WebRequestMethods.Ftp.UploadFile, new_fileName, folderName);
            if (request != null)
            {
                // Copy the contents of the file to the request stream.
                byte[] fileContents = File.ReadAllBytes(file_path);

                request.RenameTo = new_fileName;
                request.ContentLength = fileContents.Length;

                try
                {
                    Stream requestStream;
                    using (requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(fileContents, 0, fileContents.Length);
                        requestStream.Close();

                        FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                        if (response.StatusCode == FtpStatusCode.ClosingData) boolReturn = true;
                        else
                        {
                            MessageBox.Show("(" + response.StatusCode.ToString() + ") " + response.StatusDescription);
                            boolReturn = false;
                        }

                        response.Close();
                    }
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }
            }
            return boolReturn;
        }

        public static Image download(string fileName, string folderName)
        {
            GF.doDebug("DOWNLOADING " + fileName + " FROM " + folderName);
            Image returnImage = null;
            FtpWebRequest request = open(WebRequestMethods.Ftp.DownloadFile, fileName, folderName);
            if (request != null)
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();

                if (response.StatusCode == FtpStatusCode.OpeningData)
                {
                    returnImage = Bitmap.FromStream(responseStream);
                }
                else
                {
                    MessageBox.Show("(" + response.StatusCode.ToString() + ") " + response.StatusDescription);
                    returnImage = null;
                }

                response.Close();
            }
            return returnImage;
        }

        public static bool delete(string fileName, string folderName)
        {
            GF.doDebug("DELETING " + fileName + " FROM " + folderName);
            bool boolReturn = false;
            FtpWebRequest request = open(WebRequestMethods.Ftp.DeleteFile, fileName, folderName);
            if (request != null)
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                if (response.StatusCode == FtpStatusCode.FileActionOK) boolReturn = true;
                else
                {
                    MessageBox.Show("(" + response.StatusCode.ToString() + ") " + response.StatusDescription);
                    boolReturn = false;
                }
            }
            return boolReturn;
        }

        public static String[] GetDetailForAllFiles(){
            try
            {
                FtpWebRequest ftpclientRequest = open(WebRequestMethods.Ftp.ListDirectoryDetails, "", "SMS_CARDS");
                ftpclientRequest.Proxy = null;
                using (FtpWebResponse response = ftpclientRequest.GetResponse() as FtpWebResponse)
                {
                    StreamReader sr = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8);
                    string Datastring = sr.ReadToEnd();

                    GF.doDebug("\r\n" + Datastring + "\r\n");

                    FileStruct[] list = GetList(Datastring);
                    //Console.WriteLine("------------After Parsing-----------");
                    List<String> outputStr = new List<String>();
                    foreach (FileStruct thisstruct in list)
                    {
                        if (!thisstruct.IsDirectory)
                            outputStr.Add(thisstruct.Name + "!!!" + thisstruct.Size.ToString() + "!!!" + thisstruct.CreateTime);
                    }
                    return outputStr.ToArray();
                }
            }
            catch (Exception e)
            {
                GF.doDebug(e.Message + "\r\n" + e.Data);
                return null;
            }
        }

        private static FileStruct[] GetList(string datastring)
        {
            List<FileStruct> myListArray = new List<FileStruct>(); 
            string[] dataRecords = datastring.Split('\n');
            FileListStyle _directoryListStyle = GuessFileListStyle(dataRecords);
            foreach (string s in dataRecords)
            {    
                if (_directoryListStyle != FileListStyle.Unknown && s != "")
                {
                    FileStruct f = new FileStruct();
                    f.Name = "..";
                    switch (_directoryListStyle)
                    {
                        case FileListStyle.UnixStyle:
                            f = ParseFileStructFromUnixStyleRecord(s);
                            break;
                        case FileListStyle.WindowsStyle:
;                            f = ParseFileStructFromWindowsStyleRecord(s);
                            break;
                    }
                    if (!(f.Name == "." || f.Name == ".."))
                    {
                        myListArray.Add(f);     
                    }    
                }
            }
            return myListArray.ToArray(); ;
        }

        private static FileStruct ParseFileStructFromWindowsStyleRecord(string Record)
        {
            ///Assuming the record style as 
            /// 02-03-04  07:46PM       <DIR>          Append
            FileStruct f = new FileStruct();
            string processstr = Record.Trim();
            string dateStr = processstr.Substring(0,8);      
            processstr = (processstr.Substring(8, processstr.Length - 8)).Trim();
            string timeStr = processstr.Substring(0, 7);
            processstr = (processstr.Substring(7, processstr.Length - 7)).Trim();
            //f.CreateTime = DateTime.Parse(dateStr + " " + timeStr);
            f.CreateTime = DateTime.Parse(dateStr + " " + timeStr, CultureInfo.GetCultureInfo("en-US"));
            if (processstr.Substring(0,5) == "<DIR>")
            {
                f.IsDirectory = true;    
                processstr = (processstr.Substring(5, processstr.Length - 5)).Trim();
            }
            else
            {
                f.Size = Convert.ToInt64(processstr.Substring(0, processstr.IndexOf(' ')).Trim());
                processstr = processstr.Remove(0, processstr.IndexOf(' ') + 1);
                f.IsDirectory = false;
            }   
            f.Name = processstr;  //Rest is name   
            return f;
        }

        public static FileListStyle GuessFileListStyle(string[] recordList)
        {
            foreach (string s in recordList)
            {
                if(s.Length > 10 && Regex.IsMatch(s.Substring(0,10),"(-|d)(-|r)(-|w)(-|x)(-|r)(-|w)(-|x)(-|r)(-|w)(-|x)"))
                {
                    return FileListStyle.UnixStyle;
                }      
                else if (s.Length > 8 && Regex.IsMatch(s.Substring(0, 8),  "[0-9][0-9]-[0-9][0-9]-[0-9][0-9]"))
                {
                    return FileListStyle.WindowsStyle;
                }   
            }
            return FileListStyle.Unknown;
        }

        private static FileStruct ParseFileStructFromUnixStyleRecord(string Record)
        {
            GF.doDebug(Record);
            ///Assuming record style as
            /// dr-xr-xr-x   1 owner    group               0 Nov 25  2002 bussys
            FileStruct f= new FileStruct();   
            string processstr = Record.Trim();        
            f.Flags = processstr.Substring(0,9);
            f.IsDirectory = (f.Flags[0] == 'd');  
            processstr =  (processstr.Substring(11)).Trim();
            _cutSubstringFromStringWithTrim(ref processstr,' ',0);   //skip one part
            f.Owner = _cutSubstringFromStringWithTrim(ref processstr,' ',0);
            f.Group = _cutSubstringFromStringWithTrim(ref processstr,' ',0);
            f.Size = Convert.ToInt64(_cutSubstringFromStringWithTrim(ref processstr, ' ', 0));
            //_cutSubstringFromStringWithTrim(ref processstr,' ',0);   //skip one part
            f.CreateTime = DateTime.Parse(_cutSubstringFromStringWithTrim(ref processstr,' ',8));     
            f.Name =  processstr;   //Rest of the part is name
            return f;
        }

        private static string _cutSubstringFromStringWithTrim(ref string s, char c, int startIndex)
        {
            int pos1 = s.IndexOf(c, startIndex);
            string retString = s.Substring(0,pos1);
            s = (s.Substring(pos1)).Trim();
            return retString;
        }
    }
}
