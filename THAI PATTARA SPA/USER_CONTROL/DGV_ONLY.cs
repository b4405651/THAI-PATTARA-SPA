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
    public partial class DGV_ONLY : UserControl
    {
        public DGV_ONLY()
        {
            InitializeComponent();
        }

        private void DGV_Paint(object sender, PaintEventArgs e)
        {
            DataGridView sndr = (DataGridView)sender;

            if (sndr.Rows.Count == 0) // <-- if there are no rows in the DataGridView when it paints, then it will create your message
            {
                using (Graphics grfx = e.Graphics)
                {
                    // create a white rectangle so text will be easily readable
                    grfx.FillRectangle(Brushes.Plum, new Rectangle(new Point(), new Size(sndr.Width, sndr.Height)));
                    // write text on top of the white rectangle just created
                    grfx.DrawString("--- NO DATA ---", new Font("Microsoft Sans Serif", 18, FontStyle.Bold), Brushes.Black, new PointF((sndr.Width / 2) - 100, (sndr.Height / 2)));
                }
            }
            else
            {
                foreach (DataGridViewColumn column in sndr.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
        }

        private void DGV_ONLY_Load(object sender, EventArgs e)
        {
            DGV.Size = this.Size;
        }
    }
}
