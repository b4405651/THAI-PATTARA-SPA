using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.MEMBERSHIP
{
    public partial class config_member_card_manage : Form
    {
        String current_card_front = "";
        String current_card_back = "";
        String current_letter = "";

        String new_card_front = "";
        String new_card_back = "";
        String new_letter = "";

        public config_member_card_manage()
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

            coupon_item.Items.Add(new ComboItem(-99, "MONEY"));
            String queryString = "SELECT * FROM SPA_PROGRAM WHERE IS_USE = 1 ORDER BY CODE";
            using (DataTable DT = DB.getS(queryString, null, "GET ALL ACTIVE SPA PROGRAM", false))
            {
                foreach (DataRow row in DT.Rows)
                {
                    coupon_item.Items.Add(new ComboItem(Convert.ToInt32(row["SPA_PROGRAM_ID"].ToString()), "[" + row["CODE"].ToString() + "] " + row["PROGRAM_NAME"].ToString()));
                }
            }

            GF.resizeComboBox(coupon_item);
            coupon_item.SelectedIndex = 0;

            if (coupon_DGV.Columns.Count == 0)
            {
                coupon_DGV.Columns.Add("detail", "DETAIL");
                coupon_DGV.Columns.Add("amount", "AMOUNT");
                coupon_DGV.Columns.Add("type", "TYPE");

                coupon_DGV.Columns["detail"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                coupon_DGV.Columns["amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                coupon_DGV.Columns["type"].Visible = false;
            }

            food_discount_unit.Items.Clear();
            food_discount_unit.Items.Add(new ComboItem(0, "%"));
            food_discount_unit.Items.Add(new ComboItem(1, Properties.Settings.Default.money_unit));
            food_discount_unit.SelectedIndex = 0;
            GF.resizeComboBox(food_discount_unit);
        }

        private void config_member_card_manage_Load(object sender, EventArgs e)
        {
            if (manage_btn.Text.Trim() == "UPDATE")
            {
                String queryString = "SELECT TOP 1 * FROM MEMBERCARD_TYPE WHERE MEMBERCARD_TYPE_ID = " + GF.selected_id.ToString();
                using (DataTable DT = DB.getS(queryString, null, "GET MEMBERCARD_TYPE[" + GF.selected_id.ToString() + "]", false))
                {
                    DataRow row = DT.Rows[0];

                    card_name.Text = row["MEMBERCARD_TYPE_NAME"].ToString();
                    discount.Text = row["DISCOUNT"].ToString();
                    credit.Text = row["CREDIT"].ToString();
                    price.Text = row["PRICE"].ToString();
                    expire_amount.Text = row["EXPIRE_AMOUNT"].ToString();
                    expire_unit.SelectedIndex = Convert.ToInt32(row["EXPIRE_UNIT"].ToString());
                    if (row["EXPIRE_AMOUNT"].ToString() == "1") can_use_no_credit.Checked = true;
                    current_card_front = row["FRONT_CARD"].ToString();
                    current_card_back = row["BACK_CARD"].ToString();
                    current_letter = row["ATTACH_PAPER"].ToString();
                    food_discount.Text = row["DISCOUNT_FOOD"].ToString();
                    food_discount_unit.SelectedIndex = Convert.ToInt32(row["DISCOUNT_FOOD_UNIT"].ToString());

                    if (current_card_front == "") card_front_btn.Text = "UPLOAD";
                    else card_front_btn.Text = "CHANGE";

                    if (current_card_back == "") card_back_btn.Text = "UPLOAD";
                    else card_back_btn.Text = "CHANGE";

                    if (current_letter == "") letter_btn.Text = "UPLOAD";
                    else letter_btn.Text = "CHANGE";

                    String[] complementary_spa_program_id = (row["complementary_spa_program_id"].ToString() == "" || row["complementary_spa_program_id"].ToString() == "NULL" ? null : row["complementary_spa_program_id"].ToString().Split(','));
                    String[] complementary_discount_amount = (row["complementary_discount_amount"].ToString() == "" || row["complementary_discount_amount"].ToString() == "NULL" ? null : row["complementary_discount_amount"].ToString().Split(','));
                    String[] complementary_discount_unit = (row["complementary_discount_unit"].ToString() == "" || row["complementary_discount_unit"].ToString() == "NULL" ? null : row["complementary_discount_unit"].ToString().Split(','));

                    coupon_DGV.Rows.Clear();
                    if (complementary_spa_program_id != null)
                    {
                        for (int index = 0; index < complementary_spa_program_id.Length; index++)
                        {
                            if (complementary_spa_program_id[index] == "-99")
                            {
                                coupon_DGV.Rows.Add("MONEY", complementary_discount_amount[index] + " " + Properties.Settings.Default.money_unit, "-99");
                            }
                            else
                            {
                                queryString = "SELECT * FROM SPA_PROGRAM WHERE SPA_PROGRAM_ID = " + complementary_spa_program_id[index];
                                using (DataTable tmpDT = DB.getS(queryString, null, "GET SPA PROGRAM ID [" + complementary_spa_program_id[index] + "] DETAIL", false))
                                {
                                    DataRow tmpRow = tmpDT.Rows[0];
                                    coupon_DGV.Rows.Add("[" + tmpRow["CODE"].ToString() + "] " + tmpRow["PROGRAM_NAME"].ToString(), complementary_discount_amount[index] + " %", complementary_spa_program_id[index]);
                                }
                            }
                        }
                        GF.updateRowNum(coupon_DGV);
                    }

                    coupon_DGV.ClearSelection();
                }
            }
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if (card_name.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER CARD NAME !!", "ERROR");
                card_name.Select();
                return;
            }
            if (discount.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER DISCOUNT AMOUNT IN % !!", "ERROR");
                discount.Select();
                return;
            }
            if (credit.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER CREDIT AMOUNT !!", "ERROR");
                credit.Select();
                return;
            }
            if (price.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER SELLING PRICE !!", "ERROR");
                price.Select();
                return;
            }
            if (expire_amount.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER THE EXPIRY DETAIL !!", "ERROR");
                expire_amount.Select();
                return;
            }
            if (current_card_front == "" && new_card_front == "" && manage_btn.Text.Trim() == "ADD")
            {
                MessageBox.Show("PLEASE SELECT IMAGE FOR CARD FRONT SIDE !!", "ERROR");
                return;
            }
            if (current_card_back == "" && new_card_back == "" && manage_btn.Text.Trim() == "ADD")
            {
                MessageBox.Show("PLEASE SELECT IMAGE FOR CARD BACK SIDE !!", "ERROR");
                return;
            }
            if (current_letter == "" && new_letter == "" && manage_btn.Text.Trim() == "ADD")
            {
                MessageBox.Show("PLEASE SELECT IMAGE FOR ATTACH PAPER !!", "ERROR");
                return;
            }
            if (food_discount.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER DISCOUNT FOR FOOD !!", "ERROR");
                food_discount.Select();
                return;
            }

            Dictionary<string, string> Params = new Dictionary<string, string>();
            //Params.Add("@card_name", card_name.Text);

            string queryString = "SELECT * FROM MEMBERCARD_TYPE WHERE MEMBERCARD_TYPE_NAME = '" + card_name.Text + "'";
            if (manage_btn.Text.Trim() == "UPDATE") queryString += " AND MEMBERCARD_TYPE_ID != " + GF.selected_id.ToString();

            using (DataTable DT = DB.getS(queryString, Params, "CHECK MEMBERCARD_TYPE IF EXISTED", false))
            {
                if (DT.Rows.Count > 0)
                {
                    MessageBox.Show("THIS CARD NAME IS ALREADY EXISTED !!", "ERROR");
                    return;
                }
            }

            // CARD FRONT
            String card_front_ext = "";
            String tmp_card_front_filename = "";

            GF.doDebug("CURRENT CARD FRONT : " + current_card_front);
            GF.doDebug("NEW CARD FRONT : " + new_card_front);

            if (new_card_front.Trim() != "") 
            {
                card_front_ext = new_card_front.Substring(new_card_front.LastIndexOf("."));
                tmp_card_front_filename = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00") + DateTime.Now.Millisecond.ToString("000") + new Random().Next(0, 999999).ToString("000000") + card_front_ext;

                if (!FTP.upload(new_card_front, tmp_card_front_filename, "SMS_CARDS"))
                {
                    MessageBox.Show("ERROR UPLOADING CARD FRONT FILE !!", "ERROR");
                    return;
                }
                else if (current_card_front.Trim() != "")
                {
                    if (!FTP.delete(current_card_front, "SMS_CARDS"))
                    {
                        MessageBox.Show("ERROR DELETE OLD CARD FRONT FILE ON SERVER !!", "ERROR");
                        return;
                    }
                }
            }

            String card_front_filename = current_card_front;
            if (new_card_front.Trim() != "") card_front_filename = tmp_card_front_filename;

            if (card_front_filename.Trim() == "") card_front_filename = "NULL";
            else card_front_filename = "'" + card_front_filename + "'";

            new_card_front = "";
            current_card_front = card_front_filename.Replace("'","");

            // CARD BACK
            String card_back_ext = "";
            String tmp_card_back_filename = "";

            GF.doDebug("CURRENT CARD BACK : " + current_card_back);
            GF.doDebug("NEW CARD BACK : " + new_card_back);

            if (new_card_back.Trim() != "")
            {
                card_back_ext = new_card_back.Substring(new_card_back.LastIndexOf("."));
                tmp_card_back_filename = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00") + DateTime.Now.Millisecond.ToString("000") + new Random().Next(0, 999999).ToString("000000") + card_back_ext;

                if (!FTP.upload(new_card_back, tmp_card_back_filename, "SMS_CARDS"))
                {
                    if (!FTP.delete(tmp_card_front_filename, "SMS_CARDS"))
                    {
                        MessageBox.Show("ERROR DELETE TEMP CARD FRONT ON SERVER !!", "ERROR");
                        return;
                    }
                    MessageBox.Show("ERROR UPLOADING CARD BACK FILE !!", "ERROR");
                    return;
                }
                else if (current_card_back.Trim() != "")
                {
                    if (!FTP.delete(current_card_back, "SMS_CARDS"))
                    {
                        MessageBox.Show("ERROR DELETE OLD CARD BACK FILE ON SERVER !!", "ERROR");
                        return;
                    }
                }
            }

            String card_back_filename = current_card_back;
            if (new_card_back.Trim() != "") card_back_filename = tmp_card_back_filename;
            
            if (card_back_filename.Trim() == "") card_back_filename = "NULL";
            else card_back_filename = "'" + card_back_filename + "'";

            new_card_back = "";
            current_card_back = card_back_filename.Replace("'", "");

            // LETTER
            String letter_ext = "";
            String tmp_letter_filename = "";

            GF.doDebug("CURRENT LETTER : " + current_letter);
            GF.doDebug("NEW LETTER : " + new_letter);

            if (new_letter.Trim() != "")
            {
                letter_ext = new_letter.Substring(new_letter.LastIndexOf("."));
                tmp_letter_filename = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00") + DateTime.Now.Millisecond.ToString("000") + new Random().Next(0, 999999).ToString("000000") + letter_ext;

                if (!FTP.upload(new_letter, tmp_letter_filename, "SMS_CARDS"))
                {
                    if (!FTP.delete(tmp_card_front_filename, "SMS_CARDS"))
                    {
                        MessageBox.Show("ERROR DELETE TEMP CARD FRONT ON SERVER !!", "ERROR");
                        return;
                    }
                    if (!FTP.delete(tmp_card_back_filename, "SMS_CARDS"))
                    {
                        MessageBox.Show("ERROR DELETE TEMP CARD BACK ON SERVER !!", "ERROR");
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

            String letter_filename = current_letter;
            if (new_letter.Trim() != "") letter_filename = tmp_letter_filename;
            
            if (letter_filename.Trim() == "") letter_filename = "NULL";
            else letter_filename = "'" + letter_filename + "'";

            new_letter = "";
            current_letter = letter_filename.Replace("'", "");

            String complementary_spa_program_id = "";
            String complementary_discount_amount = "";
            String complementary_discount_unit = "";

            foreach (DataGridViewRow row in coupon_DGV.Rows)
            {
                complementary_spa_program_id += row.Cells["type"].Value.ToString() + ",";
                String[] tmp = row.Cells["amount"].Value.ToString().Split(' ');
                complementary_discount_amount += tmp[0] + ",";
                complementary_discount_unit += (tmp[1] == Properties.Settings.Default.money_unit ? "1" : "0") + ",";
            }

            if (complementary_spa_program_id.Trim().Length > 0) complementary_spa_program_id = complementary_spa_program_id.Substring(0, complementary_spa_program_id.Length - 1);
            if (complementary_discount_amount.Trim().Length > 0) complementary_discount_amount = complementary_discount_amount.Substring(0, complementary_discount_amount.Length - 1);
            if (complementary_discount_unit.Trim().Length > 0) complementary_discount_unit = complementary_discount_unit.Substring(0, complementary_discount_unit.Length - 1);

            GF.showLoading(this);

            if (manage_btn.Text.Trim() == "ADD")
            {
                queryString = "INSERT INTO MEMBERCARD_TYPE ( MEMBERCARD_TYPE_NAME, DISCOUNT, DISCOUNT_FOOD, DISCOUNT_FOOD_UNIT, CREDIT, PRICE, EXPIRE_AMOUNT, EXPIRE_UNIT, FRONT_CARD, BACK_CARD, ATTACH_PAPER, CAN_USE_NO_CREDIT, COMPLEMENTARY_SPA_PROGRAM_ID, COMPLEMENTARY_DISCOUNT_AMOUNT, COMPLEMENTARY_DISCOUNT_UNIT ) VALUES (";
                queryString += "'" + card_name.Text.Trim().ToUpper() + "', ";
                queryString += discount.Text.Trim().ToUpper() + ", ";
                queryString += food_discount.Text.Trim().ToUpper() + ", ";
                queryString += ((ComboItem)food_discount_unit.SelectedItem).Key.ToString() + ", ";
                queryString += credit.Text.Trim().ToUpper() + ", ";
                queryString += price.Text.Trim().ToUpper() + ", ";
                queryString += expire_amount.Text.Trim() + ", ";
                queryString += ((ComboItem)expire_unit.SelectedItem).Key.ToString() + ", ";
                queryString += card_front_filename + ", ";
                queryString += card_back_filename + ", ";
                queryString += letter_filename + ", ";
                queryString += (can_use_no_credit.Checked ? "1" : "0") + ", ";
                queryString += (complementary_spa_program_id.Trim().Length == 0 ? "NULL" : "'" + complementary_spa_program_id + "'") + ", ";
                queryString += (complementary_discount_amount.Trim().Length == 0 ? "NULL" : "'" + complementary_discount_amount + "'") + ", ";
                queryString += (complementary_discount_unit.Trim().Length == 0 ? "NULL" : "'" + complementary_discount_unit + "'") + ")";

                DB.beginTrans();
                if (DB.set(queryString, "INSERT MEMBERCARD_TYPE[" + card_name.Text.Trim().ToUpper() + "]"))
                {
                    DB.close();
                    MessageBox.Show("MEMBER CARD IS ADDED !!", "COMPLETED");
                    ((btn_dgv)this.Owner.Controls["btn_dgv"]).refresh_btn.PerformClick();
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

            if (manage_btn.Text.Trim() == "UPDATE")
            {
                queryString = "UPDATE MEMBERCARD_TYPE SET ";
                queryString += "MEMBERCARD_TYPE_NAME = '" + card_name.Text.Trim().ToUpper() + "', ";
                queryString += "DISCOUNT = " + discount.Text.Trim().ToUpper() + ", ";
                queryString += "DISCOUNT_FOOD = " + food_discount.Text.Trim() + ", ";
                queryString += "DISCOUNT_FOOD_UNIT = " + ((ComboItem)food_discount_unit.SelectedItem).Key.ToString() + ", ";
                queryString += "CREDIT = " + credit.Text.Trim().ToUpper() + ", ";
                queryString += "PRICE = " + price.Text.Trim().ToUpper() + ", ";
                queryString += "EXPIRE_AMOUNT = " + expire_amount.Text.Trim() + ", ";
                queryString += "EXPIRE_UNIT = " + ((ComboItem)expire_unit.SelectedItem).Key.ToString() + ", ";
                queryString += "FRONT_CARD = " + card_front_filename + ", ";
                queryString += "BACK_CARD = " + card_back_filename + ", ";
                queryString += "ATTACH_PAPER = " + letter_filename + ", ";
                queryString += "CAN_USE_NO_CREDIT = " + (can_use_no_credit.Checked ? "1" : "0") + ", ";
                queryString += "COMPLEMENTARY_SPA_PROGRAM_ID = " + (complementary_spa_program_id.Trim().Length == 0 ? "NULL" : "'" + complementary_spa_program_id + "'") + ", ";
                queryString += "COMPLEMENTARY_DISCOUNT_AMOUNT = " + (complementary_discount_amount.Trim().Length == 0 ? "NULL" : "'" + complementary_discount_amount + "'") + ", ";
                queryString += "COMPLEMENTARY_DISCOUNT_UNIT = " + (complementary_discount_unit.Trim().Length == 0 ? "NULL" : "'" + complementary_discount_unit + "'") + " ";
                queryString += "WHERE MEMBERCARD_TYPE_ID = " + GF.selected_id.ToString();

                DB.beginTrans();
                if (DB.set(queryString, "UPDATE MEMBERCARD_TYPE[ID:" + GF.selected_id.ToString() + "]"))
                {
                    DB.close();
                    ((btn_dgv)this.Owner.Controls["btn_dgv"]).refresh_btn.PerformClick();
                    GF.closeLoading();
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("ERROR UPDATE IN DATABASE !!", "ERROR");
                    GF.closeLoading();
                    return;
                }
            }
        }

        private void credit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void price_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void discount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void expire_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void config_member_card_manage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Activate();
        }

        private void coupon_item_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (coupon_item.SelectedIndex == 0)
            {
                coupon_lbl.Text = "BALANCE : ";
                unit_lbl.Text = Properties.Settings.Default.money_unit;
                amount_txt.Text = "";
                amount_txt.Select();
            }
            else
            {
                coupon_lbl.Text = "DISCOUNT : ";
                unit_lbl.Text = "%";
                amount_txt.Text = "100";
            }
        }

        private void coupon_add_btn_Click(object sender, EventArgs e)
        {
            coupon_DGV.Rows.Add(coupon_item.Text, amount_txt.Text.Trim() + " " + unit_lbl.Text.Trim(), ((ComboItem)coupon_item.SelectedItem).Key.ToString());
            GF.updateRowNum(coupon_DGV);
            coupon_item.SelectedIndex = 0;
            amount_txt.Text = "";
        }

        private void coupon_DGV_Paint(object sender, PaintEventArgs e)
        {
            if (((DataGridView)sender).Rows.Count == 0) // <-- if there are no rows in the DataGridView when it paints, then it will create your message
            {
                using (Graphics grfx = e.Graphics)
                {
                    // create a white rectangle so text will be easily readable
                    grfx.FillRectangle(Brushes.Plum, new Rectangle(new Point(), new Size(((DataGridView)sender).Width, ((DataGridView)sender).Height)));
                    // write text on top of the white rectangle just created
                    grfx.DrawString("--- NO DATA ---", new Font("Microsoft Sans Serif", 18, FontStyle.Bold), Brushes.Black, new PointF((((DataGridView)sender).Width / 2) - 100, (((DataGridView)sender).Height / 2)));
                }
            }
            else
            {
                foreach (DataGridViewColumn column in ((DataGridView)sender).Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
        }

        private void card_front_btn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                DialogResult result = ofd.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {
                    new_card_front = ofd.FileName;
                }
            }
        }

        private void card_back_btn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                DialogResult result = ofd.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {
                    new_card_back = ofd.FileName;
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

        private void amount_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
