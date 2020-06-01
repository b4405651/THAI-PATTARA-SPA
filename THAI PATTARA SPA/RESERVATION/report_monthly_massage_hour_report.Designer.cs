namespace SPA_MANAGEMENT_SYSTEM.RESERVATION
{
    partial class report_monthly_massage_hour_report
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
            this.report_month_lbl = new System.Windows.Forms.Label();
            this.print_report = new SPA_MANAGEMENT_SYSTEM.USER_CONTROL.print_report();
            this.report_year_lbl = new System.Windows.Forms.Label();
            this.report_month = new System.Windows.Forms.TextBox();
            this.report_year = new System.Windows.Forms.TextBox();
            this.report_master_id_lbl = new System.Windows.Forms.Label();
            this.report_master_id = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.excelViewer = new SPA_MANAGEMENT_SYSTEM.USER_CONTROL.ExcelViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // report_month_lbl
            // 
            this.report_month_lbl.AutoSize = true;
            this.report_month_lbl.BackColor = System.Drawing.Color.Transparent;
            this.report_month_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.report_month_lbl.Location = new System.Drawing.Point(3, 9);
            this.report_month_lbl.Name = "report_month_lbl";
            this.report_month_lbl.Size = new System.Drawing.Size(84, 18);
            this.report_month_lbl.TabIndex = 49;
            this.report_month_lbl.Text = "MONTH : ";
            // 
            // print_report
            // 
            this.print_report.Location = new System.Drawing.Point(543, 4);
            this.print_report.Name = "print_report";
            this.print_report.Size = new System.Drawing.Size(32, 28);
            this.print_report.TabIndex = 51;
            // 
            // report_year_lbl
            // 
            this.report_year_lbl.AutoSize = true;
            this.report_year_lbl.BackColor = System.Drawing.Color.Transparent;
            this.report_year_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.report_year_lbl.Location = new System.Drawing.Point(146, 9);
            this.report_year_lbl.Name = "report_year_lbl";
            this.report_year_lbl.Size = new System.Drawing.Size(61, 18);
            this.report_year_lbl.TabIndex = 10001;
            this.report_year_lbl.Text = "YEAR :";
            // 
            // report_month
            // 
            this.report_month.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.report_month.Location = new System.Drawing.Point(89, 6);
            this.report_month.Name = "report_month";
            this.report_month.Size = new System.Drawing.Size(52, 24);
            this.report_month.TabIndex = 1;
            this.report_month.Tag = "";
            this.report_month.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.report_month.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.report_month_KeyPress);
            this.report_month.KeyUp += new System.Windows.Forms.KeyEventHandler(this.report_month_KeyUp);
            // 
            // report_year
            // 
            this.report_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.report_year.Location = new System.Drawing.Point(210, 6);
            this.report_year.Name = "report_year";
            this.report_year.Size = new System.Drawing.Size(59, 24);
            this.report_year.TabIndex = 2;
            this.report_year.Tag = "";
            this.report_year.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.report_year.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.report_year_KeyPress);
            this.report_year.KeyUp += new System.Windows.Forms.KeyEventHandler(this.report_year_KeyUp);
            // 
            // report_master_id_lbl
            // 
            this.report_master_id_lbl.AutoSize = true;
            this.report_master_id_lbl.BackColor = System.Drawing.Color.Transparent;
            this.report_master_id_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.report_master_id_lbl.Location = new System.Drawing.Point(284, 9);
            this.report_master_id_lbl.Name = "report_master_id_lbl";
            this.report_master_id_lbl.Size = new System.Drawing.Size(91, 18);
            this.report_master_id_lbl.TabIndex = 10002;
            this.report_master_id_lbl.Text = "MASTER : ";
            // 
            // report_master_id
            // 
            this.report_master_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.report_master_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.report_master_id.FormattingEnabled = true;
            this.report_master_id.Location = new System.Drawing.Point(372, 6);
            this.report_master_id.Name = "report_master_id";
            this.report_master_id.Size = new System.Drawing.Size(168, 26);
            this.report_master_id.TabIndex = 3;
            this.report_master_id.SelectedIndexChanged += new System.EventHandler(this.report_master_id_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.report_month_lbl);
            this.panel1.Controls.Add(this.report_master_id);
            this.panel1.Controls.Add(this.print_report);
            this.panel1.Controls.Add(this.report_master_id_lbl);
            this.panel1.Controls.Add(this.report_year_lbl);
            this.panel1.Controls.Add(this.report_year);
            this.panel1.Controls.Add(this.report_month);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(965, 39);
            this.panel1.TabIndex = 10003;
            // 
            // excelViewer
            // 
            this.excelViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.excelViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.excelViewer.Location = new System.Drawing.Point(10, 39);
            this.excelViewer.Name = "excelViewer";
            this.excelViewer.Size = new System.Drawing.Size(965, 517);
            this.excelViewer.TabIndex = 10004;
            // 
            // report_monthly_massage_hour_report
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
            this.Name = "report_monthly_massage_hour_report";
            this.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "BOOKING CANCEL REPORT";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.report_monthly_massage_hour_report_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label report_month_lbl;
        private USER_CONTROL.print_report print_report;
        private System.Windows.Forms.Label report_year_lbl;
        private System.Windows.Forms.TextBox report_month;
        private System.Windows.Forms.TextBox report_year;
        private System.Windows.Forms.Label report_master_id_lbl;
        public System.Windows.Forms.ComboBox report_master_id;
        private System.Windows.Forms.Panel panel1;
        private USER_CONTROL.ExcelViewer excelViewer;
    }
}