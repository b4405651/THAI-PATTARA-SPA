namespace SPA_MANAGEMENT_SYSTEM.DEBTOR
{
    partial class debtor_manage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(debtor_manage));
            this.name = new System.Windows.Forms.TextBox();
            this.name_lbl = new System.Windows.Forms.Label();
            this.manage_btn = new System.Windows.Forms.Button();
            this.tel = new System.Windows.Forms.TextBox();
            this.tel_lbl = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.TextBox();
            this.email_lbl = new System.Windows.Forms.Label();
            this.debtor_type_id = new System.Windows.Forms.ComboBox();
            this.debtor_type_lbl = new System.Windows.Forms.Label();
            this.address = new System.Windows.Forms.TextBox();
            this.address_lbl = new System.Windows.Forms.Label();
            this.data_gb = new System.Windows.Forms.GroupBox();
            this.id_card_no_lbl = new System.Windows.Forms.Label();
            this.id_card_no = new System.Windows.Forms.TextBox();
            this.search_name = new SPA_MANAGEMENT_SYSTEM.customAutoComplete();
            this.add_data_btn = new System.Windows.Forms.Button();
            this.search_name_lbl = new System.Windows.Forms.Label();
            this.data_gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.name.Location = new System.Drawing.Point(148, 14);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(185, 24);
            this.name.TabIndex = 2;
            // 
            // name_lbl
            // 
            this.name_lbl.AutoSize = true;
            this.name_lbl.BackColor = System.Drawing.Color.Transparent;
            this.name_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.name_lbl.Location = new System.Drawing.Point(8, 18);
            this.name_lbl.Name = "name_lbl";
            this.name_lbl.Size = new System.Drawing.Size(110, 18);
            this.name_lbl.TabIndex = 39;
            this.name_lbl.Text = "FULLNAME : ";
            // 
            // manage_btn
            // 
            this.manage_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.manage_btn.FlatAppearance.BorderSize = 0;
            this.manage_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manage_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.manage_btn.Location = new System.Drawing.Point(261, 280);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(101, 59);
            this.manage_btn.TabIndex = 7;
            this.manage_btn.Text = "ADD";
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // tel
            // 
            this.tel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tel.Location = new System.Drawing.Point(148, 72);
            this.tel.Name = "tel";
            this.tel.Size = new System.Drawing.Size(140, 24);
            this.tel.TabIndex = 4;
            this.tel.Tag = "barcode";
            // 
            // tel_lbl
            // 
            this.tel_lbl.AutoSize = true;
            this.tel_lbl.BackColor = System.Drawing.Color.Transparent;
            this.tel_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tel_lbl.Location = new System.Drawing.Point(8, 75);
            this.tel_lbl.Name = "tel_lbl";
            this.tel_lbl.Size = new System.Drawing.Size(53, 18);
            this.tel_lbl.TabIndex = 53;
            this.tel_lbl.Text = "TEL : ";
            // 
            // email
            // 
            this.email.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.email.Location = new System.Drawing.Point(148, 102);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(140, 24);
            this.email.TabIndex = 5;
            this.email.Tag = "";
            // 
            // email_lbl
            // 
            this.email_lbl.AutoSize = true;
            this.email_lbl.BackColor = System.Drawing.Color.Transparent;
            this.email_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.email_lbl.Location = new System.Drawing.Point(8, 105);
            this.email_lbl.Name = "email_lbl";
            this.email_lbl.Size = new System.Drawing.Size(77, 18);
            this.email_lbl.TabIndex = 56;
            this.email_lbl.Text = "E-MAIL : ";
            // 
            // debtor_type_id
            // 
            this.debtor_type_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.debtor_type_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.debtor_type_id.FormattingEnabled = true;
            this.debtor_type_id.Location = new System.Drawing.Point(152, 7);
            this.debtor_type_id.Name = "debtor_type_id";
            this.debtor_type_id.Size = new System.Drawing.Size(210, 26);
            this.debtor_type_id.TabIndex = 1;
            this.debtor_type_id.SelectedIndexChanged += new System.EventHandler(this.debtor_type_id_SelectedIndexChanged);
            // 
            // debtor_type_lbl
            // 
            this.debtor_type_lbl.AutoSize = true;
            this.debtor_type_lbl.BackColor = System.Drawing.Color.Transparent;
            this.debtor_type_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.debtor_type_lbl.Location = new System.Drawing.Point(12, 11);
            this.debtor_type_lbl.Name = "debtor_type_lbl";
            this.debtor_type_lbl.Size = new System.Drawing.Size(139, 18);
            this.debtor_type_lbl.TabIndex = 58;
            this.debtor_type_lbl.Text = "DEBTOR TYPE : ";
            // 
            // address
            // 
            this.address.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.address.Location = new System.Drawing.Point(148, 131);
            this.address.Multiline = true;
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(185, 99);
            this.address.TabIndex = 6;
            this.address.Tag = "";
            // 
            // address_lbl
            // 
            this.address_lbl.AutoSize = true;
            this.address_lbl.BackColor = System.Drawing.Color.Transparent;
            this.address_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.address_lbl.Location = new System.Drawing.Point(8, 134);
            this.address_lbl.Name = "address_lbl";
            this.address_lbl.Size = new System.Drawing.Size(102, 18);
            this.address_lbl.TabIndex = 60;
            this.address_lbl.Text = "ADDRESS : ";
            // 
            // data_gb
            // 
            this.data_gb.Controls.Add(this.id_card_no_lbl);
            this.data_gb.Controls.Add(this.id_card_no);
            this.data_gb.Controls.Add(this.name_lbl);
            this.data_gb.Controls.Add(this.address);
            this.data_gb.Controls.Add(this.name);
            this.data_gb.Controls.Add(this.address_lbl);
            this.data_gb.Controls.Add(this.tel_lbl);
            this.data_gb.Controls.Add(this.tel);
            this.data_gb.Controls.Add(this.email);
            this.data_gb.Controls.Add(this.email_lbl);
            this.data_gb.Location = new System.Drawing.Point(15, 34);
            this.data_gb.Name = "data_gb";
            this.data_gb.Size = new System.Drawing.Size(347, 239);
            this.data_gb.TabIndex = 61;
            this.data_gb.TabStop = false;
            // 
            // id_card_no_lbl
            // 
            this.id_card_no_lbl.AutoSize = true;
            this.id_card_no_lbl.BackColor = System.Drawing.Color.Transparent;
            this.id_card_no_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.id_card_no_lbl.Location = new System.Drawing.Point(8, 47);
            this.id_card_no_lbl.Name = "id_card_no_lbl";
            this.id_card_no_lbl.Size = new System.Drawing.Size(120, 18);
            this.id_card_no_lbl.TabIndex = 62;
            this.id_card_no_lbl.Text = "ID CARD NO : ";
            // 
            // id_card_no
            // 
            this.id_card_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.id_card_no.Location = new System.Drawing.Point(148, 43);
            this.id_card_no.Name = "id_card_no";
            this.id_card_no.Size = new System.Drawing.Size(185, 24);
            this.id_card_no.TabIndex = 3;
            // 
            // search_name
            // 
            this.search_name.currentID = -1;
            this.search_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.search_name.Location = new System.Drawing.Point(152, 37);
            this.search_name.Mode = "";
            this.search_name.Name = "search_name";
            this.search_name.Size = new System.Drawing.Size(179, 24);
            this.search_name.TabIndex = 59;
            // 
            // add_data_btn
            // 
            this.add_data_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.add_data_btn.FlatAppearance.BorderSize = 0;
            this.add_data_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_data_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.add_data_btn.Image = ((System.Drawing.Image)(resources.GetObject("add_data_btn.Image")));
            this.add_data_btn.Location = new System.Drawing.Point(337, 37);
            this.add_data_btn.Name = "add_data_btn";
            this.add_data_btn.Size = new System.Drawing.Size(24, 24);
            this.add_data_btn.TabIndex = 60;
            this.add_data_btn.UseVisualStyleBackColor = false;
            this.add_data_btn.Click += new System.EventHandler(this.add_data_btn_Click);
            // 
            // search_name_lbl
            // 
            this.search_name_lbl.AutoSize = true;
            this.search_name_lbl.BackColor = System.Drawing.Color.Transparent;
            this.search_name_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.search_name_lbl.Location = new System.Drawing.Point(12, 41);
            this.search_name_lbl.Name = "search_name_lbl";
            this.search_name_lbl.Size = new System.Drawing.Size(126, 18);
            this.search_name_lbl.TabIndex = 61;
            this.search_name_lbl.Text = "NAME or TEL : ";
            // 
            // debtor_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(370, 349);
            this.Controls.Add(this.debtor_type_id);
            this.Controls.Add(this.debtor_type_lbl);
            this.Controls.Add(this.manage_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "debtor_manage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MANAGE DEBTOR DATA";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.debtor_manage_FormClosed);
            this.Load += new System.EventHandler(this.debtor_manage_Load);
            this.data_gb.ResumeLayout(false);
            this.data_gb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label name_lbl;
        public System.Windows.Forms.Button manage_btn;
        private System.Windows.Forms.TextBox tel;
        private System.Windows.Forms.Label tel_lbl;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Label email_lbl;
        private System.Windows.Forms.ComboBox debtor_type_id;
        private System.Windows.Forms.Label debtor_type_lbl;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.Label address_lbl;
        private System.Windows.Forms.GroupBox data_gb;
        public customAutoComplete search_name;
        public System.Windows.Forms.Button add_data_btn;
        private System.Windows.Forms.Label search_name_lbl;
        private System.Windows.Forms.Label id_card_no_lbl;
        private System.Windows.Forms.TextBox id_card_no;
    }
}