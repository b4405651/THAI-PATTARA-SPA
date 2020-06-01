using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.USER
{
    public partial class change_pwd : Form
    {
        public change_pwd()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (password.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER NEW PASSWORD !!", "ERROR");
                password.Focus();
                return;
            }

            if (password2.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER THE VERIFY PASSWORD !!", "ERROR");
                password2.Focus();
                return;
            }

            if(password.Text.Trim() != password2.Text.Trim())
            {
                MessageBox.Show("NEW PASSWORD AND VERIFY PASSWORD ARE MISMATCHED !!", "ERROR");
                password2.Focus();
                return;
            }

            String queryString = "UPDATE USERS SET PASSWORD = '" + GF.SHA256_encode(password.Text.Trim()) + "' WHERE USER_ID = " + GF.user_id.ToString();
            GF.showLoading(this);
            DB.beginTrans();
            if (!DB.set(queryString, "CHANGE PASSWORD FOR USER_ID[" + GF.user_id.ToString() + "]"))
            {
                MessageBox.Show("ERROR UPDATE PASSWORD !!", "ERROR");
                GF.closeLoading();
                return;
            }
            DB.close();
            MessageBox.Show("PASSWORD IS UPDATED !!", "COMPLETED");
            GF.closeLoading();
            this.Close();
        }
    }
}
