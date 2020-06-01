namespace SPA_MANAGEMENT_SYSTEM.RESERVATION
{
    partial class master_day_off
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.masterTable = new SPA_MANAGEMENT_SYSTEM.BufferedDataGridView();
            this.day_off = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMP_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.masterTable)).BeginInit();
            this.SuspendLayout();
            // 
            // masterTable
            // 
            this.masterTable.AllowUserToAddRows = false;
            this.masterTable.AllowUserToDeleteRows = false;
            this.masterTable.AllowUserToResizeColumns = false;
            this.masterTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(143)))));
            this.masterTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.masterTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.masterTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.masterTable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.masterTable.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.masterTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 7, 0, 7);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.masterTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.masterTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.masterTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.day_off,
            this.name,
            this.EMP_ID});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 7, 0, 7);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.masterTable.DefaultCellStyle = dataGridViewCellStyle3;
            this.masterTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.masterTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.masterTable.EnableHeadersVisualStyles = false;
            this.masterTable.Location = new System.Drawing.Point(0, 0);
            this.masterTable.MultiSelect = false;
            this.masterTable.Name = "masterTable";
            this.masterTable.ReadOnly = true;
            this.masterTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.masterTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.masterTable.RowHeadersVisible = false;
            this.masterTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.masterTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.masterTable.ShowCellErrors = false;
            this.masterTable.ShowCellToolTips = false;
            this.masterTable.ShowEditingIcon = false;
            this.masterTable.Size = new System.Drawing.Size(284, 501);
            this.masterTable.TabIndex = 113;
            this.masterTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.masterTable_CellClick);
            this.masterTable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.masterTable_CellDoubleClick);
            // 
            // day_off
            // 
            this.day_off.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.day_off.FalseValue = "";
            this.day_off.HeaderText = "";
            this.day_off.Name = "day_off";
            this.day_off.ReadOnly = true;
            this.day_off.TrueValue = "";
            this.day_off.Width = 5;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.HeaderText = "MASTER";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // EMP_ID
            // 
            this.EMP_ID.HeaderText = "EMP_ID";
            this.EMP_ID.Name = "EMP_ID";
            this.EMP_ID.ReadOnly = true;
            this.EMP_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.EMP_ID.Visible = false;
            // 
            // master_day_off
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(284, 501);
            this.Controls.Add(this.masterTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "master_day_off";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MASTER DAY OFF";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.master_day_off_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.master_day_off_FormClosed);
            this.Load += new System.EventHandler(this.master_day_off_Load);
            ((System.ComponentModel.ISupportInitialize)(this.masterTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public BufferedDataGridView masterTable;
        private System.Windows.Forms.DataGridViewCheckBoxColumn day_off;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMP_ID;
    }
}