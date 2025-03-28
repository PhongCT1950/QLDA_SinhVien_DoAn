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
    public partial class frmQuyenDoAn: Form
    {
        NhomSinhVienService nhomSinhVienService = new NhomSinhVienService();
        QuyenDoAnService quyenDoAnService = new QuyenDoAnService();
        DeTaiService deTaiService = new DeTaiService();
        public frmQuyenDoAn()
        {
            InitializeComponent();
        }

        private void frmQuyenDoAn_Load(object sender, EventArgs e)
        {
            loadListNhom();
            loadMaDA();
            loadLoaiDA();
            loadListQuyenDoAn();
        }

        public void loadHuy()
        {
            txt_MaDA.Text = "";
            txt_TenDA.Text = "";
            txt_MaNH.Text = "";
            cmb_LoaiDA.Text = "";
            cmb_soTC.Text = "";
            btn_Them.Text = "Thêm";
            loadMaDA();
            isEdit = false;
        }

        public void loadLoaiDA()
        {
            DataTable LoaiDa = deTaiService.getLoaiDa();

            cmb_LoaiDA.DataSource = LoaiDa;
            cmb_LoaiDA.DisplayMember = "LOAIDA";
        }

        public void loadMaDA()
        {
            txt_MaDA.Text = quyenDoAnService.GenerateMaDA();
        }

        public void loadListNhom()
        {
            dtgv_Nhom.DataSource = nhomSinhVienService.getDatadsNhomSV();

            dtgv_Nhom.Columns["MANHOM"].HeaderText = "MaNH";
            dtgv_Nhom.Columns["TENNHOM"].HeaderText = "TenNH";
            dtgv_Nhom.Columns["Soluong"].HeaderText = "Số lượng thành viên";
            dtgv_Nhom.Columns["Soluong"].Width = 500;
        }

        public void loadListQuyenDoAn()
        {
            dtgv_QuyenDoAn.DataSource = quyenDoAnService.getDataListQuyenDoAn();

            dtgv_QuyenDoAn.Columns["MADA"].HeaderText = "MaDA";
            dtgv_QuyenDoAn.Columns["TENDA"].HeaderText = "TenDA";
            dtgv_QuyenDoAn.Columns["LOAIDA"].HeaderText = "Loại đồ án";
            dtgv_QuyenDoAn.Columns["SOTC"].HeaderText = "Số tín chỉ";
            dtgv_QuyenDoAn.Columns["MANHOM"].HeaderText = "MaNH";
            dtgv_QuyenDoAn.Columns["TinhTrang"].HeaderText = "Tình trạng";
        }

        private void btn_chon_Click(object sender, EventArgs e)
        {
            txt_MaNH.Text = dtgv_Nhom.SelectedRows[0].Cells["MANHOM"].Value.ToString();
        }

        bool isEdit = false;
        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                if (isEdit)
                {
                    QuyenDoAnDTO quyenDoAn = new QuyenDoAnDTO();
                    quyenDoAn.MaDA = txt_MaDA.Text;
                    quyenDoAn.TenDA = txt_TenDA.Text;
                    quyenDoAn.LoaiDA = cmb_LoaiDA.Text;
                    quyenDoAn.SoTC = int.Parse(cmb_soTC.Text);
                    quyenDoAn.MaNH = txt_MaNH.Text;

                    quyenDoAnService.updateDataQuyenDoAn(quyenDoAn);

                    loadListQuyenDoAn();
                    loadListNhom();
                    isEdit = false;
                    loadHuy();
                    MessageBox.Show("Sửa đồ án thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    QuyenDoAnDTO quyenDoAn = new QuyenDoAnDTO();
                    quyenDoAn.MaDA = txt_MaDA.Text;
                    quyenDoAn.TenDA = txt_TenDA.Text;
                    quyenDoAn.LoaiDA = cmb_LoaiDA.Text;
                    quyenDoAn.SoTC = int.Parse(cmb_soTC.Text);
                    quyenDoAn.MaNH = txt_MaNH.Text;

                    quyenDoAnService.addDataQuyenDoAn(quyenDoAn);

                    loadHuy();
                    loadListQuyenDoAn();
                    loadListNhom();
                    loadMaDA();
                    MessageBox.Show("Thêm đồ án thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            string MaDA = dtgv_QuyenDoAn.SelectedRows[0].Cells["MADA"].Value.ToString();
            DataTable dataQuyenDoAn = quyenDoAnService.getDataEditQuyenDoAn(MaDA);

            txt_MaDA.Text = dataQuyenDoAn.Rows[0]["MADA"].ToString();
            txt_TenDA.Text = dataQuyenDoAn.Rows[0]["TENDA"].ToString();
            cmb_soTC.Text = dataQuyenDoAn.Rows[0]["SOTC"].ToString();
            cmb_LoaiDA.Text = dataQuyenDoAn.Rows[0]["LOAIDA"].ToString();
            txt_MaNH.Text = dataQuyenDoAn.Rows[0]["MANHOM"].ToString();

            btn_Them.Text = "Lưu";
            isEdit = true;
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            loadHuy();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Xác nhận xóa đồ án?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    string MaDA = dtgv_QuyenDoAn.SelectedRows[0].Cells["MADA"].Value.ToString();

                    quyenDoAnService.deleteDataQuyenDoAn(MaDA);

                    loadHuy();
                    loadListQuyenDoAn();
                    loadListNhom();
                    loadMaDA();
                    MessageBox.Show("Xóa đồ án thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            DataTable quyendoan = quyenDoAnService.getDataQuyenDoAnFind(keyword);

            dtgv_QuyenDoAn.DataSource = quyendoan;
        }
    }
}
