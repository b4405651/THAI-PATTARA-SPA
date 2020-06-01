using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.RESERVATION
{
    public partial class report_booking_cancel : Form
    {
        public report_booking_cancel()
        {
            InitializeComponent();

            print_report.PrintClick += (s, e) => { print_report.url = "reservation/cancel/3/" + report_date.Text.Trim(); };
        }

        private void report_booking_cancel_Load(object sender, EventArgs e)
        {
            report_date.Text = GF.TODAY();
            //"reservation/end_day/3/" + report_date.Text.Trim()
        }

        private void report_date_ValueChanged(object sender, EventArgs e)
        {
            ActiveControl = excelViewer;
            excelViewer.openURL("reservation/cancel/1/" + report_date.Text.Trim());
        }
    }
}
