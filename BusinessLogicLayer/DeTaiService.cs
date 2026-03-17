using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DTO;

namespace BusinessLogicLayer
{
    public class DeTaiService
    {
        DeTaiRepository deTaiRepository = new DeTaiRepository();
        public DataTable getLoaiDa()
        {
            return deTaiRepository.getLoaiDA();
        }

        public DataTable getDataListDeTai()
        {
            return deTaiRepository.getListDeTai();
        }

        public DataTable getAllDataDeTai(string MaNH,string MaNganh)
        {
            return deTaiRepository.getAllDeTai(MaNH, MaNganh);
        }

        public DataTable getDataDeTai()
        {
            return deTaiRepository.getDeTai();
        }

        public DataTable GetDataThongKeDeTaiTheoNganh(string MANK)
        {
            return deTaiRepository.GetThongKeDeTaiTheoNganh(MANK);
        }
        public DeTaiDTO getEditDeTai(string MaDT)
        {
            return deTaiRepository.getDeTaiEdit(MaDT);
        }


        public void addDetai(DeTaiDTO detai)
        {
            if (string.IsNullOrWhiteSpace(detai.TenDT))
            {
                throw new ArgumentException("Tên đề tài không được để trống.");
            }

            if (string.IsNullOrWhiteSpace(detai.MoTa))
            {
                throw new ArgumentException("Mô tả đề tài không được để trống.");
            }

            deTaiRepository.addDeTai(detai);
        }

        public void updateDataDeTai(DeTaiDTO detai)
        {
            deTaiRepository.updataDeTai(detai);
        }

        public void deteleDataDeTai(string MaDT)
        {
            deTaiRepository.deleteDeTai(MaDT);
        }

        public int getDataCountNhom(string MaDT)
        {
            return deTaiRepository.getCountNhom(MaDT);
        }

        public DataTable getDataDeTaiFind(string keyword,string MAGV)
        {
            return deTaiRepository.getDeTaiFind(keyword, MAGV);
        }

        public DataTable getDataDeTaiFindSinhVien(string keyword,string maNhom, string maNganh)
        {
            return deTaiRepository.getDataDeTaiFindSinhVien(keyword, maNhom, maNganh);
        }

        public string getDeTaiChoAI(string MANHOM, string MANGANH)
        {
            return deTaiRepository.LayDanhSachDeTaiChoAI(MANHOM, MANGANH);
        }

        public int DemDoAnDaNop(string MANK)
        {
            return deTaiRepository.DoAnDaNop(MANK);
        }
        public int DemTongDoAn(string MANK)
        {
            return deTaiRepository.TongDoAn(MANK);
        }
    }
}
