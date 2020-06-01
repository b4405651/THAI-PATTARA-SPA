﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM
{
    public partial class line_sep : UserControl
    {
        public line_sep()
        {
            InitializeComponent();

            this.Paint += new PaintEventHandler(line_sep_Paint);
            this.MaximumSize = new Size(2000, 2);
            this.MinimumSize = new Size(0, 2);
            this.Width = 350;
        }

        private void line_sep_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawLine(Pens.DarkGray, new Point(0, 0), new Point(this.Width, 0));
            g.DrawLine(Pens.White, new Point(0, 1), new Point(this.Width, 1));
        }
    }
}