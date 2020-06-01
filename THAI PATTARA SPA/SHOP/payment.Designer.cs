namespace SPA_MANAGEMENT_SYSTEM.SHOP
{
    partial class payment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(payment));
            this.grand_total_lbl = new System.Windows.Forms.Label();
            this.grand_total = new System.Windows.Forms.Label();
            this.receive_lbl = new System.Windows.Forms.Label();
            this.receive = new System.Windows.Forms.TextBox();
            this.change_lbl = new System.Windows.Forms.Label();
            this.change = new System.Windows.Forms.Label();
            this.debtor_info = new System.Windows.Forms.GroupBox();
            this.debtor_id = new SPA_MANAGEMENT_SYSTEM.customAutoComplete();
            this.debtor_id_lbl = new System.Windows.Forms.Label();
            this.credit_card_info = new System.Windows.Forms.GroupBox();
            this.visa_rd = new System.Windows.Forms.RadioButton();
            this.mastercard_rd = new System.Windows.Forms.RadioButton();
            this.credit_card_no = new System.Windows.Forms.MaskedTextBox();
            this.debtor_info.SuspendLayout();
            this.credit_card_info.SuspendLayout();
            this.SuspendLayout();
            // 
            // grand_total_lbl
            // 
            this.grand_total_lbl.AutoSize = true;
            this.grand_total_lbl.BackColor = System.Drawing.Color.Transparent;
            this.grand_total_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.grand_total_lbl.Location = new System.Drawing.Point(215, 9);
            this.grand_total_lbl.Name = "grand_total_lbl";
            this.grand_total_lbl.Size = new System.Drawing.Size(177, 26);
            this.grand_total_lbl.TabIndex = 70;
            this.grand_total_lbl.Text = "GRAND TOTAL";
            this.grand_total_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // grand_total
            // 
            this.grand_total.BackColor = System.Drawing.Color.Transparent;
            this.grand_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 27F, System.Drawing.FontStyle.Bold);
            this.grand_total.ForeColor = System.Drawing.Color.White;
            this.grand_total.Location = new System.Drawing.Point(126, 44);
            this.grand_total.Name = "grand_total";
            this.grand_total.Size = new System.Drawing.Size(284, 40);
            this.grand_total.TabIndex = 69;
            this.grand_total.Text = "GRAND TOTAL";
            this.grand_total.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // receive_lbl
            // 
            this.receive_lbl.AutoSize = true;
            this.receive_lbl.BackColor = System.Drawing.Color.Transparent;
            this.receive_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.receive_lbl.Location = new System.Drawing.Point(275, 111);
            this.receive_lbl.Name = "receive_lbl";
            this.receive_lbl.Size = new System.Drawing.Size(117, 26);
            this.receive_lbl.TabIndex = 71;
            this.receive_lbl.Text = "RECEIVE";
            this.receive_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // receive
            // 
            this.receive.Font = new System.Drawing.Font("Microsoft Sans Serif", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.receive.Location = new System.Drawing.Point(12, 146);
            this.receive.Name = "receive";
            this.receive.Size = new System.Drawing.Size(393, 48);
            this.receive.TabIndex = 1;
            this.receive.Text = "0";
            this.receive.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.receive.TextChanged += new System.EventHandler(this.receive_TextChanged);
            this.receive.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.receive_KeyPress);
            this.receive.KeyUp += new System.Windows.Forms.KeyEventHandler(this.receive_KeyUp);
            // 
            // change_lbl
            // 
            this.change_lbl.AutoSize = true;
            this.change_lbl.BackColor = System.Drawing.Color.Transparent;
            this.change_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.change_lbl.Location = new System.Drawing.Point(279, 230);
            this.change_lbl.Name = "change_lbl";
            this.change_lbl.Size = new System.Drawing.Size(113, 26);
            this.change_lbl.TabIndex = 73;
            this.change_lbl.Text = "CHANGE";
            this.change_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // change
            // 
            this.change.BackColor = System.Drawing.Color.Transparent;
            this.change.Font = new System.Drawing.Font("Microsoft Sans Serif", 27F, System.Drawing.FontStyle.Bold);
            this.change.ForeColor = System.Drawing.Color.White;
            this.change.Location = new System.Drawing.Point(126, 266);
            this.change.Name = "change";
            this.change.Size = new System.Drawing.Size(284, 40);
            this.change.TabIndex = 74;
            this.change.Text = "0.00";
            this.change.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // debtor_info
            // 
            this.debtor_info.Controls.Add(this.debtor_id);
            this.debtor_info.Controls.Add(this.debtor_id_lbl);
            this.debtor_info.Location = new System.Drawing.Point(12, 309);
            this.debtor_info.Name = "debtor_info";
            this.debtor_info.Size = new System.Drawing.Size(393, 66);
            this.debtor_info.TabIndex = 0;
            this.debtor_info.TabStop = false;
            // 
            // debtor_id
            // 
            this.debtor_id.currentID = -1;
            this.debtor_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.debtor_id.Location = new System.Drawing.Point(136, 24);
            this.debtor_id.Mode = "DEBTOR";
            this.debtor_id.Name = "debtor_id";
            this.debtor_id.Size = new System.Drawing.Size(178, 24);
            this.debtor_id.TabIndex = 75;
            this.debtor_id.Tag = "";
            // 
            // debtor_id_lbl
            // 
            this.debtor_id_lbl.AutoSize = true;
            this.debtor_id_lbl.BackColor = System.Drawing.Color.Transparent;
            this.debtor_id_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.debtor_id_lbl.Location = new System.Drawing.Point(44, 25);
            this.debtor_id_lbl.Name = "debtor_id_lbl";
            this.debtor_id_lbl.Size = new System.Drawing.Size(92, 18);
            this.debtor_id_lbl.TabIndex = 77;
            this.debtor_id_lbl.Text = "DEBTOR : ";
            // 
            // credit_card_info
            // 
            this.credit_card_info.Controls.Add(this.visa_rd);
            this.credit_card_info.Controls.Add(this.mastercard_rd);
            this.credit_card_info.Controls.Add(this.credit_card_no);
            this.credit_card_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.credit_card_info.Location = new System.Drawing.Point(17, 331);
            this.credit_card_info.Name = "credit_card_info";
            this.credit_card_info.Size = new System.Drawing.Size(380, 151);
            this.credit_card_info.TabIndex = 76;
            this.credit_card_info.TabStop = false;
            // 
            // visa_rd
            // 
            this.visa_rd.Image = ((System.Drawing.Image)(resources.GetObject("visa_rd.Image")));
            this.visa_rd.Location = new System.Drawing.Point(203, 83);
            this.visa_rd.Name = "visa_rd";
            this.visa_rd.Size = new System.Drawing.Size(104, 60);
            this.visa_rd.TabIndex = 4;
            this.visa_rd.UseVisualStyleBackColor = true;
            this.visa_rd.CheckedChanged += new System.EventHandler(this.visa_rd_CheckedChanged);
            // 
            // mastercard_rd
            // 
            this.mastercard_rd.Image = ((System.Drawing.Image)(resources.GetObject("mastercard_rd.Image")));
            this.mastercard_rd.Location = new System.Drawing.Point(89, 83);
            this.mastercard_rd.Name = "mastercard_rd";
            this.mastercard_rd.Size = new System.Drawing.Size(108, 60);
            this.mastercard_rd.TabIndex = 3;
            this.mastercard_rd.TabStop = true;
            this.mastercard_rd.UseVisualStyleBackColor = true;
            this.mastercard_rd.CheckedChanged += new System.EventHandler(this.mastercard_rd_CheckedChanged);
            // 
            // credit_card_no
            // 
            this.credit_card_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.credit_card_no.Location = new System.Drawing.Point(26, 35);
            this.credit_card_no.Mask = "XXXX - XXXX -  XXXX - 0000";
            this.credit_card_no.Name = "credit_card_no";
            this.credit_card_no.Size = new System.Drawing.Size(328, 32);
            this.credit_card_no.TabIndex = 2;
            this.credit_card_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.credit_card_no.KeyUp += new System.Windows.Forms.KeyEventHandler(this.credit_card_no_KeyUp);
            // 
            // payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(416, 322);
            this.Controls.Add(this.change);
            this.Controls.Add(this.change_lbl);
            this.Controls.Add(this.receive);
            this.Controls.Add(this.receive_lbl);
            this.Controls.Add(this.grand_total_lbl);
            this.Controls.Add(this.grand_total);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "payment";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.payment_FormClosed);
            this.Load += new System.EventHandler(this.payment_Load);
            this.debtor_info.ResumeLayout(false);
            this.debtor_info.PerformLayout();
            this.credit_card_info.ResumeLayout(false);
            this.credit_card_info.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label grand_total_lbl;
        private System.Windows.Forms.Label receive_lbl;
        private System.Windows.Forms.Label change_lbl;
        public System.Windows.Forms.TextBox receive;
        public System.Windows.Forms.Label change;
        private System.Windows.Forms.GroupBox credit_card_info;
        private System.Windows.Forms.GroupBox debtor_info;
        private System.Windows.Forms.MaskedTextBox credit_card_no;
        private System.Windows.Forms.RadioButton mastercard_rd;
        private System.Windows.Forms.RadioButton visa_rd;
        public customAutoComplete debtor_id;
        private System.Windows.Forms.Label debtor_id_lbl;
        public System.Windows.Forms.Label grand_total;
    }
}