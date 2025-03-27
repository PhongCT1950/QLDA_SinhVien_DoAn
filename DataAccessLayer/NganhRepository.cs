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
    public class NganhRepository
    {
        public List<int> GetAllMaNG()
        {
            List<int> numMaNG = new List<int>();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query = "SELECT MANGANH FROM NGANH ORDER BY MANGANH";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string MaNG = reader["MANGANH"].ToString().Substring(2);
                    numMaNG.Add(int.Parse(MaNG));
                }
            }
            return numMaNG;
        }

        public DataTable getKhoa()
        {
            DataTable khoa = new DataTable();
            using(SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_khoa", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(khoa);
            }
            return khoa;
        }

        public DataTable getNganh()
        {
            DataTable nganh = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_Nganh", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill( nganh);
            }
            return nganh;
        }

        public void addNganh(NganhDTO nganh)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("InSert_Nganh", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MANGANH", SqlDbType.Char, 6) { Value = nganh.MaNG });
                cmd.Parameters.Add(new SqlParameter("@TENNGANH", SqlDbType.NVarChar, 100) { Value = nganh.TenNG });
                cmd.Parameters.Add(new SqlParameter("@MAKHOA", SqlDbType.Int) { Value = nganh.MaKhoa });

                cmd.ExecuteNonQuery();
            }
        }

        public DataTable getNganhEdit(string MaNG)
        {
            DataTable nganh = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Edit_Nganh", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MANGANH", SqlDbType.Char, 6) { Value = MaNG });

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(nganh);
            }
            return nganh;
        }

        public void updateNganh(NganhDTO nganh)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update_Nganh", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MANGANH", SqlDbType.Char, 6) { Value = nganh.MaNG });
                cmd.Parameters.Add(new SqlParameter("@TENNGANH", SqlDbType.NVarChar, 100) { Value = nganh.TenNG });
                cmd.Parameters.Add(new SqlParameter("@MAKHOA", SqlDbType.Int) { Value = nganh.MaKhoa });

                cmd.ExecuteNonQuery();
            }
        }

        public void deleteNganh(string MaNG)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Delete_nganh", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MANGANH", SqlDbType.Char, 6) { Value = MaNG });

                cmd.ExecuteNonQuery();
            }
        }

        public DataTable getNganhFind(string keyword)
        {
            DataTable nganh = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Find_Nganh", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@keyword", SqlDbType.NVarChar, 200) { Value = keyword });

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(nganh);
            }
            return nganh;
        }
    }
}
