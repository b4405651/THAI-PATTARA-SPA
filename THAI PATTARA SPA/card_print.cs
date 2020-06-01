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
    public partial class card_print : Form
    {
        public bool isFile = false;
        public bool isReIssue = false;
        public int billID = -1;
        public int membercard_type_id = -1;
        public int card_type = -1;
        public string card_no = "";
        public int approved_id = -1;
        private static String[] type_name = {"MEMBERCARD", "MEMBERCARD_LIMITED_EDITION", "GIFT_CERTIFICATE", "GIFT_VOUCHER"};
        string file1 = "";
        string file2 = "";
        string file3 = "";
        string insertString = "";
        int expire_amount = -1;
        int expire_unit = -1;
        string expire_date = "";
        string customer_code = "";
        string spaProgramName = "";
        string price = "";
        string from_txt = "";
        string for_txt = "";
        public string gv_issue_for = "";
        public int member_card_id = -1;
        public int gift_certificate_id = -1;

        public card_print()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };
        }

        private void card_print_Load(object sender, EventArgs e)
        {
            String queryString = "";
            DataTable DT = null;

            switch (card_type)
            {
                case 0: case 1: // MEMBERCARD & MEMBERCARD_LIMITED_EDITION
                    print_card1_btn.Text = "FRONT";
                    print_card2_btn.Text = "BACK";
                    attach_paper_btn.Text = "ATTACH PAPER";
                    break;
                case 2: // GIFT CERTIFICATE
                    print_card1_btn.Text = "CARD";
                    print_card1_btn.Width = attach_paper_btn.Width;
                    print_card2_btn.Visible = false;
                    break;
                case 3: // GIFT VOUCHER
                    GF.enableButton(print_card1_btn);
                    print_card1_btn.Text = "CARD";
                    print_card1_btn.Width = attach_paper_btn.Width;
                    print_card2_btn.Visible = false;
                    attach_paper_btn.Visible = false;
                    groupBox1.Height = attach_paper_btn.Top;
                    instruction_lbl.Top = groupBox1.Height + 15;
                    this.Height = instruction_lbl.Top + instruction_lbl.Height + 40;
                    break;
            }

            switch (card_type)
            {
                case 0: case 1: // MEMBERCARD
                    queryString = @"
                    SELECT 
                        A.CARD_NO,
                        B.*, C.CODE
                    FROM MEMBERCARD A 
                    INNER JOIN MEMBERCARD_TYPE B ON A.MEMBERCARD_TYPE_ID = B.MEMBERCARD_TYPE_ID 
                    INNER JOIN CUSTOMER C ON A.CUSTOMER_ID = C.CUSTOMER_ID
                    WHERE A.MEMBERCARD_ID = " + GF.selected_id.ToString();
                    using (DT = DB.getS(queryString, null, "GET DATA FROM MEMBERCARD_TYPE", false))
                    {
                        file1 = DT.Rows[0]["FRONT_CARD"].ToString();
                        file2 = DT.Rows[0]["BACK_CARD"].ToString();
                        file3 = DT.Rows[0]["ATTACH_PAPER"].ToString();
                        customer_code = DT.Rows[0]["CODE"].ToString();
                        if(card_no == "") card_no = DT.Rows[0]["CARD_NO"].ToString();
                    }
                    break;
                case 2: // GIFT CERTIFICATE
                    queryString = "SELECT A.*, B.RUS_NAME FROM GIFT_CERTIFICATE A LEFT OUTER JOIN SPA_PROGRAM B ON A.SPA_PROGRAM_ID = B.SPA_PROGRAM_ID WHERE A.GIFT_CERTIFICATE_ID = " + GF.selected_id.ToString();
                    using (DT = DB.getS(queryString, null, "GET SPA_PROGRAM_NAME FROM GIFT_CERTIFICATE[" + GF.selected_id.ToString() + "]", false))
                    {
                        if (DT.Rows.Count == 1)
                        {
                            spaProgramName = DT.Rows[0]["RUS_NAME"].ToString();
                            if (DT.Rows[0]["BALANCE_MAX"].ToString() != "")
                                price = DT.Rows[0]["BALANCE_MAX"].ToString();
                            else
                                price = DT.Rows[0]["PRICE"].ToString();
                            from_txt = DT.Rows[0]["FROM_TXT"].ToString();
                            for_txt = DT.Rows[0]["FOR_TXT"].ToString();
                            if (card_no == "") card_no = DT.Rows[0]["CARD_NO"].ToString();
                        }
                    }

                    queryString = "SELECT * FROM GIFT_CERTIFICATE_CONFIG";
                    DT = DB.getS(queryString, null, "GET GIFT_CERTIFICATE_CONFIG", false);
                    file1 = DT.Rows[0]["CARD1"].ToString();
                    file3 = DT.Rows[0]["CARD2"].ToString();
                    break;
                case 3: // GIFT VOUCHER
                    String[] tmp = GF.tmpText.Split();
                    if (!isReIssue)
                    {
                        if (GF.selected_id.ToString() != "-1")
                        {
                            queryString = "SELECT RUS_NAME FROM SPA_PROGRAM WHERE SPA_PROGRAM_ID = " + GF.selected_id.ToString();
                            using (DT = DB.getS(queryString, null, "GET RUS_NAME OF SPA_PROGRAM_NAME FROM GIFT_VOUCHER", false))
                            {
                                spaProgramName = DT.Rows[0]["RUS_NAME"].ToString();
                            }
                        }
                        else spaProgramName = "ALL SPA PROGRAM " + tmp[0] + " " + tmp[1];
                    }
                    else
                    {
                        if (GF.selected_id.ToString() != "-1")
                        {
                            queryString = "SELECT B.RUS_NAME FROM GIFT_VOUCHER A INNER JOIN SPA_PROGRAM B ON A.SPA_PROGRAM_ID = B.SPA_PROGRAM_ID WHERE A.GIFT_VOUCHER_ID = " + GF.selected_id.ToString();
                            using (DT = DB.getS(queryString, null, "GET RUS_NAME OF SPA_PROGRAM_NAME FROM GIFT_VOUCHER", false))
                            {
                                spaProgramName = DT.Rows[0]["RUS_NAME"].ToString();
                            }
                        }
                        else spaProgramName = "ALL SPA PROGRAM " + tmp[0] + " " + tmp[1];
                    }

                    queryString = "SELECT * FROM GIFT_VOUCHER_CONFIG";
                    using (DT = DB.getS(queryString, null, "GET GIFT_VOUCHER_CONFIG", false))
                    {
                        file1 = DT.Rows[0]["CARD"].ToString();
                    }
                    break;
            }

            if (!isReIssue)
            {
                expire_amount = Convert.ToInt32(DT.Rows[0]["EXPIRE_AMOUNT"].ToString());
                expire_unit = Convert.ToInt32(DT.Rows[0]["EXPIRE_UNIT"].ToString());

                if (expire_amount.ToString() != "0")
                {
                    DateTime expiryDate = new DateTime();
                    if (expire_unit == 0) expiryDate = DateTime.Now.AddMonths(expire_amount);
                    if (expire_unit == 1) expiryDate = DateTime.Now.AddYears(expire_amount);
                    expire_date = expiryDate.Day.ToString("00") + "/" + expiryDate.Month.ToString("00") + "/" + expiryDate.Year.ToString();
                }

                if (card_type == 3)
                {
                    card_no = (DateTime.Now.Year + 543).ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00") + new Random().Next(1, 100).ToString("00");
                }

                switch (card_type)
                {
                    case 0:
                    case 1: // MEMBERCARD
                        break;
                    case 2:
                        insertString = "UPDATE GIFT_CERTIFICATE SET IS_PAID = 1, IS_USE = 1 WHERE GIFT_CERTIFICATE_ID = " + GF.selected_id.ToString();
                        break;
                    case 3: // GIFT_VOUCHER
                        String[] tmp = GF.tmpText.Split(' ');

                        insertString = "INSERT INTO GIFT_VOUCHER (" + (billID != -1 ? "BILL_ID, " : "") + "CARD_NO, SPA_PROGRAM_ID, EXPIRY_DATE, DISCOUNT_AMOUNT, DISCOUNT_UNIT, ISSUE_BY, APPROVED_BY, ISSUE_FOR";
                        if (member_card_id != -1) insertString += ", MEMBERCARD_ID";
                        insertString += ") SELECT " + (billID != -1 ? billID.ToString() + ", " : "") + "'" + card_no + "', " + GF.selected_id.ToString() + ", ";
                        if (GF.selected_id.ToString() != "-1")
                        {
                            insertString += "DATEADD(";
                            if (expire_unit == 0) insertString += "MONTH";
                            if (expire_unit == 1) insertString += "YEAR";
                            insertString += ", " + expire_amount.ToString() + ", GETDATE()), ";
                        }
                        else
                        {
                            insertString += GF.modDate(tmp[2]) + ", ";
                        }
                        insertString += tmp[0] + ", ";
                        insertString += (tmp[1].Trim() == "%" ? "0, " : "1, ");
                        insertString += GF.emp_id.ToString() + ", " + approved_id.ToString() + ", '" + gv_issue_for + "'";
                        if (member_card_id != -1) insertString += ", " + member_card_id.ToString();
                        insertString += " FROM GIFT_VOUCHER_CONFIG WHERE GIFT_VOUCHER_CONFIG_ID = 1";
                        break;
                }

                if (insertString.Trim() != "")
                {
                    DB.beginTrans();
                    GF.doDebug(">>>>>>>>>> " + insertString);
                    if (!DB.set(insertString, "INSERT INTO " + type_name[card_type] + " TABLE"))
                    {
                        GF.closeLoading();
                        MessageBox.Show("ERROR INSERT INTO " + type_name[card_type] + " TABLE !!", "ERROR");
                        return;
                    }
                    else DB.close();
                }
            }
            else
            {
                switch (card_type)
                {
                    case 0: case 1: // MEMBERCARD
                        queryString = "SELECT CARD_NO, CONVERT(NVARCHAR(MAX), EXPIRE_DATE, 103) EXPIRY_DATE FROM MEMBERCARD WHERE MEMBERCARD_ID = " + GF.selected_id.ToString();
                        DT = DB.getS(queryString, null, "GET CARD_NO, EXPIRY_DATE FROM MEMBERCARD[" + GF.selected_id.ToString() + "]", false);
                        break;
                    case 2:
                        queryString = "SELECT CARD_NO, CONVERT(NVARCHAR(MAX), EXPIRY_DATE, 103) EXPIRY_DATE FROM GIFT_CERTIFICATE WHERE GIFT_CERTIFICATE_ID = " + GF.selected_id.ToString();
                        DT = DB.getS(queryString, null, "GET CARD_NO, EXPIRY_DATE FROM GIFT_CERTIFICATE[" + GF.selected_id.ToString() + "]", false);
                        break;
                    case 3:
                        queryString = "SELECT CARD_NO, CONVERT(NVARCHAR(MAX), EXPIRY_DATE, 103) EXPIRY_DATE FROM GIFT_VOUCHER WHERE GIFT_VOUCHER_ID = " + GF.selected_id.ToString();
                        DT = DB.getS(queryString, null, "GET CARD_NO, EXPIRY_DATE FROM GIFT_VOUCHER[" + GF.selected_id.ToString() + "]", false);
                        break;
                }
                
                card_no = DT.Rows[0]["CARD_NO"].ToString();
                expire_date = DT.Rows[0]["EXPIRY_DATE"].ToString();
                DT.Dispose();
            }
        }

        private void print_card1_btn_Click(object sender, EventArgs e)
        {
            PRINT.initPrint(isFile, type_name[card_type], file1, this, (card_type == 0 || card_type == 1 ? true : false), false, false, card_no, expire_date, spaProgramName, price, from_txt, for_txt);
        }

        private void print_card2_btn_Click(object sender, EventArgs e)
        {
            PRINT.initPrint(isFile, type_name[card_type], file2, this, false, (card_type == 0 || card_type == 1 ? true : false), false, card_no, expire_date, spaProgramName, price, from_txt, for_txt);
        }

        private void attach_paper_btn_Click(object sender, EventArgs e)
        {
            PRINT.initPrint(isFile, type_name[card_type] + "_LETTER", file3, this, false, false, (card_type == 0 || card_type == 1 ? true : false), card_no, expire_date, spaProgramName, price, from_txt, for_txt);
        }

        private void card_print_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!print_card1_btn.Enabled && (!print_card2_btn.Enabled || !print_card2_btn.Visible) && (!attach_paper_btn.Enabled || !attach_paper_btn.Visible))
            {
                GF.showLoading(this);
                if (!isReIssue)
                {
                    switch (card_type)
                    {
                        case 0:
                        case 1:// MEMBERCARD, MEMBERCARD LIMITED EDITION

                            break;
                        case 2: // GIFT_CERTIFICATE
                            break;
                        case 3: // GIFT_VOUCHER
                            if (Owner.Name != "payment")
                            {
                                if ((VOUCHER.issue_e_voucher)Owner != null) ((VOUCHER.issue_e_voucher)Owner).Close();
                            }
                            break;
                    }
                }
                else
                {
                    GF.showLoading(this);
                    DB.beginTrans();
                    String queryString = "";
                    String tblName = "";
                    switch (card_type)
                    {
                        case 0: case 1: // MEMBERCARD
                            queryString = "UPDATE MEMBERCARD SET ISSUE_DATE = CURRENT_TIMESTAMP, ISSUE_BY = " + GF.emp_id.ToString() + " WHERE MEMBERCARD_ID = " + GF.selected_id.ToString();
                            tblName = "MEMBERCARD";
                            break;
                        case 2: // GIFT CERTIFICATE
                            queryString = "UPDATE GIFT_CERTIFICATE SET ISSUE_DATE = CURRENT_TIMESTAMP, ISSUE_BY = " + GF.emp_id.ToString() + " WHERE GIFT_CERTIFICATE_ID = " + GF.selected_id.ToString();
                            tblName = "GIFT_CERTIFICATE";
                            break;
                        case 3: // GIFT VOUCHER
                            queryString = "UPDATE GIFT_VOUCHER SET ISSUE_DATETIME = CURRENT_TIMESTAMP, ISSUE_BY = " + GF.emp_id.ToString() + " WHERE GIFT_VOUCHER_ID = " + GF.selected_id.ToString();
                            tblName = "GIFT_VOUCHER";
                            break;
                    }
                    if (!DB.set(queryString, "UPDATE " + tblName + "[" + GF.selected_id.ToString() + "]"))
                    {
                        MessageBox.Show("ERROR UPDATE " + tblName + " !!", "ERROR");
                        GF.closeLoading();
                    }
                    DB.close();
                    GF.closeLoading();
                    ((re_issue_card)((re_issue_card_approve)Owner).Owner).btn_dgv.search_btn.PerformClick();
                    ((re_issue_card_approve)Owner).Close();
                }
                GF.closeLoading();
            }
            //if (this.Owner.Name == "cashier") ((SPA_MANAGEMENT_SYSTEM.SHOP.cashier)this.Owner).new_bill_btn.PerformClick();
        }
    }
}
