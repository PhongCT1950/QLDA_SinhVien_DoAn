using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class TaiKhoanService
    {
        TaiKhoanRepository taiKhoanRepository = new TaiKhoanRepository();
        public string CheckRoleLg(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Tên đăng nhập và mật khẩu không được để trống.");
            }

            string role = taiKhoanRepository.checkRole(username, password);

            if (string.IsNullOrEmpty(role))
            {
                throw new UnauthorizedAccessException("Tài khoản hoặc mật khẩu không chính xác.");
            }

            return role;
        }
    }
}
