using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM
{
    public partial class viewer : Form
    {
        public bool hidePrint = false;
        string _filename = "";
        public string filename { get { return _filename; } set { _filename = value; } }
        public string folderName = "ATTACHMENT";
        Image _file = null;
        public Image file { get { return _file; } set { _file = value; } }

        int theLeft = 0;
        int theWidth = 0;
        int theHeight = 0;

        public viewer()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };
        }

        private void viewer_Load(object sender, EventArgs e)
        {
            GF.showLoading(this);

            if (hidePrint)
            {
                panel.Height += toolbar.Height;
                panel.Top = toolbar.Top;
                toolbar.Visible = false;
            }
            
            file = FTP.download(filename, folderName);

            double percentage = 0.00;

            if (file.Width > this.Width)
            {
                percentage = ((double)(Width) / (double)file.Width);
            }

            theWidth = file.Width;
            theHeight = file.Height;

            if (percentage != 0.00)
            {
                theWidth = (Int32)(theWidth * percentage) - 23;
                theHeight = (Int32)(theHeight * percentage);
            }
            else
            {
                theLeft = ((panel.Width - theWidth) / 2);
            }

            panel.AutoScrollMinSize = new Size(theWidth, theHeight);
            GF.closeLoading();
            this.Focus();
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            if (file != null)
            {
                e.Graphics.TranslateTransform(panel.AutoScrollPosition.X, panel.AutoScrollPosition.Y);
                e.Graphics.DrawImage(file, theLeft, 0, theWidth, theHeight);
            }
        }

        private void print_preview_btn_Click(object sender, EventArgs e)
        {
            GF.showLoading(this);
            PRINT.initPrint(false, "ATTACHMENT", filename, this);
        }

        private void viewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (file != null) file.Dispose();
        }
    }
}
