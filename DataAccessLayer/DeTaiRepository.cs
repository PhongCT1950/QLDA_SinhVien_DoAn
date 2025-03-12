using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DeTaiRepository
    {
        public DataTable getLoaiDA()
        {
            DataTable LoaiDA = new DataTable();
            using(SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_LoaiDA", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(LoaiDA);
            }
            return LoaiDA;
        }

        public DataTable getListDeTai()
        {
            DataTable Detai = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_DeTaiforGV", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaGV", SqlDbType.Char, 6) { Value = UserSession.Username });

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(Detai);
            }
            return Detai;
        }

        public DataTable getAllDeTai()
        {
            DataTable Detai = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_DeTai", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(Detai);
            }
            return Detai;
        }

        public void addDeTai(DeTaiDTO detai)
        {
            using(SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("InSert_DeTai", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TenDT", SqlDbType.NVarChar, 200) { Value = detai.TenDT });
                cmd.Parameters.Add(new SqlParameter("@LOAIDA", SqlDbType.NVarChar, 100) { Value = detai.LoaiDA });
                cmd.Parameters.Add(new SqlParameter("@MOTA", SqlDbType.NVarChar, 200) { Value = detai.MoTa });
                cmd.Parameters.Add(new SqlParameter("@MAGV", SqlDbType.Char, 6) { Value = detai.MaGV });

                cmd.ExecuteNonQuery();
            }
        }

        public DeTaiDTO getDeTaiEdit(string MaDT)
        {
            DeTaiDTO detai = new DeTaiDTO();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Edit_DeTai", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaDT", SqlDbType.Char, 6) { Value = MaDT });

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    detai.MaDT   = reader["MADT"].ToString();
                    detai.TenDT  = reader["TENDT"].ToString();
                    detai.LoaiDA = reader["LOAIDA"].ToString();
                    detai.MoTa   = reader["MOTA"].ToString();
                }
            }
            return detai;
        }

        public void updataDeTai(DeTaiDTO detai)
        {
            using(SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update_DeTai", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaDT", SqlDbType.Char, 6) { Value = detai.MaDT });
                cmd.Parameters.Add(new SqlParameter("@TENDT", SqlDbType.NVarChar, 200) { Value = detai.TenDT });
                cmd.Parameters.Add(new SqlParameter("@LOAIDA", SqlDbType.NVarChar, 100) { Value = detai.LoaiDA });
                cmd.Parameters.Add(new SqlParameter("@MOTA", SqlDbType.NVarChar, 200) { Value = detai.MoTa });

                cmd.ExecuteNonQuery();
            }
        }

        public void deleteDeTai(string MaDT)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Delete_DeTai", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaDT", SqlDbType.Char, 6) { Value = MaDT });

                cmd.ExecuteNonQuery();
            }
        }
    }
}
