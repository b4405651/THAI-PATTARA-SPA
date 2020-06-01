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
    public partial class other_discount : Form
    {
        public int billID = -1;
        public int approve_id = -1;
        int card_id = -1;
        DataRow card_data;

        public other_discount()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };
            
            GF.resizeMgmtForm(this);

            discount_type.Items.Add(new ComboItem(0, "OTHER"));
            discount_type.Items.Add(new ComboItem(1, "BARTER"));
            discount_type.SelectedIndex = 0;
            GF.resizeComboBox(discount_type);

            unit.Items.Add(new ComboItem(0, "%"));
            unit.Items.Add(new ComboItem(1, Properties.Settings.Default.money_unit));
            unit.SelectedIndex = 0;
            GF.resizeComboBox(unit);
        }

        private void other_discount_Load(object sender, EventArgs e)
        {
            GF.showLoading(this);
            item.Items.Add(new ComboItem(-1, "TOTAL"));

            foreach (DataGridViewRow row in ((cashier)Owner).btn_dgv.DGV.Rows)
            {
                if (row.Cells["ITEM_TYPE"].Value != null)
                {
                    // "ITEM_ID" BELOW IS "BILL_DETAIL_ID"
                    if ((row.Cells["ITEM_TYPE"].Value.ToString() == "MASSAGE" || row.Cells["ITEM_TYPE"].Value.ToString() == "RETAIL ITEM") && row.Cells["APPLY_DISCOUNT"].Value.ToString() == "1" && Convert.ToInt32(GF.removeThousandAndDecimal(row.Cells["AMOUNT_LEFT"].Value.ToString())) > 0)
                    {
                        item.Items.Add(new ComboItem(Convert.ToInt32(row.Cells["BILL_TARGET_ID"].Value.ToString()), row.Cells["DETAIL"].Value.ToString() + " (" + row.Cells["AMOUNT"].Value.ToString() + ")"));
                    }
                }
            }

            item.SelectedIndex = 0;
            GF.resizeComboBox(item);
            
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
            GF.closeLoading();
            if (GF.can_approve)
                approve_id = GF.emp_id;
        }

        private void approved_by_SelectedIndexChanged(object sender, EventArgs e)
        {
            approve_id = -1;
            approve_code.Text = "";
            if (((ComboItem)((ComboBox)sender).SelectedItem).Key < 0) approve_code.Enabled = false;
            else approve_code.Enabled = true;
        }

        private void approve_code_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) manage_btn.PerformClick();
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            String queryString = "";
            if (amount.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER DISCOUNT AMOUNT !!", "ERROR");
                return;
            }

            if (approved_by.SelectedIndex == 1)
            {
                if (approve_code.Text.Trim() != GF.SAapproveCode)
                {
                    MessageBox.Show("APPROVE CODE IS NOT CORRECT !!", "ERROR");
                    approve_code.Focus();
                    return;
                }
                else approve_id = GF.emp_id;
            }
            else if (approved_by.SelectedIndex > 1 && approve_id == -1)
            {
                if (approve_code.Text.Trim().Length == 0)
                {
                    MessageBox.Show("PLEASE ENTER APPROVE CODE !!", "ERROR");
                    return;
                }

                Dictionary<string, string> Params = new Dictionary<string, string>();
                //Params.Add("@approve_code", CRYPT.Encode(approve_code.Text.Trim()));

                queryString = "SELECT * FROM EMPLOYEE WHERE EMP_ID = " + ((ComboItem)approved_by.SelectedItem).Key.ToString() + " AND approve_code = '" + CRYPT.Encode(approve_code.Text.Trim()) + "'";
                using (DataTable DT = DB.getS(queryString, null, "CHECK APPROVE CODE WITH EMP_ID[" + ((ComboItem)approved_by.SelectedItem).Key.ToString() + "]", false))
                {
                    if (DT.Rows.Count == 0)
                    {
                        MessageBox.Show("APPROVE CODE IS NOT CORRECT !!", "ERROR");
                        approve_code.Focus();
                        return;
                    } else if (DT.Rows.Count == 1 && DT.Rows[0]["EMP_STATUS"].ToString() != "1")
                    {
                        MessageBox.Show("THIS EMPLOYEE CANNOT APPROVE ANYMORE !!", "ERROR");
                        approved_by.Focus();
                        return;
                    }
                    else if(DT.Rows[0]["CAN_APPROVE"].ToString() != "1")
                    {
                        MessageBox.Show("THIS EMPLOYEE CANNOT APPROVE !!", "ERROR");
                        return;
                    }
                    else
                    {
                        approve_id = Convert.ToInt32(DT.Rows[0]["EMP_ID"].ToString());
                    }
                }
            }

            if (approve_id == -1)
            {
                MessageBox.Show("MANUAL DISCOUNT NEEDS APPROVAL !!", "ERROR");
                return;
            }

            List<string> param = new List<string>();
            
            string subject = "";
            string bill_detail_id = "";

            if (item.SelectedIndex == 0)
            {
                subject = item.Text;
                bill_detail_id = "-1";
            }
            else
            {
                if (card_data != null) subject = card_data["PROGRAM_NAME"].ToString();
                else subject = item.Text;
                bill_detail_id = ((ComboItem)item.SelectedItem).Key.ToString();
            }

            if (reason.Text.Trim() != "") subject += " ==" + reason.Text.Trim() + "==";

            if (unit.Text.Trim() == "%" && Convert.ToInt32(amount.Text.Trim()) > 100) amount.Text = "100";

            param.Add(discount_type.Text + " DISCOUNT");
            param.Add(subject + " ** " + GF.formatNumber(Convert.ToInt32(amount.Text)) + " " + ((ComboItem)unit.SelectedItem).Value + " **");
            param.Add(GF.formatNumber(Convert.ToInt32(amount.Text)));
            param.Add(Properties.Settings.Default.money_unit);
            param.Add(bill_detail_id);
            param.Add((new Random().Next(1, 1000000) * -1).ToString());
            param.Add("0");
            param.Add(GF.formatNumber(Convert.ToInt32(amount.Text)));
            param.Add((card_id != -1 ? card_id.ToString() : ""));
            param.Add(approve_id.ToString());

            ((cashier)this.Owner).pushRow("DISCOUNT", param);
            ((cashier)this.Owner).updateTotal();
            this.Close();
        }

        private void amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void discount_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{TAB}");
        }

        private void ref_no_KeyUp(object sender, KeyEventArgs e)
        {
            if(discount_type.SelectedIndex == 1){
                if (e.KeyCode == Keys.Enter && ref_no.Text.Trim().Length >= 15)
                {
                    card_data = GF.validateCards("GIFT_VOUCHER", ref_no.Text.Trim());
                    if (card_data == null) return;
                    int cbIndex = -1;
                    foreach (ComboItem cb in item.Items)
                    {
                        cbIndex++;
                        if (cb.Value.IndexOf(card_data["PROGRAM_NAME"].ToString()) != -1)
                        {
                            break;
                        }
                    }
                    if (cbIndex != -1)
                    {
                        item.SelectedIndex = cbIndex;
                        amount.Text = "100";
                        card_id = Convert.ToInt32(card_data["GIFT_VOUCHER_ID"].ToString());
                    }
                }
            }
        }

        private void ref_no_TextChanged(object sender, EventArgs e)
        {
            card_id = -1;
            if (discount_type.SelectedIndex == 1)
            {
                card_data = null;
                item.SelectedIndex = 0;
                amount.Text = "";
            }
        }

        private void approve_scan_btn_Click(object sender, EventArgs e)
        {
            using (scan_barcode scan = new scan_barcode())
            {
                scan.Mode = "APPROVER";
                scan.Owner = this;
                scan.ShowDialog();
                int tmpID = approve_id;
                foreach (ComboItem items in approved_by.Items)
                {
                    if (items.Key == approve_id)
                    {
                        approved_by.Text = items.Value;
                        break;
                    }
                }
                approve_id = tmpID;
            }
        }
    }
}
