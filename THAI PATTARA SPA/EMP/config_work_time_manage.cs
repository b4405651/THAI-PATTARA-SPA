using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.EMP
{
    public partial class config_work_time_manage : Form
    {
        public config_work_time_manage()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };

            GF.resizeMgmtForm(this);
        }

        private void config_work_time_manage_Load(object sender, EventArgs e)
        {
            cut_wage_unit.Items.Add(new ComboItem(0, Properties.Settings.Default.money_unit));
            cut_wage_unit.Items.Add(new ComboItem(1, "%"));
            cut_wage_unit.SelectedIndex = 0;

            if (manage_btn.Text.Trim() == "UPDATE")
            {
                string queryString = "SELECT TOP 1 IN_TIME, LATE_TIME, OUT_TIME, CUT_WAGE_AMOUNT, CUT_WAGE_UNIT FROM EMP_CONFIG_WORK_TIME WHERE EMP_CONFIG_WORK_TIME_ID = " + GF.selected_id.ToString();
                using (DataTable myDT = DB.getS(queryString, null, "GET EMP CONFIG WORK TIME [" + GF.selected_id.ToString() + "]", false))
                {
                    foreach (DataRow row in myDT.Rows)
                    {
                        in_time.Text = row["in_time"].ToString();
                        late_time.Text = row["late_time"].ToString();
                        out_time.Text = row["out_time"].ToString();
                        cut_wage_amount.Text = row["cut_wage_amount"].ToString();
                        cut_wage_unit.Text = (row["cut_wage_unit"].ToString() == "0") ? Properties.Settings.Default.money_unit : "%";
                    }
                }
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if (in_time.Text.Trim() == ":")
            {
                MessageBox.Show("PLEASE ENTER CLOCK-IN TIME.", "ERROR");
                in_time.Select();
                return;
            }
            else if (!in_time.isValid)
            {
                MessageBox.Show("TIME MUST BE ONLY IN FORMAT (00-23):(00-59) !!", "ERROR");
                in_time.Select();
                return;
            }

            if (late_time.Text.Trim() == ":")
            {
                MessageBox.Show("PLEASE ENTER LATE TIME.", "ERROR");
                late_time.Select();
                return;
            }
            else if (!late_time.isValid)
            {
                MessageBox.Show("TIME MUST BE ONLY IN FORMAT (00-23):(00-59) !!", "ERROR");
                late_time.Select();
                return;
            }

            if (out_time.Text.Trim() == ":")
            {
                MessageBox.Show("PLEASE ENTER CLOCK-OUT TIME.", "ERROR");
                out_time.Select();
                return;
            }
            else if (!out_time.isValid)
            {
                MessageBox.Show("TIME MUST BE ONLY IN FORMAT (00-23):(00-59) !!", "ERROR");
                out_time.Select();
                return;
            }

            if (cut_wage_amount.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER AMOUNT OF CUTTING WAGE.", "ERROR");
                cut_wage_amount.Select();
                return;
            }
            GF.showLoading(this);
            DB.beginTrans();

            Dictionary<string, string> Params = new Dictionary<string, string>();
            /*Params.Add("@in_time", in_time.Text);
            Params.Add("@out_time", out_time.Text);*/

            string queryString = "SELECT * FROM EMP_CONFIG_WORK_TIME WHERE IN_TIME = '" + in_time.Text + "' AND OUT_TIME = '" + out_time.Text + "'";
            if (manage_btn.Text.Trim() == "UPDATE") queryString += " AND EMP_CONFIG_WORK_TIME_ID != " + GF.selected_id.ToString();
            if (DB.getS(queryString, Params, "CHECK EMP WORK TIME BEFORE INSERT", false).Rows.Count > 0)
            {
                MessageBox.Show("WORK TIME RULE FOR SPECIFIC DATA IS ALREADY EXISTED.", "ERROR");
                GF.closeLoading();
                return;
            }

            switch (manage_btn.Text.Trim()){
                case "ADD":
                    queryString = @"INSERT INTO EMP_CONFIG_WORK_TIME (IN_TIME, LATE_TIME, OUT_TIME, CUT_WAGE_AMOUNT, CUT_WAGE_UNIT) VALUES (
                    '" + in_time.Text.Trim() + @"', 
                    '" + late_time.Text.Trim() + @"', 
                    '" + out_time.Text.Trim() + @"', 
                    " + cut_wage_amount.Text.Trim() + @", 
                    " + ((ComboItem)this.cut_wage_unit.SelectedItem).Key.ToString() + ")";
                    DB.beginTrans();
                    if (DB.set(queryString, "INSERT EMP CONFIG LATE"))
                    {
                        DB.close();
                        GF.closeLoading();
                        MessageBox.Show("RULE IS ADDED !!", "COMPLETED");
                        ((btn_dgv)this.Owner.Controls["btn_dgv"]).refresh_btn.PerformClick();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("ERROR ADDING RULE !!", "ERROR");
                        GF.closeLoading();
                        return;
                    }
                    break;
                case "UPDATE":
                    queryString = "UPDATE EMP_CONFIG_WORK_TIME SET IN_TIME = '" + in_time.Text.Trim() + "', LATE_TIME = '" + late_time.Text.Trim() + "', OUT_TIME = '" + out_time.Text.Trim() + "', CUT_WAGE_AMOUNT = " + cut_wage_amount.Text.Trim() + ", CUT_WAGE_UNIT = " + ((ComboItem)cut_wage_unit.SelectedItem).Key.ToString() + " WHERE EMP_CONFIG_WORK_TIME_ID = " + GF.selected_id.ToString();
                    DB.beginTrans();
                    if (DB.set(queryString, "UPDATE RULE"))
                    {
                        DB.close();
                        GF.closeLoading();
                        MessageBox.Show("RULE IS UPDATE !!", "COMPLETED");
                        ((btn_dgv)this.Owner.Controls["btn_dgv"]).refresh_btn.PerformClick();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("ERROR UPDATING RULE !!", "ERROR");
                        GF.closeLoading();
                        return;
                    }
                    break;
            }
        }

        private void config_work_time_manage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Activate();
        }

        private void cut_wage_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
