namespace SPA_MANAGEMENT_SYSTEM.EMP
{
    partial class config_department_manage
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
            this.department_name = new System.Windows.Forms.TextBox();
            this.department_name_lbl = new System.Windows.Forms.Label();
            this.department_code = new System.Windows.Forms.TextBox();
            this.department_code_lbl = new System.Windows.Forms.Label();
            this.manage_btn = new System.Windows.Forms.Button();
            this.active = new System.Windows.Forms.ComboBox();
            this.active_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // department_name
            // 
            this.department_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.department_name.Location = new System.Drawing.Point(198, 6);
            this.department_name.Name = "department_name";
            this.department_name.Size = new System.Drawing.Size(149, 24);
            this.department_name.TabIndex = 1;
            // 
            // department_name_lbl
            // 
            this.department_name_lbl.AutoSize = true;
            this.department_name_lbl.BackColor = System.Drawing.Color.Transparent;
            this.department_name_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.department_name_lbl.Location = new System.Drawing.Point(12, 9);
            this.department_name_lbl.Name = "department_name_lbl";
            this.department_name_lbl.Size = new System.Drawing.Size(188, 18);
            this.department_name_lbl.TabIndex = 53;
            this.department_name_lbl.Text = "DEPARTMENT NAME : ";
            // 
            // department_code
            // 
            this.department_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.department_code.Location = new System.Drawing.Point(198, 35);
            this.department_code.Name = "department_code";
            this.department_code.Size = new System.Drawing.Size(149, 24);
            this.department_code.TabIndex = 2;
            // 
            // department_code_lbl
            // 
            this.department_code_lbl.AutoSize = true;
            this.department_code_lbl.BackColor = System.Drawing.Color.Transparent;
            this.department_code_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.department_code_lbl.Location = new System.Drawing.Point(12, 38);
            this.department_code_lbl.Name = "department_code_lbl";
            this.department_code_lbl.Size = new System.Drawing.Size(71, 18);
            this.department_code_lbl.TabIndex = 55;
            this.department_code_lbl.Text = "CODE : ";
            // 
            // manage_btn
            // 
            this.manage_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.manage_btn.FlatAppearance.BorderSize = 0;
            this.manage_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manage_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.manage_btn.Location = new System.Drawing.Point(244, 95);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(101, 59);
            this.manage_btn.TabIndex = 4;
            this.manage_btn.Text = "ADD";
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // active
            // 
            this.active.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.active.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.active.FormattingEnabled = true;
            this.active.Location = new System.Drawing.Point(198, 63);
            this.active.Name = "active";
            this.active.Size = new System.Drawing.Size(149, 26);
            this.active.TabIndex = 3;
            // 
            // active_lbl
            // 
            this.active_lbl.AutoSize = true;
            this.active_lbl.BackColor = System.Drawing.Color.Transparent;
            this.active_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.active_lbl.Location = new System.Drawing.Point(12, 67);
            this.active_lbl.Name = "active_lbl";
            this.active_lbl.Size = new System.Drawing.Size(87, 18);
            this.active_lbl.TabIndex = 57;
            this.active_lbl.Text = "STATUS : ";
            // 
            // config_department_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(353, 159);
            this.Controls.Add(this.active);
            this.Controls.Add(this.active_lbl);
            this.Controls.Add(this.manage_btn);
            this.Controls.Add(this.department_code);
            this.Controls.Add(this.department_code_lbl);
            this.Controls.Add(this.department_name);
            this.Controls.Add(this.department_name_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "config_department_manage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MANAGE DEPARTMENT";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.config_department_manage_FormClosed);
            this.Load += new System.EventHandler(this.config_department_manage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox department_name;
        private System.Windows.Forms.Label department_name_lbl;
        private System.Windows.Forms.TextBox department_code;
        private System.Windows.Forms.Label department_code_lbl;
        public System.Windows.Forms.Button manage_btn;
        private System.Windows.Forms.ComboBox active;
        private System.Windows.Forms.Label active_lbl;
    }
}