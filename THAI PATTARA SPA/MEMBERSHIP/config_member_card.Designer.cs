namespace SPA_MANAGEMENT_SYSTEM.MEMBERSHIP
{
    partial class config_member_card
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
            this.btn_dgv = new SPA_MANAGEMENT_SYSTEM.btn_dgv();
            this.card_name = new System.Windows.Forms.TextBox();
            this.card_name_lbl = new System.Windows.Forms.Label();
            this.line_sep1 = new SPA_MANAGEMENT_SYSTEM.line_sep();
            this.item_name = new System.Windows.Forms.TextBox();
            this.item_name_lbl = new System.Windows.Forms.Label();
            this.show_disabled = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_dgv
            // 
            this.btn_dgv.AutoSize = true;
            this.btn_dgv.BackColor = System.Drawing.Color.Transparent;
            this.btn_dgv.Location = new System.Drawing.Point(12, 51);
            this.btn_dgv.Name = "btn_dgv";
            this.btn_dgv.preventDGVSelectionChanged = false;
            this.btn_dgv.Size = new System.Drawing.Size(1423, 645);
            this.btn_dgv.TabIndex = 41;
            // 
            // card_name
            // 
            this.card_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.card_name.Location = new System.Drawing.Point(127, 10);
            this.card_name.Name = "card_name";
            this.card_name.Size = new System.Drawing.Size(178, 24);
            this.card_name.TabIndex = 40;
            // 
            // card_name_lbl
            // 
            this.card_name_lbl.AutoSize = true;
            this.card_name_lbl.BackColor = System.Drawing.Color.Transparent;
            this.card_name_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.card_name_lbl.Location = new System.Drawing.Point(12, 13);
            this.card_name_lbl.Name = "card_name_lbl";
            this.card_name_lbl.Size = new System.Drawing.Size(116, 18);
            this.card_name_lbl.TabIndex = 42;
            this.card_name_lbl.Text = "CARD NAME :";
            // 
            // line_sep1
            // 
            this.line_sep1.BackColor = System.Drawing.Color.Transparent;
            this.line_sep1.Location = new System.Drawing.Point(12, 40);
            this.line_sep1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.line_sep1.MinimumSize = new System.Drawing.Size(0, 2);
            this.line_sep1.Name = "line_sep1";
            this.line_sep1.Size = new System.Drawing.Size(350, 2);
            this.line_sep1.TabIndex = 39;
            // 
            // item_name
            // 
            this.item_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_name.Location = new System.Drawing.Point(228, -209);
            this.item_name.Name = "item_name";
            this.item_name.Size = new System.Drawing.Size(178, 24);
            this.item_name.TabIndex = 37;
            // 
            // item_name_lbl
            // 
            this.item_name_lbl.AutoSize = true;
            this.item_name_lbl.BackColor = System.Drawing.Color.Transparent;
            this.item_name_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_name_lbl.Location = new System.Drawing.Point(113, -206);
            this.item_name_lbl.Name = "item_name_lbl";
            this.item_name_lbl.Size = new System.Drawing.Size(109, 18);
            this.item_name_lbl.TabIndex = 38;
            this.item_name_lbl.Text = "ITEM NAME :";
            // 
            // show_disabled
            // 
            this.show_disabled.AutoSize = true;
            this.show_disabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.show_disabled.Location = new System.Drawing.Point(323, 12);
            this.show_disabled.Name = "show_disabled";
            this.show_disabled.Size = new System.Drawing.Size(164, 22);
            this.show_disabled.TabIndex = 43;
            this.show_disabled.Text = "SHOW DISABLED";
            this.show_disabled.UseVisualStyleBackColor = true;
            this.show_disabled.CheckedChanged += new System.EventHandler(this.doLoadGridData);
            // 
            // config_member_card
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(885, 261);
            this.ControlBox = false;
            this.Controls.Add(this.show_disabled);
            this.Controls.Add(this.btn_dgv);
            this.Controls.Add(this.card_name);
            this.Controls.Add(this.card_name_lbl);
            this.Controls.Add(this.line_sep1);
            this.Controls.Add(this.item_name);
            this.Controls.Add(this.item_name_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "config_member_card";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "config_member_card";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.doLoadGridData);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private btn_dgv btn_dgv;
        private System.Windows.Forms.TextBox card_name;
        private System.Windows.Forms.Label card_name_lbl;
        private line_sep line_sep1;
        private System.Windows.Forms.TextBox item_name;
        private System.Windows.Forms.Label item_name_lbl;
        private System.Windows.Forms.CheckBox show_disabled;
    }
}