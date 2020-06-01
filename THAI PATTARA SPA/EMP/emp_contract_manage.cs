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
    public partial class emp_contract_manage : Form
    {
        int _id = -1;
        bool _gen = false;
        int new_id = -1;

        public int id { get { return _id; } set { _id = value; } }
        public bool gen { get { return _gen; } set { _gen = value; } }

        public emp_contract_manage()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };

            GF.resizeMgmtForm(this);
        }

        private void emp_contract_manage_Load(object sender, EventArgs e)
        {
            if (!gen)
            {
                string queryString = "SELECT TOP 1 CONVERT(VARCHAR,START_DATE,101) START_DATE, CONVERT(VARCHAR,END_DATE,101) END_DATE FROM EMP_CONTRACT WHERE EMP_CONTRACT_ID = " + id.ToString();
                using (DataTable DT = DB.getS(queryString, null, "GET EMP_CONTRACT[" + id.ToString() + "]", false))
                {
                    foreach(DataRow row in DT.Rows){
                        start_date.Text = row["START_DATE"].ToString();
                        end_date.Text = row["END_DATE"].ToString();
                    }
                }
            }
        }

        private void attachment_btn_Click(object sender, EventArgs e)
        {
            GF.loadAttachmentPage(this, this.id);
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            if (new_id == -1 && gen == true)
            {
                GF.deleteTempAttachment(id, this.Owner.Name);
            }
            this.Close();
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if (GF.emptyDate(start_date.Text.Trim()))
            {
                MessageBox.Show("PLEASE ENTER START DATE !!", "ERROR");
                start_date.Focus();
                return;
            }
            if (GF.emptyDate(end_date.Text.Trim()))
            {
                MessageBox.Show("PLEASE ENTER END DATE !!", "ERROR");
                end_date.Focus();
                return;
            }

            // CHECK IN DB
            Dictionary<string, string> Params = new Dictionary<string, string>();
            //Params.Add("@start_date", GF.modDate(start_date.Text.Trim()));

            string queryString = "SELECT * FROM EMP_CONTRACT WHERE EMP_ID = " + GF.selected_id.ToString() + " AND START_DATE <= " + GF.modDate(start_date.Text.Trim()) + " AND @start_date <= " + GF.modDate(start_date.Text.Trim()) + " ";
            if (manage_btn.Text.Trim() == "UPDATE") queryString += "AND EMP_CONTRACT_ID != " + GF.selected_id.ToString();

            using (DataTable DT = DB.getS(queryString, Params, "CHECK EMP_CONTRACT BEFORE INSERT/UPDATE", false))
            {
                if (DT.Rows.Count > 0)
                {
                    MessageBox.Show("THIS START DATE IS EXISTED IN DATABASE !!", "ERROR");
                    return;
                }
            }

            DB.beginTrans();
            if (manage_btn.Text.Trim() == "ADD") // INSERT INTO DB
            {
                queryString = "INSERT INTO EMP_CONTRACT ( EMP_ID , START_DATE , END_DATE ) VALUES ( " + GF.selected_id.ToString() + ", " + GF.modDate(start_date.Text.Trim()) + ", " + GF.modDate(end_date.Text.Trim()) + " )";
                new_id = DB.insertReturnID(queryString, "INSERT EMP_CONTACT RETURN ID");
                if (gen)
                {
                    // UPDATE GEN OWNER_ID TO NEW_ID
                    queryString = "UPDATE ATTACHMENT SET OWNER_ID = " + new_id.ToString() + " WHERE OWNER_ID = " + id.ToString() + " AND OWNER_FORM LIKE '" + this.Owner.Name + "'";
                    if (!DB.set(queryString, "UPDATE ATTACHMENT GEN ID[" + id.ToString() + " > " + new_id.ToString() + "]"))
                    {
                        MessageBox.Show("ERROR UPDATE ATTACHMENT GEN ID !!", "ERROR");
                        GF.closeLoading();
                        return;
                    }
                    
                    // UPDATE CONTRACT END DATE IN EMPLOYEE
                    // CHECK IF THIS END_DATE FOR THIS EMPLOYEE IS LATER THAN IN DB
                    // IF YES => MODIFY
                    queryString = "SELECT * FROM EMPLOYEE WHERE EMP_ID = " + GF.selected_id.ToString() + " AND (@end_date > CONTRACT_END_DATE OR CONTRACT_END_DATE IS NULL)";
                    Params = new Dictionary<string, string>();
                    Params.Add("@end_date", GF.modDate(end_date.Text.Trim()));

                    using (DataTable DT = DB.getS(queryString, Params, "GET EMP_ID FOR MODIFY CONTRACT END DATE", false))
                    {
                        if (DT.Rows.Count != 0)
                        {
                            if (DB.set("UPDATE EMPLOYEE SET CONTRACT_END_DATE = " + GF.modDate(end_date.Text.Trim()) + " WHERE EMP_ID = " + GF.selected_id.ToString(), "MODIFY CONTRACT_END_DATE OF EMP_ID[" + GF.selected_id.ToString() + "]"))
                            {
                                GF.closeLoading();
                                DB.close();
                                MessageBox.Show("EMP_CONTRACT IS ADDED !!", "COMPLETED");
                                ((btn_dgv)this.Owner.Controls["btn_dgv"]).refresh_btn.PerformClick();
                                this.Close();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("ERROR UPDATE CONTRACT_END_DATE OF EMPLOYEE !!", "ERROR");
                                GF.closeLoading();
                                return;
                            }
                        }
                    }
                }
            }
            if (manage_btn.Text.Trim() == "UPDATE") // UPDATE DB
            {
                queryString = "UPDATE EMP_CONTRACT SET ";
                queryString += "START_DATE = " + GF.modDate(start_date.Text.Trim()) + ", ";
                queryString += "END_DATE = " + GF.modDate(end_date.Text.Trim()) + ", ";
                queryString += "WHERE EMP_CONTRACT_ID = " + id.ToString();

                if (DB.set(queryString, "UPDATE EMP_CONTRACT[" + id.ToString() + "]"))
                {
                    GF.closeLoading();
                    DB.close();
                    MessageBox.Show("EMPLOYEE CONTRACT IS UPDATED !!", "COMPLETED");
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

        private void emp_contract_manage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Activate();
        }
    }
}
