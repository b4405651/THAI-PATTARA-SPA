using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.PROMOTION
{
    public partial class promotion_manage : Form
    {
        public promotion_manage()
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

        private void promotion_manage_Load(object sender, EventArgs e)
        {
            if (manage_btn.Text.Trim() == "UPDATE")
            {
                string queryString = "SELECT TOP 1 PROMOTION_ID, PROMOTION_NAME, DISCOUNT_AMOUNT, DISCOUNT_UNIT, CONVERT(VARCHAR,START_DATE,103) START_DATE, CONVERT(VARCHAR,END_DATE,103) END_DATE, OVERRIDE_APPROVE FROM PROMOTION WHERE PROMOTION_ID = " + GF.selected_id.ToString();
                using (DataTable DT = DB.getS(queryString, null, "GET PROMOTION[" + GF.selected_id.ToString() + "]", false))
                {
                    foreach(DataRow row in DT.Rows)
                    {
                        promotion_name.Text = row["PROMOTION_NAME"].ToString();
                        start_date.Text = row["START_DATE"].ToString();
                        end_date.Text = row["END_DATE"].ToString();
                        amount.Text = row["DISCOUNT_AMOUNT"].ToString();
                        if (row["OVERRIDE_APPROVE"].ToString() == "1") cashier_can_approve.Checked = true;
                    }
                }
            }
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if (promotion_name.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER PROMOTION NAME !!", "ERROR");
                promotion_name.Select();
                return;
            }
            if (GF.emptyDate(start_date.Text.Trim()))
            {
                MessageBox.Show("PLEASE ENTER PROMOTION START DATE !!", "ERROR");
                start_date.Select();
                return;
            }
            if (GF.emptyDate(end_date.Text.Trim()))
            {
                MessageBox.Show("PLEASE ENTER PROMOTION END DATE !!", "ERROR");
                end_date.Select();
                return;
            }
            if (Convert.ToDateTime(end_date.Text.Trim()).CompareTo(Convert.ToDateTime(start_date.Text.Trim())) < 0)
            {
                MessageBox.Show("THE 'END DATE' DATE MUST BE LATER THAN OR SAME DAY AS 'START DATE' !!", "ERROR");
                end_date.Focus();
                return;
            }
            if (amount.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER DISCOUNT AMOUNT !!", "ERROR");
                amount.Select();
                return;
            }

            string queryString = "SELECT * FROM PROMOTION WHERE IS_USE = 1 AND ((START_DATE <= " + GF.modDate(start_date.Text.Trim()) + " AND " + GF.modDate(start_date.Text.Trim()) + " <= END_DATE) OR (START_DATE <= " + GF.modDate(end_date.Text.Trim()) + " AND " + GF.modDate(end_date.Text.Trim()) + " <= END_DATE))";
            if (manage_btn.Text.Trim() == "UPDATE") queryString += " AND PROMOTION_ID != " + GF.selected_id.ToString();

            Dictionary<string, string> Params = new Dictionary<string, string>();
            /*Params.Add("@start_date", GF.modDate(start_date.Text.Trim()));
            Params.Add("@end_date", GF.modDate(end_date.Text.Trim()));*/

            using (DataTable DT = DB.getS(queryString, Params, "CHECK IF THE PROMOTION IS BETWEEN OTHER PROMOTION", false))
            {
                if (DT.Rows.Count > 0)
                {
                    MessageBox.Show("THE START DATE OR END DATE IS ALREADY BETWEEN OTHER PROMOTION", "ERROR");
                    return;
                }
            }

            GF.showLoading(this);
            DB.beginTrans();
            queryString = "SELECT * FROM PROMOTION WHERE PROMOTION_NAME = @promotion_name";
            if (manage_btn.Text.Trim() == "UPDATE") queryString += " AND PROMOTION_ID != " + GF.selected_id.ToString();

            Params = new Dictionary<string, string>();
            Params.Add("@promotion_name", promotion_name.Text);

            using (DataTable DT = DB.getS(queryString, Params, "CHECK PROMOTION NAME IF EXISTED", false))
            {
                if (DT.Rows.Count > 0)
                {
                    MessageBox.Show("THIS PROMOTION NAME IS ALREADY EXISTED !!", "ERROR");
                    GF.closeLoading();
                    promotion_name.Select();
                    return;
                }
            }

            if (manage_btn.Text.Trim() == "ADD")
            {
                queryString = "INSERT INTO PROMOTION (PROMOTION_NAME, START_DATE, END_DATE, DISCOUNT_AMOUNT, DISCOUNT_UNIT, OVERRIDE_APPROVE) VALUES (";
                queryString += "'" + promotion_name.Text.Trim() + "', ";
                queryString += GF.modDate(start_date.Text.Trim()) + ", ";
                queryString += GF.modDate(end_date.Text.Trim()) + ", ";
                queryString += amount.Text.Trim() + ", ";
                queryString += "0, ";
                queryString += ", " + (cashier_can_approve.Checked ? "1" : "0");
                queryString += ")";
                if (DB.set(queryString, "INSERT PROMOTION"))
                {
                    DB.close();
                    MessageBox.Show("PROMOTION IS ADDED !!", "COMPLETED");
                    ((btn_dgv)this.Owner.Controls["btn_dgv"]).refresh_btn.PerformClick();
                    GF.closeLoading();
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("ERROR INSERT PROMOTION !!", "ERROR");
                    GF.closeLoading();
                    return;
                }
            }

            if (manage_btn.Text.Trim() == "UPDATE")
            {
                queryString = "UPDATE PROMOTION SET ";
                queryString += "PROMOTION_NAME = '" + promotion_name.Text.Trim() + "', ";
                queryString += "START_DATE = " + GF.modDate(start_date.Text.Trim()) + ", ";
                queryString += "END_DATE = " + GF.modDate(end_date.Text.Trim()) + ", ";
                queryString += "DISCOUNT_AMOUNT = " + amount.Text.Trim() + ", ";
                queryString += "DISCOUNT_UNIT = 0, ";
                queryString += "OVERRIDE_APPROVE = " + (cashier_can_approve.Checked ? "1" : "0") + " ";
                queryString += "WHERE PROMOTION_ID = " + GF.selected_id.ToString();
                if (DB.set(queryString, "UPDATE PROMOTION[" + GF.selected_id.ToString() + "]"))
                {
                    DB.close();
                    MessageBox.Show("PROMOTION IS UPDATED !!", "COMPLETED");
                    ((btn_dgv)this.Owner.Controls["btn_dgv"]).refresh_btn.PerformClick();
                    GF.closeLoading();
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("ERROR UPDATE PROMOTION !!", "ERROR");
                    GF.closeLoading();
                    return;
                }
            }
        }

        private void amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void promotion_manage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Activate();
        }
    }
}
