using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using DTO;

namespace QLDA_SinhVien.AdminGUI
{
    public partial class frmNienKhoa : Form
    {
        NienKhoaService nienKhoaService = new NienKhoaService();
        bool isEdit = false;
        public frmNienKhoa()
        {
            InitializeComponent();
        }

        private void frmNienKhoa_Load(object sender, EventArgs e)
        {
            loadListNienKhoa();
            loadMaNG();
        }

        public void loadHuy()
        {
            txt_MaNK.Text = "";
            txt_TenNK.Text = "";
            txt_NienKhoa.Text = "";
            btn_Them.Text = "Thêm";
            isEdit = false;
            loadMaNG();
        }

        public void loadListNienKhoa()
        {
            DataTable nienkhoa = nienKhoaService.getDataDsNienKhoa();
            dtgv_NienKhoa.DataSource = nienkhoa;
        }

        public void loadMaNG()
        {
            string MaNG = nienKhoaService.GenerateMaNG();
            txt_MaNK.Text = MaNG;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isEdit)
                {
                    NienKhoaDTO nienkhoa = new NienKhoaDTO();
                    nienkhoa.MaNK = txt_MaNK.Text;
                    nienkhoa.TenNK = txt_TenNK.Text;
                    nienkhoa.NienKhoa = txt_NienKhoa.Text;

                    nienKhoaService.addDataNienKhoa( nienkhoa );

                    loadListNienKhoa();
                    loadHuy();
                    MessageBox.Show("Thêm niên khóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    NienKhoaDTO nienkhoa = new NienKhoaDTO();
                    nienkhoa.MaNK = txt_MaNK.Text;
                    nienkhoa.TenNK = txt_TenNK.Text;
                    nienkhoa.NienKhoa = txt_NienKhoa.Text;

                    nienKhoaService.updateDataNienKhoa(nienkhoa);

                    loadListNienKhoa();
                    loadHuy();
                    MessageBox.Show("Sửa niên khóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            try
            {
                string MaNG = dtgv_NienKhoa.SelectedRows[0].Cells["MANK"].Value.ToString();
                DataTable nganh = nienKhoaService.getDataNganhEdit(MaNG);

                txt_MaNK.Text = nganh.Rows[0]["MANK"].ToString();
                txt_TenNK.Text = nganh.Rows[0]["TENNK"].ToString();
                txt_NienKhoa.Text = nganh.Rows[0]["NIENKHOA"].ToString();

                isEdit = true;
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

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = MessageBox.Show("Xác nhận xóa niên khóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    string MaNG = dtgv_NienKhoa.SelectedRows[0].Cells["MANK"].Value.ToString();

                    nienKhoaService.deleteDataNganh(MaNG);

                    loadListNienKhoa();
                    loadHuy();
                    MessageBox.Show("Xóa niên khóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            DataTable nganh = nienKhoaService.getDataNganhFind(keyword);

            dtgv_NienKhoa.DataSource = nganh;
        }
    }
}
