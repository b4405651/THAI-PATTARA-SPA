namespace SPA_MANAGEMENT_SYSTEM.RESERVATION
{
    partial class barcode_program_search
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
            this.card_no = new System.Windows.Forms.TextBox();
            this.ref_no_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // card_no
            // 
            this.card_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.card_no.Location = new System.Drawing.Point(102, 5);
            this.card_no.Name = "card_no";
            this.card_no.Size = new System.Drawing.Size(212, 24);
            this.card_no.TabIndex = 1;
            this.card_no.KeyUp += new System.Windows.Forms.KeyEventHandler(this.card_no_KeyUp);
            // 
            // ref_no_lbl
            // 
            this.ref_no_lbl.AutoSize = true;
            this.ref_no_lbl.BackColor = System.Drawing.Color.Transparent;
            this.ref_no_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ref_no_lbl.Location = new System.Drawing.Point(5, 8);
            this.ref_no_lbl.Name = "ref_no_lbl";
            this.ref_no_lbl.Size = new System.Drawing.Size(99, 18);
            this.ref_no_lbl.TabIndex = 61;
            this.ref_no_lbl.Text = "CARD NO : ";
            // 
            // barcode_program_search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(323, 34);
            this.Controls.Add(this.card_no);
            this.Controls.Add(this.ref_no_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "barcode_program_search";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SEARCH BY BARCODE";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox card_no;
        private System.Windows.Forms.Label ref_no_lbl;
    }
}