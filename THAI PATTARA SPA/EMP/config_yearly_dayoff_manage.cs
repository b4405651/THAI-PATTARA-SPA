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
    public partial class config_yearly_dayoff_manage : Form
    {
        public config_yearly_dayoff_manage()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };

            GF.resizeMgmtForm(this);
        }

        private void config_yearly_dayoff_manage_Load(object sender, EventArgs e)
        {
            if (manage_btn.Text.Trim() == "UPDATE")
            {
                string queryString = "SELECT TOP 1 YEAR_NO, DAY_NAME, CONVERT(VARCHAR,START_DATE,101) START_DATE,  CONVERT(VARCHAR,END_DATE,101) END_DATE FROM EMP_CONFIG_YEARLY_DAYOFF WHERE EMP_CONFIG_YEARLY_DAYOFF_ID = " + GF.selected_id.ToString();
                using (DataTable myDT = DB.getS(queryString, null, "GET EMP CONFIG YEARLY DAYOFF [" + GF.selected_id.ToString() + "]", false))
                {
                    foreach (DataRow myRow in myDT.Rows)
                    {
                        year.Text = myRow["year_no"].ToString();
                        day_name.Text = myRow["day_name"].ToString().Trim();
                        start_date.Text = myRow["start_date"].ToString();
                        end_date.Text = myRow["end_date"].ToString();
                    }
                }
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void year_Leave(object sender, EventArgs e)
        {
            if (year.Text.Trim() != "")
            {
                int tmp = -1;
                if (!int.TryParse(year.Text, out tmp))
                {
                    MessageBox.Show("YEAR MUST BE NUMBER ONLY !!", "ERROR");
                    year.Select();
                    return;
                }
            }
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            if (year.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER YEAR NUMBER", "ERROR");
                year.Focus();
                return;
            }
            if (day_name.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER NAME OF DAY", "ERROR");
                day_name.Focus();
                return;
            }
            if (GF.emptyDate(start_date.Text.Trim()))
            {
                MessageBox.Show("PLEASE ENTER START DATE", "ERROR");
                start_date.Focus();
                return;
            }
            if (GF.emptyDate(end_date.Text.Trim()))
            {
                MessageBox.Show("PLEASE ENTER END DATE", "ERROR");
                end_date.Focus();
                return;
            }
            
            GF.showLoading(this);
            DB.beginTrans();
            string queryString = "";
            Dictionary<string, string> Params = null;
            switch (manage_btn.Text.Trim())
            {
                case "ADD":
                    queryString = "SELECT * FROM EMP_CONFIG_YEARLY_DAYOFF WHERE START_DATE <= @start_date AND @start_date <= END_DATE";

                    Params = new Dictionary<string, string>();
                    Params.Add("@start_date", GF.modDate(start_date.Text.Trim()));

                    if (DB.getS(queryString, Params, "CHECK EMP CONFIG YEARLY DAYOFF BEFORE INSERT", false).Rows.Count > 0)
                    {
                        MessageBox.Show("DURATION FOR THE DAYOFF IS ALREADY EXISTED.", "ERROR");
                        GF.closeLoading();
                        return;
                    }
                    else
                    {
                        queryString = @"INSERT INTO EMP_CONFIG_YEARLY_DAYOFF (YEAR_NO, DAY_NAME, START_DATE, END_DATE) VALUES (
                        " + year.Text.Trim() + @", 
                        '" + day_name.Text.Trim() + @"',
                        " + GF.modDate(start_date.Text.Trim()) + @", 
                        " + GF.modDate(end_date.Text.Trim()) + @")";
                        DB.beginTrans();
                        if (DB.set(queryString, "INSERT EMP CONFIG LATE"))
                        {
                            DB.close();
                            GF.closeLoading();
                            MessageBox.Show("DAYOFF IS ADDED !!", "COMPLETED");
                            ((config_yearly_dayoff)this.Owner).getYear(Convert.ToInt32(year.Text.Trim()));
                            ((btn_dgv)this.Owner.Controls["btn_dgv"]).refresh_btn.PerformClick();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("ERROR ADDING DAYOFF !!", "ERROR");
                            GF.closeLoading();
                            return;
                        }
                    }
                    break;
                case "UPDATE":
                    Params = new Dictionary<string, string>();
                    Params.Add("@start_date", start_date.Text);
                    Params.Add("@end_date", end_date.Text);

                    queryString = "SELECT * FROM EMP_CONFIG_YEARLY_DAYOFF WHERE START_DATE <= @start_date AND @end_date <= END_DATE AND EMP_CONFIG_YEARLY_DAYOFF_ID != " + GF.selected_id.ToString();
                    if (DB.getS(queryString, Params, "CHECK EMP CONFIG YEARLY DAYOFF BEFORE INSERT", false).Rows.Count > 0)
                    {
                        MessageBox.Show("DURATION FOR THE DAYOFF IS ALREADY EXISTED.", "ERROR");
                        GF.closeLoading();
                        return;
                    }
                    else
                    {
                        queryString = "UPDATE EMP_CONFIG_YEARLY_DAYOFF SET YEAR_NO = " + year.Text.Trim() + ", DAY_NAME = '" + day_name.Text.Trim() + "', START_DATE = " + GF.modDate(start_date.Text.Trim()) + ", END_DATE = " + GF.modDate(end_date.Text.Trim()) + " WHERE EMP_CONFIG_YEARLY_DAYOFF_ID = " + GF.selected_id.ToString();
                        DB.beginTrans();
                        if (DB.set(queryString, "UPDATE RULE"))
                        {
                            DB.close();
                            GF.closeLoading();
                            MessageBox.Show("DAYOFF IS UPDATED !!", "COMPLETED");
                            ((config_yearly_dayoff)this.Owner).getYear(Convert.ToInt32(year.Text.Trim()));
                            ((btn_dgv)this.Owner.Controls["btn_dgv"]).refresh_btn.PerformClick();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("ERROR UPDATING DAYOFF !!", "ERROR");
                            GF.closeLoading();
                            return;
                        }
                    }
                    break;
            }
        }

        private void config_yearly_dayoff_manage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Activate();
        }

        private void year_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
