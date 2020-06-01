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
    public partial class config_department_manage : Form
    {
        public config_department_manage()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };

            active.Items.Add(new ComboItem(1, "ACTIVE"));
            active.Items.Add(new ComboItem(0, "INACTIVE"));
            active.SelectedIndex = 0;
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if (department_name.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER DEPARTMENT NAME !!", "ERROR");
                department_name.Focus();
                return;
            }
            if (department_code.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER DEPARTMENT CODE !!", "ERROR");
                department_code.Focus();
                return;
            }

            string queryString = "SELECT * FROM EMP_DEPT WHERE DEPT_NAME = '" + department_name.Text + "'";
            if (manage_btn.Text.Trim() == "UPDATE") queryString += " AND EMP_DEPT_ID != " + GF.selected_id.ToString();

            Dictionary<string, string> Params = new Dictionary<string, string>();
            //Params.Add("@department_name", department_name.Text);

            if (DB.getS(queryString, Params, "CHECK DEPT_NAME IF EXISTED", false).Rows.Count > 0)
            {
                MessageBox.Show("THIS DEPARTMENT NAME IS ALREADY EXISTED !!", "ERROR");
                department_name.Focus();
                return;
            }

            Params = new Dictionary<string, string>();
            Params.Add("@dept_code", department_code.Text);

            queryString = "SELECT * FROM EMP_DEPT WHERE DEPT_CODE = @dept_code";
            if (manage_btn.Text.Trim() == "UPDATE") queryString += " AND EMP_DEPT_ID != " + GF.selected_id.ToString();

            if (DB.getS(queryString, Params, "CHECK DEPT_CODE IF EXISTED", false).Rows.Count > 0)
            {
                MessageBox.Show("THIS DEPARTMENT CODE IS ALREADY EXISTED !!", "ERROR");
                department_code.Focus();
                return;
            }
            if (!DB.beginTrans())
            {
                MessageBox.Show("COULD NOT BEGIN TRANSACTION !!", "ERROR");
                return;
            }
            if (manage_btn.Text.Trim() == "ADD")
            {
                queryString = "INSERT INTO EMP_DEPT (DEPT_NAME, DEPT_CODE, IS_USE) VALUES ('" + department_name.Text.Trim() + "', '" + department_code.Text + "', " + ((ComboItem)active.SelectedItem).Key.ToString() + ")";
                DB.beginTrans();
                if (DB.set(queryString, "INSERT DEPARTMENT"))
                {
                    GF.closeLoading();
                    DB.close();
                    MessageBox.Show("DEPARTMENT '" + department_name.Text.Trim() + "[" + department_code.Text.Trim() + "]' IS ADDED !!", "COMPLETED");
                    ((btn_dgv)this.Owner.Controls["btn_dgv"]).refresh_btn.PerformClick();
                    this.Close();
                }
                else
                {
                    GF.closeLoading();
                    MessageBox.Show("ERROR INSERT DEPARTMENT INTO DATABASE !!", "ERROR");
                    return;
                }
            }

            if (manage_btn.Text.Trim() == "UPDATE")
            {
                queryString = "UPDATE EMP_DEPT SET DEPT_NAME = '" + department_name.Text.Trim() + "', DEPT_CODE = '" + department_code.Text + "', IS_USE = " + ((ComboItem)active.SelectedItem).Key.ToString() + " WHERE EMP_DEPT_ID = " + GF.selected_id.ToString();
                DB.beginTrans();
                if (DB.set(queryString, "UPDATE DEPARTMENT[" + GF.selected_id.ToString() + "]"))
                {
                    GF.closeLoading();
                    DB.close();
                    MessageBox.Show("DEPARTMENT '" + department_name.Text.Trim() + "[" + department_code.Text.Trim() + "]' IS UPDATED !!", "COMPLETED");
                    ((btn_dgv)this.Owner.Controls["btn_dgv"]).refresh_btn.PerformClick();
                    this.Close();
                }
                else
                {
                    GF.closeLoading();
                    MessageBox.Show("ERROR UPDATE DEPARTMENT IN DATABASE !!", "ERROR");
                    return;
                }
            }
        }

        private void config_department_manage_Load(object sender, EventArgs e)
        {
            if (manage_btn.Text.Trim() == "UPDATE")
            {
                string queryString = "SELECT TOP 1 * FROM EMP_DEPT WHERE EMP_DEPT_ID = " + GF.selected_id.ToString();
                using (DataTable DT = DB.getS(queryString, null, "GET EMP DEPT[" + GF.selected_id.ToString() + "]", false))
                {
                    foreach (DataRow row in DT.Rows)
                    {
                        department_name.Text = row["DEPT_NAME"].ToString();
                        department_code.Text = row["DEPT_CODE"].ToString();
                        active.Text = (row["IS_USE"].ToString() == "1" ? "ACTIVE" : "INACTIVE");
                    }
                }
            }
        }

        private void config_department_manage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Activate();
        }
    }
}
