namespace SPA_MANAGEMENT_SYSTEM.SHOP
{
    partial class gift_certificate_money
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
            this.cancel_btn = new System.Windows.Forms.Button();
            this.manage_btn = new System.Windows.Forms.Button();
            this.for_txt = new System.Windows.Forms.TextBox();
            this.for_lbl = new System.Windows.Forms.Label();
            this.from_txt = new System.Windows.Forms.TextBox();
            this.from_lbl = new System.Windows.Forms.Label();
            this.rub_lbl = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.TextBox();
            this.price_lbl = new System.Windows.Forms.Label();
            this.rub1_lbl = new System.Windows.Forms.Label();
            this.rub2_lbl = new System.Windows.Forms.Label();
            this.balance = new System.Windows.Forms.TextBox();
            this.balance_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancel_btn
            // 
            this.cancel_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.cancel_btn.CausesValidation = false;
            this.cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_btn.FlatAppearance.BorderSize = 0;
            this.cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cancel_btn.Location = new System.Drawing.Point(206, 117);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(101, 59);
            this.cancel_btn.TabIndex = 6;
            this.cancel_btn.Text = "CANCEL";
            this.cancel_btn.UseVisualStyleBackColor = false;
            // 
            // manage_btn
            // 
            this.manage_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.manage_btn.FlatAppearance.BorderSize = 0;
            this.manage_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manage_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.manage_btn.Location = new System.Drawing.Point(99, 117);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(101, 59);
            this.manage_btn.TabIndex = 5;
            this.manage_btn.Text = "ADD";
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // for_txt
            // 
            this.for_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.for_txt.Location = new System.Drawing.Point(107, 87);
            this.for_txt.Name = "for_txt";
            this.for_txt.Size = new System.Drawing.Size(200, 24);
            this.for_txt.TabIndex = 4;
            this.for_txt.Tag = "barcode";
            // 
            // for_lbl
            // 
            this.for_lbl.AutoSize = true;
            this.for_lbl.BackColor = System.Drawing.Color.Transparent;
            this.for_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.for_lbl.Location = new System.Drawing.Point(9, 90);
            this.for_lbl.Name = "for_lbl";
            this.for_lbl.Size = new System.Drawing.Size(58, 18);
            this.for_lbl.TabIndex = 90;
            this.for_lbl.Text = "FOR : ";
            // 
            // from_txt
            // 
            this.from_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.from_txt.Location = new System.Drawing.Point(107, 60);
            this.from_txt.Name = "from_txt";
            this.from_txt.Size = new System.Drawing.Size(200, 24);
            this.from_txt.TabIndex = 3;
            this.from_txt.Tag = "barcode";
            // 
            // from_lbl
            // 
            this.from_lbl.AutoSize = true;
            this.from_lbl.BackColor = System.Drawing.Color.Transparent;
            this.from_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.from_lbl.Location = new System.Drawing.Point(9, 63);
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
            // price
            // 
            this.price.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.price.Location = new System.Drawing.Point(107, 6);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(106, 24);
            this.price.TabIndex = 1;
            this.price.Tag = "barcode";
            this.price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.price_KeyPress);
            this.price.Leave += new System.EventHandler(this.price_Leave);
            // 
            // price_lbl
            // 
            this.price_lbl.AutoSize = true;
            this.price_lbl.BackColor = System.Drawing.Color.Transparent;
            this.price_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.price_lbl.Location = new System.Drawing.Point(9, 9);
            this.price_lbl.Name = "price_lbl";
            this.price_lbl.Size = new System.Drawing.Size(73, 18);
            this.price_lbl.TabIndex = 92;
            this.price_lbl.Text = "PRICE : ";
            // 
            // rub1_lbl
            // 
            this.rub1_lbl.AutoSize = true;
            this.rub1_lbl.BackColor = System.Drawing.Color.Transparent;
            this.rub1_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rub1_lbl.Location = new System.Drawing.Point(219, 9);
            this.rub1_lbl.Name = "rub1_lbl";
            this.rub1_lbl.Size = new System.Drawing.Size(43, 18);
            this.rub1_lbl.TabIndex = 93;
            this.rub1_lbl.Text = "Rub.";
            // 
            // rub2_lbl
            // 
            this.rub2_lbl.AutoSize = true;
            this.rub2_lbl.BackColor = System.Drawing.Color.Transparent;
            this.rub2_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rub2_lbl.Location = new System.Drawing.Point(219, 36);
            this.rub2_lbl.Name = "rub2_lbl";
            this.rub2_lbl.Size = new System.Drawing.Size(43, 18);
            this.rub2_lbl.TabIndex = 96;
            this.rub2_lbl.Text = "Rub.";
            // 
            // balance
            // 
            this.balance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.balance.Location = new System.Drawing.Point(107, 33);
            this.balance.Name = "balance";
            this.balance.Size = new System.Drawing.Size(106, 24);
            this.balance.TabIndex = 2;
            this.balance.Tag = "barcode";
            this.balance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.balance_KeyPress);
            // 
            // balance_lbl
            // 
            this.balance_lbl.AutoSize = true;
            this.balance_lbl.BackColor = System.Drawing.Color.Transparent;
            this.balance_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.balance_lbl.Location = new System.Drawing.Point(9, 36);
            this.balance_lbl.Name = "balance_lbl";
            this.balance_lbl.Size = new System.Drawing.Size(98, 18);
            this.balance_lbl.TabIndex = 95;
            this.balance_lbl.Text = "BALANCE : ";
            // 
            // gift_certificate_money
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.CancelButton = this.cancel_btn;
            this.ClientSize = new System.Drawing.Size(321, 183);
            this.Controls.Add(this.rub2_lbl);
            this.Controls.Add(this.balance);
            this.Controls.Add(this.balance_lbl);
            this.Controls.Add(this.rub1_lbl);
            this.Controls.Add(this.price);
            this.Controls.Add(this.price_lbl);
            this.Controls.Add(this.for_txt);
            this.Controls.Add(this.for_lbl);
            this.Controls.Add(this.from_txt);
            this.Controls.Add(this.from_lbl);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.manage_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "gift_certificate_money";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MONEY GIFT CERTIFICATE";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.gift_certificate_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button cancel_btn;
        public System.Windows.Forms.Button manage_btn;
        private System.Windows.Forms.TextBox for_txt;
        private System.Windows.Forms.Label for_lbl;
        private System.Windows.Forms.TextBox from_txt;
        private System.Windows.Forms.Label from_lbl;
        private System.Windows.Forms.Label rub_lbl;
        private System.Windows.Forms.TextBox price;
        private System.Windows.Forms.Label price_lbl;
        private System.Windows.Forms.Label rub1_lbl;
        private System.Windows.Forms.Label rub2_lbl;
        private System.Windows.Forms.TextBox balance;
        private System.Windows.Forms.Label balance_lbl;
    }
}