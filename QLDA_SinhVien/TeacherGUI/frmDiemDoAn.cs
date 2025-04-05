using BusinessLogicLayer;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDA_SinhVien.TeacherGUI
{
    public partial class frmDiemDoAn: Form
    {
        DiemService diemService = new DiemService();
        public static double Diem { get; set; }
        bool isEdit = false;
        public frmDiemDoAn()
        {
            InitializeComponent();
        }

        private void frmDiemDoAn_Load(object sender, EventArgs e)
        {
            loadListDoAn();
        }

        public void loadListDoAn()
        {
            string MaGV = UserSession.Refld;
            System.Data.DataTable DoAn = diemService.getDataDsDoAn(MaGV);

            dtgv_Diem.DataSource = DoAn;

            dtgv_Diem.Columns["MADA"].HeaderText = "Mã DA";
            dtgv_Diem.Columns["MANHOM"].HeaderText = "Mã Nhóm";
            dtgv_Diem.Columns["TENDA"].HeaderText = "Tên DA";
            dtgv_Diem.Columns["LOAIDA"].HeaderText = "Loại đồ án";
            dtgv_Diem.Columns["SOTC"].HeaderText = "Số tín chỉ";
            dtgv_Diem.Columns["NGAYNOP"].HeaderText = "Ngày nộp";
            dtgv_Diem.Columns["NGAYNOP"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dtgv_Diem.Columns["PATH"].HeaderText = "Tên tài liệu";
            dtgv_Diem.Columns["DIEM"].HeaderText = "Điểm";
        }

        public void OpenWord(string path)
        {
            if (!File.Exists(path))
            {
                MessageBox.Show("File không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Microsoft.Office.Interop.Word.Application wordApp = null;
            Microsoft.Office.Interop.Word.Document wordDoc = null;

            try
            {
                wordApp = new Microsoft.Office.Interop.Word.Application();
                wordApp.Visible = true;
                wordDoc = wordApp.Documents.Open(path);
                wordApp.Activate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (wordDoc != null)
                {
                    Marshal.ReleaseComObject(wordDoc);
                }

                if (wordApp != null)
                {
                    Marshal.ReleaseComObject(wordApp);
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
        private void btn_openFile_Click_1(object sender, EventArgs e)
        {
            string MaDA = dtgv_Diem.SelectedRows[0].Cells["MADA"].Value.ToString();
            string fileName = diemService.getDataPath(MaDA);
            string filePath = Path.Combine(System.Windows.Forms.Application.StartupPath, "Documents", fileName);

            OpenWord(filePath);
        }

        private void dtgv_Diem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtgv_Diem.Columns[e.ColumnIndex].Name == "DIEM")
            {
                if (e.Value == null || e.Value == DBNull.Value || string.IsNullOrWhiteSpace(e.Value.ToString()))
                {
                    e.Value = "Chưa chấm";
                    e.FormattingApplied = true;
                }
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (dtgv_Diem.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dtgv_Diem.SelectedRows[0].Index;
                string MaDA = dtgv_Diem.SelectedRows[0].Cells["MADA"].Value.ToString();

                frmChiTietDiem.MaDA = MaDA;
                frmChiTietDiem frm = new frmChiTietDiem();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dtgv_Diem.Rows[selectedRowIndex].Cells["DIEM"].Value = Diem;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đồ án!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            bool suaDiem = false;
            foreach (DataGridViewRow row in dtgv_Diem.Rows)
            {
                if (row.IsNewRow) continue;

                var maDA = row.Cells["MADA"].Value?.ToString();
                var diemObj = row.Cells["Diem"].Value;
                var maGV = UserSession.Refld;

                if (string.IsNullOrEmpty(maDA) ||
                    diemObj == null ||
                    string.IsNullOrWhiteSpace(diemObj.ToString()) ||
                    diemObj.ToString() == "Chưa chấm")
                {
                    continue;
                }

                string diemStr = diemObj.ToString().Replace(',', '.');
                if (!double.TryParse(diemStr, out double diemValue))
                {
                    MessageBox.Show($"Điểm của đồ án {maDA} không đúng định dạng số",
                                  "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }

                try
                {
                    if (isEdit)
                    {
                        diemService.updateDataDiem(maDA, diemValue);
                        suaDiem = true;
                    }
                    else
                    {
                        if (diemService.isDiemExists(maDA))
                        {
                            continue;
                        }

                        diemService.addDataDiemDoAn(maDA, diemValue, maGV);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lưu điểm cho đồ án {maDA}: {ex.Message}",
                                  "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            loadListDoAn();
            if (suaDiem)
            {
                MessageBox.Show("Sửa điểm thành công!", "Thông báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                isEdit = false;
            }
            else
            {
                MessageBox.Show("Nhập điểm thành công!", "Thông báo",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_suaDiem_Click(object sender, EventArgs e)
        {
            if (dtgv_Diem.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dtgv_Diem.SelectedRows[0].Index;
                string MaDA = dtgv_Diem.SelectedRows[0].Cells["MADA"].Value.ToString();

                frmChiTietDiem.MaDA = MaDA;
                frmChiTietDiem frm = new frmChiTietDiem();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dtgv_Diem.Rows[selectedRowIndex].Cells["DIEM"].Value = Diem;
                }
                isEdit = true;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đồ án!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dtgv_Diem_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgv_Diem.CurrentRow != null && !dtgv_Diem.CurrentRow.IsNewRow)
            {
                var diemValue = dtgv_Diem.CurrentRow.Cells["Diem"].Value?.ToString();

                if (diemValue == "Chưa chấm" || string.IsNullOrEmpty(diemValue))
                {
                    btn_Them.Enabled = true;
                }
                else
                {
                    btn_Them.Enabled = false;
                }
            }
            else
            {
                btn_Them.Enabled = false;
            }
        }
    }
}
