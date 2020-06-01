namespace SPA_MANAGEMENT_SYSTEM.SHOP
{
    partial class item_amount
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
            this.amount = new System.Windows.Forms.TextBox();
            this.amount_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // amount
            // 
            this.amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.amount.Location = new System.Drawing.Point(106, 6);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(45, 24);
            this.amount.TabIndex = 1;
            this.amount.Tag = "";
            this.amount.Text = "1";
            this.amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.amount_KeyPress);
            this.amount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.amount_KeyUp);
            // 
            // amount_lbl
            // 
            this.amount_lbl.AutoSize = true;
            this.amount_lbl.BackColor = System.Drawing.Color.Transparent;
            this.amount_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.amount_lbl.Location = new System.Drawing.Point(12, 9);
            this.amount_lbl.Name = "amount_lbl";
            this.amount_lbl.Size = new System.Drawing.Size(94, 18);
            this.amount_lbl.TabIndex = 93;
            this.amount_lbl.Text = "AMOUNT : ";
            // 
            // item_amount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(173, 39);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.amount_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "item_amount";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AMOUNT OF ITEM";
            this.TopMost = true;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.item_amount_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label amount_lbl;
        public System.Windows.Forms.TextBox amount;
    }
}