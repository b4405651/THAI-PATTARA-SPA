namespace SPA_MANAGEMENT_SYSTEM.VIP_CARD
{
    partial class vip_card_manage
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
            this.code_end = new System.Windows.Forms.TextBox();
            this.code_end_lbl = new System.Windows.Forms.Label();
            this.code_begin = new System.Windows.Forms.TextBox();
            this.code_begin_lbl = new System.Windows.Forms.Label();
            this.responsible_id_lbl = new System.Windows.Forms.Label();
            this.discount_lbl = new System.Windows.Forms.Label();
            this.percent_lbl = new System.Windows.Forms.Label();
            this.discount = new System.Windows.Forms.TextBox();
            this.expiry_date_lbl = new System.Windows.Forms.Label();
            this.responsible_id = new SPA_MANAGEMENT_SYSTEM.customAutoComplete();
            this.expiry_date = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // manage_btn
            // 
            this.manage_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.manage_btn.FlatAppearance.BorderSize = 0;
            this.manage_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manage_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.manage_btn.Location = new System.Drawing.Point(278, 144);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(101, 59);
            this.manage_btn.TabIndex = 7;
            this.manage_btn.Text = "ADD";
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // code_end
            // 
            this.code_end.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.code_end.Location = new System.Drawing.Point(202, 33);
            this.code_end.Name = "code_end";
            this.code_end.Size = new System.Drawing.Size(178, 24);
            this.code_end.TabIndex = 2;
            this.code_end.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.code_end_KeyPress);
            // 
            // code_end_lbl
            // 
            this.code_end_lbl.AutoSize = true;
            this.code_end_lbl.BackColor = System.Drawing.Color.Transparent;
            this.code_end_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.code_end_lbl.Location = new System.Drawing.Point(12, 36);
            this.code_end_lbl.Name = "code_end_lbl";
            this.code_end_lbl.Size = new System.Drawing.Size(106, 18);
            this.code_end_lbl.TabIndex = 51;
            this.code_end_lbl.Text = "CODE END :";
            // 
            // code_begin
            // 
            this.code_begin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.code_begin.Location = new System.Drawing.Point(202, 6);
            this.code_begin.Name = "code_begin";
            this.code_begin.Size = new System.Drawing.Size(178, 24);
            this.code_begin.TabIndex = 1;
            this.code_begin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.code_begin_KeyPress);
            // 
            // code_begin_lbl
            // 
            this.code_begin_lbl.AutoSize = true;
            this.code_begin_lbl.BackColor = System.Drawing.Color.Transparent;
            this.code_begin_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.code_begin_lbl.Location = new System.Drawing.Point(12, 9);
            this.code_begin_lbl.Name = "code_begin_lbl";
            this.code_begin_lbl.Size = new System.Drawing.Size(122, 18);
            this.code_begin_lbl.TabIndex = 50;
            this.code_begin_lbl.Text = "CODE BEGIN :";
            // 
            // responsible_id_lbl
            // 
            this.responsible_id_lbl.AutoSize = true;
            this.responsible_id_lbl.BackColor = System.Drawing.Color.Transparent;
            this.responsible_id_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.responsible_id_lbl.Location = new System.Drawing.Point(12, 65);
            this.responsible_id_lbl.Name = "responsible_id_lbl";
            this.responsible_id_lbl.Size = new System.Drawing.Size(139, 18);
            this.responsible_id_lbl.TabIndex = 74;
            this.responsible_id_lbl.Text = "RESPONSIBLE : ";
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
            this.percent_lbl.Location = new System.Drawing.Point(265, 91);
            this.percent_lbl.Name = "percent_lbl";
            this.percent_lbl.Size = new System.Drawing.Size(27, 18);
            this.percent_lbl.TabIndex = 81;
            this.percent_lbl.Text = "% ";
            // 
            // discount
            // 
            this.discount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.discount.Location = new System.Drawing.Point(202, 88);
            this.discount.Name = "discount";
            this.discount.Size = new System.Drawing.Size(57, 24);
            this.discount.TabIndex = 4;
            this.discount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.discount_KeyPress);
            // 
            // expiry_date_lbl
            // 
            this.expiry_date_lbl.AutoSize = true;
            this.expiry_date_lbl.BackColor = System.Drawing.Color.Transparent;
            this.expiry_date_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.expiry_date_lbl.Location = new System.Drawing.Point(12, 119);
            this.expiry_date_lbl.Name = "expiry_date_lbl";
            this.expiry_date_lbl.Size = new System.Drawing.Size(130, 18);
            this.expiry_date_lbl.TabIndex = 114;
            this.expiry_date_lbl.Text = "EXPIRY DATE : ";
            // 
            // responsible_id
            // 
            this.responsible_id.currentID = -1;
            this.responsible_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.responsible_id.ForeColor = System.Drawing.Color.Red;
            this.responsible_id.Location = new System.Drawing.Point(202, 60);
            this.responsible_id.Mode = "EMPLOYEE";
            this.responsible_id.Name = "responsible_id";
            this.responsible_id.Size = new System.Drawing.Size(178, 24);
            this.responsible_id.TabIndex = 3;
            // 
            // expiry_date
            // 
            this.expiry_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.expiry_date.Location = new System.Drawing.Point(202, 116);
            this.expiry_date.Mask = "00/00/0000";
            this.expiry_date.Name = "expiry_date";
            this.expiry_date.Size = new System.Drawing.Size(100, 24);
            this.expiry_date.TabIndex = 115;
            this.expiry_date.ValidatingType = typeof(System.DateTime);
            // 
            // vip_card_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(388, 210);
            this.Controls.Add(this.expiry_date);
            this.Controls.Add(this.expiry_date_lbl);
            this.Controls.Add(this.discount);
            this.Controls.Add(this.percent_lbl);
            this.Controls.Add(this.discount_lbl);
            this.Controls.Add(this.responsible_id);
            this.Controls.Add(this.responsible_id_lbl);
            this.Controls.Add(this.manage_btn);
            this.Controls.Add(this.code_end);
            this.Controls.Add(this.code_end_lbl);
            this.Controls.Add(this.code_begin);
            this.Controls.Add(this.code_begin_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "vip_card_manage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MANAGE VIP CARD";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.vip_card_manage_FormClosed);
            this.Load += new System.EventHandler(this.vip_card_manage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button manage_btn;
        private System.Windows.Forms.TextBox code_end;
        private System.Windows.Forms.Label code_end_lbl;
        private System.Windows.Forms.TextBox code_begin;
        private System.Windows.Forms.Label code_begin_lbl;
        //public System.Windows.Forms.ComboBox responsible_id;
        public customAutoComplete responsible_id;
        private System.Windows.Forms.Label responsible_id_lbl;
        private System.Windows.Forms.Label discount_lbl;
        private System.Windows.Forms.Label percent_lbl;
        private System.Windows.Forms.TextBox discount;
        private System.Windows.Forms.Label expiry_date_lbl;
        private System.Windows.Forms.MaskedTextBox expiry_date;
    }
}