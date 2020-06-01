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
    public partial class store : Form
    {
        public int barcodeItemID = -1;
        public store()
        {
            InitializeComponent();

            code_lbl.Top = item_name_lbl.Top = item_cat_lbl.Top = GF.pageTop;
            code.Top = item_name.Top = item_name_lbl.Top - 3;

            line_sep.Top = item_name_lbl.Top + 35; line_sep.Width = btn_dgv.Width;

            btn_dgv.preventDGVSelectionChanged = true;
            btn_dgv.edit_btn.Visible = false;
            //btn_dgv.add_btn.Left = btn_dgv.edit_btn.Left;

            btn_dgv.del_btn.Text = "OUT";// btn_dgv.del_btn.Width = 146; btn_dgv.del_btn.Left = 1749;
            btn_dgv.add_btn.Text = "IN"; btn_dgv.add_btn.Left = btn_dgv.del_btn.Left - btn_dgv.add_btn.Width - 5;

            btn_dgv.refresh_btn.Text = "SEARCH BY BARCODE"; btn_dgv.refresh_btn.Width = 209;
            //btn_dgv.search_btn.Left = btn_dgv.refresh_btn.Left + btn_dgv.refresh_btn.Width + 5;

            btn_dgv.search_btn.Visible = false;

            item_cat.Items.Clear();
            item_cat.Items.Add(new ComboItem(-1, "== CATEGORY =="));
            string queryString = "SELECT * FROM ITEM_TYPE WHERE IS_USE = 1 ORDER BY ITEM_TYPE_NAME ASC";
            using (DataTable DT = DB.getS(queryString, null, "GET ITEM CATEGORIES", false))
            {
                foreach (DataRow row in DT.Rows)
                {
                    item_cat.Items.Add(new ComboItem(Convert.ToInt32(row["ITEM_TYPE_ID"].ToString()), row["ITEM_TYPE_NAME"].ToString()));
                }
            }
            item_cat.SelectedIndex = 0;

            GF.enableButton(btn_dgv.del_btn);

            //UC EVENTS
            btn_dgv.AddClick += new btn_dgv.AddClickHandler(AddClick);
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
            code.Text = "";
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
            } else if (btn_dgv.refresh_btn.Text == "CLEAR RESULT")
            {
                barcodeItemID = -1;
                btn_dgv.refresh_btn.Text = "SEARCH BY BARCODE";
                loadGridData();
            }
        }
        void AddClick(object sender, EventArgs e) // ปุ่ม DEPOSIT
        {
            GF.selected_id = 0;

            using (store_manage managePage = new store_manage())
            {
                managePage.Owner = this;
                managePage.Text = "DEPOSIT STORE";

                managePage.ShowDialog();
            }
        }
        void DeleteClick(object sender, EventArgs e) // ปุ่ม WITHDRAW
        {
            using (store_manage managePage = new store_manage())
            {
                managePage.Owner = this;
                managePage.Text = "WITHDRAW STORE";

                managePage.ShowDialog();
            }
        }

        void doLoadGridData(object sender, EventArgs e)
        {
            btn_dgv.rearrange(line_sep.Top + 15);
            GF.resetAC(this);
            loadGridData();
        }
        // DELEGATE PART :: END

        public void loadGridData()
        {
            GF.showLoading(this);
            this.btn_dgv.DGV.Rows.Clear();

            if (btn_dgv.DGV.Columns.Count == 0)
            {
                this.btn_dgv.DGV.Columns.Add("item_code", "CODE");
                this.btn_dgv.DGV.Columns.Add("item_name", "ITEM NAME");
                this.btn_dgv.DGV.Columns.Add("item_cat", "ITEM CATEGORY");
                this.btn_dgv.DGV.Columns.Add("current_amount", "AMOUNT");
                this.btn_dgv.DGV.Columns.Add("last_updated", "LAST UPDATE");
                this.btn_dgv.DGV.Columns["item_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            // GET TOTAL PAGE

            Dictionary<string, string> Params = new Dictionary<string, string>();

            String queryString = @"SELECT 
            A.CURRENT_AMOUNT, B.ITEM_CODE, B.ITEM_NAME, C.ITEM_TYPE_NAME, A.LAST_CHANGE
            FROM STORE A
            INNER JOIN ITEM B ON A.ITEM_ID = B.ITEM_ID
            INNER JOIN ITEM_TYPE C ON B.ITEM_TYPE_ID = C.ITEM_TYPE_ID 
            WHERE 1=1";

            if (code.Text.Trim() != "")
            {
                queryString += " AND (B.ITEM_CODE LIKE " + code.Text + " + '%' OR B.BARCODE = '" + code.Text + "')";
                //Params.Add("@code", code.Text);
            }
            if (item_name.Text.Trim() != "")
            {
                queryString += " AND B.ITEM_NAME LIKE '%" + item_name.Text + "%'";
                //Params.Add("@item_name", item_name.Text);
            }
            if (item_cat.SelectedIndex != 0) queryString += " AND B.ITEM_TYPE_ID = " + ((ComboItem)item_cat.SelectedItem).Key.ToString();
            if (barcodeItemID != -1) queryString += " AND B.ITEM_ID = " + barcodeItemID.ToString();

            GF.getTotalPage(btn_dgv, queryString, Params);

            queryString = DB.insertRowNum("ITEM_TYPE_NAME", queryString);

            using (DataTable myDT = DB.getS(queryString, Params, "GET ALL ITEM IN STORE"))
            {
                foreach (DataRow myRow in myDT.Rows)
                {
                    this.btn_dgv.DGV.Rows.Add(
                        myRow["item_code"],
                        myRow["item_name"],
                        myRow["item_type_name"],
                        GF.formatNumber(Int32.Parse(myRow["current_amount"].ToString())),
                        GF.formatDateTime(myRow["LAST_CHANGE"].ToString())
                    );
                }
            }
            GF.updateRowNum(btn_dgv.DGV, true);
            this.btn_dgv.DGV.ClearSelection();
            GF.closeLoading();
        }

        private void item_code_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return) loadGridData();
        }

        private void item_name_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return) loadGridData();
        }

        private void item_cat_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadGridData();
        }
    }
}
