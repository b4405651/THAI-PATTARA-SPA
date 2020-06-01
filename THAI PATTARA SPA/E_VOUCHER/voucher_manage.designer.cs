namespace SPA_MANAGEMENT_SYSTEM.VOUCHER
{
    partial class voucher_manage
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
            this.manage_btn = new System.Windows.Forms.Button();
            this.expire_amount = new System.Windows.Forms.TextBox();
            this.expire_lbl = new System.Windows.Forms.Label();
            this.expire_unit = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // manage_btn
            // 
            this.manage_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.manage_btn.FlatAppearance.BorderSize = 0;
            this.manage_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manage_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.manage_btn.Location = new System.Drawing.Point(166, 36);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(101, 59);
            this.manage_btn.TabIndex = 7;
            this.manage_btn.Text = "ADD";
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // expire_amount
            // 
            this.expire_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.expire_amount.Location = new System.Drawing.Point(91, 6);
            this.expire_amount.Name = "expire_amount";
            this.expire_amount.Size = new System.Drawing.Size(82, 24);
            this.expire_amount.TabIndex = 1;
            this.expire_amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.expire_amount_KeyPress);
            // 
            // expire_lbl
            // 
            this.expire_lbl.AutoSize = true;
            this.expire_lbl.BackColor = System.Drawing.Color.Transparent;
            this.expire_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.expire_lbl.Location = new System.Drawing.Point(8, 9);
            this.expire_lbl.Name = "expire_lbl";
            this.expire_lbl.Size = new System.Drawing.Size(83, 18);
            this.expire_lbl.TabIndex = 68;
            this.expire_lbl.Text = "EXPIRE : ";
            // 
            // expire_unit
            // 
            this.expire_unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.expire_unit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.expire_unit.FormattingEnabled = true;
            this.expire_unit.Location = new System.Drawing.Point(175, 6);
            this.expire_unit.Name = "expire_unit";
            this.expire_unit.Size = new System.Drawing.Size(94, 26);
            this.expire_unit.TabIndex = 2;
            // 
            // voucher_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(275, 105);
            this.Controls.Add(this.expire_unit);
            this.Controls.Add(this.expire_amount);
            this.Controls.Add(this.expire_lbl);
            this.Controls.Add(this.manage_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "voucher_manage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONFIG VOUCHER";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.voucher_manage_FormClosed);
            this.Load += new System.EventHandler(this.voucher_manage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button manage_btn;
        private System.Windows.Forms.TextBox expire_amount;
        private System.Windows.Forms.Label expire_lbl;
        public System.Windows.Forms.ComboBox expire_unit;
    }
}