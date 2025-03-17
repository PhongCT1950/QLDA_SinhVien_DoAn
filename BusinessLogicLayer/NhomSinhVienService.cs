using DataAccessLayer;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class NhomSinhVienService
    {
        NhomSinhVienRepository nhomSinhVienRepository = new NhomSinhVienRepository();
        public string GenerateMaNH()
        {
            List<int> numMaNH = nhomSinhVienRepository.GetAllMaNH();
            int n = 1;
            while (numMaNH.Contains(n))
            {
                n++;
            }
            return $"NH{n:D3}";
        }

        public void addDataInNhomSV(NhomSinhVienDTO nhomsv)
        {
            nhomSinhVienRepository.addDataNhomSV(nhomsv);
        }

        public void addDataInChiTietNhom(string manhom, string masv)
        {
            nhomSinhVienRepository.addDataChiTietNhom(manhom, masv);
        }

        public DataTable getDataNhomSV()
        {
            return nhomSinhVienRepository.getNhomSV();
        }

        public void updateDataNhomSV(NhomSinhVienDTO nhomsv)
        {
            nhomSinhVienRepository.updateDataNhomSV(nhomsv);
        }

        public void updateDataChiTietNhom(string manhom, string masv)
        {
            nhomSinhVienRepository.updateDataChiTietNhom(manhom, masv);
        }

        public DataTable getDsThanhVienSV(string MANHOM)
        {
            return nhomSinhVienRepository.getDsThanhVien(MANHOM);
        }

        public void deleteDataThanhVien(string manhom)
        {
            nhomSinhVienRepository.deleteThanhVien(manhom);
        }

        public void deleteDataNhomSV(string manhom)
        {
            nhomSinhVienRepository.deleteNhomSV(manhom);
        }

        public string getDataMaNhom(string MaSV)
        {
            return nhomSinhVienRepository.getMaNhom(MaSV);
        }

        public void updateDKDeTai(string MaNhom, string MaDT)
        {
            nhomSinhVienRepository.updateDangKyDeTai(MaNhom,MaDT);
        }

        public string getDataMaDT(string MaNhom)
        {
            return nhomSinhVienRepository.getMaNhom(MaNhom);
        }
    }
}
