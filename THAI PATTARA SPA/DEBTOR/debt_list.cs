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
    public partial class debt_list : Form
    {
        public int id = -1;
        String queryString = "";
        public string void_reason = "";
        bool firstLoad = true;

        public debt_list()
        {
            InitializeComponent();

            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };

            //PAGING DELEGATE
            btn_dgv.firstClick += new btn_dgv.firstClickHandler(doLoadGridData);
            btn_dgv.prevClick += new btn_dgv.prevClickHandler(doLoadGridData);
            btn_dgv.nextClick += new btn_dgv.nextClickHandler(doLoadGridData);
            btn_dgv.lastClick += new btn_dgv.lastClickHandler(doLoadGridData);
            btn_dgv.pageNumberChanged += new btn_dgv.pageNumberChangedHandler(doLoadGridData);

            GF.addKeyUp(this);

            GF.disableButton(pay_btn);
            GF.disableButton(cancel_paid_btn);
            GF.disableButton(void_btn);

            debt_type.Items.Clear();
            debt_type.Items.Add(new ComboItem(-1, "ALL"));
            debt_type.Items.Add(new ComboItem(0, "BILL"));
            debt_type.Items.Add(new ComboItem(1, "SINGLE COUPON"));
            debt_type.Items.Add(new ComboItem(2, "COUPON SET"));
            GF.resizeComboBox(debt_type);
            debt_type.SelectedIndex = 0;

            btn_dgv.DGV.SelectionChanged += (s, e) =>
            {
                if (btn_dgv.DGV.SelectedRows.Count == 1)
                {
                    if (btn_dgv.DGV.SelectedRows[0].DefaultCellStyle.BackColor == Color.LightCoral)
                        GF.enableButton(pay_btn);
                    else if (btn_dgv.DGV.SelectedRows[0].DefaultCellStyle.BackColor == Color.LightGreen)
                        GF.enableButton(cancel_paid_btn);
                    else
                    {
                        GF.disableButton(pay_btn);
                        GF.disableButton(cancel_paid_btn);
                    }

                    if (btn_dgv.DGV.SelectedRows[0].Cells[4].Value.ToString().Trim() == "VOIDED") GF.disableButton(void_btn);
                    else GF.enableButton(void_btn);
                }
                else
                {
                    GF.disableButton(pay_btn);
                    GF.disableButton(cancel_paid_btn);
                    GF.disableButton(void_btn);
                }
            };

            btn_dgv.DGV.CellDoubleClick += (s, e) =>
            {
                if (btn_dgv.DGV.SelectedRows.Count == 1)
                {
                    using (debt_detail detail = new debt_detail())
                    {
                        detail.debtor_data_id = btn_dgv.DGV.SelectedRows[0].Cells["debtor_data_id"].Value.ToString();
                        detail.Owner = this;
                        detail.ShowDialog();
                    }
                }
            };

            since_date.my_date.KeyUp += (s, e) =>
            {
                if (e.KeyCode == Keys.Return) if (!e.Handled) loadData();
            };

            to_date.my_date.KeyUp += (s, e) =>
            {
                if (e.KeyCode == Keys.Return) if (!e.Handled) loadData();
            };
        }

        void doLoadGridData(object sender, EventArgs e)
        {
            if (firstLoad)
            {
                btn_dgv.rearrange(pay_btn.Top + pay_btn.Height + 7);
                btn_dgv.hideTopPanel();
                btn_dgv.Left += 10;
                btn_dgv.DGV.Height += 90;
                btn_dgv.paging_panel.Top += 90;
                firstLoad = false;
            }
            initDGV();
            loadData();
        }

        private void initDGV()
        {
            this.btn_dgv.DGV.Rows.Clear();

            if (btn_dgv.DGV.Columns.Count == 0)
            {
                this.btn_dgv.DGV.Columns.Add("type", "TYPE");
                this.btn_dgv.DGV.Columns.Add("detail", "DETAIL");
                this.btn_dgv.DGV.Columns.Add("debt_datetime", "DEBT DATETIME");
                this.btn_dgv.DGV.Columns.Add("amount", "AMOUNT");
                this.btn_dgv.DGV.Columns.Add("status", "STATUS");
                this.btn_dgv.DGV.Columns.Add("paid_datetime", "PAID DATETIME");
                this.btn_dgv.DGV.Columns.Add("void_datetime", "VOID DATETIME");
                this.btn_dgv.DGV.Columns.Add("void_detail", "VOID DETAIL");
                this.btn_dgv.DGV.Columns.Add("debtor_data_id", "DEBTOR_DATA_ID");

                this.btn_dgv.DGV.Columns["detail"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.btn_dgv.DGV.Columns["void_detail"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.btn_dgv.DGV.Columns["debtor_data_id"].Visible = false;
            }
        }

        private void loadData()
        {
            GF.showLoading(this);
            btn_dgv.DGV.Rows.Clear();

            Dictionary<string, string> Params = new Dictionary<string,string>();

            queryString = "SELECT * FROM DEBTOR_DATA WHERE DEBTOR_ID = " + id.ToString();
            if (debt_type.SelectedIndex > 0) queryString += " AND ITEM_TYPE = " + ((ComboItem)debt_type.SelectedItem).Key.ToString();
            if (GF.isValidDate(since_date.Text.Trim()))
            {
                queryString += " AND CONVERT(DATE, DEBT_DATETIME) >= @since";
                Params.Add("@since", GF.modDate(since_date.Text.Trim()));
            }
            if (GF.isValidDate(to_date.Text.Trim()))
            {
                queryString += " AND CONVERT(DATE, DEBT_DATETIME) <= @to";
                Params.Add("@to", GF.modDate(to_date.Text.Trim()));
            }

            GF.getTotalPage(btn_dgv, queryString, Params);
            queryString = DB.insertRowNum("DEBT_DATETIME DESC", queryString);

            using (DataTable DT = DB.getS(queryString, Params, "GET DEBT DETAIL OF DEBTOR[" + id.ToString() + "]"))
            {
                foreach (DataRow row in DT.Rows)
                {
                    String type = "";
                    String detail = "";
                    String status = "";
                    switch (row["ITEM_TYPE"].ToString())
                    {
                        case "0":
                            type = "BILL";
                            queryString = "SELECT BILL_NO FROM BILL WHERE BILL_ID = " + row["ITEM_ID"].ToString();
                            using (DataTable tmpDT = DB.getS(queryString, null, "GET BILL_NO FROM BILL_ID[" + row["ITEM_ID"].ToString() + "]", false))
                            {
                                detail = tmpDT.Rows[0]["BILL_NO"].ToString();
                            }
                            break;
                        case "1":
                            type = "SINGLE COUPON";
                            break;
                        case "2":
                            type = "COUPON SET";
                            break;
                    }

                    if (row["IS_VOID"].ToString() == "1") status = "VOIDED";
                    else if (row["IS_PAID"].ToString() == "1") status = "PAID";
                    else status = "UNPAID";

                    string void_by = "";
                    if (row["IS_VOID"].ToString() == "1")
                    {
                        if (row["VOID_BY"].ToString() == "0") void_by = "S.A.";
                        else
                        {
                            queryString = "SELECT FULLNAME FROM EMPLOYEE WHERE EMP_ID = " + row["VOID_BY"].ToString();
                            using (DataTable tmpDT = DB.getS(queryString, null, "GET VOIDER", false))
                            {
                                void_by = tmpDT.Rows[0]["FULLNAME"].ToString();
                            }
                        }
                    }

                    btn_dgv.DGV.Rows.Add(
                        type,
                        detail,
                        GF.formatDateTime(row["DEBT_DATETIME"].ToString()),
                        GF.formatNumber(Convert.ToInt32(row["AMOUNT"].ToString())),
                        status,
                        (row["IS_PAID"].ToString() == "1" ? GF.formatDateTime(row["PAID_DATETIME"].ToString()) : ""),
                        (row["IS_VOID"].ToString() == "1" ? GF.formatDateTime(row["VOID_DATETIME"].ToString()) : ""),
                        (row["IS_VOID"].ToString() == "1" ? ("By " + void_by + " : " + row["VOID_REASON"].ToString()) : ""),
                        row["DEBTOR_DATA_ID"].ToString()
                    );
                    if (status == "VOIDED")
                        this.btn_dgv.DGV.Rows[this.btn_dgv.DGV.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGray;
                    else if (status == "PAID")
                        this.btn_dgv.DGV.Rows[this.btn_dgv.DGV.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGreen;
                    else
                        this.btn_dgv.DGV.Rows[this.btn_dgv.DGV.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightCoral;
                }
                this.btn_dgv.DGV.ClearSelection();
                GF.updateRowNum(btn_dgv.DGV, true);
            }
            GF.closeLoading();
        }

        private void pay_btn_Click(object sender, EventArgs e)
        {
            queryString = "UPDATE DEBTOR_DATA SET IS_PAID = 1, PAID_DATETIME = CURRENT_TIMESTAMP WHERE DEBTOR_DATA_ID = " + btn_dgv.DGV.SelectedRows[0].Cells["DEBTOR_DATA_ID"].Value.ToString();
            GF.showLoading(this);
            DB.beginTrans();
            if (!DB.set(queryString, "SET DEBTOR_DATA[" + btn_dgv.DGV.SelectedRows[0].Cells["DEBTOR_DATA_ID"].Value.ToString() + "] AS PAID"))
            {
                MessageBox.Show("ERROR SET DEBT AS PAID !!", "ERROR");
                GF.closeLoading();
            }
            DB.close();
            GF.closeLoading();
            loadData();
        }

        private void cancel_paid_btn_Click(object sender, EventArgs e)
        {
            queryString = "UPDATE DEBTOR_DATA SET IS_PAID = 0, PAID_DATETIME = NULL WHERE DEBTOR_DATA_ID = " + btn_dgv.DGV.SelectedRows[0].Cells["DEBTOR_DATA_ID"].Value.ToString();
            GF.showLoading(this);
            DB.beginTrans();
            if (!DB.set(queryString, "SET DEBTOR_DATA[" + btn_dgv.DGV.SelectedRows[0].Cells["DEBTOR_DATA_ID"].Value.ToString() + "] AS UNPAID"))
            {
                MessageBox.Show("ERROR SET DEBT AS UNPAID !!", "ERROR");
                GF.closeLoading();
            }
            DB.close();
            GF.closeLoading();
            loadData();
        }

        private void debt_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void void_btn_Click(object sender, EventArgs e)
        {
            void_reason = "";
            using (void_reason voidPage = new void_reason()) 
            {
                voidPage.Owner = this;
                voidPage.ShowDialog();
                if (void_reason.Trim() != "")
                {
                    queryString = "UPDATE DEBTOR_DATA SET IS_VOID = 1, VOID_REASON = '" + void_reason.Trim() + "', VOID_BY = " + GF.emp_id.ToString() + ", VOID_DATETIME = CURRENT_TIMESTAMP WHERE DEBTOR_DATA_ID = " + btn_dgv.DGV.SelectedRows[0].Cells["DEBTOR_DATA_ID"].Value.ToString();
                    GF.showLoading(this);
                    DB.beginTrans();
                    if (!DB.set(queryString, "VOID DEBTOR_DATA[" + btn_dgv.DGV.SelectedRows[0].Cells["DEBTOR_DATA_ID"].Value.ToString() + "]"))
                    {
                        MessageBox.Show("ERROR VOID DEBT !!", "ERROR");
                        GF.closeLoading();
                    }
                    DB.close();
                    GF.closeLoading();
                    loadData();
                }
            }
        }
        
    }
}
