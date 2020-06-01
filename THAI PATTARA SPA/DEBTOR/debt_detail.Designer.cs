namespace SPA_MANAGEMENT_SYSTEM.DEBTOR
{
    partial class debt_detail
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
            this.btn_dgv = new SPA_MANAGEMENT_SYSTEM.USER_CONTROL.DGV_ONLY();
            this.SuspendLayout();
            // 
            // btn_dgv
            // 
            this.btn_dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_dgv.Location = new System.Drawing.Point(0, 0);
            this.btn_dgv.Name = "btn_dgv";
            this.btn_dgv.Size = new System.Drawing.Size(681, 531);
            this.btn_dgv.TabIndex = 0;
            // 
            // debt_detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 531);
            this.Controls.Add(this.btn_dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "debt_detail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DEBT DETAIL";
            this.Load += new System.EventHandler(this.debt_detail_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private USER_CONTROL.DGV_ONLY btn_dgv;
    }
}