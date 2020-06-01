using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SPA_MANAGEMENT_SYSTEM.CUSTOMER;

namespace SPA_MANAGEMENT_SYSTEM.SHOP
{
    public partial class payment : Form
    {
        bool _fromDB = false;
        int _billID = -1;
        bool _isPaid = false;
        int _paymentType = -1;
        int _grandTotalAmount = 0;

        public int billID { get { return _billID; } set { _billID = value; } }
        public bool fromDB { get { return _fromDB; } set { _fromDB = value; } }
        public bool isPaid { get { return _isPaid; } set { _isPaid = value; } }
        public int paymentType { get { return _paymentType; } set { _paymentType = value; } } // 0=CASH; 1=CREDIT CARD
        public int grandTotalAmount { get { return _grandTotalAmount; } set { _grandTotalAmount = value; } }

        public payment()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };
            this.Visible = false;
        }

        private void payment_Load(object sender, EventArgs e)
        {
            switch (paymentType)
            {
                case -1:
                    Controls.Add(debtor_info);
                    debtor_id.parentForm = this;
                    Height = 426;
                    break;
                case 0:
                    Height = 360;
                    break;
                case 1:
                    Controls.Add(credit_card_info);
                    Height = 533;
                    break;
            }
            if (paymentType == 1)
            {
                Controls.Add(credit_card_info);
            }
            else credit_card_info.Enabled = false;
            updateGrandTotal();
        }

        private void insertBillPayment()
        {
            if (Convert.ToInt32(GF.removeThousandAndDecimal(receive.Text.Trim())) - Convert.ToInt32(GF.removeThousandAndDecimal(change.Text.Trim())) > 0)
            {
                string discount_name = "";
                string credit_card = "";
                switch (paymentType)
                {
                    case 0:
                        discount_name = "CASH";
                        break;
                    case 1:
                        discount_name = "CREDIT CARD";
                        credit_card += " " + credit_card_no.Text.Trim().Replace(" ", "") + " [";
                        if (mastercard_rd.Checked) credit_card += "MASTERCARD";
                        if (visa_rd.Checked) credit_card += "VISA";
                        credit_card += "]";
                        break;
                    case -1:
                        discount_name = "PERSONAL CREDIT" + " of " + debtor_id.Text;
                        break;
                }

                List<string> param = new List<string>();
                param.Add("PAID");
                param.Add("by " + discount_name + credit_card);
                param.Add(GF.formatNumber(Convert.ToInt32(GF.removeThousandAndDecimal(receive.Text.Trim())) - Convert.ToInt32(GF.removeThousandAndDecimal(change.Text.Trim()))));
                param.Add(Properties.Settings.Default.money_unit);
                param.Add((new Random().Next(1, 1000000) * -1).ToString());
                param.Add((new Random().Next(1, 1000000) * -1).ToString());
                param.Add("0");
                param.Add("0");
                if (paymentType == -1) param.Add(debtor_id.currentID.ToString());

                ((cashier)this.Owner).pushRow("PAID", param);
                ((cashier)this.Owner).updateTotal();
            }
            this.Close();
        }

        void updateGrandTotal()
        {
            grand_total.Text = GF.formatNumber(grandTotalAmount);
            receive.Text = "0.00";
            this.Visible = true;
        }

        private void receive_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void receive_TextChanged(object sender, EventArgs e)
        {
            Double receiveAmount = 0;

            if (receive.Text.Trim() != "") receiveAmount = Double.Parse(receive.Text.Trim().Replace(GF.thousandSep, ""));

            Double changeAmount = receiveAmount - Double.Parse(grand_total.Text.Trim().Replace(GF.thousandSep, ""));
            if (changeAmount < 0) changeAmount = 0;
            change.Text = GF.formatDecimal(changeAmount);
        }

        private bool validateMoney()
        {
            if (GF.removeThousandAndDecimal(receive.Text.Trim()) == "0" || receive.Text.Trim() == "")
            {
                MessageBox.Show("NOT RECEIVED MONEY YET !!", "ERROR");
                receive.Select();
                return false;
            }

            if (paymentType == 1)
            {
                if (credit_card_no.Text.Trim().Replace(" ", "").Replace("_", "").Length < 16)
                {
                    MessageBox.Show("PLEASE CHECK CREDIT CARD NUMBER !!", "ERROR");
                    credit_card_no.Focus();
                    return false;
                }
                if(!mastercard_rd.Checked && !visa_rd.Checked)
                {
                    MessageBox.Show("PLEASE CHOOSE CREDIT CARD TYPE !!\r\n\r\nMASTER CARD or VISA", "ERROR");
                    return false;
                }
            }

            return true;
        }

        private void payment_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Activate();
        }

        private void receive_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if(validateMoney()) insertBillPayment();
            }
        }

        private void credit_card_no_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (validateMoney()) insertBillPayment();
            }
        }

        private void add_debtor_btn_Click(object sender, EventArgs e)
        {
            using (DEBTOR.debtor_manage addDebtor = new DEBTOR.debtor_manage())
            {
                addDebtor.Owner = this;
                addDebtor.id = -1;
                addDebtor.manage_btn.Text = "ADD";
                addDebtor.Text = "ADD DEBTOR DATA";

                addDebtor.ShowDialog();
            }
        }

        private void mastercard_rd_CheckedChanged(object sender, EventArgs e)
        {
            if (mastercard_rd.Checked)
            {
                receive.Select();
            }
        }

        private void visa_rd_CheckedChanged(object sender, EventArgs e)
        {
            if (visa_rd.Checked)
            {
                receive.Select();
            }
        }
    }
}
