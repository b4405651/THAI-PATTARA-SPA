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
    public partial class report_monthly_massage_hour_report : Form
    {
        public report_monthly_massage_hour_report()
        {
            InitializeComponent();

            String queryString = "SELECT * FROM EMPLOYEE WHERE EMP_STATUS = 1 AND EMP_DEPT_ID = 3";
            using (DataTable DT = DB.getS(queryString, null, "GET THERAPIST", false))
            {
                GF.closeLoading();
                report_master_id.Items.Add(new ComboItem(-1, "MASTER"));
                foreach (DataRow row in DT.Rows)
                {
                    //report_master_id.Items.Add(new ComboItem(Convert.ToInt32(row["EMP_ID"].ToString()), GF.getNickname(row["FULLNAME"].ToString().Trim())));
                    report_master_id.Items.Add(new ComboItem(Convert.ToInt32(row["EMP_ID"].ToString()), (row["NICKNAME"].ToString().Trim() == String.Empty ? row["FULLNAME"].ToString() : row["NICKNAME"].ToString()).Trim()));
                }
            }
            GF.resizeComboBox(report_master_id);
            report_master_id.SelectedIndex = 0;

            print_report.PrintClick += (s, e) => { 
                if (report_month.Text.Trim() != "" && report_year.Text.Trim().Length == 4 && report_master_id.SelectedIndex > 0)
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
                    
                    print_report.url = "reservation/monthly_massage_hour/3/" + month_no.ToString("00") + "/" + year_no.ToString("0000") + "/" + ((ComboItem)report_master_id.SelectedItem).Key.ToString(); 
                }
            };
        }

        private void report_monthly_massage_hour_report_Load(object sender, EventArgs e)
        {
            report_month.Focus();
        }

        private void getReport()
        {
            if (report_month.Text.Trim() != "" && report_year.Text.Trim().Length == 4 && report_master_id.SelectedIndex > 0)
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
                excelViewer.openURL("reservation/monthly_massage_hour/1/" + month_no.ToString("00") + "/" + year_no.ToString("0000") + "/" + ((ComboItem)report_master_id.SelectedItem).Key.ToString());
            }
            else
            {
                excelViewer.openURL("about:blank", true);
            }
        }

        private void report_month_KeyUp(object sender, KeyEventArgs e)
        {
            getReport();
        }

        private void report_year_KeyUp(object sender, KeyEventArgs e)
        {
            getReport();
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
