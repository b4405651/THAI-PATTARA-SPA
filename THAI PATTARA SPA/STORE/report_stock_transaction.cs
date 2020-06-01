using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.STORE
{
    public partial class report_stock_transaction : Form
    {
        bool firstLoad = true;
        public report_stock_transaction()
        {
            InitializeComponent();

            String queryString = @"SELECT ITEM_TYPE_ID, ITEM_TYPE_NAME
            FROM ITEM_TYPE
            WHERE IS_USE = 1 AND ITEM_TYPE_ID >= 3  
            ORDER BY ITEM_TYPE_NAME";
            using (DataTable DT = DB.getS(queryString, null, "GET EMPLOYEE", false))
            {
                GF.closeLoading();
                report_cat_id.Items.Add(new ComboItem(-1, "ALL"));
                foreach (DataRow row in DT.Rows)
                {
                    report_cat_id.Items.Add(new ComboItem(Convert.ToInt32(row["ITEM_TYPE_ID"].ToString()), row["ITEM_TYPE_NAME"].ToString().Trim()));
                }
            }
            GF.resizeComboBox(report_cat_id);
            report_cat_id.SelectedIndex = 0;

            item_id.Items.Add(new ComboItem(-1, "ALL"));
            GF.resizeComboBox(item_id);
            item_id.SelectedIndex = 0;

            transaction_type.Items.Add(new ComboItem(-1, "ALL"));
            transaction_type.Items.Add(new ComboItem(0, "IN"));
            transaction_type.Items.Add(new ComboItem(1, "OUT"));
            transaction_type.SelectedIndex = 0;

            queryString = @"SELECT B.EMP_ID, B.FULLNAME
            FROM USERS A
            INNER JOIN EMPLOYEE B ON A.EMP_ID = B.EMP_ID
            WHERE A.IS_USE = 1
            AND B.EMP_STATUS = 1
            ORDER BY B.FULLNAME";
            using (DataTable DT = DB.getS(queryString, null, "GET EMPLOYEE", false))
            {
                GF.closeLoading();
                transaction_by.Items.Add(new ComboItem(-99, "ALL"));
                transaction_by.Items.Add(new ComboItem(-1, "SYSTEM / BILL"));
                transaction_by.Items.Add(new ComboItem(0, "S.A."));
                foreach (DataRow row in DT.Rows)
                {
                    transaction_by.Items.Add(new ComboItem(Convert.ToInt32(row["EMP_ID"].ToString()), row["FULLNAME"].ToString().Trim()));
                }
            }
            GF.resizeComboBox(transaction_by);
            transaction_by.SelectedIndex = 0;

            print_report.PrintClick += (s, e) =>
            {
                print_report.url = "stock/transaction/3/" + getParam();
            };
        }

        private void report_stock_transaction_Load(object sender, EventArgs e)
        {
            
        }

        private void getReport()
        {
            ActiveControl = excelViewer;
            excelViewer.openURL("stock/transaction/1/" + getParam());
        }

        string getParam()
        {
            if (firstLoad) return "";
            String param = "";

            param += ((ComboItem)report_cat_id.SelectedItem).Key.ToString() + "/";
            param += ((ComboItem)item_id.SelectedItem).Key.ToString() + "/";
            param += ((ComboItem)transaction_type.SelectedItem).Key.ToString() + "/";
            param += ((ComboItem)transaction_by.SelectedItem).Key.ToString() + "/";

            return param;
        }

        private void report_cat_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            item_id.Items.Clear();
            String queryString = @"SELECT
                B.ITEM_CODE,
                B.ITEM_NAME,
                A.PRICE,
                A.APPLY_DISCOUNT,
                B.ITEM_ID,
                C.ITEM_TYPE_NAME
            FROM ITEM_PRICE A
            INNER JOIN ITEM B ON A.ITEM_ID = B.ITEM_ID
            INNER JOIN ITEM_TYPE C ON B.ITEM_TYPE_ID = C.ITEM_TYPE_ID
            WHERE A.IS_USE = 1 AND B.IS_USE = 1 AND C.IS_USE = 1 AND B.ITEM_TYPE_ID >= 3 " + (((ComboItem)report_cat_id.SelectedItem).Key == -1 ? "" : "AND B.ITEM_TYPE_ID = " + ((ComboItem)report_cat_id.SelectedItem).Key.ToString()) + @" 
            ORDER BY C.ITEM_TYPE_NAME, CONVERT(FLOAT, B.ITEM_CODE)";
            using (DataTable DT = DB.getS(queryString, null, "GET ITEM", false))
            {
                item_id.Items.Add(new ComboItem(-1, "ALL"));
                foreach (DataRow row in DT.Rows)
                {
                    item_id.Items.Add(new ComboItem(Convert.ToInt32(row["ITEM_ID"].ToString()), row["ITEM_CODE"].ToString().Trim() + ". " + row["ITEM_NAME"].ToString().Trim()));
                }
            }
            GF.resizeComboBox(item_id);
            item_id.SelectedIndex = 0;
            getReport();
        }

        private void item_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            getReport();
        }

        private void transaction_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            getReport();
        }

        private void transaction_by_SelectedIndexChanged(object sender, EventArgs e)
        {
            getReport();
            if (firstLoad) firstLoad = false;
        }
    }
}
