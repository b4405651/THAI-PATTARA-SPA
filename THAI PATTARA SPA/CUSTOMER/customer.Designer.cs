namespace SPA_MANAGEMENT_SYSTEM.CUSTOMER
{
    partial class customer
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
            this.code = new System.Windows.Forms.TextBox();
            this.code_lbl = new System.Windows.Forms.Label();
            this.customer_data = new System.Windows.Forms.TextBox();
            this.customer_data_lbl = new System.Windows.Forms.Label();
            this.item_name = new System.Windows.Forms.TextBox();
            this.item_name_lbl = new System.Windows.Forms.Label();
            this.only_member = new System.Windows.Forms.CheckBox();
            this.only_neighbor = new System.Windows.Forms.CheckBox();
            this.btn_dgv = new SPA_MANAGEMENT_SYSTEM.btn_dgv();
            this.line_sep1 = new SPA_MANAGEMENT_SYSTEM.line_sep();
            this.SuspendLayout();
            // 
            // code
            // 
            this.code.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.code.Location = new System.Drawing.Point(445, 5);
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(178, 24);
            this.code.TabIndex = 43;
            this.code.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.code_KeyPress);
            this.code.KeyUp += new System.Windows.Forms.KeyEventHandler(this.code_KeyUp);
            // 
            // code_lbl
            // 
            this.code_lbl.AutoSize = true;
            this.code_lbl.BackColor = System.Drawing.Color.Transparent;
            this.code_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.code_lbl.Location = new System.Drawing.Point(377, 8);
            this.code_lbl.Name = "code_lbl";
            this.code_lbl.Size = new System.Drawing.Size(66, 18);
            this.code_lbl.TabIndex = 44;
            this.code_lbl.Text = "CODE :";
            // 
            // customer_data
            // 
            this.customer_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.customer_data.Location = new System.Drawing.Point(175, 5);
            this.customer_data.Name = "customer_data";
            this.customer_data.Size = new System.Drawing.Size(178, 24);
            this.customer_data.TabIndex = 40;
            this.customer_data.KeyDown += new System.Windows.Forms.KeyEventHandler(this.card_name_KeyDown);
            // 
            // customer_data_lbl
            // 
            this.customer_data_lbl.AutoSize = true;
            this.customer_data_lbl.BackColor = System.Drawing.Color.Transparent;
            this.customer_data_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.customer_data_lbl.Location = new System.Drawing.Point(8, 8);
            this.customer_data_lbl.Name = "customer_data_lbl";
            this.customer_data_lbl.Size = new System.Drawing.Size(160, 18);
            this.customer_data_lbl.TabIndex = 42;
            this.customer_data_lbl.Text = "CUSTOMER DATA :";
            // 
            // item_name
            // 
            this.item_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_name.Location = new System.Drawing.Point(224, -214);
            this.item_name.Name = "item_name";
            this.item_name.Size = new System.Drawing.Size(178, 24);
            this.item_name.TabIndex = 37;
            // 
            // item_name_lbl
            // 
            this.item_name_lbl.AutoSize = true;
            this.item_name_lbl.BackColor = System.Drawing.Color.Transparent;
            this.item_name_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.item_name_lbl.Location = new System.Drawing.Point(109, -211);
            this.item_name_lbl.Name = "item_name_lbl";
            this.item_name_lbl.Size = new System.Drawing.Size(109, 18);
            this.item_name_lbl.TabIndex = 38;
            this.item_name_lbl.Text = "ITEM NAME :";
            // 
            // only_member
            // 
            this.only_member.AutoSize = true;
            this.only_member.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.only_member.Location = new System.Drawing.Point(639, 7);
            this.only_member.Name = "only_member";
            this.only_member.Size = new System.Drawing.Size(347, 22);
            this.only_member.TabIndex = 45;
            this.only_member.Text = "ONLY CUSTOMER WITH MEMBER CARD";
            this.only_member.UseVisualStyleBackColor = true;
            this.only_member.CheckedChanged += new System.EventHandler(this.only_member_CheckedChanged);
            // 
            // only_neighbor
            // 
            this.only_neighbor.AutoSize = true;
            this.only_neighbor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.only_neighbor.Location = new System.Drawing.Point(992, 7);
            this.only_neighbor.Name = "only_neighbor";
            this.only_neighbor.Size = new System.Drawing.Size(164, 22);
            this.only_neighbor.TabIndex = 46;
            this.only_neighbor.Text = "ONLY NEIGHBOR";
            this.only_neighbor.UseVisualStyleBackColor = true;
            this.only_neighbor.CheckedChanged += new System.EventHandler(this.only_neighbor_CheckedChanged);
            // 
            // btn_dgv
            // 
            this.btn_dgv.AutoSize = true;
            this.btn_dgv.BackColor = System.Drawing.Color.Transparent;
            this.btn_dgv.Location = new System.Drawing.Point(8, 46);
            this.btn_dgv.Name = "btn_dgv";
            this.btn_dgv.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.btn_dgv.preventDGVSelectionChanged = false;
            this.btn_dgv.Size = new System.Drawing.Size(1423, 645);
            this.btn_dgv.TabIndex = 41;
            // 
            // line_sep1
            // 
            this.line_sep1.BackColor = System.Drawing.Color.Transparent;
            this.line_sep1.Location = new System.Drawing.Point(8, 35);
            this.line_sep1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.line_sep1.MinimumSize = new System.Drawing.Size(0, 2);
            this.line_sep1.Name = "line_sep1";
            this.line_sep1.Size = new System.Drawing.Size(350, 2);
            this.line_sep1.TabIndex = 39;
            // 
            // customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(1055, 566);
            this.ControlBox = false;
            this.Controls.Add(this.only_neighbor);
            this.Controls.Add(this.only_member);
            this.Controls.Add(this.code);
            this.Controls.Add(this.code_lbl);
            this.Controls.Add(this.btn_dgv);
            this.Controls.Add(this.customer_data);
            this.Controls.Add(this.customer_data_lbl);
            this.Controls.Add(this.line_sep1);
            this.Controls.Add(this.item_name);
            this.Controls.Add(this.item_name_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "customer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "member_data";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.doLoadGridData);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox code;
        private System.Windows.Forms.Label code_lbl;
        private btn_dgv btn_dgv;
        private System.Windows.Forms.TextBox customer_data;
        private System.Windows.Forms.Label customer_data_lbl;
        private line_sep line_sep1;
        private System.Windows.Forms.TextBox item_name;
        private System.Windows.Forms.Label item_name_lbl;
        private System.Windows.Forms.CheckBox only_member;
        private System.Windows.Forms.CheckBox only_neighbor;
    }
}