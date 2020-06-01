using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SPA_MANAGEMENT_SYSTEM.USER_CONTROL;
using System.IO;

namespace SPA_MANAGEMENT_SYSTEM.RESERVATION
{
    public partial class report_massage_end_day : Form
    {
        public report_massage_end_day()
        {
            InitializeComponent();
            print_report.PrintClick += (s, e) => { print_report.url = "reservation/end_day/3/" + report_date.Text.Trim(); };
        }

        private void report_end_day_Load(object sender, EventArgs e)
        {
            report_date.Text = GF.TODAY();
            report_date.Focus();
        }

        private void report_date_ValueChanged(object sender, EventArgs e)
        {
            ActiveControl = excelViewer;
            excelViewer.openURL("reservation/end_day/1/" + report_date.Text.Trim());
        }
    }
}
