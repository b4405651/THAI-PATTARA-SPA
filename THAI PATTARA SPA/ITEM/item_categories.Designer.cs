namespace SPA_MANAGEMENT_SYSTEM.ITEM
{
    partial class item_categories
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
            this.item_cat_lbl = new System.Windows.Forms.Label();
            this.line_sep1 = new SPA_MANAGEMENT_SYSTEM.line_sep();
            this.item_cat = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_dgv
            // 
            this.btn_dgv.AutoSize = true;
            this.btn_dgv.BackColor = System.Drawing.Color.Transparent;
            this.btn_dgv.Location = new System.Drawing.Point(12, 55);
            this.btn_dgv.Name = "btn_dgv";
            this.btn_dgv.preventDGVSelectionChanged = false;
            this.btn_dgv.Size = new System.Drawing.Size(1903, 645);
            this.btn_dgv.TabIndex = 3;
            // 
            // item_cat_lbl
            // 
            this.item_cat_lbl.AutoSize = true;
            this.item_cat_lbl.BackColor = System.Drawing.Color.Transparent;
            this.item_cat_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_cat_lbl.Location = new System.Drawing.Point(9, 9);
            this.item_cat_lbl.Name = "item_cat_lbl";
            this.item_cat_lbl.Size = new System.Drawing.Size(158, 18);
            this.item_cat_lbl.TabIndex = 1;
            this.item_cat_lbl.Text = "ITEM CATEGORY : ";
            // 
            // line_sep1
            // 
            this.line_sep1.BackColor = System.Drawing.Color.Transparent;
            this.line_sep1.Location = new System.Drawing.Point(12, 40);
            this.line_sep1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.line_sep1.MinimumSize = new System.Drawing.Size(0, 2);
            this.line_sep1.Name = "line_sep1";
            this.line_sep1.Size = new System.Drawing.Size(350, 2);
            this.line_sep1.TabIndex = 15;
            // 
            // item_cat
            // 
            this.item_cat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_cat.Location = new System.Drawing.Point(172, 6);
            this.item_cat.Name = "item_cat";
            this.item_cat.Size = new System.Drawing.Size(178, 24);
            this.item_cat.TabIndex = 1;
            // 
            // item_categories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(885, 261);
            this.ControlBox = false;
            this.Controls.Add(this.item_cat);
            this.Controls.Add(this.item_cat_lbl);
            this.Controls.Add(this.line_sep1);
            this.Controls.Add(this.btn_dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "item_categories";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "users_auth";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.doLoadGridData);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private btn_dgv btn_dgv;
        private System.Windows.Forms.Label item_cat_lbl;
        private line_sep line_sep1;
        private System.Windows.Forms.TextBox item_cat;
    }
}