using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM
{
    public partial class re_issue_card : Form
    {
        public re_issue_card()
        {
            InitializeComponent();
            card_type.Items.Add(new ComboItem(-1, "CARD TYPE"));

            // ADD MEMBERCARD TYPE TO CARD_TYPE
            String queryString = "SELECT * FROM MEMBERCARD_TYPE WHERE (EXPIRY_DATE IS NULL OR GETDATE() <= EXPIRY_DATE) ORDER BY MEMBERCARD_TYPE_NAME";
            DataTable DT;
            using (DT = DB.getS(queryString, null, "GET LIMITED MEMBERCARD TYPE", false))
            {
                foreach (DataRow row in DT.Rows)
                {
                    card_type.Items.Add(new ComboItem(Convert.ToInt32(row["MEMBERCARD_TYPE_ID"].ToString()), row["MEMBERCARD_TYPE_NAME"].ToString()));
                }
            }

            card_type.Items.Add(new ComboItem(50, "GIFT CERTIFICATE"));
            //card_type.Items.Add(new ComboItem(99, "GIFT VOUCHER"));

            card_type.SelectedIndex = 0;
            GF.resizeComboBox(card_type);

            //UC EVENTS
            btn_dgv.DeleteClick += new btn_dgv.DeleteClickHandler(DeleteClick);
            btn_dgv.RefreshClick += new btn_dgv.RefreshClickHandler(doLoadGridData);
            btn_dgv.SearchClick += new btn_dgv.SearchClickHandler(doLoadGridData);

            //PAGING DELEGATE
            btn_dgv.firstClick += new btn_dgv.firstClickHandler(doLoadGridData);
            btn_dgv.prevClick += new btn_dgv.prevClickHandler(doLoadGridData);
            btn_dgv.nextClick += new btn_dgv.nextClickHandler(doLoadGridData);
            btn_dgv.lastClick += new btn_dgv.lastClickHandler(doLoadGridData);
            btn_dgv.pageNumberChanged += new btn_dgv.pageNumberChangedHandler(doLoadGridData);
        }

        void DeleteClick(object sender, EventArgs e) // ปรับไปเป็นปุ่มออกการ์ด เพราะจะ Enable เมื่อ click row
        {
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells["card_id"].Value);
            re_issue_card_approve approvePage;
            using (approvePage = new re_issue_card_approve())
            {
                approvePage.Visible = false;
                approvePage.Owner = this;
                approvePage.card_type = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells["card_type"].Value);
                approvePage.ShowDialog();
            }
        }

        void doLoadGridData(object sender, EventArgs e)
        {
            card_type_lbl.Top = issue_date_lbl.Top = GF.pageTop;
            card_type.Top = card_type_lbl.Top - 3;
            issue_date.Top = issue_date_lbl.Top - 2;

            line_sep1.Top = card_type_lbl.Top + 35; line_sep1.Width = btn_dgv.Width;
            btn_dgv.rearrange(line_sep1.Top + 15);

            btn_dgv.enable_btn.Visible = false;
            btn_dgv.add_btn.Visible = false;
            btn_dgv.edit_btn.Visible = false;
            btn_dgv.del_btn.Text = "RE-ISSUE";

            GF.resetAC(this);
            loadGridData();
        }
        // DELEGATE PART :: END

        public void loadGridData()
        {
            GF.showLoading(this);
            this.btn_dgv.DGV.Visible = false;
            this.btn_dgv.DGV.Rows.Clear();

            if (btn_dgv.DGV.Columns.Count == 0)
            {
                this.btn_dgv.DGV.Columns.Add("card_type_name", "CARD NAME");
                this.btn_dgv.DGV.Columns.Add("owner_name", "OWNER NAME");
                this.btn_dgv.DGV.Columns.Add("code", "CODE");
                this.btn_dgv.DGV.Columns.Add("detail", "DETAIL");
                this.btn_dgv.DGV.Columns.Add("issue_datetime", "ISSUED DATETIME");
                this.btn_dgv.DGV.Columns.Add("status", "STATUS");
                this.btn_dgv.DGV.Columns.Add("issue_by", "ISSUED BY");
                this.btn_dgv.DGV.Columns.Add("card_type", "card_type");
                this.btn_dgv.DGV.Columns.Add("card_id", "card_id");
                this.btn_dgv.DGV.Columns["card_type"].Visible = false;
                this.btn_dgv.DGV.Columns["card_id"].Visible = false;
                this.btn_dgv.DGV.Columns["status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // GET TOTAL PAGE
            Dictionary<string, string> Params = new Dictionary<string, string>();
            String queryString = @"
            SELECT A.*, ISNULL(B.FULLNAME, 'S.A.') ISSUE_BY_NAME FROM (
                (SELECT 
                    B.MEMBERCARD_TYPE_NAME CARD_TYPE_NAME, 
                    A.CARD_NO, 
                    Convert(NVARCHAR(MAX),A.PRICE) PRICE, 
                    A.ISSUE_DATE,
                    CONVERT(NVARCHAR(MAX), A.ISSUE_DATE, 103) + ' ' + CONVERT(NVARCHAR(MAX), A.ISSUE_DATE, 108) ISSUE_DATETIME, 
                    A.ISSUE_BY,
                    A.MEMBERCARD_TYPE_ID CARD_TYPE,
                    A.MEMBERCARD_ID CARD_ID,
                    C.CUSTOMER_NAME + '-' + C.TEL OWNER_NAME,
                    NULL SPA_PROGRAM,
                    A.IS_USE
                FROM MEMBERCARD A 
                INNER JOIN MEMBERCARD_TYPE B ON A.MEMBERCARD_TYPE_ID = B.MEMBERCARD_TYPE_ID
                INNER JOIN CUSTOMER C ON A.CUSTOMER_ID = C.CUSTOMER_ID
                WHERE B.IS_USE = 1)
                UNION ALL
                (SELECT
                    CASE A.SPA_PROGRAM_ID WHEN -1 THEN 'MONEY ' ELSE 'SPA MENU ' END + 'GIFT CERTIFICATE' CARD_TYPE_NAME,
                    A.CARD_NO,
                    Convert(NVARCHAR(MAX),A.PRICE) PRICE,
                    A.ISSUE_DATE,
                    CONVERT(NVARCHAR(MAX), A.ISSUE_DATE, 103) + ' ' + CONVERT(NVARCHAR(MAX), A.ISSUE_DATE, 108) ISSUE_DATETIME, 
                    A.ISSUE_BY,
                    50 CARD_TYPE,
                    A.GIFT_CERTIFICATE_ID CARD_ID,
                    B.CUSTOMER_NAME + '-' + B.TEL OWNER_NAME,
                    C.PROGRAM_NAME SPA_PROGRAM,
                    A.IS_USE
                FROM GIFT_CERTIFICATE A
                LEFT OUTER JOIN CUSTOMER B ON A.CUSTOMER_ID = B.CUSTOMER_ID
                LEFT OUTER JOIN SPA_PROGRAM C ON A.SPA_PROGRAM_ID = C.SPA_PROGRAM_ID
                )
                UNION ALL
                (SELECT
                    'GIFT VOUCHER' CARD_TYPE_NAME,
                    A.CARD_NO,
                    '-' PRICE,
                    A.ISSUE_DATETIME ISSUE_DATE,
                    CONVERT(NVARCHAR(MAX), A.ISSUE_DATETIME, 103) + ' ' + CONVERT(NVARCHAR(MAX), A.ISSUE_DATETIME, 108) ISSUE_DATETIME, 
                    A.ISSUE_BY,
                    99 CARD_TYPE,
                    A.GIFT_VOUCHER_ID,
                    A.ISSUE_FOR OWNER_NAME,
                    B.PROGRAM_NAME SPA_PROGRAM,
                    A.IS_USE
                FROM GIFT_VOUCHER A
                INNER JOIN SPA_PROGRAM B ON A.SPA_PROGRAM_ID = B.SPA_PROGRAM_ID
                )
            ) A LEFT OUTER JOIN EMPLOYEE B ON A.ISSUE_BY = B.EMP_ID WHERE 1=1";
            if (((ComboItem)card_type.SelectedItem).Key != -1)
            {
                queryString += " AND A.CARD_TYPE = " + ((ComboItem)card_type.SelectedItem).Key.ToString();
                //Params.Add("@card_type", ((ComboItem)card_type.SelectedItem).Key.ToString());
            }
            if (!GF.emptyDate(issue_date.Text.Trim()))
            {
                queryString += " AND CONVERT(DATE, ISSUE_DATE) = CONVERT(DATE, '" + issue_date.Text + "', 103)";
                //Params.Add("@issue_date", issue_date.Text);
            }

            GF.getTotalPage(btn_dgv, "SELECT COUNT(*) AS TOTAL FROM (" + queryString + ") AS TOTAL_ROW", Params);

            queryString = DB.insertRowNum("A.ISSUE_DATE DESC", queryString);
            GF.doDebug(">>>> " + queryString);
            DataTable myDT;
            using (myDT = DB.getS(queryString, Params, "GET ALL ISSUED CARDS"))
            {
                for (int rowNum = 0; rowNum < myDT.Rows.Count; rowNum++)
                {
                    DataRow myRow = myDT.Rows[rowNum];

                    String detail = "";
                    if (myRow["SPA_PROGRAM"].ToString() != "") detail = myRow["SPA_PROGRAM"].ToString();
                    else detail = GF.formatNumber(Convert.ToInt32(myRow["PRICE"].ToString()));

                    this.btn_dgv.DGV.Rows.Add(
                        myRow["CARD_TYPE_NAME"].ToString(),
                        myRow["OWNER_NAME"].ToString(),
                        myRow["CARD_NO"].ToString(),
                        detail,
                        myRow["ISSUE_DATETIME"].ToString(),
                        (myRow["IS_USE"].ToString() == "1" ? "ACTIVE": "INACTIVE"),
                        myRow["ISSUE_BY_NAME"].ToString(),
                        myRow["CARD_TYPE"].ToString(),
                        myRow["CARD_ID"].ToString()
                    );

                    btn_dgv.DGV.Rows[rowNum].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    if (myRow["IS_USE"].ToString() == "1") btn_dgv.DGV.Rows[rowNum].Cells["status"].Style.ForeColor = Color.Green;
                    else btn_dgv.DGV.Rows[rowNum].Cells["status"].Style.ForeColor = Color.Red;
                    this.btn_dgv.DGV.ClearSelection();
                }
            }

            GF.updateRowNum(btn_dgv.DGV, true);
            this.btn_dgv.DGV.Refresh();
            this.btn_dgv.DGV.Visible = true;
            GF.closeLoading();
        }
    }
}
