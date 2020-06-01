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
    public partial class register_coupon : Form
    {
        public string event_text = "";
        public string membercard_id = "-1";
        public string selected_spa_program_id = "-99";
        public string selected_discount_amount = "100";
        public string selected_discount_unit = "0";
        public string coupon_set_id = "-1";
        public string debtor_id = "-1";
        public string payment_type = "-1";
        public string expire_amount = "-1";
        public string expire_unit = "-1";
        public bool preventTransManage = false;
        String queryString = "";

        public register_coupon()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };
        }

        private void register_coupon_Load(object sender, EventArgs e)
        {
            int index = 0;
            int selected_index = 0;
            GF.doDebug("SELECTED_SPA_PROGRAM_ID = " + selected_spa_program_id.ToString());
            spa_program_id.Items.Add(new ComboItem(-99, "MONEY COUPON"));
            spa_program_id.Items.Add(new ComboItem(-1, "ALL SPA PROGRAM"));
            queryString = "SELECT * FROM SPA_PROGRAM WHERE IS_USE = 1 ORDER BY CODE";
            using (DataTable DT = DB.getS(queryString, null, "GET ALL ACTIVE SPA PROGRAM", false))
            {
                foreach (DataRow row in DT.Rows)
                {
                    index++;
                    spa_program_id.Items.Add(new ComboItem(Convert.ToInt32(row["SPA_PROGRAM_ID"].ToString()), "[#" + row["CODE"].ToString() + "] " + row["PROGRAM_NAME"].ToString()));
                    if (selected_spa_program_id == row["SPA_PROGRAM_ID"].ToString()) selected_index = (index + 1);
                }
            }
            spa_program_id.SelectedIndex = selected_index;
            GF.resizeComboBox(spa_program_id);
            //if (selected_spa_program_id != "-99") spa_program_id.Enabled = false;

            discount_unit.Items.Clear();
            discount_unit.Items.Add(new ComboItem(0, "%"));
            discount_unit.Items.Add(new ComboItem(1, Properties.Settings.Default.money_unit));
            if (selected_spa_program_id == "-99")
            {
                discount_lbl.Text = "BALANCE : ";
                discount_unit.SelectedIndex = 1;
                discount_amount.Select();
            }
            else
            {
                discount_unit.SelectedIndex = 0;
            }
            discount_amount.Text = selected_discount_amount;
            GF.resizeComboBox(discount_unit);

            DateTime theExpiryDate = Convert.ToDateTime(GF.TODAY());
            if(expire_amount == "-1" && expire_unit == "-1")
                theExpiryDate = theExpiryDate.AddMonths(3);
            else
            {
                if (expire_unit == "0")
                    theExpiryDate = theExpiryDate.AddMonths(Convert.ToInt32(expire_amount));
                if (expire_unit == "1")
                    theExpiryDate = theExpiryDate.AddYears(Convert.ToInt32(expire_amount));
            }
                
            expiry_date.Text = theExpiryDate.ToString();

            if (selected_spa_program_id != "-99") card_no.Select();
        }

        private void card_no_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (card_no.Text.Trim() != "")
                {
                    if (discount_amount.Text.Trim() == "")
                    {
                        if ((spa_program_id.SelectedItem as ComboItem).Key.ToString() != "-99")
                            MessageBox.Show("PLEASE ENTER DISCOUNT AMOUNT !!", "ERROR");
                        else
                            MessageBox.Show("PLEASE ENTER BALANCE OF MONEY COUPON !!", "ERROR");
                        discount_amount.Focus();
                        return;
                    }

                    long tmp = -1;
                    if (!Int64.TryParse(card_no.Text.Trim(), out tmp))
                    {
                        MessageBox.Show("CARD NO. MUST BE ONLY NUMBER !!", "ERROR");
                        card_no.Select();
                        return;
                    }

                    if (Convert.ToInt32(discount_amount.Text.Trim()) <= 0)
                    {
                        if ((spa_program_id.SelectedItem as ComboItem).Key.ToString() != "-99")
                            MessageBox.Show("DISCOUNT AMOUNT MUST BE MORE THAN ZERO !!", "ERROR");
                        else
                            MessageBox.Show("BALANCE OF MONEY COUPON MUST BE MORE THAN ZERO !!", "ERROR");
                        discount_amount.Focus();
                        return;
                    }

                    Dictionary<string, string> Params = new Dictionary<string, string>();
                    //Params.Add("@card_no", card_no.Text);

                    queryString = "SELECT * FROM COUPON WHERE CARD_NO = '" + card_no.Text + "' AND IS_VOID = 0";
                    using (DataTable DT = DB.getS(queryString, Params, "CHECK IF COUPON NO [" + card_no.Text.Trim() + "] IS EXISTED", false))
                    {
                        if (DT.Rows.Count > 0)
                        {
                            MessageBox.Show("COUPON NO " + card_no.Text.Trim() + " IS ALREADY EXISTED !!", "ERROR");
                            card_no.Text = "";
                            card_no.Focus();
                            return;
                        }
                    }

                    queryString = "INSERT INTO COUPON (";
                    if ((spa_program_id.SelectedItem as ComboItem).Key.ToString() == "-99")
                        queryString += "CARD_NO, SPA_PROGRAM_ID, EXPIRY_DATE, SOLD_ON, PRICE, CREATED_BY, CREATED_DATE, PAYMENT_TYPE, DEBTOR_ID, COUPON_SET_ID, EVENT_NAME, BALANCE, BALANCE_MAX, MEMBERCARD_ID";
                    else
                        queryString += "CARD_NO, SPA_PROGRAM_ID, EXPIRY_DATE, SOLD_ON, PRICE, CREATED_BY, CREATED_DATE, PAYMENT_TYPE, DEBTOR_ID, COUPON_SET_ID, EVENT_NAME, DISCOUNT_AMOUNT, DISCOUNT_UNIT, MEMBERCARD_ID";
                    queryString += ") VALUES (";
                    queryString += "'" + card_no.Text.Trim() + "', ";
                    queryString += ((ComboItem)spa_program_id.SelectedItem).Key.ToString() + ", ";
                    queryString += GF.modDate(expiry_date.Text.Trim()) + ", ";
                    queryString += GF.modDate(GF.TODAY()) + ", ";
                    queryString += "0, ";
                    queryString += GF.emp_id.ToString() + ", ";
                    queryString += "CURRENT_TIMESTAMP, ";
                    queryString += payment_type + ", ";
                    queryString += (debtor_id == "-1" ? "NULL" : debtor_id) + ", ";
                    queryString += (coupon_set_id == "-1" ? "NULL" : coupon_set_id) + ", ";
                    queryString += "'" + event_text + "', ";
                    if ((spa_program_id.SelectedItem as ComboItem).Key.ToString() != "-99")
                    {
                        queryString += discount_amount.Text.Trim() + ", ";
                        queryString += ((ComboItem)discount_unit.SelectedItem).Key.ToString() + ", ";
                    }
                    else
                    {
                        queryString += discount_amount.Text.Trim() + ", ";
                        queryString += discount_amount.Text.Trim() + ", ";
                    }
                    queryString += membercard_id;
                    queryString += ")";

                    GF.showLoading(this);
                    if(!preventTransManage) DB.beginTrans();
                    if (!DB.set(queryString, "REGISTER COUPON NO [" + card_no.Text.Trim() + "] INTO DATABASE"))
                    {
                        GF.closeLoading();
                        MessageBox.Show("ERROR ADDING DATA !!", "ERROR");
                        return;
                    }
                    if (!preventTransManage) DB.close();
                    GF.closeLoading();
                    this.Close();
                }
            }
        }

        private void discount_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void card_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
