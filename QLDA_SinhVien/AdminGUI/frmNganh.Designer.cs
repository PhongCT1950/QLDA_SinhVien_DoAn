namespace QLDA_SinhVien.AdminGUI
{
    partial class frmNganh
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
            this.txt_Find = new Guna.UI2.WinForms.Guna2TextBox();
            this.btn_Sua = new Guna.UI2.WinForms.Guna2Button();
            this.btn_Xoa = new Guna.UI2.WinForms.Guna2Button();
            this.txt_TenNganh = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtgv_Nganh = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.cmb_khoa = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_MaNG = new Guna.UI2.WinForms.Guna2TextBox();
            this.label_Notify = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Them = new Guna.UI2.WinForms.Guna2Button();
            this.btn_Huy = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_Nganh)).BeginInit();
            this.panel2.SuspendLayout();
            this.guna2GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_Find
            // 
            this.txt_Find.BorderColor = System.Drawing.Color.Black;
            this.txt_Find.BorderRadius = 2;
            this.txt_Find.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Find.DefaultText = "";
            this.txt_Find.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_Find.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_Find.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Find.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Find.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Find.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Find.ForeColor = System.Drawing.Color.Black;
            this.txt_Find.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Find.Location = new System.Drawing.Point(465, 176);
            this.txt_Find.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txt_Find.Name = "txt_Find";
            this.txt_Find.PasswordChar = '\0';
            this.txt_Find.PlaceholderText = "Thông tin cần tìm...";
            this.txt_Find.SelectedText = "";
            this.txt_Find.Size = new System.Drawing.Size(593, 50);
            this.txt_Find.TabIndex = 14;
            this.txt_Find.TextChanged += new System.EventHandler(this.txt_Find_TextChanged);
            // 
            // btn_Sua
            // 
            this.btn_Sua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Sua.BorderRadius = 4;
            this.btn_Sua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Sua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Sua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Sua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Sua.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
            this.btn_Sua.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sua.ForeColor = System.Drawing.Color.White;
            this.btn_Sua.Location = new System.Drawing.Point(1163, 752);
            this.btn_Sua.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(104, 50);
            this.btn_Sua.TabIndex = 17;
            this.btn_Sua.Text = "Sửa";
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Xoa.BorderRadius = 4;
            this.btn_Xoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Xoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Xoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Xoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Xoa.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
            this.btn_Xoa.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Xoa.ForeColor = System.Drawing.Color.White;
            this.btn_Xoa.Location = new System.Drawing.Point(1292, 752);
            this.btn_Xoa.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(104, 50);
            this.btn_Xoa.TabIndex = 18;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // txt_TenNganh
            // 
            this.txt_TenNganh.BorderRadius = 2;
            this.txt_TenNganh.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_TenNganh.DefaultText = "";
            this.txt_TenNganh.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_TenNganh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_TenNganh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_TenNganh.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_TenNganh.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_TenNganh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TenNganh.ForeColor = System.Drawing.Color.Black;
            this.txt_TenNganh.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_TenNganh.Location = new System.Drawing.Point(661, 82);
            this.txt_TenNganh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_TenNganh.Name = "txt_TenNganh";
            this.txt_TenNganh.PasswordChar = '\0';
            this.txt_TenNganh.PlaceholderText = "Nhập tên ngành";
            this.txt_TenNganh.SelectedText = "";
            this.txt_TenNganh.Size = new System.Drawing.Size(286, 35);
            this.txt_TenNganh.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 205);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 21);
            this.label2.TabIndex = 97;
            this.label2.Text = "Danh sách ngành";
            // 
            // dtgv_Nganh
            // 
            this.dtgv_Nganh.AllowUserToAddRows = false;
            this.dtgv_Nganh.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dtgv_Nganh.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgv_Nganh.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_Nganh.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgv_Nganh.ColumnHeadersHeight = 30;
            this.dtgv_Nganh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgv_Nganh.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgv_Nganh.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtgv_Nganh.GridColor = System.Drawing.Color.White;
            this.dtgv_Nganh.Location = new System.Drawing.Point(22, 234);
            this.dtgv_Nganh.Name = "dtgv_Nganh";
            this.dtgv_Nganh.RowHeadersVisible = false;
            this.dtgv_Nganh.RowHeadersWidth = 51;
            this.dtgv_Nganh.RowTemplate.Height = 24;
            this.dtgv_Nganh.Size = new System.Drawing.Size(1512, 511);
            this.dtgv_Nganh.TabIndex = 44;
            this.dtgv_Nganh.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_Nganh.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtgv_Nganh.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.White;
            this.dtgv_Nganh.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(236)))), ((int)(((byte)(139)))));
            this.dtgv_Nganh.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtgv_Nganh.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_Nganh.ThemeStyle.GridColor = System.Drawing.Color.White;
            this.dtgv_Nganh.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
            this.dtgv_Nganh.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            this.dtgv_Nganh.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv_Nganh.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.dtgv_Nganh.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv_Nganh.ThemeStyle.HeaderStyle.Height = 30;
            this.dtgv_Nganh.ThemeStyle.ReadOnly = false;
            this.dtgv_Nganh.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_Nganh.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgv_Nganh.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv_Nganh.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgv_Nganh.ThemeStyle.RowsStyle.Height = 24;
            this.dtgv_Nganh.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgv_Nganh.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dtgv_Nganh);
            this.panel2.Controls.Add(this.guna2GroupBox1);
            this.panel2.Controls.Add(this.txt_Find);
            this.panel2.Controls.Add(this.btn_Them);
            this.panel2.Controls.Add(this.btn_Sua);
            this.panel2.Controls.Add(this.btn_Xoa);
            this.panel2.Controls.Add(this.btn_Huy);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1562, 817);
            this.panel2.TabIndex = 9;
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GroupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.guna2GroupBox1.Controls.Add(this.cmb_khoa);
            this.guna2GroupBox1.Controls.Add(this.label3);
            this.guna2GroupBox1.Controls.Add(this.txt_TenNganh);
            this.guna2GroupBox1.Controls.Add(this.label1);
            this.guna2GroupBox1.Controls.Add(this.txt_MaNG);
            this.guna2GroupBox1.Controls.Add(this.label_Notify);
            this.guna2GroupBox1.Controls.Add(this.label5);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
            this.guna2GroupBox1.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.guna2GroupBox1.Location = new System.Drawing.Point(17, 4);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(1513, 164);
            this.guna2GroupBox1.TabIndex = 43;
            this.guna2GroupBox1.Text = "Thông Tin Ngành";
            // 
            // cmb_khoa
            // 
            this.cmb_khoa.BackColor = System.Drawing.Color.Transparent;
            this.cmb_khoa.BorderRadius = 2;
            this.cmb_khoa.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_khoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_khoa.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmb_khoa.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmb_khoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_khoa.ForeColor = System.Drawing.Color.Black;
            this.cmb_khoa.ItemHeight = 30;
            this.cmb_khoa.Location = new System.Drawing.Point(1165, 82);
            this.cmb_khoa.Name = "cmb_khoa";
            this.cmb_khoa.Size = new System.Drawing.Size(286, 36);
            this.cmb_khoa.TabIndex = 105;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label3.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1064, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 21);
            this.label3.TabIndex = 104;
            this.label3.Text = "Khoa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(535, 90);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 21);
            this.label1.TabIndex = 73;
            this.label1.Text = "Tên Ngành";
            // 
            // txt_MaNG
            // 
            this.txt_MaNG.BorderRadius = 2;
            this.txt_MaNG.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_MaNG.DefaultText = "";
            this.txt_MaNG.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_MaNG.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_MaNG.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_MaNG.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_MaNG.Enabled = false;
            this.txt_MaNG.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_MaNG.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MaNG.ForeColor = System.Drawing.Color.Black;
            this.txt_MaNG.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_MaNG.Location = new System.Drawing.Point(150, 82);
            this.txt_MaNG.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_MaNG.Name = "txt_MaNG";
            this.txt_MaNG.PasswordChar = '\0';
            this.txt_MaNG.PlaceholderText = "";
            this.txt_MaNG.SelectedText = "";
            this.txt_MaNG.Size = new System.Drawing.Size(286, 35);
            this.txt_MaNG.TabIndex = 1;
            // 
            // label_Notify
            // 
            this.label_Notify.BackColor = System.Drawing.Color.Transparent;
            this.label_Notify.Location = new System.Drawing.Point(0, 0);
            this.label_Notify.Name = "label_Notify";
            this.label_Notify.Size = new System.Drawing.Size(3, 2);
            this.label_Notify.TabIndex = 71;
            this.label_Notify.Text = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label5.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(35, 90);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 21);
            this.label5.TabIndex = 54;
            this.label5.Text = "Mã Ngành";
            // 
            // btn_Them
            // 
            this.btn_Them.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Them.BorderRadius = 4;
            this.btn_Them.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Them.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Them.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Them.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Them.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
            this.btn_Them.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Them.ForeColor = System.Drawing.Color.White;
            this.btn_Them.Location = new System.Drawing.Point(1035, 752);
            this.btn_Them.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(104, 50);
            this.btn_Them.TabIndex = 16;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // btn_Huy
            // 
            this.btn_Huy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Huy.BorderRadius = 4;
            this.btn_Huy.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Huy.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Huy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Huy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Huy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
            this.btn_Huy.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Huy.ForeColor = System.Drawing.Color.White;
            this.btn_Huy.Location = new System.Drawing.Point(1425, 752);
            this.btn_Huy.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Huy.Name = "btn_Huy";
            this.btn_Huy.Size = new System.Drawing.Size(104, 50);
            this.btn_Huy.TabIndex = 19;
            this.btn_Huy.Text = "Hủy";
            this.btn_Huy.Click += new System.EventHandler(this.btn_Huy_Click);
            // 
            // frmNganh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1562, 817);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNganh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNganh";
            this.Load += new System.EventHandler(this.frmNganh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_Nganh)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txt_Find;
        private Guna.UI2.WinForms.Guna2Button btn_Sua;
        private Guna.UI2.WinForms.Guna2Button btn_Xoa;
        private Guna.UI2.WinForms.Guna2TextBox txt_TenNganh;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2DataGridView dtgv_Nganh;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txt_MaNG;
        private Guna.UI2.WinForms.Guna2HtmlLabel label_Notify;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Button btn_Them;
        private Guna.UI2.WinForms.Guna2Button btn_Huy;
        private Guna.UI2.WinForms.Guna2ComboBox cmb_khoa;
        private System.Windows.Forms.Label label3;
    }
}