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
    public partial class program_type : Form
    {
        public program_type()
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
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells["spa_program_type_id"].Value);
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO ENABLE THIS SPA PROGRAM TYPE ?", "ENABLE SPA PROGRAM TYPE", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GF.showLoading(this);
                DB.beginTrans();
                if (DB.set("UPDATE SPA_PROGRAM_TYPE SET is_use = 1 WHERE spa_program_type_id = " + GF.selected_id, "ENABLE SPA PROGRAM TYPE"))
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

            using (program_type_manage managePage = new program_type_manage())
            {
                managePage.Owner = this;
                managePage.manage_btn.Text = "ADD";
                managePage.Text = "ADD SPA PROGRAM TYPE";
                managePage.ShowDialog();
            }
        }
        void EditClick(object sender, EventArgs e)
        {
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells["spa_program_type_id"].Value);

            using (program_type_manage managePage = new program_type_manage())
            {
                managePage.Owner = this;
                managePage.manage_btn.Text = "UPDATE";
                managePage.Text = "EDIT SPA PROGRAM TYPE";

                managePage.ShowDialog();
            }
        }
        void DeleteClick(object sender, EventArgs e)
        {
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells["spa_program_type_id"].Value);
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO DISABLE THIS SPA PROGRAM TYPE ?", "DISABLE SPA PROGRAM TYPE", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GF.showLoading(this);
                DB.beginTrans();
                if (DB.set("UPDATE SPA_PROGRAM_TYPE SET is_use = 0 WHERE spa_program_type_id = " + GF.selected_id, "DISABLE SPA PROGRAM TYPE"))
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
            spa_program_type_lbl.Top = GF.pageTop;
            spa_program_type_name.Top = spa_program_type_lbl.Top - 5;

            line_sep1.Top = spa_program_type_lbl.Top + 35; line_sep1.Width = btn_dgv.Width;
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
                this.btn_dgv.DGV.Columns.Add("spa_program_type_name", "SPA PROGRAM TYPE");
                this.btn_dgv.DGV.Columns.Add("is_use", "ACTIVE");
                this.btn_dgv.DGV.Columns.Add("spa_program_type_id", "SPA PROGRAM TYPE ID");
                this.btn_dgv.DGV.Columns["spa_program_type_id"].Visible = false;
            }

            Dictionary<string, string> Params = null;
            String queryString = "SELECT * FROM SPA_PROGRAM_TYPE WHERE 1=1";
            if (spa_program_type_name.Text.Trim() != "")
            {
                queryString += " AND spa_program_type_name LIKE '%' + @spa_program_type_name + '%'";
                Params = new Dictionary<string, string>();
                Params.Add("@spa_program_type_name", spa_program_type_name.Text);
            }

            // GET TOTAL PAGE
            GF.getTotalPage(btn_dgv, "SELECT COUNT(*) AS TOTAL FROM SPA_PROGRAM_TYPE WHERE 1=1", Params);

            using (DataTable myDT = DB.getS(DB.insertRowNum("spa_program_type_name ASC, is_use DESC", queryString), Params, "GET ALL SPA PROGRAM TYPE"))
            {
                int rowNum = 0;
                foreach (DataRow myRow in myDT.Rows)
                {
                    this.btn_dgv.DGV.Rows.Add(
                        myRow["spa_program_type_name"],
                        (myRow["is_use"].ToString() == "1" ? "ACTIVE" : "INACTIVE"),
                        myRow["spa_program_type_id"]
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
    }
}
