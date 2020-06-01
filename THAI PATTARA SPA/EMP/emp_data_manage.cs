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
    public partial class emp_data_manage : Form
    {
        int _id = -1;

        public int id { get { return _id; } set { _id = value; } }

        public emp_data_manage()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };

            //GF.resizeMgmtForm(this);

            emp_type_id.Items.Add(new ComboItem(0, "FULLTIME"));
            emp_type_id.Items.Add(new ComboItem(1, "PARTTIME"));
            emp_type_id.SelectedIndex = 0;

            String queryString = "SELECT * FROM EMP_DEPT WHERE IS_USE = 1 ORDER BY DEPT_NAME";
            using (DataTable DT = DB.getS(queryString, null, "GET EMP_DEPT", false))
            {
                foreach (DataRow row in DT.Rows)
                {
                    department.Items.Add(new ComboItem(Convert.ToInt32(row["EMP_DEPT_ID"].ToString()), row["DEPT_NAME"].ToString()));
                }
            }
            department.SelectedIndex = 0;
            GF.resizeComboBox(department);
        }

        private void emp_data_manage_Load(object sender, EventArgs e)
        {
            /*if (id == -1) attachment_btn.Visible = false;
            else attachment_btn.Visible = true;*/

            if (id != -1)
            {
                string queryString = @"
                SELECT 
                    TOP 1 
                    A.FULLNAME, 
                    A.NICKNAME,
                    A.CODE, 
                    A.EMP_TYPE, 
                    CONVERT(VARCHAR,A.REGISTER_DATE,103) REGISTER_DATE, 
                    A.CAN_APPROVE, 
                    A.APPROVE_CODE,
                    B.DEPT_NAME
                FROM EMPLOYEE A
                LEFT OUTER JOIN EMP_DEPT B ON A.EMP_DEPT_ID = B.EMP_DEPT_ID
                WHERE A.EMP_ID = " + id.ToString();
                using (DataTable myDT = DB.getS(queryString, null, "GET EMP DATA", false))
                {
                    foreach (DataRow myRow in myDT.Rows)
                    {
                        fullname.Text = myRow["FULLNAME"].ToString();
                        nickname.Text = myRow["NICKNAME"].ToString();
                        employee_code.Text = myRow["CODE"].ToString();
                        emp_type_id.Text = myRow["EMP_TYPE"].ToString();
                        register_date.Text = myRow["REGISTER_DATE"].ToString();
                        if (myRow["CAN_APPROVE"].ToString() == "1") can_approve.Checked = true; else can_approve.Checked = false;
                        approve_code.Text = CRYPT.Decode(myRow["APPROVE_CODE"].ToString());
                        department.Text = myRow["DEPT_NAME"].ToString();
                    }
                }
            }
            else
            {
                String queryString = "SELECT CONVERT(NVARCHAR(MAX), GETDATE(),103) TODAY";
                using (DataTable myDT = DB.getS(queryString, null, "GET TODAY", false))
                {
                    register_date.Text = myDT.Rows[0]["TODAY"].ToString();
                }
            }
        }

        private void attachment_Click(object sender, EventArgs e)
        {
            GF.loadAttachmentPage(this, this.id);
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if (fullname.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER EMPLOYEE'S FULLNAME !!", "ERROR");
                fullname.Focus();
                return;
            }
            if (employee_code.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER EMPLOYEE'S CODE !!", "ERROR");
                employee_code.Focus();
                return;
            }
            if (GF.emptyDate(register_date.Text.Trim()))
            {
                MessageBox.Show("PLEASE ENTER REGISTER DATE !!", "ERROR");
                register_date.Focus();
                return;
            }

            Dictionary<string, string> Params = new Dictionary<string, string>();
            /*Params.Add("@fullname", fullname.Text);
            Params.Add("@emp_code", employee_code.Text);*/

            string queryString = "SELECT * FROM EMPLOYEE WHERE (FULLNAME = '" + fullname.Text + "' OR CODE LIKE '" + employee_code.Text + "')";
            if(manage_btn.Text == "UPDATE") queryString += " AND EMP_ID != " + id.ToString();

            using (DataTable myDT = DB.getS(queryString, Params, "CHECK EMP BEFORE EXECUTE", false))
            {
                if (myDT.Rows.Count > 0)
                {
                    MessageBox.Show("THIS EMPLOYEE IS ALREADY EXISTED IN DATABASE !!", "ERROR");
                    return;
                }
                else
                {
                    GF.showLoading(this);
                    DB.beginTrans();
                    if (manage_btn.Text == "ADD")
                    {
                        queryString = "INSERT INTO EMPLOYEE (FULLNAME, NICKNAME, CODE, EMP_DEPT_ID, EMP_TYPE, REGISTER_DATE, CAN_APPROVE, APPROVE_CODE) VALUES (";
                        queryString += "'" + fullname.Text.Trim() + "', ";
                        queryString += (nickname.Text.Trim() == String.Empty ? "NULL" : "'" + nickname.Text.Trim() + "'") + ", ";
                        queryString += "'" + employee_code.Text.Trim() + "', ";
                        queryString += ((ComboItem)department.SelectedItem).Key.ToString() + ", ";
                        queryString += ((ComboItem)emp_type_id.SelectedItem).Key.ToString() + ", ";
                        queryString += GF.modDate(register_date.Text.Trim()) + ", ";
                        queryString += (this.can_approve.Checked ? "1" : "0") + ", ";
                        queryString += (this.can_approve.Checked ? "'" + CRYPT.Encode(approve_code.Text.Trim()) + "'" : "NULL") + ")";

                        this.id = DB.insertReturnID(queryString, "INSERT EMPLOYEE RETURN ID");
                        if (this.id == -1)
                        {
                            MessageBox.Show("ERROR INSERT EMPLOYEE !!", "ERROR");
                            GF.closeLoading();
                            return;
                        }

                        DB.close();
                        GF.closeLoading();
                        //MessageBox.Show("EMPLOYEE IS ADDED !!", "COMPLETED");
                        ((btn_dgv)this.Owner.Controls["btn_dgv"]).refresh_btn.PerformClick();
                        this.Close();
                    }
                    if (manage_btn.Text == "UPDATE")
                    {
                        queryString = "UPDATE EMPLOYEE SET ";
                        queryString += "FULLNAME = '" + fullname.Text.Trim() + "', ";
                        queryString += "NICKNAME = " + (nickname.Text.Trim() == String.Empty ? "NULL" : "'" + nickname.Text.Trim() + "'") + ", ";
                        queryString += "CODE = '" + employee_code.Text.Trim() + "', ";
                        queryString += "EMP_DEPT_ID = " + ((ComboItem)department.SelectedItem).Key.ToString() + ", ";
                        queryString += "EMP_TYPE = " + ((ComboItem)emp_type_id.SelectedItem).Key.ToString() + ", ";
                        queryString += "REGISTER_DATE = " + GF.modDate(register_date.Text.Trim()) + ", ";
                        queryString += "CAN_APPROVE = " + (can_approve.Checked ? "1" : "0") + ", ";
                        queryString += "APPROVE_CODE = " + (can_approve.Checked ? "'" + CRYPT.Encode(approve_code.Text.Trim()) + "'" : "NULL") + " ";
                        queryString += "WHERE EMP_ID = " + id.ToString();

                        if (DB.set(queryString, "UPDATE EMP[" + id.ToString() + "]"))
                        {
                            GF.closeLoading();
                            DB.close();
                            //MessageBox.Show("EMPLOYEE IS UPDATED !!", "COMPLETED");
                            ((btn_dgv)this.Owner.Controls["btn_dgv"]).refresh_btn.PerformClick();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("ERROR UPDATE EMPLOYEE !!", "ERROR");
                            GF.closeLoading();
                            return;
                        }
                    }
                }
            }
        }

        private void can_approve_CheckedChanged(object sender, EventArgs e)
        {
            if (can_approve.Checked)
            {
                approve_code.Text = "";
                approve_code.Enabled = true;
            }
            else
            {
                approve_code.Text = "";
                approve_code.Enabled = false;
            }
        }

        private void department_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (id == -1)
            {
                string emp_code = (DateTime.Now.Year + 543).ToString("0000");
                string queryString = "SELECT * FROM EMP_DEPT WHERE EMP_DEPT_ID = " + ((ComboItem)department.SelectedItem).Key.ToString();
                using (DataTable myDT = DB.getS(queryString, null, "GET DEPT_CODE FROM EMP_DEPT[" + ((ComboItem)department.SelectedItem).Key.ToString() + "]", false))
                {
                    emp_code += myDT.Rows[0]["DEPT_CODE"].ToString();
                }

                Dictionary<string, string> Params = new Dictionary<string, string>();
                //Params.Add("@emp_code", emp_code);

                queryString = "SELECT MAX(CODE) + 1 NEXT_CODE FROM EMPLOYEE WHERE LEFT(CODE, 6) = '" + emp_code + "'";
                using (DataTable myDT = DB.getS(queryString, Params, "GET NEXT CODE", false))
                {
                    if (myDT.Rows[0]["NEXT_CODE"].ToString().Trim() == "") emp_code += "01";
                    else emp_code += myDT.Rows[0]["NEXT_CODE"].ToString().Trim().Substring(6);

                    employee_code.Text = emp_code;
                }
            }
        }

        private void emp_data_manage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null)
            {
                if (this.Owner.Name == "debtor_manage")
                {
                    if (this.id != -1)
                    {
                        ((DEBTOR.debtor_manage)this.Owner).search_name.SetID(this.id);
                    }
                }
                this.Owner.Activate();
            }
        }
    }
}
