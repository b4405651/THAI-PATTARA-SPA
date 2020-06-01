using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.MEMBERSHIP
{
    public partial class config_member_card : Form
    {
        public config_member_card()
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
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO ENABLE THIS MEMBER CARD ?", "ENABLE MEMBER CARD", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GF.showLoading(this);
                DB.beginTrans();
                if (DB.set("UPDATE MEMBERCARD_TYPE SET is_use = 1 WHERE membercard_type_id = " + GF.selected_id, "ENABLE MEMBER CARD"))
                {
                    DB.close();
                    MessageBox.Show("MEMBER CARD IS ENABLED.", "COMPLETED");
                    GF.closeLoading();
                    btn_dgv.refresh_btn.PerformClick();
                    return;
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

            using (config_member_card_manage managePage = new config_member_card_manage())
            {
                managePage.Owner = this;
                managePage.manage_btn.Text = "ADD";
                managePage.Text = "ADD MEMBER CARD";

                managePage.ShowDialog();
            }
        }
        void EditClick(object sender, EventArgs e)
        {
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells["membercard_type_id"].Value);

            using (config_member_card_manage managePage = new config_member_card_manage())
            {
                managePage.Owner = this;
                managePage.manage_btn.Text = "UPDATE";
                managePage.Text = "EDIT MEMBER CARD";

                managePage.ShowDialog();
            }
        }
        void DeleteClick(object sender, EventArgs e)
        {
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells[btn_dgv.DGV.Columns.Count - 1].Value);
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO DISABLE THIS MEMBER CARD ?", "DISABLE MEMBER CARD", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GF.showLoading(this);
                DB.beginTrans();
                if (DB.set("UPDATE MEMBERCARD_TYPE SET is_use = 0 WHERE membercard_type_id = " + GF.selected_id, "DISABLE MEMBER CARD"))
                {
                    DB.close();
                    MessageBox.Show("MEMBER CARD IS DISABLED.", "COMPLETED");
                    GF.closeLoading();
                    btn_dgv.refresh_btn.PerformClick();
                    return;
                }
                else
                {
                    GF.closeLoading();
                    MessageBox.Show("ERROR DISABLED DATA !!", "ERROR");
                    return;
                }
            }
        }

        void doLoadGridData(object sender, EventArgs e)
        {
            card_name_lbl.Top = GF.pageTop;
            card_name.Top = card_name_lbl.Top - 3;

            line_sep1.Top = card_name_lbl.Top + 35; line_sep1.Width = btn_dgv.Width;
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
                this.btn_dgv.DGV.Columns.Add("membercard_name", "CARD NAME");
                this.btn_dgv.DGV.Columns.Add("discount", "DISCOUNT");
                this.btn_dgv.DGV.Columns.Add("credit", "CREDIT");
                this.btn_dgv.DGV.Columns.Add("price", "PRICE");
                this.btn_dgv.DGV.Columns.Add("expire", "EXPIRE");
                this.btn_dgv.DGV.Columns.Add("is_use", "ACTIVE");
                this.btn_dgv.DGV.Columns.Add("coupon_num", "COUPON");
                this.btn_dgv.DGV.Columns.Add("membercard_type_id", "MEMBER CARD ID");
                this.btn_dgv.DGV.Columns["membercard_type_id"].Visible = false;
            }

            // GET TOTAL PAGE
            Dictionary<string, string> Params = new Dictionary<string,string>();
            String queryString = "SELECT COUNT(*) AS TOTAL FROM MEMBERCARD_TYPE WHERE 1=1";
            if (card_name.Text.Trim() != "")
            {
                queryString += " AND MEMBERCARD_TYPE_NAME LIKE '%' + @card_name + '%'";
                Params.Add("@card_name", card_name.Text);
            }
            if (!show_disabled.Checked) queryString += " AND IS_USE = 1";
            
            queryString = @"SELECT * FROM MEMBERCARD_TYPE WHERE 1=1";

            if (card_name.Text.Trim() != "")
            {
                queryString += " AND MEMBERCARD_TYPE_NAME LIKE '%' + @card_name + '%'";
                Params.Add("@card_name", card_name.Text);
            }
            if (!show_disabled.Checked) queryString += " AND IS_USE = 1";

            GF.getTotalPage(btn_dgv, queryString, Params);

            queryString = DB.insertRowNum("MEMBERCARD_TYPE_NAME", queryString);
            GF.doDebug(">>>> " + queryString);
            using (DataTable myDT = DB.getS(queryString, Params, "GET ALL MEMBERCARD TYPE"))
            {
                int rowNum = 0;

                foreach (DataRow myRow in myDT.Rows)
                {
                    this.btn_dgv.DGV.Rows.Add(
                        myRow["membercard_type_name"],
                        GF.formatNumber(Convert.ToInt32(myRow["discount"].ToString())) + " %",
                        GF.formatNumber(Convert.ToInt32(myRow["credit"].ToString())),
                        GF.formatNumber(Convert.ToInt32(myRow["price"].ToString())),
                        (myRow["expire_amount"].ToString() == "0" ? "-" : myRow["expire_amount"].ToString() + " " + (myRow["expire_unit"].ToString() == "0" ? "MONTH" : "YEAR")),
                        (myRow["is_use"].ToString() == "1" ? "ACTIVE" : "INACTIVE"),
                        (myRow["complementary_spa_program_id"].ToString() == "" || myRow["complementary_spa_program_id"].ToString() == "NULL" ? "0" : myRow["complementary_spa_program_id"].ToString().Split(',').Length.ToString()),
                        myRow["membercard_type_id"]
                    );

                    this.btn_dgv.DGV["is_use", rowNum].Style.ForeColor = (myRow["is_use"].ToString() == "1" ? Color.Green : Color.Red);
                    this.btn_dgv.DGV[0, rowNum].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    rowNum++;
                }
            }

            GF.updateRowNum(btn_dgv.DGV, true);
            this.btn_dgv.DGV.Refresh();
            this.btn_dgv.DGV.Visible = true;
            this.btn_dgv.DGV.ClearSelection();
            GF.closeLoading();
        }

        private void card_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) loadGridData();
        }

        private void code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) loadGridData();
        }
    }
}
