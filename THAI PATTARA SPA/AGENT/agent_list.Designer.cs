namespace SPA_MANAGEMENT_SYSTEM.AGENT
{
    partial class agent_list
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
            this.tel = new System.Windows.Forms.TextBox();
            this.tel_lbl = new System.Windows.Forms.Label();
            this.agent_type = new System.Windows.Forms.ComboBox();
            this.agent_type_lbl = new System.Windows.Forms.Label();
            this.agent_name_lbl = new System.Windows.Forms.Label();
            this.agent_name = new System.Windows.Forms.TextBox();
            this.btn_dgv = new SPA_MANAGEMENT_SYSTEM.btn_dgv();
            this.line_sep1 = new SPA_MANAGEMENT_SYSTEM.line_sep();
            this.SuspendLayout();
            // 
            // tel
            // 
            this.tel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tel.Location = new System.Drawing.Point(371, 9);
            this.tel.Name = "tel";
            this.tel.Size = new System.Drawing.Size(140, 24);
            this.tel.TabIndex = 2;
            this.tel.Tag = "";
            // 
            // tel_lbl
            // 
            this.tel_lbl.AutoSize = true;
            this.tel_lbl.BackColor = System.Drawing.Color.Transparent;
            this.tel_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tel_lbl.Location = new System.Drawing.Point(317, 9);
            this.tel_lbl.Name = "tel_lbl";
            this.tel_lbl.Size = new System.Drawing.Size(53, 18);
            this.tel_lbl.TabIndex = 18;
            this.tel_lbl.Text = "TEL : ";
            // 
            // agent_type
            // 
            this.agent_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.agent_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.agent_type.FormattingEnabled = true;
            this.agent_type.Location = new System.Drawing.Point(674, 5);
            this.agent_type.Name = "agent_type";
            this.agent_type.Size = new System.Drawing.Size(132, 26);
            this.agent_type.TabIndex = 3;
            // 
            // agent_type_lbl
            // 
            this.agent_type_lbl.AutoSize = true;
            this.agent_type_lbl.BackColor = System.Drawing.Color.Transparent;
            this.agent_type_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.agent_type_lbl.Location = new System.Drawing.Point(536, 9);
            this.agent_type_lbl.Name = "agent_type_lbl";
            this.agent_type_lbl.Size = new System.Drawing.Size(126, 18);
            this.agent_type_lbl.TabIndex = 22;
            this.agent_type_lbl.Text = "AGENT TYPE : ";
            // 
            // agent_name_lbl
            // 
            this.agent_name_lbl.AutoSize = true;
            this.agent_name_lbl.BackColor = System.Drawing.Color.Transparent;
            this.agent_name_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.agent_name_lbl.Location = new System.Drawing.Point(12, 9);
            this.agent_name_lbl.Name = "agent_name_lbl";
            this.agent_name_lbl.Size = new System.Drawing.Size(131, 18);
            this.agent_name_lbl.TabIndex = 26;
            this.agent_name_lbl.Text = "AGENT NAME : ";
            // 
            // agent_name
            // 
            this.agent_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.agent_name.Location = new System.Drawing.Point(140, 9);
            this.agent_name.Name = "agent_name";
            this.agent_name.Size = new System.Drawing.Size(140, 24);
            this.agent_name.TabIndex = 1;
            this.agent_name.Tag = "";
            // 
            // btn_dgv
            // 
            this.btn_dgv.AutoSize = true;
            this.btn_dgv.BackColor = System.Drawing.Color.Transparent;
            this.btn_dgv.Location = new System.Drawing.Point(15, 51);
            this.btn_dgv.Name = "btn_dgv";
            this.btn_dgv.preventDGVSelectionChanged = false;
            this.btn_dgv.Size = new System.Drawing.Size(1903, 645);
            this.btn_dgv.TabIndex = 4;
            // 
            // line_sep1
            // 
            this.line_sep1.BackColor = System.Drawing.Color.Transparent;
            this.line_sep1.Location = new System.Drawing.Point(15, 41);
            this.line_sep1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.line_sep1.MinimumSize = new System.Drawing.Size(0, 2);
            this.line_sep1.Name = "line_sep1";
            this.line_sep1.Size = new System.Drawing.Size(350, 2);
            this.line_sep1.TabIndex = 24;
            // 
            // agent_list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(1051, 261);
            this.ControlBox = false;
            this.Controls.Add(this.agent_name);
            this.Controls.Add(this.agent_name_lbl);
            this.Controls.Add(this.btn_dgv);
            this.Controls.Add(this.line_sep1);
            this.Controls.Add(this.agent_type);
            this.Controls.Add(this.agent_type_lbl);
            this.Controls.Add(this.tel);
            this.Controls.Add(this.tel_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "agent_list";
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

        private System.Windows.Forms.TextBox tel;
        private System.Windows.Forms.Label tel_lbl;
        private System.Windows.Forms.ComboBox agent_type;
        private System.Windows.Forms.Label agent_type_lbl;
        private line_sep line_sep1;
        private System.Windows.Forms.Label agent_name_lbl;
        public btn_dgv btn_dgv;
        private System.Windows.Forms.TextBox agent_name;
    }
}