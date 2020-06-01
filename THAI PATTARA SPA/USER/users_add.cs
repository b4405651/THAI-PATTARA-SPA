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
    public partial class users_add : Form
    {
        public users_add()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };
            GF.resizeMgmtForm(this);
            emp_id.parentForm = this;
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            if (username.Text.Trim() == "")
            {
                MessageBox.Show("USERNAME IS REQUIRED !!", "ERROR");
                username.Focus();
                return;
            }
            if (password.Text.Trim() == "")
            {
                MessageBox.Show("PASSWORD IS REQUIRED !!", "ERROR");
                password.Focus();
                return;
            }
            if (password2.Text.Trim() == "")
            {
                MessageBox.Show("PASSWORD VERIFICATION IS REQUIRED !!", "ERROR");
                password.Focus();
                return;
            }
            if (password.Text.Trim() != password2.Text.Trim())
            {
                MessageBox.Show("PASSWORD AND PASSWORD VERIFICATION ARE MISMATCHED !!", "ERROR");
                password.Focus();
                return;
            }
            if (emp_id.Text == "")
            {
                MessageBox.Show("YOU DID NOT CHOOSE EMPLOYEE !!", "ERROR");
                emp_id.Focus();
                return;
            }
            String QueryString = "SELECT * FROM USERS WHERE USERNAME = '" + username.Text + "'";

            Dictionary<string, string> Params = new Dictionary<string, string>();
            //Params.Add("@username", username.Text);

            using (DataTable DT = DB.getS(QueryString, Params, "CHECK IF USERNAME EXISTED", false))
            {
                if (DT.Rows.Count > 0)
                {
                    MessageBox.Show("THIS USERNAME IS ALREADY EXISTED IN DATABASE !!", "ERROR");
                    return;
                }
            }

            DataTable myDT;
            String unique_key = "";
            do{
                unique_key = new Random().Next(1000000).ToString();
                QueryString = "SELECT COUNT(*) ROW_COUNT FROM USERS WHERE UNIQUE_KEY = '" + unique_key + "'";
                myDT = DB.getS(QueryString, null, "CHECK IF THE UNIQUE KEY IS USED.", false);
            } while (Convert.ToInt32(myDT.Rows[0]["ROW_COUNT"].ToString()) > 0);
            myDT.Dispose();

            QueryString = @"
                INSERT INTO USERS ( username, password, emp_id, created_date, created_by, unique_key)
                VALUES (
                    '" + username.Text.Trim().Replace("'", "''") + @"', 
                    '" + GF.SHA256_encode(password.Text.Trim()) + @"', ";
            if(emp_id.currentID == -1){
                QueryString += "NULL";
            } else {
                QueryString += emp_id.currentID.ToString();
            }
            QueryString += @", CONVERT(DATETIME, '" + GF.NOW() + "', 103), ";

            QueryString += GF.user_id.ToString() + ", '" + unique_key + "')";
            GF.showLoading(this);
            DB.beginTrans();
            if (DB.set(QueryString, "CREATE NEW USER"))
            {
                DB.close();
                GF.closeLoading();

                ((btn_dgv)this.Owner.Controls["btn_dgv"]).refresh_btn.PerformClick();
                this.Close();
            }
            else
            {
                MessageBox.Show("ERROR INSERT INTO DATABASE !!", "ERROR");
                GF.closeLoading();
                return;
            }
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void users_add_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Activate();
        }
    }
}
