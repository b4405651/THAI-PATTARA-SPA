using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.VOUCHER
{
    public partial class issue_e_voucher : Form
    {
        public issue_e_voucher()
        {
            InitializeComponent();
        }

        private void issue_e_voucher_Load(object sender, EventArgs e)
        {
            spa_program_id.Items.Add(new ComboItem(-1, "ALL"));
            String queryString = "SELECT * FROM SPA_PROGRAM WHERE IS_USE = 1 ORDER BY CODE";
            using (DataTable DT = DB.getS(queryString, null, "GET SPA_PROGRAM", false))
            {
                foreach (DataRow row in DT.Rows)
                {
                    spa_program_id.Items.Add(new ComboItem(Convert.ToInt32(row["SPA_PROGRAM_ID"].ToString()), "[" + row["CODE"].ToString() + "] " + row["PROGRAM_NAME"].ToString()));
                }
            }
            GF.resizeComboBox(spa_program_id);
            spa_program_id.SelectedIndex = 0;

            approved_by.Items.Add(new ComboItem(-1, "APPROVER"));
            approved_by.Items.Add(new ComboItem(0, "S.A."));

            queryString = "SELECT EMP_ID, FULLNAME FROM EMPLOYEE WHERE EMP_STATUS=1 AND CAN_APPROVE=1 ORDER BY FULLNAME";
            using (DataTable DT = DB.getS(queryString, null, "GET APPROVABLE EMPLOYEE", false))
            {
                foreach (DataRow row in DT.Rows)
                {
                    approved_by.Items.Add(new ComboItem(Convert.ToInt32(row["EMP_ID"].ToString()), row["FULLNAME"].ToString()));
                }
            }
            approved_by.SelectedIndex = 0;
            GF.resizeComboBox(approved_by);

            discount_unit.Items.Clear();
            discount_unit.Items.Add(new ComboItem(0, "%"));
            discount_unit.Items.Add(new ComboItem(1, Properties.Settings.Default.money_unit));
            discount_unit.SelectedIndex = 0;
            GF.resizeComboBox(discount_unit);

            DateTime theExpiryDate = Convert.ToDateTime(GF.TODAY());
            theExpiryDate = theExpiryDate.AddMonths(3);
            expiry_date.Text = theExpiryDate.ToString();
        }

        private void save_file_btn_Click(object sender, EventArgs e)
        {
            if (approve_code.Text.Trim() == "")
            {
                MessageBox.Show("NEED TO APPROVE FOR ISSUE THE GIFT VOUCHER !!", "ERROR");
                approved_by.Focus();
                return;
            }

            GF.selected_id = ((ComboItem)spa_program_id.SelectedItem).Key;
            using (card_print printPage = new card_print())
            {
                printPage.isFile = true;
                printPage.gv_issue_for = issue_for.Text.Trim();
                printPage.Owner = this;
                if (GF.selected_id.ToString() != "-1")
                {
                    GF.tmpText = discount_amount.Text.Trim() + " " + discount_unit.Text.Trim() + " " + expiry_date.Text.Trim();
                    printPage.Text = "E-VOUCHER # SPA MENU #" + GF.selected_id.ToString();
                }
                else
                {
                    printPage.Text = "E-VOUCHER # ALL SPA PROGRAM " + discount_amount.Text + " " + discount_unit.Text;
                    GF.tmpText = discount_amount.Text.Trim() + " " + discount_unit.Text.Trim() + " " + expiry_date.Text.Trim();
                }
                printPage.card_type = 3; // GIFT_VOUCHER
                printPage.approved_id = ((ComboItem)approved_by.SelectedItem).Key;
                printPage.ShowDialog();
            }

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
                Dictionary<string, string> Params = new Dictionary<string, string>();
                //Params.Add("@approve_code", CRYPT.Encode(approve_code.Text.Trim()));

                String queryString = "SELECT * FROM EMPLOYEE WHERE EMP_ID = " + ((ComboItem)approved_by.SelectedItem).Key.ToString() + " AND approve_code = '" + CRYPT.Encode(approve_code.Text.Trim()) + "'";
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

        private void issue_e_voucher_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Activate();
        }

        private void discount_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
