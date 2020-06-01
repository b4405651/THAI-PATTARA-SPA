using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.CROSS_PROMOTION
{
    public partial class cross_promotion : Form
    {
        bool justOpen = true;
        public cross_promotion()
        {
            InitializeComponent();
            //UC EVENTS
            btn_dgv.AddClick += new btn_dgv.AddClickHandler(AddClick);
            btn_dgv.DeleteClick += new btn_dgv.DeleteClickHandler(DeleteClick);
            btn_dgv.RefreshClick += new btn_dgv.RefreshClickHandler(doLoadGridData);
            btn_dgv.SearchClick += new btn_dgv.SearchClickHandler(doLoadGridData);

            //PAGING DELEGATE
            btn_dgv.firstClick += new btn_dgv.firstClickHandler(doLoadGridData);
            btn_dgv.prevClick += new btn_dgv.prevClickHandler(doLoadGridData);
            btn_dgv.nextClick += new btn_dgv.nextClickHandler(doLoadGridData);
            btn_dgv.lastClick += new btn_dgv.lastClickHandler(doLoadGridData);
            btn_dgv.pageNumberChanged += new btn_dgv.pageNumberChangedHandler(doLoadGridData);

            btn_dgv.DGV.CellDoubleClick += (s, e) =>
            {
                if (btn_dgv.DGV.SelectedRows.Count == 1)
                {
                    using (cross_promotion_manage managePage = new cross_promotion_manage())
                    {
                        managePage.cross_promotion_id = btn_dgv.DGV.SelectedRows[0].Cells["CROSS_PROMOTION_ID"].Value.ToString();
                        managePage.Owner = this;
                        managePage.Text = "EDIT CROSS PROMOTION";
                        managePage.manage_btn.Text = "UPDATE";
                        managePage.ShowDialog();
                    }
                }
            };
        }

        // DELEGATE PART :: BEGIN
        void AddClick(object sender, EventArgs e)
        {
            GF.selected_id = 0;

            using (cross_promotion_manage managePage = new cross_promotion_manage())
            {
                managePage.Owner = this;
                managePage.Text = "ADD CROSS PROMOTION";
                managePage.manage_btn.Text = "ADD";
                managePage.ShowDialog();
            }
        }

        void DeleteClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO DISABLE THIS CROSS PROMOTION ?", "DISABLE CROSS PROMOTION", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                String queryString = "UPDATE CROSS_PROMOTION SET IS_USE = 0 WHERE CROSS_PROMOTION_ID = " + btn_dgv.DGV.SelectedRows[0].Cells["cross_promotion_id"].Value.ToString();
                GF.showLoading(this);
                DB.beginTrans();
                if (!DB.set(queryString, "DISABLE CROSS_PROMOTION[" + btn_dgv.DGV.SelectedRows[0].Cells["cross_promotion_id"].Value.ToString() + "]"))
                {
                    MessageBox.Show("ERROR DISABLE CROSS PROMOTION !!", "ERROR");
                    GF.closeLoading();
                    return;
                }
                DB.close();
                GF.closeLoading();
                btn_dgv.refresh_btn.PerformClick();
            }
        }

        void doLoadGridData(object sender, EventArgs e)
        {
            card_no_lbl.Top = GF.pageTop;
            card_no.Top = card_no_lbl.Top - 3;

            line_sep1.Top = card_no_lbl.Top + 35; line_sep1.Width = btn_dgv.Width;
            if (justOpen)
            {
                btn_dgv.rearrange(line_sep1.Top + 15);
                justOpen = false;
            }

            btn_dgv.del_btn.Text = "DISABLE";
            btn_dgv.edit_btn.Visible = false;
            btn_dgv.add_btn.Left = btn_dgv.edit_btn.Left;
            btn_dgv.preventDGVSelectionChanged = true;
            //btn_dgv.preventEnable = true;

            GF.resetAC(this);
            loadGridData();

            GF.enableButton(btn_dgv.del_btn);
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
                this.btn_dgv.DGV.Columns.Add("cross_promotion_name", "CROSS PROMOTION");
                this.btn_dgv.DGV.Columns.Add("card_no", "CARD NO.");
                this.btn_dgv.DGV.Columns.Add("program_name", "SPA PROGRAM");
                this.btn_dgv.DGV.Columns.Add("discount", "DISCOUNT");
                this.btn_dgv.DGV.Columns.Add("expiry_date", "EXPIRY DATE");
                this.btn_dgv.DGV.Columns.Add("cross_promotion_id", "cross_promotion_id");

                this.btn_dgv.DGV.Columns["cross_promotion_id"].Visible = false;
                this.btn_dgv.DGV.Columns["cross_promotion_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.btn_dgv.DGV.Columns["card_no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.btn_dgv.DGV.Columns["program_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            Dictionary<string, string> Params = new Dictionary<string, string>();

            String queryString = @"
            SELECT 
                A.cross_promotion_id
                ,A.cross_promotion_name
                ,A.card_no
                ,A.discount
                ,A.IS_USE
                ,B.CODE
                ,B.PROGRAM_NAME
                ,ISNULL(CONVERT(VARCHAR(MAX), A.expiry_date, 103) + ' ' + CONVERT(VARCHAR(MAX), A.expiry_date, 108), '') expiry_date
            FROM 
            CROSS_PROMOTION A
            INNER JOIN SPA_PROGRAM B ON A.SPA_PROGRAM_ID = B.SPA_PROGRAM_ID
            WHERE 1=1";

            if (card_no.Text.Trim() != "")
            {
                queryString += " AND A.CARD_NO = '" + card_no.Text + "'";
                //Params.Add("@card_no", card_no.Text);
            }

            // GET TOTAL PAGE
            GF.getTotalPage(btn_dgv, queryString, Params);

            queryString = DB.insertRowNum("A.CROSS_PROMOTION_NAME ASC", queryString);
            GF.doDebug(">>>> " + queryString);
            using (DataTable myDT = DB.getS(queryString, Params, "GET ALL CROSS PROMOTION"))
            {
                for (int rowNum = 0; rowNum < myDT.Rows.Count; rowNum++)
                {
                    this.btn_dgv.DGV.Rows.Add(
                        myDT.Rows[rowNum]["CROSS_PROMOTION_NAME"],
                        myDT.Rows[rowNum]["CARD_NO"],
                        "[#" + myDT.Rows[rowNum]["CODE"].ToString() + "] " + myDT.Rows[rowNum]["PROGRAM_NAME"].ToString(),
                        GF.formatNumber(Convert.ToInt32(myDT.Rows[rowNum]["DISCOUNT"].ToString())) + "%",
                        GF.formatDate(myDT.Rows[rowNum]["expiry_date"].ToString()),
                        myDT.Rows[rowNum]["cross_promotion_id"]
                    );
                    if (myDT.Rows[rowNum]["is_use"].ToString() == "0") this.btn_dgv.DGV.Rows[rowNum].DefaultCellStyle.BackColor = Color.LightCoral;
                    this.btn_dgv.DGV.ClearSelection();
                }
            }
            GF.updateRowNum(btn_dgv.DGV, true);
            this.btn_dgv.DGV.Refresh();
            this.btn_dgv.DGV.Visible = true;
            GF.closeLoading();
        }

        private void card_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
