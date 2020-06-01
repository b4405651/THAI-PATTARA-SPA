using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using SPA_MANAGEMENT_SYSTEM.CUSTOMER;

namespace SPA_MANAGEMENT_SYSTEM.RESERVATION
{
    public partial class reservation_manage : Form
    {
        public string res_id = "";
        public string res_time = "";
        public string cancel_reason = "";
        public bool isApproved = true;
        public string selected_date = "";
        public int returnCode = -1;
        public int currentRoomID = -1;
        public bool isSpaProgramChanged = false;
        public reservation theOwner = null;
        public int therapist_id = -1;

        string billID = "";
        bool isSpaCardIssued = false;
        bool preventClose = false;
        //bool firstLoad = true;
        int loadedStatus = 1;
        String res_status = "";

        int time_range = 0;
        
        public reservation_manage()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };

            code.Text = "NONE";
            end_time.Text = "";

            agent_id.parentForm = this;
            customer_name.parentForm = this;

            for(int hrs=0; hrs<=23; hrs++) appointment_hours.Items.Add(new ComboItem(hrs, hrs.ToString("00")));
            appointment_hours.SelectedIndex = 0;
            for (int mins = 0; mins <= 59; mins++) appointment_minutes.Items.Add(new ComboItem(mins, mins.ToString("00")));
            appointment_minutes.SelectedIndex = 0;

            start_hours.Items.Add(new ComboItem(-1, "HOURS"));
            for (int hrs = 0; hrs <= 23; hrs++) start_hours.Items.Add(new ComboItem(hrs, hrs.ToString("00")));
            start_hours.SelectedIndex = 0;
            GF.resizeComboBox(start_hours);

            start_minutes.Items.Add(new ComboItem(-1, "MINUTES"));
            for (int mins = 0; mins <= 59; mins++) start_minutes.Items.Add(new ComboItem(mins, mins.ToString("00")));
            start_minutes.SelectedIndex = 0;
            GF.resizeComboBox(start_minutes);

            room_id.SelectedIndexChanged += (ss, ee) => {
                currentRoomID = ((ComboItem)room_id.SelectedItem).Key;
            };

            agent_id.Mode = "AGENT";
            customer_name.Mode = "CUSTOMER";

            reservation_detail.RowsAdded += (ss, ee) =>
            {
                isSpaProgramChanged = true;
            };
            reservation_detail.RowsRemoved += (ss, ee) =>
            {
                isSpaProgramChanged = true;
            };
        }

        private void reservation_manage_Load(object sender, EventArgs e)
        {
            GF.showLoading(this);
            String queryString = "";

            if (selected_date.Trim() == String.Empty) selected_date = ((reservation)this.Owner).reservation_date.Text.Trim();
            date.Text = selected_date;
            String[] tmpResTime = res_time.Split('.');
            if (tmpResTime.Length > 1)
            {
                appointment_hours.Text = tmpResTime[0];
                appointment_minutes.Text = tmpResTime[1];
            }
            
            if (res_id.Trim() == String.Empty)
            {
                reserve.Enabled = true;
                start.Enabled = true;
                finish.Enabled = false;
                cancel.Enabled = false;
            }
            else
            {
                manage_btn.Text = "UPDATE";
                queryString = @"
                SELECT 
                    A.RESERVATION_ID,
                    A.STATUS,
                    A.CODE,
                    A.CUSTOMER_ID,
                    E.NOTE,
                    CONVERT(NVARCHAR(MAX), CONVERT(DATE, A.RES_DATE), 103) RES_DATE,
                    CONVERT(NVARCHAR(MAX), CONVERT(DATE, A.APPOINTMENT_START), 103) APPOINTMENT_START_DATE,
                    CONVERT(NVARCHAR(MAX), CONVERT(TIME, A.APPOINTMENT_START), 108) APPOINTMENT_START_TIME,
                    CONVERT(NVARCHAR(MAX), CONVERT(DATE, A.APPOINTMENT_END), 103) APPOINTMENT_END_DATE,
                    CONVERT(NVARCHAR(MAX), CONVERT(TIME, A.APPOINTMENT_END), 108) APPOINTMENT_END_TIME,
                    CONVERT(NVARCHAR(MAX), CONVERT(DATE, A.START_TIME), 103) START_DATE,
                    CONVERT(NVARCHAR(MAX), CONVERT(TIME, A.START_TIME), 108) START_TIME,
                    CONVERT(NVARCHAR(MAX), CONVERT(DATE, A.END_TIME), 103) END_DATE,
                    CONVERT(NVARCHAR(MAX), CONVERT(TIME, A.END_TIME), 108) END_TIME,
                    A.SPA_CARD_ISSUE,
                    A.KEYCARD_ISSUE,
                    A.KEYCARD_RETURN,
                    A.ROOM_ID,
                    A.IS_ROOM_REQUESTED,
                    A.PREFER,
                    A.BILL_ID,
                    CASE WHEN A.RESERVE_BY = 0 THEN 'S.A.' ELSE B.FULLNAME END RESERVE_NAME,
                    CONVERT(NVARCHAR(MAX), A.RESERVE_SYS_TIME, 103) + ' ' + CONVERT(NVARCHAR(MAX), A.RESERVE_SYS_TIME, 108) RESERVE_SYS_TIME,
                    CASE WHEN A.START_BY = 0 THEN 'S.A.' ELSE C.FULLNAME END START_NAME,
                    CONVERT(NVARCHAR(MAX), A.START_SYS_TIME, 103) + ' ' + CONVERT(NVARCHAR(MAX), A.START_SYS_TIME, 108) START_SYS_TIME,
                    CASE WHEN A.FINISH_BY = 0 THEN 'S.A.' ELSE D.FULLNAME END FINISH_NAME,
                    CONVERT(NVARCHAR(MAX), A.FINISH_SYS_TIME, 103) + ' ' + CONVERT(NVARCHAR(MAX), A.FINISH_SYS_TIME, 108) FINISH_SYS_TIME,
                    CONVERT(NVARCHAR(MAX), A.SPA_CARD_ISSUE, 103) + ' ' + CONVERT(NVARCHAR(MAX), A.SPA_CARD_ISSUE, 108) SPA_CARD_SYS_TIME,
                    CONVERT(NVARCHAR(MAX), A.KEYCARD_ISSUE, 103) + ' ' + CONVERT(NVARCHAR(MAX), A.KEYCARD_ISSUE, 108) ISSUE_KEYCARD_SYS_TIME,
                    CONVERT(NVARCHAR(MAX), A.KEYCARD_RETURN, 103) + ' ' + CONVERT(NVARCHAR(MAX), A.KEYCARD_RETURN, 108) RETURN_KEYCARD_SYS_TIME,
                    A.IS_BARTER,
                    A.BARTER_DETAIL
                FROM RESERVATION A
                LEFT OUTER JOIN EMPLOYEE B ON A.RESERVE_BY = B.EMP_ID
                LEFT OUTER JOIN EMPLOYEE C ON A.START_BY = C.EMP_ID
                LEFT OUTER JOIN EMPLOYEE D ON A.FINISH_BY = D.EMP_ID
                LEFT OUTER JOIN CUSTOMER E ON A.CUSTOMER_ID = E.CUSTOMER_ID
                WHERE A.RESERVATION_ID = " + res_id.Trim();
                using (DataTable DT = DB.getS(queryString, null, "GET RESERVATION[" + res_id.Trim() + "]", false))
                {
                    if (DT.Rows.Count == 1)
                    {
                        billID = DT.Rows[0]["BILL_ID"].ToString();
                        code.Text = DT.Rows[0]["CODE"].ToString();

                        customer_name.SetID(Convert.ToInt32(DT.Rows[0]["CUSTOMER_ID"].ToString()));
                        //customer_name.SetText(Convert.ToInt32(row["CUSTOMER_ID"].ToString()), row["CUSTOMER_NAME"].ToString() + " - " + (row["GENDER"].ToString() == "1" ? "MALE" : "FEMALE") + " - " + row["TEL"].ToString());

                        note.Text = DT.Rows[0]["NOTE"].ToString();

                        isBarter.Checked = (DT.Rows[0]["IS_BARTER"].ToString() == "1");
                        barter_detail.Text = DT.Rows[0]["BARTER_DETAIL"].ToString();

                        if (DT.Rows[0]["RES_DATE"].ToString() != String.Empty) date.Text = DT.Rows[0]["RES_DATE"].ToString();
                        if (DT.Rows[0]["APPOINTMENT_START_DATE"].ToString() != String.Empty) date.Text = DT.Rows[0]["APPOINTMENT_START_DATE"].ToString();
                        if (DT.Rows[0]["START_DATE"].ToString() != String.Empty) date.Text = DT.Rows[0]["START_DATE"].ToString();
                        
                        currentRoomID = Convert.ToInt32(DT.Rows[0]["ROOM_ID"].ToString());

                        if (DT.Rows[0]["IS_ROOM_REQUESTED"].ToString() == "1") request.Checked = true;
                        else request.Checked = false;

                        String[] tmpAppTime = DT.Rows[0]["APPOINTMENT_START_TIME"].ToString().Split(':');

                        if (tmpAppTime.Length == 2)
                        {
                            appointment_hours.Text = tmpAppTime[0];
                            appointment_minutes.Text = tmpAppTime[1];
                        }
                        loadedStatus = Convert.ToInt32(DT.Rows[0]["STATUS"].ToString());

                        manage_btn.BackColor = Color.FromArgb(194, 169, 239);

                        res_status = DT.Rows[0]["STATUS"].ToString();
                        switch (res_status)
                        {
                            case "0": // CANCEL
                                add_customer_btn.Visible = false;

                                payment_btn.Visible = false;
                                manage_btn.Visible = false;
                                cancel_btn.Visible = false;
                                keycard_btn.Visible = false;
                                spa_card_btn.Visible = false;

                                cancel.Checked = true;

                                customer_name.Enabled = false;

                                appointment_hours.Enabled = false;
                                appointment_minutes.Enabled = false;

                                if (DT.Rows[0]["START_TIME"].ToString() == "")
                                {
                                    start_hours.SelectedIndex = 0;
                                    start_minutes.SelectedIndex = 0;
                                }
                                else
                                {
                                    String[] tmp = DT.Rows[0]["START_TIME"].ToString().Split(':');
                                    start_hours.Text = tmp[0];
                                    start_minutes.Text = tmp[1];
                                }

                                start_group.Visible = false;
                                break;
                            case "1": // RESERVE
                                payment_btn.Visible = false;

                                add_customer_btn.Visible = true;
                                start.Enabled = true;
                                reserve.Enabled = true;
                                finish.Enabled = false;
                                cancel.Enabled = true;

                                keycard_btn.Visible = false;
                                spa_card_btn.Visible = false;

                                reserve.Checked = true;

                                customer_name.Enabled = true;
                                appointment_hours.Enabled = true;
                                appointment_minutes.Enabled = true;

                                start_hours.SelectedIndex = 0;
                                start_minutes.SelectedIndex = 0;

                                start_group.Visible = false;
                                break;
                            case "2": // START
                                payment_btn.Visible = false;

                                reserve.Enabled = false;
                                start.Enabled = true;
                                finish.Enabled = true;
                                if(!GF.can_approve) cancel.Enabled = false;

                                keycard_btn.Visible = true;
                                spa_card_btn.Visible = true;
                                if (DT.Rows[0]["SPA_CARD_ISSUE"].ToString() != "")
                                {
                                    isSpaCardIssued = true;
                                    spa_card_btn.BackColor = Color.LightCoral;
                                }
                                else
                                {
                                    isSpaCardIssued = false;
                                    spa_card_btn.BackColor = Color.YellowGreen;
                                }

                                if (DT.Rows[0]["KEYCARD_ISSUE"].ToString() != "")
                                {
                                    keycard_btn.BackColor = Color.LightCoral;
                                }
                                else
                                {
                                    keycard_btn.BackColor = Color.YellowGreen;
                                }
                                keycard_btn.Text = "ISSUE KEYCARD";

                                start.Checked = true;

                                if (!GF.can_approve)
                                {
                                    add_customer_btn.Visible = false;
                                    customer_name.Enabled = false;
                                    appointment_hours.Enabled = false;
                                    appointment_minutes.Enabled = false;
                                }

                                if (DT.Rows[0]["START_TIME"].ToString() == "")
                                {
                                    start_hours.SelectedIndex = 0;
                                    start_minutes.SelectedIndex = 0;
                                }
                                else
                                {
                                    String[] tmp = DT.Rows[0]["START_TIME"].ToString().Split(':');
                                    start_hours.Text = tmp[0];
                                    start_minutes.Text = tmp[1];
                                }

                                if (DT.Rows[0]["END_TIME"].ToString() != "") end_time.Text = DT.Rows[0]["END_TIME"].ToString();
                                if (DT.Rows[0]["START_DATE"].ToString().Trim() != DT.Rows[0]["END_DATE"].ToString().Trim()) end_time.Text += " (+1)";

                                start_group.Visible = true;
                                break;
                            case "3": // FINISH
                                payment_btn.Visible = true;
                                billID = DT.Rows[0]["BILL_ID"].ToString().Trim();
                                keycard_btn.Text = "RETURN KEYCARD";
                                if (DT.Rows[0]["KEYCARD_RETURN"].ToString() == "") keycard_btn.Visible = true;
                                else keycard_btn.Visible = false;
                                if(!GF.can_approve) spa_card_btn.Visible = false;
                                else spa_card_btn.Visible = true;
                                finish.Checked = true;

                                GF.closeLoading();

                                start_hours.Text = DT.Rows[0]["START_TIME"].ToString().Split(':')[0];
                                start_minutes.Text = DT.Rows[0]["START_TIME"].ToString().Split(':')[1];
                                end_time.Text = DT.Rows[0]["END_TIME"].ToString();
                                if (DT.Rows[0]["START_DATE"].ToString().Trim() != DT.Rows[0]["END_DATE"].ToString().Trim()) end_time.Text += " (+1)";

                                start_group.Visible = true;

                                if (GF.can_approve)
                                {
                                    GF.enableButton(add_program_btn);
                                    GF.enableButton(manage_btn);
                                    reservation_detail.Enabled = true;
                                }
                                else
                                {
                                    GF.disableButton(add_program_btn);
                                    GF.disableButton(manage_btn);
                                    reservation_detail.Enabled = false;

                                    add_customer_btn.Visible = false;
                                    note.Enabled = false;
                                    if (!GF.can_approve) reserve.Enabled = false;
                                    else reserve.Enabled = true;

                                    if (!GF.can_approve) start.Enabled = false;
                                    else start.Enabled = true;
                                    
                                    finish.Enabled = true;
                                    cancel.Enabled = false;
                                    isBarter.Enabled = false;
                                    barter_detail.Enabled = false;
                                    room_id.Enabled = false;

                                    customer_name.Enabled = false;
                                    appointment_hours.Enabled = false;
                                    appointment_minutes.Enabled = false;

                                    start_group.Enabled = false;
                                }
                                break;
                        }

                        if (billID != "") manage_btn.BackColor = Color.Red;

                        string hrs = "";
                        string mins = "";
                        if (DT.Rows[0]["APPOINTMENT_START_TIME"].ToString().Trim() != "")
                        {
                            string[] tmpTime = DT.Rows[0]["APPOINTMENT_START_TIME"].ToString().Split(':');
                            hrs = tmpTime[0];
                            mins = tmpTime[1];
                        }
                        appointment_hours.Text = hrs;
                        appointment_minutes.Text = mins;

                        switch (DT.Rows[0]["PREFER"].ToString())
                        {
                            case "0":
                                low.Checked = true;
                                break;
                            case "1":
                                medium.Checked = true;
                                break;
                            case "2":
                                strong.Checked = true;
                                break;
                        }

                        initHistory();

                        history.Rows[0].Cells["by"].Value = DT.Rows[0]["RESERVE_NAME"].ToString();
                        history.Rows[0].Cells["time"].Value = DT.Rows[0]["RESERVE_SYS_TIME"].ToString();

                        history.Rows[1].Cells["by"].Value = DT.Rows[0]["START_NAME"].ToString();
                        history.Rows[1].Cells["time"].Value = DT.Rows[0]["START_SYS_TIME"].ToString();

                        history.Rows[2].Cells["time"].Value = DT.Rows[0]["SPA_CARD_SYS_TIME"].ToString();
                        history.Rows[3].Cells["time"].Value = DT.Rows[0]["ISSUE_KEYCARD_SYS_TIME"].ToString();
                        history.Rows[4].Cells["time"].Value = DT.Rows[0]["RETURN_KEYCARD_SYS_TIME"].ToString();

                        history.Rows[5].Cells["by"].Value = DT.Rows[0]["FINISH_NAME"].ToString();
                        history.Rows[5].Cells["time"].Value = DT.Rows[0]["FINISH_SYS_TIME"].ToString();

                        history.ClearSelection();
                    }
                }
            }
            getRoom();
            loadDGV();
            //firstLoad = false;

            disableForm();

            GF.closeLoading();
        }

        void initDGV()
        {
            if (reservation_detail.Columns.Count == 0)
            {
                reservation_detail.Columns.Add("program_name", "SPA PROGRAM");
                reservation_detail.Columns.Add("therapist_list", "THERAPIST(S)");
                reservation_detail.Columns.Add("program_id", "program_id");
                reservation_detail.Columns.Add("price", "PRICE");
                reservation_detail.Columns.Add("hours", "hours");
                reservation_detail.Columns.Add("minutes", "minutes");
                reservation_detail.Columns.Add("oil", "oil");
                reservation_detail.Columns.Add("scrub", "scrub");
                reservation_detail.Columns.Add("therapist_id", "therapist_id");
                reservation_detail.Columns.Add("is_requested", "is_requested");
                reservation_detail.Columns.Add("apply_discount", "apply_discount");
                reservation_detail.Columns.Add("reservation_detail_id", "reservation_detail_id");

                reservation_detail.Columns["program_id"].Visible = false;
                reservation_detail.Columns["hours"].Visible = false;
                reservation_detail.Columns["minutes"].Visible = false;
                reservation_detail.Columns["oil"].Visible = false;
                reservation_detail.Columns["scrub"].Visible = false;
                reservation_detail.Columns["therapist_id"].Visible = false;
                reservation_detail.Columns["is_requested"].Visible = false;
                reservation_detail.Columns["apply_discount"].Visible = false;
                reservation_detail.Columns["reservation_detail_id"].Visible = false;

                reservation_detail.Columns["program_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                reservation_detail.Columns["therapist_list"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                reservation_detail.Columns["price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                reservation_detail.RowHeadersVisible = false;
            }
        }

        void initHistory()
        {
            history.Rows.Clear();

            if (history.Columns.Count == 0)
            {
                history.Columns.Add("action", "");
                history.Columns.Add("by", "BY");
                history.Columns.Add("time", "TIME");
            }

            history.Rows.Add("RESERVE", "", "");
            history.Rows.Add("START", "", "");
            history.Rows.Add("PRINT SPA CARD", "", "");
            history.Rows.Add("ISSUE KEYCARD", "", "");
            history.Rows.Add("RETURN KEYCARD", "", "");
            history.Rows.Add("FINISH", "", "");
        }

        void addReserveRow()
        {
            reservation_detail.Rows.Add(
                "RESERVE",
                "",
                "-1",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "1",
                (new Random().Next(1, 1000000) * -1).ToString()
            );
            reservation_detail.ClearSelection();
        }

        public void loadDGV()
        {
            reservation_detail.Rows.Clear();
            initDGV();
            if (res_id == "" && reserve.Checked)
            {
                addReserveRow();
            }
            else
            {
                String queryString = @"
                SELECT 
                    A.*,
                    B.*
                FROM RESERVATION_DETAIL A 
                LEFT OUTER JOIN SPA_PROGRAM B ON A.SPA_PROGRAM_ID = B.SPA_PROGRAM_ID 
                WHERE A.RESERVATION_ID = " + res_id + " ORDER BY A.RESERVATION_DETAIL_ID";
                using (DataTable DT = DB.getS(queryString, null, "GET RESERVATION_DETAIL AND RESERVATION_THERAPIST FROM RES_ID[" + res_id + "]", false))
                {
                    String therapist_id = "";
                    String program_id = "";
                    String price = "";
                    String hours = "";
                    String minutes = "";
                    String oil_id = "";
                    String scrub_id = "";
                    String is_request = "";
                    
                    if (DT.Rows.Count > 0)
                    {
                        int rowCount = 1;
                        foreach (DataRow row in DT.Rows)
                        {
                            if (row["SPA_PROGRAM_ID"].ToString() != "-1") rowCount++;
                        }
                        
                        if (rowCount == 1) // SHOW ONLY RESERVE
                        {
                            string res_detail_id = DT.Rows[0]["RESERVATION_DETAIL_ID"].ToString();

                            if (DT.Rows[0]["SPA_PROGRAM_ID"].ToString() == "-1")
                            {
                                queryString = @"
                                SELECT
                                    A.*,
                                    B.FULLNAME
                                FROM RESERVATION_THERAPIST A
                                INNER JOIN EMPLOYEE B ON A.THERAPIST_ID = B.EMP_ID
                                WHERE A.RESERVATION_DETAIL_ID = " + res_detail_id + " ORDER BY A.RESERVATION_THERAPIST_ID";

                                String therapistName = "";
                                using (DataTable localDT = DB.getS(queryString, null, "GET APPOINTED THERAPIST FROM RESV_DETAIL_ID[" + res_detail_id + "]", false))
                                {
                                    if (localDT.Rows.Count == 1)
                                    {
                                        program_id = "-1";
                                        therapist_id += localDT.Rows[0]["THERAPIST_ID"].ToString() + ", ";

                                        if (localDT.Rows.Count == 1) therapistName = GF.getNickname(DT.Rows[0]["FULLNAME"].ToString()) + (DT.Rows[0]["IS_REQUESTED"].ToString() == "1" ? "[REQUEST]" : "");

                                        if (therapist_id.IndexOf(",") != -1) therapist_id = therapist_id.Substring(therapist_id.Length - 2);
                                        if (is_request.IndexOf(",") != -1) is_request = is_request.Substring(is_request.Length - 2);
                                    }
                                }
                                reservation_detail.Rows.Add(
                                    "RESERVE",
                                    therapistName,
                                    program_id,
                                    price,
                                    hours,
                                    minutes,
                                    oil_id,
                                    scrub_id,
                                    therapist_id,
                                    is_request,
                                    "0",
                                    res_detail_id
                                );
                            }
                        }
                        else // SHOW SPA PROGRAM
                        {
                            foreach (DataRow row in DT.Rows)
                            {
                                if (row["SPA_PROGRAM_ID"].ToString() != "-1")
                                {
                                    therapist_id = "";
                                    string res_detail_id = row["RESERVATION_DETAIL_ID"].ToString();
                                    string spa_program_code = row["CODE"].ToString();
                                    string spa_program_name = row["PROGRAM_NAME"].ToString();
                                    string therapist_name = "";
                                    string oil = "";
                                    string scrub = "";
                                    String apply_discount = "";

                                    is_request = "";
                                    program_id = row["SPA_PROGRAM_ID"].ToString();
                                    if ((row["PRICE"] ?? "").ToString() != String.Empty)
                                        price = GF.formatNumber(Convert.ToInt32(row["PRICE"].ToString()));
                                    hours = row["HOURS"].ToString();
                                    minutes = row["MINUTES"].ToString();
                                    oil_id = row["OIL"].ToString();
                                    scrub_id = row["SCRUB"].ToString();
                                    apply_discount = (row["APPLY_DISCOUNT"].ToString() == "" ? "0" : row["APPLY_DISCOUNT"].ToString());

                                    switch (row["OIL"].ToString())
                                    {
                                        case "-1": oil = "*** UNKNOWN ***"; break;
                                        case "0": oil = "WATER"; break;
                                        case "1": oil = "EARTH"; break;
                                        case "2": oil = "WOOD"; break;
                                        case "3": oil = "FIRE"; break;
                                        case "4": oil = "METAL"; break;
                                        case "5": oil = "COCONUT"; break;
                                    }

                                    switch (row["SCRUB"].ToString())
                                    {
                                        case "-1": scrub = "*** UNKNOWN ***"; break;
                                        case "0": scrub = "WATER"; break;
                                        case "1": scrub = "EARTH"; break;
                                        case "2": scrub = "WOOD"; break;
                                        case "3": scrub = "FIRE"; break;
                                        case "4": scrub = "METAL"; break;
                                        case "5": scrub = "CHOCOLATE"; break;
                                        case "6": scrub = "COFFEE"; break;
                                        case "7": scrub = "THAI HERB"; break;
                                    }

                                    queryString = "SELECT B.NICKNAME, A.* FROM RESERVATION_THERAPIST A LEFT OUTER JOIN EMPLOYEE B ON A.THERAPIST_ID = B.EMP_ID WHERE A.RESERVATION_DETAIL_ID = " + res_detail_id;

                                    using (DataTable tmpDT = DB.getS(queryString, null, "GET THERAPIST NAME FROM RES_DETAIL[" + res_detail_id + "]", false))
                                    {
                                        if (tmpDT.Rows.Count > 0)
                                        {
                                            foreach (DataRow tpRow in tmpDT.Rows)
                                            {
                                                is_request += tpRow["IS_REQUESTED"].ToString() + ", ";
                                                therapist_id += tpRow["THERAPIST_ID"].ToString() + ", ";
                                                //therapist_name += (tpRow["FULLNAME"].ToString() == "" ? "UNKNOWN" : GF.getNickname(tpRow["FULLNAME"].ToString()) + (tpRow["IS_REQUESTED"].ToString() == "1" ? "[REQUEST]" : "")) + ", ";
                                                therapist_name += (tpRow["NICKNAME"].ToString() == "" ? "UNKNOWN" : tpRow["NICKNAME"].ToString() + (tpRow["IS_REQUESTED"].ToString() == "1" ? "[REQUEST]" : "")) + ", ";
                                            }
                                            if (therapist_name.Trim() != "") therapist_name = therapist_name.Trim().Substring(0, therapist_name.Trim().Length - 1);

                                            if (therapist_id.IndexOf(",") != -1) therapist_id = therapist_id.Substring(0, therapist_id.Length - 2);
                                            if (is_request.IndexOf(",") != -1) is_request = is_request.Substring(0, is_request.Length - 2);
                                        }
                                    }

                                    reservation_detail.Rows.Add(
                                        "[#" + spa_program_code + "] " + spa_program_name + ((oil.Trim() != "") ? " [OIL:" + oil + "]" : "") + ((scrub.Trim() != "") ? " [SCRUB:" + scrub + "]" : ""),
                                        (therapist_name == String.Empty ? "UNKNOWN" : therapist_name),
                                        program_id,
                                        price,
                                        hours,
                                        minutes,
                                        oil_id,
                                        scrub_id,
                                        (therapist_id == String.Empty ? "-1" : therapist_id),
                                        is_request,
                                        apply_discount,
                                        res_detail_id
                                    );
                                }
                            }
                        }

                        reservation_detail.ClearSelection();
                    }
                }
            }
            recalculateTime();
        }

        private void reserve_CheckedChanged(object sender, EventArgs e)
        {
            if (reserve.Checked)
            {
                GF.showLoading(this);
                recalculateTime();
                appointment_hours.Enabled = true;
                appointment_minutes.Enabled = true;

                start_group.Visible = false;

                start_hours.SelectedIndex = 0;
                start_minutes.SelectedIndex = 0;

                room_id.SelectedIndex = 0;
                low.Checked = true;

                if (res_id == "") manage_btn.Text = "RESERVE";
                this.Activate();
                this.BringToFront();
                GF.closeLoading();
            }
        }

        private void start_CheckedChanged(object sender, EventArgs e)
        {
            if (start.Checked)
            {
                GF.showLoading(this);
                recalculateTime();
                appointment_hours.Enabled = false;
                appointment_minutes.Enabled = false;
                String[] tmpTime = GF.NOW().Split(' ')[1].Split(':');

                start_hours.Text = tmpTime[0];
                start_minutes.Text = tmpTime[1];

                start_group.Visible = true;

                if(res_id == "") manage_btn.Text = "START";
                this.Activate();
                this.BringToFront();
                GF.closeLoading();
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            if (cancel.Checked)
            {
                cancel_reason = "";
                using (reservation_cancel_reason cancelPage = new reservation_cancel_reason())
                {
                    cancelPage.Owner = this;
                    cancelPage.ShowDialog();
                    cancelPage.Activate();
                    cancelPage.BringToFront();
                }
            }
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if (manage_btn.BackColor == Color.Red)
            {
                MessageBox.Show("THIS RESERVATION HAD AN INVOICE !!\r\n\r\nTO CHANGE THE DETAIL.\r\nYOU MUST VOID THE INVOICE FIRST !!", "ERROR");
                return;
            }
            String queryString = "";
            if (((ComboItem)room_id.SelectedItem).Key == -1)
            {
                MessageBox.Show("PLEASE CHOOSE THE ROOM !!", "ERROR");
                return;
            }

            if (cancel.Checked && cancel_reason.Trim() == "")
            {
                MessageBox.Show("REQUIRE THE REASON OF CANCELLATION !!", "ERROR");
                return;
            }
            
            if (reservation_detail.Rows.Count == 0 && !cancel.Checked)
            {
                MessageBox.Show("REQUIRE AT LEAST 1 SPA PROGRAM !!", "ERROR");
                return;
            }

            if (manage_btn.Text.Trim() == "UPDATE" && start.Checked)
            {
                bool foundReserve = false;
                foreach (DataGridViewRow tmpRow in reservation_detail.Rows)
                {
                    if (tmpRow.Cells["PROGRAM_NAME"].Value.ToString().IndexOf("RESERVE") != -1)
                    {
                        foundReserve = true;
                        break;
                    }
                }
                if (foundReserve)
                {
                    MessageBox.Show("YOU HAVE NOT CHOOSE THE SPA PROGRAM YET !!", "ERROR");
                    return;
                }
            }

            if (start_group.Visible)
            {
                if (start_hours.SelectedIndex == 0)
                {
                    MessageBox.Show("PLEASE CHOOSE THE START HOUR OF MASSAGE COURSE !!", "ERROR");
                    return;
                }

                if (start_minutes.SelectedIndex == 0)
                {
                    MessageBox.Show("PLEASE CHOOSE THE START MINUTE OF MASSAGE COURSE !!", "ERROR");
                    return;
                }
            }

            string resv_code = code.Text.Trim();
            if (start.Checked)
            {
                bool found = false;
                foreach (DataGridViewRow row in reservation_detail.Rows)
                {
                    if (row.Cells["program_name"].Value.ToString().Trim().IndexOf("UNKNOWN") != -1)
                    {
                        found = true;
                        break;
                    }
                    if (row.Cells["therapist_list"].Value.ToString().Trim().IndexOf("UNKNOWN") != -1)
                    {
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    MessageBox.Show("PLEASE RE-CHECK THE SPA PROGRAM DETAIL !! THERE IS SOMETHING 'UNKNOWN' !!", "ERROR");
                    return;
                }

                if (resv_code == "NONE")
                {
                    string[] tmp = selected_date.Split('/');
                    string selected_year = tmp[2];
                    string selected_month = tmp[1];
                    string selected_day = tmp[0];
                    queryString = "SELECT MAX(CODE) CODE FROM RESERVATION WHERE STATUS > 1";
                    queryString += " AND LEFT(CODE, 8) LIKE '" + (Convert.ToInt32(selected_year) + 543).ToString() + selected_month + selected_day + "'";

                    using (DataTable DT = DB.getS(queryString, null, "GET LATEST CODE FROM RESERVATION", false))
                    {
                        if (DT.Rows[0]["CODE"].ToString() == "" || DT.Rows[0]["CODE"].ToString() == "NULL") code.Text = (Convert.ToInt32(selected_year) + 543).ToString() + selected_month + selected_day + "0001";
                        else
                        {
                            resv_code = DT.Rows[0]["CODE"].ToString();
                            string year = resv_code.Substring(0, 4);
                            string month = resv_code.Substring(4, 2);
                            string day = resv_code.Substring(6, 2);
                            string current_no = resv_code.Substring(8);

                            if (year == (Convert.ToInt32(selected_year) + 543).ToString() && month == selected_month && day == selected_day)
                            {
                                current_no = (Int32.Parse(current_no) + 1).ToString("0000");
                                code.Text = year + month + day + current_no;
                            }
                            else
                            {
                                code.Text = (Convert.ToInt32(selected_year) + 543).ToString() + selected_month + selected_day + "0001";
                            }
                        }
                    }
                }
            }

            if (finish.Checked)
            {
                queryString = "SELECT SPA_CARD_ISSUE FROM RESERVATION WHERE RESERVATION_ID = " + res_id.Trim();

                using (DataTable DT = DB.getS(queryString, null, "CHECK IF ISSUED SPA CARD OR NOT", false))
                {
                    if (DT.Rows[0]["SPA_CARD_ISSUE"].ToString() == "NULL" || DT.Rows[0]["SPA_CARD_ISSUE"].ToString() == "")
                    {
                        MessageBox.Show("YOU DID NOT ISSUE SPA CARD !!", "ERROR");
                        return;
                    }
                }
            }

            //if (!GF.can_approve && !(res_status == "" || res_status == "0" || res_status == "1"))
            //{
            //    using (reservation_approve approvePage = new reservation_approve())
            //    {
            //        approvePage.Owner = this;
            //        approvePage.ShowDialog();
            //    }
            //}

            //if (!isApproved && !GF.can_approve)
            //{
            //    MessageBox.Show("YOU MUST BE APPROVED BY MANAGER / SUPERVISOR\r\nTO MODIFY THIS BOOKING !!", "ERROR");
            //    return;
            //}

            GF.showLoading(this);
            
            DB.beginTrans();
            if (customer_name.currentID == -1)
            {
                MessageBox.Show("YOU DID NOT CHOOSE CUSTOMER !!", "ERROR");
                GF.closeLoading();
                return;
            }
            else
            {
                queryString = "UPDATE CUSTOMER SET NOTE = '" + note.Text.Trim() + "' WHERE CUSTOMER_ID = " + customer_name.currentID.ToString();
                if (!DB.set(queryString, "UPDATE NOTE TO CUSTOMER[" + customer_name.currentID.ToString() + "]"))
                {
                    MessageBox.Show("ERROR UPDATE NOTE TO CUSTOMER !!", "ERROR");
                    GF.closeLoading();
                    return;
                }
            }

            if (res_id == "") res_id = DB.insertReturnID("INSERT INTO RESERVATION DEFAULT VALUES", "INSERT EMPTY RESERVATION RETURN RESERVATION_ID").ToString();
            
            if (res_id == "")
            {
                MessageBox.Show("ERROR INSERT EMPTY RESERVATION !!", "ERROR");
                DB.rollbackTrans();
                DB.close();
                GF.closeLoading();
                return;
            }

            using (DataTable myDT = DB.getS("SELECT time_range FROM APP_CONFIG", null, "GET CONFIG", false))
            {
                time_range = Convert.ToInt16(myDT.Rows[0]["time_range"].ToString());

                /*
                * 0=00:01-00:00; 
                * 1=01:01-01:00; 
                * 2=02:01-02:00; 
                * 3=03:01-03:00; 
                * 4=04:01-04:00; 
                * 5=05:01-05:00; 
                * 6=06:01-06:00; 
                * 7=07:01-07:00; 
                * 8=08:01-08:00; 
                * 9=09:01-09:00; 
                * 10=10:01-10:00; 
                * 11=11:01-11:00; 
                * 12=12:01-12:00; 
                * 13=13:01-13:00; 
                * 14=14:01-14:00; 
                * 15=15:01-15:00; 
                * 16=16:01-16:00; 
                * 17=17:01-17:00; 
                * 18=18:01-18:00; 
                * 19=19:01-19:00; 
                * 20=20:01-20:00; 
                * 21=21:01-21:00; 
                * 22=22:01-22:00; 
                * 23=23:01-23:00;
                * */
            }

            DateTime the_date = date.Value;
            
            // ================================= MAIN RESERVATION DATA ==================================
            queryString = "UPDATE RESERVATION SET AGENT_ID = " + (agent_id.currentID == -1 ? "NULL" : agent_id.currentID.ToString()) + ", RES_DATE = " + GF.modDate(date.Text.Trim()) + ", STATUS = ";
            if (reserve.Checked) queryString += "1, RESERVE_BY = " + GF.emp_id.ToString() + ", RESERVE_SYS_TIME = CURRENT_TIMESTAMP, START_BY = NULL, START_SYS_TIME = NULL, FINISH_BY = NULL, FINISH_SYS_TIME = NULL, CODE = 'NONE', SPA_CARD_ISSUE = NULL, KEYCARD_ISSUE = NULL, PREFER=NULL, START_TIME=NULL, END_TIME=NULL, ";
            else if (cancel.Checked) queryString += "0, CANCEL_BY = " + GF.emp_id.ToString() + ", CANCEL_SYS_TIME = CURRENT_TIMESTAMP, STATUS_BEFORE_CANCEL = " + loadedStatus.ToString() + ", CANCEL_DETAIL = '" + cancel_reason.Trim() + "', CODE = '" + code.Text.Trim() + "', ";
            else if (start.Checked) queryString += "2, START_BY = " + GF.emp_id.ToString() + ", START_SYS_TIME = CURRENT_TIMESTAMP, FINISH_BY = NULL, FINISH_SYS_TIME = NULL, CODE = '" + code.Text.Trim() + "', ";
            else if (finish.Checked) queryString += "3, FINISH_BY = " + GF.emp_id.ToString() + ", FINISH_SYS_TIME = CURRENT_TIMESTAMP, CODE = '" + code.Text.Trim() + "', ";

            queryString += "ROOM_ID = " + ((ComboItem)room_id.SelectedItem).Key.ToString() + ", ";
            queryString += "IS_ROOM_REQUESTED = " + (request.Checked ? "1" : "0") + ", ";

            queryString += "IS_BARTER = " + (this.isBarter.Checked ? "1" : "0") + ", ";
            queryString += "BARTER_DETAIL = " + (this.isBarter.Checked ? "'" + barter_detail.Text.Trim() + "'" : "NULL") + ", ";

            queryString += "CUSTOMER_ID = " + customer_name.currentID.ToString() + ", ";

            if (reserve.Checked)
            {
                int time = Convert.ToInt32(((ComboItem)appointment_hours.SelectedItem).Key.ToString("00"));
                if (time_range > 0 && time >= 0 && time < time_range) the_date = the_date.AddDays(1);

                string appointmentStart = GF.modDateTime(the_date.Year.ToString() + "-" + the_date.Month.ToString("00") + "-" + the_date.Day.ToString("00") + " " + ((ComboItem)appointment_hours.SelectedItem).Key.ToString("00") + ":" + ((ComboItem)appointment_minutes.SelectedItem).Key.ToString("00") + ":00");
                queryString += "APPOINTMENT_START = " + appointmentStart + ", ";

                int minutes_add = 0;
                if (reservation_detail.Rows.Count == 1 && reservation_detail.Rows[0].Cells["PROGRAM_NAME"].Value.ToString().IndexOf("RESERVE") != -1)
                {
                    minutes_add = GF.reservePeriod;
                }
                else
                {
                    if (reservation_detail.Rows[0].Cells["PROGRAM_NAME"].Value.ToString().IndexOf("RESERVE") == -1)
                    {
                        foreach (DataGridViewRow resRow in reservation_detail.Rows)
                        {
                            minutes_add += Convert.ToInt32(resRow.Cells["hours"].Value.ToString()) * 60;
                            minutes_add += Convert.ToInt32(resRow.Cells["minutes"].Value.ToString());
                        }
                    }
                }

                queryString += "APPOINTMENT_END = DATEADD(MINUTE, +" + minutes_add.ToString() + ", " + appointmentStart + "), ";
            }
            recalculateTime();
            if (start.Checked || finish.Checked)
            {
                int time = Convert.ToInt32(start_hours.Text.Trim());
                if (time_range > 0 && time >= 0 && time < time_range) the_date = the_date.AddDays(1);

                string startDateTime = the_date.Year.ToString() + "-" + the_date.Month.ToString("00") + "-" + the_date.Day.ToString("00") + " " + start_hours.Text.Trim() + ":" + start_minutes.Text.Trim() + ":00";
                queryString += "START_TIME = " + GF.modDateTime(the_date.Year.ToString() + "-" + the_date.Month.ToString("00") + "-" + the_date.Day.ToString("00") + " " + start_hours.Text.Trim() + ":" + start_minutes.Text.Trim() + ":00") + ", ";

                String end_time_txt = end_time.Text;
                bool crossDay = (end_time.Text.IndexOf("+1") == -1 ? false : true);
                end_time_txt = startDateTime.Split(' ')[0] + ' ' + end_time_txt.Replace(" (+1)", "");

                if (!crossDay)
                    queryString += "END_TIME = " + GF.modDateTime(end_time_txt) + ", ";
                else
                    queryString += "END_TIME = DATEADD(DAY, +1, " + GF.modDateTime(end_time_txt) + "), ";
                queryString += "PREFER = ";
                if (low.Checked) queryString += "0, ";
                if (medium.Checked) queryString += "1, ";
                if (strong.Checked) queryString += "2, ";
            }

            queryString = queryString.Substring(0, queryString.Length - 2) + " ";
            queryString += "WHERE RESERVATION_ID = " + res_id;

            if (!DB.set(queryString, "COMMIT " + manage_btn.Text.Trim() + "[" + res_id + "]"))
            {
                MessageBox.Show("ERROR TO " + manage_btn.Text.Trim() + " !!", "ERROR");
                GF.closeLoading();
                return;
            }

            //==================================== RESERVATION_THERAPIST ===================================
            //DELETE
            queryString = "DELETE FROM RESERVATION_THERAPIST WHERE RESERVATION_DETAIL_ID IN (SELECT RESERVATION_DETAIL_ID FROM RESERVATION_DETAIL WHERE RESERVATION_ID = " + res_id + ")";
            if (!DB.set(queryString, "DELETE UNUSED THERAPIST IN RESERVATION_ID[" + res_id + "]", false))
            {
                MessageBox.Show("ERROR DELETING RESERVATION_THERAPIST !!", "ERROR");
                GF.closeLoading();
                return;
            }

            String res_detail_list = "";
            // ======================================= RESERVATION DETAIL =======================================
            // DELETE
            foreach (DataGridViewRow row in reservation_detail.Rows)
            {
                if(Convert.ToInt64(row.Cells["reservation_detail_id"].Value.ToString()) > 0) res_detail_list += row.Cells["reservation_detail_id"].Value.ToString() + ", ";
            }
            if (res_detail_list.IndexOf(",") != -1) res_detail_list = res_detail_list.Substring(0, res_detail_list.Length - 2);

            if (res_detail_list != "")
            {
                queryString = "DELETE FROM RESERVATION_DETAIL WHERE RESERVATION_ID = " + res_id;
                if (!DB.set(queryString, "DELETE UNUSED RESERVATION_DETAIL IN RES_ID[" + res_id + "]", false))
                {
                    MessageBox.Show("ERROR DELETING RESERVATION_DETAIL !!", "ERROR");
                    GF.closeLoading();
                    return;
                }
            }

            //ADD
            foreach (DataGridViewRow row in reservation_detail.Rows)
            {
                queryString = "INSERT INTO RESERVATION_DETAIL (RESERVATION_ID, SPA_PROGRAM_ID, PRICE, OIL, SCRUB, HOURS, MINS) VALUES (";
                queryString += res_id + ", ";
                queryString += row.Cells["program_id"].Value.ToString() + ", ";
                queryString += (row.Cells["price"].Value.ToString() == "" ? "NULL" : GF.removeThousandAndDecimal(row.Cells["price"].Value.ToString())) + ", ";
                queryString += (row.Cells["oil"].Value.ToString() == "" ? "NULL" : row.Cells["oil"].Value.ToString()) + ", ";
                queryString += (row.Cells["scrub"].Value.ToString() == "" ? "NULL" : row.Cells["scrub"].Value.ToString()) + ", ";
                queryString += (row.Cells["hours"].Value.ToString() == "" ? "NULL" : row.Cells["hours"].Value.ToString()) + ", ";
                queryString += (row.Cells["minutes"].Value.ToString() == "" ? "NULL" : row.Cells["minutes"].Value.ToString()) + ")";
                int tmpResDetailID = -1;
                tmpResDetailID = DB.insertReturnID(queryString, "ADD NEW RESERVATION_DETAIL IN RES_ID[" + res_id + "]");
                if (tmpResDetailID == -1)
                {
                    MessageBox.Show("ERROR ADD NEW RESERVATION_DETAIL !!", "ERROR");
                    DB.rollbackTrans();
                    DB.close();
                    GF.closeLoading();
                    return;
                }
                row.Cells["reservation_detail_id"].Value = tmpResDetailID.ToString();

                //ADD
                String[] tmpStr = row.Cells["therapist_id"].Value.ToString().Split(',');
                String[] tmpRequest = row.Cells["is_requested"].Value.ToString().Split(',');
                int index = -1;
                foreach (String therapist_id in tmpStr)
                {
                    index++;
                    queryString = "INSERT INTO RESERVATION_THERAPIST (RESERVATION_DETAIL_ID, THERAPIST_ID, HOURS, MINS, IS_REQUESTED) VALUES (";
                    queryString += row.Cells["reservation_detail_id"].Value.ToString() + ", ";
                    queryString += (therapist_id == "" ? "-1" : therapist_id) + ", ";
                    queryString += (row.Cells["hours"].Value.ToString() == "" ? "NULL" : row.Cells["hours"].Value.ToString()) + ", ";
                    queryString += (row.Cells["minutes"].Value.ToString() == "" ? "NULL" : row.Cells["minutes"].Value.ToString()) + ", ";
                    queryString += (tmpRequest[index] == "" ? "NULL" : tmpRequest[index]) + ")";
                    if (!DB.set(queryString, "ADD NEW THERAPIST IN RESERVATION_DETAIL_ID[" + row.Cells["reservation_detail_id"].Value.ToString() + "]", false))
                    {
                        MessageBox.Show("ERROR INSERTING RESERVATION_THERAPIST !!", "ERROR");
                        GF.closeLoading();
                        return;
                    }
                }
            }

            // ======================================= COMMIT ===================================================
            DB.close();

            manage_btn.Text = "UPDATE";
            if (cancel.Checked) loadedStatus = 0;
            if (reserve.Checked) loadedStatus = 1;
            if (start.Checked)
            {
                loadedStatus = 2;
                spa_card_btn.Visible = true;
                spa_card_btn.BackColor = Color.YellowGreen;

                keycard_btn.Visible = true;
                keycard_btn.BackColor = Color.YellowGreen;
                preventClose = true;
                
                finish.Enabled = true;
            }
            if (finish.Checked)
            {
                loadedStatus = 3;
                preventClose = true;
                if(!GF.can_approve) spa_card_btn.Visible = false;
                keycard_btn.Visible = true;
                keycard_btn.Text = "RETURN KEYCARD";
                keycard_btn.BackColor = Color.YellowGreen;
                
                if (GF.can_approve)
                {
                    GF.enableButton(add_program_btn);
                    reservation_detail.Enabled = true;
                    GF.enableButton(manage_btn);
                }
                else
                {
                    GF.disableButton(add_program_btn);
                    reservation_detail.Enabled = false;
                    GF.disableButton(manage_btn);
                }
                payment_btn.Visible = true;
            }
            isSpaProgramChanged = false;
            isApproved = false;
            ((reservation)this.Owner).loadData();
            if (!preventClose) this.Close();
            this.Activate();
            this.BringToFront();
            GF.closeLoading();

            if (cancel.Checked) res_status = "0";
            if (reserve.Checked) res_status = "1";
            if (start.Checked) res_status = "2";
            if (finish.Checked) res_status = "3";

            disableForm();
        }

        private void reservation_detail_Paint(object sender, PaintEventArgs e)
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

        private void add_program_btn_Click(object sender, EventArgs e)
        {
            recalculateTime();

            /*string start_time = "";
            string end_time = "";

            getStartAndEndTime(out start_time, out end_time);*/

            using (reservation_program spaProgram = new reservation_program())
            {
                String therapist_id_list = "";
                foreach (DataGridViewRow row in reservation_detail.Rows)
                {
                    therapist_id_list += row.Cells["therapist_id"].Value.ToString() + ", ";
                }
                if (therapist_id_list.IndexOf(",") != -1) therapist_id_list = therapist_id_list.Substring(0, therapist_id_list.Length - 2);

                spaProgram.agent_id = agent_id.currentID.ToString();
                spaProgram.therapist1_id = spaProgram.therapist2_id = therapist_id;
                spaProgram.therapist_id_list = therapist_id_list;
                //spaProgram.start_time = start_time;
                //spaProgram.end_time = end_time;
                spaProgram.Owner = this;
                spaProgram.ShowDialog();
                spaProgram.Activate();
                spaProgram.BringToFront();
            }
            preventClose = false;
        }

        public void getRoom()
        {
            GF.showLoading(this);
            /*String start_datetime = "";
            String end_datetime = "";

            getStartAndEndTime(out start_datetime, out end_datetime);*/

            string room_queryString = "SELECT * FROM ROOM WHERE IS_USE = 1";
            if(currentRoomID.ToString() != "" && currentRoomID.ToString() != "-1") room_queryString += " OR (ROOM_ID = " + currentRoomID.ToString() + ")";
            room_queryString += " ORDER BY CONVERT(BIGINT, REPLACE(CODE, '/', ''))";
            /*room_queryString = @"
            SELECT * 
            FROM ROOM 
            WHERE IS_USE = 1 AND (ROOM_ID = " + currentRoomID.ToString() + @" OR ROOM_ID NOT IN 
                (
                    SELECT ROOM_ID
                    FROM RESERVATION
                    WHERE 
                    (
                        (
                            (
                                APPOINTMENT_START BETWEEN " + GF.modDateTime(start_datetime) + @" AND " + GF.modDateTime(end_datetime) + @"
                                OR
                                APPOINTMENT_END BETWEEN " + GF.modDateTime(start_datetime) + @" AND " + GF.modDateTime(end_datetime) + @"
                            )
                            AND START_TIME IS NULL AND END_TIME IS NULL
                        )
                        OR
                        (
                            (
                                START_TIME BETWEEN " + GF.modDateTime(start_datetime) + @" AND " + GF.modDateTime(end_datetime) + @"
                                OR
                                END_TIME BETWEEN  " + GF.modDateTime(start_datetime) + @" AND " + GF.modDateTime(end_datetime) + @"
                            )
                            AND START_TIME IS NOT NULL AND END_TIME IS NOT NULL
                        )
                    )
                )
            )
            ORDER BY CONVERT(INT, REPLACE(CODE, '/', ''))";*/

            room_id.Items.Clear();
            room_id.Items.Add(new ComboItem(-1, "ROOM LIST"));
            
            int room_index = 0;

            using (DataTable roomDT = DB.getS(room_queryString, null, "GET UNOCCUPIED ROOM", false))
            {
                for (int index = 0; index < roomDT.Rows.Count; index++)
                {
                    room_id.Items.Add(new ComboItem(Convert.ToInt32(roomDT.Rows[index]["ROOM_ID"].ToString()), roomDT.Rows[index]["CODE"] + " - " + roomDT.Rows[index]["ROOM_NAME"].ToString()));
                    if (roomDT.Rows[index]["ROOM_ID"].ToString() == currentRoomID.ToString()) room_index = index + 1;
                }
            }
            room_id.SelectedIndex = room_index;
            GF.resizeComboBox(room_id);
            GF.closeLoading();
        }

        private void start_hours_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (!firstLoad) getRoom();
        }

        private void spa_card_btn_Click(object sender, EventArgs e)
        {
            bool foundReserve = false;
            foreach (DataGridViewRow tmpRow in reservation_detail.Rows)
            {
                if (tmpRow.Cells["PROGRAM_NAME"].Value.ToString().IndexOf("RESERVE") != -1)
                {
                    foundReserve = true;
                    break;
                }
            }
            if (foundReserve)
            {
                MessageBox.Show("YOU HAVE NOT CHOOSE THE SPA PROGRAM YET !!", "ERROR");
                return;
            }
            if (spa_card_btn.Text.Trim() == "ISSUE SPA CARD")
            {
                if (isSpaCardIssued && !GF.can_approve)
                {
                    using (reservation_approve approvePage = new reservation_approve())
                    {
                        approvePage.Owner = this;
                        approvePage.ShowDialog();
                    }
                }

                if (isApproved || !isSpaCardIssued || GF.can_approve)
                {
                    String queryString = "UPDATE RESERVATION SET SPA_CARD_ISSUE = CURRENT_TIMESTAMP WHERE RESERVATION_ID = " + res_id;
                    DB.beginTrans();
                    if (!DB.set(queryString, "UPDATE SPA_CARD_ISSUE IN RES_ID[" + res_id + "]"))
                    {
                        MessageBox.Show("ERROR UPDATE RESERVATION !!", "ERROR");
                        return;
                    }
                    DB.close();
                    GF.selected_id = Convert.ToInt32(res_id);

                    PRINT.initPrint(false, "SPA_CARD_NEW", "SPA_CARD_NEW.jpg", this);
                    isSpaCardIssued = true;
                    spa_card_btn.BackColor = Color.LightCoral;
                }

                isApproved = false;
            }
        }

        private void keycard_btn_Click(object sender, EventArgs e)
        {
            if (keycard_btn.Text.Trim() == "ISSUE KEYCARD")
            {
                GF.showLoading(this);

                if (keycard_btn.Text.Trim() == "RE-ISSUE KEYCARD") KEYCARD.executeCommand(this, "REVOKE");
                if (keycard_btn.Text.Trim() == "RE-ISSUE KEYCARD" && returnCode != 0)
                {
                    MessageBox.Show("ERROR REVOKE KEYCARD FOR RE-ISSUE !!", "ERROR");
                    GF.closeLoading();
                    return;
                }

                String queryString = "SELECT CODE FROM ROOM WHERE ROOM_ID = " + ((ComboItem)room_id.SelectedItem).Key.ToString();
                String room_no = "";
                using (DataTable DT = DB.getS(queryString, null, "GET CODE OF ROOM[" + ((ComboItem)room_id.SelectedItem).Key.ToString() + "]", false))
                {
                    room_no = DT.Rows[0]["CODE"].ToString().Split('/')[0];
                }

                queryString = "SELECT CONVERT(NVARCHAR(MAX), DATEADD(MINUTE, -15, START_TIME), 103) + ' ' + CONVERT(NVARCHAR(MAX), DATEADD(MINUTE, -15, START_TIME), 108) START_TIME, CONVERT(NVARCHAR(MAX), DATEADD(MINUTE, +15, END_TIME), 103) + ' ' + CONVERT(NVARCHAR(MAX), DATEADD(MINUTE, +15, END_TIME), 108) END_TIME FROM RESERVATION WHERE RESERVATION_ID = " + res_id;
                using (DataTable DT = DB.getS(queryString, null, "GET END_TIME FROM RESERVATION[" + res_id + "]", false))
                {
                    String startTime = DT.Rows[0]["START_TIME"].ToString();
                    String endTime = DT.Rows[0]["END_TIME"].ToString();

                    KEYCARD.executeCommand(this, "ISSUE", room_no, startTime, endTime);
                }

                if (returnCode == 0)
                {
                    DB.beginTrans();
                    queryString = "UPDATE RESERVATION SET KEYCARD_ISSUE = CURRENT_TIMESTAMP WHERE RESERVATION_ID = " + res_id;
                    if (!DB.set(queryString, ""))
                    {
                        MessageBox.Show("ERROR UPDATE KEYCARD_ISSUE !!", "ERROR");
                        GF.closeLoading();
                        return;
                    }
                    DB.close();
                }
                keycard_btn.BackColor = Color.LightCoral;
                GF.closeLoading();
            }

            if (keycard_btn.Text.Trim() == "RETURN KEYCARD")
            {
                GF.showLoading();
                KEYCARD.executeCommand(this, "REVOKE");
                if (returnCode == 0)
                {
                    DB.beginTrans();
                    String queryString = "UPDATE RESERVATION SET KEYCARD_RETURN = CURRENT_TIMESTAMP WHERE RESERVATION_ID = " + res_id;
                    if (!DB.set(queryString, ""))
                    {
                        MessageBox.Show("ERROR UPDATE KEYCARD_RETURN !!", "ERROR");
                        GF.closeLoading();
                        return;
                    }
                    DB.close();
                    keycard_btn.BackColor = Color.LightCoral;
                }
                GF.closeLoading();
            }
        }

        private void reservation_detail_Scroll(object sender, ScrollEventArgs e)
        {
            reservation_detail.Invalidate();
        }

        private void tel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void history_Paint(object sender, PaintEventArgs e)
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

        private void isBarter_CheckedChanged(object sender, EventArgs e)
        {
            if (isBarter.Checked) barter_detail.Enabled = true;
            else barter_detail.Enabled = false;
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            //((reservation)this.Owner).loadData();
            this.Close();
        }

        private void add_customer_btn_Click(object sender, EventArgs e)
        {
            using (CUSTOMER.customer_manage add_customer = new CUSTOMER.customer_manage())
            {
                add_customer.Owner = this;
                add_customer.ShowDialog();
            };
        }

        private void reservation_detail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (reservation_detail.Rows[e.RowIndex].Cells[0].Value.ToString().IndexOf("RESERVE") == -1)
                {
                    using (reservation_program spaProgram = new reservation_program())
                    {
                        spaProgram.spa_program = Convert.ToInt32(reservation_detail.Rows[e.RowIndex].Cells["program_id"].Value.ToString());
                        spaProgram.oil_id = Convert.ToInt32(reservation_detail.Rows[e.RowIndex].Cells["oil"].Value.ToString() == "" ? "-1" : reservation_detail.Rows[e.RowIndex].Cells["oil"].Value.ToString());
                        spaProgram.scrub_id = Convert.ToInt32(reservation_detail.Rows[e.RowIndex].Cells["scrub"].Value.ToString() == "" ? "-1" : reservation_detail.Rows[e.RowIndex].Cells["scrub"].Value.ToString());
                        spaProgram.therapist1_id = spaProgram.therapist2_id = therapist_id;

                        String[] tmp = reservation_detail.Rows[e.RowIndex].Cells["therapist_id"].Value.ToString().Trim().Split(',');
                        if (tmp.Length > 0)
                        {
                            if(tmp[0] != String.Empty)
                                spaProgram.therapist1_id = Convert.ToInt32(tmp[0]);

                            if (tmp.Length > 1)
                            {
                                spaProgram.therapist2_id = Convert.ToInt32(tmp[1]);
                            }
                        }

                        tmp = reservation_detail.Rows[e.RowIndex].Cells["is_requested"].Value.ToString().Trim().Split(',');
                        if (tmp.Length > 0)
                        {
                            if(tmp[0] != String.Empty)
                                spaProgram.therapist1_request = Convert.ToInt32(tmp[0]);
                            if (tmp.Length > 1)
                            {
                                spaProgram.therapist2_request = Convert.ToInt32(tmp[1]);
                            }
                        }

                        spaProgram.res_detail_id = reservation_detail.Rows[e.RowIndex].Cells["reservation_detail_id"].Value.ToString();
                        spaProgram.Owner = this;

                        spaProgram.ShowDialog();
                    }
                    preventClose = false;
                }
            }
        }

        private void payment_btn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in reservation_detail.Rows)
            {
                if (Convert.ToInt64(row.Cells["RESERVATION_DETAIL_ID"].Value.ToString()) < 0)
                {
                    MessageBox.Show("SOME DETAIL HAS BEEN MODIFIED.\r\n\r\n PLEASE PRESS 'UPDATE' BUTTON FIRST !!", "ERROR");
                    return;
                }
            }

            Form paymentPage = new SHOP.cashier();
            if (billID != "") ((SHOP.cashier)paymentPage).billID = Convert.ToInt32(billID);
            else
            {
                ((SHOP.cashier)paymentPage).DGVRC = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in reservation_detail.Rows)
                {
                    ((SHOP.cashier)paymentPage).DGVRC.Add(row);
                }
                ((SHOP.cashier)paymentPage).theDate = date.Text.Trim();
            }
            GF.initPage(paymentPage, GF.mainPage);
        }

        public void recalculateTime()
        {
            try
            {
                int sum_hours = 0;
                int sum_minutes = 0;

                if (reservation_detail.Rows.Count == 1 && reservation_detail.Rows[0].Cells["program_name"].Value.ToString().IndexOf("RESERVE") != -1)
                {
                    sum_hours = 0;
                    sum_minutes = 15;
                }
                else
                {
                    foreach (DataGridViewRow row in reservation_detail.Rows)
                    {
                        if (row.Cells["program_name"].Value.ToString().IndexOf("RESERVE") == -1)
                        {
                            if((row.Cells["HOURS"].Value ?? "").ToString() != String.Empty)
                                sum_hours += Convert.ToInt32(row.Cells["HOURS"].Value.ToString());
                            if ((row.Cells["MINUTES"].Value ?? "").ToString() != String.Empty)
                                sum_minutes += Convert.ToInt32(row.Cells["MINUTES"].Value.ToString());
                        }
                    }

                    while (sum_minutes >= 60)
                    {
                        sum_hours++;
                        sum_minutes -= 60;
                    }
                }

                if (start.Checked || finish.Checked)
                {
                    int tmp = -1;
                    if (Int32.TryParse(start_hours.Text, out tmp) && Int32.TryParse(start_minutes.Text, out tmp))
                    {
                        while (Convert.ToInt32(start_minutes.Text) + sum_minutes >= 60)
                        {
                            sum_hours++;
                            sum_minutes -= 60;
                        }

                        if (Convert.ToInt32(start_hours.Text) + sum_hours >= 24)
                        {
                            end_time.Text = (Convert.ToInt32(start_hours.Text) + sum_hours - 24).ToString("00") + ":" + (Convert.ToInt32(start_minutes.Text) + sum_minutes).ToString("00") + ":00 (+1)";
                        }
                        else
                            end_time.Text = (Convert.ToInt32(start_hours.Text) + sum_hours).ToString("00") + ":" + (Convert.ToInt32(start_minutes.Text) + sum_minutes).ToString("00") + ":00";
                    }
                }
            }
            catch (Exception e)
            {
                GF.closeLoading();
                MessageBox.Show("ERROR IN 'RECALCULATION THE TIME' !!\r\n\r\nPLEASE CONTACT SOFTWARE DEVELOPER !!\r\nMESSAGE : " + e.Message, "ERROR !!");
            }
        }

        private void reservation_detail_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            recalculateTime();
            if (reserve.Checked && reservation_detail.Rows.Count == 0)
            {
                addReserveRow();
            }
            reservation_detail.ClearSelection();
        }

        /*private void getStartAndEndTime(out string start_datetime, out string end_datetime)
        {
            recalculateTime();
            if (start.Checked && start_hours.SelectedIndex != 0 && start_minutes.SelectedIndex != 0)
            {
                start_datetime = date.Value.Year.ToString() + "-" + date.Value.Month.ToString("00") + "-" + date.Value.Day.ToString("00") + " " + start_hours.Text + ":" + start_minutes.Text + ":00";
                end_datetime = this.end_time.Text;
                if (end_datetime.IndexOf("+") != -1)
                {
                    using (DateTimePicker DTP = new DateTimePicker())
                    {
                        DTP.Value.AddDays(1);
                        date.Text = DTP.Text;
                        end_datetime = DTP.Value.Year.ToString() + "-" + DTP.Value.Month.ToString("00") + "-" + DTP.Value.Day.ToString("00") + " " + end_datetime.Trim().Substring(0, end_datetime.Length - 5);
                    }
                }
                else
                {
                    end_datetime = date.Value.Year.ToString() + "-" + date.Value.Month.ToString("00") + "-" + date.Value.Day.ToString("00") + " " + end_time.Text.Trim();
                }
            }
            else
            {
                start_datetime = date.Value.Year.ToString() + "-" + date.Value.Month.ToString("00") + "-" + date.Value.Day.ToString("00") + " " + appointment_hours.Text + ":" + appointment_minutes.Text + ":00";
                using (DateTimePicker DTP = new DateTimePicker())
                {
                    DTP.CustomFormat = "dd/MM/yyyy HH:mm:ss";
                    DTP.Text = date.Text.Split(' ')[0] + " " + appointment_hours.Text + ":" + appointment_minutes.Text + ":00";
                    DTP.Value.AddMinutes(15);
                    date.Text = DTP.Text;
                    end_datetime = DTP.Value.Year.ToString() + "-" + DTP.Value.Month.ToString("00") + "-" + DTP.Value.Day.ToString("00") + " " + DTP.Value.Hour.ToString("00") + ":" + DTP.Value.Minute.ToString("00") + ":00";
                }
            }
        }*/

        private void room_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentRoomID = ((ComboItem)room_id.SelectedItem).Key;
        }

        private void start_minutes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (!firstLoad) getRoom();
        }

        private void info_btn_Click(object sender, EventArgs e)
        {
            if (customer_name.currentID == -1)
            {
                MessageBox.Show("PLEASE CHOOSE CUSTOMER !!", "ERROR");
                return;
            }

            using (customer_history history = new customer_history())
            {
                history.customer_id = customer_name.currentID.ToString();
                history.Owner = this;
                history.ShowDialog();
            }
        }

        private void membercard_btn_Click(object sender, EventArgs e)
        {
            if (customer_name.currentID == -1)
            {
                MessageBox.Show("PLEASE CHOOSE CUSTOMER !!", "ERROR");
                return;
            }

            using (membercard_list cardList = new membercard_list())
            {
                cardList.customer_id = customer_name.currentID.ToString();
                cardList.Owner = this;
                cardList.ShowDialog();
            }
        }

        private void finish_CheckedChanged(object sender, EventArgs e)
        {
            this.Activate();
            this.BringToFront();
        }

        void disableForm()
        {
            Boolean mode = (res_status == "" || res_status == "1" || GF.can_approve);

            agent_id.Enabled = mode;
            customer_name.Enabled = mode;
            note.Enabled = mode;

            date.Enabled = (res_status == "1");
            //date.Enabled = mode;
            appointment_hours.Enabled = mode;
            appointment_minutes.Enabled = mode;
            room_id.Enabled = mode;
            request.Enabled = mode;
            isBarter.Enabled = mode;
            barter_detail.Enabled = mode;
            start_hours.Enabled = mode;
            start_minutes.Enabled = mode;
            low.Enabled = mode;
            medium.Enabled = mode;
            strong.Enabled = mode;
            add_program_btn.Enabled = mode;
        }

        private void reservation_detail_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = (!GF.can_approve && res_status != "" && res_status != "1");
        }
    }
}
