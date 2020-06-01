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
    public partial class report_customer_list : Form
    {
        public report_customer_list()
        {
            InitializeComponent();

            print_report.PrintClick += (s, e) => { print_report.url = "customer/customer_list/3" + criteria(); };
        }

        private void report_customer_list_Load(object sender, EventArgs e)
        {
            ActiveControl = excelViewer;
            excelViewer.openURL("customer/customer_list/1" + criteria());
        }

        private string criteria()
        {
            String str = "";

            if (only_member_cb.Checked) str += "/1"; else str += "/0";
            if (only_neighbor_cb.Checked) str += "/1"; else str += "/0";
            if (name_rdb.Checked) str += "/0";
            if (code_rdb.Checked) str += "/1";
            if (no_of_visit_rdb.Checked) str += "/2";
            if (asc_rdb.Checked) str += "/0";
            if (desc_rdb.Checked) str += "/1";

            return str;
        }

        private void getReport()
        {
            ActiveControl = excelViewer;
            excelViewer.openURL("customer/customer_list/1" + criteria());
        }

        private void name_rdb_CheckedChanged(object sender, EventArgs e)
        {
            if (name_rdb.Checked) getReport();
        }

        private void code_rdb_CheckedChanged(object sender, EventArgs e)
        {
            if (code_rdb.Checked) getReport();
        }

        private void asc_rdb_CheckedChanged(object sender, EventArgs e)
        {
            if (asc_rdb.Checked) getReport();
        }

        private void desc_rdb_CheckedChanged(object sender, EventArgs e)
        {
            if (desc_rdb.Checked) getReport();
        }

        private void only_member_cb_CheckedChanged(object sender, EventArgs e)
        {
            getReport();
        }

        private void no_of_visit_rdb_CheckedChanged(object sender, EventArgs e)
        {
            getReport();
        }

        private void only_neighbor_cb_CheckedChanged(object sender, EventArgs e)
        {
            getReport();
        }
    }
}
