namespace SPA_MANAGEMENT_SYSTEM.ITEM
{
    partial class unit
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
            this.unit_name = new System.Windows.Forms.TextBox();
            this.unit_name_lbl = new System.Windows.Forms.Label();
            this.line_sep = new SPA_MANAGEMENT_SYSTEM.line_sep();
            this.btn_dgv = new SPA_MANAGEMENT_SYSTEM.btn_dgv();
            this.SuspendLayout();
            // 
            // unit_name
            // 
            this.unit_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.unit_name.Location = new System.Drawing.Point(127, 6);
            this.unit_name.Name = "unit_name";
            this.unit_name.Size = new System.Drawing.Size(178, 24);
            this.unit_name.TabIndex = 1;
            this.unit_name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.unit_name_KeyDown);
            // 
            // unit_name_lbl
            // 
            this.unit_name_lbl.AutoSize = true;
            this.unit_name_lbl.BackColor = System.Drawing.Color.Transparent;
            this.unit_name_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.unit_name_lbl.Location = new System.Drawing.Point(12, 9);
            this.unit_name_lbl.Name = "unit_name_lbl";
            this.unit_name_lbl.Size = new System.Drawing.Size(108, 18);
            this.unit_name_lbl.TabIndex = 25;
            this.unit_name_lbl.Text = "UNIT NAME :";
            // 
            // line_sep
            // 
            this.line_sep.BackColor = System.Drawing.Color.Transparent;
            this.line_sep.Location = new System.Drawing.Point(15, 36);
            this.line_sep.MaximumSize = new System.Drawing.Size(2000, 2);
            this.line_sep.MinimumSize = new System.Drawing.Size(0, 2);
            this.line_sep.Name = "line_sep";
            this.line_sep.Size = new System.Drawing.Size(350, 2);
            this.line_sep.TabIndex = 26;
            // 
            // btn_dgv
            // 
            this.btn_dgv.AutoSize = true;
            this.btn_dgv.BackColor = System.Drawing.Color.Transparent;
            this.btn_dgv.Location = new System.Drawing.Point(15, 44);
            this.btn_dgv.Name = "btn_dgv";
            this.btn_dgv.preventDGVSelectionChanged = false;
            this.btn_dgv.Size = new System.Drawing.Size(1349, 645);
            this.btn_dgv.TabIndex = 2;
            // 
            // unit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(885, 503);
            this.ControlBox = false;
            this.Controls.Add(this.btn_dgv);
            this.Controls.Add(this.line_sep);
            this.Controls.Add(this.unit_name);
            this.Controls.Add(this.unit_name_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "unit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "unit";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.doLoadGridData);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox unit_name;
        private System.Windows.Forms.Label unit_name_lbl;
        private line_sep line_sep;
        private btn_dgv btn_dgv;
    }
}