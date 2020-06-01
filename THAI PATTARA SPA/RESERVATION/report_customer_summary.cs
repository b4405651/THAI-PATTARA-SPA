using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.RESERVATION
{
    public partial class report_customer_summary : Form
    {
        public report_customer_summary()
        {
            InitializeComponent();

            print_report.PrintClick += (s, e) => { print_report.url = "reservation/customer_summary/3/" + report_date.Text.Trim(); };
        }

        private void report_customer_summary_Load(object sender, EventArgs e)
        {
            report_date.Text = GF.TODAY();
            report_date.Focus();
        }

        private void report_date_ValueChanged(object sender, EventArgs e)
        {
            ActiveControl = excelViewer;
            excelViewer.openURL("reservation/customer_summary/1/" + report_date.Text.Trim());
        }
    }
}
