using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.RESERVATION
{
    public partial class reservation_program : Form
    {
        int masseur_use = 1;
        string apply_discount = "0";

        public string agent_id = "-1";
        public string res_detail_id = "";
        public string start_time = "";
        public string end_time = "";
        public string spa_program_text = "";
        public int spa_program = -1;
        public int oil_id = -1;
        public int scrub_id = -1;
        public string therapistName = "";
        public String therapist_id_list = "";
        public int therapist1_id = -1;
        public int therapist1_request = -1;
        public int therapist2_id = -1;
        public int therapist2_request = -1;

        DataTable DT = null;

        public reservation_program()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };

            showTherapist2(false);

            spa_program_id.Items.Add(new ComboItem(-1, "SPA PROGRAM")); 
            therapist1.Items.Add(new ComboItem(-1, "THERAPIST")); 
            therapist2.Items.Add(new ComboItem(-1, "CHOOSE THERAPIST1"));

            oil.Items.Add(new ComboItem(-1, "UNKNOWN"));
            int index = -1;
            foreach (String oilStr in GF.oilList)
            {
                index++;
                oil.Items.Add(new ComboItem(index, oilStr));
            }

            scrub.Items.Add(new ComboItem(-1, "UNKNOWN"));
            index = -1;
            foreach (String scrubStr in GF.scrubList)
            {
                index++;
                scrub.Items.Add(new ComboItem(index, scrubStr));
            }

            String queryString = "SELECT * FROM SPA_PROGRAM WHERE IS_USE = 1 ORDER BY CODE";
            using (DT = DB.getS(queryString, null, "GET ALL ACTIVE SPA PROGRAM", false))
            {
                foreach (DataRow row in DT.Rows)
                {
                    spa_program_id.Items.Add(new ComboItem(Convert.ToInt32(row["SPA_PROGRAM_ID"].ToString()), "[" + row["CODE"].ToString() + "] " + row["PROGRAM_NAME"].ToString()));
                }
            }

            GF.resizeComboBox(spa_program_id);
            
            spa_program_id.SelectedIndex = 0;
            therapist1.SelectedIndex = 0;
            therapist2.SelectedIndex = 0;
            oil.SelectedIndex = 0;
            scrub.SelectedIndex = 0;
        }

        private void reservation_program_Load(object sender, EventArgs e)
        {
            this.Width = cancel_btn.Left + cancel_btn.Width + 20;
            this.Height = manage_btn.Top + manage_btn.Height + 40;
            GF.showLoading(this);
            if (res_detail_id != "") manage_btn.Text = "UPDATE";
            
            if (spa_program != -1)
            {
                foreach (ComboItem item in spa_program_id.Items)
                {
                    if (item.Key == spa_program)
                    {
                        spa_program_text = item.Value.Trim();
                        break;
                    }
                }
            }

            if (spa_program_text != "") spa_program_id.Text = spa_program_text;
            else spa_program_id.SelectedIndex = 0;
            
            GF.closeLoading();
        }

        private void spa_program_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            GF.showLoading(this);
            if (spa_program_id.SelectedIndex > 0)
            {
                String queryString = "SELECT MASSEUR_USE, SELECT_OIL, SELECT_SCRUB, HOURS, MINUTES, APPLY_DISCOUNT FROM SPA_PROGRAM WHERE SPA_PROGRAM_ID = " + ((ComboItem)spa_program_id.SelectedItem).Key.ToString();
                using (DT = DB.getS(queryString, null, "GET MASSEUR_USE FROM SPA_PROGRAM[" + ((ComboItem)spa_program_id.SelectedItem).Key.ToString() + "]", false))
                {

                    int total_hours = 0;
                    int total_mins = 0;

                    if (DT.Rows[0]["SELECT_OIL"].ToString() == "1")
                    {
                        oil.Text = "UNKNOWN";
                        oil.Enabled = true;
                        String oil_text = "";
                        if (oil_id != -1)
                        {
                            foreach (ComboItem item in oil.Items)
                            {
                                if (item.Key == oil_id)
                                {
                                    oil_text = item.Value.Trim();
                                    break;
                                }
                            }
                        }
                        if (oil_text != "") oil.Text = oil_text;
                        else oil.SelectedIndex = 0;
                    }
                    else
                    {
                        oil.SelectedIndex = 0;
                        oil.Enabled = false;
                    }

                    if (DT.Rows[0]["SELECT_SCRUB"].ToString() == "1")
                    {
                        scrub.Text = "UNKNOWN";
                        scrub.Enabled = true;
                        String scrub_text = "";
                        if (scrub_id != -1)
                        {
                            foreach (ComboItem item in scrub.Items)
                            {
                                if (item.Key == scrub_id)
                                {
                                    scrub_text = item.Value.Trim();
                                    break;
                                }
                            }
                        }
                        if (scrub_text != "") scrub.Text = scrub_text;
                        else scrub.SelectedIndex = 0;
                    }
                    else
                    {
                        scrub.SelectedIndex = 0;
                        scrub.Enabled = false;
                    }

                    masseur_use = Convert.ToInt32(DT.Rows[0]["MASSEUR_USE"].ToString());
                    apply_discount = DT.Rows[0]["APPLY_DISCOUNT"].ToString();

                    total_hours = Convert.ToInt32(DT.Rows[0]["HOURS"].ToString());
                    total_mins = Convert.ToInt32(DT.Rows[0]["MINUTES"].ToString());
                    total_mins += (total_hours * 60);

                    therapist1.Enabled = true;
                    if (masseur_use > 1) showTherapist2(true);
                    else showTherapist2(false);
                    GF.showLoading(this);
                    getTherapist(ref therapist1, total_mins);
                    if (masseur_use > 1) getTherapist(ref therapist2, total_mins);
                    GF.closeLoading();
                }
            }
            else
            {
                oil.SelectedIndex = 0;
                oil.Enabled = false;

                showTherapist2(false);
                therapist1.Enabled = false;
                therapist1.SelectedIndex = 0;
                therapist2.SelectedIndex = 0;

                apply_discount = "0";
            }
            GF.closeLoading();
            this.Activate();
            this.BringToFront();
        }

        private void therapist1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (therapist1.SelectedIndex > 0 && masseur_use > 1)
            {
                if(therapist1_id == -1) therapist1_id = ((ComboItem)therapist1.SelectedItem).Key;
                GF.showLoading(this);
                getTherapist(ref therapist2, ((ComboItem)therapist1.SelectedItem).Key);
                GF.closeLoading();
            }
            else
            {
                therapist2.SelectedIndex = 0;
            }
        }

        private void therapist2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (therapist2.SelectedIndex > 0) therapist1_id = ((ComboItem)therapist1.SelectedItem).Key;
        }

        void getTherapist(ref ComboBox cb, int total_mins, int exception_id = -1)
        {
            cb.Items.Clear();
            string originalDate = ((reservation)((reservation_manage)Owner).Owner).reservation_date.Text.Trim();
            this.Hide();

            String queryString = "";
            queryString = "SELECT * FROM EMPLOYEE WHERE EMP_STATUS = 1";
            /*queryString = @"
            SELECT 
                * 
            FROM EMPLOYEE 
            WHERE EMP_DEPT_ID = 3 AND EMP_STATUS = 1 AND (
                ";
            if (therapist_id_list.Trim() != "") queryString += "EMP_ID IN (" + therapist_id_list + @") OR";
            queryString += @" EMP_ID NOT IN 
                (
				    (
					    SELECT DISTINCT C.THERAPIST_ID
					    FROM RESERVATION A
					    INNER JOIN RESERVATION_DETAIL B ON A.RESERVATION_ID = B.RESERVATION_ID
					    INNER JOIN RESERVATION_THERAPIST C ON B.RESERVATION_DETAIL_ID = C.RESERVATION_DETAIL_ID
					    WHERE A.status = 1";
            if(res_id != "") queryString += " AND A.reservation_id != " + res_id;
            queryString += @" 
					    AND 
					    (
                            (
						        A.APPOINTMENT_START BETWEEN " + GF.modDateTime(start_time) + @" AND DATEADD(MINUTE, +" + total_mins + @", " + GF.modDateTime(end_time) + @") 
						        OR 
						        A.APPOINTMENT_END BETWEEN " + GF.modDateTime(start_time) + @" AND DATEADD(MINUTE, +" + total_mins + @", " + GF.modDateTime(end_time) + @")
                            ) AND A.START_TIME IS NULL AND A.END_TIME IS NULL
					    )
				    ) UNION (
					    SELECT DISTINCT C.THERAPIST_ID
					    FROM RESERVATION A
					    INNER JOIN RESERVATION_DETAIL B ON A.RESERVATION_ID = B.RESERVATION_ID
					    INNER JOIN RESERVATION_THERAPIST C ON B.RESERVATION_DETAIL_ID = C.RESERVATION_DETAIL_ID
					    WHERE (A.status = 2 OR A.status = 3)";
            if(res_id != "") queryString += " AND A.reservation_id != " + res_id;
		    queryString += @" 
                        AND 
					    (
						    A.START_TIME BETWEEN " + GF.modDateTime(start_time) + @" AND DATEADD(MINUTE, +" + total_mins + @", " + GF.modDateTime(end_time) + @") 
						    OR 
						    A.END_TIME BETWEEN " + GF.modDateTime(start_time) + @" AND DATEADD(MINUTE, +" + total_mins + @", " + GF.modDateTime(end_time) + @")
					    )
                        AND A.START_TIME IS NOT NULL AND A.END_TIME IS NOT NULL
                    )
                )
            )";*/

            queryString += " AND EMP_DEPT_ID = 3";
            if (exception_id != -1) queryString += " AND EMP_ID != " + exception_id.ToString();
            if (cb.Name == "therapist2") queryString += " AND EMP_ID != " + therapist1_id.ToString();

            using (DataTable localDT = DB.getS(queryString, null, "GET THERAPIST", false))
            {
                GF.closeLoading();
                cb.Items.Add(new ComboItem(-1, "UNKNOWN"));
                foreach (DataRow row in localDT.Rows)
                {
                    //cb.Items.Add(new ComboItem(Convert.ToInt32(row["EMP_ID"].ToString()), GF.getNickname(row["FULLNAME"].ToString().Trim())));
                    cb.Items.Add(new ComboItem(Convert.ToInt32(row["EMP_ID"].ToString()), (row["NICKNAME"].ToString().Trim() == String.Empty ? row["FULLNAME"].ToString() : row["NICKNAME"].ToString())));
                }
            }
            GF.resizeComboBox(cb);
            cb.Sorted = true;
            if (therapistName != "") cb.Text = therapistName;
            else cb.Text = "UNKNOWN";

            string therapist_text = "";

            if (cb == therapist1)
            {
                if (therapist1_id != -1)
                {
                    foreach (ComboItem item in cb.Items)
                    {
                        if (item.Key == therapist1_id)
                        {
                            therapist_text = item.Value.Trim();
                            break;
                        }
                    }
                }
                if (therapist_text != "") cb.Text = therapist_text;
                if (therapist1_request == 1) request1.Checked = true;
            }

            if (cb == therapist2)
            {
                if (therapist2_id != -1)
                {
                    foreach (ComboItem item in cb.Items)
                    {
                        if (item.Key == therapist2_id)
                        {
                            therapist_text = item.Value.Trim();
                            break;
                        }
                    }
                }
                if (therapist_text != "") cb.Text = therapist_text;
                if (therapist2_request == 1) request2.Checked = true;
            }
            this.Show();
            this.Activate();
        }

        void showTherapist2(bool show)
        {
            if (!show)
            {
                therapist1_lbl.Text = "THERAPIST : ";
                therapist2_lbl.Visible = false;
                therapist2.Visible = false;
                request2.Visible = false;

                manage_btn.Top = cancel_btn.Top = therapist2.Top + 2;
                this.Height = manage_btn.Top + manage_btn.Height + 40;
            }
            else
            {
                therapist1_lbl.Text = "THERAPIST1 : ";
                therapist2_lbl.Visible = true;
                therapist2.Visible = true;
                therapist2.SelectedIndex = 0;
                request2.Visible = true;

                manage_btn.Top = cancel_btn.Top = 152;
                this.Height = 253;
            }
        }

        private void reservation_program_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Activate();
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if (spa_program_id.SelectedIndex == 0)
            {
                MessageBox.Show("PLEASE CHOOSE SPA PROGRAM !!", "ERROR");
                return;
            }

            DataGridView DGV = ((reservation_manage)this.Owner).reservation_detail;

            if (DGV.Rows.Count == 1 && DGV.Rows[0].Cells["PROGRAM_NAME"].Value.ToString().IndexOf("RESERVE") != -1) DGV.Rows.RemoveAt(0);

            String therapist_name = therapist1.Text;
            String therapist_id = ((ComboItem)therapist1.SelectedItem).Key.ToString();
            String isRequest = (request1.Checked ? "1" : "0");
            if (request1.Checked) therapist_name += "[REQUEST]";
            if (therapist2.Visible)
            {
                therapist_name += ", " + therapist2.Text;
                therapist_id += ", " + ((ComboItem)therapist2.SelectedItem).Key.ToString();
                isRequest += ", " + (request2.Checked ? "1" : "0");
                if (request2.Checked) therapist_name += "[REQUEST]";
            }

            String queryString = "SELECT TOP 1 * FROM SPA_PROGRAM WHERE SPA_PROGRAM_ID = " + ((ComboItem)spa_program_id.SelectedItem).Key.ToString();
            DataTable DT, tmpDT;
            using (DT = DB.getS(queryString, null, "GET DETAIL OF SPA_PROGRAM[" + ((ComboItem)spa_program_id.SelectedItem).Key.ToString() + "]", false))
            {
                foreach (DataRow row in DT.Rows)
                {

                    String price = row["PRICE"].ToString();
                    String theDate = ((reservation)((reservation_manage)Owner).Owner).reservation_date.Text.Trim();

                    queryString = @"
                SELECT B.PRICE 
                FROM AGENT_CONTRACT_RATE A
                INNER JOIN AGENT_CONTRACT_RATE_DETAIL B ON A.AGENT_CONTRACT_RATE_ID = B.AGENT_CONTRACT_RATE_ID
                WHERE A.AGENT_ID = " + agent_id + @" AND B.SPA_PROGRAM_ID = " + ((ComboItem)spa_program_id.SelectedItem).Key.ToString() + @"
                AND " + GF.modDate(theDate) + @" BETWEEN A.START_DATE AND A.END_DATE
                ";

                    using (tmpDT = DB.getS(queryString, null, "GET CONTRACT RATE OF AGENT[" + agent_id + "] FOR SPA_PROGRAM[" + ((ComboItem)spa_program_id.SelectedItem).Key.ToString() + "]", false))
                    {
                        if (tmpDT.Rows.Count == 1)
                        {
                            price = tmpDT.Rows[0]["PRICE"].ToString();
                        }
                    }
                    price = GF.formatNumber(Convert.ToInt32(price));

                    String oil_txt = "";
                    if (oil.Enabled)
                    {
                        oil_txt += " [OIL:";

                        if (((ComboItem)oil.SelectedItem).Key == -1)
                            oil_txt += "*** " + oil.Text + " ***";
                        else
                            oil_txt += oil.Text.Trim();

                        oil_txt += "]";
                    }

                    String scrub_txt = "";
                    if (scrub.Enabled)
                    {
                        scrub_txt += " [SCRUB:";

                        if (((ComboItem)scrub.SelectedItem).Key == -1)
                            scrub_txt += "*** " + scrub.Text + " ***";
                        else
                            scrub_txt += scrub.Text.Trim();

                        scrub_txt += "]";
                    }

                    if (res_detail_id == "")
                    {
                        res_detail_id = (new Random().Next(1, 1000000) * -1).ToString();
                        DGV.Rows.Add(
                            spa_program_id.Text.Trim() + oil_txt + scrub_txt,
                            therapist_name,
                            ((ComboItem)spa_program_id.SelectedItem).Key.ToString(),
                            price,
                            row["HOURS"].ToString(),
                            row["MINUTES"].ToString(),
                            (oil.Enabled ? ((ComboItem)oil.SelectedItem).Key.ToString() : ""),
                            (scrub.Enabled ? ((ComboItem)scrub.SelectedItem).Key.ToString() : ""),
                            therapist_id,
                            isRequest,
                            apply_discount,
                            "1",
                            res_detail_id
                        );
                    }
                    else
                    {
                        int rowIndex = -1;
                        foreach (DataGridViewRow DGV_Row in DGV.Rows)
                        {
                            if (DGV_Row.Cells["reservation_detail_id"].Value.ToString() == res_detail_id)
                            {
                                rowIndex = DGV_Row.Index;
                                break;
                            }
                        }
                        if (rowIndex != -1)
                        {
                            DGV.Rows[rowIndex].Cells[0].Value = spa_program_id.Text.Trim() + oil_txt + scrub_txt;
                            DGV.Rows[rowIndex].Cells[1].Value = therapist_name;
                            DGV.Rows[rowIndex].Cells[2].Value = ((ComboItem)spa_program_id.SelectedItem).Key.ToString();
                            DGV.Rows[rowIndex].Cells[3].Value = price;
                            DGV.Rows[rowIndex].Cells[4].Value = row["HOURS"].ToString();
                            DGV.Rows[rowIndex].Cells[5].Value = row["MINUTES"].ToString();
                            DGV.Rows[rowIndex].Cells[6].Value = (oil.Enabled ? ((ComboItem)oil.SelectedItem).Key.ToString() : "");
                            DGV.Rows[rowIndex].Cells[7].Value = (scrub.Enabled ? ((ComboItem)scrub.SelectedItem).Key.ToString() : "");
                            DGV.Rows[rowIndex].Cells[8].Value = therapist_id;
                            DGV.Rows[rowIndex].Cells[9].Value = isRequest;
                            DGV.Rows[rowIndex].Cells[10].Value = apply_discount;
                            DGV.Rows[rowIndex].Cells[11].Value = res_detail_id;
                        }
                    }
                }
            }

            ((reservation_manage)this.Owner).isSpaProgramChanged = true;
            ((reservation_manage)this.Owner).recalculateTime();
            //((reservation_manage)this.Owner).getRoom();
            DGV.ClearSelection();
            this.Close();
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            using (barcode_program_search searchPage = new barcode_program_search())
            {
                searchPage.Owner = this;
                searchPage.ShowDialog();
            }
        }
    }
}
