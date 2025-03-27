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

namespace QLDA_SinhVien.StudentGUI
{
    public partial class frmDangKyDeTai: Form
    {
        NopDoAnService nopDoAnService = new NopDoAnService();
        NhomSinhVienService nhomSinhVienService = new NhomSinhVienService();
        DeTaiService deTaiService = new DeTaiService();
        public frmDangKyDeTai()
        {
            InitializeComponent();
        }

        private void frmDangKyDeTai_Load(object sender, EventArgs e)
        {
            loadMaNhom();
            loadAllDeTai();
            loadTtNhomSV();
            loadtvNhom();
        }

        public void loadtvNhom()
        {
            string MANHOM = txt_MaNH.Text;

            if (MANHOM == null)
            {
                return;
            }

            DataTable dsThanhVien = nhomSinhVienService.getDsThanhVienSV(MANHOM);

            if (dsThanhVien == null || dsThanhVien.Rows.Count == 0)
            {
                return;
            }

            string danhSach = dsThanhVien.Rows[0]["DanhSachSinhVien"].ToString();
            string[] sinhVienArray = danhSach.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            lsb_tvNhom.Items.Clear();
            foreach (string sinhVien in sinhVienArray)
            {
                lsb_tvNhom.Items.Add(sinhVien);
            }
        }

        public void loadMaNhom()
        {
            string MaSV = UserSession.Refld;
            string MaNhom = nhomSinhVienService.getDataMaNhom(MaSV);
            if (MaNhom == null)
            {
                txt_MaNH.Text = "Chưa có nhóm";
                return;
            }
            label6.Text = $"Thông tin nhóm {MaNhom}";
            label1.Text = $"Thành viên nhóm {MaNhom}";
            txt_MaNH.Text = MaNhom;


            string MaNH = nopDoAnService.getDataMaNH(txt_MaNH.Text);
            if (MaNH == txt_MaNH.Text)
            {
                btn_ThayDoiDT.Enabled = false;
                return;
            }
        }

        public void loadAllDeTai()
        {
            string MaSV = UserSession.Refld;
            string MaNhom = nhomSinhVienService.getDataMaNhom(MaSV);
            DataTable DeTai = deTaiService.getAllDataDeTai(MaNhom);

            dtgv_DeTai.DataSource = DeTai;
            dtgv_DeTai.Columns["TENDT"].HeaderText = "Tên Đề Tài";
            dtgv_DeTai.Columns["LOAIDA"].HeaderText = "Loại Đồ Án";
            dtgv_DeTai.Columns["MOTA"].HeaderText = "Mô Tả Đồ Án";
            dtgv_DeTai.Columns["TENGV"].HeaderText = "Tên Giảng Viên";
        }

        public void loadTtNhomSV()
        {
            string manhom = txt_MaNH.Text;
            dtgv_Nhom.DataSource = nhomSinhVienService.getDatattNhomSV(manhom);

            dtgv_Nhom.Columns["TENNHOM"].HeaderText = "Tên Nhóm";
            dtgv_Nhom.Columns["Soluong"].HeaderText = "Số lượng thành viên";
            dtgv_Nhom.Columns["TENDT"].HeaderText = "Tên đề tài";
        }
        bool isEdit = false;
        private void btn_DangKy_Click(object sender, EventArgs e)
        {
            try
            {
                if (isEdit)
                {
                    string MaNhom = txt_MaNH.Text;
                    string MaDT = dtgv_DeTai.SelectedRows[0].Cells["MADT"].Value.ToString();

                    string MaSV = UserSession.Refld;
                    nhomSinhVienService.updateDataTdDeTai(MaNhom, MaDT);

                    isEdit = false;
                    loadTtNhomSV();
                    MessageBox.Show($"Nhóm {MaNhom} của bạn, đã thay đổi sang đề tài số {MaDT}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string MaNhom = txt_MaNH.Text;
                    string MaDT = dtgv_DeTai.SelectedRows[0].Cells["MADT"].Value.ToString();

                    string MaSV = UserSession.Refld;
                    string MaNhoms = nhomSinhVienService.getDataMaNhom(MaSV);
                    string MaDTs = nhomSinhVienService.getDataMaDT(MaNhom);
                    if (string.IsNullOrEmpty(MaNhoms) || MaNhoms == "null")
                    {
                        MessageBox.Show($"Hiện tại bạn chưa vào nhóm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if(!string.IsNullOrEmpty(MaDTs) && MaDTs != "null")
                    {
                        MessageBox.Show($"Nhóm của bạn đã đăng ký đề tài số {MaDTs}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    nhomSinhVienService.updateDKDeTai(MaNhom, MaDT);
                    loadTtNhomSV();
                    MessageBox.Show("Đăng ký đề tài thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hệ thống đang gặp lỗi vui lòng thử lại sau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_ThayDoiDT_Click(object sender, EventArgs e)
        {
            if (isEdit == true)
            {
                MessageBox.Show($"Hiện tại hãy chọn đề tài mới và đăng ký!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            isEdit = true;
            MessageBox.Show($"Vui lòng chọn đề tài mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txt_Find_TextChanged(object sender, EventArgs e)
        {
            string keyword = txt_Find.Text.Trim();
            DataTable detai = deTaiService.getDataDeTaiFind(keyword);

            dtgv_DeTai.DataSource = detai;
        }
    }
}
