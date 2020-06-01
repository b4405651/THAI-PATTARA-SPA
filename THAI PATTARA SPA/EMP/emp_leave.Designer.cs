namespace SPA_MANAGEMENT_SYSTEM.EMP
{
    partial class emp_leave
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
            this.employee_name_lbl = new System.Windows.Forms.Label();
            this.since_lbl = new System.Windows.Forms.Label();
            this.to_lbl = new System.Windows.Forms.Label();
            this.employee_code = new System.Windows.Forms.TextBox();
            this.emp_code_lbl = new System.Windows.Forms.Label();
            this.to = new SPA_MANAGEMENT_SYSTEM.date_data();
            this.since = new SPA_MANAGEMENT_SYSTEM.date_data();
            this.btn_dgv = new SPA_MANAGEMENT_SYSTEM.btn_dgv();
            this.line_sep = new SPA_MANAGEMENT_SYSTEM.line_sep();
            this.SuspendLayout();
            // 
            // employee_name_lbl
            // 
            this.employee_name_lbl.AutoSize = true;
            this.employee_name_lbl.BackColor = System.Drawing.Color.Transparent;
            this.employee_name_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.employee_name_lbl.Location = new System.Drawing.Point(323, 9);
            this.employee_name_lbl.Name = "employee_name_lbl";
            this.employee_name_lbl.Size = new System.Drawing.Size(165, 18);
            this.employee_name_lbl.TabIndex = 19;
            this.employee_name_lbl.Text = "EMPLOYEE NAME : ";
            // 
            // since_lbl
            // 
            this.since_lbl.AutoSize = true;
            this.since_lbl.BackColor = System.Drawing.Color.Transparent;
            this.since_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.since_lbl.Location = new System.Drawing.Point(12, 38);
            this.since_lbl.Name = "since_lbl";
            this.since_lbl.Size = new System.Drawing.Size(73, 18);
            this.since_lbl.TabIndex = 23;
            this.since_lbl.Text = "SINCE : ";
            // 
            // to_lbl
            // 
            this.to_lbl.AutoSize = true;
            this.to_lbl.BackColor = System.Drawing.Color.Transparent;
            this.to_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.to_lbl.Location = new System.Drawing.Point(183, 38);
            this.to_lbl.Name = "to_lbl";
            this.to_lbl.Size = new System.Drawing.Size(46, 18);
            this.to_lbl.TabIndex = 25;
            this.to_lbl.Text = "TO : ";
            // 
            // employee_code
            // 
            this.employee_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.employee_code.Location = new System.Drawing.Point(173, 8);
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
            this.emp_code_lbl.TabIndex = 30;
            this.emp_code_lbl.Text = "EMPLOYEE CODE : ";
            // 
            // to
            // 
            this.to.Location = new System.Drawing.Point(225, 35);
            this.to.Name = "to";
            this.to.Size = new System.Drawing.Size(94, 24);
            this.to.TabIndex = 4;
            // 
            // since
            // 
            this.since.Location = new System.Drawing.Point(82, 35);
            this.since.Name = "since";
            this.since.Size = new System.Drawing.Size(94, 24);
            this.since.TabIndex = 3;
            // 
            // btn_dgv
            // 
            this.btn_dgv.AutoSize = true;
            this.btn_dgv.BackColor = System.Drawing.Color.Transparent;
            this.btn_dgv.Location = new System.Drawing.Point(15, 87);
            this.btn_dgv.Name = "btn_dgv";
            this.btn_dgv.preventDGVSelectionChanged = false;
            this.btn_dgv.Size = new System.Drawing.Size(1349, 645);
            this.btn_dgv.TabIndex = 5;
            this.btn_dgv.Load += new System.EventHandler(this.doLoadGridData);
            // 
            // line_sep
            // 
            this.line_sep.BackColor = System.Drawing.Color.Transparent;
            this.line_sep.Location = new System.Drawing.Point(15, 76);
            this.line_sep.MaximumSize = new System.Drawing.Size(2000, 2);
            this.line_sep.MinimumSize = new System.Drawing.Size(0, 2);
            this.line_sep.Name = "line_sep";
            this.line_sep.Size = new System.Drawing.Size(350, 2);
            this.line_sep.TabIndex = 21;
            // 
            // emp_leave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(1140, 314);
            this.ControlBox = false;
            this.Controls.Add(this.employee_code);
            this.Controls.Add(this.emp_code_lbl);
            this.Controls.Add(this.to);
            this.Controls.Add(this.since);
            this.Controls.Add(this.btn_dgv);
            this.Controls.Add(this.line_sep);
            this.Controls.Add(this.employee_name_lbl);
            this.Controls.Add(this.to_lbl);
            this.Controls.Add(this.since_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "emp_leave";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "emp_leave";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label employee_name_lbl;
        private line_sep line_sep;
        private btn_dgv btn_dgv;
        private System.Windows.Forms.Label since_lbl;
        private System.Windows.Forms.Label to_lbl;
        private date_data since;
        private date_data to;
        private System.Windows.Forms.TextBox employee_code;
        private System.Windows.Forms.Label emp_code_lbl;

    }
}