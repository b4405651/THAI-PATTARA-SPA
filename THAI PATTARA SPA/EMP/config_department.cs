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
    public partial class config_department : Form
    {
        public config_department()
        {
            InitializeComponent();

            view.Items.Add(new ComboItem(-1, "ALL"));
            view.Items.Add(new ComboItem(1, "ACTIVE"));
            view.Items.Add(new ComboItem(0, "INACTIVE"));
            view.SelectedIndex = 0;

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
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells["emp_dept_id"].Value);
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO ENABLE THIS DEPARTMENT ?", "ENABLE DEPARTMENT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GF.showLoading(this);
                DB.beginTrans();
                if (DB.set("UPDATE EMP_DEPT SET IS_USE = 1 WHERE emp_dept_id = " + GF.selected_id, "ENABLE DEPARTMENT[" + GF.selected_id + "]"))
                {
                    MessageBox.Show("DEPARTMENT IS ENABLED.", "COMPLETED");
                    DB.close();
                    GF.closeLoading();
                    btn_dgv.refresh_btn.PerformClick();
                }
                else
                {
                    GF.closeLoading();
                    MessageBox.Show("ERROR ENABLE DEPARTMENT !!", "ERROR");
                    return;
                }
            }
        }
        void AddClick(object sender, EventArgs e)
        {
            GF.selected_id = 0;

            using (config_department_manage managePage = new config_department_manage())
            {
                managePage.Owner = this;
                managePage.manage_btn.Text = "ADD";
                managePage.Text = "ADD DEPARTMENT";

                managePage.ShowDialog();
            }
        }
        void EditClick(object sender, EventArgs e)
        {
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells["emp_dept_id"].Value);

            using (config_department_manage managePage = new config_department_manage())
            {
                managePage.Owner = this;
                managePage.manage_btn.Text = "UPDATE";
                managePage.Text = "EDIT DEPARTMENT";

                managePage.ShowDialog();
            }
        }
        void DeleteClick(object sender, EventArgs e)
        {
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells["emp_dept_id"].Value);
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO DISABLE THIS DEPARTMENT ?", "DISABLE DEPARTMENT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GF.showLoading(this);
                DB.beginTrans();
                if (DB.set("UPDATE EMP_DEPT SET IS_USE = 0 WHERE emp_dept_id = " + GF.selected_id, "DISABLE DEPARTMENT[" + GF.selected_id + "]"))
                {
                    MessageBox.Show("DEPARTMENT IS DISABLED.", "COMPLETED");
                    DB.close();
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
            department_name_lbl.Top = view_lbl.Top = GF.pageTop;
            department_name.Top = department_name_lbl.Top - 6;
            view.Top = view_lbl.Top - 3;

            line_sep1.Top = department_name_lbl.Top + 35; line_sep1.Width = btn_dgv.Width;
            btn_dgv.rearrange(line_sep1.Top + 15);
            loadGridData();
        }
        // DELEGATE PART :: END

        public void loadGridData()
        {
            GF.showLoading(this);
            this.btn_dgv.DGV.Rows.Clear();
            if (btn_dgv.DGV.Columns.Count == 0)
            {
                this.btn_dgv.DGV.Columns.Add("department_name", "DEPARTMENT NAME");
                this.btn_dgv.DGV.Columns.Add("department_code", "CODE");
                this.btn_dgv.DGV.Columns.Add("is_use", "STATUS");
                this.btn_dgv.DGV.Columns.Add("emp_dept_id", "EMP_DEPT_ID");
                this.btn_dgv.DGV.Columns["emp_dept_id"].Visible = false;
            }
            
            // GET TOTAL PAGE
            String queryString = @"SELECT * FROM EMP_DEPT WHERE 1=1";

            Dictionary<string, string> Params = null;
            if (department_name.Text.Trim() != "")
            {
                queryString += " AND DEPT_NAME LIKE '%' + @dept_name + '%'";
                Params = new Dictionary<string, string>();
                Params.Add("@dept_name", department_name.Text);
            }
            if (((ComboItem)view.SelectedItem).Key != -1) queryString += " AND IS_USE = " + ((ComboItem)view.SelectedItem).Key.ToString();

            GF.getTotalPage(btn_dgv, queryString, Params);

            queryString = DB.insertRowNum("IS_USE DESC, DEPT_NAME ASC", queryString);
            using (DataTable myDT = DB.getS(queryString, Params, "GET ALL EMP DEPARTMENT"))
            {
                int rowNum = 0;
                foreach (DataRow myRow in myDT.Rows)
                {
                    this.btn_dgv.DGV.Rows.Add(
                        myRow["DEPT_NAME"],
                        myRow["DEPT_CODE"],
                        (myRow["IS_USE"].ToString() == "1" ? "ACTIVE" : "INACTIVE"),
                        myRow["emp_dept_id"]
                    );

                    this.btn_dgv.DGV["is_use", rowNum].Style.ForeColor = (myRow["is_use"].ToString() == "1" ? Color.Green : Color.Red);
                    this.btn_dgv.DGV[0, rowNum].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    rowNum++;
                }
            }
            GF.updateRowNum(btn_dgv.DGV, true);
            this.btn_dgv.DGV.ClearSelection();
            GF.closeLoading();
        }
    }
}
