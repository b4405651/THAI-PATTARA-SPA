using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.USER_CONTROL
{
    public partial class time_data : UserControl
    {
        public override String Text { get { return my_time.Text.Trim(); } set { my_time.Text = value; } }
        public Boolean isEmpty { get { return (my_time.Text.Trim() == ":"); } }
        public Boolean isValid { get { return (GF.validTime.IsMatch(my_time.Text.Trim())); } }
        public time_data()
        {
            InitializeComponent();
        }

        private void my_time_TextChanged(object sender, EventArgs e)
        {
            if (Text.Trim().Length == 5) SendKeys.Send("{TAB}");
        }

        private void time_data_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
