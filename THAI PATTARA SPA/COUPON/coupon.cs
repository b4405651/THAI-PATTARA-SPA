using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.COUPON
{
    public partial class coupon : Form
    {
        bool justOpen = true;
        public coupon()
        {
            InitializeComponent();

            coupon_type.Items.Add(new ComboItem(-1, "ALL"));
            coupon_type.Items.Add(new ComboItem(0, "SPA PROGRAM COUPON"));
            coupon_type.Items.Add(new ComboItem(1, "DISCOUNT COUPON"));
            coupon_type.Items.Add(new ComboItem(2, "MONEY COUPON"));
            GF.resizeComboBox(coupon_type);
            coupon_type.SelectedIndex = 0;

            btn_dgv.useDefaultEnable = false;

            if (GF.emp_id == 0)
            {
                btn_dgv.enable_btn.Visible = true;
                GF.disableButton(btn_dgv.enable_btn);
            }
            else btn_dgv.enable_btn.Visible = false;

            btn_dgv.DGV.SelectionChanged += (ss, ee) =>
            {
                if (btn_dgv.enable_btn.Visible)
                {
                    if (btn_dgv.DGV.SelectedRows.Count == 1)
                    {
                        if (btn_dgv.DGV.SelectedRows[0].Cells["status"].Value.ToString() == "INACTIVE") GF.enableButton(btn_dgv.enable_btn);
                        else GF.disableButton(btn_dgv.enable_btn);
                    }
                    else GF.disableButton(btn_dgv.enable_btn);
                }
            };

            //UC EVENTS
            btn_dgv.EnableClick += new btn_dgv.EnableClickHandler(EnableClick);
            btn_dgv.AddClick += new btn_dgv.AddClickHandler(AddClick);
            btn_dgv.EditClick += new btn_dgv.EditClickHandler(EditClick);
            btn_dgv.DeleteClick += new btn_dgv.DeleteClickHandler(DeleteClick);
            btn_dgv.RefreshClick += new btn_dgv.RefreshClickHandler(doLoadGridData);
            btn_dgv.SearchClick += new btn_dgv.SearchClickHandler(doLoadGridData);

            //PAGING DELEGATE
            btn_dgv.firstClick += new btn_dgv.firstClickHandler(doLoadGridData);
            btn_dgv.prevClick += new btn_dgv.prevClickHandler(doLoadGridData);
            btn_dgv.nextClick += new btn_dgv.nextClickHandler(doLoadGridData);
            btn_dgv.lastClick += new btn_dgv.lastClickHandler(doLoadGridData);
            btn_dgv.pageNumberChanged += new btn_dgv.pageNumberChangedHandler(doLoadGridData);
        }

        // DELEGATE PART :: BEGIN
        void EnableClick(object sender, EventArgs e)
        {
            String coupon_id = btn_dgv.DGV.SelectedRows[0].Cells["coupon_id"].Value.ToString();
            String queryString = "UPDATE COUPON SET IS_USE = 1 WHERE COUPON_ID = " + coupon_id;
            GF.showLoading(this);
            DB.beginTrans();
            if (!DB.set(queryString, "FORCE ENABLE COUPON"))
            {
                MessageBox.Show("ERROR FORCE ENABLE COUPON !!", "ERROR");
                GF.closeLoading();
                return;
            }
            DB.close();
            GF.closeLoading();
            loadGridData();
        }
        void AddClick(object sender, EventArgs e)
        {
            GF.selected_id = 0;

            using (coupon_manage managePage = new coupon_manage())
            {
                managePage.coupon_id = "-1";
                managePage.Owner = this;
                managePage.Text = "ADD COUPON";
                managePage.manage_btn.Text = "ADD";
                //GF.showLoading(managePage);
                managePage.ShowDialog();
            }
        }

        void EditClick(object sender, EventArgs e)
        {
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells["coupon_id"].Value.ToString());

            using (coupon_manage managePage = new coupon_manage())
            {
                managePage.coupon_id = btn_dgv.DGV.SelectedRows[0].Cells["coupon_id"].Value.ToString();
                managePage.Owner = this;
                managePage.Text = "EDIT COUPON";
                managePage.manage_btn.Text = "UPDATE";
                //GF.showLoading(managePage);
                managePage.ShowDialog();
            }
        }
        
        void DeleteClick(object sender, EventArgs e)
        {
            //GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells["special_card_set_id"].Value);
            
            //if (MessageBox.Show("ARE YOU SURE YOU WANT TO VOID THIS COUPON ?", "VOID COUPON", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
                using (coupon_void voidPage = new coupon_void())
                {
                    voidPage.code_begin.Text = voidPage.code_end.Text = btn_dgv.DGV.SelectedRows[0].Cells["card_no"].Value.ToString();
                    voidPage.Text = "VOID COUPON";
                    voidPage.Owner = this;
                    voidPage.ShowDialog();
                }
            //}
        }

        void doLoadGridData(object sender, EventArgs e)
        {
            code_begin_lbl.Top = code_end_lbl.Top = event_name.Top + 27;
            code_begin.Top = code_end.Top = code_begin_lbl.Top - 3;

            line_sep1.Top = code_begin_lbl.Top + 35; line_sep1.Width = btn_dgv.Width;
            if (justOpen)
            {
                btn_dgv.rearrange(line_sep1.Top + 15);
                justOpen = false;
            }
            
            btn_dgv.del_btn.Text = "VOID";
            //btn_dgv.edit_btn.Visible = false;
            //btn_dgv.add_btn.Left = btn_dgv.edit_btn.Left;
            //btn_dgv.preventDGVSelectionChanged = true;
            //btn_dgv.preventEnable = true;

            GF.resetAC(this);
            loadGridData();

            //GF.enableButton(btn_dgv.del_btn);
        }

        // DELEGATE PART :: END

        private void card_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) loadGridData();
        }

        private void code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) loadGridData();
        }

        public void loadGridData()
        {
            GF.showLoading(this);

            this.btn_dgv.DGV.Visible = false;
            this.btn_dgv.DGV.Rows.Clear();

            if (btn_dgv.DGV.Columns.Count == 0)
            {
                this.btn_dgv.DGV.Columns.Add("card_no", "COUPON NO.");
                this.btn_dgv.DGV.Columns.Add("status", "STATUS");
                this.btn_dgv.DGV.Columns.Add("event_name", "EVENT");
                this.btn_dgv.DGV.Columns.Add("program_name", "PROGRAM");
                this.btn_dgv.DGV.Columns.Add("balance", "BALANCE");
                this.btn_dgv.DGV.Columns.Add("price", "PRICE");
                this.btn_dgv.DGV.Columns.Add("payment", "PAYMENT");
                this.btn_dgv.DGV.Columns.Add("expiry_date", "EXPIRY DATE");
                this.btn_dgv.DGV.Columns.Add("sold_on", "SOLD ON");
                this.btn_dgv.DGV.Columns.Add("used_on", "USED ON");
                this.btn_dgv.DGV.Columns.Add("bill_no", "BILL NO");
                this.btn_dgv.DGV.Columns.Add("input_by", "INPUT BY");
                this.btn_dgv.DGV.Columns.Add("input_on", "INPUT ON");
                this.btn_dgv.DGV.Columns.Add("voided_by", "VOIDED BY");
                this.btn_dgv.DGV.Columns.Add("voided_date", "VOIDED ON");
                this.btn_dgv.DGV.Columns.Add("voided_reason", "REASON");
                this.btn_dgv.DGV.Columns.Add("coupon_id", "coupon_id");

                this.btn_dgv.DGV.Columns["coupon_id"].Visible = false;
                this.btn_dgv.DGV.Columns["event_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.btn_dgv.DGV.Columns["program_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.btn_dgv.DGV.Columns["input_by"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.btn_dgv.DGV.Columns["voided_by"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.btn_dgv.DGV.Columns["voided_reason"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            if (code_begin.Text.Trim() != "" && code_end.Text.Trim() != "" && Convert.ToInt64(code_begin.Text.Trim()) > Convert.ToInt64(code_end.Text.Trim()))
            {
                String tmp = code_end.Text.Trim();
                code_end.Text = code_begin.Text;
                code_begin.Text = tmp;
            }

            String criteria = "";
            if (event_name.Text.Trim() != "") criteria += " AND A.EVENT_NAME LIKE '%" + event_name.Text.Trim() + "%'";
            if (code_begin.Text.Trim() != "") criteria += " AND " + code_begin.Text.Trim() + " <= CONVERT(BIGINT, A.CARD_NO)";
            if (code_end.Text.Trim() != "") criteria += " AND CONVERT(BIGINT, A.CARD_NO) <= " + code_end.Text.Trim();
            if (coupon_type.SelectedIndex > 0)
            {
                if (coupon_type.SelectedIndex == 1) criteria += " AND A.SPA_PROGRAM_ID != -1";
                if (coupon_type.SelectedIndex == 2) criteria += " AND A.SPA_PROGRAM_ID = -1 AND A.BALANCE IS NULL";
                if (coupon_type.SelectedIndex == 3) criteria += " AND A.BALANCE IS NOT NULL";
            }

            String queryString = @"
	            SELECT
		            A.coupon_id
		            ,A.SPA_PROGRAM_ID
		            ,A.event_name
		            ,A.card_no
                    ,A.balance
                    ,A.balance_max
		            ,A.price
		            ,A.payment_type
		            ,A.discount_amount
		            ,A.discount_unit
		            ,A.created_by
		            ,B.CODE
		            ,B.PROGRAM_NAME
		            ,C.FULLNAME creator
		            ,CONVERT(VARCHAR(MAX), A.created_date, 103) + ' ' + CONVERT(VARCHAR(MAX), A.created_date, 108) created_date
		            ,CONVERT(VARCHAR(MAX), A.expiry_date, 103) expiry_date
		            ,CONVERT(VARCHAR(MAX), A.sold_on, 103) sold_on
		            ,A.is_use
		            ,A.is_void
		            ,NULL voided_by
		            ,NULL voider
		            ,NULL voided_reason
		            ,NULL voided_datetime
		            ,NULL BILL_DATETIME
		            ,NULL DISCOUNT_DATETIME
		            ,CASE WHEN D.COUPON_SET_ID IS NOT NULL THEN 'COUPON SET : ' + E.COUPON_SET_NAME + ' [#' + CONVERT(NVARCHAR(MAX), D.COUPON_SET_ID) + ']' ELSE NULL END COUPON_SET_NAME
		            ,NULL PAYMENT_BILL_NO
		            ,NULL DISCOUNT_BILL_NO
	            FROM 
	            COUPON A
	            LEFT OUTER JOIN SPA_PROGRAM B ON A.SPA_PROGRAM_ID = B.SPA_PROGRAM_ID
	            LEFT OUTER JOIN EMPLOYEE C ON A.created_by = C.EMP_ID
	            LEFT OUTER JOIN COUPON_SET D ON A.COUPON_SET_ID = D.COUPON_SET_ID
	            LEFT OUTER JOIN COUPON_SET_CONFIG E ON D.COUPON_SET_CONFIG_ID = E.COUPON_SET_CONFIG_ID
	            WHERE A.IS_USE = 1 AND A.IS_VOID = 0" + criteria + @"
            UNION ALL
	            SELECT
		            A.coupon_id
                    ,A.SPA_PROGRAM_ID
                    ,A.event_name
                    ,A.card_no
                    ,A.balance
                    ,A.balance_max
                    ,A.price
                    ,A.payment_type
                    ,A.discount_amount
                    ,A.discount_unit
                    ,A.created_by
                    ,B.CODE
                    ,B.PROGRAM_NAME
                    ,C.FULLNAME creator
                    ,CONVERT(VARCHAR(MAX), A.created_date, 103) + ' ' + CONVERT(VARCHAR(MAX), A.created_date, 108) created_date
                    ,CONVERT(VARCHAR(MAX), A.expiry_date, 103) expiry_date
                    ,CONVERT(VARCHAR(MAX), A.sold_on, 103) sold_on
                    ,A.is_use
                    ,A.is_void
                    ,NULL voided_by
                    ,NULL voider
                    ,NULL voided_reason
                    ,NULL voided_datetime
                    ,CONVERT(VARCHAR(MAX), F.BILL_DATETIME, 103) + ' ' + CONVERT(VARCHAR(MAX), F.BILL_DATETIME, 108) BILL_DATETIME
                    ,NULL DISCOUNT_DATETIME
                    ,CASE WHEN G.COUPON_SET_ID IS NOT NULL THEN 'COUPON SET : ' + H.COUPON_SET_NAME + ' [#' + CONVERT(NVARCHAR(MAX), G.COUPON_SET_ID) + ']' ELSE NULL END COUPON_SET_NAME
                    ,F.BILL_NO PAYMENT_BILL_NO
                    ,NULL DISCOUNT_BILL_NO
                FROM 
                COUPON A
                LEFT OUTER JOIN SPA_PROGRAM B ON A.SPA_PROGRAM_ID = B.SPA_PROGRAM_ID
                LEFT OUTER JOIN EMPLOYEE C ON A.created_by = C.EMP_ID
                LEFT OUTER JOIN EMPLOYEE D ON A.voided_by = D.EMP_ID
                INNER JOIN BILL_PAYMENT E ON A.COUPON_ID = E.USE_CARD_ID AND E.PAYMENT_TYPE = 5
                INNER JOIN BILL F ON E.BILL_ID = F.BILL_ID AND F.IS_VOID = 0
                LEFT OUTER JOIN COUPON_SET G ON A.COUPON_SET_ID = G.COUPON_SET_ID
                LEFT OUTER JOIN COUPON_SET_CONFIG H ON G.COUPON_SET_CONFIG_ID = H.COUPON_SET_CONFIG_ID
                WHERE A.IS_USE = 0 AND A.IS_VOID = 0" + criteria + @"
            UNION ALL
	            SELECT
		            A.coupon_id
                    ,A.SPA_PROGRAM_ID
                    ,A.event_name
                    ,A.card_no
                    ,A.balance
                    ,A.balance_max
                    ,A.price
                    ,A.payment_type
                    ,A.discount_amount
                    ,A.discount_unit
                    ,A.created_by
                    ,B.CODE
                    ,B.PROGRAM_NAME
                    ,C.FULLNAME creator
                    ,CONVERT(VARCHAR(MAX), A.created_date, 103) + ' ' + CONVERT(VARCHAR(MAX), A.created_date, 108) created_date
                    ,CONVERT(VARCHAR(MAX), A.expiry_date, 103) expiry_date
                    ,CONVERT(VARCHAR(MAX), A.sold_on, 103) sold_on
                    ,A.is_use
                    ,A.is_void
                    ,NULL voided_by
                    ,NULL voider
                    ,NULL voided_reason
                    ,NULL voided_datetime
                    ,NULL BILL_DATETIME
                    ,CONVERT(VARCHAR(MAX), J.BILL_DATETIME, 103) + ' ' + CONVERT(VARCHAR(MAX), J.BILL_DATETIME, 108) DISCOUNT_DATETIME
                    ,CASE WHEN G.COUPON_SET_ID IS NOT NULL THEN 'COUPON SET : ' + H.COUPON_SET_NAME + ' [#' + CONVERT(NVARCHAR(MAX), G.COUPON_SET_ID) + ']' ELSE NULL END COUPON_SET_NAME
                    ,NULL PAYMENT_BILL_NO
                    ,J.BILL_NO DISCOUNT_BILL_NO
                FROM 
                COUPON A
                LEFT OUTER JOIN SPA_PROGRAM B ON A.SPA_PROGRAM_ID = B.SPA_PROGRAM_ID
                LEFT OUTER JOIN EMPLOYEE C ON A.created_by = C.EMP_ID
                LEFT OUTER JOIN EMPLOYEE D ON A.voided_by = D.EMP_ID
                LEFT OUTER JOIN COUPON_SET G ON A.COUPON_SET_ID = G.COUPON_SET_ID
                LEFT OUTER JOIN COUPON_SET_CONFIG H ON G.COUPON_SET_CONFIG_ID = H.COUPON_SET_CONFIG_ID
                INNER JOIN BILL_DISCOUNT I ON A.COUPON_ID = I.USE_CARD_ID AND I.USE_CARD_TYPE = 3
                INNER JOIN BILL J ON I.BILL_ID = J.BILL_ID AND J.IS_VOID = 0
                WHERE A.IS_USE = 0 AND A.IS_VOID = 0" + criteria + @"
            UNION ALL
	            SELECT
		            A.coupon_id
                    ,A.SPA_PROGRAM_ID
                    ,A.event_name
                    ,A.card_no
                    ,A.balance
                    ,A.balance_max
                    ,A.price
                    ,A.payment_type
                    ,A.discount_amount
                    ,A.discount_unit
                    ,A.created_by
                    ,B.CODE
                    ,B.PROGRAM_NAME
                    ,C.FULLNAME creator
                    ,CONVERT(VARCHAR(MAX), A.created_date, 103) + ' ' + CONVERT(VARCHAR(MAX), A.created_date, 108) created_date
                    ,CONVERT(VARCHAR(MAX), A.expiry_date, 103) expiry_date
                    ,CONVERT(VARCHAR(MAX), A.sold_on, 103) sold_on
                    ,A.is_use
                    ,A.is_void
                    ,A.voided_by
                    ,D.FULLNAME voider
                    ,A.voided_reason
                    ,CONVERT(VARCHAR(MAX), A.voided_datetime, 103) + ' ' + CONVERT(VARCHAR(MAX), A.voided_datetime, 108) voided_datetime
                    ,NULL BILL_DATETIME
                    ,NULL DISCOUNT_DATETIME
                    ,CASE WHEN E.COUPON_SET_ID IS NOT NULL THEN 'COUPON SET : ' + F.COUPON_SET_NAME + ' [#' + CONVERT(NVARCHAR(MAX), E.COUPON_SET_ID) + ']' ELSE NULL END COUPON_SET_NAME
                    ,NULL PAYMENT_BILL_NO
                    ,NULL DISCOUNT_BILL_NO
                FROM 
                COUPON A
                LEFT OUTER JOIN SPA_PROGRAM B ON A.SPA_PROGRAM_ID = B.SPA_PROGRAM_ID
                LEFT OUTER JOIN EMPLOYEE C ON A.created_by = C.EMP_ID
                LEFT OUTER JOIN EMPLOYEE D ON A.voided_by = D.EMP_ID
                LEFT OUTER JOIN COUPON_SET E ON A.COUPON_SET_ID = E.COUPON_SET_ID
                LEFT OUTER JOIN COUPON_SET_CONFIG F ON E.COUPON_SET_CONFIG_ID = F.COUPON_SET_CONFIG_ID
                WHERE A.IS_VOID = 1" + criteria;

            // GET TOTAL PAGE
            GF.getTotalPage(btn_dgv, queryString, null);

            queryString = DB.insertRowNum("CREATED_DATE DESC, CARD_NO ASC, is_void ASC", queryString);
            //queryString = DB.insertRowNum("A.CREATED_DATE DESC, CONVERT(BIGINT, A.CARD_NO) ASC, A.IS_VOID ASC", queryString);
            GF.doDebug(">>>> " + queryString);
            String used_bill_no;
            String status;
            using (DataTable myDT = DB.getS(queryString, null, "GET ALL COUPON"))
            {
                for (int rowNum = 0; rowNum < myDT.Rows.Count; rowNum++)
                {
                    used_bill_no = "";
                    if (myDT.Rows[rowNum]["PAYMENT_BILL_NO"].ToString() != "") used_bill_no = myDT.Rows[rowNum]["PAYMENT_BILL_NO"].ToString();
                    if (myDT.Rows[rowNum]["DISCOUNT_BILL_NO"].ToString() != "") used_bill_no = myDT.Rows[rowNum]["DISCOUNT_BILL_NO"].ToString();

                    status = "";
                    if (myDT.Rows[rowNum]["IS_VOID"].ToString() == "1") status = "VOIDED";
                    else if (myDT.Rows[rowNum]["IS_USE"].ToString() == "0") status = "INACTIVE";
                    else status = "ACTIVE";

                    String program_name = "-";
                    if (myDT.Rows[rowNum]["BALANCE"].ToString() == "")
                    {
                        if (myDT.Rows[rowNum]["PROGRAM_NAME"].ToString() == "")
                            program_name = "ALL SPA PROGRAM";
                        else
                            program_name = "[#" + myDT.Rows[rowNum]["CODE"].ToString() + "] " + myDT.Rows[rowNum]["PROGRAM_NAME"].ToString();

                        program_name += " " + myDT.Rows[rowNum]["DISCOUNT_AMOUNT"].ToString() + " " + (myDT.Rows[rowNum]["DISCOUNT_UNIT"].ToString() == "0" ? "%" : Properties.Settings.Default.money_unit);
                    }

                    String theBalance = "";
                    if(myDT.Rows[rowNum]["BALANCE"].ToString() == "" || myDT.Rows[rowNum]["BALANCE"].ToString() == "NULL")
                        theBalance = "-";
                    else
                        theBalance = GF.formatNumber(Convert.ToInt32(myDT.Rows[rowNum]["BALANCE"].ToString()));

                    if (myDT.Rows[rowNum]["BALANCE_MAX"].ToString() == "" || myDT.Rows[rowNum]["BALANCE_MAX"].ToString() == "NULL")
                        theBalance += "";
                    else
                        theBalance += " / " + GF.formatNumber(Convert.ToInt32(myDT.Rows[rowNum]["BALANCE_MAX"].ToString()));
                    
                    this.btn_dgv.DGV.Rows.Add(
                        myDT.Rows[rowNum]["card_no"],
                        status,
                        (myDT.Rows[rowNum]["COUPON_SET_NAME"].ToString() != "" ? myDT.Rows[rowNum]["COUPON_SET_NAME"].ToString() : myDT.Rows[rowNum]["event_name"].ToString()),
                        program_name,
                        theBalance,
                        GF.formatNumber(Convert.ToInt32(myDT.Rows[rowNum]["PRICE"].ToString())),
                        (myDT.Rows[rowNum]["PAYMENT_TYPE"].ToString() == "0" ? "CASH" : (myDT.Rows[rowNum]["PAYMENT_TYPE"].ToString() == "1" ? "CREDIT CARD" : "-")),
                        GF.formatDate(myDT.Rows[rowNum]["expiry_date"].ToString()),
                        GF.formatDate(myDT.Rows[rowNum]["sold_on"].ToString()),
                        (myDT.Rows[rowNum]["SPA_PROGRAM_ID"].ToString() == "-1" ? myDT.Rows[rowNum]["DISCOUNT_DATETIME"].ToString() : myDT.Rows[rowNum]["BILL_DATETIME"].ToString()),
                        used_bill_no,
                        (myDT.Rows[rowNum]["CREATED_BY"].ToString() == "0" ? "S.A." : myDT.Rows[rowNum]["CREATOR"].ToString()),
                        GF.formatDateTime(myDT.Rows[rowNum]["created_date"].ToString()),
                        (myDT.Rows[rowNum]["voided_by"].ToString() == "0" ? "S.A." : myDT.Rows[rowNum]["voider"]),
                        GF.formatDateTime(myDT.Rows[rowNum]["voided_datetime"].ToString()),
                        myDT.Rows[rowNum]["voided_reason"],
                        myDT.Rows[rowNum]["coupon_id"]
                    );
                    if (myDT.Rows[rowNum]["is_void"].ToString() == "1") this.btn_dgv.DGV.Rows[rowNum].DefaultCellStyle.BackColor = Color.LightCoral;
                    if (btn_dgv.DGV.Rows[rowNum].Cells["status"].Value.ToString() == "VOIDED" || btn_dgv.DGV.Rows[rowNum].Cells["status"].Value.ToString() == "INACTIVE")
                        btn_dgv.DGV.Rows[rowNum].Cells["status"].Style.ForeColor = Color.Red;
                    else
                        btn_dgv.DGV.Rows[rowNum].Cells["status"].Style.ForeColor = Color.Green;

                    this.btn_dgv.DGV.ClearSelection();
                }
            }
            GF.updateRowNum(btn_dgv.DGV, true);
            this.btn_dgv.DGV.Refresh();
            this.btn_dgv.DGV.Visible = true;
            GF.closeLoading();
        }

        private void code_end_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) loadGridData();
        }

        private void event_name_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) loadGridData();
        }

        private void coupon_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadGridData();
        }

        private void code_begin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void code_end_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
