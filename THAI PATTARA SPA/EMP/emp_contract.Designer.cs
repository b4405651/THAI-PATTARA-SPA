namespace SPA_MANAGEMENT_SYSTEM.EMP
{
    partial class emp_contract
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
            this.employee_code = new System.Windows.Forms.TextBox();
            this.emp_code_lbl = new System.Windows.Forms.Label();
            this.employee_name_lbl = new System.Windows.Forms.Label();
            this.line_sep = new SPA_MANAGEMENT_SYSTEM.line_sep();
            this.btn_dgv = new SPA_MANAGEMENT_SYSTEM.btn_dgv();
            this.SuspendLayout();
            // 
            // employee_code
            // 
            this.employee_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.employee_code.Location = new System.Drawing.Point(175, 6);
            this.employee_code.Name = "employee_code";
            this.employee_code.Size = new System.Drawing.Size(140, 24);
            this.employee_code.TabIndex = 1;
            this.employee_code.Tag = "barcode";
            this.employee_code.TextChanged += new System.EventHandler(this.employee_code_TextChanged);
            this.employee_code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.employee_code_KeyDown);
            // 
            // emp_code_lbl
            // 
            this.emp_code_lbl.AutoSize = true;
            this.emp_code_lbl.BackColor = System.Drawing.Color.Transparent;
            this.emp_code_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.emp_code_lbl.Location = new System.Drawing.Point(12, 9);
            this.emp_code_lbl.Name = "emp_code_lbl";
            this.emp_code_lbl.Size = new System.Drawing.Size(166, 18);
            this.emp_code_lbl.TabIndex = 36;
            this.emp_code_lbl.Text = "EMPLOYEE CODE : ";
            // 
            // employee_name_lbl
            // 
            this.employee_name_lbl.AutoSize = true;
            this.employee_name_lbl.BackColor = System.Drawing.Color.Transparent;
            this.employee_name_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.employee_name_lbl.Location = new System.Drawing.Point(324, 9);
            this.employee_name_lbl.Name = "employee_name_lbl";
            this.employee_name_lbl.Size = new System.Drawing.Size(165, 18);
            this.employee_name_lbl.TabIndex = 34;
            this.employee_name_lbl.Text = "EMPLOYEE NAME : ";
            // 
            // line_sep
            // 
            this.line_sep.BackColor = System.Drawing.Color.Transparent;
            this.line_sep.Location = new System.Drawing.Point(15, 42);
            this.line_sep.MaximumSize = new System.Drawing.Size(2000, 2);
            this.line_sep.MinimumSize = new System.Drawing.Size(0, 2);
            this.line_sep.Name = "line_sep";
            this.line_sep.Size = new System.Drawing.Size(350, 2);
            this.line_sep.TabIndex = 35;
            // 
            // btn_dgv
            // 
            this.btn_dgv.AutoSize = true;
            this.btn_dgv.BackColor = System.Drawing.Color.Transparent;
            this.btn_dgv.Location = new System.Drawing.Point(15, 50);
            this.btn_dgv.Name = "btn_dgv";
            this.btn_dgv.preventDGVSelectionChanged = false;
            this.btn_dgv.Size = new System.Drawing.Size(1349, 645);
            this.btn_dgv.TabIndex = 2;
            // 
            // emp_contract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(885, 261);
            this.ControlBox = false;
            this.Controls.Add(this.btn_dgv);
            this.Controls.Add(this.employee_code);
            this.Controls.Add(this.emp_code_lbl);
            this.Controls.Add(this.employee_name_lbl);
            this.Controls.Add(this.line_sep);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "emp_contract";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "emp_contract";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.doLoadGridData);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox employee_code;
        private System.Windows.Forms.Label emp_code_lbl;
        private System.Windows.Forms.Label employee_name_lbl;
        private line_sep line_sep;
        private btn_dgv btn_dgv;
    }
}