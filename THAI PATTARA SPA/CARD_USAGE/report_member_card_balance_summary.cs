using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.CARD_USAGE
{
    public partial class report_member_card_balance_summary : Form
    {
        public report_member_card_balance_summary()
        {
            InitializeComponent();

            print_report.PrintClick += (s, e) => { print_report.url = "card_usage/member_cards_balance/3/"; };
        }

        private void report_member_card_balance_summary_Load(object sender, EventArgs e)
        {
            ActiveControl = excelViewer;
            excelViewer.openURL("card_usage/member_cards_balance/1/");
        }
    }
}
