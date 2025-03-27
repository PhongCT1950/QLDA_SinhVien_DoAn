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

        public DataTable getAllDataDeTai(string MaNH)
        {
            return deTaiRepository.getAllDeTai(MaNH);
        }

        public DataTable getDataDeTai()
        {
            return deTaiRepository.getDeTai();
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

        public DataTable getDataDeTaiFind(string keyword)
        {
            return deTaiRepository.getDeTaiFind(keyword);
        }
    }
}
