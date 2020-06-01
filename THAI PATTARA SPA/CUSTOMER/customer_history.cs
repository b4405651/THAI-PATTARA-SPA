using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.CUSTOMER
{
    public partial class customer_history : Form
    {
        public string customer_id = "";
        public customer_history()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };

            print_report.PrintClick += (s, e) => { print_report.url = "customer/history/3/" + customer_id.Trim(); };
        }

        private void customer_history_Load(object sender, EventArgs e)
        {
            this.Top = this.Left = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;

            ActiveControl = excelViewer;
            excelViewer.openURL("customer/history/1/" + customer_id.Trim());
        }
    }
}
