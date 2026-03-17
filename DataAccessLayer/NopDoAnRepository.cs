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
    public class NopDoAnRepository
    {
        public DataTable getDoAn(string MaNH)
        {
            DataTable doan = new DataTable();
            using(SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_DataDoAn", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MANHOM", SqlDbType.Char, 6) { Value = MaNH });

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(doan);
            }
            return doan;
        }

        public void addDoAnNop(DoAnNopDTO doAnNop)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("InSert_DoAnNop", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MANHOM", SqlDbType.Char, 6) { Value = doAnNop.MaNH });
                cmd.Parameters.Add(new SqlParameter("@MADA", SqlDbType.Char, 6) { Value = doAnNop.MaDA });
                cmd.Parameters.Add(new SqlParameter("@NGAYNOP", SqlDbType.Date) { Value = doAnNop.NgayNop });
                cmd.Parameters.Add(new SqlParameter("@PATH", SqlDbType.NText) { Value = doAnNop.Path });

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateDoAnNop(string MaNH)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update_TinhTrang", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MANHOM", SqlDbType.Char, 6) { Value = MaNH });
                
                cmd.ExecuteNonQuery();
            }
        }

        public string getMaNH(string MaNHom)
        {
            string MaNH = null;
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("kiemtra_MaNH", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MANHOM", SqlDbType.Char, 6) { Value = MaNHom });

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MaNH = reader["MANHOM"].ToString();
                }
            }
            return MaNH;
        }

        public bool KiemTraNopDA(string MaNHom, string MADA)
        {
            int count = 0;
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("kiemtraNopDA", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@MANHOM", SqlDbType.VarChar, 20) { Value = MaNHom.Trim() });
                cmd.Parameters.Add(new SqlParameter("@MADA", SqlDbType.VarChar, 20) { Value = MADA.Trim() });

                conn.Open();

                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    count = Convert.ToInt32(result);
                }
            }

            return count > 0;
        }

    }
}
