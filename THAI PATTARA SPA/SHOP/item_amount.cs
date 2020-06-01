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
    public partial class item_amount : Form
    {
        public item_amount()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };
        }

        private void amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void amount_KeyUp(object sender, KeyEventArgs e)
        {
            if (amount.Text.Trim() != "" && e.KeyCode == Keys.Return)
            {
                if (GF.isValidInt32(amount.Text.Trim()))
                {
                    ((cashier)this.Owner).item_amount = Convert.ToInt32(amount.Text.Trim());
                    this.Close();
                }
            }
        }

        private void item_amount_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !amount.Enabled)
            {
                amount.Enabled = true;
                amount.Select();
            }
        }
    }
}
