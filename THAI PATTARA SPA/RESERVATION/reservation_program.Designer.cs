namespace SPA_MANAGEMENT_SYSTEM.RESERVATION
{
    partial class reservation_program
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
            this.spa_program_id = new System.Windows.Forms.ComboBox();
            this.spa_program_lbl = new System.Windows.Forms.Label();
            this.therapist1 = new System.Windows.Forms.ComboBox();
            this.therapist1_lbl = new System.Windows.Forms.Label();
            this.therapist2 = new System.Windows.Forms.ComboBox();
            this.therapist2_lbl = new System.Windows.Forms.Label();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.manage_btn = new System.Windows.Forms.Button();
            this.oil = new System.Windows.Forms.ComboBox();
            this.oil_lbl = new System.Windows.Forms.Label();
            this.scrub = new System.Windows.Forms.ComboBox();
            this.scrub_lbl = new System.Windows.Forms.Label();
            this.request1 = new System.Windows.Forms.CheckBox();
            this.request2 = new System.Windows.Forms.CheckBox();
            this.search_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // spa_program_id
            // 
            this.spa_program_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.spa_program_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.spa_program_id.FormattingEnabled = true;
            this.spa_program_id.Location = new System.Drawing.Point(196, 4);
            this.spa_program_id.Name = "spa_program_id";
            this.spa_program_id.Size = new System.Drawing.Size(236, 26);
            this.spa_program_id.TabIndex = 2;
            this.spa_program_id.SelectedIndexChanged += new System.EventHandler(this.spa_program_id_SelectedIndexChanged);
            // 
            // spa_program_lbl
            // 
            this.spa_program_lbl.AutoSize = true;
            this.spa_program_lbl.BackColor = System.Drawing.Color.Transparent;
            this.spa_program_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.spa_program_lbl.Location = new System.Drawing.Point(6, 9);
            this.spa_program_lbl.Name = "spa_program_lbl";
            this.spa_program_lbl.Size = new System.Drawing.Size(145, 18);
            this.spa_program_lbl.TabIndex = 90;
            this.spa_program_lbl.Text = "SPA PROGRAM : ";
            // 
            // therapist1
            // 
            this.therapist1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.therapist1.Enabled = false;
            this.therapist1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.therapist1.FormattingEnabled = true;
            this.therapist1.Location = new System.Drawing.Point(196, 91);
            this.therapist1.Name = "therapist1";
            this.therapist1.Size = new System.Drawing.Size(236, 26);
            this.therapist1.TabIndex = 5;
            this.therapist1.SelectedIndexChanged += new System.EventHandler(this.therapist1_SelectedIndexChanged);
            // 
            // therapist1_lbl
            // 
            this.therapist1_lbl.AutoSize = true;
            this.therapist1_lbl.BackColor = System.Drawing.Color.Transparent;
            this.therapist1_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.therapist1_lbl.Location = new System.Drawing.Point(6, 96);
            this.therapist1_lbl.Name = "therapist1_lbl";
            this.therapist1_lbl.Size = new System.Drawing.Size(114, 18);
            this.therapist1_lbl.TabIndex = 92;
            this.therapist1_lbl.Text = "THERAPIST : ";
            // 
            // therapist2
            // 
            this.therapist2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.therapist2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.therapist2.FormattingEnabled = true;
            this.therapist2.Location = new System.Drawing.Point(196, 120);
            this.therapist2.Name = "therapist2";
            this.therapist2.Size = new System.Drawing.Size(236, 26);
            this.therapist2.TabIndex = 7;
            this.therapist2.Visible = false;
            this.therapist2.SelectedIndexChanged += new System.EventHandler(this.therapist2_SelectedIndexChanged);
            // 
            // therapist2_lbl
            // 
            this.therapist2_lbl.AutoSize = true;
            this.therapist2_lbl.BackColor = System.Drawing.Color.Transparent;
            this.therapist2_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.therapist2_lbl.Location = new System.Drawing.Point(6, 125);
            this.therapist2_lbl.Name = "therapist2_lbl";
            this.therapist2_lbl.Size = new System.Drawing.Size(123, 18);
            this.therapist2_lbl.TabIndex = 94;
            this.therapist2_lbl.Text = "THERAPIST2 : ";
            this.therapist2_lbl.Visible = false;
            // 
            // cancel_btn
            // 
            this.cancel_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.cancel_btn.CausesValidation = false;
            this.cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_btn.FlatAppearance.BorderSize = 0;
            this.cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cancel_btn.Location = new System.Drawing.Point(331, 152);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(101, 59);
            this.cancel_btn.TabIndex = 10;
            this.cancel_btn.Text = "CLOSE";
            this.cancel_btn.UseVisualStyleBackColor = false;
            // 
            // manage_btn
            // 
            this.manage_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.manage_btn.FlatAppearance.BorderSize = 0;
            this.manage_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manage_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.manage_btn.Location = new System.Drawing.Point(224, 152);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(101, 59);
            this.manage_btn.TabIndex = 9;
            this.manage_btn.Text = "ADD";
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // oil
            // 
            this.oil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.oil.Enabled = false;
            this.oil.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.oil.FormattingEnabled = true;
            this.oil.Location = new System.Drawing.Point(196, 33);
            this.oil.Name = "oil";
            this.oil.Size = new System.Drawing.Size(236, 26);
            this.oil.TabIndex = 3;
            // 
            // oil_lbl
            // 
            this.oil_lbl.AutoSize = true;
            this.oil_lbl.BackColor = System.Drawing.Color.Transparent;
            this.oil_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.oil_lbl.Location = new System.Drawing.Point(6, 38);
            this.oil_lbl.Name = "oil_lbl";
            this.oil_lbl.Size = new System.Drawing.Size(49, 18);
            this.oil_lbl.TabIndex = 96;
            this.oil_lbl.Text = "OIL : ";
            // 
            // scrub
            // 
            this.scrub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scrub.Enabled = false;
            this.scrub.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.scrub.FormattingEnabled = true;
            this.scrub.Location = new System.Drawing.Point(196, 62);
            this.scrub.Name = "scrub";
            this.scrub.Size = new System.Drawing.Size(236, 26);
            this.scrub.TabIndex = 4;
            // 
            // scrub_lbl
            // 
            this.scrub_lbl.AutoSize = true;
            this.scrub_lbl.BackColor = System.Drawing.Color.Transparent;
            this.scrub_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.scrub_lbl.Location = new System.Drawing.Point(6, 67);
            this.scrub_lbl.Name = "scrub_lbl";
            this.scrub_lbl.Size = new System.Drawing.Size(81, 18);
            this.scrub_lbl.TabIndex = 98;
            this.scrub_lbl.Text = "SCRUB : ";
            // 
            // request1
            // 
            this.request1.AutoSize = true;
            this.request1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.request1.Location = new System.Drawing.Point(156, 95);
            this.request1.Name = "request1";
            this.request1.Size = new System.Drawing.Size(39, 22);
            this.request1.TabIndex = 6;
            this.request1.Text = "R";
            this.request1.UseVisualStyleBackColor = true;
            // 
            // request2
            // 
            this.request2.AutoSize = true;
            this.request2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.request2.Location = new System.Drawing.Point(156, 124);
            this.request2.Name = "request2";
            this.request2.Size = new System.Drawing.Size(39, 22);
            this.request2.TabIndex = 8;
            this.request2.Text = "R";
            this.request2.UseVisualStyleBackColor = true;
            // 
            // search_btn
            // 
            this.search_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.search_btn.FlatAppearance.BorderSize = 0;
            this.search_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.search_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.search_btn.Image = global::SPA_MANAGEMENT_SYSTEM.Properties.Resources.magnifying_glass_24x24;
            this.search_btn.Location = new System.Drawing.Point(147, 4);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(26, 26);
            this.search_btn.TabIndex = 99;
            this.search_btn.UseVisualStyleBackColor = false;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // reservation_program
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(444, 223);
            this.ControlBox = false;
            this.Controls.Add(this.search_btn);
            this.Controls.Add(this.request2);
            this.Controls.Add(this.request1);
            this.Controls.Add(this.scrub);
            this.Controls.Add(this.scrub_lbl);
            this.Controls.Add(this.oil);
            this.Controls.Add(this.oil_lbl);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.manage_btn);
            this.Controls.Add(this.therapist2);
            this.Controls.Add(this.therapist2_lbl);
            this.Controls.Add(this.therapist1);
            this.Controls.Add(this.therapist1_lbl);
            this.Controls.Add(this.spa_program_id);
            this.Controls.Add(this.spa_program_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "reservation_program";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADD SPA PROGRAM";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.reservation_program_FormClosed);
            this.Load += new System.EventHandler(this.reservation_program_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox spa_program_id;
        private System.Windows.Forms.Label spa_program_lbl;
        public System.Windows.Forms.ComboBox therapist1;
        private System.Windows.Forms.Label therapist1_lbl;
        public System.Windows.Forms.ComboBox therapist2;
        private System.Windows.Forms.Label therapist2_lbl;
        public System.Windows.Forms.Button cancel_btn;
        public System.Windows.Forms.Button manage_btn;
        public System.Windows.Forms.ComboBox oil;
        private System.Windows.Forms.Label oil_lbl;
        public System.Windows.Forms.ComboBox scrub;
        private System.Windows.Forms.Label scrub_lbl;
        private System.Windows.Forms.CheckBox request1;
        private System.Windows.Forms.CheckBox request2;
        public System.Windows.Forms.Button search_btn;
    }
}