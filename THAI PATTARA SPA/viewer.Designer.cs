namespace SPA_MANAGEMENT_SYSTEM
{
    partial class viewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(viewer));
            this.print_preview_btn = new System.Windows.Forms.ToolStripButton();
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.panel = new System.Windows.Forms.Panel();
            this.toolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // print_preview_btn
            // 
            this.print_preview_btn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.print_preview_btn.AutoSize = false;
            this.print_preview_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.print_preview_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.print_preview_btn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.print_preview_btn.Image = ((System.Drawing.Image)(resources.GetObject("print_preview_btn.Image")));
            this.print_preview_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.print_preview_btn.Margin = new System.Windows.Forms.Padding(5);
            this.print_preview_btn.Name = "print_preview_btn";
            this.print_preview_btn.Size = new System.Drawing.Size(150, 59);
            this.print_preview_btn.Text = "PRINT PREVIEW";
            this.print_preview_btn.Click += new System.EventHandler(this.print_preview_btn_Click);
            // 
            // toolbar
            // 
            this.toolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.print_preview_btn});
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(765, 69);
            this.toolbar.TabIndex = 0;
            this.toolbar.Text = "toolStrip1";
            // 
            // panel
            // 
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 69);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(765, 341);
            this.panel.TabIndex = 1;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(765, 410);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.toolbar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "viewer";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FILE VIEWER";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.viewer_FormClosed);
            this.Load += new System.EventHandler(this.viewer_Load);
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton print_preview_btn;
        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.Panel panel;








    }
}