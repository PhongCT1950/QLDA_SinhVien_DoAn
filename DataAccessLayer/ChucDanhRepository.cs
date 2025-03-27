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
    public class ChucDanhRepository
    {
        public DataTable getDsChucDanh()
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

        public void addChucDanh(ChucDanhDTO chucdanh)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("InSert_ChucDanh", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CHUCDANH", SqlDbType.NVarChar,100) { Value = chucdanh.ChucDanh });
                cmd.Parameters.Add(new SqlParameter("@HESOCD", SqlDbType.Float) { Value = chucdanh.hesoCD });

                cmd.ExecuteNonQuery();
            }
        }

        public void updateChucDanh(ChucDanhDTO chucdanh)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update_ChucDanh", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MACD", SqlDbType.Int) { Value = chucdanh.MaCD });
                cmd.Parameters.Add(new SqlParameter("@CHUCDANH", SqlDbType.NVarChar, 100) { Value = chucdanh.ChucDanh });
                cmd.Parameters.Add(new SqlParameter("@HESOCD", SqlDbType.Float) { Value = chucdanh.hesoCD });

                cmd.ExecuteNonQuery();
            }
        }

        public DataTable getChucDanhEdit(string MaCD)
        {
            DataTable chucdanh = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Edit_ChucDanh", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MACD", SqlDbType.Int) { Value = MaCD });

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(chucdanh);
            }
            return chucdanh;
        }

        public void deleteChucDanh(string MaCD)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Delete_ChucDanh", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MACD", SqlDbType.Int) { Value = MaCD });

                cmd.ExecuteNonQuery();
            }
        }

        public DataTable getChucDanhFind(string keyword)
        {
            DataTable chucdanh = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Find_ChucDanh", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@keyword", SqlDbType.NVarChar, 200) { Value = keyword });

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(chucdanh);
            }
            return chucdanh;
        }
    }
}
