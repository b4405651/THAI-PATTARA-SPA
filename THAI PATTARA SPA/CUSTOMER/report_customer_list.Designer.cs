namespace SPA_MANAGEMENT_SYSTEM.CUSTOMER
{
    partial class report_customer_list
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
            this.order_group = new System.Windows.Forms.GroupBox();
            this.no_of_visit_rdb = new System.Windows.Forms.RadioButton();
            this.code_rdb = new System.Windows.Forms.RadioButton();
            this.name_rdb = new System.Windows.Forms.RadioButton();
            this.sorting_group = new System.Windows.Forms.GroupBox();
            this.desc_rdb = new System.Windows.Forms.RadioButton();
            this.asc_rdb = new System.Windows.Forms.RadioButton();
            this.only_member_cb = new System.Windows.Forms.CheckBox();
            this.only_neighbor_cb = new System.Windows.Forms.CheckBox();
            this.print_report = new SPA_MANAGEMENT_SYSTEM.USER_CONTROL.print_report();
            this.panel1 = new System.Windows.Forms.Panel();
            this.excelViewer = new SPA_MANAGEMENT_SYSTEM.USER_CONTROL.ExcelViewer();
            this.order_group.SuspendLayout();
            this.sorting_group.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // order_group
            // 
            this.order_group.Controls.Add(this.no_of_visit_rdb);
            this.order_group.Controls.Add(this.code_rdb);
            this.order_group.Controls.Add(this.name_rdb);
            this.order_group.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.order_group.Location = new System.Drawing.Point(3, 3);
            this.order_group.Name = "order_group";
            this.order_group.Size = new System.Drawing.Size(297, 58);
            this.order_group.TabIndex = 52;
            this.order_group.TabStop = false;
            this.order_group.Text = "ORDER BY";
            // 
            // no_of_visit_rdb
            // 
            this.no_of_visit_rdb.AutoSize = true;
            this.no_of_visit_rdb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.no_of_visit_rdb.Location = new System.Drawing.Point(170, 23);
            this.no_of_visit_rdb.Name = "no_of_visit_rdb";
            this.no_of_visit_rdb.Size = new System.Drawing.Size(117, 22);
            this.no_of_visit_rdb.TabIndex = 55;
            this.no_of_visit_rdb.Text = "No. of VISIT";
            this.no_of_visit_rdb.UseVisualStyleBackColor = true;
            this.no_of_visit_rdb.CheckedChanged += new System.EventHandler(this.no_of_visit_rdb_CheckedChanged);
            // 
            // code_rdb
            // 
            this.code_rdb.AutoSize = true;
            this.code_rdb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.code_rdb.Location = new System.Drawing.Point(90, 23);
            this.code_rdb.Name = "code_rdb";
            this.code_rdb.Size = new System.Drawing.Size(74, 22);
            this.code_rdb.TabIndex = 54;
            this.code_rdb.Text = "CODE";
            this.code_rdb.UseVisualStyleBackColor = true;
            this.code_rdb.CheckedChanged += new System.EventHandler(this.code_rdb_CheckedChanged);
            // 
            // name_rdb
            // 
            this.name_rdb.AutoSize = true;
            this.name_rdb.Checked = true;
            this.name_rdb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_rdb.Location = new System.Drawing.Point(11, 23);
            this.name_rdb.Name = "name_rdb";
            this.name_rdb.Size = new System.Drawing.Size(73, 22);
            this.name_rdb.TabIndex = 53;
            this.name_rdb.TabStop = true;
            this.name_rdb.Text = "NAME";
            this.name_rdb.UseVisualStyleBackColor = true;
            this.name_rdb.CheckedChanged += new System.EventHandler(this.name_rdb_CheckedChanged);
            // 
            // sorting_group
            // 
            this.sorting_group.Controls.Add(this.desc_rdb);
            this.sorting_group.Controls.Add(this.asc_rdb);
            this.sorting_group.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sorting_group.Location = new System.Drawing.Point(310, 3);
            this.sorting_group.Name = "sorting_group";
            this.sorting_group.Size = new System.Drawing.Size(289, 58);
            this.sorting_group.TabIndex = 55;
            this.sorting_group.TabStop = false;
            this.sorting_group.Text = "SORTING";
            // 
            // desc_rdb
            // 
            this.desc_rdb.AutoSize = true;
            this.desc_rdb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc_rdb.Location = new System.Drawing.Point(142, 23);
            this.desc_rdb.Name = "desc_rdb";
            this.desc_rdb.Size = new System.Drawing.Size(136, 22);
            this.desc_rdb.TabIndex = 54;
            this.desc_rdb.Text = "DESCENDING";
            this.desc_rdb.UseVisualStyleBackColor = true;
            this.desc_rdb.CheckedChanged += new System.EventHandler(this.desc_rdb_CheckedChanged);
            // 
            // asc_rdb
            // 
            this.asc_rdb.AutoSize = true;
            this.asc_rdb.Checked = true;
            this.asc_rdb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asc_rdb.Location = new System.Drawing.Point(11, 23);
            this.asc_rdb.Name = "asc_rdb";
            this.asc_rdb.Size = new System.Drawing.Size(123, 22);
            this.asc_rdb.TabIndex = 53;
            this.asc_rdb.TabStop = true;
            this.asc_rdb.Text = "ASCENDING";
            this.asc_rdb.UseVisualStyleBackColor = true;
            this.asc_rdb.CheckedChanged += new System.EventHandler(this.asc_rdb_CheckedChanged);
            // 
            // only_member_cb
            // 
            this.only_member_cb.AutoSize = true;
            this.only_member_cb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.only_member_cb.Location = new System.Drawing.Point(610, 27);
            this.only_member_cb.Name = "only_member_cb";
            this.only_member_cb.Size = new System.Drawing.Size(149, 22);
            this.only_member_cb.TabIndex = 56;
            this.only_member_cb.Text = "ONLY MEMBER";
            this.only_member_cb.UseVisualStyleBackColor = true;
            this.only_member_cb.CheckedChanged += new System.EventHandler(this.only_member_cb_CheckedChanged);
            // 
            // only_neighbor_cb
            // 
            this.only_neighbor_cb.AutoSize = true;
            this.only_neighbor_cb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.only_neighbor_cb.Location = new System.Drawing.Point(765, 27);
            this.only_neighbor_cb.Name = "only_neighbor_cb";
            this.only_neighbor_cb.Size = new System.Drawing.Size(164, 22);
            this.only_neighbor_cb.TabIndex = 57;
            this.only_neighbor_cb.Text = "ONLY NEIGHBOR";
            this.only_neighbor_cb.UseVisualStyleBackColor = true;
            this.only_neighbor_cb.CheckedChanged += new System.EventHandler(this.only_neighbor_cb_CheckedChanged);
            // 
            // print_report
            // 
            this.print_report.Location = new System.Drawing.Point(934, 20);
            this.print_report.Name = "print_report";
            this.print_report.Size = new System.Drawing.Size(32, 28);
            this.print_report.TabIndex = 51;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.order_group);
            this.panel1.Controls.Add(this.only_neighbor_cb);
            this.panel1.Controls.Add(this.print_report);
            this.panel1.Controls.Add(this.only_member_cb);
            this.panel1.Controls.Add(this.sorting_group);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1100, 71);
            this.panel1.TabIndex = 58;
            // 
            // excelViewer
            // 
            this.excelViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.excelViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.excelViewer.Location = new System.Drawing.Point(10, 71);
            this.excelViewer.Name = "excelViewer";
            this.excelViewer.Size = new System.Drawing.Size(1100, 485);
            this.excelViewer.TabIndex = 59;
            // 
            // report_customer_list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(1120, 566);
            this.ControlBox = false;
            this.Controls.Add(this.excelViewer);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "report_customer_list";
            this.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "CUSTOMER LIST REPORT";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.report_customer_list_Load);
            this.order_group.ResumeLayout(false);
            this.order_group.PerformLayout();
            this.sorting_group.ResumeLayout(false);
            this.sorting_group.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private USER_CONTROL.print_report print_report;
        private System.Windows.Forms.GroupBox order_group;
        private System.Windows.Forms.RadioButton code_rdb;
        private System.Windows.Forms.RadioButton name_rdb;
        private System.Windows.Forms.GroupBox sorting_group;
        private System.Windows.Forms.RadioButton desc_rdb;
        private System.Windows.Forms.RadioButton asc_rdb;
        private System.Windows.Forms.CheckBox only_member_cb;
        private System.Windows.Forms.RadioButton no_of_visit_rdb;
        private System.Windows.Forms.CheckBox only_neighbor_cb;
        private System.Windows.Forms.Panel panel1;
        private USER_CONTROL.ExcelViewer excelViewer;
    }
}