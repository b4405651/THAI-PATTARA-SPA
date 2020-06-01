namespace SPA_MANAGEMENT_SYSTEM.EMP
{
    partial class emp_contract_manage
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
            this.attachment_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.manage_btn = new System.Windows.Forms.Button();
            this.start_date_lbl = new System.Windows.Forms.Label();
            this.end_date_lbl = new System.Windows.Forms.Label();
            this.end_date = new SPA_MANAGEMENT_SYSTEM.date_data();
            this.start_date = new SPA_MANAGEMENT_SYSTEM.date_data();
            this.SuspendLayout();
            // 
            // attachment_btn
            // 
            this.attachment_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.attachment_btn.FlatAppearance.BorderSize = 0;
            this.attachment_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.attachment_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.attachment_btn.Location = new System.Drawing.Point(12, 65);
            this.attachment_btn.Name = "attachment_btn";
            this.attachment_btn.Size = new System.Drawing.Size(155, 59);
            this.attachment_btn.TabIndex = 3;
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
            this.cancel_btn.Location = new System.Drawing.Point(289, 65);
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
            this.manage_btn.Location = new System.Drawing.Point(182, 65);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(101, 59);
            this.manage_btn.TabIndex = 4;
            this.manage_btn.Text = "ADD";
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // start_date_lbl
            // 
            this.start_date_lbl.AutoSize = true;
            this.start_date_lbl.BackColor = System.Drawing.Color.Transparent;
            this.start_date_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.start_date_lbl.Location = new System.Drawing.Point(12, 9);
            this.start_date_lbl.Name = "start_date_lbl";
            this.start_date_lbl.Size = new System.Drawing.Size(124, 18);
            this.start_date_lbl.TabIndex = 63;
            this.start_date_lbl.Text = "START DATE : ";
            // 
            // end_date_lbl
            // 
            this.end_date_lbl.AutoSize = true;
            this.end_date_lbl.BackColor = System.Drawing.Color.Transparent;
            this.end_date_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.end_date_lbl.Location = new System.Drawing.Point(12, 38);
            this.end_date_lbl.Name = "end_date_lbl";
            this.end_date_lbl.Size = new System.Drawing.Size(106, 18);
            this.end_date_lbl.TabIndex = 65;
            this.end_date_lbl.Text = "END DATE : ";
            // 
            // end_date
            // 
            this.end_date.Location = new System.Drawing.Point(136, 35);
            this.end_date.Name = "end_date";
            this.end_date.Size = new System.Drawing.Size(94, 24);
            this.end_date.TabIndex = 2;
            // 
            // start_date
            // 
            this.start_date.Location = new System.Drawing.Point(136, 6);
            this.start_date.Name = "start_date";
            this.start_date.Size = new System.Drawing.Size(94, 24);
            this.start_date.TabIndex = 1;
            // 
            // emp_contract_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(402, 133);
            this.ControlBox = false;
            this.Controls.Add(this.end_date);
            this.Controls.Add(this.end_date_lbl);
            this.Controls.Add(this.start_date);
            this.Controls.Add(this.attachment_btn);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.manage_btn);
            this.Controls.Add(this.start_date_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "emp_contract_manage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MANAGE EMPLOYEE CONTRACT";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.emp_contract_manage_FormClosed);
            this.Load += new System.EventHandler(this.emp_contract_manage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private date_data start_date;
        public System.Windows.Forms.Button attachment_btn;
        public System.Windows.Forms.Button cancel_btn;
        public System.Windows.Forms.Button manage_btn;
        private System.Windows.Forms.Label start_date_lbl;
        private date_data end_date;
        private System.Windows.Forms.Label end_date_lbl;
    }
}