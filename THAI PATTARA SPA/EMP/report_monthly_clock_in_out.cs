using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.EMP
{
    public partial class report_monthly_clock_in_out : Form
    {
        public report_monthly_clock_in_out()
        {
            InitializeComponent();

            print_report.PrintClick += (s, e) =>
            {
                if (report_month.Text.Trim() != "" && report_year.Text.Trim().Length == 4)
                {
                    int month_no;
                    int year_no;
                    if (!Int32.TryParse(report_month.Text.Trim(), out month_no))
                    {
                        MessageBox.Show("INVALID MONTH !! PLEASE CHECK !!", "ERROR");
                        return;
                    }
                    if (month_no <= 0 || month_no > 12)
                    {
                        MessageBox.Show("INVALID MONTH !! PLEASE CHECK !!", "ERROR");
                        return;
                    }
                    if (!Int32.TryParse(report_year.Text.Trim(), out year_no))
                    {
                        MessageBox.Show("INVALID YEAR !! PLEASE CHECK !!", "ERROR");
                        return;
                    }

                    print_report.url = "employee/clock_in_out/3/" + month_no.ToString("00") + "/" + year_no.ToString("0000") + "/";
                }
            };
        }

        private void report_monthly_clock_in_out_Load(object sender, EventArgs e)
        {
            report_month.Focus();
        }

        private void getReport()
        {
            if (report_month.Text.Trim() != "" && report_year.Text.Trim().Length == 4)
            {
                int month_no;
                int year_no;
                if (!Int32.TryParse(report_month.Text.Trim(), out month_no))
                {
                    MessageBox.Show("INVALID MONTH !! PLEASE CHECK !!", "ERROR");
                    excelViewer.openURL("about:blank", true);
                    return;
                }
                if (month_no <= 0 || month_no > 12)
                {
                    MessageBox.Show("INVALID MONTH !! PLEASE CHECK !!", "ERROR");
                    excelViewer.openURL("about:blank", true);
                    return;
                }
                if (!Int32.TryParse(report_year.Text.Trim(), out year_no))
                {
                    MessageBox.Show("INVALID YEAR !! PLEASE CHECK !!", "ERROR");
                    excelViewer.openURL("about:blank", true);
                    return;
                }
                ActiveControl = excelViewer;
                excelViewer.openURL("employee/clock_in_out/1/" + month_no.ToString("00") + "/" + year_no.ToString("0000") + "/");
            }
            else
            {
                excelViewer.openURL("about:blank", true);
            }
        }

        private void report_month_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) getReport();
        }

        private void report_year_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) getReport();
        }

        private void report_month_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void report_year_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
