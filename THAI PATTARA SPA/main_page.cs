using SPA_MANAGEMENT_SYSTEM.AGENT;
using SPA_MANAGEMENT_SYSTEM.CARD_USAGE;
using SPA_MANAGEMENT_SYSTEM.COUPON;
using SPA_MANAGEMENT_SYSTEM.CROSS_PROMOTION;
using SPA_MANAGEMENT_SYSTEM.CUSTOMER;
using SPA_MANAGEMENT_SYSTEM.DEBTOR;
using SPA_MANAGEMENT_SYSTEM.EMP;
using SPA_MANAGEMENT_SYSTEM.GIFT_CERTIFICATE;
using SPA_MANAGEMENT_SYSTEM.VOUCHER;
using SPA_MANAGEMENT_SYSTEM.ITEM;
using SPA_MANAGEMENT_SYSTEM.MEMBERSHIP;
using SPA_MANAGEMENT_SYSTEM.PROMOTION;
using SPA_MANAGEMENT_SYSTEM.RESERVATION;
using SPA_MANAGEMENT_SYSTEM.SHOP;
using SPA_MANAGEMENT_SYSTEM.SPA;
using SPA_MANAGEMENT_SYSTEM.VIP_CARD;
using SPA_MANAGEMENT_SYSTEM.STORE;
using SPA_MANAGEMENT_SYSTEM.USER;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Deployment.Application;

namespace SPA_MANAGEMENT_SYSTEM
{
    public partial class main_page : Form
    {
        Timer clock;
        public main_page()
        {
            InitializeComponent();

            //File.WriteAllText(GF.path, String.Empty);

            GF.doDebug("===== MAIN FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== MAIN FORM :: " + this.Name + " IS CLOSED =====");
            };

            GF.mainPage = this;

            GF.initLoading();
            GF.showLoading(this);
            DB.initLocalVars();
            
            switch (CultureInfo.CurrentCulture.Name)
            {
                case "th-TH":
                case "en-US":
                    GF.dateSep = "/";
                    GF.thousandSep = ",";
                    GF.decimalSep = ".";
                    break;
                case "ru-RU":
                    GF.dateSep = ".";
                    GF.thousandSep = " ";
                    GF.decimalSep = ",";
                    break;
            }

            using (clock = new Timer())
            {
                clock.Enabled = true;
                clock.Interval = 100;
                int count = 0;
                clock.Tick += (s, ee) =>
                {
                    count++;
                    uint idleTime = 0;
                    GF.LASTINPUTINFO lastInputInfo = new GF.LASTINPUTINFO();
                    lastInputInfo.cbSize = (uint)Marshal.SizeOf(lastInputInfo);
                    lastInputInfo.dwTime = 0;

                    uint envTicks = (uint)Environment.TickCount;

                    if (GF.GetLastInputInfo(ref lastInputInfo))
                    {
                        uint lastInputTick = lastInputInfo.dwTime;

                        idleTime = envTicks - lastInputTick;
                    }
                    //GF.doDebug(">>>>>>>>>> " + idleTime.ToString());
                    if (Math.Floor(Convert.ToDouble(idleTime / 1000)) >= (10 * 60))
                    {
                        logOutTopToolStripMenuItem.PerformClick();
                    }

                    String language_txt = InputLanguage.CurrentInputLanguage.Culture.EnglishName;
                    if (language_txt.ToUpper().IndexOf("ENGLISH") != -1) language_txt = "ENGLISH";
                    if (language_txt.ToUpper().IndexOf("THAI") != -1) language_txt = "ไทย";
                    if (language_txt.ToUpper().IndexOf("RUSSIAN") != -1) language_txt = "РУССКИЙ";
                    language.Text = language_txt;

                    if (count % 10 == 0)
                    {
                        timenow.Text = GF.NOW();
                        count = 0;
                    }
                    GF.ClickButtonLabeledOK("Hotel lock system interface");
                };
            }

            if (!GF.is_logged_in)
            {
                this.Hide();
                /*if (!DB.skipFileCheck)
                {
                    using (progress progressPage = new progress())
                    {
                        progressPage.Owner = this;
                        progressPage.ShowDialog();
                    }
                }
                else
                {*/
                    using (login loginPage = new login())
                    {
                        loginPage.Owner = this;
                        GF.closeLoading();
                        loginPage.ShowDialog();
                    }
                //}
            }
        }

        private void main_page_Load(object sender, EventArgs e)
        {
            if (!GF.is_logged_in)
            {
                this.Close();
                return;
            }

            if (ApplicationDeployment.IsNetworkDeployed) version.Text = "V." + ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4);

            this.Top = this.Left = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            
            foreach (ToolStripMenuItem menu in this.MainMenuStrip.Items)
            {
                foreach (ToolStripMenuItem sub_menu_lv1 in menu.DropDownItems.OfType<ToolStripMenuItem>())
                {
                    sub_menu_lv1.Click += new EventHandler(dropDownItem_Click);
                    foreach (ToolStripMenuItem sub_menu_lv2 in sub_menu_lv1.DropDownItems.OfType<ToolStripMenuItem>())
                    {
                        sub_menu_lv2.Click += new EventHandler(dropDownItem_Click);
                    }
                }
            }
            GF.pageTop = 10;
            //GF.bottomBound = statusStrip1.Height;
            //GF.showLoading(this);
        }

        static void dropDownItem_Click(object sender, EventArgs e)
        {
            itemClicked(((ToolStripMenuItem)sender).Name);
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clock.Dispose();
            this.Close();
        }

        private void menuStrip1_Click(object sender, EventArgs e)
        {
            itemClicked(((ToolStripMenuItem)sender).Name);
        }

        private static void itemClicked(string name)
        {
            if (GF.form != null && GF.mainPage.ActiveMdiChild != null)
            {
                if (GF.mainPage.ActiveMdiChild.Name.Trim() == "cashier")
                {
                    if (((cashier)GF.mainPage.ActiveMdiChild).done_btn.Visible)
                    {
                        DialogResult theResult = MessageBox.Show("YOU DID NOT CLICK 'DONE' BUTTON YET !!\r\n\r\nYOU REALLY WANT TO LEAVE ?", "WARNING !!", MessageBoxButtons.YesNo);
                        if (theResult == DialogResult.No)
                        {
                            return;
                        }
                    }
                }
            }

            switch (name.Replace("ToolStripMenuItem", ""))
            {
                case "cardCheck":
                    using (scan_barcode scan = new scan_barcode())
                    {
                        scan.Mode = "CARD_CHECK";
                        scan.Owner = GF.mainPage;
                        scan.ShowDialog();
                    }
                    break;
                //CONFIG :: CROSS_PROMOTION
                case "crossPromotion":
                    GF.form = new cross_promotion();
                    break;
                //RE-ISSUE CARD
                case "reIssueCard":
                    GF.form = new re_issue_card();
                    break;
                //CONFIG :: COUPON SET
                case "couponSet":
                    GF.form = new config_coupon_set();
                    break;
                //CONFIG :: MEMBER CARD
                case "memberCard":
                    GF.form = new config_member_card();
                    break;
                //CONFIG :: VIP CARD
                case "VIPCard":
                    GF.form = new vip_card();
                    break;
                //CONFIG :: GIFT CERTIFICATE
                case "giftCertificateConfig":
                    using (gift_certificate_manage giftCertificateConfig = new gift_certificate_manage())
                    {
                        giftCertificateConfig.ShowDialog();
                    }
                    break;
                //CONFIG :: GIFT VOUCHER
                case "voucherConfig":
                    using (voucher_manage voucherConfig = new voucher_manage())
                    {
                        voucherConfig.ShowDialog();
                    }
                    break;
                case "issueEVoucher":
                    using (issue_e_voucher issueEVoucher = new issue_e_voucher())
                    {
                        issueEVoucher.ShowDialog();
                    }
                    break;

                //CONFIG :: AGENT
                case "agent":
                    GF.form = new agent_list();
                    break;

                //CONFIG :: HR
                case "configDepartment":
                    GF.form = new config_department();
                    break;
                case "configWorkTime":
                    GF.form = new config_work_time();
                    break;
                case "configYearlyDayOff":
                    GF.form = new config_yearly_dayoff();
                    break;

                // CONFIG :: SPA
                case "spaItem":
                    GF.form = new spa_item();
                    break;
                case "spaProgram":
                    GF.form = new program();
                    break;
                case "spaProgramType":
                    GF.form = new program_type();
                    break;
                case "promotion":
                    GF.form = new promotion();
                    break;

                // CONFIG :: STORE
                case "itemCatagory":
                    GF.form = new item_categories();
                    break;
                case "storeItem":
                    GF.form = new item();
                    break;
                case "unit":
                    GF.form = new unit();
                    break;

                // CONFIG :: DEBTOR
                case "configDebtor":
                    GF.form = new debtor_data();
                    break;

                // CONFIG :: USERS
                case "manageUsers":
                    GF.form = new user_page();
                    break;
                case "usersAuth":
                    GF.form = new users_auth();
                    break;
                case "logs":
                    GF.form = new log();
                    break;

                // RESERVE ::
                case "reserveTop":
                    GF.form = new reservation();
                    break;
                case "dailySummary":
                    GF.form = new report_daily_summary();
                    break;
                case "bookingCancelReport":
                    GF.form = new report_booking_cancel();
                    break;
                case "endDayMassageReport":
                    GF.form = new report_massage_end_day();
                    break;
                case "massageHour":
                    GF.form = new report_therapist();
                    break;
                case "massageHourSummaryReport":
                    GF.form = new report_massage_hour_summary();
                    break;
                case "monthlyMassageHourReport":
                    GF.form = new report_monthly_massage_hour_report();
                    break;
                case "spaProgramSummaryReport":
                    GF.form = new report_spa_program_summary();
                    break;
                case "customerSummaryReport":
                    GF.form = new report_customer_summary();
                    break;

                // SHOP ::
                case "cashierTop":
                    GF.form = new cashier();
                    break;
                case "sellingPrice":
                    GF.form = new selling_price();
                    break;
                case "endDayCashierReport":
                    GF.form = new report_cashier_end_day();
                    break;
                case "revenueReport":
                    GF.form = new report_revenue();
                    break;
                case "soldItemReport":
                    GF.form = new report_sold_item();
                    break;
                case "soldItemSummaryReport":
                    GF.form = new report_sold_item_summary();
                    break;
                case "miscItemReport":
                    GF.form = new report_misc_item();
                    break;

                // STORE ::
                case "storeManage":
                    GF.form = new store();
                    break;
                case "storeTransaction":
                    GF.form = new store_transaction();
                    break;

                // ACCOUNTING ::

                // HR
                case "contract":
                    GF.form = new emp_contract();
                    break;
                case "employeeData":
                    GF.form = new emp_data();
                    break;
                case "leave":
                    GF.form = new emp_leave();
                    break;
                case "promote":
                    GF.form = new emp_promote();
                    break;
                case "monthlyClockInOutReport":
                    GF.form = new report_monthly_clock_in_out();
                    break;
                case "fingerPrintLog":
                    GF.form = new report_finger_print_log();
                    break;

                // CUSTOMER
                case "customer":
                    GF.form = new customer();
                    break;
                case "customerListReport":
                    GF.form = new report_customer_list();
                    break;
                case "customerHistory":
                    GF.form = new report_customer_history();
                    break;
                case "memberCardOfCustomer":
                    GF.form = new report_membercard_in_customer();
                    break;

                //COUPON
                case "couponTop":
                    GF.form = new coupon();
                    break;

                //CARD USAGE
                case "memberCardBalanceSummary":
                    GF.form = new report_member_card_balance_summary();
                    break;
                case "memberCardUsage":
                    GF.form = new report_member_card_usage();
                    break;
                case "vipCardUsage":
                    GF.form = new report_vip_card_usage();
                    break;

                //STOCK
                case "itemListReport":
                    GF.form = new report_item_list();
                    break;
                case "stockTransactionReport":
                    GF.form = new report_stock_transaction();
                    break;

                //DEBTOR REPORT
                case "debtorListReport":
                    GF.form = new report_debtor();
                    break;
                case "debtDetailReport":
                    GF.form = new report_debt_detail();
                    break;

                default:
                    GF.form = null;
                    break;
            }

            if (GF.form != null) GF.initPage(GF.form, GF.mainPage);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            itemClicked(e.ClickedItem.Name);
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (change_pwd changePassword = new change_pwd())
            {
                changePassword.Owner = this;
                changePassword.ShowDialog();
            }
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GF.allowMinimize = true;
            this.WindowState = FormWindowState.Minimized;
            /*this.clock.Enabled = false;
            if (GF.clock != null)
            {
                GF.clock.Enabled = false;
            }*/
        }

        private void main_page_SizeChanged(object sender, EventArgs e)
        {
            if (((main_page)sender).WindowState == FormWindowState.Minimized && !GF.allowMinimize)
            {
                //((main_page)sender).WindowState = FormWindowState.Maximized;
                this.Width = Screen.PrimaryScreen.WorkingArea.Width;
                this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            }
            else if (((main_page)sender).WindowState == FormWindowState.Maximized)
            {
                GF.allowMinimize = false;
                if(this.clock != null) this.clock.Enabled = true;
                if (GF.clock != null) GF.clock.Enabled = true;
            }
        }

        private void main_page_FormClosing(object sender, FormClosingEventArgs e)
        {
            GF.doDebug(" ========== MAIN FORM IS NOW CLOSED !! ===========");
            //clock.Dispose();
            GF.closeChildren(this);
            GF.showLoading(this);
            //DB.logout();
            GF.closeLoading();
        }
    }
}
