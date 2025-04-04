using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class DiemService
    {
        DiemRepository diemRepository = new DiemRepository();
        public DataTable getDataDsDoAn(string MaGV)
        {
            return diemRepository.getDsDoAn(MaGV);
        }

        public DataTable getDataDiemDoAn(string MaGV)
        {
            return diemRepository.getDiemDoAn(MaGV);
        }

        public DataTable getDataThongtinDoAn(string MaDA)
        {
            return diemRepository.getThongtinDoAn(MaDA);
        }

        public void updateDataDiem(object MaDA, object Diem)
        {
            diemRepository.updateDiem(MaDA, Diem);
        }

        public string getDataPath(string MaDA)
        {
            return diemRepository.getPath(MaDA);
        }

        public void addDataDiemDoAn(object MaDA, object Diem, string MaGV)
        {
            diemRepository.addDiemDoAn(MaDA, Diem, MaGV);
        }

        public string getDataMaDA(string MaNH)
        {
            return diemRepository.getMaDA(MaNH);
        }

        public DataTable getDataDiem(string MaDA)
        {
            return diemRepository.getDiem(MaDA);
        }

        public string getDataMaDADiem(string MaDA)
        {
            return diemRepository.getMaDADiem(MaDA);
        }

        public DataTable getDataDiemFind(string keyword,string MaGV)
        {
            return diemRepository.getDiemFind(keyword, MaGV);
        }

        public DataTable getDataDiemDoAnFind(string keyword, string MaGV)
        {
            return diemRepository.getDiemDoAnFind(keyword, MaGV);
        }

        public bool isDiemExists(string maDA)
        {
            return diemRepository.isKiemTraDiem(maDA);
        }
    }
}
