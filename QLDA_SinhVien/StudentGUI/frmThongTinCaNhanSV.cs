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
    public partial class frmThongTinCaNhanSV: Form
    {
        SinhVienService sinhVienService = new SinhVienService();
        public frmThongTinCaNhanSV()
        {
            InitializeComponent();
        }

        private void frmThongTinCaNhan_Load(object sender, EventArgs e)
        {
            loadTTCaNhan();
        }

        public void loadTTCaNhan()
        {
            string MaSV = UserSession.Refld;
            DataTable sinhvien = sinhVienService.getDataTTCaNhan(MaSV);
            if(sinhvien.Rows.Count > 0)
            {
                label_MaSV.Text = sinhvien.Rows[0]["MASV"].ToString();
                label_TenSV.Text = sinhvien.Rows[0]["TENSV"].ToString();
                label_GioiTinh.Text = sinhvien.Rows[0]["GIOITINH"].ToString();
                DateTime ngaysinh = Convert.ToDateTime(sinhvien.Rows[0]["NGAYSINH"]);
                label_NgaySinh.Text = ngaysinh.ToString("dd/MM/yyyy");
                label_DiaChi.Text = sinhvien.Rows[0]["DIACHI"].ToString();
                label_Email.Text = sinhvien.Rows[0]["EMAIL"].ToString();
                label_DienThoai.Text = sinhvien.Rows[0]["SDT"].ToString();
                label_Nganh.Text = sinhvien.Rows[0]["TENNGANH"].ToString();
                label_Khoa.Text = sinhvien.Rows[0]["TENKHOA"].ToString();
                label_KhoaHoc.Text = sinhvien.Rows[0]["NIENKHOA"].ToString();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
