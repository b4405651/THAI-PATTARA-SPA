namespace SPA_MANAGEMENT_SYSTEM.USER
{
    partial class user_page
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
            this.last_login_lbl = new System.Windows.Forms.Label();
            this.owner_lbl = new System.Windows.Forms.Label();
            this.created_since_lbl = new System.Windows.Forms.Label();
            this.created_by_lbl = new System.Windows.Forms.Label();
            this.status_lbl = new System.Windows.Forms.Label();
            this.username_lbl = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.ComboBox();
            this.username = new System.Windows.Forms.TextBox();
            this.owner = new System.Windows.Forms.TextBox();
            this.created_by = new System.Windows.Forms.TextBox();
            this.btn_dgv = new SPA_MANAGEMENT_SYSTEM.btn_dgv();
            this.line_sep1 = new SPA_MANAGEMENT_SYSTEM.line_sep();
            this.create_since = new SPA_MANAGEMENT_SYSTEM.date_data();
            this.last_login = new SPA_MANAGEMENT_SYSTEM.date_data();
            this.SuspendLayout();
            // 
            // last_login_lbl
            // 
            this.last_login_lbl.AutoSize = true;
            this.last_login_lbl.BackColor = System.Drawing.Color.Transparent;
            this.last_login_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.last_login_lbl.Location = new System.Drawing.Point(325, 62);
            this.last_login_lbl.Name = "last_login_lbl";
            this.last_login_lbl.Size = new System.Drawing.Size(119, 18);
            this.last_login_lbl.TabIndex = 7;
            this.last_login_lbl.Text = "LAST LOGIN : ";
            // 
            // owner_lbl
            // 
            this.owner_lbl.AutoSize = true;
            this.owner_lbl.BackColor = System.Drawing.Color.Transparent;
            this.owner_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.owner_lbl.Location = new System.Drawing.Point(12, 35);
            this.owner_lbl.Name = "owner_lbl";
            this.owner_lbl.Size = new System.Drawing.Size(87, 18);
            this.owner_lbl.TabIndex = 2;
            this.owner_lbl.Text = "OWNER : ";
            // 
            // created_since_lbl
            // 
            this.created_since_lbl.AutoSize = true;
            this.created_since_lbl.BackColor = System.Drawing.Color.Transparent;
            this.created_since_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.created_since_lbl.Location = new System.Drawing.Point(325, 9);
            this.created_since_lbl.Name = "created_since_lbl";
            this.created_since_lbl.Size = new System.Drawing.Size(144, 18);
            this.created_since_lbl.TabIndex = 3;
            this.created_since_lbl.Text = "CREATE SINCE : ";
            // 
            // created_by_lbl
            // 
            this.created_by_lbl.AutoSize = true;
            this.created_by_lbl.BackColor = System.Drawing.Color.Transparent;
            this.created_by_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.created_by_lbl.Location = new System.Drawing.Point(325, 35);
            this.created_by_lbl.Name = "created_by_lbl";
            this.created_by_lbl.Size = new System.Drawing.Size(115, 18);
            this.created_by_lbl.TabIndex = 4;
            this.created_by_lbl.Text = "CREATE BY : ";
            // 
            // status_lbl
            // 
            this.status_lbl.AutoSize = true;
            this.status_lbl.BackColor = System.Drawing.Color.Transparent;
            this.status_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.status_lbl.Location = new System.Drawing.Point(12, 62);
            this.status_lbl.Name = "status_lbl";
            this.status_lbl.Size = new System.Drawing.Size(87, 18);
            this.status_lbl.TabIndex = 5;
            this.status_lbl.Text = "STATUS : ";
            // 
            // username_lbl
            // 
            this.username_lbl.AutoSize = true;
            this.username_lbl.BackColor = System.Drawing.Color.Transparent;
            this.username_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.username_lbl.Location = new System.Drawing.Point(12, 9);
            this.username_lbl.Name = "username_lbl";
            this.username_lbl.Size = new System.Drawing.Size(116, 18);
            this.username_lbl.TabIndex = 0;
            this.username_lbl.Text = "USERNAME : ";
            // 
            // status
            // 
            this.status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.status.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.status.FormattingEnabled = true;
            this.status.Location = new System.Drawing.Point(131, 58);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(176, 26);
            this.status.TabIndex = 3;
            // 
            // username
            // 
            this.username.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.username.Location = new System.Drawing.Point(131, 7);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(178, 24);
            this.username.TabIndex = 1;
            // 
            // owner
            // 
            this.owner.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.owner.Location = new System.Drawing.Point(131, 32);
            this.owner.Name = "owner";
            this.owner.Size = new System.Drawing.Size(178, 24);
            this.owner.TabIndex = 2;
            // 
            // created_by
            // 
            this.created_by.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.created_by.Location = new System.Drawing.Point(472, 32);
            this.created_by.Name = "created_by";
            this.created_by.Size = new System.Drawing.Size(176, 24);
            this.created_by.TabIndex = 5;
            // 
            // btn_dgv
            // 
            this.btn_dgv.AutoSize = true;
            this.btn_dgv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.btn_dgv.Location = new System.Drawing.Point(12, 113);
            this.btn_dgv.Name = "btn_dgv";
            this.btn_dgv.preventDGVSelectionChanged = false;
            this.btn_dgv.Size = new System.Drawing.Size(1349, 700);
            this.btn_dgv.TabIndex = 7;
            // 
            // line_sep1
            // 
            this.line_sep1.BackColor = System.Drawing.Color.Transparent;
            this.line_sep1.Location = new System.Drawing.Point(12, 89);
            this.line_sep1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.line_sep1.MinimumSize = new System.Drawing.Size(0, 2);
            this.line_sep1.Name = "line_sep1";
            this.line_sep1.Size = new System.Drawing.Size(350, 2);
            this.line_sep1.TabIndex = 14;
            // 
            // create_since
            // 
            this.create_since.Location = new System.Drawing.Point(472, 7);
            this.create_since.Name = "create_since";
            this.create_since.Size = new System.Drawing.Size(94, 24);
            this.create_since.TabIndex = 4;
            // 
            // last_login
            // 
            this.last_login.Location = new System.Drawing.Point(472, 58);
            this.last_login.Name = "last_login";
            this.last_login.Size = new System.Drawing.Size(94, 24);
            this.last_login.TabIndex = 6;
            // 
            // user_page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(711, 261);
            this.ControlBox = false;
            this.Controls.Add(this.last_login);
            this.Controls.Add(this.create_since);
            this.Controls.Add(this.created_by);
            this.Controls.Add(this.owner);
            this.Controls.Add(this.username);
            this.Controls.Add(this.status);
            this.Controls.Add(this.btn_dgv);
            this.Controls.Add(this.username_lbl);
            this.Controls.Add(this.created_since_lbl);
            this.Controls.Add(this.created_by_lbl);
            this.Controls.Add(this.owner_lbl);
            this.Controls.Add(this.status_lbl);
            this.Controls.Add(this.last_login_lbl);
            this.Controls.Add(this.line_sep1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "user_page";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "user";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.doLoadGridData);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public btn_dgv btn_dgv;
        private System.Windows.Forms.Label last_login_lbl;
        private System.Windows.Forms.Label username_lbl;
        private System.Windows.Forms.Label owner_lbl;
        private System.Windows.Forms.Label created_since_lbl;
        private System.Windows.Forms.Label created_by_lbl;
        private System.Windows.Forms.Label status_lbl;
        private System.Windows.Forms.ComboBox status;
        private line_sep line_sep1;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox owner;
        private System.Windows.Forms.TextBox created_by;
        private date_data create_since;
        private date_data last_login;



    }
}