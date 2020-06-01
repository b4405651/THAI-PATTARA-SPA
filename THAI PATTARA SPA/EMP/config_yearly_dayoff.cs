using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.EMP
{
    public partial class config_yearly_dayoff : Form
    {
        public config_yearly_dayoff()
        {
            InitializeComponent();

            getYear();

            //UC EVENTS
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
        void AddClick(object sender, EventArgs e)
        {
            GF.selected_id = 0;

            using (config_yearly_dayoff_manage managePage = new config_yearly_dayoff_manage())
            {
                managePage.Owner = this;
                managePage.manage_btn.Text = "ADD";
                managePage.Text = "ADD EMPLOYEE YEARLY DAYOFF";

                managePage.ShowDialog();
            }
        }
        void EditClick(object sender, EventArgs e)
        {
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells[btn_dgv.DGV.Columns.Count - 1].Value);

            using (config_yearly_dayoff_manage editPage = new config_yearly_dayoff_manage())
            {
                editPage.Owner = this;
                editPage.manage_btn.Text = "UPDATE";
                editPage.Text = "EDIT EMPLOYEE YEARLY DAYOFF";

                editPage.ShowDialog();
            }
        }
        void DeleteClick(object sender, EventArgs e)
        {
            GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells[btn_dgv.DGV.Columns.Count - 1].Value);
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO DELETE THIS ITEM ?", "DELETE ITEM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GF.showLoading(this);
                DB.beginTrans();
                if (DB.set("DELETE FROM EMP_CONFIG_YEARLY_DAYOFF WHERE emp_config_yearly_dayoff_id = " + GF.selected_id, "DELETE YEARLY DAYOFF[" + GF.selected_id + "]"))
                {
                    DB.close();
                    MessageBox.Show("DAYOFF IS DELETED.", "COMPLETED");
                    GF.closeLoading();
                    getYear(Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells[1].Value));
                    btn_dgv.refresh_btn.PerformClick();
                }
                else
                {
                    GF.closeLoading();
                    MessageBox.Show("ERROR DELETING DATA !!", "ERROR");
                    return;
                }
            }
        }

        void doLoadGridData(object sender, EventArgs e)
        {
            year_lbl.Top = GF.pageTop;
            year.Top = year_lbl.Top - 3;

            line_sep1.Top = year_lbl.Top + 35; line_sep1.Width = btn_dgv.Width;
            btn_dgv.rearrange(line_sep1.Top + 15);

            if (year.Items.Count == 1 && ((ComboItem)year.Items[0]).Key == -1)
            {
                MessageBox.Show("NO YEARLY DAYOFF DATA. PLEASE CREATE ONE !!", "ERROR");
                return;
            }
            else
            {
                GF.resetAC(this);
                loadGridData();
            }
        }
        // DELEGATE PART :: END

        public void loadGridData()
        {
            GF.showLoading(this);
            this.btn_dgv.DGV.Rows.Clear();

            if (btn_dgv.DGV.Columns.Count == 0)
            {
                this.btn_dgv.DGV.Columns.Add("year_no", "YEAR");
                this.btn_dgv.DGV.Columns.Add("day_name", "DAY NAME");
                this.btn_dgv.DGV.Columns.Add("start_date", "START DATE");
                this.btn_dgv.DGV.Columns.Add("end_date", "END DATE");
                this.btn_dgv.DGV.Columns.Add("emp_config_yearly_dayoff_id", "EMP_CONFIG_YEARLY_DAYOFF_ID");
                this.btn_dgv.DGV.Columns["emp_config_yearly_dayoff_id"].Visible = false;
            }

            // GET TOTAL PAGE
            String queryString = @"SELECT EMP_CONFIG_YEARLY_DAYOFF_ID, YEAR_NO, DAY_NAME, CONVERT(VARCHAR,START_DATE,103) START_DATE, CONVERT(VARCHAR,END_DATE,103) END_DATE FROM EMP_CONFIG_YEARLY_DAYOFF WHERE 1=1";

            if (((ComboItem)this.year.SelectedItem).Key != -1) queryString += " AND year_no = " + ((ComboItem)this.year.SelectedItem).Key.ToString(); ;

            GF.getTotalPage(btn_dgv, queryString, null);

            queryString = DB.insertRowNum("year_no DESC, start_date ASC", queryString);
            using (DataTable myDT = DB.getS(queryString, null, "GET ALL EMP CONFIG YEARLY_DAYOFF"))
            {
                int rowNum = 0;
                foreach (DataRow myRow in myDT.Rows)
                {
                    this.btn_dgv.DGV.Rows.Add(
                        myRow["year_no"],
                        myRow["day_name"].ToString().Trim(),
                        myRow["start_date"].ToString().Split(' ')[0].ToString(),
                        myRow["end_date"].ToString().Split(' ')[0].ToString(),
                        myRow["emp_config_yearly_dayoff_id"]
                    );

                    this.btn_dgv.DGV[1, rowNum].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    rowNum++;
                }
            }
            GF.updateRowNum(btn_dgv.DGV, true);
            this.btn_dgv.DGV.ClearSelection();
            GF.closeLoading();
        }

        public void getYear(int year_no = -1)
        {
            year.Items.Clear();

            using (DataTable myDT = DB.getS("SELECT DISTINCT YEAR_NO FROM EMP_CONFIG_YEARLY_DAYOFF ORDER BY YEAR_NO DESC", null, "GET YEAR FOR YEARLY DAYOFF", false))
            {
                if (myDT.Rows.Count == 0)
                {
                    year.Items.Add(new ComboItem(-1, "NO DATA"));
                }
                else
                {
                    foreach (DataRow row in myDT.Rows)
                    {
                        year.Items.Add(new ComboItem(Convert.ToInt32(row["YEAR_NO"].ToString()), row["YEAR_NO"].ToString()));
                    }
                }
            }
            if (year_no == -1) year.SelectedIndex = 0;
            else
            {
                int index = -1;
                for(int i = 0; i < year.Items.Count; i++){
                    if (((ComboItem)year.Items[i]).Key == year_no)
                    {
                        index = i;
                        break;
                    }
                }
                if (index != -1) year.SelectedIndex = index;
                else year.SelectedIndex = 0;
            }
        }
    }
}
