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

        public DataTable getDataDeTai()
        {
            return deTaiRepository.getListDeTai();
        }

        public DataTable getAllDataDeTai()
        {
            return deTaiRepository.getAllDeTai();
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
    }
}
