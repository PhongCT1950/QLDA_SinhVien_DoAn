using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using Guna.UI2.WinForms;
using Newtonsoft.Json;

namespace QLDA_SinhVien.StudentGUI
{
    public partial class frmKetQuaGoiY: Form
    {
        public string MaDeTaiDaChon { get; set; }
        public string TenDT { get; set; }

        public frmKetQuaGoiY(List<DeTaiGoiY> dataTuAI)
        {
            InitializeComponent();

            //List<DeTaiGoiY> listTest = new List<DeTaiGoiY>();

            //listTest.Add(new DeTaiGoiY
            //{
            //    MaDT = "11",
            //    TenDeTai = "Hệ thống quản lý bãi xe thông minh",
            //    GiangVien = "ThS. Nguyễn Văn A",
            //    DoPhuHop = "95%",
            //    LyDo = "Dựa trên kỹ năng C# và SQL Server của bạn. Đề tài này có tính thực tiễn cao và phù hợp với thời gian thực hiện dự án 3 tháng."
            //});

            //listTest.Add(new DeTaiGoiY
            //{
            //    MaDT = "21",
            //    TenDeTai = "Ứng dụng nhận diện khuôn mặt điểm danh",
            //    GiangVien = "TS. Trần Thị B",
            //    DoPhuHop = "88%",
            //    LyDo = "Bạn có nền tảng về Python và AI. Đây là một thách thức kỹ thuật tốt giúp nâng cao năng lực nghiên cứu của bạn trong học kỳ này."
            //});

            //listTest.Add(new DeTaiGoiY
            //{
            //    MaDT = "15",
            //    TenDeTai = "Website thương mại điện tử tích hợp Chatbot",
            //    GiangVien = "ThS. Lê Hoàng C",
            //    DoPhuHop = "92%",
            //    LyDo = "Đề tài này rất dài để kiểm tra chức năng WrapText của bạn: Hệ thống yêu cầu tích hợp nhiều API từ bên thứ ba như thanh toán trực tuyến, gợi ý sản phẩm thông minh bằng AI, và quản lý kho vận theo thời gian thực. Phù hợp với định hướng làm Fullstack của bạn."
            //});

            designDgvKetQua(dataTuAI);
        }

        public void designDgvKetQua(List<DeTaiGoiY> dataTuAI)
        {
            dgvKetQuaAI.DataSource = dataTuAI;

            dgvKetQuaAI.Columns["TenDeTai"].HeaderText = "Tên Đề Tài";
            dgvKetQuaAI.Columns["GiangVien"].HeaderText = "Giảng viên hướng dẫn";
            dgvKetQuaAI.Columns["DoPhuHop"].HeaderText = "Độ phù hợp";
            dgvKetQuaAI.Columns["LyDo"].HeaderText = "Lý do";

            dgvKetQuaAI.Columns["LyDo"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvKetQuaAI.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvKetQuaAI.Columns["LyDo"].Width = 210;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (dgvKetQuaAI.CurrentRow != null)
            {
                string tenDT = dgvKetQuaAI.CurrentRow.Cells["TenDeTai"].Value.ToString();
                MaDeTaiDaChon = dgvKetQuaAI.CurrentRow.Cells["MaDT"].Value.ToString();
                TenDT = tenDT;

                guna2MessageDialog1.Text = $"Bạn có chắc chắn muốn chọn đề tài:\n\"{tenDT}\"?";
                guna2MessageDialog1.Caption = "Xác nhận lựa chọn";
                guna2MessageDialog1.Buttons = MessageDialogButtons.YesNo;
                guna2MessageDialog1.Icon = MessageDialogIcon.Question;

                DialogResult result = guna2MessageDialog1.Show();

                if (result == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                guna2MessageDialog1.Show("Vui lòng chọn một đề tài từ danh sách!", "Thông báo");
            }
        }
    }
}
