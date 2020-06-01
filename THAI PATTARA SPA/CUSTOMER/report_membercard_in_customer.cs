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
    public partial class report_membercard_in_customer : Form
    {
        public report_membercard_in_customer()
        {
            InitializeComponent();

            customer_data.Mode = "CUSTOMER";
            customer_data.parentForm = this;

            membercard_id.Items.Add(new ComboItem(-1, "CHOOSE MEMBER CARD"));
            GF.resizeComboBox(membercard_id);
            membercard_id.SelectedIndex = 0;

            print_report.PrintClick += (s, e) => { print_report.url = "membercard/history/3/" + ((ComboItem)membercard_id.SelectedItem).Key.ToString(); };
        }

        private void report_membercard_in_customer_Load(object sender, EventArgs e)
        {
            
        }

        public void getReport()
        {
            ActiveControl = excelViewer;
            if (customer_data.currentID != -1) excelViewer.openURL("membercard/history/1/" + ((ComboItem)membercard_id.SelectedItem).Key.ToString());
            else excelViewer.openURL("about:blank", true);
        }

        public void getMemberCard()
        {
            membercard_id.Items.Clear();
            membercard_id.Items.Add(new ComboItem(-1, "CHOOSE MEMBER CARD"));
            String queryString = @"
            SELECT CARD_NO, MEMBERCARD_ID, BALANCE
            FROM MEMBERCARD
            WHERE CUSTOMER_ID = " + customer_data.currentID.ToString();
            using (DataTable DT = DB.getS(queryString, null, "GET MEMBERCARD IN CUSTOMER[" + customer_data.currentID.ToString() + "]", false))
            {
                foreach (DataRow row in DT.Rows)
                {
                    membercard_id.Items.Add(new ComboItem(Convert.ToInt32(row["MEMBERCARD_ID"].ToString()), row["CARD_NO"].ToString() + " BALANCE : " + GF.formatDecimal(Convert.ToInt32(row["BALANCE"].ToString()))));
                }
            }
            GF.resizeComboBox(membercard_id);
            membercard_id.SelectedIndex = 0;
        }

        private void membercard_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (membercard_id.SelectedIndex == 0) excelViewer.openURL("about:blank", true);
            else getReport();
        }
    }
}
