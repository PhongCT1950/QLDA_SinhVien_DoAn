using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccessLayer;
using System.Data;

namespace BusinessLogicLayer
{
    public class GiangVienService
    {
        GiangVienRepository giangVienRepository = new GiangVienRepository();

        public string GenerateMaGV()
        {
            List<int> numMaGV = giangVienRepository.GetAllMaGV();
            int n = 1;
            while (numMaGV.Contains(n))
            {
                n++;
            }
            return $"GV{n:D3}";
        }
        public DataTable getListGiangVien()
        {
            return giangVienRepository.getAllGiangVien();
        }

        public DataTable getNameKhoa()
        {
            return giangVienRepository.getKhoaName();
        }

        public DataTable getDataChucDanh()
        {
            return giangVienRepository.getChucDanh();
        }

        public void addNewGiangVien(GiangVienDTO giangvien, bool rdb_Nam, bool rdb_Nu)
        {
            if (string.IsNullOrWhiteSpace(giangvien.TenGV))
            {
                throw new ArgumentException("Tên giảng viên không được để trống.");
            }

            if (string.IsNullOrWhiteSpace(giangvien.DiaChi))
            {
                throw new ArgumentException("Địa chỉ giảng viên không được để trống.");
            }

            if (!rdb_Nam && !rdb_Nu)
            {
                throw new ArgumentException("Vui lòng chọn giới tính trước khi thêm giảng viên.");
            }

            if (string.IsNullOrWhiteSpace(giangvien.Email))
            {
                throw new ArgumentException("Email giảng viên không được để trống.");
            }

            if (string.IsNullOrWhiteSpace(giangvien.SDT))
            {
                throw new ArgumentException("Số điện thoại giảng viên không được để trống.");
            }

            giangVienRepository.addGiangVien(giangvien);
        }

        public GiangVienDTO getDataGiangVienEdit(string MaGV)
        {
            return giangVienRepository.getGiangVienEdit(MaGV);
        }

        public void GiangVienDelete(string MaGV)
        {
            giangVienRepository.DeleteGiangVien(MaGV);
        }

        public string getNameGV(string MaGV)
        {
            return giangVienRepository.getNameGiangvien(MaGV);
        }
    }
}
