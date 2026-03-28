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

        public DataTable getAllDeTai(string MaNH, string MaNganh, string MaGV)
        {
            DataTable Detai = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_DeTai", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MANHOM", SqlDbType.VarChar, 20)
                { Value = (object)MaNH ?? DBNull.Value });

                cmd.Parameters.Add(new SqlParameter("@MANGANH", SqlDbType.VarChar, 20)
                { Value = (object)MaNganh ?? DBNull.Value });

                cmd.Parameters.Add(new SqlParameter("@MaGV", SqlDbType.VarChar, 20)
                { Value = (object)MaGV ?? DBNull.Value });

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(Detai);
            }
            return Detai;
        }

        public DataTable getDeTai()
        {
            DataTable Detai = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_AllDeTai", conn);
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

        public int getCountNhom(string MaDT)
        {
            int count = 0;
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_CountNhom", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaDT", SqlDbType.Char, 6) { Value = MaDT });

                count = (int)cmd.ExecuteScalar();
            }
            return count;
        }
        public int DoAnDaNop(string MANK)
        {
            int count = 0;
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SelectCountDoAnNop", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MANK", SqlDbType.VarChar, 20) { Value = MANK });

                count = (int)cmd.ExecuteScalar();
            }
            return count;
        }
        public int TongDoAn(string MANK)
        {
            int count = 0;
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SelectCountTongDoAn", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MANK", SqlDbType.VarChar, 20) { Value = MANK });
                count = (int)cmd.ExecuteScalar();
            }
            return count;
        }
        public DataTable getDeTaiFind(string keyword, string maGV)
        {
            DataTable detai = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Find_DeTai", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@keyword", SqlDbType.NVarChar, 200) { Value = keyword });

                cmd.Parameters.Add(new SqlParameter("@MAGV", SqlDbType.VarChar, 20) { Value = (object)maGV ?? DBNull.Value });

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(detai);
            }
            return detai;
        }

        public DataTable getDataDeTaiFindSinhVien(string keyword, string maNhom, string maNganh)
        {
            DataTable detai = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Find_DeTai_SinhVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@keyword", SqlDbType.NVarChar, 200) { Value = keyword });

                cmd.Parameters.Add(new SqlParameter("@MANHOM", SqlDbType.VarChar, 20) { Value = (object)maNhom ?? DBNull.Value });
                cmd.Parameters.Add(new SqlParameter("@MANGANH", SqlDbType.VarChar, 20) { Value = (object)maNganh ?? DBNull.Value });

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(detai);
            }
            return detai;
        }

        public string LayDanhSachDeTaiChoAI(string MANHOM, string MANGANH)
        {
            StringBuilder sb = new StringBuilder();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SelectDsDeTaiChoAI", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@MANHOM", SqlDbType.VarChar, 20) { Value = (object)MANHOM ?? DBNull.Value });
                cmd.Parameters.Add(new SqlParameter("@MANGANH", SqlDbType.VarChar, 20) { Value = (object)MANGANH ?? DBNull.Value });
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string maDT = reader["MADT"].ToString();
                        string tenDT = reader["TenDT"].ToString();
                        string loaiDA = reader["LoaiDA"].ToString();
                        string tenNganh = reader["TenNganh"].ToString();
                        string moTa = reader["MoTa"].ToString();
                        string tenGV = reader["TenGV"].ToString();

                        sb.AppendLine($"- Mã Đề Tài: {maDT}");
                        sb.AppendLine($"- Tên Đề Tài: {tenDT}");
                        sb.AppendLine($"- Giảng viên: {tenGV}");
                        sb.AppendLine($"- Mô tả: {moTa}");
                        sb.AppendLine("-------------------");
                    }
                }
            }

            if (sb.Length == 0)
            {
                return "Hiện tại hệ thống không có đề tài nào phù hợp với ngành của bạn.";
            }

            return sb.ToString();
        }

        public DataTable GetThongKeDeTaiTheoNganh(string MANK)
        {
            DataTable Detai = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select_ThongKeDeTaiTheoNganh", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MANK", SqlDbType.VarChar, 20) { Value = (object)MANK ?? DBNull.Value });
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(Detai);
            }
            return Detai;
        }
    }
}
