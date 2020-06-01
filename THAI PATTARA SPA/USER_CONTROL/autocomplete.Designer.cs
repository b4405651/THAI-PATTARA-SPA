namespace SPA_MANAGEMENT_SYSTEM
{
    partial class autocomplete
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
            this.acTxt = new System.Windows.Forms.TextBox();
            this.acBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // acTxt
            // 
            this.acTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.acTxt.Location = new System.Drawing.Point(3, 3);
            this.acTxt.Name = "acTxt";
            this.acTxt.Size = new System.Drawing.Size(180, 24);
            this.acTxt.TabIndex = 0;
            this.acTxt.TextChanged += new System.EventHandler(this.acTxt_TextChanged);
            this.acTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.acTxt_KeyPress);
            this.acTxt.Leave += new System.EventHandler(this.acTxt_Leave);
            this.acTxt.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.acTxt_PreviewKeyDown);
            // 
            // acBox
            // 
            this.acBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.acBox.FormattingEnabled = true;
            this.acBox.IntegralHeight = false;
            this.acBox.ItemHeight = 18;
            this.acBox.Location = new System.Drawing.Point(3, 26);
            this.acBox.Name = "acBox";
            this.acBox.Size = new System.Drawing.Size(178, 256);
            this.acBox.TabIndex = 16;
            this.acBox.Visible = false;
            this.acBox.Click += new System.EventHandler(this.acBox_Click);
            // 
            // autocomplete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.acBox);
            this.Controls.Add(this.acTxt);
            this.Name = "autocomplete";
            this.Size = new System.Drawing.Size(180, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox acTxt;
        public System.Windows.Forms.ListBox acBox;
    }
}
