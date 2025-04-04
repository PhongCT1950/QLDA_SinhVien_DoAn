using BusinessLogicLayer;
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
    public partial class frmChiTietDiem: Form
    {
        DiemService diemService = new DiemService();
        public static string MaDA { get; set; }
        public frmChiTietDiem()
        {
            InitializeComponent();
        }

        private void frmChiTietDiem_Load(object sender, EventArgs e)
        {
            loadDataDiem();
        }

        public void loadDataDiem()
        {
            string MADA = MaDA;
            DataTable DoAn = diemService.getDataThongtinDoAn(MADA);

            label_MaDA.Text = DoAn.Rows[0]["MADA"].ToString();
            label_TenDA.Text = DoAn.Rows[0]["TENDA"].ToString();
            label_MaNhom.Text = DoAn.Rows[0]["MANHOM"].ToString();
            label_LoaiDA.Text = DoAn.Rows[0]["LOAIDA"].ToString();
            label_NgayNop.Text = Convert.ToDateTime(DoAn.Rows[0]["NGAYNOP"]).ToString("dd/MM/yyyy");
            label_SoTC.Text = DoAn.Rows[0]["SOTC"].ToString();
            label_TenFile.Text = DoAn.Rows[0]["PATH"].ToString();
        }

        private void btn_XacNhan_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txt_Diem.Text.Trim(), out double diem))
            {
                if (diem >= 0 && diem <= 10)
                {
                    frmDiemDoAn.Diem = diem;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Điểm phải nằm trong khoảng 0 - 10!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập điểm hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmChiTietDiem_FormClosed(object sender, FormClosedEventArgs e)
        {
            MaDA = null;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
