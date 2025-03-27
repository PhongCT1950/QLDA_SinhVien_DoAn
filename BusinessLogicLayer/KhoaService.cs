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
    public class KhoaService
    {
        KhoaRepository khoaRepository = new KhoaRepository();

        public DataTable getDataKhoa()
        {
            return khoaRepository.getKhoa();
        }

        public void addDataKhoa(string tenkhoa)
        {
            if (string.IsNullOrWhiteSpace(tenkhoa))
            {
                throw new ArgumentException("Tên khoa không được để trống!");
            }

            khoaRepository.addKhoa(tenkhoa);
        }

        public void updateDataKhoa(KhoaDTO khoa)
        {
            if (string.IsNullOrWhiteSpace(khoa.TenKhoa))
            {
                throw new ArgumentException("Tên khoa không được để trống!");
            }

            khoaRepository.updateKhoa(khoa);
        }

        public DataTable getDataKhoaEdit(string makhoa)
        {
            return khoaRepository.getKhoaEdit(makhoa);
        }

        public void deleteDataKhoa(string makhoa)
        {
            khoaRepository.deleteKhoa(makhoa);
        }

        public DataTable getDataKhoaFind(string keyword)
        {
            return khoaRepository.getKhoaFind(keyword);
        }
    }
}
