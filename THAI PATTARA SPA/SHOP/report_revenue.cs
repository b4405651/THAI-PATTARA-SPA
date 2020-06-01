using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using MigraDoc;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;

namespace SPA_MANAGEMENT_SYSTEM.SHOP
{
    public partial class report_revenue : Form
    {
        public report_revenue()
        {
            InitializeComponent();

            print_report.PrintClick += (s, e) => { print_report.url = "cashier/revenue/" + (GF.can_approve ? "1" : "0") + "/3/" + report_date.Text.Trim(); };
        }

        private void report_revenue_Load(object sender, EventArgs e)
        {
            report_date.Text = GF.TODAY();
            report_date.Focus();
        }

        private void report_date_ValueChanged(object sender, EventArgs e)
        {
            ActiveControl = excelViewer;
            excelViewer.openURL("cashier/revenue/" + (GF.can_approve ? "1" : "0") + "/1/" + report_date.Text.Trim());
        }
    }
}
