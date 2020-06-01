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
    public partial class program : Form
    {
        public program()
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
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells["spa_program_id"].Value);
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO ENABLE THIS SPA PROGRAM ?", "ENABLE SPA PROGRAM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GF.showLoading(this);
                DB.beginTrans();
                if (DB.set("UPDATE SPA_PROGRAM SET IS_USE = 1 WHERE spa_program_id = " + GF.selected_id, "ENABLE SPA PROGRAM[" + GF.selected_id + "]"))
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

            using (program_manage managePage = new program_manage())
            {
                managePage.Owner = this;
                managePage.manage_btn.Text = "ADD";
                managePage.Text = "ADD SPA PROGRAM";

                managePage.ShowDialog();
            }
        }
        void EditClick(object sender, EventArgs e)
        {
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells["spa_program_id"].Value);

            using (program_manage managePage = new program_manage())
            {
                managePage.Owner = this;
                managePage.manage_btn.Text = "UPDATE";
                managePage.Text = "EDIT SPA PROGRAM";

                managePage.ShowDialog();
            }
        }
        void DeleteClick(object sender, EventArgs e)
        {
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells["spa_program_id"].Value);
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO DISABLE THIS SPA PROGRAM ?", "DISABLE SPA PROGRAM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GF.showLoading(this);
                DB.beginTrans();
                if (DB.set("UPDATE SPA_PROGRAM SET IS_USE = 0 WHERE spa_program_id = " + GF.selected_id, "DISABLE SPA PROGRAM[" + GF.selected_id + "]"))
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
            program_name_lbl.Top = GF.pageTop;
            program_name.Top = program_name_lbl.Top - 6;

            line_sep.Top = program_name_lbl.Top + 35; line_sep.Width = btn_dgv.Width - 4;
            btn_dgv.rearrange(line_sep.Top + 12);
            loadGridData();
        }
        // DELEGATE PART :: END

        public void loadGridData()
        {
            GF.showLoading(this);
            this.btn_dgv.DGV.Rows.Clear();
            if (btn_dgv.DGV.Columns.Count == 0)
            {
                this.btn_dgv.DGV.Columns.Add("code", "CODE");
                //this.btn_dgv.DGV.Columns.Add("program_type", "PROGRAM TYPE");
                this.btn_dgv.DGV.Columns.Add("program_name", "PROGRAM NAME");
                this.btn_dgv.DGV.Columns.Add("masseur_use", "MASTER");
                this.btn_dgv.DGV.Columns.Add("price", "PRICE");
                this.btn_dgv.DGV.Columns.Add("select_oil", "OIL");
                this.btn_dgv.DGV.Columns.Add("select_scrub", "SCRUB");
                this.btn_dgv.DGV.Columns.Add("apply_discount", "APPLY DISCOUNT");
                this.btn_dgv.DGV.Columns.Add("is_use", "ACTIVE");
                this.btn_dgv.DGV.Columns.Add("spa_program_id", "SPA_PROGRAM_ID");
                this.btn_dgv.DGV.Columns["spa_program_id"].Visible = false;
            }

            // GET TOTAL PAGE
            String queryString = @"
            SELECT A.*, B.SPA_PROGRAM_TYPE_NAME 
            FROM SPA_PROGRAM A 
            INNER JOIN SPA_PROGRAM_TYPE B ON A.SPA_PROGRAM_TYPE_ID = B.SPA_PROGRAM_TYPE_ID
            WHERE 1=1";

            Dictionary<string, string> Params = null;

            if (program_name.Text.Trim() != "")
            {
                queryString += " AND A.PROGRAM_NAME LIKE '%' + @program_name + '%'";
                Params = new Dictionary<string, string>();
                Params.Add("@program_name", program_name.Text);
            }
            if (!show_disabled.Checked) queryString += " AND A.IS_USE = 1";

            GF.getTotalPage(btn_dgv, queryString, Params);

            queryString = DB.insertRowNum("A.CODE ASC", queryString);
            using (DataTable myDT = DB.getS(queryString, Params, "GET ALL SPA PROGRAM"))
            {
                int rowNum = 0;
                foreach (DataRow myRow in myDT.Rows)
                {
                    this.btn_dgv.DGV.Rows.Add(
                        myRow["CODE"],
                        //myRow["SPA_PROGRAM_TYPE_NAME"],
                        myRow["PROGRAM_NAME"],
                        myRow["MASSEUR_USE"],
                        GF.formatNumber(Int32.Parse(myRow["PRICE"].ToString())),
                        "",
                        "",
                        "",
                        (myRow["is_use"].ToString() == "1" ? "ACTIVE" : "INACTIVE"),
                        myRow["spa_program_id"]
                    );

                    this.btn_dgv.DGV["select_oil", rowNum].Style.BackColor = (myRow["select_oil"].ToString() == "1" ? Color.Green : Color.Red);
                    this.btn_dgv.DGV["select_scrub", rowNum].Style.BackColor = (myRow["select_scrub"].ToString() == "1" ? Color.Green : Color.Red);
                    this.btn_dgv.DGV["apply_discount", rowNum].Style.BackColor = (myRow["apply_discount"].ToString() == "1" ? Color.Green : Color.Red);
                    this.btn_dgv.DGV["is_use", rowNum].Style.ForeColor = (myRow["is_use"].ToString() == "1" ? Color.Green : Color.Red);
                    this.btn_dgv.DGV[1, rowNum].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    rowNum++;
                }
            }
            GF.updateRowNum(btn_dgv.DGV, true);
            this.btn_dgv.DGV.ClearSelection();
            GF.closeLoading();
        }

        private void program_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadGridData();
            }
        }
    }
}
