using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.ITEM
{
    public partial class unit_manage : Form
    {
        public unit_manage()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };
        }

        private void unit_manage_Load(object sender, EventArgs e)
        {
            if (manage_btn.Text.Trim() == "UPDATE")
            {
                String queryString = "SELECT * FROM UNIT WHERE UNIT_ID = " + GF.selected_id.ToString();
                using (DataTable DT = DB.getS(queryString, null, "GET UNIT[" + GF.selected_id.ToString() + "]", false))
                {
                    if (DT.Rows.Count == 1)
                    {
                        unit_name.Text = DT.Rows[0]["UNIT_NAME"].ToString();
                    }
                }
            }
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if (unit_name.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER UNIT NAME !!", "ERROR");
                unit_name.Select();
                return;
            }

            DB.beginTrans();
            String queryString = "SELECT * FROM UNIT WHERE UNIT_NAME = '" + unit_name.Text + "'";
            if (manage_btn.Text.Trim() == "UPDATE") queryString += " AND UNIT_ID != " + GF.selected_id.ToString();

            Dictionary<string, string> Params = new Dictionary<string, string>();
            //Params.Add("@unit_name", unit_name.Text);

            using (DataTable DT = DB.getS(queryString, Params, "CHECK IF UNIT NAME EXISTED", false))
            {
                if (DT.Rows.Count > 0)
                {
                    MessageBox.Show("THIS UNIT IS ALREADY EXISTED !!", "ERROR");
                    return;
                }
            }

            if (manage_btn.Text.Trim() == "ADD")
            {
                queryString = "INSERT INTO UNIT (UNIT_NAME) VALUES ('" + unit_name.Text.Trim() + "')";
                if (DB.set(queryString, "INSERT UNIT"))
                {
                    DB.close();
                    ((btn_dgv)this.Owner.Controls["btn_dgv"]).refresh_btn.PerformClick();
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("ERROR INSERT UNIT !!", "ERROR");
                    return;
                }
            }

            if (manage_btn.Text.Trim() == "UPDATE")
            {
                queryString = "UPDATE UNIT SET UNIT_NAME = '" + unit_name.Text.Trim() + "' WHERE UNIT_ID = " + GF.selected_id.ToString();
                if (DB.set(queryString, "UPDATE UNIT[" + GF.selected_id.ToString() + "]"))
                {
                    DB.close();
                    ((btn_dgv)this.Owner.Controls["btn_dgv"]).refresh_btn.PerformClick();
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("ERROR UPDATE UNIT !!", "ERROR");
                    return;
                }
            }
        }

        private void unit_manage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Activate();
        }
    }
}
