using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.CROSS_PROMOTION
{
    public partial class cross_promotion_manage : Form
    {
        public string cross_promotion_id = "";
        public cross_promotion_manage()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };
        }

        private void no_expiry_date_CheckedChanged(object sender, EventArgs e)
        {
            expiry_date.Enabled = !no_expiry_date.Checked;
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cross_promotion_manage_Load(object sender, EventArgs e)
        {
            String queryString = "SELECT * FROM SPA_PROGRAM WHERE IS_USE = 1 ORDER BY CODE";
            using (DataTable DT = DB.getS(queryString, null, "GET ALL ACTIVE SPA PROGRAM", false))
            {
                spa_program_id.Items.Add(new ComboItem(-1, "SPA PROGRAM"));
                foreach (DataRow row in DT.Rows)
                {
                    spa_program_id.Items.Add(new ComboItem(Convert.ToInt32(row["SPA_PROGRAM_ID"].ToString()), "[#" + row["CODE"].ToString() + "] " + row["PROGRAM_NAME"].ToString()));
                }
            }
            spa_program_id.SelectedIndex = 0;
            GF.resizeComboBox(spa_program_id);

            DateTime theExpiryDate = Convert.ToDateTime(GF.TODAY());
            theExpiryDate = theExpiryDate.AddYears(1);
            expiry_date.Text = theExpiryDate.ToString();

            if (cross_promotion_id.Trim() != "")
            {
                queryString = "SELECT CROSS_PROMOTION_NAME, CARD_NO, DISCOUNT, SPA_PROGRAM_ID, CONVERT(NVARCHAR(MAX), EXPIRY_DATE, 103) EXPIRY_DATE FROM CROSS_PROMOTION WHERE CROSS_PROMOTION_ID = " + cross_promotion_id;
                using (DataTable DT = DB.getS(queryString, null, "GET CROSS_PROMOTION[" + cross_promotion_id + "]", false))
                {
                    cross_promotion_name.Text = DT.Rows[0]["CROSS_PROMOTION_NAME"].ToString();
                    card_no.Text = DT.Rows[0]["CARD_NO"].ToString();
                    discount.Text = DT.Rows[0]["DISCOUNT"].ToString();
                    if (DT.Rows[0]["EXPIRY_DATE"].ToString() == "NULL" || DT.Rows[0]["EXPIRY_DATE"].ToString() == "")
                        no_expiry_date.Checked = true;
                    else
                        expiry_date.Text = DT.Rows[0]["EXPIRY_DATE"].ToString();

                    int index = 0;
                    int count = -1;
                    foreach (ComboItem item in spa_program_id.Items)
                    {
                        count++;
                        if (item.Key == Convert.ToInt32(DT.Rows[0]["SPA_PROGRAM_ID"].ToString()))
                        {
                            index = count;
                            break;
                        }
                    }
                    spa_program_id.SelectedIndex = count;
                }
            }
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            String queryString = "";
            if (manage_btn.Text.Trim() == "ADD")
            {
                queryString = "INSERT INTO CROSS_PROMOTION (CROSS_PROMOTION_NAME, CARD_NO, EXPIRY_DATE, SPA_PROGRAM_ID, DISCOUNT, IS_USE) VALUES (";
                queryString += "'" + cross_promotion_name.Text.Trim() + "', ";
                queryString += "'" + card_no.Text.Trim() + "', ";
                queryString += (no_expiry_date.Checked ? "NULL" : GF.modDate(expiry_date.Text.Trim())) + ", ";
                queryString += ((ComboItem)spa_program_id.SelectedItem).Key.ToString() + ", ";
                queryString += discount.Text.Trim() + ", ";
                queryString += "1)";
            }
            if (manage_btn.Text.Trim() == "UPDATE")
            {
                queryString = "UPDATE CROSS_PROMOTION SET ";
                queryString += "CROSS_PROMOTION_NAME = '" + cross_promotion_name.Text.Trim() + "', ";
                queryString += "CARD_NO = '" + card_no.Text.Trim() + "', ";
                queryString += "EXPIRY_DATE = " + (no_expiry_date.Checked ? "NULL" : GF.modDate(expiry_date.Text.Trim())) + ", ";
                queryString += "SPA_PROGRAM_ID = " + ((ComboItem)spa_program_id.SelectedItem).Key.ToString() + ", ";
                queryString += "DISCOUNT = " + discount.Text.Trim() + " ";
                queryString += "WHERE CROSS_PROMOTION_ID = " + cross_promotion_id;
            }

            GF.showLoading(this);
            DB.beginTrans();
            if (!DB.set(queryString, manage_btn.Text.Trim() + " CROSS PROMOTION" + (manage_btn.Text.Trim() == "UPDATE" ? "[" + cross_promotion_id + "]" : "")))
            {
                MessageBox.Show("ERROR " + manage_btn.Text.Trim() + " CROSS PROMOTION !!", "ERROR");
                GF.closeLoading();
                return;
            }
            DB.close();
            GF.closeLoading();

            ((cross_promotion)this.Owner).btn_dgv.refresh_btn.PerformClick();
            this.Close();
        }

        private void card_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void discount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
