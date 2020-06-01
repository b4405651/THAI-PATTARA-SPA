namespace SPA_MANAGEMENT_SYSTEM.ITEM
{
    partial class unit_manage
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
            this.unit_name = new System.Windows.Forms.TextBox();
            this.item_cat_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // manage_btn
            // 
            this.manage_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.manage_btn.FlatAppearance.BorderSize = 0;
            this.manage_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manage_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.manage_btn.Location = new System.Drawing.Point(202, 38);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(101, 59);
            this.manage_btn.TabIndex = 2;
            this.manage_btn.Text = "ADD";
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // unit_name
            // 
            this.unit_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.unit_name.Location = new System.Drawing.Point(125, 7);
            this.unit_name.Name = "unit_name";
            this.unit_name.Size = new System.Drawing.Size(178, 24);
            this.unit_name.TabIndex = 1;
            // 
            // item_cat_lbl
            // 
            this.item_cat_lbl.AutoSize = true;
            this.item_cat_lbl.BackColor = System.Drawing.Color.Transparent;
            this.item_cat_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_cat_lbl.Location = new System.Drawing.Point(10, 10);
            this.item_cat_lbl.Name = "item_cat_lbl";
            this.item_cat_lbl.Size = new System.Drawing.Size(113, 18);
            this.item_cat_lbl.TabIndex = 6;
            this.item_cat_lbl.Text = "UNIT NAME : ";
            // 
            // unit_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(315, 109);
            this.Controls.Add(this.manage_btn);
            this.Controls.Add(this.unit_name);
            this.Controls.Add(this.item_cat_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "unit_manage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MANAGE UNIT";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.unit_manage_FormClosed);
            this.Load += new System.EventHandler(this.unit_manage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button manage_btn;
        private System.Windows.Forms.TextBox unit_name;
        private System.Windows.Forms.Label item_cat_lbl;
    }
}