using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.SPA
{
    public partial class spa_item_manage : Form
    {
        int currentItemID = -1;
        public spa_item_manage()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };
            GF.addKeyUp(this);

            item_detail.Text = "";
        }

        private void spa_item_manage_Load(object sender, EventArgs e)
        {
            if (manage_btn.Text == "UPDATE")
            {
                string queryString = @"SELECT
                    A.PRICE,
                    B.ITEM_CODE
                FROM SPA_ITEM A
                INNER JOIN ITEM B ON A.ITEM_ID = B.ITEM_ID
                WHERE SPA_ITEM_ID = " + GF.selected_id.ToString();
                using (DataTable DT = DB.getS(queryString, null, "GET SPA_ITEM[" + GF.selected_id.ToString() + "]", false))
                {
                    DataRow myDR = DT.Rows[0];
                    price.Text = myDR["PRICE"].ToString();
                    item_code.Text = myDR["ITEM_CODE"].ToString();
                    item_code.Focus();
                    SendKeys.Send("{ENTER}");
                }
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void item_code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (item_code.Text.Trim() != "")
                {
                    DataRow myDR = DB.getDataFromCode(item_code);
                    if (myDR == null)
                    {
                        MessageBox.Show("NO ITEM WITH THIS CODE !!", "ERROR");
                        item_code.Text = "";
                        return;
                    }
                    else
                    {
                        Int32.TryParse(myDR["ITEM_ID"].ToString(), out currentItemID);
                        item_detail.Text = myDR["ITEM_NAME"].ToString() + " (" + myDR["ITEM_TYPE_NAME"].ToString() + ")";
                        SendKeys.Send("{TAB}");
                    }
                }
            }
        }

        private void item_code_TextChanged(object sender, EventArgs e)
        {
            if (currentItemID != -1)
            {
                item_code.Text = "";
                currentItemID = -1;
                item_detail.Text = "";
            }
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            GF.showLoading(this);
            if (currentItemID == -1)
            {
                MessageBox.Show("PLEASE ENTER ITEM CODE !!", "ERROR");
                item_code.Focus();
                GF.closeLoading();
                return;
            }
            if (price.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER THE PRICE !!", "ERROR");
                price.Focus();
                GF.closeLoading();
                return;
            }
            int tmp;
            if (!Int32.TryParse(price.Text.Trim(), out tmp))
            {
                MessageBox.Show("PRICE MUST BE IN DIGIT !!", "ERROR");
                price.Select();
                GF.closeLoading();
                return;
            }
            string queryString = "SELECT * FROM SPA_ITEM WHERE ITEM_ID = " + currentItemID.ToString();
            if (manage_btn.Text == "UPDATE") queryString += " AND SPA_ITEM_ID != " + GF.selected_id.ToString();
            using (DataTable myDT = DB.getS(queryString, null, "CHECK IF SPA_ITEM EXIST", false))
            {
                if (myDT.Rows.Count > 0)
                {
                    MessageBox.Show("THIS SPA_ITEM IS ALREADY EXISTED !!", "ERROR");
                    GF.closeLoading();
                    DB.rollbackTrans();
                    item_code.Select();
                    return;
                }
            }

            DB.beginTrans();
            if (manage_btn.Text == "ADD")
            {
                queryString = "INSERT INTO SPA_ITEM (ITEM_ID, PRICE, LAST_CHANGE) VALUES (";
                queryString += currentItemID.ToString() + ", ";
                queryString += price.Text.Trim() + ", ";
                queryString += GF.modDate(GF.NOW()) + ")";
                if (!DB.set(queryString, "INSERT SPA_ITEM[" + currentItemID.ToString() + "]"))
                {
                    MessageBox.Show("ERROR INSERT INTO SPA_ITEM[" + currentItemID.ToString() + "] !!", "ERROR");
                    GF.closeLoading();
                    DB.rollbackTrans();
                    return;
                }
                else
                {
                    GF.closeLoading();
                    DB.close();

                    ((btn_dgv)this.Owner.Controls["btn_dgv"]).refresh_btn.PerformClick();
                    this.Close();
                }
            }
            if (manage_btn.Text == "UPDATE")
            {
                queryString = "UPDATE SPA_ITEM SET ";
                queryString += "PRICE = " + price.Text.Trim() + ", ";
                queryString += "LAST_CHANGE = " + GF.modDate(GF.NOW()) + " ";
                queryString += "WHERE ITEM_ID = " + currentItemID.ToString();
                if (!DB.set(queryString, "UPDATE SPA_ITEM[" + currentItemID.ToString() + "]"))
                {
                    MessageBox.Show("ERROR UPDATE SPA_ITEM[" + currentItemID.ToString() + "] !!", "ERROR");
                    GF.closeLoading();
                    DB.rollbackTrans();
                    return;
                }
                else
                {
                    GF.closeLoading();
                    DB.close();

                    ((btn_dgv)this.Owner.Controls["btn_dgv"]).refresh_btn.PerformClick();
                    this.Close();
                }
            }
        }

        private void spa_item_manage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Activate();
        }

        private void price_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
