namespace SPA_MANAGEMENT_SYSTEM.SPA
{
    partial class program_type_manage
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
            this.spa_program_type_name_lbl = new System.Windows.Forms.Label();
            this.spa_program_type_name = new System.Windows.Forms.TextBox();
            this.manage_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // spa_program_type_name_lbl
            // 
            this.spa_program_type_name_lbl.AutoSize = true;
            this.spa_program_type_name_lbl.BackColor = System.Drawing.Color.Transparent;
            this.spa_program_type_name_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.spa_program_type_name_lbl.Location = new System.Drawing.Point(12, 9);
            this.spa_program_type_name_lbl.Name = "spa_program_type_name_lbl";
            this.spa_program_type_name_lbl.Size = new System.Drawing.Size(244, 18);
            this.spa_program_type_name_lbl.TabIndex = 2;
            this.spa_program_type_name_lbl.Text = "SPA PROGRAM TYPE NAME : ";
            // 
            // spa_program_type_name
            // 
            this.spa_program_type_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.spa_program_type_name.Location = new System.Drawing.Point(255, 6);
            this.spa_program_type_name.Name = "spa_program_type_name";
            this.spa_program_type_name.Size = new System.Drawing.Size(178, 24);
            this.spa_program_type_name.TabIndex = 1;
            // 
            // manage_btn
            // 
            this.manage_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.manage_btn.FlatAppearance.BorderSize = 0;
            this.manage_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manage_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.manage_btn.Location = new System.Drawing.Point(331, 34);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(101, 59);
            this.manage_btn.TabIndex = 5;
            this.manage_btn.Text = "ADD";
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // program_type_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(439, 105);
            this.Controls.Add(this.manage_btn);
            this.Controls.Add(this.spa_program_type_name);
            this.Controls.Add(this.spa_program_type_name_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "program_type_manage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MANAGE SPA PROGRAM TYPE";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.program_type_manage_FormClosed);
            this.Load += new System.EventHandler(this.program_type_manage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label spa_program_type_name_lbl;
        private System.Windows.Forms.TextBox spa_program_type_name;
        public System.Windows.Forms.Button manage_btn;
    }
}