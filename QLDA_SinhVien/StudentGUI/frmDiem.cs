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

namespace QLDA_SinhVien.StudentGUI
{
    public partial class frmDiem: Form
    {
        NhomSinhVienService nhomSinhVienService = new NhomSinhVienService();
        DiemService diemService = new DiemService();
        public frmDiem()
        {
            InitializeComponent();
        }

        private void frmDiem_Load(object sender, EventArgs e)
        {
            //loadDiem();
        }

        //public void loadDiem()
        //{
        //    label1.Visible = false;
        //    string MASV = UserSession.Refld;
        //    //string MASV = "SV005";
        //    string MaNH = nhomSinhVienService.getDataMaNhom(MASV);

        //    if(MaNH == null)
        //    {
        //        label1.Visible = true;
        //        return;
        //    }
        //    string MaDA = diemService.getDataMaDA(MaNH);
        //    DataTable dsDiem = diemService.getDataDiem(MaDA);
        //    string DiemMaDA = diemService.getDataMaDADiem(MaDA);
        //    if (DiemMaDA != MaDA)
        //    {
        //        label1.Visible = true;
        //        return;
        //    }

        //    dtgv_Diem.DataSource = dsDiem;

        //    dtgv_Diem.Columns["MADA"].HeaderText = "MaDA";
        //    dtgv_Diem.Columns["MANHOM"].HeaderText = "MaNH";
        //    dtgv_Diem.Columns["TENDA"].HeaderText = "TenDA";
        //    dtgv_Diem.Columns["LOAIDA"].HeaderText = "Loại đồ án";
        //    dtgv_Diem.Columns["SOTC"].HeaderText = "Số tín chỉ";
        //    dtgv_Diem.Columns["NGAYNOP"].HeaderText = "Ngày nộp";
        //    dtgv_Diem.Columns["NGAYNOP"].DefaultCellStyle.Format = "dd/MM/yyyy";
        //    dtgv_Diem.Columns["DIEM"].HeaderText = "Điểm";
        //}
    }
}
