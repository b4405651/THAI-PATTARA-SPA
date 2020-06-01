namespace SPA_MANAGEMENT_SYSTEM.COUPON
{
    partial class config_coupon_set_manage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(config_coupon_set_manage));
            this.save_btn = new System.Windows.Forms.Button();
            this.spa_program_id = new System.Windows.Forms.ComboBox();
            this.spa_program_lbl = new System.Windows.Forms.Label();
            this.add_data_btn = new System.Windows.Forms.Button();
            this.amount = new System.Windows.Forms.TextBox();
            this.add_data_panel = new System.Windows.Forms.Panel();
            this.coupon_set_data_panel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.TextBox();
            this.price_lbl = new System.Windows.Forms.Label();
            this.expire_unit = new System.Windows.Forms.ComboBox();
            this.expire_amount = new System.Windows.Forms.TextBox();
            this.expire_lbl = new System.Windows.Forms.Label();
            this.coupon_set_name = new System.Windows.Forms.TextBox();
            this.coupon_set_name_lbl = new System.Windows.Forms.Label();
            this.btn_dgv = new SPA_MANAGEMENT_SYSTEM.btn_dgv();
            this.add_data_panel.SuspendLayout();
            this.coupon_set_data_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // save_btn
            // 
            this.save_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.save_btn.FlatAppearance.BorderSize = 0;
            this.save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.save_btn.Location = new System.Drawing.Point(10, 7);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(109, 50);
            this.save_btn.TabIndex = 9999;
            this.save_btn.Text = "SAVE";
            this.save_btn.UseVisualStyleBackColor = false;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // spa_program_id
            // 
            this.spa_program_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.spa_program_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.spa_program_id.FormattingEnabled = true;
            this.spa_program_id.Location = new System.Drawing.Point(165, 11);
            this.spa_program_id.Name = "spa_program_id";
            this.spa_program_id.Size = new System.Drawing.Size(176, 26);
            this.spa_program_id.TabIndex = 5;
            // 
            // spa_program_lbl
            // 
            this.spa_program_lbl.AutoSize = true;
            this.spa_program_lbl.BackColor = System.Drawing.Color.Transparent;
            this.spa_program_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.spa_program_lbl.Location = new System.Drawing.Point(19, 16);
            this.spa_program_lbl.Name = "spa_program_lbl";
            this.spa_program_lbl.Size = new System.Drawing.Size(145, 18);
            this.spa_program_lbl.TabIndex = 1001;
            this.spa_program_lbl.Text = "SPA PROGRAM : ";
            // 
            // add_data_btn
            // 
            this.add_data_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.add_data_btn.FlatAppearance.BorderSize = 0;
            this.add_data_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_data_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.add_data_btn.Image = ((System.Drawing.Image)(resources.GetObject("add_data_btn.Image")));
            this.add_data_btn.Location = new System.Drawing.Point(430, 11);
            this.add_data_btn.Name = "add_data_btn";
            this.add_data_btn.Size = new System.Drawing.Size(24, 24);
            this.add_data_btn.TabIndex = 7;
            this.add_data_btn.UseVisualStyleBackColor = false;
            this.add_data_btn.Click += new System.EventHandler(this.add_data_btn_Click);
            // 
            // amount
            // 
            this.amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.amount.Location = new System.Drawing.Point(348, 13);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(74, 24);
            this.amount.TabIndex = 6;
            this.amount.Text = "1";
            this.amount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.amount_KeyUp);
            // 
            // add_data_panel
            // 
            this.add_data_panel.Controls.Add(this.spa_program_lbl);
            this.add_data_panel.Controls.Add(this.amount);
            this.add_data_panel.Controls.Add(this.spa_program_id);
            this.add_data_panel.Controls.Add(this.add_data_btn);
            this.add_data_panel.Location = new System.Drawing.Point(126, 7);
            this.add_data_panel.Name = "add_data_panel";
            this.add_data_panel.Size = new System.Drawing.Size(484, 50);
            this.add_data_panel.TabIndex = 1005;
            // 
            // coupon_set_data_panel
            // 
            this.coupon_set_data_panel.Controls.Add(this.label2);
            this.coupon_set_data_panel.Controls.Add(this.price);
            this.coupon_set_data_panel.Controls.Add(this.price_lbl);
            this.coupon_set_data_panel.Controls.Add(this.expire_unit);
            this.coupon_set_data_panel.Controls.Add(this.expire_amount);
            this.coupon_set_data_panel.Controls.Add(this.expire_lbl);
            this.coupon_set_data_panel.Controls.Add(this.coupon_set_name);
            this.coupon_set_data_panel.Controls.Add(this.coupon_set_name_lbl);
            this.coupon_set_data_panel.Location = new System.Drawing.Point(617, 7);
            this.coupon_set_data_panel.Name = "coupon_set_data_panel";
            this.coupon_set_data_panel.Size = new System.Drawing.Size(928, 50);
            this.coupon_set_data_panel.TabIndex = 1006;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(873, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 18);
            this.label2.TabIndex = 1012;
            this.label2.Text = "RUB";
            // 
            // price
            // 
            this.price.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.price.Location = new System.Drawing.Point(750, 13);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(117, 24);
            this.price.TabIndex = 4;
            this.price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.price_KeyPress);
            // 
            // price_lbl
            // 
            this.price_lbl.AutoSize = true;
            this.price_lbl.BackColor = System.Drawing.Color.Transparent;
            this.price_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.price_lbl.Location = new System.Drawing.Point(676, 16);
            this.price_lbl.Name = "price_lbl";
            this.price_lbl.Size = new System.Drawing.Size(73, 18);
            this.price_lbl.TabIndex = 1011;
            this.price_lbl.Text = "PRICE : ";
            // 
            // expire_unit
            // 
            this.expire_unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.expire_unit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.expire_unit.FormattingEnabled = true;
            this.expire_unit.Location = new System.Drawing.Point(566, 13);
            this.expire_unit.Name = "expire_unit";
            this.expire_unit.Size = new System.Drawing.Size(94, 26);
            this.expire_unit.TabIndex = 3;
            // 
            // expire_amount
            // 
            this.expire_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.expire_amount.Location = new System.Drawing.Point(482, 13);
            this.expire_amount.Name = "expire_amount";
            this.expire_amount.Size = new System.Drawing.Size(82, 24);
            this.expire_amount.TabIndex = 2;
            this.expire_amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.expire_amount_KeyPress);
            // 
            // expire_lbl
            // 
            this.expire_lbl.AutoSize = true;
            this.expire_lbl.BackColor = System.Drawing.Color.Transparent;
            this.expire_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.expire_lbl.Location = new System.Drawing.Point(400, 16);
            this.expire_lbl.Name = "expire_lbl";
            this.expire_lbl.Size = new System.Drawing.Size(83, 18);
            this.expire_lbl.TabIndex = 1009;
            this.expire_lbl.Text = "EXPIRE : ";
            // 
            // coupon_set_name
            // 
            this.coupon_set_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.coupon_set_name.Location = new System.Drawing.Point(204, 13);
            this.coupon_set_name.Name = "coupon_set_name";
            this.coupon_set_name.Size = new System.Drawing.Size(190, 24);
            this.coupon_set_name.TabIndex = 1;
            // 
            // coupon_set_name_lbl
            // 
            this.coupon_set_name_lbl.AutoSize = true;
            this.coupon_set_name_lbl.BackColor = System.Drawing.Color.Transparent;
            this.coupon_set_name_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.coupon_set_name_lbl.Location = new System.Drawing.Point(17, 16);
            this.coupon_set_name_lbl.Name = "coupon_set_name_lbl";
            this.coupon_set_name_lbl.Size = new System.Drawing.Size(180, 18);
            this.coupon_set_name_lbl.TabIndex = 1006;
            this.coupon_set_name_lbl.Text = "COUPON SET NAME :";
            // 
            // btn_dgv
            // 
            this.btn_dgv.AutoSize = true;
            this.btn_dgv.BackColor = System.Drawing.Color.Transparent;
            this.btn_dgv.Location = new System.Drawing.Point(0, 63);
            this.btn_dgv.Name = "btn_dgv";
            this.btn_dgv.preventDGVSelectionChanged = false;
            this.btn_dgv.Size = new System.Drawing.Size(1903, 645);
            this.btn_dgv.TabIndex = 999;
            // 
            // config_coupon_set_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(1550, 383);
            this.Controls.Add(this.coupon_set_data_panel);
            this.Controls.Add(this.add_data_panel);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.btn_dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "config_coupon_set_manage";
            this.ShowInTaskbar = false;
            this.Text = "  MANAGE COUPON SET DETAIL";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.config_coupon_set_manage_Load);
            this.add_data_panel.ResumeLayout(false);
            this.add_data_panel.PerformLayout();
            this.coupon_set_data_panel.ResumeLayout(false);
            this.coupon_set_data_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public btn_dgv btn_dgv;
        public System.Windows.Forms.Button save_btn;
        public System.Windows.Forms.ComboBox spa_program_id;
        private System.Windows.Forms.Label spa_program_lbl;
        public System.Windows.Forms.Button add_data_btn;
        private System.Windows.Forms.TextBox amount;
        private System.Windows.Forms.Panel add_data_panel;
        private System.Windows.Forms.Panel coupon_set_data_panel;
        private System.Windows.Forms.TextBox coupon_set_name;
        private System.Windows.Forms.Label coupon_set_name_lbl;
        public System.Windows.Forms.ComboBox expire_unit;
        private System.Windows.Forms.TextBox expire_amount;
        private System.Windows.Forms.Label expire_lbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox price;
        private System.Windows.Forms.Label price_lbl;
    }
}