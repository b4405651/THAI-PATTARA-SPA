namespace SPA_MANAGEMENT_SYSTEM.SHOP
{
    partial class register_gift_certificate
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
            this.choiceTab = new System.Windows.Forms.TabControl();
            this.spaTab = new System.Windows.Forms.TabPage();
            this.moneyTab = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.balance = new System.Windows.Forms.TextBox();
            this.balance_lbl = new System.Windows.Forms.Label();
            this.rub1_lbl = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.TextBox();
            this.amount_lbl = new System.Windows.Forms.Label();
            this.choiceTab.SuspendLayout();
            this.spaTab.SuspendLayout();
            this.moneyTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // card_no
            // 
            this.card_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.card_no.Location = new System.Drawing.Point(159, 152);
            this.card_no.Name = "card_no";
            this.card_no.Size = new System.Drawing.Size(178, 24);
            this.card_no.TabIndex = 5;
            this.card_no.KeyUp += new System.Windows.Forms.KeyEventHandler(this.card_no_KeyUp);
            // 
            // code_begin_lbl
            // 
            this.code_begin_lbl.AutoSize = true;
            this.code_begin_lbl.BackColor = System.Drawing.Color.Transparent;
            this.code_begin_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.code_begin_lbl.Location = new System.Drawing.Point(12, 155);
            this.code_begin_lbl.Name = "code_begin_lbl";
            this.code_begin_lbl.Size = new System.Drawing.Size(94, 18);
            this.code_begin_lbl.TabIndex = 41;
            this.code_begin_lbl.Text = "CARD NO :";
            // 
            // spa_program_id
            // 
            this.spa_program_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.spa_program_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.spa_program_id.FormattingEnabled = true;
            this.spa_program_id.Location = new System.Drawing.Point(155, 7);
            this.spa_program_id.Name = "spa_program_id";
            this.spa_program_id.Size = new System.Drawing.Size(179, 26);
            this.spa_program_id.TabIndex = 1;
            // 
            // spa_program_lbl
            // 
            this.spa_program_lbl.AutoSize = true;
            this.spa_program_lbl.BackColor = System.Drawing.Color.Transparent;
            this.spa_program_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.spa_program_lbl.Location = new System.Drawing.Point(6, 12);
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
            this.discount_unit.Location = new System.Drawing.Point(214, 36);
            this.discount_unit.Name = "discount_unit";
            this.discount_unit.Size = new System.Drawing.Size(71, 26);
            this.discount_unit.TabIndex = 3;
            // 
            // discount_amount
            // 
            this.discount_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.discount_amount.Location = new System.Drawing.Point(155, 37);
            this.discount_amount.Name = "discount_amount";
            this.discount_amount.Size = new System.Drawing.Size(57, 24);
            this.discount_amount.TabIndex = 2;
            this.discount_amount.Text = "100";
            this.discount_amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.discount_amount_KeyPress);
            // 
            // discount_lbl
            // 
            this.discount_lbl.AutoSize = true;
            this.discount_lbl.BackColor = System.Drawing.Color.Transparent;
            this.discount_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.discount_lbl.Location = new System.Drawing.Point(6, 40);
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
            this.expiry_date.Location = new System.Drawing.Point(160, 124);
            this.expiry_date.Name = "expiry_date";
            this.expiry_date.Size = new System.Drawing.Size(124, 24);
            this.expiry_date.TabIndex = 4;
            // 
            // expiry_date_lbl
            // 
            this.expiry_date_lbl.AutoSize = true;
            this.expiry_date_lbl.BackColor = System.Drawing.Color.Transparent;
            this.expiry_date_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.expiry_date_lbl.Location = new System.Drawing.Point(12, 127);
            this.expiry_date_lbl.Name = "expiry_date_lbl";
            this.expiry_date_lbl.Size = new System.Drawing.Size(130, 18);
            this.expiry_date_lbl.TabIndex = 126;
            this.expiry_date_lbl.Text = "EXPIRY DATE : ";
            // 
            // choiceTab
            // 
            this.choiceTab.Controls.Add(this.spaTab);
            this.choiceTab.Controls.Add(this.moneyTab);
            this.choiceTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.choiceTab.Location = new System.Drawing.Point(12, 12);
            this.choiceTab.Name = "choiceTab";
            this.choiceTab.SelectedIndex = 0;
            this.choiceTab.Size = new System.Drawing.Size(351, 105);
            this.choiceTab.TabIndex = 127;
            this.choiceTab.SelectedIndexChanged += new System.EventHandler(this.choiceTab_SelectedIndexChanged);
            // 
            // spaTab
            // 
            this.spaTab.Controls.Add(this.spa_program_lbl);
            this.spaTab.Controls.Add(this.spa_program_id);
            this.spaTab.Controls.Add(this.discount_lbl);
            this.spaTab.Controls.Add(this.discount_unit);
            this.spaTab.Controls.Add(this.discount_amount);
            this.spaTab.Location = new System.Drawing.Point(4, 27);
            this.spaTab.Name = "spaTab";
            this.spaTab.Padding = new System.Windows.Forms.Padding(3);
            this.spaTab.Size = new System.Drawing.Size(343, 74);
            this.spaTab.TabIndex = 0;
            this.spaTab.Text = "Spa Program";
            this.spaTab.UseVisualStyleBackColor = true;
            // 
            // moneyTab
            // 
            this.moneyTab.Controls.Add(this.label1);
            this.moneyTab.Controls.Add(this.balance);
            this.moneyTab.Controls.Add(this.balance_lbl);
            this.moneyTab.Controls.Add(this.rub1_lbl);
            this.moneyTab.Controls.Add(this.price);
            this.moneyTab.Controls.Add(this.amount_lbl);
            this.moneyTab.Location = new System.Drawing.Point(4, 27);
            this.moneyTab.Name = "moneyTab";
            this.moneyTab.Padding = new System.Windows.Forms.Padding(3);
            this.moneyTab.Size = new System.Drawing.Size(343, 74);
            this.moneyTab.TabIndex = 1;
            this.moneyTab.Text = "Money";
            this.moneyTab.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(228, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 18);
            this.label1.TabIndex = 47;
            this.label1.Text = "Rub.";
            // 
            // balance
            // 
            this.balance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.balance.Location = new System.Drawing.Point(99, 38);
            this.balance.Name = "balance";
            this.balance.Size = new System.Drawing.Size(123, 24);
            this.balance.TabIndex = 45;
            this.balance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.balance_KeyPress);
            // 
            // balance_lbl
            // 
            this.balance_lbl.AutoSize = true;
            this.balance_lbl.BackColor = System.Drawing.Color.Transparent;
            this.balance_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.balance_lbl.Location = new System.Drawing.Point(6, 41);
            this.balance_lbl.Name = "balance_lbl";
            this.balance_lbl.Size = new System.Drawing.Size(93, 18);
            this.balance_lbl.TabIndex = 46;
            this.balance_lbl.Text = "BALANCE :";
            // 
            // rub1_lbl
            // 
            this.rub1_lbl.AutoSize = true;
            this.rub1_lbl.BackColor = System.Drawing.Color.Transparent;
            this.rub1_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rub1_lbl.Location = new System.Drawing.Point(228, 12);
            this.rub1_lbl.Name = "rub1_lbl";
            this.rub1_lbl.Size = new System.Drawing.Size(43, 18);
            this.rub1_lbl.TabIndex = 44;
            this.rub1_lbl.Text = "Rub.";
            // 
            // price
            // 
            this.price.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.price.Location = new System.Drawing.Point(99, 9);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(123, 24);
            this.price.TabIndex = 42;
            this.price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.price_KeyPress);
            this.price.Leave += new System.EventHandler(this.price_Leave);
            // 
            // amount_lbl
            // 
            this.amount_lbl.AutoSize = true;
            this.amount_lbl.BackColor = System.Drawing.Color.Transparent;
            this.amount_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.amount_lbl.Location = new System.Drawing.Point(6, 12);
            this.amount_lbl.Name = "amount_lbl";
            this.amount_lbl.Size = new System.Drawing.Size(68, 18);
            this.amount_lbl.TabIndex = 43;
            this.amount_lbl.Text = "PRICE :";
            // 
            // register_gift_certificate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(377, 187);
            this.Controls.Add(this.choiceTab);
            this.Controls.Add(this.expiry_date);
            this.Controls.Add(this.expiry_date_lbl);
            this.Controls.Add(this.card_no);
            this.Controls.Add(this.code_begin_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "register_gift_certificate";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REGISTER GIFT CERTIFICATE";
            this.Load += new System.EventHandler(this.register_gift_certificate_Load);
            this.choiceTab.ResumeLayout(false);
            this.spaTab.ResumeLayout(false);
            this.spaTab.PerformLayout();
            this.moneyTab.ResumeLayout(false);
            this.moneyTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox card_no;
        private System.Windows.Forms.Label code_begin_lbl;
        public System.Windows.Forms.ComboBox spa_program_id;
        private System.Windows.Forms.Label spa_program_lbl;
        public System.Windows.Forms.ComboBox discount_unit;
        private System.Windows.Forms.TextBox discount_amount;
        private System.Windows.Forms.Label discount_lbl;
        public System.Windows.Forms.DateTimePicker expiry_date;
        private System.Windows.Forms.Label expiry_date_lbl;
        private System.Windows.Forms.TabPage spaTab;
        private System.Windows.Forms.TabPage moneyTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox balance;
        private System.Windows.Forms.Label balance_lbl;
        private System.Windows.Forms.Label rub1_lbl;
        private System.Windows.Forms.TextBox price;
        private System.Windows.Forms.Label amount_lbl;
        public System.Windows.Forms.TabControl choiceTab;
    }
}