namespace SPA_MANAGEMENT_SYSTEM.USER_CONTROL
{
    partial class time_data
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
            this.my_time = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // my_time
            // 
            this.my_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.my_time.Location = new System.Drawing.Point(0, 0);
            this.my_time.Mask = "00:00";
            this.my_time.Name = "my_time";
            this.my_time.Size = new System.Drawing.Size(50, 24);
            this.my_time.TabIndex = 2;
            this.my_time.ValidatingType = typeof(System.DateTime);
            this.my_time.TextChanged += new System.EventHandler(this.my_time_TextChanged);
            // 
            // time_data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.my_time);
            this.Name = "time_data";
            this.Size = new System.Drawing.Size(50, 24);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.time_data_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox my_time;
    }
}
