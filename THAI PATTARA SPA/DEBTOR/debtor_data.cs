using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.DEBTOR
{
    public partial class debtor_data : Form
    {
        String queryString = "";
        public debtor_data()
        {
            InitializeComponent();

            GF.addKeyUp(this);

            debtor_type_id.Items.Add(new ComboItem(-1, "ALL"));
            queryString = "SELECT * FROM DEBTOR_TYPE ORDER BY DEBTOR_TYPE_ID";
            using (DataTable DT = DB.getS(queryString, null, "GET DEBTOR_TYPE", false))
            {
                foreach (DataRow row in DT.Rows)
                {
                    debtor_type_id.Items.Add(new ComboItem(Convert.ToInt32(row["DEBTOR_TYPE_ID"].ToString()), row["DEBTOR_TYPE_NAME"].ToString()));
                }
            }
            debtor_type_id.SelectedIndex = 0;

            btn_dgv.refresh_btn.Text = "DEBT LIST";
            GF.disableButton(btn_dgv.refresh_btn);

            btn_dgv.DGV.SelectionChanged += (s, e) =>
            {
                if (btn_dgv.DGV.SelectedRows.Count == 1)
                    GF.enableButton(btn_dgv.refresh_btn);
                else
                    GF.disableButton(btn_dgv.refresh_btn);
            };

            //UC EVENTS
            btn_dgv.AddClick += new btn_dgv.AddClickHandler(AddClick);
            btn_dgv.EditClick += new btn_dgv.EditClickHandler(EditClick);
            btn_dgv.DeleteClick += new btn_dgv.DeleteClickHandler(DeleteClick);
            btn_dgv.EnableClick += new btn_dgv.EnableClickHandler(EnableClick);
            btn_dgv.RefreshClick += new btn_dgv.RefreshClickHandler(DebtListClick); // USE REFRESH BUTTON AS DEBT LIST BUTTON
            btn_dgv.SearchClick += new btn_dgv.SearchClickHandler(doLoadGridData);

            //PAGING DELEGATE
            btn_dgv.firstClick += new btn_dgv.firstClickHandler(doLoadGridData);
            btn_dgv.prevClick += new btn_dgv.prevClickHandler(doLoadGridData);
            btn_dgv.nextClick += new btn_dgv.nextClickHandler(doLoadGridData);
            btn_dgv.lastClick += new btn_dgv.lastClickHandler(doLoadGridData);
            btn_dgv.pageNumberChanged += new btn_dgv.pageNumberChangedHandler(doLoadGridData);
        }

        // DELEGATE PART :: BEGIN
        void AddClick(object sender, EventArgs e)
        {
            using (debtor_manage managePage = new debtor_manage())
            {
                managePage.Owner = this;
                managePage.id = -1;
                managePage.manage_btn.Text = "ADD";
                managePage.Text = "ADD DEBTOR DATA";

                managePage.ShowDialog();
            }
        }
        void EditClick(object sender, EventArgs e)
        {
            using (debtor_manage managePage = new debtor_manage())
            {
                managePage.Owner = this;
                managePage.manage_btn.Text = "UPDATE";
                managePage.id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells["debtor_id"].Value);
                managePage.Text = "EDIT DEBTOR DATA";

                managePage.ShowDialog();
            }
        }
        void DeleteClick(object sender, EventArgs e)
        {
            string the_id = btn_dgv.DGV.SelectedRows[0].Cells["debtor_id"].Value.ToString();
            queryString = "UPDATE DEBTOR SET IS_USE = 0 WHERE DEBTOR_ID = " + the_id;
            GF.showLoading(this);
            if (!DB.set(queryString, "DISABLE DEBTOR[" + the_id + "]"))
            {
                MessageBox.Show("ERROR DISABLE THE DEBTOR !!", "ERROR");
                GF.closeLoading();
            }
            DB.close();
            GF.closeLoading();
            loadGridData();
        }
        void EnableClick(object sender, EventArgs e)
        {
            string the_id = btn_dgv.DGV.SelectedRows[0].Cells["debtor_id"].Value.ToString();
            queryString = "UPDATE DEBTOR SET IS_USE = 1 WHERE DEBTOR_ID = " + the_id;
            GF.showLoading(this);
            if (!DB.set(queryString, "ENABLE DEBTOR[" + the_id + "]"))
            {
                MessageBox.Show("ERROR ENABLE THE DEBTOR !!", "ERROR");
                GF.closeLoading();
            }
            DB.close();
            GF.closeLoading();
            loadGridData();
        }

        void DebtListClick(object sender, EventArgs e)
        {
            using (debt_list debtList = new debt_list())
            {
                debtList.Owner = this;
                debtList.id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells["debtor_id"].Value);

                debtList.ShowDialog();
            }
        }

        void doLoadGridData(object sender, EventArgs e)
        {
            debtor_name_lbl.Top = tel_lbl.Top = debtor_type_lbl.Top = GF.pageTop;
            debtor_name.Top = tel.Top = debtor_name_lbl.Top - 3;
            debtor_type_id.Top = debtor_type_lbl.Top - 3;

            line_sep1.Top = debtor_name_lbl.Top + 35; line_sep1.Width = btn_dgv.Width;
            btn_dgv.rearrange(line_sep1.Top + 15);

            btn_dgv.del_btn.Text = "DISABLE";

            GF.resetAC(this);
            loadGridData();
        }
        // DELEGATE PART :: END

        public void loadGridData()
        {
            GF.showLoading(this);
            this.btn_dgv.DGV.Rows.Clear();

            if (btn_dgv.DGV.Columns.Count == 0)
            {
                this.btn_dgv.DGV.Columns.Add("debtor_name", "NAME");
                this.btn_dgv.DGV.Columns.Add("tel", "TEL");
                this.btn_dgv.DGV.Columns.Add("debtor_type_name", "TYPE");
                this.btn_dgv.DGV.Columns.Add("debtor_amount", "AMOUNT");
                this.btn_dgv.DGV.Columns.Add("is_use", "ACTIVE");
                this.btn_dgv.DGV.Columns.Add("debtor_id", "DEBTOR_ID");

                this.btn_dgv.DGV.Columns["is_use"].Visible = false;
                this.btn_dgv.DGV.Columns["debtor_id"].Visible = false;
            }

            // GET TOTAL PAGE

            Dictionary<string, string> Params = new Dictionary<string, string>();

            queryString = @"
            SELECT A.*, B.DEBTOR_TYPE_NAME, ISNULL(C.SUM_AMOUNT, 0) SUM_AMOUNT FROM
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
            LEFT OUTER JOIN (
	            SELECT DEBTOR_ID, SUM(AMOUNT) SUM_AMOUNT FROM DEBTOR_DATA
	            WHERE IS_VOID = 0 AND IS_PAID = 0
	            GROUP BY DEBTOR_ID
            ) C ON A.DEBTOR_ID = C.DEBTOR_ID
            WHERE 1=1";

            if (debtor_name.Text.Trim() != "")
            {
                queryString += " AND A.NAME = '%' + " + debtor_name.Text + " + '%'";
                //Params.Add("@debtor_name", debtor_name.Text);
            }
            if (tel.Text.Trim() != "")
            {
                queryString += " AND A.TEL = '%' + " + tel.Text + " + '%'";
                //Params.Add("@tel", tel.Text);
            }
            if (((ComboItem)this.debtor_type_id.SelectedItem).Key != -1) queryString += " AND A.DEBTOR_TYPE_ID = " + ((ComboItem)this.debtor_type_id.SelectedItem).Key.ToString();

            GF.getTotalPage(btn_dgv, queryString, Params);

            queryString = DB.insertRowNum("A.NAME, A.TEL", queryString);
            using (DataTable DT = DB.getS(queryString, Params, "GET ALL DEBTOR"))
            {
                int rowNum = 0;
                foreach (DataRow myRow in DT.Rows)
                {
                    this.btn_dgv.DGV.Rows.Add(
                        myRow["NAME"],
                        myRow["TEL"],
                        myRow["DEBTOR_TYPE_NAME"],
                        GF.formatNumber(Convert.ToInt32(myRow["SUM_AMOUNT"].ToString())),
                        (myRow["IS_USE"].ToString() == "1" ? "ACTIVE" : "INACTIVE"),
                        myRow["DEBTOR_ID"]
                    );

                    if (myRow["IS_USE"].ToString() == "0") this.btn_dgv.DGV.Rows[rowNum].DefaultCellStyle.BackColor = Color.LightCoral;
                    this.btn_dgv.DGV[0, rowNum].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    rowNum++;
                }
            }

            GF.updateRowNum(btn_dgv.DGV, true);
            this.btn_dgv.DGV.ClearSelection();
            GF.closeLoading();
        }
    }
}
