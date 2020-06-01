namespace SPA_MANAGEMENT_SYSTEM
{
    partial class date_data
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
            this.my_date = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // my_date
            // 
            this.my_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.my_date.Location = new System.Drawing.Point(0, 0);
            this.my_date.Mask = "00000000";
            this.my_date.Name = "my_date";
            this.my_date.Size = new System.Drawing.Size(94, 24);
            this.my_date.TabIndex = 4;
            this.my_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.my_date.ValidatingType = typeof(System.DateTime);
            this.my_date.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.my_date_TypeValidationCompleted);
            this.my_date.TextChanged += new System.EventHandler(this.my_date_TextChanged);
            this.my_date.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.my_date_KeyPress);
            this.my_date.KeyUp += new System.Windows.Forms.KeyEventHandler(this.my_date_KeyUp);
            // 
            // date_data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.my_date);
            this.Name = "date_data";
            this.Size = new System.Drawing.Size(94, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MaskedTextBox my_date;

    }
}
