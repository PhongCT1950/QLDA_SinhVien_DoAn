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
    public class ChucDanhService
    {
        ChucDanhRepository chucDanhRepository = new ChucDanhRepository();

        public DataTable getDataDsChucDanh()
        {
            return chucDanhRepository.getDsChucDanh();
        }

        public void addDataChucDanh(ChucDanhDTO chucdanh)
        {
            if (string.IsNullOrWhiteSpace(chucdanh.ChucDanh))
            {
                throw new ArgumentException("Chức danh không được để trống!");
            }

            chucDanhRepository.addChucDanh(chucdanh);
        }

        public DataTable getDataChucDanhEdit(string MaCD)
        {
            return chucDanhRepository.getChucDanhEdit(MaCD);
        }

        public void updateDataChucDanh(ChucDanhDTO chucdanh)
        {
            if (string.IsNullOrWhiteSpace(chucdanh.ChucDanh))
            {
                throw new ArgumentException("Chức danh không được để trống!");
            }

            chucDanhRepository.updateChucDanh(chucdanh);
        }

        public void deleteDataChucDanh(string MaCD)
        {
            chucDanhRepository.deleteChucDanh(MaCD);
        }

        public DataTable getDataChucDanhFind(string keyword)
        {
            return chucDanhRepository.getChucDanhFind(keyword);
        }
    }
}
