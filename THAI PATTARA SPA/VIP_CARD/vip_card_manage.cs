using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.VIP_CARD
{
    public partial class vip_card_manage : Form
    {
        public vip_card_manage()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };

            responsible_id.parentForm = this;
        }

        private void vip_card_manage_Load(object sender, EventArgs e)
        {
            DateTime theExpiryDate = Convert.ToDateTime(GF.TODAY());
            theExpiryDate = theExpiryDate.AddYears(1);
            expiry_date.Text = theExpiryDate.ToString();
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if (code_begin.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER CODE BEGIN !!", "ERROR");
                code_begin.Select();
                return;
            }

            if (code_end.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER CODE END !!", "ERROR");
                code_end.Select();
                return;
            }

            if (code_begin.Text.Trim().Length != code_end.Text.Trim().Length)
            {
                MessageBox.Show("PLEASE CHECK CODE BEGIN AND END !!\r\n\r\nTHE CODE LENGTH IS MISMATCH !!", "ERROR");
                return;
            }

            if (responsible_id.currentID == -1)
            {
                MessageBox.Show("PLEASE SELECT THE RESPONSIBLE EMPLOYEE !!", "ERROR");
                responsible_id.Select();
                return;
            }

            if (expiry_date.Text.Trim().Length < 10)
            {
                MessageBox.Show("EXPIRY DATE MUST BE IN THE FORMAT 'DD/MM/YYYY' !!", "ERROR");
                expiry_date.Select();
                return;
            }

            String queryString = "SELECT CARD_NO FROM VIP_CARD WHERE IS_VOID = 0 AND CONVERT(BIGINT,CARD_NO) BETWEEN " + Convert.ToInt32(code_begin.Text.Trim()).ToString() + " AND " + Convert.ToInt32(code_end.Text.Trim()).ToString();

            Dictionary<string, string> Params = new Dictionary<string, string>();
            /*Params.Add("@code_begin", Convert.ToInt32(code_begin.Text.Trim()).ToString());
            Params.Add("@code_end", Convert.ToInt32(code_end.Text.Trim()).ToString());*/

            using (DataTable DT = DB.getS(queryString, Params, "CHECK IF ANY CODE BETWEEN BEGIN AND END IS EXISTED", false))
            {
                if (DT.Rows.Count > 0)
                {
                    String tmp_code = "";
                    foreach (DataRow row in DT.Rows)
                    {
                        tmp_code += row["CARD_NO"].ToString() + ", ";
                    }
                    tmp_code = tmp_code.Substring(0, tmp_code.Length - 2);
                    MessageBox.Show("FOLLOWING CODE IS ALREADY EXISTED IN THIS RANGE !!\r\n\r\n" + tmp_code, "ERROR");
                    return;
                }
            }

            GF.showLoading(this);
            DB.beginTrans();
            if (Convert.ToInt64(code_begin.Text.Trim()) > Convert.ToInt64(code_end.Text.Trim()))
            {
                String tmp = code_begin.Text.Trim();
                code_begin.Text = code_end.Text.Trim();
                code_end.Text = tmp;
            }
            for (Int64 card_no = Convert.ToInt64(code_begin.Text.Trim()); card_no <= Convert.ToInt64(code_end.Text.Trim()); card_no++)
            {
                queryString = "INSERT INTO VIP_CARD (CARD_NO, DISCOUNT, CREATED_BY, CREATED_DATE, EXPIRY_DATE, RESPONSIBLE_ID) VALUES (";
                queryString += "'" + card_no.ToString() + "', ";
                queryString += discount.Text.Trim() + ", ";
                queryString += GF.emp_id.ToString() + ", ";
                queryString += "CURRENT_TIMESTAMP, ";
                queryString += GF.modDate(expiry_date.Text.Trim()) + ", ";
                queryString += responsible_id.currentID.ToString();
                queryString += ")";

                if (!DB.set(queryString, "INSERT VIP_CARD[" + card_no.ToString() + "]"))
                {
                    GF.closeLoading();
                    MessageBox.Show("ERROR ADDING DATA !!", "ERROR");
                    return;
                }
            }

            DB.close();
            ((vip_card)Owner).btn_dgv.refresh_btn.PerformClick();
            GF.closeLoading();
            this.Close();
        }

        private void discount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void vip_card_manage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Activate();
        }

        private void code_begin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void code_end_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
