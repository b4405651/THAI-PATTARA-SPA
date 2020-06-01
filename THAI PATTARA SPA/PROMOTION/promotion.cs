using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.PROMOTION
{
    public partial class promotion : Form
    {
        public promotion()
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
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells["promotion_id"].Value);
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO ENABLE THIS PROMOTION ?", "ENABLE PROMOTION", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GF.showLoading(this);
                DB.beginTrans();
                if (DB.set("UPDATE PROMOTION SET IS_USE = 1 WHERE PROMOTION_ID = " + GF.selected_id.ToString(), "ENABLE PROMOTION[" + GF.selected_id.ToString() + "]"))
                {
                    DB.close();
                    MessageBox.Show("PROMOTION IS ENABLED.", "COMPLETED");
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
            using (promotion_manage managePage = new promotion_manage())
            {
                managePage.Owner = this;
                managePage.manage_btn.Text = "ADD";
                managePage.ShowDialog();
            }
        }
        void EditClick(object sender, EventArgs e)
        {
            using (promotion_manage managePage = new promotion_manage())
            {
                managePage.Owner = this;
                managePage.manage_btn.Text = "UPDATE";
                GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells["promotion_id"].Value);
                managePage.ShowDialog();
            }
        }
        void DeleteClick(object sender, EventArgs e)
        {
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells["promotion_id"].Value);
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO DISABLE THIS PROMOTION ?", "DISABLE PROMOTION", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GF.showLoading(this);
                DB.beginTrans();
                if (DB.set("UPDATE PROMOTION SET IS_USE = 0 WHERE PROMOTION_ID = " + GF.selected_id.ToString(), "DISABLE PROMOTION[" + GF.selected_id.ToString() + "]"))
                {
                    DB.close();
                    MessageBox.Show("PROMOTION IS DISABLED.", "COMPLETED");
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
            since_lbl.Top = to_lbl.Top = GF.pageTop;
            start_date.Top = end_date.Top = since_lbl.Top - 3;
            line_sep.Top = since_lbl.Top + 35; line_sep.Width = btn_dgv.Width;
            btn_dgv.rearrange(line_sep.Top + 15);

            if (!GF.emptyDate(start_date.Text.Trim()) && !GF.emptyDate(end_date.Text.Trim()))
            {
                if (Convert.ToDateTime(end_date.Text.Trim()).CompareTo(Convert.ToDateTime(start_date.Text.Trim())) < 0)
                {
                    MessageBox.Show("THE 'END DATE' DATE MUST BE LATER THAN OR SAME DAY AS 'START DATE' !!", "ERROR");
                    end_date.Focus();
                    return;
                }
            }
            loadGridData();
        }
        // DELEGATE PART :: END

        public void loadGridData()
        {
            GF.showLoading(this);
            this.btn_dgv.DGV.Rows.Clear();

            if (btn_dgv.DGV.Columns.Count == 0)
            {
                this.btn_dgv.DGV.Columns.Add("start_date", "SINCE");
                this.btn_dgv.DGV.Columns.Add("end_date", "TO");
                this.btn_dgv.DGV.Columns.Add("promotion_name", "PROMOTION NAME");
                this.btn_dgv.DGV.Columns.Add("is_use", "ACTIVE");
                this.btn_dgv.DGV.Columns.Add("promotion_id", "PROMOTION ID");
                this.btn_dgv.DGV.Columns["promotion_id"].Visible = false;
            }

            // GET TOTAL PAGE
            String queryString = @"SELECT PROMOTION_ID, PROMOTION_NAME, CONVERT(VARCHAR,START_DATE,103) START_DATE, CONVERT(VARCHAR,END_DATE,103) END_DATE, IS_USE FROM PROMOTION WHERE IS_USE = 1";
            if (!GF.emptyDate(start_date.Text.Trim())) queryString += " AND " + GF.modDate(start_date.Text.Trim()) + " <= START_DATE";
            if (!GF.emptyDate(end_date.Text.Trim())) queryString += " AND START_DATE <= " + GF.modDate(end_date.Text.Trim());

            Dictionary<string, string> Params = new Dictionary<string, string>();
            /*Params.Add("@start_date", GF.modDate(start_date.Text.Trim()));
            Params.Add("@end_date", GF.modDate(end_date.Text.Trim()));*/

            GF.getTotalPage(btn_dgv, queryString, Params);

            using (DataTable myDT = DB.getS(DB.insertRowNum("START_DATE DESC", queryString), Params, "GET PROMOTION"))
            {
                foreach (DataRow row in myDT.Rows)
                {
                    this.btn_dgv.DGV.Rows.Add(
                        row["start_date"],
                        row["end_date"],
                        row["promotion_name"],
                        (row["is_use"].ToString() == "1" ? "ACTIVE" : "INACTIVE"),
                        row["promotion_id"]
                    );
                    int index = btn_dgv.DGV.Rows.Count - 1;
                    this.btn_dgv.DGV[2, index].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

                    this.btn_dgv.DGV["is_use", index].Style.ForeColor = (row["is_use"].ToString() == "1" ? Color.Green : Color.Red);
                }
            }

            GF.updateRowNum(btn_dgv.DGV, true);
            this.btn_dgv.DGV.ClearSelection();
            GF.closeLoading();
        }
    }
}
