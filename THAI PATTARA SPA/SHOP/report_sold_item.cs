using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.SHOP
{
    public partial class report_sold_item : Form
    {
        int cbHeight = 0;
        public report_sold_item()
        {
            InitializeComponent();

            print_report.PrintClick += (s, e) => { print_report.url = "cashier/sold_item/3/" + getParam(); };
        }

        private void report_sold_item_Load(object sender, EventArgs e)
        {
            report_date2.Text = report_date1.Text = GF.TODAY();
            report_date1.Focus();

            String queryString = "SELECT * FROM ITEM_TYPE WHERE IS_USE = 1 ORDER BY ITEM_TYPE_NAME";
            using (DataTable DT = DB.getS(queryString, null, "GET ITEM TYPE", false))
            {
                int useLeft = 130;
                int useTop = 43;
                int maxWidth = this.Width - 130 - 15;
                foreach (DataRow row in DT.Rows)
                {
                    CheckBox cb = new CheckBox();

                    cb.Name = row["ITEM_TYPE_ID"].ToString();
                    cb.Text = row["ITEM_TYPE_NAME"].ToString();
                    cb.Top = useTop;
                    cb.Left = useLeft;
                    cb.AutoSize = true;
                    Font fnt = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);
                    cb.Font = fnt;
                    useLeft += TextRenderer.MeasureText(cb.Text, fnt).Width + 50;
                    if (useLeft >= maxWidth)
                    {
                        useLeft = 130;
                        useTop += TextRenderer.MeasureText(cb.Text, fnt).Height + 5;
                    }
                    cbHeight = useTop + TextRenderer.MeasureText(cb.Text, fnt).Height + 5;

                    cb.CheckedChanged += getReport;

                    this.Controls.Add(cb);
                    //item_cat.Items.Add(new ComboItem(Convert.ToInt32(row["ITEM_TYPE_ID"].ToString()), row["ITEM_TYPE_NAME"].ToString()));
                }
            }
        }

        private void getReport(object sender, EventArgs e)
        {
            ActiveControl = excelViewer;
            excelViewer.openURL("cashier/sold_item/1/" + getParam());
        }

        private string getParam()
        {
            String param = "";
            DateTime dt1 = DateTime.ParseExact(report_date1.Text.Trim(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime dt2 = DateTime.ParseExact(report_date2.Text.Trim(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            if (DateTime.Compare(dt1, dt2) <= 0) param = report_date1.Text.Trim() + "/" + report_date2.Text.Trim() + "/";
            else param = report_date2.Text.Trim() + "/" + report_date1.Text.Trim() + "/";

            foreach (Control ctl in this.Controls)
            {
                if (ctl.GetType() == typeof(CheckBox))
                {
                    if (((CheckBox)ctl).Checked) param += ctl.Name + "_";
                }
            }
            if (param[param.Length - 1] == '_')
            {
                param = param.Substring(0, param.Length - 1);
                param += "/";
            }

            return param;
        }
    }
}
