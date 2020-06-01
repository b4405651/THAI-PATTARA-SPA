namespace SPA_MANAGEMENT_SYSTEM.EMP
{
    partial class emp_data
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
            this.status = new System.Windows.Forms.ComboBox();
            this.emp_code_lbl = new System.Windows.Forms.Label();
            this.status_lbl = new System.Windows.Forms.Label();
            this.emp_type_id = new System.Windows.Forms.ComboBox();
            this.emp_type_lbl = new System.Windows.Forms.Label();
            this.btn_dgv = new SPA_MANAGEMENT_SYSTEM.btn_dgv();
            this.line_sep1 = new SPA_MANAGEMENT_SYSTEM.line_sep();
            this.fullname = new System.Windows.Forms.TextBox();
            this.fullname_lbl = new System.Windows.Forms.Label();
            this.department = new System.Windows.Forms.ComboBox();
            this.department_lbl = new System.Windows.Forms.Label();
            this.nickname = new System.Windows.Forms.TextBox();
            this.nickname_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // employee_code
            // 
            this.employee_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.employee_code.Location = new System.Drawing.Point(173, 7);
            this.employee_code.Name = "employee_code";
            this.employee_code.Size = new System.Drawing.Size(140, 24);
            this.employee_code.TabIndex = 1;
            this.employee_code.Tag = "barcode";
            this.employee_code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fullname_KeyDown);
            // 
            // status
            // 
            this.status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.status.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.status.FormattingEnabled = true;
            this.status.Location = new System.Drawing.Point(402, 33);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(124, 26);
            this.status.TabIndex = 5;
            // 
            // emp_code_lbl
            // 
            this.emp_code_lbl.AutoSize = true;
            this.emp_code_lbl.BackColor = System.Drawing.Color.Transparent;
            this.emp_code_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.emp_code_lbl.Location = new System.Drawing.Point(12, 8);
            this.emp_code_lbl.Name = "emp_code_lbl";
            this.emp_code_lbl.Size = new System.Drawing.Size(166, 18);
            this.emp_code_lbl.TabIndex = 18;
            this.emp_code_lbl.Text = "EMPLOYEE CODE : ";
            // 
            // status_lbl
            // 
            this.status_lbl.AutoSize = true;
            this.status_lbl.BackColor = System.Drawing.Color.Transparent;
            this.status_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.status_lbl.Location = new System.Drawing.Point(319, 37);
            this.status_lbl.Name = "status_lbl";
            this.status_lbl.Size = new System.Drawing.Size(87, 18);
            this.status_lbl.TabIndex = 19;
            this.status_lbl.Text = "STATUS : ";
            // 
            // emp_type_id
            // 
            this.emp_type_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.emp_type_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.emp_type_id.FormattingEnabled = true;
            this.emp_type_id.Location = new System.Drawing.Point(173, 33);
            this.emp_type_id.Name = "emp_type_id";
            this.emp_type_id.Size = new System.Drawing.Size(132, 26);
            this.emp_type_id.TabIndex = 4;
            // 
            // emp_type_lbl
            // 
            this.emp_type_lbl.AutoSize = true;
            this.emp_type_lbl.BackColor = System.Drawing.Color.Transparent;
            this.emp_type_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.emp_type_lbl.Location = new System.Drawing.Point(12, 37);
            this.emp_type_lbl.Name = "emp_type_lbl";
            this.emp_type_lbl.Size = new System.Drawing.Size(160, 18);
            this.emp_type_lbl.TabIndex = 22;
            this.emp_type_lbl.Text = "EMPLOYEE TYPE : ";
            // 
            // btn_dgv
            // 
            this.btn_dgv.AutoSize = true;
            this.btn_dgv.BackColor = System.Drawing.Color.Transparent;
            this.btn_dgv.Location = new System.Drawing.Point(15, 86);
            this.btn_dgv.Name = "btn_dgv";
            this.btn_dgv.preventDGVSelectionChanged = false;
            this.btn_dgv.Size = new System.Drawing.Size(1349, 645);
            this.btn_dgv.TabIndex = 6;
            // 
            // line_sep1
            // 
            this.line_sep1.BackColor = System.Drawing.Color.Transparent;
            this.line_sep1.Location = new System.Drawing.Point(15, 72);
            this.line_sep1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.line_sep1.MinimumSize = new System.Drawing.Size(0, 2);
            this.line_sep1.Name = "line_sep1";
            this.line_sep1.Size = new System.Drawing.Size(350, 2);
            this.line_sep1.TabIndex = 24;
            // 
            // fullname
            // 
            this.fullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.fullname.Location = new System.Drawing.Point(480, 7);
            this.fullname.Name = "fullname";
            this.fullname.Size = new System.Drawing.Size(140, 24);
            this.fullname.TabIndex = 2;
            this.fullname.Tag = "";
            // 
            // fullname_lbl
            // 
            this.fullname_lbl.AutoSize = true;
            this.fullname_lbl.BackColor = System.Drawing.Color.Transparent;
            this.fullname_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.fullname_lbl.Location = new System.Drawing.Point(319, 8);
            this.fullname_lbl.Name = "fullname_lbl";
            this.fullname_lbl.Size = new System.Drawing.Size(165, 18);
            this.fullname_lbl.TabIndex = 26;
            this.fullname_lbl.Text = "EMPLOYEE NAME : ";
            // 
            // department
            // 
            this.department.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.department.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.department.FormattingEnabled = true;
            this.department.Location = new System.Drawing.Point(679, 33);
            this.department.Name = "department";
            this.department.Size = new System.Drawing.Size(132, 26);
            this.department.TabIndex = 3;
            // 
            // department_lbl
            // 
            this.department_lbl.AutoSize = true;
            this.department_lbl.BackColor = System.Drawing.Color.Transparent;
            this.department_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.department_lbl.Location = new System.Drawing.Point(544, 37);
            this.department_lbl.Name = "department_lbl";
            this.department_lbl.Size = new System.Drawing.Size(136, 18);
            this.department_lbl.TabIndex = 28;
            this.department_lbl.Text = "DEPARTMENT : ";
            // 
            // nickname
            // 
            this.nickname.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.nickname.Location = new System.Drawing.Point(741, 7);
            this.nickname.Name = "nickname";
            this.nickname.Size = new System.Drawing.Size(140, 24);
            this.nickname.TabIndex = 29;
            this.nickname.Tag = "";
            // 
            // nickname_lbl
            // 
            this.nickname_lbl.AutoSize = true;
            this.nickname_lbl.BackColor = System.Drawing.Color.Transparent;
            this.nickname_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.nickname_lbl.Location = new System.Drawing.Point(626, 10);
            this.nickname_lbl.Name = "nickname_lbl";
            this.nickname_lbl.Size = new System.Drawing.Size(109, 18);
            this.nickname_lbl.TabIndex = 30;
            this.nickname_lbl.Text = "NICKNAME : ";
            // 
            // emp_data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(1051, 261);
            this.ControlBox = false;
            this.Controls.Add(this.nickname);
            this.Controls.Add(this.nickname_lbl);
            this.Controls.Add(this.department);
            this.Controls.Add(this.department_lbl);
            this.Controls.Add(this.fullname);
            this.Controls.Add(this.fullname_lbl);
            this.Controls.Add(this.btn_dgv);
            this.Controls.Add(this.line_sep1);
            this.Controls.Add(this.emp_type_id);
            this.Controls.Add(this.emp_type_lbl);
            this.Controls.Add(this.employee_code);
            this.Controls.Add(this.status);
            this.Controls.Add(this.emp_code_lbl);
            this.Controls.Add(this.status_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "emp_data";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "emp_data";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.doLoadGridData);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox employee_code;
        private System.Windows.Forms.ComboBox status;
        private System.Windows.Forms.Label emp_code_lbl;
        private System.Windows.Forms.Label status_lbl;
        private System.Windows.Forms.ComboBox emp_type_id;
        private System.Windows.Forms.Label emp_type_lbl;
        private line_sep line_sep1;
        private btn_dgv btn_dgv;
        private System.Windows.Forms.TextBox fullname;
        private System.Windows.Forms.Label fullname_lbl;
        private System.Windows.Forms.ComboBox department;
        private System.Windows.Forms.Label department_lbl;
        private System.Windows.Forms.TextBox nickname;
        private System.Windows.Forms.Label nickname_lbl;
    }
}