namespace SPA_MANAGEMENT_SYSTEM.DEBTOR
{
    partial class debt_list
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
            this.pay_btn = new System.Windows.Forms.Button();
            this.cancel_paid_btn = new System.Windows.Forms.Button();
            this.btn_dgv = new SPA_MANAGEMENT_SYSTEM.btn_dgv();
            this.to_date = new SPA_MANAGEMENT_SYSTEM.date_data();
            this.to_lbl = new System.Windows.Forms.Label();
            this.since_date = new SPA_MANAGEMENT_SYSTEM.date_data();
            this.since_lbl = new System.Windows.Forms.Label();
            this.debt_type = new System.Windows.Forms.ComboBox();
            this.debt_type_lbl = new System.Windows.Forms.Label();
            this.void_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pay_btn
            // 
            this.pay_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.pay_btn.FlatAppearance.BorderSize = 0;
            this.pay_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pay_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.pay_btn.Location = new System.Drawing.Point(10, 7);
            this.pay_btn.Name = "pay_btn";
            this.pay_btn.Size = new System.Drawing.Size(109, 50);
            this.pay_btn.TabIndex = 1;
            this.pay_btn.Text = "PAY";
            this.pay_btn.UseVisualStyleBackColor = false;
            this.pay_btn.Click += new System.EventHandler(this.pay_btn_Click);
            // 
            // cancel_paid_btn
            // 
            this.cancel_paid_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.cancel_paid_btn.FlatAppearance.BorderSize = 0;
            this.cancel_paid_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_paid_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cancel_paid_btn.Location = new System.Drawing.Point(125, 7);
            this.cancel_paid_btn.Name = "cancel_paid_btn";
            this.cancel_paid_btn.Size = new System.Drawing.Size(154, 50);
            this.cancel_paid_btn.TabIndex = 2;
            this.cancel_paid_btn.Text = "CANCEL PAID";
            this.cancel_paid_btn.UseVisualStyleBackColor = false;
            this.cancel_paid_btn.Click += new System.EventHandler(this.cancel_paid_btn_Click);
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
            // to_date
            // 
            this.to_date.Location = new System.Drawing.Point(1016, 20);
            this.to_date.Name = "to_date";
            this.to_date.Size = new System.Drawing.Size(94, 24);
            this.to_date.TabIndex = 1002;
            // 
            // to_lbl
            // 
            this.to_lbl.AutoSize = true;
            this.to_lbl.BackColor = System.Drawing.Color.Transparent;
            this.to_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.to_lbl.Location = new System.Drawing.Point(970, 23);
            this.to_lbl.Name = "to_lbl";
            this.to_lbl.Size = new System.Drawing.Size(46, 18);
            this.to_lbl.TabIndex = 1005;
            this.to_lbl.Text = "TO : ";
            // 
            // since_date
            // 
            this.since_date.Location = new System.Drawing.Point(859, 20);
            this.since_date.Name = "since_date";
            this.since_date.Size = new System.Drawing.Size(94, 24);
            this.since_date.TabIndex = 1001;
            // 
            // since_lbl
            // 
            this.since_lbl.AutoSize = true;
            this.since_lbl.BackColor = System.Drawing.Color.Transparent;
            this.since_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.since_lbl.Location = new System.Drawing.Point(785, 23);
            this.since_lbl.Name = "since_lbl";
            this.since_lbl.Size = new System.Drawing.Size(73, 18);
            this.since_lbl.TabIndex = 1004;
            this.since_lbl.Text = "SINCE : ";
            // 
            // debt_type
            // 
            this.debt_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.debt_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.debt_type.FormattingEnabled = true;
            this.debt_type.Location = new System.Drawing.Point(576, 19);
            this.debt_type.Name = "debt_type";
            this.debt_type.Size = new System.Drawing.Size(177, 26);
            this.debt_type.TabIndex = 1000;
            // 
            // debt_type_lbl
            // 
            this.debt_type_lbl.AutoSize = true;
            this.debt_type_lbl.BackColor = System.Drawing.Color.Transparent;
            this.debt_type_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.debt_type_lbl.Location = new System.Drawing.Point(461, 23);
            this.debt_type_lbl.Name = "debt_type_lbl";
            this.debt_type_lbl.Size = new System.Drawing.Size(114, 18);
            this.debt_type_lbl.TabIndex = 1003;
            this.debt_type_lbl.Text = "DEBT TYPE : ";
            // 
            // void_btn
            // 
            this.void_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.void_btn.Enabled = false;
            this.void_btn.FlatAppearance.BorderSize = 0;
            this.void_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.void_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.void_btn.Location = new System.Drawing.Point(285, 7);
            this.void_btn.Name = "void_btn";
            this.void_btn.Size = new System.Drawing.Size(154, 50);
            this.void_btn.TabIndex = 1006;
            this.void_btn.Text = "VOID DEBT";
            this.void_btn.UseVisualStyleBackColor = false;
            this.void_btn.Click += new System.EventHandler(this.void_btn_Click);
            // 
            // debt_list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(1126, 383);
            this.Controls.Add(this.void_btn);
            this.Controls.Add(this.to_date);
            this.Controls.Add(this.to_lbl);
            this.Controls.Add(this.since_date);
            this.Controls.Add(this.since_lbl);
            this.Controls.Add(this.debt_type);
            this.Controls.Add(this.debt_type_lbl);
            this.Controls.Add(this.cancel_paid_btn);
            this.Controls.Add(this.pay_btn);
            this.Controls.Add(this.btn_dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "debt_list";
            this.ShowInTaskbar = false;
            this.Text = "  DEBT LIST";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.doLoadGridData);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public btn_dgv btn_dgv;
        public System.Windows.Forms.Button pay_btn;
        public System.Windows.Forms.Button cancel_paid_btn;
        private date_data to_date;
        private System.Windows.Forms.Label to_lbl;
        private date_data since_date;
        private System.Windows.Forms.Label since_lbl;
        private System.Windows.Forms.ComboBox debt_type;
        private System.Windows.Forms.Label debt_type_lbl;
        public System.Windows.Forms.Button void_btn;
    }
}