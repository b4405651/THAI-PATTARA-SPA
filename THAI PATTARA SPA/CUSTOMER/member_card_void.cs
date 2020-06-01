using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.CUSTOMER
{
    public partial class member_card_void : Form
    {
        public int membercard_id = -1;
        public member_card_void()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if (reason.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER REASON !!", "ERROR");
                reason.Select();
                return;
            }

            GF.showLoading(this);
            DB.beginTrans();
            String queryString = "UPDATE MEMBERCARD SET IS_USE = 0, VOID_BY = " + GF.emp_id.ToString() + ", VOID_DATETIME = GETDATE(), VOID_REASON = '" + reason.Text.Trim() + "' WHERE MEMBERCARD_ID = " + membercard_id.ToString();
            if (!DB.set(queryString, "VOID MEMBERCARD[" + membercard_id.ToString() + "]", false))
            {
                MessageBox.Show("FAILED TO VOID MEMBERCARD !!", "ERROR");
                return;
            }

            queryString = @"
            SELECT 
                TOP 1 
                membercard_id
                ,bill_id
                ,customer_id
                ,membercard_type_id
                ,card_no
                ,issue_date
                ,CONVERT(VARCHAR,expire_date,103)
                ,balance
                ,last_use
                ,is_use
                ,void_by
                ,void_datetime
                ,void_reason
                ,price
                ,is_paid
            FROM MEMBERCARD WHERE MEMBERCARD_ID = " + membercard_id.ToString();

            using (DataTable DT = DB.getS(queryString, null, "GET DATA FROM MEMBERCARD[" + membercard_id.ToString() + "]", false))
            {
                foreach (DataRow row in DT.Rows)
                {
                    string member_code = row["CARD_NO"].ToString().Substring(0, 12);
                    int rand = new Random().Next(1, 10000);

                    string balance = DT.Rows[0]["balance"].ToString();
                    string price = DT.Rows[0]["price"].ToString();

                    queryString = "INSERT INTO MEMBERCARD (BILL_ID, CUSTOMER_ID, MEMBERCARD_TYPE_ID, CARD_NO, ISSUE_DATE, EXPIRE_DATE, BALANCE, LAST_USE, IS_USE, PRICE, IS_PAID) VALUES (";
                    queryString += row["BILL_ID"].ToString() + ", ";
                    queryString += row["CUSTOMER_ID"].ToString() + ", ";
                    queryString += row["MEMBERCARD_TYPE_ID"].ToString() + ", ";
                    queryString += "'" + member_code + rand.ToString("0000") + "', ";
                    queryString += "GETDATE(), ";
                    queryString += "'" + row["EXPIRE_DATE"].ToString() + "', ";
                    queryString += balance + ", ";
                    queryString += "'" + row["LAST_USE"].ToString() + "', ";
                    queryString += "1, ";
                    queryString += price + ", ";
                    queryString += row["IS_PAID"].ToString() + ")";

                    if (!DB.set(queryString, "DUPLICATE MEMBER CARD FROM [" + membercard_id.ToString() + "]"))
                    {
                        MessageBox.Show("CANNOT DUPLICATE MEMBER CARD !!", "ERROR");
                        GF.closeLoading();
                        return;
                    }

                    DB.close();
                    this.Close();
                }
            }
        }

        private void member_card_void_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Activate();
        }
    }
}
