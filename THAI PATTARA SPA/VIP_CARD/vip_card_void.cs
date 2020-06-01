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
    public partial class vip_card_void : Form
    {
        public vip_card_void()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };
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

            if(Convert.ToInt32(code_begin.Text.Trim()) > Convert.ToInt32(code_end.Text.Trim()))
            {
                String tmp = code_end.Text.Trim();
                code_end.Text = code_begin.Text;
                code_begin.Text = tmp;
            }

            if (code_begin.Text.Trim().Length != code_end.Text.Trim().Length)
            {
                MessageBox.Show("PLEASE CHECK CODE BEGIN AND END !!\r\n\r\nTHE CODE LENGTH IS MISMATCH !!", "ERROR");
                return;
            }

            int strlen = code_begin.Text.Trim().Length;

            if (reason.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER REASON !!", "ERROR");
                reason.Select();
                return;
            }

            String queryString = "";

            queryString = @"
            SELECT A.CARD_NO, C.BILL_NO
            FROM VIP_CARD A
            INNER JOIN BILL_DISCOUNT B ON B.USE_CARD_TYPE = 4 AND A.VIP_CARD_ID = B.USE_CARD_ID
            INNER JOIN BILL C ON B.BILL_ID = C.BILL_ID
            WHERE CONVERT(BIGINT, A.CARD_NO) BETWEEN " + code_begin.Text + @" AND " + code_end.Text + @"
            ORDER BY A.CARD_NO, C.BILL_NO";

            Dictionary<string, string> Params = new Dictionary<string, string>();
            /*Params.Add("@code_begin", code_begin.Text);
            Params.Add("@code_end", code_end.Text);*/

            using (DataTable DT = DB.getS(queryString, Params, "CHECK IF ANY CARD IN RANGE WAS USED", false))
            {
                if (DT.Rows.Count > 0)
                {
                    string tmp = "";
                    foreach (DataRow row in DT.Rows)
                    {
                        tmp += "CARD NO : " + row["CARD_NO"] + " in BILL NO : " + row["BILL_NO"] + "\r\n";
                    }
                    tmp = tmp.Substring(0, tmp.Length - 4);
                    MessageBox.Show("CANNOT VOID VIP CARD(s) !!\r\nFOLLOWING CARD NO. WAS USED IN BILL.\r\nYOU MUST VOID BILL FIRST !!\r\n\r\n" + tmp, "ERROR");
                    return;
                }
            }

            GF.showLoading(this);
            DB.beginTrans();
            queryString = "UPDATE VIP_CARD SET IS_VOID = 1, VOIDED_BY = " + GF.emp_id + ", VOIDED_REASON = '" + reason.Text.Trim() + "', VOIDED_DATETIME = CURRENT_TIMESTAMP, IS_USE = 0 WHERE CONVERT(BIGINT, CARD_NO) BETWEEN " + code_begin.Text.Trim() + " AND " + code_end.Text.Trim();
            if (!DB.set(queryString, "VOID VIP_CARD"))
            {
                MessageBox.Show("ERROR VOID VIP CARD(s) !!", "ERROR");
                GF.closeLoading();
                return;
            }
            DB.close();
            ((vip_card)Owner).btn_dgv.refresh_btn.PerformClick();
            GF.closeLoading();
            this.Close();
        }

        private void vip_card_void_FormClosed(object sender, FormClosedEventArgs e)
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
