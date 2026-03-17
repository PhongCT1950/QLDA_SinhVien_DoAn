using BusinessLogicLayer;
using DTO;
using Microsoft.Office.Interop.Word;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QLDA_SinhVien.StudentGUI
{
    public partial class frmNopDoAn: Form
    {
        NopDoAnService nopDoAnService = new NopDoAnService();
        NhomSinhVienService nhomSinhVienService = new NhomSinhVienService();
        DiemService diemService = new DiemService();
        public frmNopDoAn()
        {
            InitializeComponent();
        }
        private string selectedFilePath = "";
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Chọn đồ án";
            openFileDialog1.Filter = "Tất cả tập tin (*.*)|*.*|Hình ảnh (*.jpg;*.png)|*.jpg;*.png|Tài liệu (*.pdf;*.docx)|*.pdf;*.docx";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                selectedFilePath = openFileDialog1.FileName;
                txt_Path.Text = Path.GetFileName(filePath);
            }
        }

        private void frmNopDoAn_Load(object sender, EventArgs e)
        {
            guna2PictureBox1.MouseEnter += (s, ev) => guna2PictureBox1.BackColor = Color.LightGray;
            guna2PictureBox1.MouseLeave += (s, ev) => guna2PictureBox1.BackColor = Color.Transparent;
            loadDataDoAn();
            KiemTraTinhTrang();
            loadDiem();
        }
        public void loadDiem()
        {
            labelThongBao.Visible = false;
            string MASV = UserSession.Refld;
            string MaNH = nhomSinhVienService.getDataMaNhom(MASV);

            if (MaNH == null)
            {
                labelThongBao.Visible = true;
                return;
            }
            string MaDA = diemService.getDataMaDA(MaNH);

            System.Data.DataTable dsDiem = diemService.getDataDiem(MaDA);

            if (dsDiem != null && dsDiem.Rows.Count > 0)
            {
                labelThongBao.Visible = false;

                lbTenDA.Text = dsDiem.Rows[0]["TENDA"].ToString();
                lbLoaiDA.Text = dsDiem.Rows[0]["LOAIDA"].ToString();
                lbTaiLieu.Text = dsDiem.Rows[0]["PATH"].ToString();

                if (dsDiem.Rows[0]["NGAYNOP"] != DBNull.Value)
                {
                    lbNgayNop.Text = Convert.ToDateTime(dsDiem.Rows[0]["NGAYNOP"]).ToString("dd/MM/yyyy");
                }

                if (dsDiem.Rows[0]["DIEM"] != DBNull.Value)
                {
                    lbDiem.Text = dsDiem.Rows[0]["DIEM"].ToString();
                }
                else
                {
                    lbDiem.Text = "Chưa có điểm";
                    lbDiem.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                labelThongBao.Visible = true;
                btn_openFile.Enabled = false;

                lbTenDA.Text = "...";
                lbNgayNop.Text = "...";
                lbTaiLieu.Text = "...";
                lbLoaiDA.Text = "...";
                lbDiem.Text = "...";
            }

        }

        public void KiemTraTinhTrang()
        {
            DoAnNopDTO doAnNop = new DoAnNopDTO();
            doAnNop.MaNH = txt_MaNH.Text;
            doAnNop.MaDA = txt_MaDA.Text;
            doAnNop.NgayNop = txt_NgayNop.Value;
            doAnNop.Path = txt_Path.Text;

            bool MaNH = nopDoAnService.getDataKiemTraNopDA(doAnNop.MaNH, doAnNop.MaDA);
            if (MaNH)
            {
                btn_Them.Enabled = false;
                lbThongBao.Visible = true;
            }
        }

        public void loadDataDoAn()
        {
            string MaSV = UserSession.Refld;
            string MaNhom = nhomSinhVienService.getDataMaNhom(MaSV);

            if (string.IsNullOrEmpty(MaNhom))
            {
                return;
            }

            System.Data.DataTable DoAn = nopDoAnService.getDataDoAn(MaNhom);

            if (DoAn != null && DoAn.Rows.Count > 0)
            {
                txt_MaNH.Text = DoAn.Rows[0]["MANHOM"].ToString().Trim();
                txt_MaDA.Text = DoAn.Rows[0]["MADA"].ToString().Trim();
                txt_TenDA.Text = DoAn.Rows[0]["TENDA"].ToString().Trim();
                txt_LoaiDA.Text = DoAn.Rows[0]["LOAIDA"].ToString().Trim();
            }
            else
            {
                txt_MaNH.Text = MaNhom;
                txt_MaDA.Text = "Chưa có";
                txt_TenDA.Text = "Chưa được phân công";
                txt_LoaiDA.Text = "N/A";
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_Path.Text))
                {
                    MessageBox.Show("Chưa chọn file đồ án!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(selectedFilePath) || !File.Exists(selectedFilePath))
                {
                    MessageBox.Show("File không hợp lệ hoặc không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string maNH_Input = txt_MaNH.Text.Trim();
                string MaNH_DaNop = nopDoAnService.getDataMaNH(maNH_Input);

                if (!string.IsNullOrEmpty(MaNH_DaNop) && MaNH_DaNop == maNH_Input)
                {
                    MessageBox.Show("Nhóm của bạn đã nộp đồ án rồi! Không thể nộp thêm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string fileName = Path.GetFileName(selectedFilePath);
                string destinationFolder = Path.Combine(System.Windows.Forms.Application.StartupPath, "Documents");
                string destinationPath = Path.Combine(destinationFolder, fileName);
            
                if (!Directory.Exists(destinationFolder))
                {
                    Directory.CreateDirectory(destinationFolder);
                }

                File.Copy(selectedFilePath, destinationPath, true);

                DoAnNopDTO doAnNop = new DoAnNopDTO();
                doAnNop.MaNH = txt_MaNH.Text;
                doAnNop.MaDA = txt_MaDA.Text;
                doAnNop.NgayNop = txt_NgayNop.Value;
                doAnNop.Path = txt_Path.Text;

                nopDoAnService.addDataDoAnNop(doAnNop);

                nopDoAnService.UpdateDataDoAnNop(doAnNop.MaNH);

                MessageBox.Show("Nộp đồ án thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hệ thống đang gặp lỗi vui lòng thử lại sau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string filePath = Path.Combine(System.Windows.Forms.Application.StartupPath, "Documents", "filetest.docx");

            OpenWord(filePath);
        }

        private void btn_openFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lbTaiLieu.Text))
            {
                MessageBox.Show("Chưa có tài liệu đính kèm nào để mở!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string MaDA = txt_MaDA.Text.Trim();
            if (string.IsNullOrEmpty(MaDA))
            {
                MessageBox.Show("Mã đồ án trống hoặc không hợp lệ!", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string fileName = diemService.getDataPath(MaDA);
            if (string.IsNullOrEmpty(fileName))
            {
                MessageBox.Show("Hệ thống chưa ghi nhận file bài làm cho đồ án này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string filePath = Path.Combine(System.Windows.Forms.Application.StartupPath, "Documents", fileName);

            if (!File.Exists(filePath))
            {
                MessageBox.Show($"Không tìm thấy file vật lý tại đường dẫn:\n{filePath}", "Lỗi File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OpenWord(filePath);
        }
    }
}
