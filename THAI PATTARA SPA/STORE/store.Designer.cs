namespace SPA_MANAGEMENT_SYSTEM.STORE
{
    partial class store
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
            this.item_name_lbl = new System.Windows.Forms.Label();
            this.item_name = new System.Windows.Forms.TextBox();
            this.item_cat_lbl = new System.Windows.Forms.Label();
            this.code = new System.Windows.Forms.TextBox();
            this.code_lbl = new System.Windows.Forms.Label();
            this.btn_dgv = new SPA_MANAGEMENT_SYSTEM.btn_dgv();
            this.line_sep = new SPA_MANAGEMENT_SYSTEM.line_sep();
            this.item_cat = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // item_name_lbl
            // 
            this.item_name_lbl.AutoSize = true;
            this.item_name_lbl.BackColor = System.Drawing.Color.Transparent;
            this.item_name_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_name_lbl.Location = new System.Drawing.Point(429, 9);
            this.item_name_lbl.Name = "item_name_lbl";
            this.item_name_lbl.Size = new System.Drawing.Size(114, 18);
            this.item_name_lbl.TabIndex = 29;
            this.item_name_lbl.Text = "ITEM NAME : ";
            // 
            // item_name
            // 
            this.item_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_name.Location = new System.Drawing.Point(539, 6);
            this.item_name.Name = "item_name";
            this.item_name.Size = new System.Drawing.Size(178, 24);
            this.item_name.TabIndex = 2;
            this.item_name.KeyUp += new System.Windows.Forms.KeyEventHandler(this.item_name_KeyUp);
            // 
            // item_cat_lbl
            // 
            this.item_cat_lbl.AutoSize = true;
            this.item_cat_lbl.BackColor = System.Drawing.Color.Transparent;
            this.item_cat_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_cat_lbl.Location = new System.Drawing.Point(723, 9);
            this.item_cat_lbl.Name = "item_cat_lbl";
            this.item_cat_lbl.Size = new System.Drawing.Size(158, 18);
            this.item_cat_lbl.TabIndex = 39;
            this.item_cat_lbl.Text = "ITEM CATEGORY : ";
            // 
            // code
            // 
            this.code.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.code.Location = new System.Drawing.Point(241, 6);
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(178, 24);
            this.code.TabIndex = 1;
            this.code.Tag = "barcode";
            this.code.KeyUp += new System.Windows.Forms.KeyEventHandler(this.item_code_KeyUp);
            // 
            // code_lbl
            // 
            this.code_lbl.AutoSize = true;
            this.code_lbl.BackColor = System.Drawing.Color.Transparent;
            this.code_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.code_lbl.Location = new System.Drawing.Point(12, 9);
            this.code_lbl.Name = "code_lbl";
            this.code_lbl.Size = new System.Drawing.Size(236, 18);
            this.code_lbl.TabIndex = 41;
            this.code_lbl.Text = "ITEM CODE OR BARCODE :  ";
            // 
            // btn_dgv
            // 
            this.btn_dgv.AutoSize = true;
            this.btn_dgv.BackColor = System.Drawing.Color.Transparent;
            this.btn_dgv.Location = new System.Drawing.Point(15, 43);
            this.btn_dgv.Name = "btn_dgv";
            this.btn_dgv.preventDGVSelectionChanged = false;
            this.btn_dgv.Size = new System.Drawing.Size(1903, 645);
            this.btn_dgv.TabIndex = 4;
            // 
            // line_sep
            // 
            this.line_sep.BackColor = System.Drawing.Color.Transparent;
            this.line_sep.Location = new System.Drawing.Point(15, 35);
            this.line_sep.MaximumSize = new System.Drawing.Size(2000, 2);
            this.line_sep.MinimumSize = new System.Drawing.Size(0, 2);
            this.line_sep.Name = "line_sep";
            this.line_sep.Size = new System.Drawing.Size(350, 2);
            this.line_sep.TabIndex = 37;
            // 
            // item_cat
            // 
            this.item_cat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.item_cat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_cat.FormattingEnabled = true;
            this.item_cat.Location = new System.Drawing.Point(876, 6);
            this.item_cat.Name = "item_cat";
            this.item_cat.Size = new System.Drawing.Size(178, 26);
            this.item_cat.TabIndex = 42;
            this.item_cat.SelectedIndexChanged += new System.EventHandler(this.item_cat_SelectedIndexChanged);
            // 
            // store
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(1051, 261);
            this.ControlBox = false;
            this.Controls.Add(this.item_cat);
            this.Controls.Add(this.code);
            this.Controls.Add(this.code_lbl);
            this.Controls.Add(this.item_cat_lbl);
            this.Controls.Add(this.btn_dgv);
            this.Controls.Add(this.line_sep);
            this.Controls.Add(this.item_name);
            this.Controls.Add(this.item_name_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "store";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "store";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.doLoadGridData);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label item_name_lbl;
        private System.Windows.Forms.TextBox item_name;
        private line_sep line_sep;
        private btn_dgv btn_dgv;
        private System.Windows.Forms.Label item_cat_lbl;
        private System.Windows.Forms.TextBox code;
        private System.Windows.Forms.Label code_lbl;
        public System.Windows.Forms.ComboBox item_cat;
    }
}