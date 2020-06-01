using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace SPA_MANAGEMENT_SYSTEM
{
    public partial class scan_barcode : Form
    {
        private Label scan_now;
        public string Mode = "";
        public int theID = -1;
        private Label label1;
        private Label barcode;
        string theCode = "";
    
        public scan_barcode()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };
        }

        private void InitializeComponent()
        {
            this.scan_now = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.barcode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // scan_now
            // 
            this.scan_now.AutoSize = true;
            this.scan_now.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scan_now.ForeColor = System.Drawing.Color.Red;
            this.scan_now.Location = new System.Drawing.Point(12, 104);
            this.scan_now.Name = "scan_now";
            this.scan_now.Size = new System.Drawing.Size(260, 36);
            this.scan_now.TabIndex = 0;
            this.scan_now.Text = "... SCAN NOW ...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(53, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "press ESC to close";
            // 
            // barcode
            // 
            this.barcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barcode.ForeColor = System.Drawing.Color.Black;
            this.barcode.Location = new System.Drawing.Point(3, 185);
            this.barcode.Name = "barcode";
            this.barcode.Size = new System.Drawing.Size(280, 24);
            this.barcode.TabIndex = 2;
            this.barcode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.barcode.TextChanged += new System.EventHandler(this.barcode_TextChanged);
            // 
            // scan_barcode
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.barcode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scan_now);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "scan_barcode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.scan_barcode_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.scan_barcode_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void scan_barcode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if(e.KeyCode == Keys.Back)
            {
                if (barcode.Text.Trim().Length > 0) barcode.Text = barcode.Text.Trim().Substring(0, barcode.Text.Trim().Length - 1);
            }
            else if ((e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return) && theCode.Trim() != "")
            {
                theCode = theCode.Replace("NumPad", "").Replace("Return", "").Trim();
                String queryString = "";
                String action = "QUERY SCANNED BARCODE [" + Mode + "] // theCode = " + theCode;

                //MessageBox.Show(theCode);

                Dictionary<string, string> Params;

                switch (Mode)
                {
                    case "APPROVER":
                        queryString = @"
                        SELECT B.*, A.CAN_APPROVE 
                        FROM USERS B
                        LEFT OUTER JOIN EMPLOYEE A ON A.EMP_ID = B.EMP_ID
                        WHERE replace(replace(replace(Convert(nvarchar(max), B.created_date, 120), '-', ''), ' ', ''), ':', '') = @thecode";

                        Params = new Dictionary<string, string>();
                        Params.Add("@thecode", theCode);

                        using (DataTable DT = DB.getS(queryString, Params, action, false))
                        {
                            if (DT.Rows.Count == 0)
                            {
                                MessageBox.Show("NOT FOUND THIS BARCODE !!", "ERROR");
                                barcode.Text = "";
                            }
                            else if (DT.Rows[0]["CAN_APPROVE"].ToString() == "0")
                                MessageBox.Show("THIS CARD CANNOT APPROVE !!", "ERROR");
                            else
                            {
                                theID = Convert.ToInt32((DT.Rows[0]["EMP_ID"].ToString() == "" || DT.Rows[0]["EMP_ID"].ToString() == "NULL") ? "0" : DT.Rows[0]["EMP_ID"].ToString());
                                this.Close();
                            }
                        }
                        break;

                    case "CARD_CHECK":
                        queryString = @"
                        SELECT A.*, ISNULL(B.FULLNAME, 'S.A.') ISSUE_BY_NAME FROM 
                        (
	                        (
		                        SELECT 
                                    'MEMBERCARD' RAW_TYPE,
			                        B.MEMBERCARD_TYPE_NAME CARD_TYPE_NAME, 
			                        A.CARD_NO, 
                                    A.BALANCE,
                                    NULL BALANCE_MAX,
			                        Convert(NVARCHAR(MAX),A.PRICE) PRICE, 
			                        A.ISSUE_DATE,
			                        CONVERT(NVARCHAR(MAX), A.ISSUE_DATE, 103) + ' ' + CONVERT(NVARCHAR(MAX), A.ISSUE_DATE, 108) ISSUE_DATETIME, 
			                        A.ISSUE_BY,
			                        A.MEMBERCARD_TYPE_ID CARD_TYPE,
			                        A.MEMBERCARD_ID CARD_ID,
			                        C.CUSTOMER_NAME + '-' + C.TEL OWNER_NAME,
                                    NULL CODE,
			                        NULL SPA_PROGRAM,
			                        A.IS_USE,
                                    CASE WHEN A.EXPIRE_DATE IS NULL THEN '-' ELSE CONVERT(NVARCHAR(MAX), A.EXPIRE_DATE, 103) END EXPIRY_DATE,
                                    CONVERT(NVARCHAR(MAX), A.VOID_DATETIME, 103) + ' ' + CONVERT(NVARCHAR(MAX), A.VOID_DATETIME, 108) VOID_DATETIME,
                                    A.VOID_REASON,
                                    A.VOID_BY
		                        FROM MEMBERCARD A 
		                        INNER JOIN MEMBERCARD_TYPE B ON A.MEMBERCARD_TYPE_ID = B.MEMBERCARD_TYPE_ID
		                        INNER JOIN CUSTOMER C ON A.CUSTOMER_ID = C.CUSTOMER_ID
		                        WHERE B.IS_USE = 1
	                        )
	                        UNION ALL
	                        (
		                        SELECT
                                    CASE A.SPA_PROGRAM_ID WHEN -1 THEN 'MONEY ' ELSE 'SPA MENU ' END + 'GIFT CERTIFICATE' RAW_TYPE,
			                        CASE A.SPA_PROGRAM_ID WHEN -1 THEN 'MONEY ' ELSE 'SPA MENU ' END + 'GIFT CERTIFICATE' CARD_TYPE_NAME,
			                        A.CARD_NO,
                                    A.BALANCE,
                                    NULL BALANCE_MAX,
			                        Convert(NVARCHAR(MAX),A.PRICE) PRICE,
			                        A.ISSUE_DATE,
			                        CONVERT(NVARCHAR(MAX), A.ISSUE_DATE, 103) + ' ' + CONVERT(NVARCHAR(MAX), A.ISSUE_DATE, 108) ISSUE_DATETIME, 
			                        A.ISSUE_BY,
			                        50 CARD_TYPE,
			                        A.GIFT_CERTIFICATE_ID CARD_ID,
			                        B.CUSTOMER_NAME + '-' + B.TEL OWNER_NAME,
                                    C.CODE,
			                        C.PROGRAM_NAME SPA_PROGRAM,
			                        A.IS_USE,
                                    CASE WHEN A.EXPIRY_DATE IS NULL THEN '-' ELSE CONVERT(NVARCHAR(MAX), A.EXPIRY_DATE, 103) END EXPIRY_DATE,
                                    NULL VOID_DATETIME,
                                    NULL VOID_REASON,
                                    NULL VOID_BY
		                        FROM GIFT_CERTIFICATE A
		                        LEFT OUTER JOIN CUSTOMER B ON A.CUSTOMER_ID = B.CUSTOMER_ID
		                        LEFT OUTER JOIN SPA_PROGRAM C ON A.SPA_PROGRAM_ID = C.SPA_PROGRAM_ID
	                        )
	                        UNION ALL
	                        (
		                        SELECT
                                    'GIFT VOUCHER' RAW_TYPE,
			                        'GIFT VOUCHER' CARD_TYPE_NAME,
			                        A.CARD_NO,
                                    NULL BALANCE,
                                    NULL BALANCE_MAX,
			                        '-' PRICE,
			                        A.ISSUE_DATETIME ISSUE_DATE,
			                        CONVERT(NVARCHAR(MAX), A.ISSUE_DATETIME, 103) + ' ' + CONVERT(NVARCHAR(MAX), A.ISSUE_DATETIME, 108) ISSUE_DATETIME, 
			                        A.ISSUE_BY,
			                        99 CARD_TYPE,
			                        A.GIFT_VOUCHER_ID,
			                        A.ISSUE_FOR OWNER_NAME,
                                    B.CODE,
			                        B.PROGRAM_NAME SPA_PROGRAM,
			                        A.IS_USE,
                                    CASE WHEN A.EXPIRY_DATE IS NULL THEN '-' ELSE CONVERT(NVARCHAR(MAX), A.EXPIRY_DATE, 103) END EXPIRY_DATE,
                                    NULL VOID_DATETIME,
                                    NULL VOID_REASON,
                                    NULL VOID_BY
		                        FROM GIFT_VOUCHER A
		                        INNER JOIN SPA_PROGRAM B ON A.SPA_PROGRAM_ID = B.SPA_PROGRAM_ID
	                        )
	                        UNION ALL
	                        (
		                        SELECT
                                    'COUPON' RAW_TYPE,
			                        'COUPON' CARD_TYPE_NAME,
			                        A.CARD_NO,
                                    A.BALANCE,
                                    A.BALANCE_MAX,
			                        A.PRICE,
			                        A.CREATED_DATE ISSUE_DATE,
			                        CONVERT(NVARCHAR(MAX), A.CREATED_DATE, 103) + ' ' + CONVERT(NVARCHAR(MAX), A.CREATED_DATE, 108) ISSUE_DATETIME,
			                        A.CREATED_BY ISSUE_BY,
			                        98 CARD_TYPE,
			                        A.COUPON_ID,
			                        A.EVENT_NAME OWNER_NAME,
                                    B.CODE,
			                        B.PROGRAM_NAME SPA_PROGRAM,
			                        A.IS_USE,
                                    CASE WHEN A.EXPIRY_DATE IS NULL THEN '-' ELSE CONVERT(NVARCHAR(MAX), A.EXPIRY_DATE, 103) END EXPIRY_DATE,
                                    CONVERT(NVARCHAR(MAX), A.VOIDED_DATETIME, 103) + ' ' + CONVERT(NVARCHAR(MAX), A.VOIDED_DATETIME, 108) VOID_DATETIME,
                                    A.VOIDED_REASON,
                                    A.VOIDED_BY VOID_BY
		                        FROM COUPON A
		                        INNER JOIN SPA_PROGRAM B ON A.SPA_PROGRAM_ID = B.SPA_PROGRAM_ID
                                WHERE A.BALANCE IS NULL AND A.BALANCE_MAX IS NULL
	                        )
                            UNION ALL
	                        (
		                        SELECT
                                    'COUPON' RAW_TYPE,
			                        'MONEY_COUPON' CARD_TYPE_NAME,
			                        A.CARD_NO,
                                    A.BALANCE,
                                    A.BALANCE_MAX,
			                        A.PRICE,
			                        A.CREATED_DATE ISSUE_DATE,
			                        CONVERT(NVARCHAR(MAX), A.CREATED_DATE, 103) + ' ' + CONVERT(NVARCHAR(MAX), A.CREATED_DATE, 108) ISSUE_DATETIME,
			                        A.CREATED_BY ISSUE_BY,
			                        98 CARD_TYPE,
			                        A.COUPON_ID,
			                        A.EVENT_NAME OWNER_NAME,
                                    '' CODE,
			                        '' SPA_PROGRAM,
			                        A.IS_USE,
                                    CASE WHEN A.EXPIRY_DATE IS NULL THEN '-' ELSE CONVERT(NVARCHAR(MAX), A.EXPIRY_DATE, 103) END EXPIRY_DATE,
                                    CONVERT(NVARCHAR(MAX), A.VOIDED_DATETIME, 103) + ' ' + CONVERT(NVARCHAR(MAX), A.VOIDED_DATETIME, 108) VOID_DATETIME,
                                    A.VOIDED_REASON,
                                    A.VOIDED_BY VOID_BY
		                        FROM COUPON A
		                        WHERE A.SPA_PROGRAM_ID = -1 AND A.BALANCE IS NOT NULL AND A.BALANCE_MAX IS NOT NULL
	                        )
                        ) A LEFT OUTER JOIN EMPLOYEE B ON A.ISSUE_BY = B.EMP_ID WHERE A.CARD_NO = @thecode ORDER BY A.IS_USE DESC, A.CARD_ID DESC";

                        Params = new Dictionary<string, string>();
                        Params.Add("@thecode", theCode);

                        using (DataTable DT = DB.getS(queryString, Params, action, false))
                        {
                            if (DT.Rows.Count == 0)
                            {
                                MessageBox.Show("NOT FOUND !!", "ERROR");
                            } else {
                                DataRow data = DT.Rows[0];
                                String result = "CARD TYPE : ";
                                
                                result += data["CARD_TYPE_NAME"].ToString() + "\r\n\r\n";
                                result += "CARD NO : " + data["CARD_NO"].ToString() + "\r\n\r\n";
                                result += "SELLING PRICE : " + GF.formatNumber(Convert.ToInt32(data["PRICE"].ToString())) + "\r\n\r\n";
                                if (data["OWNER_NAME"].ToString() != "" && data["OWNER_NAME"].ToString() != "NULL")
                                {
                                    if (data["CARD_TYPE_NAME"].ToString().IndexOf("COUPON") != -1) result += "DETAIL : " + data["OWNER_NAME"].ToString() + "\r\n\r\n";
                                    else result += "OWNER : " + data["OWNER_NAME"].ToString() + "\r\n\r\n";
                                }

                                if (data["RAW_TYPE"].ToString() == "MONEY GIFT CERTIFICATE" || data["RAW_TYPE"].ToString() == "MEMBERCARD" || data["CARD_TYPE_NAME"].ToString() == "MONEY_COUPON"){
                                    result += "BALANCE : " + GF.formatNumber(Convert.ToInt32(data["BALANCE"].ToString()));
                                    if (data["BALANCE_MAX"].ToString() != "") result += " / " + GF.formatNumber(Convert.ToInt32(data["BALANCE_MAX"].ToString()));
                                    result += "\r\n\r\n";
                                }
                                else
                                    result += "SPA PROGRAM : " + data["SPA_PROGRAM"].ToString() + "\r\n\r\n";

                                result += "STATUS : " + (data["IS_USE"].ToString() == "1" ? "ACTIVE" : "INACTIVE") + "\r\n\r\n";
                                result += "ISSUE ON : " + data["ISSUE_DATETIME"].ToString() + "\r\n\r\n";
                                result += "ISSUE BY : " + data["ISSUE_BY_NAME"].ToString() + "\r\n\r\n";
                                result += "EXPIRE DATE : " + data["EXPIRY_DATE"].ToString();

                                if (data["RAW_TYPE"].ToString().IndexOf("COUPON") != -1)
                                {
                                    queryString = @"
                                    SELECT A.USED_BILL_ID, B.BILL_NO, CONVERT(NVARCHAR(MAX), B.BILL_DATETIME, 103) + ' ' + CONVERT(NVARCHAR(MAX), B.BILL_DATETIME, 108) BILL_DATETIME 
                                    FROM COUPON A 
                                    LEFT OUTER JOIN BILL B ON A.USED_BILL_ID = B.BILL_ID
                                    WHERE A.COUPON_ID = @card_id";

                                    Params = new Dictionary<string, string>();
                                    Params.Add("@card_id", data["CARD_ID"].ToString());

                                    using (DataTable couponDT = DB.getS(queryString, Params, "CHECK USED DATETIME", false))
                                    {
                                        DataRow couponData = couponDT.Rows[0];
                                        if ((couponData["USED_BILL_ID"] ?? "").ToString() != String.Empty)
                                        {
                                            result += "\r\n\r\n";
                                            result += "USED ON BILL NO : " + couponData["BILL_NO"].ToString() + "\r\n\r\n";
                                            result += "BILL DATETIME : " + couponData["BILL_DATETIME"].ToString();
                                        }
                                    }

                                    if((data["VOID_BY"] ?? "").ToString() != String.Empty)
                                    {
                                        result += "\r\n\r\n";
                                        result += "VOIDED !!\r\n\r\n";
                                        result += "VOID REASON : " + data["VOID_REASON"].ToString() + "\r\n\r\n";
                                        result += "VOID BY : ";
                                        if (Convert.ToInt32(data["VOID_BY"].ToString()) < 1)
                                        {
                                            result += "SYSTEM ADMINISTRATOR";
                                        }
                                        else
                                        {
                                            queryString = "SELECT * FROM EMPLOYEE WHERE EMP_ID = @void_by";

                                            Params = new Dictionary<string, string>();
                                            Params.Add("@void_by", data["VOID_BY"].ToString());

                                            using (DataTable voiderDT = DB.getS(queryString, Params, "GET VOIDER", false))
                                            {
                                                DataRow voiderData = voiderDT.Rows[0];
                                                result += voiderData["FULLNAME"].ToString();
                                                if ((voiderData["NICKNAME"] ?? "").ToString() != String.Empty)
                                                    result += " (" + voiderData["NICKNAME"].ToString() + ")";
                                            }
                                        }
                                    }
                                }

                                MessageBox.Show(result, "CARD DETAIL");
                            }
                            barcode.Text = "";
                        }
                        break;

                    case "PRODUCT":
                        queryString = @"
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
                        AND B.BARCODE = @thecode
                        ORDER BY C.ITEM_TYPE_NAME, B.ITEM_CODE";

                        Params = new Dictionary<string, string>();
                        Params.Add("@thecode", theCode);

                        using (DataTable DT = DB.getS(queryString, Params, action, false))
                        {
                            if (DT.Rows.Count == 0)
                            {
                                MessageBox.Show("NOT FOUND THIS BARCODE !!", "ERROR");
                                barcode.Text = "";
                            }
                            else
                            {
                                theID = Convert.ToInt32(DT.Rows[0]["ITEM_ID"].ToString());
                                switch (this.Owner.Name.ToUpper())
                                {
                                    case "CASHIER":
                                        ((SPA_MANAGEMENT_SYSTEM.SHOP.cashier)this.Owner).productRow = DT.Rows[0];
                                        break;
                                    case "STORE":
                                        ((SPA_MANAGEMENT_SYSTEM.STORE.store)this.Owner).barcodeItemID = theID;
                                        break;
                                }

                                this.Close();
                            }
                        }
                        break;
                }
                theCode = "";
            }
            else
            {
                if (e.KeyCode.ToString().Length == 2 && e.KeyCode.ToString()[0] == 'D')
                {
                    theCode += e.KeyCode.ToString()[1];
                    barcode.Text += e.KeyCode.ToString()[1];
                }
                else
                {
                    theCode += e.KeyCode.ToString();
                    barcode.Text += e.KeyCode.ToString();
                }
            }
        }

        private void scan_barcode_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (theID != -1)
            {
                switch (this.Owner.Name.ToUpper())
                {
                    case "OTHER_DISCOUNT":
                        ((SPA_MANAGEMENT_SYSTEM.SHOP.other_discount)this.Owner).approve_id = theID;
                        break;
                    case "STORE":
                        ((SPA_MANAGEMENT_SYSTEM.STORE.store)this.Owner).loadGridData();
                        break;
                }
            }
        }

        private void barcode_TextChanged(object sender, EventArgs e)
        {
            barcode.Text = barcode.Text.Replace("NumPad", "");
        }
    }
}
