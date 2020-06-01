namespace SPA_MANAGEMENT_SYSTEM.CARD_USAGE
{
    partial class report_vip_card_usage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.card_no_lbl = new System.Windows.Forms.Label();
            this.print_report = new SPA_MANAGEMENT_SYSTEM.USER_CONTROL.print_report();
            this.card_no = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.excelViewer = new SPA_MANAGEMENT_SYSTEM.USER_CONTROL.ExcelViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // card_no_lbl
            // 
            this.card_no_lbl.AutoSize = true;
            this.card_no_lbl.BackColor = System.Drawing.Color.Transparent;
            this.card_no_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.card_no_lbl.Location = new System.Drawing.Point(3, 9);
            this.card_no_lbl.Name = "card_no_lbl";
            this.card_no_lbl.Size = new System.Drawing.Size(99, 18);
            this.card_no_lbl.TabIndex = 49;
            this.card_no_lbl.Text = "CARD NO : ";
            // 
            // print_report
            // 
            this.print_report.Location = new System.Drawing.Point(296, 4);
            this.print_report.Name = "print_report";
            this.print_report.Size = new System.Drawing.Size(32, 28);
            this.print_report.TabIndex = 51;
            // 
            // card_no
            // 
            this.card_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.card_no.Location = new System.Drawing.Point(102, 6);
            this.card_no.Name = "card_no";
            this.card_no.Size = new System.Drawing.Size(192, 24);
            this.card_no.TabIndex = 52;
            this.card_no.Tag = "barcode";
            this.card_no.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.card_no_KeyPress);
            this.card_no.KeyUp += new System.Windows.Forms.KeyEventHandler(this.card_no_KeyUp);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.card_no_lbl);
            this.panel1.Controls.Add(this.card_no);
            this.panel1.Controls.Add(this.print_report);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(965, 39);
            this.panel1.TabIndex = 53;
            // 
            // excelViewer
            // 
            this.excelViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.excelViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.excelViewer.Location = new System.Drawing.Point(10, 39);
            this.excelViewer.Name = "excelViewer";
            this.excelViewer.Size = new System.Drawing.Size(965, 517);
            this.excelViewer.TabIndex = 54;
            // 
            // report_vip_card_usage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(985, 566);
            this.ControlBox = false;
            this.Controls.Add(this.excelViewer);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "report_vip_card_usage";
            this.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "MEMBER CARD USAGE REPORT";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.report_vip_card_usage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label card_no_lbl;
        private USER_CONTROL.print_report print_report;
        private System.Windows.Forms.TextBox card_no;
        private System.Windows.Forms.Panel panel1;
        private USER_CONTROL.ExcelViewer excelViewer;
    }
}