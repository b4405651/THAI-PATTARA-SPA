﻿namespace SPA_MANAGEMENT_SYSTEM
{
    partial class re_issue_card_approve
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
            this.approved_by_lbl = new System.Windows.Forms.Label();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.approve_btn = new System.Windows.Forms.Button();
            this.approve_code = new System.Windows.Forms.TextBox();
            this.approved_by = new System.Windows.Forms.ComboBox();
            this.approve_code_lbl = new System.Windows.Forms.Label();
            this.scan_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // approved_by_lbl
            // 
            this.approved_by_lbl.AutoSize = true;
            this.approved_by_lbl.BackColor = System.Drawing.Color.Transparent;
            this.approved_by_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.approved_by_lbl.Location = new System.Drawing.Point(7, 9);
            this.approved_by_lbl.Name = "approved_by_lbl";
            this.approved_by_lbl.Size = new System.Drawing.Size(139, 18);
            this.approved_by_lbl.TabIndex = 68;
            this.approved_by_lbl.Text = "APPROVED BY : ";
            // 
            // cancel_btn
            // 
            this.cancel_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.cancel_btn.CausesValidation = false;
            this.cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_btn.FlatAppearance.BorderSize = 0;
            this.cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cancel_btn.Location = new System.Drawing.Point(259, 62);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(101, 59);
            this.cancel_btn.TabIndex = 4;
            this.cancel_btn.Text = "CANCEL";
            this.cancel_btn.UseVisualStyleBackColor = false;
            // 
            // approve_btn
            // 
            this.approve_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.approve_btn.FlatAppearance.BorderSize = 0;
            this.approve_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.approve_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.approve_btn.Location = new System.Drawing.Point(132, 62);
            this.approve_btn.Name = "approve_btn";
            this.approve_btn.Size = new System.Drawing.Size(121, 59);
            this.approve_btn.TabIndex = 3;
            this.approve_btn.Text = "APPROVE";
            this.approve_btn.UseVisualStyleBackColor = false;
            this.approve_btn.Click += new System.EventHandler(this.approve_btn_Click);
            // 
            // approve_code
            // 
            this.approve_code.Enabled = false;
            this.approve_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.approve_code.Location = new System.Drawing.Point(154, 34);
            this.approve_code.Name = "approve_code";
            this.approve_code.PasswordChar = '*';
            this.approve_code.Size = new System.Drawing.Size(206, 24);
            this.approve_code.TabIndex = 2;
            this.approve_code.KeyUp += new System.Windows.Forms.KeyEventHandler(this.approve_code_KeyUp);
            this.approve_code.Leave += new System.EventHandler(this.approve_code_Leave);
            // 
            // approved_by
            // 
            this.approved_by.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.approved_by.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.approved_by.FormattingEnabled = true;
            this.approved_by.Location = new System.Drawing.Point(154, 5);
            this.approved_by.Name = "approved_by";
            this.approved_by.Size = new System.Drawing.Size(206, 26);
            this.approved_by.TabIndex = 1;
            this.approved_by.SelectedIndexChanged += new System.EventHandler(this.approved_by_SelectedIndexChanged);
            // 
            // approve_code_lbl
            // 
            this.approve_code_lbl.AutoSize = true;
            this.approve_code_lbl.BackColor = System.Drawing.Color.Transparent;
            this.approve_code_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.approve_code_lbl.Location = new System.Drawing.Point(7, 36);
            this.approve_code_lbl.Name = "approve_code_lbl";
            this.approve_code_lbl.Size = new System.Drawing.Size(154, 18);
            this.approve_code_lbl.TabIndex = 69;
            this.approve_code_lbl.Text = "APPROVE CODE : ";
            // 
            // scan_btn
            // 
            this.scan_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.scan_btn.FlatAppearance.BorderSize = 0;
            this.scan_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scan_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.scan_btn.Location = new System.Drawing.Point(5, 62);
            this.scan_btn.Name = "scan_btn";
            this.scan_btn.Size = new System.Drawing.Size(121, 59);
            this.scan_btn.TabIndex = 70;
            this.scan_btn.Text = "SCAN";
            this.scan_btn.UseVisualStyleBackColor = false;
            this.scan_btn.Click += new System.EventHandler(this.scan_btn_Click);
            // 
            // re_issue_card_approve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.CancelButton = this.cancel_btn;
            this.ClientSize = new System.Drawing.Size(370, 132);
            this.ControlBox = false;
            this.Controls.Add(this.scan_btn);
            this.Controls.Add(this.approved_by_lbl);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.approve_btn);
            this.Controls.Add(this.approve_code);
            this.Controls.Add(this.approved_by);
            this.Controls.Add(this.approve_code_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "re_issue_card_approve";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "APPROVE TO RE-ISSUE THE CARD";
            this.Load += new System.EventHandler(this.re_issue_card_approve_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label approved_by_lbl;
        public System.Windows.Forms.Button cancel_btn;
        public System.Windows.Forms.Button approve_btn;
        private System.Windows.Forms.TextBox approve_code;
        public System.Windows.Forms.ComboBox approved_by;
        private System.Windows.Forms.Label approve_code_lbl;
        public System.Windows.Forms.Button scan_btn;
    }
}