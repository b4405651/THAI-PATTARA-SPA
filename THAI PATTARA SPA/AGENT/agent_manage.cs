using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.AGENT
{
    public partial class agent_manage : Form
    {
        String queryString = "";
                public int id = -1;
        public agent_manage()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };

            agent_type.Items.Add(new ComboItem(0, "COMPANY"));
            agent_type.Items.Add(new ComboItem(1, "PERSON"));
            GF.resizeComboBox(agent_type);
            agent_type.SelectedIndex = 0;
        }

        private void agent_manage_Load(object sender, EventArgs e)
        {
            if (id > 0)
            {
                queryString = "SELECT * FROM AGENT WHERE AGENT_ID = " + id.ToString();
                using (DataTable DT = DB.getS(queryString, null, "GET DETAIL OF AGENT[" + id.ToString() + "]", false))
                {
                    agent_name.Text = DT.Rows[0]["AGENT_NAME"].ToString();
                    tel.Text = DT.Rows[0]["TEL"].ToString();
                    contact_person.Text = DT.Rows[0]["CONTACT_PERSON"].ToString();

                    foreach (ComboItem item in agent_type.Items)
                    {
                        if (item.Key.ToString() == DT.Rows[0]["AGENT_TYPE"].ToString())
                        {
                            agent_type.Text = item.Value;
                            break;
                        }
                    }
                }
            }
        }

        private void agent_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (agent_type.SelectedIndex == 0)
                contact_person.Enabled = true;
            else
                contact_person.Enabled = false;
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if (agent_name.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER AGENT NAME !!", "ERROR");
                agent_name.Select();
                return;
            }
            if (tel.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER THE TELEPHONE NUMBER !!", "ERROR");
                tel.Select();
                return;
            }
            if (agent_type.SelectedIndex == 0 && contact_person.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER THE NAME OF CONTACT PERSON !!", "ERROR");
                contact_person.Select();
                return;
            }

            GF.showLoading(this);
            DB.beginTrans();
            if (id == -1)
            {
                queryString = "INSERT INTO AGENT (AGENT_NAME, TEL, AGENT_TYPE, CONTACT_PERSON) VALUES (";
                queryString += "'" + agent_name.Text.Trim() + "',";
                queryString += "'" + tel.Text.Trim() + "', ";
                queryString += ((ComboItem)agent_type.SelectedItem).Key.ToString() + ", ";
                queryString += (agent_type.SelectedIndex == 0 ? ("'" + contact_person.Text.Trim() + "'") : "NULL");
                queryString += ")";
                if (!DB.set(queryString, "INSERT NEW AGENT"))
                {
                    MessageBox.Show("ERROR INSERT NEW AGENT !!", "ERROR");
                    GF.closeLoading();
                    return;
                }
            }
            else
            {
                queryString = "UPDATE AGENT SET ";
                queryString += "AGENT_NAME = '" + agent_name.Text.Trim() + "', ";
                queryString += "TEL = '" + tel.Text.Trim() + "', ";
                queryString += "AGENT_TYPE = " + ((ComboItem)agent_type.SelectedItem).Key.ToString() + ", ";
                queryString += "CONTACT_PERSON = " + (agent_type.SelectedIndex == 0 ? ("'" + contact_person.Text.Trim() + "'") : "NULL") + " ";
                queryString += "WHERE AGENT_ID = " + id.ToString();
                if (!DB.set(queryString, "UPDATE AGENT[" + id.ToString() + "]"))
                {
                    MessageBox.Show("ERROR UPDATE THE AGENT !!", "ERROR");
                    GF.closeLoading();
                    return;
                }
            }
            DB.close();
            GF.closeLoading();
            ((agent_list)Owner).btn_dgv.refresh_btn.PerformClick();
            this.Close();
        }
    }
}
