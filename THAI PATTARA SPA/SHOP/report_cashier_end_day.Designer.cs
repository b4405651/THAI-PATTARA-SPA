namespace SPA_MANAGEMENT_SYSTEM.SHOP
{
    partial class report_cashier_end_day
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
            this.report_date_lbl = new System.Windows.Forms.Label();
            this.report_date = new System.Windows.Forms.DateTimePicker();
            this.btn_panel = new System.Windows.Forms.Panel();
            this.excelViewer = new SPA_MANAGEMENT_SYSTEM.USER_CONTROL.ExcelViewer();
            this.print_report = new SPA_MANAGEMENT_SYSTEM.USER_CONTROL.print_report();
            this.btn_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // report_date_lbl
            // 
            this.report_date_lbl.AutoSize = true;
            this.report_date_lbl.BackColor = System.Drawing.Color.Transparent;
            this.report_date_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.report_date_lbl.Location = new System.Drawing.Point(9, 6);
            this.report_date_lbl.Name = "report_date_lbl";
            this.report_date_lbl.Size = new System.Drawing.Size(66, 18);
            this.report_date_lbl.TabIndex = 49;
            this.report_date_lbl.Text = "DATE : ";
            // 
            // report_date
            // 
            this.report_date.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.report_date.CustomFormat = "dd/MM/yyyy";
            this.report_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.report_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.report_date.Location = new System.Drawing.Point(80, 3);
            this.report_date.Name = "report_date";
            this.report_date.Size = new System.Drawing.Size(124, 24);
            this.report_date.TabIndex = 113;
            this.report_date.ValueChanged += new System.EventHandler(this.report_date_ValueChanged);
            // 
            // btn_panel
            // 
            this.btn_panel.Controls.Add(this.report_date_lbl);
            this.btn_panel.Controls.Add(this.report_date);
            this.btn_panel.Controls.Add(this.print_report);
            this.btn_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_panel.Location = new System.Drawing.Point(10, 0);
            this.btn_panel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_panel.Name = "btn_panel";
            this.btn_panel.Size = new System.Drawing.Size(965, 29);
            this.btn_panel.TabIndex = 114;
            // 
            // excelViewer
            // 
            this.excelViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.excelViewer.Location = new System.Drawing.Point(10, 29);
            this.excelViewer.Name = "excelViewer";
            this.excelViewer.Size = new System.Drawing.Size(965, 527);
            this.excelViewer.TabIndex = 115;
            // 
            // print_report
            // 
            this.print_report.Location = new System.Drawing.Point(200, 1);
            this.print_report.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.print_report.Name = "print_report";
            this.print_report.Size = new System.Drawing.Size(32, 28);
            this.print_report.TabIndex = 51;
            // 
            // report_cashier_end_day
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(985, 566);
            this.ControlBox = false;
            this.Controls.Add(this.excelViewer);
            this.Controls.Add(this.btn_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "report_cashier_end_day";
            this.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "END DAY REPORT";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.report_end_day_Load);
            this.btn_panel.ResumeLayout(false);
            this.btn_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label report_date_lbl;
        private USER_CONTROL.print_report print_report;
        public System.Windows.Forms.DateTimePicker report_date;
        private System.Windows.Forms.Panel btn_panel;
        private USER_CONTROL.ExcelViewer excelViewer;
    }
}