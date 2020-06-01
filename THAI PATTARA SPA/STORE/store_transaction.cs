using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.STORE
{
    public partial class store_transaction : Form
    {
        public int barcodeItemID = -1;
        public store_transaction()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };
            
            item_cat.Items.Clear();
            item_cat.Items.Add(new ComboItem(-99, "== CATEGORY =="));
            string queryString = "SELECT * FROM ITEM_TYPE WHERE IS_USE = 1 ORDER BY ITEM_TYPE_NAME ASC";
            using (DataTable DT = DB.getS(queryString, null, "GET ITEM CATEGORIES", false))
            {
                foreach (DataRow row in DT.Rows)
                {
                    item_cat.Items.Add(new ComboItem(Convert.ToInt32(row["ITEM_TYPE_ID"].ToString()), row["ITEM_TYPE_NAME"].ToString()));
                }
            }
            item_cat.SelectedIndex = 0;
            GF.resizeComboBox(item_cat);

            deposit_by.Items.Clear();
            withdraw_by.Items.Clear();

            deposit_by.Items.Add(new ComboItem(-99, "== CHOOSE =="));
            deposit_by.Items.Add(new ComboItem(-1, "SYSTEM"));
            deposit_by.Items.Add(new ComboItem(0, "S.A."));

            withdraw_by.Items.Add(new ComboItem(-99, "== CHOOSE =="));
            withdraw_by.Items.Add(new ComboItem(-1, "BILL"));
            withdraw_by.Items.Add(new ComboItem(0, "S.A."));

            queryString = @"
            SELECT B.EMP_ID, B.FULLNAME
            FROM USERS A
            INNER JOIN EMPLOYEE B ON A.EMP_ID = B.EMP_ID
            WHERE A.IS_USE = 1
            AND B.EMP_STATUS = 1
            ORDER BY B.FULLNAME";

            using (DataTable DT = DB.getS(queryString, null, "GET EMPLOYEE", false))
            {
                foreach (DataRow row in DT.Rows)
                {
                    deposit_by.Items.Add(new ComboItem(Convert.ToInt32(row["EMP_ID"].ToString()), row["FULLNAME"].ToString()));
                    withdraw_by.Items.Add(new ComboItem(Convert.ToInt32(row["EMP_ID"].ToString()), row["FULLNAME"].ToString()));
                }
            }
            deposit_by.SelectedIndex = 0;
            withdraw_by.SelectedIndex = 0;

            GF.resizeComboBox(deposit_by);
            GF.resizeComboBox(withdraw_by);

            type.Items.Add(new ComboItem(-1, "ALL"));
            type.Items.Add(new ComboItem(0, "IN"));
            type.Items.Add(new ComboItem(1, "OUT"));
            type.Items.Add(new ComboItem(2, "VOID"));
            type.SelectedIndex = 0;
            GF.resizeComboBox(type);

            btn_dgv.refresh_btn.Text = "SEARCH BY BARCODE";
            btn_dgv.refresh_btn.Width = 209;
            btn_dgv.search_btn.Visible = false;

            //UC EVENTS
            btn_dgv.DeleteClick += new btn_dgv.DeleteClickHandler(DeleteClick);
            btn_dgv.RefreshClick += new btn_dgv.RefreshClickHandler(BarcodeClick);

            //PAGING DELEGATE
            btn_dgv.firstClick += new btn_dgv.firstClickHandler(doLoadGridData);
            btn_dgv.prevClick += new btn_dgv.prevClickHandler(doLoadGridData);
            btn_dgv.nextClick += new btn_dgv.nextClickHandler(doLoadGridData);
            btn_dgv.lastClick += new btn_dgv.lastClickHandler(doLoadGridData);
            btn_dgv.pageNumberChanged += new btn_dgv.pageNumberChangedHandler(doLoadGridData);
        }

        // DELEGATE PART :: BEGIN
        void BarcodeClick(object sender, EventArgs e) // ปุ่ม Scan Barcode
        {
            GF.selected_id = 0;
            item_code.Text = "";
            item_name.Text = "";
            item_cat.SelectedIndex = 0;

            if (btn_dgv.refresh_btn.Text == "SEARCH BY BARCODE")
            {
                barcodeItemID = -1;
                using (scan_barcode scan = new scan_barcode())
                {
                    scan.Mode = "PRODUCT";
                    scan.Owner = this;
                    scan.ShowDialog();
                }
                if (barcodeItemID != -1) btn_dgv.refresh_btn.Text = "CLEAR RESULT";
            }
            else if (btn_dgv.refresh_btn.Text == "CLEAR RESULT")
            {
                barcodeItemID = -1;
                btn_dgv.refresh_btn.Text = "SEARCH BY BARCODE";
                loadGridData();
            }
        }
        void DeleteClick(object sender, EventArgs e) // ปุ่ม WITHDRAW
        {
            DataGridViewCellCollection cell = btn_dgv.DGV.SelectedRows[0].Cells;

            if (cell["TYPE"].Value.ToString() == "VOID")
            {
                MessageBox.Show("THIS TRANSACTION IS ALREADY VOIDED !!", "ERROR");
                return;
            }
            else if (cell[8].Value.ToString().IndexOf("BY BILL") != -1)
            {
                MessageBox.Show("YOU CANNOT VOID THE TRANSACTION OF SYSTEM !!", "ERROR");
                return;
            }
            else
            {
                using (store_void managePage = new store_void())
                {
                    managePage.Owner = this;
                    managePage.Text = "VOID STORE TRANSACTION";

                    managePage.id = Int32.Parse(cell["STORE_HISTORY_DETAIL_ID"].Value.ToString());
                    managePage.item_code.Text = cell["ITEM_CODE"].Value.ToString();
                    managePage.item_cat.Text = cell["ITEM_CAT"].Value.ToString();
                    managePage.item_name.Text = cell["ITEM_NAME"].Value.ToString();
                    managePage.amount.Text = cell["AMOUNT"].Value.ToString();
                    managePage.type.Text = cell["TYPE"].Value.ToString();
                    managePage.by.Text = cell["BY"].Value.ToString();
                    managePage.on.Text = cell["ON"].Value.ToString();

                    managePage.ShowDialog();
                }
            }
        }

        void doLoadGridData(object sender, EventArgs e)
        {
            item_code_lbl.Top = item_name_lbl.Top = item_cat_lbl.Top = GF.pageTop;
            item_code.Top = item_name.Top = item_name_lbl.Top - 3;
            item_cat.Top = item_name_lbl.Top - 6;

            type_lbl.Top = withdraw_by_lbl.Top = deposit_by_lbl.Top = item_name_lbl.Top + 27;
            type.Top = withdraw_by.Top = deposit_by.Top = withdraw_by_lbl.Top - 6;
            type.Top = withdraw_by_lbl.Top - 3;

            line_sep.Top = type_lbl.Top + 35; line_sep.Width = btn_dgv.Width;
            btn_dgv.rearrange(line_sep.Top + 15);

            btn_dgv.add_btn.Visible = false;
            btn_dgv.edit_btn.Visible = false;
            btn_dgv.del_btn.Text = "VOID";

            GF.resetAC(this);
            loadGridData();
        }
        // DELEGATE PART :: END

        public void loadGridData()
        {
            GF.showLoading(this);
            this.btn_dgv.DGV.Visible = false;
            this.btn_dgv.DGV.Rows.Clear();

            if (btn_dgv.DGV.Columns.Count == 0)
            {
                this.btn_dgv.DGV.Columns.Add("on", "DATE");
                this.btn_dgv.DGV.Columns.Add("type", "TYPE");
                this.btn_dgv.DGV.Columns.Add("item_code", "CODE");
                this.btn_dgv.DGV.Columns.Add("item_name", "ITEM NAME");
                this.btn_dgv.DGV.Columns.Add("item_cat", "ITEM CATEGORY");
                this.btn_dgv.DGV.Columns.Add("amount", "AMOUNT");
                this.btn_dgv.DGV.Columns.Add("by", "BY");
                this.btn_dgv.DGV.Columns.Add("reason", "REASON");
                this.btn_dgv.DGV.Columns.Add("store_history_detail_id", "STORE_HISTORY_DETAIL_ID");
                this.btn_dgv.DGV.Columns["store_history_detail_id"].Visible = false;
            }

            // GET TOTAL PAGE
            String queryString = @"SELECT 
                B.STORE_HISTORY_DETAIL_ID,
                A.TYPE,
                A.HISTORY_DATE HISTORY_DATETIME,
                CONVERT(VARCHAR,A.HISTORY_DATE,103) + ' ' + CONVERT(VARCHAR,A.HISTORY_DATE,108) HISTORY_DATE,
                A.DEPOSIT_BY,
	            CASE
		            WHEN A.deposit_by = 0 THEN 'S.A.' ELSE E.fullname
	            END DEPOSIT_NAME,
                A.WITHDRAW_BY,
	            CASE
		            WHEN A.withdraw_by = 0 THEN 'S.A.' ELSE F.fullname
	            END WITHDRAW_NAME,
	            A.withdraw_reason,
	            B.AMOUNT,
                C.ITEM_CODE,
	            C.ITEM_NAME, 
	            D.ITEM_TYPE_NAME,
	            CASE
		            WHEN B.void_by = 0 THEN 'S.A.' ELSE G.fullname
	            END VOID_BY,
	            B.VOID_REASON,
	            CONVERT(VARCHAR,B.void_datetime,103) + ' ' + CONVERT(VARCHAR,B.void_datetime,108) VOID_DATETIME
            FROM STORE_HISTORY A
            INNER JOIN STORE_HISTORY_DETAIL B ON A.store_history_id = B.store_history_id
            INNER JOIN ITEM C ON B.item_id = C.item_id
            INNER JOIN ITEM_TYPE D ON C.item_type_id = D.item_type_id
            LEFT OUTER JOIN EMPLOYEE E ON A.deposit_by = E.emp_id
            LEFT OUTER JOIN EMPLOYEE F ON A.withdraw_by = F.emp_id
            LEFT OUTER JOIN EMPLOYEE G ON B.void_by = G.emp_id 
            WHERE 1=1";

            Dictionary<string, string> Params = new Dictionary<string, string>();

            if (item_code.Text.Trim() != "")
            {
                queryString += " AND C.ITEM_CODE LIKE '" + item_code.Text + "%'";
                //Params.Add("@item_code", item_code.Text);
            }
            if (item_name.Text.Trim() != "")
            {
                queryString += " AND C.ITEM_NAME LIKE '%" + item_name.Text + "%'";
                //Params.Add("@item_name", item_name.Text);
            }
            if (item_cat.SelectedIndex > 0) queryString += " AND C.ITEM_TYPE_ID = " + ((ComboItem)item_cat.SelectedItem).Key.ToString();
            if (type.SelectedIndex > 0) queryString += " AND A.TYPE = " + ((ComboItem)type.SelectedItem).Key.ToString();
            if (deposit_by.SelectedIndex > 0) queryString += " AND A.DEPOSIT_BY = " + ((ComboItem)deposit_by.SelectedItem).Key.ToString();
            if (withdraw_by.SelectedIndex > 0) queryString += " AND A.WITHDRAW_BY = " + ((ComboItem)withdraw_by.SelectedItem).Key.ToString();

            GF.getTotalPage(btn_dgv, queryString, Params);

            queryString = DB.insertRowNum("A.HISTORY_DATETIME DESC", queryString);

            using (DataTable myDT = DB.getS(queryString, Params, "GET ALL STORE_HISTORY_DETAIIL"))
            {
                int rowNum = 0;
                foreach (DataRow myRow in myDT.Rows)
                {
                    string deposit_name = "";
                    switch (myRow["DEPOSIT_BY"].ToString())
                    {
                        case "-1": deposit_name = "SYSTEM"; break;
                        case "0": deposit_name = "S.A."; break;
                        default: deposit_name = myRow["DEPOSIT_NAME"].ToString(); break;
                    }

                    string withdraw_name = "";
                    switch (myRow["WITHDRAW_BY"].ToString())
                    {
                        case "-1": withdraw_name = "BILL"; break;
                        case "0": withdraw_name = "S.A."; break;
                        default: withdraw_name = myRow["WITHDRAW_NAME"].ToString(); break;
                    }

                    this.btn_dgv.DGV.Rows.Add(
                        (myRow["VOID_DATETIME"].ToString() != "") ? myRow["VOID_DATETIME"] : myRow["HISTORY_DATE"],
                        (myRow["VOID_BY"].ToString() != "NULL" && myRow["VOID_BY"].ToString() != "") ? "VOID" : ((myRow["type"].ToString() == "0") ? "IN" : "OUT"),
                        myRow["item_code"],
                        myRow["item_name"],
                        myRow["item_type_name"],
                        myRow["amount"],
                        (myRow["VOID_BY"].ToString() != "NULL" && myRow["VOID_BY"].ToString() != "") ? myRow["void_by"] : ((myRow["type"].ToString() == "0") ? deposit_name : withdraw_name),
                        (myRow["VOID_BY"].ToString() != "NULL" && myRow["VOID_BY"].ToString() != "") ? myRow["void_reason"] : ((myRow["type"].ToString() == "0") ? "" : myRow["withdraw_reason"]),
                        myRow["store_history_detail_id"]
                    );

                    this.btn_dgv.DGV[0, rowNum].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    this.btn_dgv.DGV[3, rowNum].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    this.btn_dgv.DGV[7, rowNum].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    rowNum++;
                }
            }
            
            GF.updateRowNum(btn_dgv.DGV, true);
            this.btn_dgv.DGV.Refresh();
            this.btn_dgv.DGV.Visible = true;
            GF.closeLoading();
        }

        private void item_code_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) loadGridData();
        }

        private void item_name_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) loadGridData();
        }

        private void item_cat_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadGridData();
        }

        private void type_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadGridData();
        }

        private void deposit_by_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadGridData();
        }

        private void withdraw_by_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadGridData();
        }
    }
}
