using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.COUPON
{
    public partial class config_coupon_set_manage : Form
    {
        public int id = -1;
        String queryString = "";
        
        public config_coupon_set_manage()
        {
            InitializeComponent();

            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };

            btn_dgv.allowDeleteRow = true;

            spa_program_id.Items.Add(new ComboItem(-1, "ALL SPA PROGRAM"));
            queryString = "SELECT * FROM SPA_PROGRAM WHERE IS_USE = 1 ORDER BY CODE";
            using (DataTable DT = DB.getS(queryString, null, "GET ALL ACTIVE SPA PROGRAM", false))
            {
                foreach (DataRow row in DT.Rows)
                {
                    spa_program_id.Items.Add(new ComboItem(Convert.ToInt32(row["SPA_PROGRAM_ID"].ToString()), "[" + row["CODE"].ToString() + "] " + row["PROGRAM_NAME"].ToString()));
                }
            }
            spa_program_id.SelectedIndex = 0;
            GF.resizeComboBox(spa_program_id);

            expire_unit.Items.Add(new ComboItem(0, "MONTH"));
            expire_unit.Items.Add(new ComboItem(1, "YEAR"));
            expire_unit.SelectedIndex = 0;
            GF.resizeComboBox(expire_unit);
        }

        private void config_coupon_set_manage_Load(object sender, EventArgs e)
        {
            coupon_set_data_panel.Left = this.Width - coupon_set_data_panel.Width - 10;
            btn_dgv.rearrange(save_btn.Top + save_btn.Height + 7);
            btn_dgv.hideTopPanel();
            btn_dgv.paging_panel.Visible = false;
            btn_dgv.Left += 10;
            btn_dgv.DGV.Height += 90 + btn_dgv.paging_panel.Height;
            initDGV();
            loadData();
        }

        private void initDGV()
        {
            this.btn_dgv.DGV.Rows.Clear();

            if (btn_dgv.DGV.Columns.Count == 0)
            {
                this.btn_dgv.DGV.Columns.Add("spa_program_name", "SPA PROGRAM");
                this.btn_dgv.DGV.Columns.Add("spa_program_id", "spa_program_id");
                this.btn_dgv.DGV.Columns.Add("amount", "AMOUNT");
                this.btn_dgv.DGV.Columns["spa_program_id"].Visible = false;
                this.btn_dgv.DGV.Columns["spa_program_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private void loadData()
        {
            if (id > 0)
            {
                GF.showLoading(this);
                queryString = "SELECT COUPON_SET_NAME, PRICE, EXPIRE_AMOUNT, EXPIRE_UNIT FROM COUPON_SET_CONFIG WHERE COUPON_SET_CONFIG_ID = " + id.ToString();
                using (DataTable DT = DB.getS(queryString, null, "GET DETAIL OF COUPON_SET[" + id.ToString() + "]", false))
                {
                    coupon_set_name.Text = DT.Rows[0]["COUPON_SET_NAME"].ToString();
                    price.Text = DT.Rows[0]["PRICE"].ToString();
                    expire_amount.Text = DT.Rows[0]["EXPIRE_AMOUNT"].ToString();
                    int index = -1;
                    foreach (ComboItem item in expire_unit.Items)
                    {
                        index++;
                        if (item.Key.ToString() == DT.Rows[0]["EXPIRE_UNIT"].ToString())
                        {
                            expire_unit.SelectedIndex = index;
                            break;
                        }
                    }
                    if (index == -1)
                        expire_unit.SelectedIndex = 0;
                }

                btn_dgv.DGV.Rows.Clear();
                queryString = @"
                SELECT 
                    B.SPA_PROGRAM_ID, 
                    B.CODE,
                    B.PROGRAM_NAME,
                    A.AMOUNT
                FROM COUPON_SET_CONFIG_DETAIL A
                LEFT OUTER JOIN SPA_PROGRAM B ON A.SPA_PROGRAM_ID = B.SPA_PROGRAM_ID
                WHERE A.COUPON_SET_CONFIG_ID = " + id.ToString() + @" 
                ORDER BY CONVERT(BIGINT, B.CODE) ASC";

                using (DataTable DT = DB.getS(queryString, null, "GET CONFIG DETAIL OF COUPON SET[" + id.ToString() + "]", false))
                {
                    foreach (DataRow row in DT.Rows)
                    {
                        this.btn_dgv.DGV.Rows.Add(
                            "[" + row["CODE"].ToString() + "] " + row["PROGRAM_NAME"].ToString(),
                            row["SPA_PROGRAM_ID"].ToString(),
                            row["AMOUNT"].ToString()
                        );
                    }
                    
                    this.btn_dgv.DGV.ClearSelection();
                    GF.updateRowNum(btn_dgv.DGV, true);
                }
                GF.closeLoading();
            }
        }

        private void add_data_btn_Click(object sender, EventArgs e)
        {
            if (amount.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER AMOUNT !!", "ERROR");
                amount.Select();
                return;
            }
            bool found = false;
            foreach (DataGridViewRow row in btn_dgv.DGV.Rows)
            {
                if (row.Cells[0].Value.ToString() == spa_program_id.Text)
                {
                    row.Cells[2].Value = (Convert.ToInt32(row.Cells[2].Value) + Convert.ToInt32(amount.Text)).ToString();
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                this.btn_dgv.DGV.Rows.Add(
                    spa_program_id.Text,
                    ((ComboItem)spa_program_id.SelectedItem).Key,
                    amount.Text.Trim()
                );
            }
            GF.updateRowNum(this.btn_dgv.DGV);
            spa_program_id.SelectedIndex = 0;
            amount.Text = "1";
        }

        private void amount_KeyUp(object sender, KeyEventArgs e)
        {
            int result;
            e.Handled = !Int32.TryParse(amount.Text.Trim(), out result);
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (coupon_set_name.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER THE NAME OF THIS COUPON SET !!", "ERROR");
                coupon_set_name.Select();
                return;
            }
            
            if (expire_amount.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER THE NAME OF THIS COUPON SET !!", "ERROR");
                coupon_set_name.Select();
                return;
            }

            int tmp = -1;
            if (Int32.TryParse(expire_amount.Text.Trim(), out tmp) == false)
            {
                MessageBox.Show("EXPIRE AMOUNT MUST BE ONLY IN DIGIT !!", "ERROR");
                expire_amount.Select();
                return;
            }

            if (btn_dgv.DGV.Rows.Count == 0)
            {
                MessageBox.Show("NO DATA !!", "ERROR");
                return;
            }

            GF.showLoading(this);
            DB.beginTrans();

            if (id == -1)
            {
                queryString = "INSERT INTO COUPON_SET_CONFIG (COUPON_SET_NAME, PRICE, EXPIRE_AMOUNT, EXPIRE_UNIT) VALUES (";
                queryString += "'" + coupon_set_name.Text.Trim() + "', ";
                queryString += price.Text.Trim() + ", ";
                queryString += expire_amount.Text.Trim() + ", ";
                queryString += ((ComboItem)expire_unit.SelectedItem).Key.ToString();
                queryString += ")";

                id = DB.insertReturnID(queryString, "INSERT NEW COUPON SET");
                if (id == -1)
                {
                    MessageBox.Show("ERROR INSERT NEW COUPON SET !!", "ERROR");
                    GF.closeLoading();
                    return;
                }
            }

            String id_list = "";
            foreach (DataGridViewRow row in btn_dgv.DGV.Rows)
            {
                id_list += row.Cells["spa_program_id"].Value.ToString() + ",";
            }
            if (id_list.Trim() != "") id_list = id_list.Substring(0, id_list.Length - 1);

            queryString = "DELETE FROM COUPON_SET_CONFIG_DETAIL WHERE COUPON_SET_CONFIG_ID = " + id.ToString();
            if(id_list != "") queryString += " AND SPA_PROGRAM_ID NOT IN (" + id_list + ")";
            if (!DB.set(queryString, "DELETE UNUSED SPA PROGRAM SETTING FOR COUPON SET"))
            {
                MessageBox.Show("ERROR DELETING UNUSED SPA PROGRAM SETTING FOR COUPON SET !!", "ERROR");
                GF.closeLoading();
                return;
            }
            foreach (DataGridViewRow row in btn_dgv.DGV.Rows)
            {
                queryString = "SELECT * FROM COUPON_SET_CONFIG_DETAIL WHERE COUPON_SET_CONFIG_ID = " + id.ToString() + " AND SPA_PROGRAM_ID = " + row.Cells["SPA_PROGRAM_ID"].Value.ToString();
                using (DataTable DT = DB.getS(queryString, null, "CHECK IF SPA_PROGRAM_ID[" + row.Cells["SPA_PROGRAM_ID"].Value.ToString() + "] IN COUPON_SET_CONFIG[" + id.ToString() + "] EXISTED ?", false))
                {
                    if (DT.Rows.Count == 0)
                    {
                        queryString = "INSERT INTO COUPON_SET_CONFIG_DETAIL (COUPON_SET_CONFIG_ID, SPA_PROGRAM_ID, AMOUNT) VALUES (" + id.ToString() + ", " + row.Cells["SPA_PROGRAM_ID"].Value.ToString() + ", " + row.Cells["AMOUNT"].Value.ToString() + ")";
                        if (!DB.set(queryString, "INSERT NEW SPA PROGRAM SETTING FOR COUPON SET"))
                        {
                            MessageBox.Show("ERROR INSERT NEW SPA PROGRAM SETTING FOR COUPON SET !!", "ERROR");
                            GF.closeLoading();
                            return;
                        }
                    }
                    else
                    {
                        queryString = "UPDATE COUPON_SET_CONFIG_DETAIL SET AMOUNT = " + row.Cells["AMOUNT"].Value.ToString() + " WHERE COUPON_SET_CONFIG_ID = " + id.ToString() + " AND SPA_PROGRAM_ID = " + row.Cells["SPA_PROGRAM_ID"].Value.ToString();
                        if (!DB.set(queryString, "UPDATE AMOUNT OF SPA PROGRAM SETTING FOR COUPON SET"))
                        {
                            MessageBox.Show("ERROR UPDATING THE AMOUNT OF SPA PROGRAM SETTING FOR COUPON SET !!", "ERROR");
                            GF.closeLoading();
                            return;
                        }
                    }
                }
            }
            DB.close();
            GF.closeLoading();
            ((config_coupon_set)this.Owner).btn_dgv.refresh_btn.PerformClick();
            this.Close();
        }

        private void expire_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void price_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
