namespace SPA_MANAGEMENT_SYSTEM.CUSTOMER
{
    partial class customer_manage
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
            this.customer_name = new System.Windows.Forms.TextBox();
            this.customer_name_lbl = new System.Windows.Forms.Label();
            this.code_lbl = new System.Windows.Forms.Label();
            this.code = new System.Windows.Forms.Label();
            this.tel = new System.Windows.Forms.TextBox();
            this.tel_lbl = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.TextBox();
            this.email_lbl = new System.Windows.Forms.Label();
            this.wedding_anniversary_lbl = new System.Windows.Forms.Label();
            this.wedding_anniversary = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.manage_btn = new System.Windows.Forms.Button();
            this.birthday_lbl = new System.Windows.Forms.Label();
            this.birthday = new SPA_MANAGEMENT_SYSTEM.date_data();
            this.gender = new System.Windows.Forms.ComboBox();
            this.gender_lbl = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.note = new System.Windows.Forms.TextBox();
            this.history_btn = new System.Windows.Forms.Button();
            this.membercard_btn = new System.Windows.Forms.Button();
            this.rus_name = new System.Windows.Forms.TextBox();
            this.russian_name_lbl = new System.Windows.Forms.Label();
            this.is_neighbor = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // customer_name
            // 
            this.customer_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.customer_name.Location = new System.Drawing.Point(230, 32);
            this.customer_name.Name = "customer_name";
            this.customer_name.Size = new System.Drawing.Size(178, 24);
            this.customer_name.TabIndex = 1;
            // 
            // customer_name_lbl
            // 
            this.customer_name_lbl.AutoSize = true;
            this.customer_name_lbl.BackColor = System.Drawing.Color.Transparent;
            this.customer_name_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.customer_name_lbl.Location = new System.Drawing.Point(12, 35);
            this.customer_name_lbl.Name = "customer_name_lbl";
            this.customer_name_lbl.Size = new System.Drawing.Size(170, 18);
            this.customer_name_lbl.TabIndex = 6;
            this.customer_name_lbl.Text = "CUSTOMER NAME : ";
            // 
            // code_lbl
            // 
            this.code_lbl.AutoSize = true;
            this.code_lbl.BackColor = System.Drawing.Color.Transparent;
            this.code_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.code_lbl.Location = new System.Drawing.Point(12, 9);
            this.code_lbl.Name = "code_lbl";
            this.code_lbl.Size = new System.Drawing.Size(71, 18);
            this.code_lbl.TabIndex = 8;
            this.code_lbl.Text = "CODE : ";
            // 
            // code
            // 
            this.code.AutoSize = true;
            this.code.BackColor = System.Drawing.Color.Transparent;
            this.code.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.code.Location = new System.Drawing.Point(230, 9);
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(178, 18);
            this.code.TabIndex = 9;
            this.code.Text = "- CUSTOMER CODE -";
            // 
            // tel
            // 
            this.tel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tel.Location = new System.Drawing.Point(230, 116);
            this.tel.Name = "tel";
            this.tel.Size = new System.Drawing.Size(178, 24);
            this.tel.TabIndex = 4;
            this.tel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tel_KeyPress);
            // 
            // tel_lbl
            // 
            this.tel_lbl.AutoSize = true;
            this.tel_lbl.BackColor = System.Drawing.Color.Transparent;
            this.tel_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tel_lbl.Location = new System.Drawing.Point(12, 119);
            this.tel_lbl.Name = "tel_lbl";
            this.tel_lbl.Size = new System.Drawing.Size(159, 18);
            this.tel_lbl.TabIndex = 11;
            this.tel_lbl.Text = "PHONE NUMBER : ";
            // 
            // email
            // 
            this.email.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.email.Location = new System.Drawing.Point(230, 143);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(178, 24);
            this.email.TabIndex = 5;
            // 
            // email_lbl
            // 
            this.email_lbl.AutoSize = true;
            this.email_lbl.BackColor = System.Drawing.Color.Transparent;
            this.email_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.email_lbl.Location = new System.Drawing.Point(12, 146);
            this.email_lbl.Name = "email_lbl";
            this.email_lbl.Size = new System.Drawing.Size(77, 18);
            this.email_lbl.TabIndex = 13;
            this.email_lbl.Text = "E-MAIL : ";
            // 
            // wedding_anniversary_lbl
            // 
            this.wedding_anniversary_lbl.AutoSize = true;
            this.wedding_anniversary_lbl.BackColor = System.Drawing.Color.Transparent;
            this.wedding_anniversary_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.wedding_anniversary_lbl.Location = new System.Drawing.Point(12, 198);
            this.wedding_anniversary_lbl.Name = "wedding_anniversary_lbl";
            this.wedding_anniversary_lbl.Size = new System.Drawing.Size(222, 18);
            this.wedding_anniversary_lbl.TabIndex = 47;
            this.wedding_anniversary_lbl.Text = "WEDDING ANNIVERSARY : ";
            // 
            // wedding_anniversary
            // 
            this.wedding_anniversary.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.wedding_anniversary.Location = new System.Drawing.Point(230, 195);
            this.wedding_anniversary.Mask = "00/00";
            this.wedding_anniversary.Name = "wedding_anniversary";
            this.wedding_anniversary.Size = new System.Drawing.Size(53, 24);
            this.wedding_anniversary.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(289, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 18);
            this.label1.TabIndex = 49;
            this.label1.Text = "( MM / DD )";
            // 
            // cancel_btn
            // 
            this.cancel_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.cancel_btn.CausesValidation = false;
            this.cancel_btn.FlatAppearance.BorderSize = 0;
            this.cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cancel_btn.Location = new System.Drawing.Point(701, 233);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(101, 59);
            this.cancel_btn.TabIndex = 12;
            this.cancel_btn.Text = "CANCEL";
            this.cancel_btn.UseVisualStyleBackColor = false;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // manage_btn
            // 
            this.manage_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.manage_btn.FlatAppearance.BorderSize = 0;
            this.manage_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manage_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.manage_btn.Location = new System.Drawing.Point(594, 233);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(101, 59);
            this.manage_btn.TabIndex = 11;
            this.manage_btn.Text = "ADD";
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // birthday_lbl
            // 
            this.birthday_lbl.AutoSize = true;
            this.birthday_lbl.BackColor = System.Drawing.Color.Transparent;
            this.birthday_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.birthday_lbl.Location = new System.Drawing.Point(12, 172);
            this.birthday_lbl.Name = "birthday_lbl";
            this.birthday_lbl.Size = new System.Drawing.Size(104, 18);
            this.birthday_lbl.TabIndex = 50;
            this.birthday_lbl.Text = "BIRTHDAY : ";
            // 
            // birthday
            // 
            this.birthday.Location = new System.Drawing.Point(230, 169);
            this.birthday.Name = "birthday";
            this.birthday.Size = new System.Drawing.Size(94, 24);
            this.birthday.TabIndex = 6;
            // 
            // gender
            // 
            this.gender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gender.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gender.FormattingEnabled = true;
            this.gender.ItemHeight = 18;
            this.gender.Location = new System.Drawing.Point(230, 87);
            this.gender.Name = "gender";
            this.gender.Size = new System.Drawing.Size(104, 26);
            this.gender.TabIndex = 3;
            // 
            // gender_lbl
            // 
            this.gender_lbl.AutoSize = true;
            this.gender_lbl.BackColor = System.Drawing.Color.Transparent;
            this.gender_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gender_lbl.Location = new System.Drawing.Point(12, 92);
            this.gender_lbl.Name = "gender_lbl";
            this.gender_lbl.Size = new System.Drawing.Size(94, 18);
            this.gender_lbl.TabIndex = 103;
            this.gender_lbl.Text = "GENDER : ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.note);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(414, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 201);
            this.groupBox1.TabIndex = 104;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "NOTE";
            // 
            // note
            // 
            this.note.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.note.Location = new System.Drawing.Point(6, 19);
            this.note.Multiline = true;
            this.note.Name = "note";
            this.note.Size = new System.Drawing.Size(376, 174);
            this.note.TabIndex = 8;
            // 
            // history_btn
            // 
            this.history_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.history_btn.FlatAppearance.BorderSize = 0;
            this.history_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.history_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.history_btn.Location = new System.Drawing.Point(15, 233);
            this.history_btn.Name = "history_btn";
            this.history_btn.Size = new System.Drawing.Size(101, 59);
            this.history_btn.TabIndex = 9;
            this.history_btn.Text = "HISTORY";
            this.history_btn.UseVisualStyleBackColor = false;
            this.history_btn.Click += new System.EventHandler(this.history_btn_Click);
            // 
            // membercard_btn
            // 
            this.membercard_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.membercard_btn.FlatAppearance.BorderSize = 0;
            this.membercard_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.membercard_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.membercard_btn.Location = new System.Drawing.Point(122, 233);
            this.membercard_btn.Name = "membercard_btn";
            this.membercard_btn.Size = new System.Drawing.Size(161, 59);
            this.membercard_btn.TabIndex = 10;
            this.membercard_btn.Text = "MEMBER CARD";
            this.membercard_btn.UseVisualStyleBackColor = false;
            this.membercard_btn.Click += new System.EventHandler(this.membercard_btn_Click);
            // 
            // rus_name
            // 
            this.rus_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rus_name.Location = new System.Drawing.Point(230, 59);
            this.rus_name.Name = "rus_name";
            this.rus_name.Size = new System.Drawing.Size(178, 24);
            this.rus_name.TabIndex = 2;
            // 
            // russian_name_lbl
            // 
            this.russian_name_lbl.AutoSize = true;
            this.russian_name_lbl.BackColor = System.Drawing.Color.Transparent;
            this.russian_name_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.russian_name_lbl.Location = new System.Drawing.Point(12, 62);
            this.russian_name_lbl.Name = "russian_name_lbl";
            this.russian_name_lbl.Size = new System.Drawing.Size(147, 18);
            this.russian_name_lbl.TabIndex = 108;
            this.russian_name_lbl.Text = "RUSSIAN NAME : ";
            // 
            // is_neighbor
            // 
            this.is_neighbor.AutoSize = true;
            this.is_neighbor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.is_neighbor.Location = new System.Drawing.Point(687, 5);
            this.is_neighbor.Name = "is_neighbor";
            this.is_neighbor.Size = new System.Drawing.Size(115, 22);
            this.is_neighbor.TabIndex = 109;
            this.is_neighbor.Text = "NEIGHBOR";
            this.is_neighbor.UseVisualStyleBackColor = true;
            // 
            // customer_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(814, 303);
            this.ControlBox = false;
            this.Controls.Add(this.is_neighbor);
            this.Controls.Add(this.rus_name);
            this.Controls.Add(this.russian_name_lbl);
            this.Controls.Add(this.membercard_btn);
            this.Controls.Add(this.history_btn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gender);
            this.Controls.Add(this.gender_lbl);
            this.Controls.Add(this.birthday);
            this.Controls.Add(this.birthday_lbl);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.manage_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.wedding_anniversary);
            this.Controls.Add(this.wedding_anniversary_lbl);
            this.Controls.Add(this.email);
            this.Controls.Add(this.email_lbl);
            this.Controls.Add(this.tel);
            this.Controls.Add(this.tel_lbl);
            this.Controls.Add(this.code);
            this.Controls.Add(this.code_lbl);
            this.Controls.Add(this.customer_name);
            this.Controls.Add(this.customer_name_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "customer_manage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MANAGE CUSTOMER";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.customer_manage_FormClosed);
            this.Load += new System.EventHandler(this.customer_manage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox customer_name;
        private System.Windows.Forms.Label customer_name_lbl;
        private System.Windows.Forms.Label code_lbl;
        private System.Windows.Forms.Label code;
        private System.Windows.Forms.TextBox tel;
        private System.Windows.Forms.Label tel_lbl;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Label email_lbl;
        private System.Windows.Forms.Label wedding_anniversary_lbl;
        private System.Windows.Forms.MaskedTextBox wedding_anniversary;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button cancel_btn;
        public System.Windows.Forms.Button manage_btn;
        private System.Windows.Forms.Label birthday_lbl;
        private date_data birthday;
        public System.Windows.Forms.ComboBox gender;
        private System.Windows.Forms.Label gender_lbl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox note;
        public System.Windows.Forms.Button history_btn;
        public System.Windows.Forms.Button membercard_btn;
        private System.Windows.Forms.TextBox rus_name;
        private System.Windows.Forms.Label russian_name_lbl;
        private System.Windows.Forms.CheckBox is_neighbor;
    }
}