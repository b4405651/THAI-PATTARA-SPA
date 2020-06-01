namespace SPA_MANAGEMENT_SYSTEM.STORE
{
    partial class report_stock_transaction
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
            this.report_code_lbl = new System.Windows.Forms.Label();
            this.type_lbl = new System.Windows.Forms.Label();
            this.report_cat_id_lbl = new System.Windows.Forms.Label();
            this.report_cat_id = new System.Windows.Forms.ComboBox();
            this.order_type_lbl = new System.Windows.Forms.Label();
            this.item_id = new System.Windows.Forms.ComboBox();
            this.transaction_type = new System.Windows.Forms.ComboBox();
            this.transaction_by = new System.Windows.Forms.ComboBox();
            this.print_report = new SPA_MANAGEMENT_SYSTEM.USER_CONTROL.print_report();
            this.panel1 = new System.Windows.Forms.Panel();
            this.excelViewer = new SPA_MANAGEMENT_SYSTEM.USER_CONTROL.ExcelViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // report_code_lbl
            // 
            this.report_code_lbl.AutoSize = true;
            this.report_code_lbl.BackColor = System.Drawing.Color.Transparent;
            this.report_code_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.report_code_lbl.Location = new System.Drawing.Point(3, 38);
            this.report_code_lbl.Name = "report_code_lbl";
            this.report_code_lbl.Size = new System.Drawing.Size(62, 18);
            this.report_code_lbl.TabIndex = 49;
            this.report_code_lbl.Text = "ITEM : ";
            // 
            // type_lbl
            // 
            this.type_lbl.AutoSize = true;
            this.type_lbl.BackColor = System.Drawing.Color.Transparent;
            this.type_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.type_lbl.Location = new System.Drawing.Point(3, 70);
            this.type_lbl.Name = "type_lbl";
            this.type_lbl.Size = new System.Drawing.Size(65, 18);
            this.type_lbl.TabIndex = 10001;
            this.type_lbl.Text = "TYPE : ";
            // 
            // report_cat_id_lbl
            // 
            this.report_cat_id_lbl.AutoSize = true;
            this.report_cat_id_lbl.BackColor = System.Drawing.Color.Transparent;
            this.report_cat_id_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.report_cat_id_lbl.Location = new System.Drawing.Point(3, 9);
            this.report_cat_id_lbl.Name = "report_cat_id_lbl";
            this.report_cat_id_lbl.Size = new System.Drawing.Size(114, 18);
            this.report_cat_id_lbl.TabIndex = 10002;
            this.report_cat_id_lbl.Text = "CATEGORY : ";
            // 
            // report_cat_id
            // 
            this.report_cat_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.report_cat_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.report_cat_id.FormattingEnabled = true;
            this.report_cat_id.Location = new System.Drawing.Point(114, 6);
            this.report_cat_id.Name = "report_cat_id";
            this.report_cat_id.Size = new System.Drawing.Size(168, 26);
            this.report_cat_id.TabIndex = 3;
            this.report_cat_id.SelectedIndexChanged += new System.EventHandler(this.report_cat_id_SelectedIndexChanged);
            // 
            // order_type_lbl
            // 
            this.order_type_lbl.AutoSize = true;
            this.order_type_lbl.BackColor = System.Drawing.Color.Transparent;
            this.order_type_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.order_type_lbl.Location = new System.Drawing.Point(3, 101);
            this.order_type_lbl.Name = "order_type_lbl";
            this.order_type_lbl.Size = new System.Drawing.Size(44, 18);
            this.order_type_lbl.TabIndex = 10007;
            this.order_type_lbl.Text = "BY : ";
            // 
            // item_id
            // 
            this.item_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.item_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_id.FormattingEnabled = true;
            this.item_id.Location = new System.Drawing.Point(64, 35);
            this.item_id.Name = "item_id";
            this.item_id.Size = new System.Drawing.Size(471, 26);
            this.item_id.TabIndex = 10009;
            this.item_id.SelectedIndexChanged += new System.EventHandler(this.item_id_SelectedIndexChanged);
            // 
            // transaction_type
            // 
            this.transaction_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.transaction_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.transaction_type.FormattingEnabled = true;
            this.transaction_type.Location = new System.Drawing.Point(64, 67);
            this.transaction_type.Name = "transaction_type";
            this.transaction_type.Size = new System.Drawing.Size(168, 26);
            this.transaction_type.TabIndex = 10010;
            this.transaction_type.SelectedIndexChanged += new System.EventHandler(this.transaction_type_SelectedIndexChanged);
            // 
            // transaction_by
            // 
            this.transaction_by.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.transaction_by.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.transaction_by.FormattingEnabled = true;
            this.transaction_by.Location = new System.Drawing.Point(53, 98);
            this.transaction_by.Name = "transaction_by";
            this.transaction_by.Size = new System.Drawing.Size(168, 26);
            this.transaction_by.TabIndex = 10011;
            this.transaction_by.SelectedIndexChanged += new System.EventHandler(this.transaction_by_SelectedIndexChanged);
            // 
            // print_report
            // 
            this.print_report.Location = new System.Drawing.Point(291, 4);
            this.print_report.Name = "print_report";
            this.print_report.Size = new System.Drawing.Size(32, 28);
            this.print_report.TabIndex = 51;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.report_cat_id_lbl);
            this.panel1.Controls.Add(this.transaction_by);
            this.panel1.Controls.Add(this.report_code_lbl);
            this.panel1.Controls.Add(this.transaction_type);
            this.panel1.Controls.Add(this.print_report);
            this.panel1.Controls.Add(this.item_id);
            this.panel1.Controls.Add(this.type_lbl);
            this.panel1.Controls.Add(this.order_type_lbl);
            this.panel1.Controls.Add(this.report_cat_id);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(965, 130);
            this.panel1.TabIndex = 10012;
            // 
            // excelViewer
            // 
            this.excelViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.excelViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.excelViewer.Location = new System.Drawing.Point(10, 130);
            this.excelViewer.Name = "excelViewer";
            this.excelViewer.Size = new System.Drawing.Size(965, 426);
            this.excelViewer.TabIndex = 10013;
            // 
            // report_stock_transaction
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
            this.Name = "report_stock_transaction";
            this.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "BOOKING CANCEL REPORT";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.report_stock_transaction_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label report_code_lbl;
        private USER_CONTROL.print_report print_report;
        private System.Windows.Forms.Label type_lbl;
        private System.Windows.Forms.Label report_cat_id_lbl;
        public System.Windows.Forms.ComboBox report_cat_id;
        private System.Windows.Forms.Label order_type_lbl;
        public System.Windows.Forms.ComboBox item_id;
        public System.Windows.Forms.ComboBox transaction_type;
        public System.Windows.Forms.ComboBox transaction_by;
        private System.Windows.Forms.Panel panel1;
        private USER_CONTROL.ExcelViewer excelViewer;
    }
}