namespace SPA_MANAGEMENT_SYSTEM.SPA
{
    partial class program
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
            this.program_name = new System.Windows.Forms.TextBox();
            this.program_name_lbl = new System.Windows.Forms.Label();
            this.line_sep = new SPA_MANAGEMENT_SYSTEM.line_sep();
            this.btn_dgv = new SPA_MANAGEMENT_SYSTEM.btn_dgv();
            this.show_disabled = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // program_name
            // 
            this.program_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.program_name.Location = new System.Drawing.Point(173, 8);
            this.program_name.Name = "program_name";
            this.program_name.Size = new System.Drawing.Size(232, 24);
            this.program_name.TabIndex = 27;
            this.program_name.Tag = "";
            this.program_name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.program_name_KeyDown);
            // 
            // program_name_lbl
            // 
            this.program_name_lbl.AutoSize = true;
            this.program_name_lbl.BackColor = System.Drawing.Color.Transparent;
            this.program_name_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.program_name_lbl.Location = new System.Drawing.Point(12, 9);
            this.program_name_lbl.Name = "program_name_lbl";
            this.program_name_lbl.Size = new System.Drawing.Size(160, 18);
            this.program_name_lbl.TabIndex = 28;
            this.program_name_lbl.Text = "PROGRAM NAME : ";
            // 
            // line_sep
            // 
            this.line_sep.BackColor = System.Drawing.Color.Transparent;
            this.line_sep.Location = new System.Drawing.Point(15, 38);
            this.line_sep.MaximumSize = new System.Drawing.Size(2000, 2);
            this.line_sep.MinimumSize = new System.Drawing.Size(0, 2);
            this.line_sep.Name = "line_sep";
            this.line_sep.Size = new System.Drawing.Size(350, 2);
            this.line_sep.TabIndex = 29;
            // 
            // btn_dgv
            // 
            this.btn_dgv.AutoSize = true;
            this.btn_dgv.BackColor = System.Drawing.Color.Transparent;
            this.btn_dgv.Location = new System.Drawing.Point(15, 46);
            this.btn_dgv.Name = "btn_dgv";
            this.btn_dgv.preventDGVSelectionChanged = false;
            this.btn_dgv.Size = new System.Drawing.Size(1423, 645);
            this.btn_dgv.TabIndex = 30;
            // 
            // show_disabled
            // 
            this.show_disabled.AutoSize = true;
            this.show_disabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.show_disabled.Location = new System.Drawing.Point(422, 8);
            this.show_disabled.Name = "show_disabled";
            this.show_disabled.Size = new System.Drawing.Size(164, 22);
            this.show_disabled.TabIndex = 31;
            this.show_disabled.Text = "SHOW DISABLED";
            this.show_disabled.UseVisualStyleBackColor = true;
            this.show_disabled.CheckedChanged += new System.EventHandler(this.doLoadGridData);
            // 
            // program
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(696, 566);
            this.ControlBox = false;
            this.Controls.Add(this.show_disabled);
            this.Controls.Add(this.btn_dgv);
            this.Controls.Add(this.line_sep);
            this.Controls.Add(this.program_name);
            this.Controls.Add(this.program_name_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "program";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "program_single";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.doLoadGridData);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox program_name;
        private System.Windows.Forms.Label program_name_lbl;
        private line_sep line_sep;
        private btn_dgv btn_dgv;
        private System.Windows.Forms.CheckBox show_disabled;
    }
}