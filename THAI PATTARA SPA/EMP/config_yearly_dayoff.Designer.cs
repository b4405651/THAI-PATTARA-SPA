namespace SPA_MANAGEMENT_SYSTEM.EMP
{
    partial class config_yearly_dayoff
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
            this.year_lbl = new System.Windows.Forms.Label();
            this.year = new System.Windows.Forms.ComboBox();
            this.line_sep1 = new SPA_MANAGEMENT_SYSTEM.line_sep();
            this.btn_dgv = new SPA_MANAGEMENT_SYSTEM.btn_dgv();
            this.SuspendLayout();
            // 
            // year_lbl
            // 
            this.year_lbl.AutoSize = true;
            this.year_lbl.BackColor = System.Drawing.Color.Transparent;
            this.year_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.year_lbl.Location = new System.Drawing.Point(12, 9);
            this.year_lbl.Name = "year_lbl";
            this.year_lbl.Size = new System.Drawing.Size(66, 18);
            this.year_lbl.TabIndex = 24;
            this.year_lbl.Text = "YEAR : ";
            // 
            // year
            // 
            this.year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.year.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.year.FormattingEnabled = true;
            this.year.Location = new System.Drawing.Point(79, 7);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(99, 26);
            this.year.TabIndex = 1;
            // 
            // line_sep1
            // 
            this.line_sep1.BackColor = System.Drawing.Color.Transparent;
            this.line_sep1.Location = new System.Drawing.Point(12, 39);
            this.line_sep1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.line_sep1.MinimumSize = new System.Drawing.Size(0, 2);
            this.line_sep1.Name = "line_sep1";
            this.line_sep1.Size = new System.Drawing.Size(350, 2);
            this.line_sep1.TabIndex = 25;
            // 
            // btn_dgv
            // 
            this.btn_dgv.AutoSize = true;
            this.btn_dgv.BackColor = System.Drawing.Color.Transparent;
            this.btn_dgv.Location = new System.Drawing.Point(12, 47);
            this.btn_dgv.Name = "btn_dgv";
            this.btn_dgv.Size = new System.Drawing.Size(1349, 645);
            this.btn_dgv.TabIndex = 2;
            // 
            // config_yearly_dayoff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(885, 261);
            this.ControlBox = false;
            this.Controls.Add(this.btn_dgv);
            this.Controls.Add(this.line_sep1);
            this.Controls.Add(this.year_lbl);
            this.Controls.Add(this.year);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "config_yearly_dayoff";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "config_yearly_dayoff";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.doLoadGridData);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label year_lbl;
        public System.Windows.Forms.ComboBox year;
        private line_sep line_sep1;
        private btn_dgv btn_dgv;
    }
}