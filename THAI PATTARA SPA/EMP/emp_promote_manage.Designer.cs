namespace SPA_MANAGEMENT_SYSTEM.EMP
{
    partial class emp_promote_manage
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
            this.promote_date_lbl = new System.Windows.Forms.Label();
            this.new_wage_lbl = new System.Windows.Forms.Label();
            this.attachment_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.manage_btn = new System.Windows.Forms.Button();
            this.new_wage = new System.Windows.Forms.TextBox();
            this.promote_date = new SPA_MANAGEMENT_SYSTEM.date_data();
            this.SuspendLayout();
            // 
            // promote_date_lbl
            // 
            this.promote_date_lbl.AutoSize = true;
            this.promote_date_lbl.BackColor = System.Drawing.Color.Transparent;
            this.promote_date_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.promote_date_lbl.Location = new System.Drawing.Point(12, 9);
            this.promote_date_lbl.Name = "promote_date_lbl";
            this.promote_date_lbl.Size = new System.Drawing.Size(155, 18);
            this.promote_date_lbl.TabIndex = 50;
            this.promote_date_lbl.Text = "PROMOTE DATE : ";
            // 
            // new_wage_lbl
            // 
            this.new_wage_lbl.AutoSize = true;
            this.new_wage_lbl.BackColor = System.Drawing.Color.Transparent;
            this.new_wage_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.new_wage_lbl.Location = new System.Drawing.Point(12, 37);
            this.new_wage_lbl.Name = "new_wage_lbl";
            this.new_wage_lbl.Size = new System.Drawing.Size(117, 18);
            this.new_wage_lbl.TabIndex = 54;
            this.new_wage_lbl.Text = "NEW WAGE : ";
            // 
            // attachment_btn
            // 
            this.attachment_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.attachment_btn.FlatAppearance.BorderSize = 0;
            this.attachment_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.attachment_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.attachment_btn.Location = new System.Drawing.Point(12, 63);
            this.attachment_btn.Name = "attachment_btn";
            this.attachment_btn.Size = new System.Drawing.Size(155, 59);
            this.attachment_btn.TabIndex = 4;
            this.attachment_btn.Text = "ATTACHMENT";
            this.attachment_btn.UseVisualStyleBackColor = false;
            this.attachment_btn.Click += new System.EventHandler(this.attachment_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.cancel_btn.CausesValidation = false;
            this.cancel_btn.FlatAppearance.BorderSize = 0;
            this.cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cancel_btn.Location = new System.Drawing.Point(289, 63);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(101, 59);
            this.cancel_btn.TabIndex = 6;
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
            this.manage_btn.Location = new System.Drawing.Point(182, 63);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(101, 59);
            this.manage_btn.TabIndex = 5;
            this.manage_btn.Text = "ADD";
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // new_wage
            // 
            this.new_wage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.new_wage.Location = new System.Drawing.Point(165, 34);
            this.new_wage.Name = "new_wage";
            this.new_wage.Size = new System.Drawing.Size(94, 24);
            this.new_wage.TabIndex = 2;
            this.new_wage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.new_wage_KeyPress);
            this.new_wage.Leave += new System.EventHandler(this.new_wage_Leave);
            // 
            // promote_date
            // 
            this.promote_date.Location = new System.Drawing.Point(165, 6);
            this.promote_date.Name = "promote_date";
            this.promote_date.Size = new System.Drawing.Size(94, 24);
            this.promote_date.TabIndex = 1;
            // 
            // emp_promote_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(402, 135);
            this.ControlBox = false;
            this.Controls.Add(this.promote_date);
            this.Controls.Add(this.new_wage);
            this.Controls.Add(this.attachment_btn);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.manage_btn);
            this.Controls.Add(this.new_wage_lbl);
            this.Controls.Add(this.promote_date_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "emp_promote_manage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MANAGE EMPLOYEE PROMOTE";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.emp_promote_manage_FormClosed);
            this.Load += new System.EventHandler(this.emp_promote_manage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label promote_date_lbl;
        private System.Windows.Forms.Label new_wage_lbl;
        public System.Windows.Forms.Button attachment_btn;
        public System.Windows.Forms.Button cancel_btn;
        public System.Windows.Forms.Button manage_btn;
        private System.Windows.Forms.TextBox new_wage;
        private date_data promote_date;
    }
}