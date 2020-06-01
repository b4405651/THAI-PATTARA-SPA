namespace SPA_MANAGEMENT_SYSTEM.DEBTOR
{
    partial class report_debt_detail
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
            this.debtor_id = new System.Windows.Forms.ComboBox();
            this.debtor_id_lbl = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.ComboBox();
            this.status_lbl = new System.Windows.Forms.Label();
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
            this.debtor_type.Location = new System.Drawing.Point(145, 6);
            this.debtor_type.Name = "debtor_type";
            this.debtor_type.Size = new System.Drawing.Size(168, 26);
            this.debtor_type.TabIndex = 3;
            this.debtor_type.SelectedIndexChanged += new System.EventHandler(this.debtor_type_SelectedIndexChanged);
            // 
            // print_report
            // 
            this.print_report.Location = new System.Drawing.Point(322, 4);
            this.print_report.Name = "print_report";
            this.print_report.Size = new System.Drawing.Size(32, 28);
            this.print_report.TabIndex = 51;
            // 
            // debtor_id
            // 
            this.debtor_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.debtor_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.debtor_id.FormattingEnabled = true;
            this.debtor_id.Location = new System.Drawing.Point(145, 33);
            this.debtor_id.Name = "debtor_id";
            this.debtor_id.Size = new System.Drawing.Size(168, 26);
            this.debtor_id.TabIndex = 10003;
            this.debtor_id.SelectedIndexChanged += new System.EventHandler(this.debtor_id_SelectedIndexChanged);
            // 
            // debtor_id_lbl
            // 
            this.debtor_id_lbl.AutoSize = true;
            this.debtor_id_lbl.BackColor = System.Drawing.Color.Transparent;
            this.debtor_id_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.debtor_id_lbl.Location = new System.Drawing.Point(3, 36);
            this.debtor_id_lbl.Name = "debtor_id_lbl";
            this.debtor_id_lbl.Size = new System.Drawing.Size(92, 18);
            this.debtor_id_lbl.TabIndex = 10004;
            this.debtor_id_lbl.Text = "DEBTOR : ";
            // 
            // status
            // 
            this.status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.status.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.status.FormattingEnabled = true;
            this.status.Location = new System.Drawing.Point(145, 60);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(168, 26);
            this.status.TabIndex = 10005;
            this.status.SelectedIndexChanged += new System.EventHandler(this.status_SelectedIndexChanged);
            // 
            // status_lbl
            // 
            this.status_lbl.AutoSize = true;
            this.status_lbl.BackColor = System.Drawing.Color.Transparent;
            this.status_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.status_lbl.Location = new System.Drawing.Point(3, 63);
            this.status_lbl.Name = "status_lbl";
            this.status_lbl.Size = new System.Drawing.Size(87, 18);
            this.status_lbl.TabIndex = 10006;
            this.status_lbl.Text = "STATUS : ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.report_cat_id_lbl);
            this.panel1.Controls.Add(this.status);
            this.panel1.Controls.Add(this.print_report);
            this.panel1.Controls.Add(this.status_lbl);
            this.panel1.Controls.Add(this.debtor_type);
            this.panel1.Controls.Add(this.debtor_id);
            this.panel1.Controls.Add(this.debtor_id_lbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(965, 96);
            this.panel1.TabIndex = 10007;
            // 
            // excelViewer
            // 
            this.excelViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.excelViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.excelViewer.Location = new System.Drawing.Point(10, 96);
            this.excelViewer.Name = "excelViewer";
            this.excelViewer.Size = new System.Drawing.Size(965, 460);
            this.excelViewer.TabIndex = 10008;
            // 
            // report_debt_detail
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
            this.Name = "report_debt_detail";
            this.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "BOOKING CANCEL REPORT";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.report_debt_detail_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private USER_CONTROL.print_report print_report;
        private System.Windows.Forms.Label report_cat_id_lbl;
        public System.Windows.Forms.ComboBox debtor_type;
        public System.Windows.Forms.ComboBox debtor_id;
        private System.Windows.Forms.Label debtor_id_lbl;
        public System.Windows.Forms.ComboBox status;
        private System.Windows.Forms.Label status_lbl;
        private System.Windows.Forms.Panel panel1;
        private USER_CONTROL.ExcelViewer excelViewer;
    }
}