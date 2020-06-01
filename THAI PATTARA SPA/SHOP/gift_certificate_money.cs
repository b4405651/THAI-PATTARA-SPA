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
    public partial class gift_certificate_money : Form
    {
        public int billID = -1;
        public Boolean is_website = false;

        public gift_certificate_money()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };

            price.KeyPress += (s, e) =>
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            };

            balance.KeyPress += (s, e) =>
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            };
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if (price.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER PRICE !!", "ERROR");
                price.Focus();
                return;
            }

            if (Convert.ToInt32(price.Text.Trim()) <= 0)
            {
                MessageBox.Show("PRICE MUST BE MORE THAN ZERO !!", "ERROR");
                price.Focus();
                return;
            }

            if (balance.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER BALANCE !!", "ERROR");
                balance.Focus();
                return;
            }

            if (Convert.ToInt32(balance.Text.Trim()) <= 0)
            {
                MessageBox.Show("BALANCE MUST BE MORE THAN ZERO !!", "ERROR");
                balance.Focus();
                return;
            }

            GF.showLoading(this);
            List<string> param = new List<string>();
            
            String subject = "";
            String amount = "";

            subject = "BALANCE : " + GF.formatNumber(Convert.ToInt32(balance.Text.Trim()));
            if (from_txt.Text.Trim() != "") subject += " [FROM " + from_txt.Text.Trim() + "]";
            if (for_txt.Text.Trim() != "") subject += " [FOR " + for_txt.Text.Trim() + "]";
            amount = price.Text.Trim();
            
            param.Add((is_website ? "WEBSITE " : "") + "MONEY GIFT CERTIFICATE");
            param.Add(subject);
            param.Add(GF.formatNumber(Convert.ToInt32(amount)));
            param.Add(Properties.Settings.Default.money_unit);
            param.Add((new Random().Next(1, 1000000) * -1).ToString());
            param.Add((new Random().Next(1, 1000000) * -1).ToString());
            param.Add("1");
            param.Add(Convert.ToInt32(amount).ToString());

            ((cashier)this.Owner).pushRow("GIFT_CERTIFICATE", param);
            ((cashier)this.Owner).updateTotal();
            GF.closeLoading();
            this.Close();
        }

        private void gift_certificate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Activate();
        }

        private void price_Leave(object sender, EventArgs e)
        {
            balance.Text = price.Text;
        }

        private void price_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void balance_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
