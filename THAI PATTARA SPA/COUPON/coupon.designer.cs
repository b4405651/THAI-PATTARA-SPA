namespace SPA_MANAGEMENT_SYSTEM.COUPON
{
    partial class coupon
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
            this.item_name = new System.Windows.Forms.TextBox();
            this.item_name_lbl = new System.Windows.Forms.Label();
            this.code_begin = new System.Windows.Forms.TextBox();
            this.code_begin_lbl = new System.Windows.Forms.Label();
            this.code_end = new System.Windows.Forms.TextBox();
            this.code_end_lbl = new System.Windows.Forms.Label();
            this.btn_dgv = new SPA_MANAGEMENT_SYSTEM.btn_dgv();
            this.line_sep1 = new SPA_MANAGEMENT_SYSTEM.line_sep();
            this.event_name = new System.Windows.Forms.TextBox();
            this.event_name_lbl = new System.Windows.Forms.Label();
            this.coupon_type = new System.Windows.Forms.ComboBox();
            this.coupon_type_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // item_name
            // 
            this.item_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_name.Location = new System.Drawing.Point(228, -213);
            this.item_name.Name = "item_name";
            this.item_name.Size = new System.Drawing.Size(178, 24);
            this.item_name.TabIndex = 27;
            // 
            // item_name_lbl
            // 
            this.item_name_lbl.AutoSize = true;
            this.item_name_lbl.BackColor = System.Drawing.Color.Transparent;
            this.item_name_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_name_lbl.Location = new System.Drawing.Point(113, -210);
            this.item_name_lbl.Name = "item_name_lbl";
            this.item_name_lbl.Size = new System.Drawing.Size(109, 18);
            this.item_name_lbl.TabIndex = 29;
            this.item_name_lbl.Text = "ITEM NAME :";
            // 
            // code_begin
            // 
            this.code_begin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.code_begin.Location = new System.Drawing.Point(137, 34);
            this.code_begin.Name = "code_begin";
            this.code_begin.Size = new System.Drawing.Size(178, 24);
            this.code_begin.TabIndex = 2;
            this.code_begin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.code_KeyDown);
            this.code_begin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.code_begin_KeyPress);
            // 
            // code_begin_lbl
            // 
            this.code_begin_lbl.AutoSize = true;
            this.code_begin_lbl.BackColor = System.Drawing.Color.Transparent;
            this.code_begin_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.code_begin_lbl.Location = new System.Drawing.Point(12, 37);
            this.code_begin_lbl.Name = "code_begin_lbl";
            this.code_begin_lbl.Size = new System.Drawing.Size(122, 18);
            this.code_begin_lbl.TabIndex = 36;
            this.code_begin_lbl.Text = "CODE BEGIN :";
            // 
            // code_end
            // 
            this.code_end.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.code_end.Location = new System.Drawing.Point(475, 34);
            this.code_end.Name = "code_end";
            this.code_end.Size = new System.Drawing.Size(178, 24);
            this.code_end.TabIndex = 3;
            this.code_end.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.code_end_KeyPress);
            this.code_end.KeyUp += new System.Windows.Forms.KeyEventHandler(this.code_end_KeyUp);
            // 
            // code_end_lbl
            // 
            this.code_end_lbl.AutoSize = true;
            this.code_end_lbl.BackColor = System.Drawing.Color.Transparent;
            this.code_end_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.code_end_lbl.Location = new System.Drawing.Point(333, 37);
            this.code_end_lbl.Name = "code_end_lbl";
            this.code_end_lbl.Size = new System.Drawing.Size(106, 18);
            this.code_end_lbl.TabIndex = 38;
            this.code_end_lbl.Text = "CODE END :";
            // 
            // btn_dgv
            // 
            this.btn_dgv.AutoSize = true;
            this.btn_dgv.BackColor = System.Drawing.Color.Transparent;
            this.btn_dgv.Location = new System.Drawing.Point(12, 76);
            this.btn_dgv.Name = "btn_dgv";
            this.btn_dgv.preventDGVSelectionChanged = false;
            this.btn_dgv.Size = new System.Drawing.Size(1903, 645);
            this.btn_dgv.TabIndex = 4;
            // 
            // line_sep1
            // 
            this.line_sep1.BackColor = System.Drawing.Color.Transparent;
            this.line_sep1.Location = new System.Drawing.Point(12, 65);
            this.line_sep1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.line_sep1.MinimumSize = new System.Drawing.Size(0, 2);
            this.line_sep1.Name = "line_sep1";
            this.line_sep1.Size = new System.Drawing.Size(350, 2);
            this.line_sep1.TabIndex = 30;
            // 
            // event_name
            // 
            this.event_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.event_name.Location = new System.Drawing.Point(137, 6);
            this.event_name.Name = "event_name";
            this.event_name.Size = new System.Drawing.Size(178, 24);
            this.event_name.TabIndex = 1;
            this.event_name.KeyUp += new System.Windows.Forms.KeyEventHandler(this.event_name_KeyUp);
            // 
            // event_name_lbl
            // 
            this.event_name_lbl.AutoSize = true;
            this.event_name_lbl.BackColor = System.Drawing.Color.Transparent;
            this.event_name_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.event_name_lbl.Location = new System.Drawing.Point(12, 9);
            this.event_name_lbl.Name = "event_name_lbl";
            this.event_name_lbl.Size = new System.Drawing.Size(124, 18);
            this.event_name_lbl.TabIndex = 40;
            this.event_name_lbl.Text = "EVENT NAME :";
            // 
            // coupon_type
            // 
            this.coupon_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.coupon_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.coupon_type.FormattingEnabled = true;
            this.coupon_type.Location = new System.Drawing.Point(474, 6);
            this.coupon_type.Name = "coupon_type";
            this.coupon_type.Size = new System.Drawing.Size(178, 26);
            this.coupon_type.TabIndex = 77;
            this.coupon_type.SelectedIndexChanged += new System.EventHandler(this.coupon_type_SelectedIndexChanged);
            // 
            // coupon_type_lbl
            // 
            this.coupon_type_lbl.AutoSize = true;
            this.coupon_type_lbl.BackColor = System.Drawing.Color.Transparent;
            this.coupon_type_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.coupon_type_lbl.Location = new System.Drawing.Point(333, 9);
            this.coupon_type_lbl.Name = "coupon_type_lbl";
            this.coupon_type_lbl.Size = new System.Drawing.Size(143, 18);
            this.coupon_type_lbl.TabIndex = 78;
            this.coupon_type_lbl.Text = "COUPON TYPE : ";
            // 
            // coupon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(885, 261);
            this.ControlBox = false;
            this.Controls.Add(this.coupon_type);
            this.Controls.Add(this.coupon_type_lbl);
            this.Controls.Add(this.event_name);
            this.Controls.Add(this.event_name_lbl);
            this.Controls.Add(this.code_end);
            this.Controls.Add(this.code_end_lbl);
            this.Controls.Add(this.code_begin);
            this.Controls.Add(this.code_begin_lbl);
            this.Controls.Add(this.btn_dgv);
            this.Controls.Add(this.line_sep1);
            this.Controls.Add(this.item_name);
            this.Controls.Add(this.item_name_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "coupon";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "config_special_card";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.doLoadGridData);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private line_sep line_sep1;
        private System.Windows.Forms.TextBox item_name;
        private System.Windows.Forms.Label item_name_lbl;
        private System.Windows.Forms.TextBox code_begin;
        private System.Windows.Forms.Label code_begin_lbl;
        private System.Windows.Forms.TextBox code_end;
        private System.Windows.Forms.Label code_end_lbl;
        public btn_dgv btn_dgv;
        private System.Windows.Forms.TextBox event_name;
        private System.Windows.Forms.Label event_name_lbl;
        public System.Windows.Forms.ComboBox coupon_type;
        private System.Windows.Forms.Label coupon_type_lbl;
    }
}