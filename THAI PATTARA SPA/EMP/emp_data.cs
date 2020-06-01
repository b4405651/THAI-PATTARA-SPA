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
    public partial class emp_data : Form
    {
        public emp_data()
        {
            InitializeComponent();
            GF.addKeyUp(this);

            emp_type_id.Items.Add(new ComboItem(-1, "ALL"));
            emp_type_id.Items.Add(new ComboItem(0, "FULLTIME"));
            emp_type_id.Items.Add(new ComboItem(1, "PARTTIME"));
            emp_type_id.SelectedIndex = 0;

            status.Items.Add(new ComboItem(-1, "ALL"));
            status.Items.Add(new ComboItem(1, "NORMAL"));
            status.Items.Add(new ComboItem(0, "RESIGNED"));
            status.Items.Add(new ComboItem(2, "CONTRACT END"));
            status.SelectedIndex = 0;

            department.Items.Add(new ComboItem(-1, "ALL"));
            String queryString = "SELECT * FROM EMP_DEPT WHERE IS_USE = 1 ORDER BY DEPT_NAME";
            using (DataTable DT = DB.getS(queryString, null, "GET EMP_DEPT", false))
            {
                foreach (DataRow row in DT.Rows)
                {
                    department.Items.Add(new ComboItem(Convert.ToInt32(row["EMP_DEPT_ID"].ToString()), row["DEPT_NAME"].ToString()));
                }
            }
            department.SelectedIndex = 0;

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

            btn_dgv.DGV.SelectionChanged += (ss, ee) =>
            {
                if (btn_dgv.DGV.SelectedRows.Count == 1)
                {
                    if (btn_dgv.DGV.SelectedRows[0].Cells["emp_status"].Value.ToString() == "RESIGNED")
                    {
                        btn_dgv.del_btn.Text = "ENABLE";
                    }

                    if (btn_dgv.DGV.SelectedRows[0].Cells["emp_status"].Value.ToString() == "NORMAL")
                    {
                        btn_dgv.del_btn.Text = "RESIGN";
                    }
                }
            };
        }

        // DELEGATE PART :: BEGIN
        void AddClick(object sender, EventArgs e)
        {
            GF.selected_id = -1;

            using (emp_data_manage managePage = new emp_data_manage())
            {
                managePage.Owner = this;
                managePage.id = GF.selected_id;
                managePage.manage_btn.Text = "ADD";
                managePage.Text = "ADD EMPLOYEE DATA";

                managePage.ShowDialog();
            }
        }
        void EditClick(object sender, EventArgs e)
        {
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells[btn_dgv.DGV.Columns.Count - 1].Value);

            using (emp_data_manage managePage = new emp_data_manage())
            {
                managePage.Owner = this;
                managePage.manage_btn.Text = "UPDATE";
                managePage.id = GF.selected_id;
                managePage.Text = "EDIT EMPLOYEE DATA";

                managePage.ShowDialog();
            }
        }
        void DeleteClick(object sender, EventArgs e)
        {
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells[btn_dgv.DGV.Columns.Count - 1].Value);
            if (btn_dgv.del_btn.Text == "RESIGN")
            {
                using (emp_data_resign managePage = new emp_data_resign())
                {
                    managePage.Owner = this;

                    managePage.ShowDialog();
                }
            }

            if (btn_dgv.del_btn.Text == "ENABLE")
            {
                GF.showLoading(this);
                String queryString = "UPDATE EMPLOYEE SET RESIGN_DATE = NULL, EMP_STATUS = 1 WHERE EMP_ID = " + GF.selected_id.ToString();
                DB.beginTrans();
                if (!DB.set(queryString, "RE-ENABLE EMPLOYEE"))
                {
                    MessageBox.Show("ERROR RE-ENABLE EMPLOYEE !!", "ERROR");
                    GF.closeLoading();
                    return;
                }
                DB.close();
                loadGridData();
            }
        }

        void doLoadGridData(object sender, EventArgs e)
        {
            emp_code_lbl.Top = fullname_lbl.Top = nickname_lbl.Top = GF.pageTop;
            employee_code.Top = fullname.Top = emp_code_lbl.Top - 3;
            
            emp_type_lbl.Top = status_lbl.Top = department_lbl.Top = emp_code_lbl.Top + 27;
            emp_type_id.Top = status.Top = emp_type_lbl.Top - 3;

            department.Top = department_lbl.Top - 3;

            line_sep1.Top = emp_type_lbl.Top + 35; line_sep1.Width = btn_dgv.Width;
            btn_dgv.rearrange(line_sep1.Top + 15);

            btn_dgv.del_btn.Text = "RESIGN";

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
                this.btn_dgv.DGV.Columns.Add("code", "CODE");
                this.btn_dgv.DGV.Columns.Add("fullname", "EMPLOYEE NAME");
                this.btn_dgv.DGV.Columns.Add("nickname", "NICKNAME");
                this.btn_dgv.DGV.Columns.Add("dept_name", "DEPARTMENT");
                this.btn_dgv.DGV.Columns.Add("emp_type_name", "TYPE");
                this.btn_dgv.DGV.Columns.Add("register_date", "REGISTER DATE");
                this.btn_dgv.DGV.Columns.Add("contract_end_date", "CONTRACT END DATE");
                this.btn_dgv.DGV.Columns.Add("can_approve", "CAN APPROVE");
                this.btn_dgv.DGV.Columns.Add("emp_status", "STATUS");
                this.btn_dgv.DGV.Columns.Add("resign_date", "RESIGNED ON");
                this.btn_dgv.DGV.Columns.Add("emp_id", "EMP_ID");
                this.btn_dgv.DGV.Columns["emp_id"].Visible = false;
            }

            // GET TOTAL PAGE

            Dictionary<string, string> Params = new Dictionary<string, string>();

            String queryString = @"
            SELECT 
                A.EMP_ID, 
                A.FULLNAME, 
                A.NICKNAME,
                A.CODE, 
                A.EMP_TYPE, 
                CONVERT(VARCHAR,A.REGISTER_DATE,103) REGISTER_DATE, 
                CONVERT(VARCHAR,A.CONTRACT_END_DATE,103) CONTRACT_END_DATE, 
                A.EMP_STATUS, 
                CONVERT(VARCHAR,A.RESIGN_DATE,103) RESIGN_DATE, 
                A.CAN_APPROVE,
                A.EMP_DEPT_ID,
                B.DEPT_NAME
            FROM EMPLOYEE A 
            LEFT OUTER JOIN EMP_DEPT B ON A.EMP_DEPT_ID = B.EMP_DEPT_ID
            WHERE 1=1";

            if (employee_code.Text.Trim() != "")
            {
                queryString += " AND A.code = '" + employee_code.Text + "'";
                //Params.Add("@employee_code", employee_code.Text);
            }
            if (fullname.Text.Trim() != "")
            {
                queryString += " AND A.fullname LIKE '%' + " + fullname.Text + " + '%'";
                //Params.Add("@fullname", fullname.Text);
            }
            if (nickname.Text.Trim() != "")
            {
                queryString += " AND A.nickname LIKE '%' + " + nickname.Text + " + '%'";
                //Params.Add("@nickname", nickname.Text);
            }
            if (((ComboItem)this.emp_type_id.SelectedItem).Key != -1) queryString += " AND A.emp_type = " + ((ComboItem)this.emp_type_id.SelectedItem).Key.ToString();

            if (((ComboItem)status.SelectedItem).Key == 2) queryString += " AND A.CONTRACT_END_DATE < GETDATE()";
            else if (((ComboItem)status.SelectedItem).Key != -1) queryString += " AND A.EMP_STATUS = " + ((ComboItem)this.status.SelectedItem).Key.ToString();

            if (((ComboItem)department.SelectedItem).Key != -1) queryString += " AND A.EMP_DEPT_ID = " + ((ComboItem)department.SelectedItem).Key.ToString();
            
            GF.getTotalPage(btn_dgv, queryString, Params);

            queryString = DB.insertRowNum("A.EMP_STATUS DESC, A.EMP_DEPT_ID, CONVERT(BIGINT, A.CODE), A.FULLNAME, A.EMP_TYPE", queryString);
            using (DataTable myDT = DB.getS(queryString, Params, "GET ALL EMPLOYEE"))
            {
                int rowNum = 0;
                foreach (DataRow myRow in myDT.Rows)
                {
                    this.btn_dgv.DGV.Rows.Add(
                        myRow["code"],
                        myRow["fullname"],
                        myRow["nickname"],
                        myRow["DEPT_NAME"],
                        (myRow["emp_type"].ToString() == "0" ? "FULLTIME" : "PARTTIME"),
                        ((myRow["register_date"].ToString() == "NULL" || myRow["register_date"].ToString() == "") ? "" : myRow["register_date"].ToString().Split(' ')[0].ToString()),
                        ((myRow["contract_end_date"].ToString() == "" || myRow["contract_end_date"].ToString() == "NULL") ? "NO CONTRACT DATA" : myRow["contract_end_date"].ToString().Split(' ')[0].ToString()),
                        "",
                        (myRow["emp_status"].ToString() == "0" ? "RESIGNED" : "NORMAL"),
                        ((myRow["resign_date"].ToString() == "NULL" || myRow["resign_date"].ToString() == "") ? "" : myRow["resign_date"].ToString().Split(' ')[0].ToString()),
                        myRow["emp_id"]
                    );

                    if (myRow["can_approve"].ToString() == "1") this.btn_dgv.DGV["can_approve", rowNum].Style.BackColor = Color.Green;
                    this.btn_dgv.DGV[1, rowNum].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    rowNum++;
                }

                // FORMAT CONTRACT_END_DATE
                for (rowNum = 0; rowNum < this.btn_dgv.DGV.Rows.Count; rowNum++)
                {
                    for (int tmpCol = 0; tmpCol < this.btn_dgv.DGV.Columns.Count; tmpCol++)
                    {
                        if (this.btn_dgv.DGV.Columns[tmpCol].Name.ToUpper() == "CONTRACT_END_DATE")
                        {
                            if (this.btn_dgv.DGV[tmpCol, rowNum].Value.ToString().Trim() == "NO CONTRACT DATA")
                            {
                                this.btn_dgv.DGV[tmpCol, rowNum].Style.ForeColor = Color.Red;
                            }
                            else
                            {
                                DateTime contract_date_end = DateTime.Parse(this.btn_dgv.DGV[tmpCol, rowNum].Value.ToString().Trim());
                                DateTime now = DateTime.Now;
                                TimeSpan diff = contract_date_end - now;

                                if (contract_date_end < now || diff.TotalDays <= 30)
                                {
                                    this.btn_dgv.DGV[tmpCol, rowNum].Style.ForeColor = Color.Red;
                                }
                            }
                        }
                    }
                }
            }

            GF.updateRowNum(btn_dgv.DGV, true);
            this.btn_dgv.DGV.ClearSelection();
            GF.closeLoading();
        }

        private void fullname_KeyDown(object sender, KeyEventArgs e)
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
                    }
                    else
                    {
                        emp_type_id.Text = (myDR["EMP_TYPE"].ToString() == "0") ? "FULLTIME" : "PARTTIME";
                        status.Text = (myDR["EMP_STATUS"].ToString() == "1") ? "NORMAL" : "RESIGNED";
                    }

                    loadGridData();
                }
            }
        }
    }
}
