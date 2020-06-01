namespace SPA_MANAGEMENT_SYSTEM.COUPON
{
    partial class coupon_manage
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
            this.debtor_id_lbl = new System.Windows.Forms.Label();
            this.manage_btn = new System.Windows.Forms.Button();
            this.coupon_type_panel = new System.Windows.Forms.Panel();
            this.money_coupon_rb = new System.Windows.Forms.RadioButton();
            this.membercard_id = new System.Windows.Forms.ComboBox();
            this.membercard_rb = new System.Windows.Forms.RadioButton();
            this.line_sep1 = new SPA_MANAGEMENT_SYSTEM.line_sep();
            this.coupon_set = new System.Windows.Forms.ComboBox();
            this.coupon_set_rb = new System.Windows.Forms.RadioButton();
            this.simple_coupon_rb = new System.Windows.Forms.RadioButton();
            this.coupon_type_lbl = new System.Windows.Forms.Label();
            this.payment_panel = new System.Windows.Forms.Panel();
            this.personal_credit_rb = new System.Windows.Forms.RadioButton();
            this.payment_lbl = new System.Windows.Forms.Label();
            this.free = new System.Windows.Forms.RadioButton();
            this.debtor_id = new SPA_MANAGEMENT_SYSTEM.customAutoComplete();
            this.credit = new System.Windows.Forms.RadioButton();
            this.cash = new System.Windows.Forms.RadioButton();
            this.expiry_date = new System.Windows.Forms.DateTimePicker();
            this.expiry_date_lbl = new System.Windows.Forms.Label();
            this.spa_program_id = new System.Windows.Forms.ComboBox();
            this.price = new System.Windows.Forms.TextBox();
            this.sold_on_lbl = new System.Windows.Forms.Label();
            this.percent_lbl = new System.Windows.Forms.Label();
            this.sold_on = new System.Windows.Forms.DateTimePicker();
            this.price_lbl = new System.Windows.Forms.Label();
            this.spa_program_lbl = new System.Windows.Forms.Label();
            this.code_end = new System.Windows.Forms.TextBox();
            this.discount_lbl = new System.Windows.Forms.Label();
            this.code_end_lbl = new System.Windows.Forms.Label();
            this.discount_amount = new System.Windows.Forms.TextBox();
            this.code_begin = new System.Windows.Forms.TextBox();
            this.discount_unit = new System.Windows.Forms.ComboBox();
            this.code_begin_lbl = new System.Windows.Forms.Label();
            this.single_coupon_panel = new System.Windows.Forms.Panel();
            this.event_name_lbl = new System.Windows.Forms.Label();
            this.event_name = new System.Windows.Forms.TextBox();
            this.line_sep2 = new SPA_MANAGEMENT_SYSTEM.line_sep();
            this.coupon_type_panel.SuspendLayout();
            this.payment_panel.SuspendLayout();
            this.single_coupon_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // debtor_id_lbl
            // 
            this.debtor_id_lbl.AutoSize = true;
            this.debtor_id_lbl.BackColor = System.Drawing.Color.Transparent;
            this.debtor_id_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.debtor_id_lbl.Location = new System.Drawing.Point(3, 115);
            this.debtor_id_lbl.Name = "debtor_id_lbl";
            this.debtor_id_lbl.Size = new System.Drawing.Size(92, 18);
            this.debtor_id_lbl.TabIndex = 77;
            this.debtor_id_lbl.Text = "DEBTOR : ";
            // 
            // manage_btn
            // 
            this.manage_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.manage_btn.FlatAppearance.BorderSize = 0;
            this.manage_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manage_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.manage_btn.Location = new System.Drawing.Point(286, 571);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(101, 59);
            this.manage_btn.TabIndex = 999;
            this.manage_btn.Text = "ADD";
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // coupon_type_panel
            // 
            this.coupon_type_panel.Controls.Add(this.money_coupon_rb);
            this.coupon_type_panel.Controls.Add(this.membercard_id);
            this.coupon_type_panel.Controls.Add(this.membercard_rb);
            this.coupon_type_panel.Controls.Add(this.line_sep1);
            this.coupon_type_panel.Controls.Add(this.coupon_set);
            this.coupon_type_panel.Controls.Add(this.coupon_set_rb);
            this.coupon_type_panel.Controls.Add(this.simple_coupon_rb);
            this.coupon_type_panel.Controls.Add(this.coupon_type_lbl);
            this.coupon_type_panel.Location = new System.Drawing.Point(6, 1);
            this.coupon_type_panel.Name = "coupon_type_panel";
            this.coupon_type_panel.Size = new System.Drawing.Size(381, 178);
            this.coupon_type_panel.TabIndex = 123;
            // 
            // money_coupon_rb
            // 
            this.money_coupon_rb.AutoSize = true;
            this.money_coupon_rb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.money_coupon_rb.Location = new System.Drawing.Point(192, 30);
            this.money_coupon_rb.Name = "money_coupon_rb";
            this.money_coupon_rb.Size = new System.Drawing.Size(164, 22);
            this.money_coupon_rb.TabIndex = 124;
            this.money_coupon_rb.Text = "MONEY COUPON";
            this.money_coupon_rb.UseVisualStyleBackColor = true;
            this.money_coupon_rb.CheckedChanged += new System.EventHandler(this.money_coupon_rb_CheckedChanged);
            // 
            // membercard_id
            // 
            this.membercard_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.membercard_id.Enabled = false;
            this.membercard_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.membercard_id.FormattingEnabled = true;
            this.membercard_id.Location = new System.Drawing.Point(191, 141);
            this.membercard_id.Name = "membercard_id";
            this.membercard_id.Size = new System.Drawing.Size(179, 26);
            this.membercard_id.TabIndex = 5;
            // 
            // membercard_rb
            // 
            this.membercard_rb.AutoSize = true;
            this.membercard_rb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.membercard_rb.Location = new System.Drawing.Point(192, 115);
            this.membercard_rb.Name = "membercard_rb";
            this.membercard_rb.Size = new System.Drawing.Size(145, 22);
            this.membercard_rb.TabIndex = 4;
            this.membercard_rb.Text = "MEMBERCARD";
            this.membercard_rb.UseVisualStyleBackColor = true;
            this.membercard_rb.CheckedChanged += new System.EventHandler(this.membercard_rb_CheckedChanged);
            // 
            // line_sep1
            // 
            this.line_sep1.BackColor = System.Drawing.Color.Transparent;
            this.line_sep1.Location = new System.Drawing.Point(3, 176);
            this.line_sep1.Margin = new System.Windows.Forms.Padding(4);
            this.line_sep1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.line_sep1.MinimumSize = new System.Drawing.Size(0, 2);
            this.line_sep1.Name = "line_sep1";
            this.line_sep1.Size = new System.Drawing.Size(377, 2);
            this.line_sep1.TabIndex = 123;
            // 
            // coupon_set
            // 
            this.coupon_set.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.coupon_set.Enabled = false;
            this.coupon_set.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.coupon_set.FormattingEnabled = true;
            this.coupon_set.Location = new System.Drawing.Point(191, 83);
            this.coupon_set.Name = "coupon_set";
            this.coupon_set.Size = new System.Drawing.Size(179, 26);
            this.coupon_set.TabIndex = 3;
            // 
            // coupon_set_rb
            // 
            this.coupon_set_rb.AutoSize = true;
            this.coupon_set_rb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coupon_set_rb.Location = new System.Drawing.Point(192, 55);
            this.coupon_set_rb.Name = "coupon_set_rb";
            this.coupon_set_rb.Size = new System.Drawing.Size(136, 22);
            this.coupon_set_rb.TabIndex = 2;
            this.coupon_set_rb.Text = "COUPON SET";
            this.coupon_set_rb.UseVisualStyleBackColor = true;
            this.coupon_set_rb.CheckedChanged += new System.EventHandler(this.coupon_set_rb_CheckedChanged);
            // 
            // simple_coupon_rb
            // 
            this.simple_coupon_rb.AutoSize = true;
            this.simple_coupon_rb.Checked = true;
            this.simple_coupon_rb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simple_coupon_rb.Location = new System.Drawing.Point(192, 6);
            this.simple_coupon_rb.Name = "simple_coupon_rb";
            this.simple_coupon_rb.Size = new System.Drawing.Size(164, 22);
            this.simple_coupon_rb.TabIndex = 1;
            this.simple_coupon_rb.TabStop = true;
            this.simple_coupon_rb.Text = "SIMPLE COUPON";
            this.simple_coupon_rb.UseVisualStyleBackColor = true;
            this.simple_coupon_rb.CheckedChanged += new System.EventHandler(this.simple_coupon_rb_CheckedChanged);
            // 
            // coupon_type_lbl
            // 
            this.coupon_type_lbl.AutoSize = true;
            this.coupon_type_lbl.BackColor = System.Drawing.Color.Transparent;
            this.coupon_type_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.coupon_type_lbl.Location = new System.Drawing.Point(3, 8);
            this.coupon_type_lbl.Name = "coupon_type_lbl";
            this.coupon_type_lbl.Size = new System.Drawing.Size(138, 18);
            this.coupon_type_lbl.TabIndex = 122;
            this.coupon_type_lbl.Text = "COUPON TYPE :";
            // 
            // payment_panel
            // 
            this.payment_panel.Controls.Add(this.personal_credit_rb);
            this.payment_panel.Controls.Add(this.payment_lbl);
            this.payment_panel.Controls.Add(this.free);
            this.payment_panel.Controls.Add(this.debtor_id);
            this.payment_panel.Controls.Add(this.debtor_id_lbl);
            this.payment_panel.Controls.Add(this.credit);
            this.payment_panel.Controls.Add(this.cash);
            this.payment_panel.Location = new System.Drawing.Point(6, 423);
            this.payment_panel.Name = "payment_panel";
            this.payment_panel.Size = new System.Drawing.Size(381, 142);
            this.payment_panel.TabIndex = 1001;
            // 
            // personal_credit_rb
            // 
            this.personal_credit_rb.AutoSize = true;
            this.personal_credit_rb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.personal_credit_rb.Location = new System.Drawing.Point(192, 87);
            this.personal_credit_rb.Name = "personal_credit_rb";
            this.personal_credit_rb.Size = new System.Drawing.Size(181, 22);
            this.personal_credit_rb.TabIndex = 18;
            this.personal_credit_rb.Text = "PERSONAL CREDIT";
            this.personal_credit_rb.UseVisualStyleBackColor = true;
            this.personal_credit_rb.CheckedChanged += new System.EventHandler(this.personal_credit_rb_CheckedChanged);
            // 
            // payment_lbl
            // 
            this.payment_lbl.AutoSize = true;
            this.payment_lbl.BackColor = System.Drawing.Color.Transparent;
            this.payment_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.payment_lbl.Location = new System.Drawing.Point(3, 4);
            this.payment_lbl.Name = "payment_lbl";
            this.payment_lbl.Size = new System.Drawing.Size(101, 18);
            this.payment_lbl.TabIndex = 1000;
            this.payment_lbl.Text = "PAYMENT : ";
            // 
            // free
            // 
            this.free.AutoSize = true;
            this.free.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.free.Location = new System.Drawing.Point(192, 59);
            this.free.Name = "free";
            this.free.Size = new System.Drawing.Size(180, 22);
            this.free.TabIndex = 17;
            this.free.Text = "NO SELLING PRICE";
            this.free.UseVisualStyleBackColor = true;
            // 
            // debtor_id
            // 
            this.debtor_id.currentID = -1;
            this.debtor_id.Enabled = false;
            this.debtor_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.debtor_id.ForeColor = System.Drawing.Color.Red;
            this.debtor_id.Location = new System.Drawing.Point(101, 112);
            this.debtor_id.Mode = "DEBTOR";
            this.debtor_id.Name = "debtor_id";
            this.debtor_id.Size = new System.Drawing.Size(269, 24);
            this.debtor_id.TabIndex = 19;
            this.debtor_id.Tag = "";
            // 
            // credit
            // 
            this.credit.AutoSize = true;
            this.credit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.credit.Location = new System.Drawing.Point(192, 31);
            this.credit.Name = "credit";
            this.credit.Size = new System.Drawing.Size(138, 22);
            this.credit.TabIndex = 16;
            this.credit.Text = "CREDIT CARD";
            this.credit.UseVisualStyleBackColor = true;
            // 
            // cash
            // 
            this.cash.AutoSize = true;
            this.cash.Checked = true;
            this.cash.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cash.Location = new System.Drawing.Point(192, 3);
            this.cash.Name = "cash";
            this.cash.Size = new System.Drawing.Size(71, 22);
            this.cash.TabIndex = 15;
            this.cash.TabStop = true;
            this.cash.Text = "CASH";
            this.cash.UseVisualStyleBackColor = true;
            // 
            // expiry_date
            // 
            this.expiry_date.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.expiry_date.CustomFormat = "dd/MM/yyyy";
            this.expiry_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.expiry_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.expiry_date.Location = new System.Drawing.Point(193, 196);
            this.expiry_date.Name = "expiry_date";
            this.expiry_date.Size = new System.Drawing.Size(124, 24);
            this.expiry_date.TabIndex = 13;
            // 
            // expiry_date_lbl
            // 
            this.expiry_date_lbl.AutoSize = true;
            this.expiry_date_lbl.BackColor = System.Drawing.Color.Transparent;
            this.expiry_date_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.expiry_date_lbl.Location = new System.Drawing.Point(3, 199);
            this.expiry_date_lbl.Name = "expiry_date_lbl";
            this.expiry_date_lbl.Size = new System.Drawing.Size(130, 18);
            this.expiry_date_lbl.TabIndex = 114;
            this.expiry_date_lbl.Text = "EXPIRY DATE : ";
            // 
            // spa_program_id
            // 
            this.spa_program_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.spa_program_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.spa_program_id.FormattingEnabled = true;
            this.spa_program_id.Location = new System.Drawing.Point(192, 86);
            this.spa_program_id.Name = "spa_program_id";
            this.spa_program_id.Size = new System.Drawing.Size(179, 26);
            this.spa_program_id.TabIndex = 9;
            // 
            // price
            // 
            this.price.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.price.Location = new System.Drawing.Point(193, 141);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(57, 24);
            this.price.TabIndex = 12;
            this.price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.discount_KeyPress);
            // 
            // sold_on_lbl
            // 
            this.sold_on_lbl.AutoSize = true;
            this.sold_on_lbl.BackColor = System.Drawing.Color.Transparent;
            this.sold_on_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.sold_on_lbl.Location = new System.Drawing.Point(3, 172);
            this.sold_on_lbl.Name = "sold_on_lbl";
            this.sold_on_lbl.Size = new System.Drawing.Size(98, 18);
            this.sold_on_lbl.TabIndex = 116;
            this.sold_on_lbl.Text = "SOLD ON : ";
            // 
            // percent_lbl
            // 
            this.percent_lbl.AutoSize = true;
            this.percent_lbl.BackColor = System.Drawing.Color.Transparent;
            this.percent_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.percent_lbl.Location = new System.Drawing.Point(256, 144);
            this.percent_lbl.Name = "percent_lbl";
            this.percent_lbl.Size = new System.Drawing.Size(43, 18);
            this.percent_lbl.TabIndex = 81;
            this.percent_lbl.Text = "Rub.";
            // 
            // sold_on
            // 
            this.sold_on.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sold_on.CustomFormat = "dd/MM/yyyy";
            this.sold_on.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sold_on.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.sold_on.Location = new System.Drawing.Point(193, 169);
            this.sold_on.Name = "sold_on";
            this.sold_on.Size = new System.Drawing.Size(124, 24);
            this.sold_on.TabIndex = 14;
            // 
            // price_lbl
            // 
            this.price_lbl.AutoSize = true;
            this.price_lbl.BackColor = System.Drawing.Color.Transparent;
            this.price_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.price_lbl.Location = new System.Drawing.Point(3, 144);
            this.price_lbl.Name = "price_lbl";
            this.price_lbl.Size = new System.Drawing.Size(73, 18);
            this.price_lbl.TabIndex = 80;
            this.price_lbl.Text = "PRICE : ";
            // 
            // spa_program_lbl
            // 
            this.spa_program_lbl.AutoSize = true;
            this.spa_program_lbl.BackColor = System.Drawing.Color.Transparent;
            this.spa_program_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.spa_program_lbl.Location = new System.Drawing.Point(3, 91);
            this.spa_program_lbl.Name = "spa_program_lbl";
            this.spa_program_lbl.Size = new System.Drawing.Size(145, 18);
            this.spa_program_lbl.TabIndex = 74;
            this.spa_program_lbl.Text = "SPA PROGRAM : ";
            // 
            // code_end
            // 
            this.code_end.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.code_end.Location = new System.Drawing.Point(193, 59);
            this.code_end.Name = "code_end";
            this.code_end.Size = new System.Drawing.Size(178, 24);
            this.code_end.TabIndex = 8;
            this.code_end.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.code_end_KeyPress);
            // 
            // discount_lbl
            // 
            this.discount_lbl.AutoSize = true;
            this.discount_lbl.BackColor = System.Drawing.Color.Transparent;
            this.discount_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.discount_lbl.Location = new System.Drawing.Point(3, 117);
            this.discount_lbl.Name = "discount_lbl";
            this.discount_lbl.Size = new System.Drawing.Size(109, 18);
            this.discount_lbl.TabIndex = 121;
            this.discount_lbl.Text = "DISCOUNT : ";
            // 
            // code_end_lbl
            // 
            this.code_end_lbl.AutoSize = true;
            this.code_end_lbl.BackColor = System.Drawing.Color.Transparent;
            this.code_end_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.code_end_lbl.Location = new System.Drawing.Point(3, 62);
            this.code_end_lbl.Name = "code_end_lbl";
            this.code_end_lbl.Size = new System.Drawing.Size(106, 18);
            this.code_end_lbl.TabIndex = 51;
            this.code_end_lbl.Text = "CODE END :";
            // 
            // discount_amount
            // 
            this.discount_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.discount_amount.Location = new System.Drawing.Point(193, 114);
            this.discount_amount.Name = "discount_amount";
            this.discount_amount.Size = new System.Drawing.Size(57, 24);
            this.discount_amount.TabIndex = 10;
            this.discount_amount.Text = "100";
            this.discount_amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.discount_amount_KeyPress);
            // 
            // code_begin
            // 
            this.code_begin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.code_begin.Location = new System.Drawing.Point(193, 32);
            this.code_begin.Name = "code_begin";
            this.code_begin.Size = new System.Drawing.Size(178, 24);
            this.code_begin.TabIndex = 7;
            this.code_begin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.code_begin_KeyPress);
            this.code_begin.Leave += new System.EventHandler(this.code_begin_Leave);
            // 
            // discount_unit
            // 
            this.discount_unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.discount_unit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.discount_unit.FormattingEnabled = true;
            this.discount_unit.Location = new System.Drawing.Point(252, 113);
            this.discount_unit.Name = "discount_unit";
            this.discount_unit.Size = new System.Drawing.Size(71, 26);
            this.discount_unit.TabIndex = 11;
            // 
            // code_begin_lbl
            // 
            this.code_begin_lbl.AutoSize = true;
            this.code_begin_lbl.BackColor = System.Drawing.Color.Transparent;
            this.code_begin_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.code_begin_lbl.Location = new System.Drawing.Point(3, 35);
            this.code_begin_lbl.Name = "code_begin_lbl";
            this.code_begin_lbl.Size = new System.Drawing.Size(122, 18);
            this.code_begin_lbl.TabIndex = 50;
            this.code_begin_lbl.Text = "CODE BEGIN :";
            // 
            // single_coupon_panel
            // 
            this.single_coupon_panel.Controls.Add(this.event_name_lbl);
            this.single_coupon_panel.Controls.Add(this.event_name);
            this.single_coupon_panel.Controls.Add(this.line_sep2);
            this.single_coupon_panel.Controls.Add(this.code_begin_lbl);
            this.single_coupon_panel.Controls.Add(this.discount_unit);
            this.single_coupon_panel.Controls.Add(this.code_begin);
            this.single_coupon_panel.Controls.Add(this.discount_amount);
            this.single_coupon_panel.Controls.Add(this.code_end_lbl);
            this.single_coupon_panel.Controls.Add(this.discount_lbl);
            this.single_coupon_panel.Controls.Add(this.code_end);
            this.single_coupon_panel.Controls.Add(this.spa_program_lbl);
            this.single_coupon_panel.Controls.Add(this.price_lbl);
            this.single_coupon_panel.Controls.Add(this.sold_on);
            this.single_coupon_panel.Controls.Add(this.percent_lbl);
            this.single_coupon_panel.Controls.Add(this.sold_on_lbl);
            this.single_coupon_panel.Controls.Add(this.price);
            this.single_coupon_panel.Controls.Add(this.spa_program_id);
            this.single_coupon_panel.Controls.Add(this.expiry_date_lbl);
            this.single_coupon_panel.Controls.Add(this.expiry_date);
            this.single_coupon_panel.Location = new System.Drawing.Point(6, 185);
            this.single_coupon_panel.Name = "single_coupon_panel";
            this.single_coupon_panel.Size = new System.Drawing.Size(381, 232);
            this.single_coupon_panel.TabIndex = 122;
            // 
            // event_name_lbl
            // 
            this.event_name_lbl.AutoSize = true;
            this.event_name_lbl.BackColor = System.Drawing.Color.Transparent;
            this.event_name_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.event_name_lbl.Location = new System.Drawing.Point(3, 8);
            this.event_name_lbl.Name = "event_name_lbl";
            this.event_name_lbl.Size = new System.Drawing.Size(124, 18);
            this.event_name_lbl.TabIndex = 126;
            this.event_name_lbl.Text = "EVENT NAME :";
            // 
            // event_name
            // 
            this.event_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.event_name.Location = new System.Drawing.Point(193, 5);
            this.event_name.Name = "event_name";
            this.event_name.Size = new System.Drawing.Size(178, 24);
            this.event_name.TabIndex = 6;
            // 
            // line_sep2
            // 
            this.line_sep2.BackColor = System.Drawing.Color.Transparent;
            this.line_sep2.Location = new System.Drawing.Point(2, 229);
            this.line_sep2.Margin = new System.Windows.Forms.Padding(4);
            this.line_sep2.MaximumSize = new System.Drawing.Size(2000, 2);
            this.line_sep2.MinimumSize = new System.Drawing.Size(0, 2);
            this.line_sep2.Name = "line_sep2";
            this.line_sep2.Size = new System.Drawing.Size(377, 2);
            this.line_sep2.TabIndex = 124;
            // 
            // coupon_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(395, 638);
            this.Controls.Add(this.payment_panel);
            this.Controls.Add(this.single_coupon_panel);
            this.Controls.Add(this.coupon_type_panel);
            this.Controls.Add(this.manage_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "coupon_manage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MANAGE COUPON";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.coupon_manage_FormClosed);
            this.Load += new System.EventHandler(this.coupon_manage_Load);
            this.SizeChanged += new System.EventHandler(this.coupon_manage_SizeChanged);
            this.coupon_type_panel.ResumeLayout(false);
            this.coupon_type_panel.PerformLayout();
            this.payment_panel.ResumeLayout(false);
            this.payment_panel.PerformLayout();
            this.single_coupon_panel.ResumeLayout(false);
            this.single_coupon_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button manage_btn;
        //public System.Windows.Forms.ComboBox responsible_id;
        private System.Windows.Forms.Panel coupon_type_panel;
        private System.Windows.Forms.RadioButton coupon_set_rb;
        private System.Windows.Forms.RadioButton simple_coupon_rb;
        private System.Windows.Forms.Label coupon_type_lbl;
        private System.Windows.Forms.Panel payment_panel;
        private System.Windows.Forms.RadioButton personal_credit_rb;
        private System.Windows.Forms.Label payment_lbl;
        private System.Windows.Forms.RadioButton free;
        private System.Windows.Forms.RadioButton credit;
        private System.Windows.Forms.RadioButton cash;
        public customAutoComplete debtor_id;
        private System.Windows.Forms.Label debtor_id_lbl;
        public System.Windows.Forms.DateTimePicker expiry_date;
        private System.Windows.Forms.Label expiry_date_lbl;
        public System.Windows.Forms.ComboBox spa_program_id;
        private System.Windows.Forms.TextBox price;
        private System.Windows.Forms.Label sold_on_lbl;
        private System.Windows.Forms.Label percent_lbl;
        public System.Windows.Forms.DateTimePicker sold_on;
        private System.Windows.Forms.Label price_lbl;
        private System.Windows.Forms.Label spa_program_lbl;
        private System.Windows.Forms.TextBox code_end;
        private System.Windows.Forms.Label discount_lbl;
        private System.Windows.Forms.Label code_end_lbl;
        private System.Windows.Forms.TextBox discount_amount;
        private System.Windows.Forms.TextBox code_begin;
        public System.Windows.Forms.ComboBox discount_unit;
        private System.Windows.Forms.Label code_begin_lbl;
        private System.Windows.Forms.Panel single_coupon_panel;
        private line_sep line_sep1;
        public System.Windows.Forms.ComboBox coupon_set;
        private line_sep line_sep2;
        public System.Windows.Forms.ComboBox membercard_id;
        private System.Windows.Forms.RadioButton membercard_rb;
        private System.Windows.Forms.Label event_name_lbl;
        private System.Windows.Forms.TextBox event_name;
        private System.Windows.Forms.RadioButton money_coupon_rb;
    }
}