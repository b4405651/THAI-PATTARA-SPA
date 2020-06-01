namespace SPA_MANAGEMENT_SYSTEM.CUSTOMER
{
    partial class customer_history
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(customer_history));
            this.top_panel = new System.Windows.Forms.Panel();
            this.print_report = new SPA_MANAGEMENT_SYSTEM.USER_CONTROL.print_report();
            this.excelViewer = new SPA_MANAGEMENT_SYSTEM.USER_CONTROL.ExcelViewer();
            this.top_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // top_panel
            // 
            this.top_panel.Controls.Add(this.print_report);
            this.top_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_panel.Location = new System.Drawing.Point(0, 0);
            this.top_panel.Name = "top_panel";
            this.top_panel.Size = new System.Drawing.Size(1313, 42);
            this.top_panel.TabIndex = 53;
            // 
            // print_report
            // 
            this.print_report.Location = new System.Drawing.Point(5, 5);
            this.print_report.Margin = new System.Windows.Forms.Padding(5);
            this.print_report.Name = "print_report";
            this.print_report.Size = new System.Drawing.Size(43, 34);
            this.print_report.TabIndex = 52;
            // 
            // excelViewer
            // 
            this.excelViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.excelViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.excelViewer.Location = new System.Drawing.Point(0, 0);
            this.excelViewer.Margin = new System.Windows.Forms.Padding(5);
            this.excelViewer.Name = "excelViewer";
            this.excelViewer.Padding = new System.Windows.Forms.Padding(13, 0, 13, 12);
            this.excelViewer.Size = new System.Drawing.Size(1313, 697);
            this.excelViewer.TabIndex = 50;
            // 
            // customer_history
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(1313, 697);
            this.Controls.Add(this.top_panel);
            this.Controls.Add(this.excelViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "customer_history";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CUSTOMER HISTORY";
            this.Load += new System.EventHandler(this.customer_history_Load);
            this.top_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private USER_CONTROL.ExcelViewer excelViewer;
        private USER_CONTROL.print_report print_report;
        private System.Windows.Forms.Panel top_panel;
    }
}