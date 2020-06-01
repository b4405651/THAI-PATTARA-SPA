namespace SPA_MANAGEMENT_SYSTEM.CROSS_PROMOTION
{
    partial class cross_promotion_manage
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
            this.card_no = new System.Windows.Forms.TextBox();
            this.card_no_lbl = new System.Windows.Forms.Label();
            this.cross_promotion_name = new System.Windows.Forms.TextBox();
            this.cross_promotion_name_lbl = new System.Windows.Forms.Label();
            this.spa_program_lbl = new System.Windows.Forms.Label();
            this.discount_lbl = new System.Windows.Forms.Label();
            this.percent_lbl = new System.Windows.Forms.Label();
            this.discount = new System.Windows.Forms.TextBox();
            this.expiry_date = new System.Windows.Forms.DateTimePicker();
            this.expiry_date_lbl = new System.Windows.Forms.Label();
            this.spa_program_id = new System.Windows.Forms.ComboBox();
            this.no_expiry_date = new System.Windows.Forms.CheckBox();
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
            this.cancel_btn.Location = new System.Drawing.Point(359, 143);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(101, 59);
            this.cancel_btn.TabIndex = 8;
            this.cancel_btn.Text = "CANCEL";
            this.cancel_btn.UseVisualStyleBackColor = false;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // manage_btn
            // 
            this.manage_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.manage_btn.FlatAppearance.BorderSize = 0;
            this.manage_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manage_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.manage_btn.Location = new System.Drawing.Point(252, 143);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(101, 59);
            this.manage_btn.TabIndex = 7;
            this.manage_btn.Text = "ADD";
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // card_no
            // 
            this.card_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.card_no.Location = new System.Drawing.Point(253, 33);
            this.card_no.Name = "card_no";
            this.card_no.Size = new System.Drawing.Size(178, 24);
            this.card_no.TabIndex = 2;
            this.card_no.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.card_no_KeyPress);
            // 
            // card_no_lbl
            // 
            this.card_no_lbl.AutoSize = true;
            this.card_no_lbl.BackColor = System.Drawing.Color.Transparent;
            this.card_no_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.card_no_lbl.Location = new System.Drawing.Point(12, 36);
            this.card_no_lbl.Name = "card_no_lbl";
            this.card_no_lbl.Size = new System.Drawing.Size(94, 18);
            this.card_no_lbl.TabIndex = 51;
            this.card_no_lbl.Text = "CARD NO :";
            // 
            // cross_promotion_name
            // 
            this.cross_promotion_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cross_promotion_name.Location = new System.Drawing.Point(253, 6);
            this.cross_promotion_name.Name = "cross_promotion_name";
            this.cross_promotion_name.Size = new System.Drawing.Size(288, 24);
            this.cross_promotion_name.TabIndex = 1;
            // 
            // cross_promotion_name_lbl
            // 
            this.cross_promotion_name_lbl.AutoSize = true;
            this.cross_promotion_name_lbl.BackColor = System.Drawing.Color.Transparent;
            this.cross_promotion_name_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cross_promotion_name_lbl.Location = new System.Drawing.Point(12, 9);
            this.cross_promotion_name_lbl.Name = "cross_promotion_name_lbl";
            this.cross_promotion_name_lbl.Size = new System.Drawing.Size(236, 18);
            this.cross_promotion_name_lbl.TabIndex = 50;
            this.cross_promotion_name_lbl.Text = "CROSS PROMOTION NAME :";
            // 
            // spa_program_lbl
            // 
            this.spa_program_lbl.AutoSize = true;
            this.spa_program_lbl.BackColor = System.Drawing.Color.Transparent;
            this.spa_program_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.spa_program_lbl.Location = new System.Drawing.Point(12, 65);
            this.spa_program_lbl.Name = "spa_program_lbl";
            this.spa_program_lbl.Size = new System.Drawing.Size(145, 18);
            this.spa_program_lbl.TabIndex = 74;
            this.spa_program_lbl.Text = "SPA PROGRAM : ";
            // 
            // discount_lbl
            // 
            this.discount_lbl.AutoSize = true;
            this.discount_lbl.BackColor = System.Drawing.Color.Transparent;
            this.discount_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.discount_lbl.Location = new System.Drawing.Point(12, 91);
            this.discount_lbl.Name = "discount_lbl";
            this.discount_lbl.Size = new System.Drawing.Size(109, 18);
            this.discount_lbl.TabIndex = 80;
            this.discount_lbl.Text = "DISCOUNT : ";
            // 
            // percent_lbl
            // 
            this.percent_lbl.AutoSize = true;
            this.percent_lbl.BackColor = System.Drawing.Color.Transparent;
            this.percent_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.percent_lbl.Location = new System.Drawing.Point(316, 91);
            this.percent_lbl.Name = "percent_lbl";
            this.percent_lbl.Size = new System.Drawing.Size(22, 18);
            this.percent_lbl.TabIndex = 81;
            this.percent_lbl.Text = "%";
            // 
            // discount
            // 
            this.discount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.discount.Location = new System.Drawing.Point(253, 88);
            this.discount.Name = "discount";
            this.discount.Size = new System.Drawing.Size(57, 24);
            this.discount.TabIndex = 4;
            this.discount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.discount_KeyPress);
            // 
            // expiry_date
            // 
            this.expiry_date.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.expiry_date.CustomFormat = "dd/MM/yyyy";
            this.expiry_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.expiry_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.expiry_date.Location = new System.Drawing.Point(253, 115);
            this.expiry_date.Name = "expiry_date";
            this.expiry_date.Size = new System.Drawing.Size(124, 24);
            this.expiry_date.TabIndex = 5;
            // 
            // expiry_date_lbl
            // 
            this.expiry_date_lbl.AutoSize = true;
            this.expiry_date_lbl.BackColor = System.Drawing.Color.Transparent;
            this.expiry_date_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.expiry_date_lbl.Location = new System.Drawing.Point(12, 118);
            this.expiry_date_lbl.Name = "expiry_date_lbl";
            this.expiry_date_lbl.Size = new System.Drawing.Size(130, 18);
            this.expiry_date_lbl.TabIndex = 114;
            this.expiry_date_lbl.Text = "EXPIRY DATE : ";
            // 
            // spa_program_id
            // 
            this.spa_program_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.spa_program_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.spa_program_id.FormattingEnabled = true;
            this.spa_program_id.Location = new System.Drawing.Point(252, 60);
            this.spa_program_id.Name = "spa_program_id";
            this.spa_program_id.Size = new System.Drawing.Size(179, 26);
            this.spa_program_id.TabIndex = 3;
            // 
            // no_expiry_date
            // 
            this.no_expiry_date.AutoSize = true;
            this.no_expiry_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.no_expiry_date.Location = new System.Drawing.Point(383, 118);
            this.no_expiry_date.Name = "no_expiry_date";
            this.no_expiry_date.Size = new System.Drawing.Size(164, 22);
            this.no_expiry_date.TabIndex = 6;
            this.no_expiry_date.Text = "NO EXPIRY DATE";
            this.no_expiry_date.UseVisualStyleBackColor = true;
            this.no_expiry_date.CheckedChanged += new System.EventHandler(this.no_expiry_date_CheckedChanged);
            // 
            // cross_promotion_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(549, 210);
            this.ControlBox = false;
            this.Controls.Add(this.no_expiry_date);
            this.Controls.Add(this.spa_program_id);
            this.Controls.Add(this.expiry_date);
            this.Controls.Add(this.expiry_date_lbl);
            this.Controls.Add(this.discount);
            this.Controls.Add(this.percent_lbl);
            this.Controls.Add(this.discount_lbl);
            this.Controls.Add(this.spa_program_lbl);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.manage_btn);
            this.Controls.Add(this.card_no);
            this.Controls.Add(this.card_no_lbl);
            this.Controls.Add(this.cross_promotion_name);
            this.Controls.Add(this.cross_promotion_name_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "cross_promotion_manage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MANAGE CROSS PROMOTION";
            this.Load += new System.EventHandler(this.cross_promotion_manage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button cancel_btn;
        public System.Windows.Forms.Button manage_btn;
        private System.Windows.Forms.TextBox card_no;
        private System.Windows.Forms.Label card_no_lbl;
        private System.Windows.Forms.TextBox cross_promotion_name;
        private System.Windows.Forms.Label cross_promotion_name_lbl;
        //public System.Windows.Forms.ComboBox responsible_id;
        private System.Windows.Forms.Label spa_program_lbl;
        private System.Windows.Forms.Label discount_lbl;
        private System.Windows.Forms.Label percent_lbl;
        private System.Windows.Forms.TextBox discount;
        public System.Windows.Forms.DateTimePicker expiry_date;
        private System.Windows.Forms.Label expiry_date_lbl;
        public System.Windows.Forms.ComboBox spa_program_id;
        private System.Windows.Forms.CheckBox no_expiry_date;
    }
}