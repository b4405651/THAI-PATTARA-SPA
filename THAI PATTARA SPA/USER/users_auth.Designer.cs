namespace SPA_MANAGEMENT_SYSTEM.USER
{
    partial class users_auth
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
            this.save_btn = new System.Windows.Forms.Button();
            this.emp_data_lbl = new System.Windows.Forms.Label();
            this.authTV = new System.Windows.Forms.myTreeView();
            this.emp_data = new SPA_MANAGEMENT_SYSTEM.customAutoComplete();
            this.go_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // save_btn
            // 
            this.save_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.save_btn.FlatAppearance.BorderSize = 0;
            this.save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.save_btn.Location = new System.Drawing.Point(776, 4);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(97, 50);
            this.save_btn.TabIndex = 4;
            this.save_btn.Text = "SAVE";
            this.save_btn.UseVisualStyleBackColor = false;
            this.save_btn.Visible = false;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // emp_data_lbl
            // 
            this.emp_data_lbl.AutoSize = true;
            this.emp_data_lbl.BackColor = System.Drawing.Color.Transparent;
            this.emp_data_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.emp_data_lbl.Location = new System.Drawing.Point(12, 9);
            this.emp_data_lbl.Name = "emp_data_lbl";
            this.emp_data_lbl.Size = new System.Drawing.Size(165, 18);
            this.emp_data_lbl.TabIndex = 33;
            this.emp_data_lbl.Text = "EMPLOYEE NAME : ";
            // 
            // authTV
            // 
            this.authTV.CheckBoxes = true;
            this.authTV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.authTV.Location = new System.Drawing.Point(15, 40);
            this.authTV.Name = "authTV";
            this.authTV.Size = new System.Drawing.Size(121, 120);
            this.authTV.TabIndex = 3;
            this.authTV.Visible = false;
            this.authTV.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.authTV_AfterCheck);
            // 
            // emp_data
            // 
            this.emp_data.currentID = -1;
            this.emp_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emp_data.ForeColor = System.Drawing.Color.Red;
            this.emp_data.Location = new System.Drawing.Point(176, 3);
            this.emp_data.Mode = "EMPLOYEE";
            this.emp_data.Name = "emp_data";
            this.emp_data.Size = new System.Drawing.Size(184, 24);
            this.emp_data.TabIndex = 1;
            // 
            // go_btn
            // 
            this.go_btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.go_btn.FlatAppearance.BorderSize = 0;
            this.go_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.go_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.go_btn.Image = global::SPA_MANAGEMENT_SYSTEM.Properties.Resources.magnifying_glass_24x24;
            this.go_btn.Location = new System.Drawing.Point(366, 4);
            this.go_btn.Name = "go_btn";
            this.go_btn.Size = new System.Drawing.Size(30, 30);
            this.go_btn.TabIndex = 2;
            this.go_btn.UseVisualStyleBackColor = true;
            this.go_btn.Click += new System.EventHandler(this.go_btn_Click);
            // 
            // users_auth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(885, 261);
            this.ControlBox = false;
            this.Controls.Add(this.go_btn);
            this.Controls.Add(this.emp_data);
            this.Controls.Add(this.emp_data_lbl);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.authTV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "users_auth";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "users_auth";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.myTreeView authTV;
        private System.Windows.Forms.Label emp_data_lbl;
        public System.Windows.Forms.Button go_btn;
        public customAutoComplete emp_data;
    }
}