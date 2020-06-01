namespace SPA_MANAGEMENT_SYSTEM.COUPON
{
    partial class register_coupon
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
            this.code_begin_lbl = new System.Windows.Forms.Label();
            this.spa_program_id = new System.Windows.Forms.ComboBox();
            this.spa_program_lbl = new System.Windows.Forms.Label();
            this.discount_unit = new System.Windows.Forms.ComboBox();
            this.discount_amount = new System.Windows.Forms.TextBox();
            this.discount_lbl = new System.Windows.Forms.Label();
            this.expiry_date = new System.Windows.Forms.DateTimePicker();
            this.expiry_date_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // card_no
            // 
            this.card_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.card_no.Location = new System.Drawing.Point(159, 91);
            this.card_no.Name = "card_no";
            this.card_no.Size = new System.Drawing.Size(300, 24);
            this.card_no.TabIndex = 5;
            this.card_no.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.card_no_KeyPress);
            this.card_no.KeyUp += new System.Windows.Forms.KeyEventHandler(this.card_no_KeyUp);
            // 
            // code_begin_lbl
            // 
            this.code_begin_lbl.AutoSize = true;
            this.code_begin_lbl.BackColor = System.Drawing.Color.Transparent;
            this.code_begin_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.code_begin_lbl.Location = new System.Drawing.Point(12, 94);
            this.code_begin_lbl.Name = "code_begin_lbl";
            this.code_begin_lbl.Size = new System.Drawing.Size(94, 18);
            this.code_begin_lbl.TabIndex = 41;
            this.code_begin_lbl.Text = "CARD NO :";
            // 
            // spa_program_id
            // 
            this.spa_program_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.spa_program_id.Enabled = false;
            this.spa_program_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.spa_program_id.FormattingEnabled = true;
            this.spa_program_id.Location = new System.Drawing.Point(161, 4);
            this.spa_program_id.Name = "spa_program_id";
            this.spa_program_id.Size = new System.Drawing.Size(298, 26);
            this.spa_program_id.TabIndex = 1;
            // 
            // spa_program_lbl
            // 
            this.spa_program_lbl.AutoSize = true;
            this.spa_program_lbl.BackColor = System.Drawing.Color.Transparent;
            this.spa_program_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.spa_program_lbl.Location = new System.Drawing.Point(12, 9);
            this.spa_program_lbl.Name = "spa_program_lbl";
            this.spa_program_lbl.Size = new System.Drawing.Size(145, 18);
            this.spa_program_lbl.TabIndex = 76;
            this.spa_program_lbl.Text = "SPA PROGRAM : ";
            // 
            // discount_unit
            // 
            this.discount_unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.discount_unit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.discount_unit.FormattingEnabled = true;
            this.discount_unit.Location = new System.Drawing.Point(244, 33);
            this.discount_unit.Name = "discount_unit";
            this.discount_unit.Size = new System.Drawing.Size(71, 26);
            this.discount_unit.TabIndex = 3;
            // 
            // discount_amount
            // 
            this.discount_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.discount_amount.Location = new System.Drawing.Point(161, 34);
            this.discount_amount.Name = "discount_amount";
            this.discount_amount.Size = new System.Drawing.Size(77, 24);
            this.discount_amount.TabIndex = 2;
            this.discount_amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.discount_amount_KeyPress);
            // 
            // discount_lbl
            // 
            this.discount_lbl.AutoSize = true;
            this.discount_lbl.BackColor = System.Drawing.Color.Transparent;
            this.discount_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.discount_lbl.Location = new System.Drawing.Point(12, 37);
            this.discount_lbl.Name = "discount_lbl";
            this.discount_lbl.Size = new System.Drawing.Size(109, 18);
            this.discount_lbl.TabIndex = 124;
            this.discount_lbl.Text = "DISCOUNT : ";
            // 
            // expiry_date
            // 
            this.expiry_date.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.expiry_date.CustomFormat = "dd/MM/yyyy";
            this.expiry_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.expiry_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.expiry_date.Location = new System.Drawing.Point(160, 63);
            this.expiry_date.Name = "expiry_date";
            this.expiry_date.Size = new System.Drawing.Size(124, 24);
            this.expiry_date.TabIndex = 4;
            // 
            // expiry_date_lbl
            // 
            this.expiry_date_lbl.AutoSize = true;
            this.expiry_date_lbl.BackColor = System.Drawing.Color.Transparent;
            this.expiry_date_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.expiry_date_lbl.Location = new System.Drawing.Point(12, 66);
            this.expiry_date_lbl.Name = "expiry_date_lbl";
            this.expiry_date_lbl.Size = new System.Drawing.Size(130, 18);
            this.expiry_date_lbl.TabIndex = 126;
            this.expiry_date_lbl.Text = "EXPIRY DATE : ";
            // 
            // register_coupon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(471, 121);
            this.Controls.Add(this.expiry_date);
            this.Controls.Add(this.expiry_date_lbl);
            this.Controls.Add(this.discount_unit);
            this.Controls.Add(this.discount_amount);
            this.Controls.Add(this.discount_lbl);
            this.Controls.Add(this.spa_program_id);
            this.Controls.Add(this.spa_program_lbl);
            this.Controls.Add(this.card_no);
            this.Controls.Add(this.code_begin_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "register_coupon";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REGISTER COUPON";
            this.Load += new System.EventHandler(this.register_coupon_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox card_no;
        private System.Windows.Forms.Label code_begin_lbl;
        public System.Windows.Forms.ComboBox spa_program_id;
        private System.Windows.Forms.Label spa_program_lbl;
        public System.Windows.Forms.ComboBox discount_unit;
        private System.Windows.Forms.Label discount_lbl;
        public System.Windows.Forms.DateTimePicker expiry_date;
        private System.Windows.Forms.Label expiry_date_lbl;
        public System.Windows.Forms.TextBox discount_amount;
    }
}