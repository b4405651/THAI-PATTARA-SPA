namespace SPA_MANAGEMENT_SYSTEM.STORE
{
    partial class store_transaction
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
            this.item_code = new System.Windows.Forms.TextBox();
            this.item_code_lbl = new System.Windows.Forms.Label();
            this.item_cat_lbl = new System.Windows.Forms.Label();
            this.item_name = new System.Windows.Forms.TextBox();
            this.item_name_lbl = new System.Windows.Forms.Label();
            this.type = new System.Windows.Forms.ComboBox();
            this.type_lbl = new System.Windows.Forms.Label();
            this.deposit_by_lbl = new System.Windows.Forms.Label();
            this.withdraw_by_lbl = new System.Windows.Forms.Label();
            this.item_cat = new System.Windows.Forms.ComboBox();
            this.deposit_by = new System.Windows.Forms.ComboBox();
            this.withdraw_by = new System.Windows.Forms.ComboBox();
            this.btn_dgv = new SPA_MANAGEMENT_SYSTEM.btn_dgv();
            this.line_sep = new SPA_MANAGEMENT_SYSTEM.line_sep();
            this.SuspendLayout();
            // 
            // item_code
            // 
            this.item_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_code.Location = new System.Drawing.Point(129, 6);
            this.item_code.Name = "item_code";
            this.item_code.Size = new System.Drawing.Size(178, 24);
            this.item_code.TabIndex = 1;
            this.item_code.Tag = "barcode";
            this.item_code.KeyUp += new System.Windows.Forms.KeyEventHandler(this.item_code_KeyUp);
            // 
            // item_code_lbl
            // 
            this.item_code_lbl.AutoSize = true;
            this.item_code_lbl.BackColor = System.Drawing.Color.Transparent;
            this.item_code_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_code_lbl.Location = new System.Drawing.Point(12, 9);
            this.item_code_lbl.Name = "item_code_lbl";
            this.item_code_lbl.Size = new System.Drawing.Size(115, 18);
            this.item_code_lbl.TabIndex = 47;
            this.item_code_lbl.Text = "ITEM CODE : ";
            // 
            // item_cat_lbl
            // 
            this.item_cat_lbl.AutoSize = true;
            this.item_cat_lbl.BackColor = System.Drawing.Color.Transparent;
            this.item_cat_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_cat_lbl.Location = new System.Drawing.Point(623, 9);
            this.item_cat_lbl.Name = "item_cat_lbl";
            this.item_cat_lbl.Size = new System.Drawing.Size(158, 18);
            this.item_cat_lbl.TabIndex = 46;
            this.item_cat_lbl.Text = "ITEM CATEGORY : ";
            // 
            // item_name
            // 
            this.item_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_name.Location = new System.Drawing.Point(438, 6);
            this.item_name.Name = "item_name";
            this.item_name.Size = new System.Drawing.Size(178, 24);
            this.item_name.TabIndex = 2;
            this.item_name.KeyUp += new System.Windows.Forms.KeyEventHandler(this.item_name_KeyUp);
            // 
            // item_name_lbl
            // 
            this.item_name_lbl.AutoSize = true;
            this.item_name_lbl.BackColor = System.Drawing.Color.Transparent;
            this.item_name_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_name_lbl.Location = new System.Drawing.Point(314, 9);
            this.item_name_lbl.Name = "item_name_lbl";
            this.item_name_lbl.Size = new System.Drawing.Size(114, 18);
            this.item_name_lbl.TabIndex = 45;
            this.item_name_lbl.Text = "ITEM NAME : ";
            // 
            // type
            // 
            this.type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.type.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.type.FormattingEnabled = true;
            this.type.Location = new System.Drawing.Point(129, 33);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(178, 26);
            this.type.TabIndex = 4;
            this.type.SelectedIndexChanged += new System.EventHandler(this.type_SelectedIndexChanged);
            // 
            // type_lbl
            // 
            this.type_lbl.AutoSize = true;
            this.type_lbl.BackColor = System.Drawing.Color.Transparent;
            this.type_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.type_lbl.Location = new System.Drawing.Point(12, 37);
            this.type_lbl.Name = "type_lbl";
            this.type_lbl.Size = new System.Drawing.Size(65, 18);
            this.type_lbl.TabIndex = 51;
            this.type_lbl.Text = "TYPE : ";
            // 
            // deposit_by_lbl
            // 
            this.deposit_by_lbl.AutoSize = true;
            this.deposit_by_lbl.BackColor = System.Drawing.Color.Transparent;
            this.deposit_by_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.deposit_by_lbl.Location = new System.Drawing.Point(314, 37);
            this.deposit_by_lbl.Name = "deposit_by_lbl";
            this.deposit_by_lbl.Size = new System.Drawing.Size(121, 18);
            this.deposit_by_lbl.TabIndex = 56;
            this.deposit_by_lbl.Text = "DEPOSIT BY : ";
            // 
            // withdraw_by_lbl
            // 
            this.withdraw_by_lbl.AutoSize = true;
            this.withdraw_by_lbl.BackColor = System.Drawing.Color.Transparent;
            this.withdraw_by_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.withdraw_by_lbl.Location = new System.Drawing.Point(623, 37);
            this.withdraw_by_lbl.Name = "withdraw_by_lbl";
            this.withdraw_by_lbl.Size = new System.Drawing.Size(141, 18);
            this.withdraw_by_lbl.TabIndex = 58;
            this.withdraw_by_lbl.Text = "WITHDRAW BY : ";
            // 
            // item_cat
            // 
            this.item_cat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.item_cat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_cat.FormattingEnabled = true;
            this.item_cat.Location = new System.Drawing.Point(783, 6);
            this.item_cat.Name = "item_cat";
            this.item_cat.Size = new System.Drawing.Size(178, 26);
            this.item_cat.TabIndex = 59;
            this.item_cat.SelectedIndexChanged += new System.EventHandler(this.item_cat_SelectedIndexChanged);
            // 
            // deposit_by
            // 
            this.deposit_by.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deposit_by.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.deposit_by.FormattingEnabled = true;
            this.deposit_by.Location = new System.Drawing.Point(438, 33);
            this.deposit_by.Name = "deposit_by";
            this.deposit_by.Size = new System.Drawing.Size(178, 26);
            this.deposit_by.TabIndex = 60;
            this.deposit_by.SelectedIndexChanged += new System.EventHandler(this.deposit_by_SelectedIndexChanged);
            // 
            // withdraw_by
            // 
            this.withdraw_by.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.withdraw_by.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.withdraw_by.FormattingEnabled = true;
            this.withdraw_by.Location = new System.Drawing.Point(783, 33);
            this.withdraw_by.Name = "withdraw_by";
            this.withdraw_by.Size = new System.Drawing.Size(178, 26);
            this.withdraw_by.TabIndex = 61;
            this.withdraw_by.SelectedIndexChanged += new System.EventHandler(this.withdraw_by_SelectedIndexChanged);
            // 
            // btn_dgv
            // 
            this.btn_dgv.AutoSize = true;
            this.btn_dgv.BackColor = System.Drawing.Color.Transparent;
            this.btn_dgv.Location = new System.Drawing.Point(15, 74);
            this.btn_dgv.Name = "btn_dgv";
            this.btn_dgv.preventDGVSelectionChanged = false;
            this.btn_dgv.Size = new System.Drawing.Size(1903, 645);
            this.btn_dgv.TabIndex = 7;
            // 
            // line_sep
            // 
            this.line_sep.BackColor = System.Drawing.Color.Transparent;
            this.line_sep.Location = new System.Drawing.Point(15, 66);
            this.line_sep.MaximumSize = new System.Drawing.Size(2000, 2);
            this.line_sep.MinimumSize = new System.Drawing.Size(0, 2);
            this.line_sep.Name = "line_sep";
            this.line_sep.Size = new System.Drawing.Size(350, 2);
            this.line_sep.TabIndex = 49;
            // 
            // store_transaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(1051, 261);
            this.ControlBox = false;
            this.Controls.Add(this.withdraw_by);
            this.Controls.Add(this.deposit_by);
            this.Controls.Add(this.item_cat);
            this.Controls.Add(this.withdraw_by_lbl);
            this.Controls.Add(this.type);
            this.Controls.Add(this.type_lbl);
            this.Controls.Add(this.btn_dgv);
            this.Controls.Add(this.line_sep);
            this.Controls.Add(this.item_code);
            this.Controls.Add(this.item_code_lbl);
            this.Controls.Add(this.item_cat_lbl);
            this.Controls.Add(this.item_name);
            this.Controls.Add(this.item_name_lbl);
            this.Controls.Add(this.deposit_by_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "store_transaction";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "transaction";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.doLoadGridData);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox item_code;
        private System.Windows.Forms.Label item_code_lbl;
        private System.Windows.Forms.Label item_cat_lbl;
        private System.Windows.Forms.TextBox item_name;
        private System.Windows.Forms.Label item_name_lbl;
        private btn_dgv btn_dgv;
        private line_sep line_sep;
        private System.Windows.Forms.ComboBox type;
        private System.Windows.Forms.Label type_lbl;
        private System.Windows.Forms.Label deposit_by_lbl;
        private System.Windows.Forms.Label withdraw_by_lbl;
        public System.Windows.Forms.ComboBox item_cat;
        public System.Windows.Forms.ComboBox deposit_by;
        public System.Windows.Forms.ComboBox withdraw_by;
    }
}