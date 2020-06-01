namespace SPA_MANAGEMENT_SYSTEM.SHOP
{
    partial class cashier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cashier));
            this.total = new System.Windows.Forms.Label();
            this.total_lbl = new System.Windows.Forms.Label();
            this.member_card_btn = new System.Windows.Forms.Button();
            this.bill_no = new System.Windows.Forms.TextBox();
            this.bill_no_lbl = new System.Windows.Forms.Label();
            this.manage_btn = new System.Windows.Forms.Button();
            this.discount_lbl = new System.Windows.Forms.Label();
            this.discount = new System.Windows.Forms.Label();
            this.grand_total_lbl = new System.Windows.Forms.Label();
            this.grand_total = new System.Windows.Forms.Label();
            this.void_btn = new System.Windows.Forms.Button();
            this.voided = new System.Windows.Forms.Label();
            this.customer_id_lbl = new System.Windows.Forms.Label();
            this.item_id = new System.Windows.Forms.ComboBox();
            this.item_lbl = new System.Windows.Forms.Label();
            this.item_type_lbl = new System.Windows.Forms.Label();
            this.item_type = new System.Windows.Forms.ComboBox();
            this.invoice_btn = new System.Windows.Forms.Button();
            this.add_customer_btn = new System.Windows.Forms.Button();
            this.gift_cer_btn = new System.Windows.Forms.Button();
            this.gift_voucher_btn = new System.Windows.Forms.Button();
            this.coupon_btn = new System.Windows.Forms.Button();
            this.vip_card_btn = new System.Windows.Forms.Button();
            this.other_discount_btn = new System.Windows.Forms.Button();
            this.pay_by_credit_card_btn = new System.Windows.Forms.Button();
            this.pay_by_cash_btn = new System.Windows.Forms.Button();
            this.paid_lbl = new System.Windows.Forms.Label();
            this.paid = new System.Windows.Forms.Label();
            this.payment_groupBox = new System.Windows.Forms.GroupBox();
            this.personal_credit_btn = new System.Windows.Forms.Button();
            this.line_sep1 = new SPA_MANAGEMENT_SYSTEM.line_sep();
            this.done_btn = new System.Windows.Forms.Button();
            this.new_bill_btn = new System.Windows.Forms.Button();
            this.cross_promotion_btn = new System.Windows.Forms.Button();
            this.customer_id = new SPA_MANAGEMENT_SYSTEM.customAutoComplete();
            this.btn_dgv = new SPA_MANAGEMENT_SYSTEM.btn_dgv();
            this.bill_by = new System.Windows.Forms.Label();
            this.money_coupon_btn = new System.Windows.Forms.Button();
            this.payment_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // total
            // 
            this.total.BackColor = System.Drawing.Color.Transparent;
            this.total.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.total.ForeColor = System.Drawing.Color.White;
            this.total.Location = new System.Drawing.Point(762, 40);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(279, 26);
            this.total.TabIndex = 54;
            this.total.Text = "TOTAL";
            this.total.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // total_lbl
            // 
            this.total_lbl.AutoSize = true;
            this.total_lbl.BackColor = System.Drawing.Color.Transparent;
            this.total_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.total_lbl.Location = new System.Drawing.Point(955, 11);
            this.total_lbl.Name = "total_lbl";
            this.total_lbl.Size = new System.Drawing.Size(85, 26);
            this.total_lbl.TabIndex = 55;
            this.total_lbl.Text = "TOTAL";
            this.total_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // member_card_btn
            // 
            this.member_card_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.member_card_btn.Enabled = false;
            this.member_card_btn.FlatAppearance.BorderSize = 0;
            this.member_card_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.member_card_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.member_card_btn.Location = new System.Drawing.Point(325, 624);
            this.member_card_btn.Name = "member_card_btn";
            this.member_card_btn.Size = new System.Drawing.Size(197, 59);
            this.member_card_btn.TabIndex = 9;
            this.member_card_btn.Text = "MEMBER CARD";
            this.member_card_btn.UseVisualStyleBackColor = false;
            this.member_card_btn.Click += new System.EventHandler(this.member_card_btn_Click);
            // 
            // bill_no
            // 
            this.bill_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.bill_no.Location = new System.Drawing.Point(136, 6);
            this.bill_no.Name = "bill_no";
            this.bill_no.Size = new System.Drawing.Size(178, 24);
            this.bill_no.TabIndex = 999;
            this.bill_no.Tag = "barcode";
            this.bill_no.KeyUp += new System.Windows.Forms.KeyEventHandler(this.bill_no_KeyUp);
            // 
            // bill_no_lbl
            // 
            this.bill_no_lbl.AutoSize = true;
            this.bill_no_lbl.BackColor = System.Drawing.Color.Transparent;
            this.bill_no_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.bill_no_lbl.Location = new System.Drawing.Point(12, 9);
            this.bill_no_lbl.Name = "bill_no_lbl";
            this.bill_no_lbl.Size = new System.Drawing.Size(86, 18);
            this.bill_no_lbl.TabIndex = 62;
            this.bill_no_lbl.Text = "BILL NO : ";
            // 
            // manage_btn
            // 
            this.manage_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.manage_btn.FlatAppearance.BorderSize = 0;
            this.manage_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manage_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.manage_btn.Location = new System.Drawing.Point(322, 65);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(116, 44);
            this.manage_btn.TabIndex = 5;
            this.manage_btn.Text = "ADD ITEM";
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // discount_lbl
            // 
            this.discount_lbl.AutoSize = true;
            this.discount_lbl.BackColor = System.Drawing.Color.Transparent;
            this.discount_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.discount_lbl.Location = new System.Drawing.Point(906, 74);
            this.discount_lbl.Name = "discount_lbl";
            this.discount_lbl.Size = new System.Drawing.Size(134, 26);
            this.discount_lbl.TabIndex = 66;
            this.discount_lbl.Text = "DISCOUNT";
            this.discount_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // discount
            // 
            this.discount.BackColor = System.Drawing.Color.Transparent;
            this.discount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.discount.ForeColor = System.Drawing.Color.White;
            this.discount.Location = new System.Drawing.Point(762, 107);
            this.discount.Name = "discount";
            this.discount.Size = new System.Drawing.Size(279, 26);
            this.discount.TabIndex = 65;
            this.discount.Text = "DISCOUNT";
            this.discount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // grand_total_lbl
            // 
            this.grand_total_lbl.AutoSize = true;
            this.grand_total_lbl.BackColor = System.Drawing.Color.Transparent;
            this.grand_total_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.grand_total_lbl.Location = new System.Drawing.Point(863, 140);
            this.grand_total_lbl.Name = "grand_total_lbl";
            this.grand_total_lbl.Size = new System.Drawing.Size(177, 26);
            this.grand_total_lbl.TabIndex = 68;
            this.grand_total_lbl.Text = "GRAND TOTAL";
            this.grand_total_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // grand_total
            // 
            this.grand_total.BackColor = System.Drawing.Color.Transparent;
            this.grand_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 27F, System.Drawing.FontStyle.Bold);
            this.grand_total.ForeColor = System.Drawing.Color.White;
            this.grand_total.Location = new System.Drawing.Point(757, 172);
            this.grand_total.Name = "grand_total";
            this.grand_total.Size = new System.Drawing.Size(284, 40);
            this.grand_total.TabIndex = 67;
            this.grand_total.Text = "GRAND TOTAL";
            this.grand_total.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // void_btn
            // 
            this.void_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.void_btn.Enabled = false;
            this.void_btn.FlatAppearance.BorderSize = 0;
            this.void_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.void_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.void_btn.Location = new System.Drawing.Point(576, 6);
            this.void_btn.Name = "void_btn";
            this.void_btn.Size = new System.Drawing.Size(175, 49);
            this.void_btn.TabIndex = 6;
            this.void_btn.Text = "VOID THIS BILL";
            this.void_btn.UseVisualStyleBackColor = false;
            this.void_btn.Click += new System.EventHandler(this.void_btn_Click);
            // 
            // voided
            // 
            this.voided.AutoSize = true;
            this.voided.BackColor = System.Drawing.Color.Transparent;
            this.voided.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.voided.ForeColor = System.Drawing.Color.Red;
            this.voided.Location = new System.Drawing.Point(320, 9);
            this.voided.Name = "voided";
            this.voided.Size = new System.Drawing.Size(122, 18);
            this.voided.TabIndex = 69;
            this.voided.Text = "*** VOIDED ***";
            this.voided.Visible = false;
            // 
            // customer_id_lbl
            // 
            this.customer_id_lbl.AutoSize = true;
            this.customer_id_lbl.BackColor = System.Drawing.Color.Transparent;
            this.customer_id_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.customer_id_lbl.Location = new System.Drawing.Point(12, 35);
            this.customer_id_lbl.Name = "customer_id_lbl";
            this.customer_id_lbl.Size = new System.Drawing.Size(118, 18);
            this.customer_id_lbl.TabIndex = 74;
            this.customer_id_lbl.Text = "CUSTOMER : ";
            // 
            // item_id
            // 
            this.item_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.item_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_id.FormattingEnabled = true;
            this.item_id.Location = new System.Drawing.Point(136, 89);
            this.item_id.Name = "item_id";
            this.item_id.Size = new System.Drawing.Size(178, 26);
            this.item_id.TabIndex = 4;
            // 
            // item_lbl
            // 
            this.item_lbl.AutoSize = true;
            this.item_lbl.BackColor = System.Drawing.Color.Transparent;
            this.item_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_lbl.Location = new System.Drawing.Point(12, 95);
            this.item_lbl.Name = "item_lbl";
            this.item_lbl.Size = new System.Drawing.Size(62, 18);
            this.item_lbl.TabIndex = 49;
            this.item_lbl.Text = "ITEM : ";
            // 
            // item_type_lbl
            // 
            this.item_type_lbl.AutoSize = true;
            this.item_type_lbl.BackColor = System.Drawing.Color.Transparent;
            this.item_type_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_type_lbl.Location = new System.Drawing.Point(12, 64);
            this.item_type_lbl.Name = "item_type_lbl";
            this.item_type_lbl.Size = new System.Drawing.Size(109, 18);
            this.item_type_lbl.TabIndex = 76;
            this.item_type_lbl.Text = "ITEM TYPE : ";
            // 
            // item_type
            // 
            this.item_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.item_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_type.FormattingEnabled = true;
            this.item_type.Location = new System.Drawing.Point(136, 61);
            this.item_type.Name = "item_type";
            this.item_type.Size = new System.Drawing.Size(178, 26);
            this.item_type.TabIndex = 3;
            this.item_type.SelectedIndexChanged += new System.EventHandler(this.item_type_SelectedIndexChanged);
            // 
            // invoice_btn
            // 
            this.invoice_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.invoice_btn.Enabled = false;
            this.invoice_btn.FlatAppearance.BorderSize = 0;
            this.invoice_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.invoice_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.invoice_btn.Location = new System.Drawing.Point(762, 282);
            this.invoice_btn.Name = "invoice_btn";
            this.invoice_btn.Size = new System.Drawing.Size(283, 59);
            this.invoice_btn.TabIndex = 80;
            this.invoice_btn.Text = "INVOICE";
            this.invoice_btn.UseVisualStyleBackColor = false;
            this.invoice_btn.Click += new System.EventHandler(this.invoice_btn_Click);
            // 
            // add_customer_btn
            // 
            this.add_customer_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.add_customer_btn.FlatAppearance.BorderSize = 0;
            this.add_customer_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_customer_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.add_customer_btn.Image = ((System.Drawing.Image)(resources.GetObject("add_customer_btn.Image")));
            this.add_customer_btn.Location = new System.Drawing.Point(320, 35);
            this.add_customer_btn.Name = "add_customer_btn";
            this.add_customer_btn.Size = new System.Drawing.Size(24, 24);
            this.add_customer_btn.TabIndex = 2;
            this.add_customer_btn.UseVisualStyleBackColor = false;
            this.add_customer_btn.Click += new System.EventHandler(this.add_customer_btn_Click);
            // 
            // gift_cer_btn
            // 
            this.gift_cer_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.gift_cer_btn.Enabled = false;
            this.gift_cer_btn.FlatAppearance.BorderSize = 0;
            this.gift_cer_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gift_cer_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gift_cer_btn.Location = new System.Drawing.Point(16, 624);
            this.gift_cer_btn.Name = "gift_cer_btn";
            this.gift_cer_btn.Size = new System.Drawing.Size(189, 59);
            this.gift_cer_btn.TabIndex = 83;
            this.gift_cer_btn.Text = "GIFT CERTIFICATE";
            this.gift_cer_btn.UseVisualStyleBackColor = false;
            this.gift_cer_btn.Click += new System.EventHandler(this.gift_cer_btn_Click);
            // 
            // gift_voucher_btn
            // 
            this.gift_voucher_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.gift_voucher_btn.Enabled = false;
            this.gift_voucher_btn.FlatAppearance.BorderSize = 0;
            this.gift_voucher_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gift_voucher_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gift_voucher_btn.Location = new System.Drawing.Point(15, 689);
            this.gift_voucher_btn.Name = "gift_voucher_btn";
            this.gift_voucher_btn.Size = new System.Drawing.Size(190, 59);
            this.gift_voucher_btn.TabIndex = 84;
            this.gift_voucher_btn.Text = "GIFT VOUCHER";
            this.gift_voucher_btn.UseVisualStyleBackColor = false;
            this.gift_voucher_btn.Click += new System.EventHandler(this.gift_voucher_btn_Click);
            // 
            // coupon_btn
            // 
            this.coupon_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.coupon_btn.Enabled = false;
            this.coupon_btn.FlatAppearance.BorderSize = 0;
            this.coupon_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.coupon_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.coupon_btn.Location = new System.Drawing.Point(212, 624);
            this.coupon_btn.Name = "coupon_btn";
            this.coupon_btn.Size = new System.Drawing.Size(107, 59);
            this.coupon_btn.TabIndex = 85;
            this.coupon_btn.Text = "COUPON";
            this.coupon_btn.UseVisualStyleBackColor = false;
            this.coupon_btn.Click += new System.EventHandler(this.coupon_btn_Click);
            // 
            // vip_card_btn
            // 
            this.vip_card_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.vip_card_btn.Enabled = false;
            this.vip_card_btn.FlatAppearance.BorderSize = 0;
            this.vip_card_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vip_card_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.vip_card_btn.Location = new System.Drawing.Point(212, 689);
            this.vip_card_btn.Name = "vip_card_btn";
            this.vip_card_btn.Size = new System.Drawing.Size(107, 59);
            this.vip_card_btn.TabIndex = 86;
            this.vip_card_btn.Text = "VIP CARD";
            this.vip_card_btn.UseVisualStyleBackColor = false;
            this.vip_card_btn.Click += new System.EventHandler(this.vip_card_btn_Click);
            // 
            // other_discount_btn
            // 
            this.other_discount_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.other_discount_btn.FlatAppearance.BorderSize = 0;
            this.other_discount_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.other_discount_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.other_discount_btn.Location = new System.Drawing.Point(528, 624);
            this.other_discount_btn.Name = "other_discount_btn";
            this.other_discount_btn.Size = new System.Drawing.Size(177, 59);
            this.other_discount_btn.TabIndex = 88;
            this.other_discount_btn.Text = "OTHER DISCOUNT";
            this.other_discount_btn.UseVisualStyleBackColor = false;
            this.other_discount_btn.Click += new System.EventHandler(this.other_discount_btn_Click);
            // 
            // pay_by_credit_card_btn
            // 
            this.pay_by_credit_card_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.pay_by_credit_card_btn.Enabled = false;
            this.pay_by_credit_card_btn.FlatAppearance.BorderSize = 0;
            this.pay_by_credit_card_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pay_by_credit_card_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.pay_by_credit_card_btn.Location = new System.Drawing.Point(21, 91);
            this.pay_by_credit_card_btn.Name = "pay_by_credit_card_btn";
            this.pay_by_credit_card_btn.Size = new System.Drawing.Size(243, 59);
            this.pay_by_credit_card_btn.TabIndex = 90;
            this.pay_by_credit_card_btn.Text = "PAY by CREDIT CARD";
            this.pay_by_credit_card_btn.UseVisualStyleBackColor = false;
            this.pay_by_credit_card_btn.Click += new System.EventHandler(this.pay_by_credit_card_btn_Click);
            // 
            // pay_by_cash_btn
            // 
            this.pay_by_cash_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.pay_by_cash_btn.Enabled = false;
            this.pay_by_cash_btn.FlatAppearance.BorderSize = 0;
            this.pay_by_cash_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pay_by_cash_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.pay_by_cash_btn.Location = new System.Drawing.Point(21, 26);
            this.pay_by_cash_btn.Name = "pay_by_cash_btn";
            this.pay_by_cash_btn.Size = new System.Drawing.Size(243, 59);
            this.pay_by_cash_btn.TabIndex = 89;
            this.pay_by_cash_btn.Text = "PAY by CASH";
            this.pay_by_cash_btn.UseVisualStyleBackColor = false;
            this.pay_by_cash_btn.Click += new System.EventHandler(this.pay_by_cash_btn_Click);
            // 
            // paid_lbl
            // 
            this.paid_lbl.AutoSize = true;
            this.paid_lbl.BackColor = System.Drawing.Color.Transparent;
            this.paid_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.paid_lbl.Location = new System.Drawing.Point(972, 217);
            this.paid_lbl.Name = "paid_lbl";
            this.paid_lbl.Size = new System.Drawing.Size(68, 26);
            this.paid_lbl.TabIndex = 92;
            this.paid_lbl.Text = "PAID";
            this.paid_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // paid
            // 
            this.paid.BackColor = System.Drawing.Color.Transparent;
            this.paid.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.paid.ForeColor = System.Drawing.Color.White;
            this.paid.Location = new System.Drawing.Point(762, 245);
            this.paid.Name = "paid";
            this.paid.Size = new System.Drawing.Size(279, 26);
            this.paid.TabIndex = 91;
            this.paid.Text = "PAID";
            this.paid.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // payment_groupBox
            // 
            this.payment_groupBox.Controls.Add(this.personal_credit_btn);
            this.payment_groupBox.Controls.Add(this.line_sep1);
            this.payment_groupBox.Controls.Add(this.pay_by_cash_btn);
            this.payment_groupBox.Controls.Add(this.pay_by_credit_card_btn);
            this.payment_groupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.payment_groupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payment_groupBox.Location = new System.Drawing.Point(762, 385);
            this.payment_groupBox.Name = "payment_groupBox";
            this.payment_groupBox.Size = new System.Drawing.Size(283, 232);
            this.payment_groupBox.TabIndex = 93;
            this.payment_groupBox.TabStop = false;
            this.payment_groupBox.Text = "PAYMENT METHOD";
            // 
            // personal_credit_btn
            // 
            this.personal_credit_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.personal_credit_btn.Enabled = false;
            this.personal_credit_btn.FlatAppearance.BorderSize = 0;
            this.personal_credit_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.personal_credit_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.personal_credit_btn.Location = new System.Drawing.Point(21, 164);
            this.personal_credit_btn.Name = "personal_credit_btn";
            this.personal_credit_btn.Size = new System.Drawing.Size(243, 59);
            this.personal_credit_btn.TabIndex = 9;
            this.personal_credit_btn.Text = "PERSONAL CREDIT";
            this.personal_credit_btn.UseVisualStyleBackColor = false;
            this.personal_credit_btn.Click += new System.EventHandler(this.pay_by_personal_credit_btn_Click);
            // 
            // line_sep1
            // 
            this.line_sep1.BackColor = System.Drawing.Color.Transparent;
            this.line_sep1.Location = new System.Drawing.Point(8, 156);
            this.line_sep1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.line_sep1.MaximumSize = new System.Drawing.Size(3333, 3);
            this.line_sep1.MinimumSize = new System.Drawing.Size(0, 3);
            this.line_sep1.Name = "line_sep1";
            this.line_sep1.Size = new System.Drawing.Size(265, 3);
            this.line_sep1.TabIndex = 91;
            // 
            // done_btn
            // 
            this.done_btn.BackColor = System.Drawing.Color.White;
            this.done_btn.FlatAppearance.BorderSize = 0;
            this.done_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.done_btn.Image = global::SPA_MANAGEMENT_SYSTEM.Properties.Resources.done;
            this.done_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.done_btn.Location = new System.Drawing.Point(1052, 624);
            this.done_btn.Name = "done_btn";
            this.done_btn.Padding = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.done_btn.Size = new System.Drawing.Size(120, 60);
            this.done_btn.TabIndex = 94;
            this.done_btn.Text = "DONE";
            this.done_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.done_btn.UseVisualStyleBackColor = false;
            this.done_btn.Visible = false;
            this.done_btn.Click += new System.EventHandler(this.done_btn_Click);
            // 
            // new_bill_btn
            // 
            this.new_bill_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.new_bill_btn.Enabled = false;
            this.new_bill_btn.FlatAppearance.BorderSize = 0;
            this.new_bill_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.new_bill_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.new_bill_btn.Location = new System.Drawing.Point(576, 61);
            this.new_bill_btn.Name = "new_bill_btn";
            this.new_bill_btn.Size = new System.Drawing.Size(175, 52);
            this.new_bill_btn.TabIndex = 1000;
            this.new_bill_btn.Text = "NEW BILL";
            this.new_bill_btn.UseVisualStyleBackColor = false;
            this.new_bill_btn.Click += new System.EventHandler(this.new_bill_btn_Click);
            // 
            // cross_promotion_btn
            // 
            this.cross_promotion_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.cross_promotion_btn.Enabled = false;
            this.cross_promotion_btn.FlatAppearance.BorderSize = 0;
            this.cross_promotion_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cross_promotion_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cross_promotion_btn.Location = new System.Drawing.Point(325, 689);
            this.cross_promotion_btn.Name = "cross_promotion_btn";
            this.cross_promotion_btn.Size = new System.Drawing.Size(197, 59);
            this.cross_promotion_btn.TabIndex = 1001;
            this.cross_promotion_btn.Text = "CROSS PROMOTION";
            this.cross_promotion_btn.UseVisualStyleBackColor = false;
            this.cross_promotion_btn.Click += new System.EventHandler(this.cross_promotion_btn_Click);
            // 
            // customer_id
            // 
            this.customer_id.currentID = -1;
            this.customer_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.customer_id.ForeColor = System.Drawing.Color.Red;
            this.customer_id.Location = new System.Drawing.Point(136, 34);
            this.customer_id.Mode = "CUSTOMER";
            this.customer_id.Name = "customer_id";
            this.customer_id.Size = new System.Drawing.Size(178, 24);
            this.customer_id.TabIndex = 1;
            this.customer_id.Tag = "barcode";
            // 
            // btn_dgv
            // 
            this.btn_dgv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btn_dgv.Location = new System.Drawing.Point(15, 120);
            this.btn_dgv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_dgv.Name = "btn_dgv";
            this.btn_dgv.preventDGVSelectionChanged = false;
            this.btn_dgv.Size = new System.Drawing.Size(736, 498);
            this.btn_dgv.TabIndex = 78;
            // 
            // bill_by
            // 
            this.bill_by.AutoSize = true;
            this.bill_by.BackColor = System.Drawing.Color.Transparent;
            this.bill_by.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.bill_by.Location = new System.Drawing.Point(967, 640);
            this.bill_by.Name = "bill_by";
            this.bill_by.Size = new System.Drawing.Size(81, 26);
            this.bill_by.TabIndex = 1002;
            this.bill_by.Text = "bill_by";
            this.bill_by.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.bill_by.Visible = false;
            // 
            // money_coupon_btn
            // 
            this.money_coupon_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.money_coupon_btn.Enabled = false;
            this.money_coupon_btn.FlatAppearance.BorderSize = 0;
            this.money_coupon_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.money_coupon_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.money_coupon_btn.Location = new System.Drawing.Point(528, 689);
            this.money_coupon_btn.Name = "money_coupon_btn";
            this.money_coupon_btn.Size = new System.Drawing.Size(177, 59);
            this.money_coupon_btn.TabIndex = 1003;
            this.money_coupon_btn.Text = "MONEY COUPON";
            this.money_coupon_btn.UseVisualStyleBackColor = false;
            this.money_coupon_btn.Click += new System.EventHandler(this.money_coupon_btn_Click);
            // 
            // cashier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(1211, 760);
            this.ControlBox = false;
            this.Controls.Add(this.money_coupon_btn);
            this.Controls.Add(this.bill_by);
            this.Controls.Add(this.cross_promotion_btn);
            this.Controls.Add(this.new_bill_btn);
            this.Controls.Add(this.done_btn);
            this.Controls.Add(this.payment_groupBox);
            this.Controls.Add(this.member_card_btn);
            this.Controls.Add(this.paid_lbl);
            this.Controls.Add(this.paid);
            this.Controls.Add(this.other_discount_btn);
            this.Controls.Add(this.vip_card_btn);
            this.Controls.Add(this.coupon_btn);
            this.Controls.Add(this.gift_voucher_btn);
            this.Controls.Add(this.gift_cer_btn);
            this.Controls.Add(this.add_customer_btn);
            this.Controls.Add(this.customer_id);
            this.Controls.Add(this.invoice_btn);
            this.Controls.Add(this.btn_dgv);
            this.Controls.Add(this.item_type);
            this.Controls.Add(this.item_type_lbl);
            this.Controls.Add(this.item_id);
            this.Controls.Add(this.customer_id_lbl);
            this.Controls.Add(this.voided);
            this.Controls.Add(this.void_btn);
            this.Controls.Add(this.grand_total_lbl);
            this.Controls.Add(this.grand_total);
            this.Controls.Add(this.discount_lbl);
            this.Controls.Add(this.discount);
            this.Controls.Add(this.manage_btn);
            this.Controls.Add(this.bill_no);
            this.Controls.Add(this.bill_no_lbl);
            this.Controls.Add(this.total_lbl);
            this.Controls.Add(this.total);
            this.Controls.Add(this.item_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "cashier";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "cashier";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.cashier_FormClosing);
            this.Load += new System.EventHandler(this.shop_selling_Load);
            this.payment_groupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label total;
        private System.Windows.Forms.Label total_lbl;
        public System.Windows.Forms.Button member_card_btn;
        private System.Windows.Forms.TextBox bill_no;
        private System.Windows.Forms.Label bill_no_lbl;
        public System.Windows.Forms.Button manage_btn;
        private System.Windows.Forms.Label discount_lbl;
        private System.Windows.Forms.Label discount;
        private System.Windows.Forms.Label grand_total_lbl;
        public System.Windows.Forms.Button void_btn;
        private System.Windows.Forms.Label voided;
        private System.Windows.Forms.Label customer_id_lbl;
        public System.Windows.Forms.ComboBox item_id;
        private System.Windows.Forms.Label item_lbl;
        private System.Windows.Forms.Label item_type_lbl;
        public System.Windows.Forms.ComboBox item_type;
        public btn_dgv btn_dgv;
        public System.Windows.Forms.Button invoice_btn;
        public customAutoComplete customer_id;
        public System.Windows.Forms.Button add_customer_btn;
        public System.Windows.Forms.Button gift_cer_btn;
        public System.Windows.Forms.Button gift_voucher_btn;
        public System.Windows.Forms.Button coupon_btn;
        public System.Windows.Forms.Button vip_card_btn;
        public System.Windows.Forms.Button other_discount_btn;
        public System.Windows.Forms.Button pay_by_credit_card_btn;
        public System.Windows.Forms.Button pay_by_cash_btn;
        private System.Windows.Forms.Label paid_lbl;
        private System.Windows.Forms.Label paid;
        private System.Windows.Forms.GroupBox payment_groupBox;
        public System.Windows.Forms.Label grand_total;
        public System.Windows.Forms.Button done_btn;
        public System.Windows.Forms.Button new_bill_btn;
        public System.Windows.Forms.Button cross_promotion_btn;
        public System.Windows.Forms.Button personal_credit_btn;
        private line_sep line_sep1;
        private System.Windows.Forms.Label bill_by;
        public System.Windows.Forms.Button money_coupon_btn;
    }
}