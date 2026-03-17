using DTO;
using QLDA_SinhVien.AdminGUI;
using QLDA_SinhVien.StudentGUI;
using QLDA_SinhVien.TeacherGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDA_SinhVien
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
            //Application.Run(new frmGoiYGiangVien());
            List<DeTaiGoiY> listTest = new List<DeTaiGoiY>();

            listTest.Add(new DeTaiGoiY
            {
                MaDT = "11",
                TenDeTai = "Hệ thống quản lý bãi xe thông minh",
                GiangVien = "ThS. Nguyễn Văn A",
                DoPhuHop = "95%",
                LyDo = "Dựa trên kỹ năng C# và SQL Server của bạn. Đề tài này có tính thực tiễn cao và phù hợp với thời gian thực hiện dự án 3 tháng."
            });

            listTest.Add(new DeTaiGoiY
            {
                MaDT = "21",
                TenDeTai = "Ứng dụng nhận diện khuôn mặt điểm danh",
                GiangVien = "TS. Trần Thị B",
                DoPhuHop = "88%",
                LyDo = "Bạn có nền tảng về Python và AI. Đây là một thách thức kỹ thuật tốt giúp nâng cao năng lực nghiên cứu của bạn trong học kỳ này."
            });

            listTest.Add(new DeTaiGoiY
            {
                MaDT = "15",
                TenDeTai = "Website thương mại điện tử tích hợp Chatbot",
                GiangVien = "ThS. Lê Hoàng C",
                DoPhuHop = "92%",
                LyDo = "Đề tài này rất dài để kiểm tra chức năng WrapText của bạn: Hệ thống yêu cầu tích hợp nhiều API từ bên thứ ba như thanh toán trực tuyến, gợi ý sản phẩm thông minh bằng AI, và quản lý kho vận theo thời gian thực. Phù hợp với định hướng làm Fullstack của bạn."
            });
            //Application.Run(new frmKetQuaGoiY(listTest));
        }
    }
}
