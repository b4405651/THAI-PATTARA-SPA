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
    public partial class report_item_list : Form
    {
        public report_item_list()
        {
            InitializeComponent();

            String queryString = @"SELECT ITEM_TYPE_ID, ITEM_TYPE_NAME
            FROM ITEM_TYPE
            WHERE IS_USE = 1 AND ITEM_TYPE_ID >= 3  
            ORDER BY ITEM_TYPE_NAME";
            using (DataTable DT = DB.getS(queryString, null, "GET THERAPIST", false))
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

            print_report.PrintClick += (s, e) =>
            {
                print_report.url = "stock/item_list/3/" + getParam();
            };
        }

        private void report_item_list_Load(object sender, EventArgs e)
        {
            code.Focus();
        }

        private void getReport()
        {
            ActiveControl = excelViewer;
            excelViewer.openURL("stock/item_list/1/" + getParam());
        }

        string getParam()
        {
            String param = "";
            if (item_code.Checked) param += "0/";
            if (item_name.Checked) param += "1/";
            if (amount.Checked) param += "2/";

            if (asc.Checked) param += "0/";
            if (desc.Checked) param += "1/";

            param += ((ComboItem)report_cat_id.SelectedItem).Key.ToString() + "/";

            if (code.Text.Trim() == "") param += "_/";
            else param += code.Text.Trim() + "_/";

            return param;
        }

        private void report_cat_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            getReport();
        }

        private void code_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) getReport();
        }

        private void item_code_Click(object sender, EventArgs e)
        {
            getReport();
        }

        private void item_name_Click(object sender, EventArgs e)
        {
            getReport();
        }

        private void amount_Click(object sender, EventArgs e)
        {
            getReport();
        }

        private void asc_Click(object sender, EventArgs e)
        {
            getReport();
        }

        private void desc_Click(object sender, EventArgs e)
        {
            getReport();
        }
    }
}
