namespace QLDA_SinhVien.StudentGUI
{
    partial class frmGoiYGiangVien
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
            this.components = new System.ComponentModel.Container();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.rtxtMoTa = new System.Windows.Forms.RichTextBox();
            this.guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.cmbNganh = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cmb_LoaiDT = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmb_Nganh = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnGoiY = new Guna.UI2.WinForms.Guna2Button();
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(189, 14);
            this.guna2HtmlLabel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(409, 33);
            this.guna2HtmlLabel1.TabIndex = 0;
            this.guna2HtmlLabel1.Text = "Gợi ý đề tài và giảng viên phù hợp";
            // 
            // rtxtMoTa
            // 
            this.rtxtMoTa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtMoTa.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.rtxtMoTa.Location = new System.Drawing.Point(105, 110);
            this.rtxtMoTa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rtxtMoTa.Name = "rtxtMoTa";
            this.rtxtMoTa.Size = new System.Drawing.Size(596, 195);
            this.rtxtMoTa.TabIndex = 4;
            this.rtxtMoTa.Text = "";
            this.rtxtMoTa.Click += new System.EventHandler(this.rtxtMoTa_Click);
            // 
            // guna2MessageDialog1
            // 
            this.guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.guna2MessageDialog1.Caption = "Đề tài được gợi ý";
            this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
            this.guna2MessageDialog1.Parent = this;
            this.guna2MessageDialog1.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;
            this.guna2MessageDialog1.Text = null;
            // 
            // cmbNganh
            // 
            this.cmbNganh.BackColor = System.Drawing.Color.Transparent;
            this.cmbNganh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNganh.Location = new System.Drawing.Point(24, 68);
            this.cmbNganh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbNganh.Name = "cmbNganh";
            this.cmbNganh.Size = new System.Drawing.Size(67, 27);
            this.cmbNganh.TabIndex = 5;
            this.cmbNganh.Text = "Ngành:";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(372, 68);
            this.guna2HtmlLabel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(100, 27);
            this.guna2HtmlLabel3.TabIndex = 6;
            this.guna2HtmlLabel3.Text = "Loại đồ án:";
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(33, 110);
            this.guna2HtmlLabel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(58, 27);
            this.guna2HtmlLabel4.TabIndex = 7;
            this.guna2HtmlLabel4.Text = "Mô tả:";
            // 
            // cmb_LoaiDT
            // 
            this.cmb_LoaiDT.BackColor = System.Drawing.Color.Transparent;
            this.cmb_LoaiDT.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_LoaiDT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_LoaiDT.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmb_LoaiDT.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmb_LoaiDT.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmb_LoaiDT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmb_LoaiDT.ItemHeight = 30;
            this.cmb_LoaiDT.Location = new System.Drawing.Point(480, 64);
            this.cmb_LoaiDT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmb_LoaiDT.Name = "cmb_LoaiDT";
            this.cmb_LoaiDT.Size = new System.Drawing.Size(221, 36);
            this.cmb_LoaiDT.TabIndex = 9;
            // 
            // cmb_Nganh
            // 
            this.cmb_Nganh.BackColor = System.Drawing.Color.Transparent;
            this.cmb_Nganh.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_Nganh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Nganh.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmb_Nganh.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmb_Nganh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmb_Nganh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmb_Nganh.ItemHeight = 30;
            this.cmb_Nganh.Location = new System.Drawing.Point(105, 64);
            this.cmb_Nganh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmb_Nganh.Name = "cmb_Nganh";
            this.cmb_Nganh.Size = new System.Drawing.Size(221, 36);
            this.cmb_Nganh.TabIndex = 10;
            // 
            // btnGoiY
            // 
            this.btnGoiY.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGoiY.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGoiY.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGoiY.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGoiY.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
            this.btnGoiY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoiY.ForeColor = System.Drawing.Color.White;
            this.btnGoiY.Location = new System.Drawing.Point(504, 315);
            this.btnGoiY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGoiY.Name = "btnGoiY";
            this.btnGoiY.Size = new System.Drawing.Size(197, 39);
            this.btnGoiY.TabIndex = 11;
            this.btnGoiY.Text = "Gợi ý";
            this.btnGoiY.Click += new System.EventHandler(this.btnGoiY_Click_1);
            // 
            // btnBack
            // 
            this.btnBack.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBack.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBack.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(105, 315);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(107, 39);
            this.btnBack.TabIndex = 12;
            this.btnBack.Text = "Quay lại";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // frmGoiYGiangVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 377);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnGoiY);
            this.Controls.Add(this.cmb_Nganh);
            this.Controls.Add(this.cmb_LoaiDT);
            this.Controls.Add(this.guna2HtmlLabel4);
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.cmbNganh);
            this.Controls.Add(this.rtxtMoTa);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmGoiYGiangVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGoiYGiangVien";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private System.Windows.Forms.RichTextBox rtxtMoTa;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel cmbNganh;
        private Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog1;
        private Guna.UI2.WinForms.Guna2ComboBox cmb_Nganh;
        private Guna.UI2.WinForms.Guna2ComboBox cmb_LoaiDT;
        private Guna.UI2.WinForms.Guna2Button btnGoiY;
        private Guna.UI2.WinForms.Guna2Button btnBack;
    }
}