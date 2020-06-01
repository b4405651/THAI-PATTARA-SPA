using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using SPA_MANAGEMENT_SYSTEM.COUPON;

namespace SPA_MANAGEMENT_SYSTEM.SHOP
{
    public partial class cashier : Form
    {
        public int billID = -1;
        public int customerID = -1;
        public bool gen = false;
        public string currentBillNo = "";
        public int membercardID = -1;
        public string theDate = GF.TODAY();
        public int item_amount = 0;
        string promotion_id = "NULL";
        public string invoice_datetime = "";
        public string void_reason = "";
        public DataRow productRow = null;

        bool isPaid = false;
        bool isVoid = false;

        DataGridView DGV;

        public List<DataGridViewRow> DGVRC;
        List<string> membercard_price_list;
        List<string> delivery_club_price_list;
        List<string> mango_price_list;
        List<DataRow> item_list;

        int total_amount = 0;
        int no_discount_amount = 0;
        int discount_amount = 0;
        int paid_amount = 0;

        public cashier()
        {
            InitializeComponent();

            GF.showLoading(this);
            customer_id.parentForm = this;

            DGV = btn_dgv.DGV;
            DGV.RowHeadersVisible = false;
            DGV.UserDeletingRow += (s, ce) =>
            {
                if (btn_dgv.DGV.SelectedRows.Count == 1)
                {
                    using (DataGridViewRow row = btn_dgv.DGV.SelectedRows[0])
                    {
                        if (row.Cells["ITEM_TYPE"].Value != null)
                        {
                            if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") == -1)
                            {
                                // DELETE ITEM ---- NOT DISCOUNT
                                if (row.Cells["ITEM_TYPE"].Value.ToString() == "MASSAGE")
                                {
                                    MessageBox.Show("YOU CANNOT DELETE RESERVATION DETAIL HERE !!", "ERROR");
                                    ce.Cancel = true;
                                    return;
                                }
                            }
                            else
                            {
                                // DELETE DISCOUNT
                                if (row.Cells["ITEM_TYPE"].Value.ToString() == "PROMOTION DISCOUNT")
                                {
                                    MessageBox.Show("YOU CANNOT DELETE PROMOTION DISCOUNT !!", "ERROR");
                                    ce.Cancel = true;
                                    return;
                                }
                            }
                        }
                    }
                }
            };

            DGV.UserDeletedRow += (ce, ee) =>
            {
                // RE-ARRANGE EMPTY ROW
                int rowCount = 0;
                foreach (DataGridViewRow row in DGV.Rows)
                {
                    if (row.Cells["ITEM_TYPE"].Value == null)
                    {
                        rowCount++;
                        if (rowCount == 2)
                        {
                            DGV.Rows.RemoveAt(row.Index);
                            rowCount = 0;
                        }
                    }
                    else rowCount = 0;
                }
                if (DGV.Rows.Count > 0)
                {
                    if (DGV.Rows[DGV.Rows.Count - 1].Cells["ITEM_TYPE"].Value == null) DGV.Rows.RemoveAt(DGV.Rows.Count - 1);
                }
                updateTotal();

                rowCount = 0;
                foreach (DataGridViewRow row in DGV.Rows)
                {
                    if (row.Cells["ITEM_TYPE"].Value != null)
                    {
                        if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("MASSAGE") != -1 || row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("ITEM") != -1 || row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("MEMBER") != -1 || row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("GIFT CERTIFICATE") != -1)
                        {
                            rowCount++;
                        }
                    }
                }

                if (rowCount > 0)
                {
                    GF.enableButton(invoice_btn);
                    GF.enableButton(pay_by_cash_btn);
                    GF.enableButton(pay_by_credit_card_btn);
                    GF.enableButton(personal_credit_btn);
                    toggleAllDiscount("ENABLE");
                }
                else
                {
                    GF.disableButton(invoice_btn);
                    GF.disableButton(pay_by_cash_btn);
                    GF.disableButton(pay_by_credit_card_btn);
                    GF.disableButton(personal_credit_btn);
                    done_btn.Visible = false;
                    toggleAllDiscount("DISABLE");
                }
            };

            DGV.RowsAdded += (ss, ee) =>
            {
                GF.enableButton(invoice_btn);
                if (invoice_datetime != "")
                {
                    GF.enableButton(pay_by_cash_btn);
                    GF.enableButton(pay_by_credit_card_btn);
                    GF.enableButton(personal_credit_btn);
                }
                else
                {
                    GF.disableButton(pay_by_cash_btn);
                    GF.disableButton(pay_by_credit_card_btn);
                    GF.disableButton(personal_credit_btn);
                }
                toggleAllDiscount("ENABLE");
            };
        }

        private void shop_selling_Load(object sender, EventArgs e)
        {
            bill_no_lbl.Top = voided.Top = GF.pageTop;
            bill_no.Top = bill_no_lbl.Top - 3;
            voided.Left = bill_no.Left + bill_no.Width + 27;

            customer_id_lbl.Top = bill_no_lbl.Top + 25;
            customer_id.Left = bill_no.Left;
            customer_id.Top = customer_id_lbl.Top - 3;
            add_customer_btn.Top = customer_id.Top;
            add_customer_btn.Left = customer_id.Left + customer_id.Width + 5;
            
            item_type_lbl.Top = customer_id_lbl.Top + 25;
            item_type.Top = item_type_lbl.Top - 3;

            item_type.Items.Add(new ComboItem(1, "MEMBER CARD"));
            item_type.Items.Add(new ComboItem(2, "GIFT CERTIFICATE"));
            item_type.Items.Add(new ComboItem(6, "WEBSITE GIFT CERTIFICATE"));
            item_type.Items.Add(new ComboItem(3, "COUPON"));
            item_type.Items.Add(new ComboItem(8, "RESTAURANT"));
            item_type.Items.Add(new ComboItem(5, "DELIVERY CLUB"));
            item_type.Items.Add(new ComboItem(7, "MANGO"));
            item_type.Items.Add(new ComboItem(0, "PRODUCT & OTHER"));
            item_type.SelectedIndex = 0;
            GF.resizeComboBox(item_type);

            item_lbl.Top = item_type_lbl.Top + 28;
            item_id.Top = item_lbl.Top - 3;

            btn_dgv.DGV.AllowUserToDeleteRows = true;
            btn_dgv.Top = item_lbl.Top + 35;
            btn_dgv.Width = this.Width - invoice_btn.Width - 50;
            btn_dgv.Height = this.Height - btn_dgv.Top - 270;
            btn_dgv.allowDeleteRow = true;
            btn_dgv.btn_panel.Visible = false;
            btn_dgv.paging_panel.Visible = false;
            btn_dgv.DGV.Width = btn_dgv.Width;
            btn_dgv.DGV.Top = btn_dgv.btn_panel.Top;
            btn_dgv.DGV.Height = btn_dgv.Height;

            manage_btn.Top = item_type.Top + 4;
            manage_btn.Left = add_customer_btn.Left;

            total_lbl.Top = bill_no_lbl.Top;
            total_lbl.Left = this.Width - total_lbl.Width - 10;
            total.Top = total_lbl.Top + 30;
            total.Left = this.Width - total.Width - 10;

            discount_lbl.Top = total.Top + 40;
            discount_lbl.Left = this.Width - discount_lbl.Width - 10;
            discount.Top = discount_lbl.Top + 30;
            discount.Left = this.Width - discount.Width - 10;

            paid_lbl.Top = discount.Top + 40;
            paid_lbl.Left = this.Width - paid_lbl.Width - 10;
            paid.Top = paid_lbl.Top + 30;
            paid.Left = this.Width - paid.Width - 10;

            grand_total_lbl.Top = paid.Top + 50;
            grand_total_lbl.Left = this.Width - grand_total_lbl.Width - 10;
            grand_total.Top = grand_total_lbl.Top + 30;
            grand_total.Left = this.Width - grand_total.Width - 10;

            gift_cer_btn.Top = coupon_btn.Top = member_card_btn.Top = other_discount_btn.Top = btn_dgv.Top + btn_dgv.Height + 10;
            money_coupon_btn.Top = gift_voucher_btn.Top = vip_card_btn.Top = cross_promotion_btn.Top = gift_cer_btn.Top + gift_cer_btn.Height + 5;

            payment_groupBox.Top = gift_voucher_btn.Top + gift_voucher_btn.Height - payment_groupBox.Height;
            payment_groupBox.Left = btn_dgv.Left + btn_dgv.Width + 20;

            invoice_btn.Left = payment_groupBox.Left;
            invoice_btn.Top = payment_groupBox.Top - 15 - invoice_btn.Height;

            new_bill_btn.Left = btn_dgv.Left + btn_dgv.Width - new_bill_btn.Width;
            new_bill_btn.Top = btn_dgv.Top - 5 - new_bill_btn.Height;

            void_btn.Left = new_bill_btn.Left;
            void_btn.Top = new_bill_btn.Top - 3 - void_btn.Height;

            done_btn.Left = btn_dgv.Left + btn_dgv.Width - done_btn.Width;
            done_btn.Top = btn_dgv.Top + btn_dgv.Height + 5;

            NewBill();
            
            if (billID != -1)
            {
                loadData();
            }
            else
            {
                if (DGVRC != null)
                {
                    /*  ========== COLUMNS IN DGVRC ==========
                     *  0 : program_name,
                        1 : therapist_list,
                        2 : program_id,
                        3 : price,
                        4 : hours,
                        5 : minutes,
                        6 : oil,
                        7 : scrub,
                        8 : therapist_id,
                        9 : is_requested,
                        10 : apply_discount,
                        11 : is_updated,
                        12 : reservation_detail_id
                     * */
                    foreach (DataGridViewRow row in DGVRC)
                    {
                        List<string> param = new List<string>();

                        param.Add("MASSAGE");
                        param.Add(row.Cells[0].Value.ToString());
                        param.Add(GF.formatNumber(Convert.ToInt32(GF.removeThousandAndDecimal(row.Cells[3].Value.ToString()))));
                        param.Add(Properties.Settings.Default.money_unit);
                        param.Add(row.Cells[11].Value.ToString());
                        param.Add(getRand());
                        param.Add(row.Cells[10].Value.ToString());
                        param.Add(GF.removeThousandAndDecimal(row.Cells[3].Value.ToString()));

                        pushRow("MASSAGE", param);
                    }

                    GF.enableButton(invoice_btn);
                    /*GF.enableButton(pay_by_cash_btn);
                    GF.enableButton(pay_by_credit_card_btn);
                    GF.enableButton(personal_credit_btn);*/
                    toggleAllDiscount("ENABLE");
                }

                /*String queryString = "SELECT * FROM PROMOTION WHERE " + GF.modDate(theDate) + @" BETWEEN CONVERT(DATE, START_DATE) AND CONVERT(DATE, END_DATE)";
                using (DataTable DT = DB.get(queryString, "GET PROMOTION", false))
                {
                    if (DT.Rows.Count > 0)
                    {
                        DGV.Rows.Add();
                        foreach (DataRow row in DT.Rows)
                        {
                            promotion_id = row["PROMOTION_ID"].ToString();
                            String subject = "";
                            queryString = @"
                        SELECT
                            A.PROMOTION_TYPE,
                            C.CODE,
                            C.PROGRAM_NAME 
                        FROM PROMOTION_SUB A
                        LEFT OUTER JOIN PROMOTION_SUB_DETAIL B ON A.PROMOTION_SUB_ID = B.PROMOTION_SUB_ID
                        LEFT OUTER JOIN SPA_PROGRAM C ON B.SPA_PROGRAM_ID = C.SPA_PROGRAM_ID
                        WHERE A.PROMOTION_ID = " + row["PROMOTION_ID"].ToString();
                             using (DataTable promotionDT = DB.get(queryString, "GET DETAIL OF PROMOTION[" + row["PROMOTION_ID"].ToString() + "]", false))
                            {
                                if (promotionDT.Rows.Count == 1)
                                {
                                    if (promotionDT.Rows[0]["PROMOTION_TYPE"].ToString() == "0") // ALL
                                        subject += "ALL SPA PROGRAM";
                                    else // ITEM or COMBINATION WITH ONLY 1 PROGRAM 
                                        subject += "#" + promotionDT.Rows[0]["CODE"].ToString();
                                }
                                else // COMBINATION WITH MULTI PROGRAM
                                {
                                    foreach (DataRow promotionRow in promotionDT.Rows)
                                    {
                                        subject += "#" + promotionRow["CODE"].ToString() + ", ";
                                        foreach (DataGridViewRow itemRow in DGV.Rows) // MARK SPA PROGRAM IN COMBINATION -> NO "APPLY_DISCOUNT"
                                        {
                                            if (itemRow.Cells["DETAIL"].Value.ToString() == promotionRow["PROGRAM_NAME"].ToString())
                                            {
                                                itemRow.Cells["APPLY_DISCOUNT"].Value = "0";
                                                break;
                                            }
                                        }
                                    }
                                    if (subject.IndexOf(",") != -1) subject = subject.Substring(0, subject.Length - 2);
                                }
                            }
                            subject += " [" + row["PROMOTION_NAME"].ToString() + "]";

                            DGV.Rows.Add(
                                "PROMOTION DISCOUNT",
                                subject + " **" + GF.formatNumber(Convert.ToInt32(row["AMOUNT"].ToString())) + (row["UNIT"].ToString() == "0" ? "%" : Properties.Settings.Default.money_unit) + "**",
                                "0",
                                Properties.Settings.Default.money_unit,
                                row["PROMOTION_ID"].ToString(),
                                row["BILL_DISCOUNT_ID"].ToString(),
                                "0",
                                "0"
                            );
                        }
                    }
                }*/

                updateTotal();
                new_bill_btn.Visible = true;
                GF.enableButton(new_bill_btn);
            }
            GF.closeLoading();
        }

        void initDGV()
        {
            if (btn_dgv.DGV.Columns.Count == 0)
            {
                DGV.Columns.Add("item_type", "TYPE");
                DGV.Columns.Add("detail", "DETAIL");
                DGV.Columns.Add("amount", "AMOUNT");
                DGV.Columns.Add("unit", "UNIT");
                DGV.Columns.Add("source_id", "source_id"); // RESERVATION_DETAIL_ID or MEMBERCARD_ID or GIFT_CER_ID or ITEM_ID ( or BILL_DETAIL_ID for BILL_DISCOUNT )
                DGV.Columns.Add("bill_target_id", "bill_target_id"); // BILL_DETAIL_ID or BILL_DISCOUNT_ID or BILL_PAYMENT_ID
                DGV.Columns.Add("apply_discount", "apply_discount");
                DGV.Columns.Add("amount_left", "AMOUNT_LEFT");
                DGV.Columns.Add("use_card_id", "use_card_id");
                DGV.Columns.Add("approved_by", "approved_by");
                DGV.Columns.Add("card_no", "card_no");

                DGV.Columns["detail"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                DGV.Columns["source_id"].Visible = false;
                DGV.Columns["bill_target_id"].Visible = false;
                DGV.Columns["apply_discount"].Visible = false;
                DGV.Columns["amount_left"].Visible = false;
                DGV.Columns["use_card_id"].Visible = false;
                DGV.Columns["approved_by"].Visible = false;
                DGV.Columns["card_no"].Visible = false;
            }
        }

        public void loadData()
        {
            GF.showLoading(this);
            String queryString = "";

            queryString = @"
            SELECT A.*, CASE WHEN A.BILL_BY = 0 THEN 'S.A.' ELSE B.FULLNAME END BILL_BY_NAME
            FROM BILL A 
            LEFT OUTER JOIN EMPLOYEE B ON A.BILL_BY = B.EMP_ID
            WHERE A.BILL_ID LIKE '" + billID.ToString() + "'";
            using (DataTable DT = DB.getS(queryString, null, "GET BILL_ID[" + billID.ToString() + "]", false))
            {
                if (DT.Rows.Count == 0)
                {
                    MessageBox.Show("BILL NOT FOUND !!", "ERROR");
                    NewBill();
                    return;
                }
                billID = Int32.Parse(DT.Rows[0]["BILL_ID"].ToString());
                if (bill_no.Text.Trim() == "") bill_no.Text = DT.Rows[0]["BILL_NO"].ToString();

                bill_by.Text = "BILL BY : " + DT.Rows[0]["BILL_BY_NAME"].ToString();
                bill_by.Top = payment_groupBox.Top + payment_groupBox.Height - bill_by.Height;
                bill_by.Left = payment_groupBox.Left - bill_by.Width - 20;
                bill_by.Visible = true;

                isPaid = (DT.Rows[0]["IS_PAID"].ToString() == "1" ? true : false);

                if (DT.Rows[0]["IS_VOID"].ToString() == "1")
                {
                    isVoid = true;
                    voided.Visible = true;
                    void_btn.Visible = false;
                    if (!isPaid)
                    {
                        add_customer_btn.Enabled = false;
                        GF.disableButton(manage_btn);
                    }
                }
                else
                {
                    isVoid = false;
                    voided.Visible = false;
                    if (GF.can_approve)
                    {
                        void_btn.Visible = true;
                        GF.enableButton(void_btn);
                    }
                    if (!isPaid)
                    {
                        add_customer_btn.Enabled = true;
                        GF.enableButton(manage_btn);
                    }
                }

                if (DT.Rows[0]["INVOICE_DATETIME"].ToString() != "" && DT.Rows[0]["INVOICE_DATETIME"].ToString() != "NULL") invoice_datetime = DT.Rows[0]["INVOICE_DATETIME"].ToString();

                if (isPaid)
                {
                    GF.disableButton(pay_by_cash_btn);
                    GF.disableButton(pay_by_credit_card_btn);
                    GF.disableButton(personal_credit_btn);
                    toggleAllDiscount("DISABLE");
                }
                else
                {
                    if (invoice_datetime != "")
                    {
                        GF.enableButton(pay_by_cash_btn);
                        GF.enableButton(pay_by_credit_card_btn);
                        GF.enableButton(personal_credit_btn);
                        toggleAllDiscount("ENABLE");
                    }
                    else
                    {
                        GF.disableButton(pay_by_cash_btn);
                        GF.disableButton(pay_by_credit_card_btn);
                        GF.disableButton(personal_credit_btn);
                        toggleAllDiscount("DISABLE");
                    }
                }

                if (DT.Rows[0]["CUSTOMER_ID"].ToString() != "NULL" && DT.Rows[0]["CUSTOMER_ID"].ToString() != "")
                {
                    queryString = "SELECT * FROM CUSTOMER WHERE CUSTOMER_ID = " + DT.Rows[0]["CUSTOMER_ID"].ToString();
                    using (DataTable tmpDT = DB.getS(queryString, null, "GET CUSTOMER[" + DT.Rows[0]["CUSTOMER_ID"].ToString() + "]", false))
                    {
                        if (tmpDT.Rows.Count == 1)
                        {
                            customer_id.SetText(Convert.ToInt32(tmpDT.Rows[0]["CUSTOMER_ID"].ToString()), tmpDT.Rows[0]["CUSTOMER_NAME"].ToString() + " - " + (tmpDT.Rows[0]["GENDER"].ToString() == "1" ? "MALE" : "FEMALE") + " - " + tmpDT.Rows[0]["TEL"].ToString());
                        }
                    }
                }
            }

            DGV.Rows.Clear();
            initDGV();

            total_amount = 0;
            discount_amount = 0;
            paid_amount = 0;
            int modified_spa_row = 0;
            //========================================= ITEM ====================================================    

            string reservation_detail_id_list = "";

            queryString = "SELECT * FROM BILL_DETAIL WHERE BILL_ID = " + billID.ToString() + " ORDER BY SORT";
            using (DataTable DT = DB.getS(queryString, null, "GET ALL BILL_DETAIL FROM BILL_ID[" + billID.ToString() + "]", false))
            {
                String caption = "";
                foreach (DataRow row in DT.Rows)
                {
                    switch (row["ITEM_TYPE"].ToString())
                    {
                        case "0": // MASSAGE
                            queryString = @"
                        SELECT A.RESERVATION_DETAIL_ID, B.*
                        FROM RESERVATION_DETAIL A
                        INNER JOIN SPA_PROGRAM B ON A.SPA_PROGRAM_ID = B.SPA_PROGRAM_ID
                        WHERE A.RESERVATION_DETAIL_ID = " + row["ITEM_ID"].ToString();
                            using (DataTable tmpDT = DB.getS(queryString, null, "GET RESERVATION_DETAIL[" + row["ITEM_ID"].ToString() + "]", false))
                            {
                                foreach (DataRow tmpRow in tmpDT.Rows)
                                {
                                    reservation_detail_id_list += tmpRow["RESERVATION_DETAIL_ID"].ToString() + ",";

                                    List<string> param = new List<string>();

                                    param.Add("MASSAGE");
                                    param.Add("[#" + tmpRow["CODE"] + "] " + tmpRow["PROGRAM_NAME"].ToString());
                                    param.Add(GF.formatNumber(Convert.ToInt32(row["PRICE"].ToString())));
                                    param.Add(Properties.Settings.Default.money_unit);
                                    param.Add(tmpRow["RESERVATION_DETAIL_ID"].ToString());
                                    param.Add(row["BILL_DETAIL_ID"].ToString());
                                    param.Add(row["APPLY_DISCOUNT"].ToString());
                                    param.Add(GF.formatNumber(Convert.ToInt32(GF.removeThousandAndDecimal((row["AMOUNT_LEFT"].ToString() == "" ? tmpRow["PRICE"].ToString() : row["AMOUNT_LEFT"].ToString())))));

                                    pushRow("MASSAGE", param);

                                    total_amount += Convert.ToInt32(row["PRICE"].ToString());
                                }
                            }
                            break;
                        case "1": // MEMBER CARD
                            queryString = "SELECT A.*, B.MEMBERCARD_TYPE_NAME FROM MEMBERCARD A INNER JOIN MEMBERCARD_TYPE B ON A.MEMBERCARD_TYPE_ID = B.MEMBERCARD_TYPE_ID WHERE A.MEMBERCARD_ID = " + row["ITEM_ID"].ToString();
                            using (DataTable tmpDT = DB.getS(queryString, null, "GET MEMBERCARD[" + row["ITEM_ID"].ToString() + "]", false))
                            {
                                if (tmpDT.Rows.Count == 1)
                                {
                                    List<string> param = new List<string>();

                                    param.Add("MASSAGE");
                                    param.Add(tmpDT.Rows[0]["MEMBERCARD_TYPE_NAME"].ToString() + " [ " + tmpDT.Rows[0]["CARD_NO"].ToString() + " ]");
                                    param.Add(GF.formatNumber(Convert.ToInt32(tmpDT.Rows[0]["PRICE"].ToString())));
                                    param.Add(Properties.Settings.Default.money_unit);
                                    param.Add(tmpDT.Rows[0]["MEMBERCARD_ID"].ToString());
                                    param.Add(row["BILL_DETAIL_ID"].ToString());
                                    param.Add(row["APPLY_DISCOUNT"].ToString());
                                    param.Add(GF.formatNumber(Convert.ToInt32(row["AMOUNT_LEFT"].ToString())));

                                    pushRow("MEMBERCARD", param);

                                    total_amount += Convert.ToInt32(tmpDT.Rows[0]["PRICE"].ToString());
                                }
                            }
                            break;
                        case "2": // SPA GIFT CERT.
                        case "6": // WEBSITE
                            queryString = @"
                        SELECT 
                            A.*, B.PROGRAM_NAME, B.CODE
                        FROM GIFT_CERTIFICATE A 
                        INNER JOIN SPA_PROGRAM B ON A.SPA_PROGRAM_ID = B.SPA_PROGRAM_ID 
                        WHERE A.GIFT_CERTIFICATE_ID = " + row["ITEM_ID"].ToString();

                            caption = "SPA MENU GIFT CERTIFICATE";
                            if (row["ITEM_TYPE"].ToString() == "6") caption = "WEBSITE " + caption;

                            using (DataTable tmpDT = DB.getS(queryString, null, "GET " + caption + "[" + row["ITEM_ID"].ToString() + "]", false))
                            {
                                if (tmpDT.Rows.Count == 1)
                                {
                                    List<string> param = new List<string>();

                                    param.Add(caption);
                                    param.Add("[#" + tmpDT.Rows[0]["CODE"] + "] " + tmpDT.Rows[0]["PROGRAM_NAME"].ToString() + (tmpDT.Rows[0]["FROM_TXT"].ToString() != "" ? " [FROM " + tmpDT.Rows[0]["FROM_TXT"].ToString() + "]" : "") + (tmpDT.Rows[0]["FOR_TXT"].ToString() != "" ? " [FOR " + tmpDT.Rows[0]["FOR_TXT"].ToString() + "]" : ""));
                                    param.Add(GF.formatNumber(Convert.ToInt32(tmpDT.Rows[0]["PRICE"].ToString())));
                                    param.Add(Properties.Settings.Default.money_unit);
                                    param.Add(tmpDT.Rows[0]["GIFT_CERTIFICATE_ID"].ToString());
                                    param.Add(row["BILL_DETAIL_ID"].ToString());
                                    param.Add(row["APPLY_DISCOUNT"].ToString());
                                    param.Add(GF.formatNumber(Convert.ToInt32(row["AMOUNT_LEFT"].ToString())));

                                    pushRow("GIFT_CERTIFICATE", param);

                                    total_amount += Convert.ToInt32(tmpDT.Rows[0]["PRICE"].ToString());
                                }
                            }
                            break;
                        case "3": // MONEY GIFT CERT.
                        case "9": // WEBSITE
                            queryString = "SELECT * FROM GIFT_CERTIFICATE WHERE GIFT_CERTIFICATE_ID = " + row["ITEM_ID"].ToString();

                            caption = "MONEY GIFT CERTIFICATE";
                            if (row["ITEM_TYPE"].ToString() == "9") caption = "WEBSITE " + caption;

                            using (DataTable tmpDT = DB.getS(queryString, null, "GET " + caption + "[" + row["ITEM_ID"].ToString() + "]", false))
                            {
                                if (tmpDT.Rows.Count == 1)
                                {
                                    List<string> param = new List<string>();

                                    param.Add(caption);
                                    param.Add("BALANCE : " + GF.formatNumber(Convert.ToInt32(tmpDT.Rows[0]["BALANCE_MAX"].ToString())) + " " + (tmpDT.Rows[0]["FROM_TXT"].ToString() != "" ? "[FROM " + tmpDT.Rows[0]["FROM_TXT"].ToString() + "]" : "") + (tmpDT.Rows[0]["FOR_TXT"].ToString() != "" ? " [FOR " + tmpDT.Rows[0]["FOR_TXT"].ToString() + "]" : ""));
                                    param.Add(GF.formatNumber(Convert.ToInt32(tmpDT.Rows[0]["PRICE"].ToString())));
                                    param.Add(Properties.Settings.Default.money_unit);
                                    param.Add(tmpDT.Rows[0]["GIFT_CERTIFICATE_ID"].ToString());
                                    param.Add(row["BILL_DETAIL_ID"].ToString());
                                    param.Add(row["APPLY_DISCOUNT"].ToString());
                                    param.Add(GF.formatNumber(Convert.ToInt32(row["AMOUNT_LEFT"].ToString())));

                                    pushRow("GIFT_CERTIFICATE", param);

                                    total_amount += Convert.ToInt32(tmpDT.Rows[0]["PRICE"].ToString());
                                }
                            }
                            break;
                        default: // RESTAURANT + PRODUCT & OTHER
                            queryString = "SELECT * FROM ITEM WHERE ITEM_ID = " + row["ITEM_ID"].ToString();
                            using (DataTable tmpDT = DB.getS(queryString, null, "GET DETAIL IN ITEM[" + row["ITEM_ID"].ToString() + "]", false))
                            {
                                List<string> param = new List<string>();

                                switch (row["ITEM_TYPE"].ToString())
                                {
                                    case "5":
                                        param.Add("DELIVERY CLUB");
                                        break;
                                    case "7":
                                        param.Add("MANGO");
                                        break;
                                    case "8":
                                        param.Add("RESTAURANT");
                                        break;
                                    default:
                                        param.Add("PRODUCT & OTHER");
                                        break;
                                }

                                if (tmpDT.Rows.Count == 1) param.Add(tmpDT.Rows[0]["ITEM_NAME"].ToString() + " [" + row["AMOUNT"].ToString() + "]");
                                else param.Add(row["MISC_ITEM_NAME"].ToString() + " [" + row["AMOUNT"].ToString() + "]");

                                param.Add(GF.formatNumber(Convert.ToInt32(row["PRICE"].ToString())));
                                param.Add(Properties.Settings.Default.money_unit);
                                param.Add(row["ITEM_ID"].ToString());
                                param.Add(row["BILL_DETAIL_ID"].ToString());
                                param.Add(row["APPLY_DISCOUNT"].ToString());
                                param.Add(GF.formatNumber(Convert.ToInt32(row["AMOUNT_LEFT"].ToString())));

                                pushRow("ITEM", param);
                                total_amount += Convert.ToInt32(row["PRICE"].ToString());
                            }
                            break;
                    }
                }
            }

            // ================================== DISCOUNT ======================================================
            queryString = "SELECT * FROM BILL_DISCOUNT WHERE BILL_ID = " + billID.ToString() + " AND IS_PROMOTION = 0 ORDER BY BILL_DETAIL_ID DESC";
            using (DataTable DT = DB.getS(queryString, null, "GET BILL_DISCOUNT FROM BILL_ID[" + billID.ToString() + "]", false))
            {
                foreach (DataRow row in DT.Rows)
                {
                    string discount_name = "";
                    if (row["IS_BARTER"].ToString() == "1") discount_name += "BARTER ";
                    if (row["USE_CARD_TYPE"].ToString() == "0") discount_name += "MEMBER CARD ";
                    if (row["USE_CARD_TYPE"].ToString() == "3") discount_name += "COUPON ";
                    if (row["USE_CARD_TYPE"].ToString() == "4") discount_name += "VIP CARD ";
                    if (row["USE_CARD_TYPE"].ToString() == "5" && discount_name.IndexOf("BARTER") == -1) discount_name += "BARTER ";
                    if (row["USE_CARD_TYPE"].ToString() == "6") discount_name += "OTHER ";

                    List<string> param = new List<string>();

                    if (row["USE_CARD_TYPE"].ToString() != "7") param.Add(discount_name + "DISCOUNT");
                    else param.Add("PAID");

                    param.Add(row["RAW_TEXT"].ToString());
                    param.Add(GF.formatNumber(Convert.ToInt32(row["AMOUNT"].ToString())));
                    param.Add((row["UNIT"].ToString() == "0" ? "%" : Properties.Settings.Default.money_unit));
                    param.Add(row["BILL_DETAIL_ID"].ToString());
                    param.Add(row["BILL_DISCOUNT_ID"].ToString());
                    param.Add("0");
                    param.Add("0");
                    param.Add(row["USE_CARD_ID"].ToString());

                    if (row["USE_CARD_TYPE"].ToString() != "7") pushRow("DISCOUNT", param);
                    else pushRow("PAID", param);

                    if (row["USE_CARD_TYPE"].ToString() != "7") discount_amount += Convert.ToInt32(row["AMOUNT"].ToString());
                    else paid_amount += Convert.ToInt32(row["AMOUNT"].ToString());
                    //MessageBox.Show(row["AMOUNT"].ToString() + " -> " + discount_amount.ToString());
                }
            }

            // =================================== PAID DETAIL ===============================================

            queryString = @"
            SELECT B.IS_PAID, A.* 
            FROM BILL_PAYMENT A
            INNER JOIN BILL B ON A.BILL_ID = B.BILL_ID
            WHERE A.BILL_ID = " + billID.ToString();
            using (DataTable DT = DB.getS(queryString, null, "GET BILL_PAYMENT IN BILL_ID[" + billID.ToString() + "]", false))
            {
                foreach(DataRow row in DT.Rows){
                    String paymentType = "";
                    String amount_left = "0";
                    switch (row["payment_type"].ToString())
                    {
                        case "0":
                            paymentType = "CASH";
                            break;
                        case "1":
                            paymentType = "CREDIT CARD";
                            break;
                        case "2":
                            paymentType = "MEMBER CARD";
                            if (row["IS_PAID"].ToString() == "0")
                            {
                                queryString = "SELECT * FROM MEMBERCARD WHERE MEMBERCARD_ID = " + row["USE_CARD_ID"].ToString();
                                using (DataTable tmpDT = DB.getS(queryString, null, "GET MEMBERCARD[" + row["USE_CARD_ID"].ToString() + "] BALANCE", false))
                                {
                                    amount_left = tmpDT.Rows[0]["BALANCE"].ToString();
                                }
                            }
                            break;
                        case "3":
                            if (row["IS_PAID"].ToString() == "0")
                            {
                                queryString = "SELECT * FROM GIFT_CERTIFICATE WHERE GIFT_CERTIFICATE_ID = " + row["USE_CARD_ID"].ToString();
                                using (DataTable tmpDT = DB.getS(queryString, null, "GET CERTIFICATE[" + row["USE_CARD_ID"].ToString() + "] BALANCE", false))
                                {
                                    if (tmpDT.Rows[0]["SPA_PROGRAM_ID"].ToString() == "-1")
                                    {
                                        amount_left = tmpDT.Rows[0]["BALANCE"].ToString();
                                    }
                                }
                            }
                            break;
                    }

                    List<string> param = new List<string>();
                    
                    param.Add("PAID");
                    param.Add((row["RAW_TEXT"].ToString() == "" ? ("by " + paymentType) : row["RAW_TEXT"].ToString()));
                    param.Add(GF.formatNumber(Convert.ToInt32(row["MONEY_RECEIVE"].ToString())));
                    param.Add(Properties.Settings.Default.money_unit);
                    param.Add("");
                    param.Add(row["BILL_PAYMENT_ID"].ToString());
                    param.Add("0");
                    param.Add(amount_left);
                    param.Add(row["USE_CARD_ID"].ToString());

                    pushRow("PAID", param);

                    paid_amount += (Convert.ToInt32(row["MONEY_RECEIVE"].ToString()));
                }
            }

            total.Text = GF.formatDecimal(total_amount);
            discount.Text = GF.formatDecimal(discount_amount);
            paid.Text = GF.formatDecimal(paid_amount);
            grand_total.Text = GF.formatDecimal(total_amount - discount_amount - paid_amount);

            done_btn.Visible = false;
            if (isPaid)
            {
                toggleAllDiscount("DISABLE");
                GF.disableButton(pay_by_cash_btn);
                GF.disableButton(pay_by_credit_card_btn);
                GF.disableButton(personal_credit_btn);
                GF.disableButton(manage_btn);
                GF.disableButton(other_discount_btn);
                GF.disableButton(add_customer_btn);
                GF.enableButton(new_bill_btn);

                btn_dgv.DGV.Enabled = false;
                customer_id.Enabled = false;
                item_type.Enabled = false;
                item_id.Enabled = false;
            }
            else
            {
                toggleAllDiscount("ENABLE");
                if (Convert.ToInt32(GF.removeThousandAndDecimal(grand_total.Text)) <= 0) done_btn.Visible = true;
                if (modified_spa_row == 0)
                {
                    if (invoice_datetime != "")
                    {
                        GF.enableButton(pay_by_cash_btn);
                        GF.enableButton(pay_by_credit_card_btn);
                        GF.enableButton(personal_credit_btn);
                    }
                    else
                    {
                        GF.disableButton(pay_by_cash_btn);
                        GF.disableButton(pay_by_credit_card_btn);
                        GF.disableButton(personal_credit_btn);
                        done_btn.Visible = false;
                    }
                }
                else
                {
                    GF.disableButton(pay_by_cash_btn);
                    GF.disableButton(pay_by_credit_card_btn);
                    GF.disableButton(personal_credit_btn);
                    done_btn.Visible = false;
                }
                GF.enableButton(manage_btn);
                GF.enableButton(other_discount_btn);
                GF.enableButton(add_customer_btn);
                GF.disableButton(new_bill_btn);

                btn_dgv.DGV.Enabled = true;
                customer_id.Enabled = true;
                item_type.Enabled = true;
                item_id.Enabled = true;
            }

            GF.enableButton(invoice_btn);
            DGV.ClearSelection();
            GF.updateRowNum(btn_dgv.DGV);
            //updateTotal();
            GF.closeLoading();
        }

        public void updateTotal()
        {
            total.Text = "0.00";
            discount.Text = "0.00";
            paid.Text = "0.00";
            grand_total.Text = "0.00";

            foreach (DataGridViewRow row in DGV.Rows)
            {
                if (row.Cells["ITEM_TYPE"].Value != null)
                {
                    if (row.Cells["ITEM_TYPE"].Value.ToString() != "PAID" && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") == -1)
                    {
                        row.Cells["AMOUNT_LEFT"].Value = GF.removeThousandAndDecimal(row.Cells["AMOUNT"].Value.ToString());
                    }
                }
            }

            calculateTotal();
            calculatePromotion();
            calculateDiscount();
            calculatePrePaid();
            calculatePaid();
            calculateGrandTotal();
        }

        void calculateTotal()
        {
            total_amount = 0;
            no_discount_amount = 0;
            foreach (DataGridViewRow row in DGV.Rows)
            {
                if (row.Cells["ITEM_TYPE"].Value != null)
                {
                    if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") == -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PAID") == -1)
                    {
                        total_amount += Convert.ToInt32(GF.removeThousandAndDecimal(row.Cells["AMOUNT"].Value.ToString()));
                        if (row.Cells["APPLY_DISCOUNT"].Value.ToString() == "0") no_discount_amount += Convert.ToInt32(GF.removeThousandAndDecimal(row.Cells["AMOUNT"].Value.ToString()));
                    }
                }
            }
            total.Text = GF.formatDecimal(total_amount);
        }

        void calculatePromotion()
        {
            foreach (DataGridViewRow row in DGV.Rows) // COMBINATION, ITEM
            {
                if (row.Cells["ITEM_TYPE"].Value != null)
                {
                    if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PROMOTION") != -1)
                    {
                        int sharpCount = 0;
                        foreach (Char target in row.Cells["DETAIL"].Value.ToString())
                        {
                            if (target == '#') sharpCount++;
                        }
                        if (sharpCount > 0)
                        {
                            if(row.Cells["UNIT"].Value.ToString().Trim() == "%")
                                discount_amount += ((total_amount - no_discount_amount) * Convert.ToInt32(GF.removeThousandAndDecimal(row.Cells["AMOUNT"].Value.ToString()))) / 100;
                            if(row.Cells["UNIT"].Value.ToString().Trim() == Properties.Settings.Default.money_unit)
                                discount_amount += Convert.ToInt32(GF.removeThousandAndDecimal(row.Cells["AMOUNT"].Value.ToString()));
                        }
                    }
                }
            }

            // PROMOTION DISCOUNT ALL
            foreach (DataGridViewRow row in DGV.Rows) // COMBINATION
            {
                if (row.Cells["ITEM_TYPE"].Value != null)
                {
                    if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PROMOTION") != -1)
                    {
                        if (row.Cells["DETAIL"].Value.ToString().IndexOf("ALL") != -1)
                        {
                            switch (row.Cells["UNIT"].Value.ToString())
                            {
                                case "0": //%
                                    discount_amount += ((total_amount - no_discount_amount) * Convert.ToInt32(GF.removeThousandAndDecimal(row.Cells["AMOUNT"].Value.ToString()))) / 100;
                                    break;
                                case "1": // Rub
                                    discount_amount += Convert.ToInt32(GF.removeThousandAndDecimal(row.Cells["AMOUNT"].Value.ToString()));
                                    break;
                            }
                        }
                    }
                }
            }
        }

        void calculateDiscount()
        {
            /* === NOTE ===
             * MANUAL DISCOUNT
             * IS IN
             * calculatePaid()
             */ 
            discount_amount = 0;

            foreach (DataGridViewRow row in DGV.Rows) // ITEM :: OTHER & BARTER *********************
            {
                if (row.Cells["ITEM_TYPE"].Value != null)
                {
                    if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") != -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PROMOTION") == -1 && row.Cells["SOURCE_ID"].Value.ToString() != "-1" && (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("BARTER") != -1 || row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("OTHER") != -1))
                    {
                        foreach (DataGridViewRow spaRow in DGV.Rows)
                        {
                            if (spaRow.Cells["ITEM_TYPE"].Value != null)
                            {
                                if (spaRow.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") == -1 && spaRow.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PAID") == -1)
                                {
                                    if (spaRow.Cells["BILL_TARGET_ID"].Value.ToString() == row.Cells["SOURCE_ID"].Value.ToString())
                                    {
                                        string tmp = row.Cells["DETAIL"].Value.ToString().Substring(row.Cells["DETAIL"].Value.ToString().IndexOf("**")).Trim();
                                        tmp = tmp.Substring(3, tmp.Length - 6).Trim();

                                        int amount = 0;
                                        if (tmp.Substring(tmp.Length - Properties.Settings.Default.money_unit.Length).Trim() == Properties.Settings.Default.money_unit)
                                        {
                                            tmp = tmp.Substring(0, tmp.Length - Properties.Settings.Default.money_unit.Length).Trim();
                                            amount = Convert.ToInt32(GF.removeThousandAndDecimal(tmp));
                                        }
                                        else
                                        {
                                            tmp = tmp.Substring(0, tmp.Length - 1).Trim();
                                            amount = (int)Math.Floor((Convert.ToDouble(GF.removeThousandAndDecimal(spaRow.Cells["AMOUNT_LEFT"].Value.ToString())) * Convert.ToDouble(GF.removeThousandAndDecimal(tmp))) / 100);
                                        }
                                        discount_amount += amount;
                                        row.Cells["AMOUNT"].Value = GF.formatNumber(amount);
                                        spaRow.Cells["AMOUNT_LEFT"].Value = GF.formatNumber(Convert.ToInt32(GF.removeThousandAndDecimal(spaRow.Cells["AMOUNT_LEFT"].Value.ToString())) - amount);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            foreach (DataGridViewRow row in DGV.Rows) // ALL :: MEMBERCARD & VIP & BARTER & VOUCHER & COUPON *********************
            {
                if (row.Cells["ITEM_TYPE"].Value != null)
                {
                    if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") != -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PROMOTION") == -1 && row.Cells["SOURCE_ID"].Value.ToString() == "-1" && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("OTHER") == -1)
                    {
                        int this_item_discount = 0;
                        string tmp = row.Cells["DETAIL"].Value.ToString().Substring(row.Cells["DETAIL"].Value.ToString().IndexOf("**")).Trim();
                        tmp = tmp.Substring(3, tmp.Length - 6).Trim();

                        if (row.Cells["DETAIL"].Value.ToString().IndexOf("ALL SPA PROGRAM") != -1 && tmp.Substring(tmp.Length - Properties.Settings.Default.money_unit.Length).Trim() == Properties.Settings.Default.money_unit)
                        {
                            tmp = tmp.Substring(0, tmp.Length - Properties.Settings.Default.money_unit.Length).Trim();
                            this_item_discount += Convert.ToInt32(GF.removeThousandAndDecimal(tmp));
                        }
                        else
                        {
                            this_item_discount = 0;
                            foreach (DataGridViewRow spaRow in DGV.Rows)
                            {
                                if (spaRow.Cells["ITEM_TYPE"].Value != null)
                                {
                                    if (spaRow.Cells["ITEM_TYPE"].Value.ToString() == "MASSAGE" || spaRow.Cells["ITEM_TYPE"].Value.ToString() == "SPA MENU GIFT CERTIFICATE")
                                    {
                                        if (spaRow.Cells["APPLY_DISCOUNT"].Value.ToString() == "1")
                                        {
                                            tmp = row.Cells["DETAIL"].Value.ToString().Substring(row.Cells["DETAIL"].Value.ToString().IndexOf("**")).Trim();
                                            tmp = tmp.Substring(3, tmp.Length - 6).Trim();

                                            int amount = 0;
                                            if (tmp.Substring(tmp.Length - Properties.Settings.Default.money_unit.Length).Trim() == Properties.Settings.Default.money_unit)
                                            {
                                                tmp = tmp.Substring(0, tmp.Length - Properties.Settings.Default.money_unit.Length).Trim();
                                                amount = Convert.ToInt32(GF.removeThousandAndDecimal(tmp));
                                            }
                                            else
                                            {
                                                tmp = tmp.Substring(0, tmp.Length - 1).Trim();
                                                amount = (int)Math.Floor((Convert.ToDouble(GF.removeThousandAndDecimal(spaRow.Cells["AMOUNT_LEFT"].Value.ToString())) * Convert.ToDouble(GF.removeThousandAndDecimal(tmp))) / 100);
                                            }

                                            this_item_discount += amount;
                                            spaRow.Cells["AMOUNT_LEFT"].Value = GF.formatNumber(Convert.ToInt32(GF.removeThousandAndDecimal(spaRow.Cells["AMOUNT_LEFT"].Value.ToString())) - amount);
                                        }
                                    }
                                }
                            }
                        }

                        foreach (DataGridViewRow itemRow in DGV.Rows)
                        {
                            if (itemRow.Cells["ITEM_TYPE"].Value != null)
                            {
                                if (itemRow.Cells["ITEM_TYPE"].Value.ToString().IndexOf("ITEM") != -1)
                                {
                                    tmp = row.Cells["DETAIL"].Value.ToString().Substring(row.Cells["DETAIL"].Value.ToString().IndexOf("**")).Trim();
                                    tmp = tmp.Substring(3, tmp.Length - 6).Trim();

                                    int amount = 0;
                                    if (tmp.Substring(tmp.Length - Properties.Settings.Default.money_unit.Length).Trim() == Properties.Settings.Default.money_unit)
                                    {
                                        tmp = tmp.Substring(0, tmp.Length - Properties.Settings.Default.money_unit.Length).Trim();
                                        amount = Convert.ToInt32(GF.removeThousandAndDecimal(tmp));
                                    }
                                    else
                                    {
                                        tmp = tmp.Substring(0, tmp.Length - 1).Trim();
                                        amount = (int)Math.Floor((Convert.ToDouble(GF.removeThousandAndDecimal(itemRow.Cells["AMOUNT_LEFT"].Value.ToString())) * Convert.ToDouble(GF.removeThousandAndDecimal(tmp))) / 100);
                                    }

                                    this_item_discount += amount;
                                    itemRow.Cells["AMOUNT_LEFT"].Value = GF.formatNumber(Convert.ToInt32(GF.removeThousandAndDecimal(itemRow.Cells["AMOUNT_LEFT"].Value.ToString())) - amount);
                                }
                            }
                        }

                        discount_amount += this_item_discount;
                        row.Cells["AMOUNT"].Value = GF.formatNumber(this_item_discount);
                    }
                }
            }
            discount.Text = GF.formatDecimal(discount_amount);
            calculateGrandTotal();
        }

        void calculatePrePaid()
        {
            // PUT AMOUNT_LEFT OF MATCHED ITEM INTO SPA MENU GIFT CERTIFICATE OR GIFT VOUCHER OR COUPON
            foreach (DataGridViewRow row in DGV.Rows) // ITEM :: %
            {
                if (row.Cells["ITEM_TYPE"].Value != null)
                {
                    if (row.Cells["ITEM_TYPE"].Value.ToString() == "PAID" && (row.Cells["DETAIL"].Value.ToString().IndexOf("SPA MENU GIFT CERTIFICATE") != -1 || row.Cells["DETAIL"].Value.ToString().IndexOf("GIFT VOUCHER") != -1 || (row.Cells["DETAIL"].Value.ToString().IndexOf("COUPON") != -1 && row.Cells["DETAIL"].Value.ToString().IndexOf("MONEY COUPON") == -1)))
                    {
                        foreach (DataGridViewRow targetRow in DGV.Rows)
                        {
                            if (targetRow.Cells["ITEM_TYPE"].Value != null)
                            {
                                if (targetRow.Cells["BILL_TARGET_ID"].Value.ToString() == row.Cells["SOURCE_ID"].Value.ToString())
                                {
                                    row.Cells["AMOUNT"].Value = targetRow.Cells["AMOUNT_LEFT"].Value;
                                    row.Cells["UNIT"].Value = Properties.Settings.Default.money_unit;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            calculateGrandTotal();
        }

        void calculatePaid()
        {
            //MessageBox.Show("#1\r\nTOTAL : " + total.Text + "\r\nDISCOUNT : " + discount_amount.ToString() + "\r\nPAID : " + paid_amount.ToString() + "\r\nGRAND TOTAL : " + grand_total.Text);

            // SPA MENU GIFT CERTIFICATE, VOUCHER , COUPON , CROSS PROMOTION
            foreach (DataGridViewRow row in DGV.Rows)
            {
                if (row.Cells["ITEM_TYPE"].Value != null)
                {
                    if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PAID") != -1 && (row.Cells["DETAIL"].Value.ToString().IndexOf("SPA MENU GIFT CERTIFICATE") != -1 || (row.Cells["DETAIL"].Value.ToString().IndexOf("GIFT VOUCHER") != -1 && row.Cells["DETAIL"].Value.ToString().IndexOf("ALL SPA") == -1) || row.Cells["DETAIL"].Value.ToString().IndexOf("CROSS PROMOTION") != -1 || (row.Cells["DETAIL"].Value.ToString().IndexOf("COUPON") != -1 && row.Cells["DETAIL"].Value.ToString().IndexOf("MONEY COUPON") == -1)))
                    {
                        foreach (DataGridViewRow targetRow in DGV.Rows)
                        {
                            if (targetRow.Cells["ITEM_TYPE"].Value != null)
                            {
                                if (targetRow.Cells["BILL_TARGET_ID"].Value.ToString() == row.Cells["SOURCE_ID"].Value.ToString())
                                {
                                    string tmp = row.Cells["DETAIL"].Value.ToString().Substring(row.Cells["DETAIL"].Value.ToString().IndexOf("**")).Trim();
                                    tmp = tmp.Substring(3, tmp.Length - 6).Trim();

                                    int amount = 0;
                                    if (tmp.Substring(tmp.Length - Properties.Settings.Default.money_unit.Length).Trim() == Properties.Settings.Default.money_unit)
                                    {
                                        tmp = tmp.Substring(0, tmp.Length - Properties.Settings.Default.money_unit.Length).Trim();
                                        amount = Convert.ToInt32(GF.removeThousandAndDecimal(tmp));
                                    }
                                    else
                                    {
                                        tmp = tmp.Substring(0, tmp.Length - 1).Trim();
                                        amount = (int)Math.Floor((Convert.ToDouble(GF.removeThousandAndDecimal(targetRow.Cells["AMOUNT_LEFT"].Value.ToString())) * Convert.ToDouble(GF.removeThousandAndDecimal(tmp))) / 100);
                                    }

                                    row.Cells["AMOUNT"].Value = GF.formatNumber(amount);
                                    targetRow.Cells["AMOUNT_LEFT"].Value = (Convert.ToInt32(GF.removeThousandAndDecimal(targetRow.Cells["AMOUNT_LEFT"].Value.ToString())) - amount).ToString();
                                    break;
                                }
                            }
                        }
                        paid.Text = GF.formatDecimal(Convert.ToInt32(GF.removeThousandAndDecimal(paid.Text)) + Convert.ToInt32(GF.removeThousandAndDecimal(row.Cells["AMOUNT"].Value.ToString())));
                    }
                }
            }
            calculateGrandTotal();
            //MessageBox.Show("#2\r\nTOTAL : " + total.Text + "\r\nDISCOUNT : " + discount_amount.ToString() + "\r\nPAID : " + paid_amount.ToString() + "\r\nGRAND TOTAL : " + grand_total.Text);

            // OTHER DISCOUNT for FINAL DISCOUNT :: ALL
            foreach (DataGridViewRow row in DGV.Rows)
            {
                if (row.Cells["ITEM_TYPE"].Value != null)
                {
                    if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("OTHER") != -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PRODUCT") == -1 && row.Cells["SOURCE_ID"].Value.ToString() == "-1")
                    {
                        string tmp = row.Cells["DETAIL"].Value.ToString().Substring(row.Cells["DETAIL"].Value.ToString().IndexOf("**")).Trim();
                        tmp = tmp.Substring(3, tmp.Length - 6).Trim();

                        int amount = 0;
                        if (tmp.Substring(tmp.Length - Properties.Settings.Default.money_unit.Length).Trim() == Properties.Settings.Default.money_unit)
                        {
                            tmp = tmp.Substring(0, tmp.Length - Properties.Settings.Default.money_unit.Length).Trim();
                            amount = Convert.ToInt32(GF.removeThousandAndDecimal(tmp));
                        }
                        else
                        {
                            tmp = tmp.Substring(0, tmp.Length - 1).Trim();
                            amount = (int)Math.Floor((Convert.ToDouble(GF.removeThousandAndDecimal(grand_total.Text)) * Convert.ToDouble(GF.removeThousandAndDecimal(tmp))) / 100);
                        }
                        
                        discount.Text = GF.formatDecimal(Convert.ToInt32(GF.removeThousandAndDecimal(discount.Text.Trim())) + amount);
                        row.Cells["AMOUNT"].Value = GF.formatNumber(amount);
                    }
                }
            }
            calculateGrandTotal();
            //MessageBox.Show("#4\r\nTOTAL : " + total.Text + "\r\nDISCOUNT : " + discount_amount.ToString() + "\r\nPAID : " + paid_amount.ToString() + "\r\nGRAND TOTAL : " + grand_total.Text);

            // PAID :: MONEY COUPON
            foreach (DataGridViewRow row in DGV.Rows)
            {
                if (row.Cells["ITEM_TYPE"].Value != null)
                {
                    if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PAID") != -1 && row.Cells["DETAIL"].Value.ToString().IndexOf("MONEY COUPON") != -1 && row.Cells["AMOUNT_LEFT"].Value.ToString() != "")
                    {
                        int amount = 0;

                        foreach (DataGridViewRow tmpRow in DGV.Rows)
                        {
                            if (tmpRow.Cells["ITEM_TYPE"].Value != null)
                            {
                                if (tmpRow.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") == -1 && tmpRow.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PAID") == -1 && tmpRow.Cells["ITEM_TYPE"].Value.ToString() != "MEMBERCARD" && tmpRow.Cells["ITEM_TYPE"].Value.ToString().IndexOf("GIFT CERTIFICATE") == -1)
                                {
                                    amount += Convert.ToInt32(GF.removeThousandAndDecimal(tmpRow.Cells["AMOUNT_LEFT"].Value.ToString()));
                                }
                            }
                        }

                        if (amount > Convert.ToInt32(row.Cells["AMOUNT_LEFT"].Value.ToString()))
                            amount = Convert.ToInt32(row.Cells["AMOUNT_LEFT"].Value.ToString());

                        paid.Text = GF.formatDecimal(Convert.ToInt32(GF.removeThousandAndDecimal(paid.Text)) + amount);

                        row.Cells["AMOUNT"].Value = GF.formatNumber(amount);
                    }
                }
            }
            calculateGrandTotal();

            // PAID :: MONEY GIFT CERTIFICATE
            bool found = false;
            foreach (DataGridViewRow row in DGV.Rows)
            {
                if (row.Cells["ITEM_TYPE"].Value != null)
                {
                    if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("ITEM") != -1)
                    {
                        found = true;
                        break;
                    }
                }
            }

            if (Convert.ToInt32(GF.removeThousandAndDecimal(grand_total.Text)) > 0 && !found)
            {
                foreach (DataGridViewRow row in DGV.Rows)
                {
                    if (row.Cells["ITEM_TYPE"].Value != null)
                    {
                        if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PAID") != -1 && row.Cells["DETAIL"].Value.ToString().IndexOf("MONEY GIFT CERTIFICATE") != -1)
                        {
                            int amount = 0;

                            foreach (DataGridViewRow tmpRow in DGV.Rows)
                            {
                                if (tmpRow.Cells["ITEM_TYPE"].Value != null)
                                {
                                    if (tmpRow.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") == -1 && tmpRow.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PAID") == -1 && tmpRow.Cells["ITEM_TYPE"].Value.ToString().IndexOf("ITEM") == -1 && tmpRow.Cells["ITEM_TYPE"].Value.ToString() != "MEMBERCARD" && tmpRow.Cells["ITEM_TYPE"].Value.ToString().IndexOf("GIFT CERTIFICATE") == -1)
                                    {
                                        amount += Convert.ToInt32(GF.removeThousandAndDecimal(tmpRow.Cells["AMOUNT_LEFT"].Value.ToString()));
                                    }
                                }
                            }
                            
                            if (amount > Convert.ToInt32(row.Cells["AMOUNT_LEFT"].Value.ToString()))
                                amount = Convert.ToInt32(row.Cells["AMOUNT_LEFT"].Value.ToString());
                            
                            paid.Text = GF.formatDecimal(Convert.ToInt32(GF.removeThousandAndDecimal(paid.Text)) + amount);
                            
                            row.Cells["AMOUNT"].Value = GF.formatNumber(amount);
                        }
                    }
                }
                calculateGrandTotal();
            }

            // PAID :: MEMBER
            if (Convert.ToInt32(GF.removeThousandAndDecimal(grand_total.Text)) > 0 && !found)
            {
                foreach (DataGridViewRow row in DGV.Rows)
                {
                    if (row.Cells["ITEM_TYPE"].Value != null)
                    {
                        if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PAID") != -1 && row.Cells["DETAIL"].Value.ToString().IndexOf("MEMBER") != -1)
                        {
                            int amount = 0;
                            foreach (DataGridViewRow tmpRow in DGV.Rows)
                            {
                                if (tmpRow.Cells["ITEM_TYPE"].Value != null)
                                {
                                    if (tmpRow.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") == -1 && tmpRow.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PAID") == -1 && tmpRow.Cells["ITEM_TYPE"].Value.ToString().IndexOf("ITEM") == -1 && tmpRow.Cells["ITEM_TYPE"].Value.ToString() != "MEMBERCARD" && tmpRow.Cells["ITEM_TYPE"].Value.ToString() != "MONEY GIFT CERTIFICATE")
                                    {
                                        amount += Convert.ToInt32(GF.removeThousandAndDecimal(tmpRow.Cells["AMOUNT_LEFT"].Value.ToString()));
                                    }
                                }
                            }

                            if (amount > Convert.ToInt32(row.Cells["AMOUNT_LEFT"].Value.ToString()))
                                amount = Convert.ToInt32(row.Cells["AMOUNT_LEFT"].Value.ToString());

                            paid.Text = GF.formatDecimal(Convert.ToInt32(GF.removeThousandAndDecimal(paid.Text)) + amount);

                            row.Cells["AMOUNT"].Value = GF.formatNumber(amount);
                        }
                    }
                }
                //MessageBox.Show("#5\r\nTOTAL : " + total.Text + "\r\nDISCOUNT : " + discount_amount.ToString() + "\r\nPAID : " + paid_amount.ToString() + "\r\nGRAND TOTAL : " + grand_total.Text);
                calculateGrandTotal();
            }

            // PAID :: CASH, CREDIT
            foreach (DataGridViewRow row in DGV.Rows)
            {
                if (row.Cells["ITEM_TYPE"].Value != null)
                {
                    if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PAID") != -1 && (row.Cells["DETAIL"].Value.ToString().IndexOf("CASH") != -1 || row.Cells["DETAIL"].Value.ToString().IndexOf("CREDIT") != -1))
                    {
                        paid.Text = GF.formatDecimal(Convert.ToInt32(GF.removeThousandAndDecimal(paid.Text)) + Convert.ToInt32(GF.removeThousandAndDecimal(row.Cells["AMOUNT"].Value.ToString())));
                    }
                }
            }
            calculateGrandTotal();
        }

        void calculateGrandTotal()
        {
            int total_amount = Convert.ToInt32(GF.removeThousandAndDecimal(total.Text.Trim()));
            int discount_amount = Convert.ToInt32(GF.removeThousandAndDecimal(discount.Text.Trim()));
            int paid_amount = Convert.ToInt32(GF.removeThousandAndDecimal(paid.Text.Trim()));

            grand_total.Text = GF.formatDecimal(total_amount - discount_amount - paid_amount);
            if (Convert.ToInt32(GF.removeThousandAndDecimal(grand_total.Text.Trim())) == 0 && DGV.Rows.Count > 0)
            {
                done_btn.Visible = true;
            }
            else
            {
                done_btn.Visible = false;
            }
        }

        private void bill_no_KeyUp(object sender, KeyEventArgs e)
        {
            if (bill_no.Text.Trim().Length == 12 && e.KeyCode == Keys.Return)
            {
                GF.showLoading(this);

                clearTmpBill();
                Dictionary<string, string> Params = new Dictionary<string, string>();
                //Params.Add("@bill_no", bill_no.Text);

                String queryString = "SELECT BILL_ID FROM BILL WHERE BILL_NO = '" + bill_no.Text + "'";
                using (DataTable DT = DB.getS(queryString, Params, "", false))
                {
                    if (DT.Rows.Count == 0)
                    {
                        MessageBox.Show("NO BILL WITH THIS CODE !!", "ERROR");
                        GF.closeLoading();
                        return;
                    }
                    else
                    {
                        billID = Convert.ToInt32(DT.Rows[0]["BILL_ID"].ToString());
                    }
                }
                loadData();
                //updateTotal();
                gen = false;

                if (!voided.Visible) GF.enableButton(void_btn);
                GF.closeLoading();
            }
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if (customer_id.currentID == -1 && ((ComboItem)item_type.SelectedItem).Key == 1)
            {
                MessageBox.Show("PLEASE SELECT CUSTOMER !!", "ERROR");
                customer_id.Focus();
                return;
            }

            if (((ComboItem)item_type.SelectedItem).Key == 0 || ((ComboItem)item_type.SelectedItem).Key == 5 || ((ComboItem)item_type.SelectedItem).Key == 7 || ((ComboItem)item_type.SelectedItem).Key == 8) // PRODUCT & OTHER + RESTAURANT
            {
                String caption = ((ComboItem)item_type.SelectedItem).Value;

                if (((ComboItem)item_id.SelectedItem).Key == -99) // BARCODE
                {
                    using (scan_barcode scan = new scan_barcode())
                    {
                        productRow = null;
                        scan.Mode = "PRODUCT";
                        scan.Owner = this;
                        scan.ShowDialog();
                    }

                    item_amount = 0;

                    if (productRow == null) return;

                    using (item_amount itemAmount = new item_amount())
                    {
                        itemAmount.Owner = this;
                        itemAmount.Text = "AMOUNT of " + productRow["ITEM_NAME"].ToString();
                        itemAmount.ShowDialog();
                    }

                    if (item_amount <= 0) return;
                    List<string> param = new List<string>();

                    param.Add(caption);
                    param.Add(productRow["ITEM_NAME"].ToString() + " [" + item_amount.ToString() + "]");

                    param.Add(GF.formatNumber(Convert.ToInt32(productRow["PRICE"].ToString()) * item_amount));
                    param.Add(Properties.Settings.Default.money_unit);
                    param.Add(productRow["ITEM_ID"].ToString());
                    param.Add(getRand());
                    param.Add(productRow["APPLY_DISCOUNT"].ToString());
                    param.Add(Properties.Settings.Default.money_unit);
                    param.Add(Convert.ToInt32(productRow["PRICE"].ToString()).ToString());

                    pushRow("ITEM", param);
                    updateTotal();
                }
                else if (((ComboItem)item_id.SelectedItem).Key == 0) // MISC ITEM
                {
                     using (misc_item miscItem = new misc_item())
                    {
                        miscItem.Owner = this;
                        miscItem.item_type = ((ComboItem)item_type.SelectedItem).Value;
                        miscItem.ShowDialog();
                    }
                }
                else
                {
                    if (item_id.Text.IndexOf("===") != -1)
                    {
                        MessageBox.Show("PLEASE CHOOSE ITEM !!", "ERROR");
                        return;
                    }

                    item_amount = 0;

                    using (item_amount itemAmount = new item_amount())
                    {
                        itemAmount.Owner = this;
                        itemAmount.Text = "AMOUNT of " + item_id.Text;
                        itemAmount.amount.Enabled = true;
                        itemAmount.ShowDialog();
                    }

                    if (item_amount <= 0) return;
                    List<string> param = new List<string>();
                    param.Add(caption);
                    param.Add(item_id.Text + " [" + item_amount.ToString() + "]");

                    int type_name_count = 0;
                    foreach (ComboItem item in item_id.Items)
                    {
                        if (item.Value == item_id.Text) break;
                        if (item.Value.IndexOf("MISC") != -1 || item.Value.IndexOf("===") != -1) type_name_count++;
                    }

                    int itemIndex = item_id.SelectedIndex - type_name_count;
                    param.Add(GF.formatNumber(Convert.ToInt32(item_list[itemIndex]["PRICE"].ToString()) * item_amount));
                    param.Add(Properties.Settings.Default.money_unit);
                    param.Add(item_list[itemIndex]["ITEM_ID"].ToString());
                    param.Add(getRand());
                    param.Add(item_list[itemIndex]["APPLY_DISCOUNT"].ToString());
                    param.Add(Properties.Settings.Default.money_unit);
                    param.Add(Convert.ToInt32(item_list[itemIndex]["PRICE"].ToString()).ToString());

                    pushRow("ITEM", param);
                    updateTotal();
                }
            }

            if (((ComboItem)item_type.SelectedItem).Key == 1) // MEMBERCARD
            {
                List<string> param = new List<string>();
                param.Add("MEMBERCARD");
                param.Add(item_id.Text);
                param.Add(GF.formatNumber(Convert.ToInt32(membercard_price_list[item_id.SelectedIndex])));
                param.Add(Properties.Settings.Default.money_unit);
                param.Add(getRand());
                param.Add(getRand());
                param.Add("0");
                param.Add(Convert.ToInt32(membercard_price_list[item_id.SelectedIndex]).ToString());

                pushRow("MEMBERCARD", param);
                updateTotal();
            }

            if (((ComboItem)item_type.SelectedItem).Key == 2 || ((ComboItem)item_type.SelectedItem).Key == 6) // GIFT CERT.
            {
                Boolean is_website = ((ComboItem)item_type.SelectedItem).Key == 6;
                if (item_id.SelectedIndex == 0)
                {
                    if (MessageBox.Show("DO YOU HAVE THE CARD NUMBER ?", "Method", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        using (register_gift_certificate registerGC = new register_gift_certificate())
                        {
                            registerGC.is_website = is_website;
                            registerGC.Owner = this;
                            registerGC.choiceTab.TabPages.RemoveAt(1);
                            registerGC.ShowDialog();
                        }
                    }
                    else
                    {
                        using (gift_certificate_spa_program giftCertificateDetail = new gift_certificate_spa_program())
                        {
                            giftCertificateDetail.is_website = is_website;
                            giftCertificateDetail.Owner = this;
                            giftCertificateDetail.billID = billID;
                            giftCertificateDetail.ShowDialog();
                        }
                    }
                }

                if (item_id.SelectedIndex == 1)
                {
                    if (MessageBox.Show("DO YOU HAVE THE CARD NUMBER ?", "Method", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        using (register_gift_certificate registerGC = new register_gift_certificate())
                        {
                            registerGC.is_website = is_website;
                            registerGC.Owner = this;
                            registerGC.choiceTab.TabPages.RemoveAt(0);
                            registerGC.ShowDialog();
                        }
                    }
                    else
                    {
                        using (gift_certificate_money giftCertificateDetail = new gift_certificate_money())
                        {
                            giftCertificateDetail.is_website = is_website;
                            giftCertificateDetail.Owner = this;
                            giftCertificateDetail.billID = billID;
                            giftCertificateDetail.ShowDialog();
                        }
                    }
                }
            }

            /*if (((ComboItem)item_type.SelectedItem).Key == 5) // DELIVERY CLUB
            {
                if (((ComboItem)item_id.SelectedItem).Key != -99 && ((ComboItem)item_id.SelectedItem).Key != 0)
                {
                    using (item_amount itemAmount = new item_amount())
                    {
                        itemAmount.Owner = this;
                        itemAmount.Text = "AMOUNT of " + item_id.Text;
                        itemAmount.ShowDialog();
                    }

                    if (item_amount <= 0) return;

                    List<string> param = new List<string>();
                    param.Add("DELIVERY CLUB");
                    param.Add(item_id.Text + " [" + item_amount.ToString() + "]");
                    param.Add(GF.formatNumber(Convert.ToInt32(delivery_club_price_list[item_id.SelectedIndex])));
                    param.Add(Properties.Settings.Default.money_unit);
                    param.Add(((ComboItem)item_id.SelectedItem).Key.ToString());
                    param.Add(getRand());
                    param.Add("0");
                    param.Add(Convert.ToInt32(delivery_club_price_list[item_id.SelectedIndex]).ToString());

                    pushRow("DELIVERY CLUB", param);
                    updateTotal();
                }
            }

            if (((ComboItem)item_type.SelectedItem).Key == 7) // MANGO
            {
                if (((ComboItem)item_id.SelectedItem).Key != -99 && ((ComboItem)item_id.SelectedItem).Key != 0)
                {
                    using (item_amount itemAmount = new item_amount())
                    {
                        itemAmount.Owner = this;
                        itemAmount.Text = "AMOUNT of " + item_id.Text;
                        itemAmount.ShowDialog();
                    }

                    if (item_amount <= 0) return;

                    List<string> param = new List<string>();
                    param.Add("MANGO");
                    param.Add(item_id.Text + " [" + item_amount.ToString() + "]");
                    param.Add(GF.formatNumber(Convert.ToInt32(mango_price_list[item_id.SelectedIndex])));
                    param.Add(Properties.Settings.Default.money_unit);
                    param.Add(((ComboItem)item_id.SelectedItem).Key.ToString());
                    param.Add(getRand());
                    param.Add("0");
                    param.Add(Convert.ToInt32(mango_price_list[item_id.SelectedIndex]).ToString());

                    pushRow("MANGO", param);
                    updateTotal();
                }
            }*/
        }

        public void NewBill()
        {
            bill_no.Text = "";
            invoice_datetime = "";
            isPaid = false;
            
            customer_id.SetText(-1, "");
            item_type.SelectedIndex = 0;
            DGV.Rows.Clear();
            initDGV();
            GF.disableButton(invoice_btn);
            GF.disableButton(pay_by_cash_btn);
            GF.disableButton(pay_by_credit_card_btn);
            GF.disableButton(personal_credit_btn);
            
            done_btn.Visible = false;
            toggleAllDiscount("DISABLE");
            voided.Visible = false;
            void_btn.Visible = false;
            manage_btn.Text = "ADD ITEM";

            GF.enableButton(add_customer_btn);
            GF.enableButton(manage_btn);
            GF.enableButton(new_bill_btn);

            done_btn.Visible = false;

            customer_id.Enabled = true;
            item_type.Enabled = true;
            item_id.Enabled = true;

            total.Text = "0.00";
            discount.Text = "0.00";
            paid.Text = "0.00";
            grand_total.Text = "0.00";
        }

        private void attachment_btn_Click(object sender, EventArgs e)
        {
            GF.loadAttachmentPage(this, this.billID, ((!gen) ? true : false));
        }

        private void void_btn_Click(object sender, EventArgs e)
        {
            using (void_reason voidPage = new void_reason())
            {
                voidPage.Owner = this;
                voidPage.ShowDialog();
                if (void_reason.Trim() != "")
                {
                    DB.beginTrans();
                    string queryString = "UPDATE BILL SET IS_VOID = 1, VOID_BY = " + GF.emp_id.ToString() + ", VOID_REASON = '" + void_reason + "' WHERE BILL_ID = " + billID.ToString();
                    if (!DB.set(queryString, "VOID BILL[" + billID.ToString() + "]"))
                    {
                        MessageBox.Show("CANNOT VOID THIS BILL !!", "ERROR");
                        GF.closeLoading();
                        return;
                    }
                    else
                    {
                        if (!DB.executeSP("VOID_BILL", "BILL_ID", billID.ToString()))
                        {
                            MessageBox.Show("CANNOT VOID THIS BILL_ !!", "ERROR");
                            GF.closeLoading();
                            return;
                        }

                    }
                    DB.close();

                    this.isVoid = true;
                    void_btn.Visible = false;
                    done_btn.Visible = false;
                    GF.disableButton(invoice_btn);
                    GF.disableButton(pay_by_cash_btn);
                    GF.disableButton(pay_by_credit_card_btn);
                    GF.disableButton(personal_credit_btn);
                    toggleAllDiscount("DISABLE");
                    voided.Visible = true;
                    GF.closeLoading();

                }
            }
        }

        private void cashier_FormClosing(object sender, FormClosingEventArgs e)
        {
            clearTmpBill();
            DGV.Dispose();
        }

        void clearTmpBill()
        {
            if (gen)
            {
                bool success = true;
                using (DataTable DT = DB.getS("SELECT * FROM ATTACHMENT WHERE OWNER_FORM LIKE 'cashier' AND OWNER_ID = " + billID.ToString(), null, "GET ATTACHMENTS FROM CASHIER", false))
                {
                    foreach (DataRow DR in DT.Rows)
                    {
                        if (!FTP.delete(DR["FILE_NAME"].ToString(), "ATTACHMENT"))
                        {
                            success = false;
                            MessageBox.Show("ERROR DELETE FILE !!", "ERROR");
                            break;
                        }
                    }
                    if (!success) return;

                    DB.beginTrans();
                    String queryString = "DELETE FROM BILL WHERE INVOICE_DATETIME IS NULL AND IS_PAID = 0 AND BILL_ID = " + billID.ToString();
                    if (!DB.set(queryString, "DELETE TEMP BILL FROM BILL_ID[" + billID.ToString() + "]"))
                    {
                        MessageBox.Show("COULD NOT CLEAR TEMP BILL !!", "ERROR");
                        return;
                    }
                }
                DB.close();
            }
        }

        private void item_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            GF.closeLoading();
            item_id.Items.Clear();
            item_id.Enabled = false;

            if (((ComboItem)item_type.SelectedItem).Key == 1) // MEMBERCARD
            {
                GF.showLoading(this);
                string queryString = "SELECT * FROM MEMBERCARD_TYPE WHERE IS_USE = 1 AND (CONVERT(DATE, GETDATE()) <= EXPIRY_DATE OR EXPIRY_DATE IS NULL)";
                using (DataTable DT = DB.getS(queryString, null, "GET MEMBERCARDS", false))
                {
                    membercard_price_list = new List<string>();
                    foreach (DataRow row in DT.Rows)
                    {
                        membercard_price_list.Add(row["PRICE"].ToString());
                        item_id.Items.Add(new ComboItem(Convert.ToInt32(row["MEMBERCARD_TYPE_ID"].ToString()), row["MEMBERCARD_TYPE_NAME"].ToString()));
                    }
                }
                GF.closeLoading();
            }

            if (((ComboItem)item_type.SelectedItem).Key == 2 || ((ComboItem)item_type.SelectedItem).Key == 6) // GIFT CERTIFICATE + WEBSITE GIFT CERT.
            {
                item_id.Items.Add(new ComboItem(0, "SPA PROGRAM"));
                item_id.Items.Add(new ComboItem(1, "MONEY"));
            }
            if (((ComboItem)item_type.SelectedItem).Key == 3) // COUPON
            {
                item_id.Items.Add(new ComboItem(0, "1 COUPON"));
                item_id.Items.Add(new ComboItem(1, "COUPON SET"));
            }

            if (((ComboItem)item_type.SelectedItem).Key == 8) // RESTAURANT
            {
                item_id.Items.Clear();
                item_id.Items.Add(new ComboItem(-99, "=== BARCODE ==="));
                item_id.Items.Add(new ComboItem(0, "MISC."));
                String queryString = @"
                SELECT
                    B.ITEM_CODE,
                    B.ITEM_NAME,
                    A.PRICE,
                    A.APPLY_DISCOUNT,
                    B.ITEM_ID,
                    C.ITEM_TYPE_NAME
                FROM ITEM_PRICE A
                INNER JOIN ITEM B ON A.ITEM_ID = B.ITEM_ID
                INNER JOIN ITEM_TYPE C ON B.ITEM_TYPE_ID = C.ITEM_TYPE_ID
                WHERE A.IS_USE = 1 AND B.IS_USE = 1 AND C.IS_USE = 1
                AND C.ITEM_TYPE_ID IN (1, 10)
                ORDER BY C.ITEM_TYPE_NAME, B.ITEM_CODE";

                using (DataTable DT = DB.getS(queryString, null, "GET RESTAURANT ITEMS", false))
                {
                    String item_type_name = "";
                    item_list = new List<DataRow>();
                    foreach (DataRow row in DT.Rows)
                    {
                        if (row["ITEM_TYPE_NAME"].ToString().Trim() != item_type_name)
                        {
                            item_id.Items.Add(new ComboItem(-1, "=== " + row["ITEM_TYPE_NAME"].ToString() + " ==="));
                            item_type_name = row["ITEM_TYPE_NAME"].ToString().Trim();
                        }

                        //Console.WriteLine("#" + row["ITEM_ID"].ToString() + " = " + row["ITEM_CODE"].ToString() + ". " + row["ITEM_NAME"].ToString());
                        item_id.Items.Add(new ComboItem(Convert.ToInt32(row["ITEM_ID"].ToString()), row["ITEM_CODE"].ToString() + ". " + row["ITEM_NAME"].ToString()));
                        item_list.Add(row);
                    }
                }

            }

            if (((ComboItem)item_type.SelectedItem).Key == 5) // DELIVERY CLUB
            {
                item_id.Items.Add(new ComboItem(-99, "=== BARCODE ==="));
                item_id.Items.Add(new ComboItem(0, "MISC."));
                string queryString = @"SELECT
                    B.ITEM_CODE,
                    B.ITEM_NAME,
                    A.PRICE,
                    A.APPLY_DISCOUNT,
                    B.ITEM_ID,
                    C.ITEM_TYPE_NAME
                FROM ITEM_PRICE A
                INNER JOIN ITEM B ON A.ITEM_ID = B.ITEM_ID
                INNER JOIN ITEM_TYPE C ON B.ITEM_TYPE_ID = C.ITEM_TYPE_ID
                WHERE A.IS_USE = 1 AND B.IS_USE = 1 AND C.IS_USE = 1
                AND C.ITEM_TYPE_ID = 13
                ORDER BY C.ITEM_TYPE_NAME, B.ITEM_CODE";

                item_list = new List<DataRow>();
                using (DataTable DT = DB.getS(queryString, null, "GET DELIVERY CLUB", false))
                {
                    delivery_club_price_list = new List<string>();
                    foreach (DataRow row in DT.Rows)
                    {
                        delivery_club_price_list.Add(row["PRICE"].ToString());
                        item_id.Items.Add(new ComboItem(Convert.ToInt32(row["ITEM_ID"].ToString()), row["ITEM_CODE"].ToString() + ". " + row["ITEM_NAME"].ToString()));
                        item_list.Add(row);
                    }
                }
            }

            if (((ComboItem)item_type.SelectedItem).Key == 7) // MANGO
            {
                item_id.Items.Add(new ComboItem(-99, "=== BARCODE ==="));
                item_id.Items.Add(new ComboItem(0, "MISC."));
                string queryString = @"SELECT
                    B.ITEM_CODE,
                    B.ITEM_NAME,
                    A.PRICE,
                    A.APPLY_DISCOUNT,
                    B.ITEM_ID,
                    C.ITEM_TYPE_NAME
                FROM ITEM_PRICE A
                INNER JOIN ITEM B ON A.ITEM_ID = B.ITEM_ID
                INNER JOIN ITEM_TYPE C ON B.ITEM_TYPE_ID = C.ITEM_TYPE_ID
                WHERE A.IS_USE = 1 AND B.IS_USE = 1 AND C.IS_USE = 1
                AND C.ITEM_TYPE_ID = 2
                ORDER BY C.ITEM_TYPE_NAME, B.ITEM_CODE";

                item_list = new List<DataRow>();
                using (DataTable DT = DB.getS(queryString, null, "GET DELIVERY CLUB", false))
                {
                    mango_price_list = new List<string>();
                    foreach (DataRow row in DT.Rows)
                    {
                        mango_price_list.Add(row["PRICE"].ToString());
                        item_id.Items.Add(new ComboItem(Convert.ToInt32(row["ITEM_ID"].ToString()), row["ITEM_CODE"].ToString() + ". " + row["ITEM_NAME"].ToString()));
                        item_list.Add(row);
                    }
                }
            }

            if (((ComboItem)item_type.SelectedItem).Key == 0) // PRODUCT & OTHER
            {
                item_id.Items.Clear();
                item_id.Items.Add(new ComboItem(-99, "=== BARCODE ==="));
                item_id.Items.Add(new ComboItem(0, "MISC."));
                String queryString = @"
                SELECT
                    B.ITEM_CODE,
                    B.ITEM_NAME,
                    A.PRICE,
                    A.APPLY_DISCOUNT,
                    B.ITEM_ID,
                    C.ITEM_TYPE_NAME
                FROM ITEM_PRICE A
                INNER JOIN ITEM B ON A.ITEM_ID = B.ITEM_ID
                INNER JOIN ITEM_TYPE C ON B.ITEM_TYPE_ID = C.ITEM_TYPE_ID
                WHERE A.IS_USE = 1 AND B.IS_USE = 1 AND C.IS_USE = 1
                AND C.ITEM_TYPE_ID IN (3,4,5,6,7,8,9,12)
                ORDER BY C.ITEM_TYPE_NAME, B.ITEM_CODE";

                using (DataTable DT = DB.getS(queryString, null, "GET PRODUCT AND OTHER ITEMS", false))
                {
                    String item_type_name = "";
                    item_list = new List<DataRow>();
                    foreach (DataRow row in DT.Rows)
                    {
                        if (row["ITEM_TYPE_NAME"].ToString().Trim() != item_type_name)
                        {
                            item_id.Items.Add(new ComboItem(-1, "=== " + row["ITEM_TYPE_NAME"].ToString() + " ==="));
                            item_type_name = row["ITEM_TYPE_NAME"].ToString().Trim();
                        }

                        //Console.WriteLine("#" + row["ITEM_ID"].ToString() + " = " + row["ITEM_CODE"].ToString() + ". " + row["ITEM_NAME"].ToString());
                        item_id.Items.Add(new ComboItem(Convert.ToInt32(row["ITEM_ID"].ToString()), row["ITEM_CODE"].ToString() + ". " + row["ITEM_NAME"].ToString()));
                        item_list.Add(row);
                    }
                }

            }

            item_id.SelectedIndex = 0;
            item_id.Enabled = true;
            GF.resizeComboBox(item_id);
        }

        private void add_customer_btn_Click(object sender, EventArgs e)
        {
            using (CUSTOMER.customer_manage add_customer = new CUSTOMER.customer_manage())
            {
                add_customer.Owner = this;
                add_customer.ShowDialog();
            };
        }

        private void invoice_btn_Click(object sender, EventArgs e)
        {
            if(!isPaid) updateDB();
            String queryString = "UPDATE BILL SET INVOICE_DATETIME = CURRENT_TIMESTAMP WHERE BILL_ID = " + billID.ToString();
            if (!DB.set(queryString, "UPDATE BILL[" + billID.ToString() + "] INVOICE_DATETIME = CURRENT_TIMESTAMP"))
            {
                MessageBox.Show("ERROR UPDATE BILL !!", "ERROR");
                GF.closeLoading();
                return;
            }
            invoice_datetime = GF.NOW();
            if (bill_no.Text.Trim() != "")
            {
                PRINT.initPrint(false, "INVOICE", "", this, false, false, false, bill_no.Text.Trim());
                if (invoice_datetime != "" && !isPaid && !isVoid)
                {
                    GF.enableButton(pay_by_cash_btn);
                    GF.enableButton(pay_by_credit_card_btn);
                    GF.enableButton(personal_credit_btn);
                }
                else
                {
                    GF.disableButton(pay_by_cash_btn);
                    GF.disableButton(pay_by_credit_card_btn);
                    GF.disableButton(personal_credit_btn);
                }
                toggleAllDiscount("ENABLE");
            }
        }

        public void toggleAllDiscount(String MODE)
        {
            if (MODE == "DISABLE")
            {
                GF.disableButton(gift_cer_btn);
                GF.disableButton(gift_voucher_btn);
                GF.disableButton(coupon_btn);
                GF.disableButton(vip_card_btn);
                GF.disableButton(member_card_btn);
                GF.disableButton(cross_promotion_btn);
                GF.disableButton(other_discount_btn);
                GF.disableButton(money_coupon_btn);
            }
            if (MODE == "ENABLE")
            {
                GF.enableButton(gift_cer_btn);
                GF.enableButton(gift_voucher_btn);
                GF.enableButton(coupon_btn);
                GF.enableButton(vip_card_btn);
                GF.enableButton(member_card_btn);
                GF.enableButton(cross_promotion_btn);
                GF.enableButton(other_discount_btn);
                GF.enableButton(money_coupon_btn);
            }
        }

        private void showPayPage(int paymentType)
        {
            // SHOW RECEIVE MONEY FORM
            using (payment payment_page = new payment())
            {
                payment_page.Owner = this;
                payment_page.billID = billID;
                payment_page.paymentType = paymentType;
                payment_page.grandTotalAmount = Convert.ToInt32(GF.removeThousandAndDecimal(grand_total.Text.Trim()));
                payment_page.ShowDialog();
                payment_page.BringToFront();
            }
        }

        private void pay_by_cash_btn_Click(object sender, EventArgs e)
        {
            showPayPage(0);
        }

        private void pay_by_credit_card_btn_Click(object sender, EventArgs e)
        {
            showPayPage(1);
        }
        private void pay_by_personal_credit_btn_Click(object sender, EventArgs e)
        {
            showPayPage(-1);
        }

        private void printCards()
        {
            foreach (DataGridViewRow row in btn_dgv.DGV.Rows)
            {
                if (row.Cells["ITEM_TYPE"].Value != null)
                {
                    if (row.Cells["ITEM_TYPE"].Value.ToString() == "MEMBERCARD" || (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("GIFT CERTIFICATE") != -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("WEBSITE") == -1))
                    {
                        GF.selected_id = Convert.ToInt32(row.Cells["SOURCE_ID"].Value.ToString());

                        using (card_print printPage = new card_print())
                        {
                            printPage.Owner = this;
                            printPage.Text = row.Cells["DETAIL"].Value.ToString();

                            if (row.Cells["ITEM_TYPE"].Value.ToString() == "MEMBERCARD")
                            {
                                //GF.disableButton(printPage.attach_paper_btn);
                                if (row.Cells["DETAIL"].Value.ToString().IndexOf("LIMITED EDITION") == -1) printPage.card_type = 0; // MEMBERCARD
                                else printPage.card_type = 1; // MEMBERCARD LIMITED EDITION

                                membercardID = Convert.ToInt32(row.Cells["SOURCE_ID"].Value.ToString());
                                if (row.Cells["CARD_NO"].Value.ToString() != null && row.Cells["CARD_NO"].Value.ToString() != "") printPage.card_no = row.Cells["CARD_NO"].Value.ToString();
                                printPage.ShowDialog();
                            }

                            if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("GIFT CERTIFICATE") != -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("WEBSITE") == -1) // GIFT_CERTIFICATE
                            {
                                printPage.card_type = 2;
                                if (row.Cells["DETAIL"].Value.ToString().IndexOf("CARD NO : ") == -1)
                                {
                                    if (row.Cells["CARD_NO"].Value.ToString() != null && row.Cells["CARD_NO"].Value.ToString() != "") printPage.card_no = row.Cells["CARD_NO"].Value.ToString();
                                    printPage.ShowDialog();
                                }
                            }
                            
                            // PRINT COMPLIMENTARY !!

                            if (row.Cells["ITEM_TYPE"].Value.ToString() == "MEMBERCARD")
                            {
                                string queryString = @"
                                SELECT A.CARD_NO, B.COMPLEMENTARY_SPA_PROGRAM_ID, B.COMPLEMENTARY_DISCOUNT_AMOUNT, B.COMPLEMENTARY_DISCOUNT_UNIT 
                                FROM MEMBERCARD A 
                                INNER JOIN MEMBERCARD_TYPE B ON A.MEMBERCARD_TYPE_ID = B.MEMBERCARD_TYPE_ID
                                WHERE A.MEMBERCARD_ID = " + membercardID;

                                using (DataTable tmpDT = DB.getS(queryString, null, "GET COMPLEMENTARTY OF MEMBERCARD[" + membercardID + "]", false))
                                {
                                    foreach (DataRow tmpDR in tmpDT.Rows)
                                    {
                                        String[] spa_program_id_arr = tmpDR["COMPLEMENTARY_SPA_PROGRAM_ID"].ToString().Split(',');
                                        String[] spa_program_disc_amt_arr = tmpDR["COMPLEMENTARY_DISCOUNT_AMOUNT"].ToString().Split(',');
                                        String[] spa_program_disc_unit_arr = tmpDR["COMPLEMENTARY_DISCOUNT_UNIT"].ToString().Split(',');
                                        String member_card_no = tmpDR["CARD_NO"].ToString();
                                        int index = 0;
                                        foreach (String spa_program_id in spa_program_id_arr)
                                        {
                                            using (register_coupon registerCoupon = new register_coupon())
                                            {
                                                registerCoupon.Owner = this;
                                                registerCoupon.membercard_id = membercardID.ToString();
                                                registerCoupon.selected_spa_program_id = spa_program_id;
                                                registerCoupon.selected_discount_amount = spa_program_disc_amt_arr[index];
                                                registerCoupon.selected_discount_unit = spa_program_disc_unit_arr[index];
                                                registerCoupon.event_text = "MEMBER CARD : #" + member_card_no;
                                                registerCoupon.payment_type = "3";
                                                registerCoupon.ShowDialog();
                                            }
                                            index++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void done_btn_Click(object sender, EventArgs e)
        {
            updateDB();
            String queryString = "UPDATE BILL SET IS_PAID = 1 WHERE BILL_ID = " + billID.ToString();
            if (!DB.set(queryString, "UPDATE BILL[" + billID.ToString() + "] IS_PAID = 1"))
            {
                MessageBox.Show("ERROR UPDATE BILL !!", "ERROR");
                GF.closeLoading();
                return;
            }
            if (bill_no.Text.Trim() != "")
            {
                bool foundCardUsage = false;
                foreach (DataGridViewRow row in DGV.Rows)
                {
                    if (row.Cells["ITEM_TYPE"].Value != null)
                    {
                        if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PAID") != -1)
                        {
                            if (row.Cells["DETAIL"].Value.ToString().IndexOf("MEMBER") != -1)
                            {
                                queryString = "UPDATE MEMBERCARD SET BALANCE = BALANCE - " + GF.removeThousandAndDecimal(row.Cells["AMOUNT"].Value.ToString()) + " WHERE MEMBERCARD_ID = " + row.Cells["USE_CARD_ID"].Value.ToString();
                                if (!DB.set(queryString, "UPDATE BALANCE OF MEMBERCARD[" + row.Cells["USE_CARD_ID"].Value.ToString() + "]"))
                                {
                                    MessageBox.Show("ERROR UPDATE BALANCE OF MEMBERCARD !!", "ERROR");
                                    GF.closeLoading();
                                    return;
                                }
                                if (!foundCardUsage)
                                {
                                    foundCardUsage = true;
                                    break;
                                }                                
                            }
                            if (row.Cells["DETAIL"].Value.ToString().IndexOf("MONEY GIFT CERTIFICATE") != -1)
                            {
                                queryString = "UPDATE GIFT_CERTIFICATE SET BALANCE = BALANCE - " + GF.removeThousandAndDecimal(row.Cells["AMOUNT"].Value.ToString()) + " WHERE GIFT_CERTIFICATE_ID = " + row.Cells["USE_CARD_ID"].Value.ToString();
                                if (!DB.set(queryString, "UPDATE BALANCE OF GIFT_CERTIFICATE[" + row.Cells["USE_CARD_ID"].Value.ToString() + "]"))
                                {
                                    MessageBox.Show("ERROR UPDATE BALANCE OF GIFT CERTIFICATE !!", "ERROR");
                                    GF.closeLoading();
                                    return;
                                }
                                if (!foundCardUsage)
                                {
                                    foundCardUsage = true;
                                    break;
                                }
                            }
                            if (row.Cells["DETAIL"].Value.ToString().IndexOf("COUPON") != -1 && row.Cells["AMOUNT_LEFT"].Value.ToString() != "")
                            {
                                queryString = "UPDATE COUPON SET BALANCE = BALANCE - " + GF.removeThousandAndDecimal(row.Cells["AMOUNT"].Value.ToString()) + " WHERE COUPON_ID = " + row.Cells["USE_CARD_ID"].Value.ToString();
                                if (!DB.set(queryString, "UPDATE BALANCE OF MONEY_COUPON[" + row.Cells["USE_CARD_ID"].Value.ToString() + "]"))
                                {
                                    MessageBox.Show("ERROR UPDATE BALANCE OF MONEY COUPON !!", "ERROR");
                                    GF.closeLoading();
                                    return;
                                }
                                if (!foundCardUsage)
                                {
                                    foundCardUsage = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                if (foundCardUsage)
                {
                    PRINT.initPrint(false, "CARD_USAGE", "", this, false, false, false, bill_no.Text.Trim());
                }
            }
            DB.close();
            toggleAllDiscount("DISABLE");
            //GF.disableButton(invoice_btn);
            GF.disableButton(pay_by_cash_btn);
            GF.disableButton(pay_by_credit_card_btn);
            GF.disableButton(personal_credit_btn);
            GF.disableButton(manage_btn);
            GF.disableButton(other_discount_btn);
            GF.disableButton(add_customer_btn);
            GF.enableButton(new_bill_btn);
            if (GF.can_approve)
            {
                GF.enableButton(void_btn);
                void_btn.Visible = true;
            }
            done_btn.Visible = false;
            printCards();
        }

        private void member_card_btn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                if (row.Cells["ITEM_TYPE"].Value != null)
                {
                    if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("VIP") != -1)
                    {
                        MessageBox.Show("MEMBER CARD CANNOT BE USED WITH VIP CARD !!", "ERROR");
                        return;
                    }
                }
            }
            using (use_cards useCardPage = new use_cards())
            {
                useCardPage.payment_type = 0;
                useCardPage.Owner = this;
                useCardPage.ShowDialog();
            }
        }

        private void gift_cer_btn_Click(object sender, EventArgs e)
        {
            using (use_cards useCardPage = new use_cards())
            {
                useCardPage.payment_type = 1;
                useCardPage.Owner = this;
                useCardPage.ShowDialog();
            }
        }

        private void gift_voucher_btn_Click(object sender, EventArgs e)
        {
            using (use_cards useCardPage = new use_cards())
            {
                useCardPage.payment_type = 2;
                useCardPage.Owner = this;
                useCardPage.ShowDialog();
            }
        }

        private void coupon_btn_Click(object sender, EventArgs e)
        {
            using (use_cards useCardPage = new use_cards())
            {
                useCardPage.payment_type = 3;
                useCardPage.Owner = this;
                useCardPage.ShowDialog();
            }
        }

        private void cross_promotion_btn_Click(object sender, EventArgs e)
        {
            using (use_cards useCardPage = new use_cards())
            {
                useCardPage.payment_type = 5;
                useCardPage.Owner = this;
                useCardPage.ShowDialog();
            }
        }

        private void vip_card_btn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                if (row.Cells["ITEM_TYPE"].Value != null)
                {
                    if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("MEMBER") != -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") != -1)
                    {
                        MessageBox.Show("VIP CARD CANNOT BE USED WITH MEMBER CARD !!", "ERROR");
                        return;
                    }
                }
            }

            using (use_cards useCardPage = new use_cards())
            {
                useCardPage.payment_type = 4;
                useCardPage.Owner = this;
                useCardPage.ShowDialog();
            }
        }

        public void pushRow(String TYPE, List<String> param)
        {
            int rowIndex = -1;
            
            switch (TYPE)
            {
                case "ITEM":
                case "MASSAGE":
                case "MEMBERCARD":
                case "GIFT_CERTIFICATE":
                case "DELIVERY CLUB":
                case "MANGO":
                    foreach (DataGridViewRow row in DGV.Rows)
                    {
                        if (row.Cells["ITEM_TYPE"].Value != null)
                        {
                            if (row.Cells["ITEM_TYPE"].Value.ToString() == "MASSAGE" || row.Cells["ITEM_TYPE"].Value.ToString() == "MEMBERCARD" || row.Cells["ITEM_TYPE"].Value.ToString() == "SPA MENU GIFT CERTIFICATE" || row.Cells["ITEM_TYPE"].Value.ToString() == "MONEY GIFT CERTIFICATE" || row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("ITEM") != -1 || row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DELIVERY CLUB") != -1 || row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("MANGO") != -1) rowIndex = row.Index;
                        }
                    }

                    if (rowIndex != -1)
                    {
                        if (rowIndex == DGV.Rows.Count - 1) addRow(param);
                        else insertRow(rowIndex + 1, param);
                        return;
                    }

                    if (rowIndex == -1)
                    {
                        foreach (DataGridViewRow row in DGV.Rows)
                        {
                            if (row.Cells["ITEM_TYPE"].Value != null)
                            {
                                if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PAID") != -1)
                                {
                                    rowIndex = row.Index;
                                    return;
                                }
                            }
                        }
                    }

                    if (rowIndex == -1)
                    {
                        foreach (DataGridViewRow row in DGV.Rows)
                        {
                            if (row.Cells["ITEM_TYPE"].Value != null)
                            {
                                if (row.Cells["ITEM_TYPE"].Value.ToString() == "DISCOUNT")
                                {
                                    rowIndex = row.Index;
                                    break;
                                }
                            }
                        }
                    }

                    if (rowIndex == -1)
                    {
                        foreach (DataGridViewRow row in DGV.Rows)
                        {
                            if (row.Cells["ITEM_TYPE"].Value != null)
                            {
                                if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PROMOTION") != -1)
                                {
                                    rowIndex = row.Index;
                                    return;
                                }
                            }
                        }
                    }

                    if (rowIndex != -1)
                    {
                        insertRow(rowIndex + 1, param);
                        insertRow(rowIndex + 2);
                    }
                    else
                        addRow(param);
                    break;

                case "DISCOUNT":
                    // ========================= DISCOUNT ITEM [RUB] :: INCLUDE [OTHER] ===========================
                    if (param[1].IndexOf("ALL") == -1 && param[1].IndexOf("TOTAL") == -1 && param[1].IndexOf("Rub") != -1)
                    {
                        foreach (DataGridViewRow row in DGV.Rows) // SEARCH FOR DISCOUNT ITEM [RUB] :: INCLUDE [OTHER] -> INSERT LAST INDEX
                        {
                            if (row.Cells["ITEM_TYPE"].Value != null)
                            {
                                if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") != -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PROMOTION") == -1 && row.Cells["DETAIL"].Value.ToString().IndexOf("ALL") == -1 && row.Cells["DETAIL"].Value.ToString().IndexOf("TOTAL") == -1 && row.Cells["DETAIL"].Value.ToString().IndexOf("Rub") != -1)
                                    rowIndex = row.Index;
                            }
                        }
                        
                        if (rowIndex != -1)
                        {
                            if (rowIndex == DGV.Rows.Count - 1) addRow(param);
                            else insertRow(rowIndex + 1, param);
                            return;
                        }

                        foreach (DataGridViewRow row in DGV.Rows) // SEARCH FOR DISCOUNT ITEM [%] :: INCLUDE [OTHER] -> INSERT 1ST INDEX
                        {
                            if (row.Cells["ITEM_TYPE"].Value != null)
                            {
                                if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") != -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PROMOTION") == -1 && row.Cells["DETAIL"].Value.ToString().IndexOf("ALL") == -1 && row.Cells["DETAIL"].Value.ToString().IndexOf("TOTAL") == -1 && row.Cells["DETAIL"].Value.ToString().IndexOf("%") != -1)
                                {
                                    rowIndex = row.Index;
                                    break;
                                }
                            }
                        }

                        if (rowIndex != -1)
                        {
                            insertRow(rowIndex, param);
                            return;
                        }

                        foreach (DataGridViewRow row in DGV.Rows) // SEARCH FOR DISCOUNT ALL :: INCLUDE [OTHER] -> INSERT 1ST INDEX
                        {
                            if (row.Cells["ITEM_TYPE"].Value != null)
                            {
                                if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") != -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PROMOTION") == -1 && (row.Cells["DETAIL"].Value.ToString().IndexOf("ALL") != -1 || row.Cells["DETAIL"].Value.ToString().IndexOf("TOTAL") != -1))
                                {
                                    rowIndex = row.Index;
                                    break;
                                }
                            }
                        }
                        
                        if (rowIndex != -1)
                        {
                            insertRow(rowIndex, param);
                            return;
                        }
                    }

                    // ========================= DISCOUNT ITEM [%] :: INCLUDE [OTHER] ===========================
                    if (param[1].IndexOf("ALL") == -1 && param[1].IndexOf("TOTAL") == -1 && param[1].IndexOf("%") != -1)
                    {
                        foreach (DataGridViewRow row in DGV.Rows) // SEARCH FOR DISCOUNT ITEM [%] :: INCLUDE [OTHER] -> INSERT LAST INDEX
                        {
                            if (row.Cells["ITEM_TYPE"].Value != null)
                            {
                                if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") != -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PROMOTION") == -1 && row.Cells["DETAIL"].Value.ToString().IndexOf("ALL") == -1 && row.Cells["DETAIL"].Value.ToString().IndexOf("TOTAL") == -1 && row.Cells["DETAIL"].Value.ToString().IndexOf("%") != -1)
                                    rowIndex = row.Index;
                            }
                        }

                        if (rowIndex != -1)
                        {
                            if (rowIndex == DGV.Rows.Count - 1) addRow(param);
                            else insertRow(rowIndex + 1, param);
                            return;
                        }

                        foreach (DataGridViewRow row in DGV.Rows) // SEARCH FOR DISCOUNT ITEM [Rub] :: INCLUDE [OTHER] -> INSERT LAST INDEX
                        {
                            if (row.Cells["ITEM_TYPE"].Value != null)
                            {
                                if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") != -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PROMOTION") == -1 && row.Cells["DETAIL"].Value.ToString().IndexOf("ALL") == -1 && row.Cells["DETAIL"].Value.ToString().IndexOf("TOTAL") == -1 && row.Cells["DETAIL"].Value.ToString().IndexOf("Rub") != -1)
                                    rowIndex = row.Index;
                            }
                        }

                        if (rowIndex != -1)
                        {
                            if (rowIndex == DGV.Rows.Count - 1) addRow(param);
                            else insertRow(rowIndex + 1, param);
                            return;
                        }

                        foreach (DataGridViewRow row in DGV.Rows) // SEARCH FOR DISCOUNT ALL :: INCLUDE [OTHER] -> INSERT 1ST INDEX
                        {
                            if (row.Cells["ITEM_TYPE"].Value != null)
                            {
                                if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") != -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PROMOTION") == -1 && (row.Cells["DETAIL"].Value.ToString().IndexOf("ALL") != -1 || row.Cells["DETAIL"].Value.ToString().IndexOf("TOTAL") != -1))
                                {
                                    rowIndex = row.Index;
                                    break;
                                }
                            }
                        }

                        if (rowIndex != -1)
                        {
                            insertRow(rowIndex, param);
                            return;
                        }
                    }

                    // ========================= DISCOUNT ALL [RUB] :: NOT OTHER !! ===========================
                    if ((param[1].IndexOf("ALL") != -1 || param[1].IndexOf("TOTAL") != -1) && param[0].IndexOf("OTHER") == -1)
                    {
                        foreach (DataGridViewRow row in DGV.Rows) // SEARCH FOR DISCOUNT ALL [Rub] :: NOT OTHER -> INSERT LAST INDEX
                        {
                            if (row.Cells["ITEM_TYPE"].Value != null)
                            {
                                if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") != -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PROMOTION") == -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("OTHER") == -1 && (row.Cells["DETAIL"].Value.ToString().IndexOf("ALL") != -1 || row.Cells["DETAIL"].Value.ToString().IndexOf("TOTAL") != -1) && row.Cells["DETAIL"].Value.ToString().IndexOf("Rub") != -1)
                                {
                                    rowIndex = row.Index;
                                }
                            }
                        }
                        
                        if (rowIndex != -1)
                        {
                            insertRow(rowIndex + 1, param);
                            return;
                        }

                        foreach (DataGridViewRow row in DGV.Rows) // SEARCH FOR DISCOUNT ALL [%] :: NOT OTHER -> INSERT 1ST INDEX
                        {
                            if (row.Cells["ITEM_TYPE"].Value != null)
                            {
                                if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") != -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PROMOTION") == -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("OTHER") == -1 && (row.Cells["DETAIL"].Value.ToString().IndexOf("ALL") != -1 || row.Cells["DETAIL"].Value.ToString().IndexOf("TOTAL") != -1) && row.Cells["DETAIL"].Value.ToString().IndexOf("%") != -1)
                                {
                                    rowIndex = row.Index;
                                    break;
                                }
                            }
                        }
                        
                        if (rowIndex != -1)
                        {
                            insertRow(rowIndex, param);
                            return;
                        }

                        foreach (DataGridViewRow row in DGV.Rows) // SEARCH FOR [OTHER] DISCOUNT ALL -> INSERT 1ST INDEX
                        {
                            if (row.Cells["ITEM_TYPE"].Value != null)
                            {
                                if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") != -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PROMOTION") == -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("OTHER") != -1 && (row.Cells["DETAIL"].Value.ToString().IndexOf("ALL") != -1 || row.Cells["DETAIL"].Value.ToString().IndexOf("TOTAL") != -1))
                                {
                                    rowIndex = row.Index;
                                    break;
                                }
                            }
                        }
                        
                        if (rowIndex != -1)
                        {
                            insertRow(rowIndex, param);
                            return;
                        }

                        foreach (DataGridViewRow row in DGV.Rows) // SEARCH FOR DISCOUNT ITEM :: INCLUDE [OTHER] -> INSERT LAST INDEX
                        {
                            if (row.Cells["ITEM_TYPE"].Value != null)
                            {
                                if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") != -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PROMOTION") == -1 && row.Cells["DETAIL"].Value.ToString().IndexOf("ALL") == -1 && row.Cells["DETAIL"].Value.ToString().IndexOf("TOTAL") == -1)
                                    rowIndex = row.Index;
                            }
                        }

                        if (rowIndex != -1)
                        {
                            if (rowIndex == DGV.Rows.Count - 1) addRow(param);
                            else insertRow(rowIndex + 1, param);
                            return;
                        }
                    }

                    // ========================= DISCOUNT ALL [%] :: NOT OTHER !! ===========================
                    if ((param[1].IndexOf("ALL") != -1 || param[1].IndexOf("TOTAL") != -1) && param[0].IndexOf("OTHER") == -1)
                    {
                        foreach (DataGridViewRow row in DGV.Rows) // SEARCH FOR DISCOUNT ALL [%] :: NOT OTHER -> INSERT LAST INDEX
                        {
                            if (row.Cells["ITEM_TYPE"].Value != null)
                            {
                                if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") != -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PROMOTION") == -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("OTHER") == -1 && (row.Cells["DETAIL"].Value.ToString().IndexOf("ALL") != -1 || row.Cells["DETAIL"].Value.ToString().IndexOf("TOTAL") != -1) && row.Cells["DETAIL"].Value.ToString().IndexOf("%") != -1)
                                {
                                    rowIndex = row.Index;
                                }
                            }
                        }
                        
                        if (rowIndex != -1)
                        {
                            insertRow(rowIndex + 1, param);
                            return;
                        }

                        foreach (DataGridViewRow row in DGV.Rows) // SEARCH FOR DISCOUNT ALL [Rub] :: NOT OTHER -> INSERT LAST INDEX
                        {
                            if (row.Cells["ITEM_TYPE"].Value != null)
                            {
                                if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") != -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PROMOTION") == -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("OTHER") == -1 && (row.Cells["DETAIL"].Value.ToString().IndexOf("ALL") != -1 || row.Cells["DETAIL"].Value.ToString().IndexOf("TOTAL") != -1) && row.Cells["DETAIL"].Value.ToString().IndexOf("Rub") != -1)
                                {
                                    rowIndex = row.Index;
                                }
                            }
                        }
                        
                        if (rowIndex != -1)
                        {
                            insertRow(rowIndex + 1, param);
                            return;
                        }

                        foreach (DataGridViewRow row in DGV.Rows) // SEARCH FOR [OTHER] DISCOUNT -> INSERT 1ST INDEX
                        {
                            if (row.Cells["ITEM_TYPE"].Value != null)
                            {
                                if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") != -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PROMOTION") == -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("OTHER") != -1 && (row.Cells["DETAIL"].Value.ToString().IndexOf("ALL") != -1 || row.Cells["DETAIL"].Value.ToString().IndexOf("TOTAL") != -1))
                                {
                                    rowIndex = row.Index;
                                    break;
                                }
                            }
                        }
                        
                        if (rowIndex != -1)
                        {
                            insertRow(rowIndex, param);
                            return;
                        }

                        foreach (DataGridViewRow row in DGV.Rows) // SEARCH FOR DISCOUNT ITEM :: INCLUDE [OTHER] -> INSERT LAST INDEX
                        {
                            if (row.Cells["ITEM_TYPE"].Value != null)
                            {
                                if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") != -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PROMOTION") == -1 && row.Cells["DETAIL"].Value.ToString().IndexOf("ALL") == -1 && row.Cells["DETAIL"].Value.ToString().IndexOf("TOTAL") == -1)
                                    rowIndex = row.Index;
                            }
                        }
                        
                        if (rowIndex != -1)
                        {
                            if (rowIndex == DGV.Rows.Count - 1) addRow(param);
                            else insertRow(rowIndex + 1, param);
                            return;
                        }
                    }

                    // ========================= [OTHER] DISCOUNT ALL [RUB] ===========================
                    if (param[1].IndexOf("TOTAL") != -1 && param[0].IndexOf("OTHER") != -1 && param[1].IndexOf("Rub") != -1) // OTHER DISCOUNT ALL
                    {
                        foreach (DataGridViewRow row in DGV.Rows) // SEARCH FOR [OTHER] DISCOUNT ALL [RUB] -> INSERT LAST INDEX
                        {
                            if (row.Cells["ITEM_TYPE"].Value != null)
                            {
                                if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") != -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PROMOTION") == -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("OTHER") != -1 && (row.Cells["DETAIL"].Value.ToString().IndexOf("ALL") != -1 || row.Cells["DETAIL"].Value.ToString().IndexOf("TOTAL") != -1) && row.Cells["DETAIL"].Value.ToString().IndexOf("Rub") != -1)
                                    rowIndex = row.Index;
                            }
                        }

                        if (rowIndex != -1)
                        {
                            if (rowIndex == DGV.Rows.Count - 1) addRow(param);
                            else insertRow(rowIndex + 1, param);
                            return;
                        }

                        foreach (DataGridViewRow row in DGV.Rows) // SEARCH FOR [OTHER] DISCOUNT ALL [%] -> INSERT FIRST INDEX
                        {
                            if (row.Cells["ITEM_TYPE"].Value != null)
                            {
                                if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") != -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PROMOTION") == -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("OTHER") != -1 && (row.Cells["DETAIL"].Value.ToString().IndexOf("ALL") != -1 || row.Cells["DETAIL"].Value.ToString().IndexOf("TOTAL") != -1) && row.Cells["DETAIL"].Value.ToString().IndexOf("%") != -1)
                                {
                                    rowIndex = row.Index;
                                    break;
                                }
                            }
                        }

                        if (rowIndex != -1)
                        {
                            insertRow(rowIndex, param);
                            return;
                        }

                        foreach (DataGridViewRow row in DGV.Rows) // SEARCH FOR ANYOTHER DISCOUNT -> INSERT LAST INDEX
                        {
                            if (row.Cells["ITEM_TYPE"].Value != null)
                            {
                                if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") != -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PROMOTION") == -1)
                                    rowIndex = row.Index;
                            }
                        }

                        if (rowIndex != -1)
                        {
                            if (rowIndex == DGV.Rows.Count - 1) addRow(param);
                            else insertRow(rowIndex + 1, param);
                            return;
                        }
                    }

                    // ========================= [OTHER] DISCOUNT ALL [%] ===========================
                    if (param[1].IndexOf("TOTAL") != -1 && param[0].IndexOf("OTHER") != -1 && param[1].IndexOf("%") != -1) // OTHER DISCOUNT ALL
                    {
                        foreach (DataGridViewRow row in DGV.Rows) // SEARCH FOR [OTHER] DISCOUNT ALL [%] -> INSERT LAST INDEX
                        {
                            if (row.Cells["ITEM_TYPE"].Value != null)
                            {
                                if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") != -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PROMOTION") == -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("OTHER") != -1 && (row.Cells["DETAIL"].Value.ToString().IndexOf("ALL") != -1 || row.Cells["DETAIL"].Value.ToString().IndexOf("TOTAL") != -1) && row.Cells["DETAIL"].Value.ToString().IndexOf("%") != -1)
                                    rowIndex = row.Index;
                            }
                        }

                        if (rowIndex != -1)
                        {
                            if (rowIndex == DGV.Rows.Count - 1) addRow(param);
                            else insertRow(rowIndex + 1, param);
                            return;
                        }

                        foreach (DataGridViewRow row in DGV.Rows) // SEARCH FOR OTHER DISCOUNT ALL [RUB] -> INSERT LAST INDEX
                        {
                            if (row.Cells["ITEM_TYPE"].Value != null)
                            {
                                if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") != -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PROMOTION") == -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("OTHER") != -1 && (row.Cells["DETAIL"].Value.ToString().IndexOf("ALL") != -1 || row.Cells["DETAIL"].Value.ToString().IndexOf("TOTAL") != -1) && row.Cells["DETAIL"].Value.ToString().IndexOf("Rub") != -1)
                                    rowIndex = row.Index;
                            }
                        }

                        if (rowIndex != -1)
                        {
                            if (rowIndex == DGV.Rows.Count - 1) addRow(param);
                            else insertRow(rowIndex + 1, param);
                            return;
                        }

                        foreach (DataGridViewRow row in DGV.Rows) // SEARCH FOR ANYOTHER DISCOUNT -> INSERT LAST INDEX
                        {
                            if (row.Cells["ITEM_TYPE"].Value != null)
                            {
                                if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") != -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PROMOTION") == -1)
                                    rowIndex = row.Index;
                            }
                        }

                        if (rowIndex != -1)
                        {
                            if (rowIndex == DGV.Rows.Count - 1) addRow(param);
                            else insertRow(rowIndex + 1, param);
                            return;
                        }
                    }

                    foreach (DataGridViewRow row in DGV.Rows) // SEARCH FOR PAID -> INSERT 1ST INDEX
                    {
                        if (row.Cells["ITEM_TYPE"].Value != null)
                        {
                            if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PAID") != -1)
                            {
                                rowIndex = row.Index;
                                break;
                            }
                        }
                    }
                    
                    if (rowIndex != -1)
                    {
                        insertRow(rowIndex, param);
                        insertRow(rowIndex + 1);
                        return;
                    }

                    foreach (DataGridViewRow row in DGV.Rows) // SEARCH FOR ITEMS -> INSERT LAST INDEX
                    {
                        if (row.Cells["ITEM_TYPE"].Value != null)
                        {
                            if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("MASSAGE") != -1 || row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("ITEM") != -1 || (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("MEMBER") != -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") == -1) || (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("CERTIFICATE") != -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") == -1))
                                rowIndex = row.Index;
                        }
                    }
                    
                    if (rowIndex != -1)
                    {
                        if (rowIndex == DGV.Rows.Count - 1)
                        {
                            addRow();
                            addRow(param);
                        }
                        else
                        {
                            insertRow(rowIndex);
                            insertRow(rowIndex + 1, param);
                        }
                        return;
                    }
                    break;

                case "PAID":
                    foreach (DataGridViewRow row in DGV.Rows)
                    {
                        if (row.Cells["ITEM_TYPE"].Value != null)
                        {
                            if (row.Cells["ITEM_TYPE"].Value.ToString() == "PAID") rowIndex = row.Index;
                        }
                    }

                    if (rowIndex != -1)
                    {
                        if (rowIndex == DGV.Rows.Count - 1) addRow(param);
                        else insertRow(rowIndex + 1, param);
                        return;
                    }

                    if (rowIndex == -1)
                    {
                        foreach (DataGridViewRow row in DGV.Rows)
                        {
                            if (row.Cells["ITEM_TYPE"].Value != null)
                            {
                                if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") != -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PROMOTION") == -1) 
                                    rowIndex = row.Index;
                            }
                        }
                    }

                    if (rowIndex == -1)
                    {
                        foreach (DataGridViewRow row in DGV.Rows)
                        {
                            if (row.Cells["ITEM_TYPE"].Value != null)
                            {
                                if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PROMOTION") != -1) rowIndex = row.Index;
                            }
                        }
                    }

                    if (rowIndex == -1)
                    {
                        foreach (DataGridViewRow row in DGV.Rows)
                        {
                            if (row.Cells["ITEM_TYPE"].Value != null)
                            {
                                if (row.Cells["ITEM_TYPE"].Value.ToString() == "MASSAGE" || row.Cells["ITEM_TYPE"].Value.ToString() == "MEMBERCARD" || row.Cells["ITEM_TYPE"].Value.ToString() == "SPA MENU GIFT CERTIFICATE" || row.Cells["ITEM_TYPE"].Value.ToString() == "MONEY GIFT CERTIFICATE" || row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("ITEM") != -1) rowIndex = row.Index;
                            }
                        }
                    }

                    if (rowIndex != -1) addRow();
                    addRow(param);
                    break;
            }
        }

        void addRow(List<string> param = null)
        {
            if (param == null) DGV.Rows.Add();
            else
                DGV.Rows.Add(
                    param[0],
                    param[1],
                    param[2],
                    param[3],
                    param[4],
                    param[5],
                    param[6],
                    param[7],
                    (param.Count < 9 ? "" : param[8]),
                    (param.Count < 10 ? "" : param[9])
                );
        }

        void insertRow(int rowIndex, List<string> param = null)
        {
            if (param == null) DGV.Rows.Insert(rowIndex);
            else 
                DGV.Rows.Insert(rowIndex,
                    param[0],
                    param[1],
                    param[2],
                    param[3],
                    param[4],
                    param[5],
                    param[6],
                    param[7],
                    (param.Count < 9 ? "" : param[8]),
                    (param.Count < 10 ? "" : param[9])
                );
        }

        private void other_discount_btn_Click(object sender, EventArgs e)
        {
            using (other_discount otherDiscount = new other_discount())
            {
                otherDiscount.Owner = this;
                otherDiscount.ShowDialog();
            }
        }

        private void new_bill_btn_Click(object sender, EventArgs e)
        {
            NewBill();
            billID = -1;
        }

        private void updateDB()
        {
            GF.showLoading(this);
            DB.beginTrans();

            String queryString = "";

            string customer_code = "";
            string customer_id_txt = "NULL";
            if (customer_id.currentID != -1) // GET CUSTOMER CODE -> USE FOR GENERATE MEMBERCARD NO and GIFT CERTIFICATE NO
            {
                customer_id_txt = customer_id.currentID.ToString();
                queryString = "SELECT CODE FROM CUSTOMER WHERE CUSTOMER_ID = " + customer_id.currentID.ToString();
                using (DataTable DT = DB.getS(queryString, null, "GET CUSTOMER_CODE[" + customer_id.currentID.ToString() + "]", false))
                {
                    customer_code = DT.Rows[0]["CODE"].ToString();
                }
            }

            if (billID == -1) // IF NEW BILL -> GET LAST BILL_NO OF THE DAY
            {
                queryString = "SELECT MAX(BILL_NO) BILL_NO FROM BILL WHERE SUBSTRING(BILL_NO, 0, 9) LIKE '" + (DateTime.Today.Year + 543).ToString("0000") + DateTime.Today.Month.ToString("00") + DateTime.Today.Day.ToString("00") + "'";
                using (DataTable DT = DB.getS(queryString, null, "GET MAX BILL_NO", false))
                {
                    if (DT.Rows[0]["BILL_NO"].ToString() == "")
                    {
                        bill_no.Text = (DateTime.Today.Year + 543).ToString("0000") + DateTime.Today.Month.ToString("00") + DateTime.Today.Day.ToString("00") + "0001";
                    }
                    else
                    {
                        bill_no.Text = DT.Rows[0]["BILL_NO"].ToString().Substring(0, 8) + (Convert.ToInt32(DT.Rows[0]["BILL_NO"].ToString().Substring(8, 4)) + 1).ToString("0000");
                    }
                }

                queryString = "INSERT INTO BILL (BILL_NO, CUSTOMER_ID, BILL_BY, BILL_DATETIME, TOTAL_PRICE, DISCOUNT, GRAND_TOTAL) VALUES (";
                queryString += "'" + bill_no.Text.Trim() + "', ";
                queryString += customer_id_txt + ", ";
                queryString += GF.emp_id.ToString() + ", ";
                queryString += "CURRENT_TIMESTAMP, ";
                queryString += GF.removeThousandAndDecimal(total.Text.Trim()) + ", ";
                queryString += GF.removeThousandAndDecimal(discount.Text.Trim()) + ", ";
                queryString += GF.removeThousandAndDecimal(grand_total.Text.Trim()) + ")";

                billID = DB.insertReturnID(queryString, "CREATE BILL[" + bill_no.Text + "]");
                if (billID == -1)
                {
                    bill_no.Text = "";
                    DB.rollbackTrans();
                    GF.closeLoading();
                    return;
                }
            }
            else
            {
                queryString = "UPDATE BILL SET ";
                queryString += "CUSTOMER_ID = " + customer_id_txt + ", ";
                queryString += "BILL_BY = " + GF.emp_id.ToString() + ", ";
                queryString += "BILL_DATETIME = CURRENT_TIMESTAMP, ";
                queryString += "TOTAL_PRICE = " + GF.removeThousandAndDecimal(total.Text.Trim()) + ", ";
                queryString += "DISCOUNT = " + GF.removeThousandAndDecimal(discount.Text.Trim()) + ", ";
                queryString += "GRAND_TOTAL = " + GF.removeThousandAndDecimal(grand_total.Text.Trim()) + " ";
                queryString += "WHERE BILL_ID = " + billID.ToString();
                if (!DB.set(queryString, "UPDATE PRICES BILL_ID[" + billID.ToString() + "]"))
                {
                    GF.closeLoading();
                    return;
                }

                // CLEAR BILL_DETAIL
                queryString = "DELETE FROM BILL_DETAIL WHERE BILL_ID = " + billID.ToString();
                if (!DB.set(queryString, "CLEAR BILL_DETAIL AND RELATED BILL_DISCOUNT IN BILL_ID[" + billID.ToString() + "]"))
                {
                    GF.closeLoading();
                    return;
                }

                // CLEAR BILL_DISCOUNT
                queryString = "DELETE FROM BILL_DISCOUNT WHERE BILL_ID = " + billID.ToString();
                if (!DB.set(queryString, "CLEAR BILL_DISCOUNT IN BILL_ID[" + billID.ToString() + "]"))
                {
                    GF.closeLoading();
                    return;
                }

                // CLEAR BILL_PAYMENT
                queryString = "DELETE FROM BILL_PAYMENT WHERE BILL_ID = " + billID.ToString();
                if (!DB.set(queryString, "CLEAR BILL_PAYMENT IN BILL_ID[" + billID.ToString() + "]"))
                {
                    GF.closeLoading();
                    return;
                }
            }

            string tmp = "";
            int sort = 0;
            foreach (DataGridViewRow row in DGV.Rows)
            {
                if (row.Cells["ITEM_TYPE"].Value != null)
                {
                    if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") == -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PAID") == -1)
                    {
                        if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("ITEM") == -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("MASSAGE") == -1)
                        {
                            String card_no = (row.Cells["CARD_NO"].Value ?? "").ToString();
                            // INSERT MEMBERCARD INTO DATABASE
                            if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("MEMBERCARD") != -1)
                            {
                                int membercard_id = -1;
                                DataTable DT;
                                if (card_no.Trim() == String.Empty)
                                {
                                    string rand = "";
                                    do // RANDOM NUMBER UNTIL NO MATCH IN DATABASE
                                    {
                                        rand = new Random().Next(1, 10000).ToString("0000");
                                        queryString = "SELECT * FROM MEMBERCARD WHERE CARD_NO LIKE '" + customer_code + rand + "'";
                                        DT = DB.getS(queryString, null, "CHECK IF MEMBERCARD NO[" + customer_code + rand + "] EXISTED", false);
                                    } while (DT.Rows.Count > 0);
                                    DT.Dispose();
                                    card_no = customer_code + rand;
                                }

                                int membercard_type_id = -1;
                                int expire_amount = -1;
                                int expire_unit = -1;
                                int credit = -1;
                                queryString = "SELECT * FROM MEMBERCARD_TYPE WHERE MEMBERCARD_TYPE_NAME = '" + row.Cells["DETAIL"].Value.ToString().Trim() + "'";
                                using (DT = DB.getS(queryString, null, "GET MEMBERCARD_TYPE_ID[" + row.Cells["DETAIL"].Value.ToString() + "]", false))
                                {
                                    // GET MEMBERCARD CONFIG
                                    membercard_type_id = Convert.ToInt32(DT.Rows[0]["MEMBERCARD_TYPE_ID"].ToString());
                                    expire_amount = Convert.ToInt32(DT.Rows[0]["EXPIRE_AMOUNT"].ToString());
                                    expire_unit = Convert.ToInt32(DT.Rows[0]["EXPIRE_UNIT"].ToString());
                                    credit = Convert.ToInt32(DT.Rows[0]["CREDIT"].ToString());
                                }

                                // INSERT MEMBERCARD INTO DATABASE
                                queryString = "INSERT INTO MEMBERCARD (BILL_ID, CUSTOMER_ID, MEMBERCARD_TYPE_ID, CARD_NO, ISSUE_DATE, ISSUE_BY, EXPIRE_DATE, BALANCE, IS_USE, PRICE, IS_PAID) VALUES (";
                                queryString += billID.ToString() + ", ";
                                queryString += customer_id.currentID.ToString() + ", ";
                                queryString += membercard_type_id.ToString() + ", ";
                                queryString += "'" + card_no + "', ";
                                queryString += "CURRENT_TIMESTAMP, ";
                                queryString += GF.emp_id.ToString() + ", ";
                                if (expire_amount == 0 && expire_unit == 0)
                                    queryString += "NULL, ";
                                else
                                    queryString += "DATEADD(" + (expire_unit == 0 ? "MONTH" : "YEAR") + ", " + expire_amount.ToString() + ", CURRENT_TIMESTAMP), ";
                                queryString += credit.ToString() + ", ";
                                queryString += "1, "; // <----- WILL BE UPDATE AFTER CARD IS PRINTED
                                queryString += GF.removeThousandAndDecimal(row.Cells["AMOUNT"].Value.ToString()) + ", ";
                                queryString += "1)"; // <----- WILL BE UPDATE AFTER CARD IS PRINTED

                                // GET ID OF INSERTED MEMBERCARD
                                membercard_id = DB.insertReturnID(queryString, "INSERT MEMBERCARD[" + card_no + "]");
                                if (membercard_id == -1)
                                {
                                    DB.rollbackTrans();
                                    GF.closeLoading();
                                    return;
                                }

                                queryString = "SELECT CARD_NO FROM MEMBERCARD WHERE MEMBERCARD_ID = " + membercard_id.ToString();
                                using (DataTable tmpDT = DB.getS(queryString, null, "GET CARD_NO FROM MEMBERCARD_ID[" + membercard_id.ToString() + "]", false))
                                {
                                    card_no = tmpDT.Rows[0]["CARD_NO"].ToString();
                                }


                                // UPDATE TEMP ID ( MINUS 6-DIGITS RANDOM ) TO INSERTED
                                row.Cells["SOURCE_ID"].Value = membercard_id.ToString();
                                row.Cells["CARD_NO"].Value = card_no;
                            }

                            // INSERT GIFT CERTIFICATE INTO DATABASE
                            if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("GIFT CERTIFICATE") != -1)
                            {
                                string the_code = customer_code;
                                string rand = "";
                                string expiry_date = "";
                                string is_paid = "0";
                                if (row.Cells["DETAIL"].Value.ToString().IndexOf("CARD NO : ") == -1)
                                {
                                    if (the_code == "")
                                    {
                                        the_code = (DateTime.Today.Year + 543).ToString("0000") + DateTime.Today.Month.ToString("00") + DateTime.Today.Day.ToString("00") + DateTime.Today.Hour.ToString("00") + DateTime.Today.Minute.ToString("00");
                                    }
                                    DataTable DT;
                                    do // RANDOM NUMBER UNTIL NO MATCH IN DATABASE
                                    {
                                        rand = new Random().Next(1, 10000).ToString("0000");
                                        queryString = "SELECT * FROM GIFT_CERTIFICATE WHERE CARD_NO LIKE '" + the_code + rand + "'";
                                        DT = DB.getS(queryString, null, "CHECK IF GIFT CERTIFICATE NO[" + the_code + rand + "] EXISTED", false);
                                    } while (DT.Rows.Count > 0);
                                    DT.Dispose();
                                    card_no = the_code + rand;

                                    int expire_amount = -1;
                                    int expire_unit = -1;
                                    queryString = "SELECT * FROM GIFT_CERTIFICATE_CONFIG";
                                    using (DT = DB.getS(queryString, null, "GET GIFT CERTIFICATE CONFIG", false))
                                    {
                                        // GET GIFT CERTIFICATE CONFIG
                                        expire_amount = Convert.ToInt32(DT.Rows[0]["EXPIRE_AMOUNT"].ToString());
                                        expire_unit = Convert.ToInt32(DT.Rows[0]["EXPIRE_UNIT"].ToString());
                                    }
                                    expiry_date = "DATEADD(" + (expire_unit == 0 ? "MONTH" : "YEAR") + ", " + expire_amount.ToString() + ", CURRENT_TIMESTAMP)";
                                }
                                else
                                {
                                    is_paid = "1";
                                    card_no = row.Cells["DETAIL"].Value.ToString();
                                    card_no = card_no.Substring(card_no.IndexOf("CARD NO : ") + "CARD NO : ".Length, card_no.IndexOf("EXPIRE") - (card_no.IndexOf("CARD NO : ") + "CARD NO : ".Length));
                                    
                                    expiry_date = row.Cells["DETAIL"].Value.ToString();
                                    expiry_date = GF.modDate(expiry_date.Substring(expiry_date.IndexOf("EXPIRE : ") + "EXPIRE : ".Length));
                                }

                                int spa_program_id = -1;
                                string balance = "NULL";
                                if (row.Cells["DETAIL"].Value.ToString().IndexOf("#") != -1)
                                {
                                    // IF THIS IS SPA MENU GIFT CERTIFICATE ( HAS # ) -> GET SPA_PROGRAM_ID
                                    tmp = row.Cells["DETAIL"].Value.ToString();
                                    string code = tmp.Substring(tmp.IndexOf("#") + 1, tmp.IndexOf("]") - tmp.IndexOf("#") - 1);
                                    queryString = "SELECT SPA_PROGRAM_ID FROM SPA_PROGRAM WHERE CODE LIKE '" + code + "'";
                                    using (DataTable DT = DB.getS(queryString, null, "GET SPA_PROGRAM_ID FROM CODE[" + code + "]", false))
                                    {
                                        spa_program_id = Convert.ToInt32(DT.Rows[0]["SPA_PROGRAM_ID"].ToString());
                                    }
                                }
                                GF.closeLoading();
                                if (row.Cells["DETAIL"].Value.ToString().IndexOf("BALANCE : ") != -1)
                                {
                                    tmp = row.Cells["DETAIL"].Value.ToString();
                                    if (row.Cells["DETAIL"].Value.ToString().IndexOf("CARD NO : ") != -1)
                                        balance = GF.removeThousandAndDecimal((tmp.Substring(tmp.IndexOf("BALANCE : ") + "BALANCE : ".Length, tmp.IndexOf("CARD NO : ") - (tmp.IndexOf("BALANCE : ") + "BALANCE : ".Length))).Trim());
                                    else
                                    {
                                        if(tmp.IndexOf("[") == -1)
                                            balance = GF.removeThousandAndDecimal((tmp.Substring(tmp.IndexOf("BALANCE : ") + "BALANCE : ".Length)).Trim());
                                        else
                                            balance = GF.removeThousandAndDecimal((tmp.Substring(tmp.IndexOf("BALANCE : ") + "BALANCE : ".Length, tmp.IndexOf("[") - "BALANCE : ".Length)).Trim());
                                    }
                                }

                                // EXTRACT FROM & FOR
                                string from_txt = "";
                                string to_txt = "";
                                tmp = row.Cells["DETAIL"].Value.ToString();
                                if(tmp.IndexOf("FROM") != -1)
                                    from_txt = tmp.Substring((tmp.IndexOf("FROM") + "FROM".Length), tmp.IndexOf("]", tmp.IndexOf("FROM")) - (tmp.IndexOf("FROM") + "FROM".Length));
                                if(tmp.IndexOf("FOR") != -1)
                                    to_txt = tmp.Substring((tmp.IndexOf("FOR") + "FOR".Length), tmp.IndexOf("]", tmp.IndexOf("FOR")) - (tmp.IndexOf("FOR") + "FOR".Length));

                                // INSERT INTO DATABASE
                                queryString = "INSERT INTO GIFT_CERTIFICATE (BILL_ID, CUSTOMER_ID, CARD_NO, SPA_PROGRAM_ID, PRICE, BALANCE, BALANCE_MAX, PROMOTION_ID, EXPIRY_DATE, FROM_TXT, FOR_TXT, ISSUE_DATE, ISSUE_BY, IS_USE, IS_PAID, IS_WEBSITE) VALUES (";
                                queryString += billID.ToString() + ", ";
                                queryString += customer_id.currentID.ToString() + ", ";
                                queryString += "'" + card_no + "', ";
                                queryString += spa_program_id.ToString() + ", ";
                                queryString += GF.removeThousandAndDecimal(row.Cells["AMOUNT"].Value.ToString()) + ", ";
                                queryString += balance + ", ";
                                queryString += balance + ", ";
                                queryString += promotion_id + ", ";
                                queryString += expiry_date + ", ";
                                queryString += "N'" + from_txt.Trim() + "', ";
                                queryString += "N'" + to_txt.Trim() + "', ";
                                queryString += "CURRENT_TIMESTAMP, ";
                                queryString += GF.emp_id.ToString() + ", ";
                                queryString += "1, "; // <----- IF WE PRINT THE CARD <--- WILL BE UPDATE AFTER CARD IS PRINTED
                                queryString += is_paid + ", "; // <----- IF WE PRINT THE CARD <--- WILL BE UPDATE AFTER CARD IS PRINTED
                                queryString += (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("WEBSITE") != -1 ? "1" : "0") + ")";

                                // GET ID OF INSERTED GIFT CERTIFICATE
                                int gift_certificate_id = -1;
                                gift_certificate_id = DB.insertReturnID(queryString, "INSERT " + (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("WEBSITE") != -1 ? "WEBSITE " : "") + "GIFT CERTIFICATE[" + customer_code + rand + "]");
                                if (gift_certificate_id == -1)
                                {
                                    DB.rollbackTrans();
                                    GF.closeLoading();
                                    return;
                                }

                                queryString = "SELECT CARD_NO FROM GIFT_CERTIFICATE WHERE GIFT_CERTIFICATE_ID = " + gift_certificate_id.ToString();
                                using (DataTable tmpDT = DB.getS(queryString, null, "GET CARD_NO FROM GIFT_CERTIFICATE_ID[" + gift_certificate_id.ToString() + "]", false))
                                {
                                    card_no = tmpDT.Rows[0]["CARD_NO"].ToString();
                                }

                                // UPDATE TEMP ID ( MINUS 6-DIGITS RANDOM ) TO INSERTED
                                row.Cells["SOURCE_ID"].Value = gift_certificate_id.ToString();
                                row.Cells["CARD_NO"].Value = card_no;
                            }
                        }

                        sort++;
                        /* ======================= INSERT THE LIST INTO BILL_DETAIL ======================= */
                        tmp = row.Cells["DETAIL"].Value.ToString().Trim();
                        string amount = "1";
                        string misc_item_name = "";
                        int the_item_type = -1;

                        if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("MASSAGE") != -1) the_item_type = 0;
                        if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("MEMBER") != -1) the_item_type = 1;
                        
                        if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("CERTIFICATE") != -1)
                        {
                            if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("WEBSITE") == -1)
                            {
                                if (row.Cells["DETAIL"].Value.ToString().IndexOf("#") != -1) the_item_type = 2; // SPA MENU
                                else the_item_type = 3; // MONEY
                            }
                            else // WEBSITE
                            {
                                if (row.Cells["DETAIL"].Value.ToString().IndexOf("#") != -1) the_item_type = 6; // SPA MENU
                                else the_item_type = 9; // MONEY
                            }
                        }

                        if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PRODUCT & OTHER") != -1) the_item_type = 4;
                        if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DELIVERY CLUB") != -1) the_item_type = 5;
                        if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("MANGO") != -1) the_item_type = 7;
                        if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("RESTAURANT") != -1) the_item_type = 8;

                        if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("ITEM") != -1 || row.Cells["ITEM_TYPE"].Value.ToString().Trim() == "DELIVERY CLUB" || row.Cells["ITEM_TYPE"].Value.ToString().Trim() == "MANGO" || row.Cells["ITEM_TYPE"].Value.ToString().Trim() == "RESTAURANT" || row.Cells["ITEM_TYPE"].Value.ToString().Trim() == "PRODUCT & OTHER")
                        {
                            amount = tmp.Substring(tmp.IndexOf("[") + 1, tmp.IndexOf("]") - (tmp.IndexOf("[") + 1));
                            misc_item_name = tmp.Substring(0, tmp.IndexOf("[") - 1).Trim();
                        }


                        queryString = "INSERT INTO BILL_DETAIL (BILL_ID, ITEM_TYPE, ITEM_ID, AMOUNT, PRICE, MISC_ITEM_NAME, APPLY_DISCOUNT, AMOUNT_LEFT, SORT) VALUES (";
                        queryString += billID.ToString() + ", ";
                        queryString += the_item_type.ToString() + ", ";
                        queryString += row.Cells["SOURCE_ID"].Value.ToString() + ", ";
                        queryString += amount + ", ";
                        queryString += GF.removeThousandAndDecimal(row.Cells["AMOUNT"].Value.ToString()) + ", ";
                        queryString += "'" + misc_item_name + "', ";
                        queryString += (row.Cells["APPLY_DISCOUNT"].Value != null && row.Cells["APPLY_DISCOUNT"].Value.ToString() != "" ? row.Cells["APPLY_DISCOUNT"].Value.ToString() : "NULL") + ", ";
                        queryString += (row.Cells["AMOUNT_LEFT"].Value != null && row.Cells["AMOUNT_LEFT"].Value.ToString() != "" ? GF.removeThousandAndDecimal(row.Cells["AMOUNT_LEFT"].Value.ToString()) : "NULL") + ", ";
                        queryString += sort.ToString() + ")";

                        // GET ID OF INSERTED ITEM.
                        int bill_detail_id = DB.insertReturnID(queryString, "INSERT ITEM INTO BILL_DETAIL");
                        if (bill_detail_id == -1)
                        {
                            DB.rollbackTrans();
                            GF.closeLoading();
                            return;
                        }

                        // UPDATE EVERY REFERENCE TO IT.
                        foreach (DataGridViewRow targetRow in DGV.Rows)
                        {
                            if (targetRow.Cells["ITEM_TYPE"].Value != null)
                            {
                                if (targetRow.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") != -1 || targetRow.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PAID") != -1)
                                {
                                    if (targetRow.Cells["SOURCE_ID"].Value.ToString().Trim() == row.Cells["BILL_TARGET_ID"].Value.ToString().Trim())
                                    {
                                        //MessageBox.Show(targetRow.Cells["ITEM_TYPE"].Value.ToString() + " >> " + targetRow.Cells["SOURCE_ID"].Value.ToString() + " : " + row.Cells["BILL_TARGET_ID"].Value.ToString() + "\r\nBILL_DETAIL_ID = " + bill_detail_id.ToString());
                                        targetRow.Cells["SOURCE_ID"].Value = bill_detail_id.ToString();
                                    }
                                }
                            }
                        }

                        // UPDATE BILL_ID INTO RESERVATION
                        if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("MASSAGE") != -1)
                        {
                            queryString = "SELECT RESERVATION_ID FROM RESERVATION_DETAIL WHERE RESERVATION_DETAIL_ID = " + row.Cells["SOURCE_ID"].Value.ToString();
                            using (DataTable DT = DB.getS(queryString, null, "GET RESERVATION_ID FROM RESERVATION_DETAIL_ID[" + row.Cells["SOURCE_ID"].Value.ToString() + "]", false))
                            {
                                if (DT.Rows.Count == 1)
                                {
                                    queryString = "UPDATE RESERVATION SET BILL_ID = " + billID.ToString() + " WHERE RESERVATION_ID = " + DT.Rows[0]["RESERVATION_ID"].ToString() + " AND BILL_ID IS NULL";
                                    if (!DB.set(queryString, "UPDATE BILL_ID[" + billID.ToString() + "] INTO RES_ID[" + DT.Rows[0]["RESERVATION_ID"].ToString() + "]"))
                                    {
                                        MessageBox.Show("CANNOT UPDATE BILL_ID !!", "ERROR");
                                        GF.closeLoading();
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("CANNOT UPDATE BILL_ID !!", "ERROR");
                                    GF.closeLoading();
                                    return;
                                }
                            }
                        }

                        // UPDATE ITSELF.
                        row.Cells["BILL_TARGET_ID"].Value = bill_detail_id.ToString();
                    }

                    /* ======================= INSERT DISCOUNT INTO BILL_DISCOUNT ======================= 
                     * MEMBERCARD, GIFT VOUCHER, VIP, BARTER, MANUAL, CROSS PROMOTION
                     * EXCLUDE : PAID with MEMBER, CASH, CREDIT, VIP
                     */
                    if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") != -1 || (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PAID") != -1 && row.Cells["DETAIL"].Value.ToString().IndexOf("GIFT CERTIFICATE") == -1 && row.Cells["DETAIL"].Value.ToString().IndexOf("COUPON") == -1 && row.Cells["DETAIL"].Value.ToString().IndexOf("GIFT VOUCHER") == -1 && (row.Cells["DETAIL"].Value.ToString().IndexOf("MEMBER") == -1 && row.Cells["DETAIL"].Value.ToString().IndexOf("CASH") == -1 && row.Cells["DETAIL"].Value.ToString().IndexOf("CREDIT") == -1)))
                    {
                        tmp = row.Cells["DETAIL"].Value.ToString();
                        String reason = "NULL";
                        int use_card_type = -1;

                        if (tmp.IndexOf("==") != -1)
                        {
                            reason = tmp.Substring(tmp.IndexOf("==") + 2, tmp.IndexOf("==", tmp.IndexOf("==") + 2) - tmp.IndexOf("=="));
                        }
                        if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") != -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("MEMBER") != -1)
                            use_card_type = 0;
                        /*if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PAID") != -1 && row.Cells["DETAIL"].Value.ToString().IndexOf("GIFT CERTIFICATE") != -1)
                            use_card_type = 1;
                        if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PAID") != -1 && row.Cells["DETAIL"].Value.ToString().IndexOf("VOUCHER") != -1)
                            use_card_type = 2;
                        if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PAID") != -1 && row.Cells["DETAIL"].Value.ToString().IndexOf("COUPON") != -1)
                            use_card_type = 3;*/
                        if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") != -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("COUPON") != -1)
                            use_card_type = 3;
                        if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") != -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("VIP") != -1)
                            use_card_type = 4;
                        if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") != -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("BARTER") != -1)
                            use_card_type = 5;
                        if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("DISCOUNT") != -1 && row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("OTHER") != -1)
                            use_card_type = 6;
                        if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PAID") != -1 && row.Cells["DETAIL"].Value.ToString().IndexOf("CROSS PROMOTION") != -1)
                            use_card_type = 7;

                        queryString = "INSERT INTO BILL_DISCOUNT (BILL_ID, BILL_DETAIL_ID, REASON, AMOUNT, UNIT, APPROVED_BY, IS_PROMOTION, PROMOTION_ID, USE_CARD_ID, USE_CARD_TYPE, IS_BARTER, RAW_TEXT) VALUES (";
                        queryString += billID.ToString() + ", ";
                        queryString += row.Cells["SOURCE_ID"].Value.ToString() + ", ";
                        queryString += "'" + reason + "', ";
                        queryString += GF.removeThousandAndDecimal(row.Cells["AMOUNT"].Value.ToString()) + ", ";
                        queryString += "1, ";
                        queryString += (row.Cells["APPROVED_BY"].Value != null && row.Cells["APPROVED_BY"].Value.ToString() != "" ? row.Cells["APPROVED_BY"].Value.ToString() : "NULL") + ", ";
                        queryString += (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PROMOTION") == -1 ? "0" : "1") + ", ";
                        queryString += promotion_id + ", ";
                        queryString += (row.Cells["USE_CARD_ID"].Value != null && row.Cells["USE_CARD_ID"].Value.ToString() != "" ? row.Cells["USE_CARD_ID"].Value.ToString() : "NULL") + ", ";
                        queryString += use_card_type.ToString() + ", ";
                        queryString += (use_card_type == 5 ? "1" : "0") + ", ";
                        queryString += "'" + row.Cells["DETAIL"].Value.ToString() + "')";

                        int bill_discount_id = DB.insertReturnID(queryString, "INSERT BILL DISCOUNT");
                        if (bill_discount_id == -1)
                        {
                            DB.rollbackTrans();
                            GF.closeLoading();
                            return;
                        }

                        row.Cells["BILL_TARGET_ID"].Value = bill_discount_id.ToString();
                    }

                    /* ======================= INSERT PAID INTO BILL_PAYMENT ======================= */
                    if (row.Cells["ITEM_TYPE"].Value.ToString().IndexOf("PAID") != -1 && row.Cells["DETAIL"].Value.ToString().IndexOf("CROSS PROMOTION") == -1)
                    {
                        
                        int payment_type = -1;
                        string credit_card_no = "NULL";
                        string credit_card_type = "NULL";

                        if (row.Cells["DETAIL"].Value.ToString().IndexOf("PERSONAL CREDIT") != -1) payment_type = -1;
                        if (row.Cells["DETAIL"].Value.ToString().IndexOf("CASH") != -1) payment_type = 0;
                        if (row.Cells["DETAIL"].Value.ToString().IndexOf("CREDIT") != -1 && row.Cells["DETAIL"].Value.ToString().IndexOf("PERSONAL CREDIT") == -1)
                        {
                            payment_type = 1;
                            credit_card_no = row.Cells["DETAIL"].Value.ToString();
                            credit_card_no = credit_card_no.Substring(credit_card_no.IndexOf("XXXX-XXXX-XXXX-"), 19);
                            credit_card_no = credit_card_no.Substring(credit_card_no.Length - 4);
                            credit_card_no = "'" + credit_card_no + "'";

                            if (row.Cells["DETAIL"].Value.ToString().IndexOf("MASTERCARD") != -1) credit_card_type = "0";
                            if (row.Cells["DETAIL"].Value.ToString().IndexOf("VISA") != -1) credit_card_type = "1";
                        }
                        if (row.Cells["DETAIL"].Value.ToString().IndexOf("MEMBER") != -1) payment_type = 2;
                        if (row.Cells["DETAIL"].Value.ToString().IndexOf("GIFT CERTIFICATE") != -1) payment_type = 3;
                        if (row.Cells["DETAIL"].Value.ToString().IndexOf("GIFT VOUCHER") != -1) payment_type = 4;
                        if (row.Cells["DETAIL"].Value.ToString().IndexOf("COUPON") != -1)
                        {
                            if (row.Cells["DETAIL"].Value.ToString().IndexOf("MONEY COUPON") != -1) payment_type = 6;
                            else payment_type = 5;
                        }

                        String use_card_id = "";
                        if (payment_type == -1)
                            use_card_id = "NULL";
                        else
                            use_card_id = (row.Cells["USE_CARD_ID"].Value == null || row.Cells["USE_CARD_ID"].Value.ToString() == "" ? "NULL" : row.Cells["USE_CARD_ID"].Value.ToString());

                        queryString = "INSERT INTO BILL_PAYMENT (BILL_ID, PAYMENT_TYPE, MONEY_RECEIVE, USE_CARD_ID, CREDIT_CARD_NO, CREDIT_CARD_TYPE, RAW_TEXT) VALUES (";
                        queryString += billID.ToString() + ", ";
                        queryString += payment_type.ToString() + ", ";
                        queryString += GF.removeThousandAndDecimal(row.Cells["AMOUNT"].Value.ToString()) + ", ";
                        queryString += use_card_id + ", ";
                        queryString += credit_card_no + ", ";
                        queryString += credit_card_type + ", ";
                        queryString += "'" + row.Cells["DETAIL"].Value.ToString() + "'";
                        queryString += ")";

                        int bill_payment_id = DB.insertReturnID(queryString, "INSERT BILL_PAYMENT");
                        if (bill_payment_id == -1)
                        {
                            DB.rollbackTrans();
                            GF.closeLoading();
                            return;
                        }

                        if (payment_type == -1)
                        {
                            queryString = "INSERT INTO DEBTOR_DATA ( DEBTOR_ID, ITEM_TYPE, ITEM_ID, AMOUNT, DEBT_DATETIME, RECORD_BY ) VALUES (";
                            queryString += row.Cells["USE_CARD_ID"].Value.ToString() + ", ";
                            queryString += "0, ";
                            queryString += billID.ToString() + ", ";
                            queryString += GF.removeThousandAndDecimal(row.Cells["AMOUNT"].Value.ToString()) + ", ";
                            queryString += "CURRENT_TIMESTAMP, ";
                            queryString += GF.emp_id.ToString();
                            queryString += ")";
                            if (!DB.set(queryString, "INSERT DEBTOR_DATA"))
                            {
                                MessageBox.Show("ERROR ADDING DEBTOR DATA !!", "ERROR");
                                GF.closeLoading();
                                return;
                            }
                        }

                        if (payment_type == 3 && row.Cells["DETAIL"].Value.ToString().IndexOf("SPA MENU") != -1)
                        {
                            queryString = "UPDATE GIFT_CERTIFICATE SET IS_USE = 0 WHERE SPA_PROGRAM_ID != -1 AND GIFT_CERTIFICATE_ID = " + row.Cells["USE_CARD_ID"].Value.ToString();
                            if (!DB.set(queryString, "UPDATE GIFT_CERTIFICATE SET IS_USE = 0 AS PAID"))
                            {
                                MessageBox.Show("ERROR UPDATE GIFT CERTIFICATE AS USED !!", "ERROR");
                                GF.closeLoading();
                                return;
                            }
                        }

                        if (payment_type == 4)
                        {
                            queryString = "UPDATE GIFT_VOUCHER SET IS_USE = 0 WHERE GIFT_VOUCHER_ID = " + row.Cells["USE_CARD_ID"].Value.ToString();
                            if (!DB.set(queryString, "UPDATE GIFT_VOUCHER SET IS_USE = 0 AS PAID"))
                            {
                                MessageBox.Show("ERROR UPDATE GIFT VOUCHER AS USED !!", "ERROR");
                                GF.closeLoading();
                                return;
                            }
                        }

                        if (payment_type == 5)
                        {
                            queryString = "UPDATE COUPON SET IS_USE = 0, USED_BILL_ID = " + billID.ToString() + " WHERE COUPON_ID = " + row.Cells["USE_CARD_ID"].Value.ToString();
                            if (!DB.set(queryString, "UPDATE COUPON SET IS_USE = 0 AS PAID"))
                            {
                                MessageBox.Show("ERROR UPDATE COUPON AS USED !!", "ERROR");
                                GF.closeLoading();
                                return;
                            }
                        }

                        if (payment_type == 6)
                        {
                            queryString = "UPDATE COUPON SET BALANCE = BALANCE - " + GF.removeThousandAndDecimal(row.Cells["AMOUNT"].Value.ToString()) + ", USED_BILL_ID = " + billID.ToString() + " WHERE COUPON_ID = " + row.Cells["USE_CARD_ID"].Value.ToString();
                            if (!DB.set(queryString, "UPDATE BALANCE IN MONEY COUPON"))
                            {
                                MessageBox.Show("ERROR UPDATE BALANCE IN MONEY COUPON !!", "ERROR");
                                GF.closeLoading();
                                return;
                            }
                            queryString = "SELECT BALANCE FROM COUPON WHERE COUPON_ID = " + row.Cells["USE_CARD_ID"].Value.ToString();
                            using (DataTable tmpBal = DB.getS(queryString, null, "CHECK BALANCE OF MONEY COUPON ** IF EMPTY THEN DISABLE", false))
                            {
                                if (tmpBal.Rows.Count == 1)
                                {
                                    //GF.doDebug(">>>>>>>>>>>>>>>>>>>> " + tmpBal.Rows[0]["BALANCE"].ToString());
                                    if (Convert.ToInt32(tmpBal.Rows[0]["BALANCE"].ToString()) == 0)
                                    {
                                        queryString = "UPDATE COUPON SET IS_USE = 0 WHERE COUPON_ID = " + row.Cells["USE_CARD_ID"].Value.ToString();
                                        if (!DB.set(queryString, "DISABLE MONEY COUPON"))
                                        {
                                            MessageBox.Show("ERROR DISABLE MONEY COUPON !!", "ERROR");
                                            GF.closeLoading();
                                            return;
                                        }
                                    }
                                }
                            }
                        }

                        row.Cells["BILL_TARGET_ID"].Value = bill_payment_id.ToString();
                    }
                }
            }
            DB.close();

            GF.closeLoading();
        }

        private string getRand()
        {
            int rand = -1;
            bool found = false;
            do {
                found = false;
                rand = new Random().Next(1, 1000000) * -1;
                foreach (DataGridViewRow row in DGV.Rows)
                {
                    if (row.Cells["SOURCE_ID"].Value != null)
                    {
                        if (row.Cells["SOURCE_ID"].Value.ToString() == rand.ToString())
                        {
                            found = true;
                            break;
                        }
                    }
                    if (row.Cells["BILL_TARGET_ID"].Value != null)
                    {
                        if (row.Cells["BILL_TARGET_ID"].Value.ToString() == rand.ToString())
                        {
                            found = true;
                            break;
                        }
                    }
                }
            } while(found);
            return rand.ToString();
        }

        private void money_coupon_btn_Click(object sender, EventArgs e)
        {
            using (use_cards useCardPage = new use_cards())
            {
                useCardPage.payment_type = 6;
                useCardPage.Owner = this;
                useCardPage.ShowDialog();
            }
        }
    }
}
