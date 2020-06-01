namespace SPA_MANAGEMENT_SYSTEM
{
    partial class re_issue_card
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
            this.issue_date_lbl = new System.Windows.Forms.Label();
            this.card_type = new System.Windows.Forms.ComboBox();
            this.card_type_lbl = new System.Windows.Forms.Label();
            this.btn_dgv = new SPA_MANAGEMENT_SYSTEM.btn_dgv();
            this.line_sep1 = new SPA_MANAGEMENT_SYSTEM.line_sep();
            this.issue_date = new SPA_MANAGEMENT_SYSTEM.date_data();
            this.SuspendLayout();
            // 
            // issue_date_lbl
            // 
            this.issue_date_lbl.AutoSize = true;
            this.issue_date_lbl.BackColor = System.Drawing.Color.Transparent;
            this.issue_date_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.issue_date_lbl.Location = new System.Drawing.Point(331, 9);
            this.issue_date_lbl.Name = "issue_date_lbl";
            this.issue_date_lbl.Size = new System.Drawing.Size(66, 18);
            this.issue_date_lbl.TabIndex = 49;
            this.issue_date_lbl.Text = "DATE : ";
            // 
            // card_type
            // 
            this.card_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.card_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.card_type.FormattingEnabled = true;
            this.card_type.Location = new System.Drawing.Point(136, 6);
            this.card_type.Name = "card_type";
            this.card_type.Size = new System.Drawing.Size(178, 26);
            this.card_type.TabIndex = 77;
            // 
            // card_type_lbl
            // 
            this.card_type_lbl.AutoSize = true;
            this.card_type_lbl.BackColor = System.Drawing.Color.Transparent;
            this.card_type_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.card_type_lbl.Location = new System.Drawing.Point(12, 9);
            this.card_type_lbl.Name = "card_type_lbl";
            this.card_type_lbl.Size = new System.Drawing.Size(116, 18);
            this.card_type_lbl.TabIndex = 78;
            this.card_type_lbl.Text = "CARD TYPE : ";
            // 
            // btn_dgv
            // 
            this.btn_dgv.AutoSize = true;
            this.btn_dgv.BackColor = System.Drawing.Color.Transparent;
            this.btn_dgv.Location = new System.Drawing.Point(12, 44);
            this.btn_dgv.Name = "btn_dgv";
            this.btn_dgv.preventDGVSelectionChanged = false;
            this.btn_dgv.Size = new System.Drawing.Size(1349, 645);
            this.btn_dgv.TabIndex = 79;
            // 
            // line_sep1
            // 
            this.line_sep1.BackColor = System.Drawing.Color.Transparent;
            this.line_sep1.Location = new System.Drawing.Point(12, 36);
            this.line_sep1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.line_sep1.MinimumSize = new System.Drawing.Size(0, 2);
            this.line_sep1.Name = "line_sep1";
            this.line_sep1.Size = new System.Drawing.Size(350, 2);
            this.line_sep1.TabIndex = 50;
            // 
            // issue_date
            // 
            this.issue_date.Location = new System.Drawing.Point(391, 6);
            this.issue_date.Name = "issue_date";
            this.issue_date.Size = new System.Drawing.Size(94, 24);
            this.issue_date.TabIndex = 48;
            // 
            // re_issue_card
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(885, 261);
            this.ControlBox = false;
            this.Controls.Add(this.btn_dgv);
            this.Controls.Add(this.card_type);
            this.Controls.Add(this.card_type_lbl);
            this.Controls.Add(this.line_sep1);
            this.Controls.Add(this.issue_date);
            this.Controls.Add(this.issue_date_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "re_issue_card";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "re_issue_card";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.doLoadGridData);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private date_data issue_date;
        private System.Windows.Forms.Label issue_date_lbl;
        private line_sep line_sep1;
        public System.Windows.Forms.ComboBox card_type;
        private System.Windows.Forms.Label card_type_lbl;
        public btn_dgv btn_dgv;
    }
}