using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.DEBTOR
{
    public partial class debt_detail : Form
    {
        public string debtor_data_id = "";
        public debt_detail()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };
        }

        private void debt_detail_Load(object sender, EventArgs e)
        {
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

                this.btn_dgv.DGV.Columns["type"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.btn_dgv.DGV.Columns["detail"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private void loadData()
        {
            GF.showLoading(this);
            btn_dgv.DGV.Rows.Clear();
            string queryString = "SELECT * FROM DEBTOR_DATA WHERE DEBTOR_DATA_ID = " + debtor_data_id;

            using (DataTable DT = DB.getS(queryString, null, "GET DEBT DETAIL OF DEBTOR_DATA[" + debtor_data_id + "]", false))
            {
                foreach (DataRow row in DT.Rows)
                {
                    String type = "";
                    String detail = "";
                    switch (row["ITEM_TYPE"].ToString())
                    {
                        case "0":
                            queryString = "SELECT DISTINCT item_id, item_type, amount, misc_item_name FROM BILL_DETAIL WHERE BILL_ID = " + row["ITEM_ID"].ToString() + " ORDER BY MISC_ITEM_NAME";
                            using (DataTable tmp0 = DB.getS(queryString, null, "", false))
                            {
                                foreach (DataRow bill_detail_row in tmp0.Rows)
                                {
                                    switch (bill_detail_row["ITEM_TYPE"].ToString())
                                    {
                                        case "0":
                                            queryString = "SELECT * FROM RESERVATION WHERE RESERVATION_ID = " + bill_detail_row["ITEM_ID"].ToString();
                                            using (DataTable tmp1 = DB.getS(queryString, null, "", false))
                                            {
                                                type = "SPA CARD";
                                                detail += "No : " + tmp1.Rows[0]["CODE"].ToString() + " (";

                                                queryString = @"SELECT 
								                    B.CODE
							                    FROM RESERVATION_DETAIL A
							                    INNER JOIN SPA_PROGRAM B ON A.SPA_PROGRAM_ID = B.SPA_PROGRAM_ID
							                    WHERE A.RESERVATION_ID = " + bill_detail_row["ITEM_ID"].ToString() + @"
							                    ORDER BY CONVERT(FLOAT, B.CODE)";
                                                using (DataTable tmp2 = DB.getS(queryString, null, "", false))
                                                {
                                                    foreach (DataRow tmpRow in tmp2.Rows)
                                                    {
                                                        detail += "#" + tmpRow["CODE"].ToString() + ", ";
                                                    }
                                                }

                                                if (detail.Trim().Length > 0) detail = detail.Substring(0, detail.Trim().Length - 1);

                                                detail += ")";
                                            }
                                            break;
                                        case "1":
                                            queryString = "SELECT A.card_no, B.membercard_type_name FROM MEMBERCARD A INNER JOIN MEMBERCARD_TYPE B ON A.MEMBERCARD_TYPE_ID = B.MEMBERCARD_TYPE_ID WHERE A.MEMBERCARD_ID = " + bill_detail_row["ITEM_ID"];
                                            using (DataTable tmp1 = DB.getS(queryString, null, "", false))
                                            {
                                                type = "MEMBERCARD";
                                                detail += "No : " + tmp1.Rows[0]["card_no"].ToString() + " (" + tmp1.Rows[0]["membercard_type_name"].ToString() + ")";
                                            }
                                            break;
                                        case "2":
                                        case "3":
                                            queryString = "SELECT * FROM GIFT_CERTIFICATE WHERE GIFT_CERTIFICATE_ID = " + bill_detail_row["ITEM_ID"];
                                            using (DataTable tmp1 = DB.getS(queryString, null, "", false))
                                            {
                                                detail += "No : " + tmp1.Rows[0]["card_no"].ToString();
                                                if (bill_detail_row["ITEM_TYPE"].ToString() == "3") type = "MONEY GIFT CERTIFICATE";
                                                else
                                                {
                                                    type = "SPA MENU GIFT CERTIFICATE";
                                                    queryString = "SELECT CODE FROM SPA_PROGRAM WHERE SPA_PROGRAM_ID = " + tmp1.Rows[0]["spa_program_id"];
                                                    using (DataTable tmp2 = DB.getS(queryString, null, "", false))
                                                    {
                                                        detail += " (SPA PROGRAM #" + tmp2.Rows[0]["CODE"].ToString() + ")";
                                                    }
                                                }
                                            }
                                            break;
                                        case "4":
                                            if (bill_detail_row["misc_item_name"].ToString() != "")
                                            {
                                                type = "MISC ITEM";
                                                detail += bill_detail_row["misc_item_name"] + " x " + bill_detail_row["amount"];
                                            }
                                            else
                                            {
                                                queryString = "SELECT A.item_code, A.item_name, B.item_type_name FROM ITEM A INNER JOIN ITEM_TYPE B ON A.ITEM_TYPE_ID = B.ITEM_TYPE_ID WHERE A.ITEM_ID = " + bill_detail_row["item_id"] + " ORDER BY A.ITEM_NAME";
                                                using (DataTable tmp1 = DB.getS(queryString, null, "", false))
                                                {
                                                    type = tmp1.Rows[0]["item_type_name"].ToString();
                                                    detail += "#" + tmp1.Rows[0]["item_code"].ToString() + "-" + tmp1.Rows[0]["item_name"].ToString() + " x " + bill_detail_row["amount"].ToString() + ", ";
                                                }
                                            }
                                            break;
                                    }
                                }
                            }
                            break;
                        case "1":
                            type = "SINGLE COUPON";
                            queryString = "SELECT CARD_NO FROM COUPON WHERE COUPON_ID = " + row["item_id"];
                            using (DataTable tmp0 = DB.getS(queryString, null, "", false))
                            {
                                detail += "No : " + tmp0.Rows[0]["CARD_NO"].ToString();
                            }
                            break;
                        case "2":
                            queryString = @"
					        SELECT 
						        B.COUPON_SET_NAME 
					        FROM COUPON_SET A
					        INNER JOIN COUPON_SET_CONFIG B ON A.COUPON_SET_CONFIG_ID = B.COUPON_SET_CONFIG_ID
					        WHERE A.COUPON_SET_ID = " + row["item_id"];
                            using (DataTable tmp0 = DB.getS(queryString, null, "", false))
                            {
                                type = "COUPON SET";
                                detail += "[" + tmp0.Rows[0]["COUPON_SET_NAME"].ToString() + "] (";
                                queryString = "SELECT CARD_NO FROM COUPON WHERE COUPON_SET_ID = " + row["item_id"] + " ORDER BY CARD_NO";
                                using (DataTable tmp1 = DB.getS(queryString, null, "", false))
                                {
                                    foreach (DataRow tmpRow in tmp1.Rows)
                                    {
                                        detail += tmpRow["CARD_NO"].ToString() + ", ";
                                    }
                                }
                                if (detail.Trim().Length > 0) detail = detail.Substring(0, detail.Trim().Length - 1);
                            }
                            break;
                    }
                    

                    btn_dgv.DGV.Rows.Add(type, detail);
                }
                this.btn_dgv.DGV.ClearSelection();
                GF.updateRowNum(btn_dgv.DGV, true);
            }
            GF.closeLoading();
        }
    }
}
