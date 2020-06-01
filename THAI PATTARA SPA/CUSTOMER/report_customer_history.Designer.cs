namespace SPA_MANAGEMENT_SYSTEM.CUSTOMER
{
    partial class report_customer_history
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
            this.print_report = new SPA_MANAGEMENT_SYSTEM.USER_CONTROL.print_report();
            this.customer_data = new SPA_MANAGEMENT_SYSTEM.customAutoComplete();
            this.panel1 = new System.Windows.Forms.Panel();
            this.excelViewer = new SPA_MANAGEMENT_SYSTEM.USER_CONTROL.ExcelViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // report_date_lbl
            // 
            this.report_date_lbl.AutoSize = true;
            this.report_date_lbl.BackColor = System.Drawing.Color.Transparent;
            this.report_date_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.report_date_lbl.Location = new System.Drawing.Point(3, 9);
            this.report_date_lbl.Name = "report_date_lbl";
            this.report_date_lbl.Size = new System.Drawing.Size(165, 18);
            this.report_date_lbl.TabIndex = 49;
            this.report_date_lbl.Text = "CUSTOMER DATA : ";
            // 
            // print_report
            // 
            this.print_report.Location = new System.Drawing.Point(420, 4);
            this.print_report.Name = "print_report";
            this.print_report.Size = new System.Drawing.Size(32, 28);
            this.print_report.TabIndex = 51;
            // 
            // customer_data
            // 
            this.customer_data.currentID = -1;
            this.customer_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.customer_data.ForeColor = System.Drawing.Color.Red;
            this.customer_data.Location = new System.Drawing.Point(172, 6);
            this.customer_data.Mode = "";
            this.customer_data.Name = "customer_data";
            this.customer_data.Size = new System.Drawing.Size(242, 24);
            this.customer_data.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.report_date_lbl);
            this.panel1.Controls.Add(this.print_report);
            this.panel1.Controls.Add(this.customer_data);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(965, 39);
            this.panel1.TabIndex = 52;
            // 
            // excelViewer
            // 
            this.excelViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.excelViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.excelViewer.Location = new System.Drawing.Point(10, 39);
            this.excelViewer.Name = "excelViewer";
            this.excelViewer.Size = new System.Drawing.Size(965, 517);
            this.excelViewer.TabIndex = 53;
            // 
            // report_customer_history
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
            this.Name = "report_customer_history";
            this.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "BOOKING CANCEL REPORT";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.report_customer_history_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label report_date_lbl;
        private USER_CONTROL.print_report print_report;
        public customAutoComplete customer_data;
        private System.Windows.Forms.Panel panel1;
        private USER_CONTROL.ExcelViewer excelViewer;
    }
}