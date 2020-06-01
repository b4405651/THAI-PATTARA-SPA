namespace SPA_MANAGEMENT_SYSTEM.SHOP
{
    partial class misc_item
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
            this.unit_price = new System.Windows.Forms.TextBox();
            this.unit_price_lbl = new System.Windows.Forms.Label();
            this.misc_name = new System.Windows.Forms.TextBox();
            this.misc_name_lbl = new System.Windows.Forms.Label();
            this.rub_lbl = new System.Windows.Forms.Label();
            this.amount = new System.Windows.Forms.TextBox();
            this.amount_lbl = new System.Windows.Forms.Label();
            this.total_lbl = new System.Windows.Forms.Label();
            this.total_price = new System.Windows.Forms.Label();
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
            this.cancel_btn.Location = new System.Drawing.Point(206, 123);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(101, 59);
            this.cancel_btn.TabIndex = 5;
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
            this.manage_btn.Location = new System.Drawing.Point(99, 123);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(101, 59);
            this.manage_btn.TabIndex = 4;
            this.manage_btn.Text = "ADD";
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // unit_price
            // 
            this.unit_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.unit_price.Location = new System.Drawing.Point(127, 31);
            this.unit_price.Name = "unit_price";
            this.unit_price.Size = new System.Drawing.Size(106, 24);
            this.unit_price.TabIndex = 2;
            this.unit_price.Tag = "";
            this.unit_price.Text = "0";
            this.unit_price.TextChanged += new System.EventHandler(this.price_TextChanged);
            this.unit_price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.price_KeyPress);
            // 
            // unit_price_lbl
            // 
            this.unit_price_lbl.AutoSize = true;
            this.unit_price_lbl.BackColor = System.Drawing.Color.Transparent;
            this.unit_price_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.unit_price_lbl.Location = new System.Drawing.Point(9, 34);
            this.unit_price_lbl.Name = "unit_price_lbl";
            this.unit_price_lbl.Size = new System.Drawing.Size(116, 18);
            this.unit_price_lbl.TabIndex = 90;
            this.unit_price_lbl.Text = "UNIT PRICE : ";
            // 
            // misc_name
            // 
            this.misc_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.misc_name.Location = new System.Drawing.Point(127, 4);
            this.misc_name.Name = "misc_name";
            this.misc_name.Size = new System.Drawing.Size(180, 24);
            this.misc_name.TabIndex = 1;
            this.misc_name.Tag = "barcode";
            // 
            // misc_name_lbl
            // 
            this.misc_name_lbl.AutoSize = true;
            this.misc_name_lbl.BackColor = System.Drawing.Color.Transparent;
            this.misc_name_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.misc_name_lbl.Location = new System.Drawing.Point(9, 7);
            this.misc_name_lbl.Name = "misc_name_lbl";
            this.misc_name_lbl.Size = new System.Drawing.Size(114, 18);
            this.misc_name_lbl.TabIndex = 88;
            this.misc_name_lbl.Text = "ITEM NAME : ";
            // 
            // rub_lbl
            // 
            this.rub_lbl.AutoSize = true;
            this.rub_lbl.BackColor = System.Drawing.Color.Transparent;
            this.rub_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rub_lbl.Location = new System.Drawing.Point(236, 34);
            this.rub_lbl.Name = "rub_lbl";
            this.rub_lbl.Size = new System.Drawing.Size(43, 18);
            this.rub_lbl.TabIndex = 91;
            this.rub_lbl.Text = "Rub.";
            // 
            // amount
            // 
            this.amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.amount.Location = new System.Drawing.Point(127, 58);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(106, 24);
            this.amount.TabIndex = 3;
            this.amount.Tag = "";
            this.amount.Text = "1";
            this.amount.TextChanged += new System.EventHandler(this.amount_TextChanged);
            this.amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.amount_KeyPress);
            // 
            // amount_lbl
            // 
            this.amount_lbl.AutoSize = true;
            this.amount_lbl.BackColor = System.Drawing.Color.Transparent;
            this.amount_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.amount_lbl.Location = new System.Drawing.Point(9, 61);
            this.amount_lbl.Name = "amount_lbl";
            this.amount_lbl.Size = new System.Drawing.Size(94, 18);
            this.amount_lbl.TabIndex = 93;
            this.amount_lbl.Text = "AMOUNT : ";
            // 
            // total_lbl
            // 
            this.total_lbl.AutoSize = true;
            this.total_lbl.BackColor = System.Drawing.Color.Transparent;
            this.total_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.total_lbl.Location = new System.Drawing.Point(9, 91);
            this.total_lbl.Name = "total_lbl";
            this.total_lbl.Size = new System.Drawing.Size(75, 18);
            this.total_lbl.TabIndex = 94;
            this.total_lbl.Text = "TOTAL : ";
            // 
            // total_price
            // 
            this.total_price.AutoSize = true;
            this.total_price.BackColor = System.Drawing.Color.Transparent;
            this.total_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.total_price.Location = new System.Drawing.Point(125, 91);
            this.total_price.Name = "total_price";
            this.total_price.Size = new System.Drawing.Size(52, 18);
            this.total_price.TabIndex = 95;
            this.total_price.Text = "0 Rub";
            // 
            // misc_item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.CancelButton = this.cancel_btn;
            this.ClientSize = new System.Drawing.Size(321, 193);
            this.Controls.Add(this.total_price);
            this.Controls.Add(this.total_lbl);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.amount_lbl);
            this.Controls.Add(this.rub_lbl);
            this.Controls.Add(this.unit_price);
            this.Controls.Add(this.unit_price_lbl);
            this.Controls.Add(this.misc_name);
            this.Controls.Add(this.misc_name_lbl);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.manage_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "misc_item";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MISCELLANEOUS ITEM";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.misc_item_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button cancel_btn;
        public System.Windows.Forms.Button manage_btn;
        private System.Windows.Forms.TextBox unit_price;
        private System.Windows.Forms.Label unit_price_lbl;
        private System.Windows.Forms.TextBox misc_name;
        private System.Windows.Forms.Label misc_name_lbl;
        private System.Windows.Forms.Label rub_lbl;
        private System.Windows.Forms.TextBox amount;
        private System.Windows.Forms.Label amount_lbl;
        private System.Windows.Forms.Label total_lbl;
        private System.Windows.Forms.Label total_price;
    }
}