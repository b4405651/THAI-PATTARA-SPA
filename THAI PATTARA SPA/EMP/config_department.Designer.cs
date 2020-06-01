namespace SPA_MANAGEMENT_SYSTEM.EMP
{
    partial class config_department
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
            this.department_name_lbl = new System.Windows.Forms.Label();
            this.department_name = new System.Windows.Forms.TextBox();
            this.btn_dgv = new SPA_MANAGEMENT_SYSTEM.btn_dgv();
            this.line_sep1 = new SPA_MANAGEMENT_SYSTEM.line_sep();
            this.view = new System.Windows.Forms.ComboBox();
            this.view_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // department_name_lbl
            // 
            this.department_name_lbl.AutoSize = true;
            this.department_name_lbl.BackColor = System.Drawing.Color.Transparent;
            this.department_name_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.department_name_lbl.Location = new System.Drawing.Point(12, 9);
            this.department_name_lbl.Name = "department_name_lbl";
            this.department_name_lbl.Size = new System.Drawing.Size(188, 18);
            this.department_name_lbl.TabIndex = 26;
            this.department_name_lbl.Text = "DEPARTMENT NAME : ";
            // 
            // department_name
            // 
            this.department_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.department_name.Location = new System.Drawing.Point(198, 6);
            this.department_name.Name = "department_name";
            this.department_name.Size = new System.Drawing.Size(149, 24);
            this.department_name.TabIndex = 1;
            // 
            // btn_dgv
            // 
            this.btn_dgv.AutoSize = true;
            this.btn_dgv.BackColor = System.Drawing.Color.Transparent;
            this.btn_dgv.Location = new System.Drawing.Point(15, 47);
            this.btn_dgv.Name = "btn_dgv";
            this.btn_dgv.preventDGVSelectionChanged = false;
            this.btn_dgv.Size = new System.Drawing.Size(1903, 645);
            this.btn_dgv.TabIndex = 2;
            // 
            // line_sep1
            // 
            this.line_sep1.BackColor = System.Drawing.Color.Transparent;
            this.line_sep1.Location = new System.Drawing.Point(15, 39);
            this.line_sep1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.line_sep1.MinimumSize = new System.Drawing.Size(0, 2);
            this.line_sep1.Name = "line_sep1";
            this.line_sep1.Size = new System.Drawing.Size(350, 2);
            this.line_sep1.TabIndex = 27;
            // 
            // view
            // 
            this.view.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.view.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.view.FormattingEnabled = true;
            this.view.Location = new System.Drawing.Point(451, 5);
            this.view.Name = "view";
            this.view.Size = new System.Drawing.Size(124, 26);
            this.view.TabIndex = 28;
            // 
            // view_lbl
            // 
            this.view_lbl.AutoSize = true;
            this.view_lbl.BackColor = System.Drawing.Color.Transparent;
            this.view_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.view_lbl.Location = new System.Drawing.Point(367, 9);
            this.view_lbl.Name = "view_lbl";
            this.view_lbl.Size = new System.Drawing.Size(87, 18);
            this.view_lbl.TabIndex = 29;
            this.view_lbl.Text = "STATUS : ";
            // 
            // config_department
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(885, 261);
            this.ControlBox = false;
            this.Controls.Add(this.view);
            this.Controls.Add(this.view_lbl);
            this.Controls.Add(this.btn_dgv);
            this.Controls.Add(this.department_name);
            this.Controls.Add(this.line_sep1);
            this.Controls.Add(this.department_name_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "config_department";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "config_department";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.doLoadGridData);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private line_sep line_sep1;
        private System.Windows.Forms.Label department_name_lbl;
        private System.Windows.Forms.TextBox department_name;
        private btn_dgv btn_dgv;
        private System.Windows.Forms.ComboBox view;
        private System.Windows.Forms.Label view_lbl;
    }
}