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
    public partial class emp_data_resign : Form
    {
        public emp_data_resign()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };

            //GF.resizeMgmtForm(this);
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (GF.emptyDate(resign_date.Text.Trim()))
            {
                MessageBox.Show("PLEASE ENTER RESIGN DATE !!", "ERROR");
                resign_date.Focus();
                return;
            }

            GF.showLoading(this);
            DB.beginTrans();
            string queryString = "UPDATE EMPLOYEE SET EMP_STATUS = 0, RESIGN_DATE = " + GF.modDate(resign_date.Text.Trim()) + " WHERE EMP_ID = " + GF.selected_id.ToString();
            if (DB.set(queryString, "RESIGN EMP[" + GF.selected_id.ToString() + "]"))
            {
                GF.closeLoading();
                DB.close();
                ((btn_dgv)this.Owner.Controls["btn_dgv"]).refresh_btn.PerformClick();
                this.Close();
            }
            else
            {
                MessageBox.Show("ERROR RESIGN AN EMPLOYEE !!", "ERROR");
                GF.closeLoading();
                return;
            }
        }

        private void emp_data_resign_Load(object sender, EventArgs e)
        {
            resign_date.Text = GF.TODAY();
        }

        private void emp_data_resign_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Activate();
        }
    }
}
