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
    public class NganhService
    {
        NganhRepository nganhRepository = new NganhRepository();
        public string GenerateMaNG()
        {
            List<int> numMaNG = nganhRepository.GetAllMaNG();
            int n = 1;
            while (numMaNG.Contains(n))
            {
                n++;
            }
            return $"MN{n:D3}";
        }

        public DataTable getDataKhoa()
        {
            return nganhRepository.getKhoa();
        }

        public DataTable getDataNganh()
        {
            return nganhRepository.getNganh();
        }

        public void addDataNganh(NganhDTO nganh)
        {
            if (string.IsNullOrWhiteSpace(nganh.TenNG))
            {
                throw new ArgumentException("Tên ngành không thể để trống!");
            }
            nganhRepository.addNganh(nganh);
        }

        public DataTable getDataNganhEdit(string MaNG)
        {
            return nganhRepository.getNganhEdit(MaNG);
        }

        public void updateDataNganh(NganhDTO nganh)
        {
            if (string.IsNullOrWhiteSpace(nganh.TenNG))
            {
                throw new ArgumentException("Tên ngành không thể để trống!");
            }
            nganhRepository.updateNganh(nganh);
        }

        public void deleteDataNganh(string MaNG)
        {
            nganhRepository.deleteNganh(MaNG);
        }

        public DataTable getDataNganhFind(string keyword)
        {
            return nganhRepository.getNganhFind(keyword);
        }

        public string getDataMaNganh(string MASV)
        {
            return nganhRepository.getMaNganh(MASV);
        }
    }
}
