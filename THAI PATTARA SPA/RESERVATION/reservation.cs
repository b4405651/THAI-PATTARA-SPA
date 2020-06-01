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
    public partial class reservation : Form
    {
        public string targetDate = "";
        public int billType = 1;
        Brush reserved = null;
        Brush started = null;
        Brush unpaid = null;
        Brush paid = null;
        List<bar> roomBarList = new List<bar>();
        List<bar> therapistBarList = new List<bar>();

        bool firstLoad = true;
        public bool isExit = false;
        public bool isChoosing = false;

        int therapistVisibleRowsCount = -1;
        int therapistFirstDisplayedRowIndex = -1;
        int therapistLastVisibleRowIndex = -1;
        int roomVisibleRowsCount = -1;
        int roomFirstDisplayedRowIndex = -1;
        int roomLastVisibleRowIndex = -1;

        int isUnpaid = 0;
        int isPaid = 0;
        int isNotFinished = 0;
        int firstCellWidth = 0;
        int otherCellWidth = 0;

        public bool isMasterCard = false;

        string force_open_res_id = "";
        int force_open_therapist_id = -1;
        string force_open_res_time = "";

        int time_range = 0;

        public reservation()
        {
            InitializeComponent();
            this.Visible = false;

            spa_card_no.KeyUp += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    loadData();
                }
            };

            spa_card_no.KeyPress += (s, e) =>
            {
                force_open_res_id = "";
                force_open_res_time = "";
                force_open_therapist_id = -1;
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !(e.KeyChar == ',');
                if (spa_card_no.Text.Trim().Length == 0) force_open_btn.Visible = false;
                else
                {
                    String[] tmp = spa_card_no.Text.Trim().Split(',');
                    if (tmp.Length == 1) force_open_btn.Visible = true;
                    else force_open_btn.Visible = false;
                }
            };

            roomTable.Scroll += (s, e) =>
            {
                updateVisibleRow();
            };
        }

        private void reservation_Load(object sender, EventArgs e)
        {
            reserved = Brushes.MediumSlateBlue;
            started = Brushes.LightCoral;
            unpaid = Brushes.Red;
            paid = Brushes.YellowGreen;

            reservation_date_lbl.Top = total_lbl.Top = GF.pageTop;
            reservation_date.Top = reservation_date_lbl.Top - 2;

            status_lbl.Top = customer_data_lbl.Top = spa_card_no_lbl.Top = reservation_date_lbl.Top + 31;
            status.Top = customer_data.Top = spa_card_no.Top = status_lbl.Top - 3;
            force_open_btn.Left = spa_card_no.Left + spa_card_no.Width + 5;
            force_open_btn.Top = spa_card_no.Top + spa_card_no.Height - force_open_btn.Height;
            force_open_btn.Visible = false;

            desc_tbl.Top = GF.pageTop + this.Height - 170;
            desc_tbl.Width = this.Width - 17;

            status.Items.Add(new ComboItem(-1, "ALL"));
            status.Items.Add(new ComboItem(1, "RESERVE"));
            status.Items.Add(new ComboItem(2, "STARTED"));
            status.Items.Add(new ComboItem(3, "FINISHED - UNPAID"));
            status.Items.Add(new ComboItem(4, "FINISHED - PAID"));
            status.SelectedIndex = 0;

            select_btn.Left = this.Width - 10 - select_btn.Width;
            finish_btn.Left = select_btn.Left - 132;
            cancel_btn.Left = finish_btn.Left - 132;
            select_btn.Top = cancel_btn.Top = finish_btn.Top = GF.pageTop - 5;
            return_keycard_btn.Left = this.Width - return_keycard_btn.Width - 10;
            master_day_off_btn.Top = return_keycard_btn.Top = desc_tbl.Top - 6;
            master_day_off_btn.Left = return_keycard_btn.Left - master_day_off_btn.Width - 10;
            Invalidate();

            initTable();
            loadData();
            updateVisibleRow();
            firstLoad = false;

            GF.createTimer();
            GF.clock.Tick += (s, ee) =>
            {
                loadData();
            };

            //this.Visible = true;
        }

        public void updateVisibleRow()
        {
            therapistVisibleRowsCount = therapistTable.DisplayedRowCount(false) + 1;
            therapistFirstDisplayedRowIndex = therapistTable.FirstDisplayedCell.RowIndex;
            therapistLastVisibleRowIndex = (therapistFirstDisplayedRowIndex + therapistVisibleRowsCount) - 1;

            roomVisibleRowsCount = roomTable.DisplayedRowCount(false) + 1;
            roomFirstDisplayedRowIndex = roomTable.FirstDisplayedCell.RowIndex;
            roomLastVisibleRowIndex = (roomFirstDisplayedRowIndex + roomVisibleRowsCount) - 1;

            /*MessageBox.Show(
                "therapistVisibleRowsCount = " + therapistVisibleRowsCount.ToString() + "\r\n" +
                "therapistFirstDisplayedRowIndex = " + therapistFirstDisplayedRowIndex.ToString() + "\r\n" +
                "therapistLastVisibleRowIndex = " + therapistLastVisibleRowIndex.ToString() + "\r\n" +
                "\r\n" +
                "roomVisibleRowsCount = " + roomVisibleRowsCount.ToString() + "\r\n" +
                "roomFirstDisplayedRowIndex = " + roomFirstDisplayedRowIndex.ToString() + "\r\n" +
                "roomLastVisibleRowIndex = " + roomLastVisibleRowIndex.ToString()
            );*/
        }

        public void loadData()
        {
            if (reservation_date == null) return;
            if (reservation_date.Text.Trim() == "") return;
            if (!GF.isValidDate(reservation_date.Text.Trim())) return;
            GF.currResDate = reservation_date.Text.Trim();
            GF.showLoading(this);

            Dictionary<string, string> Params = new Dictionary<string, string>();
            //Params.Add("@resv_date", GF.modDate(reservation_date.Text.Trim()));

            Console.WriteLine(reservation_date.Text.Trim());
            Console.WriteLine(GF.modDate(reservation_date.Text.Trim()));

            String date1 = GF.modDate(reservation_date.Text.Trim().Split(' ')[0]);
            String date2 = date1;

            Console.WriteLine(time_range.ToString());

            String app_start_date = "";
            String app_start_time = "";
            String app_end_date = "";
            String app_end_time = "";

            String real_start_date = "";
            String real_start_time = "";
            String real_end_date = "";
            String real_end_time = "";

            if (time_range > 0)
            {
                DateTime theDate = reservation_date.Value;
                date2 = GF.modDate(theDate.AddDays(1).ToString().Split(' ')[0]);

                app_start_date = real_start_date = reservation_date.Value.Year.ToString() + "-" + reservation_date.Value.Month.ToString("00") + "-" + reservation_date.Value.Day.ToString("00");
                app_end_date = real_end_date = reservation_date.Value.AddDays(1).Year.ToString() + "-" + reservation_date.Value.AddDays(1).Month.ToString("00") + "-" + reservation_date.Value.AddDays(1).Day.ToString("00");

                app_start_time = real_start_time = time_range.ToString("00") + ":00:00";
                app_end_time = real_end_time = (time_range - 1).ToString("00") + ":59:59";
            }
            else
            {
                app_start_date = app_end_date = real_start_date = real_end_date = reservation_date.Value.Year.ToString() + "-" + reservation_date.Value.Month.ToString("00") + "-" + reservation_date.Value.Day.ToString("00");
                app_start_time = real_start_time = "00:00:00";
                app_end_time = real_end_time = "23:59:00";
            }

            String queryString = @"
            SELECT 
                A.RESERVATION_ID,
                A.CODE,
                A.IS_BARTER,
                A.STATUS,
                A.ROOM_ID,
                A.IS_ROOM_REQUESTED,
                A.KEYCARD_RETURN,
                CONVERT(NVARCHAR(MAX), A.APPOINTMENT_START, 103) + ' ' + CONVERT(NVARCHAR(MAX), A.APPOINTMENT_START, 108) APPOINTMENT_START,
                CONVERT(NVARCHAR(MAX), A.APPOINTMENT_END, 103) + ' ' + CONVERT(NVARCHAR(MAX), A.APPOINTMENT_END, 108) APPOINTMENT_END,
                CONVERT(NVARCHAR(MAX), A.START_TIME, 103) + ' ' + CONVERT(NVARCHAR(MAX), A.START_TIME, 108) START_TIME,
                CONVERT(NVARCHAR(MAX), A.END_TIME, 103) + ' ' + CONVERT(NVARCHAR(MAX), A.END_TIME, 108) END_TIME, 
                A.BILL_ID,
                B.CUSTOMER_NAME, 
                B.TEL,
                C.IS_PAID,
                STUFF(
					(
						SELECT 
							',' + CASE WHEN Z.NICKNAME IS NULL THEN 'UNKNOWN' ELSE Z.NICKNAME END
						FROM RESERVATION_DETAIL X
						INNER JOIN RESERVATION_THERAPIST Y ON X.reservation_detail_id = Y.reservation_detail_id
						LEFT OUTER JOIN EMPLOYEE Z ON Y.therapist_id = Z.emp_id
						WHERE X.reservation_id = A.reservation_id
						FOR XML PATH('')
					)
				, 1, 1, '') THERAPIST,
                STUFF(
					(
						SELECT 
							', ' + CONVERT(NVARCHAR(MAX), Y.THERAPIST_ID)
						FROM RESERVATION_DETAIL X
						INNER JOIN RESERVATION_THERAPIST Y ON X.reservation_detail_id = Y.reservation_detail_id
						WHERE X.reservation_id = A.reservation_id
						FOR XML PATH('')
					)
				, 1, 1, '') THERAPIST_ID,
				STUFF(
					(
						SELECT 
							', ' + CONVERT(NVARCHAR(MAX), ISNULL(Y.IS_REQUESTED, 0))
						FROM RESERVATION_DETAIL X
						INNER JOIN RESERVATION_THERAPIST Y ON X.reservation_detail_id = Y.reservation_detail_id
						WHERE X.reservation_id = A.reservation_id
						FOR XML PATH('')
					)
				, 1, 1, '') IS_REQUESTED,
				STUFF(
					(
						SELECT 
							', ' + CASE WHEN Y.program_name IS NULL THEN 'RESERVE' ELSE '#' + Y.CODE END
						FROM RESERVATION_DETAIL X
						LEFT OUTER JOIN SPA_PROGRAM Y ON X.spa_program_id = Y.spa_program_id
						WHERE X.reservation_id = A.reservation_id
						FOR XML PATH('')
					)
				, 1, 1, '') CODES,
				STUFF(
					(
						SELECT 
							', ' + CONVERT(NVARCHAR(MAX), X.reservation_detail_id)
						FROM RESERVATION_DETAIL X
                        INNER JOIN RESERVATION_THERAPIST Y ON X.RESERVATION_DETAIL_ID = Y.RESERVATION_DETAIL_ID
						WHERE X.reservation_id = A.reservation_id
						FOR XML PATH('')
					)
				, 1, 1, '') RESERVATION_DETAIL_ID,
				STUFF(
					(
						SELECT 
							', ' + CONVERT(NVARCHAR(MAX), (X.hours * 60) + X.mins)
						FROM RESERVATION_DETAIL X
						INNER JOIN RESERVATION_THERAPIST Y ON X.RESERVATION_DETAIL_ID = Y.RESERVATION_DETAIL_ID
						INNER JOIN SPA_PROGRAM Z ON X.SPA_PROGRAM_ID = Z.SPA_PROGRAM_ID
						WHERE X.reservation_id = A.reservation_id
                        ORDER BY X.RESERVATION_DETAIL_ID
						FOR XML PATH('')
					)
				, 1, 1, '') TOTAL_MINS
            FROM RESERVATION A
            LEFT OUTER JOIN CUSTOMER B ON A.CUSTOMER_ID = B.CUSTOMER_ID
            LEFT OUTER JOIN BILL C ON A.BILL_ID = C.BILL_ID
            WHERE A.is_shadow = 0 AND 
            (
	            (
		            (
                        CONVERT(VARCHAR, A.APPOINTMENT_START, 23) = '" + app_start_date + @"'
		            )
		            AND
		            A.START_TIME IS NULL
		            AND
		            A.END_TIME IS NULL
	            )
	            OR
	            (
		            (
                        CONVERT(VARCHAR, A.START_TIME, 23) = '" + real_start_date + @"'
		            )
		            AND
		            A.START_TIME IS NOT NULL
		            AND
		            A.END_TIME IS NOT NULL
	            )
            )";

            //(
            //    (
            //        (
            //            CONVERT(DATETIME, A.APPOINTMENT_START, 120) >= " + GF.modDate(app_start_date + " " + app_start_time, 120) + @"

            //            AND

            //            CONVERT(DATETIME, A.APPOINTMENT_END, 120) <= " + GF.modDate(app_end_date + " " + app_end_time, 120) + @"
		          //  )
		          //  AND

            //        A.START_TIME IS NULL
            //        AND

            //        A.END_TIME IS NULL
	           // )
	           // OR
            //    (
            //        (
            //            CONVERT(DATETIME, A.START_TIME, 120) >= " + GF.modDate(real_start_date + " " + real_start_time, 120) + @"

            //            AND

            //            CONVERT(DATETIME, A.END_TIME, 120) <= " + GF.modDate(real_end_date + " " + real_end_time, 120) + @"
            //        )

            //        AND

            //        A.START_TIME IS NOT NULL

            //        AND

            //        A.END_TIME IS NOT NULL
	           // )
            //)

            if (status.SelectedIndex != 0)
            {
                if (status.SelectedIndex < 3)
                {
                    queryString += " AND A.STATUS = " + ((ComboItem)status.SelectedItem).Key.ToString();
                }
                else
                {
                    queryString += " AND A.STATUS = 3";
                }
                if (status.SelectedIndex == 3) queryString += " AND A.BILL_ID IS NULL";
                if (status.SelectedIndex == 4) queryString += " AND A.BILL_ID IS NOT NULL";
            }
            else queryString += " AND A.STATUS IS NOT NULL";
            if (customer_data.Text.Trim() != "")
            {
                queryString += " AND (B.CUSTOMER_NAME LIKE '%' + @customer_data + '%' OR B.TEL LIKE '%' + @customer_data + '%')";
                Params.Add("@customer_data", customer_data.Text);
            }
            if (spa_card_no.Text.Trim() != "")
            {
                queryString += " AND (";
                foreach (String theCode in spa_card_no.Text.Trim().Split(','))
                {
                    if(theCode != String.Empty)
                        queryString += "A.CODE LIKE '" + (reservation_date.Value.Year + 543).ToString("0000") + reservation_date.Value.Month.ToString("00") + reservation_date.Value.Day.ToString("00") + Convert.ToInt32(theCode).ToString("0000") + "' OR ";
                }
                queryString = queryString.Substring(0, queryString.Length - 4);
                queryString += ")";
            }

            Console.WriteLine();
            Console.WriteLine(queryString);
            Console.WriteLine();

            using (DataTable resvDT = DB.getS(queryString, Params, "GET RESERVATION DATA ON " + reservation_date.Text.Trim(), false))
            {
                /* FORCE OPEN START */
                if (resvDT.Rows.Count == 1)
                {
                    String[] tmp = spa_card_no.Text.Trim().Split(',');
                    if (tmp.Length == 1)
                    {
                        force_open_res_id = resvDT.Rows[0]["RESERVATION_ID"].ToString();
                        if (resvDT.Rows[0]["START_TIME"].ToString() != "" && resvDT.Rows[0]["START_TIME"].ToString() != "NULL")
                        {
                            tmp = resvDT.Rows[0]["START_TIME"].ToString().Split(' ');
                            tmp = tmp[1].Split(':');
                            force_open_res_time = tmp[0] + "." + tmp[1];
                        }
                        else
                        {
                            tmp = resvDT.Rows[0]["APPOINTMENT_START"].ToString().Split(' ');
                            tmp = tmp[1].Split(':');
                            force_open_res_time = tmp[0] + "." + tmp[1];
                        }

                        queryString = @"
                        SELECT TOP 1 B.THERAPIST_ID
                        FROM RESERVATION_DETAIL A
                        INNER JOIN RESERVATION_THERAPIST B ON A.RESERVATION_DETAIL_ID = B.RESERVATION_DETAIL_ID
                        WHERE A.RESERVATION_ID = " + resvDT.Rows[0]["RESERVATION_ID"].ToString();
                        using (DataTable tmpDT = DB.getS(queryString, null, "GET FORCE OPEN THERAPIST_ID", false))
                        {
                            if (tmpDT.Rows.Count == 1)
                            {
                                force_open_therapist_id = Convert.ToInt32(tmpDT.Rows[0]["THERAPIST_ID"].ToString());
                            }
                        }
                    }
                }
                /* FORCE OPEN END */

                therapistBarList.Clear();
                roomBarList.Clear();

                for (int index = therapistTable.Rows.Count - 1; index >= 0; index--)
                {
                    if (therapistTable.Rows[index].Cells[0].Value.ToString() == "UNKNOWN")
                    {
                        therapistTable.Rows.RemoveAt(index);
                    }
                }

                int total = 0;
                int reserve = 0;
                int unfinish = 0;
                int unpaid = 0;
                int paid = 0;
                int cancel = 0;
                int barter = 0;

                foreach (DataRow data in resvDT.Rows)
                {
                    if (data["THERAPIST"].ToString().IndexOf("UNKNOWN") != -1 && data["STATUS"].ToString() != "0")
                    {
                        therapistTable.Rows.Insert(0, "UNKNOWN", data["RESERVATION_ID"].ToString());
                    }
                }

                foreach (DataRow data in resvDT.Rows)
                {
                    String start_date = "";
                    if (data["START_TIME"].ToString() == "NULL" || data["START_TIME"].ToString() == "")
                        start_date = data["APPOINTMENT_START"].ToString().Split(' ')[0];
                    if (data["START_TIME"].ToString() != "NULL" && data["START_TIME"].ToString() != "" && data["END_TIME"].ToString() != "NULL" && data["END_TIME"].ToString() != "NULL")
                        start_date = data["START_TIME"].ToString().Split(' ')[0];

                    String[] tmpDate = start_date.Split('/');
                    start_date = Convert.ToInt32(tmpDate[0]).ToString("00") + "/" + Convert.ToInt32(tmpDate[1]).ToString("00") + "/" + Convert.ToInt32(tmpDate[2]).ToString("0000");
                    //MessageBox.Show(reservation_date.Text.Trim() + " : " + start_date);
                    if (reservation_date.Text.Trim() == start_date)
                    {
                        total++;
                        if (data["IS_BARTER"].ToString() == "1") barter++;
                        switch (data["STATUS"].ToString())
                        {
                            case "0": cancel++; break;
                            case "1": reserve++; break;
                            case "2": unfinish++; break;
                            case "3":
                                if (data["BILL_ID"].ToString() == "") unpaid++;
                                else
                                {
                                    if (data["IS_PAID"].ToString() == "1") paid++;
                                    else unpaid++;
                                }
                                break;
                        }
                    }

                    if (data["STATUS"].ToString() != "0")
                    {
                        String[] isRequested = data["IS_REQUESTED"].ToString().Split(',');
                        String[] therapistID = data["THERAPIST_ID"].ToString().Split(',');
                        String[] reservationDetailID = data["RESERVATION_DETAIL_ID"].ToString().Split(',');
                        String[] totalMins = data["TOTAL_MINS"].ToString().Split(',');

                        if (data["reservation_id"].ToString() == "23853") Console.WriteLine(data["THERAPIST_ID"].ToString());

                        for (int dataIndex = 0; dataIndex < therapistID.Length; dataIndex++)
                        {
                            int therapistTableRowIndex = -1;
                            foreach (DataGridViewRow therapistTableRow in therapistTable.Rows)
                            {
                                if (data["THERAPIST"].ToString().IndexOf("UNKNOWN") != -1)
                                {
                                    if (therapistTableRow.Cells[0].Value.ToString().IndexOf("UNKNOWN") != -1)
                                    {
                                        if (therapistTableRow.Cells[1].Value.ToString() == data["RESERVATION_ID"].ToString().Trim())
                                        {
                                            therapistTableRowIndex = therapistTableRow.Index;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    if (therapistTableRow.Cells[1].Value.ToString() == therapistID[dataIndex].Trim())
                                    {
                                        therapistTableRowIndex = therapistTableRow.Index;
                                        break;
                                    }
                                }
                            }

                            if (data["reservation_id"].ToString() == "23853") Console.WriteLine(therapistID[dataIndex].Trim() + " // " + reservationDetailID[dataIndex].Trim() + " // " + totalMins[dataIndex].Trim());

                            String[] tmpDate1, tmpDate2, tmpTime1, tmpTime2, tmpDateTime;

                            if (data["START_TIME"].ToString() == "" || data["END_TIME"].ToString() == "") // JUST RESERVED OR NOT COMPLETE SPA PROGRAM DATA
                            {
                                tmpDateTime = data["APPOINTMENT_START"].ToString().Split(' ');
                                tmpDate1 = tmpDateTime[0].Split('/');
                                tmpTime1 = tmpDateTime[1].Split(':');

                                tmpDateTime = data["APPOINTMENT_END"].ToString().Split(' ');
                                tmpDate2 = tmpDateTime[0].Split('/');
                                tmpTime2 = tmpDateTime[1].Split(':');
                            }
                            else // STARTED
                            {
                                tmpDateTime = data["START_TIME"].ToString().Split(' ');
                                tmpDate1 = tmpDateTime[0].Split('/');
                                tmpTime1 = tmpDateTime[1].Split(':');

                                tmpDateTime = data["END_TIME"].ToString().Split(' ');
                                tmpDate2 = tmpDateTime[0].Split('/');
                                tmpTime2 = tmpDateTime[1].Split(':');
                            }

                            if (data["reservation_id"].ToString() == "23853")
                            {
                                Console.WriteLine("START : " + String.Join("/", tmpDate1) + " @ " + String.Join(":", tmpTime1));
                                Console.WriteLine("END : " + String.Join("/", tmpDate2) + " @ " + String.Join(":", tmpTime2));
                                Console.WriteLine();
                            }

                            GF.closeLoading();

                            int full_start_hours = Convert.ToInt32(tmpTime1[0]);
                            int full_start_minutes = Convert.ToInt32(tmpTime1[1]);
                            int full_end_hours = Convert.ToInt32(tmpTime2[0]);
                            int full_end_minutes = Convert.ToInt32(tmpTime2[1]);

                            if (therapistTableRowIndex > -1) createTherapistBar(data, therapistID[dataIndex], therapistTableRowIndex, data["CUSTOMER_NAME"].ToString(), data["TEL"].ToString(), (isRequested[dataIndex].Trim() == "1" ? true : false));
                            //dataIndex++;
                        }

                        foreach (DataGridViewRow roomTableRow in roomTable.Rows)
                        {
                            if (roomTableRow.Cells["ROOM_ID"].Value.ToString() == data["ROOM_ID"].ToString())
                            {
                                createRoomBar(data, roomTableRow.Index);
                                break;
                            }
                        }
                    }
                }
                //if (therapistTable.Columns[0].Width > firstCellWidth) firstCellWidth = therapistTable.Columns[0].Width;
                firstCellWidth = therapistTable.Columns[0].Width;
                therapistTable.Invalidate();
                roomTable.Invalidate();
                total_lbl.Text = "TOTAL : " + total.ToString() + "     RESERVE : " + reserve.ToString() + "     UNFINISHED : " + unfinish.ToString() + "     UNPAID : " + unpaid.ToString() + "     PAID : " + paid.ToString() + "     CANCEL : " + cancel.ToString() + "     BARTER : " + barter.ToString();
                ActiveControl = therapistTable;

            }
            checkDayOff();
            GF.closeLoading();
        }

        void createTherapistBar(DataRow data, String therapistID, int row, string customer_name, string customer_tel, bool isRequested = false)
        {
            String[] tmpDate1, tmpDate2, tmpTime1, tmpTime2, tmpDateTime;
            bool crossStart = false;
            bool crossEnd = false;

            if (data["START_TIME"].ToString() == "" || data["END_TIME"].ToString() == "") // JUST RESERVED OR NOT COMPLETE SPA PROGRAM DATA
            {
                tmpDateTime = data["APPOINTMENT_START"].ToString().Split(' ');
                tmpDate1 = tmpDateTime[0].Split('/');
                tmpTime1 = tmpDateTime[1].Split(':');

                tmpDateTime = data["APPOINTMENT_END"].ToString().Split(' ');
                tmpDate2 = tmpDateTime[0].Split('/');
                tmpTime2 = tmpDateTime[1].Split(':');
            }
            else // STARTED
            {
                tmpDateTime = data["START_TIME"].ToString().Split(' ');
                tmpDate1 = tmpDateTime[0].Split('/');
                tmpTime1 = tmpDateTime[1].Split(':');

                tmpDateTime = data["END_TIME"].ToString().Split(' ');
                tmpDate2 = tmpDateTime[0].Split('/');
                tmpTime2 = tmpDateTime[1].Split(':');
            }

            //Console.WriteLine(customer_name + " >> " + tmpTime1[0] + ":" + tmpTime1[1]);

            if(Convert.ToInt32(tmpTime1[0]) >= 0 && Convert.ToInt32(tmpTime1[0]) < time_range)
            {
                tmpTime1[0] = time_range.ToString();
                tmpTime1[1] = "00";
            }

            //Console.WriteLine(customer_name + " >> " + tmpTime1[0] + ":" + tmpTime1[1]);

            /*if (data["reservation_id"].ToString() == "23853")
            {
                Console.WriteLine("START : " + String.Join("/", tmpDate1) + " @ " + String.Join(":", tmpTime1));
                Console.Write("END : " + String.Join("/", tmpDate2) + " @ " + String.Join(":", tmpTime2));
                Console.WriteLine();
            }

            GF.closeLoading();*/

            int full_start_hours = Convert.ToInt32(tmpTime1[0]);
            int full_start_minutes = Convert.ToInt32(tmpTime1[1]);
            int full_end_hours = Convert.ToInt32(tmpTime2[0]);
            int full_end_minutes = Convert.ToInt32(tmpTime2[1]);

            int start_col = -1;
            int end_col = -1;

            int today_year = reservation_date.Value.Year;
            int today_month = reservation_date.Value.Month;
            int today_day = reservation_date.Value.Day;

            string[] tmp;

            if (Convert.ToInt32(tmpDate1[2]) < today_year || (Convert.ToInt32(tmpDate1[2]) == today_year && Convert.ToInt32(tmpDate1[1]) < today_month) || (Convert.ToInt32(time_range) == 0 && (Convert.ToInt32(tmpDate1[2]) == today_year && Convert.ToInt32(tmpDate1[1]) == today_month && Convert.ToInt32(tmpDate1[0]) < today_day)))
            {
                start_col = 2;
                crossStart = true;
            }
            else
            {
                foreach (DataGridViewColumn tmpCol in therapistTable.Columns) // START
                {
                    if (tmpCol.Index > 1)
                    {
                        using (DataGridViewHeaderCell header = tmpCol.HeaderCell)
                        {
                            tmp = header.Value.ToString().Trim().Split('.');
                        }
                        int tmpHour = Convert.ToInt32(tmp[0]);
                        int tmpMin = Convert.ToInt32(tmp[1]);

                        if (tmpHour == full_start_hours)
                        {
                            start_col = tmpCol.Index;
                            break;
                        }
                    }
                }
            }

            foreach (DataGridViewColumn tmpCol in therapistTable.Columns) // END
            {
                if (tmpCol.Index > 1)
                {
                    using (DataGridViewHeaderCell header = tmpCol.HeaderCell)
                    {
                        tmp = header.Value.ToString().Trim().Split('.');
                    }
                    int tmpHour = Convert.ToInt32(tmp[0]);
                    int tmpMin = Convert.ToInt32(tmp[1]);

                    if (tmpHour == full_end_hours)
                    {
                        end_col = tmpCol.Index;
                        break;
                    }
                }
            }

            if (end_col == -1)
            {
                end_col = therapistTable.Columns.Count - 1;
                crossEnd = true;
            }

            foreach (DataGridViewRow theRow in therapistTable.Rows)
            {
                if (data["THERAPIST"].ToString().IndexOf("UNKNOWN") != -1 && theRow.Cells[1].Value.ToString() == data["RESERVATION_ID"].ToString())
                {
                    row = theRow.Index;
                    break;
                }
            }

            // Row & Col :: END HERE //

            Brush color = null;

            if (data["STATUS"].ToString() == "1") color = reserved;
            if (data["STATUS"].ToString() == "2") color = started;
            if (data["STATUS"].ToString() == "3")
            {
                if (data["BILL_ID"].ToString() == "") color = unpaid;
                else
                {
                    if (data["IS_PAID"].ToString() == "1") color = paid;
                    else color = unpaid;
                }
            }

            string display_text = "";
            display_text += customer_name + "|";
            display_text += customer_tel += "|";

            display_text += data["CODES"] + ",";

            therapistBarList.Add(new bar(data["RESERVATION_ID"].ToString(), data["ROOM_ID"].ToString(), color, display_text, row, start_col, end_col, full_start_minutes, full_end_minutes, isRequested, crossStart, crossEnd));
        }

        void createRoomBar(DataRow data, int row)
        {
            String[] tmpDate1, tmpDate2, tmpTime1, tmpTime2, tmpDateTime;
            bool crossStart = false;
            bool crossEnd = false;

            if (data["START_TIME"].ToString() == "" || data["END_TIME"].ToString() == "") // JUST RESERVED OR NOT COMPLETE SPA PROGRAM DATA
            {
                tmpDateTime = data["APPOINTMENT_START"].ToString().Split(' ');
                tmpDate1 = tmpDateTime[0].Split('/');
                tmpTime1 = tmpDateTime[1].Split(':');

                tmpDateTime = data["APPOINTMENT_END"].ToString().Split(' ');
                tmpDate2 = tmpDateTime[0].Split('/');
                tmpTime2 = tmpDateTime[1].Split(':');
            }
            else // STARTED
            {
                tmpDateTime = data["START_TIME"].ToString().Split(' ');
                tmpDate1 = tmpDateTime[0].Split('/');
                tmpTime1 = tmpDateTime[1].Split(':');

                tmpDateTime = data["END_TIME"].ToString().Split(' ');
                tmpDate2 = tmpDateTime[0].Split('/');
                tmpTime2 = tmpDateTime[1].Split(':');
            }

            if (Convert.ToInt32(tmpTime1[0]) >= 0 && Convert.ToInt32(tmpTime1[0]) < time_range)
            {
                tmpTime1[0] = time_range.ToString();
                tmpTime1[1] = "00";
            }

            int full_start_hours = Convert.ToInt32(tmpTime1[0]);
            int full_start_minutes = Convert.ToInt32(tmpTime1[1]);
            int full_end_hours = Convert.ToInt32(tmpTime2[0]);
            int full_end_minutes = Convert.ToInt32(tmpTime2[1]);

            int start_col = -1;
            int end_col = -1;

            int today_year = reservation_date.Value.Year;
            int today_month = reservation_date.Value.Month;
            int today_day = reservation_date.Value.Day;

            string[] tmp;

            if (Convert.ToInt32(tmpDate1[2]) < today_year || (Convert.ToInt32(tmpDate1[2]) == today_year && Convert.ToInt32(tmpDate1[1]) < today_month) || (Convert.ToInt32(tmpDate1[2]) == today_year && Convert.ToInt32(tmpDate1[1]) == today_month && Convert.ToInt32(tmpDate1[0]) < today_day))
            {
                start_col = 2;
                crossStart = true;
            }
            else
            {
                foreach (DataGridViewColumn tmpCol in roomTable.Columns) // START
                {
                    if (tmpCol.Index > 1)
                    {
                        using (DataGridViewHeaderCell header = tmpCol.HeaderCell)
                        {
                            tmp = header.Value.ToString().Trim().Split('.');
                        }
                        int tmpHour = Convert.ToInt32(tmp[0]);
                        int tmpMin = Convert.ToInt32(tmp[1]);

                        if (tmpHour == full_start_hours)
                        {
                            start_col = tmpCol.Index;
                            break;
                        }
                    }
                }
            }

            /*if (Convert.ToInt32(tmpDate2[2]) > today_year || (Convert.ToInt32(tmpDate2[2]) == today_year && Convert.ToInt32(tmpDate2[1]) > today_month) || (Convert.ToInt32(tmpDate2[2]) == today_year && Convert.ToInt32(tmpDate2[1]) == today_month && Convert.ToInt32(tmpDate2[0]) > today_day))
            {
                end_col = therapistTable.Columns.Count - 1;
                crossEnd = true;
            }
            else
            {
                foreach (DataGridViewColumn tmpCol in roomTable.Columns) // END
                {
                    if (tmpCol.Index > 1)
                    {
                        using (DataGridViewHeaderCell header = tmpCol.HeaderCell)
                        {
                            tmp = header.Value.ToString().Trim().Split('.');
                        }
                        int tmpHour = Convert.ToInt32(tmp[0]);
                        int tmpMin = Convert.ToInt32(tmp[1]);

                        if (tmpHour == end_hours)
                        {
                            end_col = tmpCol.Index;
                            break;
                        }
                    }
                }
            }
             
            if (end_col == -1) end_col = roomTable.Columns.Count - 1;*/

            foreach (DataGridViewColumn tmpCol in roomTable.Columns) // END
            {
                if (tmpCol.Index > 1)
                {
                    using (DataGridViewHeaderCell header = tmpCol.HeaderCell)
                    {
                        tmp = header.Value.ToString().Trim().Split('.');
                    }
                    int tmpHour = Convert.ToInt32(tmp[0]);
                    int tmpMin = Convert.ToInt32(tmp[1]);

                    if (tmpHour == full_end_hours)
                    {
                        end_col = tmpCol.Index;
                        break;
                    }
                }
            }

            if (end_col == -1)
            {
                end_col = roomTable.Columns.Count - 1;
                crossEnd = true;
            }

            // Row & Col :: END HERE //

            Brush color = null;
            if (data["STATUS"].ToString() == "1") color = reserved;
            if (data["STATUS"].ToString() == "2") color = started;
            if (data["STATUS"].ToString() == "3" && data["BILL_ID"].ToString() == "") color = unpaid;
            if (data["STATUS"].ToString() == "3" && data["BILL_ID"].ToString() != "") color = paid;

            string therapist_name = "";
            /*String queryString = @"
            SELECT 
                C.FULLNAME THERAPIST_NAME
            FROM RESERVATION_DETAIL A
            INNER JOIN RESERVATION_THERAPIST B ON A.RESERVATION_DETAIL_ID = B.RESERVATION_DETAIL_ID
            LEFT OUTER JOIN EMPLOYEE C ON B.THERAPIST_ID = C.EMP_ID
            WHERE A.RESERVATION_ID = " + data["RESERVATION_ID"].ToString();

            using (DataTable DT = DB.get(queryString, "GET THERAPIST DATA FROM RESERVATION[" + data["RESERVATION_ID"].ToString() + "]", false))
            {
                foreach (DataRow therapistRow in DT.Rows)
                {
                    if (therapistRow["THERAPIST_NAME"].ToString() != "")
                    {
                        if (therapist_name.IndexOf(GF.getNickname(therapistRow["THERAPIST_NAME"].ToString())) == -1) therapist_name += GF.getNickname(therapistRow["THERAPIST_NAME"].ToString()) + ", ";
                    }
                }
            }
            if (therapist_name.Trim() != "")
            {
                therapist_name = therapist_name.Substring(0, therapist_name.Trim().Length - 1);
            }*/

            therapist_name = String.Join(", ", data["THERAPIST"].ToString().Trim().Split(',').Distinct().ToArray());

            roomBarList.Add(new bar(data["RESERVATION_ID"].ToString(), data["ROOM_ID"].ToString(), color, therapist_name, row, start_col, end_col, full_start_minutes, full_end_minutes, (data["IS_ROOM_REQUESTED"].ToString() == "1" ? true : false), crossStart, crossEnd));
            //color.Dispose();
        }

        public void initTable()
        {
            using (DataTable myDT = DB.getS("SELECT time_range FROM APP_CONFIG", null, "GET CONFIG", false))
            {
                time_range = Convert.ToInt16(myDT.Rows[0]["time_range"].ToString());

                /*
                * 0=00:01-01:00; 
                * 1=01:01-02:00; 
                * 2=02:01-03:00; 
                * 3=03:01-04:00; 
                * 4=04:01-05:00; 
                * 5=05:01-06:00; 
                * 6=06:01-07:00; 
                * 7=07:01-08:00; 
                * 8=08:01-09:00; 
                * 9=09:01-10:00; 
                * 10=10:01-11:00; 
                * 11=11:01-12:00; 
                * 12=12:01-13:00; 
                * 13=13:01-14:00; 
                * 14=14:01-15:00; 
                * 15=15:01-16:00; 
                * 16=16:01-17:00; 
                * 17=17:01-18:00; 
                * 18=18:01-19:00; 
                * 19=19:01-20:00; 
                * 20=20:01-21:00; 
                * 21=21:01-22:00; 
                * 22=22:01-23:00; 
                * 23=23:01-00:00;
                * */
            }

            int availableHeight = this.Height - customer_data_lbl.Top - desc_tbl.Height - 150 - 10;
            int availableWidth = this.Width - 17;

            therapistTable.Left = 10;
            therapistTable.Top = customer_data_lbl.Top + 30;
            therapistTable.Width = availableWidth;
            therapistTable.Height = Convert.ToInt32(Convert.ToDouble(availableHeight) / 2);
            therapistTable.BackColor = Color.White;

            roomTable.Left = 10;
            roomTable.Top = therapistTable.Top + Convert.ToInt32(Convert.ToDouble(availableHeight) / 2) + 10;
            roomTable.Width = availableWidth;
            roomTable.Height = Convert.ToInt32(Convert.ToDouble(availableHeight) / 2);
            roomTable.BackColor = Color.White;

            if (therapistTable.ColumnCount == 0)
            {
                therapistTable.Columns.Add("THERAPIST_NAME", "");
                therapistTable.Columns.Add("THERAPIST_ID", "THERAPIST_ID");
                therapistTable.Columns["THERAPIST_ID"].Visible = false;
                for (int i = time_range; i < 24 + time_range; i++)
                {
                    int hour_num = i;
                    if (hour_num >= 24) hour_num = hour_num - 24;
                    
                    therapistTable.Columns.Add(hour_num.ToString("00") + "00", hour_num.ToString("00") + ".00");
                    therapistTable.Columns[hour_num.ToString("00") + "00"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                foreach (DataGridViewColumn column in therapistTable.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            string queryString = @"
            SELECT 
                A.emp_id, 
                ISNULL(A.nickname, A.fullname) THERAPIST_NAME 
            FROM EMPLOYEE A 
            WHERE A.EMP_DEPT_ID = 3 
            AND A.EMP_STATUS = 1
            ORDER BY A.fullname";
            /*string queryString = @"
            SELECT 
                A.emp_id, 
                SUBSTRING(A.fullname, CHARINDEX('(', A.fullname) + 1, ((CHARINDEX(')', A.fullname) - CHARINDEX('(', A.fullname))) - 1) THERAPIST_NAME 
            FROM EMPLOYEE A 
            WHERE A.EMP_DEPT_ID = 3 
            AND A.EMP_STATUS = 1
            ORDER BY SUBSTRING(A.fullname, CHARINDEX('(', A.fullname) + 1, ((CHARINDEX(')', A.fullname) - CHARINDEX('(', A.fullname))) - 1)";*/
            using (DataTable DT = DB.getS(queryString, null, "GET THERAPIST LIST", false))
            {
                foreach (DataRow row in DT.Rows)
                {
                    therapistTable.Rows.Add(row["THERAPIST_NAME"].ToString(), row["EMP_ID"].ToString());
                    therapistTable.Rows[therapistTable.Rows.Count - 1].Cells[0].Style.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
                }
            }

            if (!therapistTable.Columns[therapistTable.Columns.Count - 1].Displayed)
            {
                do
                {
                    float fontSize = therapistTable.ColumnHeadersDefaultCellStyle.Font.Size;
                    DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
                    headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                    headerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
                    headerStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", fontSize - 1, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                    headerStyle.ForeColor = System.Drawing.SystemColors.WindowText;
                    headerStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
                    headerStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
                    headerStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
                    therapistTable.ColumnHeadersDefaultCellStyle = headerStyle;
                } while (!therapistTable.Columns[therapistTable.Columns.Count - 1].Displayed);
            }

            int tableHeight = therapistTable.Columns[0].HeaderCell.Size.Height;
            do
            {
                tableHeight += therapistTable.Rows[0].Height;
            } while (tableHeight + therapistTable.Rows[0].Height < therapistTable.Height);
            therapistTable.Height = tableHeight;

            firstCellWidth = therapistTable.Columns["THERAPIST_NAME"].Width;
            otherCellWidth = therapistTable.Columns[2].Width;

            if (roomTable.ColumnCount == 0)
            {
                roomTable.Columns.Add("ROOM_NAME", "");
                roomTable.Columns.Add("ROOM_ID", "ROOM_ID");
                roomTable.Columns["ROOM_ID"].Visible = false;
                for (int i = time_range; i < 24 + time_range; i++)
                {
                    int hour_num = i;
                    if (hour_num >= 24) hour_num = hour_num - 24;
                    
                    roomTable.Columns.Add(hour_num.ToString("00") + "00", hour_num.ToString("00") + ".00");
                    roomTable.Columns[hour_num.ToString("00") + "00"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                foreach (DataGridViewColumn column in roomTable.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            using (DataTable DT = DB.getS("SELECT * FROM ROOM WHERE IS_USE = 1 ORDER BY CONVERT(BIGINT, SUBSTRING(CODE, 0, CHARINDEX('/', code))), CONVERT(BIGINT, SUBSTRING(CODE, CHARINDEX('/', code) + 1, LEN(CODE) - (CHARINDEX('/', code))))", null, "GET ROOM LIST", false))
            {
                foreach (DataRow row in DT.Rows)
                {
                    roomTable.Rows.Add(row["CODE"].ToString(), row["ROOM_ID"].ToString());
                    roomTable.Rows[roomTable.Rows.Count - 1].Cells[0].Style.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
                    if ((int)(Convert.ToInt32(row["CODE"].ToString().Substring(0, row["CODE"].ToString().IndexOf('/'))) % 2) != 0)
                        roomTable.Rows[roomTable.Rows.Count - 1].DefaultCellStyle.BackColor = Color.White;
                    else
                        roomTable.Rows[roomTable.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(242, 201, 143);
                }
            }
            if (roomTable.Columns["ROOM_NAME"].Width < firstCellWidth) roomTable.Columns[0].Width = firstCellWidth;
            foreach (DataGridViewColumn col in roomTable.Columns)
            {
                if (col.Index > 1) col.Width = otherCellWidth;
            }
            GF.closeLoading();
            int loopCount = 0;
            if (!roomTable.Columns[roomTable.Columns.Count - 1].Displayed)
            {
                do
                {
                    loopCount++;
                    float fontSize = roomTable.ColumnHeadersDefaultCellStyle.Font.Size;
                    DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
                    headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                    headerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
                    headerStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", fontSize - 1, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                    headerStyle.ForeColor = System.Drawing.SystemColors.WindowText;
                    headerStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
                    headerStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
                    headerStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
                    roomTable.ColumnHeadersDefaultCellStyle = headerStyle;
                } while (!roomTable.Columns[roomTable.Columns.Count - 1].Displayed);
            }
            
            tableHeight = roomTable.Columns[0].HeaderCell.Size.Height;
            do
            {
                tableHeight += roomTable.Rows[0].Height;
            } while (tableHeight + roomTable.Rows[0].Height < roomTable.Height);
            roomTable.Height = tableHeight;
            roomTable.AutoResizeColumns();
        }

        private void therapistTable_Paint(object sender, PaintEventArgs e)
        {
            if (GF.TODAY() == reservation_date.Text.Trim())
            {
                int currHour = DateTime.Now.Hour;
                int currMin = DateTime.Now.Minute;
                int colIndex = -1;
                int colLeft = -1;
                int colWidth = -1;
                int lineTop = -1;
                int lineBottom = -1;

                foreach (DataGridViewColumn col in therapistTable.Columns)
                {
                    if (col.Index > 1)
                    {
                        int cellHour = Convert.ToInt32(col.HeaderText.Trim().Split('.')[0]);
                        int cellMin = Convert.ToInt32(col.HeaderText.Trim().Split('.')[1]);

                        if (cellHour == currHour)
                        {
                            colIndex = col.Index;
                            break;
                        }
                    }
                }

                colLeft = therapistTable.GetCellDisplayRectangle(colIndex, (therapistFirstDisplayedRowIndex < 0 ? 0 : therapistFirstDisplayedRowIndex), true).Left;
                colWidth = therapistTable.GetCellDisplayRectangle(colIndex, (therapistFirstDisplayedRowIndex < 0 ? 0 : therapistFirstDisplayedRowIndex), true).Width;
                lineTop = therapistTable.GetCellDisplayRectangle(colIndex, (therapistFirstDisplayedRowIndex < 0 ? 0 : therapistFirstDisplayedRowIndex), true).Top;
                lineBottom = therapistTable.GetCellDisplayRectangle(colIndex, (therapistLastVisibleRowIndex > therapistTable.Rows.Count - 1 ? therapistTable.Rows.Count - 1 : therapistLastVisibleRowIndex), true).Bottom;

                colLeft = colLeft + (int)(((float)currMin / (float)60) * colWidth);

                e.Graphics.FillRectangle(Brushes.Blue, colLeft, lineTop, 3, lineBottom - lineTop);
            }
            foreach (bar tmpBar in therapistBarList)
            {
                if (therapistFirstDisplayedRowIndex <= tmpBar.rowIndex && tmpBar.rowIndex <= therapistLastVisibleRowIndex)
                {
                    tmpBar.drawBar(therapistTable, e);
                }
            }
            //e.Graphics.Dispose();
        }

        private void roomTable_Paint(object sender, PaintEventArgs e)
        {
            if (GF.TODAY() == reservation_date.Text.Trim())
            {
                int currHour = DateTime.Now.Hour;
                int currMin = DateTime.Now.Minute;
                int colIndex = -1;
                int colLeft = -1;
                int colWidth = -1;
                int lineTop = -1;
                int lineBottom = -1;

                foreach (DataGridViewColumn col in roomTable.Columns)
                {
                    if (col.Index > 1)
                    {
                        int cellHour = Convert.ToInt32(col.HeaderText.Trim().Split('.')[0]);
                        int cellMin = Convert.ToInt32(col.HeaderText.Trim().Split('.')[1]);

                        if (cellHour == currHour)
                        {
                            colIndex = col.Index;
                            break;
                        }
                    }
                }

                colLeft = roomTable.GetCellDisplayRectangle(colIndex, (roomFirstDisplayedRowIndex < 0 ? 0 : roomFirstDisplayedRowIndex), true).Left;
                colWidth = roomTable.GetCellDisplayRectangle(colIndex, (roomFirstDisplayedRowIndex < 0 ? 0 : roomFirstDisplayedRowIndex), true).Width;
                lineTop = roomTable.GetCellDisplayRectangle(colIndex, (roomFirstDisplayedRowIndex < 0 ? 0 : roomFirstDisplayedRowIndex), true).Top;
                lineBottom = roomTable.GetCellDisplayRectangle(colIndex, (roomLastVisibleRowIndex > roomTable.Rows.Count - 1 ? roomTable.Rows.Count - 1 : roomLastVisibleRowIndex), true).Bottom;

                colLeft = colLeft + (int)(((float)currMin / (float)60) * colWidth);

                e.Graphics.FillRectangle(Brushes.Blue, colLeft, lineTop, 3, lineBottom - lineTop);
            }
            foreach (bar tmpBar in roomBarList)
            {
                if (roomFirstDisplayedRowIndex <= tmpBar.rowIndex && tmpBar.rowIndex <= roomLastVisibleRowIndex)
                {
                    tmpBar.drawBar(roomTable, e);
                }
            }
            roomTable.Columns["ROOM_NAME"].Width = firstCellWidth;
        }

        private void therapistTable_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > 0 && e.RowIndex >= 0)
            {
                string res_id = "";
                Rectangle cellRect = therapistTable.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                int left = cellRect.Left;
                int top = cellRect.Top;

                foreach (bar tmpBar in therapistBarList)
                {
                    if (tmpBar.isClicked((float)(left + e.X), e.RowIndex))
                    {
                        res_id = tmpBar.res_id;
                        if (isChoosing && (tmpBar.brush == unpaid || tmpBar.brush == started)) tmpBar.toggleSelect();
                        break;
                    }
                }

                if (!isChoosing)
                {
                    GF.destroyTimer();
                    using (reservation_manage managePage = new reservation_manage())
                    {
                        managePage.Owner = this;
                        managePage.res_id = res_id;
                        managePage.res_time = therapistTable.Columns[e.ColumnIndex].HeaderText.Trim();
                        managePage.currentRoomID = -1;
                        managePage.selected_date = reservation_date.Text.Trim();
                        managePage.theOwner = this;
                        managePage.therapist_id = Convert.ToInt32(therapistTable.Rows[e.RowIndex].Cells["THERAPIST_ID"].Value.ToString().Trim());
                        managePage.ShowDialog();
                    }
                }
                else therapistTable.Invalidate();
            }
        }

        private void roomTable_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > 0 && e.RowIndex >= 0)
            {
                string res_id = "";
                Rectangle cellRect = roomTable.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                int left = cellRect.Left;
                int top = cellRect.Top;

                foreach (bar tmpBar in roomBarList)
                {
                    if (tmpBar.isClicked((float)(left + e.X), e.RowIndex))
                    {
                        res_id = tmpBar.res_id;
                        if (isChoosing && (tmpBar.brush == unpaid || tmpBar.brush == started)) tmpBar.toggleSelect();
                        break;
                    }
                }

                if (!isChoosing)
                {
                    GF.destroyTimer();
                    using (reservation_manage managePage = new reservation_manage())
                    {
                        managePage.Owner = this;
                        managePage.res_id = res_id;
                        managePage.res_time = roomTable.Columns[e.ColumnIndex].HeaderText.Trim();
                        managePage.currentRoomID = Convert.ToInt32(roomTable.Rows[e.RowIndex].Cells["ROOM_ID"].Value.ToString().Trim());
                        managePage.selected_date = reservation_date.Text.Trim();
                        managePage.theOwner = this;
                        managePage.therapist_id = -1;
                        managePage.ShowDialog();
                    }
                }
                else roomTable.Invalidate();
            }
        }

        private void therapistTable_Scroll(object sender, ScrollEventArgs e)
        {
            updateVisibleRow();
            therapistTable.Invalidate();
        }
        private void roomTable_Scroll(object sender, ScrollEventArgs e)
        {
            updateVisibleRow();
            roomTable.Invalidate();
        }

        private void status_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!firstLoad) loadData();
        }

        private void reservation_FormClosing(object sender, FormClosingEventArgs e)
        {
            GF.destroyTimer();
            isExit = true;
        }

        private void select_btn_Click(object sender, EventArgs e)
        {
            if (select_btn.Text.Trim() == "SELECT")
            {
                isUnpaid = 0;
                isPaid = 0;
                isNotFinished = 0;
                isChoosing = true;
                select_btn.Text = "PAYMENT";
                finish_btn.Visible = true;
                cancel_btn.Visible = true;
                GF.destroyTimer();
                ActiveControl = therapistTable;
                return;
            }
            if (select_btn.Text.Trim() == "PAYMENT")
            {
                string res_id = "";
                foreach (bar theBar in roomBarList)
                {
                    if (theBar.isSelected())
                    {
                        res_id += theBar.res_id + ", ";
                        if (theBar.brush == unpaid) isUnpaid++;
                        if (theBar.brush == paid) isPaid++;
                        if (theBar.brush == started) isNotFinished++;
                    }
                }
                if (isNotFinished > 0)
                {
                    MessageBox.Show("PLEASE SELECT ONLY FINISHED RESERVATION !!", "ERROR");
                    return;
                }
                if (res_id.Trim() == "")
                {
                    MessageBox.Show("YOU DID NOT SELECT ANY RESERVATION !!", "ERROR");
                    return;
                }
                else res_id = res_id.Substring(0, res_id.Trim().Length - 1);

                GF.initPage(new SHOP.cashier(), GF.mainPage);
                return;
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            foreach (bar selectedBar in roomBarList)
            {
                selectedBar.toggleSelect(false);
            }
            foreach (bar selectedBar in therapistBarList)
            {
                selectedBar.toggleSelect(false);
            }
            isChoosing = false;
            select_btn.Text = "SELECT";
            finish_btn.Visible = false;
            cancel_btn.Visible = false;
            loadData();
            roomTable.Invalidate();
            therapistTable.Invalidate();
            //GF.createTimer();
            //GF.clock.Tick += (s, ee) =>
            //{
                
            //};
            ActiveControl = therapistTable;
        }

        private void therapistTable_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            therapistTable.ClearSelection();
        }

        private void roomTable_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            roomTable.ClearSelection();
        }

        private void finish_btn_Click(object sender, EventArgs e)
        {
            string res_id = "";
            foreach (bar theBar in roomBarList)
            {
                if (theBar.isSelected())
                {
                    res_id += theBar.res_id + ", ";
                    if (theBar.brush == unpaid) isUnpaid++;
                    if (theBar.brush == paid) isPaid++;
                    if (theBar.brush == started) isNotFinished++;
                }
            }
            if (isUnpaid > 0)
            {
                MessageBox.Show("PLEASE SELECT ONLY UNFINISHED RESERVATION !!", "ERROR");
                return;
            }
            if (res_id.Trim() == "")
            {
                MessageBox.Show("YOU DID NOT SELECT ANY RESERVATION !!", "ERROR");
                return;
            }
            else res_id = res_id.Substring(0, res_id.Trim().Length - 1);

            GF.showLoading(this);
            DB.beginTrans();
            String queryString = "UPDATE RESERVATION WITH (ROWLOCK) SET STATUS=3, FINISH_BY=" + GF.emp_id.ToString() + ", FINISH_SYS_TIME=GETDATE() WHERE RESERVATION_ID IN (" + res_id + ")";
            if (!DB.set(queryString, "FINISH RES_ID[" + res_id + "] FROM roomTable"))
            {
                MessageBox.Show("ERROR MARK AS FINISHED !!", "ERROR");
                GF.closeLoading();
            }
            DB.close();

            foreach (bar selectedBar in roomBarList)
            {
                selectedBar.toggleSelect(false);
            }
            isChoosing = false;
            select_btn.Text = "SELECT";
            finish_btn.Visible = false;
            cancel_btn.Visible = false;
            loadData();
            roomTable.Invalidate();
            therapistTable.Invalidate();
            /*GF.createTimer();
            GF.clock.Tick += (s, ee) =>
            {
                
            };*/
            ActiveControl = therapistTable;
            GF.closeLoading();
        }

        private void reservation_date_ValueChanged(object sender, EventArgs e)
        {
            loadData();
            ActiveControl = therapistTable;
        }

        private void customer_data_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return) loadData();
        }

        private void return_keycard_btn_Click(object sender, EventArgs e)
        {
            isMasterCard = false;
            GF.showLoading();
            KEYCARD.executeCommand(this, "REVOKE");
            //KEYCARD keycard = new KEYCARD(this, "VERIFY");
            GF.closeLoading();
        }

        private void master_day_off_btn_Click(object sender, EventArgs e)
        {
            GF.destroyTimer();
            using (master_day_off masterDayOff = new master_day_off())
            {
                masterDayOff.Owner = this;
                masterDayOff.res_date = this.reservation_date.Text.Trim();
                masterDayOff.Text = "MASTER DAY OFF : " + this.reservation_date.Text.Trim();
                masterDayOff.ShowDialog();
            }
            GF.showLoading(this);
            loadData();
            updateVisibleRow();
            GF.closeLoading();
        }

        private void checkDayOff()
        {
            foreach (DataGridViewRow row in therapistTable.Rows)
            {
                row.Cells[0].Style.ForeColor = Color.Black;
            }

            Dictionary<string, string> Params = new Dictionary<string, string>();
            /*Params.Add("@res_date", GF.modDate(reservation_date.Text.Trim()));*/
            string queryString = "SELECT THERAPIST_ID FROM RESERVATION_THERAPIST_DAY_OFF WHERE RES_DATE = " + GF.modDate(reservation_date.Text.Trim());
            using (DataTable DT = DB.getS(queryString, Params, "CHECK THERAPIST DAY OFF ON " + reservation_date.Text.Trim(), false))
            {
                foreach (DataRow row in DT.Rows)
                {
                    foreach (DataGridViewRow DGVrow in therapistTable.Rows)
                    {
                        if (DGVrow.Cells[1].Value.ToString() == row["THERAPIST_ID"].ToString())
                        {
                            DGVrow.Cells[0].Style.ForeColor = Color.Red;
                            break;
                        }
                    }
                }
            }
        }

        private void reservation_FormClosed(object sender, FormClosedEventArgs e)
        {
            /*reserved.Dispose();
            started.Dispose();
            unpaid.Dispose();
            paid.Dispose();
            foreach (bar thebar in roomBarList)
            {
                thebar.Dispose();
            }
            foreach (bar thebar in therapistBarList)
            {
                thebar.Dispose();
            }*/
        }

        private void force_open_btn_Click(object sender, EventArgs e)
        {
            String[] tmp = spa_card_no.Text.Trim().Split(',');
            if (tmp.Length == 0)
            {
                MessageBox.Show("NO SPA CARD NUMBER !!\r\nor\r\nSPA CARD NUMBER IS INVALID !!", "ERROR");
                return;
            }
            if (tmp.Length > 1)
            {
                MessageBox.Show("FORCE OPEN CAN ONLY OPEN 1 SPA CARD NUMBER !!", "ERROR");
                return;
            }
            GF.destroyTimer();
            
            using (reservation_manage managePage = new reservation_manage())
            {
                managePage.Owner = this;
                managePage.res_id = force_open_res_id;
                managePage.res_time = force_open_res_time;
                managePage.currentRoomID = -1;
                managePage.selected_date = reservation_date.Text.Trim();
                managePage.theOwner = this;
                managePage.therapist_id = force_open_therapist_id;
                managePage.ShowDialog();
            }
        }

        private void spa_card_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void spa_card_no_TextChanged(object sender, EventArgs e)
        {

        }

        private void spa_card_no_lbl_Click(object sender, EventArgs e)
        {

        }
    }
}
