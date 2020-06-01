using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.STORE
{
    public partial class store_void : Form
    {
        int _id = -1;
        public int id { get { return _id; } set { _id = value; } }
        public store_void()
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
                reason.Focus();
                return;
            }
            else
            {
                GF.showLoading(this);
                DB.beginTrans();
                int type = -1;
                int amount = -1;
                int item_id = -1;

                using (DataTable DT = DB.getS(@"SELECT TOP 1 
                    A.* , B.TYPE
                FROM STORE_HISTORY_DETAIL A
                INNER JOIN STORE_HISTORY B ON A.STORE_HISTORY_ID = B.STORE_HISTORY_ID
                WHERE A.STORE_HISTORY_DETAIL_ID = " + id.ToString(), null, "GET STORE_HISTORY_DETAIL[" + id.ToString() + "]", false))
                {
                    foreach (DataRow row in DT.Rows)
                    {
                        type = Int32.Parse(row["TYPE"].ToString());
                        amount = Int32.Parse(row["AMOUNT"].ToString());
                        item_id = Int32.Parse(row["ITEM_ID"].ToString());
                    }
                }

                string queryString = "UPDATE STORE_HISTORY_DETAIL SET VOID_BY = " + GF.emp_id + ", VOID_REASON = '" + reason.Text.Trim() + "' WHERE STORE_HISTORY_DETAIL_ID = " + id.ToString();
                if (!DB.set(queryString, "VOID STORE_HISTORY_DETAIL[" + id.ToString() + "]"))
                {
                    DB.rollbackTrans();
                    MessageBox.Show("ERROR UPDATE STORE_HISTORY_DETAIL[" + id.ToString() + "] !!", "ERROR");
                    GF.closeLoading();
                    return;
                }
                else
                {
                    queryString = "UPDATE STORE SET LAST_CHANGE = GETDATE(), CURRENT_AMOUNT = CURRENT_AMOUNT";
                    if (type == 0) queryString += " - " + amount.ToString();
                    if (type == 1) queryString += " + " + amount.ToString();
                    queryString += " WHERE ITEM_ID = " + item_id.ToString();
                    if (!DB.set(queryString, "UPDATE STORE WITH ITEM_ID[" + item_id.ToString() + "]"))
                    {
                        DB.rollbackTrans();
                        MessageBox.Show("ERROR UPDATE STORE WITH ITEM_ID[" + item_id.ToString() + "] !!", "ERROR");
                        GF.closeLoading();
                        return;
                    }
                    else
                    {
                        GF.closeLoading();
                        DB.close();
                        ((store_transaction)this.Owner).loadGridData();
                        this.Close();
                    }
                }
            }
        }

        private void store_void_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Activate();
        }
    }
}
