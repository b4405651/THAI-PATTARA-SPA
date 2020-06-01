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
    public partial class item_category_manage : Form
    {
        public item_category_manage()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if (item_type_name.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER CATEGORY NAME !!", "ERROR");
                item_type_name.Focus();
                return;
            }
            GF.showLoading(this);
            DB.beginTrans();

            string queryString = "SELECT * FROM ITEM_TYPE WHERE ITEM_TYPE_NAME = '" + item_type_name.Text + "'";
            if (manage_btn.Text.Trim() == "UPDATE") queryString += " AND ITEM_TYPE_ID != " + GF.selected_id.ToString();

            Dictionary<string, string> Params = new Dictionary<string, string>();
            //Params.Add("@item_name", item_type_name.Text);

            using (DataTable myDT = DB.getS(queryString, Params, "CHECK ITEM TYPE BEFORE INSERT", false))
            {
                if (myDT.Rows.Count > 0)
                {
                    MessageBox.Show("THIS ITEM CATEGORY IS ALREADY EXISTED.", "ERROR");
                    GF.closeLoading();
                    return;
                }
            }
            switch (manage_btn.Text)
            {
                case "ADD":
                    queryString = "INSERT INTO ITEM_TYPE (ITEM_TYPE_NAME) VALUES ('" + item_type_name.Text.Trim() + "')";
                    DB.beginTrans();
                    if (DB.set(queryString, "INSERT ITEM TYPE"))
                    {
                        GF.closeLoading();
                        DB.close();

                        ((btn_dgv)this.Owner.Controls["btn_dgv"]).refresh_btn.PerformClick();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("ERROR ADDING ITEM CATEGORY !!", "ERROR");
                        GF.closeLoading();
                        return;
                    }

                    break;
                case "UPDATE":
                    queryString = "UPDATE ITEM_TYPE SET ITEM_TYPE_NAME = '" + item_type_name.Text.Trim() + "' WHERE ITEM_TYPE_ID = " + GF.selected_id.ToString();
                    DB.beginTrans();
                    if (DB.set(queryString, "UPDATE ITEM TYPE"))
                    {
                        GF.closeLoading();
                        DB.close();

                        ((btn_dgv)this.Owner.Controls["btn_dgv"]).refresh_btn.PerformClick();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("ERROR UPDATING ITEM CATEGORY !!", "ERROR");
                        GF.closeLoading();
                        return;
                    }
                    break;
            }
        }

        private void item_category_manage_Load(object sender, EventArgs e)
        {
            if (manage_btn.Text.Trim() == "UPDATE")
            {
                string queryString = "SELECT TOP 1 * FROM ITEM_TYPE WHERE item_type_id = " + GF.selected_id.ToString();
                using (DataTable myDT = DB.getS(queryString, null, "GET ITEM CAT [" + GF.selected_id.ToString() + "]", false))
                {
                    item_type_name.Text = myDT.Rows[0]["item_type_name"].ToString();
                }
            }
        }

        private void item_category_manage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Activate();
        }
    }
}
