namespace SPA_MANAGEMENT_SYSTEM
{
    partial class btn_dgv
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_panel = new System.Windows.Forms.Panel();
            this.search_btn = new System.Windows.Forms.Button();
            this.refresh_btn = new System.Windows.Forms.Button();
            this.paging_panel = new System.Windows.Forms.Panel();
            this.total_record_lbl = new System.Windows.Forms.Label();
            this.last_btn = new System.Windows.Forms.Button();
            this.next_btn = new System.Windows.Forms.Button();
            this.total_lbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.page_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.prev_btn = new System.Windows.Forms.Button();
            this.first_btn = new System.Windows.Forms.Button();
            this.DGV_panel = new System.Windows.Forms.Panel();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.del_btn = new System.Windows.Forms.Button();
            this.edit_btn = new System.Windows.Forms.Button();
            this.add_btn = new System.Windows.Forms.Button();
            this.enable_btn = new System.Windows.Forms.Button();
            this.btn_panel.SuspendLayout();
            this.paging_panel.SuspendLayout();
            this.DGV_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_panel
            // 
            this.btn_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(96)))), ((int)(((byte)(135)))));
            this.btn_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btn_panel.Controls.Add(this.enable_btn);
            this.btn_panel.Controls.Add(this.add_btn);
            this.btn_panel.Controls.Add(this.edit_btn);
            this.btn_panel.Controls.Add(this.search_btn);
            this.btn_panel.Controls.Add(this.refresh_btn);
            this.btn_panel.Controls.Add(this.del_btn);
            this.btn_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_panel.Location = new System.Drawing.Point(0, 0);
            this.btn_panel.Name = "btn_panel";
            this.btn_panel.Size = new System.Drawing.Size(784, 57);
            this.btn_panel.TabIndex = 13;
            // 
            // search_btn
            // 
            this.search_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.search_btn.Dock = System.Windows.Forms.DockStyle.Left;
            this.search_btn.FlatAppearance.BorderSize = 0;
            this.search_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.search_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.search_btn.Location = new System.Drawing.Point(109, 0);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(97, 55);
            this.search_btn.TabIndex = 13;
            this.search_btn.Text = "SEARCH";
            this.search_btn.UseVisualStyleBackColor = false;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // refresh_btn
            // 
            this.refresh_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.refresh_btn.Dock = System.Windows.Forms.DockStyle.Left;
            this.refresh_btn.FlatAppearance.BorderSize = 0;
            this.refresh_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.refresh_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.refresh_btn.Location = new System.Drawing.Point(0, 0);
            this.refresh_btn.Name = "refresh_btn";
            this.refresh_btn.Size = new System.Drawing.Size(109, 55);
            this.refresh_btn.TabIndex = 12;
            this.refresh_btn.Text = "REFRESH";
            this.refresh_btn.UseVisualStyleBackColor = false;
            this.refresh_btn.Click += new System.EventHandler(this.refresh_btn_Click);
            // 
            // paging_panel
            // 
            this.paging_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paging_panel.Controls.Add(this.total_record_lbl);
            this.paging_panel.Controls.Add(this.last_btn);
            this.paging_panel.Controls.Add(this.next_btn);
            this.paging_panel.Controls.Add(this.total_lbl);
            this.paging_panel.Controls.Add(this.label2);
            this.paging_panel.Controls.Add(this.page_txt);
            this.paging_panel.Controls.Add(this.label1);
            this.paging_panel.Controls.Add(this.prev_btn);
            this.paging_panel.Controls.Add(this.first_btn);
            this.paging_panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.paging_panel.Location = new System.Drawing.Point(0, 164);
            this.paging_panel.Name = "paging_panel";
            this.paging_panel.Size = new System.Drawing.Size(784, 40);
            this.paging_panel.TabIndex = 18;
            // 
            // total_record_lbl
            // 
            this.total_record_lbl.AutoSize = true;
            this.total_record_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.total_record_lbl.Location = new System.Drawing.Point(452, 8);
            this.total_record_lbl.Name = "total_record_lbl";
            this.total_record_lbl.Size = new System.Drawing.Size(194, 20);
            this.total_record_lbl.TabIndex = 8;
            this.total_record_lbl.Text = "TOTAL RECORD(S) : 0";
            // 
            // last_btn
            // 
            this.last_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.last_btn.Enabled = false;
            this.last_btn.FlatAppearance.BorderSize = 0;
            this.last_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.last_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.last_btn.Location = new System.Drawing.Point(391, 3);
            this.last_btn.Name = "last_btn";
            this.last_btn.Size = new System.Drawing.Size(40, 31);
            this.last_btn.TabIndex = 7;
            this.last_btn.Text = ">>";
            this.last_btn.UseVisualStyleBackColor = false;
            this.last_btn.Click += new System.EventHandler(this.last_btn_Click);
            // 
            // next_btn
            // 
            this.next_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.next_btn.Enabled = false;
            this.next_btn.FlatAppearance.BorderSize = 0;
            this.next_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.next_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.next_btn.Location = new System.Drawing.Point(349, 3);
            this.next_btn.Name = "next_btn";
            this.next_btn.Size = new System.Drawing.Size(40, 31);
            this.next_btn.TabIndex = 6;
            this.next_btn.Text = ">";
            this.next_btn.UseVisualStyleBackColor = false;
            this.next_btn.Click += new System.EventHandler(this.next_btn_Click);
            // 
            // total_lbl
            // 
            this.total_lbl.AutoSize = true;
            this.total_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.total_lbl.Location = new System.Drawing.Point(265, 8);
            this.total_lbl.Name = "total_lbl";
            this.total_lbl.Size = new System.Drawing.Size(19, 20);
            this.total_lbl.TabIndex = 5;
            this.total_lbl.Text = "0";
            this.total_lbl.TextChanged += new System.EventHandler(this.total_lbl_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(245, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "/";
            // 
            // page_txt
            // 
            this.page_txt.Enabled = false;
            this.page_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.page_txt.Location = new System.Drawing.Point(197, 6);
            this.page_txt.Name = "page_txt";
            this.page_txt.Size = new System.Drawing.Size(42, 26);
            this.page_txt.TabIndex = 3;
            this.page_txt.Text = "0";
            this.page_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.page_txt.Click += new System.EventHandler(this.page_txt_Leave);
            this.page_txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.page_txt_KeyPress);
            this.page_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.page_txt_KeyUp);
            this.page_txt.Leave += new System.EventHandler(this.page_txt_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(137, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "page : ";
            // 
            // prev_btn
            // 
            this.prev_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.prev_btn.Enabled = false;
            this.prev_btn.FlatAppearance.BorderSize = 0;
            this.prev_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prev_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.prev_btn.Location = new System.Drawing.Point(45, 3);
            this.prev_btn.Name = "prev_btn";
            this.prev_btn.Size = new System.Drawing.Size(40, 31);
            this.prev_btn.TabIndex = 1;
            this.prev_btn.Text = "<";
            this.prev_btn.UseVisualStyleBackColor = false;
            this.prev_btn.Click += new System.EventHandler(this.prev_btn_Click);
            // 
            // first_btn
            // 
            this.first_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.first_btn.Enabled = false;
            this.first_btn.FlatAppearance.BorderSize = 0;
            this.first_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.first_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.first_btn.Location = new System.Drawing.Point(3, 3);
            this.first_btn.Name = "first_btn";
            this.first_btn.Size = new System.Drawing.Size(40, 31);
            this.first_btn.TabIndex = 0;
            this.first_btn.Text = "<<";
            this.first_btn.UseVisualStyleBackColor = false;
            this.first_btn.Click += new System.EventHandler(this.first_btn_Click);
            // 
            // DGV_panel
            // 
            this.DGV_panel.Controls.Add(this.DGV);
            this.DGV_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_panel.Location = new System.Drawing.Point(0, 57);
            this.DGV_panel.Name = "DGV_panel";
            this.DGV_panel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.DGV_panel.Size = new System.Drawing.Size(784, 107);
            this.DGV_panel.TabIndex = 19;
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToResizeColumns = false;
            this.DGV.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(143)))));
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.DGV.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.DGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(7);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV.DefaultCellStyle = dataGridViewCellStyle7;
            this.DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DGV.EnableHeadersVisualStyles = false;
            this.DGV.Location = new System.Drawing.Point(0, 5);
            this.DGV.MultiSelect = false;
            this.DGV.Name = "DGV";
            this.DGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.DGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.ShowCellErrors = false;
            this.DGV.ShowCellToolTips = false;
            this.DGV.ShowEditingIcon = false;
            this.DGV.Size = new System.Drawing.Size(784, 97);
            this.DGV.TabIndex = 20;
            this.DGV.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DGV_Scroll);
            this.DGV.SelectionChanged += new System.EventHandler(this.DGV_SelectionChanged);
            this.DGV.Paint += new System.Windows.Forms.PaintEventHandler(this.DGV_Paint);
            this.DGV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_KeyDown);
            // 
            // del_btn
            // 
            this.del_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.del_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.del_btn.Enabled = false;
            this.del_btn.FlatAppearance.BorderSize = 0;
            this.del_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.del_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.del_btn.Location = new System.Drawing.Point(686, 0);
            this.del_btn.Name = "del_btn";
            this.del_btn.Size = new System.Drawing.Size(96, 55);
            this.del_btn.TabIndex = 9;
            this.del_btn.Text = "DISABLE";
            this.del_btn.UseVisualStyleBackColor = false;
            this.del_btn.Click += new System.EventHandler(this.del_btn_Click);
            // 
            // edit_btn
            // 
            this.edit_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.edit_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.edit_btn.Enabled = false;
            this.edit_btn.FlatAppearance.BorderSize = 0;
            this.edit_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.edit_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.edit_btn.Location = new System.Drawing.Point(611, 0);
            this.edit_btn.Name = "edit_btn";
            this.edit_btn.Size = new System.Drawing.Size(75, 55);
            this.edit_btn.TabIndex = 15;
            this.edit_btn.Text = "EDIT";
            this.edit_btn.UseVisualStyleBackColor = false;
            this.edit_btn.Click += new System.EventHandler(this.edit_btn_Click);
            // 
            // add_btn
            // 
            this.add_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.add_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.add_btn.FlatAppearance.BorderSize = 0;
            this.add_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.add_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.add_btn.Location = new System.Drawing.Point(536, 0);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(75, 55);
            this.add_btn.TabIndex = 16;
            this.add_btn.Text = "ADD";
            this.add_btn.UseVisualStyleBackColor = false;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // enable_btn
            // 
            this.enable_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.enable_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.enable_btn.FlatAppearance.BorderSize = 0;
            this.enable_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.enable_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.enable_btn.Location = new System.Drawing.Point(440, 0);
            this.enable_btn.Name = "enable_btn";
            this.enable_btn.Size = new System.Drawing.Size(96, 55);
            this.enable_btn.TabIndex = 17;
            this.enable_btn.Text = "ENABLE";
            this.enable_btn.UseVisualStyleBackColor = false;
            this.enable_btn.Visible = false;
            this.enable_btn.Click += new System.EventHandler(this.enable_btn_Click);
            // 
            // btn_dgv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DGV_panel);
            this.Controls.Add(this.paging_panel);
            this.Controls.Add(this.btn_panel);
            this.Name = "btn_dgv";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.Size = new System.Drawing.Size(784, 209);
            this.Load += new System.EventHandler(this.btn_dgv_Load);
            this.btn_panel.ResumeLayout(false);
            this.paging_panel.ResumeLayout(false);
            this.paging_panel.PerformLayout();
            this.DGV_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel btn_panel;
        public System.Windows.Forms.Button search_btn;
        public System.Windows.Forms.Button refresh_btn;
        public System.Windows.Forms.Panel paging_panel;
        public System.Windows.Forms.Button last_btn;
        public System.Windows.Forms.Button next_btn;
        public System.Windows.Forms.Label total_lbl;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox page_txt;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button prev_btn;
        public System.Windows.Forms.Button first_btn;
        private System.Windows.Forms.Label total_record_lbl;
        private System.Windows.Forms.Panel DGV_panel;
        public System.Windows.Forms.DataGridView DGV;
        public System.Windows.Forms.Button enable_btn;
        public System.Windows.Forms.Button add_btn;
        public System.Windows.Forms.Button edit_btn;
        public System.Windows.Forms.Button del_btn;
    }
}
