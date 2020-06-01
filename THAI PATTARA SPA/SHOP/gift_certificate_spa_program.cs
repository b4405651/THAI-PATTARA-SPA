using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.SHOP
{
    public partial class gift_certificate_spa_program : Form
    {
        public int billID = -1;
        public Boolean is_website = false;
        List<string> price_list;

        public gift_certificate_spa_program()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };
        }

        private void gift_certificate_spa_program_Load(object sender, EventArgs e)
        {
            GF.showLoading(this);
            price_list = new List<string>();
            String queryString = "SELECT * FROM SPA_PROGRAM WHERE IS_USE = 1 ORDER BY CODE";
            using (DataTable DT = DB.getS(queryString, null, "GET ALL ACTIVE SPA PROGRAM", false))
            {
                spa_program_id.Items.Add(new ComboItem(-1, "SPA PROGRAM"));
                foreach (DataRow row in DT.Rows)
                {
                    spa_program_id.Items.Add(new ComboItem(Convert.ToInt32(row["SPA_PROGRAM_ID"].ToString()), "[#" + row["CODE"].ToString() + "] " + row["PROGRAM_NAME"].ToString()));
                    price_list.Add(row["PRICE"].ToString());
                }
            }
            spa_program_id.SelectedIndex = 0;
            GF.resizeComboBox(spa_program_id);
            GF.closeLoading();
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if (spa_program_id.SelectedIndex == 0)
            {
                MessageBox.Show("PLEASE CHOOSE SPA PROGRAM !!", "ERROR");
                spa_program_id.Focus();
                return;
            }

            GF.showLoading(this);
            List<string> param = new List<string>();
            
            String subject = "";
            String amount = "";

            subject = spa_program_id.Text;
            if (from_txt.Text.Trim() != "") subject += " [FROM " + from_txt.Text.Trim() + "]";
            if(for_txt.Text.Trim() != "") subject +=" [FOR " + for_txt.Text.Trim() + "]";
            amount = price_list[spa_program_id.SelectedIndex - 1];

            param.Add((is_website ? "WEBSITE " : "") + "SPA MENU GIFT CERTIFICATE");
            param.Add(subject);
            param.Add(GF.formatNumber(Convert.ToInt32(amount)));
            param.Add(Properties.Settings.Default.money_unit);
            param.Add((new Random().Next(1, 1000000) * -1).ToString());
            param.Add((new Random().Next(1, 1000000) * -1).ToString());
            param.Add("1");
            param.Add(Convert.ToInt32(amount).ToString());

            ((cashier)this.Owner).pushRow("GIFT_CERTIFICATE", param);
            ((cashier)this.Owner).updateTotal();
            GF.closeLoading();
            this.Close();
        }

        private void gift_certificate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Activate();
        }
    }
}
