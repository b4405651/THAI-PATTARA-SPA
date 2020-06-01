namespace SPA_MANAGEMENT_SYSTEM
{
    partial class ac_data
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
            this.myAC = new SPA_MANAGEMENT_SYSTEM.autocomplete();
            this.SuspendLayout();
            // 
            // myAC
            // 
            this.myAC.BackColor = System.Drawing.Color.Transparent;
            this.myAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.myAC.Location = new System.Drawing.Point(0, 0);
            this.myAC.Name = "myAC";
            this.myAC.Size = new System.Drawing.Size(180, 30);
            this.myAC.TabIndex = 2;
            this.myAC.value = -1;
            this.myAC.textChanged += new SPA_MANAGEMENT_SYSTEM.autocomplete.textChangedHandler(this.myAC_textChanged);
            // 
            // ac_data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.myAC);
            this.Name = "ac_data";
            this.Size = new System.Drawing.Size(183, 33);
            this.ResumeLayout(false);

        }

        #endregion

        public autocomplete myAC;


    }
}
