using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.USER_CONTROL
{
    public partial class print_report : UserControl
    {
        public String url;
        public print_report()
        {
            InitializeComponent();
        }

        public delegate void PrintClickHandler(object sender, EventArgs e);
        public event PrintClickHandler PrintClick;

        public void OnPrintClick(EventArgs e)
        {
            if (PrintClick != null)
            {
                PrintClick(this, e);
            }
        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            OnPrintClick(EventArgs.Empty);
            object em = null;

            GF.showLoading((this.Parent as Panel).Parent as Form);
            using (AxSHDocVw.AxWebBrowser wb = new AxSHDocVw.AxWebBrowser())
            {
                wb.CreateControl();
                wb.Left = -1000;
                wb.Top = -1000;
                wb.Navigate(Properties.Settings.Default.webserver_url + url);
                for (; wb.ReadyState != SHDocVw.tagREADYSTATE.READYSTATE_COMPLETE; )
                {
                    System.Windows.Forms.Application.DoEvents();
                }
                GF.closeLoading();
                try
                {
                    SHDocVw.OLECMDF eQuery = wb.QueryStatusWB(SHDocVw.OLECMDID.OLECMDID_PAGESETUP);
                    wb.ExecWB(SHDocVw.OLECMDID.OLECMDID_PAGESETUP, SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_PROMPTUSER, ref em, ref em);
                    wb.ExecWB(SHDocVw.OLECMDID.OLECMDID_PRINT, SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_PROMPTUSER, ref em, ref em);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }
    }
}
