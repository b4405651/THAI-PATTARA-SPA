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
    public partial class void_reason : Form
    {
        public void_reason()
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
            if (reason.Text == "")
            {
                MessageBox.Show("PLEASE ENTER THE VOID REASON !!", "ERROR");
                reason.Focus();
                return;
            }

            ((cashier)Owner).void_reason = reason.Text.Trim();
            this.Close();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            ((cashier)Owner).void_reason = "";
        }

        private void void_reason_Load(object sender, EventArgs e)
        {
            reason.Text = ((cashier)Owner).void_reason;
        }
    }
}
