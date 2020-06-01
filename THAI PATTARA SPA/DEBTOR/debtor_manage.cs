using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.DEBTOR
{
    public partial class debtor_manage : Form
    {
        public int id = -1;

        String queryString = "";
        public debtor_manage()
        {
            InitializeComponent();

            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };

            GF.addKeyUp(this);

            search_name.parentForm = this;

            queryString = "SELECT * FROM DEBTOR_TYPE ORDER BY DEBTOR_TYPE_ID";
            using (DataTable DT = DB.getS(queryString, null, "GET DEBTOR_TYPE", false))
            {
                foreach (DataRow row in DT.Rows)
                {
                    debtor_type_id.Items.Add(new ComboItem(Convert.ToInt32(row["DEBTOR_TYPE_ID"].ToString()), row["DEBTOR_TYPE_NAME"].ToString()));
                }
            }
            debtor_type_id.SelectedIndex = 0;
        }

        private void debtor_manage_Load(object sender, EventArgs e)
        {
            if (id != -1)
            {
                GF.showLoading(this);
                queryString = "SELECT TOP 1 * FROM DEBTOR WHERE DEBTOR_ID = " + id.ToString();
                using (DataTable DT = DB.getS(queryString, null, "GET DEBTOR[" + id.ToString() + "]", false))
                {
                    foreach (DataRow row in DT.Rows)
                    {
                        int index = -1;
                        foreach (ComboItem item in debtor_type_id.Items)
                        {
                            index++;
                            if (item.Key.ToString() == row["DEBTOR_TYPE_ID"].ToString())
                            {
                                debtor_type_id.SelectedIndex = index;
                                break;
                            }
                        }
                        if (index == -1) debtor_type_id.SelectedIndex = 0;
                        if (row["TARGET_ID"].ToString() != "")
                            search_name.SetID(Convert.ToInt32(row["TARGET_ID"].ToString()));
                        else
                        {
                            name.Text = row["DEBTOR_NAME"].ToString();
                            id_card_no.Text = row["ID_CARD_NO"].ToString();
                            tel.Text = row["TEL"].ToString();
                            email.Text = row["EMAIL"].ToString();
                            address.Text = row["ADDRESS"].ToString();
                        }
                    }
                }
                GF.closeLoading();
            }
        }

        private void debtor_type_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboItem sel = (ComboItem)((ComboBox)sender).SelectedItem;
            if (sel.Key == 1)
            {
                if (Controls.Find("search_name", true).Count() == 1)
                    Controls.Remove(search_name);
                if (Controls.Find("add_data_btn", true).Count() == 1)
                    Controls.Remove(add_data_btn);
                if (Controls.Find("search_name_lbl", true).Count() == 1)
                    Controls.Remove(search_name_lbl);

                if(Controls.Find("data_gb", true).Count() == 0){
                    Controls.Add(data_gb);
                    name.Select();
                }
                manage_btn.Top = 280;
                this.Height = 382;
                //data_gb.Enabled = true;
            }
            else
            {
                if (Controls.Find("data_gb", true).Count() == 1)
                {
                    Controls.Remove(data_gb);
                }

                search_name.Mode = sel.Value;

                if (Controls.Find("search_name", true).Count() == 0)
                    Controls.Add(search_name);
                else
                    search_name.SetText(-1, "");

                if (Controls.Find("add_data_btn", true).Count() == 0)
                    Controls.Add(add_data_btn);

                if (Controls.Find("search_name_lbl", true).Count() == 0)
                    Controls.Add(search_name_lbl);

                search_name.Select();
                //data_gb.Enabled = false;
                manage_btn.Top = 70;
                this.Height = 172;
            }
        }

        private void add_data_btn_Click(object sender, EventArgs e)
        {
            switch (debtor_type_id.Text)
            {
                case "CUSTOMER":
                    CUSTOMER.customer_manage add_customer;
                    using (add_customer = new CUSTOMER.customer_manage())
                    {
                        add_customer.Owner = this;
                        add_customer.ShowDialog();
                    };
                    break;
                case "EMPLOYEE":
                    EMP.emp_data_manage add_employee;
                    using (add_employee = new EMP.emp_data_manage())
                    {
                        add_employee.Owner = this;
                        add_employee.ShowDialog();
                    };
                    break;
            }
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            queryString = "";

            if (debtor_type_id.Text == "OUTSIDER")
            {
                if (name.Text.Trim() == "")
                {
                    MessageBox.Show("PLEASE ENTER THE DEBTOR'S NAME !!", "ERROR");
                    name.Select();
                    return;
                }
                if (id_card_no.Text.Trim() == "")
                {
                    MessageBox.Show("PLEASE ENTER ID CARD NUMBER OF DEBTOR !!", "ERROR");
                    id_card_no.Select();
                    return;
                }
                if (tel.Text.Trim() == "")
                {
                    MessageBox.Show("PLEASE ENTER PHONE NUMBER OF DEBTOR !!", "ERROR");
                    tel.Select();
                    return;
                }
                if (email.Text.Trim() == "")
                {
                    MessageBox.Show("PLEASE ENTER EMAIL OF DEBTOR !!", "ERROR");
                    email.Select();
                    return;
                }
                if (address.Text.Trim() == "")
                {
                    MessageBox.Show("PLEASE ENTER THE ADDRESS OF DEBTOR !!", "ERROR");
                    address.Select();
                    return;
                }
            }
            else
            {
                if (search_name.currentID == -1)
                {
                    MessageBox.Show("PLEASE CHOOSE THE " + debtor_type_id.Text + " !!", "ERROR");
                    search_name.Select();
                    return;
                }
            }

            GF.showLoading(this);
            DB.beginTrans();
            if (manage_btn.Text == "ADD")
            {
                if (debtor_type_id.Text == "OUTSIDER")
                {
                    queryString = "INSERT INTO DEBTOR (DEBTOR_TYPE_ID, TARGET_ID, DEBTOR_NAME, ID_CARD_NO, TEL, EMAIL, ADDRESS, INPUT_BY, INPUT_DATETIME) VALUES (";
                    queryString += ((ComboItem)debtor_type_id.SelectedItem).Key.ToString() + ", ";
                    queryString += "NULL, ";
                    queryString += "'" + name.Text.Trim() + "', ";
                    queryString += "'" + id_card_no.Text.Trim() + "', ";
                    queryString += "'" + tel.Text.Trim() + "', ";
                    queryString += "'" + email.Text.Trim() + "', ";
                    queryString += "'" + address.Text.Trim() + "', ";
                    queryString += GF.emp_id + ", CURRENT_TIMESTAMP)";
                }
                else
                {
                    queryString = "INSERT INTO DEBTOR (DEBTOR_TYPE_ID, TARGET_ID, DEBTOR_NAME, ID_CARD_NO, TEL, EMAIL, ADDRESS, INPUT_BY, INPUT_DATETIME) VALUES (";
                    queryString += ((ComboItem)debtor_type_id.SelectedItem).Key.ToString() + ", ";
                    queryString += search_name.currentID.ToString() + ", ";
                    queryString += "NULL, ";
                    queryString += "NULL, ";
                    queryString += "NULL, ";
                    queryString += "NULL, ";
                    queryString += "NULL, ";
                    queryString += GF.emp_id + ", ";
                    queryString += "CURRENT_TIMESTAMP)";
                }

                id = DB.insertReturnID(queryString, "INSERT DEBTOR");
                if (id == -1)
                {
                    MessageBox.Show("ERROR INSERT DEBTOR !!", "ERROR");
                    GF.closeLoading();
                    return;
                }
            }
            if (manage_btn.Text.Trim() == "UPDATE" && id != -1)
            {
                queryString = "UPDATE DEBTOR SET DEBTOR_TYPE_ID = " + ((ComboItem)debtor_type_id.SelectedItem).Key.ToString() + ", ";
                if (debtor_type_id.Text == "OUTSIDER")
                {
                    queryString += "TARGET_ID = NULL, DEBTOR_NAME = '" + name.Text.Trim() + "', ID_CARD_NO = '" + id_card_no.Text.Trim() + "', TEL = '" + tel.Text.Trim() + "', EMAIL = '" + email.Text.Trim() + "', ADDRESS = '" + address.Text.Trim() + "'";
                }
                else
                {
                    queryString += "TARGET_ID = " + search_name.currentID.ToString() + ", DEBTOR_NAME = NULL, ID_CARD_NO = NULL, TEL = NULL, EMAIL = NULL, ADDRESS = NULL";
                }
                queryString += " WHERE DEBTOR_ID = " + id.ToString();

                if (!DB.set(queryString, "UPDATE DEBTOR[" + id.ToString() + "]"))
                {
                    MessageBox.Show("ERROR UPDATE DEBTOR !!", "ERROR");
                    GF.closeLoading();
                    return;
                }
            }

            DB.close();
            GF.closeLoading();
            if(this.Owner.Name == "debtor_data") ((debtor_data)this.Owner).btn_dgv.search_btn.PerformClick();
            this.Close();
        }

        private void debtor_manage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null)
            {
                if (this.Owner.Name == "payment")
                {
                    if (this.id != -1)
                    {
                        ((SHOP.payment)this.Owner).debtor_id.SetID(this.id);
                        ((SHOP.payment)this.Owner).debtor_id.Focus();
                    }
                }
                this.Owner.Activate();
            }
        }
    }
}
