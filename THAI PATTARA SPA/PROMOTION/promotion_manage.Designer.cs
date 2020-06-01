namespace SPA_MANAGEMENT_SYSTEM.PROMOTION
{
    partial class promotion_manage
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
            this.promotion_name = new System.Windows.Forms.TextBox();
            this.promotion_name_lbl = new System.Windows.Forms.Label();
            this.to_lbl = new System.Windows.Forms.Label();
            this.since_lbl = new System.Windows.Forms.Label();
            this.amount = new System.Windows.Forms.TextBox();
            this.amount_lbl = new System.Windows.Forms.Label();
            this.end_date = new SPA_MANAGEMENT_SYSTEM.date_data();
            this.start_date = new SPA_MANAGEMENT_SYSTEM.date_data();
            this.for_spa = new System.Windows.Forms.CheckBox();
            this.for_shop = new System.Windows.Forms.CheckBox();
            this.for_restaurant = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cashier_can_approve = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancel_btn
            // 
            this.cancel_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.cancel_btn.CausesValidation = false;
            this.cancel_btn.FlatAppearance.BorderSize = 0;
            this.cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cancel_btn.Location = new System.Drawing.Point(279, 177);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(101, 59);
            this.cancel_btn.TabIndex = 11;
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
            this.manage_btn.Location = new System.Drawing.Point(172, 177);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(101, 59);
            this.manage_btn.TabIndex = 10;
            this.manage_btn.Text = "ADD";
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // promotion_name
            // 
            this.promotion_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.promotion_name.Location = new System.Drawing.Point(187, 6);
            this.promotion_name.Name = "promotion_name";
            this.promotion_name.Size = new System.Drawing.Size(192, 24);
            this.promotion_name.TabIndex = 1;
            this.promotion_name.Tag = "barcode";
            // 
            // promotion_name_lbl
            // 
            this.promotion_name_lbl.AutoSize = true;
            this.promotion_name_lbl.BackColor = System.Drawing.Color.Transparent;
            this.promotion_name_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.promotion_name_lbl.Location = new System.Drawing.Point(12, 9);
            this.promotion_name_lbl.Name = "promotion_name_lbl";
            this.promotion_name_lbl.Size = new System.Drawing.Size(177, 18);
            this.promotion_name_lbl.TabIndex = 57;
            this.promotion_name_lbl.Text = "PROMOTION NAME : ";
            // 
            // to_lbl
            // 
            this.to_lbl.AutoSize = true;
            this.to_lbl.BackColor = System.Drawing.Color.Transparent;
            this.to_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.to_lbl.Location = new System.Drawing.Point(210, 36);
            this.to_lbl.Name = "to_lbl";
            this.to_lbl.Size = new System.Drawing.Size(46, 18);
            this.to_lbl.TabIndex = 61;
            this.to_lbl.Text = "TO : ";
            // 
            // since_lbl
            // 
            this.since_lbl.AutoSize = true;
            this.since_lbl.BackColor = System.Drawing.Color.Transparent;
            this.since_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.since_lbl.Location = new System.Drawing.Point(39, 36);
            this.since_lbl.Name = "since_lbl";
            this.since_lbl.Size = new System.Drawing.Size(73, 18);
            this.since_lbl.TabIndex = 60;
            this.since_lbl.Text = "SINCE : ";
            // 
            // amount
            // 
            this.amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.amount.Location = new System.Drawing.Point(197, 60);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(82, 24);
            this.amount.TabIndex = 4;
            this.amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.amount_KeyPress);
            // 
            // amount_lbl
            // 
            this.amount_lbl.AutoSize = true;
            this.amount_lbl.BackColor = System.Drawing.Color.Transparent;
            this.amount_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.amount_lbl.Location = new System.Drawing.Point(13, 63);
            this.amount_lbl.Name = "amount_lbl";
            this.amount_lbl.Size = new System.Drawing.Size(185, 18);
            this.amount_lbl.TabIndex = 64;
            this.amount_lbl.Text = "DISCOUNT AMOUNT : ";
            // 
            // end_date
            // 
            this.end_date.Location = new System.Drawing.Point(252, 33);
            this.end_date.Name = "end_date";
            this.end_date.Size = new System.Drawing.Size(94, 24);
            this.end_date.TabIndex = 3;
            // 
            // start_date
            // 
            this.start_date.Location = new System.Drawing.Point(109, 33);
            this.start_date.Name = "start_date";
            this.start_date.Size = new System.Drawing.Size(94, 24);
            this.start_date.TabIndex = 2;
            // 
            // for_spa
            // 
            this.for_spa.AutoSize = true;
            this.for_spa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.for_spa.Location = new System.Drawing.Point(36, 23);
            this.for_spa.Name = "for_spa";
            this.for_spa.Size = new System.Drawing.Size(59, 22);
            this.for_spa.TabIndex = 7;
            this.for_spa.Text = "SPA";
            this.for_spa.UseVisualStyleBackColor = true;
            // 
            // for_shop
            // 
            this.for_shop.AutoSize = true;
            this.for_shop.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.for_shop.Location = new System.Drawing.Point(113, 23);
            this.for_shop.Name = "for_shop";
            this.for_shop.Size = new System.Drawing.Size(74, 22);
            this.for_shop.TabIndex = 8;
            this.for_shop.Text = "SHOP";
            this.for_shop.UseVisualStyleBackColor = true;
            // 
            // for_restaurant
            // 
            this.for_restaurant.AutoSize = true;
            this.for_restaurant.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.for_restaurant.Location = new System.Drawing.Point(201, 23);
            this.for_restaurant.Name = "for_restaurant";
            this.for_restaurant.Size = new System.Drawing.Size(137, 22);
            this.for_restaurant.TabIndex = 9;
            this.for_restaurant.Text = "RESTAURANT";
            this.for_restaurant.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.for_spa);
            this.groupBox1.Controls.Add(this.for_restaurant);
            this.groupBox1.Controls.Add(this.for_shop);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(16, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 57);
            this.groupBox1.TabIndex = 65;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "APPLY TO : ";
            // 
            // cashier_can_approve
            // 
            this.cashier_can_approve.AutoSize = true;
            this.cashier_can_approve.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cashier_can_approve.Location = new System.Drawing.Point(158, 92);
            this.cashier_can_approve.Name = "cashier_can_approve";
            this.cashier_can_approve.Size = new System.Drawing.Size(221, 22);
            this.cashier_can_approve.TabIndex = 6;
            this.cashier_can_approve.Text = "CASHIER CAN APPROVE";
            this.cashier_can_approve.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(285, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 18);
            this.label1.TabIndex = 66;
            this.label1.Text = "%";
            // 
            // promotion_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(392, 251);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cashier_can_approve);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.amount_lbl);
            this.Controls.Add(this.end_date);
            this.Controls.Add(this.start_date);
            this.Controls.Add(this.to_lbl);
            this.Controls.Add(this.since_lbl);
            this.Controls.Add(this.promotion_name);
            this.Controls.Add(this.promotion_name_lbl);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.manage_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "promotion_manage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MANAGE PROMOTION";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.promotion_manage_FormClosed);
            this.Load += new System.EventHandler(this.promotion_manage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button cancel_btn;
        public System.Windows.Forms.Button manage_btn;
        private System.Windows.Forms.TextBox promotion_name;
        private System.Windows.Forms.Label promotion_name_lbl;
        private date_data end_date;
        private date_data start_date;
        private System.Windows.Forms.Label to_lbl;
        private System.Windows.Forms.Label since_lbl;
        private System.Windows.Forms.TextBox amount;
        private System.Windows.Forms.Label amount_lbl;
        private System.Windows.Forms.CheckBox for_spa;
        private System.Windows.Forms.CheckBox for_shop;
        private System.Windows.Forms.CheckBox for_restaurant;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cashier_can_approve;
        private System.Windows.Forms.Label label1;
    }
}