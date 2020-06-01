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
    public partial class selling_price : Form
    {
        public selling_price()
        {
            InitializeComponent();

            GF.addKeyUp(this);

            btn_dgv.DGV.SelectionChanged += (ss, ee) =>
            {
                if (btn_dgv.DGV.SelectedRows.Count == 1)
                {
                    if (btn_dgv.DGV.SelectedRows[0].Cells["status"].Value.ToString() == "ACTIVE")
                    {
                        btn_dgv.del_btn.Text = "DISABLE";
                    }

                    if (btn_dgv.DGV.SelectedRows[0].Cells["status"].Value.ToString() == "INACTIVE")
                    {
                        btn_dgv.del_btn.Text = "ENABLE";
                    }
                }
            };

            //UC EVENTS
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
        void AddClick(object sender, EventArgs e)
        {
            GF.selected_id = 0;

            using (selling_price_manage managePage = new selling_price_manage())
            {
                managePage.Owner = this;
                managePage.manage_btn.Text = "ADD";
                managePage.Text = "ADD ITEM PRICE";

                managePage.ShowDialog();
            }
        }
        void EditClick(object sender, EventArgs e)
        {
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells["item_price_id"].Value);

            using (selling_price_manage managePage = new selling_price_manage())
            {
                managePage.Owner = this;
                managePage.manage_btn.Text = "UPDATE";
                managePage.Text = "EDIT ITEM PRICE";

                managePage.ShowDialog();
            }
        }
        void DeleteClick(object sender, EventArgs e)
        {
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells["ITEM_PRICE_ID"].Value);
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO " + btn_dgv.del_btn.Text + " THIS ITEM PRICE ?", btn_dgv.del_btn.Text + " ITEM PRICE", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GF.showLoading(this);
                DB.beginTrans();
                string queryString = "UPDATE ITEM_PRICE SET IS_USE = " + (btn_dgv.del_btn.Text == "ENABLE" ? "1" : "0") + " WHERE ITEM_PRICE_ID = " + GF.selected_id.ToString();
                if (!DB.set(queryString, btn_dgv.del_btn.Text + " ITEM_PRICE[" + GF.selected_id.ToString() + "]"))
                {
                    MessageBox.Show("ERROR " + btn_dgv.del_btn.Text + " ITEM_PRICE[" + GF.selected_id.ToString() + "]", "ERROR");
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
            code_lbl.Top = GF.pageTop;
            code.Top = code_lbl.Top - 3;

            line_sep.Top = code_lbl.Top + 28;
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
                A.item_price_id,
                A.apply_discount,
	            B.item_code,
	            B.item_name,
	            c.item_type_name,
	            A.price,
                A.is_use,
	            CONVERT(VARCHAR,A.last_change,103) last_change
            FROM ITEM_PRICE A
            INNER JOIN ITEM B ON A.item_id = B.item_id
            INNER JOIN ITEM_TYPE C ON B.item_type_id = C.item_type_id
            WHERE 1=1";
            
            Dictionary<string, string> Params = null;

            if (code.Text.Trim() != "")
            {
                queryString += " AND (B.item_code LIKE '%' + @code + '%' OR B.BARCODE LIKE '%' + @code + '%')";
                Params = new Dictionary<string, string>();
                Params.Add("@code", code.Text);
            }

            GF.getTotalPage(btn_dgv, queryString, Params);
            
            queryString = DB.insertRowNum("CONVERT(FLOAT, ITEM_CODE) ASC", queryString);
            using (DataTable myDT = DB.getS(queryString, Params, "GET ALL ITEM_PRICE"))
            {
                if (btn_dgv.DGV.Columns.Count == 0)
                {
                    this.btn_dgv.DGV.Columns.Add("item_code", "CODE");
                    this.btn_dgv.DGV.Columns.Add("item_name", "ITEM NAME");
                    this.btn_dgv.DGV.Columns.Add("item_cat", "CATEGORY");
                    this.btn_dgv.DGV.Columns.Add("price", "PRICE");
                    this.btn_dgv.DGV.Columns.Add("apply_discount", "APPLY DISCOUNT");
                    this.btn_dgv.DGV.Columns.Add("last_change", "LAST CHANGE");
                    this.btn_dgv.DGV.Columns.Add("status", "STATUS");
                    this.btn_dgv.DGV.Columns.Add("item_price_id", "ITEM_PRICE_ID");
                    this.btn_dgv.DGV.Columns["item_price_id"].Visible = false;
                }

                int rowNum = 0;
                foreach (DataRow myRow in myDT.Rows)
                {
                    this.btn_dgv.DGV.Rows.Add(
                        myRow["item_code"],
                        myRow["item_name"],
                        myRow["item_type_name"],
                        GF.formatNumber(Int32.Parse(myRow["price"].ToString())),
                        "",
                        myRow["last_change"],
                        (myRow["is_use"].ToString() == "1" ? "ACTIVE" : "INACTIVE"),
                        myRow["item_price_id"]
                    );
                    if (myRow["APPLY_DISCOUNT"].ToString() == "1")
                        this.btn_dgv.DGV[4, rowNum].Style.BackColor = Color.LightGreen;
                    else
                        this.btn_dgv.DGV[4, rowNum].Style.BackColor = Color.LightCoral;
                    this.btn_dgv.DGV[1, rowNum].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

                    if (myRow["is_use"].ToString() == "1") btn_dgv.DGV[6, rowNum].Style.ForeColor = Color.Green;
                    else btn_dgv.DGV[6, rowNum].Style.ForeColor = Color.Red;

                    rowNum++;
                }
            }
            GF.updateRowNum(btn_dgv.DGV, true);
            this.btn_dgv.DGV.ClearSelection();
            GF.closeLoading();
        }
    }
}
