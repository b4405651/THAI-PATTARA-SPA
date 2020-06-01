namespace SPA_MANAGEMENT_SYSTEM.SHOP
{
    partial class report_sold_item_summary
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
            this.report_from_date_lbl = new System.Windows.Forms.Label();
            this.print_report = new SPA_MANAGEMENT_SYSTEM.USER_CONTROL.print_report();
            this.report_date1 = new System.Windows.Forms.DateTimePicker();
            this.report_date2 = new System.Windows.Forms.DateTimePicker();
            this.report_to_date_lbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.excelViewer = new SPA_MANAGEMENT_SYSTEM.USER_CONTROL.ExcelViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // report_from_date_lbl
            // 
            this.report_from_date_lbl.AutoSize = true;
            this.report_from_date_lbl.BackColor = System.Drawing.Color.Transparent;
            this.report_from_date_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.report_from_date_lbl.Location = new System.Drawing.Point(3, 9);
            this.report_from_date_lbl.Name = "report_from_date_lbl";
            this.report_from_date_lbl.Size = new System.Drawing.Size(120, 18);
            this.report_from_date_lbl.TabIndex = 49;
            this.report_from_date_lbl.Text = "FROM DATE : ";
            // 
            // print_report
            // 
            this.print_report.Location = new System.Drawing.Point(483, 4);
            this.print_report.Name = "print_report";
            this.print_report.Size = new System.Drawing.Size(32, 28);
            this.print_report.TabIndex = 51;
            // 
            // report_date1
            // 
            this.report_date1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.report_date1.CustomFormat = "dd/MM/yyyy";
            this.report_date1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.report_date1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.report_date1.Location = new System.Drawing.Point(121, 6);
            this.report_date1.Name = "report_date1";
            this.report_date1.Size = new System.Drawing.Size(124, 24);
            this.report_date1.TabIndex = 113;
            this.report_date1.ValueChanged += new System.EventHandler(this.report_date_ValueChanged);
            // 
            // report_date2
            // 
            this.report_date2.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.report_date2.CustomFormat = "dd/MM/yyyy";
            this.report_date2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.report_date2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.report_date2.Location = new System.Drawing.Point(355, 6);
            this.report_date2.Name = "report_date2";
            this.report_date2.Size = new System.Drawing.Size(124, 24);
            this.report_date2.TabIndex = 115;
            this.report_date2.ValueChanged += new System.EventHandler(this.report_date_ValueChanged);
            // 
            // report_to_date_lbl
            // 
            this.report_to_date_lbl.AutoSize = true;
            this.report_to_date_lbl.BackColor = System.Drawing.Color.Transparent;
            this.report_to_date_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.report_to_date_lbl.Location = new System.Drawing.Point(260, 9);
            this.report_to_date_lbl.Name = "report_to_date_lbl";
            this.report_to_date_lbl.Size = new System.Drawing.Size(94, 18);
            this.report_to_date_lbl.TabIndex = 114;
            this.report_to_date_lbl.Text = "TO DATE : ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.report_from_date_lbl);
            this.panel1.Controls.Add(this.report_date2);
            this.panel1.Controls.Add(this.print_report);
            this.panel1.Controls.Add(this.report_to_date_lbl);
            this.panel1.Controls.Add(this.report_date1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(965, 41);
            this.panel1.TabIndex = 116;
            // 
            // excelViewer
            // 
            this.excelViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.excelViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.excelViewer.Location = new System.Drawing.Point(10, 41);
            this.excelViewer.Name = "excelViewer";
            this.excelViewer.Size = new System.Drawing.Size(965, 515);
            this.excelViewer.TabIndex = 117;
            // 
            // report_sold_item_summary
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
            this.Name = "report_sold_item_summary";
            this.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "END DAY REPORT";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.report_sold_item_summary_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label report_from_date_lbl;
        private USER_CONTROL.print_report print_report;
        public System.Windows.Forms.DateTimePicker report_date1;
        public System.Windows.Forms.DateTimePicker report_date2;
        private System.Windows.Forms.Label report_to_date_lbl;
        private System.Windows.Forms.Panel panel1;
        private USER_CONTROL.ExcelViewer excelViewer;
    }
}