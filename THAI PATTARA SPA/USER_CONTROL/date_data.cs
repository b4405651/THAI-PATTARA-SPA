using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM
{
    public partial class date_data : UserControl
    {
        public date_data()
        {
            InitializeComponent();
            my_date.Mask = "00" + GF.dateSep + "00" + GF.dateSep + "0000";
            my_date.ValidatingType = typeof(System.DateTime);
        }
        public override string Text { get { return my_date.Text; } set { my_date.Text = value; } }

        private void my_date_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!GF.emptyDate(Text.Trim()))
            {
                if (!e.IsValidInput || Text.Trim().Length != 10 || !GF.isValidDate(Text.Trim()))
                {
                    MessageBox.Show("INVALID DATE !! PLEASE CHECK THE DATE AGAIN !!\r\n\r\n HINT : DATE MUST BE ONLY IN FORMAT DD/MM/YYYY !!", "ERROR");
                    my_date.Select();
                    GF.closeLoading();
                    return;
                }
            }
        }

        private void my_date_TextChanged(object sender, EventArgs e)
        {
            if (Text.Trim().Length == 10) SendKeys.Send("{ENTER}");
        }

        private void my_date_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!GF.isValidDate(my_date.Text))
                {
                    MessageBox.Show("INVALID DATE FORMAT !!\r\nPLEASE CHECK !!", "ERROR");
                    e.Handled = true;
                }
            }
        }

        private void my_date_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
