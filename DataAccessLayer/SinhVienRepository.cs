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
    public class SinhVienRepository
    {
        //public List<SinhVienDTO> getAllSinhVien()
        //{
        //    List<SinhVienDTO> sinhvienList = new List<SinhVienDTO>();
        //    using(SqlConnection conn = DatabaseHelper.GetConnection())
        //    {
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand("Select_SinhVien", conn);
        //        SqlDataReader reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            sinhvienList.Add(new SinhVienDTO
        //            {
        //                MaSV = reader["MASV"].ToString(),
        //                TenSV = reader["TENSV"].ToString(),
        //                NgaySinh = reader.GetDateTime(reader.GetOrdinal("NGAYSINH")),
        //                GioiTinh = reader["GIOITINH"].ToString(),
        //                MaHeDT = reader["TenHeDT"].ToString(),
        //                MaNganh = reader["TENNGANH"].ToString(),
        //                MaKhoa = reader["TENKHOA"].ToString(),
        //                MaNK = reader["NIENKHOA"].ToString(),
        //                SDT = reader["SDT"].ToString(),
        //                DiaChi = reader["DiaChi"].ToString(),
        //                Email = reader["Email"].ToString(),
        //            });
        //        }
        //        reader.Close();
        //    }
        //    return sinhvienList;
        //}

        public DataTable getAllSinhViens()
        {
            DataTable sinhvien = new DataTable();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_SinhVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(sinhvien);
            }

            return sinhvien;
        }

        public DataTable getAllSinhVien(string MANGANH)
        {
            DataTable sinhvien = new DataTable();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_SinhVienWhere", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MANGANH", SqlDbType.Char, 6) { Value = MANGANH });
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(sinhvien);
            }

            return sinhvien;
        }

        public DataTable getAllNganh()
        {
            DataTable nganh = new DataTable();
            using(SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_Nganh", conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(nganh);
            }
            return nganh;
        }

        public DataTable getNganhSinhVien(string MASV)
        {
            DataTable nganh = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SelectMaNganh", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MASV", SqlDbType.VarChar, 20) { Value = MASV });
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(nganh);
            }
            return nganh;
        }


        public DataTable getAllNganhGiangVien(string MAGV)
        {
            DataTable nganh = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SelectNganhGiangVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MAGV", SqlDbType.Char, 6) { Value = MAGV });

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(nganh);
            }
            return nganh;
        }
        public DataTable getAllDonVi()
        {
            DataTable donvi = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_DonVi", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(donvi);
            }
            return donvi;
        }

        public void AddSinhVien(SinhVienDTO sinhvien)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("InSert_SinhVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaSV", SqlDbType.VarChar, 6) { Value = sinhvien.MaSV });
                cmd.Parameters.Add(new SqlParameter("@TenSV", SqlDbType.NVarChar, 150) { Value = sinhvien.TenSV });
                cmd.Parameters.Add(new SqlParameter("@NgaySinh", SqlDbType.Date) { Value = sinhvien.NgaySinh });
                cmd.Parameters.Add(new SqlParameter("@GioiTinh", SqlDbType.NVarChar, 5) { Value = sinhvien.GioiTinh });
                cmd.Parameters.Add(new SqlParameter("@MaNganh", SqlDbType.Char, 6) { Value = sinhvien.MaNganh });
                cmd.Parameters.Add(new SqlParameter("@MaKhoa", SqlDbType.Char, 6) { Value = sinhvien.MaKhoa });
                cmd.Parameters.Add(new SqlParameter("@MaNK", SqlDbType.Char, 6) { Value = sinhvien.MaNK });
                cmd.Parameters.Add(new SqlParameter("@SDT", SqlDbType.Char, 12) { Value = sinhvien.SDT });
                cmd.Parameters.Add(new SqlParameter("@DiaChi", SqlDbType.NVarChar, 150) { Value = sinhvien.DiaChi });
                cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 150) { Value = sinhvien.Email });

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteSinhVien(string MaSV)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Delete_SinhVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaSV", SqlDbType.Char, 6) { Value = MaSV });

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateSinhVien(SinhVienDTO sinhvien)
        {
            using(SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update_SinhVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("MaSV", SqlDbType.Char, 6) { Value = sinhvien.MaSV });
                cmd.Parameters.Add(new SqlParameter("@TenSV", SqlDbType.NVarChar, 150) { Value = sinhvien.TenSV });
                cmd.Parameters.Add(new SqlParameter("@NgaySinh", SqlDbType.Date) { Value = sinhvien.NgaySinh });
                cmd.Parameters.Add(new SqlParameter("@GioiTinh", SqlDbType.NVarChar, 5) { Value = sinhvien.GioiTinh });
                cmd.Parameters.Add(new SqlParameter("@MaNganh", SqlDbType.Char, 6) { Value = sinhvien.MaNganh });
                cmd.Parameters.Add(new SqlParameter("@TENKHOA", SqlDbType.NVarChar, 50) { Value = sinhvien.MaKhoa });
                cmd.Parameters.Add(new SqlParameter("@MaNK", SqlDbType.Char, 6) { Value = sinhvien.MaNK });
                cmd.Parameters.Add(new SqlParameter("@SDT", SqlDbType.Char, 12) { Value = sinhvien.SDT });
                cmd.Parameters.Add(new SqlParameter("@DiaChi", SqlDbType.NText) { Value = sinhvien.DiaChi });
                cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.Text) { Value = sinhvien.Email });

                cmd.ExecuteNonQuery();
            }
        }

        public DataTable getSinhVienFind(string keyword)
        {
            DataTable sinhvien = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Find_SinhVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@keyword", SqlDbType.NVarChar, 200) { Value = keyword });

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(sinhvien);
            }
            return sinhvien;
        }

        public SinhVienDTO getSinhVienEdit(string MaSV)
        {
            SinhVienDTO sinhvien = new SinhVienDTO();
            using(SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Edit_SinhVien", conn);
                cmd.Parameters.Add(new SqlParameter("@MaSV", SqlDbType.Char, 6) { Value = MaSV });
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    sinhvien.MaSV = reader["MASV"].ToString();
                    sinhvien.TenSV = reader["TENSV"].ToString();
                    sinhvien.DiaChi = reader["DiaChi"].ToString();
                    sinhvien.GioiTinh = reader["GIOITINH"].ToString();
                    sinhvien.SDT = reader["SDT"].ToString();
                    sinhvien.Email = reader["Email"].ToString();
                    sinhvien.NgaySinh = reader.GetDateTime(reader.GetOrdinal("NGAYSINH"));
                    sinhvien.MaNganh = reader["MANGANH"].ToString();
                    sinhvien.MaKhoa = reader["TENKHOA"].ToString();
                    sinhvien.MaNK = reader["MANK"].ToString();
                }
            }
            return sinhvien;
        }

        public DataTable getAllHeDT()
        {
            DataTable HeDT = new DataTable();
            using(SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_HeDT", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(HeDT);
            }
            return HeDT;
        }

        public DataTable getAllNienKhoa()
        {
            DataTable NienKhoa = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_NienKhoa", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(NienKhoa);
            }
            return NienKhoa;
        }

        public List<int> GetAllMaSV()
        {
            List<int> numMaSV = new List<int>();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query = "SELECT MASV FROM SINHVIEN ORDER BY MASV";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string MaSV = reader["MASV"].ToString().Substring(2);
                    numMaSV.Add(int.Parse(MaSV));
                }
            }
            return numMaSV;
        }

        public string getNameSinhVien(string MaSV)
        {
            string NameSV = null;
            using(SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SelectName_SinhVien", conn);
                cmd.Parameters.Add(new SqlParameter("@MaSV", SqlDbType.Char, 6) { Value = MaSV });
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    NameSV = reader["TENSV"].ToString();
                }
            }
            return NameSV;
        }

        public DataTable getTTCaNhan(string MaSV)
        {
            DataTable sinhvien = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_ttCaNhan", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaSV", SqlDbType.Char, 6) { Value = MaSV });

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(sinhvien);
            }
            return sinhvien;
        }
    }
}
