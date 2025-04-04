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
    public partial class frmChucDanh: Form
    {
        ChucDanhService chucDanhService = new ChucDanhService();
        bool isEdit = false;
        public frmChucDanh()
        {
            InitializeComponent();
        }

        private void frmChucDanh_Load(object sender, EventArgs e)
        {
            loadHuy();
            loadListCD();
        }

        public void loadHuy()
        {
            txt_MaCD.Text = "";
            txt_TenCD.Text = "";
            txt_hesoCD.Text = "";
            btn_Them.Text = "Thêm";
            isEdit = false;
        }

        public void loadListCD()
        {
            DataTable chucdanh = chucDanhService.getDataDsChucDanh();
            dtgv_ChucDanh.DataSource = chucdanh;

            dtgv_ChucDanh.Columns["MACD"].HeaderText = "Mã CD";
            dtgv_ChucDanh.Columns["ChucDanh"].HeaderText = "Chức Danh";
            dtgv_ChucDanh.Columns["hesoCD"].HeaderText = "Hệ Số Chức Danh";
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isEdit)
                {
                    ChucDanhDTO chucdanh = new ChucDanhDTO();
                    chucdanh.ChucDanh = txt_TenCD.Text.Trim();
                    if (float.TryParse(txt_hesoCD.Text.Trim(), out float heso))
                    {
                        chucdanh.hesoCD = (float)Math.Round(heso,2);
                    }
                    else
                    {
                        MessageBox.Show("Hệ số chức danh không hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    chucDanhService.addDataChucDanh(chucdanh);

                    loadListCD();
                    loadHuy();
                    MessageBox.Show("Thêm chức danh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ChucDanhDTO chucdanh = new ChucDanhDTO();
                    chucdanh.MaCD = int.Parse(txt_MaCD.Text.Trim());
                    chucdanh.ChucDanh = txt_TenCD.Text.Trim();
                    if (float.TryParse(txt_hesoCD.Text.Trim(), out float heso))
                    {
                        chucdanh.hesoCD = (float)Math.Round(heso, 2);
                    }
                    else
                    {
                        MessageBox.Show("Hệ số chức danh không hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    chucDanhService.updateDataChucDanh(chucdanh);

                    loadListCD();
                    loadHuy();
                    MessageBox.Show("Sửa chức danh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string MaCD = dtgv_ChucDanh.SelectedRows[0].Cells["MaCD"].Value.ToString();
                DataTable chucdanh = chucDanhService.getDataChucDanhEdit(MaCD);

                txt_MaCD.Text = chucdanh.Rows[0]["MaCD"].ToString();
                txt_TenCD.Text = chucdanh.Rows[0]["ChucDanh"].ToString();
                txt_hesoCD.Text = chucdanh.Rows[0]["hesoCD"].ToString();

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
                DialogResult = MessageBox.Show("Xác nhận xóa chức danh?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    string MaCD = dtgv_ChucDanh.SelectedRows[0].Cells["MaCD"].Value.ToString();

                    chucDanhService.deleteDataChucDanh(MaCD);

                    loadListCD();
                    loadHuy();
                    MessageBox.Show("Xóa chức danh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chức danh đang còn sử dụng không thể xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_Find_TextChanged(object sender, EventArgs e)
        {
            string keyword = txt_Find.Text.Trim();
            DataTable chucdanh = chucDanhService.getDataChucDanhFind(keyword);

            dtgv_ChucDanh.DataSource = chucdanh;
        }
    }
}
