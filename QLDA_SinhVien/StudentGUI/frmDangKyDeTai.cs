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
        NganhService nganhService = new NganhService();
        DeTaiService deTaiService = new DeTaiService();
        public frmDangKyDeTai()
        {
            InitializeComponent();
        }

        private void frmDangKyDeTai_Load(object sender, EventArgs e)
        {
            loadMaNhom();
            loadDeTai();
            loadTtNhomSV();
            loadtvNhom();
            loadDeTaiIfNoMADA();
        }

        private void FormatGridDeTai()
        {
            if (dtgv_DeTai.Columns.Contains("MADT")) dtgv_DeTai.Columns["MADT"].HeaderText = "Mã Đề Tài";
            if (dtgv_DeTai.Columns.Contains("TENDT")) dtgv_DeTai.Columns["TENDT"].HeaderText = "Tên Đề Tài";
            if (dtgv_DeTai.Columns.Contains("LOAIDA")) dtgv_DeTai.Columns["LOAIDA"].HeaderText = "Loại Đồ Án";
            if (dtgv_DeTai.Columns.Contains("MOTA")) dtgv_DeTai.Columns["MOTA"].HeaderText = "Mô Tả Đồ Án";
            if (dtgv_DeTai.Columns.Contains("TENGV")) dtgv_DeTai.Columns["TENGV"].HeaderText = "Tên Giảng Viên";
            if (dtgv_DeTai.Columns.Contains("TENNGANH")) dtgv_DeTai.Columns["TENNGANH"].HeaderText = "Tên Ngành";
        }

        public void loadtvNhom()
        {
            string MANHOM = txt_MaNH.Text.Trim();

            if (string.IsNullOrEmpty(MANHOM) || MANHOM == "Chưa có nhóm")
            {
                lsb_tvNhom.Items.Clear();
                lsb_tvNhom.Items.Add("Bạn chưa tham gia nhóm nào.");
                btnGoiYGV_Click.Enabled = false;
                return;
            }

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

            string MaNH = nopDoAnService.getDataMaNH(MaNhom);
            if (MaNH == txt_MaNH.Text)
            {
                btn_ThayDoiDT.Enabled = false;
                return;
            }
        }

        public void loadAllDeTai()
        {
            DataTable DeTai = deTaiService.getDataDeTai();

            dtgv_DeTai.DataSource = DeTai;
            FormatGridDeTai();
            btn_ThayDoiDT.Enabled = false;
        }

        public void loadDeTai()
        {
            string MaSV = UserSession.Refld;
            string MaNhom = nhomSinhVienService.getDataMaNhom(MaSV);
            string MaNganh = nganhService.getDataMaNganh(MaSV);
            if (string.IsNullOrEmpty(MaNhom) || string.IsNullOrEmpty(MaNganh))
            {
                loadAllDeTai();
                return;
            }
            DataTable DeTai = deTaiService.getAllDataDeTai(MaNhom, MaNganh);

            dtgv_DeTai.DataSource = DeTai;
            FormatGridDeTai();
        }

        public void loadDeTaiIfNoMADA()
        {
            string MaSV = UserSession.Refld;
            string MaNhom = nhomSinhVienService.getDataMaNhom(MaSV);

            if (string.IsNullOrEmpty(MaNhom))
            {
                return;
            }

            System.Data.DataTable DoAn = nopDoAnService.getDataDoAn(MaNhom);

            if (DoAn != null && DoAn.Rows.Count > 0)
            {
                loadDeTai();
            }
            else
            {
                loadAllDeTai();
                btn_DangKy.Enabled = false;
                btnGoiYGV_Click.Enabled = false;
            }
        }

        public void loadTtNhomSV()
        {
            string manhom = txt_MaNH.Text.Trim();

            if (string.IsNullOrEmpty(manhom) || manhom == "Chưa có nhóm") return;
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
                string MaDT = txtMaDeTai.Text.Trim();
                string MaNhom = txt_MaNH.Text.Trim();
                string MaSV = UserSession.Refld;

                if (string.IsNullOrEmpty(MaDT))
                {
                    MessageBox.Show("Vui lòng chọn một đề tài từ danh sách hoặc dùng AI gợi ý!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (isEdit)
                {
                    nhomSinhVienService.updateDataTdDeTai(MaNhom, MaDT);

                    isEdit = false;
                    loadTtNhomSV();
                    MessageBox.Show($"Nhóm {MaNhom} của bạn đã thay đổi sang đề tài số {MaDT}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string MaNhoms = nhomSinhVienService.getDataMaNhom(MaSV);
                    string MaDTs = nhomSinhVienService.getDataMaDT(MaNhom);

                    if (string.IsNullOrEmpty(MaNhoms) || MaNhoms == "null")
                    {
                        MessageBox.Show("Hiện tại bạn chưa vào nhóm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (!string.IsNullOrEmpty(MaDTs) && MaDTs != "null")
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
            try
            {
                string keyword = txt_Find.Text.Trim();

                string MaSV = UserSession.Refld;
                string MaNhom = nhomSinhVienService.getDataMaNhom(MaSV);
                string MaNganh = nganhService.getDataMaNganh(MaSV);

                if (string.IsNullOrEmpty(MaNhom) || string.IsNullOrEmpty(MaNganh))
                {
                    return;
                }

                DataTable detai = deTaiService.getDataDeTaiFindSinhVien(keyword, MaNhom, MaNganh);

                dtgv_DeTai.DataSource = detai;

                FormatGridDeTai();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tìm kiếm đề tài: " + ex.Message);
            }
        }

        private void btnGoiYGV_Click_Click_1(object sender, EventArgs e)
        {
            frmGoiYGiangVien frmNhap = new frmGoiYGiangVien();
            //frmKetQuaGoiY frmNhap = new frmKetQuaGoiY(listTest);

            string MaNhom = txt_MaNH.Text.Trim();
            string MaSV = UserSession.Refld;

            if (frmNhap.ShowDialog() == DialogResult.OK)
            {
                txtMaDeTai.Text = frmNhap.MaDeTaiDaChon;
                string tenDT = frmNhap.tenDT;

                string MaNhoms = nhomSinhVienService.getDataMaNhom(MaSV);
                string MaDTs = nhomSinhVienService.getDataMaDT(MaNhom);

                if (string.IsNullOrEmpty(MaNhoms) || MaNhoms == "null")
                {
                    MessageBox.Show("Hiện tại bạn chưa vào nhóm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!string.IsNullOrEmpty(MaDTs) && MaDTs != "null")
                {
                    MessageBox.Show($"Nhóm của bạn đã đăng ký đề tài số {MaDTs} nên không thể đăng ký đề tài mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                MessageBox.Show($"Đã chọn đề tài {tenDT} từ gợi ý của AI, hãy tiếp tục nhấn đăng ký để hoàn thành đăng ký đề tài!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dtgv_DeTai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaDeTai.Text = dtgv_DeTai.Rows[e.RowIndex].Cells["MADT"].Value.ToString();
            }
        }
    }
}
