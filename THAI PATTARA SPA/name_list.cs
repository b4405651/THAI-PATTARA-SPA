using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM
{
    public partial class name_list : Form
    {
        public String Mode = "";
        public name_list()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };
        }

        private void resultTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                DataGridViewRow row = resultTable.Rows[e.RowIndex];
                int ID = Convert.ToInt32(row.Cells[row.Cells.Count - 1].Value.ToString());
                switch (Owner.Name)
                {
                    case "cashier":
                        SHOP.cashier billPage = (SHOP.cashier)Owner;
                        billPage.customer_id.SetID(ID);
                        //billPage.customer_id.SetText(Convert.ToInt32(row.Cells["CUSTOMER_ID"].Value.ToString()), row.Cells["NAME"].Value.ToString() + " - " + row.Cells["GENDER"].Value.ToString() + " - " + row.Cells["TEL"].Value.ToString());
                        break;

                    case "coupon_manage":
                        COUPON.coupon_manage couponManage = (COUPON.coupon_manage)Owner;
                        couponManage.debtor_id.SetID(ID);
                        break;

                    case "report_membercard_in_customer":
                        CUSTOMER.report_membercard_in_customer membercardCustomer = (CUSTOMER.report_membercard_in_customer)Owner;
                        membercardCustomer.customer_data.SetID(ID);
                        break;

                    case "report_customer_history":
                        CUSTOMER.report_customer_history customerHistory = (CUSTOMER.report_customer_history)Owner;
                        customerHistory.customer_data.SetID(ID);
                        break;

                    case "debtor_manage":
                        DEBTOR.debtor_manage debtorManage = (DEBTOR.debtor_manage)Owner;
                        debtorManage.search_name.SetID(ID);
                        break;

                    case "payment":
                        SHOP.payment paymentPage = (SHOP.payment)Owner;
                        paymentPage.debtor_id.SetID(ID);
                        break;

                    case "reservation_manage":
                        RESERVATION.reservation_manage reservationManage = (RESERVATION.reservation_manage)Owner;
                        if (Mode == "CUSTOMER")
                        {
                            reservationManage.customer_name.SetID(ID);
                            reservationManage.currentRoomID = ID;
                            reservationManage.note.Text = row.Cells["NOTE"].Value.ToString();
                        }
                        if (Mode == "AGENT")
                            reservationManage.agent_id.SetID(ID);
                        break;
                    
                    case "users_add":
                        USER.users_add userPage = (USER.users_add)Owner;
                        userPage.emp_id.SetID(ID);
                        //userPage.emp_id.SetText(Convert.ToInt32(row.Cells["EMP_ID"].Value.ToString()), row.Cells["FULLNAME"].Value.ToString());
                        break;

                    case "users_auth":
                        USER.users_auth userAuthPage = (USER.users_auth)Owner;
                        userAuthPage.emp_data.SetID(ID);
                        //userPage.emp_data.SetText(Convert.ToInt32(row.Cells["EMP_ID"].Value.ToString()), row.Cells["FULLNAME"].Value.ToString());
                        break;

                    case "vip_card":
                        VIP_CARD.vip_card_manage vipcardManage = (VIP_CARD.vip_card_manage)Owner;
                        vipcardManage.responsible_id.SetID(ID);
                        break;

                }
                this.Close();
            }
        }

        private void name_list_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Activate();
            Owner.BringToFront();
        }
    }
}
