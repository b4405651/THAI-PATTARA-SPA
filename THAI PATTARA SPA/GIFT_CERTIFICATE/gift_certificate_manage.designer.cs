namespace SPA_MANAGEMENT_SYSTEM.GIFT_CERTIFICATE
{
    partial class gift_certificate_manage
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
            this.letter_btn = new System.Windows.Forms.Button();
            this.card_btn = new System.Windows.Forms.Button();
            this.attach_paper_lbl = new System.Windows.Forms.Label();
            this.card_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // manage_btn
            // 
            this.manage_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.manage_btn.FlatAppearance.BorderSize = 0;
            this.manage_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manage_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.manage_btn.Location = new System.Drawing.Point(167, 127);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(101, 59);
            this.manage_btn.TabIndex = 7;
            this.manage_btn.Text = "UPDATE";
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // expire_amount
            // 
            this.expire_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.expire_amount.Location = new System.Drawing.Point(90, 6);
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
            this.expire_unit.Location = new System.Drawing.Point(174, 6);
            this.expire_unit.Name = "expire_unit";
            this.expire_unit.Size = new System.Drawing.Size(94, 26);
            this.expire_unit.TabIndex = 2;
            // 
            // letter_btn
            // 
            this.letter_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.letter_btn.FlatAppearance.BorderSize = 0;
            this.letter_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.letter_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.letter_btn.Location = new System.Drawing.Point(167, 82);
            this.letter_btn.Name = "letter_btn";
            this.letter_btn.Size = new System.Drawing.Size(101, 39);
            this.letter_btn.TabIndex = 72;
            this.letter_btn.Text = "UPLOAD";
            this.letter_btn.UseVisualStyleBackColor = false;
            this.letter_btn.Click += new System.EventHandler(this.letter_btn_Click);
            // 
            // card_btn
            // 
            this.card_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.card_btn.FlatAppearance.BorderSize = 0;
            this.card_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.card_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.card_btn.Location = new System.Drawing.Point(167, 37);
            this.card_btn.Name = "card_btn";
            this.card_btn.Size = new System.Drawing.Size(101, 39);
            this.card_btn.TabIndex = 71;
            this.card_btn.Text = "UPLOAD";
            this.card_btn.UseVisualStyleBackColor = false;
            this.card_btn.Click += new System.EventHandler(this.card_btn_Click);
            // 
            // attach_paper_lbl
            // 
            this.attach_paper_lbl.AutoSize = true;
            this.attach_paper_lbl.BackColor = System.Drawing.Color.Transparent;
            this.attach_paper_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.attach_paper_lbl.Location = new System.Drawing.Point(8, 92);
            this.attach_paper_lbl.Name = "attach_paper_lbl";
            this.attach_paper_lbl.Size = new System.Drawing.Size(86, 18);
            this.attach_paper_lbl.TabIndex = 74;
            this.attach_paper_lbl.Text = "LETTER : ";
            // 
            // card_lbl
            // 
            this.card_lbl.AutoSize = true;
            this.card_lbl.BackColor = System.Drawing.Color.Transparent;
            this.card_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.card_lbl.Location = new System.Drawing.Point(8, 47);
            this.card_lbl.Name = "card_lbl";
            this.card_lbl.Size = new System.Drawing.Size(69, 18);
            this.card_lbl.TabIndex = 73;
            this.card_lbl.Text = "CARD : ";
            // 
            // gift_certificate_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(279, 196);
            this.Controls.Add(this.letter_btn);
            this.Controls.Add(this.card_btn);
            this.Controls.Add(this.attach_paper_lbl);
            this.Controls.Add(this.card_lbl);
            this.Controls.Add(this.expire_unit);
            this.Controls.Add(this.expire_amount);
            this.Controls.Add(this.expire_lbl);
            this.Controls.Add(this.manage_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "gift_certificate_manage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONFIG GIFT CERTIFICATE";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.gift_certificate_manage_FormClosed);
            this.Load += new System.EventHandler(this.gift_certificate_manage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button manage_btn;
        private System.Windows.Forms.TextBox expire_amount;
        private System.Windows.Forms.Label expire_lbl;
        public System.Windows.Forms.ComboBox expire_unit;
        public System.Windows.Forms.Button letter_btn;
        public System.Windows.Forms.Button card_btn;
        private System.Windows.Forms.Label attach_paper_lbl;
        private System.Windows.Forms.Label card_lbl;
    }
}