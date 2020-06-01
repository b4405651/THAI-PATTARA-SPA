using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.CUSTOMER
{
    public partial class customer : Form
    {
        public customer()
        {
            InitializeComponent();
            btn_dgv.refresh_btn.Text = "EXCEL";

            //UC EVENTS
            btn_dgv.EnableClick += new btn_dgv.EnableClickHandler(EnableClick);
            btn_dgv.AddClick += new btn_dgv.AddClickHandler(AddClick);
            btn_dgv.EditClick += new btn_dgv.EditClickHandler(EditClick);
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

        // DELEGATE PART :: BEGIN
        void EnableClick(object sender, EventArgs e)
        {
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells["CUSTOMER_ID"].Value);
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO ENABLE THIS CUSTOMER ?", "ENABLE CUSTOMER", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GF.showLoading(this);
                DB.beginTrans();
                if (DB.set("UPDATE CUSTOMER SET is_use = 1 WHERE customer_id = " + GF.selected_id, "ENABLE CUSTOMER[" + GF.selected_id.ToString() + "]"))
                {
                    DB.close();
                    //MessageBox.Show("CUSTOMER IS ENABLED.", "COMPLETED");
                    GF.closeLoading();
                    btn_dgv.refresh_btn.PerformClick();
                    return;
                }
                else
                {
                    GF.closeLoading();
                    MessageBox.Show("ERROR ENABLED CUSTOMER !!", "ERROR");
                    return;
                }
            }
        }
        void AddClick(object sender, EventArgs e)
        {
            GF.selected_id = 0;

            using (customer_manage managePage = new customer_manage())
            {
                managePage.Owner = this;
                managePage.manage_btn.Text = "ADD";
                managePage.Text = "ADD CUSTOMER";

                managePage.history_btn.Visible = false;
                managePage.membercard_btn.Visible = false;

                managePage.ShowDialog();
            }
        }
        void EditClick(object sender, EventArgs e)
        {
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells["customer_id"].Value);

            using (customer_manage managePage = new customer_manage())
            {
                managePage.Owner = this;
                managePage.manage_btn.Text = "UPDATE";
                managePage.Text = "EDIT CUSTOMER";

                managePage.ShowDialog();
            }
        }
        void DeleteClick(object sender, EventArgs e)
        {
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells["CUSTOMER_ID"].Value);
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO DISABLE THIS CUSTOMER ?", "DISABLE CUSTOMER", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GF.showLoading(this);
                DB.beginTrans();
                if (DB.set("UPDATE CUSTOMER SET is_use = 0 WHERE customer_id = " + GF.selected_id, "DISABLE CUSTOMER[" + GF.selected_id.ToString() + "]"))
                {
                    DB.close();
                    //MessageBox.Show("CUSTOMER IS DISABLED.", "COMPLETED");
                    GF.closeLoading();
                    btn_dgv.refresh_btn.PerformClick();
                    return;
                }
                else
                {
                    GF.closeLoading();
                    MessageBox.Show("ERROR DISABLED CUSTOMER !!", "ERROR");
                    return;
                }
            }
        }

        void doLoadGridData(object sender, EventArgs e)
        {
            customer_data_lbl.Top = code_lbl.Top = GF.pageTop;
            customer_data.Top = code.Top = customer_data_lbl.Top - 3;
            only_neighbor.Top = only_member.Top = customer_data_lbl.Top;

            line_sep1.Top = customer_data_lbl.Top + 35; line_sep1.Width = btn_dgv.Width;
            btn_dgv.rearrange(line_sep1.Top + 15);
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
                this.btn_dgv.DGV.Columns.Add("code", "CODE");
                this.btn_dgv.DGV.Columns.Add("customer_name", "CUSTOMER NAME");
                this.btn_dgv.DGV.Columns.Add("rus_name", "RUSSIAN NAME");
                this.btn_dgv.DGV.Columns.Add("gender", "GENDER");
                this.btn_dgv.DGV.Columns.Add("tel", "PHONE NO.");
                this.btn_dgv.DGV.Columns.Add("email", "E-MAIL");
                this.btn_dgv.DGV.Columns.Add("birthday", "BIRTH DAY");
                this.btn_dgv.DGV.Columns.Add("wedding_anniversary", "WEDDING ANNIVERSARY");
                this.btn_dgv.DGV.Columns.Add("is_use", "ACTIVE");
                this.btn_dgv.DGV.Columns.Add("customer_id", "CUSTOMER_ID");
                this.btn_dgv.DGV.Columns["customer_id"].Visible = false;
            }

            Dictionary<string, string> Params = new Dictionary<string, string>();

            String queryString = @"
            SELECT 
                A.customer_id
                ,A.customer_name
                ,A.rus_name
                ,A.code
                ,A.gender
                ,A.tel
                ,A.email
                ,CONVERT(VARCHAR,A.birthday,103) birthday
                ,A.wedding_anniversary
                ,A.register_date
                ,A.is_use
            FROM CUSTOMER A ";

            if (only_member.Checked) queryString += "INNER JOIN MEMBERCARD B ON A.CUSTOMER_ID = B.CUSTOMER_ID";
            queryString += " WHERE 1=1 ";
            if (customer_data.Text.Trim() != "")
            {
                queryString += "AND (A.CUSTOMER_NAME LIKE '%" + customer_data.Text + "%' OR A.TEL LIKE '%" + customer_data.Text + "%') ";
                //Params.Add("@customer_data", customer_data.Text);
            }
            if (code.Text.Trim() != "")
            {
                queryString += "AND A.CODE LIKE '%' + " + code.Text + " + '%' ";
                //Params.Add("@code", code.Text);
            }
            if (only_neighbor.Checked) queryString += "AND A.IS_NEIGHBOR = 1 ";

            // GET TOTAL PAGE
            GF.getTotalPage(btn_dgv, queryString, Params);

            queryString = DB.insertRowNum("CUSTOMER_NAME", queryString);
            GF.doDebug(">>>> " + queryString);
            using (DataTable myDT = DB.getS(queryString, Params, "GET ALL CUSTOMER"))
            {

                for (int rowNum = 0; rowNum < myDT.Rows.Count; rowNum++)
                {
                    this.btn_dgv.DGV.Rows.Add(
                        myDT.Rows[rowNum]["code"],
                        myDT.Rows[rowNum]["customer_name"],
                        myDT.Rows[rowNum]["rus_name"],
                        (myDT.Rows[rowNum]["gender"].ToString() == "0" ? "FEMALE" : "MALE"),
                        myDT.Rows[rowNum]["tel"],
                        myDT.Rows[rowNum]["email"],
                        myDT.Rows[rowNum]["birthday"],
                        (myDT.Rows[rowNum]["wedding_anniversary"].ToString() == "" || myDT.Rows[rowNum]["wedding_anniversary"].ToString() == "NULL" ? "" : myDT.Rows[rowNum]["wedding_anniversary"].ToString()),
                        (myDT.Rows[rowNum]["is_use"].ToString() == "1" ? "ACTIVE" : "INACTIVE"),
                        myDT.Rows[rowNum]["customer_id"]
                    );

                    this.btn_dgv.DGV["is_use", rowNum].Style.ForeColor = (myDT.Rows[rowNum]["is_use"].ToString() == "1" ? Color.Green : Color.Red);
                    this.btn_dgv.DGV[1, rowNum].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    this.btn_dgv.DGV[2, rowNum].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }

            GF.updateRowNum(btn_dgv.DGV, true);
            this.btn_dgv.DGV.Refresh();
            this.btn_dgv.DGV.Visible = true;
            GF.closeLoading();
        }

        private void card_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadGridData();
            }
        }

        private void only_member_CheckedChanged(object sender, EventArgs e)
        {
            loadGridData();
        }

        private void only_neighbor_CheckedChanged(object sender, EventArgs e)
        {
            loadGridData();
        }

        private void code_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void code_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (code.Text.Trim().Length > 12) code.Text = code.Text.Trim().Substring(0, 12);
                loadGridData();
            }
        }
    }
}
