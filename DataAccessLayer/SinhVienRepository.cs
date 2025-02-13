using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DataAccessLayer
{
    public class SinhVienRepository
    {
        public List<SinhVienDTO> getAllSinhVien()
        {
            List<SinhVienDTO> sinhvien = new List<SinhVienDTO>();
            using(SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_SinhVien", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    sinhvien.Add(new SinhVienDTO
                    {
                        MaSV = reader.GetString(0),
                        TenSV = reader.GetString(1),
                        NgaySinh = reader.GetDateTime(2)
                    });
                }
                reader.Close();
            }
            return sinhvien;
        }
    }
}
