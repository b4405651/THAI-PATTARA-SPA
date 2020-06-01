using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM
{
    public partial class ac_data : UserControl
    {
        string _type = "";
        string queryString = "";
        Dictionary<int, string> list;

        public ac_data()
        {
            InitializeComponent();
        }

        public string Type { get { return _type; } set { _type = value; } }
        public int value { get { return myAC.value; } }

        public void setText(string text)
        {
            myAC.setText(text);
        }
        public void setID(int ID)
        {
            doQuery(ID);
        }
        public int maxWidth { get { return myAC.maxWidth; } set { myAC.maxWidth = value; } }

        private void doQuery(int id = -1)
        {
            Dictionary<string, string> Params = new Dictionary<string, string>();
            //Params.Add("@text", myAC.acTxt.Text);
            switch (this.Type)
            {
                case "CUSTOMER":
                    queryString = "SELECT * FROM CUSTOMER WHERE (CUSTOMER_NAME LIKE '%" + myAC.acTxt.Text + "%' OR TEL = '" + myAC.acTxt.Text + "%')";
                    if (id != -1)
                    {
                        queryString += " AND CUSTOMER_ID = " + id.ToString();
                        using (DataTable myDT = DB.getS(queryString, Params, "GET CUSTOMER[" + id.ToString() + "]", false))
                        {
                            if (myDT.Rows.Count == 1)
                            {
                                setText(myDT.Rows[0]["CUSTOMER_NAME"].ToString() + " - " + myDT.Rows[0]["TEL"].ToString());
                            }
                        }
                        break;
                    }

                    using (DataTable myDT = DB.getS(queryString, Params, "GET CUSTOMER FOR AUTOCOMPLETE", false))
                    {
                        foreach (DataRow row in myDT.Rows)
                        {
                            this.list.Add(Convert.ToInt32(row["CUSTOMER_ID"].ToString()), row["CUSTOMER_NAME"].ToString() + " - " + row["TEL"].ToString());
                        }
                    }
                    break;
                case "EMPLOYEE":
                    queryString = @"SELECT * FROM (
                        SELECT 0 emp_id, 'ผู้พัฒนา Software' fullname, '0' code, 0 emp_type, 1 emp_status, NULL resign_date
                        UNION ALL
                        SELECT emp_id, fullname, code, emp_type, emp_status, resign_date FROM EMPLOYEE) AS EMP WHERE 1=1";
                    
                    if (myAC.acTxt.Text.Trim() != "")
                    {
                        queryString += " AND (EMP.fullname LIKE '%' + @text + '%' OR EMP.CODE = @text + '%')";
                    }

                    if (id != -1)
                    {
                        queryString += " AND EMP_ID = " + id.ToString();
                        using (DataTable myDT = DB.getS(queryString, Params, "GET EMPLOYEE[" + id.ToString() + "]", false))
                        {
                            if (myDT.Rows.Count == 1)
                            {
                                setText(myDT.Rows[0]["FULLNAME"].ToString());
                            }
                        }
                        break;
                    }

                    using (DataTable myDT = DB.getS(DB.insertRowNum("FULLNAME", queryString, false), Params, "GET EMPLOYEE LIST TO BE DISPLAYED ON EMP_LEAVE FORM", false))
                    {

                        for (int rowNum = 0; rowNum < myDT.Rows.Count; rowNum++)
                        {
                            this.list.Add(Convert.ToInt32(myDT.Rows[rowNum]["emp_id"]), myDT.Rows[rowNum]["fullname"].ToString() + " [" + myDT.Rows[rowNum]["code"].ToString() + "]");
                        }
                    }
                    
                    break;
                case "ITEM_CAT":
                    queryString = @"SELECT * FROM ITEM_TYPE WHERE 1=1";
                    
                    if (myAC.acTxt.Text.Trim() != "")
                    {
                        queryString += " AND item_type_name LIKE '%' + @text + '%'";
                    }
                    if (id != -1)
                    {
                        queryString += " AND ITEM_TYPE_ID = " + id.ToString();
                        using (DataTable myDT = DB.getS(queryString, Params, "GET ITEM_TYPE[" + id.ToString() + "]", false))
                        {
                            if (myDT.Rows.Count == 1)
                            {
                                setText(myDT.Rows[0]["ITEM_TYPE_NAME"].ToString());
                            }
                        }
                        break;
                    }

                    queryString += " ORDER BY item_type_name ASC";
                    using (DataTable myDT = DB.getS(queryString, Params, "GET ITEM_TYPE FOR ITEM MANAGE SEARCH", false))
                    {
                        for (int rowNum = 0; rowNum < myDT.Rows.Count; rowNum++)
                        {
                            list.Add(Convert.ToInt32(myDT.Rows[rowNum]["item_type_id"]), myDT.Rows[rowNum]["item_type_name"].ToString());
                        }
                    }
                    break;
            }
        }

        private void myAC_textChanged(object sender, EventArgs e)
        {
            GF.bringToFront(this);
            
            this.list = new Dictionary<int, string>();
            if (myAC.acTxt.Text.Trim() != "") doQuery();
            else myAC.acBox.Items.Clear();

            myAC.acBox.DisplayMember = "Value";
            myAC.acBox.Items.AddRange(list.OfType<object>().ToArray());
            myAC.acBox.Refresh();
            this.Height = myAC.Height;
            this.Width = myAC.Width;
        }

        public void next()
        {
            SendKeys.Send("{TAB}");
        }
    }
}
