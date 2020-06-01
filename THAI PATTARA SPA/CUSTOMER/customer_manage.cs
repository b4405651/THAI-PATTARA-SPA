using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.CUSTOMER
{
    public partial class customer_manage : Form
    {
        int currID = -1;
        public customer_manage()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };

            gender.Items.Add(new ComboItem(0, "FEMALE"));
            gender.Items.Add(new ComboItem(1, "MALE"));
            gender.SelectedIndex = 0;
        }

        private void customer_manage_Load(object sender, EventArgs e)
        {
            if (manage_btn.Text.Trim() == "ADD")
            {
                code.Text = (DateTime.Now.Year + 543).ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00");
            }
            if (manage_btn.Text.Trim() == "UPDATE")
            {
                String queryString = "SELECT TOP 1 * FROM CUSTOMER WHERE CUSTOMER_ID = " + GF.selected_id.ToString();

                using (DataTable DT = DB.getS(queryString, null, "GET CUSTOMER[" + GF.selected_id.ToString() + "]", false))
                {
                    if (DT.Rows.Count > 0)
                    {
                        foreach (DataRow row in DT.Rows)
                        {
                            if (row["BIRTHDAY"].ToString() != "")
                            {
                                string[] bdayArr = row["BIRTHDAY"].ToString().Split(' ')[0].Split('/');
                                int[] bday = new int[bdayArr.Length];
                                int count = 0;
                                foreach (String bdayStr in bdayArr)
                                {
                                    bday[count] = Convert.ToInt32(bdayStr);
                                    count++;
                                }
                                birthday.Text = bday[0].ToString("00") + "/" + bday[1].ToString("00") + "/" + bday[2].ToString("0000");
                            }
                            code.Text = row["CODE"].ToString();
                            customer_name.Text = row["CUSTOMER_NAME"].ToString();
                            rus_name.Text = row["RUS_NAME"].ToString();
                            tel.Text = row["TEL"].ToString();
                            email.Text = row["EMAIL"].ToString();
                            
                            wedding_anniversary.Text = row["WEDDING_ANNIVERSARY"].ToString();
                            note.Text = row["NOTE"].ToString();

                            for (int index = 0; index < gender.Items.Count; index++)
                            {
                                if (((ComboItem)gender.Items[index]).Key.ToString() == row["GENDER"].ToString())
                                {
                                    gender.SelectedIndex = index;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            String queryString = "";
            
            if (customer_name.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER CUSTOMER NAME !!", "ERROR");
                customer_name.Select();
                return;
            }

            if (tel.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER CUSTOMER PHONE NUMBER !!", "ERROR");
                tel.Select();
                return;
            }

            /*if (email.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER CUSTOMER E-MAIL !!", "ERROR");
                email.Select();
                return;
            }

            if (birthday.Text.Trim() == "/  /")
            {
                MessageBox.Show("PLEASE ENTER BIRTHDAY !!", "ERROR");
                birthday.Select();
                return;
            }

            if (wedding_anniversary.Text.Trim() != "/")
            {
                if (wedding_anniversary.Text.Trim().Length < 5)
                {
                    MessageBox.Show("WEDDING ANNIVERSARY DATE MUST BE IN 'MM/DD' !!\r\n\r\nFORMAT : (01-12)/(01-31)", "ERROR");
                    wedding_anniversary.Select();
                    return;
                }
                string[] WA = wedding_anniversary.Text.Trim().Split('/');
                if (Convert.ToInt32(WA[0]) < 1 || Convert.ToInt32(WA[0]) > 12)
                {
                    MessageBox.Show("MM FOR WEDDING ANNIVERSARY DATE MUST BE BETWEEN 01-12", "ERROR");
                    wedding_anniversary.Select(0, 2);
                    return;
                }
                if (Convert.ToInt32(WA[1]) < 1 || Convert.ToInt32(WA[1]) > GF.maxDay[Convert.ToInt32(WA[0]) - 1])
                {
                    MessageBox.Show("DD IN MONTH[" + WA[0] + " FOR WEDDING ANNIVERSARY DATE MUST BE BETWEEN 01-" + GF.maxDay[Convert.ToInt32(WA[0]) - 1].ToString() , "ERROR");
                    wedding_anniversary.Select(3, 5);
                    return;
                }
            }*/

            Dictionary<string, string> Params = new Dictionary<string, string>();
            /*Params.Add("@customer_name", customer_name.Text);
            Params.Add("@tel", tel.Text);*/

            queryString = "SELECT * FROM CUSTOMER WHERE CUSTOMER_NAME = '" + customer_name.Text + "' AND TEL = '" + tel.Text + "'";
            if (manage_btn.Text.Trim() == "UPDATE") queryString += " AND CUSTOMER_ID != " + GF.selected_id.ToString();

            using (DataTable DT = DB.getS(queryString, Params, "CHECK CUSTOMER IF EXISTED", false))
            {
                if (DT.Rows.Count > 0)
                {
                    MessageBox.Show("THIS CUSTOMER NAME IS ALREADY EXISTED !!", "ERROR");
                    return;
                }
            }

            if (tel.Text.Trim().Substring(0, 1) == "7")
                tel.Text = "8" + tel.Text.Trim().Substring(1);

            if (manage_btn.Text.Trim() == "ADD")
            {
                queryString = "INSERT INTO CUSTOMER ( CUSTOMER_NAME, RUS_NAME, CODE, GENDER, TEL, EMAIL, BIRTHDAY, WEDDING_ANNIVERSARY, REGISTER_DATE, NOTE, IS_NEIGHBOR ) VALUES (";
                queryString += "N'" + customer_name.Text.Trim() + "', ";
                queryString += "N'" + rus_name.Text.Trim() + "', ";
                queryString += "'" + code.Text.Trim() + "', ";
                queryString += ((ComboItem)gender.SelectedItem).Key.ToString() + ", ";
                queryString += "'" + tel.Text.Trim() + "', ";
                queryString += "'" + email.Text.Trim() + "', ";
                queryString += (!GF.emptyDate(birthday.Text.Trim()) ? GF.modDate(birthday.Text.Trim()) : "NULL") + ", ";
                queryString += "'" + (wedding_anniversary.Text.Trim() == "/" ? "NULL" : wedding_anniversary.Text.Trim()) + "', ";
                queryString += "GETDATE(), ";
                queryString += "N'" + note.Text.Trim() + "', ";
                queryString += (is_neighbor.Checked ? "1" : "0") + ")";

                GF.showLoading(this);
                DB.beginTrans();

                currID = DB.insertReturnID(queryString, "INSERT CUSTOMER RETURN ID");
                if (currID == -1)
                {
                    GF.closeLoading();
                    MessageBox.Show("ERROR INSERT CUSTOMER !!", "ERROR");
                    return;
                }

                DB.close();
                GF.closeLoading();
                if (this.Owner.Name != "reservation_manage") ((btn_dgv)this.Owner.Controls["btn_dgv"]).refresh_btn.PerformClick();
                this.Close();
            }

            if (manage_btn.Text.Trim() == "UPDATE")
            {
                queryString = "UPDATE CUSTOMER SET ";
                queryString += "CUSTOMER_NAME = N'" + customer_name.Text.Trim() + "', ";
                queryString += "RUS_NAME = N'" + rus_name.Text.Trim() + "', ";
                queryString += "GENDER = " + ((ComboItem)gender.SelectedItem).Key.ToString() + ", ";
                queryString += "TEL = '" + tel.Text.Trim() + "', ";
                queryString += "EMAIL = '" + email.Text.Trim() + "', ";
                queryString += "BIRTHDAY = " + (!GF.emptyDate(birthday.Text.Trim()) ? GF.modDate(birthday.Text.Trim()) : "NULL") + ", ";
                queryString += "WEDDING_ANNIVERSARY = '" + (wedding_anniversary.Text.Trim() == "/" ? "NULL" : wedding_anniversary.Text.Trim()) + "', ";
                queryString += "NOTE = N'" + note.Text.Trim() + "', ";
                queryString += "IS_NEIGHBOR = " + (is_neighbor.Checked ? "1" : "0") + " ";
                queryString += "WHERE CUSTOMER_ID = " + GF.selected_id.ToString();

                GF.showLoading(this);
                DB.beginTrans();
                if (!DB.set(queryString, "UPDATE CUSTOMER[" + GF.selected_id.ToString() + "]"))
                {
                    GF.closeLoading();
                    MessageBox.Show("ERROR UPDATE CUSTOMER !!", "ERROR");
                    return;
                }
                else
                {
                    DB.close();
                    //MessageBox.Show("CUSTOMER IS UPDATED !!", "COMPLETED");
                    ((btn_dgv)this.Owner.Controls["btn_dgv"]).refresh_btn.PerformClick();
                    GF.closeLoading();
                    this.Close();
                }
            }
        }

        private void customer_manage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null)
            {
                if (this.Owner.Name == "reservation_manage")
                {
                    if (this.currID != -1)
                    {
                        ((RESERVATION.reservation_manage)this.Owner).customer_name.SetID(this.currID);
                        //((RESERVATION.reservation_manage)this.Owner).customer_name.SetText(this.currID, customer_name.Text.Trim() + " - " + gender.Text + " - " + tel.Text.Trim());
                        ((RESERVATION.reservation_manage)this.Owner).customer_name.Focus();
                        ((RESERVATION.reservation_manage)this.Owner).cancel_btn.Focus();
                    }
                }
                if (this.Owner.Name == "cashier")
                {
                    if (this.currID != -1)
                    {
                        ((SHOP.cashier)this.Owner).customer_id.SetID(this.currID);
                        //((SHOP.cashier)this.Owner).customer_id.SetText(this.currID, customer_name.Text.Trim() + " - " + gender.Text + " - " + tel.Text.Trim());
                        ((SHOP.cashier)this.Owner).customer_id.Focus();
                        ((SHOP.cashier)this.Owner).item_type.Focus();
                    }
                }
                this.Owner.Activate();
            }
        }

        private void tel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void history_btn_Click(object sender, EventArgs e)
        {
            using (customer_history history = new customer_history())
            {
                history.customer_id = GF.selected_id.ToString();
                history.Owner = this;
                history.ShowDialog();
            }
        }

        private void membercard_btn_Click(object sender, EventArgs e)
        {
            using (membercard_list cardList = new membercard_list())
            {
                cardList.customer_id = GF.selected_id.ToString();
                cardList.Owner = this;
                cardList.ShowDialog();
            }
        }
    }
}
