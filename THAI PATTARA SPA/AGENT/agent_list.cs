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
    public partial class agent_list : Form
    {
        String queryString = "";
        
        public agent_list()
        {
            InitializeComponent();
            GF.addKeyUp(this);

            agent_type.Items.Add(new ComboItem(-1, "ALL"));
            agent_type.Items.Add(new ComboItem(0, "COMPANY"));
            agent_type.Items.Add(new ComboItem(2, "PERSON"));

            GF.resizeComboBox(agent_type);
            agent_type.SelectedIndex = 0;

            GF.disableButton(btn_dgv.refresh_btn);
            btn_dgv.refresh_btn.Text = "CONTRACT RATE";
            btn_dgv.refresh_btn.Width += 50;
            btn_dgv.search_btn.Left += 50;
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
            btn_dgv.RefreshClick += new btn_dgv.RefreshClickHandler(ContractRateClick); // USE THIS BUTTON AS CONTRACT RATE
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
            using (agent_manage managePage = new agent_manage())
            {
                managePage.Owner = this;
                managePage.id = -1;
                managePage.manage_btn.Text = "ADD";
                managePage.Text = "ADD AGENT DATA";

                managePage.ShowDialog();
            }
        }
        void EditClick(object sender, EventArgs e)
        {
            using (agent_manage managePage = new agent_manage())
            {
                managePage.Owner = this;
                managePage.manage_btn.Text = "UPDATE";
                managePage.id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells[btn_dgv.DGV.Columns.Count - 1].Value);
                managePage.Text = "EDIT AGENT DATA";

                managePage.ShowDialog();
            }
        }
        void DeleteClick(object sender, EventArgs e)
        {
            string the_id = btn_dgv.DGV.SelectedRows[0].Cells[btn_dgv.DGV.Columns.Count - 1].Value.ToString();
            queryString = "UPDATE AGENT SET IS_USE = 0 WHERE AGENT_ID = " + the_id;
            GF.showLoading(this);
            if (!DB.set(queryString, "DISABLE AGENT[" + the_id + "]"))
            {
                MessageBox.Show("ERROR DISABLE THE AGENT !!", "ERROR");
                GF.closeLoading();
            }
            DB.close();
            GF.closeLoading();
            loadGridData();
        }
        void EnableClick(object sender, EventArgs e)
        {
            string the_id = btn_dgv.DGV.SelectedRows[0].Cells[btn_dgv.DGV.Columns.Count - 1].Value.ToString();
            queryString = "UPDATE AGENT SET IS_USE = 1 WHERE AGENT_ID = " + the_id;
            GF.showLoading(this);
            if (!DB.set(queryString, "ENABLE AGENT[" + the_id + "]"))
            {
                MessageBox.Show("ERROR ENABLE THE AGENT !!", "ERROR");
                GF.closeLoading();
            }
            DB.close();
            GF.closeLoading();
            loadGridData();
        }

        void ContractRateClick(object sender, EventArgs e)
        {
            using (contract_rate managePage = new contract_rate())
            {
                managePage.Text = "CONTRACT RATE : " + btn_dgv.DGV.SelectedRows[0].Cells["agent_name"].Value.ToString();
                managePage.agent_id = btn_dgv.DGV.SelectedRows[0].Cells["agent_id"].Value.ToString();
                managePage.Owner = this;
                managePage.ShowDialog();
            }
        }

        void doLoadGridData(object sender, EventArgs e)
        {
            agent_name_lbl.Top = tel_lbl.Top = agent_type_lbl.Top = GF.pageTop;
            agent_name.Top = tel.Top = agent_name_lbl.Top - 3;
            agent_type.Top = agent_type_lbl.Top - 3;

            line_sep1.Top = agent_name_lbl.Top + 35; line_sep1.Width = btn_dgv.Width;
            btn_dgv.rearrange(line_sep1.Top + 15);

            btn_dgv.del_btn.Text = "DISABLE";

            GF.resetAC(this);

            btn_dgv.rearrange(line_sep1.Top + 15);
            this.btn_dgv.DGV.Rows.Clear();

            if (btn_dgv.DGV.Columns.Count == 0)
            {
                this.btn_dgv.DGV.Columns.Add("agent_name", "NAME");
                this.btn_dgv.DGV.Columns.Add("tel", "TEL");
                this.btn_dgv.DGV.Columns.Add("agent_type_name", "TYPE");
                this.btn_dgv.DGV.Columns.Add("contact_person", "CONTACT PERSON");
                this.btn_dgv.DGV.Columns.Add("latest_contract_rate", "LATEST CONTRACT RATE");
                this.btn_dgv.DGV.Columns.Add("is_use", "ACTIVE");
                this.btn_dgv.DGV.Columns.Add("agent_id", "AGENT_ID");

                this.btn_dgv.DGV.Columns["is_use"].Visible = false;
                this.btn_dgv.DGV.Columns["agent_id"].Visible = false;
                this.btn_dgv.DGV.Columns["agent_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.btn_dgv.DGV.Columns["tel"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.btn_dgv.DGV.Columns["contact_person"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            loadGridData();
        }
        // DELEGATE PART :: END
        private void loadGridData()
        {
            GF.showLoading(this);
            btn_dgv.DGV.Rows.Clear();

            Dictionary<string, string> Params = new Dictionary<string, string>();

            queryString = @"
            SELECT 
                A.*, 
                (
                    SELECT CONVERT(NVARCHAR(MAX), MAX(Z.START_DATE), 103) MAX_START_DATE
                    FROM AGENT_CONTRACT_RATE Z
                    WHERE Z.AGENT_ID = A.AGENT_ID
                ) START_DATE,
                (
                    SELECT CONVERT(NVARCHAR(MAX), MAX(Z.END_DATE), 103) MAX_END_DATE
                    FROM AGENT_CONTRACT_RATE Z
                    WHERE Z.AGENT_ID = A.AGENT_ID
                ) END_DATE
            FROM AGENT A
            WHERE 1=1";

            if (agent_name.Text.Trim() != "")
            {
                queryString += " AND A.AGENT_NAME LIKE '%' + " + agent_name.Text + " + '%'";
                //Params.Add("@agent_name", agent_name.Text);
            }
            if (tel.Text.Trim() != "")
            {
                queryString += " AND A.TEL LIKE '%' + " + tel.Text + " + '%'";
                //Params.Add("@tel", tel.Text);
            }
            if (((ComboItem)this.agent_type.SelectedItem).Key != -1) queryString += " AND A.AGENT_TYPE = " + ((ComboItem)this.agent_type.SelectedItem).Key.ToString();

            GF.getTotalPage(btn_dgv, queryString, Params);

            queryString = DB.insertRowNum("A.AGENT_NAME, A.TEL", queryString);
            using (DataTable DT = DB.getS(queryString, Params, "GET ALL AGENT"))
            {

                for (int rowNum = 0; rowNum < DT.Rows.Count; rowNum++)
                {
                    this.btn_dgv.DGV.Rows.Add(
                        DT.Rows[rowNum]["AGENT_NAME"],
                        DT.Rows[rowNum]["TEL"],
                        (DT.Rows[rowNum]["AGENT_TYPE"].ToString() == "0" ? "COMPANY" : "PERSON"),
                        DT.Rows[rowNum]["CONTACT_PERSON"].ToString(),
                        DT.Rows[rowNum]["START_DATE"].ToString() + " - " + DT.Rows[rowNum]["END_DATE"].ToString(),
                        (DT.Rows[rowNum]["IS_USE"].ToString() == "1" ? "ACTIVE" : "INACTIVE"),
                        DT.Rows[rowNum]["AGENT_ID"]
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
