using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using System.Web.Util;
using System.Data.SqlClient;
using DTO;

namespace QLDA_SinhVien.TeacherGUI
{
    public partial class frmDiemDoAn: Form
    {
        DiemService diemService = new DiemService();
        public frmDiemDoAn()
        {
            InitializeComponent();
        }

        private void frmDiemDoAn_Load(object sender, EventArgs e)
        {
            loadListDoAn();
            loadListDiemDoAn();
            readDiem();
        }

        private void readDiem()
        {
            dtgv_diemDoAn.Columns["DIEM"].ReadOnly = true;
        }

        public void loadListDoAn()
        {
            string MaGV = UserSession.Refld;
            System.Data.DataTable DoAn = diemService.getDataDsDoAn(MaGV);

            dtgv_Diem.DataSource = DoAn;

            dtgv_Diem.Columns["MADA"].HeaderText = "MaDA";
            dtgv_Diem.Columns["MANHOM"].HeaderText = "MaNH";
            dtgv_Diem.Columns["TENDA"].HeaderText = "TenDA";
            dtgv_Diem.Columns["LOAIDA"].HeaderText = "Loại đồ án";
            dtgv_Diem.Columns["SOTC"].HeaderText = "Số tín chỉ";
            dtgv_Diem.Columns["NGAYNOP"].HeaderText = "Ngày nộp";
            dtgv_Diem.Columns["NGAYNOP"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dtgv_Diem.Columns["PATH"].HeaderText = "Tên tài liệu";
            dtgv_Diem.Columns["DIEM"].HeaderText = "Điểm";
        }

        public void loadListDiemDoAn()
        {
            string MaGV = UserSession.Refld;
            System.Data.DataTable DoAn = diemService.getDataDiemDoAn(MaGV);

            dtgv_diemDoAn.DataSource = DoAn;

            dtgv_diemDoAn.Columns["MADA"].HeaderText = "MaDA";
            dtgv_diemDoAn.Columns["MANHOM"].HeaderText = "MaNH";
            dtgv_diemDoAn.Columns["TENDA"].HeaderText = "TenDA";
            dtgv_diemDoAn.Columns["LOAIDA"].HeaderText = "Loại đồ án";
            dtgv_diemDoAn.Columns["SOTC"].HeaderText = "Số tín chỉ";
            dtgv_diemDoAn.Columns["NGAYNOP"].HeaderText = "Ngày nộp";
            dtgv_diemDoAn.Columns["NGAYNOP"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dtgv_diemDoAn.Columns["PATH"].HeaderText = "Tên tài liệu";
            dtgv_diemDoAn.Columns["DIEM"].HeaderText = "Điểm";
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

        private void btn_openFile_Click(object sender, EventArgs e)
        {
            string MaDA = dtgv_Diem.SelectedRows[0].Cells["MADA"].Value.ToString();
            string fileName = diemService.getDataPath(MaDA);
            string filePath = Path.Combine(System.Windows.Forms.Application.StartupPath, "Documents", fileName);

            OpenWord(filePath);
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            bool coLuuDuLieu = false;
            try
            {
                foreach (DataGridViewRow row in dtgv_Diem.Rows)
                {
                    if (row.IsNewRow) continue;

                    var MaDA = row.Cells["MADA"].Value?.ToString();
                    var Diem = row.Cells["Diem"].Value;
                    //var MaGV = "GV001";
                    var MaGV = UserSession.Refld;

                    if (string.IsNullOrEmpty(MaDA))
                    {
                        continue;
                    }

                    if (Diem == null || string.IsNullOrWhiteSpace(Diem.ToString()) || Diem.ToString() == "Chưa chấm")
                    {
                        continue;
                    }

                    try
                    {
                        string diemStr = Diem.ToString().Replace(',', '.');
                        double diemValue = Convert.ToDouble(diemStr, System.Globalization.CultureInfo.InvariantCulture);

                        diemService.addDataDiemDoAn(MaDA, diemValue, MaGV);

                        coLuuDuLieu = true;
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show($"Điểm của đồ án {MaDA} không đúng định dạng số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi lưu điểm cho đồ án {MaDA}: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (coLuuDuLieu)
                {
                    MessageBox.Show("Nhập điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadListDoAn();
                    loadListDiemDoAn();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu nào được lưu. Vui lòng kiểm tra lại điểm đã nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private void btn_suaDiem_Click(object sender, EventArgs e)
        {
            dtgv_diemDoAn.Columns["DIEM"].ReadOnly = false;
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            bool coLuuDuLieu = false;
            try
            {
                foreach (DataGridViewRow row in dtgv_diemDoAn.Rows)
                {
                    if (row.IsNewRow) continue;

                    var MaDA = row.Cells["MADA"].Value?.ToString();
                    var Diem = row.Cells["Diem"].Value;

                    try
                    {
                        string diemStr = Diem.ToString().Replace(',', '.');
                        double diemValue = Convert.ToDouble(diemStr, System.Globalization.CultureInfo.InvariantCulture);

                        if (diemValue < 0 || diemValue > 10)
                        {
                            MessageBox.Show($"Điểm của đồ án {MaDA} không hợp lệ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            continue;
                        }

                        diemService.updateDataDiem(MaDA, diemValue);
                        coLuuDuLieu = true;
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show($"Điểm của đồ án {MaDA} không đúng định dạng số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi lưu điểm cho đồ án {MaDA}: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (coLuuDuLieu)
                {
                    MessageBox.Show("Sửa điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadListDiemDoAn();
                    readDiem();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu nào được sửa. Vui lòng kiểm tra lại điểm đã sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_Find_TextChanged(object sender, EventArgs e)
        {
            string keyword = txt_Find.Text.Trim();
            string MaGV = UserSession.Refld;
            System.Data.DataTable diem = diemService.getDataDiemFind(keyword,MaGV);

            dtgv_Diem.DataSource = diem;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = txt_Find.Text.Trim();
            string MaGV = UserSession.Refld;
            System.Data.DataTable diem = diemService.getDataDiemDoAnFind(keyword, MaGV);

            dtgv_diemDoAn.DataSource = diem;
        }
    }
}
