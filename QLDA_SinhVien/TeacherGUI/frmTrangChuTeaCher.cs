using BusinessLogicLayer;
using DTO;
using Guna.UI2.WinForms;
using QLDA_SinhVien.TeacherGUI;
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
    public partial class frmTrangChuTeaCher: Form
    {
        GiangVienService giangVienService = new GiangVienService();
        private bool isDragging = false;
        private Point startPoint;
        public frmTrangChuTeaCher()
        {
            InitializeComponent();
            Guna2BorderlessForm gunaBorderlessForm = new Guna2BorderlessForm();
            gunaBorderlessForm.ContainerControl = this;
            this.Size = new Size(1300, 720);

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
            childform.Dock = DockStyle.Fill;
            panel_body.Controls.Add(childform);
            panel_body.Tag = childform;
            childform.BringToFront();
            childform.Show();
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

        public void LoadName()
        {
            string MaGV = UserSession.Username;
            string NameGV = giangVienService.getNameGV(MaGV);

            txt_TenGV.Text = NameGV;
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            UserSession.UserID = 0;
            UserSession.Username = null;
            UserSession.Role = null;
            UserSession.Refld = null;

            this.Close();
            frmLogin f = new frmLogin();
            f.Show();
        }

        private void frmTrangChuTeaCher_Load(object sender, EventArgs e)
        {
            //LoadName();
        }

        private void btn_Detai_Click(object sender, EventArgs e)
        {
            OpenFormChild(new frmDeTai());
        }

        private void btn_Nhomsv_Click(object sender, EventArgs e)
        {
            OpenFormChild(new frmNhomSinhVien());
        }
    }
}
