namespace SPA_MANAGEMENT_SYSTEM.SHOP
{
    partial class gift_certificate_spa_program
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
            this.detail_lbl = new System.Windows.Forms.Label();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.manage_btn = new System.Windows.Forms.Button();
            this.for_txt = new System.Windows.Forms.TextBox();
            this.for_lbl = new System.Windows.Forms.Label();
            this.from_txt = new System.Windows.Forms.TextBox();
            this.from_lbl = new System.Windows.Forms.Label();
            this.rub_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // spa_program_id
            // 
            this.spa_program_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.spa_program_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.spa_program_id.FormattingEnabled = true;
            this.spa_program_id.Location = new System.Drawing.Point(94, 5);
            this.spa_program_id.Name = "spa_program_id";
            this.spa_program_id.Size = new System.Drawing.Size(213, 26);
            this.spa_program_id.TabIndex = 3;
            // 
            // detail_lbl
            // 
            this.detail_lbl.AutoSize = true;
            this.detail_lbl.BackColor = System.Drawing.Color.Transparent;
            this.detail_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.detail_lbl.Location = new System.Drawing.Point(9, 8);
            this.detail_lbl.Name = "detail_lbl";
            this.detail_lbl.Size = new System.Drawing.Size(79, 18);
            this.detail_lbl.TabIndex = 86;
            this.detail_lbl.Text = "DETAIL : ";
            // 
            // cancel_btn
            // 
            this.cancel_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.cancel_btn.CausesValidation = false;
            this.cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_btn.FlatAppearance.BorderSize = 0;
            this.cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cancel_btn.Location = new System.Drawing.Point(206, 89);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(101, 59);
            this.cancel_btn.TabIndex = 8;
            this.cancel_btn.Text = "CANCEL";
            this.cancel_btn.UseVisualStyleBackColor = false;
            // 
            // manage_btn
            // 
            this.manage_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.manage_btn.FlatAppearance.BorderSize = 0;
            this.manage_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manage_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.manage_btn.Location = new System.Drawing.Point(99, 89);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(101, 59);
            this.manage_btn.TabIndex = 7;
            this.manage_btn.Text = "ADD";
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // for_txt
            // 
            this.for_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.for_txt.Location = new System.Drawing.Point(94, 59);
            this.for_txt.Name = "for_txt";
            this.for_txt.Size = new System.Drawing.Size(213, 24);
            this.for_txt.TabIndex = 6;
            this.for_txt.Tag = "barcode";
            // 
            // for_lbl
            // 
            this.for_lbl.AutoSize = true;
            this.for_lbl.BackColor = System.Drawing.Color.Transparent;
            this.for_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.for_lbl.Location = new System.Drawing.Point(9, 62);
            this.for_lbl.Name = "for_lbl";
            this.for_lbl.Size = new System.Drawing.Size(58, 18);
            this.for_lbl.TabIndex = 90;
            this.for_lbl.Text = "FOR : ";
            // 
            // from_txt
            // 
            this.from_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.from_txt.Location = new System.Drawing.Point(94, 32);
            this.from_txt.Name = "from_txt";
            this.from_txt.Size = new System.Drawing.Size(213, 24);
            this.from_txt.TabIndex = 5;
            this.from_txt.Tag = "barcode";
            // 
            // from_lbl
            // 
            this.from_lbl.AutoSize = true;
            this.from_lbl.BackColor = System.Drawing.Color.Transparent;
            this.from_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.from_lbl.Location = new System.Drawing.Point(9, 35);
            this.from_lbl.Name = "from_lbl";
            this.from_lbl.Size = new System.Drawing.Size(72, 18);
            this.from_lbl.TabIndex = 88;
            this.from_lbl.Text = "FROM : ";
            // 
            // rub_lbl
            // 
            this.rub_lbl.AutoSize = true;
            this.rub_lbl.BackColor = System.Drawing.Color.Transparent;
            this.rub_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rub_lbl.Location = new System.Drawing.Point(182, 38);
            this.rub_lbl.Name = "rub_lbl";
            this.rub_lbl.Size = new System.Drawing.Size(43, 18);
            this.rub_lbl.TabIndex = 94;
            this.rub_lbl.Text = "Rub.";
            // 
            // gift_certificate_spa_program
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.CancelButton = this.cancel_btn;
            this.ClientSize = new System.Drawing.Size(321, 155);
            this.Controls.Add(this.spa_program_id);
            this.Controls.Add(this.for_txt);
            this.Controls.Add(this.for_lbl);
            this.Controls.Add(this.from_txt);
            this.Controls.Add(this.from_lbl);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.manage_btn);
            this.Controls.Add(this.detail_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "gift_certificate_spa_program";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SPA PROGRAM GIFT CERTIFICATE";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.gift_certificate_FormClosed);
            this.Load += new System.EventHandler(this.gift_certificate_spa_program_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox spa_program_id;
        private System.Windows.Forms.Label detail_lbl;
        public System.Windows.Forms.Button cancel_btn;
        public System.Windows.Forms.Button manage_btn;
        private System.Windows.Forms.TextBox for_txt;
        private System.Windows.Forms.Label for_lbl;
        private System.Windows.Forms.TextBox from_txt;
        private System.Windows.Forms.Label from_lbl;
        private System.Windows.Forms.Label rub_lbl;
    }
}