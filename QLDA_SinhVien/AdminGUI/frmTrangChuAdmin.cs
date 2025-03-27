using DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDA_SinhVien.AdminGUI
{
    public partial class frmTrangChuAdmin: Form
    {
        private bool isDragging = false;
        private Point startPoint;
        public frmTrangChuAdmin()
        {
            InitializeComponent();
            Guna2BorderlessForm gunaBorderlessForm = new Guna2BorderlessForm();
            gunaBorderlessForm.ContainerControl = this;
            this.Size = new Size(1280, 720);

            gunaBorderlessForm.BorderRadius = 15;
            panel1.MouseDown += Panel1_MouseDown;
            panel1.MouseMove += Panel1_MouseMove;
            panel1.MouseUp += Panel1_MouseUp;
        }

        private Form currentFormChild;
        private void OpenFormChild(Form childform)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            //childform.Dock = DockStyle.Fill;
            panel_body.Controls.Add(childform);
            panel_body.Tag = childform;
            childform.BringToFront();
            childform.Show();
        }

        private void frmTrangChuAdmin_Load(object sender, EventArgs e)
        {

        }

        private void btn_Minimize_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_Close_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_SinhVien_Click(object sender, EventArgs e)
        {
            OpenFormChild(new frmSinhVien());
        }
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            startPoint = new Point(e.X, e.Y); 
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point newPosition = PointToScreen(e.Location);
                Location = new Point(newPosition.X - startPoint.X, newPosition.Y - startPoint.Y);
            }
        }

        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void btn_ttcn_Click(object sender, EventArgs e)
        {
            UserSession.UserID = 0;
            UserSession.Username = null;
            UserSession.Role = null;
            UserSession.Refld = null;

            this.Close();
            frmLogin f = new frmLogin();
            f.Show();
        }

        private void btn_giangvien_Click(object sender, EventArgs e)
        {
            OpenFormChild(new frmGiangVien());
        }

        private void btn_taiKhoan_Click(object sender, EventArgs e)
        {
            OpenFormChild(new frmTaiKhoan());
        }

        private void btn_khoa_Click(object sender, EventArgs e)
        {
            OpenFormChild(new frmKhoa());
        }

        private void btn_nganh_Click(object sender, EventArgs e)
        {
            OpenFormChild(new frmNganh());
        }

        private void btn_ChucDanh_Click(object sender, EventArgs e)
        {
            OpenFormChild(new frmChucDanh());
        }
    }
}
