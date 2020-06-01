namespace SPA_MANAGEMENT_SYSTEM.DEBTOR
{
    partial class report_debtor
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
            this.report_cat_id_lbl = new System.Windows.Forms.Label();
            this.debtor_type = new System.Windows.Forms.ComboBox();
            this.print_report = new SPA_MANAGEMENT_SYSTEM.USER_CONTROL.print_report();
            this.panel1 = new System.Windows.Forms.Panel();
            this.excelViewer = new SPA_MANAGEMENT_SYSTEM.USER_CONTROL.ExcelViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // report_cat_id_lbl
            // 
            this.report_cat_id_lbl.AutoSize = true;
            this.report_cat_id_lbl.BackColor = System.Drawing.Color.Transparent;
            this.report_cat_id_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.report_cat_id_lbl.Location = new System.Drawing.Point(3, 9);
            this.report_cat_id_lbl.Name = "report_cat_id_lbl";
            this.report_cat_id_lbl.Size = new System.Drawing.Size(139, 18);
            this.report_cat_id_lbl.TabIndex = 10002;
            this.report_cat_id_lbl.Text = "DEBTOR TYPE : ";
            // 
            // debtor_type
            // 
            this.debtor_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.debtor_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.debtor_type.FormattingEnabled = true;
            this.debtor_type.Location = new System.Drawing.Point(142, 6);
            this.debtor_type.Name = "debtor_type";
            this.debtor_type.Size = new System.Drawing.Size(168, 26);
            this.debtor_type.TabIndex = 3;
            this.debtor_type.SelectedIndexChanged += new System.EventHandler(this.debtor_type_SelectedIndexChanged);
            // 
            // print_report
            // 
            this.print_report.Location = new System.Drawing.Point(317, 4);
            this.print_report.Name = "print_report";
            this.print_report.Size = new System.Drawing.Size(32, 28);
            this.print_report.TabIndex = 51;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.report_cat_id_lbl);
            this.panel1.Controls.Add(this.debtor_type);
            this.panel1.Controls.Add(this.print_report);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(965, 41);
            this.panel1.TabIndex = 10003;
            // 
            // excelViewer
            // 
            this.excelViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.excelViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.excelViewer.Location = new System.Drawing.Point(10, 41);
            this.excelViewer.Name = "excelViewer";
            this.excelViewer.Size = new System.Drawing.Size(965, 515);
            this.excelViewer.TabIndex = 10004;
            // 
            // report_debtor
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
            this.Name = "report_debtor";
            this.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "BOOKING CANCEL REPORT";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.report_debtor_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private USER_CONTROL.print_report print_report;
        private System.Windows.Forms.Label report_cat_id_lbl;
        public System.Windows.Forms.ComboBox debtor_type;
        private System.Windows.Forms.Panel panel1;
        private USER_CONTROL.ExcelViewer excelViewer;
    }
}