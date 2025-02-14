using System;
using System.Collections.Generic;
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
    }
}
