namespace SPA_MANAGEMENT_SYSTEM.PROMOTION
{
    partial class promotion
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
            this.end_date = new SPA_MANAGEMENT_SYSTEM.date_data();
            this.start_date = new SPA_MANAGEMENT_SYSTEM.date_data();
            this.to_lbl = new System.Windows.Forms.Label();
            this.since_lbl = new System.Windows.Forms.Label();
            this.line_sep = new SPA_MANAGEMENT_SYSTEM.line_sep();
            this.btn_dgv = new SPA_MANAGEMENT_SYSTEM.btn_dgv();
            this.SuspendLayout();
            // 
            // end_date
            // 
            this.end_date.Location = new System.Drawing.Point(225, 6);
            this.end_date.Name = "end_date";
            this.end_date.Size = new System.Drawing.Size(94, 24);
            this.end_date.TabIndex = 27;
            // 
            // start_date
            // 
            this.start_date.Location = new System.Drawing.Point(82, 6);
            this.start_date.Name = "start_date";
            this.start_date.Size = new System.Drawing.Size(94, 24);
            this.start_date.TabIndex = 26;
            // 
            // to_lbl
            // 
            this.to_lbl.AutoSize = true;
            this.to_lbl.BackColor = System.Drawing.Color.Transparent;
            this.to_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.to_lbl.Location = new System.Drawing.Point(183, 9);
            this.to_lbl.Name = "to_lbl";
            this.to_lbl.Size = new System.Drawing.Size(46, 18);
            this.to_lbl.TabIndex = 29;
            this.to_lbl.Text = "TO : ";
            // 
            // since_lbl
            // 
            this.since_lbl.AutoSize = true;
            this.since_lbl.BackColor = System.Drawing.Color.Transparent;
            this.since_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.since_lbl.Location = new System.Drawing.Point(12, 9);
            this.since_lbl.Name = "since_lbl";
            this.since_lbl.Size = new System.Drawing.Size(73, 18);
            this.since_lbl.TabIndex = 28;
            this.since_lbl.Text = "SINCE : ";
            // 
            // line_sep
            // 
            this.line_sep.BackColor = System.Drawing.Color.Transparent;
            this.line_sep.Location = new System.Drawing.Point(15, 36);
            this.line_sep.MaximumSize = new System.Drawing.Size(2000, 2);
            this.line_sep.MinimumSize = new System.Drawing.Size(0, 2);
            this.line_sep.Name = "line_sep";
            this.line_sep.Size = new System.Drawing.Size(350, 2);
            this.line_sep.TabIndex = 30;
            // 
            // btn_dgv
            // 
            this.btn_dgv.AutoSize = true;
            this.btn_dgv.BackColor = System.Drawing.Color.Transparent;
            this.btn_dgv.Location = new System.Drawing.Point(15, 44);
            this.btn_dgv.Name = "btn_dgv";
            this.btn_dgv.preventDGVSelectionChanged = false;
            this.btn_dgv.Size = new System.Drawing.Size(1349, 645);
            this.btn_dgv.TabIndex = 31;
            // 
            // promotion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(696, 566);
            this.ControlBox = false;
            this.Controls.Add(this.btn_dgv);
            this.Controls.Add(this.line_sep);
            this.Controls.Add(this.end_date);
            this.Controls.Add(this.start_date);
            this.Controls.Add(this.to_lbl);
            this.Controls.Add(this.since_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "promotion";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "promotion";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.doLoadGridData);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private date_data end_date;
        private date_data start_date;
        private System.Windows.Forms.Label to_lbl;
        private System.Windows.Forms.Label since_lbl;
        private line_sep line_sep;
        private btn_dgv btn_dgv;
    }
}