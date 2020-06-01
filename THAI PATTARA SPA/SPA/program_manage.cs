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
    public partial class program_manage : Form
    {
        public program_manage()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };

            program_type_id.Items.Add(new ComboItem(-1, "== PROGRAM TYPE =="));
            program_type_id.SelectedIndex = 0;

            GF.enableButton(new_item_btn);
            GF.disableButton(edit_item_btn);
        }

        private void program_manage_Load(object sender, EventArgs e)
        {
            GF.showLoading(this);
            using (DataTable DT = DB.getS("SELECT * FROM SPA_PROGRAM_TYPE WHERE IS_USE = 1", null, "GET ALL SPA PROGRAM TYPE", false))
            {
                foreach (DataRow row in DT.Rows)
                {
                    program_type_id.Items.Add(new ComboItem(Int32.Parse(row["SPA_PROGRAM_TYPE_ID"].ToString()), row["SPA_PROGRAM_TYPE_NAME"].ToString()));
                }
            }
            GF.resizeComboBox(program_type_id);

            if (manage_btn.Text.Trim() == "UPDATE")
            {
                string queryString = @"
                SELECT TOP 1 * 
                FROM SPA_PROGRAM A
                INNER JOIN SPA_PROGRAM_TYPE B ON A.SPA_PROGRAM_TYPE_ID = B.SPA_PROGRAM_TYPE_ID
                WHERE SPA_PROGRAM_ID = " + GF.selected_id.ToString();
                using (DataTable DT = DB.getS(queryString, null, "GET SPA_PROGRAM[" + GF.selected_id.ToString() + "]", false))
                {
                    foreach(DataRow row in DT.Rows)
                    {
                        code.Text = row["CODE"].ToString();
                        program_type_id.Text = row["SPA_PROGRAM_TYPE_NAME"].ToString();
                        program_name.Text = row["PROGRAM_NAME"].ToString();
                        rus_name.Text = row["RUS_NAME"].ToString();
                        price.Text = row["PRICE"].ToString();
                        masseur_use.Text = row["MASSEUR_USE"].ToString();
                        description.Text = row["DESCRIPTION"].ToString();
                        hours.Text = row["HOURS"].ToString();
                        minutes.Text = row["MINUTES"].ToString();
                        apply_discount.Checked = (row["APPLY_DISCOUNT"].ToString() == "1" ? true : false);
                        select_oil.Checked = (row["SELECT_OIL"].ToString() == "1" ? true : false);
                        select_scrub.Checked = (row["SELECT_SCRUB"].ToString() == "1" ? true : false);

                        initDGV();
                        queryString = @"
                    SELECT D.ITEM_TYPE_NAME, C.ITEM_NAME, A.*, E.UNIT_NAME
                    FROM SPA_PROGRAM_ITEM A
                    INNER JOIN SPA_ITEM B ON A.SPA_ITEM_ID = B.SPA_ITEM_ID
                    INNER JOIN ITEM C ON B.ITEM_ID = C.ITEM_ID
                    INNER JOIN ITEM_TYPE D ON C.ITEM_TYPE_ID = D.ITEM_TYPE_ID
                    INNER JOIN UNIT E ON A.UNIT_ID = E.UNIT_ID
                    WHERE SPA_PROGRAM_ID = " + GF.selected_id.ToString();
                        using (DataTable tmpDT = DB.getS(queryString, null, "GET SPA_PROGRAM_ITEM FROM SPA_PROGRAM[" + GF.selected_id.ToString() + "]", false))
                        {
                            foreach (DataRow myRow in tmpDT.Rows)
                            {
                                DGV.Rows.Add(
                                    myRow["ITEM_TYPE_NAME"].ToString(),
                                    myRow["ITEM_NAME"].ToString(),
                                    myRow["AMOUNT"].ToString(),
                                    myRow["UNIT_NAME"].ToString(),
                                    ((myRow["customer_choose"].ToString() == "1") ? "YES" : "NO"),

                                    myRow["customer_choose"].ToString(),
                                    myRow["UNIT_ID"].ToString(),
                                    myRow["SPA_ITEM_ID"].ToString(),
                                    myRow["SPA_PROGRAM_ITEM_ID"].ToString()
                                );
                                DGV[1, DGV.Rows.Count - 1].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            }
                        }
                        GF.updateRowNum(DGV);
                        DGV.ClearSelection();
                        DGV.Visible = true;
                    }
                }
            }
            GF.closeLoading();
        }

        public void initDGV()
        {
            if (DGV.Columns.Count == 0)
            {
                DGV.Columns.Add("item_cat", "CATAGORY");
                DGV.Columns.Add("item_name", "ITEM NAME");
                DGV.Columns.Add("amount", "AMOUNT");
                DGV.Columns.Add("unit", "UNIT");
                DGV.Columns.Add("can_choose", "CAN CHOOSE ?");

                DGV.Columns.Add("customer_choose", "CUSTOMER_CHOOSE");
                DGV.Columns.Add("unit_id", "UNIT_ID");
                DGV.Columns.Add("spa_item_id", "SPA_ITEM_ID");
                DGV.Columns.Add("spa_program_item_id", "SPA_PROGRAM_ITEM_ID");

                DGV.Columns["customer_choose"].Visible = false;
                DGV.Columns["unit_id"].Visible = false;
                DGV.Columns["spa_item_id"].Visible = false;
                DGV.Columns["spa_program_item_id"].Visible = false;
            }
        }

        private void DGV_Paint(object sender, PaintEventArgs e)
        {
            DataGridView sndr = (DataGridView)sender;

            if (sndr.Rows.Count == 0) // <-- if there are no rows in the DataGridView when it paints, then it will create your message
            {
                using (Graphics grfx = e.Graphics)
                {
                    // create a white rectangle so text will be easily readable
                    grfx.FillRectangle(Brushes.Plum, new Rectangle(new Point(), new Size(sndr.Width, sndr.Height)));
                    // write text on top of the white rectangle just created
                    grfx.DrawString("--- NO ITEM ---", new Font("Microsoft Sans Serif", 18, FontStyle.Bold), Brushes.Black, new PointF((sndr.Width / 2) - 100, (sndr.Height / 2) - 15));
                }
            }
            else
            {
                foreach (DataGridViewColumn column in sndr.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
        }

        private void new_item_btn_Click(object sender, EventArgs e)
        {
            using (program_item item_page = new program_item())
            {
                item_page.id = -1;
                item_page.manage_btn.Text = "ADD";
                item_page.Owner = this;
                item_page.ShowDialog();
            }
        }

        private void edit_item_btn_Click(object sender, EventArgs e)
        {
            using (program_item item_page = new program_item())
            {
                item_page.id = Int32.Parse(DGV.SelectedRows[0].Cells["spa_program_item_id"].Value.ToString());
                item_page.manage_btn.Text = "UPDATE";
                item_page.Owner = this;
                item_page.ShowDialog();
            }
        }

        private void price_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if (code.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER THE CODE OF SPA PROGRAM !!", "ERROR");
                code.Focus();
                return;
            }

            if (((ComboItem)program_type_id.SelectedItem).Key == -1)
            {
                MessageBox.Show("PLEASE CHOOSE SPA PROGRAM TYPE", "ERROR");
                program_type_id.Focus();
                return;
            }

            if (program_name.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER SPA PROGRAM NAME", "ERROR");
                program_name.Select();
                return;
            }

            if(price.Text.Trim() == ""){
                MessageBox.Show("PLEASE ENTER THE PRICE", "ERROR");
                price.Select();
                return;
            }

            if (hours.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER THE NUMBER OF HOUR FOR SPA PROGRAM !!", "ERROR");
                hours.Select();
                return;
            }

            if (minutes.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER THE NUMBER OF MINUTE FOR SPA PROGRAM !!", "ERROR");
                minutes.Select();
                return;
            }

            if (masseur_use.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER THE NUMBER OF MASSEUR FOR SPA PROGRAM !!", "ERROR");
                masseur_use.Select();
                return;
            }

            /*if (DGV.Rows.Count == 0)
            {
                MessageBox.Show("PLEASE ADD SPA ITEM", "ERROR");
                return;
            }*/

            GF.showLoading(this);

            Dictionary<string, string> Params = new Dictionary<string, string>();
            //Params.Add("@program_name", program_name.Text);

            string queryString = "SELECT * FROM SPA_PROGRAM WHERE SPA_PROGRAM_TYPE_ID = " + ((ComboItem)program_type_id.SelectedItem).Key.ToString() + " AND PROGRAM_NAME = '" + program_name.Text + "'";
            if (manage_btn.Text.Trim() == "UPDATE") queryString += " AND SPA_PROGRAM_ID != " + GF.selected_id.ToString();

            using (DataTable DT = DB.getS(queryString, Params, "CHECK IF SPA_PROGRAM EXISTED", false))
            {

                DB.beginTrans();

                if (DT.Rows.Count > 0)
                {
                    MessageBox.Show("THIS SPA PROGRAM IS ALREADY EXISTED !!", "ERROR");
                    GF.closeLoading();
                    return;
                }
            }
            
            if (manage_btn.Text.Trim() == "ADD")
            {
                int spa_program_id = -1;
                queryString = "INSERT INTO SPA_PROGRAM ( CODE, SPA_PROGRAM_TYPE_ID, PROGRAM_NAME, RUS_NAME, MASSEUR_USE, DESCRIPTION, PRICE, HOURS, MINUTES, APPLY_DISCOUNT, SELECT_OIL, SELECT_SCRUB ) VALUES (";
                queryString += "'" + code.Text.Trim() + "', ";
                queryString += ((ComboItem)program_type_id.SelectedItem).Key.ToString() + ", ";
                queryString += "'" + program_name.Text.Trim() + "', ";
                queryString += "N'" + rus_name.Text.Trim() + "', ";
                queryString += masseur_use.Text.Trim() + ", ";
                queryString += "'" + description.Text.Trim() + "', ";
                queryString += price.Text.Trim() + ", ";
                queryString += hours.Text.Trim() + ", ";
                queryString += minutes.Text.Trim() + ", ";
                queryString += (apply_discount.Checked ? "1" : "0") + ", ";
                queryString += (select_oil.Checked ? "1" : "0") + ", ";
                queryString += (select_scrub.Checked ? "1" : "0") + ")";

                spa_program_id = DB.insertReturnID(queryString, "INSERT SPA_PROGRAM RETURN ID");
                if (spa_program_id != -1)
                {
                    foreach (DataGridViewRow row in DGV.Rows)
                    {
                        queryString = "INSERT INTO SPA_PROGRAM_ITEM (SPA_PROGRAM_ID, SPA_ITEM_ID, UNIT_ID, AMOUNT, CUSTOMER_CHOOSE) VALUES (";
                        queryString += spa_program_id.ToString() + ", ";
                        queryString += row.Cells["spa_item_id"].Value.ToString() + ", ";
                        queryString += row.Cells["unit_id"].Value.ToString() + ", ";
                        queryString += row.Cells["amount"].Value.ToString() + ", ";
                        queryString += row.Cells["customer_choose"].Value.ToString() + ")";
                        if (!DB.set(queryString, "INSERT SPA_PROGRAM_ITEM INTO SPA_PROGRAM[" + spa_program_id.ToString() + "]"))
                        {
                            MessageBox.Show("ERROR INSERT ITEM FOR SPA PROGRAM !!", "ERROR");
                            GF.closeLoading();
                            return;
                        }
                    }
                    DB.close();
                    GF.closeLoading();

                    ((btn_dgv)this.Owner.Controls["btn_dgv"]).refresh_btn.PerformClick();
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("ERROR INSERT SPA PROGRAM !!", "ERROR");
                    GF.closeLoading();
                    return;
                }
            }

            if (manage_btn.Text.Trim() == "UPDATE")
            {
                queryString = "UPDATE SPA_PROGRAM SET ";
                queryString += "CODE = '" + code.Text.Trim() + "', ";
                queryString += "SPA_PROGRAM_TYPE_ID = " + ((ComboItem)program_type_id.SelectedItem).Key.ToString() + ", ";
                queryString += "PROGRAM_NAME = '" + program_name.Text.Trim() + "', ";
                queryString += "RUS_NAME = N'" + rus_name.Text.Trim() + "', ";
                queryString += "MASSEUR_USE = " + masseur_use.Text.Trim() + ", ";
                queryString += "DESCRIPTION = '" + description.Text.Trim() + "', ";
                queryString += "PRICE = " + price.Text.Trim() + ", ";
                queryString += "HOURS = " + hours.Text.Trim() + ", ";
                queryString += "MINUTES = " + minutes.Text.Trim() + ", ";
                queryString += "APPLY_DISCOUNT = " + (apply_discount.Checked ? "1" : "0") + ", ";
                queryString += "SELECT_OIL = " + (select_oil.Checked ? "1" : "0") + ", ";
                queryString += "SELECT_SCRUB = " + (select_scrub.Checked ? "1" : "0") + " ";
                queryString += "WHERE SPA_PROGRAM_ID = " + GF.selected_id.ToString();
                if (DB.set(queryString, "UPDATE SPA_PROGRAM"))
                {
                    if (!DB.set("DELETE FROM SPA_PROGRAM_ITEM WHERE SPA_PROGRAM_ID = " + GF.selected_id.ToString(), "CLEAR SPA_PROGRAM_ITEM IN SPA_PROGRAM[" + GF.selected_id.ToString() + "]"))
                    {
                        MessageBox.Show("ERROR CLEARING SPA_PROGRAM_ITEM !!", "ERROR");
                        GF.closeLoading();
                        return;
                    }
                    foreach (DataGridViewRow row in DGV.Rows)
                    {
                        queryString = "INSERT INTO SPA_PROGRAM_ITEM (SPA_PROGRAM_ID, SPA_ITEM_ID, UNIT_ID, AMOUNT, CUSTOMER_CHOOSE) VALUES (";
                        queryString += GF.selected_id.ToString() + ", ";
                        queryString += row.Cells["spa_item_id"].Value.ToString() + ", ";
                        queryString += row.Cells["unit_id"].Value.ToString() + ", ";
                        queryString += row.Cells["amount"].Value.ToString() + ", ";
                        queryString += row.Cells["customer_choose"].Value.ToString() + ")";
                        if (!DB.set(queryString, "INSERT SPA_PROGRAM_ITEM INTO SPA_PROGRAM[" + GF.selected_id.ToString() + "]"))
                        {
                            MessageBox.Show("ERROR INSERT ITEM FOR SPA PROGRAM !!", "ERROR");
                            GF.closeLoading();
                            return;
                        }
                    }
                    DB.close();
                    GF.closeLoading();

                    ((btn_dgv)this.Owner.Controls["btn_dgv"]).refresh_btn.PerformClick();
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("ERROR UPDATE SPA PROGRAM !!", "ERROR");
                    GF.closeLoading();
                    return;
                }
            }
        }

        private void DGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DGV.ClearSelection();
            }
        }

        private void DGV_SelectionChanged(object sender, EventArgs e)
        {
            if (DGV.SelectedRows.Count == 1)
            {
                GF.disableButton(new_item_btn);
                GF.enableButton(edit_item_btn);
            }
            else
            {
                GF.enableButton(new_item_btn);
                GF.disableButton(edit_item_btn);
            }
        }

        private void masseur_use_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void program_manage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Activate();
        }

        private void code_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !(e.KeyChar == '.');
        }

        private void hours_Enter(object sender, EventArgs e)
        {
            hours.SelectAll();
        }

        private void minutes_Enter(object sender, EventArgs e)
        {
            minutes.SelectAll();
        }

        private void masseur_use_Enter(object sender, EventArgs e)
        {
            masseur_use.SelectAll();
        }

        private void hours_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void minutes_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
