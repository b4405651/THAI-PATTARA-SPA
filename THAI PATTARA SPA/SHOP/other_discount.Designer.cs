namespace SPA_MANAGEMENT_SYSTEM.SHOP
{
    partial class other_discount
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
            this.amount = new System.Windows.Forms.TextBox();
            this.amount_lbl = new System.Windows.Forms.Label();
            this.manage_btn = new System.Windows.Forms.Button();
            this.ref_no = new System.Windows.Forms.TextBox();
            this.ref_no_lbl = new System.Windows.Forms.Label();
            this.item = new System.Windows.Forms.ComboBox();
            this.item_lbl = new System.Windows.Forms.Label();
            this.approved_by = new System.Windows.Forms.ComboBox();
            this.approved_by_lbl = new System.Windows.Forms.Label();
            this.approve_code = new System.Windows.Forms.TextBox();
            this.approve_code_lbl = new System.Windows.Forms.Label();
            this.approve_box = new System.Windows.Forms.GroupBox();
            this.reason = new System.Windows.Forms.TextBox();
            this.reason_lbl = new System.Windows.Forms.Label();
            this.discount_type = new System.Windows.Forms.ComboBox();
            this.discount_type_lbl = new System.Windows.Forms.Label();
            this.unit = new System.Windows.Forms.ComboBox();
            this.approve_scan_btn = new System.Windows.Forms.Button();
            this.approve_box.SuspendLayout();
            this.SuspendLayout();
            // 
            // amount
            // 
            this.amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.amount.Location = new System.Drawing.Point(135, 108);
            this.amount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(108, 28);
            this.amount.TabIndex = 4;
            this.amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.amount_KeyPress);
            // 
            // amount_lbl
            // 
            this.amount_lbl.AutoSize = true;
            this.amount_lbl.BackColor = System.Drawing.Color.Transparent;
            this.amount_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.amount_lbl.Location = new System.Drawing.Point(16, 111);
            this.amount_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.amount_lbl.Name = "amount_lbl";
            this.amount_lbl.Size = new System.Drawing.Size(117, 24);
            this.amount_lbl.TabIndex = 52;
            this.amount_lbl.Text = "AMOUNT : ";
            // 
            // manage_btn
            // 
            this.manage_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.manage_btn.FlatAppearance.BorderSize = 0;
            this.manage_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manage_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.manage_btn.Location = new System.Drawing.Point(425, 140);
            this.manage_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(221, 73);
            this.manage_btn.TabIndex = 9;
            this.manage_btn.Text = "SUBMIT";
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // ref_no
            // 
            this.ref_no.BackColor = System.Drawing.Color.Gainsboro;
            this.ref_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ref_no.Location = new System.Drawing.Point(135, 42);
            this.ref_no.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ref_no.Name = "ref_no";
            this.ref_no.Size = new System.Drawing.Size(281, 28);
            this.ref_no.TabIndex = 2;
            this.ref_no.TextChanged += new System.EventHandler(this.ref_no_TextChanged);
            this.ref_no.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ref_no_KeyUp);
            // 
            // ref_no_lbl
            // 
            this.ref_no_lbl.AutoSize = true;
            this.ref_no_lbl.BackColor = System.Drawing.Color.Transparent;
            this.ref_no_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ref_no_lbl.Location = new System.Drawing.Point(16, 46);
            this.ref_no_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ref_no_lbl.Name = "ref_no_lbl";
            this.ref_no_lbl.Size = new System.Drawing.Size(106, 24);
            this.ref_no_lbl.TabIndex = 57;
            this.ref_no_lbl.Text = "REF NO : ";
            // 
            // item
            // 
            this.item.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.item.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item.FormattingEnabled = true;
            this.item.Location = new System.Drawing.Point(135, 74);
            this.item.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.item.Name = "item";
            this.item.Size = new System.Drawing.Size(281, 30);
            this.item.TabIndex = 3;
            // 
            // item_lbl
            // 
            this.item_lbl.AutoSize = true;
            this.item_lbl.BackColor = System.Drawing.Color.Transparent;
            this.item_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_lbl.Location = new System.Drawing.Point(16, 79);
            this.item_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.item_lbl.Name = "item_lbl";
            this.item_lbl.Size = new System.Drawing.Size(77, 24);
            this.item_lbl.TabIndex = 59;
            this.item_lbl.Text = "ITEM : ";
            // 
            // approved_by
            // 
            this.approved_by.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.approved_by.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.approved_by.FormattingEnabled = true;
            this.approved_by.Location = new System.Drawing.Point(204, 21);
            this.approved_by.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.approved_by.Name = "approved_by";
            this.approved_by.Size = new System.Drawing.Size(267, 30);
            this.approved_by.TabIndex = 7;
            this.approved_by.SelectedIndexChanged += new System.EventHandler(this.approved_by_SelectedIndexChanged);
            // 
            // approved_by_lbl
            // 
            this.approved_by_lbl.AutoSize = true;
            this.approved_by_lbl.BackColor = System.Drawing.Color.Transparent;
            this.approved_by_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.approved_by_lbl.Location = new System.Drawing.Point(8, 26);
            this.approved_by_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.approved_by_lbl.Name = "approved_by_lbl";
            this.approved_by_lbl.Size = new System.Drawing.Size(172, 24);
            this.approved_by_lbl.TabIndex = 61;
            this.approved_by_lbl.Text = "APPROVED BY : ";
            // 
            // approve_code
            // 
            this.approve_code.Enabled = false;
            this.approve_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.approve_code.Location = new System.Drawing.Point(204, 54);
            this.approve_code.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.approve_code.Name = "approve_code";
            this.approve_code.PasswordChar = '*';
            this.approve_code.Size = new System.Drawing.Size(267, 28);
            this.approve_code.TabIndex = 8;
            this.approve_code.KeyUp += new System.Windows.Forms.KeyEventHandler(this.approve_code_KeyUp);
            // 
            // approve_code_lbl
            // 
            this.approve_code_lbl.AutoSize = true;
            this.approve_code_lbl.BackColor = System.Drawing.Color.Transparent;
            this.approve_code_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.approve_code_lbl.Location = new System.Drawing.Point(8, 57);
            this.approve_code_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.approve_code_lbl.Name = "approve_code_lbl";
            this.approve_code_lbl.Size = new System.Drawing.Size(190, 24);
            this.approve_code_lbl.TabIndex = 63;
            this.approve_code_lbl.Text = "APPROVE CODE : ";
            // 
            // approve_box
            // 
            this.approve_box.Controls.Add(this.approved_by_lbl);
            this.approve_box.Controls.Add(this.approve_code);
            this.approve_box.Controls.Add(this.approved_by);
            this.approve_box.Controls.Add(this.approve_code_lbl);
            this.approve_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.approve_box.Location = new System.Drawing.Point(425, 42);
            this.approve_box.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.approve_box.Name = "approve_box";
            this.approve_box.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.approve_box.Size = new System.Drawing.Size(480, 92);
            this.approve_box.TabIndex = 64;
            this.approve_box.TabStop = false;
            this.approve_box.Text = "APPROVE";
            // 
            // reason
            // 
            this.reason.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.reason.Location = new System.Drawing.Point(135, 140);
            this.reason.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reason.Multiline = true;
            this.reason.Name = "reason";
            this.reason.Size = new System.Drawing.Size(281, 73);
            this.reason.TabIndex = 6;
            // 
            // reason_lbl
            // 
            this.reason_lbl.AutoSize = true;
            this.reason_lbl.BackColor = System.Drawing.Color.Transparent;
            this.reason_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.reason_lbl.Location = new System.Drawing.Point(16, 143);
            this.reason_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.reason_lbl.Name = "reason_lbl";
            this.reason_lbl.Size = new System.Drawing.Size(114, 24);
            this.reason_lbl.TabIndex = 67;
            this.reason_lbl.Text = "REASON : ";
            // 
            // discount_type
            // 
            this.discount_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.discount_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.discount_type.FormattingEnabled = true;
            this.discount_type.Location = new System.Drawing.Point(221, 7);
            this.discount_type.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.discount_type.Name = "discount_type";
            this.discount_type.Size = new System.Drawing.Size(359, 30);
            this.discount_type.TabIndex = 1;
            this.discount_type.SelectedIndexChanged += new System.EventHandler(this.discount_type_SelectedIndexChanged);
            // 
            // discount_type_lbl
            // 
            this.discount_type_lbl.AutoSize = true;
            this.discount_type_lbl.BackColor = System.Drawing.Color.Transparent;
            this.discount_type_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.discount_type_lbl.Location = new System.Drawing.Point(16, 11);
            this.discount_type_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.discount_type_lbl.Name = "discount_type_lbl";
            this.discount_type_lbl.Size = new System.Drawing.Size(191, 24);
            this.discount_type_lbl.TabIndex = 78;
            this.discount_type_lbl.Text = "DISCOUNT TYPE : ";
            // 
            // unit
            // 
            this.unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.unit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.unit.FormattingEnabled = true;
            this.unit.Location = new System.Drawing.Point(252, 107);
            this.unit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.unit.Name = "unit";
            this.unit.Size = new System.Drawing.Size(83, 30);
            this.unit.TabIndex = 5;
            // 
            // approve_scan_btn
            // 
            this.approve_scan_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.approve_scan_btn.FlatAppearance.BorderSize = 0;
            this.approve_scan_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.approve_scan_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.approve_scan_btn.Location = new System.Drawing.Point(655, 140);
            this.approve_scan_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.approve_scan_btn.Name = "approve_scan_btn";
            this.approve_scan_btn.Size = new System.Drawing.Size(251, 73);
            this.approve_scan_btn.TabIndex = 10;
            this.approve_scan_btn.Text = "APPROVE SCAN";
            this.approve_scan_btn.UseVisualStyleBackColor = false;
            this.approve_scan_btn.Click += new System.EventHandler(this.approve_scan_btn_Click);
            // 
            // other_discount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(916, 225);
            this.Controls.Add(this.approve_scan_btn);
            this.Controls.Add(this.unit);
            this.Controls.Add(this.discount_type);
            this.Controls.Add(this.discount_type_lbl);
            this.Controls.Add(this.reason);
            this.Controls.Add(this.reason_lbl);
            this.Controls.Add(this.approve_box);
            this.Controls.Add(this.item);
            this.Controls.Add(this.item_lbl);
            this.Controls.Add(this.ref_no);
            this.Controls.Add(this.ref_no_lbl);
            this.Controls.Add(this.manage_btn);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.amount_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "other_discount";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OTHER DISCOUNT";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.other_discount_Load);
            this.approve_box.ResumeLayout(false);
            this.approve_box.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox amount;
        private System.Windows.Forms.Label amount_lbl;
        public System.Windows.Forms.Button manage_btn;
        private System.Windows.Forms.TextBox ref_no;
        private System.Windows.Forms.Label ref_no_lbl;
        private System.Windows.Forms.Label item_lbl;
        public System.Windows.Forms.ComboBox item;
        public System.Windows.Forms.ComboBox approved_by;
        private System.Windows.Forms.Label approved_by_lbl;
        private System.Windows.Forms.TextBox approve_code;
        private System.Windows.Forms.Label approve_code_lbl;
        private System.Windows.Forms.GroupBox approve_box;
        private System.Windows.Forms.TextBox reason;
        private System.Windows.Forms.Label reason_lbl;
        public System.Windows.Forms.ComboBox discount_type;
        private System.Windows.Forms.Label discount_type_lbl;
        public System.Windows.Forms.ComboBox unit;
        public System.Windows.Forms.Button approve_scan_btn;
    }
}