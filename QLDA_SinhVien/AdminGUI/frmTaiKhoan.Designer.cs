namespace QLDA_SinhVien.AdminGUI
{
    partial class frmTaiKhoan
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
            this.btn_Lưu = new Guna.UI2.WinForms.Guna2Button();
            this.btn_Huy = new Guna.UI2.WinForms.Guna2Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dtgv_TaiKhoan = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.cmb_role = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txt_passWord = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_UserID = new Guna.UI2.WinForms.Guna2TextBox();
            this.label_Notify = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txt_UserName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Find = new Guna.UI2.WinForms.Guna2TextBox();
            this.btn_Sua = new Guna.UI2.WinForms.Guna2Button();
            this.btn_Xoa = new Guna.UI2.WinForms.Guna2Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_TaiKhoan)).BeginInit();
            this.guna2GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Lưu
            // 
            this.btn_Lưu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Lưu.BorderRadius = 4;
            this.btn_Lưu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Lưu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Lưu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Lưu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Lưu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
            this.btn_Lưu.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Lưu.ForeColor = System.Drawing.Color.White;
            this.btn_Lưu.Location = new System.Drawing.Point(1035, 752);
            this.btn_Lưu.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Lưu.Name = "btn_Lưu";
            this.btn_Lưu.Size = new System.Drawing.Size(104, 50);
            this.btn_Lưu.TabIndex = 16;
            this.btn_Lưu.Text = "Lưu";
            this.btn_Lưu.Click += new System.EventHandler(this.btn_Lưu_Click);
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
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dtgv_TaiKhoan);
            this.panel2.Controls.Add(this.guna2GroupBox1);
            this.panel2.Controls.Add(this.txt_Find);
            this.panel2.Controls.Add(this.btn_Lưu);
            this.panel2.Controls.Add(this.btn_Sua);
            this.panel2.Controls.Add(this.btn_Xoa);
            this.panel2.Controls.Add(this.btn_Huy);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1562, 817);
            this.panel2.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 277);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 21);
            this.label2.TabIndex = 97;
            this.label2.Text = "Danh sách tài khoản";
            // 
            // dtgv_TaiKhoan
            // 
            this.dtgv_TaiKhoan.AllowUserToAddRows = false;
            this.dtgv_TaiKhoan.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dtgv_TaiKhoan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgv_TaiKhoan.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_TaiKhoan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgv_TaiKhoan.ColumnHeadersHeight = 30;
            this.dtgv_TaiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgv_TaiKhoan.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgv_TaiKhoan.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtgv_TaiKhoan.GridColor = System.Drawing.Color.White;
            this.dtgv_TaiKhoan.Location = new System.Drawing.Point(22, 306);
            this.dtgv_TaiKhoan.Name = "dtgv_TaiKhoan";
            this.dtgv_TaiKhoan.RowHeadersVisible = false;
            this.dtgv_TaiKhoan.RowHeadersWidth = 51;
            this.dtgv_TaiKhoan.RowTemplate.Height = 24;
            this.dtgv_TaiKhoan.Size = new System.Drawing.Size(1512, 439);
            this.dtgv_TaiKhoan.TabIndex = 44;
            this.dtgv_TaiKhoan.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_TaiKhoan.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtgv_TaiKhoan.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.White;
            this.dtgv_TaiKhoan.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(236)))), ((int)(((byte)(139)))));
            this.dtgv_TaiKhoan.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtgv_TaiKhoan.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_TaiKhoan.ThemeStyle.GridColor = System.Drawing.Color.White;
            this.dtgv_TaiKhoan.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
            this.dtgv_TaiKhoan.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            this.dtgv_TaiKhoan.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv_TaiKhoan.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.dtgv_TaiKhoan.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgv_TaiKhoan.ThemeStyle.HeaderStyle.Height = 30;
            this.dtgv_TaiKhoan.ThemeStyle.ReadOnly = false;
            this.dtgv_TaiKhoan.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_TaiKhoan.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgv_TaiKhoan.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv_TaiKhoan.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgv_TaiKhoan.ThemeStyle.RowsStyle.Height = 24;
            this.dtgv_TaiKhoan.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgv_TaiKhoan.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GroupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.guna2GroupBox1.Controls.Add(this.cmb_role);
            this.guna2GroupBox1.Controls.Add(this.txt_passWord);
            this.guna2GroupBox1.Controls.Add(this.label3);
            this.guna2GroupBox1.Controls.Add(this.label1);
            this.guna2GroupBox1.Controls.Add(this.txt_UserID);
            this.guna2GroupBox1.Controls.Add(this.label_Notify);
            this.guna2GroupBox1.Controls.Add(this.txt_UserName);
            this.guna2GroupBox1.Controls.Add(this.label5);
            this.guna2GroupBox1.Controls.Add(this.label4);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
            this.guna2GroupBox1.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.guna2GroupBox1.Location = new System.Drawing.Point(17, 4);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(1513, 236);
            this.guna2GroupBox1.TabIndex = 43;
            this.guna2GroupBox1.Text = "Thông Tin Tài Khoản";
            // 
            // cmb_role
            // 
            this.cmb_role.BackColor = System.Drawing.Color.Transparent;
            this.cmb_role.BorderRadius = 2;
            this.cmb_role.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_role.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_role.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmb_role.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmb_role.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_role.ForeColor = System.Drawing.Color.Black;
            this.cmb_role.ItemHeight = 30;
            this.cmb_role.Location = new System.Drawing.Point(1029, 159);
            this.cmb_role.Name = "cmb_role";
            this.cmb_role.Size = new System.Drawing.Size(379, 36);
            this.cmb_role.TabIndex = 103;
            // 
            // txt_passWord
            // 
            this.txt_passWord.BorderRadius = 2;
            this.txt_passWord.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_passWord.DefaultText = "";
            this.txt_passWord.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_passWord.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_passWord.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_passWord.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_passWord.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_passWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_passWord.ForeColor = System.Drawing.Color.Black;
            this.txt_passWord.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_passWord.Location = new System.Drawing.Point(1029, 81);
            this.txt_passWord.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_passWord.Name = "txt_passWord";
            this.txt_passWord.PasswordChar = '\0';
            this.txt_passWord.PlaceholderText = "";
            this.txt_passWord.SelectedText = "";
            this.txt_passWord.Size = new System.Drawing.Size(379, 35);
            this.txt_passWord.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label3.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(903, 169);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 21);
            this.label3.TabIndex = 75;
            this.label3.Text = "Vai trò";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(903, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 21);
            this.label1.TabIndex = 73;
            this.label1.Text = "Mật khẩu";
            // 
            // txt_UserID
            // 
            this.txt_UserID.BorderRadius = 2;
            this.txt_UserID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_UserID.DefaultText = "";
            this.txt_UserID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_UserID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_UserID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_UserID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_UserID.Enabled = false;
            this.txt_UserID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_UserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_UserID.ForeColor = System.Drawing.Color.Black;
            this.txt_UserID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_UserID.Location = new System.Drawing.Point(215, 81);
            this.txt_UserID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_UserID.Name = "txt_UserID";
            this.txt_UserID.PasswordChar = '\0';
            this.txt_UserID.PlaceholderText = "";
            this.txt_UserID.SelectedText = "";
            this.txt_UserID.Size = new System.Drawing.Size(379, 35);
            this.txt_UserID.TabIndex = 1;
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
            // txt_UserName
            // 
            this.txt_UserName.BorderRadius = 2;
            this.txt_UserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_UserName.DefaultText = "";
            this.txt_UserName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_UserName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_UserName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_UserName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_UserName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_UserName.ForeColor = System.Drawing.Color.Black;
            this.txt_UserName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_UserName.Location = new System.Drawing.Point(215, 160);
            this.txt_UserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.PasswordChar = '\0';
            this.txt_UserName.PlaceholderText = "";
            this.txt_UserName.SelectedText = "";
            this.txt_UserName.Size = new System.Drawing.Size(379, 35);
            this.txt_UserName.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label5.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(34, 89);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 21);
            this.label5.TabIndex = 54;
            this.label5.Text = "UserID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label4.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 169);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 21);
            this.label4.TabIndex = 55;
            this.label4.Text = "Tên Tài Khoản";
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
            this.txt_Find.Location = new System.Drawing.Point(464, 248);
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
            // frmTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1562, 817);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTaiKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTaiKhoan";
            this.Load += new System.EventHandler(this.frmTaiKhoan_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_TaiKhoan)).EndInit();
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btn_Lưu;
        private Guna.UI2.WinForms.Guna2Button btn_Huy;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2DataGridView dtgv_TaiKhoan;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2ComboBox cmb_role;
        private Guna.UI2.WinForms.Guna2TextBox txt_passWord;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txt_UserID;
        private Guna.UI2.WinForms.Guna2HtmlLabel label_Notify;
        private Guna.UI2.WinForms.Guna2TextBox txt_UserName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txt_Find;
        private Guna.UI2.WinForms.Guna2Button btn_Sua;
        private Guna.UI2.WinForms.Guna2Button btn_Xoa;
        private System.Windows.Forms.Label label2;
    }
}