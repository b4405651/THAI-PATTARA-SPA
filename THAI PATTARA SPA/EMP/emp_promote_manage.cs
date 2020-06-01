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
    public partial class emp_promote_manage : Form
    {
        public emp_promote_manage()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };

            GF.resizeMgmtForm(this);
        }

        private void attachment_btn_Click(object sender, EventArgs e)
        {
            GF.loadAttachmentPage(this, GF.selected_id);
        }

        private void new_wage_Leave(object sender, EventArgs e)
        {
            if (new_wage.Text.Trim() != "")
            {
                double Num;
                if (!double.TryParse(new_wage.Text.Trim(), out Num))
                {
                    MessageBox.Show("NEW WAGE MUST BE ONLY IN NUMBER !!", "ERROR");
                    new_wage.Select();
                    return;
                }
            }
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if (GF.emptyDate(promote_date.Text.Trim()))
            {
                MessageBox.Show("PLEASE ENTER PROMOTE DATE !!", "ERROR");
                promote_date.Focus();
                return;
            }
            if (new_wage.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER NEW WAGE !!", "ERROR");
                new_wage.Focus();
                return;
            }
            string queryString = "SELECT * FROM EMP_PROMOTE WHERE promote_date = " + GF.modDate(promote_date.Text.Trim());
            if (manage_btn.Text == "UPDATE") queryString += " AND EMP_PROMOTE_ID != " + GF.selected_id.ToString();

            using (DataTable myDT = DB.getS(queryString, null, "CHECK EMP_PROMOTE BEFORE INSERT", false))
            {
                if (myDT.Rows.Count > 0)
                {
                    MessageBox.Show("THIS EMPLOYEE PROMOTE DATA IS ALREADY EXISTED IN DATABASE !!", "ERROR");
                    return;
                }
            }

            GF.showLoading(this);
            DB.beginTrans();

            if (manage_btn.Text == "ADD")
            {
                queryString = "INSERT INTO EMP_PROMOTE (EMP_ID, NEW_WAGE, PROMOTE_DATE, PROMOTED_BY) VALUES (";
                queryString += GF.selected_id.ToString() + ", ";
                queryString += new_wage.Text.Trim() + ", ";
                queryString += GF.modDate(promote_date.Text.Trim()) + ", ";
                queryString += GF.emp_id.ToString() + ")";

                if (DB.set(queryString, "INSERT EMP_PROMOTE"))
                {
                    GF.closeLoading();
                    DB.close();
                    MessageBox.Show("EMPLOYEE PROMOTE DATA IS ADDED !!", "COMPLETED");
                    
                    ((btn_dgv)this.Owner.Controls["btn_dgv"]).refresh_btn.PerformClick();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("ERROR INSERT EMPLOYEE PROMOTE DATA !!", "ERROR");
                    GF.closeLoading();
                    return;
                }
            }

            if (manage_btn.Text == "UPDATE")
            {
                queryString = "UPDATE EMP_PROMOTE SET ";
                queryString += "NEW_WAGE = " + new_wage.Text.Trim() + ", ";
                queryString += "PROMOTE_DATE = " + GF.modDate(promote_date.Text.Trim()) + ", ";
                queryString += "PROMOTED_BY = " + GF.emp_id.ToString() + " ";
                queryString += "WHERE EMP_PROMOTE_ID = " + GF.selected_id.ToString();

                if (DB.set(queryString, "UPDATE EMP_PROMOTE[" + GF.selected_id.ToString() + "]"))
                {
                    GF.closeLoading();
                    DB.close();
                    MessageBox.Show("EMPLOYEE PROMOTE DATA IS UPDATED !!", "COMPLETED");
                    
                    ((btn_dgv)this.Owner.Controls["btn_dgv"]).refresh_btn.PerformClick();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("ERROR UPDATE EMPLOYEE PROMOTE DATA !!", "ERROR");
                    GF.closeLoading();
                    return;
                }
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void emp_promote_manage_Load(object sender, EventArgs e)
        {
            if (manage_btn.Text == "UPDATE")
            {
                string queryString = @"SELECT 
                    A.NEW_WAGE, CONVERT(VARCHAR,A.PROMOTE_DATE,101) PROMOTE_DATE, B.FULLNAME PROMOTED_BY
                    FROM EMP_PROMOTE A
                    INNER JOIN EMPLOYEE B ON A.PROMOTED_BY = B.EMP_ID
                    WHERE A.EMP_PROMOTE_ID = " + GF.selected_id.ToString();

                using (DataTable myDT = DB.getS(queryString, null, "GET EMP_PROMOTE[" + GF.selected_id.ToString() + "]", false))
                {
                    new_wage.Text = myDT.Rows[0]["NEW_WAGE"].ToString().Trim();
                    promote_date.Text = myDT.Rows[0]["PROMOTE_DATE"].ToString().Trim();
                }
            }
        }

        private void emp_promote_manage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Activate();
        }

        private void new_wage_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
