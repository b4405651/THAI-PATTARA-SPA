namespace SPA_MANAGEMENT_SYSTEM.STORE
{
    partial class store_manage
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
            this.withdraw_reason = new System.Windows.Forms.TextBox();
            this.withdraw_reason_lbl = new System.Windows.Forms.Label();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.code = new System.Windows.Forms.TextBox();
            this.barcode_lbl = new System.Windows.Forms.Label();
            this.amount = new System.Windows.Forms.TextBox();
            this.amount_lbl = new System.Windows.Forms.Label();
            this.item_detail_lbl = new System.Windows.Forms.Label();
            this.manage_btn = new System.Windows.Forms.Button();
            this.line_sep = new SPA_MANAGEMENT_SYSTEM.line_sep();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // withdraw_reason
            // 
            this.withdraw_reason.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.withdraw_reason.Location = new System.Drawing.Point(101, 6);
            this.withdraw_reason.Name = "withdraw_reason";
            this.withdraw_reason.Size = new System.Drawing.Size(525, 24);
            this.withdraw_reason.TabIndex = 1;
            // 
            // withdraw_reason_lbl
            // 
            this.withdraw_reason_lbl.AutoSize = true;
            this.withdraw_reason_lbl.BackColor = System.Drawing.Color.Transparent;
            this.withdraw_reason_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.withdraw_reason_lbl.Location = new System.Drawing.Point(12, 9);
            this.withdraw_reason_lbl.Name = "withdraw_reason_lbl";
            this.withdraw_reason_lbl.Size = new System.Drawing.Size(92, 18);
            this.withdraw_reason_lbl.TabIndex = 31;
            this.withdraw_reason_lbl.Text = "REASON : ";
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.AllowUserToResizeColumns = false;
            this.DGV.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(143)))));
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.DGV.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.DGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(7);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DGV.EnableHeadersVisualStyles = false;
            this.DGV.Location = new System.Drawing.Point(15, 100);
            this.DGV.MultiSelect = false;
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGV.RowHeadersWidth = 60;
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.ShowEditingIcon = false;
            this.DGV.Size = new System.Drawing.Size(611, 310);
            this.DGV.TabIndex = 5;
            this.DGV.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DGV_RowsAdded);
            this.DGV.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.DGV_RowsRemoved);
            this.DGV.Paint += new System.Windows.Forms.PaintEventHandler(this.DGV_Paint);
            this.DGV.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DGV_KeyUp);
            // 
            // code
            // 
            this.code.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.code.Location = new System.Drawing.Point(232, 44);
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(249, 24);
            this.code.TabIndex = 2;
            this.code.Tag = "barcode";
            this.code.TextChanged += new System.EventHandler(this.code_TextChanged);
            this.code.KeyUp += new System.Windows.Forms.KeyEventHandler(this.code_KeyUp);
            // 
            // barcode_lbl
            // 
            this.barcode_lbl.AutoSize = true;
            this.barcode_lbl.BackColor = System.Drawing.Color.Transparent;
            this.barcode_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.barcode_lbl.Location = new System.Drawing.Point(12, 47);
            this.barcode_lbl.Name = "barcode_lbl";
            this.barcode_lbl.Size = new System.Drawing.Size(222, 18);
            this.barcode_lbl.TabIndex = 43;
            this.barcode_lbl.Text = "BARCODE or ITEM CODE : ";
            // 
            // amount
            // 
            this.amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.amount.Location = new System.Drawing.Point(576, 44);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(50, 24);
            this.amount.TabIndex = 3;
            this.amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.amount_KeyPress);
            this.amount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.amount_KeyUp);
            // 
            // amount_lbl
            // 
            this.amount_lbl.AutoSize = true;
            this.amount_lbl.BackColor = System.Drawing.Color.Transparent;
            this.amount_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.amount_lbl.Location = new System.Drawing.Point(487, 47);
            this.amount_lbl.Name = "amount_lbl";
            this.amount_lbl.Size = new System.Drawing.Size(94, 18);
            this.amount_lbl.TabIndex = 45;
            this.amount_lbl.Text = "AMOUNT : ";
            // 
            // item_detail_lbl
            // 
            this.item_detail_lbl.AutoSize = true;
            this.item_detail_lbl.BackColor = System.Drawing.Color.Transparent;
            this.item_detail_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_detail_lbl.Location = new System.Drawing.Point(12, 72);
            this.item_detail_lbl.Name = "item_detail_lbl";
            this.item_detail_lbl.Size = new System.Drawing.Size(123, 18);
            this.item_detail_lbl.TabIndex = 46;
            this.item_detail_lbl.Text = "ITEM DETAIL : ";
            // 
            // manage_btn
            // 
            this.manage_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.manage_btn.FlatAppearance.BorderSize = 0;
            this.manage_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manage_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.manage_btn.Location = new System.Drawing.Point(469, 417);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(156, 59);
            this.manage_btn.TabIndex = 6;
            this.manage_btn.Text = "SAVE";
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // line_sep
            // 
            this.line_sep.BackColor = System.Drawing.Color.Transparent;
            this.line_sep.Location = new System.Drawing.Point(15, 36);
            this.line_sep.MaximumSize = new System.Drawing.Size(2000, 2);
            this.line_sep.MinimumSize = new System.Drawing.Size(0, 2);
            this.line_sep.Name = "line_sep";
            this.line_sep.Size = new System.Drawing.Size(350, 2);
            this.line_sep.TabIndex = 32;
            // 
            // store_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(634, 488);
            this.Controls.Add(this.manage_btn);
            this.Controls.Add(this.item_detail_lbl);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.amount_lbl);
            this.Controls.Add(this.code);
            this.Controls.Add(this.barcode_lbl);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.line_sep);
            this.Controls.Add(this.withdraw_reason);
            this.Controls.Add(this.withdraw_reason_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "store_manage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MANAGE STORE ITEM";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.store_manage_FormClosed);
            this.Load += new System.EventHandler(this.store_manage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox withdraw_reason;
        private System.Windows.Forms.Label withdraw_reason_lbl;
        private line_sep line_sep;
        public System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.TextBox code;
        private System.Windows.Forms.Label barcode_lbl;
        private System.Windows.Forms.TextBox amount;
        private System.Windows.Forms.Label amount_lbl;
        private System.Windows.Forms.Label item_detail_lbl;
        public System.Windows.Forms.Button manage_btn;
    }
}