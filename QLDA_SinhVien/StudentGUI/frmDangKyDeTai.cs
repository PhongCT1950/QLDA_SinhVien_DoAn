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
        }

        public void loadMaNhom()
        {
            string MaSV = UserSession.Refld;
            string MaNhom = nhomSinhVienService.getDataMaNhom(MaSV);
            if(MaNhom == null)
            {
                txt_MaNH.Text = "Chưa có nhóm";
                return;
            }
            txt_MaNH.Text = MaNhom;
        }

        public void loadAllDeTai()
        {
            DataTable DeTai = deTaiService.getAllDataDeTai();

            dtgv_DeTai.DataSource = DeTai;
            dtgv_DeTai.Columns["TENDT"].HeaderText = "Tên Đề Tài";
            dtgv_DeTai.Columns["LOAIDA"].HeaderText = "Loại Đồ Án";
            dtgv_DeTai.Columns["MOTA"].HeaderText = "Mô Tả Đồ Án";
            dtgv_DeTai.Columns["TENGV"].HeaderText = "Tên Giảng Viên";
        }

        private void btn_DangKy_Click(object sender, EventArgs e)
        {
            try
            {
                string MaNhom = txt_MaNH.Text;
                string MaDT = dtgv_DeTai.SelectedRows[0].Cells["MADT"].Value.ToString();

                string MaDTs = nhomSinhVienService.getDataMaDT(MaNhom);
                if(MaDTs != "")
                {
                    MessageBox.Show($"Nhóm của bạn đã đăng ký đề tài số {MaDTs}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                nhomSinhVienService.updateDKDeTai(MaNhom, MaDT);
                MessageBox.Show("Đăng ký đề tài thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hệ thống đang gặp lỗi vui lòng thử lại sau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
