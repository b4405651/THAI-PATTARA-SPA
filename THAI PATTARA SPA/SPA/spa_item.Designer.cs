namespace SPA_MANAGEMENT_SYSTEM.SPA
{
    partial class spa_item
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
            this.item_detail_lbl = new System.Windows.Forms.Label();
            this.item_code = new System.Windows.Forms.TextBox();
            this.item_code_lbl = new System.Windows.Forms.Label();
            this.btn_dgv = new SPA_MANAGEMENT_SYSTEM.btn_dgv();
            this.line_sep = new SPA_MANAGEMENT_SYSTEM.line_sep();
            this.SuspendLayout();
            // 
            // item_detail_lbl
            // 
            this.item_detail_lbl.AutoSize = true;
            this.item_detail_lbl.BackColor = System.Drawing.Color.Transparent;
            this.item_detail_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_detail_lbl.Location = new System.Drawing.Point(310, 9);
            this.item_detail_lbl.Name = "item_detail_lbl";
            this.item_detail_lbl.Size = new System.Drawing.Size(123, 18);
            this.item_detail_lbl.TabIndex = 54;
            this.item_detail_lbl.Text = "ITEM DETAIL : ";
            // 
            // item_code
            // 
            this.item_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_code.Location = new System.Drawing.Point(126, 6);
            this.item_code.Name = "item_code";
            this.item_code.Size = new System.Drawing.Size(178, 24);
            this.item_code.TabIndex = 1;
            this.item_code.Tag = "barcode";
            this.item_code.TextChanged += new System.EventHandler(this.item_code_TextChanged);
            this.item_code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.item_code_KeyDown);
            // 
            // item_code_lbl
            // 
            this.item_code_lbl.AutoSize = true;
            this.item_code_lbl.BackColor = System.Drawing.Color.Transparent;
            this.item_code_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_code_lbl.Location = new System.Drawing.Point(12, 9);
            this.item_code_lbl.Name = "item_code_lbl";
            this.item_code_lbl.Size = new System.Drawing.Size(115, 18);
            this.item_code_lbl.TabIndex = 53;
            this.item_code_lbl.Text = "ITEM CODE : ";
            // 
            // btn_dgv
            // 
            this.btn_dgv.AutoSize = true;
            this.btn_dgv.BackColor = System.Drawing.Color.Transparent;
            this.btn_dgv.Location = new System.Drawing.Point(15, 44);
            this.btn_dgv.Name = "btn_dgv";
            this.btn_dgv.preventDGVSelectionChanged = false;
            this.btn_dgv.Size = new System.Drawing.Size(1349, 645);
            this.btn_dgv.TabIndex = 2;
            // 
            // line_sep
            // 
            this.line_sep.BackColor = System.Drawing.Color.Transparent;
            this.line_sep.Location = new System.Drawing.Point(15, 36);
            this.line_sep.MaximumSize = new System.Drawing.Size(2000, 2);
            this.line_sep.MinimumSize = new System.Drawing.Size(0, 2);
            this.line_sep.Name = "line_sep";
            this.line_sep.Size = new System.Drawing.Size(350, 2);
            this.line_sep.TabIndex = 55;
            // 
            // selling_price
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(696, 566);
            this.ControlBox = false;
            this.Controls.Add(this.btn_dgv);
            this.Controls.Add(this.line_sep);
            this.Controls.Add(this.item_detail_lbl);
            this.Controls.Add(this.item_code);
            this.Controls.Add(this.item_code_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "spa_item";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "spa_item";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.doLoadGridData);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label item_detail_lbl;
        private System.Windows.Forms.TextBox item_code;
        private System.Windows.Forms.Label item_code_lbl;
        private line_sep line_sep;
        private btn_dgv btn_dgv;
    }
}