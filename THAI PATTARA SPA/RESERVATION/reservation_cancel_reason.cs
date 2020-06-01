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
    public partial class reservation_cancel_reason : Form
    {
        public reservation_cancel_reason()
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
                MessageBox.Show("PLEASE ENTER REASON OF CANCELLATION !!", "ERROR");
                reason.Focus();
                return;
            }

            ((reservation_manage)Owner).cancel_reason = reason.Text.Trim();
            this.Close();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            ((reservation_manage)Owner).cancel_reason = "";
        }
    }
}
