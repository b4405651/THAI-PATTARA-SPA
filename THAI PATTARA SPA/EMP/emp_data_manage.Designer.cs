namespace SPA_MANAGEMENT_SYSTEM.EMP
{
    partial class emp_data_manage
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
            this.fullname = new System.Windows.Forms.TextBox();
            this.year_lbl = new System.Windows.Forms.Label();
            this.emp_type_id = new System.Windows.Forms.ComboBox();
            this.emp_type_lbl = new System.Windows.Forms.Label();
            this.register_date_lbl = new System.Windows.Forms.Label();
            this.manage_btn = new System.Windows.Forms.Button();
            this.attachment_btn = new System.Windows.Forms.Button();
            this.register_date = new SPA_MANAGEMENT_SYSTEM.date_data();
            this.employee_code = new System.Windows.Forms.TextBox();
            this.emp_code_lbl = new System.Windows.Forms.Label();
            this.can_approve = new System.Windows.Forms.CheckBox();
            this.approve_code = new System.Windows.Forms.TextBox();
            this.approve_code_lbl = new System.Windows.Forms.Label();
            this.department = new System.Windows.Forms.ComboBox();
            this.department_lbl = new System.Windows.Forms.Label();
            this.nickname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fullname
            // 
            this.fullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.fullname.Location = new System.Drawing.Point(199, 5);
            this.fullname.Name = "fullname";
            this.fullname.Size = new System.Drawing.Size(185, 24);
            this.fullname.TabIndex = 1;
            // 
            // year_lbl
            // 
            this.year_lbl.AutoSize = true;
            this.year_lbl.BackColor = System.Drawing.Color.Transparent;
            this.year_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.year_lbl.Location = new System.Drawing.Point(12, 9);
            this.year_lbl.Name = "year_lbl";
            this.year_lbl.Size = new System.Drawing.Size(110, 18);
            this.year_lbl.TabIndex = 39;
            this.year_lbl.Text = "FULLNAME : ";
            // 
            // emp_type_id
            // 
            this.emp_type_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.emp_type_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.emp_type_id.FormattingEnabled = true;
            this.emp_type_id.Location = new System.Drawing.Point(199, 113);
            this.emp_type_id.Name = "emp_type_id";
            this.emp_type_id.Size = new System.Drawing.Size(132, 26);
            this.emp_type_id.TabIndex = 4;
            // 
            // emp_type_lbl
            // 
            this.emp_type_lbl.AutoSize = true;
            this.emp_type_lbl.BackColor = System.Drawing.Color.Transparent;
            this.emp_type_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.emp_type_lbl.Location = new System.Drawing.Point(12, 117);
            this.emp_type_lbl.Name = "emp_type_lbl";
            this.emp_type_lbl.Size = new System.Drawing.Size(65, 18);
            this.emp_type_lbl.TabIndex = 40;
            this.emp_type_lbl.Text = "TYPE : ";
            // 
            // register_date_lbl
            // 
            this.register_date_lbl.AutoSize = true;
            this.register_date_lbl.BackColor = System.Drawing.Color.Transparent;
            this.register_date_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.register_date_lbl.Location = new System.Drawing.Point(12, 144);
            this.register_date_lbl.Name = "register_date_lbl";
            this.register_date_lbl.Size = new System.Drawing.Size(155, 18);
            this.register_date_lbl.TabIndex = 45;
            this.register_date_lbl.Text = "REGISTER DATE : ";
            // 
            // manage_btn
            // 
            this.manage_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.manage_btn.FlatAppearance.BorderSize = 0;
            this.manage_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manage_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.manage_btn.Location = new System.Drawing.Point(289, 223);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(101, 59);
            this.manage_btn.TabIndex = 9;
            this.manage_btn.Text = "ADD";
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // attachment_btn
            // 
            this.attachment_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.attachment_btn.FlatAppearance.BorderSize = 0;
            this.attachment_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.attachment_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.attachment_btn.Location = new System.Drawing.Point(12, 223);
            this.attachment_btn.Name = "attachment_btn";
            this.attachment_btn.Size = new System.Drawing.Size(155, 59);
            this.attachment_btn.TabIndex = 8;
            this.attachment_btn.Text = "ATTACHMENT";
            this.attachment_btn.UseVisualStyleBackColor = false;
            this.attachment_btn.Visible = false;
            this.attachment_btn.Click += new System.EventHandler(this.attachment_Click);
            // 
            // register_date
            // 
            this.register_date.Location = new System.Drawing.Point(199, 141);
            this.register_date.Name = "register_date";
            this.register_date.Size = new System.Drawing.Size(94, 24);
            this.register_date.TabIndex = 5;
            // 
            // employee_code
            // 
            this.employee_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.employee_code.Location = new System.Drawing.Point(199, 87);
            this.employee_code.Name = "employee_code";
            this.employee_code.Size = new System.Drawing.Size(140, 24);
            this.employee_code.TabIndex = 3;
            this.employee_code.Tag = "barcode";
            // 
            // emp_code_lbl
            // 
            this.emp_code_lbl.AutoSize = true;
            this.emp_code_lbl.BackColor = System.Drawing.Color.Transparent;
            this.emp_code_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.emp_code_lbl.Location = new System.Drawing.Point(12, 90);
            this.emp_code_lbl.Name = "emp_code_lbl";
            this.emp_code_lbl.Size = new System.Drawing.Size(71, 18);
            this.emp_code_lbl.TabIndex = 53;
            this.emp_code_lbl.Text = "CODE : ";
            // 
            // can_approve
            // 
            this.can_approve.AutoSize = true;
            this.can_approve.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.can_approve.Location = new System.Drawing.Point(199, 171);
            this.can_approve.Name = "can_approve";
            this.can_approve.Size = new System.Drawing.Size(158, 22);
            this.can_approve.TabIndex = 6;
            this.can_approve.Text = "CAN APPROVE ?";
            this.can_approve.UseVisualStyleBackColor = true;
            this.can_approve.CheckedChanged += new System.EventHandler(this.can_approve_CheckedChanged);
            // 
            // approve_code
            // 
            this.approve_code.Enabled = false;
            this.approve_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.approve_code.Location = new System.Drawing.Point(199, 194);
            this.approve_code.Name = "approve_code";
            this.approve_code.PasswordChar = '*';
            this.approve_code.Size = new System.Drawing.Size(140, 24);
            this.approve_code.TabIndex = 7;
            this.approve_code.Tag = "";
            // 
            // approve_code_lbl
            // 
            this.approve_code_lbl.AutoSize = true;
            this.approve_code_lbl.BackColor = System.Drawing.Color.Transparent;
            this.approve_code_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.approve_code_lbl.Location = new System.Drawing.Point(12, 197);
            this.approve_code_lbl.Name = "approve_code_lbl";
            this.approve_code_lbl.Size = new System.Drawing.Size(154, 18);
            this.approve_code_lbl.TabIndex = 56;
            this.approve_code_lbl.Text = "APPROVE CODE : ";
            // 
            // department
            // 
            this.department.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.department.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.department.FormattingEnabled = true;
            this.department.Location = new System.Drawing.Point(199, 59);
            this.department.Name = "department";
            this.department.Size = new System.Drawing.Size(185, 26);
            this.department.TabIndex = 2;
            this.department.SelectedIndexChanged += new System.EventHandler(this.department_SelectedIndexChanged);
            // 
            // department_lbl
            // 
            this.department_lbl.AutoSize = true;
            this.department_lbl.BackColor = System.Drawing.Color.Transparent;
            this.department_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.department_lbl.Location = new System.Drawing.Point(12, 63);
            this.department_lbl.Name = "department_lbl";
            this.department_lbl.Size = new System.Drawing.Size(136, 18);
            this.department_lbl.TabIndex = 58;
            this.department_lbl.Text = "DEPARTMENT : ";
            // 
            // nickname
            // 
            this.nickname.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.nickname.Location = new System.Drawing.Point(199, 32);
            this.nickname.Name = "nickname";
            this.nickname.Size = new System.Drawing.Size(185, 24);
            this.nickname.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 18);
            this.label1.TabIndex = 60;
            this.label1.Text = "NICKNAME : ";
            // 
            // emp_data_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(402, 292);
            this.Controls.Add(this.nickname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.department);
            this.Controls.Add(this.department_lbl);
            this.Controls.Add(this.approve_code);
            this.Controls.Add(this.approve_code_lbl);
            this.Controls.Add(this.can_approve);
            this.Controls.Add(this.employee_code);
            this.Controls.Add(this.emp_code_lbl);
            this.Controls.Add(this.register_date);
            this.Controls.Add(this.attachment_btn);
            this.Controls.Add(this.manage_btn);
            this.Controls.Add(this.register_date_lbl);
            this.Controls.Add(this.emp_type_id);
            this.Controls.Add(this.emp_type_lbl);
            this.Controls.Add(this.fullname);
            this.Controls.Add(this.year_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "emp_data_manage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MANAGE EMPLOYEE DATA";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.emp_data_manage_FormClosed);
            this.Load += new System.EventHandler(this.emp_data_manage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fullname;
        private System.Windows.Forms.Label year_lbl;
        private System.Windows.Forms.ComboBox emp_type_id;
        private System.Windows.Forms.Label emp_type_lbl;
        private System.Windows.Forms.Label register_date_lbl;
        public System.Windows.Forms.Button manage_btn;
        public System.Windows.Forms.Button attachment_btn;
        private date_data register_date;
        private System.Windows.Forms.TextBox employee_code;
        private System.Windows.Forms.Label emp_code_lbl;
        private System.Windows.Forms.CheckBox can_approve;
        private System.Windows.Forms.TextBox approve_code;
        private System.Windows.Forms.Label approve_code_lbl;
        private System.Windows.Forms.ComboBox department;
        private System.Windows.Forms.Label department_lbl;
        private System.Windows.Forms.TextBox nickname;
        private System.Windows.Forms.Label label1;
    }
}