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
    public partial class membercard_list : Form
    {
        public string customer_id = "";
        public membercard_list()
        {
            InitializeComponent();

            print_report.PrintClick += (s, e) => {
                String[] tmp = excelViewer.currentURL().Split('/');
                print_report.url = tmp[4] + "/" + tmp[5] + "/3/" + tmp[7];
            };
        }

        private void membercard_list_Load(object sender, EventArgs e)
        {
            this.Top = this.Left = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;

            ActiveControl = excelViewer;
            excelViewer.openURL("membercard/card_list/1/" + customer_id.Trim());
        }
    }
}
