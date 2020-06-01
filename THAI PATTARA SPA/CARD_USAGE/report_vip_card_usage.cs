using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.CARD_USAGE
{
    public partial class report_vip_card_usage : Form
    {
        public report_vip_card_usage()
        {
            InitializeComponent();

            print_report.PrintClick += (s, e) => { print_report.url = "card_usage/vip_card/3/" + card_no.Text.Trim(); };
        }

        private void card_no_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (card_no.Text.Trim() != "")
                {
                    ActiveControl = excelViewer;
                    excelViewer.openURL("card_usage/vip_card/1/" + card_no.Text.Trim());
                }
                else
                {
                    excelViewer.openURL("about:blank", true);
                }
            }
        }

        private void report_vip_card_usage_Load(object sender, EventArgs e)
        {
            card_no.Focus();
        }

        private void card_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
