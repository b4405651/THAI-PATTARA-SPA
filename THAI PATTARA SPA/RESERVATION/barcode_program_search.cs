using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.RESERVATION
{
    public partial class barcode_program_search : Form
    {
        public barcode_program_search()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };
        }

        private void finalize(int spa_program_id)
        {
            if (this.Owner.Name == "reservation_program")
            {
                if (spa_program_id != -1)
                {
                    foreach (ComboItem item in ((reservation_program)Owner).spa_program_id.Items)
                    {
                        if (item.Key == spa_program_id)
                        {
                            ((reservation_program)Owner).spa_program_id.Text = item.Value.Trim();
                            this.Close();
                        }
                    }
                }
            }
        }

        private void card_no_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (card_no.Text.Trim().Length == 16)
                {
                    bool found = false;
                    // SEARCH FOR GIFT CERTIFICATE
                    String queryString = "SELECT SPA_PROGRAM_ID, IS_USE FROM GIFT_CERTIFICATE WHERE CARD_NO = '" + card_no.Text + "'";

                    Dictionary<string, string> Params = new Dictionary<string, string>();
                    //Params.Add("@card_no", card_no.Text);

                    using (DataTable DT = DB.getS(queryString, Params, "CHECK CARD_NO FROM GIFT_CERTIFICATE", false))
                    {
                        if (DT.Rows.Count == 1)
                        {
                            if (DT.Rows[0]["SPA_PROGRAM_ID"].ToString() == "-1")
                            {
                                MessageBox.Show("THIS IS MONEY GIFT CERTIFICATE !!", "ERROR");
                                this.Close();
                            }
                            else if(DT.Rows[0]["IS_USE"].ToString() == "0"){
                                MessageBox.Show("THIS GIFT CERTIFICATE IS ALREADY USED !!", "ERROR");
                                this.Close();
                            }
                            else
                            {
                                found = true;
                                finalize(Convert.ToInt32(DT.Rows[0]["SPA_PROGRAM_ID"].ToString()));
                            }
                        }
                    }

                    if (found) return;

                    queryString = "SELECT SPA_PROGRAM_ID, IS_USE FROM GIFT_VOUCHER WHERE CARD_NO = @card_no";
                    using (DataTable DT = DB.getS(queryString, Params, "CHECK CARD_NO FROM GIFT_VOUCHER", false))
                    {
                        if (DT.Rows.Count == 1)
                        {
                            if (DT.Rows[0]["IS_USE"].ToString() == "0")
                            {
                                MessageBox.Show("THIS GIFT VOUCHER IS ALREADY USED !!", "ERROR");
                                this.Close();
                            }
                            else
                            {
                                found = true;
                                finalize(Convert.ToInt32(DT.Rows[0]["SPA_PROGRAM_ID"].ToString()));
                            }
                        }
                    }

                    if (found) return;

                    queryString = @"
                    SELECT A.SPA_PROGRAM_ID, B.USED_DATETIME
                    FROM SPECIAL_CARD_SET A
                    LEFT OUTER JOIN SPECIAL_CARD_USED B ON B.CARD_NO = @card_no
                    WHERE @card_no BETWEEN CODE_BEGIN AND CODE_END";
                    using (DataTable DT = DB.getS(queryString, Params, "CHECK CARD_NO FROM COUPON", false))
                    {
                        if (DT.Rows.Count == 1)
                        {
                            if (DT.Rows[0]["USED_DATETIME"].ToString() != "")
                            {
                                MessageBox.Show("THIS COUPON IS ALREADY USED !!", "ERROR");
                                this.Close();
                            }
                            else
                            {
                                found = true;
                                finalize(Convert.ToInt32(DT.Rows[0]["SPA_PROGRAM_ID"].ToString()));
                            }
                        }
                    }

                    this.Close();
                }
            }
        }
    }
}
