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
    public class TaiKhoanRepository
    {
        private DatabaseHelper databaseHelper = new DatabaseHelper();
        public string checkRole(string username, string password)
        {
            string role = "";
            try
            {
                using(SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    SqlParameter[] parameters = {
                        new SqlParameter("@username",username),
                        new SqlParameter("@password",password)
                    };
                    object result = databaseHelper.ExecuteScalar("Select_Role",parameters);
                    if(result != null) { role = result.ToString(); }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Lỗi cơ sở dữ liệu: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi không xác định: " + ex.Message);
            }
            return role;
        }

        public TaiKhoanDTO GetTaiKhoanDTO(string username, string password)
        {
            TaiKhoanDTO taiKhoanDTO = null;
            using(SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand("Select_TaiKhoan", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@username", SqlDbType.VarChar, 50) { Value = username });
                    cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 50) { Value = password });
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()){
                        taiKhoanDTO = new TaiKhoanDTO
                        {
                            UserID = reader.GetInt32(0),
                            Username = reader.GetString(1),
                            Role = reader.GetString(2),
                            Refld = reader.IsDBNull(3) ? null : reader.GetString(3)
                        };
                    }
                }
                
            }
            return taiKhoanDTO;
        }

        public DataTable getTaiKhoan()
        {
            DataTable taikhoan = new DataTable();
            using(SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_dsTaiKhoan", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(taikhoan);
            }
            return taikhoan;
        }

        public DataTable getdsRole()
        {
            DataTable role = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_dsRole", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(role);
            }
            return role;
        }

        public DataTable getTaiKhoanEdit(string id)
        {
            DataTable taikhoan = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Edit_TaiKhoan", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@USERID", SqlDbType.VarChar, 50) { Value = id });

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(taikhoan);
            }
            return taikhoan;
        }

        public void updateTaiKhoan(TaiKhoanDTO taikhoan)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update_TaiKhoan", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@USERID", SqlDbType.Int) { Value = taikhoan.UserID });
                cmd.Parameters.Add(new SqlParameter("@USERNAME", SqlDbType.VarChar, 50) { Value = taikhoan.Username });
                cmd.Parameters.Add(new SqlParameter("@PASSWORD", SqlDbType.VarChar, 50) { Value = taikhoan.PassWord });
                cmd.Parameters.Add(new SqlParameter("@ROLE", SqlDbType.VarChar, 50) { Value = taikhoan.Role });

                cmd.ExecuteNonQuery();
            }
        }

        public void deleteTaiKhoan(string id)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Delete_TaiKhoan", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@USERID", SqlDbType.Int) { Value = id });

                cmd.ExecuteNonQuery();
            }
        }

        public DataTable getTaiKhoanFind(string keyword)
        {
            DataTable taikhoan = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Find_TaiKhoan", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@keyword", SqlDbType.NVarChar, 200) { Value = keyword });

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(taikhoan);
            }
            return taikhoan;
        }
    }
}
