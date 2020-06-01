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
    public partial class user_page : Form
    {
        public user_page()
        {
            InitializeComponent();

            status.Items.Add(new ComboItem(1, "ACTIVE"));
            status.Items.Add(new ComboItem(0, "INACTIVE"));
            status.SelectedIndex = 0;

            btn_dgv.refresh_btn.Enabled = false;
            btn_dgv.refresh_btn.Text = "PRINT BARCODE";
            btn_dgv.refresh_btn.Width += 100;
            btn_dgv.search_btn.Left += 100;

            btn_dgv.DGV.SelectionChanged += (ss, ee) =>
            {
                if (btn_dgv.DGV.SelectedRows.Count == 1)
                    GF.enableButton(btn_dgv.refresh_btn);
                else
                    GF.disableButton(btn_dgv.refresh_btn);
            };

            //UC EVENTS
            btn_dgv.EnableClick += new btn_dgv.EnableClickHandler(EnableClick);
            btn_dgv.AddClick += new btn_dgv.AddClickHandler(AddClick);
            btn_dgv.EditClick += new btn_dgv.EditClickHandler(EditClick);
            btn_dgv.DeleteClick += new btn_dgv.DeleteClickHandler(DeleteClick);
            btn_dgv.RefreshClick += new btn_dgv.RefreshClickHandler(RefreshClick); // PRINT BARCODE
            btn_dgv.SearchClick += new btn_dgv.SearchClickHandler(doLoadGridData);

            //PAGING DELEGATE
            btn_dgv.firstClick += new btn_dgv.firstClickHandler(doLoadGridData);
            btn_dgv.prevClick += new btn_dgv.prevClickHandler(doLoadGridData);
            btn_dgv.nextClick += new btn_dgv.nextClickHandler(doLoadGridData);
            btn_dgv.lastClick += new btn_dgv.lastClickHandler(doLoadGridData);
            btn_dgv.pageNumberChanged += new btn_dgv.pageNumberChangedHandler(doLoadGridData);
        }
        // DELEGATE PART :: BEGIN
        void RefreshClick(object sender, EventArgs e)
        {
            string queryString = @"
                SELECT 
                    A.UNIQUE_KEY THE_CODE,
                    A.EMP_ID, 
                    B.FULLNAME
                FROM USERS A
                LEFT OUTER JOIN EMPLOYEE B ON A.EMP_ID = B.EMP_ID
                WHERE A.USER_ID = " + btn_dgv.DGV.SelectedRows[0].Cells["USER_ID"].Value.ToString();
            using (DataTable DT = DB.getS(queryString, null, "GET CODE, NAME FOR EMPLOYEE BARCODE", false))
            {
                PRINT.initPrint(false, "EMPLOYEE_BARCODE", "", this, false, false, false, DT.Rows[0]["THE_CODE"].ToString(), "", (DT.Rows[0]["EMP_ID"].ToString() == "0" ? "SYSTEM ADMINISTRATOR" : DT.Rows[0]["FULLNAME"].ToString()));
            }
        }
        void EnableClick(object sender, EventArgs e)
        {
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells[btn_dgv.DGV.Columns.Count - 1].Value);
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO ENABLE THIS USER ?", "ENABLE USER", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GF.showLoading(this);
                DB.beginTrans();
                if (DB.set("UPDATE USERS SET is_use = 1 WHERE user_id = " + GF.selected_id, "ENABLE USER"))
                {
                    DB.close();
                    GF.closeLoading();
                    loadGridData();
                }
                else
                {
                    GF.closeLoading();
                    MessageBox.Show("ERROR ENABLE DATA !!", "ERROR");
                    return;
                }
            }
        }
        void AddClick(object sender, EventArgs e)
        {
            using (users_add usersAdd = new users_add())
            {
                usersAdd.Owner = this;
                usersAdd.ShowDialog();
            }
        }
        void EditClick(object sender, EventArgs e)
        {
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells[btn_dgv.DGV.Columns.Count - 1].Value);
            using (users_edit usersEdit = new users_edit())
            {
                usersEdit.Owner = this;
                usersEdit.ShowDialog();
            }
        }
        void DeleteClick(object sender, EventArgs e)
        {
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells[btn_dgv.DGV.Columns.Count - 1].Value);
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO DISABLE THIS USER ?", "DISABLE USER", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GF.showLoading(this);
                DB.beginTrans();
                if (DB.set("UPDATE USERS SET is_use = 0 WHERE user_id = " + GF.selected_id, "DISABLE USER"))
                {
                    DB.close();
                    GF.closeLoading();
                    loadGridData();
                }
                else
                {
                    GF.closeLoading();
                    MessageBox.Show("ERROR DISABLE DATA !!", "ERROR");
                    return;
                }
            }
        }
        
        void doLoadGridData(object sender, EventArgs e)
        {
            username_lbl.Top = created_since_lbl.Top = GF.pageTop;
            username.Top = create_since.Top = username_lbl.Top - 3;

            owner_lbl.Top = created_by_lbl.Top = username_lbl.Top + 26;
            owner.Top = created_by.Top = owner_lbl.Top - 3;

            last_login_lbl.Top = status_lbl.Top = owner_lbl.Top + 26;
            last_login.Top = last_login_lbl.Top - 2;
            status.Top = status_lbl.Top - 2;

            line_sep1.Top = last_login_lbl.Top + 35; line_sep1.Width = btn_dgv.Width;
            btn_dgv.rearrange(line_sep1.Top + 15);

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
                this.btn_dgv.DGV.Columns.Add("username", "USERNAME");
                this.btn_dgv.DGV.Columns.Add("owner", "OWNER");
                this.btn_dgv.DGV.Columns.Add("last_login", "LAST LOGIN");
                this.btn_dgv.DGV.Columns.Add("created_date", "CREATED SINCE");
                this.btn_dgv.DGV.Columns.Add("created_by", "CREATED BY");
                this.btn_dgv.DGV.Columns.Add("is_use", "STATUS");
                this.btn_dgv.DGV.Columns.Add("user_id", "USER ID");
                this.btn_dgv.DGV.Columns["user_id"].Visible = false;
            }

            // GET TOTAL PAGE
            String queryString = @"SELECT 
                    A.user_id, 
                    A.username,
                    B.fullname owner,
                    CONVERT(VARCHAR, A.last_login, 103) + ' ' + CONVERT(VARCHAR, A.last_login, 108) last_login, 
                    CONVERT(VARCHAR, A.created_date, 103) + ' ' + CONVERT(VARCHAR, A.created_date, 108) created_date, 
                    D.fullname created_fullname, 
                    A.is_use
                FROM 
                    USERS A
                LEFT OUTER JOIN
                    EMPLOYEE B ON A.emp_id = B.emp_id
                INNER JOIN
                    USERS C ON A.created_by = C.user_id
                LEFT OUTER JOIN
                    EMPLOYEE D ON C.emp_id = D.emp_id
                WHERE
                    A.username NOT LIKE 'admin' 
                    AND A.is_use = " + ((ComboItem)status.SelectedItem).Key.ToString() + " ";

            Dictionary<string, string> Params = new Dictionary<string, string>();

            if (username.Text.Trim() != "")
            {
                queryString += "AND A.username LIKE '%" + username.Text + "%' ";
                //Params.Add("@username", username.Text);
            }
            if (owner.Text.Trim() != "")
            {
                queryString += "AND B.fullname LIKE '%" + owner.Text + "%' ";
                //Params.Add("@owner", owner.Text);
            }
            if (created_by.Text.Trim() != "")
            {
                queryString += "AND D.fullname LIKE '%" + created_by.Text + "%' ";
                //Params.Add("@created_by", created_by.Text);
            }
            if (!GF.emptyDate(create_since.Text.Trim()))
            {
                queryString += "AND A.created_date = " + GF.modDate(create_since.Text.Trim()) + " ";
                //Params.Add("@created_date", GF.modDate(create_since.Text.Trim()));
            }
            if (!GF.emptyDate(last_login.Text.Trim()))
            {
                queryString += "AND A.last_login = " + GF.modDate(last_login.Text.Trim()) + " ";
                //Params.Add("@last_login", GF.modDate(last_login.Text.Trim()));
            }

            GF.getTotalPage(btn_dgv, queryString, Params);

            using (DataTable myDT = DB.getS(DB.insertRowNum("username, owner, created_fullname, is_use DESC", queryString), Params, "GET ALL USER"))
            {
                int rowNum = 0;
                foreach (DataRow myRow in myDT.Rows)
                {
                    String is_use = "";
                    if (myRow["owner"].ToString() == "")
                    {
                        myRow["owner"] = "S.A.";
                    }
                    if (myRow["created_fullname"].ToString() == "")
                    {
                        myRow["created_fullname"] = "S.A.";
                    }
                    if (myRow["is_use"].ToString() == "1")
                    {
                        is_use = "ACTIVE";
                    }
                    else
                    {
                        is_use = "INACTIVE";
                    }

                    this.btn_dgv.DGV.Rows.Add(
                        myRow["username"],
                        myRow["owner"],
                        myRow["last_login"],
                        myRow["created_date"],
                        myRow["created_fullname"],
                        is_use,
                        myRow["user_id"]
                    );

                    this.btn_dgv.DGV["is_use", rowNum].Style.ForeColor = (myRow["is_use"].ToString() == "1" ? Color.Green : Color.Red);
                    this.btn_dgv.DGV[0, rowNum].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    this.btn_dgv.DGV[1, rowNum].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    rowNum++;
                }
            }
            GF.updateRowNum(btn_dgv.DGV, true);
            this.btn_dgv.DGV.ClearSelection();
            GF.closeLoading();
        }
    }
}
