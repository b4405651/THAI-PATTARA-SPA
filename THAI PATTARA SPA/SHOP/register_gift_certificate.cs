using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.SHOP
{
    public partial class register_gift_certificate : Form
    {
        public Boolean is_website = false;
        String queryString = "";
        List<string> price_list;

        public register_gift_certificate()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };
        }

        private void register_gift_certificate_Load(object sender, EventArgs e)
        {
            queryString = "SELECT * FROM SPA_PROGRAM WHERE IS_USE = 1 ORDER BY CODE";
            using (DataTable DT = DB.getS(queryString, null, "GET ALL ACTIVE SPA PROGRAM", false))
            {
                price_list = new List<string>();
                spa_program_id.Items.Add(new ComboItem(-1, "== SPA PROGRAM =="));
                foreach (DataRow row in DT.Rows)
                {
                    spa_program_id.Items.Add(new ComboItem(Convert.ToInt32(row["SPA_PROGRAM_ID"].ToString()), "[#" + row["CODE"].ToString() + "] " + row["PROGRAM_NAME"].ToString()));
                    price_list.Add(row["PRICE"].ToString());
                }
            }
            spa_program_id.SelectedIndex = 0;
            GF.resizeComboBox(spa_program_id);

            discount_unit.Items.Clear();
            discount_unit.Items.Add(new ComboItem(0, "%"));
            discount_unit.Items.Add(new ComboItem(1, Properties.Settings.Default.money_unit));
            discount_unit.SelectedIndex = 0;
            GF.resizeComboBox(discount_unit);

            int expire_amount = -1;
            int expire_unit = -1;
            queryString = "SELECT * FROM GIFT_CERTIFICATE_CONFIG";
            using (DataTable DT = DB.getS(queryString, null, "GET GIFT CERTIFICATE CONFIG", false))
            {
                // GET GIFT CERTIFICATE CONFIG
                expire_amount = Convert.ToInt32(DT.Rows[0]["EXPIRE_AMOUNT"].ToString());
                expire_unit = Convert.ToInt32(DT.Rows[0]["EXPIRE_UNIT"].ToString());
            }

            DateTime theExpiryDate = Convert.ToDateTime(GF.TODAY());
            if (expire_unit == 0) theExpiryDate = theExpiryDate.AddMonths(expire_amount);
            if (expire_unit == 1) theExpiryDate = theExpiryDate.AddYears(expire_amount);
            expiry_date.Text = theExpiryDate.ToString();

            card_no.Select();
        }

        private void price_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void price_Leave(object sender, EventArgs e)
        {
            balance.Text = price.Text;
        }

        private void card_no_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (card_no.Text.Trim() != "")
                {
                    if (choiceTab.SelectedTab.Name == "spaTab")
                    {
                        if (spa_program_id.SelectedIndex == 0)
                        {
                            MessageBox.Show("PLEASE CHOOSE SPA PROGRAM !!", "ERROR");
                            spa_program_id.Focus();
                            return;
                        }

                        if (discount_amount.Text.Trim() == "")
                        {
                            MessageBox.Show("PLEASE ENTER DISCOUNT AMOUNT !!", "ERROR");
                            discount_amount.Select();
                            return;
                        }

                        if (Convert.ToInt32(discount_amount.Text.Trim()) <= 0)
                        {
                            MessageBox.Show("DISCOUNT AMOUNT MUST BE MORE THAN ZERO !!", "ERROR");
                            discount_amount.Select();
                            return;
                        }
                    }

                    if (choiceTab.SelectedTab.Name == "moneyTab")
                    {
                        if (price.Text.Trim() == "")
                        {
                            MessageBox.Show("PLEASE ENTER PRICE OF GIFT CERTIFICATE !!", "ERROR");
                            price.Select();
                            return;
                        }

                        if (Convert.ToInt32(price.Text.Trim()) <= 0)
                        {
                            MessageBox.Show("PRICE MUST BE MORE THAN ZERO !!", "ERROR");
                            price.Select();
                            return;
                        }

                        if (balance.Text.Trim() == "")
                        {
                            MessageBox.Show("PLEASE ENTER USABLE AMOUNT OF GIFT CERTIFICATE !!", "ERROR");
                            price.Select();
                            return;
                        }

                        if (Convert.ToInt32(balance.Text.Trim()) <= 0)
                        {
                            MessageBox.Show("BALANCE MUST BE MORE THAN ZERO !!", "ERROR");
                            price.Select();
                            return;
                        }
                    }

                    long tmp = -1;
                    if (!Int64.TryParse(card_no.Text.Trim(), out tmp))
                    {
                        MessageBox.Show("CARD NO. MUST BE ONLY NUMBER !!", "ERROR");
                        card_no.Select();
                        return;
                    }

                    // PUT RECORD INTO CASHIER DGV
                    List<string> param = new List<string>();
                    String subject = "";
                    String amount = "";

                    if (choiceTab.SelectedTab.Name == "spaTab")
                    {
                        subject = spa_program_id.Text + " CARD NO : " + card_no.Text.Trim() + " EXPIRE : " + expiry_date.Text.Trim();
                        amount = price_list[spa_program_id.SelectedIndex - 1];

                        param.Add((is_website ? "WEBSITE " : "") + "SPA MENU GIFT CERTIFICATE");
                        param.Add(subject);
                        param.Add(GF.formatNumber(Convert.ToInt32(amount)));
                        param.Add(Properties.Settings.Default.money_unit);
                        param.Add((new Random().Next(1, 1000000) * -1).ToString());
                        param.Add((new Random().Next(1, 1000000) * -1).ToString());
                        param.Add("1");
                        param.Add(Convert.ToInt32(amount).ToString());
                    }

                    if (choiceTab.SelectedTab.Name == "moneyTab")
                    {
                        subject = "BALANCE : " + GF.formatNumber(Convert.ToInt32(balance.Text.Trim())) + " CARD NO : " + card_no.Text.Trim() + " EXPIRE : " + expiry_date.Text.Trim();
                        amount = price.Text.Trim();

                        param.Add((is_website ? "WEBSITE " : "") + "MONEY GIFT CERTIFICATE");
                        param.Add(subject);
                        param.Add(GF.formatNumber(Convert.ToInt32(amount)));
                        param.Add(Properties.Settings.Default.money_unit);
                        param.Add((new Random().Next(1, 1000000) * -1).ToString());
                        param.Add((new Random().Next(1, 1000000) * -1).ToString());
                        param.Add("1");
                        param.Add(Convert.ToInt32(amount).ToString());
                    }

                    ((cashier)this.Owner).pushRow("GIFT_CERTIFICATE", param);
                    ((cashier)this.Owner).updateTotal();
                    this.Close();
                }
            }
        }

        private void choiceTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (choiceTab.SelectedTab.Name == "spaTab")
            {
                spa_program_id.SelectedIndex = 0;
                discount_amount.Text = "100";
                discount_unit.SelectedIndex = 0;
            }

            if (choiceTab.SelectedTab.Name == "moneyTab")
            {
                price.Text = "";
                balance.Text = "";
            }
        }

        private void discount_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void balance_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
