namespace Quan_li_muon_sach
{
    partial class Form1
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
            this.tab = new System.Windows.Forms.TabControl();
            this.quan_li_tab = new System.Windows.Forms.TabPage();
            this.bang_sach = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ten_sach_textbox = new System.Windows.Forms.TextBox();
            this.ma_sach_textbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.them_button = new System.Windows.Forms.Button();
            this.muon_tra_tab = new System.Windows.Forms.TabPage();
            this.bang_muon_tra = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ten_sach_combobox = new System.Windows.Forms.ComboBox();
            this.ma_sach_combobox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ten_sv_combobox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ngay_tra_picker = new System.Windows.Forms.DateTimePicker();
            this.ngay_muon_picker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.muon_button = new System.Windows.Forms.Button();
            this.tra_button = new System.Windows.Forms.Button();
            this.thong_ke_tab = new System.Windows.Forms.TabPage();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.tab.SuspendLayout();
            this.quan_li_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bang_sach)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.muon_tra_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bang_muon_tra)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.thong_ke_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Controls.Add(this.quan_li_tab);
            this.tab.Controls.Add(this.muon_tra_tab);
            this.tab.Controls.Add(this.thong_ke_tab);
            this.tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab.Location = new System.Drawing.Point(0, 0);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(945, 471);
            this.tab.TabIndex = 0;
            this.tab.SelectedIndexChanged += new System.EventHandler(this.tab_SelectedIndexChanged);
            // 
            // quan_li_tab
            // 
            this.quan_li_tab.Controls.Add(this.bang_sach);
            this.quan_li_tab.Controls.Add(this.tableLayoutPanel1);
            this.quan_li_tab.Location = new System.Drawing.Point(4, 29);
            this.quan_li_tab.Name = "quan_li_tab";
            this.quan_li_tab.Padding = new System.Windows.Forms.Padding(3);
            this.quan_li_tab.Size = new System.Drawing.Size(937, 438);
            this.quan_li_tab.TabIndex = 0;
            this.quan_li_tab.Text = " Quản lí sách";
            this.quan_li_tab.UseVisualStyleBackColor = true;
            // 
            // bang_sach
            // 
            this.bang_sach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bang_sach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.bang_sach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bang_sach.Location = new System.Drawing.Point(8, 179);
            this.bang_sach.Name = "bang_sach";
            this.bang_sach.RowHeadersWidth = 62;
            this.bang_sach.RowTemplate.Height = 28;
            this.bang_sach.Size = new System.Drawing.Size(921, 251);
            this.bang_sach.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(931, 175);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ten_sach_textbox);
            this.panel1.Controls.Add(this.ma_sach_textbox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(459, 169);
            this.panel1.TabIndex = 0;
            // 
            // ten_sach_textbox
            // 
            this.ten_sach_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ten_sach_textbox.Location = new System.Drawing.Point(117, 91);
            this.ten_sach_textbox.Name = "ten_sach_textbox";
            this.ten_sach_textbox.Size = new System.Drawing.Size(277, 26);
            this.ten_sach_textbox.TabIndex = 3;
            // 
            // ma_sach_textbox
            // 
            this.ma_sach_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ma_sach_textbox.Location = new System.Drawing.Point(117, 28);
            this.ma_sach_textbox.Name = "ma_sach_textbox";
            this.ma_sach_textbox.Size = new System.Drawing.Size(277, 26);
            this.ma_sach_textbox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên sách";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã sách";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.them_button);
            this.panel2.Location = new System.Drawing.Point(468, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(460, 169);
            this.panel2.TabIndex = 1;
            // 
            // them_button
            // 
            this.them_button.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.them_button.Location = new System.Drawing.Point(83, 34);
            this.them_button.Name = "them_button";
            this.them_button.Size = new System.Drawing.Size(212, 83);
            this.them_button.TabIndex = 0;
            this.them_button.Text = "Thêm";
            this.them_button.UseVisualStyleBackColor = true;
            this.them_button.Click += new System.EventHandler(this.them_button_Click);
            // 
            // muon_tra_tab
            // 
            this.muon_tra_tab.Controls.Add(this.bang_muon_tra);
            this.muon_tra_tab.Controls.Add(this.tableLayoutPanel2);
            this.muon_tra_tab.Location = new System.Drawing.Point(4, 29);
            this.muon_tra_tab.Name = "muon_tra_tab";
            this.muon_tra_tab.Padding = new System.Windows.Forms.Padding(3);
            this.muon_tra_tab.Size = new System.Drawing.Size(937, 438);
            this.muon_tra_tab.TabIndex = 1;
            this.muon_tra_tab.Text = "Mượn/Trả sách";
            this.muon_tra_tab.UseVisualStyleBackColor = true;
            // 
            // bang_muon_tra
            // 
            this.bang_muon_tra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bang_muon_tra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.bang_muon_tra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bang_muon_tra.Location = new System.Drawing.Point(3, 164);
            this.bang_muon_tra.Name = "bang_muon_tra";
            this.bang_muon_tra.ReadOnly = true;
            this.bang_muon_tra.RowHeadersWidth = 62;
            this.bang_muon_tra.RowTemplate.Height = 28;
            this.bang_muon_tra.Size = new System.Drawing.Size(931, 271);
            this.bang_muon_tra.TabIndex = 1;
            this.bang_muon_tra.DataSourceChanged += new System.EventHandler(this.bang_muon_tra_DataSourceChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 129F));
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel5, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(931, 158);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.ten_sach_combobox);
            this.panel3.Controls.Add(this.ma_sach_combobox);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.ten_sv_combobox);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(395, 152);
            this.panel3.TabIndex = 0;
            // 
            // ten_sach_combobox
            // 
            this.ten_sach_combobox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ten_sach_combobox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ten_sach_combobox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ten_sach_combobox.DisplayMember = "OOP";
            this.ten_sach_combobox.DropDownHeight = 80;
            this.ten_sach_combobox.FormattingEnabled = true;
            this.ten_sach_combobox.IntegralHeight = false;
            this.ten_sach_combobox.Location = new System.Drawing.Point(160, 103);
            this.ten_sach_combobox.Name = "ten_sach_combobox";
            this.ten_sach_combobox.Size = new System.Drawing.Size(195, 28);
            this.ten_sach_combobox.TabIndex = 7;
            this.ten_sach_combobox.ValueMember = " ";
            this.ten_sach_combobox.DataSourceChanged += new System.EventHandler(this.ten_sach_combobox_DataSourceChanged);
            this.ten_sach_combobox.SelectedValueChanged += new System.EventHandler(this.ten_sach_combobox_SelectedValueChanged);
            // 
            // ma_sach_combobox
            // 
            this.ma_sach_combobox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ma_sach_combobox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ma_sach_combobox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ma_sach_combobox.DisplayMember = " ";
            this.ma_sach_combobox.DropDownHeight = 80;
            this.ma_sach_combobox.FormattingEnabled = true;
            this.ma_sach_combobox.IntegralHeight = false;
            this.ma_sach_combobox.Location = new System.Drawing.Point(160, 62);
            this.ma_sach_combobox.Name = "ma_sach_combobox";
            this.ma_sach_combobox.Size = new System.Drawing.Size(195, 28);
            this.ma_sach_combobox.TabIndex = 6;
            this.ma_sach_combobox.SelectedValueChanged += new System.EventHandler(this.ma_sach_combobox_SelectedValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 20);
            this.label8.TabIndex = 5;
            this.label8.Text = "Mã sách";
            // 
            // ten_sv_combobox
            // 
            this.ten_sv_combobox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ten_sv_combobox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ten_sv_combobox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ten_sv_combobox.DropDownHeight = 80;
            this.ten_sv_combobox.FormattingEnabled = true;
            this.ten_sv_combobox.IntegralHeight = false;
            this.ten_sv_combobox.Location = new System.Drawing.Point(160, 18);
            this.ten_sv_combobox.Name = "ten_sv_combobox";
            this.ten_sv_combobox.Size = new System.Drawing.Size(195, 28);
            this.ten_sv_combobox.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Tên sách";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tên sinh viên";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ngay_tra_picker);
            this.panel4.Controls.Add(this.ngay_muon_picker);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(404, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(395, 152);
            this.panel4.TabIndex = 1;
            // 
            // ngay_tra_picker
            // 
            this.ngay_tra_picker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ngay_tra_picker.Location = new System.Drawing.Point(120, 69);
            this.ngay_tra_picker.Name = "ngay_tra_picker";
            this.ngay_tra_picker.Size = new System.Drawing.Size(268, 26);
            this.ngay_tra_picker.TabIndex = 4;
            // 
            // ngay_muon_picker
            // 
            this.ngay_muon_picker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ngay_muon_picker.Location = new System.Drawing.Point(120, 26);
            this.ngay_muon_picker.Name = "ngay_muon_picker";
            this.ngay_muon_picker.Size = new System.Drawing.Size(268, 26);
            this.ngay_muon_picker.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Ngày trả";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ngày mượn";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.muon_button);
            this.panel5.Controls.Add(this.tra_button);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(805, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(123, 152);
            this.panel5.TabIndex = 2;
            // 
            // muon_button
            // 
            this.muon_button.Location = new System.Drawing.Point(7, 21);
            this.muon_button.Name = "muon_button";
            this.muon_button.Size = new System.Drawing.Size(111, 46);
            this.muon_button.TabIndex = 6;
            this.muon_button.Text = "Mượn sách";
            this.muon_button.UseVisualStyleBackColor = true;
            this.muon_button.Click += new System.EventHandler(this.muon_button_Click);
            // 
            // tra_button
            // 
            this.tra_button.Location = new System.Drawing.Point(7, 77);
            this.tra_button.Name = "tra_button";
            this.tra_button.Size = new System.Drawing.Size(111, 46);
            this.tra_button.TabIndex = 7;
            this.tra_button.Text = "Trả sách";
            this.tra_button.UseVisualStyleBackColor = true;
            this.tra_button.Click += new System.EventHandler(this.tra_button_Click);
            // 
            // thong_ke_tab
            // 
            this.thong_ke_tab.Controls.Add(this.guna2Button2);
            this.thong_ke_tab.Controls.Add(this.guna2Button1);
            this.thong_ke_tab.Controls.Add(this.dataGridView3);
            this.thong_ke_tab.Location = new System.Drawing.Point(4, 29);
            this.thong_ke_tab.Name = "thong_ke_tab";
            this.thong_ke_tab.Padding = new System.Windows.Forms.Padding(3);
            this.thong_ke_tab.Size = new System.Drawing.Size(937, 438);
            this.thong_ke_tab.TabIndex = 2;
            this.thong_ke_tab.Text = "Thống kê";
            this.thong_ke_tab.UseVisualStyleBackColor = true;
            // 
            // guna2Button2
            // 
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Location = new System.Drawing.Point(542, 37);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(122, 45);
            this.guna2Button2.TabIndex = 3;
            this.guna2Button2.Text = "SáchTrend";
            // 
            // guna2Button1
            // 
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(179, 37);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(237, 45);
            this.guna2Button1.TabIndex = 2;
            this.guna2Button1.Text = "Sinh viên mượn quá hạn";
            this.guna2Button1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(3, 105);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 62;
            this.dataGridView3.RowTemplate.Height = 28;
            this.dataGridView3.Size = new System.Drawing.Size(931, 330);
            this.dataGridView3.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(945, 471);
            this.Controls.Add(this.tab);
            this.MinimumSize = new System.Drawing.Size(967, 527);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lí mượn sách";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tab.ResumeLayout(false);
            this.quan_li_tab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bang_sach)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.muon_tra_tab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bang_muon_tra)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.thong_ke_tab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage quan_li_tab;
        private System.Windows.Forms.TabPage muon_tra_tab;
        private System.Windows.Forms.TabPage thong_ke_tab;
        private System.Windows.Forms.DataGridView bang_sach;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ten_sach_textbox;
        private System.Windows.Forms.TextBox ma_sach_textbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView bang_muon_tra;
        private System.Windows.Forms.ComboBox ten_sv_combobox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button tra_button;
        private System.Windows.Forms.Button muon_button;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DateTimePicker ngay_tra_picker;
        private System.Windows.Forms.DateTimePicker ngay_muon_picker;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button them_button;
        private System.Windows.Forms.DataGridView dataGridView3;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.ComboBox ma_sach_combobox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox ten_sach_combobox;
    }
}

