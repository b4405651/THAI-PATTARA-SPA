namespace SPA_MANAGEMENT_SYSTEM.VIP_CARD
{
    partial class vip_card_void
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
            this.code_end = new System.Windows.Forms.TextBox();
            this.code_end_lbl = new System.Windows.Forms.Label();
            this.code_begin = new System.Windows.Forms.TextBox();
            this.code_begin_lbl = new System.Windows.Forms.Label();
            this.reason = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.manage_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // code_end
            // 
            this.code_end.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.code_end.Location = new System.Drawing.Point(137, 33);
            this.code_end.Name = "code_end";
            this.code_end.Size = new System.Drawing.Size(178, 24);
            this.code_end.TabIndex = 2;
            this.code_end.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.code_end_KeyPress);
            // 
            // code_end_lbl
            // 
            this.code_end_lbl.AutoSize = true;
            this.code_end_lbl.BackColor = System.Drawing.Color.Transparent;
            this.code_end_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.code_end_lbl.Location = new System.Drawing.Point(12, 36);
            this.code_end_lbl.Name = "code_end_lbl";
            this.code_end_lbl.Size = new System.Drawing.Size(106, 18);
            this.code_end_lbl.TabIndex = 42;
            this.code_end_lbl.Text = "CODE END :";
            // 
            // code_begin
            // 
            this.code_begin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.code_begin.Location = new System.Drawing.Point(137, 6);
            this.code_begin.Name = "code_begin";
            this.code_begin.Size = new System.Drawing.Size(178, 24);
            this.code_begin.TabIndex = 1;
            this.code_begin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.code_begin_KeyPress);
            // 
            // code_begin_lbl
            // 
            this.code_begin_lbl.AutoSize = true;
            this.code_begin_lbl.BackColor = System.Drawing.Color.Transparent;
            this.code_begin_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.code_begin_lbl.Location = new System.Drawing.Point(12, 9);
            this.code_begin_lbl.Name = "code_begin_lbl";
            this.code_begin_lbl.Size = new System.Drawing.Size(122, 18);
            this.code_begin_lbl.TabIndex = 41;
            this.code_begin_lbl.Text = "CODE BEGIN :";
            // 
            // reason
            // 
            this.reason.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.reason.Location = new System.Drawing.Point(137, 60);
            this.reason.Name = "reason";
            this.reason.Size = new System.Drawing.Size(178, 24);
            this.reason.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 18);
            this.label1.TabIndex = 44;
            this.label1.Text = "REASON :";
            // 
            // manage_btn
            // 
            this.manage_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.manage_btn.FlatAppearance.BorderSize = 0;
            this.manage_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manage_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.manage_btn.Location = new System.Drawing.Point(212, 90);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(101, 59);
            this.manage_btn.TabIndex = 45;
            this.manage_btn.Text = "VOID";
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // vip_card_void
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(322, 155);
            this.Controls.Add(this.manage_btn);
            this.Controls.Add(this.reason);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.code_end);
            this.Controls.Add(this.code_end_lbl);
            this.Controls.Add(this.code_begin);
            this.Controls.Add(this.code_begin_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "vip_card_void";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VOID SPECIAL CARD SET";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.vip_card_void_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox code_end;
        private System.Windows.Forms.Label code_end_lbl;
        private System.Windows.Forms.TextBox code_begin;
        private System.Windows.Forms.Label code_begin_lbl;
        private System.Windows.Forms.TextBox reason;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button manage_btn;
    }
}