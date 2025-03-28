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

namespace QLDA_SinhVien.TeacherGUI
{
    public partial class frmThongTinCaNhanGV: Form
    {
        GiangVienService giangVienService = new GiangVienService();
        public frmThongTinCaNhanGV()
        {
            InitializeComponent();
        }

        private void frmThongTinCaNhanGV_Load(object sender, EventArgs e)
        {
            loadTTCaNhanGV();
        }

        public void loadTTCaNhanGV()
        {
            string MAGV = UserSession.Refld.Trim();
            DataTable giangvien = giangVienService.getDataTTCaNhanGV(MAGV);
            if (giangvien.Rows.Count > 0)
            {
                label_MaGV.Text = giangvien.Rows[0]["MAGV"].ToString();
                label_TenGV.Text = giangvien.Rows[0]["TENGV"].ToString();
                label_GioiTinh.Text = giangvien.Rows[0]["GIOITINH"].ToString();
                DateTime ngaysinh = Convert.ToDateTime(giangvien.Rows[0]["NGAYSINH"]);
                label_NgaySinh.Text = ngaysinh.ToString("dd/MM/yyyy");
                label_DiaChi.Text = giangvien.Rows[0]["DIACHI"].ToString();
                label_Email.Text = giangvien.Rows[0]["EMAIL"].ToString();
                label_DienThoai.Text = giangvien.Rows[0]["SDT"].ToString();
                label_Khoa.Text = giangvien.Rows[0]["TENKHOA"].ToString();
                label_ChucDanh.Text = giangvien.Rows[0]["ChucDanh"].ToString();
                label_HeSo.Text = giangvien.Rows[0]["HeSoCD"].ToString();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
