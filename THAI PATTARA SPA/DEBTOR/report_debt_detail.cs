using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.DEBTOR
{
    public partial class report_debt_detail : Form
    {
        public report_debt_detail()
        {
            InitializeComponent();

            String queryString = "SELECT * FROM DEBTOR_TYPE ORDER BY DEBTOR_TYPE_NAME";
            using (DataTable DT = DB.getS(queryString, null, "GET DEBTOR TYPE", false))
            {
                GF.closeLoading();
                debtor_type.Items.Add(new ComboItem(-1, "CHOOSE DEBTOR TYPE"));
                foreach (DataRow row in DT.Rows)
                {
                    debtor_type.Items.Add(new ComboItem(Convert.ToInt32(row["DEBTOR_TYPE_ID"].ToString()), row["DEBTOR_TYPE_NAME"].ToString().Trim()));
                }
            }
            GF.resizeComboBox(debtor_type);
            debtor_type.SelectedIndex = 0;

            status.Items.Add(new ComboItem(-99, "ALL"));
            status.Items.Add(new ComboItem(0, "UNPAID"));
            status.Items.Add(new ComboItem(1, "PAID"));
            status.Items.Add(new ComboItem(-1, "VOID"));
            status.SelectedIndex = 0;

            print_report.PrintClick += (s, e) =>
            {
                print_report.url = "debtor/debt_list/3/" + getParam();
            };
        }

        private void report_debt_detail_Load(object sender, EventArgs e)
        {
            
        }

        private void getReport()
        {
            if (debtor_type.SelectedIndex == 0 || debtor_id.SelectedIndex == 0) excelViewer.openURL("about:blank", true);
            else
            {
                ActiveControl = excelViewer;
                excelViewer.openURL("debtor/debt_list/1/" + getParam());
            }
        }

        string getParam()
        {
            String param = "";

            param += ((ComboItem)debtor_id.SelectedItem).Key.ToString() + "/";
            param += ((ComboItem)status.SelectedItem).Key.ToString() + "/";

            return param;
        }

        private void debtor_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            debtor_id.Items.Clear();
            String queryString = @"SELECT A.*, B.DEBTOR_TYPE_NAME, ISNULL(C.SUM_AMOUNT, 0) SUM_AMOUNT FROM
            (
	            (
		            SELECT DEBTOR_NAME NAME, TEL, DEBTOR_ID, DEBTOR_TYPE_ID, IS_USE FROM DEBTOR WHERE DEBTOR_TYPE_ID = 1
	            )
	            UNION ALL
	            (
		            SELECT B.CUSTOMER_NAME NAME, B.TEL, A.DEBTOR_ID, A.DEBTOR_TYPE_ID, A.IS_USE FROM DEBTOR A INNER JOIN CUSTOMER B ON A.TARGET_ID = B.CUSTOMER_ID AND A.DEBTOR_TYPE_ID = 2
	            )
	            UNION ALL
	            (
		            SELECT B.FULLNAME NAME, B.TEL, A.DEBTOR_ID, A.DEBTOR_TYPE_ID, A.IS_USE FROM DEBTOR A INNER JOIN EMPLOYEE B ON A.TARGET_ID = B.EMP_ID AND A.DEBTOR_TYPE_ID = 3
	            )
            ) A
            INNER JOIN DEBTOR_TYPE B ON A.DEBTOR_TYPE_ID = B.DEBTOR_TYPE_ID
            LEFT OUTER JOIN (
	            SELECT DEBTOR_ID, SUM(AMOUNT) SUM_AMOUNT FROM DEBTOR_DATA
	            WHERE IS_VOID = 0 AND IS_PAID = 0
	            GROUP BY DEBTOR_ID
            ) C ON A.DEBTOR_ID = C.DEBTOR_ID
            WHERE A.DEBTOR_TYPE_ID = " + ((ComboItem)debtor_type.SelectedItem).Key.ToString();
            using (DataTable DT = DB.getS(queryString, null, "GET DEBTOR", false))
            {
                GF.closeLoading();
                debtor_id.Items.Add(new ComboItem(-1, "ALL"));
                foreach (DataRow row in DT.Rows)
                {
                    debtor_id.Items.Add(new ComboItem(Convert.ToInt32(row["DEBTOR_ID"].ToString()), row["NAME"].ToString().Trim() + (row["TEL"].ToString() == "" ? "" : " - " + row["TEL"].ToString())));
                }
            }
            GF.resizeComboBox(debtor_id);
            debtor_id.SelectedIndex = 0;
        }

        private void debtor_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            getReport();
        }

        private void status_SelectedIndexChanged(object sender, EventArgs e)
        {
            getReport();
        }
    }
}
