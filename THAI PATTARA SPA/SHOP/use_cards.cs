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
    public partial class use_cards : Form
    {
        public int billID = -1;
        public int payment_type = -1; // 0=MEMBERCARD; 1=GIFT_CERTIFICATE; 2=GIFT_VOUCHER; 3=COUPON; 4=VIP_CARD; 5=CROSS_PROMOTION; 6=MONEY_COUPON;
        public int money_amount = -1;
        public string action = "";
        string[] card_type = { "MEMBERCARD", "GIFT_CERTIFICATE", "GIFT_VOUCHER", "COUPON", "VIP_CARD", "CROSS_PROMOTION", "MONEY_COUPON" };

        public use_cards()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };
        }

        private void card_no_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GF.doDebug("*** USE CARD :: BEGIN !! ***");
                DataGridView DGV = ((cashier)this.Owner).btn_dgv.DGV;
                DataRow card_data = null;

                card_data = GF.validateCards(card_type[payment_type], card_no.Text.Trim());
                if(card_data == null) return;

                foreach (DataGridViewRow row in DGV.Rows)
                {
                    if (row.Cells["ITEM_TYPE"].Value != null)
                    {
                        if (row.Cells["USE_CARD_ID"].Value != null) // FILTER ONLY CARD
                        {
                            if ((row.Cells["DETAIL"].Value.ToString().IndexOf(card_type[payment_type].Replace("_", " ")) != -1 || row.Cells["ITEM_TYPE"].Value.ToString().IndexOf(card_type[payment_type].Replace("_", " ")) != -1) && row.Cells["USE_CARD_ID"].Value.ToString() == card_data[card_type[payment_type] + "_ID"].ToString())
                            {
                                GF.doDebug("THIS CARD IS ALREADY EXIST IN CURRENT BILL !!");
                                MessageBox.Show("THIS CARD IS ALREADY EXIST IN CURRENT BILL !!", "ERROR");
                                GF.closeLoading();
                                return;
                            }
                        }
                    }
                }

                String subject = "";
                String discount_amount = "";
                String discount_unit = "";
                String bill_detail_id = "";
                String discount_name = card_type[payment_type].Replace('_', ' ');
                List<String> param = new List<string>();

                // [DISCOUNT ALL] 0=MEMBERCARD; 4=VIP_CARD; 3=COUPON; 2=GIFT_VOUCHER
                if (payment_type == 0 || payment_type == 4 || (payment_type == 3 && card_data["SPA_PROGRAM_ID"].ToString() == "-1") || (payment_type == 2 && card_data["SPA_PROGRAM_ID"].ToString() == "-1"))
                {
                    param.Clear();
                    // SEARCH FOR MASSAGE => IF EXIST => ADD "DISCOUNT ALL SPA PROGRAM"
                    foreach (DataGridViewRow row in DGV.Rows)
                    {
                        if (row.Cells["ITEM_TYPE"].Value != null)
                        {
                            if (row.Cells["ITEM_TYPE"].Value.ToString() == "MASSAGE")
                            {
                                subject += "ALL SPA PROGRAM";
                                discount_amount = card_data["DISCOUNT"].ToString();
                                if (card_data["DISCOUNT_UNIT"].ToString() == "0")
                                    discount_unit = "%";
                                else
                                    discount_unit = Properties.Settings.Default.money_unit;

                                bill_detail_id = "-1";

                                if (payment_type == 0) discount_name = "MEMBER CARD ";
                                if (payment_type == 4) discount_name = "VIP CARD ";
                                if (payment_type == 3) discount_name = "COUPON ";
                                if (payment_type == 2) discount_name = "GIFT VOUCHER ";
                                discount_name += "DISCOUNT";

                                // ===============================================================

                                param.Add(discount_name);
                                param.Add(subject + " ** " + GF.formatNumber(Convert.ToInt32(discount_amount)) + " " + discount_unit + " **");
                                param.Add("0");
                                param.Add(Properties.Settings.Default.money_unit);
                                param.Add(bill_detail_id);
                                param.Add((new Random().Next(1, 1000000) * -1).ToString());
                                param.Add("0");
                                param.Add("0");
                                param.Add(card_data[card_type[payment_type] + "_ID"].ToString());

                                ((cashier)this.Owner).pushRow("DISCOUNT", param);
                                break;
                            }
                        }
                    }

                    if (payment_type != 5)
                    {
                        param.Clear();
                        // SEARCH FOR RETAIL ITEM => IF EXIST => ADD "DISCOUNT ALL RETAIL ITEM"
                        foreach (DataGridViewRow row in DGV.Rows)
                        {
                            if (row.Cells["ITEM_TYPE"].Value != null)
                            {
                                if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("ITEM") != -1)
                                {
                                    subject += "ALL RETAIL ITEM";
                                    discount_amount = card_data["DISCOUNT_FOOD"].ToString();
                                    discount_unit = (card_data["DISCOUNT_FOOD_UNIT"].ToString() == "0" ? "%" : Properties.Settings.Default.money_unit);
                                    bill_detail_id = "-1";

                                    if (payment_type == 0) discount_name = "MEMBER CARD";
                                    if (payment_type == 4) discount_name = "VIP CARD";
                                    discount_name += " DISCOUNT";

                                    // ===============================================================

                                    param.Add(discount_name);
                                    param.Add(subject + " ** " + GF.formatNumber(Convert.ToInt32(discount_amount)) + " " + discount_unit + " **");
                                    param.Add("0");
                                    param.Add(Properties.Settings.Default.money_unit);
                                    param.Add(bill_detail_id);
                                    param.Add((new Random().Next(1, 1000000) * -1).ToString());
                                    param.Add("0");
                                    param.Add("0");
                                    param.Add(card_data[card_type[payment_type] + "_ID"].ToString());

                                    ((cashier)this.Owner).pushRow("DISCOUNT", param);
                                    break;
                                }
                            }
                        }
                    }
                }

                param.Clear();
                // [PAID FOR SPA PROGRAM] (1 && BALANCE = NULL) = SPA GIFT_CERTIFICATE; 2 = GIFT_VOUCHER; 3 = COUPON; 5 = CROSS PROMOTION
                if (payment_type == 2 || (payment_type == 3 && card_data["SPA_PROGRAM_ID"].ToString() != "-1") || (payment_type == 1 && card_data["BALANCE"].ToString() == "") || payment_type == 5)
                {
                    if (payment_type == 3 && card_data["SPA_PROGRAM_ID"].ToString() == "-99")
                    {
                        MessageBox.Show("THIS IS MONEY COUPON !!!", "ERROR");
                        return;
                    }
                    bool foundSpaProgram = false;
                    foreach (DataGridViewRow row in DGV.Rows)
                    {
                        if (row.Cells["ITEM_TYPE"].Value != null)
                        {
                            if (row.Cells["DETAIL"].Value.ToString().IndexOf(card_data["PROGRAM_NAME"].ToString()) != -1)
                            {
                                if (/*row.Cells["APPLY_DISCOUNT"].Value.ToString() == "1" && */Convert.ToInt32(GF.removeThousandAndDecimal(row.Cells["AMOUNT_LEFT"].Value.ToString())) > 0)
                                {
                                    bill_detail_id = row.Cells["BILL_TARGET_ID"].Value.ToString();
                                    foundSpaProgram = true;
                                    break;
                                }
                            }
                        }
                    }

                    if (payment_type != 2 || (payment_type == 2 && card_data["SPA_PROGRAM_ID"].ToString() != "-1"))
                    {
                        if (!foundSpaProgram)
                        {
                            MessageBox.Show("[#" + card_data["PROGRAM_CODE"].ToString() + "]" + card_data["PROGRAM_NAME"].ToString() + "\r\nNOT FOUND !!", "ERROR");
                            GF.closeLoading();
                            return;
                        }
                    }

                    subject = "";
                    if (payment_type == 5) subject += "[" + card_data["CROSS_PROMOTION_NAME"].ToString() + "] ";
                    if (payment_type == 2 && card_data["SPA_PROGRAM_ID"].ToString() == "-1") subject += "ALL SPA PROGRAM ";
                    else subject += card_data["PROGRAM_NAME"].ToString();

                    if (payment_type == 5)
                        discount_amount = card_data["DISCOUNT"].ToString();
                    else if (payment_type == 3)
                        discount_amount = card_data["DISCOUNT_AMOUNT"].ToString();
                    else if (payment_type == 2)
                        discount_amount = card_data["DISCOUNT_AMOUNT"].ToString();
                    else
                        discount_amount = "100";

                    if (payment_type == 3)
                    {
                        if (card_data["DISCOUNT_UNIT"].ToString() == "0") discount_unit = "%";
                        if (card_data["DISCOUNT_UNIT"].ToString() == "1") discount_unit = Properties.Settings.Default.money_unit;
                    }
                    else if (payment_type == 2)
                        discount_unit = (card_data["DISCOUNT_UNIT"].ToString() == "0" ? "%" : Properties.Settings.Default.money_unit);
                    else
                        discount_unit = "%";

                    String paid_by = "";
                    if (card_type[payment_type] == "GIFT_CERTIFICATE")
                    {
                        if (card_data["PROGRAM_NAME"].ToString() == "") paid_by += "MONEY ";
                        else paid_by += "SPA MENU ";
                        paid_by += discount_name;
                    }
                    else
                    {
                        paid_by += card_type[payment_type].Replace('_', ' ');
                    }
                    paid_by += " for " + subject + " ** " + GF.formatNumber(Convert.ToInt32(discount_amount)) + " " + discount_unit + " **";

                    param.Add("PAID");
                    param.Add("by " + paid_by);
                    param.Add("0");
                    param.Add(Properties.Settings.Default.money_unit);
                    param.Add(bill_detail_id);
                    param.Add((new Random().Next(1, 1000000) * -1).ToString());
                    param.Add("0");
                    param.Add("0");
                    param.Add(card_data[card_type[payment_type] + "_ID"].ToString());

                    ((cashier)this.Owner).pushRow("PAID", param);
                }
                ((cashier)this.Owner).updateTotal();
                param.Clear();

                // [MONEY COUPON PAID FOR RETAIL ITEMS]
                if (payment_type == 6 && card_data["SPA_PROGRAM_ID"].ToString() == "-1" && card_data["BALANCE"].ToString() != "0" && card_data["BALANCE"].ToString() != "")
                {
                    bool tmpFound = false;
                    foreach (DataGridViewRow row in DGV.Rows)
                    {
                        if (row.Cells["ITEM_TYPE"].Value != null) 
                        {
                            if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PAID") != -1 && (row.Cells["DETAIL"].Value.ToString().IndexOf("MEMBERCARD") != -1 || row.Cells["DETAIL"].Value.ToString().IndexOf("MONEY GIFT CERTIFICATE") != -1))
                            {
                                tmpFound = true;
                                MessageBox.Show("CANNOT USE THIS CARD TO PAY WITH OTHER PAYMENT TYPE !!", "ERROR");
                                break;
                            }
                        }
                    }

                    if (!tmpFound)
                    {
                        // SEARCH FOR RETAIL ITEM => IF EXIST => ADD "PAID ALL RETAIL ITEM"
                        param.Add("PAID");
                        param.Add("by " + card_type[payment_type].Replace('_', ' ') + " #" + card_no.Text.Trim());
                        param.Add("");
                        param.Add(Properties.Settings.Default.money_unit);
                        param.Add((new Random().Next(1, 1000000) * -1).ToString());
                        param.Add((new Random().Next(1, 1000000) * -1).ToString());
                        param.Add("0");
                        param.Add(card_data["BALANCE"].ToString());
                        param.Add(card_data[(card_type[payment_type] == "MONEY_COUPON" ? "COUPON" : card_type[payment_type]) + "_ID"].ToString());

                        ((cashier)this.Owner).pushRow("PAID", param);
                    }
                }

                // MEMBERCARD && MONEY GIFT CER -> PAID MONEY
                int tmpAmount = 0;
                if (payment_type == 0 || payment_type == 1)
                {
                    bool tmpFound = false;
                    foreach (DataGridViewRow row in DGV.Rows)
                    {
                        if (row.Cells["ITEM_TYPE"].Value != null) 
                        {
                            if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PAID") != -1 && (row.Cells["DETAIL"].Value.ToString().IndexOf("MEMBERCARD") != -1 || row.Cells["DETAIL"].Value.ToString().IndexOf("MONEY GIFT CERTIFICATE") != -1 || row.Cells["DETAIL"].Value.ToString().IndexOf("MONEY COUPON") != -1))
                            {
                                tmpFound = true;
                                MessageBox.Show("CANNOT USE THIS CARD TO PAY WITH OTHER PAYMENT TYPE !!", "ERROR");
                                break;
                            }
                        }
                    }

                    if (!tmpFound)
                    {
                        tmpAmount = 0;
                        foreach (DataGridViewRow row in DGV.Rows)
                        {
                            if (row.Cells["ITEM_TYPE"].Value != null)
                            {
                                if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") == -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PAID") == -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("ITEM") == -1 && row.Cells["ITEM_TYPE"].Value.ToString() != "MEMBERCARD" && row.Cells["ITEM_TYPE"].Value.ToString() != "MONEY GIFT CERTIFICATE")
                                {
                                    tmpAmount += Convert.ToInt32(GF.removeThousandAndDecimal(row.Cells["AMOUNT_LEFT"].Value.ToString()));
                                }
                            }
                        }

                        if (tmpAmount > 0)
                        {
                            if (payment_type == 0 || (payment_type == 1 && card_data["BALANCE"].ToString() != ""))
                            {
                                if (card_data["BALANCE"].ToString() != "0")
                                {
                                    if (payment_type == 1)
                                    {
                                        foreach (DataGridViewRow tmpRow in DGV.Rows)
                                        {
                                            if (tmpRow.Cells["ITEM_TYPE"].Value != null)
                                            {
                                                if (tmpRow.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") == -1 && tmpRow.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PAID") == -1)
                                                {
                                                    if (tmpRow.Cells["ITEM_TYPE"].Value.ToString().IndexOf("ITEM") != -1 || tmpRow.Cells["ITEM_TYPE"].Value.ToString().IndexOf("MEMBERCARD") != -1 || tmpRow.Cells["ITEM_TYPE"].Value.ToString().IndexOf("GIFT CERTIFICATE") != -1)
                                                    {
                                                        MessageBox.Show("TO USE 'MONEY GIFT CERTIFICATE'.\r\nITEM LIST MUST BE ONLY MASSAGE !!", "ERROR");
                                                        return;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (discount_name.IndexOf(" DISCOUNT") != -1) discount_name = discount_name.Replace(" DISCOUNT", "");
                                    param.Add("PAID");
                                    param.Add("by " + (discount_name == "GIFT CERTIFICATE" ? "MONEY " : "") + discount_name + " #" + card_no.Text.Trim());
                                    param.Add("");
                                    param.Add(Properties.Settings.Default.money_unit);
                                    param.Add((new Random().Next(1, 1000000) * -1).ToString());
                                    param.Add((new Random().Next(1, 1000000) * -1).ToString());
                                    param.Add("0");
                                    param.Add(card_data["BALANCE"].ToString());
                                    param.Add(card_data[card_type[payment_type] + "_ID"].ToString());

                                    ((cashier)this.Owner).pushRow("PAID", param);
                                }
                            }
                        }
                    }
                }

                ((cashier)this.Owner).updateTotal();
                this.Close();
            }
        }
    }
}
