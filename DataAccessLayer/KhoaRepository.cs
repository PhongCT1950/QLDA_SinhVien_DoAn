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
    public class KhoaRepository
    {

        public DataTable getKhoa()
        {
            DataTable khoa = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_Khoa", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(khoa);
            }
            return khoa;
        }

        public void addKhoa(string tenkhoa)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("InSert_Khoa", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TENKHOA", SqlDbType.NVarChar, 50) { Value = tenkhoa });

                cmd.ExecuteNonQuery();
            }
        }

        public void updateKhoa(KhoaDTO khoa)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update_Khoa", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MAKHOA", SqlDbType.Int) { Value = khoa.MaKhoa });
                cmd.Parameters.Add(new SqlParameter("@TENKHOA", SqlDbType.NVarChar, 50) { Value = khoa.TenKhoa });

                cmd.ExecuteNonQuery();
            }
        }

        public DataTable getKhoaEdit(string makhoa)
        {
            DataTable khoa = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Edit_Khoa", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MAKHOA", SqlDbType.Int) { Value = makhoa });

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(khoa);
            }
            return khoa;
        }

        public void deleteKhoa(string makhoa)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Delete_Khoa", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MAKHOA", SqlDbType.Int) { Value = makhoa });

                cmd.ExecuteNonQuery();
            }
        }

        public DataTable getKhoaFind(string keyword)
        {
            DataTable khoa = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Find_Khoa", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@keyword", SqlDbType.NVarChar, 200) { Value = keyword });

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(khoa);
            }
            return khoa;
        }
    }
}
