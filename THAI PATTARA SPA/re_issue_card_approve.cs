using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM
{
    public partial class re_issue_card_approve : Form
    {
        public int card_type = -1;
        int approve_id = -1;

        public re_issue_card_approve()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };
        }

        private void re_issue_card_approve_Load(object sender, EventArgs e)
        {
            if (GF.can_approve)
            {
                approve_id = GF.emp_id;
                approve_btn.PerformClick();
            }
            else
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
        }

        private void approve_btn_Click(object sender, EventArgs e)
        {
            if (!GF.can_approve && approve_id == -1)
            {
                MessageBox.Show("NEED TO APPROVE FOR ISSUE THE GIFT VOUCHER !!", "ERROR");
                approved_by.Focus();
                return;
            }

            using (card_print printPage = new card_print())
            {
                printPage.Owner = this;
                printPage.Text = "RE-ISSUE ";
                
                switch (card_type)
                {
                    case 50:
                        printPage.Text += "GIFT CERTIFICATE";
                        printPage.card_type = 2; // GIFT_CERTIFICATE
                        break;
                    case 99:
                        printPage.Text += "GIFT VOUCHER";
                        printPage.card_type = 3; // GIFT_VOUCHER
                        break;
                    default:
                        printPage.Text += "MEMBER CARD";
                        String queryString = "SELECT B.MEMBERCARD_TYPE_NAME FROM MEMBERCARD A INNER JOIN MEMBERCARD_TYPE B ON A.MEMBERCARD_TYPE_ID = B.MEMBERCARD_TYPE_ID WHERE A.MEMBERCARD_ID = " + GF.selected_id.ToString();
                        DataTable DT;
                        using (DT = DB.getS(queryString, null, "GET MEMBERCARD_TYPE_NAME", false))
                        {
                            if (DT.Rows[0]["MEMBERCARD_TYPE_NAME"].ToString().IndexOf("LIMITED") == -1) printPage.card_type = 0; // MEMBERCARD
                            else printPage.card_type = 1; // LIMITED EDITION MEMBERCARD
                        }
                        //GF.disableButton(printPage.attach_paper_btn);
                        break;
                }

                printPage.isReIssue = true;
                printPage.ShowDialog();
            }
            this.Close();
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
                String queryString = "SELECT * FROM EMPLOYEE WHERE EMP_ID = " + ((ComboItem)approved_by.SelectedItem).Key.ToString() + " AND approve_code = '" + CRYPT.Encode(approve_code.Text.Trim()) + "'";

                Dictionary<string, string> Params = new Dictionary<string, string>();
                /*Params.Add("@emp_id", ((ComboItem)approved_by.SelectedItem).Key.ToString());
                Params.Add("@approve_code", CRYPT.Encode(approve_code.Text.Trim()));*/

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

        private void approve_code_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && approve_code.Text.Trim() != "")
            {
                approve_btn.PerformClick();
            }
        }

        private void scan_btn_Click(object sender, EventArgs e)
        {
            using (scan_barcode scan = new scan_barcode())
            {
                scan.Mode = "APPROVER";
                scan.ShowDialog();
                approve_id = scan.theID;
            }
        }
    }
}
