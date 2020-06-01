using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.VIP_CARD
{
    public partial class vip_card : Form
    {
        public vip_card()
        {
            InitializeComponent();
            
            //UC EVENTS
            btn_dgv.AddClick += new btn_dgv.AddClickHandler(AddClick);
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

            using (vip_card_manage managePage = new vip_card_manage())
            {
                managePage.Owner = this;
                managePage.Text = "ADD VIP CARD";
                managePage.ShowDialog();
            }
        }
        
        void DeleteClick(object sender, EventArgs e)
        {
            //GF.selected_id = Convert.ToInt32(btn_dgv.DGV.SelectedRows[0].Cells["special_card_set_id"].Value);
            
            //if (MessageBox.Show("ARE YOU SURE YOU WANT TO VOID THIS VIP CARD ?", "VOID VIP CARD", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            using (vip_card_void voidPage = new vip_card_void())
                {
                    voidPage.Text = "VOID VIP CARD";
                    voidPage.Owner = this;
                    voidPage.ShowDialog();
                }
            //}
        }

        void doLoadGridData(object sender, EventArgs e)
        {
            card_name_lbl.Top = GF.pageTop;

            code_begin_lbl.Top = code_end_lbl.Top = card_name_lbl.Top + 27;
            code_begin.Top = code_end.Top = code_begin_lbl.Top - 3;

            line_sep1.Top = code_begin_lbl.Top + 35; line_sep1.Width = btn_dgv.Width;
            btn_dgv.rearrange(line_sep1.Top + 15);
            
            btn_dgv.del_btn.Text = "VOID";
            btn_dgv.edit_btn.Visible = false;
            btn_dgv.add_btn.Left = btn_dgv.edit_btn.Left;
            btn_dgv.preventDGVSelectionChanged = true;
            //btn_dgv.preventEnable = true;

            card_name_lbl.Text = "CARD NAME : VIP CARD";
            GF.resetAC(this);
            loadGridData();

            GF.enableButton(btn_dgv.del_btn);
        }

        // DELEGATE PART :: END

        private void card_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) loadGridData();
        }

        private void code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) loadGridData();
        }

        public void loadGridData()
        {
            GF.showLoading(this);
            this.btn_dgv.DGV.Visible = false;
            this.btn_dgv.DGV.Rows.Clear();

            if (btn_dgv.DGV.Columns.Count == 0)
            {
                this.btn_dgv.DGV.Columns.Add("card_no", "CARD NO.");
                this.btn_dgv.DGV.Columns.Add("discount", "DISCOUNT");
                this.btn_dgv.DGV.Columns.Add("expiry_date", "EXPIRY DATE");
                this.btn_dgv.DGV.Columns.Add("responsible_by", "RESPONSIBLE");
                this.btn_dgv.DGV.Columns.Add("created_by", "CREATED BY");
                this.btn_dgv.DGV.Columns.Add("created_date", "CREATED ON");
                this.btn_dgv.DGV.Columns.Add("voided_by", "VOIDED BY");
                this.btn_dgv.DGV.Columns.Add("voided_date", "VOIDED ON");
                this.btn_dgv.DGV.Columns.Add("voided_reason", "REASON");
                this.btn_dgv.DGV.Columns.Add("vip_card_id", "vip_card_id");

                this.btn_dgv.DGV.Columns["vip_card_id"].Visible = false;
            }

            if (code_begin.Text.Trim() != "" && code_end.Text.Trim() != "" && Convert.ToInt32(code_begin.Text.Trim()) > Convert.ToInt32(code_end.Text.Trim()))
            {
                String tmp = code_end.Text.Trim();
                code_end.Text = code_begin.Text;
                code_begin.Text = tmp;
            }

            Dictionary<string, string> Params = new Dictionary<string, string>();

            String queryString = @"
            SELECT 
                A.vip_card_id
                ,A.card_no
                ,A.discount
                ,A.created_by
                ,B.FULLNAME creator
                ,CONVERT(VARCHAR(MAX), A.created_date, 103) + ' ' + CONVERT(VARCHAR(MAX), A.created_date, 108) created_date
                ,CONVERT(VARCHAR(MAX), A.expiry_date, 103) + ' ' + CONVERT(VARCHAR(MAX), A.expiry_date, 108) expiry_date
                ,A.responsible_id
                ,C.FULLNAME responsible
                ,A.is_void
                ,A.voided_by
                ,D.FULLNAME voider
                ,A.voided_reason
                ,CONVERT(VARCHAR(MAX), A.voided_datetime, 103) + ' ' + CONVERT(VARCHAR(MAX), A.voided_datetime, 108) voided_datetime
            FROM 
            VIP_CARD A
            LEFT OUTER JOIN EMPLOYEE B ON A.created_by = B.EMP_ID
            LEFT OUTER JOIN EMPLOYEE C ON A.responsible_id = C.EMP_ID
            LEFT OUTER JOIN EMPLOYEE D ON A.voided_by = D.EMP_ID
            WHERE 1=1";

            if (code_begin.Text.Trim() != "")
            {
                queryString += " AND " + code_begin.Text + " <= CONVERT(BIGINT, A.CARD_NO)";
                //Params.Add("@code_begin", code_begin.Text);
            }
            if (code_end.Text.Trim() != "")
            {
                queryString += " AND CONVERT(BIGINT, A.CARD_NO) <= " + code_end.Text;
                //Params.Add("@code_end", code_end.Text);
            }

            // GET TOTAL PAGE
            GF.getTotalPage(btn_dgv, queryString, Params);

            queryString = DB.insertRowNum("CONVERT(BIGINT, A.CARD_NO) ASC, A.IS_VOID ASC", queryString);
            GF.doDebug(">>>> " + queryString);
            using (DataTable myDT = DB.getS(queryString, Params, "GET ALL VIP CARD"))
            {
                int rowNum = 0;
                foreach (DataRow myRow in myDT.Rows)
                {
                    this.btn_dgv.DGV.Rows.Add(
                        myRow["card_no"],
                        myRow["DISCOUNT"].ToString() + "%",
                        GF.formatDate(myRow["expiry_date"].ToString()),
                        (myRow["responsible_id"].ToString() == "0" ? "S.A." : myRow["responsible"]),
                        (myRow["created_by"].ToString() == "0" ? "S.A." : myRow["creator"]),
                        GF.formatDateTime(myRow["created_date"].ToString()),
                        (myRow["voided_by"].ToString() == "0" ? "S.A." : myRow["voider"]),
                        GF.formatDateTime(myRow["voided_datetime"].ToString()),
                        myRow["voided_reason"],
                        myRow["vip_card_id"]
                    );

                    if (myRow["is_void"].ToString() == "1") this.btn_dgv.DGV.Rows[rowNum].DefaultCellStyle.BackColor = Color.LightCoral;
                    this.btn_dgv.DGV["voided_reason", rowNum].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    rowNum++;
                }
            }
            GF.updateRowNum(btn_dgv.DGV, true);
            this.btn_dgv.DGV.Refresh();
            this.btn_dgv.DGV.Visible = true;
            this.btn_dgv.DGV.ClearSelection();
            GF.closeLoading();
        }

        private void code_begin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void code_end_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
