using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DTO;

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

        public TaiKhoanDTO GetTaiKhoan(string username, string password)
        {
            return taiKhoanRepository.GetTaiKhoanDTO(username, password);
        }

        public DataTable getDataTaiKhoan()
        {
            return taiKhoanRepository.getTaiKhoan();
        }

        public DataTable getDataDsRole()
        {
            return taiKhoanRepository.getdsRole();
        }

        public DataTable getDataTaiKhoanEdit(string id)
        {
            return taiKhoanRepository.getTaiKhoanEdit(id);
        }

        public void updateDataTaiKhoan(TaiKhoanDTO taikhoan)
        {
            if (taikhoan.UserID == 0)
            {
                throw new ArgumentException("Tên tài khoản không được để trống!");
            }

            if (string.IsNullOrWhiteSpace(taikhoan.Username))
            {
                throw new ArgumentException("Tên tài khoản không được để trống!");
            }

            if (string.IsNullOrWhiteSpace(taikhoan.PassWord))
            {
                throw new ArgumentException("Mật khẩu không được để trống!");
            }

            taiKhoanRepository.updateTaiKhoan(taikhoan);
        }

        public void deleteDataTaiKhoan(string id)
        {
            taiKhoanRepository.deleteTaiKhoan(id);
        }

        public DataTable getDataTaiKhoanFind(string keyword)
        {
            return taiKhoanRepository.getTaiKhoanFind(keyword);
        }
    }
}
