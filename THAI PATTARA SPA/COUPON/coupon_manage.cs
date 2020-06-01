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
    public partial class coupon_manage : Form
    {
        String queryString = "";
        public string coupon_id = "-1";
        public coupon_manage()
        {
            InitializeComponent();

            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };

            debtor_id.parentForm = this;

            queryString = "SELECT * FROM COUPON_SET_CONFIG WHERE IS_USE = 1 ORDER BY COUPON_SET_NAME";
            using (DataTable DT = DB.getS(queryString, null, "", false))
            {
                if (DT.Rows.Count == 0)
                    coupon_set_rb.Enabled = false;
                else
                {
                    foreach (DataRow row in DT.Rows)
                    {
                        coupon_set.Items.Add(new ComboItem(Convert.ToInt32(row["COUPON_SET_CONFIG_ID"].ToString()), row["COUPON_SET_NAME"].ToString() + " - " + GF.formatNumber(Convert.ToInt32(row["PRICE"].ToString())) + "p."));
                    }
                    coupon_set.SelectedIndex = 0;
                    GF.resizeComboBox(coupon_set);
                }
            }
            queryString = "SELECT * FROM SPA_PROGRAM WHERE IS_USE = 1 ORDER BY CODE";
            using (DataTable DT = DB.getS(queryString, null, "GET ALL ACTIVE SPA PROGRAM", false))
            {
                spa_program_id.Items.Add(new ComboItem(-99, "SPA PROGRAM"));
                spa_program_id.Items.Add(new ComboItem(-1, "ALL"));
                foreach (DataRow row in DT.Rows)
                {
                    spa_program_id.Items.Add(new ComboItem(Convert.ToInt32(row["SPA_PROGRAM_ID"].ToString()), "[#" + row["CODE"].ToString() + "] " + row["PROGRAM_NAME"].ToString()));
                }
            }
            spa_program_id.SelectedIndex = 0;
            GF.resizeComboBox(spa_program_id);

            queryString = @"
            SELECT * 
            FROM MEMBERCARD A
            INNER JOIN MEMBERCARD_TYPE B ON A.MEMBERCARD_TYPE_ID = B.MEMBERCARD_TYPE_ID
            INNER JOIN CUSTOMER C ON A.CUSTOMER_ID = C.CUSTOMER_ID
            WHERE A.ISSUE_DATE >= CONVERT(DATE, '28/06/2014', 103) 
            ORDER BY CARD_NO"; // FIRST DATE MEMBER THAT ISSUE DELIGHT, EXECUTIVE AND FAMILY CARD
            using (DataTable DT = DB.getS(queryString, null, "GET MEMBERCARD THAT STILL CAN PUT COUPON IN", false))
            {
                foreach (DataRow row in DT.Rows)
                {
                    String[] tmp = row["COMPLEMENTARY_SPA_PROGRAM_ID"].ToString().Split(',');
                    queryString = "SELECT * FROM COUPON WHERE MEMBERCARD_ID = " + row["MEMBERCARD_ID"].ToString() + " AND IS_VOID = 0";
                    using (DataTable tmpDT = DB.getS(queryString, null, "GET NUMBER OF COUPON IN MEMBERCARD[" + row["MEMBERCARD_ID"].ToString() + "]", false))
                    {
                        if (tmpDT.Rows.Count < tmp.Length)
                        {
                            membercard_id.Items.Add(new ComboItem(Convert.ToInt32(row["MEMBERCARD_ID"].ToString()), row["CARD_NO"].ToString() + " - " + row["CUSTOMER_NAME"].ToString() + " - " + row["TEL"].ToString() + " [CURRENT : " + tmpDT.Rows.Count.ToString() + "/" + tmp.Length.ToString() + "]"));
                        }
                    }
                }
            }
            membercard_id.SelectedIndex = 0;
            GF.resizeComboBox(membercard_id);
            if (membercard_id.Items.Count == 0) membercard_id.Enabled = false;

            discount_unit.Items.Clear();
            discount_unit.Items.Add(new ComboItem(0, "%"));
            discount_unit.Items.Add(new ComboItem(1, Properties.Settings.Default.money_unit));
            discount_unit.SelectedIndex = 0;
            GF.resizeComboBox(discount_unit);

            DateTime theExpiryDate = Convert.ToDateTime(GF.TODAY());
            theExpiryDate = theExpiryDate.AddYears(1);
            expiry_date.Text = theExpiryDate.ToString();
        }

        private void coupon_manage_Load(object sender, EventArgs e)
        {
            if (coupon_id != "-1")
            {
                coupon_type_panel.Enabled = false;
                payment_panel.Enabled = false;

                string queryString = @"
                SELECT 
                    EVENT_NAME,
                    CARD_NO,
                    SPA_PROGRAM_ID,
                    PRICE, 
                    DISCOUNT_AMOUNT,
                    DISCOUNT_UNIT,
                    BALANCE,
                    CONVERT(DATE, EXPIRY_DATE, 103) EXPIRY_DATE,
                    CONVERT(DATE, SOLD_ON, 103) SOLD_ON
                FROM COUPON 
                WHERE COUPON_ID = " + coupon_id;
                using (DataTable DT = DB.getS(queryString, null, "GET COUPON[" + coupon_id + "]", false))
                {
                    event_name.Text = DT.Rows[0]["EVENT_NAME"].ToString();
                    code_begin.Text = code_end.Text = DT.Rows[0]["CARD_NO"].ToString();
                    code_begin.Enabled = false;
                    code_end.Enabled = false;
                    for (int i = 0; i < spa_program_id.Items.Count; i++)
                    {
                        if (((ComboItem)spa_program_id.Items[i]).Key.ToString() == DT.Rows[0]["SPA_PROGRAM_ID"].ToString())
                        {
                            spa_program_id.SelectedIndex = i;
                            break;
                        }
                    }

                    if (DT.Rows[0]["BALANCE"].ToString() == "" || DT.Rows[0]["BALANCE"].ToString() == "NULL")
                    {
                        simple_coupon_rb.Checked = true;
                        discount_amount.Text = DT.Rows[0]["DISCOUNT_AMOUNT"].ToString();
                        discount_unit.SelectedIndex = Convert.ToInt32(DT.Rows[0]["DISCOUNT_UNIT"].ToString());
                        /*spa_program_id.Enabled = true;
                        discount_unit.Enabled = true;
                        discount_lbl.Text = "DISCOUNT : ";*/
                    }
                    else
                    {
                        money_coupon_rb.Checked = true;
                        discount_amount.Text = DT.Rows[0]["BALANCE"].ToString();
                        /*spa_program_id.Enabled = false;
                        discount_unit.SelectedIndex = 1;
                        discount_unit.Enabled = false;
                        discount_lbl.Text = "BALANCE : ";*/
                    }
                    price.Text = DT.Rows[0]["PRICE"].ToString();
                    expiry_date.Text = DT.Rows[0]["EXPIRY_DATE"].ToString();
                    sold_on.Text = DT.Rows[0]["SOLD_ON"].ToString();
                }
            }
            GF.closeLoading();
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if (personal_credit_rb.Checked && debtor_id.currentID == -1)
            {
                MessageBox.Show("PLEASE CHOOSE THE DEBTOR !!", "ERROR");
                debtor_id.Select();
                return;
            }
            if (simple_coupon_rb.Checked || money_coupon_rb.Checked)
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

                if (spa_program_id.SelectedIndex == 0 && !money_coupon_rb.Checked)
                {
                    MessageBox.Show("PLEASE SELECT SPA PROGRAM !!", "ERROR");
                    spa_program_id.Focus();
                    return;
                }

                if (discount_amount.Text.Trim() == "")
                {
                    MessageBox.Show("PLEASE ENTER DISCOUNT AMOUNT !!", "ERROR");
                    discount_amount.Focus();
                    return;
                }

                Dictionary<string, string> Params = new Dictionary<string, string>();
                /*Params.Add("@code_begin", Convert.ToInt64(code_begin.Text.Trim()).ToString());
                Params.Add("@code_end", Convert.ToInt64(code_end.Text.Trim()).ToString());*/

                queryString = "SELECT CARD_NO FROM COUPON WHERE IS_VOID = 0 AND COUPON_ID != " + coupon_id + " AND CONVERT(BIGINT,CARD_NO) BETWEEN " + Convert.ToInt64(code_begin.Text.Trim()).ToString() + " AND " + Convert.ToInt64(code_end.Text.Trim()).ToString();
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
                if (manage_btn.Text == "ADD")
                {
                    if (Convert.ToInt64(code_begin.Text.Trim()) > Convert.ToInt64(code_end.Text.Trim()))
                    {
                        String tmp = code_begin.Text.Trim();
                        code_begin.Text = code_end.Text.Trim();
                        code_end.Text = tmp;
                    }

                    for (Int64 card_no = Convert.ToInt64(code_begin.Text.Trim()); card_no <= Convert.ToInt64(code_end.Text.Trim()); card_no++)
                    {
                        if(simple_coupon_rb.Checked)
                            queryString = "INSERT INTO COUPON (CARD_NO, SPA_PROGRAM_ID, PRICE, EVENT_NAME, PAYMENT_TYPE, EXPIRY_DATE, SOLD_ON, CREATED_BY, CREATED_DATE, DISCOUNT_AMOUNT, DISCOUNT_UNIT) VALUES (";
                        if (money_coupon_rb.Checked)
                            queryString = "INSERT INTO COUPON (CARD_NO, SPA_PROGRAM_ID, PRICE, EVENT_NAME, PAYMENT_TYPE, EXPIRY_DATE, SOLD_ON, CREATED_BY, CREATED_DATE, BALANCE, BALANCE_MAX) VALUES (";

                        queryString += "'" + card_no.ToString() + "', ";
                        queryString += ((ComboItem)spa_program_id.SelectedItem).Key.ToString() + ", ";
                        queryString += (free.Checked ? "0" : price.Text.Trim()) + ", ";
                        queryString += (event_name.Text.Trim() == "" ? "NULL" : ("'" + event_name.Text.Trim() + "'")) + ", ";
                        if (cash.Checked) queryString += "0, ";
                        if (credit.Checked) queryString += "1, ";
                        if (free.Checked) queryString += "-1, ";
                        queryString += GF.modDate(expiry_date.Text.Trim()) + ", ";
                        queryString += GF.modDate(sold_on.Text.Trim()) + ", ";
                        queryString += GF.emp_id.ToString() + ", ";
                        queryString += "CURRENT_TIMESTAMP, ";
                        if (simple_coupon_rb.Checked)
                        {
                            queryString += discount_amount.Text.Trim() + ", ";
                            queryString += ((ComboItem)discount_unit.SelectedItem).Key.ToString();
                        }
                        if (money_coupon_rb.Checked)
                        {
                            queryString += discount_amount.Text.Trim() + ", ";
                            queryString += discount_amount.Text.Trim();
                        }

                        queryString += ")";

                        if (!DB.set(queryString, "INSERT COUPON[" + card_no.ToString() + "]"))
                        {
                            GF.closeLoading();
                            MessageBox.Show("ERROR ADDING DATA !!", "ERROR");
                            return;
                        }
                    }
                }

                if (manage_btn.Text == "UPDATE")
                {
                    queryString = "UPDATE COUPON SET EVENT_NAME = '" + event_name.Text.Trim() + "', ";
                    queryString += "SPA_PROGRAM_ID = " + ((ComboItem)spa_program_id.SelectedItem).Key.ToString() + ", ";
                    if (simple_coupon_rb.Checked)
                    {
                        queryString += "DISCOUNT_AMOUNT = " + discount_amount.Text + ", ";
                        queryString += "DISCOUNT_UNIT = " + ((ComboItem)discount_unit.SelectedItem).Key.ToString() + ", ";
                    }
                    if (money_coupon_rb.Checked)
                    {
                        queryString += "BALANCE = " + discount_amount.Text.Trim() + ", ";
                        queryString += "BALANCE_MAX = " + discount_amount.Text.Trim() + ", ";
                    }
                    
                    queryString += "PRICE = " + price.Text.Trim() + ", ";
                    queryString += "EXPIRY_DATE = " + GF.modDate(expiry_date.Text.Trim()) + ", ";
                    queryString += "SOLD_ON = " + GF.modDate(sold_on.Text.Trim()) + " ";
                    queryString += "WHERE COUPON_ID = " + coupon_id;
                    if (!DB.set(queryString, "UPDATE COUPON[" + coupon_id + "]"))
                    {
                        GF.closeLoading();
                        MessageBox.Show("ERROR UPDATE COUPON No. " + code_begin.Text.Trim(), "ERROR");
                        return;
                    }
                }

                DB.close();
                GF.closeLoading();
            }
            if(coupon_set_rb.Checked)
            {
                GF.showLoading(this);
                DB.beginTrans();
                queryString = "INSERT INTO COUPON_SET (COUPON_SET_CONFIG_ID) VALUES (" + ((ComboItem)coupon_set.SelectedItem).Key.ToString() + ")";
                int id = DB.insertReturnID(queryString, "INSERT COUPON_SET RETURN ID");
                if (id == -1)
                {
                    MessageBox.Show("ERROR INSERT COUPON SET !!", "ERROR");
                    GF.closeLoading();
                    return;
                }

                String expire_amount = "-1";
                String expire_unit = "-1";
                queryString = "SELECT * FROM COUPON_SET_CONFIG WHERE COUPON_SET_CONFIG_ID = " + ((ComboItem)coupon_set.SelectedItem).Key.ToString();
                using (DataTable DT = DB.getS(queryString, null, "", false))
                {
                    expire_amount = DT.Rows[0]["EXPIRE_AMOUNT"].ToString();
                    expire_unit = DT.Rows[0]["EXPIRE_UNIT"].ToString();
                }
                GF.closeLoading();
                queryString = "SELECT * FROM COUPON_SET_CONFIG_DETAIL WHERE COUPON_SET_CONFIG_ID = " + ((ComboItem)coupon_set.SelectedItem).Key.ToString();
                using (DataTable DT = DB.getS(queryString, null, "GET COUPON_SET_CONFIG_DETAIL IN COUPON_SET_CONFIG[" + ((ComboItem)coupon_set.SelectedItem).Key.ToString() + "]", false))
                {
                    foreach (DataRow row in DT.Rows)
                    {
                        for (int count = 1; count <= Convert.ToInt32(row["AMOUNT"].ToString()); count++)
                        {
                            using (register_coupon managePage = new register_coupon())
                            {
                                managePage.preventTransManage = true;
                                managePage.Owner = this;
                                managePage.selected_spa_program_id = row["SPA_PROGRAM_ID"].ToString();
                                managePage.coupon_set_id = id.ToString();
                                managePage.debtor_id = debtor_id.currentID.ToString();
                                if (personal_credit_rb.Checked)
                                    managePage.payment_type = "-1";
                                if (cash.Checked)
                                    managePage.payment_type = "0";
                                if (credit.Checked)
                                    managePage.payment_type = "1";
                                if (free.Checked)
                                    managePage.payment_type = "2";
                                managePage.expire_amount = expire_amount;
                                managePage.expire_unit = expire_unit;
                                managePage.ShowDialog();
                            }
                        }
                    }
                }
                DB.close();
            }
            if (membercard_rb.Checked)
            {
                queryString = @"
                SELECT A.CARD_NO, B.COMPLEMENTARY_SPA_PROGRAM_ID, B.COMPLEMENTARY_DISCOUNT_AMOUNT, B.COMPLEMENTARY_DISCOUNT_UNIT 
                FROM MEMBERCARD A 
                INNER JOIN MEMBERCARD_TYPE B ON A.MEMBERCARD_TYPE_ID = B.MEMBERCARD_TYPE_ID
                WHERE A.MEMBERCARD_ID = " + ((ComboItem)membercard_id.SelectedItem).Key.ToString();

                using (DataTable DT = DB.getS(queryString, null, "GET COMPLEMENTARTY OF MEMBERCARD[" + ((ComboItem)membercard_id.SelectedItem).Key.ToString() + "]", false))
                {
                    foreach (DataRow DR in DT.Rows)
                    {
                        String[] spa_program_id_arr = DR["COMPLEMENTARY_SPA_PROGRAM_ID"].ToString().Split(',');
                        String[] spa_program_disc_amt_arr = DR["COMPLEMENTARY_DISCOUNT_AMOUNT"].ToString().Split(',');
                        String[] spa_program_disc_unit_arr = DR["COMPLEMENTARY_DISCOUNT_UNIT"].ToString().Split(',');
                        String member_card_no = DR["CARD_NO"].ToString();
                        int index = 0;

                        queryString = "SELECT * FROM COUPON WHERE MEMBERCARD_ID = " + ((ComboItem)membercard_id.SelectedItem).Key.ToString() + " AND IS_VOID = 0";
                        using (DataTable tmpDT = DB.getS(queryString, null, "GET COUPON IN MEMBERCARD[" + ((ComboItem)membercard_id.SelectedItem).Key.ToString() + "]", false))
                        {
                            foreach (DataRow row in tmpDT.Rows)
                            {
                                index = 0;
                                foreach (String the_spa_program in spa_program_id_arr)
                                {
                                    if (the_spa_program == row["SPA_PROGRAM_ID"].ToString())
                                    {
                                        List<String> tmp_spa_program_id = new List<string>(spa_program_id_arr);
                                        tmp_spa_program_id.RemoveAt(index);
                                        spa_program_id_arr = tmp_spa_program_id.ToArray();

                                        List<String> tmp_spa_program_disc_amt_arr = new List<string>(spa_program_disc_amt_arr);
                                        tmp_spa_program_disc_amt_arr.RemoveAt(index);
                                        spa_program_disc_amt_arr = tmp_spa_program_disc_amt_arr.ToArray();

                                        List<String> tmp_spa_program_disc_unit_arr = new List<string>(spa_program_disc_unit_arr);
                                        tmp_spa_program_disc_unit_arr.RemoveAt(index);
                                        spa_program_disc_unit_arr = tmp_spa_program_disc_unit_arr.ToArray();
                                        break;
                                    }
                                    index++;
                                }
                            }
                        }

                        index = 0;

                        foreach (String spa_program_id in spa_program_id_arr)
                        {
                            using (register_coupon registerCoupon = new register_coupon())
                            {
                                registerCoupon.Owner = this;
                                registerCoupon.membercard_id = ((ComboItem)membercard_id.SelectedItem).Key.ToString();
                                registerCoupon.event_text = "MEMBER CARD : #" + member_card_no;
                                registerCoupon.payment_type = "3";
                                
                                registerCoupon.selected_spa_program_id = spa_program_id;
                                registerCoupon.selected_discount_amount = spa_program_disc_amt_arr[index];
                                registerCoupon.selected_discount_unit = spa_program_disc_unit_arr[index];

                                registerCoupon.ShowDialog();
                            }
                            index++;
                        }
                    }
                }
            }
            ((coupon)Owner).btn_dgv.refresh_btn.PerformClick();
            this.Close();
        }

        private void coupon_manage_SizeChanged(object sender, EventArgs e)
        {
            manage_btn.Left = this.Width - 229;
        }

        private void discount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void coupon_manage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Activate();
        }

        private void code_begin_Leave(object sender, EventArgs e)
        {
            if (code_end.Text.Trim() == "") code_end.Text = code_begin.Text.Trim();
        }

        private void simple_coupon_rb_CheckedChanged(object sender, EventArgs e)
        {
            if (simple_coupon_rb.Checked)
            {
                Height = 672;
                manage_btn.Top = 571;
                payment_panel.Top = 423;
                if (this.Controls.Find("single_coupon_panel", true).Count<Control>() == 0) this.Controls.Add(single_coupon_panel);
                if (this.Controls.Find("payment_panel", true).Count<Control>() == 0) this.Controls.Add(payment_panel);
                manage_btn.Left = 286;
                coupon_set.Enabled = false;

                spa_program_id.SelectedIndex = 0;
                spa_program_id.Enabled = true;
                discount_lbl.Text = "DISCOUNT : ";
                discount_unit.SelectedIndex = 0;
                discount_unit.Enabled = true;
                discount_amount.Text = "100";
            }
        }

        private void money_coupon_rb_CheckedChanged(object sender, EventArgs e)
        {
            if (money_coupon_rb.Checked)
            {
                Height = 672;
                manage_btn.Top = 571;
                payment_panel.Top = 423;
                if (this.Controls.Find("single_coupon_panel", true).Count<Control>() == 0) this.Controls.Add(single_coupon_panel);
                if (this.Controls.Find("payment_panel", true).Count<Control>() == 0) this.Controls.Add(payment_panel);
                manage_btn.Left = 286;
                coupon_set.Enabled = false;

                spa_program_id.SelectedIndex = 0;
                spa_program_id.Enabled = false;
                discount_lbl.Text = "BALANCE : ";
                discount_unit.SelectedIndex = 1;
                discount_unit.Enabled = false;
                discount_amount.Text = "";
            }
        }

        private void coupon_set_rb_CheckedChanged(object sender, EventArgs e)
        {
            if (coupon_set_rb.Checked)
            {
                if (this.Controls.Find("single_coupon_panel", true).Count<Control>() != 0) this.Controls.Remove(single_coupon_panel);
                if (this.Controls.Find("payment_panel", true).Count<Control>() == 0) this.Controls.Add(payment_panel);
                payment_panel.Top = 185;
                manage_btn.Top = 333;
                Height = 433;
                manage_btn.Left = 286;
                coupon_set.Enabled = true;
            }
        }

        private void membercard_rb_CheckedChanged(object sender, EventArgs e)
        {
            if (membercard_rb.Checked)
            {
                if (this.Controls.Find("single_coupon_panel", true).Count<Control>() != 0) this.Controls.Remove(single_coupon_panel);
                if (this.Controls.Find("payment_panel", true).Count<Control>() != 0) this.Controls.Remove(payment_panel);
                manage_btn.Top = 185;
                Height = 287;
                manage_btn.Left = 286;
                membercard_id.Enabled = true;
            }
        }

        private void personal_credit_rb_CheckedChanged(object sender, EventArgs e)
        {
            if (personal_credit_rb.Checked)
            {
                debtor_id.SetText(-1, "");
                debtor_id.Enabled = true;
                debtor_id.Select();
            }
            else
            {
                debtor_id.Enabled = false;
                debtor_id.SetText(-1, "");
            }
        }

        private void code_begin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void code_end_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void discount_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
