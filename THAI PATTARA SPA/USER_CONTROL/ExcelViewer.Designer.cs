namespace SPA_MANAGEMENT_SYSTEM.USER_CONTROL
{
    partial class ExcelViewer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ExcelPlaceHolder = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // ExcelPlaceHolder
            // 
            this.ExcelPlaceHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExcelPlaceHolder.Location = new System.Drawing.Point(0, 0);
            this.ExcelPlaceHolder.MinimumSize = new System.Drawing.Size(20, 20);
            this.ExcelPlaceHolder.Name = "ExcelPlaceHolder";
            this.ExcelPlaceHolder.Size = new System.Drawing.Size(530, 367);
            this.ExcelPlaceHolder.TabIndex = 1;
            this.ExcelPlaceHolder.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.ExcelPlaceHolder_Navigated);
            // 
            // ExcelViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ExcelPlaceHolder);
            this.Name = "ExcelViewer";
            this.Size = new System.Drawing.Size(530, 367);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser ExcelPlaceHolder;
    }
}
