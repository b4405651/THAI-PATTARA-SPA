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
    public partial class emp_leave_manage : Form
    {
        public emp_leave_manage()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };

            GF.resizeMgmtForm(this);
        }

        private void emp_leave_manage_Load(object sender, EventArgs e)
        {
            if (manage_btn.Text == "UPDATE")
            {
                string queryString = @"SELECT TOP 1 
                    A.REASON, CONVERT(VARCHAR,A.START_DATE,101) START_DATE, CONVERT(VARCHAR,A.END_DATE,101) END_DATE, B.FULLNAME APPROVED_BY
                    FROM EMP_LEAVE A
                    INNER JOIN EMPLOYEE B ON A.APPROVED_BY = B.EMP_ID
                    WHERE A.EMP_LEAVE_ID = " + GF.selected_id.ToString();
                using (DataTable myDT = DB.getS(queryString, null, "GET EMP_LEAVE[" + GF.selected_id.ToString() + "]", false))
                {
                    reason.Text = myDT.Rows[0]["REASON"].ToString().Trim();
                    since.Text = myDT.Rows[0]["START_DATE"].ToString().Trim();
                    to.Text = myDT.Rows[0]["END_DATE"].ToString().Trim();
                }
            }
        }

        private void attachment_btn_Click(object sender, EventArgs e)
        {
            GF.loadAttachmentPage(this, GF.selected_id);
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if (reason.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER LEAVE REASON !!", "ERROR");
                reason.Focus();
                return;
            }
            if (GF.emptyDate(since.Text.Trim()))
            {
                MessageBox.Show("PLEASE ENTER FIRST DATE OF LEAVE !!", "ERROR");
                since.Focus();
                return;
            }
            if (GF.emptyDate(to.Text.Trim()))
            {
                MessageBox.Show("PLEASE ENTER LAST DATE OF LEAVE !!", "ERROR");
                to.Focus();
                return;
            }
            if (Convert.ToDateTime(to.Text.Trim()).CompareTo(Convert.ToDateTime(since.Text.Trim())) < 0)
            {
                MessageBox.Show("THE 'TO' DATE MUST BE LATER THAN OR SAME DAY AS 'SINCE' !!", "ERROR");
                to.Focus();
                return;
            }

            string queryString = "SELECT * FROM EMP_LEAVE WHERE start_date <= " + GF.modDate(since.Text.Trim()) + " AND " + GF.modDate(since.Text.Trim()) + " <= end_date";
            if (manage_btn.Text == "UPDATE") queryString += " AND EMP_LEAVE_ID != " + GF.selected_id.ToString();

            Dictionary<string, string> Params = new Dictionary<string, string>();
            //Params.Add("@since", GF.modDate(since.Text.Trim()));

            using (DataTable myDT = DB.getS(queryString, Params, "CHECK EMP_LEAVE BEFORE INSERT", false))
            {
                if (myDT.Rows.Count > 0)
                {
                    MessageBox.Show("THIS EMPLOYEE LEAVE DATA IS ALREADY EXISTED IN DATABASE !!", "ERROR");
                    return;
                }
            }

            GF.showLoading(this);
            DB.beginTrans();

            if (manage_btn.Text == "ADD")
            {
                queryString = "INSERT INTO EMP_LEAVE (EMP_ID, REASON, START_DATE, END_DATE, APPROVED_BY) VALUES (";
                queryString += GF.selected_id.ToString() + ", ";
                queryString += "'" + reason.Text.Trim() + "', ";
                queryString += GF.modDate(since.Text.Trim()) + ", ";
                queryString += GF.modDate(to.Text.Trim()) + ", ";
                queryString += GF.emp_id.ToString() + ")";

                if (DB.set(queryString, "INSERT EMP_LEAVE"))
                {
                    GF.closeLoading();
                    DB.close();
                    MessageBox.Show("EMPLOYEE LEAVE DATA IS ADDED !!", "COMPLETED");

                    ((btn_dgv)this.Owner.Controls["btn_dgv"]).refresh_btn.PerformClick();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("ERROR INSERT EMPLOYEE LEAVE DATA !!", "ERROR");
                    GF.closeLoading();
                    return;
                }
            }

            if (manage_btn.Text == "UPDATE")
            {
                queryString = "UPDATE EMP_LEAVE SET ";
                queryString += "REASON = '" + reason.Text.Trim() + "', ";
                queryString += "START_DATE = " + GF.modDate(since.Text.Trim()) + ", ";
                queryString += "END_DATE = " + GF.modDate(to.Text.Trim()) + ", ";
                queryString += "APPROVED_BY = " + GF.emp_id.ToString() + " ";
                queryString += "WHERE EMP_LEAVE_ID = " + GF.selected_id.ToString();

                if (DB.set(queryString, "UPDATE EMP_LEAVE[" + GF.selected_id.ToString() + "]"))
                {
                    GF.closeLoading();
                    DB.close();
                    MessageBox.Show("EMPLOYEE LEAVE DATA IS UPDATED !!", "COMPLETED");

                    ((btn_dgv)this.Owner.Controls["btn_dgv"]).refresh_btn.PerformClick();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("ERROR UPDATE EMPLOYEE LEAVE DATA !!", "ERROR");
                    GF.closeLoading();
                    return;
                }
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void emp_leave_manage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Activate();
        }
    }
}
