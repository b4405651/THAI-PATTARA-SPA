using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.GIFT_CERTIFICATE
{
    public partial class gift_certificate_manage : Form
    {
        String current_card = "";
        String current_letter = "";

        String new_card = "";
        String new_letter = "";

        public gift_certificate_manage()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };

            expire_unit.Items.Add(new ComboItem(0, "MONTH"));
            expire_unit.Items.Add(new ComboItem(1, "YEAR"));
            expire_unit.SelectedIndex = 0;
        }

        private void gift_certificate_manage_Load(object sender, EventArgs e)
        {
            manage_btn.Text = "ADD";

            String queryString = "SELECT TOP 1 * FROM GIFT_CERTIFICATE_CONFIG WHERE GIFT_CERTIFICATE_CONFIG_ID = 1";
            using (DataTable DT = DB.getS(queryString, null, "GET GIFT_CERTIFICATE_CONFIG", false))
            {
                foreach(DataRow row in DT.Rows)
                {
                    expire_amount.Text = row["EXPIRE_AMOUNT"].ToString();
                    expire_unit.SelectedIndex = Convert.ToInt32(row["EXPIRE_UNIT"].ToString());
                    current_card = row["CARD1"].ToString();
                    current_letter = row["CARD2"].ToString();
                    manage_btn.Text = "UPDATE";
                }
            }
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if (expire_amount.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER THE EXPIRY DETAIL !!", "ERROR");
                expire_amount.Select();
                return;
            }

            GF.showLoading(this);

            String card_ext = "";
            String tmp_card_filename = "";
            if (new_card.Trim() != "")
            {
                card_ext = new_card.Substring(new_card.IndexOf("."));
                tmp_card_filename = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + new Random().Next(0, 999999).ToString("000000") + card_ext;

                if (!FTP.upload(new_card, tmp_card_filename, "SMS_CARDS"))
                {
                    MessageBox.Show("ERROR UPLOADING CARD FILE !!", "ERROR");
                    return;
                }
                else if (current_card.Trim() != "")
                {
                    if (!FTP.delete(current_card, "SMS_CARDS"))
                    {
                        MessageBox.Show("ERROR DELETE OLD CARD FILE ON SERVER !!", "ERROR");
                        return;
                    }
                }
            }

            String letter_ext = "";
            String tmp_letter_filename = "";
            if (new_letter.Trim() != "")
            {
                letter_ext = new_letter.Substring(new_letter.IndexOf("."));
                tmp_letter_filename = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + new Random().Next(0, 999999).ToString("000000") + letter_ext;

                if (!FTP.upload(new_letter, tmp_letter_filename, "SMS_CARDS"))
                {
                    if (!FTP.delete(tmp_card_filename, "SMS_CARDS"))
                    {
                        MessageBox.Show("ERROR DELETE TEMP CARD ON SERVER !!", "ERROR");
                        return;
                    }
                    MessageBox.Show("ERROR UPLOADING LETTER FILE !!", "ERROR");
                    return;
                }
                else if (current_letter.Trim() != "")
                {
                    if (!FTP.delete(current_letter, "SMS_CARDS"))
                    {
                        MessageBox.Show("ERROR DELETE OLD LETTER ON SERVER !!", "ERROR");
                        return;
                    }
                }
            }

            String card_filename = current_card;
            if (new_card.Trim() != "") card_filename = tmp_card_filename;
            if (card_filename.Trim() == "") card_filename = "NULL";
            else card_filename = "'" + card_filename + "'";

            String letter_filename = current_letter;
            if (new_letter.Trim() != "") letter_filename = tmp_letter_filename;
            if (letter_filename.Trim() == "") letter_filename = "NULL";
            else letter_filename = "'" + letter_filename + "'";

            string queryString = "SELECT * FROM GIFT_CERTIFICATE_CONFIG";

            using (DataTable DT = DB.getS(queryString, null, "CHECK GIFT_CERTIFICATE_CONFIG IF EXISTED", false))
            {
                if (DT.Rows.Count == 0)
                {
                    queryString = "INSERT INTO GIFT_CERTIFICATE_CONFIG ( EXPIRE_AMOUNT, EXPIRE_UNIT, CARD1, CARD2 ) VALUES (";
                    queryString += expire_amount.Text.Trim() + ", ";
                    queryString += ((ComboItem)expire_unit.SelectedItem).Key.ToString() + "', ";
                    queryString += card_filename + ", ";
                    queryString += letter_filename + ")";
                }

                if (DT.Rows.Count == 1)
                {
                    queryString = "UPDATE GIFT_CERTIFICATE_CONFIG SET ";
                    queryString += "EXPIRE_AMOUNT = " + expire_amount.Text.Trim() + ", ";
                    queryString += "EXPIRE_UNIT = " + ((ComboItem)expire_unit.SelectedItem).Key.ToString() + ", ";
                    queryString += "CARD1 = " + card_filename + ", ";
                    queryString += "CARD2 = " + letter_filename + ", ";
                    queryString = queryString.Substring(0, queryString.Length - 2) + " ";
                    queryString += "WHERE GIFT_CERTIFICATE_CONFIG_ID = 1";
                }
            }

            DB.beginTrans();
            if (DB.set(queryString, manage_btn.Text.Trim() + " GIFT CERTIFICATE CONFIG"))
            {
                DB.close();
                //MessageBox.Show("GIFT CERTIFICATE CONFIG IS " + (manage_btn.Text.Trim() == "ADD" ? "ADDE" : manage_btn.Text.Trim()) + "D !!", "COMPLETED");
                GF.closeLoading();
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show("ERROR INSERT INTO DATABASE !!", "ERROR");
                GF.closeLoading();
                return;
            }
        }

        
        private void expire_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void gift_certificate_manage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Activate();
        }

        private void card_btn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                DialogResult result = ofd.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {
                    new_card = ofd.FileName;
                }
            }
        }

        private void letter_btn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                DialogResult result = ofd.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {
                    new_letter = ofd.FileName;
                }
            }
        }
    }
}
