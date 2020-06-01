using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.RESERVATION
{
    public partial class master_day_off : Form
    {
        public string res_date = "";
        public master_day_off()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };
        }

        private void master_day_off_Load(object sender, EventArgs e)
        {
            String queryString = @"
            SELECT A.*, B.RESERVATION_THERAPIST_DAY_OFF_ID DATA_ID
            FROM EMPLOYEE A
            LEFT OUTER JOIN RESERVATION_THERAPIST_DAY_OFF B ON A.EMP_ID = B.THERAPIST_ID AND B.RES_DATE = " + GF.modDate(res_date) + @"
            WHERE A.EMP_STATUS = 1 AND A.EMP_DEPT_ID = 3";
            using (DataTable DT = DB.getS(queryString, null, "GET THERAPIST", false))
            {
                foreach (DataRow row in DT.Rows)
                {
                    masterTable.Rows.Add();
                    //masterTable.Rows[masterTable.Rows.Count - 1].Cells[1].Value = GF.getNickname(row["FULLNAME"].ToString());
                    masterTable.Rows[masterTable.Rows.Count - 1].Cells[1].Value = (row["NICKNAME"].ToString().Trim() == String.Empty ? row["FULLNAME"].ToString() : row["NICKNAME"].ToString());
                    masterTable.Rows[masterTable.Rows.Count - 1].Cells[2].Value = row["EMP_ID"].ToString();
                    if(row["DATA_ID"].ToString() != "" && row["DATA_ID"].ToString() != "NULL")
                        ((DataGridViewCheckBoxCell)masterTable.Rows[masterTable.Rows.Count - 1].Cells[0]).Value = false;
                    else
                        ((DataGridViewCheckBoxCell)masterTable.Rows[masterTable.Rows.Count - 1].Cells[0]).Value = true;
                }
                masterTable.Sort(masterTable.Columns[1], ListSortDirection.Ascending);
                masterTable.ClearSelection();
            }
        }

        private void master_day_off_FormClosed(object sender, FormClosedEventArgs e)
        {
            GF.createTimer();
        }

        private void master_day_off_FormClosing(object sender, FormClosingEventArgs e)
        {
            GF.showLoading(this);
            DB.beginTrans();
            string queryString = "DELETE FROM RESERVATION_THERAPIST_DAY_OFF WHERE RES_DATE = " + GF.modDate(res_date);

            if (!DB.set(queryString, "CLEAR DAY OFF DATA [" + res_date + "]"))
            {
                MessageBox.Show("ERROR CLEAR DAY OFF DATA !!", "ERROR");
                GF.closeLoading();
                return;
            }

            foreach (DataGridViewRow row in masterTable.Rows)
            {
                if ((Boolean)((DataGridViewCheckBoxCell)row.Cells[0]).Value == false)
                {
                    queryString = "INSERT INTO RESERVATION_THERAPIST_DAY_OFF (RES_DATE, THERAPIST_ID) VALUES (" + GF.modDate(res_date) + ", " + row.Cells[2].Value.ToString().Trim() + ")";
                    if (!DB.set(queryString, "INSERT DAY OFF DATA [" + res_date + "]"))
                    {
                        MessageBox.Show("ERROR INSERT DAY OFF DATA !!", "ERROR");
                        GF.closeLoading();
                        return;
                    }
                }
            }

            DB.close();
            GF.closeLoading();
        }

        private void toggleCheckBox(int RowIndex)
        {
            ((DataGridViewCheckBoxCell)masterTable.Rows[RowIndex].Cells[0]).Value = !(Boolean)((DataGridViewCheckBoxCell)masterTable.Rows[RowIndex].Cells[0]).Value;
        }

        private void masterTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                toggleCheckBox(e.RowIndex);
            }
        }

        private void masterTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                toggleCheckBox(e.RowIndex);
            }
        }
    }
}
