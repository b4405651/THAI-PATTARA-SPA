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
    public partial class report_finger_print_log : Form
    {
        public report_finger_print_log()
        {
            InitializeComponent();

            String queryString = "SELECT * FROM EMPLOYEE ORDER BY FULLNAME";
            using (DataTable DT = DB.getS(queryString, null, "GET EMPLOYEE", false))
            {
                GF.closeLoading();
                report_master_id.Items.Add(new ComboItem(-1, "ALL"));
                foreach (DataRow row in DT.Rows)
                {
                    report_master_id.Items.Add(new ComboItem(Convert.ToInt32(row["CODE"].ToString()), GF.getNickname(row["FULLNAME"].ToString().Trim())));
                }
            }
            GF.resizeComboBox(report_master_id);
            report_master_id.SelectedIndex = 0;

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

                    print_report.url = "employee/access_log/3/" + month_no.ToString("00") + "/" + year_no.ToString("0000") + "/" + ((ComboItem)report_master_id.SelectedItem).Key.ToString() + "/";
                }
            };
        }

        private void report_finger_print_log_Load(object sender, EventArgs e)
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
                excelViewer.openURL("employee/access_log/1/" + month_no.ToString("00") + "/" + year_no.ToString("0000") + "/" + ((ComboItem)report_master_id.SelectedItem).Key.ToString() + "/");
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

        private void report_master_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            getReport();
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
