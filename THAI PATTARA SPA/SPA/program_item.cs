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
    public partial class program_item : Form
    {
        int _id = -1;
        public int id { get { return _id; } set { _id = value; } }

        public program_item()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };

            item_cat_id.Items.Add(new ComboItem(-1, "== CHOOSE =="));
            item_cat_id.SelectedIndex = 0;
            GF.resizeComboBox(item_cat_id);

            spa_item_id.Items.Add(new ComboItem(-1, "== CHOOSE =="));
            spa_item_id.SelectedIndex = 0;
            GF.resizeComboBox(spa_item_id);

            unit_id.Items.Add(new ComboItem(-1, "CHOOSE"));
            unit_id.SelectedIndex = 0;
            GF.resizeComboBox(unit_id);
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void program_item_Load(object sender, EventArgs e)
        {
            GF.showLoading(this);
            String queryString = @"
            SELECT DISTINCT C.* 
            FROM SPA_ITEM A
            INNER JOIN ITEM B ON A.ITEM_ID = B.ITEM_ID
            INNER JOIN ITEM_TYPE C ON B.ITEM_TYPE_ID = C.ITEM_TYPE_ID
            WHERE C.IS_USE = 1
            ORDER BY C.ITEM_TYPE_NAME ASC";
            using (DataTable DT = DB.getS(queryString, null, "GET SPA ITEM TYPE", false))
            {
                foreach (DataRow row in DT.Rows)
                {
                    item_cat_id.Items.Add(new ComboItem(Int32.Parse(row["ITEM_TYPE_ID"].ToString()), row["ITEM_TYPE_NAME"].ToString()));
                }
            }
            GF.resizeComboBox(item_cat_id);

            if (manage_btn.Text.Trim() == "UPDATE")
            {
                if (id == -1)
                {
                    DataGridViewRow row = ((program_manage)this.Owner).DGV.SelectedRows[0];
                    item_cat_id.Text = row.Cells["item_cat"].Value.ToString();
                    spa_item_id.Text = row.Cells["item_name"].Value.ToString();
                    amount.Text = row.Cells["amount"].Value.ToString();
                    unit_id.Text = row.Cells["unit"].Value.ToString();
                    can_choose.Checked = ((row.Cells["customer_choose"].Value.ToString() == "1") ? true : false);
                }
                else
                {
                    queryString = @"
                    SELECT TOP 1 D.ITEM_TYPE_NAME, C.ITEM_NAME, A.*, E.UNIT_NAME
                    FROM SPA_PROGRAM_ITEM A
                    INNER JOIN SPA_ITEM B ON A.SPA_ITEM_ID = B.SPA_ITEM_ID
                    INNER JOIN ITEM C ON B.ITEM_ID = C.ITEM_ID
                    INNER JOIN ITEM_TYPE D ON C.ITEM_TYPE_ID = D.ITEM_TYPE_ID
                    INNER JOIN UNIT E ON A.UNIT_ID = E.UNIT_ID
                    WHERE SPA_PROGRAM_ITEM_ID = " + id.ToString();
                    using (DataTable DT = DB.getS(queryString, null, "GET SPA PROGRAM ITEM[" + id.ToString() + "]", false))
                    {
                        foreach (DataRow row in DT.Rows)
                        {
                            item_cat_id.Text = row["ITEM_TYPE_NAME"].ToString();
                            spa_item_id.Text = row["ITEM_NAME"].ToString();
                            amount.Text = row["AMOUNT"].ToString();
                            unit_id.Text = row["UNIT_NAME"].ToString();
                            can_choose.Checked = ((row["CUSTOMER_CHOOSE"].ToString() == "1") ? true : false);
                        }
                    }
                }
            }

            GF.closeLoading();
        }

        private void item_cat_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int index = 1; index < spa_item_id.Items.Count; index++)
            {
                spa_item_id.Items.RemoveAt(index);
            }
            if (((ComboItem)item_cat_id.SelectedItem).Key != -1)
            {
                String queryString = @"
                SELECT A.SPA_ITEM_ID, B.* 
                FROM SPA_ITEM A
                INNER JOIN ITEM B ON A.ITEM_ID = B.ITEM_ID
                WHERE A.IS_USE = 1
                ORDER BY B.ITEM_NAME ASC";
                using (DataTable DT = DB.getS(queryString, null, "GET SPA ITEM", false))
                {
                    foreach (DataRow row in DT.Rows)
                    {
                        spa_item_id.Items.Add(new ComboItem(Int32.Parse(row["SPA_ITEM_ID"].ToString()), row["ITEM_NAME"].ToString()));
                    }
                }
            }
            if(spa_item_id.Items.Count > 0) GF.resizeComboBox(spa_item_id);
        }

        private void amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void item_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int index = 1; index < unit_id.Items.Count; index++)
            {
                unit_id.Items.RemoveAt(index);
            }
            if (((ComboItem)spa_item_id.SelectedItem).Key != -1)
            {
                String queryString = @"
                SELECT C.* 
                FROM SPA_ITEM A
                INNER JOIN ITEM B ON A.ITEM_ID = B.ITEM_ID
                INNER JOIN UNIT C ON B.UNIT_ID = C.UNIT_ID
                WHERE A.IS_USE = 1
                AND A.SPA_ITEM_ID = " + ((ComboItem)spa_item_id.SelectedItem).Key.ToString() + @"
                ORDER BY C.UNIT_NAME ASC";
                using (DataTable DT = DB.getS(queryString, null, "GET ITEM UNIT", false))
                {
                    foreach (DataRow row in DT.Rows)
                    {
                        unit_id.Items.Add(new ComboItem(Int32.Parse(row["UNIT_ID"].ToString()), row["UNIT_NAME"].ToString()));
                    }
                }
            }
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if (((ComboItem)item_cat_id.SelectedItem).Key == -1)
            {
                MessageBox.Show("PLEASE CHOOSE SPA ITEM CATEGORY !!", "ERROR");
                item_cat_id.Focus();
                return;
            }

            if (((ComboItem)spa_item_id.SelectedItem).Key == -1)
            {
                MessageBox.Show("PLEASE CHOOSE SPA ITEM !!", "ERROR");
                spa_item_id.Focus();
                return;
            }

            if (amount.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER AMOUNT OF ITEM !!", "ERROR");
                amount.Select();
                return;
            }

            if (((ComboItem)unit_id.SelectedItem).Key == -1)
            {
                MessageBox.Show("PLEASE CHOOSE ITEM UNIT !!", "ERROR");
                unit_id.Focus();
                return;
            }

            DataGridView DGV = ((program_manage)this.Owner).DGV;
            int foundAt = -1;

            foreach (DataGridViewRow row in DGV.Rows)
            {
                if (row.Cells["item_name"].Value.ToString() == ((ComboItem)spa_item_id.SelectedItem).Value)
                {
                    foundAt = row.Index;
                    break;
                }
            }

            if (foundAt != -1)
            {
                DGV.Rows[foundAt].Cells["item_cat"].Value = ((ComboItem)item_cat_id.SelectedItem).Value;
                DGV.Rows[foundAt].Cells["item_name"].Value = ((ComboItem)spa_item_id.SelectedItem).Value;
                DGV.Rows[foundAt].Cells["amount"].Value = amount.Text.Trim();
                DGV.Rows[foundAt].Cells["unit"].Value = ((ComboItem)unit_id.SelectedItem).Value;
                DGV.Rows[foundAt].Cells["can_choose"].Value = (can_choose.Checked) ? "YES" : "NO";

                DGV.Rows[foundAt].Cells["can_choose"].Value = (can_choose.Checked) ? "1" : "0";
                DGV.Rows[foundAt].Cells["unit_id"].Value = ((ComboItem)unit_id.SelectedItem).Key.ToString();
                DGV.Rows[foundAt].Cells["spa_item_id"].Value = ((ComboItem)spa_item_id.SelectedItem).Key.ToString();
                DGV.Rows[foundAt].Cells["spa_program_item_id"].Value = "-1";
            }
            else
            {
                if (DGV.Columns.Count == 0) ((program_manage)this.Owner).initDGV();
                DGV.Rows.Add(
                    ((ComboItem)item_cat_id.SelectedItem).Value,
                    ((ComboItem)spa_item_id.SelectedItem).Value,
                    amount.Text.Trim(),
                    ((ComboItem)unit_id.SelectedItem).Value,
                    ((can_choose.Checked) ? "YES" : "NO"),

                    ((can_choose.Checked) ? "1" : "0"),
                    ((ComboItem)unit_id.SelectedItem).Key.ToString(),
                    ((ComboItem)spa_item_id.SelectedItem).Key.ToString(),
                    "-1"
                );
                foundAt = DGV.Rows.Count - 1;
            }
            DGV[1, foundAt].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.Close();
        }

        private void program_item_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Activate();
        }
    }
}