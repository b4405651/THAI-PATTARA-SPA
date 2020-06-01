namespace SPA_MANAGEMENT_SYSTEM.USER_CONTROL
{
    partial class print_report
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
            this.print_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // print_btn
            // 
            this.print_btn.AutoSize = true;
            this.print_btn.FlatAppearance.BorderSize = 0;
            this.print_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.print_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.print_btn.Image = global::SPA_MANAGEMENT_SYSTEM.Properties.Resources.print;
            this.print_btn.Location = new System.Drawing.Point(0, 0);
            this.print_btn.Name = "print_btn";
            this.print_btn.Size = new System.Drawing.Size(32, 28);
            this.print_btn.TabIndex = 52;
            this.print_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.print_btn.UseVisualStyleBackColor = false;
            this.print_btn.Click += new System.EventHandler(this.print_btn_Click);
            // 
            // print_report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.print_btn);
            this.Name = "print_report";
            this.Size = new System.Drawing.Size(32, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button print_btn;
    }
}
