using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using BusinessLogicLayer;
using DTO;
using QLDA_SinhVien.AdminGUI;

namespace QLDA_SinhVien
{
    public partial class frmLogin: Form
    {
        TaiKhoanService taiKhoanService = new TaiKhoanService();
        public frmLogin()
        {
            InitializeComponent();
            Guna2BorderlessForm gunaBorderlessForm = new Guna2BorderlessForm();
            gunaBorderlessForm.ContainerControl = this;
        }

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            string username = txt_username.Text.Trim();
            string password = txt_password.Text.Trim();

            try
            {
                string role = taiKhoanService.CheckRoleLg(username, password);

                TaiKhoanDTO user = taiKhoanService.GetTaiKhoan(username, password);
                if (user != null)
                {
                    UserSession.UserID = user.UserID;
                    UserSession.Username = user.Username;
                    UserSession.Role = user.Role;
                    UserSession.Refld = user.Refld;
                }
                switch (role.ToLower().Trim())
                {
                    case "sinhvien":
                        frmTrangChuStudent sinhvien = new frmTrangChuStudent();
                        sinhvien.Show();
                        break;

                    case "giangvien":
                        frmTrangChuTeaCher giangvien = new frmTrangChuTeaCher();
                        giangvien.Show();
                        break;

                    default:
                        frmTrangChuAdmin home = new frmTrangChuAdmin();
                        home.Show();
                        break;
                }
                this.Hide();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hệ thống đang gặp lỗi vui lòng thử lại sau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
