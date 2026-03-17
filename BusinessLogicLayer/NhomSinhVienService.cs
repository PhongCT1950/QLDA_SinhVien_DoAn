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

        public DataTable getDataNhomSV(string MAGV)
        {
            return nhomSinhVienRepository.getNhomSV(MAGV);
        }

        public DataTable getDatadsNhomSV(string MAGV)
        {
            return nhomSinhVienRepository.getdsNhomSV(MAGV);
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

        public void deleteDataNhom(string manhom)
        {
            nhomSinhVienRepository.deleteNhom(manhom);
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
            return nhomSinhVienRepository.getMaDT(MaNhom);
        }

        public DataTable getDatattNhomSV(string MANHOM)
        {
            return nhomSinhVienRepository.getttNhomSV(MANHOM);
        }

        public void updateDataTdDeTai(string MANHOM, string MADT)
        {
            nhomSinhVienRepository.updateTdDeTai(MANHOM,MADT);
        }

        public string getDataMaNHinDoAn(string MaNH)
        {
            return nhomSinhVienRepository.getMaNHinDoAn(MaNH);
        }
        
        public int DemSinhVienDaCoNhom(string MANK)
        {
            return nhomSinhVienRepository.SinhVienDaCoNhom(MANK);
        }
        public int DemTongSinhVien(string MANK)
        {
            return nhomSinhVienRepository.TongSoSinhVien(MANK);
        }
    }
}
