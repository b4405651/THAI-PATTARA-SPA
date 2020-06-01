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
    public partial class misc_item : Form
    {
        public string item_type = "MISC. ITEM";
        public misc_item()
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

        private void price_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void price_TextChanged(object sender, EventArgs e)
        {
            if (unit_price.Text.Trim() != "") updateTotalPrice();
        }

        private void amount_TextChanged(object sender, EventArgs e)
        {
            if (amount.Text.Trim() != "") updateTotalPrice();
        }

        void updateTotalPrice()
        {
            int the_unit_price = 0;
            int the_amount = 0;

            if (unit_price.Text.Trim() != "" && amount.Text.Trim() != "")
            {
                if (Int32.TryParse(unit_price.Text.Trim(), out the_unit_price) && Int32.TryParse(amount.Text.Trim(), out the_amount))
                {
                    total_price.Text = GF.formatNumber(the_unit_price * the_amount) + " Rub";
                }
                else total_price.Text = "0 Rub";
            }
            else total_price.Text = "0 Rub";
            
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if (misc_name.Text.Trim() == "" && misc_name.Enabled)
            {
                MessageBox.Show("PLEASE ENTER THE NAME OF ITEM !!", "ERROR");
                return;
            }

            if (unit_price.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER THE PRICE OF ITEM !!", "ERROR");
                return;
            }

            List<String> param = new List<string>();

            int price = Convert.ToInt32(GF.removeThousandAndDecimal(total_price.Text.Substring(0, total_price.Text.Trim().Length - 4)));

            param.Add(item_type);
            param.Add(misc_name.Text.Trim() + " [" + amount.Text.Trim() + "]");
            param.Add(GF.formatNumber(price));
            param.Add(Properties.Settings.Default.money_unit);
            param.Add("-1");
            param.Add((new Random().Next(1, 1000000) * -1).ToString());
            param.Add("0");
            param.Add(Convert.ToInt32(unit_price.Text.Trim()).ToString());

            ((cashier)this.Owner).pushRow("ITEM", param);
            ((cashier)this.Owner).updateTotal();

            GF.enableButton(((cashier)this.Owner).invoice_btn);
            if (((cashier)this.Owner).invoice_datetime != "")
            {
                GF.enableButton(((cashier)this.Owner).pay_by_cash_btn);
                GF.enableButton(((cashier)this.Owner).pay_by_credit_card_btn);
            }
            ((cashier)this.Owner).toggleAllDiscount("ENABLE");

            GF.closeLoading();
            this.Close();
        }

        private void misc_item_Load(object sender, EventArgs e)
        {
            /*if (item_type.Trim() == "MANGO")
                misc_name.Enabled = false;
            else
                misc_name.Enabled = true;*/
        }
    }
}
