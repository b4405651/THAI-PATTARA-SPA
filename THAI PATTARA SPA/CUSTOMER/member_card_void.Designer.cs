﻿namespace SPA_MANAGEMENT_SYSTEM.CUSTOMER
{
    partial class member_card_void
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
            this.reason = new System.Windows.Forms.TextBox();
            this.reason_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancel_btn
            // 
            this.cancel_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.cancel_btn.CausesValidation = false;
            this.cancel_btn.FlatAppearance.BorderSize = 0;
            this.cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cancel_btn.Location = new System.Drawing.Point(307, 36);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(101, 59);
            this.cancel_btn.TabIndex = 16;
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
            this.manage_btn.Location = new System.Drawing.Point(200, 36);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(101, 59);
            this.manage_btn.TabIndex = 15;
            this.manage_btn.Text = "ADD";
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // reason
            // 
            this.reason.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.reason.Location = new System.Drawing.Point(102, 6);
            this.reason.Name = "reason";
            this.reason.Size = new System.Drawing.Size(306, 24);
            this.reason.TabIndex = 14;
            // 
            // reason_lbl
            // 
            this.reason_lbl.AutoSize = true;
            this.reason_lbl.BackColor = System.Drawing.Color.Transparent;
            this.reason_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.reason_lbl.Location = new System.Drawing.Point(12, 9);
            this.reason_lbl.Name = "reason_lbl";
            this.reason_lbl.Size = new System.Drawing.Size(92, 18);
            this.reason_lbl.TabIndex = 17;
            this.reason_lbl.Text = "REASON : ";
            // 
            // member_card_void
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(421, 105);
            this.ControlBox = false;
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.manage_btn);
            this.Controls.Add(this.reason);
            this.Controls.Add(this.reason_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "member_card_void";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VOID MEMBER CARD";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.member_card_void_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button cancel_btn;
        public System.Windows.Forms.Button manage_btn;
        private System.Windows.Forms.TextBox reason;
        private System.Windows.Forms.Label reason_lbl;
    }
}