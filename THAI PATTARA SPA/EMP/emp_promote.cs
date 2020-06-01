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
    public partial class emp_promote : Form
    {
        public emp_promote()
        {
            InitializeComponent();

            employee_name_lbl.Text = "";

            GF.disableButton(btn_dgv.add_btn);

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
            using (emp_promote_manage managePage = new emp_promote_manage())
            {
                managePage.Owner = this;
                managePage.manage_btn.Text = "ADD";
                managePage.ShowDialog();
            }
        }
        void EditClick(object sender, EventArgs e)
        {
            using (emp_promote_manage managePage = new emp_promote_manage())
            {
                managePage.Owner = this;
                managePage.manage_btn.Text = "UPDATE";
                // แก้ไข ใช้ emp_leave_id
                GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells["emp_promote_id"].Value);
                managePage.ShowDialog();
            }
        }
        void DeleteClick(object sender, EventArgs e)
        {
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells["emp_promote_id"].Value);
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO DELETE THIS PROMOTE DATA ?", "DELETE PROMOTE DATA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GF.showLoading(this);
                DB.beginTrans();
                if (DB.set("DELETE FROM EMP_PROMOTE WHERE emp_promote_id = " + GF.selected_id.ToString(), "DELETE EMP_PROMOTE[" + GF.selected_id.ToString() + "]"))
                {
                    DB.close();
                    MessageBox.Show("PROMOTE DATA IS DELETED.", "COMPLETED");
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
            emp_code_lbl.Top = employee_name_lbl.Top = GF.pageTop;
            employee_code.Top = employee_name_lbl.Top - 6;

            line_sep.Top = employee_name_lbl.Top + 35; line_sep.Width = btn_dgv.Width;
            btn_dgv.rearrange(line_sep.Top + 15);
            if (GF.selected_id != -1) loadGridData();
            else
            {
                MessageBox.Show("PLEASE SEARCH EMPLOYEE FROM CODE !!", "ERROR");
                employee_code.Focus();
                return;
            }
        }
        // DELEGATE PART :: END

        public void loadGridData()
        {
            GF.showLoading(this);
            this.btn_dgv.DGV.Rows.Clear();

            if(btn_dgv.DGV.Columns.Count == 0){
                this.btn_dgv.DGV.Columns.Add("promote_date", "PROMOTE DATE");
                this.btn_dgv.DGV.Columns.Add("new_wage", "NEW WAGE");
                this.btn_dgv.DGV.Columns.Add("promoted_by", "PROMOTED BY");
                this.btn_dgv.DGV.Columns.Add("emp_promote_id", "EMP PROMOTE ID");
                this.btn_dgv.DGV.Columns["emp_promote_id"].Visible = false;
            }

            // GET TOTAL PAGE
            String queryString = @"SELECT TOP 1 A.EMP_PROMOTE_ID, A.NEW_WAGE, CONVERT(VARCHAR,A.PROMOTE_DATE,103) PROMOTE_DATE, B.FULLNAME PROMOTED_BY 
                                    FROM EMP_PROMOTE A 
                                    LEFT OUTER JOIN EMPLOYEE B ON A.PROMOTED_BY = B.EMP_ID
                                    WHERE A.EMP_ID = " + GF.selected_id.ToString();

            GF.getTotalPage(btn_dgv, queryString, null);

            using (DataTable myDT = DB.getS(DB.insertRowNum("A.PROMOTE_DATE DESC", queryString), null, "GET EMP PROMOTE"))
            {
                GF.doDebug(DB.lastQuery);

                foreach (DataRow myRow in myDT.Rows)
                {
                    if (myRow["PROMOTED_BY"].ToString() == "")
                    {
                        myRow["PROMOTED_BY"] = "Administrator";
                    }

                    this.btn_dgv.DGV.Rows.Add(
                        myRow["promote_date"],
                        GF.formatNumber(Int32.Parse(myRow["new_wage"].ToString())),
                        myRow["PROMOTED_BY"],
                        myRow["emp_promote_id"]
                    );
                }
            }
            GF.updateRowNum(btn_dgv.DGV, true);
            this.btn_dgv.DGV.ClearSelection();
            GF.closeLoading();
        }

        private void employee_code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (employee_code.Text.Trim() != "")
                {
                    DataRow myDR = DB.getDataFromCode(employee_code);

                    if (myDR == null)
                    {
                        MessageBox.Show("NOT FOUND !!");
                        employee_code.Text = "";
                        employee_name_lbl.Text = "";
                        GF.selected_id = 0;
                        GF.disableButton(btn_dgv.add_btn);
                        GF.disableButton(btn_dgv.edit_btn);
                        GF.disableButton(btn_dgv.del_btn);
                    }
                    else
                    {
                        GF.selected_id = Int32.Parse(myDR["EMP_ID"].ToString());
                        employee_name_lbl.Text = myDR["FULLNAME"] + "-" + " [" + myDR["CODE"] + "]";
                        GF.enableButton(btn_dgv.add_btn);
                    }

                    loadGridData();
                }
            }
        }

        private void employee_code_TextChanged(object sender, EventArgs e)
        {
            if (GF.selected_id != 0)
            {
                employee_name_lbl.Text = "";
                GF.selected_id = 0;
                employee_code.Text = "";
            }
        }
    }
}
