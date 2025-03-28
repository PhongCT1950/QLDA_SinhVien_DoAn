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
    public  class NienKhoaService
    {
        NienKhoaRepository nienKhoaRepository = new NienKhoaRepository();

        public string GenerateMaNG()
        {
            List<int> numMaNK = nienKhoaRepository.GetAllMaNk();
            int n = 1;
            while (numMaNK.Contains(n))
            {
                n++;
            }
            return $"NK{n:D3}";
        }
        public DataTable getDataDsNienKhoa()
        {
            return nienKhoaRepository.getDsNienKhoa();
        }

        public void addDataNienKhoa(NienKhoaDTO nienkhoa)
        {
            if (string.IsNullOrWhiteSpace(nienkhoa.TenNK))
            {
                throw new ArgumentException("Tên niên khóa không thể để trống!");
            }
            if (string.IsNullOrWhiteSpace(nienkhoa.NienKhoa))
            {
                throw new ArgumentException("niên khóa không thể để trống!");
            }
            nienKhoaRepository.addNienKhoa(nienkhoa);
        }

        public DataTable getDataNganhEdit(string MaNG)
        {
            return nienKhoaRepository.getNganhEdit(MaNG);
        }

        public void deleteDataNganh(string MaNG)
        {
            nienKhoaRepository.deleteNganh(MaNG);
        }

        public void updateDataNienKhoa(NienKhoaDTO nienkhoa)
        {
            if (string.IsNullOrWhiteSpace(nienkhoa.TenNK))
            {
                throw new ArgumentException("Tên niên khóa không thể để trống!");
            }
            if (string.IsNullOrWhiteSpace(nienkhoa.NienKhoa))
            {
                throw new ArgumentException("niên khóa không thể để trống!");
            }
            nienKhoaRepository.updateNganh(nienkhoa);
        }

        public DataTable getDataNganhFind(string keyword)
        {
            return nienKhoaRepository.getNganhFind(keyword);
        }
    }
}
