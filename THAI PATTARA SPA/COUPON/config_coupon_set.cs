using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.COUPON
{
    public partial class config_coupon_set : Form
    {
        String queryString = "";
        
        public config_coupon_set()
        {
            InitializeComponent();
            GF.addKeyUp(this);
            btn_dgv.search_btn.Visible = false;
            btn_dgv.DGV.SelectionChanged += (ss, ee) =>
            {
                if (btn_dgv.DGV.SelectedRows.Count == 1)
                {
                    if (btn_dgv.DGV.SelectedRows[0].Cells["status"].Value.ToString() == "ACTIVE") btn_dgv.del_btn.Text = "DISABLE";
                    if (btn_dgv.DGV.SelectedRows[0].Cells["status"].Value.ToString() == "INACTIVE") btn_dgv.del_btn.Text = "ENABLE";
                }
            };

            //UC EVENTS
            btn_dgv.AddClick += new btn_dgv.AddClickHandler(AddClick);
            btn_dgv.EditClick += new btn_dgv.EditClickHandler(EditClick);
            btn_dgv.DeleteClick += new btn_dgv.DeleteClickHandler(DeleteClick);
            btn_dgv.EnableClick += new btn_dgv.EnableClickHandler(EnableClick);
            btn_dgv.RefreshClick += new btn_dgv.RefreshClickHandler(doLoadGridData);

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
            using (config_coupon_set_manage managePage = new config_coupon_set_manage())
            {
                managePage.Owner = this;
                managePage.id = -1;
                managePage.ShowDialog();
            }
        }
        void EditClick(object sender, EventArgs e)
        {
            using (config_coupon_set_manage managePage = new config_coupon_set_manage())
            {
                managePage.Owner = this;
                managePage.id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells["coupon_set_config_id"].Value.ToString());
                managePage.ShowDialog();
            }
        }
        void DeleteClick(object sender, EventArgs e)
        {
            string the_id = btn_dgv.DGV.SelectedRows[0].Cells[btn_dgv.DGV.Columns.Count - 1].Value.ToString();
            string is_use = (btn_dgv.del_btn.Text == "DISABLE" ? "0" : "1");
            queryString = "UPDATE COUPON_SET_CONFIG SET IS_USE = " + is_use + " WHERE COUPON_SET_CONFIG_ID = " + the_id;
            GF.showLoading(this);
            if (!DB.set(queryString, btn_dgv.del_btn.Text + " COUPON_SET_CONFIG[" + the_id + "]"))
            {
                MessageBox.Show("ERROR " + btn_dgv.del_btn.Text + " THE COUPON SET !!", "ERROR");
                GF.closeLoading();
            }
            DB.close();
            GF.closeLoading();
            loadData();
        }
        void EnableClick(object sender, EventArgs e)
        {
            string the_id = btn_dgv.DGV.SelectedRows[0].Cells[btn_dgv.DGV.Columns.Count - 1].Value.ToString();
            queryString = "UPDATE COUPON_SET_CONFIG SET IS_USE = 1 WHERE COUPON_SET_CONFIG_ID = " + the_id;
            GF.showLoading(this);
            if (!DB.set(queryString, "ENABLE COUPON_SET_CONFIG[" + the_id + "]"))
            {
                MessageBox.Show("ERROR ENABLE THE COUPON SET !!", "ERROR");
                GF.closeLoading();
            }
            DB.close();
            GF.closeLoading();
            loadData();
        }

        void doLoadGridData(object sender, EventArgs e)
        {
            loadData();
        }

        private void config_coupon_Load(object sender, EventArgs e)
        {
            btn_dgv.rearrange(GF.pageTop);
            //btn_dgv.DGV.Height += 90;
            //btn_dgv.paging_panel.Top += 90;
            initDGV();
            loadData();
        }

        private void initDGV()
        {
            this.btn_dgv.DGV.Rows.Clear();

            if (btn_dgv.DGV.Columns.Count == 0)
            {
                this.btn_dgv.DGV.Columns.Add("coupon_set_name", "COUPON SET NAME");
                this.btn_dgv.DGV.Columns.Add("detail", "DETAIL");
                this.btn_dgv.DGV.Columns.Add("price", "PRICE");
                this.btn_dgv.DGV.Columns.Add("expire", "EXPIRE");
                this.btn_dgv.DGV.Columns.Add("created_datetime", "CREATE DATETIME");
                this.btn_dgv.DGV.Columns.Add("status", "STATUS");
                this.btn_dgv.DGV.Columns.Add("coupon_set_config_id", "COUPON_SET_CONFIG_ID");

                this.btn_dgv.DGV.Columns["coupon_set_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.btn_dgv.DGV.Columns["detail"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.btn_dgv.DGV.Columns["coupon_set_config_id"].Visible = false;
            }
        }

        private void loadData()
        {
            GF.showLoading(this);
            btn_dgv.DGV.Rows.Clear();
            queryString = @"
            SELECT 
	            A.COUPON_SET_CONFIG_ID,
	            A.COUPON_SET_NAME,
                A.PRICE,
                A.EXPIRE_AMOUNT,
                A.EXPIRE_UNIT,
	            (
			            SELECT 
				            CASE WHEN (C.CODE IS NULL) THEN 'ALL SPA PROGRAM' ELSE '#' + C.CODE END + ' x ' + CONVERT(NVARCHAR(MAX), B.AMOUNT) + ', ' 
			            FROM COUPON_SET_CONFIG_DETAIL B
			            LEFT OUTER JOIN SPA_PROGRAM C ON B.SPA_PROGRAM_ID = C.SPA_PROGRAM_ID
			            WHERE B.COUPON_SET_CONFIG_ID = A.COUPON_SET_CONFIG_ID
			            ORDER BY C.CODE
			            For XML PATH ('')
	            ) PROGRAM_LIST, 
	            A.CREATE_DATETIME,
	            A.IS_USE
            FROM COUPON_SET_CONFIG A";
            
            GF.getTotalPage(btn_dgv, queryString, null);
            queryString = DB.insertRowNum("A.CREATE_DATETIME DESC", queryString);

            using (DataTable DT = DB.getS(queryString, null, "GET COUPON SET AND ITS DETAIL"))
            {
                foreach (DataRow row in DT.Rows)
                {
                    btn_dgv.DGV.Rows.Add(
                        row["COUPON_SET_NAME"].ToString(),
                        row["PROGRAM_LIST"].ToString().Trim().Substring(0, row["PROGRAM_LIST"].ToString().Trim().Length - 1),
                        GF.formatNumber(Convert.ToInt32(row["PRICE"].ToString())),
                        row["EXPIRE_AMOUNT"].ToString() + " " + (row["EXPIRE_UNIT"].ToString() == "1" ? "YEAR" : "MONTH"),
                        GF.formatDateTime(row["CREATE_DATETIME"].ToString()),
                        (row["IS_USE"].ToString() == "1" ? "ACTIVE" : "INACTIVE"),
                        row["COUPON_SET_CONFIG_ID"].ToString()
                    );
                    if(row["IS_USE"].ToString() == "0")
                        this.btn_dgv.DGV.Rows[this.btn_dgv.DGV.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGray;
                }
                this.btn_dgv.DGV.ClearSelection();
                GF.updateRowNum(btn_dgv.DGV, true);
            }
            GF.closeLoading();
        }
    }
}
