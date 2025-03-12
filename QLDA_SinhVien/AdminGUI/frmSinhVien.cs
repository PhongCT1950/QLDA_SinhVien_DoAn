using BusinessLogicLayer;
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
    
    public partial class frmSinhVien: Form
    {
        SinhVienService sinhVienService = new SinhVienService();
        public frmSinhVien()
        {
            InitializeComponent();
        }
        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            LoadListSinhVien();
            LoadListNganh();
            LoadMaSV();
            LoadListHeDT();
            LoadListNienKhoa();
        }
        public void LoadListSinhVien()
        {
            dtgv_SinhVien.DataSource = sinhVienService.getListSinhVien();

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

        public void LoadListHeDT()
        {
            DataTable HeDT = sinhVienService.getListHeDT();
            cmb_HeDT.DataSource = HeDT;
            cmb_HeDT.DisplayMember = "TenHeDT";
            cmb_HeDT.ValueMember = "MaHeDT";
        }

        public void LoadListNienKhoa()
        {
            DataTable NienKhoa = sinhVienService.getListNienKhoa();
            cmb_NienKhoa.DataSource = NienKhoa;
            cmb_NienKhoa.DisplayMember = "NIENKHOA";
            cmb_NienKhoa.ValueMember = "MANK";
        }

        public void LoadListNganh()
        {
            DataTable listNganh = sinhVienService.getListNganh();
            if(listNganh.Rows.Count > 0)
            {
                cmb_Nganh.DataSource = listNganh;
                cmb_Nganh.DisplayMember = "TENNGANH";
                cmb_Nganh.ValueMember = "MANGANH";
            }
        }
        public void LoadMaSV()
        {
            string MaSV = sinhVienService.GenerateMaSV();
            txt_MaSV.Text = MaSV;
        }

        private void cmb_Nganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Nganh.SelectedItem != null)
            {
                DataRowView row = cmb_Nganh.SelectedItem as DataRowView;
                if (row != null)
                {
                    txt_Khoa.Text = row["TENKHOA"].ToString();
                }
            }
        }

        public void LoadHuy()
        {
            txt_TenSV.Text = "";
            txt_DiaChi.Text = "";
            txt_SDT.Text = "";
            txt_Email.Text = "";
            IsEdit = false;
            btn_Them.Text = "Thêm";
            LoadMaSV();
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            LoadHuy();
        }
        bool IsEdit = false;
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Xác nhận xóa sinh viên?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if(result == DialogResult.Yes)
                {
                    if (dtgv_SinhVien.SelectedRows.Count > 0)
                    {
                        DataGridViewRow row = dtgv_SinhVien.SelectedRows[0];
                        string MaSV = row.Cells["MASV"].Value.ToString();

                        sinhVienService.DeleteSinhvien(MaSV);
                        MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        IsEdit = false;
                        btn_Them.Text = "Thêm";
                        LoadListSinhVien();
                        LoadMaSV();
                    }
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
                DataGridViewRow row = dtgv_SinhVien.SelectedRows[0];
                string MaSV = row.Cells["MASV"].Value.ToString();
                SinhVienDTO sinhvien = sinhVienService.getDataSinhVien(MaSV);

                txt_MaSV.Text = sinhvien.MaSV;
                txt_TenSV.Text = sinhvien.TenSV;
                txt_DiaChi.Text = sinhvien.DiaChi;
                txt_NgaySinh.Value = sinhvien.NgaySinh;
                txt_Email.Text = sinhvien.Email;
                txt_SDT.Text = sinhvien.SDT.Trim();
                cmb_HeDT.SelectedValue = sinhvien.MaHeDT;
                cmb_Nganh.SelectedValue = sinhvien.MaNganh;
                cmb_NienKhoa.SelectedValue = sinhvien.MaNK;

                if(sinhvien.GioiTinh == "Nam")
                {
                    rdb_Nam.Checked = true;
                }
                else
                {
                    rdb_Nu.Checked = true;
                }

                btn_Them.Text = "Lưu";
                IsEdit = true;
            }
            catch(Exception ex)
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
                    DataRowView row = (DataRowView)cmb_Nganh.SelectedItem;
                    SinhVienDTO sinhvien = new SinhVienDTO();
                    sinhvien.MaSV = txt_MaSV.Text;
                    sinhvien.TenSV = txt_TenSV.Text;
                    sinhvien.NgaySinh = txt_NgaySinh.Value;
                    sinhvien.GioiTinh = rdb_Nam.Checked ? "Nam" : "Nữ";
                    sinhvien.SDT = txt_SDT.Text;
                    sinhvien.DiaChi = txt_DiaChi.Text;
                    sinhvien.Email = txt_Email.Text;
                    sinhvien.MaHeDT = cmb_HeDT.SelectedValue.ToString();
                    sinhvien.MaNganh = cmb_Nganh.SelectedValue.ToString();
                    sinhvien.MaKhoa = row["MAKHOA"].ToString();
                    sinhvien.MaNK = cmb_NienKhoa.SelectedValue.ToString();

                    sinhVienService.AddNewSinhVien(sinhvien,rdb_Nam.Checked,rdb_Nu.Checked);

                    MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListSinhVien();
                    LoadHuy();
                }
                else
                {
                    SinhVienDTO sinhvien = new SinhVienDTO();
                    sinhvien.MaSV = txt_MaSV.Text;
                    sinhvien.TenSV = txt_TenSV.Text;
                    sinhvien.NgaySinh = txt_NgaySinh.Value;
                    sinhvien.GioiTinh = rdb_Nam.Checked ? "Nam" : "Nữ";
                    sinhvien.SDT = txt_SDT.Text;
                    sinhvien.DiaChi = txt_DiaChi.Text;
                    sinhvien.Email = txt_Email.Text;
                    sinhvien.MaHeDT = cmb_HeDT.SelectedValue.ToString();
                    sinhvien.MaNganh = cmb_Nganh.SelectedValue.ToString();
                    sinhvien.MaNK = cmb_NienKhoa.SelectedValue.ToString();
                    sinhvien.MaKhoa = txt_Khoa.Text;
                    sinhVienService.UpdateDataSinhVien(sinhvien);

                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IsEdit = false;
                    btn_Them.Text = "Thêm";
                    LoadListSinhVien();
                    LoadMaSV();
                    LoadHuy();
                }
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hệ thống đang gặp lỗi vui lòng thử lại sau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_Find_TextChanged(object sender, EventArgs e)
        {
            string keyword = txt_Find.Text.Trim();
            DataTable sinhvien = sinhVienService.getDataSinhVienFind(keyword);

            dtgv_SinhVien.DataSource = sinhvien;
        }
    }
}
