using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.AGENT
{
    public partial class contract_rate : Form
    {
        String queryString = "";
        public string agent_id = "-1";
        public contract_rate()
        {
            InitializeComponent();
            this.Height = 800;
            GF.addKeyUp(this);
            btn_dgv.Left = 10;
            btn_dgv.refresh_btn.Visible = false;
            btn_dgv.search_btn.Visible = false;

            //UC EVENTS
            btn_dgv.AddClick += new btn_dgv.AddClickHandler(AddClick);
            btn_dgv.EditClick += new btn_dgv.EditClickHandler(EditClick);
            btn_dgv.DeleteClick += new btn_dgv.DeleteClickHandler(DeleteClick);
            btn_dgv.EnableClick += new btn_dgv.EnableClickHandler(EnableClick);

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
            using (contract_rate_detail managePage = new contract_rate_detail())
            {
                managePage.Owner = this;
                managePage.agent_id = agent_id;
                managePage.agent_contract_rate_id = "-1";
                managePage.Text = "ADD CONTRACT RATE DATA";
                this.Hide();
                managePage.ShowDialog();
                this.Show();
                this.Activate();
            }
        }
        void EditClick(object sender, EventArgs e)
        {
            using (contract_rate_detail managePage = new contract_rate_detail())
            {
                managePage.Owner = this;
                managePage.agent_id = agent_id;
                managePage.agent_contract_rate_id = btn_dgv.DGV.SelectedRows[0].Cells[btn_dgv.DGV.Columns.Count - 1].Value.ToString();
                managePage.start_date.Text = btn_dgv.DGV.SelectedRows[0].Cells["START_DATE"].Value.ToString();
                managePage.end_date.Text = btn_dgv.DGV.SelectedRows[0].Cells["END_DATE"].Value.ToString();
                managePage.Text = "EDIT CONTRACT RATE DATA";
                this.Hide();
                managePage.ShowDialog();
                this.Show();
                this.Activate();
            }
        }
        void DeleteClick(object sender, EventArgs e)
        {
            string the_id = btn_dgv.DGV.SelectedRows[0].Cells[btn_dgv.DGV.Columns.Count - 1].Value.ToString();
            queryString = "UPDATE AGENT_CONTRACT_RATE SET IS_USE = 0 WHERE AGENT_CONTRACT_RATE_ID = " + the_id;
            GF.showLoading(this);
            if (!DB.set(queryString, "DISABLE AGENT_CONTRACT_RATE[" + the_id + "]"))
            {
                MessageBox.Show("ERROR DISABLE THE CONTRACT RATE OF AGENT !!", "ERROR");
                GF.closeLoading();
            }
            DB.close();
            GF.closeLoading();
            loadGridData();
        }
        void EnableClick(object sender, EventArgs e)
        {
            string the_id = btn_dgv.DGV.SelectedRows[0].Cells[btn_dgv.DGV.Columns.Count - 1].Value.ToString();
            queryString = "UPDATE AGENT_CONTRACT_RATE SET IS_USE = 1 WHERE AGENT_CONTRACT_RATE_ID = " + the_id;
            GF.showLoading(this);
            if (!DB.set(queryString, "ENABLE AGENT_CONTRACT_RATE[" + the_id + "]"))
            {
                MessageBox.Show("ERROR ENABLE THE CONTRACT RATE OF AGENT !!", "ERROR");
                GF.closeLoading();
            }
            DB.close();
            GF.closeLoading();
            loadGridData();
        }

        void doLoadGridData(object sender, EventArgs e)
        {
            btn_dgv.rearrange(10);
            //btn_dgv.doResize(Width - 15);
            btn_dgv.Height = Height - btn_dgv.Top - 10;
            btn_dgv.paging_panel.Visible = false;
            //btn_dgv.paging_panel.Top += 90;
            btn_dgv.DGV.Height += 95 + btn_dgv.paging_panel.Height;

            btn_dgv.del_btn.Text = "DISABLE";

            GF.resetAC(this);
                        
            this.btn_dgv.DGV.Rows.Clear();

            if (btn_dgv.DGV.Columns.Count == 0)
            {
                this.btn_dgv.DGV.Columns.Add("contract_rate_period", "PERIOD");
                this.btn_dgv.DGV.Columns.Add("start_date", "START_DATE");
                this.btn_dgv.DGV.Columns.Add("end_date", "END_DATE");
                this.btn_dgv.DGV.Columns.Add("is_use", "ACTIVE");
                this.btn_dgv.DGV.Columns.Add("agent_contract_rate_id", "AGENT_CONTRACT_RATE_ID");

                this.btn_dgv.DGV.Columns["start_date"].Visible = false;
                this.btn_dgv.DGV.Columns["end_date"].Visible = false;
                this.btn_dgv.DGV.Columns["is_use"].Visible = false;
                this.btn_dgv.DGV.Columns["agent_contract_rate_id"].Visible = false;
            }

            loadGridData();
        }
        // DELEGATE PART :: END
        public void loadGridData()
        {
            GF.showLoading(this);
            btn_dgv.DGV.Rows.Clear();

            queryString = @"
            SELECT A.*, B.AGENT_CONTRACT_RATE_ID, CONVERT(NVARCHAR(MAX), B.START_DATE, 103) START_DATE, CONVERT(NVARCHAR(MAX), B.END_DATE, 103) END_DATE 
            FROM AGENT A
            INNER JOIN AGENT_CONTRACT_RATE B ON A.AGENT_ID = B.AGENT_ID
            WHERE A.AGENT_ID = " + agent_id;

            GF.getTotalPage(btn_dgv, queryString, null);

            queryString = DB.insertRowNum("A.AGENT_NAME, B.START_DATE DESC, B.END_DATE DESC", queryString);
            using (DataTable DT = DB.getS(queryString, null, "GET ALL CONTRACT RATE OF AGENTS"))
            {

                for (int rowNum = 0; rowNum < DT.Rows.Count; rowNum++)
                {
                    this.btn_dgv.DGV.Rows.Add(
                        DT.Rows[rowNum]["START_DATE"].ToString() + " - " + DT.Rows[rowNum]["END_DATE"].ToString(),
                        DT.Rows[rowNum]["START_DATE"].ToString(),
                        DT.Rows[rowNum]["END_DATE"].ToString(),
                        (DT.Rows[rowNum]["IS_USE"].ToString() == "1" ? "ACTIVE" : "INACTIVE"),
                        DT.Rows[rowNum]["AGENT_CONTRACT_RATE_ID"]
                    );

                    if (DT.Rows[rowNum]["IS_USE"].ToString() == "0") this.btn_dgv.DGV.Rows[rowNum].DefaultCellStyle.BackColor = Color.LightCoral;
                    this.btn_dgv.DGV[0, rowNum].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }

            GF.updateRowNum(btn_dgv.DGV, true);
            this.btn_dgv.DGV.ClearSelection();
            GF.closeLoading();
        }
    }
}
