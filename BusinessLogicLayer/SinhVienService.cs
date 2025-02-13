using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class SinhVienService
    {
        private SinhVienRepository sinhVienRepository = new SinhVienRepository();

        public List<SinhVienDTO> getSinhVien()
        {
            return sinhVienRepository.getAllSinhVien();
        }
    }
}
