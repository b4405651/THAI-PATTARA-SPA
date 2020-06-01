namespace SPA_MANAGEMENT_SYSTEM.AGENT
{
    partial class contract_rate_detail
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
            this.save_btn = new System.Windows.Forms.Button();
            this.contract_rate_data_panel = new System.Windows.Forms.Panel();
            this.end_date = new SPA_MANAGEMENT_SYSTEM.date_data();
            this.label1 = new System.Windows.Forms.Label();
            this.start_date = new SPA_MANAGEMENT_SYSTEM.date_data();
            this.start_date_lbl = new System.Windows.Forms.Label();
            this.btn_dgv = new SPA_MANAGEMENT_SYSTEM.btn_dgv();
            this.contract_rate_data_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // save_btn
            // 
            this.save_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.save_btn.FlatAppearance.BorderSize = 0;
            this.save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.save_btn.Location = new System.Drawing.Point(10, 7);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(109, 50);
            this.save_btn.TabIndex = 9999;
            this.save_btn.Text = "SAVE";
            this.save_btn.UseVisualStyleBackColor = false;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // contract_rate_data_panel
            // 
            this.contract_rate_data_panel.Controls.Add(this.end_date);
            this.contract_rate_data_panel.Controls.Add(this.label1);
            this.contract_rate_data_panel.Controls.Add(this.start_date);
            this.contract_rate_data_panel.Controls.Add(this.start_date_lbl);
            this.contract_rate_data_panel.Location = new System.Drawing.Point(125, 7);
            this.contract_rate_data_panel.Name = "contract_rate_data_panel";
            this.contract_rate_data_panel.Size = new System.Drawing.Size(494, 50);
            this.contract_rate_data_panel.TabIndex = 1006;
            // 
            // end_date
            // 
            this.end_date.Location = new System.Drawing.Point(372, 13);
            this.end_date.Name = "end_date";
            this.end_date.Size = new System.Drawing.Size(94, 24);
            this.end_date.TabIndex = 1015;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(267, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 18);
            this.label1.TabIndex = 1014;
            this.label1.Text = "END DATE :";
            // 
            // start_date
            // 
            this.start_date.Location = new System.Drawing.Point(143, 13);
            this.start_date.Name = "start_date";
            this.start_date.Size = new System.Drawing.Size(94, 24);
            this.start_date.TabIndex = 1013;
            // 
            // start_date_lbl
            // 
            this.start_date_lbl.AutoSize = true;
            this.start_date_lbl.BackColor = System.Drawing.Color.Transparent;
            this.start_date_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.start_date_lbl.Location = new System.Drawing.Point(18, 16);
            this.start_date_lbl.Name = "start_date_lbl";
            this.start_date_lbl.Size = new System.Drawing.Size(119, 18);
            this.start_date_lbl.TabIndex = 1006;
            this.start_date_lbl.Text = "START DATE :";
            // 
            // btn_dgv
            // 
            this.btn_dgv.Location = new System.Drawing.Point(10, 63);
            this.btn_dgv.Name = "btn_dgv";
            this.btn_dgv.preventDGVSelectionChanged = false;
            this.btn_dgv.Size = new System.Drawing.Size(882, 518);
            this.btn_dgv.TabIndex = 10000;
            // 
            // contract_rate_detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(904, 593);
            this.Controls.Add(this.btn_dgv);
            this.Controls.Add(this.contract_rate_data_panel);
            this.Controls.Add(this.save_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "contract_rate_detail";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  MANAGE THE DETAIL OF CONTRACT RATE";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.contract_rate_detail_Load);
            this.contract_rate_data_panel.ResumeLayout(false);
            this.contract_rate_data_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Panel contract_rate_data_panel;
        private System.Windows.Forms.Label start_date_lbl;
        private System.Windows.Forms.Label label1;
        private btn_dgv btn_dgv;
        public date_data end_date;
        public date_data start_date;
    }
}