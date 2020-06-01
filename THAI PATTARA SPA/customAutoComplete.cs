using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM
{
    public class customAutoComplete : TextBox
    {
        String[] ModeList = { "CUSTOMER", "EMPLOYEE", "DEBTOR", "AGENT", "ITEM_TYPE" };
        String _Mode = "";
        public int _currentID = -1;
        public string currentNote = "";
        public bool preventTextChanged = false;
        DataTable DT;
        String queryString = "";
        public Form parentForm;

        public String Mode { 
            get { return _Mode; } 
            set { 
                _Mode = value.ToString().ToUpper();
                switch (_Mode)
                {
                    case "CUSTOMER":
                        queryString = "SELECT * FROM CUSTOMER WHERE IS_USE = 1 ";
                        break;
                    case "EMPLOYEE":
                        queryString = "SELECT * FROM EMPLOYEE WHERE EMP_STATUS = 1 ";
                        break;
                    case "DEBTOR":
                        queryString = @"
                        SELECT A.*, B.DEBTOR_TYPE_NAME FROM
                        (
                            (
                                SELECT DEBTOR_NAME NAME, TEL, DEBTOR_ID, DEBTOR_TYPE_ID, IS_USE FROM DEBTOR WHERE DEBTOR_TYPE_ID = 1
                            )
                            UNION ALL
                            (
                                SELECT B.CUSTOMER_NAME NAME, B.TEL, A.DEBTOR_ID, A.DEBTOR_TYPE_ID, A.IS_USE FROM DEBTOR A INNER JOIN CUSTOMER B ON A.TARGET_ID = B.CUSTOMER_ID AND A.DEBTOR_TYPE_ID = 2
                            )
                            UNION ALL
                            (
                                SELECT B.FULLNAME NAME, B.TEL, A.DEBTOR_ID, A.DEBTOR_TYPE_ID, A.IS_USE FROM DEBTOR A INNER JOIN EMPLOYEE B ON A.TARGET_ID = B.EMP_ID AND A.DEBTOR_TYPE_ID = 3
                            )
                        ) A
                        INNER JOIN DEBTOR_TYPE B ON A.DEBTOR_TYPE_ID = B.DEBTOR_TYPE_ID 
                        WHERE A.IS_USE = 1 ";
                        break;
                    case "AGENT":
                        queryString = "SELECT * FROM AGENT A WHERE A.IS_USE = 1 ";
                        break;
                    case "ITEM_TYPE":
                        queryString = "SELECT * FROM ITEM_TYPE A WHERE A.IS_USE = 1 ";
                        break;
                }
            } 
        }
        public int currentID { get { return _currentID; } set { _currentID = value; } }

        public customAutoComplete()
        {
            //Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ForeColor = System.Drawing.Color.Red;
            //Font = new System.Drawing.Font(Font, System.Drawing.FontStyle.Bold);
        }

        public void SetID(int ID)
        {
            String tmpQuery = queryString;
            switch (Mode)
            {
                case "CUSTOMER":
                    tmpQuery += "AND CUSTOMER_ID = " + ID.ToString();
                    break;
                case "EMPLOYEE":
                    tmpQuery += "AND EMP_ID = " + ID.ToString();
                    break;
                case "DEBTOR":
                    tmpQuery += "AND A.DEBTOR_ID = " + ID.ToString();
                    break;
                case "AGENT":
                    tmpQuery += "AND A.AGENT_ID = " + ID.ToString();
                    break;
                case "ITEM_TYPE":
                    tmpQuery += "AND A.ITEM_TYPE_ID = " + ID.ToString();
                    break;
            }
            if (tmpQuery != "")
            {
                using (DT = DB.getS(tmpQuery, null, "GET " + Mode + " DATA FOR SET ID[" + ID.ToString() + "]", false))
                {
                    DataRow row = DT.Rows[0];
                    switch (Mode)
                    {
                        case "CUSTOMER":
                            SetText(ID, row["CUSTOMER_NAME"].ToString() + " - " + (row["GENDER"].ToString() == "1" ? "MALE" : "FEMALE") + " - " + row["TEL"].ToString());
                            break;
                        case "EMPLOYEE":
                            SetText(ID, row["CODE"].ToString() + " - " + row["FULLNAME"].ToString());
                            break;
                        case "DEBTOR":
                            SetText(ID, "[" + row["DEBTOR_TYPE_NAME"].ToString() + "] " + row["NAME"].ToString() + " " + row["TEL"].ToString());
                            break;
                        case "AGENT":
                            SetText(ID, row["AGENT_NAME"].ToString() + " - " + row["TEL"].ToString());
                            break;
                        case "ITEM_TYPE":
                            SetText(ID, row["ITEM_TYPE_NAME"].ToString());
                            break;
                    }
                }
            }
        }

        public void SetText(int ID, string Text)
        {
            preventTextChanged = true;
            ForeColor = System.Drawing.Color.Black;
            this.currentID = ID;
            this.Text = Text;
            preventTextChanged = false;

            switch (Mode)
            {
                case "CUSTOMER":
                    if (parentForm.Name == "report_customer_history")
                    {
                        ((CUSTOMER.report_customer_history)parentForm).getReport();
                    }
                    if (parentForm.Name == "report_membercard_in_customer")
                    {
                        ((CUSTOMER.report_membercard_in_customer)parentForm).getMemberCard();
                    }
                    break;
                case "EMPLOYEE":
                    if (parentForm.Name == "users_auth")
                    {
                        ((USER.users_auth)parentForm).go_btn.PerformClick();
                    }
                    break;
                case "DEBTOR":
                    if(parentForm.Name == "payment")
                    {
                        ((SHOP.payment)parentForm).receive.Text = ((SHOP.payment)parentForm).grand_total.Text.Replace(",", "").Replace(".00", "");
                        ((SHOP.payment)parentForm).receive.Select();
                        SendKeys.Send("{ENTER}");
                    }
                    break;
                case "AGENT":
                    break;
                case "ITEM_TYPE":
                    break;
            }

            parentForm.Activate();
            parentForm.BringToFront();
        }

        protected override void OnLeave(EventArgs e)
        {
            if (currentID == -1)
            {
                Text = "";
                ForeColor = System.Drawing.Color.Red;
            }
            base.OnLeave(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (!preventTextChanged)
            {
                currentID = -1;
                ForeColor = System.Drawing.Color.Red;
                if (this.Parent.Name == "reservation")
                {
                    if (Text.Trim() == "") ((RESERVATION.reservation)Parent).loadData();
                }
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (Text.Trim() != "")
            {
                if (e.KeyCode == Keys.Return)
                {
                    if (!ModeList.Contains(Mode))
                    {
                        MessageBox.Show("THE AUTOCOMPLETE IS UNDER CONSTRUCTION !!", "ERROR");
                        return;
                    }
                    if (Mode == "") return;

                    String tmpQuery = queryString;
                    currentID = -1;
                    GF.showLoading(parentForm);

                    Dictionary<string, string> Params;

                    if (Mode == "CUSTOMER")
                    {
                        if (Text.Trim().Substring(0, 1) == "7")
                            Text = "8" + Text.Trim().Substring(1);

                        tmpQuery += "AND (CUSTOMER_NAME LIKE N'%' + @text + '%' OR RUS_NAME LIKE N'%' + @text + '%' OR TEL LIKE @text + '%')";
                        Params = new Dictionary<string, string>();
                        Params.Add("@text", Text);

                        using (DT = DB.getS(tmpQuery, Params, "GET CUSTOMER NAME", false))
                        {
                            if (DT.Rows.Count == 0)
                            {
                                GF.closeLoading();
                                MessageBox.Show("... NO RESULT ...");
                            }
                            else if (DT.Rows.Count == 1)
                            {
                                DataRow row = DT.Rows[0];
                                SetText(Convert.ToInt32(row["CUSTOMER_ID"].ToString()), row["CUSTOMER_NAME"].ToString() + " - " + (row["GENDER"].ToString() == "1" ? "MALE" : "FEMALE") + " - " + row["TEL"].ToString());
                                GF.closeLoading();
                            }
                            else
                            {
                                preventTextChanged = true;
                                using (name_list searchResult = new name_list())
                                {
                                    searchResult.Load += (ss, ee) =>
                                    {
                                        searchResult.Size = searchResult.resultTable.Size;
                                    };
                                    
                                    if (searchResult.resultTable.Rows.Count > 0) searchResult.resultTable.Rows.Clear();
                                    if (searchResult.resultTable.Columns.Count == 0)
                                    {
                                        searchResult.resultTable.Columns.Add("name", "NAME");
                                        searchResult.resultTable.Columns.Add("rus_name", "RUS NAME");
                                        searchResult.resultTable.Columns.Add("gender", "GENDER");
                                        searchResult.resultTable.Columns.Add("tel", "TEL");
                                        searchResult.resultTable.Columns.Add("note", "NOTE");
                                        searchResult.resultTable.Columns.Add("customer_id", "customer_id");
                                        searchResult.resultTable.Columns["note"].Visible = false;
                                        searchResult.resultTable.Columns["customer_id"].Visible = false;
                                    }

                                    foreach (DataRow row in DT.Rows)
                                    {
                                        searchResult.resultTable.Rows.Add(row["CUSTOMER_NAME"].ToString(), row["RUS_NAME"].ToString(), (row["GENDER"].ToString() == "1" ? "MALE" : "FEMALE"), row["TEL"].ToString(), row["NOTE"].ToString(), row["CUSTOMER_ID"].ToString());
                                    }

                                    GF.updateRowNum(searchResult.resultTable);

                                    foreach (DataGridViewColumn column in searchResult.resultTable.Columns)
                                    {
                                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                                    }
                                    GF.closeLoading();
                                    searchResult.Owner = parentForm;
                                    searchResult.Mode = this.Mode;
                                    searchResult.ShowDialog();
                                    searchResult.BringToFront();
                                }
                                preventTextChanged = false;
                            }
                        }
                    }

                    if (Mode == "EMPLOYEE")
                    {
                        tmpQuery += "AND (FULLNAME LIKE '%' + @text + '%' OR CODE LIKE @text + '%')";
                        Params = new Dictionary<string, string>();
                        Params.Add("@text", Text);

                        using (DT = DB.getS(tmpQuery, Params, "GET EMPLOYEE NAME", false))
                        {
                            if (DT.Rows.Count == 0)
                            {
                                GF.closeLoading();
                                MessageBox.Show("... NO RESULT ...");
                            }
                            else if (DT.Rows.Count == 1)
                            {
                                DataRow row = DT.Rows[0];
                                SetText(Convert.ToInt32(row["EMP_ID"].ToString()), row["CODE"].ToString() + " - " + row["FULLNAME"].ToString());
                                GF.closeLoading();
                            }
                            else
                            {
                                preventTextChanged = true;
                                using (name_list searchResult = new name_list())
                                {
                                    searchResult.Load += (ss, ee) =>
                                    {
                                        searchResult.Size = searchResult.resultTable.Size;
                                    };
                                    
                                    if (searchResult.resultTable.Rows.Count > 0) searchResult.resultTable.Rows.Clear();
                                    if (searchResult.resultTable.Columns.Count == 0)
                                    {
                                        searchResult.resultTable.Columns.Add("fullname", "NAME");
                                        searchResult.resultTable.Columns.Add("code", "CODE");
                                        searchResult.resultTable.Columns.Add("emp_id", "emp_id");
                                        searchResult.resultTable.Columns["emp_id"].Visible = false;
                                    }

                                    foreach (DataRow row in DT.Rows)
                                    {
                                        searchResult.resultTable.Rows.Add(row["FULLNAME"].ToString(), row["CODE"].ToString(), row["EMP_ID"].ToString());
                                    }

                                    GF.updateRowNum(searchResult.resultTable);

                                    foreach (DataGridViewColumn column in searchResult.resultTable.Columns)
                                    {
                                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                                    }
                                    GF.closeLoading();
                                    searchResult.Owner = parentForm;
                                    searchResult.Mode = this.Mode;
                                    searchResult.ShowDialog();
                                }
                                preventTextChanged = false;
                            }
                        }
                    }

                    if (Mode == "DEBTOR")
                    {
                        tmpQuery += "AND (A.NAME LIKE '%' + @text + '%' OR A.TEL LIKE '%' + @text + '%')";
                        Params = new Dictionary<string, string>();
                        Params.Add("@text", Text);

                        using (DT = DB.getS(tmpQuery, Params, "GET DEBTOR NAME", false))
                        {
                            if (DT.Rows.Count == 0)
                            {
                                GF.closeLoading();
                                MessageBox.Show("... NO RESULT ...");
                            }
                            else if (DT.Rows.Count == 1)
                            {
                                DataRow row = DT.Rows[0];
                                SetText(Convert.ToInt32(row["DEBTOR_ID"].ToString()), "[" + row["DEBTOR_TYPE_NAME"].ToString() + "] " + row["NAME"].ToString() + " " + row["TEL"].ToString());
                                GF.closeLoading();
                            }
                            else
                            {
                                preventTextChanged = true;
                                using (name_list searchResult = new name_list())
                                {
                                    searchResult.Load += (ss, ee) =>
                                    {
                                        searchResult.Size = searchResult.resultTable.Size;
                                    };

                                    if (searchResult.resultTable.Rows.Count > 0) searchResult.resultTable.Rows.Clear();
                                    if (searchResult.resultTable.Columns.Count == 0)
                                    {
                                        searchResult.resultTable.Columns.Add("debtor_name", "NAME");
                                        searchResult.resultTable.Columns.Add("tel", "TEL NO.");
                                        searchResult.resultTable.Columns.Add("debtor_type_name", "TYPE");
                                        searchResult.resultTable.Columns.Add("debtor_id", "debtor_id");
                                        searchResult.resultTable.Columns["debtor_id"].Visible = false;
                                    }

                                    foreach (DataRow row in DT.Rows)
                                    {
                                        searchResult.resultTable.Rows.Add(row["NAME"].ToString(), row["TEL"].ToString(), row["DEBTOR_TYPE_NAME"].ToString(), row["DEBTOR_ID"].ToString());
                                    }

                                    GF.updateRowNum(searchResult.resultTable);

                                    foreach (DataGridViewColumn column in searchResult.resultTable.Columns)
                                    {
                                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                                    }
                                    GF.closeLoading();
                                    searchResult.Owner = parentForm;
                                    searchResult.Mode = this.Mode;
                                    searchResult.ShowDialog();
                                }
                                preventTextChanged = false;
                            }
                        }                        
                    }

                    if (Mode == "AGENT")
                    {
                        tmpQuery += "AND (A.AGENT_NAME LIKE '%' + @text + '%' OR A.TEL LIKE '%' + @text + '%')";
                        Params = new Dictionary<string, string>();
                        Params.Add("@text", Text);

                        using (DT = DB.getS(tmpQuery, Params, "GET AGENT NAME", false))
                        {
                            if (DT.Rows.Count == 0)
                            {
                                GF.closeLoading();
                                MessageBox.Show("... NO RESULT ...");
                            }
                            else if (DT.Rows.Count == 1)
                            {
                                DataRow row = DT.Rows[0];
                                SetText(Convert.ToInt32(row["AGENT_ID"].ToString()), row["AGENT_NAME"].ToString() + " - " + row["TEL"].ToString());
                                GF.closeLoading();
                            }
                            else
                            {
                                preventTextChanged = true;
                                using (name_list searchResult = new name_list())
                                {
                                    searchResult.Load += (ss, ee) =>
                                    {
                                        searchResult.Size = searchResult.resultTable.Size;
                                    };

                                    if (searchResult.resultTable.Rows.Count > 0) searchResult.resultTable.Rows.Clear();
                                    if (searchResult.resultTable.Columns.Count == 0)
                                    {
                                        searchResult.resultTable.Columns.Add("agent_name", "NAME");
                                        searchResult.resultTable.Columns.Add("tel", "TEL NO.");
                                        searchResult.resultTable.Columns.Add("agent_type_name", "TYPE");
                                        searchResult.resultTable.Columns.Add("agent_id", "agent_id");
                                        searchResult.resultTable.Columns["agent_id"].Visible = false;
                                    }

                                    foreach (DataRow row in DT.Rows)
                                    {
                                        searchResult.resultTable.Rows.Add(row["AGENT_NAME"].ToString(), row["TEL"].ToString(), (row["AGENT_TYPE"].ToString() == "0" ? "COMPANY" : "PERSON"), row["AGENT_ID"].ToString());
                                    }

                                    GF.updateRowNum(searchResult.resultTable);

                                    foreach (DataGridViewColumn column in searchResult.resultTable.Columns)
                                    {
                                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                                    }
                                    GF.closeLoading();
                                    searchResult.Owner = parentForm;
                                    searchResult.Mode = this.Mode;
                                    searchResult.ShowDialog();
                                }
                                preventTextChanged = false;
                            }
                        }
                    }

                    if (Mode == "ITEM_TYPE")
                    {
                        tmpQuery += "AND A.ITEM_TYPE_NAME LIKE '%' + @text + '%'";

                        Params = new Dictionary<string, string>();
                        Params.Add("@text", Text);

                        using (DT = DB.getS(tmpQuery, Params, "GET ITEM_TYPE_NAME", false))
                        {
                            if (DT.Rows.Count == 0)
                            {
                                GF.closeLoading();
                                MessageBox.Show("... NO RESULT ...");
                            }
                            else if (DT.Rows.Count == 1)
                            {
                                DataRow row = DT.Rows[0];
                                SetText(Convert.ToInt32(row["ITEM_TYPE_ID"].ToString()), row["ITEM_TYPE_NAME"].ToString());
                                GF.closeLoading();
                            }
                            else
                            {
                                preventTextChanged = true;
                                using (name_list searchResult = new name_list())
                                {
                                    searchResult.Load += (ss, ee) =>
                                    {
                                        searchResult.Size = searchResult.resultTable.Size;
                                    };

                                    if (searchResult.resultTable.Rows.Count > 0) searchResult.resultTable.Rows.Clear();
                                    if (searchResult.resultTable.Columns.Count == 0)
                                    {
                                        searchResult.resultTable.Columns.Add("item_type_name", "ITEM TYPE NAME");
                                        searchResult.resultTable.Columns.Add("item_type_id", "item_type_id");
                                        searchResult.resultTable.Columns["item_type_id"].Visible = false;
                                    }

                                    foreach (DataRow row in DT.Rows)
                                    {
                                        searchResult.resultTable.Rows.Add(row["ITEM_TYPE_NAME"].ToString(), row["ITEM_TYPE_ID"].ToString());
                                    }

                                    GF.updateRowNum(searchResult.resultTable);

                                    foreach (DataGridViewColumn column in searchResult.resultTable.Columns)
                                    {
                                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                                    }
                                    GF.closeLoading();
                                    searchResult.Owner = parentForm;
                                    searchResult.Mode = this.Mode;
                                    searchResult.ShowDialog();
                                }
                                preventTextChanged = false;
                            }
                        }
                    }

                    parentForm.Activate();
                    parentForm.BringToFront();
                }
            }
            base.OnKeyDown(e);
        }
    }
}
