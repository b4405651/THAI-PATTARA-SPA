namespace SPA_MANAGEMENT_SYSTEM.VOUCHER
{
    partial class issue_e_voucher
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
            this.spa_program_id = new System.Windows.Forms.ComboBox();
            this.spa_program_lbl = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.approved_by_lbl = new System.Windows.Forms.Label();
            this.approve_code = new System.Windows.Forms.TextBox();
            this.approved_by = new System.Windows.Forms.ComboBox();
            this.approve_code_lbl = new System.Windows.Forms.Label();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.save_file_btn = new System.Windows.Forms.Button();
            this.issue_for = new System.Windows.Forms.TextBox();
            this.issue_for_lbl = new System.Windows.Forms.Label();
            this.discount_unit = new System.Windows.Forms.ComboBox();
            this.discount_amount = new System.Windows.Forms.TextBox();
            this.discount_lbl = new System.Windows.Forms.Label();
            this.expiry_date_lbl = new System.Windows.Forms.Label();
            this.expiry_date = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // spa_program_id
            // 
            this.spa_program_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.spa_program_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.spa_program_id.FormattingEnabled = true;
            this.spa_program_id.Location = new System.Drawing.Point(202, 4);
            this.spa_program_id.Name = "spa_program_id";
            this.spa_program_id.Size = new System.Drawing.Size(178, 26);
            this.spa_program_id.TabIndex = 2;
            // 
            // spa_program_lbl
            // 
            this.spa_program_lbl.AutoSize = true;
            this.spa_program_lbl.BackColor = System.Drawing.Color.Transparent;
            this.spa_program_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.spa_program_lbl.Location = new System.Drawing.Point(12, 9);
            this.spa_program_lbl.Name = "spa_program_lbl";
            this.spa_program_lbl.Size = new System.Drawing.Size(145, 18);
            this.spa_program_lbl.TabIndex = 82;
            this.spa_program_lbl.Text = "SPA PROGRAM : ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.approved_by_lbl);
            this.groupBox1.Controls.Add(this.approve_code);
            this.groupBox1.Controls.Add(this.approved_by);
            this.groupBox1.Controls.Add(this.approve_code_lbl);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(15, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 78);
            this.groupBox1.TabIndex = 83;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "APPROVE";
            // 
            // approved_by_lbl
            // 
            this.approved_by_lbl.AutoSize = true;
            this.approved_by_lbl.BackColor = System.Drawing.Color.Transparent;
            this.approved_by_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.approved_by_lbl.Location = new System.Drawing.Point(6, 21);
            this.approved_by_lbl.Name = "approved_by_lbl";
            this.approved_by_lbl.Size = new System.Drawing.Size(139, 18);
            this.approved_by_lbl.TabIndex = 61;
            this.approved_by_lbl.Text = "APPROVED BY : ";
            // 
            // approve_code
            // 
            this.approve_code.Enabled = false;
            this.approve_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.approve_code.Location = new System.Drawing.Point(153, 44);
            this.approve_code.Name = "approve_code";
            this.approve_code.PasswordChar = '*';
            this.approve_code.Size = new System.Drawing.Size(206, 24);
            this.approve_code.TabIndex = 8;
            this.approve_code.Leave += new System.EventHandler(this.approve_code_Leave);
            // 
            // approved_by
            // 
            this.approved_by.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.approved_by.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.approved_by.FormattingEnabled = true;
            this.approved_by.Location = new System.Drawing.Point(153, 17);
            this.approved_by.Name = "approved_by";
            this.approved_by.Size = new System.Drawing.Size(206, 26);
            this.approved_by.TabIndex = 7;
            this.approved_by.SelectedIndexChanged += new System.EventHandler(this.approved_by_SelectedIndexChanged);
            // 
            // approve_code_lbl
            // 
            this.approve_code_lbl.AutoSize = true;
            this.approve_code_lbl.BackColor = System.Drawing.Color.Transparent;
            this.approve_code_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.approve_code_lbl.Location = new System.Drawing.Point(6, 46);
            this.approve_code_lbl.Name = "approve_code_lbl";
            this.approve_code_lbl.Size = new System.Drawing.Size(154, 18);
            this.approve_code_lbl.TabIndex = 63;
            this.approve_code_lbl.Text = "APPROVE CODE : ";
            // 
            // cancel_btn
            // 
            this.cancel_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.cancel_btn.CausesValidation = false;
            this.cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_btn.FlatAppearance.BorderSize = 0;
            this.cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cancel_btn.Location = new System.Drawing.Point(279, 200);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(101, 59);
            this.cancel_btn.TabIndex = 10;
            this.cancel_btn.Text = "CANCEL";
            this.cancel_btn.UseVisualStyleBackColor = false;
            // 
            // save_file_btn
            // 
            this.save_file_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.save_file_btn.FlatAppearance.BorderSize = 0;
            this.save_file_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_file_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.save_file_btn.Location = new System.Drawing.Point(153, 200);
            this.save_file_btn.Name = "save_file_btn";
            this.save_file_btn.Size = new System.Drawing.Size(120, 59);
            this.save_file_btn.TabIndex = 9;
            this.save_file_btn.Text = "SAVE FILE";
            this.save_file_btn.UseVisualStyleBackColor = false;
            this.save_file_btn.Click += new System.EventHandler(this.save_file_btn_Click);
            // 
            // issue_for
            // 
            this.issue_for.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.issue_for.Location = new System.Drawing.Point(122, 33);
            this.issue_for.Name = "issue_for";
            this.issue_for.Size = new System.Drawing.Size(258, 24);
            this.issue_for.TabIndex = 3;
            // 
            // issue_for_lbl
            // 
            this.issue_for_lbl.AutoSize = true;
            this.issue_for_lbl.BackColor = System.Drawing.Color.Transparent;
            this.issue_for_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.issue_for_lbl.Location = new System.Drawing.Point(12, 35);
            this.issue_for_lbl.Name = "issue_for_lbl";
            this.issue_for_lbl.Size = new System.Drawing.Size(112, 18);
            this.issue_for_lbl.TabIndex = 65;
            this.issue_for_lbl.Text = "ISSUE FOR : ";
            // 
            // discount_unit
            // 
            this.discount_unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.discount_unit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.discount_unit.FormattingEnabled = true;
            this.discount_unit.Location = new System.Drawing.Point(261, 60);
            this.discount_unit.Name = "discount_unit";
            this.discount_unit.Size = new System.Drawing.Size(71, 26);
            this.discount_unit.TabIndex = 5;
            // 
            // discount_amount
            // 
            this.discount_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.discount_amount.Location = new System.Drawing.Point(202, 61);
            this.discount_amount.Name = "discount_amount";
            this.discount_amount.Size = new System.Drawing.Size(57, 24);
            this.discount_amount.TabIndex = 4;
            this.discount_amount.Text = "100";
            this.discount_amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.discount_amount_KeyPress);
            // 
            // discount_lbl
            // 
            this.discount_lbl.AutoSize = true;
            this.discount_lbl.BackColor = System.Drawing.Color.Transparent;
            this.discount_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.discount_lbl.Location = new System.Drawing.Point(12, 64);
            this.discount_lbl.Name = "discount_lbl";
            this.discount_lbl.Size = new System.Drawing.Size(109, 18);
            this.discount_lbl.TabIndex = 124;
            this.discount_lbl.Text = "DISCOUNT : ";
            // 
            // expiry_date_lbl
            // 
            this.expiry_date_lbl.AutoSize = true;
            this.expiry_date_lbl.BackColor = System.Drawing.Color.Transparent;
            this.expiry_date_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.expiry_date_lbl.Location = new System.Drawing.Point(12, 92);
            this.expiry_date_lbl.Name = "expiry_date_lbl";
            this.expiry_date_lbl.Size = new System.Drawing.Size(130, 18);
            this.expiry_date_lbl.TabIndex = 126;
            this.expiry_date_lbl.Text = "EXPIRY DATE : ";
            // 
            // expiry_date
            // 
            this.expiry_date.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.expiry_date.CustomFormat = "dd/MM/yyyy";
            this.expiry_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.expiry_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.expiry_date.Location = new System.Drawing.Point(202, 89);
            this.expiry_date.Name = "expiry_date";
            this.expiry_date.Size = new System.Drawing.Size(124, 24);
            this.expiry_date.TabIndex = 6;
            // 
            // issue_e_voucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.CancelButton = this.cancel_btn;
            this.ClientSize = new System.Drawing.Size(397, 264);
            this.ControlBox = false;
            this.Controls.Add(this.expiry_date_lbl);
            this.Controls.Add(this.expiry_date);
            this.Controls.Add(this.discount_unit);
            this.Controls.Add(this.discount_amount);
            this.Controls.Add(this.discount_lbl);
            this.Controls.Add(this.issue_for);
            this.Controls.Add(this.issue_for_lbl);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.save_file_btn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.spa_program_id);
            this.Controls.Add(this.spa_program_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "issue_e_voucher";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ISSUE E-VOUCHER";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.issue_e_voucher_FormClosed);
            this.Load += new System.EventHandler(this.issue_e_voucher_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox spa_program_id;
        private System.Windows.Forms.Label spa_program_lbl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label approved_by_lbl;
        private System.Windows.Forms.TextBox approve_code;
        public System.Windows.Forms.ComboBox approved_by;
        private System.Windows.Forms.Label approve_code_lbl;
        public System.Windows.Forms.Button cancel_btn;
        public System.Windows.Forms.Button save_file_btn;
        private System.Windows.Forms.TextBox issue_for;
        private System.Windows.Forms.Label issue_for_lbl;
        public System.Windows.Forms.ComboBox discount_unit;
        private System.Windows.Forms.TextBox discount_amount;
        private System.Windows.Forms.Label discount_lbl;
        private System.Windows.Forms.Label expiry_date_lbl;
        public System.Windows.Forms.DateTimePicker expiry_date;
    }
}