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
    public partial class report_therapist : Form
    {
        public report_therapist()
        {
            InitializeComponent();

            print_report.PrintClick += (s, e) => { print_report.url = "reservation/therapist/3/" + report_date.Text.Trim(); };
        }

        private void report_therapist_Load(object sender, EventArgs e)
        {
            report_date.Text = GF.TODAY();
            report_date.Focus();
        }

        private void report_date_ValueChanged(object sender, EventArgs e)
        {
            ActiveControl = excelViewer;
            excelViewer.openURL("reservation/therapist/1/" + report_date.Text.Trim());
        }
    }
}
