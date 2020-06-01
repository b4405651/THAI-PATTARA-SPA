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
    public partial class emp_contract : Form
    {
        public emp_contract()
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
            using (emp_contract_manage managePage = new emp_contract_manage())
            {
                managePage.Owner = this;
                managePage.manage_btn.Text = "ADD";
                managePage.id = new Random().Next(1, 1000000);
                managePage.gen = true;
                managePage.ShowDialog();
            }
        }
        void EditClick(object sender, EventArgs e)
        {
            using (emp_contract_manage managePage = new emp_contract_manage())
            {
                managePage.Owner = this;
                managePage.manage_btn.Text = "UPDATE";
                // แก้ไข ใช้ emp_contract_id
                managePage.id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells["emp_contract_id"].Value);
                managePage.gen = false;
                managePage.ShowDialog();
            }
        }
        void DeleteClick(object sender, EventArgs e)
        {
            int emp_contract_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells["emp_contract_id"].Value);
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO DELETE THIS CONTRACT DATA ?", "DELETE CONTRACT DATA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GF.showLoading(this);
                DB.beginTrans();
                if (DB.set("DELETE FROM EMP_CONTRACT WHERE emp_contract_id = " + emp_contract_id, "DELETE EMP_CONTRACT[" + emp_contract_id + "]"))
                {
                    using (DataTable DT = DB.getS("SELECT TOP 1 END_DATE FROM EMP_CONTRACT WHERE EMP_ID = " + GF.selected_id.ToString() + " ORDER BY START_DATE DESC", null, "GET LATEST CONTRACT_END_DATE FOR EMPLOYEE", false))
                    {
                        string end_date = DT.Rows[0]["END_DATE"].ToString();

                        if (DB.set("UPDATE EMPLOYEE SET CONTRACT_END_DATE = " + GF.modDate(end_date) + " WHERE EMP_ID = " + GF.selected_id.ToString(), "SET NEW CONTRACT_END_DATE OF EMP_ID[" + GF.selected_id.ToString() + "]"))
                        {
                            DB.close();
                            MessageBox.Show("CONTRACT DATA IS DELETED.", "COMPLETED");
                            GF.closeLoading();
                            btn_dgv.refresh_btn.PerformClick();
                        }
                        else
                        {
                            GF.closeLoading();
                            MessageBox.Show("ERROR UPDATE CONTRACT_END_DATE !!", "ERROR");
                            return;
                        }
                    }
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

            line_sep.Top = employee_name_lbl.Top + 35; line_sep.Width = btn_dgv.Width;
            btn_dgv.rearrange(line_sep.Top + 15);
            if (GF.selected_id != -1) loadGridData();
            else
            {
                MessageBox.Show("PLEASE SEARCH EMPLOYEE FROM CODE !!", "ERROR");
                employee_code.Focus();
            }
        }
        // DELEGATE PART :: END

        public void loadGridData()
        {
            GF.showLoading(this);
            this.btn_dgv.DGV.Rows.Clear();

            if (btn_dgv.DGV.Columns.Count == 0)
            {
                this.btn_dgv.DGV.Columns.Add("start_date", "START DATE");
                this.btn_dgv.DGV.Columns.Add("end_date", "END DATE");
                this.btn_dgv.DGV.Columns.Add("emp_contract_id", "EMP CONTRACT ID");
                this.btn_dgv.DGV.Columns["emp_contract_id"].Visible = false;
            }

            // GET TOTAL PAGE
            String queryString = @"SELECT EMP_CONTRACT_ID, CONVERT(VARCHAR, START_DATE,103) START_DATE, CONVERT(VARCHAR, END_DATE,103) END_DATE 
                                    FROM EMP_CONTRACT WHERE EMP_ID = " + GF.selected_id.ToString();

            GF.getTotalPage(btn_dgv, queryString, null);

            using (DataTable myDT = DB.getS(DB.insertRowNum("START_DATE DESC", queryString), null, "GET EMP CONTRACT"))
            {
                GF.doDebug(DB.lastQuery);
                foreach (DataRow myRow in myDT.Rows)
                {
                    this.btn_dgv.DGV.Rows.Add(
                        myRow["start_date"],
                        myRow["end_date"],
                        myRow["emp_contract_id"]
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
