namespace SPA_MANAGEMENT_SYSTEM.SPA
{
    partial class program_type
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
            this.btn_dgv = new SPA_MANAGEMENT_SYSTEM.btn_dgv();
            this.spa_program_type_lbl = new System.Windows.Forms.Label();
            this.line_sep1 = new SPA_MANAGEMENT_SYSTEM.line_sep();
            this.spa_program_type_name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_dgv
            // 
            this.btn_dgv.AutoSize = true;
            this.btn_dgv.BackColor = System.Drawing.Color.Transparent;
            this.btn_dgv.Location = new System.Drawing.Point(12, 55);
            this.btn_dgv.Name = "btn_dgv";
            this.btn_dgv.preventDGVSelectionChanged = false;
            this.btn_dgv.Size = new System.Drawing.Size(1349, 645);
            this.btn_dgv.TabIndex = 3;
            // 
            // spa_program_type_lbl
            // 
            this.spa_program_type_lbl.AutoSize = true;
            this.spa_program_type_lbl.BackColor = System.Drawing.Color.Transparent;
            this.spa_program_type_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.spa_program_type_lbl.Location = new System.Drawing.Point(9, 9);
            this.spa_program_type_lbl.Name = "spa_program_type_lbl";
            this.spa_program_type_lbl.Size = new System.Drawing.Size(192, 18);
            this.spa_program_type_lbl.TabIndex = 1;
            this.spa_program_type_lbl.Text = "SPA PROGRAM TYPE : ";
            // 
            // line_sep1
            // 
            this.line_sep1.BackColor = System.Drawing.Color.Transparent;
            this.line_sep1.Location = new System.Drawing.Point(12, 40);
            this.line_sep1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.line_sep1.MinimumSize = new System.Drawing.Size(0, 2);
            this.line_sep1.Name = "line_sep1";
            this.line_sep1.Size = new System.Drawing.Size(350, 2);
            this.line_sep1.TabIndex = 15;
            // 
            // spa_program_type_name
            // 
            this.spa_program_type_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.spa_program_type_name.Location = new System.Drawing.Point(199, 6);
            this.spa_program_type_name.Name = "spa_program_type_name";
            this.spa_program_type_name.Size = new System.Drawing.Size(178, 24);
            this.spa_program_type_name.TabIndex = 1;
            // 
            // program_type
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(885, 261);
            this.ControlBox = false;
            this.Controls.Add(this.spa_program_type_name);
            this.Controls.Add(this.spa_program_type_lbl);
            this.Controls.Add(this.line_sep1);
            this.Controls.Add(this.btn_dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "program_type";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "program_type";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.doLoadGridData);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private btn_dgv btn_dgv;
        private System.Windows.Forms.Label spa_program_type_lbl;
        private line_sep line_sep1;
        private System.Windows.Forms.TextBox spa_program_type_name;
    }
}