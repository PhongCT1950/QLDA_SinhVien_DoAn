using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccessLayer;
using System.Data;
using System.Runtime.Remoting.Messaging;

namespace BusinessLogicLayer
{
    public class SinhVienService
    {
        private SinhVienRepository sinhVienRepository = new SinhVienRepository();

        public DataTable getListSinhVien()
        {
            return sinhVienRepository.getAllSinhViens();
        }

        public DataTable getListNganh()
        {
            return sinhVienRepository.getAllNganh();
        }

        public DataTable getListDonVi()
        {
            return sinhVienRepository.getAllDonVi();
        }

        public string GenerateMaSV()
        {
            List<int> numMaSV = sinhVienRepository.GetAllMaSV();
            int n = 1;
            while (numMaSV.Contains(n))
            {
                n++;
            }
            return $"SV{n:D3}";
        }

        public DataTable getListHeDT()
        {
            return sinhVienRepository.getAllHeDT();
        }

        public DataTable getListNienKhoa()
        {
            return sinhVienRepository.getAllNienKhoa();
        }

        public void AddNewSinhVien(SinhVienDTO sinhVien,bool rdb_Nam, bool rdb_Nu)
        {
            if (string.IsNullOrWhiteSpace(sinhVien.TenSV))
            {
                throw new ArgumentException("Tên sinh viên không được để trống.");
            }

            if (string.IsNullOrWhiteSpace(sinhVien.DiaChi))
            {
                throw new ArgumentException("Địa chỉ sinh viên không được để trống.");
            }

            if (!rdb_Nam && !rdb_Nu)
            {
                throw new ArgumentException("Vui lòng chọn giới tính trước khi thêm sinh viên.");
            }

            if (string.IsNullOrWhiteSpace(sinhVien.Email))
            {
                throw new ArgumentException("Email sinh viên không được để trống.");
            }

            if (string.IsNullOrWhiteSpace(sinhVien.SDT))
            {
                throw new ArgumentException("Số điện thoại sinh viên không được để trống.");
            }

            if (string.IsNullOrWhiteSpace(sinhVien.MaNK))
            {
                throw new ArgumentException("Niên khóa không được để trống.");
            }
            sinhVienRepository.AddSinhVien(sinhVien);
        }

        public void DeleteSinhvien(string MaSV)
        {
            sinhVienRepository.DeleteSinhVien(MaSV);
        }

        public void UpdateDataSinhVien(SinhVienDTO sinhVien)
        {
            if (string.IsNullOrWhiteSpace(sinhVien.TenSV))
            {
                throw new ArgumentException("Tên sinh viên không được để trống.");
            }

            if (string.IsNullOrWhiteSpace(sinhVien.DiaChi))
            {
                throw new ArgumentException("Địa chỉ sinh viên không được để trống.");
            }

            if (string.IsNullOrWhiteSpace(sinhVien.Email))
            {
                throw new ArgumentException("Email sinh viên không được để trống.");
            }

            if (string.IsNullOrWhiteSpace(sinhVien.SDT))
            {
                throw new ArgumentException("Số điện thoại sinh viên không được để trống.");
            }

            if (string.IsNullOrWhiteSpace(sinhVien.MaNK))
            {
                throw new ArgumentException("Niên khóa không được để trống.");
            }
            sinhVienRepository.UpdateSinhVien(sinhVien);
        }

        public DataTable getDataSinhVienFind(string keyword)
        {
            return sinhVienRepository.getSinhVienFind(keyword);
        }
        public SinhVienDTO getDataSinhVien(string MaSV)
        {
            return sinhVienRepository.getSinhVienEdit(MaSV);
        }

        public string getNameSV(string MaSV)
        {
            return sinhVienRepository.getNameSinhVien(MaSV);
        }
    }
}
