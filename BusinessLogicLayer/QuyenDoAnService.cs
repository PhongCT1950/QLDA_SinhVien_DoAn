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
    public class QuyenDoAnService
    {
        QuyenDoAnRepository quyenDoAnRepository = new QuyenDoAnRepository();
        public string GenerateMaDA()
        {
            List<int> numMaNH = quyenDoAnRepository.GetAllMaDA();
            int n = 1;
            while (numMaNH.Contains(n))
            {
                n++;
            }
            return $"DA{n:D3}";
        }

        public void addDataQuyenDoAn(QuyenDoAnDTO quyenDoAn)
        {
            if (string.IsNullOrWhiteSpace(quyenDoAn.TenDA))
            {
                throw new ArgumentException("Tên đồ án không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(quyenDoAn.MaNH))
            {
                throw new ArgumentException("Chưa chọn nhóm cho đồ án.");
            }

            quyenDoAnRepository.addQuyenDoAn(quyenDoAn);
        }

        public DataTable getDataListQuyenDoAn(string MAGV)
        {
            return quyenDoAnRepository.getListQuyenDoAn(MAGV);
        }

        public DataTable getDataEditQuyenDoAn(string MaDA)
        {
            return quyenDoAnRepository.getEditQuyenDoAn(MaDA);
        }

        public void updateDataQuyenDoAn(QuyenDoAnDTO quyenDoAn)
        {
            quyenDoAnRepository.update_QuyenDoAn(quyenDoAn);
        }

        public void deleteDataQuyenDoAn(string MaDA)
        {
            quyenDoAnRepository.deleteQuyenDoAn(MaDA);
        }

        public DataTable getDataQuyenDoAnFind(string keyword)
        {
            return quyenDoAnRepository.getQuyenDoAnFind(keyword);
        }

        public DataTable getLoaiDACuaNhom(string MANHOM)
        {
            return quyenDoAnRepository.getLoaiDANhom(MANHOM);
        }
    }
}
