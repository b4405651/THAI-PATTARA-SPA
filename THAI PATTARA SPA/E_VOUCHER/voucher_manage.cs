using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.VOUCHER
{
    public partial class voucher_manage : Form
    {
        public voucher_manage()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };

            expire_unit.Items.Add(new ComboItem(0, "MONTH"));
            expire_unit.Items.Add(new ComboItem(1, "YEAR"));
            expire_unit.SelectedIndex = 0;
        }

        private void voucher_manage_Load(object sender, EventArgs e)
        {
            manage_btn.Text = "ADD";

            String queryString = "SELECT TOP 1 * FROM GIFT_VOUCHER_CONFIG WHERE GIFT_VOUCHER_CONFIG_ID = 1";
            using (DataTable DT = DB.getS(queryString, null, "GET GIFT_VOUCHER_CONFIG", false))
            {
                foreach (DataRow row in DT.Rows)
                {
                    expire_amount.Text = row["EXPIRE_AMOUNT"].ToString();
                    expire_unit.SelectedIndex = Convert.ToInt32(row["EXPIRE_UNIT"].ToString());
                    manage_btn.Text = "UPDATE";
                }
            }
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if (expire_amount.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER THE EXPIRY DETAIL !!", "ERROR");
                expire_amount.Select();
                return;
            }
            
            GF.showLoading(this);

            string queryString = "SELECT * FROM GIFT_VOUCHER_CONFIG";

            using (DataTable DT = DB.getS(queryString, null, "CHECK GIFT_VOUCHER_CONFIG IF EXISTED", false))
            {
                if (DT.Rows.Count == 0)
                {
                    queryString = "INSERT INTO GIFT_VOUCHER_CONFIG ( EXPIRE_AMOUNT, EXPIRE_UNIT ) VALUES (";
                    queryString += expire_amount.Text.Trim() + ", ";
                    queryString += ((ComboItem)expire_unit.SelectedItem).Key.ToString() + "')";
                }

                if (DT.Rows.Count == 1)
                {
                    queryString = "UPDATE GIFT_VOUCHER_CONFIG SET ";
                    queryString += "EXPIRE_AMOUNT = " + expire_amount.Text.Trim() + ", ";
                    queryString += "EXPIRE_UNIT = " + ((ComboItem)expire_unit.SelectedItem).Key.ToString() + ", ";
                    queryString = queryString.Substring(0, queryString.Length - 2) + " ";
                    queryString += "WHERE GIFT_VOUCHER_CONFIG_ID = 1";
                }
            }

            DB.beginTrans();
            if (DB.set(queryString, manage_btn.Text.Trim() + " GIFT VOUCHER CONFIG"))
            {
                DB.close();
                MessageBox.Show("GIFT VOUCHER CONFIG IS " + (manage_btn.Text.Trim() == "ADD" ? "ADDE" : manage_btn.Text.Trim()) + "D !!", "COMPLETED");
                GF.closeLoading();
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show("ERROR INSERT INTO DATABASE !!", "ERROR");
                GF.closeLoading();
                return;
            }
        }

        private void expire_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void voucher_manage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Activate();
        }
    }
}
