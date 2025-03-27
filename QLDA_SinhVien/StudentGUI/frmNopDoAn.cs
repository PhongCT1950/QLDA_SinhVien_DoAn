using BusinessLogicLayer;
using DTO;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDA_SinhVien.StudentGUI
{
    public partial class frmNopDoAn: Form
    {
        NopDoAnService nopDoAnService = new NopDoAnService();
        NhomSinhVienService nhomSinhVienService = new NhomSinhVienService();
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
        }

        public void loadDataDoAn()
        {
            string MaSV = UserSession.Refld;
            //string MaSV = "SV005";
            string MaNhom = nhomSinhVienService.getDataMaNhom(MaSV);

            if(MaNhom == null)
            {
                return;
            }

            System.Data.DataTable DoAn = nopDoAnService.getDataDoAn(MaNhom);

            txt_MaNH.Text = DoAn.Rows[0]["MANHOM"].ToString();
            txt_MaDA.Text = DoAn.Rows[0]["MADA"].ToString();
            txt_TenDA.Text = DoAn.Rows[0]["TENDA"].ToString();
            txt_LoaiDA.Text = DoAn.Rows[0]["LOAIDA"].ToString();
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

                string MaNH = nopDoAnService.getDataMaNH(doAnNop.MaNH);
                if(MaNH == doAnNop.MaNH)
                {
                    MessageBox.Show("Nhóm bạn đã nộp đồ án!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

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
    }
}
