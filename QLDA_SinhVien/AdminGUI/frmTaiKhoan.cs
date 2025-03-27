using BusinessLogicLayer;
using DTO;
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
    public partial class frmTaiKhoan: Form
    {
        TaiKhoanService taiKhoanService = new TaiKhoanService();
        bool isEdit = false;
        public frmTaiKhoan()
        {
            InitializeComponent();
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            loadListTaiKhoan();
            loadCmbRole();

            btn_Lưu.Enabled = false;
        }

        public  void loadListTaiKhoan()
        {
            DataTable taikhoan = taiKhoanService.getDataTaiKhoan();

            dtgv_TaiKhoan.DataSource = taikhoan;

            dtgv_TaiKhoan.Columns["USERNAME"].HeaderText = "Tên Tài Khoản";
            dtgv_TaiKhoan.Columns["PASSWORD"].HeaderText = "Mật Khẩu";
            dtgv_TaiKhoan.Columns["ROLE"].HeaderText = "Vai Trò";
        }

        public void loadCmbRole()
        {
            DataTable role = taiKhoanService.getDataDsRole();

            cmb_role.DataSource = role;
            cmb_role.DisplayMember = "ROLE";
        }

        public void loadHuy()
        {
            txt_UserID.Text = "";
            txt_UserName.Text = "";
            txt_passWord.Text = "";
            isEdit = false;
            btn_Lưu.Enabled = false;

        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            loadHuy();
        }

        private void btn_Lưu_Click(object sender, EventArgs e)
        {
            try
            {
                TaiKhoanDTO taikhoan = new TaiKhoanDTO();
                taikhoan.UserID = int.Parse(txt_UserID.Text.Trim());
                taikhoan.Username = txt_UserName.Text.Trim();
                taikhoan.PassWord = txt_passWord.Text.Trim();
                taikhoan.Role = cmb_role.Text.Trim();

                taiKhoanService.updateDataTaiKhoan(taikhoan);

                loadListTaiKhoan();
                loadHuy();
                MessageBox.Show("Sửa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(ArgumentException loi)
            {
                MessageBox.Show(loi.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hệ thống đang gặp lỗi vui lòng thử lại sau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dtgv_TaiKhoan.SelectedRows[0].Cells["UserID"].Value.ToString();
                DataTable taikhoan = taiKhoanService.getDataTaiKhoanEdit(id);

                txt_UserID.Text = taikhoan.Rows[0]["UserID"].ToString();
                txt_UserName.Text = taikhoan.Rows[0]["USERNAME"].ToString();
                txt_passWord.Text = taikhoan.Rows[0]["PASSWORD"].ToString();
                cmb_role.Text = taikhoan.Rows[0]["ROLE"].ToString();
                isEdit = true;

                if (isEdit)
                {
                    btn_Lưu.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hệ thống đang gặp lỗi vui lòng thử lại sau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = MessageBox.Show("Xác nhận xóa tài khoản?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(DialogResult == DialogResult.Yes)
                {
                    string id = dtgv_TaiKhoan.SelectedRows[0].Cells["UserID"].Value.ToString();
                    taiKhoanService.deleteDataTaiKhoan(id);

                    loadListTaiKhoan();
                    loadHuy();
                    MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hệ thống đang gặp lỗi vui lòng thử lại sau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_Find_TextChanged(object sender, EventArgs e)
        {
            string keyword = txt_Find.Text.Trim();
            DataTable taikhoan = taiKhoanService.getDataTaiKhoanFind(keyword);

            dtgv_TaiKhoan.DataSource = taikhoan;
        }
    }
}
