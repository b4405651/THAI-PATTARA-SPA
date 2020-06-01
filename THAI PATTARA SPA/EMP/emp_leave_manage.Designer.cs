namespace SPA_MANAGEMENT_SYSTEM.EMP
{
    partial class emp_leave_manage
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
            this.reason_lbl = new System.Windows.Forms.Label();
            this.reason = new System.Windows.Forms.TextBox();
            this.since_lbl = new System.Windows.Forms.Label();
            this.to_lbl = new System.Windows.Forms.Label();
            this.attachment_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.manage_btn = new System.Windows.Forms.Button();
            this.since = new SPA_MANAGEMENT_SYSTEM.date_data();
            this.to = new SPA_MANAGEMENT_SYSTEM.date_data();
            this.SuspendLayout();
            // 
            // reason_lbl
            // 
            this.reason_lbl.AutoSize = true;
            this.reason_lbl.BackColor = System.Drawing.Color.Transparent;
            this.reason_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.reason_lbl.Location = new System.Drawing.Point(12, 9);
            this.reason_lbl.Name = "reason_lbl";
            this.reason_lbl.Size = new System.Drawing.Size(92, 18);
            this.reason_lbl.TabIndex = 20;
            this.reason_lbl.Text = "REASON : ";
            // 
            // reason
            // 
            this.reason.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.reason.Location = new System.Drawing.Point(150, 6);
            this.reason.Name = "reason";
            this.reason.Size = new System.Drawing.Size(240, 24);
            this.reason.TabIndex = 1;
            // 
            // since_lbl
            // 
            this.since_lbl.AutoSize = true;
            this.since_lbl.BackColor = System.Drawing.Color.Transparent;
            this.since_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.since_lbl.Location = new System.Drawing.Point(12, 37);
            this.since_lbl.Name = "since_lbl";
            this.since_lbl.Size = new System.Drawing.Size(73, 18);
            this.since_lbl.TabIndex = 48;
            this.since_lbl.Text = "SINCE : ";
            // 
            // to_lbl
            // 
            this.to_lbl.AutoSize = true;
            this.to_lbl.BackColor = System.Drawing.Color.Transparent;
            this.to_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.to_lbl.Location = new System.Drawing.Point(12, 65);
            this.to_lbl.Name = "to_lbl";
            this.to_lbl.Size = new System.Drawing.Size(46, 18);
            this.to_lbl.TabIndex = 50;
            this.to_lbl.Text = "TO : ";
            // 
            // attachment_btn
            // 
            this.attachment_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.attachment_btn.FlatAppearance.BorderSize = 0;
            this.attachment_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.attachment_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.attachment_btn.Location = new System.Drawing.Point(12, 93);
            this.attachment_btn.Name = "attachment_btn";
            this.attachment_btn.Size = new System.Drawing.Size(155, 59);
            this.attachment_btn.TabIndex = 5;
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
            this.cancel_btn.Location = new System.Drawing.Point(289, 93);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(101, 59);
            this.cancel_btn.TabIndex = 7;
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
            this.manage_btn.Location = new System.Drawing.Point(182, 93);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(101, 59);
            this.manage_btn.TabIndex = 6;
            this.manage_btn.Text = "ADD";
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // since
            // 
            this.since.Location = new System.Drawing.Point(150, 34);
            this.since.Name = "since";
            this.since.Size = new System.Drawing.Size(94, 24);
            this.since.TabIndex = 2;
            // 
            // to
            // 
            this.to.Location = new System.Drawing.Point(150, 62);
            this.to.Name = "to";
            this.to.Size = new System.Drawing.Size(94, 24);
            this.to.TabIndex = 3;
            // 
            // emp_leave_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(402, 165);
            this.ControlBox = false;
            this.Controls.Add(this.to);
            this.Controls.Add(this.since);
            this.Controls.Add(this.attachment_btn);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.manage_btn);
            this.Controls.Add(this.to_lbl);
            this.Controls.Add(this.since_lbl);
            this.Controls.Add(this.reason);
            this.Controls.Add(this.reason_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "emp_leave_manage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MANAGE EMPLOYEE LEAVE";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.emp_leave_manage_FormClosed);
            this.Load += new System.EventHandler(this.emp_leave_manage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label reason_lbl;
        private System.Windows.Forms.TextBox reason;
        private System.Windows.Forms.Label since_lbl;
        private System.Windows.Forms.Label to_lbl;
        public System.Windows.Forms.Button attachment_btn;
        public System.Windows.Forms.Button cancel_btn;
        public System.Windows.Forms.Button manage_btn;
        private date_data since;
        private date_data to;
    }
}