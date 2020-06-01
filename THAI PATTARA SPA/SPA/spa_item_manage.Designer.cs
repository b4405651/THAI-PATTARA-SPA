namespace SPA_MANAGEMENT_SYSTEM.SPA
{
    partial class spa_item_manage
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
            this.item_code = new System.Windows.Forms.TextBox();
            this.item_code_lbl = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.TextBox();
            this.price_lbl = new System.Windows.Forms.Label();
            this.ruble_lbl = new System.Windows.Forms.Label();
            this.manage_btn = new System.Windows.Forms.Button();
            this.item_detail_lbl = new System.Windows.Forms.Label();
            this.item_detail = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // item_code
            // 
            this.item_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_code.Location = new System.Drawing.Point(136, 6);
            this.item_code.Name = "item_code";
            this.item_code.Size = new System.Drawing.Size(178, 24);
            this.item_code.TabIndex = 1;
            this.item_code.Tag = "barcode";
            this.item_code.TextChanged += new System.EventHandler(this.item_code_TextChanged);
            this.item_code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.item_code_KeyDown);
            // 
            // item_code_lbl
            // 
            this.item_code_lbl.AutoSize = true;
            this.item_code_lbl.BackColor = System.Drawing.Color.Transparent;
            this.item_code_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_code_lbl.Location = new System.Drawing.Point(12, 9);
            this.item_code_lbl.Name = "item_code_lbl";
            this.item_code_lbl.Size = new System.Drawing.Size(115, 18);
            this.item_code_lbl.TabIndex = 55;
            this.item_code_lbl.Text = "ITEM CODE : ";
            // 
            // price
            // 
            this.price.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.price.Location = new System.Drawing.Point(136, 54);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(91, 24);
            this.price.TabIndex = 2;
            this.price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.price_KeyPress);
            // 
            // price_lbl
            // 
            this.price_lbl.AutoSize = true;
            this.price_lbl.BackColor = System.Drawing.Color.Transparent;
            this.price_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.price_lbl.Location = new System.Drawing.Point(12, 57);
            this.price_lbl.Name = "price_lbl";
            this.price_lbl.Size = new System.Drawing.Size(73, 18);
            this.price_lbl.TabIndex = 57;
            this.price_lbl.Text = "PRICE : ";
            // 
            // ruble_lbl
            // 
            this.ruble_lbl.AutoSize = true;
            this.ruble_lbl.BackColor = System.Drawing.Color.Transparent;
            this.ruble_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ruble_lbl.Location = new System.Drawing.Point(233, 57);
            this.ruble_lbl.Name = "ruble_lbl";
            this.ruble_lbl.Size = new System.Drawing.Size(63, 18);
            this.ruble_lbl.TabIndex = 58;
            this.ruble_lbl.Text = "RUBLE";
            // 
            // manage_btn
            // 
            this.manage_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.manage_btn.FlatAppearance.BorderSize = 0;
            this.manage_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manage_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.manage_btn.Location = new System.Drawing.Point(211, 84);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(101, 59);
            this.manage_btn.TabIndex = 3;
            this.manage_btn.Text = "ADD";
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // item_detail_lbl
            // 
            this.item_detail_lbl.AutoSize = true;
            this.item_detail_lbl.BackColor = System.Drawing.Color.Transparent;
            this.item_detail_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_detail_lbl.Location = new System.Drawing.Point(12, 33);
            this.item_detail_lbl.Name = "item_detail_lbl";
            this.item_detail_lbl.Size = new System.Drawing.Size(123, 18);
            this.item_detail_lbl.TabIndex = 59;
            this.item_detail_lbl.Text = "ITEM DETAIL : ";
            // 
            // item_detail
            // 
            this.item_detail.AutoSize = true;
            this.item_detail.BackColor = System.Drawing.Color.Transparent;
            this.item_detail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_detail.Location = new System.Drawing.Point(133, 33);
            this.item_detail.Name = "item_detail";
            this.item_detail.Size = new System.Drawing.Size(123, 18);
            this.item_detail.TabIndex = 60;
            this.item_detail.Text = "ITEM DETAIL : ";
            // 
            // spa_item_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(320, 154);
            this.Controls.Add(this.item_detail);
            this.Controls.Add(this.item_detail_lbl);
            this.Controls.Add(this.manage_btn);
            this.Controls.Add(this.ruble_lbl);
            this.Controls.Add(this.price);
            this.Controls.Add(this.price_lbl);
            this.Controls.Add(this.item_code);
            this.Controls.Add(this.item_code_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "spa_item_manage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MANAGE SPA ITEM";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.spa_item_manage_FormClosed);
            this.Load += new System.EventHandler(this.spa_item_manage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox item_code;
        private System.Windows.Forms.Label item_code_lbl;
        private System.Windows.Forms.TextBox price;
        private System.Windows.Forms.Label price_lbl;
        private System.Windows.Forms.Label ruble_lbl;
        public System.Windows.Forms.Button manage_btn;
        private System.Windows.Forms.Label item_detail_lbl;
        private System.Windows.Forms.Label item_detail;
    }
}