using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.SHOP
{
    public partial class report_cashier_end_day : Form
    {
        public report_cashier_end_day()
        {
            InitializeComponent();

            print_report.PrintClick += (s, e) => { print_report.url = "cashier/end_day/3/" + report_date.Text.Trim(); };
        }

        private void report_end_day_Load(object sender, EventArgs e)
        {
            report_date.Text = GF.TODAY();
            report_date.Focus();
        }

        private void report_date_ValueChanged(object sender, EventArgs e)
        {
            ActiveControl = excelViewer;
            excelViewer.openURL("cashier/end_day/1/" + report_date.Text.Trim());
        }
    }
}
