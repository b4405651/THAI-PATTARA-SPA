using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Permissions;

namespace SPA_MANAGEMENT_SYSTEM.USER_CONTROL
{
    public partial class ExcelViewer : UserControl
    {
        string web_url = Properties.Settings.Default.webserver_url;

        [DllImport("ole32.dll")]
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        static extern int GetRunningObjectTable
            (uint reserved, out IRunningObjectTable pprot);
        [DllImport("ole32.dll")]
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        static extern int CreateBindCtx(uint reserved, out IBindCtx pctx);
        String m_ExcelFileName = "";

        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        public ExcelViewer()
        {
            InitializeComponent();
        }

        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        public void OpenFile(string filename, Form parent)
        {
            // Check the file exists
            if (!System.IO.File.Exists(filename)) throw new Exception();
            m_ExcelFileName = filename;
            // Load the workbook in the WebBrowser control
            this.ExcelPlaceHolder.Navigate(filename, false);

            parent.FormClosed += (sender, e) =>
            {
                try
                {
                    // Quit Excel and clean up.
                    if (GF.oWB != null)
                    {
                        GF.oWB.Close(true, Missing.Value, Missing.Value);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(GF.oWB);
                        GF.oWB = null;
                    }
                    if (GF.oXL != null)
                    {
                        GF.oXL.Quit();
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(GF.oXL);
                        GF.oXL = null;
                        System.GC.Collect();
                    }
                }
                catch
                {
                    MessageBox.Show("Failed to close the application");
                }
            };
        }

        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        public void openURL(String url, bool isRaw = false)
        {
            String UserAgent = "User-Agent: SMS";
            if(!isRaw) GF.showLoading();
            if (url.IndexOf("C:\\") == -1)
            {
                if (!isRaw) ExcelPlaceHolder.Navigate(web_url + url, null, null, UserAgent);
                else ExcelPlaceHolder.Navigate(url, null, null, UserAgent);
            }
            else ExcelPlaceHolder.Navigate(url, null, null, UserAgent);
        }

        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        public string currentURL()
        {
            return ExcelPlaceHolder.Url.ToString();
        }

        public void loadExcel(String FileName, Form parent)
        {
            /*try
            {
                MessageBox.Show("LOADING FILE : " + FileName);
                parent.FormClosed += (sender, e) =>
                {
                    GF.oDocument = null;
                };

                if (FileName.Length != 0)
                {
                    Object refmissing = System.Reflection.Missing.Value;
                    GF.oDocument = null;
                    //GF.showLoading(parent);
                    ExcelPlaceHolder.Navigate(FileName, ref refmissing, ref refmissing, ref refmissing, ref refmissing);
                }
            }
            catch (Exception e)
            {
                GF.closeLoading();
                MessageBox.Show(e.Message, "ERROR");
            }*/
        }

        private void ExcelPlaceHolder_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            /*// Creation of the workbook object
            if ((GF.oWB = RetrieveWorkbook(m_ExcelFileName)) == null) return;
            // Create the Excel.Application
            GF.oXL = (Microsoft.Office.Interop.Excel.Application)GF.oWB.Application;*/
            GF.closeLoading();
        }

        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        public Workbook RetrieveWorkbook(string xlfile)
        {
            IRunningObjectTable prot = null;
            IEnumMoniker pmonkenum = null;
            try
            {
                IntPtr pfetched = IntPtr.Zero;
                // Query the running object table (ROT)
                if (GetRunningObjectTable(0, out prot) != 0 || prot == null) return null;
                prot.EnumRunning(out pmonkenum); pmonkenum.Reset();
                IMoniker[] monikers = new IMoniker[1];
                while (pmonkenum.Next(1, monikers, pfetched) == 0)
                {
                    IBindCtx pctx; string filepathname;
                    CreateBindCtx(0, out pctx);
                    // Get the name of the file
                    monikers[0].GetDisplayName(pctx, null, out filepathname);
                    // Clean up
                    Marshal.ReleaseComObject(pctx);
                    // Search for the workbook
                    if (filepathname.IndexOf(xlfile) != -1)
                    {
                        object roval;
                        // Get a handle on the workbook
                        prot.GetObject(monikers[0], out roval);
                        return roval as Workbook;
                    }
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                // Clean up
                if (prot != null) Marshal.ReleaseComObject(prot);
                if (pmonkenum != null) Marshal.ReleaseComObject(pmonkenum);
            }
            return null;
        }
    }
}
