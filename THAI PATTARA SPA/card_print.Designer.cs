namespace SPA_MANAGEMENT_SYSTEM
{
    partial class card_print
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
            this.print_card2_btn = new System.Windows.Forms.Button();
            this.print_card1_btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.attach_paper_btn = new System.Windows.Forms.Button();
            this.instruction_lbl = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // print_card2_btn
            // 
            this.print_card2_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.print_card2_btn.CausesValidation = false;
            this.print_card2_btn.FlatAppearance.BorderSize = 0;
            this.print_card2_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.print_card2_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.print_card2_btn.Location = new System.Drawing.Point(133, 23);
            this.print_card2_btn.Name = "print_card2_btn";
            this.print_card2_btn.Size = new System.Drawing.Size(101, 59);
            this.print_card2_btn.TabIndex = 2;
            this.print_card2_btn.Text = "CARD2";
            this.print_card2_btn.UseVisualStyleBackColor = false;
            this.print_card2_btn.Click += new System.EventHandler(this.print_card2_btn_Click);
            // 
            // print_card1_btn
            // 
            this.print_card1_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.print_card1_btn.FlatAppearance.BorderSize = 0;
            this.print_card1_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.print_card1_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.print_card1_btn.Location = new System.Drawing.Point(17, 23);
            this.print_card1_btn.Name = "print_card1_btn";
            this.print_card1_btn.Size = new System.Drawing.Size(101, 59);
            this.print_card1_btn.TabIndex = 1;
            this.print_card1_btn.Text = "CARD1";
            this.print_card1_btn.UseVisualStyleBackColor = false;
            this.print_card1_btn.Click += new System.EventHandler(this.print_card1_btn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.attach_paper_btn);
            this.groupBox1.Controls.Add(this.print_card1_btn);
            this.groupBox1.Controls.Add(this.print_card2_btn);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 175);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PRINT CARD";
            // 
            // attach_paper_btn
            // 
            this.attach_paper_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.attach_paper_btn.FlatAppearance.BorderSize = 0;
            this.attach_paper_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.attach_paper_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.attach_paper_btn.Location = new System.Drawing.Point(17, 96);
            this.attach_paper_btn.Name = "attach_paper_btn";
            this.attach_paper_btn.Size = new System.Drawing.Size(217, 59);
            this.attach_paper_btn.TabIndex = 3;
            this.attach_paper_btn.Text = "ATTACH PAPER";
            this.attach_paper_btn.UseVisualStyleBackColor = false;
            this.attach_paper_btn.Click += new System.EventHandler(this.attach_paper_btn_Click);
            // 
            // instruction_lbl
            // 
            this.instruction_lbl.BackColor = System.Drawing.Color.Transparent;
            this.instruction_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.instruction_lbl.Location = new System.Drawing.Point(12, 190);
            this.instruction_lbl.Name = "instruction_lbl";
            this.instruction_lbl.Size = new System.Drawing.Size(253, 78);
            this.instruction_lbl.TabIndex = 11;
            this.instruction_lbl.Text = "** AFTER YOU CLICKED EVERY BUTTON TO PRINT. THIS WINDOW WILL BE CLOSED AUTOMATICA" +
    "LLY **";
            this.instruction_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // card_print
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(280, 271);
            this.Controls.Add(this.instruction_lbl);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "card_print";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PRINT CARD";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.card_print_FormClosing);
            this.Load += new System.EventHandler(this.card_print_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button print_card2_btn;
        public System.Windows.Forms.Button print_card1_btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label instruction_lbl;
        public System.Windows.Forms.Button attach_paper_btn;
    }
}