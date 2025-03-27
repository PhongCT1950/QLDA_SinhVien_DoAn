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
    public partial class frmNganh: Form
    {
        NganhService nganhService = new NganhService();
        bool isEdit = false;
        public frmNganh()
        {
            InitializeComponent();
        }

        private void frmNganh_Load(object sender, EventArgs e)
        {
            loadMaNG();
            loadCmbKhoa();
            loadListNganh();
        }

        public void loadHuy()
        {
            txt_MaNG.Text = "";
            txt_TenNganh.Text = "";
            btn_Them.Text = "Thêm";
            isEdit = false;
            loadMaNG();
        }

        public void loadListNganh()
        {
            DataTable nganh = nganhService.getDataNganh();
            dtgv_Nganh.DataSource = nganh;

            dtgv_Nganh.Columns["MANGANH"].HeaderText = "MaNG";
            dtgv_Nganh.Columns["TENNGANH"].HeaderText = "Tên Ngành";
            dtgv_Nganh.Columns["TENKHOA"].HeaderText = "Tên Khoa";
        }

        public void loadMaNG()
        {
            string MaNG = nganhService.GenerateMaNG();
            txt_MaNG.Text = MaNG;
        }

        public void loadCmbKhoa()
        {
            DataTable khoa = nganhService.getDataKhoa();
            cmb_khoa.DataSource = khoa;

            cmb_khoa.DisplayMember = "TENKHOA";
            cmb_khoa.ValueMember = "MAKHOA";
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isEdit)
                {
                    NganhDTO nganh = new NganhDTO();
                    nganh.MaNG = txt_MaNG.Text.Trim();
                    nganh.TenNG = txt_TenNganh.Text.Trim();
                    nganh.MaKhoa = int.Parse(cmb_khoa.SelectedValue.ToString());

                    nganhService.addDataNganh(nganh);

                    loadListNganh();
                    loadHuy();
                    MessageBox.Show("Thêm ngành thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    NganhDTO nganh = new NganhDTO();
                    nganh.MaNG = txt_MaNG.Text.Trim();
                    nganh.TenNG = txt_TenNganh.Text.Trim();
                    nganh.MaKhoa = int.Parse(cmb_khoa.SelectedValue.ToString());

                    nganhService.updateDataNganh(nganh);

                    loadListNganh();
                    loadHuy();
                    MessageBox.Show("Sửa ngành thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            loadHuy();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                string MaNG = dtgv_Nganh.SelectedRows[0].Cells["MANGANH"].Value.ToString();
                DataTable nganh = nganhService.getDataNganhEdit(MaNG);

                txt_MaNG.Text = nganh.Rows[0]["MANGANH"].ToString();
                txt_TenNganh.Text = nganh.Rows[0]["TENNGANH"].ToString();
                cmb_khoa.SelectedValue = nganh.Rows[0]["MAKHOA"].ToString();

                isEdit = true;
                btn_Them.Text = "Lưu";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hệ thống đang gặp lỗi vui lòng thử lại sau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = MessageBox.Show("Xác nhận xóa khoa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    string MaNG = dtgv_Nganh.SelectedRows[0].Cells["MANGANH"].Value.ToString();

                    nganhService.deleteDataNganh(MaNG);

                    loadListNganh();
                    loadHuy();
                    MessageBox.Show("Xóa ngành thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            DataTable nganh = nganhService.getDataNganhFind(keyword);

            dtgv_Nganh.DataSource = nganh;
        }
    }
}
