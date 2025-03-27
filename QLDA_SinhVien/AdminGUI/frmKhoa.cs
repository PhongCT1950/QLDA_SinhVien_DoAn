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
    public partial class frmKhoa: Form
    {
        KhoaService khoaService = new KhoaService();
        bool isEdit = false;
        public frmKhoa()
        {
            InitializeComponent();
        }

        private void frmKhoa_Load(object sender, EventArgs e)
        {
            loadListKhoa();
        }

       public void loadHuy()
        {
            txt_Makhoa.Text = "";
            txt_TenKhoa.Text = "";
            btn_Them.Text = "Thêm";
            isEdit = false;
        }

        public void loadListKhoa()
        {
            DataTable khoa = khoaService.getDataKhoa();
            dtgv_Khoa.DataSource = khoa;

            dtgv_Khoa.Columns["MAKHOA"].HeaderText = "MaKhoa";
            dtgv_Khoa.Columns["TENKHOA"].HeaderText = "Tên Khoa";
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            loadHuy();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isEdit)
                {
                    string tenkhoa = txt_TenKhoa.Text.Trim();
                    khoaService.addDataKhoa(tenkhoa);

                    loadListKhoa();
                    loadHuy();
                    MessageBox.Show("Thêm khoa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    KhoaDTO khoa = new KhoaDTO();
                    khoa.MaKhoa = int.Parse(txt_Makhoa.Text.Trim());
                    khoa.TenKhoa = txt_TenKhoa.Text.Trim();

                    khoaService.updateDataKhoa(khoa);

                    loadListKhoa();
                    loadHuy();
                    MessageBox.Show("Sửa khoa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                string makhoa = dtgv_Khoa.SelectedRows[0].Cells["MAKHOA"].Value.ToString();
                DataTable khoa = khoaService.getDataKhoaEdit(makhoa);

                txt_Makhoa.Text = khoa.Rows[0]["MAKHOA"].ToString();
                txt_TenKhoa.Text = khoa.Rows[0]["TENKHOA"].ToString();
                isEdit = true;
                btn_Them.Text = "Lưu";
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
                DialogResult = MessageBox.Show("Xác nhận xóa khoa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    string makhoa = dtgv_Khoa.SelectedRows[0].Cells["MAKHOA"].Value.ToString();

                    khoaService.deleteDataKhoa(makhoa);

                    loadListKhoa();
                    loadHuy();
                    MessageBox.Show("Xóa khoa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            DataTable khoa = khoaService.getDataKhoaFind(keyword);

            dtgv_Khoa.DataSource = khoa;
        }
    }
}
