using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.EMP
{
    public partial class config_work_time : Form
    {
        public config_work_time()
        {
            InitializeComponent();

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

            using (config_work_time_manage managePage = new config_work_time_manage())
            {
                managePage.Owner = this;
                managePage.manage_btn.Text = "ADD";
                managePage.Text = "ADD EMPLOYEE WORK TIME";

                managePage.ShowDialog();
            }
        }
        void EditClick(object sender, EventArgs e)
        {
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells[btn_dgv.DGV.Columns.Count - 1].Value);

            using (config_work_time_manage managePage = new config_work_time_manage())
            {
                managePage.Owner = this;
                managePage.manage_btn.Text = "UPDATE";
                managePage.Text = "EDIT EMPLOYEE WORK TIME";

                managePage.ShowDialog();
            }
        }
        void DeleteClick(object sender, EventArgs e)
        {
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells[btn_dgv.DGV.Columns.Count - 1].Value);
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO DELETE THIS ITEM ?", "DELETE ITEM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GF.showLoading(this);
                DB.beginTrans();
                if (DB.set("DELETE FROM EMP_CONFIG_WORK_TIME WHERE emp_config_work_time_id = " + GF.selected_id, "DELETE EMP CONFIG WORK TIME[" + GF.selected_id + "]"))
                {
                    DB.close();
                    MessageBox.Show("RULE IS DELETED.", "COMPLETED");
                    GF.closeLoading();
                    btn_dgv.refresh_btn.PerformClick();
                }
                else
                {
                    GF.closeLoading();
                    MessageBox.Show("ERROR DELETING DATA !!", "ERROR");
                    return;
                }
            }
        }

        void doLoadGridData(object sender, EventArgs e)
        {
            btn_dgv.rearrange(GF.pageTop);
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
                this.btn_dgv.DGV.Columns.Add("in_time", "CLOCK-IN TIME");
                this.btn_dgv.DGV.Columns.Add("late_time", "LATE CLOCK-IN TIME");
                this.btn_dgv.DGV.Columns.Add("out_time", "CLOCK-OUT TIME");
                this.btn_dgv.DGV.Columns.Add("cut_wage", "CUT WAGE");
                this.btn_dgv.DGV.Columns.Add("emp_config_work_time_id", "EMP_CONFIG_WORK_TIME_ID");
                this.btn_dgv.DGV.Columns["emp_config_work_time_id"].Visible = false;
            }

            // GET TOTAL PAGE
            String queryString = @"SELECT EMP_CONFIG_WORK_TIME_ID, IN_TIME, LATE_TIME, OUT_TIME, CUT_WAGE_AMOUNT, CUT_WAGE_UNIT FROM EMP_CONFIG_WORK_TIME WHERE 1=1";

            GF.getTotalPage(btn_dgv, queryString, null);

            queryString = DB.insertRowNum("config_date DESC", queryString);
            using (DataTable myDT = DB.getS(queryString, null, "GET ALL EMP CONFIG WORK_TIME"))
            {
                foreach (DataRow myRow in myDT.Rows)
                {
                    this.btn_dgv.DGV.Rows.Add(
                        myRow["in_time"],
                        myRow["late_time"],
                        myRow["out_time"],
                        GF.formatNumber(Convert.ToInt32(myRow["cut_wage_amount"])) + " " + ((myRow["cut_wage_unit"].ToString() == "0") ? Properties.Settings.Default.money_unit : "%"),
                        myRow["emp_config_work_time_id"]
                    );
                }
            }
            GF.updateRowNum(btn_dgv.DGV, true);
            this.btn_dgv.DGV.ClearSelection();
            GF.closeLoading();
        }
    }
}
