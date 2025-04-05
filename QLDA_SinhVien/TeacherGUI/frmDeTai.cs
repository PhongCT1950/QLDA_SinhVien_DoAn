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

namespace QLDA_SinhVien.TeacherGUI
{
    public partial class frmDeTai: Form
    {
        DeTaiService deTaiService = new DeTaiService();
        public bool IsEdit = false;
        public frmDeTai()
        {
            InitializeComponent();
        }
        private void frmDeTai_Load(object sender, EventArgs e)
        {
            loadLoaiDA();
            loadListDeTai();
        }

        public void loadLoaiDA()
        {
            DataTable LoaiDa = deTaiService.getLoaiDa();

            cmb_LoaiDT.DataSource = LoaiDa;
            cmb_LoaiDT.DisplayMember = "LOAIDA";
        }

        public void loadListDeTai()
        {
            DataTable DeTai = deTaiService.getDataListDeTai();

            dtgv_DeTai.DataSource = DeTai;
            dtgv_DeTai.Columns["MADT"].HeaderText  = "Mã Đề Tài";
            dtgv_DeTai.Columns["TENDT"].HeaderText  = "Tên Đề Tài";
            dtgv_DeTai.Columns["LOAIDA"].HeaderText = "Loại Đồ Án";
            dtgv_DeTai.Columns["MOTA"].HeaderText   = "Mô Tả Đồ Án";
            dtgv_DeTai.Columns["TENGV"].HeaderText  = "Tên Giảng Viên";
        }

        public void loadAllDeTai()
        {
            DataTable DeTai = deTaiService.getDataDeTai();

            dtgv_DeTai.DataSource = DeTai;
            dtgv_DeTai.Columns["MADT"].HeaderText = "Mã Đề Tài";
            dtgv_DeTai.Columns["TENDT"].HeaderText = "Tên Đề Tài";
            dtgv_DeTai.Columns["LOAIDA"].HeaderText = "Loại Đồ Án";
            dtgv_DeTai.Columns["MOTA"].HeaderText = "Mô Tả Đồ Án";
            dtgv_DeTai.Columns["TENGV"].HeaderText = "Tên Giảng Viên";
        }

        public void loadHuy()
        {
            txt_MaDT.Text = "";
            txt_TenDT.Text = "";
            txt_MoTa.Text = "";
            btn_Them.Text = "Thêm";
            IsEdit = false;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsEdit)
                {
                    DeTaiDTO detai = new DeTaiDTO();
                    detai.TenDT = txt_TenDT.Text;
                    detai.LoaiDA = cmb_LoaiDT.Text;
                    detai.MoTa = txt_MoTa.Text;
                    detai.MaGV = UserSession.Username;
                    deTaiService.addDetai(detai);

                    MessageBox.Show("Thêm đề tài thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadHuy();
                    loadListDeTai();
                }
                else
                {
                    DeTaiDTO detai = new DeTaiDTO();
                    detai.MaDT = txt_MaDT.Text;
                    detai.TenDT = txt_TenDT.Text;
                    detai.LoaiDA = cmb_LoaiDT.Text;
                    detai.MoTa = txt_MoTa.Text;
                    deTaiService.updateDataDeTai(detai);

                    MessageBox.Show("Sửa đề tài thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadHuy();
                    loadListDeTai();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                loadAllDeTai();
                btn_Sua.Enabled = false;
                btn_Xoa.Enabled = false;
            }
            else
            {
                loadListDeTai();
                btn_Sua.Enabled = true;
                btn_Xoa.Enabled = true;
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = dtgv_DeTai.SelectedRows[0];
                string MaDT = row.Cells["MADT"].Value.ToString();
                DeTaiDTO detai = deTaiService.getEditDeTai(MaDT);

                txt_MaDT.Text = detai.MaDT;
                txt_TenDT.Text = detai.TenDT;
                txt_MoTa.Text = detai.MoTa;
                cmb_LoaiDT.Text = detai.LoaiDA;

                IsEdit = true;
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
                DataGridViewRow rows = dtgv_DeTai.SelectedRows[0];
                string MaDTs = rows.Cells["MADT"].Value.ToString();
                DialogResult result = MessageBox.Show("Xác nhận xóa đề tài?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    if (dtgv_DeTai.SelectedRows.Count > 0)
                    {
                        DataGridViewRow row = dtgv_DeTai.SelectedRows[0];
                        string MaDT = row.Cells["MADT"].Value.ToString();

                        deTaiService.deteleDataDeTai(MaDT);
                        MessageBox.Show("Xóa đề tài thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btn_Them.Text = "Thêm";
                        loadHuy();
                        loadListDeTai();
                    }
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
            DataTable detai = deTaiService.getDataDeTaiFind(keyword);

            dtgv_DeTai.DataSource = detai;
        }
    }
}
