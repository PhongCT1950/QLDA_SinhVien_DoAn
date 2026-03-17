using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DataAccessLayer
{
    public class QuyenDoAnRepository
    {
        public List<int> GetAllMaDA()
        {
            List<int> numMaDA = new List<int>();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query = "SELECT MADA FROM QUYEN_DOAN ORDER BY MADA";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string MaDA = reader["MADA"].ToString().Substring(2);
                    numMaDA.Add(int.Parse(MaDA));
                }
            }
            return numMaDA;
        }

        public void addQuyenDoAn(QuyenDoAnDTO quyenDoAn)
        {
            using(SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("InSert_QuyenDoAn", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MADA", SqlDbType.Char, 6) { Value = quyenDoAn.MaDA });
                cmd.Parameters.Add(new SqlParameter("@TENDA", SqlDbType.NVarChar, 100) { Value = quyenDoAn.TenDA });
                cmd.Parameters.Add(new SqlParameter("@SOTC", SqlDbType.Int) { Value = quyenDoAn.SoTC });
                cmd.Parameters.Add(new SqlParameter("@LOAIDA", SqlDbType.NVarChar, 50) { Value = quyenDoAn.LoaiDA });
                cmd.Parameters.Add(new SqlParameter("@MANHOM", SqlDbType.Char, 6) { Value = quyenDoAn.MaNH });

                cmd.ExecuteNonQuery();
            }
        }

        public DataTable getListQuyenDoAn(string MAGV)
        {
            DataTable dsQuyenDoAn = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_ListQuyenDoAn", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@MAGV", SqlDbType.Char, 6) { Value = MAGV });

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsQuyenDoAn);
                cmd.ExecuteNonQuery();
            }
            return dsQuyenDoAn;
        }

        public DataTable getLoaiDANhom(string MANHOM)
        {
            DataTable dsQuyenDoAn = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SelectLoaiDASinhVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@MANHOM", SqlDbType.VarChar, 20) { Value = MANHOM });

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsQuyenDoAn);
                cmd.ExecuteNonQuery();
            }
            return dsQuyenDoAn;
        }

        public DataTable getEditQuyenDoAn(string MaDA)
        {
            DataTable dsQuyenDoAn = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Edit_QuyenDoAn", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MADA", SqlDbType.Char, 6) { Value = MaDA });

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsQuyenDoAn);
                cmd.ExecuteNonQuery();
            }
            return dsQuyenDoAn;
        }

        public void update_QuyenDoAn(QuyenDoAnDTO quyenDoAn)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update_QuyenDoAn", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MADA", SqlDbType.Char, 6) { Value = quyenDoAn.MaDA });
                cmd.Parameters.Add(new SqlParameter("@TENDA", SqlDbType.NVarChar, 100) { Value = quyenDoAn.TenDA });
                cmd.Parameters.Add(new SqlParameter("@SOTC", SqlDbType.Int) { Value = quyenDoAn.SoTC });
                cmd.Parameters.Add(new SqlParameter("@LOAIDA", SqlDbType.NVarChar, 50) { Value = quyenDoAn.LoaiDA });
                cmd.Parameters.Add(new SqlParameter("@MANHOM", SqlDbType.Char, 6) { Value = quyenDoAn.MaNH });

                cmd.ExecuteNonQuery();
            }
        }

        public void deleteQuyenDoAn(string MaDA)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Delete_QuyenDoAn", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MADA", SqlDbType.Char, 6) { Value = MaDA });

                cmd.ExecuteNonQuery();
            }
        }

        public DataTable getQuyenDoAnFind(string keyword)
        {
            DataTable quyen = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Find_QuyenDoAn", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@keyword", SqlDbType.NVarChar, 200) { Value = keyword });

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(quyen);
            }
            return quyen;
        }
    }
}
