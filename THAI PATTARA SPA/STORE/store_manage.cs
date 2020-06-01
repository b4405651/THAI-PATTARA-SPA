using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Transactions;

namespace SPA_MANAGEMENT_SYSTEM.STORE
{
    public partial class store_manage : Form
    {
        int currentItemID = -1;
        public store_manage()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };
            //GF.resizeMgmtForm(this);
            GF.addKeyUp(this);
        }

        private void store_manage_Load(object sender, EventArgs e)
        {
            item_detail_lbl.Text = "ITEM DETAIL : ";
            if (this.Text.IndexOf("DEPOSIT") != -1)
            {
                withdraw_reason_lbl.Visible = false;
                withdraw_reason.Visible = false;
                line_sep.Visible = false;

                barcode_lbl.Top = amount_lbl.Top = 10;
                DGV.Height += 35;
            }
            if (this.Text.IndexOf("WITHDRAW") != -1)
            {
                withdraw_reason_lbl.Visible = true;
                withdraw_reason.Visible = true;
                line_sep.Visible = true;

                withdraw_reason_lbl.Top = 10;
                withdraw_reason.Top = withdraw_reason_lbl.Top - 3;
                line_sep.Top = withdraw_reason_lbl.Top + 25;
                line_sep.Width = DGV.Width;

                barcode_lbl.Top = amount_lbl.Top = line_sep.Top + 10;
            }

            code.Top = amount.Top = barcode_lbl.Top - 3;
            item_detail_lbl.Top = barcode_lbl.Top + 25;
            DGV.Top = item_detail_lbl.Top + 25;

            DGV.Columns.Add("ITEM_NAME", "ITEM NAME");
            DGV.Columns.Add("DATA_AMOUNT", "AMOUNT");
            DGV.Columns.Add("ITEM_ID", "ITEM_ID");

            DGV.Columns["ITEM_ID"].Visible = false;
        }

        private void DGV_Paint(object sender, PaintEventArgs e)
        {
            DataGridView sndr = (DataGridView)sender;

            if (sndr.Rows.Count == 0) // <-- if there are no rows in the DataGridView when it paints, then it will create your message
            {
                using (Graphics grfx = e.Graphics)
                {
                    // create a white rectangle so text will be easily readable
                    grfx.FillRectangle(Brushes.Plum, new Rectangle(new Point(), new Size(sndr.Width, sndr.Height)));
                    // write text on top of the white rectangle just created
                    grfx.DrawString("--- NO DATA ---", new Font("Microsoft Sans Serif", 18, FontStyle.Bold), Brushes.Black, new PointF((sndr.Width / 2) - 100, (sndr.Height / 2) - 25));
                }
            }
        }

        private void code_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (code.Text.Trim() != "")
                {
                    currentItemID = -1;
                    String queryString = @"
                    SELECT
                        B.ITEM_CODE,
                        B.ITEM_NAME,
                        B.ITEM_ID,
                        C.ITEM_TYPE_NAME
                    FROM ITEM_PRICE A
                    INNER JOIN ITEM B ON A.ITEM_ID = B.ITEM_ID
                    INNER JOIN ITEM_TYPE C ON B.ITEM_TYPE_ID = C.ITEM_TYPE_ID
                    WHERE A.IS_USE = 1 AND B.IS_USE = 1 AND C.IS_USE = 1
                    AND (B.BARCODE = " + code.Text + @" OR B.ITEM_CODE = '" + code.Text + @"')
                    ORDER BY C.ITEM_TYPE_NAME, B.ITEM_CODE";

                    Dictionary<string, string> Params = new Dictionary<string, string>();
                    //Params.Add("@code", code.Text);

                    using (DataTable DT = DB.getS(queryString, Params, "SEARCH ITEM FROM CODE[" + code.Text.Trim() + "]", false))
                    {
                        if (DT.Rows.Count == 0)
                        {
                            MessageBox.Show("NO ITEM WITH THIS CODE !!", "ERROR");
                            code.Text = "";
                            return;
                        }
                        else
                        {
                            DataRow myDR = DT.Rows[0];
                            Int32.TryParse(myDR["ITEM_ID"].ToString(), out currentItemID);
                            item_detail_lbl.Text = "ITEM DETAIL : #" + myDR["ITEM_CODE"].ToString() + " " + myDR["ITEM_NAME"].ToString() + " (" + myDR["ITEM_TYPE_NAME"].ToString() + ")";
                            SendKeys.Send("{TAB}");
                        }
                    }
                }
            }
        }

        private void amount_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (amount.Text.Trim() != "")
                {
                    int tmpAmount = -1;
                    if (!Int32.TryParse(amount.Text.Trim(), out tmpAmount))
                    {
                        MessageBox.Show("AMOUNT MUST BE NUMBER !!", "ERROR");
                        amount.Select();
                        return;
                    }
                    else
                    {
                        int foundAt = -1;
                        foreach (DataGridViewRow row in DGV.Rows)
                        {
                            if (row.Cells["ITEM_ID"].Value.ToString() == currentItemID.ToString())
                            {
                                foundAt = row.Index;
                                break;
                            }
                        }
                        if (foundAt != -1)
                        {
                            DGV.Rows[foundAt].Cells["DATA_AMOUNT"].Value = GF.formatNumber(Int32.Parse(DGV.Rows[foundAt].Cells["DATA_AMOUNT"].Value.ToString().Replace(",", "")) + Int32.Parse(amount.Text));
                        }
                        else
                        {
                            DGV.Rows.Add(
                                item_detail_lbl.Text.Substring("ITEM DETAIL : ".Length),
                                GF.formatNumber(Int32.Parse(amount.Text)),
                                currentItemID.ToString()
                            );
                        }
                        code.Text = "";
                        amount.Text = "";
                        item_detail_lbl.Text = "ITEM DETAIL : ";
                        code.Focus();

                        int rowNum = DGV.Rows.Count - 1;
                        if (foundAt != -1) rowNum = foundAt;

                        DGV[1, rowNum].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        DGV[2, rowNum].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        currentItemID = -1;
                    }
                }
            }
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if (this.Text.IndexOf("WITHDRAW") != -1)
            {
                if (withdraw_reason.Text.Trim() == "")
                {
                    MessageBox.Show("PLEASE ENTER WITHDRAW REASON !!", "ERROR");
                    withdraw_reason.Focus();
                    return;
                }
            }
            if (DGV.Rows.Count == 0)
            {
                MessageBox.Show("PLEASE ADD ITEM(S) !!", "ERROR");
                code.Focus();
                return;
            }
            else
            {
                GF.showLoading(this);
                DB.beginTrans(); // BEGIN TRANS

                string queryString = "INSERT INTO STORE_HISTORY ( TYPE, HISTORY_DATE, ";
                if (this.Text.IndexOf("DEPOSIT") != -1) queryString += "DEPOSIT_BY";
                if (this.Text.IndexOf("WITHDRAW") != -1) queryString += "WITHDRAW_BY, WITHDRAW_REASON";
                queryString += ") VALUES (";
                if (this.Text.IndexOf("DEPOSIT") != -1) queryString += "0, ";
                if (this.Text.IndexOf("WITHDRAW") != -1) queryString += "1, ";
                queryString += "GETDATE(), ";
                if (this.Text.IndexOf("DEPOSIT") != -1) queryString += GF.emp_id.ToString();
                if (this.Text.IndexOf("WITHDRAW") != -1) queryString += GF.emp_id.ToString() + ", '" + withdraw_reason.Text.Trim() + "'";
                queryString += ")";
                
                int store_history_id = DB.insertReturnID(queryString, "INSERT STORE_HISTORY");

                foreach (DataGridViewRow row in DGV.Rows)
                {
                    queryString = "INSERT INTO STORE_HISTORY_DETAIL ( STORE_HISTORY_ID, ITEM_ID, AMOUNT";
                    queryString += ") VALUES (";
                    queryString += store_history_id.ToString() + ", ";
                    queryString += row.Cells["ITEM_ID"].Value.ToString() + ", ";
                    queryString += row.Cells["DATA_AMOUNT"].Value.ToString().Replace(",", "");
                    queryString += ")";

                    if (DB.set(queryString, "INSERT STORE_HISTORY_DETAIL[" + store_history_id.ToString() + "]"))
                    {
                        DataRowCollection dataRows = DB.getS("SELECT * FROM STORE WHERE ITEM_ID = " + row.Cells["ITEM_ID"].Value.ToString(), null, "CHECK STORE FOR ITEM_ID[" + row.Cells["ITEM_ID"].Value.ToString() + "]", false).Rows;
                        if (dataRows.Count == 0)
                        {
                            //RETURN 0 ROW

                            // IF DEPOSIT -> INSERT
                            if (this.Text.IndexOf("DEPOSIT") != -1)
                            {
                                queryString = "INSERT INTO STORE (ITEM_ID, CURRENT_AMOUNT, LAST_CHANGE) VALUES (";
                                queryString += row.Cells["ITEM_ID"].Value.ToString() + ", ";
                                queryString += row.Cells["DATA_AMOUNT"].Value.ToString().Replace(",", "") + ", ";
                                queryString += "GETDATE()";
                                queryString += ")";

                                if (!DB.set(queryString, "INSERT ITEM_ID[" + row.Cells["ITEM_ID"].Value.ToString() + "] INTO STORE"))
                                {
                                    MessageBox.Show("ERROR INSERT ITEM[" + row.Cells["ITEM_ID"].Value.ToString() + "] INTO STORE ....\r\nTRANSACTION NOW ROLLBACK .... !!", "ERROR");
                                    GF.closeLoading();
                                    return;
                                }
                            }

                            // IF WITHDRAW -> ROLLBACK -> ITEM IS NOT EXISTED IN DB
                            if (this.Text.IndexOf("WITHDRAW") != -1)
                            {
                                DB.rollbackTrans();
                                MessageBox.Show("CANNOT WITHDRAW '" + row.Cells["ITEM_NAME"].Value.ToString() + "'.\r\nTHIS ITEM IS NOT EXISTED !!", "ERROR");
                                DGV.Rows[row.Index].Selected = true;
                                GF.closeLoading();
                                return;
                            }
                        }
                        else
                        {
                            //RETURN MORE THAN 0 ROW

                            //IF DEPOSIT -> UPDATE ADD AMOUNT
                            if (this.Text.IndexOf("DEPOSIT") != -1)
                            {
                                queryString = "UPDATE STORE SET CURRENT_AMOUNT = CURRENT_AMOUNT + " + row.Cells["DATA_AMOUNT"].Value.ToString().Replace(",", "") + ", LAST_CHANGE = CURRENT_TIMESTAMP WHERE ITEM_ID = " + row.Cells["ITEM_ID"].Value.ToString();

                                if (!DB.set(queryString, "DEPOSIT ITEM_ID[" + row.Cells["ITEM_ID"].Value.ToString() + "] INTO STORE"))
                                {
                                    MessageBox.Show("ERROR DEPOSIT ITEM[" + row.Cells["ITEM_ID"].Value.ToString() + "] INTO STORE ....\r\nTRANSACTION NOW ROLLBACK ....", "ERROR");
                                    GF.closeLoading();
                                    return;
                                }
                            }
                            if (this.Text.IndexOf("WITHDRAW") != -1)
                            {
                                // IF WITHDRAW -> CHECK AMOUNT LEFT
                                int current_amount = -1;
                                int item_amount = -1;

                                Int32.TryParse(dataRows[0]["CURRENT_AMOUNT"].ToString().Replace(",", ""), out current_amount);
                                Int32.TryParse(row.Cells["DATA_AMOUNT"].Value.ToString().Replace(",", ""), out item_amount);

                                if (current_amount >= item_amount) //AMOUNT LEFT MORE THAN OR EQUAL WITH WITHDRAW AMOUNT -> DEDUCT
                                {
                                    queryString = "UPDATE STORE SET CURRENT_AMOUNT = CURRENT_AMOUNT - " + row.Cells["DATA_AMOUNT"].Value.ToString().Replace(",", "") + ", LAST_CHANGE = CURRENT_TIMESTAMP WHERE ITEM_ID = " + row.Cells["ITEM_ID"].Value.ToString();

                                    if (!DB.set(queryString, "WITHDRAW ITEM_ID[" + row.Cells["ITEM_ID"].Value.ToString() + "] FROM STORE"))
                                    {
                                        MessageBox.Show("ERROR WITHDRAW ITEM[" + row.Cells["ITEM_ID"].Value.ToString() + "] FROM STORE ....\r\nTRANSACTION NOW ROLLBACK .... !!", "ERROR");
                                        GF.closeLoading();
                                        return;
                                    }
                                }
                                else //AMOUNT LEFT LESS THAN WITHDRAW AMOUNT -> ROLLBACK -> ITEM AMOUNT LEFT LESS THAN WITHDRAW AMOUNT
                                {
                                    DB.rollbackTrans();
                                    MessageBox.Show("CANNOT WITHDRAW '" + row.Cells["ITEM_NAME"].Value.ToString() + "'.\r\nITEM AMOUNT LEFT IS LESS THAN WITHDRAW AMOUNT !!", "ERROR");
                                    DGV.Rows[row.Index].Selected = true;
                                    GF.closeLoading();
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("ERROR INSERT STORE_HISTORY_DETAIL[" + store_history_id.ToString() + "] ....\r\nTRANSACTION NOW ROLLBACK .... !!", "ERROR");
                        GF.closeLoading();
                        return;
                    }
                }

                GF.closeLoading();
                DB.close();
                ((store)this.Owner).loadGridData();
                this.Close();
            }
        }

        private void DGV_KeyUp(object sender, KeyEventArgs e)
        {
            if (DGV.SelectedRows.Count != 0)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    DGV.Rows.RemoveAt(DGV.SelectedRows[0].Index);
                }
            }
        }
        
        private void store_manage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Activate();
        }

        private void DGV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            GF.updateRowNum(DGV);
        }

        private void DGV_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GF.updateRowNum(DGV);
        }

        private void code_TextChanged(object sender, EventArgs e)
        {
            if (currentItemID != -1)
            {
                code.Text = "";
                currentItemID = -1;
                item_detail_lbl.Text = "";
            }
        }

        private void amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
