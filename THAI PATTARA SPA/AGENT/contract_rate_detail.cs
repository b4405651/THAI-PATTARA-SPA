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
    public partial class contract_rate_detail : Form
    {
        String queryString = "";
        public string agent_id = "-1";
        public string agent_contract_rate_id = "-1";
        String id_list = "";
        public contract_rate_detail()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };

            btn_dgv.DGV.EditMode = DataGridViewEditMode.EditOnEnter;
            btn_dgv.hideTopPanel();
            btn_dgv.paging_panel.Visible = false;
            btn_dgv.Left = 10;
            this.Height = 800;
            btn_dgv.DGV.RowHeadersVisible = false;
        }

        private void contract_rate_detail_Load(object sender, EventArgs e)
        {
            GF.showLoading(this);
            btn_dgv.rearrange(save_btn.Top + save_btn.Height + 7);
            //btn_dgv.doResize(Width - 10);
            btn_dgv.Height = Height - btn_dgv.Top - 10;
            btn_dgv.DGV.Height += 140 + btn_dgv.paging_panel.Height;
            contract_rate_data_panel.Left = Width - contract_rate_data_panel.Width - 25;
            initDGV();
            loadData();
            GF.closeLoading();
        }

        private void initDGV()
        {
            this.btn_dgv.DGV.Rows.Clear();

            if (btn_dgv.DGV.Columns.Count == 0)
            {
                this.btn_dgv.DGV.Columns.Add("code", "CODE");
                this.btn_dgv.DGV.Columns.Add("program_name", "PROGRAM NAME");
                this.btn_dgv.DGV.Columns.Add("full_price", "FULL PRICE");
                using (DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn())
                {
                    txt.HeaderText = "CONTRACT RATE";
                    txt.Name = "contract_rate";
                    this.btn_dgv.DGV.Columns.Add(txt);
                }
                this.btn_dgv.DGV.Columns.Add("spa_program_id", "SPA_PROGRAMID");

                this.btn_dgv.DGV.Columns["code"].ReadOnly = true;
                this.btn_dgv.DGV.Columns["program_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.btn_dgv.DGV.Columns["program_name"].ReadOnly = true;
                this.btn_dgv.DGV.Columns["spa_program_id"].Visible = false;
                this.btn_dgv.DGV.Columns["full_price"].ReadOnly = true;
            }
        }

        private void loadData()
        {
            queryString = "SELECT * FROM SPA_PROGRAM WHERE IS_USE = 1 ORDER BY CODE";
            using (DataTable DT = DB.getS(queryString, null, "GET ACTIVE SPA PROGRAMS", false))
            {
                foreach (DataRow row in DT.Rows)
                {
                    id_list += row["SPA_PROGRAM_ID"].ToString() + ",";
                    String price = row["PRICE"].ToString();
                    String full_price = row["PRICE"].ToString();

                    if (agent_contract_rate_id != "-1") // EDIT CURRENT AGENT_CONTRACT_RATE_DETAIL
                    {
                        queryString = "SELECT * FROM AGENT_CONTRACT_RATE_DETAIL WHERE AGENT_CONTRACT_RATE_ID = " + agent_contract_rate_id + " AND SPA_PROGRAM_ID = " + row["SPA_PROGRAM_ID"].ToString();
                        using (DataTable tmpDT = DB.getS(queryString, null, "GET CURRENT SPA_PROGRAM[" + row["SPA_PROGRAM_ID"].ToString() + "] CONTRACT RATE DETAIL OF AGENT_CONTRACT_RATE[" + agent_contract_rate_id + "]", false))
                        {
                            price = tmpDT.Rows[0]["PRICE"].ToString();
                        }
                    }
                    else // ADD NEW AGENT_CONTRACT_RATE_DETAIL
                    {
                        queryString = @"
                        SELECT B.PRICE 
                        FROM AGENT_CONTRACT_RATE A
                        INNER JOIN AGENT_CONTRACT_RATE_DETAIL B ON A.AGENT_CONTRACT_RATE_ID = B.AGENT_CONTRACT_RATE_ID
                        WHERE B.SPA_PROGRAM_ID = " + row["SPA_PROGRAM_ID"].ToString() + @"
                        AND A.AGENT_ID = " + agent_id + @" AND A.START_DATE = (
                            SELECT MAX(START_DATE)
                            FROM AGENT_CONTRACT_RATE A
                            WHERE A.AGENT_ID = " + agent_id + @"
                        )";
                        using (DataTable tmpDT = DB.getS(queryString, null, "GET LATEST PRICE IN SPA PROGRAM[" + row["SPA_PROGRAM_ID"].ToString() + "] OF AGENT[" + agent_id + "]", false))
                        {
                            if (tmpDT.Rows.Count == 1)
                            {
                                price = tmpDT.Rows[0]["PRICE"].ToString();
                            }
                        }
                    }

                    btn_dgv.DGV.Rows.Add(
                        row["CODE"].ToString(),
                        row["PROGRAM_NAME"].ToString(),
                        GF.formatNumber(Convert.ToInt32(full_price)),
                        price,
                        row["SPA_PROGRAM_ID"].ToString()
                    );
                }
                id_list = id_list.Substring(0, id_list.Length - 1);
            }
            //GF.updateRowNum(btn_dgv.DGV, false);
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (!GF.isValidDate(start_date.Text.Trim()))
            {
                MessageBox.Show("'START DATE' IS NOT VALID DATE FORMAT !!", "ERROR");
                start_date.Select();
                return;
            }

            if (!GF.isValidDate(end_date.Text.Trim()))
            {
                MessageBox.Show("'END DATE' IS NOT VALID DATE FORMAT !!", "ERROR");
                start_date.Select();
                return;
            }

            if (Convert.ToDateTime(start_date.Text.Trim()) >= Convert.ToDateTime(end_date.Text.Trim()))
            {
                MessageBox.Show("'START DATE' MUST BE LESS THAN 'END DATE' !!", "ERROR");
                start_date.Select();
                return;
            }

            foreach (DataGridViewRow row in btn_dgv.DGV.Rows)
            {
                if (row.Cells["contract_rate"].Value.ToString().Trim() == "")
                {
                    MessageBox.Show("PLEASE ENTER THE CONTRACT RATE !!", "ERROR");
                    row.Cells["contract_rate"].Selected = true;
                    return;
                }

                if (Convert.ToInt32(row.Cells["contract_rate"].Value.ToString().Trim()) <= 0)
                {
                    MessageBox.Show("THE VALUE OF CONTRACT RATE MUST BE MORE THAN ZERO !!", "ERROR");
                    row.Cells["contract_rate"].Selected = true;
                    return;
                }
            }

            GF.showLoading(this);
            DB.beginTrans();
            if(agent_contract_rate_id == "-1") // ADD
            {
                queryString = "INSERT INTO AGENT_CONTRACT_RATE (AGENT_ID, START_DATE, END_DATE) VALUES (";
                queryString += agent_id + ", ";
                queryString += GF.modDate(start_date.Text.Trim()) + ", ";
                queryString += GF.modDate(end_date.Text.Trim());
                queryString += ")";
                agent_contract_rate_id = DB.insertReturnID(queryString, "INSERT INTO AGENT_CONTRACT_RARE").ToString();
                if (agent_contract_rate_id == "-1")
                {
                    MessageBox.Show("ERROR INSERT NEW AGENT CONTRACT RATE !!", "ERROR");
                    GF.closeLoading();
                    return;
                }
                foreach (DataGridViewRow row in btn_dgv.DGV.Rows)
                {
                    queryString = "INSERT INTO AGENT_CONTRACT_RATE_DETAIL (AGENT_CONTRACT_RATE_ID, SPA_PROGRAM_ID, PRICE) VALUES (";
                    queryString += agent_contract_rate_id + ", ";
                    queryString += row.Cells["SPA_PROGRAM_ID"].Value.ToString() + ", ";
                    queryString += row.Cells["contract_rate"].Value.ToString();
                    queryString += ")";
                    if (!DB.set(queryString, "INSERT INTO AGENT_CONTRACT_RATE_DETAIL IN AGENT_CONTRACT_RATE[" + agent_contract_rate_id + "]"))
                    {
                        MessageBox.Show("ERROR INSERT AGENT CONTRACT RATE DETAIL !!", "ERROR");
                        GF.closeLoading();
                        return;
                    }
                }
            }
            else // EDIT
            {
                queryString = "UPDATE AGENT_CONTRACT_RATE SET START_DATE = " + GF.modDate(start_date.Text.Trim()) + ", END_DATE = " + GF.modDate(end_date.Text.Trim()) + " WHERE AGENT_CONTRACT_RATE_ID = " + agent_contract_rate_id;
                if (!DB.set(queryString, "UPDATE AGENT_CONTRACT_RATE[" + agent_contract_rate_id + "]"))
                {
                    MessageBox.Show("ERROR UPDATE AGENT CONTRACT RATE !!", "ERROR");
                    GF.closeLoading();
                    return;
                }

                queryString = "DELETE FROM AGENT_CONTRACT_RATE_DETAIL WHERE AGENT_CONTRACT_RATE_ID = " + agent_contract_rate_id + " AND SPA_PROGRAM_ID NOT IN (" + id_list + ")";
                if (!DB.set(queryString, "DELETE UNUSED SPA_PROGRAM IN AGENT_CONTRACT_RATE[" + agent_contract_rate_id + "]"))
                {
                    MessageBox.Show("ERROR DELETE UNUSED SPA_PROGRAM IN AGENT CONTRACT RATE !!", "ERROR");
                    GF.closeLoading();
                    return;
                }

                foreach (DataGridViewRow row in btn_dgv.DGV.Rows)
                {
                    queryString = "SELECT * FROM AGENT_CONTRACT_RATE_DETAIL WHERE AGENT_CONTRACT_RATE_ID = " + agent_contract_rate_id + " AND SPA_PROGRAM_ID = " + row.Cells["SPA_PROGRAM_ID"].Value.ToString();
                    using (DataTable DT = DB.getS(queryString, null, "CHECK IF SPA_PROGRAM[" + row.Cells["SPA_PROGRAM_ID"].Value.ToString() + "] EXISTED IN AGENT_CONTRACT_RATE[" + agent_contract_rate_id + "]", false))
                    {
                        if (DT.Rows.Count == 0)
                        {
                            queryString = "INSERT INTO AGENT_CONTRACT_RATE_DETAIL (AGENT_CONTRACT_RATE_ID, SPA_PROGRAM_ID, PRICE) VALUES (";
                            queryString += agent_contract_rate_id + ", ";
                            queryString += row.Cells["SPA_PROGRAM_ID"].Value.ToString() + ", ";
                            queryString += row.Cells["contract_rate"].Value.ToString();
                            queryString += ")";
                            if (!DB.set(queryString, "INSERT INTO AGENT_CONTRACT_RATE_DETAIL IN AGENT_CONTRACT_RATE[" + agent_contract_rate_id + "]"))
                            {
                                MessageBox.Show("ERROR INSERT AGENT CONTRACT RATE DETAIL !!", "ERROR");
                                GF.closeLoading();
                                return;
                            }
                        }
                        else
                        {
                            queryString = "UPDATE AGENT_CONTRACT_RATE_DETAIL SET PRICE = " + row.Cells["contract_rate"].Value.ToString() + " WHERE AGENT_CONTRACT_RATE_ID = " + agent_contract_rate_id + " AND SPA_PROGRAM_ID = " + row.Cells["SPA_PROGRAM_ID"].Value.ToString();
                            if (!DB.set(queryString, "UPDATE PRICE OF SPA_PROGRAM[" + row.Cells["SPA_PROGRAM_ID"].Value.ToString() + "] IN AGENT_CONTRACT_RATE[" + agent_contract_rate_id + "]"))
                            {
                                MessageBox.Show("ERROR UPDATE AGENT CONTRACT RATE DETAIL !!", "ERROR");
                                GF.closeLoading();
                                return;
                            }
                        }
                    }
                }
            }
            DB.close();
            ((contract_rate)Owner).loadGridData();
            GF.closeLoading();
            this.Close();
        }
    }
}
