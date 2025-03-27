using BusinessLogicLayer;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDA_SinhVien.TeacherGUI
{
    public partial class frmNhomSinhVien : Form
    {
        SinhVienService sinhVienService = new SinhVienService();
        NhomSinhVienService nhomSinhVienService = new NhomSinhVienService();
        bool IsEdit = false;
        public frmNhomSinhVien()
        {
            InitializeComponent();
        }

        private void frmNhomSinhVien_Load(object sender, EventArgs e)
        {
            LoadListSinhVien();
            loadMaNH();
            loadListNhom();
        }

        public void LoadListSinhVien()
        {
            dtgv_SinhVien.DataSource = sinhVienService.getListSinhVienNH();

            dtgv_SinhVien.Columns["MASV"].HeaderText = "MaSV";
            dtgv_SinhVien.Columns["TENSV"].HeaderText = "TenSV";
            dtgv_SinhVien.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
            dtgv_SinhVien.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dtgv_SinhVien.Columns["GioiTinh"].HeaderText = "Giới Tính";
            dtgv_SinhVien.Columns["SDT"].HeaderText = "SĐT";
            dtgv_SinhVien.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dtgv_SinhVien.Columns["Email"].HeaderText = "Email";
            dtgv_SinhVien.Columns["NIENKHOA"].HeaderText = "Niên Khóa";
            dtgv_SinhVien.Columns["TENNGANH"].HeaderText = "Ngành";
            dtgv_SinhVien.Columns["TENKHOA"].HeaderText = "Khoa";
            dtgv_SinhVien.Columns["TenHeDT"].HeaderText = "Hệ Đào Tạo";
        }

        public void loadListNhom()
        {
            dtgv_Nhom.DataSource = nhomSinhVienService.getDataNhomSV();

            dtgv_Nhom.Columns["TENNHOM"].HeaderText = "Tên Nhóm";
            dtgv_Nhom.Columns["Soluong"].HeaderText = "Số lượng thành viên";
            dtgv_Nhom.Columns["TENDT"].HeaderText = "Tên đề tài";
            foreach (DataGridViewRow row in dtgv_Nhom.Rows)
            {
                if (row.Cells["TENDT"].Value == null || string.IsNullOrWhiteSpace(row.Cells["TENDT"].Value.ToString()))
                {
                    row.Cells["TENDT"].Value = "Nhóm chưa đăng ký đề tài";
                }
            }
        }

        public void loadMaNH()
        {
            string MaNH = nhomSinhVienService.GenerateMaNH();

            txt_MaNH.Text = MaNH;
        }

        public void loadHuy()
        {
            txt_TenNH.Text = "";
            lsb_tvNhom.Items.Clear();
            btn_Them.Text = "Thêm";
            loadMaNH();
            IsEdit = false;
        }
        private void btn_ThemNH_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsb_tvNhom.Items.Count >= 5)
                {
                    MessageBox.Show("Nhóm tối đa số lượng thành viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dtgv_SinhVien.SelectedRows.Count > 0)
                {
                    string masv = dtgv_SinhVien.SelectedRows[0].Cells["MASV"].Value.ToString();
                    string tensv = dtgv_SinhVien.SelectedRows[0].Cells["TENSV"].Value.ToString();
                    bool exists = lsb_tvNhom.Items.Cast<string>().Any(item => item.Contains($"- {masv}"));

                    if (!exists)
                    {
                        int stt = lsb_tvNhom.Items.Count + 1;
                        string sinhvien = $"{tensv} - {masv}";
                        lsb_tvNhom.Items.Add(sinhvien);
                        LoadListSinhVien();
                    }
                    else
                    {
                        MessageBox.Show("Sinh viên đã có trong nhóm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn sinh viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (lsb_tvNhom.SelectedIndex != -1)
                {
                    lsb_tvNhom.Items.RemoveAt(lsb_tvNhom.SelectedIndex);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn thành viên cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hệ thống đang gặp lỗi vui lòng thử lại sau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsEdit)
                {
                    if (txt_TenNH.Text.Trim() == "" || lsb_tvNhom.Items.Count < 2)
                    {
                        MessageBox.Show("Vui lòng nhập đủ thông tin nhóm và ít nhất 2 thành viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    NhomSinhVienDTO nhomsv = new NhomSinhVienDTO();
                    nhomsv.MaNhom = txt_MaNH.Text;
                    nhomsv.TenNhom = txt_TenNH.Text;
                    nhomsv.SoLuong = lsb_tvNhom.Items.Count;

                    nhomSinhVienService.addDataInNhomSV(nhomsv);

                    foreach (var item in lsb_tvNhom.Items)
                    {
                        string masv = item.ToString().Split('-')[1].Trim();
                        nhomSinhVienService.addDataInChiTietNhom(nhomsv.MaNhom, masv);
                    }

                    MessageBox.Show("Thêm nhóm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListSinhVien();
                    loadListNhom();
                    loadHuy();
                }
                else
                {
                    if (txt_TenNH.Text.Trim() == "" || lsb_tvNhom.Items.Count < 2)
                    {
                        MessageBox.Show("Vui lòng nhập đủ thông tin nhóm và ít nhất 2 thành viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    NhomSinhVienDTO nhomsv = new NhomSinhVienDTO();
                    nhomsv.MaNhom = txt_MaNH.Text;
                    nhomsv.TenNhom = txt_TenNH.Text;
                    nhomsv.SoLuong = lsb_tvNhom.Items.Count;

                    nhomSinhVienService.updateDataNhomSV(nhomsv);
                    nhomSinhVienService.deleteDataThanhVien(nhomsv.MaNhom);
                    foreach (var item in lsb_tvNhom.Items)
                    {
                        string masv = item.ToString().Split('-')[1].Trim();
                        nhomSinhVienService.updateDataChiTietNhom(nhomsv.MaNhom, masv);
                    }

                    MessageBox.Show("Sửa nhóm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListSinhVien();
                    loadListNhom();
                    loadHuy();
                    btn_Them.Text = "Thêm";
                    IsEdit = false;
                }
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
                if (dtgv_Nhom.SelectedRows[0].Cells["MANHOM"].Value.ToString() == null)
                {
                    MessageBox.Show("Chưa chọn nhóm để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                lsb_tvNhom.Items.Clear();
                string MANHOM = dtgv_Nhom.SelectedRows[0].Cells["MANHOM"].Value.ToString();
                DataTable dsThanhVien = nhomSinhVienService.getDsThanhVienSV(MANHOM);
                txt_MaNH.Text = dsThanhVien.Rows[0]["MANHOM"].ToString();
                txt_TenNH.Text = dsThanhVien.Rows[0]["TENNHOM"].ToString();

                string danhSach = dsThanhVien.Rows[0]["DanhSachSinhVien"].ToString();
                string[] sinhVienArray = danhSach.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                lsb_tvNhom.Items.Clear();
                foreach (string sinhVien in sinhVienArray)
                {
                    lsb_tvNhom.Items.Add(sinhVien);
                }
                IsEdit = true;
                btn_Them.Text = "Lưu";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hệ thống đang gặp lỗi vui lòng thử lại sau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            loadHuy();
        }

        private void lsb_tvNhom_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadListSinhVien();
        }

        private void btn_Xoa_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dtgv_Nhom.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("Chưa chọn nhóm để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhóm đã chọn không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string manhom = dtgv_Nhom.SelectedRows[0].Cells["MANHOM"].Value.ToString();

                    string MaNH = nhomSinhVienService.getDataMaNHinDoAn(manhom);

                    if(manhom == MaNH)
                    {
                        nhomSinhVienService.deleteDataNhom(manhom);

                        MessageBox.Show("Xóa nhóm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadListSinhVien();
                        loadListNhom();
                        loadHuy();

                        return;
                    }

                    nhomSinhVienService.deleteDataNhomSV(manhom);

                    MessageBox.Show("Xóa nhóm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListSinhVien();
                    loadListNhom();
                    loadHuy();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hệ thống đang gặp lỗi vui lòng thử lại sau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
