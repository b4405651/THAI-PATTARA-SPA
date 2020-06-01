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
    public partial class reservation_approve : Form
    {
        bool approved = false;
        public reservation_approve()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };
        }

        private void reservation_approve_Load(object sender, EventArgs e)
        {
            approved_by.Items.Add(new ComboItem(-1, "APPROVER"));
            approved_by.Items.Add(new ComboItem(0, "S.A."));
            String queryString = "SELECT EMP_ID, FULLNAME FROM EMPLOYEE WHERE EMP_STATUS=1 AND CAN_APPROVE=1 ORDER BY FULLNAME";
            using (DataTable DT = DB.getS(queryString, null, "GET APPROVABLE EMPLOYEE", false))
            {
                foreach (DataRow row in DT.Rows)
                {
                    approved_by.Items.Add(new ComboItem(Convert.ToInt32(row["EMP_ID"].ToString()), row["FULLNAME"].ToString()));
                }
            }
            approved_by.SelectedIndex = 0;
            GF.resizeComboBox(approved_by);
        }

        private void approve_btn_Click(object sender, EventArgs e)
        {
            if (approve_code.Text.Trim() == "")
            {
                MessageBox.Show("APPROVE CODE IS REQUIRED !!", "ERROR");
                approved_by.Focus();
                return;
            }
            approved = true;
            ((reservation_manage)Owner).isApproved = approved;
            this.Close();
        }

        private void approve_code_Leave(object sender, EventArgs e)
        {
            if (((ComboItem)approved_by.SelectedItem).Key == 0)
            {
                if (approve_code.Text.Trim() != GF.SAapproveCode)
                {
                    MessageBox.Show("APPROVE CODE IS NOT CORRECT !!", "ERROR");
                    approve_code.Focus();
                    return;
                }
            }
            else
            {
                String queryString = "SELECT * FROM EMPLOYEE WHERE EMP_ID = " + ((ComboItem)approved_by.SelectedItem).Key.ToString() + " AND approve_code = '" + approve_code.Text + "'";

                Dictionary<string, string> Params = new Dictionary<string, string>();
                //Params.Add("@approve_code", approve_code.Text);

                using (DataTable DT = DB.getS(queryString, Params, "CHECK APPROVE CODE WITH EMP_ID[" + ((ComboItem)approved_by.SelectedItem).Key.ToString() + "]", false))
                {
                    if (DT.Rows.Count == 0)
                    {
                        MessageBox.Show("APPROVE CODE IS NOT CORRECT !!", "ERROR");
                        approve_code.Focus();
                        return;
                    }
                }
            }
        }

        private void spa_card_approve_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((reservation_manage)this.Owner).isApproved = approved;
        }

        private void spa_card_approve_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Activate();
        }

        private void approved_by_SelectedIndexChanged(object sender, EventArgs e)
        {
            approve_code.Text = "";
            if (((ComboItem)((ComboBox)sender).SelectedItem).Key == -1) approve_code.Enabled = false;
            else
            {
                approve_code.Enabled = true;
                approve_code.Focus();
            }
        }

        private void approve_code_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) approve_btn.PerformClick();
        }
    }
}
