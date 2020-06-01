using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.CUSTOMER
{
    public partial class report_customer_history : Form
    {
        public report_customer_history()
        {
            InitializeComponent();

            customer_data.Mode = "CUSTOMER";
            customer_data.parentForm = this;

            print_report.PrintClick += (s, e) => { print_report.url = "customer/histor/3/" + customer_data.currentID.ToString(); };
        }

        private void report_customer_history_Load(object sender, EventArgs e)
        {

        }

        private void report_date_ValueChanged(object sender, EventArgs e)
        {
            getReport();
        }

        public void getReport()
        {
            ActiveControl = excelViewer;
            if (customer_data.currentID != -1) excelViewer.openURL("customer/history/1/" + customer_data.currentID.ToString());
            else excelViewer.openURL("about:blank", true);
        }
    }
}
