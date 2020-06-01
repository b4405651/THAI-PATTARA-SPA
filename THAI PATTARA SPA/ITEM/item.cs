using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.ITEM
{
    public partial class item : Form
    {
        public item()
        {
            InitializeComponent();

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
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells[btn_dgv.DGV.Columns.Count - 1].Value);
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO ENABLE THIS ITEM ?", "ENABLE ITEM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GF.showLoading(this);
                DB.beginTrans();
                if (DB.set("UPDATE ITEM SET is_use = 1 WHERE item_id = " + GF.selected_id, "ENABLE ITEM"))
                {
                    DB.close();
                    GF.closeLoading();
                    btn_dgv.refresh_btn.PerformClick();
                }
                else
                {
                    GF.closeLoading();
                    MessageBox.Show("ERROR ENABLE DATA !!", "ERROR");
                    return;
                }
            }
        }
        void AddClick(object sender, EventArgs e)
        {
            GF.selected_id = 0;

            using (item_manage managePage = new item_manage())
            {
                managePage.Owner = this;
                managePage.manage_btn.Text = "ADD";
                managePage.Text = "ADD ITEM";

                //managePage.manage_btn.Top -= 30;

                managePage.ShowDialog();
            }
        }
        void EditClick(object sender, EventArgs e)
        {
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells[btn_dgv.DGV.Columns.Count - 1].Value);

            using (item_manage managePage = new item_manage())
            {
                managePage.Owner = this;
                managePage.manage_btn.Text = "UPDATE";
                managePage.Text = "EDIT ITEM";

                managePage.ShowDialog();
            }
        }
        void DeleteClick(object sender, EventArgs e)
        {
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells[btn_dgv.DGV.Columns.Count - 1].Value);
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO DISABLE THIS ITEM ?", "DISABLE ITEM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GF.showLoading(this);
                DB.beginTrans();
                if (DB.set("UPDATE ITEM SET is_use = 0 WHERE item_id = " + GF.selected_id, "DISABLE ITEM"))
                {
                    DB.close();
                    GF.closeLoading();
                    btn_dgv.refresh_btn.PerformClick();
                }
                else
                {
                    GF.closeLoading();
                    MessageBox.Show("ERROR DISABLE DATA !!", "ERROR");
                    return;
                }
            }
        }

        void doLoadGridData(object sender, EventArgs e)
        {
            item_code_lbl.Top = GF.pageTop;
            code.Top = item_code_lbl.Top - 3;

            item_cat_lbl.Top = item_name_lbl.Top = item_code_lbl.Top + 27;
            item_name.Top = item_cat_lbl.Top - 3;
            item_cat.Top = item_name.Top - 3;

            line_sep1.Top = item_cat_lbl.Top + 35; line_sep1.Width = btn_dgv.Width;
            btn_dgv.rearrange(line_sep1.Top + 15);

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
                this.btn_dgv.DGV.Columns.Add("item_code", "CODE");
                this.btn_dgv.DGV.Columns.Add("item_name", "ITEM NAME");
                this.btn_dgv.DGV.Columns.Add("item_type_name", "ITEM CATEGORY NAME");
                this.btn_dgv.DGV.Columns.Add("unit", "UNIT");
                this.btn_dgv.DGV.Columns.Add("barcode", "BARCODE");
                this.btn_dgv.DGV.Columns.Add("is_use", "ACTIVE");
                this.btn_dgv.DGV.Columns.Add("item_id", "ITEM ID");
                this.btn_dgv.DGV.Columns["item_id"].Visible = false;
                this.btn_dgv.DGV.Columns["item_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            Dictionary<string, string> Params = new Dictionary<string, string>();

            String queryString = @"SELECT A.ITEM_ID, A.ITEM_NAME, A.ITEM_CODE , A.IS_USE, A.BARCODE, B.ITEM_TYPE_NAME, C.UNIT_NAME FROM ITEM A
            INNER JOIN ITEM_TYPE B ON A.item_type_id = B.item_type_id
            INNER JOIN UNIT C ON A.UNIT_ID = C.UNIT_ID 
            WHERE 1=1";

            if (code.Text.Trim() != "")
            {
                queryString += " AND (A.item_code LIKE '%' + " + code.Text + " + '%' OR A.barcode LIKE '%' + " + code.Text + " + '%')";
                //Params.Add("@code", code.Text);
            }
            if (item_name.Text.Trim() != "")
            {
                queryString += " AND A.item_name LIKE N'%' + " + item_name.Text + " + '%'";
                //Params.Add("@item_name", item_name.Text);
            }
            if (item_cat.SelectedIndex > 0) queryString += " AND A.item_type_id = " + ((ComboItem)item_cat.SelectedItem).Key.ToString();

            // GET TOTAL PAGE
            GF.getTotalPage(btn_dgv, queryString, Params);

            queryString = DB.insertRowNum("CONVERT(FLOAT, item_code) ASC, item_type_name asc, is_use DESC", queryString);
            GF.doDebug(">>>> " + queryString);
            using (DataTable myDT = DB.getS(queryString, Params, "GET ALL ITEM"))
            {
                int rowNum = 0;
                foreach (DataRow myRow in myDT.Rows)
                {
                    this.btn_dgv.DGV.Rows.Add(
                        myRow["item_code"],
                        myRow["item_name"],
                        myRow["item_type_name"],
                        myRow["unit_name"],
                        myRow["barcode"],
                        (myRow["is_use"].ToString() == "1" ? "ACTIVE" : "INACTIVE"),
                        myRow["item_id"]
                    );

                    this.btn_dgv.DGV["is_use", rowNum].Style.ForeColor = (myRow["is_use"].ToString() == "1" ? Color.Green : Color.Red);
                    rowNum++;
                }
            }
            GF.updateRowNum(btn_dgv.DGV, true);
            this.btn_dgv.DGV.Refresh();
            this.btn_dgv.DGV.Visible = true;
            this.btn_dgv.DGV.ClearSelection();
            GF.closeLoading();
        }

        private void item_code_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) loadGridData();
        }

        private void item_cat_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) loadGridData();
        }

        private void item_name_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) loadGridData();
        }

    }
}
