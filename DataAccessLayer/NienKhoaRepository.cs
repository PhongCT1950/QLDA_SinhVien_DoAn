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
    public class NienKhoaRepository
    {
        public List<int> GetAllMaNk()
        {
            List<int> numMaNk = new List<int>();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query = "SELECT MANK FROM NIENKHOA ORDER BY MANK";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string MaNG = reader["MANK"].ToString().Substring(2);
                    numMaNk.Add(int.Parse(MaNG));
                }
            }
            return numMaNk;
        }

        public DataTable getDsNienKhoa()
        {
            DataTable nienkhoa = new DataTable();
            using(SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_dsNienKhoa",conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(nienkhoa);
            }
            return nienkhoa;
        }

        public void addNienKhoa(NienKhoaDTO nienkhoa)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("InSert_NienKhoa", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MANK", SqlDbType.Char, 6) { Value = nienkhoa.MaNK });
                cmd.Parameters.Add(new SqlParameter("@TENNK", SqlDbType.NVarChar, 50) { Value = nienkhoa.TenNK });
                cmd.Parameters.Add(new SqlParameter("@NIENKHOA", SqlDbType.NVarChar, 50) { Value = nienkhoa.NienKhoa });

                cmd.ExecuteNonQuery();
            }
        }

        public DataTable getNganhEdit(string MaNG)
        {
            DataTable nganh = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Edit_NienKhoa", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MANK", SqlDbType.Char, 6) { Value = MaNG });

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(nganh);
            }
            return nganh;
        }

        public void updateNganh(NienKhoaDTO nganh)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update_NienKhoa", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MANK", SqlDbType.Char, 6) { Value = nganh.MaNK });
                cmd.Parameters.Add(new SqlParameter("@TENNK", SqlDbType.NVarChar, 50) { Value = nganh.TenNK });
                cmd.Parameters.Add(new SqlParameter("@NIENKHOA", SqlDbType.NVarChar,50) { Value = nganh.NienKhoa });

                cmd.ExecuteNonQuery();
            }
        }

        public void deleteNganh(string MaNG)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Delete_NienKhoa", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MANK", SqlDbType.Char, 6) { Value = MaNG });

                cmd.ExecuteNonQuery();
            }
        }

        public DataTable getNganhFind(string keyword)
        {
            DataTable nganh = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Find_NienKhoa", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@keyword", SqlDbType.NVarChar, 200) { Value = keyword });

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(nganh);
            }
            return nganh;
        }
    }
}
