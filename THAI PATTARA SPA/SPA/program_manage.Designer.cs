namespace SPA_MANAGEMENT_SYSTEM.SPA
{
    partial class program_manage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.program_name = new System.Windows.Forms.TextBox();
            this.program_name_lbl = new System.Windows.Forms.Label();
            this.ruble_lbl = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.TextBox();
            this.price_lbl = new System.Windows.Forms.Label();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.manage_btn = new System.Windows.Forms.Button();
            this.new_item_btn = new System.Windows.Forms.Button();
            this.program_type_id = new System.Windows.Forms.ComboBox();
            this.program_type_lbl = new System.Windows.Forms.Label();
            this.description_lbl = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.TextBox();
            this.edit_item_btn = new System.Windows.Forms.Button();
            this.masseur_use = new System.Windows.Forms.TextBox();
            this.masseur_use_lbl = new System.Windows.Forms.Label();
            this.hours = new System.Windows.Forms.TextBox();
            this.duration_lbl = new System.Windows.Forms.Label();
            this.hours_lbl = new System.Windows.Forms.Label();
            this.minutes = new System.Windows.Forms.TextBox();
            this.minutes_lbl = new System.Windows.Forms.Label();
            this.code = new System.Windows.Forms.TextBox();
            this.code_lbl = new System.Windows.Forms.Label();
            this.apply_discount = new System.Windows.Forms.CheckBox();
            this.select_oil = new System.Windows.Forms.CheckBox();
            this.select_scrub = new System.Windows.Forms.CheckBox();
            this.rus_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // program_name
            // 
            this.program_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.program_name.Location = new System.Drawing.Point(173, 59);
            this.program_name.Name = "program_name";
            this.program_name.Size = new System.Drawing.Size(232, 24);
            this.program_name.TabIndex = 3;
            this.program_name.Tag = "";
            // 
            // program_name_lbl
            // 
            this.program_name_lbl.AutoSize = true;
            this.program_name_lbl.BackColor = System.Drawing.Color.Transparent;
            this.program_name_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.program_name_lbl.Location = new System.Drawing.Point(12, 60);
            this.program_name_lbl.Name = "program_name_lbl";
            this.program_name_lbl.Size = new System.Drawing.Size(160, 18);
            this.program_name_lbl.TabIndex = 30;
            this.program_name_lbl.Text = "PROGRAM NAME : ";
            // 
            // ruble_lbl
            // 
            this.ruble_lbl.AutoSize = true;
            this.ruble_lbl.BackColor = System.Drawing.Color.Transparent;
            this.ruble_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ruble_lbl.Location = new System.Drawing.Point(270, 116);
            this.ruble_lbl.Name = "ruble_lbl";
            this.ruble_lbl.Size = new System.Drawing.Size(63, 18);
            this.ruble_lbl.TabIndex = 61;
            this.ruble_lbl.Text = "RUBLE";
            // 
            // price
            // 
            this.price.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.price.Location = new System.Drawing.Point(173, 113);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(91, 24);
            this.price.TabIndex = 5;
            this.price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.price_KeyPress);
            // 
            // price_lbl
            // 
            this.price_lbl.AutoSize = true;
            this.price_lbl.BackColor = System.Drawing.Color.Transparent;
            this.price_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.price_lbl.Location = new System.Drawing.Point(12, 116);
            this.price_lbl.Name = "price_lbl";
            this.price_lbl.Size = new System.Drawing.Size(73, 18);
            this.price_lbl.TabIndex = 60;
            this.price_lbl.Text = "PRICE : ";
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToResizeColumns = false;
            this.DGV.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(201)))), ((int)(((byte)(143)))));
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.DGV.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.DGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(7);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV.DefaultCellStyle = dataGridViewCellStyle7;
            this.DGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DGV.EnableHeadersVisualStyles = false;
            this.DGV.Location = new System.Drawing.Point(15, 299);
            this.DGV.MultiSelect = false;
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.DGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.ShowCellErrors = false;
            this.DGV.ShowCellToolTips = false;
            this.DGV.ShowEditingIcon = false;
            this.DGV.Size = new System.Drawing.Size(768, 175);
            this.DGV.TabIndex = 7;
            this.DGV.TabStop = false;
            this.DGV.Visible = false;
            this.DGV.SelectionChanged += new System.EventHandler(this.DGV_SelectionChanged);
            this.DGV.Paint += new System.Windows.Forms.PaintEventHandler(this.DGV_Paint);
            this.DGV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_KeyDown);
            // 
            // manage_btn
            // 
            this.manage_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.manage_btn.FlatAppearance.BorderSize = 0;
            this.manage_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manage_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.manage_btn.Location = new System.Drawing.Point(682, 221);
            this.manage_btn.Name = "manage_btn";
            this.manage_btn.Size = new System.Drawing.Size(101, 59);
            this.manage_btn.TabIndex = 11;
            this.manage_btn.Text = "ADD";
            this.manage_btn.UseVisualStyleBackColor = false;
            this.manage_btn.Click += new System.EventHandler(this.manage_btn_Click);
            // 
            // new_item_btn
            // 
            this.new_item_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.new_item_btn.FlatAppearance.BorderSize = 0;
            this.new_item_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.new_item_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.new_item_btn.Location = new System.Drawing.Point(15, 224);
            this.new_item_btn.Name = "new_item_btn";
            this.new_item_btn.Size = new System.Drawing.Size(125, 59);
            this.new_item_btn.TabIndex = 9;
            this.new_item_btn.Text = "NEW ITEM";
            this.new_item_btn.UseVisualStyleBackColor = false;
            this.new_item_btn.Visible = false;
            this.new_item_btn.Click += new System.EventHandler(this.new_item_btn_Click);
            // 
            // program_type_id
            // 
            this.program_type_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.program_type_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.program_type_id.FormattingEnabled = true;
            this.program_type_id.Location = new System.Drawing.Point(173, 31);
            this.program_type_id.Name = "program_type_id";
            this.program_type_id.Size = new System.Drawing.Size(231, 26);
            this.program_type_id.TabIndex = 2;
            // 
            // program_type_lbl
            // 
            this.program_type_lbl.AutoSize = true;
            this.program_type_lbl.BackColor = System.Drawing.Color.Transparent;
            this.program_type_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.program_type_lbl.Location = new System.Drawing.Point(12, 34);
            this.program_type_lbl.Name = "program_type_lbl";
            this.program_type_lbl.Size = new System.Drawing.Size(155, 18);
            this.program_type_lbl.TabIndex = 63;
            this.program_type_lbl.Text = "PROGRAM TYPE : ";
            // 
            // description_lbl
            // 
            this.description_lbl.AutoSize = true;
            this.description_lbl.BackColor = System.Drawing.Color.Transparent;
            this.description_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.description_lbl.Location = new System.Drawing.Point(420, 9);
            this.description_lbl.Name = "description_lbl";
            this.description_lbl.Size = new System.Drawing.Size(135, 18);
            this.description_lbl.TabIndex = 64;
            this.description_lbl.Text = "DESCRIPTION : ";
            // 
            // description
            // 
            this.description.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.description.Location = new System.Drawing.Point(551, 5);
            this.description.Multiline = true;
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(232, 210);
            this.description.TabIndex = 12;
            this.description.Tag = "";
            // 
            // edit_item_btn
            // 
            this.edit_item_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.edit_item_btn.FlatAppearance.BorderSize = 0;
            this.edit_item_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.edit_item_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.edit_item_btn.Location = new System.Drawing.Point(420, 224);
            this.edit_item_btn.Name = "edit_item_btn";
            this.edit_item_btn.Size = new System.Drawing.Size(125, 59);
            this.edit_item_btn.TabIndex = 10;
            this.edit_item_btn.Text = "EDIT ITEM";
            this.edit_item_btn.UseVisualStyleBackColor = false;
            this.edit_item_btn.Visible = false;
            this.edit_item_btn.Click += new System.EventHandler(this.edit_item_btn_Click);
            // 
            // masseur_use
            // 
            this.masseur_use.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.masseur_use.Location = new System.Drawing.Point(173, 166);
            this.masseur_use.Name = "masseur_use";
            this.masseur_use.Size = new System.Drawing.Size(48, 24);
            this.masseur_use.TabIndex = 8;
            this.masseur_use.Text = "1";
            this.masseur_use.Enter += new System.EventHandler(this.masseur_use_Enter);
            this.masseur_use.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.masseur_use_KeyPress);
            // 
            // masseur_use_lbl
            // 
            this.masseur_use_lbl.AutoSize = true;
            this.masseur_use_lbl.BackColor = System.Drawing.Color.Transparent;
            this.masseur_use_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.masseur_use_lbl.Location = new System.Drawing.Point(12, 169);
            this.masseur_use_lbl.Name = "masseur_use_lbl";
            this.masseur_use_lbl.Size = new System.Drawing.Size(130, 18);
            this.masseur_use_lbl.TabIndex = 66;
            this.masseur_use_lbl.Text = "MASTER USE : ";
            // 
            // hours
            // 
            this.hours.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.hours.Location = new System.Drawing.Point(173, 140);
            this.hours.Name = "hours";
            this.hours.Size = new System.Drawing.Size(35, 24);
            this.hours.TabIndex = 6;
            this.hours.Text = "1";
            this.hours.Enter += new System.EventHandler(this.hours_Enter);
            this.hours.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.hours_KeyPress);
            // 
            // duration_lbl
            // 
            this.duration_lbl.AutoSize = true;
            this.duration_lbl.BackColor = System.Drawing.Color.Transparent;
            this.duration_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.duration_lbl.Location = new System.Drawing.Point(12, 143);
            this.duration_lbl.Name = "duration_lbl";
            this.duration_lbl.Size = new System.Drawing.Size(108, 18);
            this.duration_lbl.TabIndex = 68;
            this.duration_lbl.Text = "DURATION : ";
            // 
            // hours_lbl
            // 
            this.hours_lbl.AutoSize = true;
            this.hours_lbl.BackColor = System.Drawing.Color.Transparent;
            this.hours_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.hours_lbl.Location = new System.Drawing.Point(214, 143);
            this.hours_lbl.Name = "hours_lbl";
            this.hours_lbl.Size = new System.Drawing.Size(57, 18);
            this.hours_lbl.TabIndex = 69;
            this.hours_lbl.Text = "HOUR";
            // 
            // minutes
            // 
            this.minutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.minutes.Location = new System.Drawing.Point(277, 140);
            this.minutes.Name = "minutes";
            this.minutes.Size = new System.Drawing.Size(35, 24);
            this.minutes.TabIndex = 7;
            this.minutes.Text = "0";
            this.minutes.Enter += new System.EventHandler(this.minutes_Enter);
            this.minutes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.minutes_KeyPress);
            // 
            // minutes_lbl
            // 
            this.minutes_lbl.AutoSize = true;
            this.minutes_lbl.BackColor = System.Drawing.Color.Transparent;
            this.minutes_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.minutes_lbl.Location = new System.Drawing.Point(318, 143);
            this.minutes_lbl.Name = "minutes_lbl";
            this.minutes_lbl.Size = new System.Drawing.Size(71, 18);
            this.minutes_lbl.TabIndex = 71;
            this.minutes_lbl.Text = "MINUTE";
            // 
            // code
            // 
            this.code.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.code.Location = new System.Drawing.Point(173, 5);
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(91, 24);
            this.code.TabIndex = 1;
            this.code.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.code_KeyPress);
            // 
            // code_lbl
            // 
            this.code_lbl.AutoSize = true;
            this.code_lbl.BackColor = System.Drawing.Color.Transparent;
            this.code_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.code_lbl.Location = new System.Drawing.Point(12, 8);
            this.code_lbl.Name = "code_lbl";
            this.code_lbl.Size = new System.Drawing.Size(71, 18);
            this.code_lbl.TabIndex = 73;
            this.code_lbl.Text = "CODE : ";
            // 
            // apply_discount
            // 
            this.apply_discount.AutoSize = true;
            this.apply_discount.Checked = true;
            this.apply_discount.CheckState = System.Windows.Forms.CheckState.Checked;
            this.apply_discount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apply_discount.Location = new System.Drawing.Point(256, 168);
            this.apply_discount.Name = "apply_discount";
            this.apply_discount.Size = new System.Drawing.Size(169, 22);
            this.apply_discount.TabIndex = 9;
            this.apply_discount.Text = "APPLY DISCOUNT";
            this.apply_discount.UseVisualStyleBackColor = true;
            // 
            // select_oil
            // 
            this.select_oil.AutoSize = true;
            this.select_oil.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.select_oil.Location = new System.Drawing.Point(173, 193);
            this.select_oil.Name = "select_oil";
            this.select_oil.Size = new System.Drawing.Size(53, 22);
            this.select_oil.TabIndex = 10;
            this.select_oil.Text = "OIL";
            this.select_oil.UseVisualStyleBackColor = true;
            // 
            // select_scrub
            // 
            this.select_scrub.AutoSize = true;
            this.select_scrub.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.select_scrub.Location = new System.Drawing.Point(256, 193);
            this.select_scrub.Name = "select_scrub";
            this.select_scrub.Size = new System.Drawing.Size(85, 22);
            this.select_scrub.TabIndex = 11;
            this.select_scrub.Text = "SCRUB";
            this.select_scrub.UseVisualStyleBackColor = true;
            // 
            // rus_name
            // 
            this.rus_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rus_name.Location = new System.Drawing.Point(173, 86);
            this.rus_name.Name = "rus_name";
            this.rus_name.Size = new System.Drawing.Size(232, 24);
            this.rus_name.TabIndex = 4;
            this.rus_name.Tag = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(11, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 18);
            this.label1.TabIndex = 78;
            this.label1.Text = "RUSSIAN NAME : ";
            // 
            // program_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(789, 286);
            this.Controls.Add(this.rus_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.select_scrub);
            this.Controls.Add(this.select_oil);
            this.Controls.Add(this.apply_discount);
            this.Controls.Add(this.code);
            this.Controls.Add(this.code_lbl);
            this.Controls.Add(this.minutes_lbl);
            this.Controls.Add(this.minutes);
            this.Controls.Add(this.hours_lbl);
            this.Controls.Add(this.hours);
            this.Controls.Add(this.duration_lbl);
            this.Controls.Add(this.masseur_use);
            this.Controls.Add(this.masseur_use_lbl);
            this.Controls.Add(this.edit_item_btn);
            this.Controls.Add(this.description);
            this.Controls.Add(this.description_lbl);
            this.Controls.Add(this.program_type_id);
            this.Controls.Add(this.program_type_lbl);
            this.Controls.Add(this.new_item_btn);
            this.Controls.Add(this.manage_btn);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.ruble_lbl);
            this.Controls.Add(this.price);
            this.Controls.Add(this.price_lbl);
            this.Controls.Add(this.program_name);
            this.Controls.Add(this.program_name_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "program_manage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MANAGE SINGLE SPA PROGRAM";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.program_manage_FormClosed);
            this.Load += new System.EventHandler(this.program_manage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox program_name;
        private System.Windows.Forms.Label program_name_lbl;
        private System.Windows.Forms.Label ruble_lbl;
        private System.Windows.Forms.TextBox price;
        private System.Windows.Forms.Label price_lbl;
        public System.Windows.Forms.DataGridView DGV;
        public System.Windows.Forms.Button manage_btn;
        public System.Windows.Forms.Button new_item_btn;
        private System.Windows.Forms.ComboBox program_type_id;
        private System.Windows.Forms.Label program_type_lbl;
        private System.Windows.Forms.Label description_lbl;
        private System.Windows.Forms.TextBox description;
        public System.Windows.Forms.Button edit_item_btn;
        private System.Windows.Forms.TextBox masseur_use;
        private System.Windows.Forms.Label masseur_use_lbl;
        private System.Windows.Forms.TextBox hours;
        private System.Windows.Forms.Label duration_lbl;
        private System.Windows.Forms.Label hours_lbl;
        private System.Windows.Forms.TextBox minutes;
        private System.Windows.Forms.Label minutes_lbl;
        private System.Windows.Forms.TextBox code;
        private System.Windows.Forms.Label code_lbl;
        private System.Windows.Forms.CheckBox apply_discount;
        private System.Windows.Forms.CheckBox select_oil;
        private System.Windows.Forms.CheckBox select_scrub;
        private System.Windows.Forms.TextBox rus_name;
        private System.Windows.Forms.Label label1;
    }
}