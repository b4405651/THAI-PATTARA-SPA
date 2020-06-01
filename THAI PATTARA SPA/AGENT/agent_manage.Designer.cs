namespace SPA_MANAGEMENT_SYSTEM.AGENT
{
    partial class agent_manage
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
            this.manage_btn = new System.Windows.Forms.Button();
            this.tel = new System.Windows.Forms.TextBox();
            this.tel_lbl = new System.Windows.Forms.Label();
            this.agent_name = new System.Windows.Forms.TextBox();
            this.item_code_lbl = new System.Windows.Forms.Label();
            this.agent_type = new System.Windows.Forms.ComboBox();
            this.agent_type_lbl = new System.Windows.Forms.Label();
            this.contact_person = new System.Windows.Forms.TextBox();
            this.contact_person_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // manage_btn
            // 
            this.manage_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.manage_btn.FlatAppearance.BorderSize = 0;
            this.manage_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manage_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.manage_btn.Location = new System.Drawing.Point(261, 126);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(101, 59);
            this.manage_btn.TabIndex = 5;
            this.manage_btn.Text = "ADD";
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // tel
            // 
            this.tel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tel.Location = new System.Drawing.Point(184, 37);
            this.tel.Name = "tel";
            this.tel.Size = new System.Drawing.Size(178, 24);
            this.tel.TabIndex = 2;
            // 
            // tel_lbl
            // 
            this.tel_lbl.AutoSize = true;
            this.tel_lbl.BackColor = System.Drawing.Color.Transparent;
            this.tel_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tel_lbl.Location = new System.Drawing.Point(10, 40);
            this.tel_lbl.Name = "tel_lbl";
            this.tel_lbl.Size = new System.Drawing.Size(53, 18);
            this.tel_lbl.TabIndex = 15;
            this.tel_lbl.Text = "TEL : ";
            // 
            // agent_name
            // 
            this.agent_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.agent_name.Location = new System.Drawing.Point(184, 9);
            this.agent_name.Name = "agent_name";
            this.agent_name.Size = new System.Drawing.Size(178, 24);
            this.agent_name.TabIndex = 1;
            this.agent_name.Tag = "barcode";
            // 
            // item_code_lbl
            // 
            this.item_code_lbl.AutoSize = true;
            this.item_code_lbl.BackColor = System.Drawing.Color.Transparent;
            this.item_code_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_code_lbl.Location = new System.Drawing.Point(10, 12);
            this.item_code_lbl.Name = "item_code_lbl";
            this.item_code_lbl.Size = new System.Drawing.Size(131, 18);
            this.item_code_lbl.TabIndex = 32;
            this.item_code_lbl.Text = "AGENT NAME : ";
            // 
            // agent_type
            // 
            this.agent_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.agent_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.agent_type.FormattingEnabled = true;
            this.agent_type.Location = new System.Drawing.Point(184, 65);
            this.agent_type.Name = "agent_type";
            this.agent_type.Size = new System.Drawing.Size(178, 26);
            this.agent_type.TabIndex = 3;
            this.agent_type.SelectedIndexChanged += new System.EventHandler(this.agent_type_SelectedIndexChanged);
            // 
            // agent_type_lbl
            // 
            this.agent_type_lbl.AutoSize = true;
            this.agent_type_lbl.BackColor = System.Drawing.Color.Transparent;
            this.agent_type_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.agent_type_lbl.Location = new System.Drawing.Point(10, 68);
            this.agent_type_lbl.Name = "agent_type_lbl";
            this.agent_type_lbl.Size = new System.Drawing.Size(121, 18);
            this.agent_type_lbl.TabIndex = 34;
            this.agent_type_lbl.Text = "AGENT TYPE :";
            // 
            // contact_person
            // 
            this.contact_person.Enabled = false;
            this.contact_person.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.contact_person.Location = new System.Drawing.Point(184, 95);
            this.contact_person.Name = "contact_person";
            this.contact_person.Size = new System.Drawing.Size(178, 24);
            this.contact_person.TabIndex = 4;
            this.contact_person.Tag = "";
            // 
            // contact_person_lbl
            // 
            this.contact_person_lbl.AutoSize = true;
            this.contact_person_lbl.BackColor = System.Drawing.Color.Transparent;
            this.contact_person_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.contact_person_lbl.Location = new System.Drawing.Point(10, 98);
            this.contact_person_lbl.Name = "contact_person_lbl";
            this.contact_person_lbl.Size = new System.Drawing.Size(177, 18);
            this.contact_person_lbl.TabIndex = 36;
            this.contact_person_lbl.Text = "CONTACT PERSON : ";
            // 
            // agent_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(373, 195);
            this.Controls.Add(this.contact_person);
            this.Controls.Add(this.contact_person_lbl);
            this.Controls.Add(this.agent_type);
            this.Controls.Add(this.agent_type_lbl);
            this.Controls.Add(this.tel);
            this.Controls.Add(this.agent_name);
            this.Controls.Add(this.item_code_lbl);
            this.Controls.Add(this.manage_btn);
            this.Controls.Add(this.tel_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "agent_manage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MANAGE AGENT";
            this.Load += new System.EventHandler(this.agent_manage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button manage_btn;
        private System.Windows.Forms.TextBox tel;
        private System.Windows.Forms.Label tel_lbl;
        private System.Windows.Forms.TextBox agent_name;
        private System.Windows.Forms.Label item_code_lbl;
        public System.Windows.Forms.ComboBox agent_type;
        public System.Windows.Forms.Label agent_type_lbl;
        private System.Windows.Forms.TextBox contact_person;
        private System.Windows.Forms.Label contact_person_lbl;
    }
}