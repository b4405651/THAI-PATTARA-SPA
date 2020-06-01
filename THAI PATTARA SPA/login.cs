using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM
{
    public partial class login : Form
    {
        bool loginClicked = false;
        string theCode = "";
        string loginString = @"
        SELECT 
            A.USER_ID,
            A.USERNAME,
            A.PASSWORD,
            A.EMP_ID,
            A.IS_USE,
            B.FULLNAME, 
            B.CAN_APPROVE,
            CONVERT(NVARCHAR(MAX), A.LAST_LOGIN, 103) + ' ' + CONVERT(NVARCHAR(MAX), A.LAST_LOGIN, 108) LAST_LOGIN
        FROM USERS A
        LEFT OUTER JOIN EMPLOYEE B ON A.EMP_ID = B.EMP_ID";

        public login()
        {
            InitializeComponent();
            GF.doDebug("===== MAIN FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== MAIN FORM :: " + this.Name + " IS CLOSED =====");
            };
            foreach (InputLanguage IL in InputLanguage.InstalledInputLanguages)
            {
                if (IL.LayoutName.ToString() == "US")
                {
                    InputLanguage.CurrentInputLanguage = IL;
                    break;
                }
            }
        }

        private void login_btn_Click(object sender, EventArgs e) // MANUAL LOGIN
        {
            if (username.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER YOUR USERNAME !!", "ERROR");
                username.Focus();
                return;
            }

            if (password.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER YOUR PASSWORD !!", "ERROR");
                password.Focus();
                return;
            }

            String queryString = loginString + @"
            WHERE A.USERNAME LIKE '" + username.Text + @"' 
            AND A.PASSWORD LIKE '" + GF.SHA256_encode(password.Text.Trim()) + @"'
            AND A.IS_USE = 1";

            Dictionary<string, string> Params = new Dictionary<string, string>();
            /*Params.Add("@username", username.Text);
            Params.Add("@password", GF.SHA256_encode(password.Text.Trim()));*/

            using (DataTable myDT = SPA_MANAGEMENT_SYSTEM.DB.getS(queryString, Params, "LOGIN BY KEY ATTEMPTED", false))
            {

                if (myDT.Rows.Count == 0)
                {
                    // LOGIN FAILED !!
                    MessageBox.Show("LOGIN FAILED !!\r\n\r\nPLEASE CHECK YOUR USERNAME OR PASSWORD.", "ERROR");
                    password.Text = "";
                    password.Focus();
                }
                else
                {
                    //MessageBox.Show("LOGIN SUCCESS !!\r\n\r\nYOU CAN NOW PROCEED.");
                    initMainPage(myDT);
                }
            }
        }

        private void login_KeyDown(object sender, KeyEventArgs e) // KEYCARD LOGIN
        {
            if (e.KeyCode == Keys.Escape)
            {
                theCode = "";
                this.Height = 338;

                int x = Screen.PrimaryScreen.Bounds.Width / 2 - this.Width / 2;
                int y = Screen.PrimaryScreen.Bounds.Height / 2 - this.Height / 2;
                this.Location = new Point(x, y);

                username.TabStop = true;
                password.TabStop = true;
                login_btn.TabStop = true;
                exit_btn.TabStop = true;

                username.Focus();
            }
            else if (e.KeyCode == Keys.Enter && theCode.Trim() != "")
            {
                String queryString = loginString + @"
                WHERE A.unique_key = '" + theCode.Trim().Replace("NumPad", "") + @"' 
                AND A.IS_USE = 1";

                Dictionary<string, string> Params = new Dictionary<string, string>();
                //Params.Add("@thecode", theCode.Trim().Replace("NumPad", ""));

                theCode = "";
                using (DataTable myDT = SPA_MANAGEMENT_SYSTEM.DB.getS(queryString, Params, "LOGIN BY SCAN ATTEMPTED", false))
                {
                    if (myDT.Rows.Count == 0)
                    {
                        // LOGIN FAILED !!
                        MessageBox.Show("LOGIN FAILED !!\r\n\r\nPLEASE CHECK YOUR CARD !!", "ERROR");
                    }
                    else
                    {
                        //MessageBox.Show("LOGIN SUCCESS !!\r\n\r\nYOU CAN NOW PROCEED.");
                        initMainPage(myDT);
                    }
                }

            }
            else
            {
                if (e.KeyCode.ToString().Length == 2 && e.KeyCode.ToString()[0] == 'D')
                    theCode += e.KeyCode.ToString()[1];
                else
                    theCode += e.KeyCode.ToString();
            }
        }

        private void initMainPage(DataTable myDT)
        {
            loginClicked = true;
            GF.username = myDT.Rows[0]["USERNAME"].ToString();
            GF.user_id = Convert.ToInt32(myDT.Rows[0]["USER_ID"].ToString());

            AUTH.setMenu(GF.mainPage, GF.username, GF.user_id.ToString());

            // INIT USER PARAMETERS
            GF.mainPage.statusStrip1.Items[1].ForeColor = Color.LightCoral;
            if (GF.username == "admin")
            {
                GF.mainPage.statusStrip1.Items[1].Text = "SYSTEM ADMINISTRATOR";
                GF.can_approve = true;
            }
            else
            {
                GF.mainPage.statusStrip1.Items[1].Text = myDT.Rows[0]["FULLNAME"].ToString();
                GF.can_approve = (myDT.Rows[0]["CAN_APPROVE"].ToString() == "1" ? true : false);
            }

            GF.mainPage.statusStrip1.Items[3].ForeColor = Color.LightCoral;
            GF.mainPage.statusStrip1.Items[3].Text = myDT.Rows[0]["last_login"].ToString();

            if (GF.username == "admin")
            {
                GF.emp_id = 0;
            }
            else if (myDT.Rows[0]["emp_id"].ToString() != "")
            {
                GF.emp_id = Convert.ToInt32(myDT.Rows[0]["emp_id"].ToString());
            }
            GF.is_logged_in = true;

            /*PRINT printPage = new PRINT(false, "INVOICE", "", this, "255703020001");
            GF.selected_id = 207;
            PRINT print = new PRINT(false, "SPA_CARD_NEW", "SPA_CARD_NEW.jpg", this, "8");*/

            //return;
            this.Hide();

            GF.mainPage.MainMenuStrip.Items["logOutTopToolStripMenuItem"].Select();

            /*card_print printPage = new card_print();
            printPage.card_type = 2;
            //GF.selected_id = 28; // SPA PROGRAM
            GF.selected_id = 29; // MONEY
            printPage.ShowDialog();*/


            //mainPage.timenow_sl.Text = "";
            GF.mainPage.Show();
            GF.mainPage.BringToFront();
            GF.mainPage.Activate();
        }

        private void username_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                login_btn.PerformClick();
            }
        }

        private void password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                login_btn.PerformClick();
            }
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!loginClicked) Application.Exit();
        }

        private void username_Enter(object sender, EventArgs e)
        {
            username.SelectAll();
        }

        private void password_Enter(object sender, EventArgs e)
        {
            password.SelectAll();
        }
    }
}
