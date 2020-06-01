using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.SPA
{
    public partial class spa_item : Form
    {
        int currentItemID = -1;
        public spa_item()
        {
            InitializeComponent();

            GF.addKeyUp(this);
            item_detail_lbl.Text = "";

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
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells["SPA_ITEM_ID"].Value);
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO ENABLE THIS SPA ITEM ?", "ENABLE SPA ITEM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GF.showLoading(this);
                DB.beginTrans();
                string queryString = "UPDATE SPA_ITEM SET IS_USE = 1 WHERE SPA_ITEM_ID = " + GF.selected_id.ToString();
                if (!DB.set(queryString, "ENABLE SPA_ITEM[" + GF.selected_id.ToString() + "]"))
                {
                    MessageBox.Show("ERROR ENABLE SPA_ITEM[" + GF.selected_id.ToString() + "]", "ERROR");
                    GF.closeLoading();
                    DB.rollbackTrans();
                    return;
                }
                else
                {
                    GF.closeLoading();
                    DB.close();
                    loadGridData();
                    return;
                }
            }
        }
        void AddClick(object sender, EventArgs e)
        {
            GF.selected_id = 0;

            using (spa_item_manage managePage = new spa_item_manage())
            {
                managePage.Owner = this;
                managePage.manage_btn.Text = "ADD";
                managePage.Text = "ADD SPA ITEM";

                managePage.ShowDialog();
            }
        }
        void EditClick(object sender, EventArgs e)
        {
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells["spa_item_id"].Value);

            using (spa_item_manage managePage = new spa_item_manage())
            {
                managePage.Owner = this;
                managePage.manage_btn.Text = "UPDATE";
                managePage.Text = "EDIT SPA ITEM";

                managePage.ShowDialog();
            }
        }
        void DeleteClick(object sender, EventArgs e)
        {
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells["SPA_ITEM_ID"].Value);
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO DISABLE THIS SPA ITEM ?", "DISABLE SPA ITEM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GF.showLoading(this);
                DB.beginTrans();
                string queryString = "UPDATE SPA_ITEM SET IS_USE = 0 WHERE SPA_ITEM_ID = " + GF.selected_id.ToString();
                if (!DB.set(queryString, "DISABLE SPA_ITEM[" + GF.selected_id.ToString() + "]"))
                {
                    MessageBox.Show("ERROR DISABLE SPA_ITEM[" + GF.selected_id.ToString() + "]", "ERROR");
                    GF.closeLoading();
                    DB.rollbackTrans();
                    return;
                }
                else
                {
                    GF.closeLoading();
                    DB.close();
                    loadGridData();
                    return;
                }
            }
        }

        void doLoadGridData(object sender, EventArgs e)
        {
            item_code_lbl.Top = item_detail_lbl.Top = GF.pageTop;
            item_code.Top = item_code_lbl.Top - 3;

            line_sep.Top = item_code_lbl.Top + 28;
            line_sep.Width = btn_dgv.Width - 4;

            btn_dgv.rearrange(line_sep.Top + 12);
            GF.resetAC(this);
            loadGridData();
        }
        // DELEGATE PART :: END

        public void loadGridData()
        {
            GF.showLoading(this);
            this.btn_dgv.DGV.Rows.Clear();

            // GET TOTAL PAGE
            string queryString = @"SELECT
                A.spa_item_id,
	            B.item_code,
	            B.item_name,
	            c.item_type_name,
	            A.price,
	            CONVERT(VARCHAR,A.last_change,103) last_change,
                A.is_use
            FROM SPA_ITEM A
            INNER JOIN ITEM B ON A.item_id = B.item_id
            INNER JOIN ITEM_TYPE C ON B.item_type_id = C.item_type_id
            WHERE 1=1";

            Dictionary<string, string> Params = null;

            if (item_code.Text.Trim() != "")
            {
                queryString += " AND B.item_code LIKE @item_code";
                Params = new Dictionary<string, string>();
                Params.Add("@item_code", item_code.Text);
            }

            GF.getTotalPage(btn_dgv, queryString, Params);

            queryString = DB.insertRowNum("ITEM_NAME ASC", queryString);
            using (DataTable myDT = DB.getS(queryString, Params, "GET ALL SPA_ITEM"))
            {
                if (btn_dgv.DGV.Columns.Count == 0)
                {
                    this.btn_dgv.DGV.Columns.Add("item_code", "CODE");
                    this.btn_dgv.DGV.Columns.Add("item_name", "ITEM NAME");
                    this.btn_dgv.DGV.Columns.Add("item_cat", "CATEGORY");
                    this.btn_dgv.DGV.Columns.Add("price", "PRICE");
                    this.btn_dgv.DGV.Columns.Add("last_change", "LAST CHANGE");
                    this.btn_dgv.DGV.Columns.Add("is_use", "ACTIVE");
                    this.btn_dgv.DGV.Columns.Add("spa_item_id", "SPA_ITEM_ID");
                    this.btn_dgv.DGV.Columns["spa_item_id"].Visible = false;
                }

                int rowNum = 0;
                foreach (DataRow myRow in myDT.Rows)
                {
                    this.btn_dgv.DGV.Rows.Add(
                        myRow["item_code"],
                        myRow["item_name"],
                        myRow["item_type_name"],
                        GF.formatNumber(Int32.Parse(myRow["price"].ToString())),
                        myRow["last_change"],
                        (myRow["is_use"].ToString() == "1" ? "ACTIVE" : "INACTIVE"),
                        myRow["spa_item_id"]
                    );
                    this.btn_dgv.DGV["is_use", rowNum].Style.ForeColor = (myRow["is_use"].ToString() == "1" ? Color.Green : Color.Red);
                    this.btn_dgv.DGV[1, rowNum].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    rowNum++;
                }
            }
            GF.updateRowNum(btn_dgv.DGV, true);
            this.btn_dgv.DGV.ClearSelection();
            GF.closeLoading();
        }

        private void item_code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (item_code.Text.Trim() != "")
                {
                    DataRow myDR = DB.getDataFromCode(item_code);
                    if (myDR == null)
                    {
                        MessageBox.Show("NO ITEM WITH THIS CODE !!", "ERROR");
                        item_code.Text = "";
                        return;
                    }
                    else
                    {
                        Int32.TryParse(myDR["ITEM_ID"].ToString(), out currentItemID);
                        item_detail_lbl.Text = "ITEM DETAIL : " + myDR["ITEM_NAME"].ToString() + " (" + myDR["ITEM_TYPE_NAME"].ToString() + ")";
                        SendKeys.Send("{TAB}");
                    }
                }
            }
        }

        private void item_code_TextChanged(object sender, EventArgs e)
        {
            if (currentItemID != -1)
            {
                item_code.Text = "";
                currentItemID = -1;
                item_detail_lbl.Text = "";
            }
        }
    }
}
