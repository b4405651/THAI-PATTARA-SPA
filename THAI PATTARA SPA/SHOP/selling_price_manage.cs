using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.SHOP
{
    public partial class selling_price_manage : Form
    {
        int currentItemID = -1;
        public selling_price_manage()
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

        private void selling_price_manage_Load(object sender, EventArgs e)
        {
            if (manage_btn.Text == "UPDATE")
            {
                string queryString = @"SELECT
                    A.PRICE,
                    B.ITEM_CODE,
                    A.APPLY_DISCOUNT
                FROM ITEM_PRICE A
                INNER JOIN ITEM B ON A.ITEM_ID = B.ITEM_ID
                WHERE ITEM_PRICE_ID = " + GF.selected_id.ToString();
                using (DataTable DT = DB.getS(queryString, null, "GET ITEM_PRICE[" + GF.selected_id.ToString() + "]", false))
                {
                    DataRow myDR = DT.Rows[0];
                    price.Text = myDR["PRICE"].ToString();
                    item_code.Text = myDR["ITEM_CODE"].ToString();
                    item_code.Focus();
                    SendKeys.Send("{ENTER}");
                    apply_discount.Checked = (myDR["APPLY_DISCOUNT"].ToString() == "1" ? true : false);
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
                        Int32.TryParse((myDR["ITEM_PRICE_ID"] ?? "-1").ToString(), out GF.selected_id);

                        if (GF.selected_id > 0) manage_btn.Text = "UPDATE";
                        else manage_btn.Text = "ADD";

                        item_detail.Text = myDR["ITEM_NAME"].ToString() + " (" + myDR["ITEM_TYPE_NAME"].ToString() + ")";
                        apply_discount.Checked = ((myDR["APPLY_DISCOUNT"] ?? "").ToString() == "1");
                        price.Text = (myDR["PRICE"] ?? "").ToString();
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

            DB.beginTrans();
            string queryString = "SELECT * FROM ITEM_PRICE WHERE ITEM_ID = " + currentItemID.ToString();
            if (manage_btn.Text == "UPDATE") queryString += " AND ITEM_PRICE_ID != " + GF.selected_id.ToString();
            using (DataTable myDT = DB.getS(queryString, null, "CHECK IF ITEM PRICE EXIST", false))
            {
                if (myDT.Rows.Count > 0)
                {
                    if (myDT.Rows[0]["IS_USE"].ToString() == "0")
                    {
                        queryString = "UPDATE ITEM_PRICE SET IS_USE = 1, PRICE=" + price.Text.Trim() + ", APPLY_DISCOUNT=" + (apply_discount.Checked ? "1" : "0") + " WHERE ITEM_ID = " + currentItemID.ToString();
                        if (!DB.set(queryString, "RE-ENABLE ITEM_ID[" + currentItemID.ToString() + "]"))
                        {
                            MessageBox.Show("ERROR RE-ENABLE ITEM_PRICE[" + currentItemID.ToString() + "] !!", "ERROR");
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
                    else
                    {
                        MessageBox.Show("THIS ITEM IS ALREADY EXISTED !!", "ERROR");
                        GF.closeLoading();
                        DB.rollbackTrans();
                        item_code.Select();
                        return;
                    }
                }
            }
            
            if (manage_btn.Text == "ADD")
            {
                queryString = "INSERT INTO ITEM_PRICE (ITEM_ID, PRICE, LAST_CHANGE, APPLY_DISCOUNT) VALUES (";
                queryString += currentItemID.ToString() + ", ";
                queryString += price.Text.Trim() + ", ";
                queryString += GF.modDate(GF.NOW()) + ", ";
                queryString += (apply_discount.Checked ? "1" : "0") +")";
                if (!DB.set(queryString, "INSERT ITEM_PRICE[" + currentItemID.ToString() + "]"))
                {
                    MessageBox.Show("ERROR INSERT INTO ITEM_PRICE[" + currentItemID.ToString() + "] !!", "ERROR");
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
                queryString = "UPDATE ITEM_PRICE SET ";
                queryString += "PRICE = " + price.Text.Trim() + ", ";
                queryString += "LAST_CHANGE = " + GF.modDate(GF.NOW()) + ", ";
                queryString += "APPLY_DISCOUNT = " + (apply_discount.Checked ? "1" : "0") + " ";
                queryString += "WHERE ITEM_ID = " + currentItemID.ToString();
                if (!DB.set(queryString, "UPDATE ITEM_PRICE[" + currentItemID.ToString() + "]"))
                {
                    MessageBox.Show("ERROR UPDATE ITEM_PRICE[" + currentItemID.ToString() + "] !!", "ERROR");
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

        private void price_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void selling_price_manage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Activate();
        }
    }
}
