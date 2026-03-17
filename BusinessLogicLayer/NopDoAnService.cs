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
    public class NopDoAnService
    {
        NopDoAnRepository nopDoAnRepository = new NopDoAnRepository();
        public DataTable getDataDoAn(string MaNH)
        {
            return nopDoAnRepository.getDoAn(MaNH);
        }

        public void addDataDoAnNop(DoAnNopDTO doAnNop)
        {
            nopDoAnRepository.addDoAnNop(doAnNop);
        }

        public string getDataMaNH(string MaNH)
        {
            return nopDoAnRepository.getMaNH(MaNH);
        }

        public bool getDataKiemTraNopDA(string MaNH,string MADA)
        {
            return nopDoAnRepository.KiemTraNopDA(MaNH, MADA);
        }

        public void UpdateDataDoAnNop(string MaNH)
        {
            nopDoAnRepository.UpdateDoAnNop(MaNH);
        }
    }
}
