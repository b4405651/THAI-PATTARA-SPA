namespace SPA_MANAGEMENT_SYSTEM.RESERVATION
{
    partial class reservation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gray_lbl = new System.Windows.Forms.Label();
            this.blue_lbl = new System.Windows.Forms.Label();
            this.started_lbl = new System.Windows.Forms.Label();
            this.desc_tbl = new System.Windows.Forms.TableLayoutPanel();
            this.blue_panel = new System.Windows.Forms.Panel();
            this.blueBox = new System.Windows.Forms.PictureBox();
            this.lightcoral_panel = new System.Windows.Forms.Panel();
            this.lightCoralBox = new System.Windows.Forms.PictureBox();
            this.red_panel = new System.Windows.Forms.Panel();
            this.redBox = new System.Windows.Forms.PictureBox();
            this.green_panel = new System.Windows.Forms.Panel();
            this.greenBox = new System.Windows.Forms.PictureBox();
            this.paid_lbl = new System.Windows.Forms.Label();
            this.reservation_date_lbl = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.ComboBox();
            this.status_lbl = new System.Windows.Forms.Label();
            this.customer_data_lbl = new System.Windows.Forms.Label();
            this.select_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.total_lbl = new System.Windows.Forms.Label();
            this.finish_btn = new System.Windows.Forms.Button();
            this.spa_card_no_lbl = new System.Windows.Forms.Label();
            this.spa_card_no = new System.Windows.Forms.TextBox();
            this.reservation_date = new System.Windows.Forms.DateTimePicker();
            this.customer_data = new System.Windows.Forms.TextBox();
            this.return_keycard_btn = new System.Windows.Forms.Button();
            this.master_day_off_btn = new System.Windows.Forms.Button();
            this.therapistTable = new SPA_MANAGEMENT_SYSTEM.BufferedDataGridView();
            this.roomTable = new SPA_MANAGEMENT_SYSTEM.BufferedDataGridView();
            this.force_open_btn = new System.Windows.Forms.Button();
            this.desc_tbl.SuspendLayout();
            this.blue_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blueBox)).BeginInit();
            this.lightcoral_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lightCoralBox)).BeginInit();
            this.red_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.redBox)).BeginInit();
            this.green_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.greenBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.therapistTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomTable)).BeginInit();
            this.SuspendLayout();
            // 
            // gray_lbl
            // 
            this.gray_lbl.AutoSize = true;
            this.gray_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gray_lbl.Location = new System.Drawing.Point(44, 7);
            this.gray_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gray_lbl.Name = "gray_lbl";
            this.gray_lbl.Size = new System.Drawing.Size(121, 24);
            this.gray_lbl.TabIndex = 8;
            this.gray_lbl.Text = "RESERVED";
            this.gray_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // blue_lbl
            // 
            this.blue_lbl.AutoSize = true;
            this.blue_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.blue_lbl.Location = new System.Drawing.Point(45, 7);
            this.blue_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.blue_lbl.Name = "blue_lbl";
            this.blue_lbl.Size = new System.Drawing.Size(198, 24);
            this.blue_lbl.TabIndex = 12;
            this.blue_lbl.Text = "FINISHED - UNPAID";
            this.blue_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // started_lbl
            // 
            this.started_lbl.AutoSize = true;
            this.started_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.started_lbl.Location = new System.Drawing.Point(45, 7);
            this.started_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.started_lbl.Name = "started_lbl";
            this.started_lbl.Size = new System.Drawing.Size(105, 24);
            this.started_lbl.TabIndex = 14;
            this.started_lbl.Text = "STARTED";
            this.started_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // desc_tbl
            // 
            this.desc_tbl.ColumnCount = 4;
            this.desc_tbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.desc_tbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.desc_tbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.desc_tbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.desc_tbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.desc_tbl.Controls.Add(this.blue_panel, 0, 0);
            this.desc_tbl.Controls.Add(this.lightcoral_panel, 1, 0);
            this.desc_tbl.Controls.Add(this.red_panel, 2, 0);
            this.desc_tbl.Controls.Add(this.green_panel, 3, 0);
            this.desc_tbl.Location = new System.Drawing.Point(20, 524);
            this.desc_tbl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.desc_tbl.Name = "desc_tbl";
            this.desc_tbl.RowCount = 1;
            this.desc_tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.desc_tbl.Size = new System.Drawing.Size(897, 47);
            this.desc_tbl.TabIndex = 15;
            // 
            // blue_panel
            // 
            this.blue_panel.Controls.Add(this.blueBox);
            this.blue_panel.Controls.Add(this.gray_lbl);
            this.blue_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blue_panel.Location = new System.Drawing.Point(4, 4);
            this.blue_panel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.blue_panel.Name = "blue_panel";
            this.blue_panel.Size = new System.Drawing.Size(179, 39);
            this.blue_panel.TabIndex = 0;
            // 
            // blueBox
            // 
            this.blueBox.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.blueBox.Location = new System.Drawing.Point(4, 4);
            this.blueBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.blueBox.Name = "blueBox";
            this.blueBox.Size = new System.Drawing.Size(33, 31);
            this.blueBox.TabIndex = 7;
            this.blueBox.TabStop = false;
            // 
            // lightcoral_panel
            // 
            this.lightcoral_panel.Controls.Add(this.lightCoralBox);
            this.lightcoral_panel.Controls.Add(this.started_lbl);
            this.lightcoral_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lightcoral_panel.Location = new System.Drawing.Point(191, 4);
            this.lightcoral_panel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lightcoral_panel.Name = "lightcoral_panel";
            this.lightcoral_panel.Size = new System.Drawing.Size(179, 39);
            this.lightcoral_panel.TabIndex = 2;
            // 
            // lightCoralBox
            // 
            this.lightCoralBox.BackColor = System.Drawing.Color.LightCoral;
            this.lightCoralBox.Location = new System.Drawing.Point(4, 4);
            this.lightCoralBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lightCoralBox.Name = "lightCoralBox";
            this.lightCoralBox.Size = new System.Drawing.Size(33, 31);
            this.lightCoralBox.TabIndex = 13;
            this.lightCoralBox.TabStop = false;
            // 
            // red_panel
            // 
            this.red_panel.Controls.Add(this.redBox);
            this.red_panel.Controls.Add(this.blue_lbl);
            this.red_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.red_panel.Location = new System.Drawing.Point(378, 4);
            this.red_panel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.red_panel.Name = "red_panel";
            this.red_panel.Size = new System.Drawing.Size(272, 39);
            this.red_panel.TabIndex = 3;
            // 
            // redBox
            // 
            this.redBox.BackColor = System.Drawing.Color.Red;
            this.redBox.Location = new System.Drawing.Point(4, 4);
            this.redBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.redBox.Name = "redBox";
            this.redBox.Size = new System.Drawing.Size(33, 31);
            this.redBox.TabIndex = 11;
            this.redBox.TabStop = false;
            // 
            // green_panel
            // 
            this.green_panel.Controls.Add(this.greenBox);
            this.green_panel.Controls.Add(this.paid_lbl);
            this.green_panel.Location = new System.Drawing.Point(658, 4);
            this.green_panel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.green_panel.Name = "green_panel";
            this.green_panel.Size = new System.Drawing.Size(235, 39);
            this.green_panel.TabIndex = 4;
            // 
            // greenBox
            // 
            this.greenBox.BackColor = System.Drawing.Color.YellowGreen;
            this.greenBox.Location = new System.Drawing.Point(4, 5);
            this.greenBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.greenBox.Name = "greenBox";
            this.greenBox.Size = new System.Drawing.Size(33, 31);
            this.greenBox.TabIndex = 13;
            this.greenBox.TabStop = false;
            // 
            // paid_lbl
            // 
            this.paid_lbl.AutoSize = true;
            this.paid_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.paid_lbl.Location = new System.Drawing.Point(45, 7);
            this.paid_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.paid_lbl.Name = "paid_lbl";
            this.paid_lbl.Size = new System.Drawing.Size(169, 24);
            this.paid_lbl.TabIndex = 14;
            this.paid_lbl.Text = "FINISHED - PAID";
            this.paid_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // reservation_date_lbl
            // 
            this.reservation_date_lbl.AutoSize = true;
            this.reservation_date_lbl.BackColor = System.Drawing.Color.Transparent;
            this.reservation_date_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.reservation_date_lbl.Location = new System.Drawing.Point(16, 11);
            this.reservation_date_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.reservation_date_lbl.Name = "reservation_date_lbl";
            this.reservation_date_lbl.Size = new System.Drawing.Size(83, 24);
            this.reservation_date_lbl.TabIndex = 47;
            this.reservation_date_lbl.Text = "DATE : ";
            // 
            // status
            // 
            this.status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.status.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.status.FormattingEnabled = true;
            this.status.Location = new System.Drawing.Point(139, 43);
            this.status.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(223, 30);
            this.status.TabIndex = 2;
            this.status.SelectedIndexChanged += new System.EventHandler(this.status_SelectedIndexChanged);
            // 
            // status_lbl
            // 
            this.status_lbl.AutoSize = true;
            this.status_lbl.BackColor = System.Drawing.Color.Transparent;
            this.status_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.status_lbl.Location = new System.Drawing.Point(16, 49);
            this.status_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.status_lbl.Name = "status_lbl";
            this.status_lbl.Size = new System.Drawing.Size(108, 24);
            this.status_lbl.TabIndex = 103;
            this.status_lbl.Text = "STATUS : ";
            // 
            // customer_data_lbl
            // 
            this.customer_data_lbl.AutoSize = true;
            this.customer_data_lbl.BackColor = System.Drawing.Color.Transparent;
            this.customer_data_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.customer_data_lbl.Location = new System.Drawing.Point(389, 49);
            this.customer_data_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customer_data_lbl.Name = "customer_data_lbl";
            this.customer_data_lbl.Size = new System.Drawing.Size(204, 24);
            this.customer_data_lbl.TabIndex = 104;
            this.customer_data_lbl.Text = "CUSTOMER DATA : ";
            // 
            // select_btn
            // 
            this.select_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.select_btn.FlatAppearance.BorderSize = 0;
            this.select_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.select_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.select_btn.Location = new System.Drawing.Point(1636, 5);
            this.select_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.select_btn.Name = "select_btn";
            this.select_btn.Size = new System.Drawing.Size(168, 73);
            this.select_btn.TabIndex = 106;
            this.select_btn.Text = "SELECT";
            this.select_btn.UseVisualStyleBackColor = false;
            this.select_btn.Visible = false;
            this.select_btn.Click += new System.EventHandler(this.select_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.cancel_btn.FlatAppearance.BorderSize = 0;
            this.cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cancel_btn.Location = new System.Drawing.Point(1284, 5);
            this.cancel_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(168, 73);
            this.cancel_btn.TabIndex = 107;
            this.cancel_btn.Text = "CANCEL";
            this.cancel_btn.UseVisualStyleBackColor = false;
            this.cancel_btn.Visible = false;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // total_lbl
            // 
            this.total_lbl.AutoSize = true;
            this.total_lbl.BackColor = System.Drawing.Color.Transparent;
            this.total_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.total_lbl.Location = new System.Drawing.Point(269, 11);
            this.total_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.total_lbl.Name = "total_lbl";
            this.total_lbl.Size = new System.Drawing.Size(95, 24);
            this.total_lbl.TabIndex = 108;
            this.total_lbl.Text = "TOTAL : ";
            // 
            // finish_btn
            // 
            this.finish_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.finish_btn.FlatAppearance.BorderSize = 0;
            this.finish_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.finish_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.finish_btn.Location = new System.Drawing.Point(1460, 5);
            this.finish_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.finish_btn.Name = "finish_btn";
            this.finish_btn.Size = new System.Drawing.Size(168, 73);
            this.finish_btn.TabIndex = 109;
            this.finish_btn.Text = "MARK AS\r\nFINISHED";
            this.finish_btn.UseVisualStyleBackColor = false;
            this.finish_btn.Visible = false;
            this.finish_btn.Click += new System.EventHandler(this.finish_btn_Click);
            // 
            // spa_card_no_lbl
            // 
            this.spa_card_no_lbl.AutoSize = true;
            this.spa_card_no_lbl.BackColor = System.Drawing.Color.Transparent;
            this.spa_card_no_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.spa_card_no_lbl.Location = new System.Drawing.Point(867, 47);
            this.spa_card_no_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.spa_card_no_lbl.Name = "spa_card_no_lbl";
            this.spa_card_no_lbl.Size = new System.Drawing.Size(167, 24);
            this.spa_card_no_lbl.TabIndex = 110;
            this.spa_card_no_lbl.Text = "SPA CARD NO : ";
            this.spa_card_no_lbl.Click += new System.EventHandler(this.spa_card_no_lbl_Click);
            // 
            // spa_card_no
            // 
            this.spa_card_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.spa_card_no.Location = new System.Drawing.Point(1043, 46);
            this.spa_card_no.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.spa_card_no.Name = "spa_card_no";
            this.spa_card_no.Size = new System.Drawing.Size(236, 28);
            this.spa_card_no.TabIndex = 4;
            this.spa_card_no.Tag = "barcode";
            this.spa_card_no.TextChanged += new System.EventHandler(this.spa_card_no_TextChanged);
            this.spa_card_no.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.spa_card_no_KeyPress);
            // 
            // reservation_date
            // 
            this.reservation_date.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reservation_date.CustomFormat = "dd/MM/yyyy";
            this.reservation_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reservation_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.reservation_date.Location = new System.Drawing.Point(96, 9);
            this.reservation_date.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reservation_date.Name = "reservation_date";
            this.reservation_date.Size = new System.Drawing.Size(164, 28);
            this.reservation_date.TabIndex = 112;
            this.reservation_date.ValueChanged += new System.EventHandler(this.reservation_date_ValueChanged);
            // 
            // customer_data
            // 
            this.customer_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customer_data.Location = new System.Drawing.Point(613, 41);
            this.customer_data.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.customer_data.Name = "customer_data";
            this.customer_data.Size = new System.Drawing.Size(244, 28);
            this.customer_data.TabIndex = 3;
            this.customer_data.KeyUp += new System.Windows.Forms.KeyEventHandler(this.customer_data_KeyUp);
            // 
            // return_keycard_btn
            // 
            this.return_keycard_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.return_keycard_btn.FlatAppearance.BorderSize = 0;
            this.return_keycard_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.return_keycard_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.return_keycard_btn.Location = new System.Drawing.Point(1512, 532);
            this.return_keycard_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.return_keycard_btn.Name = "return_keycard_btn";
            this.return_keycard_btn.Size = new System.Drawing.Size(284, 43);
            this.return_keycard_btn.TabIndex = 113;
            this.return_keycard_btn.Text = "RETURN KEYCARD";
            this.return_keycard_btn.UseVisualStyleBackColor = false;
            this.return_keycard_btn.Click += new System.EventHandler(this.return_keycard_btn_Click);
            // 
            // master_day_off_btn
            // 
            this.master_day_off_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            this.master_day_off_btn.FlatAppearance.BorderSize = 0;
            this.master_day_off_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.master_day_off_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.master_day_off_btn.Location = new System.Drawing.Point(1220, 532);
            this.master_day_off_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.master_day_off_btn.Name = "master_day_off_btn";
            this.master_day_off_btn.Size = new System.Drawing.Size(284, 43);
            this.master_day_off_btn.TabIndex = 114;
            this.master_day_off_btn.Text = "MASTER DAY OFF";
            this.master_day_off_btn.UseVisualStyleBackColor = false;
            this.master_day_off_btn.Click += new System.EventHandler(this.master_day_off_btn_Click);
            // 
            // therapistTable
            // 
            this.therapistTable.AllowUserToAddRows = false;
            this.therapistTable.AllowUserToDeleteRows = false;
            this.therapistTable.AllowUserToResizeColumns = false;
            this.therapistTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.therapistTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.therapistTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.therapistTable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.therapistTable.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.therapistTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.therapistTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.therapistTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 7, 0, 7);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.therapistTable.DefaultCellStyle = dataGridViewCellStyle3;
            this.therapistTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.therapistTable.EnableHeadersVisualStyles = false;
            this.therapistTable.Location = new System.Drawing.Point(20, 81);
            this.therapistTable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.therapistTable.MultiSelect = false;
            this.therapistTable.Name = "therapistTable";
            this.therapistTable.ReadOnly = true;
            this.therapistTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.therapistTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.therapistTable.RowHeadersVisible = false;
            this.therapistTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.therapistTable.RowTemplate.Height = 66;
            this.therapistTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.therapistTable.ShowCellErrors = false;
            this.therapistTable.ShowCellToolTips = false;
            this.therapistTable.ShowEditingIcon = false;
            this.therapistTable.Size = new System.Drawing.Size(748, 214);
            this.therapistTable.TabIndex = 111;
            this.therapistTable.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.therapistTable_CellMouseClick);
            this.therapistTable.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.therapistTable_CellStateChanged);
            this.therapistTable.Scroll += new System.Windows.Forms.ScrollEventHandler(this.therapistTable_Scroll);
            this.therapistTable.Paint += new System.Windows.Forms.PaintEventHandler(this.therapistTable_Paint);
            // 
            // roomTable
            // 
            this.roomTable.AllowUserToAddRows = false;
            this.roomTable.AllowUserToDeleteRows = false;
            this.roomTable.AllowUserToResizeColumns = false;
            this.roomTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.roomTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.roomTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.roomTable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.roomTable.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.roomTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(169)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(0, 7, 0, 7);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.roomTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.roomTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(0, 7, 0, 7);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.roomTable.DefaultCellStyle = dataGridViewCellStyle7;
            this.roomTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.roomTable.EnableHeadersVisualStyles = false;
            this.roomTable.Location = new System.Drawing.Point(20, 303);
            this.roomTable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.roomTable.MultiSelect = false;
            this.roomTable.Name = "roomTable";
            this.roomTable.ReadOnly = true;
            this.roomTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.roomTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.roomTable.RowHeadersVisible = false;
            this.roomTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.roomTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.roomTable.ShowCellErrors = false;
            this.roomTable.ShowCellToolTips = false;
            this.roomTable.ShowEditingIcon = false;
            this.roomTable.Size = new System.Drawing.Size(748, 214);
            this.roomTable.TabIndex = 6;
            this.roomTable.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.roomTable_CellMouseClick);
            this.roomTable.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.roomTable_CellStateChanged);
            this.roomTable.Scroll += new System.Windows.Forms.ScrollEventHandler(this.roomTable_Scroll);
            this.roomTable.Paint += new System.Windows.Forms.PaintEventHandler(this.roomTable_Paint);
            // 
            // force_open_btn
            // 
            this.force_open_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.force_open_btn.FlatAppearance.BorderSize = 0;
            this.force_open_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.force_open_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.force_open_btn.Location = new System.Drawing.Point(1284, 85);
            this.force_open_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.force_open_btn.Name = "force_open_btn";
            this.force_open_btn.Size = new System.Drawing.Size(187, 30);
            this.force_open_btn.TabIndex = 115;
            this.force_open_btn.Text = "FORCE OPEN";
            this.force_open_btn.UseVisualStyleBackColor = false;
            this.force_open_btn.Click += new System.EventHandler(this.force_open_btn_Click);
            // 
            // reservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(126)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(1805, 582);
            this.ControlBox = false;
            this.Controls.Add(this.force_open_btn);
            this.Controls.Add(this.master_day_off_btn);
            this.Controls.Add(this.return_keycard_btn);
            this.Controls.Add(this.reservation_date);
            this.Controls.Add(this.therapistTable);
            this.Controls.Add(this.roomTable);
            this.Controls.Add(this.desc_tbl);
            this.Controls.Add(this.spa_card_no);
            this.Controls.Add(this.spa_card_no_lbl);
            this.Controls.Add(this.finish_btn);
            this.Controls.Add(this.total_lbl);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.select_btn);
            this.Controls.Add(this.customer_data);
            this.Controls.Add(this.customer_data_lbl);
            this.Controls.Add(this.status);
            this.Controls.Add(this.status_lbl);
            this.Controls.Add(this.reservation_date_lbl);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "reservation";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "reservation";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.reservation_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.reservation_FormClosed);
            this.Load += new System.EventHandler(this.reservation_Load);
            this.desc_tbl.ResumeLayout(false);
            this.blue_panel.ResumeLayout(false);
            this.blue_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blueBox)).EndInit();
            this.lightcoral_panel.ResumeLayout(false);
            this.lightcoral_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lightCoralBox)).EndInit();
            this.red_panel.ResumeLayout(false);
            this.red_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.redBox)).EndInit();
            this.green_panel.ResumeLayout(false);
            this.green_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.greenBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.therapistTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public BufferedDataGridView roomTable;
        private System.Windows.Forms.PictureBox blueBox;
        private System.Windows.Forms.Label gray_lbl;
        private System.Windows.Forms.Label blue_lbl;
        private System.Windows.Forms.PictureBox redBox;
        private System.Windows.Forms.Label started_lbl;
        private System.Windows.Forms.PictureBox lightCoralBox;
        private System.Windows.Forms.TableLayoutPanel desc_tbl;
        private System.Windows.Forms.Panel blue_panel;
        private System.Windows.Forms.Panel lightcoral_panel;
        private System.Windows.Forms.Panel red_panel;
        private System.Windows.Forms.Label reservation_date_lbl;
        public System.Windows.Forms.ComboBox status;
        private System.Windows.Forms.Label status_lbl;
        private System.Windows.Forms.Label customer_data_lbl;
        public System.Windows.Forms.Button select_btn;
        public System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Label total_lbl;
        public System.Windows.Forms.Button finish_btn;
        private System.Windows.Forms.Label spa_card_no_lbl;
        private System.Windows.Forms.TextBox spa_card_no;
        public BufferedDataGridView therapistTable;
        public System.Windows.Forms.DateTimePicker reservation_date;
        //public customAutoComplete customer_id;
        public System.Windows.Forms.TextBox customer_data;
        public System.Windows.Forms.Button return_keycard_btn;
        private System.Windows.Forms.Panel green_panel;
        private System.Windows.Forms.Label paid_lbl;
        public System.Windows.Forms.Button master_day_off_btn;
        private System.Windows.Forms.PictureBox greenBox;
        public System.Windows.Forms.Button force_open_btn;



    }
}