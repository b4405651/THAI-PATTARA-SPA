namespace SPA_MANAGEMENT_SYSTEM.EMP
{
    partial class emp_data_resign
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
            this.resign_date_lbl = new System.Windows.Forms.Label();
            this.save_btn = new System.Windows.Forms.Button();
            this.resign_date = new SPA_MANAGEMENT_SYSTEM.date_data();
            this.SuspendLayout();
            // 
            // resign_date_lbl
            // 
            this.resign_date_lbl.AutoSize = true;
            this.resign_date_lbl.BackColor = System.Drawing.Color.Transparent;
            this.resign_date_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.resign_date_lbl.Location = new System.Drawing.Point(12, 9);
            this.resign_date_lbl.Name = "resign_date_lbl";
            this.resign_date_lbl.Size = new System.Drawing.Size(134, 18);
            this.resign_date_lbl.TabIndex = 47;
            this.resign_date_lbl.Text = "RESIGN DATE : ";
            // 
            // save_btn
            // 
            this.save_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.save_btn.FlatAppearance.BorderSize = 0;
            this.save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.save_btn.Location = new System.Drawing.Point(139, 36);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(101, 59);
            this.save_btn.TabIndex = 2;
            this.save_btn.Text = "SAVE";
            this.save_btn.UseVisualStyleBackColor = false;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // resign_date
            // 
            this.resign_date.Location = new System.Drawing.Point(143, 6);
            this.resign_date.Name = "resign_date";
            this.resign_date.Size = new System.Drawing.Size(94, 24);
            this.resign_date.TabIndex = 1;
            // 
            // emp_data_resign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(252, 104);
            this.Controls.Add(this.resign_date);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.resign_date_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "emp_data_resign";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EMPLOYEE RESIGN";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.emp_data_resign_FormClosed);
            this.Load += new System.EventHandler(this.emp_data_resign_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label resign_date_lbl;
        public System.Windows.Forms.Button save_btn;
        private date_data resign_date;
    }
}