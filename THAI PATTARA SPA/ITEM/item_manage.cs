using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.ITEM
{
    public partial class item_manage : Form
    {
        public item_manage()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };

            unit_id.Items.Add(new ComboItem(-1, "== UNIT =="));
            unit_id.SelectedIndex = 0;

            item_type_id.Items.Clear();
            item_type_id.Items.Add(new ComboItem(-1, "== CATEGORY =="));
            string queryString = "SELECT * FROM ITEM_TYPE WHERE IS_USE = 1 ORDER BY ITEM_TYPE_NAME ASC";
            using (DataTable DT = DB.getS(queryString, null, "GET ITEM CATEGORIES", false))
            {
                foreach (DataRow row in DT.Rows)
                {
                    item_type_id.Items.Add(new ComboItem(Convert.ToInt32(row["ITEM_TYPE_ID"].ToString()), row["ITEM_TYPE_NAME"].ToString()));
                }
            }
            item_type_id.SelectedIndex = 0;
        }

        private void item_manage_Load(object sender, EventArgs e)
        {
            manage_btn.Top = barcode.Top + barcode.Height + 7;
            //GF.resizeMgmtForm(this);

            string queryString = "SELECT * FROM UNIT WHERE IS_USE = 1";
            using (DataTable myDT = DB.getS(queryString, null, "GET ALL UNIT", false))
            {
                foreach (DataRow row in myDT.Rows)
                {
                    unit_id.Items.Add(new ComboItem(Int32.Parse(row["UNIT_ID"].ToString()), row["UNIT_NAME"].ToString()));
                }
            }

            if (manage_btn.Text.Trim() == "UPDATE")
            {
                queryString = @"SELECT TOP 1 A.item_id, A.item_name, A.item_code, A.is_use, A.barcode, B.item_type_id, B.item_type_name, C.UNIT_NAME 
                FROM ITEM A 
                INNER JOIN ITEM_TYPE B ON A.item_type_id = B.item_type_id
                INNER JOIN UNIT C ON A.UNIT_ID = C.UNIT_ID
                WHERE A.item_id = " + GF.selected_id.ToString();
                using (DataTable myDT = DB.getS(queryString, null, "GET ITEM [" + GF.selected_id.ToString() + "]", false))
                {
                    item_type_id.Text = myDT.Rows[0]["item_type_name"].ToString();
                    item_code.Text = myDT.Rows[0]["item_code"].ToString();
                    item_name.Text = myDT.Rows[0]["item_name"].ToString();
                    unit_id.Text = myDT.Rows[0]["unit_name"].ToString();
                    barcode.Text = myDT.Rows[0]["barcode"].ToString();
                }
            }
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if (item_type_id.SelectedIndex == 0)
            {
                MessageBox.Show("PLEASE CHOOSE ITEM CATEGORY !!", "ERROR");
                item_type_id.Focus();
                return;
            }
            if (item_code.Text.Trim() == String.Empty)
            {
                MessageBox.Show("PLEASE ENTER ITEM CODE !!", "ERROR");
                item_code.Focus();
                return;
            }
            float tmp = 0;
            if (!float.TryParse(item_code.Text.Trim(), out tmp))
            {
                MessageBox.Show("ITEM CODE CAN BE ONLY NUMERIC AND PERIOD(.) !!", "ERROR");
                item_code.Focus();
                return;
            }
            if (item_name.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER ITEM NAME !!", "ERROR");
                item_name.Focus();
                return;
            }
            if (((ComboItem)unit_id.SelectedItem).Key == -1)
            {
                MessageBox.Show("PLEASE CHOOSE UNIT !!", "ERROR");
                unit_id.Focus();
                return;
            }
            GF.showLoading(this);
            DB.beginTrans();

            Dictionary<string, string> Params = new Dictionary<string, string>();
            /*Params.Add("@item_code", item_code.Text);
            Params.Add("@item_name", item_name.Text);*/

            string queryString = "SELECT * FROM ITEM WHERE (ITEM_CODE = '" + item_code.Text + "' OR ITEM_NAME = '" + item_name.Text + "'";
            if (barcode.Text.Trim().Length > 0)
            {
                queryString += " OR BARCODE = '" + barcode.Text + "'";
                //Params.Add("@barcode", barcode.Text);
            }
            queryString += ") AND ITEM_TYPE_ID = " + ((ComboItem)item_type_id.SelectedItem).Key.ToString();
            if (manage_btn.Text.Trim() == "UPDATE") queryString += " AND ITEM_ID != " + GF.selected_id.ToString();
            using (DataTable myDT = DB.getS(queryString, Params, "CHECK ITEM BEFORE EXECUTE", false))
            {
                if (myDT.Rows.Count > 0)
                {
                    MessageBox.Show("THIS ITEM IS ALREADY EXISTED.", "ERROR");
                    GF.closeLoading();
                    return;
                }
            }

            switch (manage_btn.Text.Trim())
            {
                case "ADD":
                    queryString = "INSERT INTO ITEM (ITEM_NAME, ITEM_CODE, ITEM_TYPE_ID, UNIT_ID, BARCODE) VALUES (N'" + item_name.Text.Trim() + "', '" + item_code.Text.Trim() + "', " + ((ComboItem)item_type_id.SelectedItem).Key.ToString() + ", " + ((ComboItem)unit_id.SelectedItem).Key.ToString() + ", '" + barcode.Text.Trim() + "')";
                    DB.beginTrans();
                    if (DB.set(queryString, "INSERT ITEM"))
                    {
                        GF.closeLoading();
                        DB.close();

                        ((btn_dgv)this.Owner.Controls["btn_dgv"]).refresh_btn.PerformClick();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("ERROR ADDING ITEM !!", "ERROR");
                        GF.closeLoading();
                        return;
                    }
                    break;

                case "UPDATE":
                    queryString = "UPDATE ITEM SET ITEM_NAME = N'" + item_name.Text.Trim() + "', ITEM_CODE = '" + item_code.Text.Trim() + "', ITEM_TYPE_ID = " + ((ComboItem)item_type_id.SelectedItem).Key.ToString() + ", UNIT_ID = " + ((ComboItem)unit_id.SelectedItem).Key.ToString() + ", BARCODE = '" + barcode.Text.Trim() + "' WHERE ITEM_ID = " + GF.selected_id.ToString();
                    DB.beginTrans();
                    if (DB.set(queryString, "UPDATE ITEM"))
                    {
                        GF.closeLoading();
                        DB.close();

                        ((btn_dgv)this.Owner.Controls["btn_dgv"]).refresh_btn.PerformClick();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("ERROR UPDATING ITEM !!", "ERROR");
                        GF.closeLoading();
                        return;
                    }
                    break;
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void item_manage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Activate();
        }

        private void item_type_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            item_code.Text = "";
            item_name.Text = "";
            unit_id.SelectedIndex = 0;
            barcode.Text = "";
            if (item_type_id.SelectedIndex == 0)
            {
                item_code.Enabled = false;
                item_name.Enabled = false;
                unit_id.Enabled = false;
                barcode.Enabled = false;
            }
            else
            {
                String queryString = "SELECT ISNULL(MAX(CONVERT(FLOAT, ITEM_CODE)), 0) + 1 NEXT_CODE FROM ITEM WHERE ITEM_TYPE_ID = " + ((ComboItem)item_type_id.SelectedItem).Key.ToString();
                using (DataTable DT = DB.getS(queryString, null, "GET MAX ITEM CODE", false))
                {
                    item_code.Enabled = true;
                    item_name.Enabled = true;
                    unit_id.Enabled = true;
                    barcode.Enabled = true;

                    item_code.Text = DT.Rows[0]["NEXT_CODE"].ToString();
                    item_name.Select();
                }
            }
        }
    }
}
