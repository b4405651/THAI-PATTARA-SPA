using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.SHOP
{
    public partial class report_misc_item : Form
    {
        public report_misc_item()
        {
            InitializeComponent();

            print_report.PrintClick += (s, e) => { print_report.url = "cashier/misc_item/3/" + getDateParam(); };
        }

        private void report_misc_item_Load(object sender, EventArgs e)
        {
            report_date2.Text = report_date1.Text = GF.TODAY();
            report_date1.Focus();
        }

        private void report_date_ValueChanged(object sender, EventArgs e)
        {
            ActiveControl = excelViewer;
            excelViewer.openURL("cashier/misc_item/1/" + getDateParam());
        }

        private string getDateParam()
        {
            DateTime dt1 = DateTime.ParseExact(report_date1.Text.Trim(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime dt2 = DateTime.ParseExact(report_date2.Text.Trim(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            if (DateTime.Compare(dt1, dt2) <= 0) return report_date1.Text.Trim() + "/" + report_date2.Text.Trim() + "/";
            else return report_date2.Text.Trim() + "/" + report_date1.Text.Trim() + "/";
        }
    }
}
