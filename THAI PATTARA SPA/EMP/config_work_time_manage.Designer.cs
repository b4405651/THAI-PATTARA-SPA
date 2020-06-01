namespace SPA_MANAGEMENT_SYSTEM.EMP
{
    partial class config_work_time_manage
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
            this.label2 = new System.Windows.Forms.Label();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.manage_btn = new System.Windows.Forms.Button();
            this.cut_wage_amount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cut_wage_unit = new System.Windows.Forms.ComboBox();
            this.in_time_lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.out_time_lbl = new System.Windows.Forms.Label();
            this.out_time = new SPA_MANAGEMENT_SYSTEM.USER_CONTROL.time_data();
            this.late_time = new SPA_MANAGEMENT_SYSTEM.USER_CONTROL.time_data();
            this.in_time = new SPA_MANAGEMENT_SYSTEM.USER_CONTROL.time_data();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 18);
            this.label2.TabIndex = 27;
            this.label2.Text = "LATE TIME : ";
            // 
            // cancel_btn
            // 
            this.cancel_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.cancel_btn.CausesValidation = false;
            this.cancel_btn.FlatAppearance.BorderSize = 0;
            this.cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cancel_btn.Location = new System.Drawing.Point(185, 120);
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
            this.manage_btn.Location = new System.Drawing.Point(78, 120);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(101, 59);
            this.manage_btn.TabIndex = 6;
            this.manage_btn.Text = "ADD";
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // cut_wage_amount
            // 
            this.cut_wage_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cut_wage_amount.Location = new System.Drawing.Point(155, 88);
            this.cut_wage_amount.Name = "cut_wage_amount";
            this.cut_wage_amount.Size = new System.Drawing.Size(64, 24);
            this.cut_wage_amount.TabIndex = 4;
            this.cut_wage_amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cut_wage_amount_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(12, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 18);
            this.label4.TabIndex = 33;
            this.label4.Text = "CUT WAGE : ";
            // 
            // cut_wage_unit
            // 
            this.cut_wage_unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cut_wage_unit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cut_wage_unit.FormattingEnabled = true;
            this.cut_wage_unit.Location = new System.Drawing.Point(225, 88);
            this.cut_wage_unit.Name = "cut_wage_unit";
            this.cut_wage_unit.Size = new System.Drawing.Size(61, 26);
            this.cut_wage_unit.TabIndex = 5;
            // 
            // in_time_lbl
            // 
            this.in_time_lbl.AutoSize = true;
            this.in_time_lbl.BackColor = System.Drawing.Color.Transparent;
            this.in_time_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.in_time_lbl.Location = new System.Drawing.Point(12, 9);
            this.in_time_lbl.Name = "in_time_lbl";
            this.in_time_lbl.Size = new System.Drawing.Size(146, 18);
            this.in_time_lbl.TabIndex = 35;
            this.in_time_lbl.Text = "CLOCK-IN TIME : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(216, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 18);
            this.label1.TabIndex = 37;
            this.label1.Text = "( 24 hrs )";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(216, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 18);
            this.label3.TabIndex = 41;
            this.label3.Text = "( 24 hrs )";
            // 
            // out_time_lbl
            // 
            this.out_time_lbl.AutoSize = true;
            this.out_time_lbl.BackColor = System.Drawing.Color.Transparent;
            this.out_time_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.out_time_lbl.Location = new System.Drawing.Point(12, 63);
            this.out_time_lbl.Name = "out_time_lbl";
            this.out_time_lbl.Size = new System.Drawing.Size(146, 18);
            this.out_time_lbl.TabIndex = 39;
            this.out_time_lbl.Text = "CLOCK-IN TIME : ";
            // 
            // out_time
            // 
            this.out_time.Location = new System.Drawing.Point(155, 60);
            this.out_time.Name = "out_time";
            this.out_time.Size = new System.Drawing.Size(50, 24);
            this.out_time.TabIndex = 3;
            // 
            // late_time
            // 
            this.late_time.Location = new System.Drawing.Point(155, 33);
            this.late_time.Name = "late_time";
            this.late_time.Size = new System.Drawing.Size(50, 24);
            this.late_time.TabIndex = 2;
            // 
            // in_time
            // 
            this.in_time.Location = new System.Drawing.Point(155, 6);
            this.in_time.Name = "in_time";
            this.in_time.Size = new System.Drawing.Size(50, 24);
            this.in_time.TabIndex = 1;
            // 
            // config_work_time_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(298, 191);
            this.ControlBox = false;
            this.Controls.Add(this.out_time);
            this.Controls.Add(this.late_time);
            this.Controls.Add(this.in_time);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.out_time_lbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.in_time_lbl);
            this.Controls.Add(this.cut_wage_unit);
            this.Controls.Add(this.cut_wage_amount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.manage_btn);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "config_work_time_manage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MANAGE EMPLOYEE LATE TIME";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.config_work_time_manage_FormClosed);
            this.Load += new System.EventHandler(this.config_work_time_manage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button cancel_btn;
        public System.Windows.Forms.Button manage_btn;
        private System.Windows.Forms.TextBox cut_wage_amount;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cut_wage_unit;
        private System.Windows.Forms.Label in_time_lbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label out_time_lbl;
        private USER_CONTROL.time_data in_time;
        private USER_CONTROL.time_data late_time;
        private USER_CONTROL.time_data out_time;
    }
}