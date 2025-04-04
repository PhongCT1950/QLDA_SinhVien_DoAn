using DTO;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class NhomSinhVienRepository
    {
        public List<int> GetAllMaNH()
        {
            List<int> numMaNH = new List<int>();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query = "SELECT MANHOM FROM NHOMSV ORDER BY MANHOM";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string MaNH = reader["MANHOM"].ToString().Substring(2);
                    numMaNH.Add(int.Parse(MaNH));
                }
            }
            return numMaNH;
        }

        public void addDataNhomSV(NhomSinhVienDTO nhomsv)
        {
            using(SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Insert_NhomSV", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@MANHOM", SqlDbType.Char, 6) { Value = nhomsv.MaNhom });
                cmd.Parameters.Add(new SqlParameter("@TENNHOM", SqlDbType.NVarChar, 100) { Value = nhomsv.TenNhom });
                cmd.Parameters.Add(new SqlParameter("@SOLUONG", SqlDbType.Int) { Value = nhomsv.SoLuong });

                cmd.ExecuteNonQuery();
            }
        }

        public void updateDataNhomSV(NhomSinhVienDTO nhomsv)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update_NhomSV", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@MANHOM", SqlDbType.Char, 6) { Value = nhomsv.MaNhom });
                cmd.Parameters.Add(new SqlParameter("@TENNHOM", SqlDbType.NVarChar, 100) { Value = nhomsv.TenNhom });
                cmd.Parameters.Add(new SqlParameter("@SOLUONG", SqlDbType.Int) { Value = nhomsv.SoLuong });

                cmd.ExecuteNonQuery();
            }
        }

        public void addDataChiTietNhom(string manhom, string masv)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Insert_ChiTietNhom", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@manhom", SqlDbType.Char, 6) { Value = manhom });
                cmd.Parameters.Add(new SqlParameter("@masv", SqlDbType.Char, 6) { Value = masv });

                cmd.ExecuteNonQuery();
            }
        }

        public void updateDataChiTietNhom(string manhom, string masv)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UpdateChiTietNhom", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@MANHOM", SqlDbType.Char, 6) { Value = manhom });
                cmd.Parameters.Add(new SqlParameter("@MASV", SqlDbType.Char, 6) { Value = masv });

                cmd.ExecuteNonQuery();
            }
        }

        public DataTable getNhomSV()
        {
            DataTable NhomSV = new DataTable();
            using(SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_NhomSV", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(NhomSV);
            }
            return NhomSV;
        }

        public DataTable getdsNhomSV()
        {
            DataTable NhomSV = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_dsNhomSV", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(NhomSV);
            }
            return NhomSV;
        }

        public DataTable getttNhomSV(string MANHOM)
        {
            DataTable NhomSV = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_ttNhomSV", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("MANHOM", SqlDbType.Char, 6) { Value = MANHOM });
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(NhomSV);
            }
            return NhomSV;
        }

        public DataTable getDsThanhVien(string MANHOM)
        {
            DataTable dsThanhVien = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_dsThanhVienSV", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MANHOM", SqlDbType.Char, 6) { Value = MANHOM });
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsThanhVien);
            }
            return dsThanhVien;
        }

        public void deleteThanhVien(string manhom)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("Delete_ThanhVien", conn, transaction);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@MANHOM", SqlDbType.Char, 6) { Value = manhom });

                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"Lỗi khi lưu điểm: {ex.Message}", ex);
                    }
                }
            }
        }

        public void deleteNhomSV(string manhom)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("Delete_NhomSV", conn,transaction);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@MANHOM", SqlDbType.Char, 6) { Value = manhom });

                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"Lỗi khi xóa nhóm: {ex.Message}", ex);
                    }
                }
            }
        }

        public void deleteNhom(string manhom)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                    SqlCommand cmd = new SqlCommand("Delete_Nhom", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@MANHOM", SqlDbType.Char, 6) { Value = manhom });

                    cmd.ExecuteNonQuery();
            }
        }

        public string getMaNhom(string MaSV)
        {
            string MaNhom = null;
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_MaNhom", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@MaSV", SqlDbType.Char, 6) { Value = MaSV });
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MaNhom = reader["MANHOM"].ToString();
                }
            }
            return MaNhom;
        }

        public void updateDangKyDeTai(string MaNhom, string MaDT)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update_dkDeTai", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@MANHOM", SqlDbType.Char, 6) { Value = MaNhom });
                cmd.Parameters.Add(new SqlParameter("@MaDT", SqlDbType.Char, 6) { Value = MaDT });

                cmd.ExecuteNonQuery();
            }
        }

        public string getMaDT(string MaNhom)
        {
            string MaDT = null;
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_MaDT", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@MANHOM", SqlDbType.Char, 6) { Value = MaNhom });
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MaDT = reader["MADT"].ToString();
                }
            }
            return MaDT;
        }

        public void updateTdDeTai(string MANHOM, string MADT)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update_tdDeTai", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@MANHOM", SqlDbType.Char, 6) { Value = MANHOM });
                cmd.Parameters.Add(new SqlParameter("@MaDT", SqlDbType.Char, 6) { Value = MADT });

                cmd.ExecuteNonQuery();
            }
        }

        public string getMaNHinDoAn(string Manhom)
        {
            string MaNH = null;
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT MANHOM FROM QUYEN_DOAN WHERE MANHOM = @MANHOM", conn);

                cmd.Parameters.Add(new SqlParameter("@MANHOM", SqlDbType.Char, 6) { Value = Manhom });
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MaNH = reader["MANHOM"].ToString();
                }
            }
            return MaNH;

        }
    }
}
