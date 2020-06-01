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
    public partial class report_debtor : Form
    {
        public report_debtor()
        {
            InitializeComponent();

            String queryString = "SELECT * FROM DEBTOR_TYPE ORDER BY DEBTOR_TYPE_NAME";
            using (DataTable DT = DB.getS(queryString, null, "GET DEBTOR TYPE", false))
            {
                GF.closeLoading();
                debtor_type.Items.Add(new ComboItem(-1, "ALL"));
                foreach (DataRow row in DT.Rows)
                {
                    debtor_type.Items.Add(new ComboItem(Convert.ToInt32(row["DEBTOR_TYPE_ID"].ToString()), row["DEBTOR_TYPE_NAME"].ToString().Trim()));
                }
            }
            GF.resizeComboBox(debtor_type);
            debtor_type.SelectedIndex = 0;

            print_report.PrintClick += (s, e) =>
            {
                print_report.url = "debtor/index/3/" + getParam();
            };
        }

        private void report_debtor_Load(object sender, EventArgs e)
        {
            
        }

        private void getReport()
        {
            ActiveControl = excelViewer;
            excelViewer.openURL("debtor/index/1/" + getParam());
        }

        string getParam()
        {
            String param = "";

            param += ((ComboItem)debtor_type.SelectedItem).Key.ToString() + "/";

            return param;
        }

        private void debtor_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            getReport();
        }
    }
}
