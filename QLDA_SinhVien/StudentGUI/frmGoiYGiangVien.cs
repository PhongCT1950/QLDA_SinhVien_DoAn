using BusinessLogicLayer;
using DTO;
using Guna.UI2.WinForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace QLDA_SinhVien.StudentGUI
{
    public partial class frmGoiYGiangVien : Form
    {
        public string MaDeTaiDaChon { get; set; }
        public string tenDT { get; set; }
        SinhVienService sinhVienService = new SinhVienService();
        DeTaiService deTaiService = new DeTaiService();
        NhomSinhVienService nhomSinhVienService = new NhomSinhVienService();
        QuyenDoAnService quyenDoAnService = new QuyenDoAnService();
        NganhService nganhService = new NganhService();
        public frmGoiYGiangVien()
        {
            InitializeComponent();

            LoadListNganh();
            loadLoaiDA();

            rtxtMoTa.Text = "Mô tả ý tưởng về đề tài bạn muốn thực hiện, hệ thống AI sẽ gợi ý đề tài phù hợp với ý tưởng của bạn.";
        }

        public void LoadListNganh()
        {
            cmbNganh.Enabled = false;
            string MASV = UserSession.Refld;
            DataTable listNganh = sinhVienService.getDataNganhSinhVien(MASV);
            if (listNganh.Rows.Count > 0)
            {
                cmb_Nganh.DataSource = listNganh;
                cmb_Nganh.DisplayMember = "TENNGANH";
                cmb_Nganh.ValueMember = "MANGANH";
            }
        }

        public void loadLoaiDA()
        {
            cmb_LoaiDT.Enabled = false;
            string MaSV = UserSession.Refld;
            string MaNhom = nhomSinhVienService.getDataMaNhom(MaSV);

            if (string.IsNullOrEmpty(MaNhom))
            {
                cmb_LoaiDT.DataSource = null;
                return;
            }

            DataTable LoaiDa = quyenDoAnService.getLoaiDACuaNhom(MaNhom);

            if (LoaiDa != null && LoaiDa.Rows.Count > 0)
            {
                cmb_LoaiDT.DataSource = LoaiDa;
                cmb_LoaiDT.DisplayMember = "LOAIDA";
            }
            else
            {
                cmb_LoaiDT.DataSource = null;
            }
        }

        private async void btnGoiY_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rtxtMoTa.Text))
            {
                MessageBox.Show("Vui lòng nhập mô tả ý tưởng đề tài của bạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnGoiY.Enabled = false;
            btnBack.Enabled = false;
            btnGoiY.Text = "Đang phân tích...";

            try
            {
                string nganh = cmbNganh.Text;
                string loaiDoAn = cmb_LoaiDT.Text;
                string moTa = rtxtMoTa.Text;
                string MaSV = UserSession.Refld;
                string MaNhom = nhomSinhVienService.getDataMaNhom(MaSV);
                string MaNganh = nganhService.getDataMaNganh(MaSV);

                string danhSachDeTaiKho = deTaiService.getDeTaiChoAI(MaNhom, MaNganh);

                string prompt = $@"
                Bạn là trợ lý học thuật. Nhiệm vụ của bạn là lọc KHO ĐỀ TÀI và chọn ra 3 đề tài phù hợp nhất.

                THÔNG TIN TỪ SINH VIÊN:
                - Ngành học: {nganh}
                - Loại đồ án: {loaiDoAn}
                - Ý tưởng mong muốn: {moTa}

                KHO ĐỀ TÀI:
                {danhSachDeTaiKho}

                [LUẬT LỆ BẮT BUỘC - PHẢI TUÂN THỦ TUYỆT ĐỐI]
                1. KHÔNG ĐƯỢC BỊA ĐẶT: Chỉ được phép chọn các đề tài có mặt trong [KHO ĐỀ TÀI HIỆN CÓ]. Tuyệt đối không tự sáng tạo ra Mã đề tài (MaDT) hay Tên đề tài mới.
                2. CHÍNH XÁC 100%: MaDT, TenDeTai, và GiangVien phải khớp từng chữ với dữ liệu trong kho.
                3. SỐ LƯỢNG: Trả về tối đa 3 đề tài có độ phù hợp cao nhất (từ trên 70%). Nếu không có đề tài nào phù hợp, hãy trả về mảng rỗng [].
                4. ĐỊNH DẠNG: Chỉ trả về MỘT MẢNG JSON hợp lệ. Không giải thích thêm, không dùng markdown ```json, không chào hỏi.

                QUAN TRỌNG: Trả về kết quả định dạng chuỗi JSON nguyên gốc (KHÔNG dùng Markdown, KHÔNG có dấu ```json ở đầu).
                Cấu trúc JSON là một mảng chứa 3 đối tượng (Object) với các Key sau:
                [
                  {{
                    ""MaDT"": ""Mã đề tài lấy từ danh sách trong kho đề tài. Lưu ý MaDT này phải nằm trong Kho đề tài: {danhSachDeTaiKho} và tương ứng với đề tài trong kho"",
                    ""TenDeTai"": ""Tên đề tài"",
                    ""GiangVien"": ""Tên giảng viên hướng dẫn"",
                    ""DoPhuHop"": ""Đánh giá % (VD: 90%)"",
                    ""LyDo"": ""Giải thích ngắn gọn 1 câu tại sao phù hợp với {nganh} và ý tưởng trên""
                  }}
                ]";

                GeminiHelper aiHelper = new GeminiHelper();
                string rawJson = await aiHelper.AskAI(prompt);

                rawJson = rawJson.Replace("```json", "").Replace("```", "").Trim();

                int startIndex = rawJson.IndexOf('[');
                int endIndex = rawJson.LastIndexOf(']');

                if (startIndex >= 0 && endIndex >= startIndex)
                {
                    rawJson = rawJson.Substring(startIndex, endIndex - startIndex + 1);
                }
                else
                {
                    MessageBox.Show("Dữ liệu thô AI trả về:\n" + rawJson, "AI không trả về chuẩn JSON", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<DTO.DeTaiGoiY> listKetQua = JsonConvert.DeserializeObject<List<DTO.DeTaiGoiY>>(rawJson);

                frmKetQuaGoiY frmKetQua = new frmKetQuaGoiY(listKetQua);

                this.Hide();

                DialogResult result = frmKetQua.ShowDialog();

                if (result == DialogResult.OK)
                {
                    this.MaDeTaiDaChon = frmKetQua.MaDeTaiDaChon;
                    this.tenDT = frmKetQua.TenDT;
                    this.DialogResult = DialogResult.OK;
                }
                else if (result == DialogResult.Cancel)
                {
                    this.DialogResult = DialogResult.Cancel;
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi phân tích hoặc dữ liệu trả về sai cấu trúc:\n" + ex.Message, "Lỗi AI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGoiY.Enabled = true;
                btnGoiY.Text = "Bắt đầu gợi ý";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool firstClick = true;
        private void rtxtMoTa_Click(object sender, EventArgs e)
        {
            if (firstClick)
            {
                rtxtMoTa.Text = "";
                firstClick = false;
                rtxtMoTa.ForeColor = Color.Black;
            }
        }
    }
}
