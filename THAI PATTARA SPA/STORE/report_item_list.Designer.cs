namespace SPA_MANAGEMENT_SYSTEM.STORE
{
    partial class report_item_list
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
            this.print_report = new SPA_MANAGEMENT_SYSTEM.USER_CONTROL.print_report();
            this.order_by_lbl = new System.Windows.Forms.Label();
            this.code = new System.Windows.Forms.TextBox();
            this.report_cat_id_lbl = new System.Windows.Forms.Label();
            this.report_cat_id = new System.Windows.Forms.ComboBox();
            this.order_by_panel = new System.Windows.Forms.Panel();
            this.amount = new System.Windows.Forms.RadioButton();
            this.item_name = new System.Windows.Forms.RadioButton();
            this.item_code = new System.Windows.Forms.RadioButton();
            this.order_type_panel = new System.Windows.Forms.Panel();
            this.desc = new System.Windows.Forms.RadioButton();
            this.asc = new System.Windows.Forms.RadioButton();
            this.order_type_lbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.excelViewer = new SPA_MANAGEMENT_SYSTEM.USER_CONTROL.ExcelViewer();
            this.order_by_panel.SuspendLayout();
            this.order_type_panel.SuspendLayout();
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
            this.report_code_lbl.Size = new System.Drawing.Size(222, 18);
            this.report_code_lbl.TabIndex = 49;
            this.report_code_lbl.Text = "BARCODE or ITEM CODE : ";
            // 
            // print_report
            // 
            this.print_report.Location = new System.Drawing.Point(291, 4);
            this.print_report.Name = "print_report";
            this.print_report.Size = new System.Drawing.Size(32, 28);
            this.print_report.TabIndex = 51;
            // 
            // order_by_lbl
            // 
            this.order_by_lbl.AutoSize = true;
            this.order_by_lbl.BackColor = System.Drawing.Color.Transparent;
            this.order_by_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.order_by_lbl.Location = new System.Drawing.Point(3, 70);
            this.order_by_lbl.Name = "order_by_lbl";
            this.order_by_lbl.Size = new System.Drawing.Size(109, 18);
            this.order_by_lbl.TabIndex = 10001;
            this.order_by_lbl.Text = "ORDER BY : ";
            // 
            // code
            // 
            this.code.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.code.Location = new System.Drawing.Point(226, 35);
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(177, 24);
            this.code.TabIndex = 1;
            this.code.Tag = "";
            this.code.KeyUp += new System.Windows.Forms.KeyEventHandler(this.code_KeyUp);
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
            // order_by_panel
            // 
            this.order_by_panel.Controls.Add(this.amount);
            this.order_by_panel.Controls.Add(this.item_name);
            this.order_by_panel.Controls.Add(this.item_code);
            this.order_by_panel.Location = new System.Drawing.Point(111, 65);
            this.order_by_panel.Name = "order_by_panel";
            this.order_by_panel.Size = new System.Drawing.Size(511, 29);
            this.order_by_panel.TabIndex = 10003;
            // 
            // amount
            // 
            this.amount.AutoSize = true;
            this.amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amount.Location = new System.Drawing.Point(307, 3);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(97, 22);
            this.amount.TabIndex = 10006;
            this.amount.Text = "AMOUNT";
            this.amount.UseVisualStyleBackColor = true;
            this.amount.Click += new System.EventHandler(this.amount_Click);
            // 
            // item_name
            // 
            this.item_name.AutoSize = true;
            this.item_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_name.Location = new System.Drawing.Point(159, 3);
            this.item_name.Name = "item_name";
            this.item_name.Size = new System.Drawing.Size(117, 22);
            this.item_name.TabIndex = 10005;
            this.item_name.Text = "ITEM NAME";
            this.item_name.UseVisualStyleBackColor = true;
            this.item_name.Click += new System.EventHandler(this.item_name_Click);
            // 
            // item_code
            // 
            this.item_code.AutoSize = true;
            this.item_code.Checked = true;
            this.item_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_code.Location = new System.Drawing.Point(11, 3);
            this.item_code.Name = "item_code";
            this.item_code.Size = new System.Drawing.Size(118, 22);
            this.item_code.TabIndex = 10004;
            this.item_code.TabStop = true;
            this.item_code.Text = "ITEM CODE";
            this.item_code.UseVisualStyleBackColor = true;
            this.item_code.Click += new System.EventHandler(this.item_code_Click);
            // 
            // order_type_panel
            // 
            this.order_type_panel.Controls.Add(this.desc);
            this.order_type_panel.Controls.Add(this.asc);
            this.order_type_panel.Location = new System.Drawing.Point(125, 96);
            this.order_type_panel.Name = "order_type_panel";
            this.order_type_panel.Size = new System.Drawing.Size(511, 29);
            this.order_type_panel.TabIndex = 10008;
            // 
            // desc
            // 
            this.desc.AutoSize = true;
            this.desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc.Location = new System.Drawing.Point(159, 3);
            this.desc.Name = "desc";
            this.desc.Size = new System.Drawing.Size(136, 22);
            this.desc.TabIndex = 10005;
            this.desc.Text = "DESCENDING";
            this.desc.UseVisualStyleBackColor = true;
            this.desc.Click += new System.EventHandler(this.desc_Click);
            // 
            // asc
            // 
            this.asc.AutoSize = true;
            this.asc.Checked = true;
            this.asc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asc.Location = new System.Drawing.Point(11, 3);
            this.asc.Name = "asc";
            this.asc.Size = new System.Drawing.Size(123, 22);
            this.asc.TabIndex = 10004;
            this.asc.TabStop = true;
            this.asc.Text = "ASCENDING";
            this.asc.UseVisualStyleBackColor = true;
            this.asc.Click += new System.EventHandler(this.asc_Click);
            // 
            // order_type_lbl
            // 
            this.order_type_lbl.AutoSize = true;
            this.order_type_lbl.BackColor = System.Drawing.Color.Transparent;
            this.order_type_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.order_type_lbl.Location = new System.Drawing.Point(3, 101);
            this.order_type_lbl.Name = "order_type_lbl";
            this.order_type_lbl.Size = new System.Drawing.Size(130, 18);
            this.order_type_lbl.TabIndex = 10007;
            this.order_type_lbl.Text = "ORDER TYPE : ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.report_cat_id_lbl);
            this.panel1.Controls.Add(this.order_type_panel);
            this.panel1.Controls.Add(this.report_code_lbl);
            this.panel1.Controls.Add(this.order_by_panel);
            this.panel1.Controls.Add(this.print_report);
            this.panel1.Controls.Add(this.order_type_lbl);
            this.panel1.Controls.Add(this.order_by_lbl);
            this.panel1.Controls.Add(this.report_cat_id);
            this.panel1.Controls.Add(this.code);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(965, 131);
            this.panel1.TabIndex = 10009;
            // 
            // excelViewer
            // 
            this.excelViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.excelViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.excelViewer.Location = new System.Drawing.Point(10, 131);
            this.excelViewer.Name = "excelViewer";
            this.excelViewer.Size = new System.Drawing.Size(965, 425);
            this.excelViewer.TabIndex = 10010;
            // 
            // report_item_list
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
            this.Name = "report_item_list";
            this.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "BOOKING CANCEL REPORT";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.report_item_list_Load);
            this.order_by_panel.ResumeLayout(false);
            this.order_by_panel.PerformLayout();
            this.order_type_panel.ResumeLayout(false);
            this.order_type_panel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label report_code_lbl;
        private USER_CONTROL.print_report print_report;
        private System.Windows.Forms.Label order_by_lbl;
        private System.Windows.Forms.TextBox code;
        private System.Windows.Forms.Label report_cat_id_lbl;
        public System.Windows.Forms.ComboBox report_cat_id;
        private System.Windows.Forms.Panel order_by_panel;
        private System.Windows.Forms.RadioButton amount;
        private System.Windows.Forms.RadioButton item_name;
        private System.Windows.Forms.RadioButton item_code;
        private System.Windows.Forms.Panel order_type_panel;
        private System.Windows.Forms.RadioButton desc;
        private System.Windows.Forms.RadioButton asc;
        private System.Windows.Forms.Label order_type_lbl;
        private System.Windows.Forms.Panel panel1;
        private USER_CONTROL.ExcelViewer excelViewer;
    }
}