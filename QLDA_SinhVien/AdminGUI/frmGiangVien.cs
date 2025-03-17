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
    public partial class frmGiangVien: Form
    {
        GiangVienService giangVienService = new GiangVienService();
        public frmGiangVien()
        {
            InitializeComponent();
        }

        private void frmGiangVien_Load(object sender, EventArgs e)
        {
            LoadListGiangVien();
            LoadMaGV();
            LoadKhoa();
            LoadChucDanh();
        }

        public void LoadMaGV()
        {
            string MaGV = giangVienService.GenerateMaGV();

            txt_MaGV.Text = MaGV;
            dtgv_GiangVien.Columns["MAGV"].HeaderText = "MaGV";
            dtgv_GiangVien.Columns["TENGV"].HeaderText = "TenGV";
            dtgv_GiangVien.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
            dtgv_GiangVien.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dtgv_GiangVien.Columns["GioiTinh"].HeaderText = "Giới Tính";
            dtgv_GiangVien.Columns["SDT"].HeaderText = "SĐT";
            dtgv_GiangVien.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dtgv_GiangVien.Columns["Email"].HeaderText = "Email";
            dtgv_GiangVien.Columns["ChucDanh"].HeaderText = "Chức Danh";
            dtgv_GiangVien.Columns["HeSoCD"].HeaderText = "Hệ Số";
            dtgv_GiangVien.Columns["TENKHOA"].HeaderText = "Khoa";
        }

        public void LoadKhoa()
        {
            DataTable giangvien = giangVienService.getNameKhoa();
            cmb_Khoa.DataSource = giangvien;
            cmb_Khoa.DisplayMember = "TENKHOA";
            cmb_Khoa.ValueMember = "MAKHOA";
        }
        public void LoadChucDanh()
        {
            DataTable ChucDanh = giangVienService.getDataChucDanh();
            cmb_ChucDanh.DataSource = ChucDanh;
            cmb_ChucDanh.DisplayMember = "ChucDanh";
            cmb_ChucDanh.ValueMember = "MaCD";
        }

        public void LoadListGiangVien()
        {
            DataTable giangvien = giangVienService.getListGiangVien();

            dtgv_GiangVien.DataSource = giangvien;
        }

        bool IsEdit = false;

        public void LoadHuy()
        {
            txt_TenGV.Text = "";
            txt_DiaChi.Text = "";
            txt_SDT.Text = "";
            txt_Email.Text = "";
            IsEdit = false;
            btn_Them.Text = "Thêm";
            LoadMaGV();
        }
        private void btn_Huy_Click(object sender, EventArgs e)
        {
            LoadHuy();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Xác nhận xóa giảng viên?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    if (dtgv_GiangVien.SelectedRows.Count > 0)
                    {
                        DataGridViewRow row = dtgv_GiangVien.SelectedRows[0];
                        string MaGV = row.Cells["MAGV"].Value.ToString();

                        giangVienService.GiangVienDelete(MaGV);
                        MessageBox.Show("Xóa giảng viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        IsEdit = false;
                        btn_Them.Text = "Thêm";
                        LoadListGiangVien();
                        LoadMaGV();
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
                DataGridViewRow row = dtgv_GiangVien.SelectedRows[0];
                string MaGV = row.Cells["MAGV"].Value.ToString();
                GiangVienDTO giangvien = giangVienService.getDataGiangVienEdit(MaGV);

                txt_MaGV.Text = giangvien.MaGV;
                txt_TenGV.Text = giangvien.TenGV;
                txt_DiaChi.Text = giangvien.DiaChi;
                txt_NgaySinh.Value = giangvien.NgaySinh;
                txt_Email.Text = giangvien.Email;
                txt_SDT.Text = giangvien.SDT.Trim();
                cmb_ChucDanh.SelectedValue = giangvien.MaCD;
                cmb_Khoa.SelectedValue = giangvien.MaKhoa;

                if (giangvien.GioiTinh == "Nam")
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
                    DataRowView row = (DataRowView)cmb_ChucDanh.SelectedItem;
                    GiangVienDTO giangvien = new GiangVienDTO();
                    giangvien.MaGV = txt_MaGV.Text;
                    giangvien.TenGV = txt_TenGV.Text;
                    giangvien.NgaySinh = txt_NgaySinh.Value;
                    giangvien.GioiTinh = rdb_Nam.Checked ? "Nam" : "Nữ";
                    giangvien.SDT = txt_SDT.Text;
                    giangvien.DiaChi = txt_DiaChi.Text;
                    giangvien.Email = txt_Email.Text;
                    giangvien.MaKhoa = cmb_Khoa.SelectedValue.ToString();
                    giangvien.MaCD = int.Parse(cmb_ChucDanh.SelectedValue.ToString());

                    giangVienService.addNewGiangVien(giangvien, rdb_Nam.Checked, rdb_Nu.Checked);

                    MessageBox.Show("Thêm giảng viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListGiangVien();
                    LoadHuy();
                }
                else
                {
                    //SinhVienDTO sinhvien = new SinhVienDTO();
                    //sinhvien.MaSV = txt_MaSV.Text;
                    //sinhvien.TenSV = txt_TenSV.Text;
                    //sinhvien.NgaySinh = txt_NgaySinh.Value;
                    //sinhvien.GioiTinh = rdb_Nam.Checked ? "Nam" : "Nữ";
                    //sinhvien.SDT = txt_SDT.Text;
                    //sinhvien.DiaChi = txt_DiaChi.Text;
                    //sinhvien.Email = txt_Email.Text;
                    //sinhvien.MaHeDT = cmb_HeDT.SelectedValue.ToString();
                    //sinhvien.MaNganh = cmb_Nganh.SelectedValue.ToString();
                    //sinhvien.MaNK = cmb_NienKhoa.SelectedValue.ToString();
                    //sinhvien.MaKhoa = txt_Khoa.Text;
                    //sinhVienService.UpdateDataSinhVien(sinhvien);

                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IsEdit = false;
                    btn_Them.Text = "Thêm";
                    LoadListGiangVien();
                    LoadMaGV();
                    LoadHuy();
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

        private void cmb_ChucDanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmb_ChucDanh.SelectedItem != null)
            {
                DataRowView row = cmb_ChucDanh.SelectedItem as DataRowView;
                if(row != null)
                {
                    txt_HeSoChucDanh.Text = row["HeSoCD"].ToString();
                }
            }
        }
    }
}
