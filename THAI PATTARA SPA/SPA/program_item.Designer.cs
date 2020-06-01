namespace SPA_MANAGEMENT_SYSTEM.SPA
{
    partial class program_item
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
            this.item_cat_id = new System.Windows.Forms.ComboBox();
            this.item_cat_lbl = new System.Windows.Forms.Label();
            this.spa_item_id = new System.Windows.Forms.ComboBox();
            this.item_lbl = new System.Windows.Forms.Label();
            this.amount = new System.Windows.Forms.TextBox();
            this.amount_lbl = new System.Windows.Forms.Label();
            this.can_choose = new System.Windows.Forms.CheckBox();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.manage_btn = new System.Windows.Forms.Button();
            this.unit_id = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // item_cat_id
            // 
            this.item_cat_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.item_cat_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_cat_id.FormattingEnabled = true;
            this.item_cat_id.Location = new System.Drawing.Point(168, 5);
            this.item_cat_id.Name = "item_cat_id";
            this.item_cat_id.Size = new System.Drawing.Size(207, 26);
            this.item_cat_id.TabIndex = 1;
            this.item_cat_id.SelectedIndexChanged += new System.EventHandler(this.item_cat_id_SelectedIndexChanged);
            // 
            // item_cat_lbl
            // 
            this.item_cat_lbl.AutoSize = true;
            this.item_cat_lbl.BackColor = System.Drawing.Color.Transparent;
            this.item_cat_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_cat_lbl.Location = new System.Drawing.Point(12, 9);
            this.item_cat_lbl.Name = "item_cat_lbl";
            this.item_cat_lbl.Size = new System.Drawing.Size(157, 18);
            this.item_cat_lbl.TabIndex = 7;
            this.item_cat_lbl.Text = "ITEM CATAGORY : ";
            // 
            // spa_item_id
            // 
            this.spa_item_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.spa_item_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.spa_item_id.FormattingEnabled = true;
            this.spa_item_id.Location = new System.Drawing.Point(168, 34);
            this.spa_item_id.Name = "spa_item_id";
            this.spa_item_id.Size = new System.Drawing.Size(207, 26);
            this.spa_item_id.TabIndex = 8;
            this.spa_item_id.SelectedIndexChanged += new System.EventHandler(this.item_id_SelectedIndexChanged);
            // 
            // item_lbl
            // 
            this.item_lbl.AutoSize = true;
            this.item_lbl.BackColor = System.Drawing.Color.Transparent;
            this.item_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_lbl.Location = new System.Drawing.Point(12, 38);
            this.item_lbl.Name = "item_lbl";
            this.item_lbl.Size = new System.Drawing.Size(62, 18);
            this.item_lbl.TabIndex = 9;
            this.item_lbl.Text = "ITEM : ";
            // 
            // amount
            // 
            this.amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.amount.Location = new System.Drawing.Point(168, 63);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(91, 24);
            this.amount.TabIndex = 3;
            this.amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.amount_KeyPress);
            // 
            // amount_lbl
            // 
            this.amount_lbl.AutoSize = true;
            this.amount_lbl.BackColor = System.Drawing.Color.Transparent;
            this.amount_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.amount_lbl.Location = new System.Drawing.Point(12, 66);
            this.amount_lbl.Name = "amount_lbl";
            this.amount_lbl.Size = new System.Drawing.Size(94, 18);
            this.amount_lbl.TabIndex = 62;
            this.amount_lbl.Text = "AMOUNT : ";
            // 
            // can_choose
            // 
            this.can_choose.AutoSize = true;
            this.can_choose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.can_choose.Location = new System.Drawing.Point(168, 91);
            this.can_choose.Name = "can_choose";
            this.can_choose.Size = new System.Drawing.Size(213, 22);
            this.can_choose.TabIndex = 5;
            this.can_choose.Text = "CUSTOMER CHOOSE ?";
            this.can_choose.UseVisualStyleBackColor = true;
            // 
            // cancel_btn
            // 
            this.cancel_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.cancel_btn.CausesValidation = false;
            this.cancel_btn.FlatAppearance.BorderSize = 0;
            this.cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cancel_btn.Location = new System.Drawing.Point(274, 119);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(101, 59);
            this.cancel_btn.TabIndex = 7;
            this.cancel_btn.Text = "CANCEL";
            this.cancel_btn.UseVisualStyleBackColor = false;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // manage_btn
            // 
            this.manage_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.manage_btn.FlatAppearance.BorderSize = 0;
            this.manage_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manage_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.manage_btn.Location = new System.Drawing.Point(167, 119);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(101, 59);
            this.manage_btn.TabIndex = 6;
            this.manage_btn.Text = "ADD";
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // unit_id
            // 
            this.unit_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.unit_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.unit_id.FormattingEnabled = true;
            this.unit_id.Location = new System.Drawing.Point(265, 63);
            this.unit_id.Name = "unit_id";
            this.unit_id.Size = new System.Drawing.Size(110, 26);
            this.unit_id.TabIndex = 4;
            // 
            // program_item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(387, 190);
            this.ControlBox = false;
            this.Controls.Add(this.unit_id);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.manage_btn);
            this.Controls.Add(this.can_choose);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.amount_lbl);
            this.Controls.Add(this.spa_item_id);
            this.Controls.Add(this.item_lbl);
            this.Controls.Add(this.item_cat_id);
            this.Controls.Add(this.item_cat_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "program_item";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADD SPA ITEM TO PROGRAM";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.program_item_FormClosed);
            this.Load += new System.EventHandler(this.program_item_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox item_cat_id;
        private System.Windows.Forms.Label item_cat_lbl;
        private System.Windows.Forms.ComboBox spa_item_id;
        private System.Windows.Forms.Label item_lbl;
        private System.Windows.Forms.TextBox amount;
        private System.Windows.Forms.Label amount_lbl;
        private System.Windows.Forms.CheckBox can_choose;
        public System.Windows.Forms.Button cancel_btn;
        public System.Windows.Forms.Button manage_btn;
        private System.Windows.Forms.ComboBox unit_id;
    }
}