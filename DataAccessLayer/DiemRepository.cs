using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataAccessLayer
{
    public class DiemRepository
    {
        public DataTable getDsDoAn(string MaGV)
        {
            DataTable DoAn = new DataTable();
            using(SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_dsDoAn", conn);
                cmd.Parameters.Add(new SqlParameter("@MAGV", SqlDbType.Char, 6) { Value = MaGV });
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(DoAn);
            }
            return DoAn;
        }

        public DataTable getDiemDoAn(string MaGV)
        {
            DataTable DoAn = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_DiemDoAn", conn);
                cmd.Parameters.Add(new SqlParameter("@MAGV", SqlDbType.Char, 6) { Value = MaGV });

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(DoAn);
            }
            return DoAn;
        }

        public DataTable getThongtinDoAn(string MaDA)
        {
            DataTable DoAn = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_ThongtinDoAn", conn);
                cmd.Parameters.Add(new SqlParameter("@MADA", SqlDbType.Char, 6) { Value = MaDA });

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(DoAn);
            }
            return DoAn;
        }

        public string getPath(string MaDA)
        {
            string path = null;
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_Path", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MADA", SqlDbType.Char, 6) { Value = MaDA });

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    path = reader["PATH"].ToString();
                }
            }
            return path;
        }

        public void updateDiem(object MaDA, object Diem)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("Update_Diem", conn, transaction);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@MADA", SqlDbType.Char, 6) { Value = MaDA });
                        cmd.Parameters.Add(new SqlParameter("@DIEM", SqlDbType.Float) { Value = Diem });

                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"Lỗi khi sửa điểm: {ex.Message}", ex);
                    }
                }
                
            }
        }

        public void addDiemDoAn(object MaDA, object Diem, string MaGV)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("InSert_DiemDoAn", conn, transaction);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@MADA", SqlDbType.Char, 6) { Value = MaDA });
                        cmd.Parameters.Add(new SqlParameter("@DIEM", SqlDbType.Float) { Value = Diem });
                        cmd.Parameters.Add(new SqlParameter("@MAGV", SqlDbType.Char, 6) { Value = MaGV });

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

        public string getMaDA(string MaNH)
        {
            string MaDA = null;
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_MaDA", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MANHOM", SqlDbType.Char, 6) { Value = MaNH });

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MaDA = reader["MADA"].ToString();
                }
            }
            return MaDA;
        }

        public DataTable getDiem(string MaDA)
        {
            DataTable diem = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_Diem", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MADA", SqlDbType.VarChar, 20) { Value = MaDA });

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(diem);
            }
            return diem;
        }

        public string getMaDADiem(string MaDA)
        {
            string mada = null;
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_MaDADiem", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MADA", SqlDbType.Char, 6) { Value = MaDA });

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mada = reader["MADA"].ToString();
                }
            }
            return mada;
        }

        public DataTable getDiemFind(string keyword,string MaGV)
        {
            DataTable diem = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Find_Diem", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@keyword", SqlDbType.NVarChar, 200) { Value = keyword });
                cmd.Parameters.Add(new SqlParameter("@MAGV", SqlDbType.VarChar, 6) { Value = MaGV });

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(diem);
            }
            return diem;
        }

        public DataTable getDiemDoAnFind(string keyword, string MaGV)
        {
            DataTable diem = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Find_DiemDoAn", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@keyword", SqlDbType.NVarChar, 200) { Value = keyword });
                cmd.Parameters.Add(new SqlParameter("@MAGV", SqlDbType.VarChar, 6) { Value = MaGV });

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(diem);
            }
            return diem;
        }

        public bool isKiemTraDiem(string MaDA)
        {
            string query = "SELECT COUNT(*) FROM DIEM WHERE MADA = @maDA";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maDA", MaDA);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
    }
}
