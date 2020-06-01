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
    public partial class item_categories : Form
    {
        public item_categories()
        {
            InitializeComponent();

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
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO ENABLE THIS ITEM CATEGORY ?", "ENABLE ITEM CATEGORY", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GF.showLoading(this);
                DB.beginTrans();
                if (DB.set("UPDATE ITEM_TYPE SET is_use = 1 WHERE item_type_id = " + GF.selected_id, "ENABLE ITEM TYPE"))
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

            using (item_category_manage managePage = new item_category_manage())
            {
                managePage.Owner = this;
                managePage.manage_btn.Text = "ADD";
                managePage.Text = "ADD CATEGORY";

                managePage.ShowDialog();
            }
        }
        void EditClick(object sender, EventArgs e)
        {
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells[btn_dgv.DGV.Columns.Count - 1].Value);

            using (item_category_manage managePage = new item_category_manage())
            {
                managePage.Owner = this;
                managePage.manage_btn.Text = "UPDATE";
                managePage.Text = "EDIT CATEGORY";

                managePage.ShowDialog();
            }
        }
        void DeleteClick(object sender, EventArgs e)
        {
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells[btn_dgv.DGV.Columns.Count - 1].Value);
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO DISABLE THIS ITEM CATEGORY ?", "DISABLE ITEM CATEGORY", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GF.showLoading(this);
                DB.beginTrans();
                if (DB.set("UPDATE ITEM_TYPE SET is_use = 0 WHERE item_type_id = " + GF.selected_id, "DISABLE ITEM TYPE"))
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
            item_cat_lbl.Top = GF.pageTop;
            item_cat.Top = item_cat_lbl.Top - 5;

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
                this.btn_dgv.DGV.Columns.Add("item_type_name", "ITEM CATEGORY NAME");
                this.btn_dgv.DGV.Columns.Add("is_use", "STATUS");
                this.btn_dgv.DGV.Columns.Add("item_type_id", "ITEM TYPE ID");
                this.btn_dgv.DGV.Columns["item_type_id"].Visible = false;
            }

            Dictionary<string, string> Params = null;
            String queryString = "SELECT * FROM ITEM_TYPE WHERE 1=1";
            if (item_cat.Text.Trim() != "")
            {
                queryString += " AND item_type_name LIKE '%' + @item_cat + '%'";
                Params = new Dictionary<string, string>();
                Params.Add("@item_cat", item_cat.Text);
            }

            // GET TOTAL PAGE
            GF.getTotalPage(btn_dgv, "SELECT COUNT(*) AS TOTAL FROM ITEM_TYPE", Params);

            using (DataTable myDT = DB.getS(DB.insertRowNum("item_type_name ASC, is_use DESC", queryString), Params, "GET ALL ITEM CATAGORIES"))
            {
                int rowNum = 0;
                foreach (DataRow myRow in myDT.Rows)
                {
                    this.btn_dgv.DGV.Rows.Add(
                        myRow["item_type_name"],
                        (myRow["is_use"].ToString() == "1" ? "ACTIVE" : "INACTIVE"),
                        myRow["item_type_id"]
                    );

                    this.btn_dgv.DGV["is_use", rowNum].Style.ForeColor = (myRow["is_use"].ToString() == "1" ? Color.Green : Color.Red);
                    this.btn_dgv.DGV[0, rowNum].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    this.btn_dgv.DGV.ClearSelection();
                    rowNum++;
                }
            }
            GF.updateRowNum(btn_dgv.DGV, true);
            this.btn_dgv.DGV.Refresh();
            this.btn_dgv.DGV.Visible = true;
            GF.closeLoading();
        }
    }
}
