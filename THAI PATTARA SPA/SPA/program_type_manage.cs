using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.SPA
{
    public partial class program_type_manage : Form
    {
        public program_type_manage()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };
        }

        private void program_type_manage_Load(object sender, EventArgs e)
        {
            if (manage_btn.Text.Trim() == "UPDATE")
            {
                string queryString = "SELECT * FROM SPA_PROGRAM_TYPE WHERE spa_program_type_id = " + GF.selected_id.ToString();
                using (DataTable myDT = DB.getS(queryString, null, "GET ITEM CAT [" + GF.selected_id.ToString() + "]", false))
                {
                    spa_program_type_name.Text = myDT.Rows[0]["spa_program_type_name"].ToString();
                }
            }
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if (spa_program_type_name.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER SPA PROGRAM TYPE NAME NAME !!", "ERROR");
                spa_program_type_name.Focus();
                return;
            }
            GF.showLoading(this);
            DB.beginTrans();

            string queryString = "SELECT * FROM SPA_PROGRAM_TYPE WHERE SPA_PROGRAM_TYPE_NAME = '" + spa_program_type_name.Text + "'";
            if (manage_btn.Text.Trim() == "UPDATE") queryString += " AND SPA_PROGRAM_TYPE_ID != " + GF.selected_id.ToString();

            Dictionary<string, string> Params = new Dictionary<string, string>();
            //Params.Add("@spa_program_type_name", spa_program_type_name.Text);

            using (DataTable myDT = DB.getS(queryString, Params, "CHECK SPA PROGRAM TYPE BEFORE INSERT", false))
            {
                if (myDT.Rows.Count > 0)
                {
                    MessageBox.Show("THIS ITEM SPA PROGRAM TYPE NAME IS ALREADY EXISTED.", "ERROR");
                    GF.closeLoading();
                    return;
                }
            }

            switch (manage_btn.Text)
            {
                case "ADD":
                    queryString = "INSERT INTO SPA_PROGRAM_TYPE (SPA_PROGRAM_TYPE_NAME) VALUES ('" + spa_program_type_name.Text.Trim() + "')";
                    DB.beginTrans();
                    if (DB.set(queryString, "INSERT SPA PROGRAM TYPE"))
                    {
                        GF.closeLoading();
                        DB.close();

                        ((btn_dgv)this.Owner.Controls["btn_dgv"]).refresh_btn.PerformClick();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("ERROR ADDING ITEM SPA PROGRAM TYPE !!", "ERROR");
                        GF.closeLoading();
                        return;
                    }

                    break;
                case "UPDATE":
                    queryString = "UPDATE SPA_PROGRAM_TYPE SET SPA_PROGRAM_TYPE_NAME = '" + spa_program_type_name.Text.Trim() + "' WHERE SPA_PROGRAM_TYPE_ID = " + GF.selected_id.ToString();
                    DB.beginTrans();
                    if (DB.set(queryString, "UPDATE SPA PROGRAM TYPE"))
                    {
                        GF.closeLoading();
                        DB.close();

                        ((btn_dgv)this.Owner.Controls["btn_dgv"]).refresh_btn.PerformClick();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("ERROR UPDATING ITEM SPA PROGRAM TYPE !!", "ERROR");
                        GF.closeLoading();
                        return;
                    }
                    break;
            }
        }

        private void program_type_manage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Activate();
        }
    }
}
