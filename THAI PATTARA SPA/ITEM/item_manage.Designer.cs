namespace SPA_MANAGEMENT_SYSTEM.ITEM
{
    partial class item_manage
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
            this.manage_btn = new System.Windows.Forms.Button();
            this.item_name = new System.Windows.Forms.TextBox();
            this.item_lbl = new System.Windows.Forms.Label();
            this.item_cat_lbl = new System.Windows.Forms.Label();
            this.item_code = new System.Windows.Forms.TextBox();
            this.item_code_lbl = new System.Windows.Forms.Label();
            this.unit_id = new System.Windows.Forms.ComboBox();
            this.unit = new System.Windows.Forms.Label();
            this.item_type_id = new System.Windows.Forms.ComboBox();
            this.barcode = new System.Windows.Forms.TextBox();
            this.barcode_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // manage_btn
            // 
            this.manage_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.manage_btn.FlatAppearance.BorderSize = 0;
            this.manage_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manage_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.manage_btn.Location = new System.Drawing.Point(348, 186);
            this.manage_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(135, 73);
            this.manage_btn.TabIndex = 6;
            this.manage_btn.Text = "ADD";
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // item_name
            // 
            this.item_name.Enabled = false;
            this.item_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_name.Location = new System.Drawing.Point(245, 79);
            this.item_name.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.item_name.Name = "item_name";
            this.item_name.Size = new System.Drawing.Size(236, 28);
            this.item_name.TabIndex = 3;
            // 
            // item_lbl
            // 
            this.item_lbl.AutoSize = true;
            this.item_lbl.BackColor = System.Drawing.Color.Transparent;
            this.item_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_lbl.Location = new System.Drawing.Point(13, 82);
            this.item_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.item_lbl.Name = "item_lbl";
            this.item_lbl.Size = new System.Drawing.Size(143, 24);
            this.item_lbl.TabIndex = 15;
            this.item_lbl.Text = "ITEM NAME : ";
            // 
            // item_cat_lbl
            // 
            this.item_cat_lbl.AutoSize = true;
            this.item_cat_lbl.BackColor = System.Drawing.Color.Transparent;
            this.item_cat_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_cat_lbl.Location = new System.Drawing.Point(13, 12);
            this.item_cat_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.item_cat_lbl.Name = "item_cat_lbl";
            this.item_cat_lbl.Size = new System.Drawing.Size(196, 24);
            this.item_cat_lbl.TabIndex = 21;
            this.item_cat_lbl.Text = "ITEM CATEGORY : ";
            // 
            // item_code
            // 
            this.item_code.Enabled = false;
            this.item_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_code.Location = new System.Drawing.Point(245, 44);
            this.item_code.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.item_code.Name = "item_code";
            this.item_code.Size = new System.Drawing.Size(236, 28);
            this.item_code.TabIndex = 2;
            this.item_code.Tag = "barcode";
            // 
            // item_code_lbl
            // 
            this.item_code_lbl.AutoSize = true;
            this.item_code_lbl.BackColor = System.Drawing.Color.Transparent;
            this.item_code_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_code_lbl.Location = new System.Drawing.Point(16, 47);
            this.item_code_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.item_code_lbl.Name = "item_code_lbl";
            this.item_code_lbl.Size = new System.Drawing.Size(141, 24);
            this.item_code_lbl.TabIndex = 32;
            this.item_code_lbl.Text = "ITEM CODE : ";
            // 
            // unit_id
            // 
            this.unit_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.unit_id.Enabled = false;
            this.unit_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.unit_id.FormattingEnabled = true;
            this.unit_id.Location = new System.Drawing.Point(245, 113);
            this.unit_id.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.unit_id.Name = "unit_id";
            this.unit_id.Size = new System.Drawing.Size(236, 30);
            this.unit_id.TabIndex = 4;
            // 
            // unit
            // 
            this.unit.AutoSize = true;
            this.unit.BackColor = System.Drawing.Color.Transparent;
            this.unit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.unit.Location = new System.Drawing.Point(13, 117);
            this.unit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.unit.Name = "unit";
            this.unit.Size = new System.Drawing.Size(57, 24);
            this.unit.TabIndex = 34;
            this.unit.Text = "UNIT";
            // 
            // item_type_id
            // 
            this.item_type_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.item_type_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_type_id.FormattingEnabled = true;
            this.item_type_id.Location = new System.Drawing.Point(245, 9);
            this.item_type_id.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.item_type_id.Name = "item_type_id";
            this.item_type_id.Size = new System.Drawing.Size(236, 30);
            this.item_type_id.TabIndex = 1;
            this.item_type_id.SelectedIndexChanged += new System.EventHandler(this.item_type_id_SelectedIndexChanged);
            // 
            // barcode
            // 
            this.barcode.Enabled = false;
            this.barcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.barcode.Location = new System.Drawing.Point(245, 149);
            this.barcode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.barcode.Name = "barcode";
            this.barcode.Size = new System.Drawing.Size(236, 28);
            this.barcode.TabIndex = 5;
            // 
            // barcode_lbl
            // 
            this.barcode_lbl.AutoSize = true;
            this.barcode_lbl.BackColor = System.Drawing.Color.Transparent;
            this.barcode_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.barcode_lbl.Location = new System.Drawing.Point(13, 153);
            this.barcode_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.barcode_lbl.Name = "barcode_lbl";
            this.barcode_lbl.Size = new System.Drawing.Size(127, 24);
            this.barcode_lbl.TabIndex = 37;
            this.barcode_lbl.Text = "BARCODE : ";
            // 
            // item_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(503, 268);
            this.Controls.Add(this.barcode);
            this.Controls.Add(this.barcode_lbl);
            this.Controls.Add(this.item_type_id);
            this.Controls.Add(this.unit_id);
            this.Controls.Add(this.unit);
            this.Controls.Add(this.item_name);
            this.Controls.Add(this.item_code);
            this.Controls.Add(this.item_code_lbl);
            this.Controls.Add(this.item_cat_lbl);
            this.Controls.Add(this.manage_btn);
            this.Controls.Add(this.item_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "item_manage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MANAGE ITEM";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.item_manage_FormClosed);
            this.Load += new System.EventHandler(this.item_manage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button manage_btn;
        private System.Windows.Forms.TextBox item_name;
        private System.Windows.Forms.Label item_lbl;
        private System.Windows.Forms.Label item_cat_lbl;
        private System.Windows.Forms.TextBox item_code;
        private System.Windows.Forms.Label item_code_lbl;
        public System.Windows.Forms.ComboBox unit_id;
        public System.Windows.Forms.Label unit;
        public System.Windows.Forms.ComboBox item_type_id;
        private System.Windows.Forms.TextBox barcode;
        private System.Windows.Forms.Label barcode_lbl;
    }
}