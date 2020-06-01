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
    public partial class users_edit : Form
    {
        public users_edit()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };
            //GF.resizeMgmtForm(this);
            using (DataTable myDT = DB.getS(@"SELECT 
                    A.username,
                    B.fullname owner,
                    CONVERT(VARCHAR, A.created_date, 101) + ' ' + CONVERT(VARCHAR, A.created_date, 108) created_date, 
                    D.fullname created_by
                FROM 
                    USERS A
                LEFT OUTER JOIN
                    EMPLOYEE B ON A.emp_id = B.emp_id
                LEFT OUTER JOIN
					USERS C ON A.created_by = C.user_id
				LEFT OUTER JOIN
                    EMPLOYEE D ON C.emp_id = C.emp_id
                WHERE A.user_id = " + GF.selected_id.ToString(), null, "GET USER DATA [" + GF.selected_id.ToString() + "]", false))
            {
                username.Text = myDT.Rows[0]["username"].ToString();
                fullname.Text = myDT.Rows[0]["owner"].ToString() == "" ? "S.A." : myDT.Rows[0]["owner"].ToString();
                created_by.Text = myDT.Rows[0]["created_by"].ToString() == "" ? "S.A." : myDT.Rows[0]["created_by"].ToString();
                created_on.Text = myDT.Rows[0]["created_date"].ToString().Split(' ')[0];
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            if (password.Text.Trim() == "")
            {
                MessageBox.Show("PASSWORD IS REQUIRED !!", "ERROR");
                password.Focus();
                return;
            }
            if (password2.Text.Trim() == "")
            {
                MessageBox.Show("PASSWORD VERIFICATION IS REQUIRED !!", "ERROR");
                password2.Focus();
                return;
            }
            if (password.Text.Trim() != password2.Text.Trim())
            {
                MessageBox.Show("PASSWORD AND PASSWORD VERIFICATION ARE MISMATCHED !!", "ERROR");
                password.Focus();
                return;
            }

            String QueryString = "UPDATE USERS SET password='" + GF.SHA256_encode(password.Text.Trim()) + @"' WHERE user_id=" + GF.selected_id.ToString();
            GF.showLoading(this);
            DB.beginTrans();
            if (DB.set(QueryString, "UPDATE USER"))
            {
                DB.close();
                GF.closeLoading();

                ((btn_dgv)this.Owner.Controls["btn_dgv"]).refresh_btn.PerformClick();
                this.Close();
            }
            else
            {
                MessageBox.Show("ERROR UPDATE USER !!", "ERROR");
                GF.closeLoading();
                return;
            }
        }

        private void users_edit_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Activate();
        }
    }
}
