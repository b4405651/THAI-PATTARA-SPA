using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.USER
{
    public partial class log : Form
    {
        public log()
        {
            InitializeComponent();

            btn_dgv.add_btn.Visible = false;
            btn_dgv.edit_btn.Visible = false;
            btn_dgv.del_btn.Visible = false;
            btn_dgv.search_btn.Visible = false;

            btn_dgv.RefreshClick += new btn_dgv.RefreshClickHandler(doLoadGridData);

            //PAGING DELEGATE
            btn_dgv.firstClick += new btn_dgv.firstClickHandler(doLoadGridData);
            btn_dgv.prevClick += new btn_dgv.prevClickHandler(doLoadGridData);
            btn_dgv.nextClick += new btn_dgv.nextClickHandler(doLoadGridData);
            btn_dgv.lastClick += new btn_dgv.lastClickHandler(doLoadGridData);
            btn_dgv.pageNumberChanged += new btn_dgv.pageNumberChangedHandler(doLoadGridData);
        }

        private void log_Load(object sender, EventArgs e)
        {
            loadGridData();
        }

        void doLoadGridData(object sender, EventArgs e)
        {
            btn_dgv.Left = 15;
            btn_dgv.rearrange(GF.pageTop);

            loadGridData();
        }

        public void loadGridData()
        {
            btn_dgv.DGV.Rows.Clear();

            if (btn_dgv.DGV.Columns.Count == 0)
            {
                btn_dgv.DGV.Columns.Add("subject", "SUBJECT");
                btn_dgv.DGV.Columns.Add("from", "FROM");
                btn_dgv.DGV.Columns.Add("log_datetime", "LOG DATETIME");
                btn_dgv.DGV.Columns.Add("query", "QUERY");
                btn_dgv.DGV.Columns.Add("old_value", "OLD VALUE");
            }

            // GET TOTAL PAGE
            string queryString =  @"
                    SELECT A.*, B.fullname
                    FROM LOG A
                    LEFT OUTER JOIN EMPLOYEE B
                    ON A.emp_id = B.emp_id";

            GF.getTotalPage(btn_dgv, queryString, null);
            queryString = DB.insertRowNum("log_datetime DESC", queryString);
            using (DataTable myDT = DB.getS(queryString, null, "GET ALL LOGS"))
            {
                int rowNum = 0;
                foreach (DataRow myRow in myDT.Rows)
                {
                    if (myRow["fullname"].ToString() == "")
                    {
                        myRow["fullname"] = "Administrator";
                    }

                    btn_dgv.DGV.Rows.Add(
                        myRow["subject"],
                        myRow["fullname"],
                        myRow["log_datetime"],
                        System.Text.RegularExpressions.Regex.Replace(myRow["query"].ToString(), @"\s+", " "),
                        myRow["old_value"]
                    );

                    btn_dgv.DGV[0, rowNum].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    btn_dgv.DGV[1, rowNum].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    btn_dgv.DGV[3, rowNum].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    btn_dgv.DGV[4, rowNum].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    rowNum++;
                }
            }
            GF.updateRowNum(btn_dgv.DGV, true);
            btn_dgv.DGV.ClearSelection();
            GF.closeLoading();
        }
    }
}
