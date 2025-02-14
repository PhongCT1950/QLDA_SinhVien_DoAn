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

                Form newForm = null;

                switch (role.ToLower())
                {
                    case "sinhvien":
                        MessageBox.Show("Đăng nhập thành công: Sinh Viên", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case "giangvien":
                        MessageBox.Show("Đăng nhập thành công: Giảng Viên", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    default:
                        MessageBox.Show("Đăng nhập thành công: Admin", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
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
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
