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
    public partial class emp_leave : Form
    {
        public emp_leave()
        {
            InitializeComponent();

            employee_name_lbl.Text = "";

            string queryString = "SELECT CONVERT(VARCHAR, GETDATE(),103) TODAY";

            using (DataTable myDT = DB.getS(queryString, null, "GET TODAY", false))
            {
                since.Text = to.Text = myDT.Rows[0]["TODAY"].ToString();
            }

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
            using (emp_leave_manage managePage = new emp_leave_manage())
            {
                managePage.Owner = this;
                managePage.manage_btn.Text = "ADD";
                managePage.ShowDialog();
            }
        }
        void EditClick(object sender, EventArgs e)
        {
            using (emp_leave_manage managePage = new emp_leave_manage())
            {
                managePage.Owner = this;
                managePage.manage_btn.Text = "UPDATE";
                GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells["emp_leave_id"].Value);
                managePage.ShowDialog();
            }
        }
        void DeleteClick(object sender, EventArgs e)
        {
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells["emp_leave_id"].Value);
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO DELETE THIS LEAVE DATA ?", "DELETE LEAVE DATA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GF.showLoading(this);
                DB.beginTrans();
                if (DB.set("DELETE FROM EMP_LEAVE WHERE emp_leave_id = " + GF.selected_id.ToString(), "DELETE EMP_LEAVE[" + GF.selected_id.ToString() + "]"))
                {
                    DB.close();
                    MessageBox.Show("LEAVE DATA IS DELETED.", "COMPLETED");
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
            employee_code.Top = employee_name_lbl.Top - 3;

            since_lbl.Top = to_lbl.Top = emp_code_lbl.Top + 27;
            since.Top = to.Top = since_lbl.Top - 3;

            line_sep.Top = since_lbl.Top + 35; line_sep.Width = btn_dgv.Width;
            btn_dgv.rearrange(line_sep.Top + 15);
            if (Convert.ToDateTime(to.Text.Trim()).CompareTo(Convert.ToDateTime(since.Text.Trim())) < 0)
            {
                MessageBox.Show("THE 'TO' DATE MUST BE LATER THAN OR SAME DAY AS 'SINCE' !!", "ERROR");
                to.Focus();
                return;
            }
            else if (GF.selected_id == 0)
            {
                MessageBox.Show("PLEASE SEARCH EMPLOYEE FROM CODE !!", "ERROR");
                employee_code.Focus();
                return;
            }
            else loadGridData();
        }
        // DELEGATE PART :: END

        public void loadGridData()
        {
            GF.showLoading(this);
            this.btn_dgv.DGV.Rows.Clear();

            if (btn_dgv.DGV.Columns.Count == 0)
            {
                this.btn_dgv.DGV.Columns.Add("reason", "REASON");
                this.btn_dgv.DGV.Columns.Add("start_date", "SINCE");
                this.btn_dgv.DGV.Columns.Add("end_date", "TO");
                this.btn_dgv.DGV.Columns.Add("approved_by", "APPROVED BY");
                this.btn_dgv.DGV.Columns.Add("emp_leave_id", "EMP LEAVE ID");
                this.btn_dgv.DGV.Columns["emp_leave_id"].Visible = false;
            }

            // GET TOTAL PAGE
            String queryString = @"SELECT A.EMP_LEAVE_ID, A.REASON, CONVERT(VARCHAR,A.START_DATE,103) START_DATE, CONVERT(VARCHAR,A.END_DATE,103) END_DATE, B.FULLNAME APPROVED_BY 
                                    FROM EMP_LEAVE A 
                                    LEFT OUTER JOIN EMPLOYEE B ON A.APPROVED_BY = B.EMP_ID
                                    WHERE A.EMP_ID = " + GF.selected_id.ToString();
            queryString += " AND " + GF.modDate(since.Text.Trim()) + " <= START_DATE";
            queryString += " AND START_DATE <= " + GF.modDate(to.Text.Trim());

            Dictionary<string, string> Params = new Dictionary<string, string>();
            /*Params.Add("@since", GF.modDate(since.Text.Trim()));
            Params.Add("@to", GF.modDate(to.Text.Trim()));*/

            GF.getTotalPage(btn_dgv, queryString, Params);

            using (DataTable myDT = DB.getS(DB.insertRowNum("A.START_DATE", queryString), Params, "GET EMP LEAVE"))
            {
                int rowNum = 0;
                foreach (DataRow myRow in myDT.Rows)
                {
                    if (myRow["APPROVED_BY"].ToString() == "")
                    {
                        myRow["APPROVED_BY"] = "Administrator";
                    }

                    this.btn_dgv.DGV.Rows.Add(
                        myRow["reason"],
                        myRow["start_date"],
                        myRow["end_date"],
                        myRow["approved_by"],
                        myRow["emp_leave_id"]
                    );

                    this.btn_dgv.DGV[0, rowNum].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    rowNum++;
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
