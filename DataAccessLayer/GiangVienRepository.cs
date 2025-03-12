using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DataAccessLayer
{
    public class GiangVienRepository
    {
        public List<int> GetAllMaGV()
        {
            List<int> numMaGV= new List<int>();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query = "SELECT MAGV FROM GIANGVIEN ORDER BY MAGV";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string MAGV = reader["MAGV"].ToString().Substring(2);
                    numMaGV.Add(int.Parse(MAGV));
                }
            }
            return numMaGV;
        }
        public DataTable getAllGiangVien()
        {
            DataTable giangvien = new DataTable();
            using(SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("Select_GiangVien",conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(giangvien);
            }
            return giangvien;
        }

        public void addGiangVien(GiangVienDTO giangvien)
        {
            using(SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("InSert_GiangVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaGV", SqlDbType.VarChar, 6) { Value = giangvien.MaGV });
                cmd.Parameters.Add(new SqlParameter("@TenGV", SqlDbType.NVarChar, 150) { Value = giangvien.TenGV });
                cmd.Parameters.Add(new SqlParameter("@NgaySinh", SqlDbType.Date) { Value = giangvien.NgaySinh });
                cmd.Parameters.Add(new SqlParameter("@GioiTinh", SqlDbType.NVarChar, 5) { Value = giangvien.GioiTinh });
                cmd.Parameters.Add(new SqlParameter("@MaKhoa", SqlDbType.Char, 6) { Value = giangvien.MaKhoa });
                cmd.Parameters.Add(new SqlParameter("@MACD", SqlDbType.Int) { Value = giangvien.MaCD });
                cmd.Parameters.Add(new SqlParameter("@SDT", SqlDbType.Char, 12) { Value = giangvien.SDT });
                cmd.Parameters.Add(new SqlParameter("@DiaChi", SqlDbType.NText) { Value = giangvien.DiaChi });
                cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.Text) { Value = giangvien.Email });

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteGiangVien(string MaGV)
        {
            using(SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Delete_GiangVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaGV", SqlDbType.Char, 6) { Value = MaGV });

                cmd.ExecuteNonQuery();
            }
        }

        public DataTable getKhoaName()
        {
            DataTable khoa = new DataTable();
            using(SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_Khoa", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(khoa);
            }
            return khoa;
        }

        public DataTable getChucDanh()
        {
            DataTable chucdanh = new DataTable();
            using(SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_ChucDanh", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(chucdanh);
            }
            return chucdanh;
        }

        public GiangVienDTO getGiangVienEdit(string MaGV)
        {
            GiangVienDTO giangvien = new GiangVienDTO();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Edit_GiangVien", conn);
                cmd.Parameters.Add(new SqlParameter("@MaGV", SqlDbType.Char, 6) { Value = MaGV });
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    giangvien.MaGV = reader["MAGV"].ToString();
                    giangvien.TenGV = reader["TENGV"].ToString();
                    giangvien.DiaChi = reader["DiaChi"].ToString();
                    giangvien.GioiTinh = reader["GIOITINH"].ToString();
                    giangvien.SDT = reader["SDT"].ToString();
                    giangvien.Email = reader["Email"].ToString();
                    giangvien.NgaySinh = reader.GetDateTime(reader.GetOrdinal("NGAYSINH"));
                    giangvien.MaKhoa = reader["MAKHOA"].ToString();
                    giangvien.MaCD = reader["MaCD"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaCD"]);
                }
            }
            return giangvien;
        }

        public string getNameGiangvien(string MaGV)
        {
            string NameGV = null;
            using(SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_NameGV", conn);
                cmd.Parameters.Add(new SqlParameter("@MaGV", SqlDbType.Char, 6) { Value = MaGV });
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    NameGV = reader["TENGV"].ToString();
                }
            }
            return NameGV;
        }
    }
}
