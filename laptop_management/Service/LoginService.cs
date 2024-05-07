using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class LoginService
    {
        /// <summary>
        /// kiểm tra login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool checkLogin(string username, string password)
        {
            using (var context = new ManagementContext())
            {
                var tk = context.taiKhoans
                    .Select(t => new {t.Username, t.Password, t.NhanVienId})
                    .Where(n => (n.Username == username && n.Password == password))
                    .FirstOrDefault();

                if (tk != null)
                    return true;
                else 
                    return false;
            }
        }
    }
}
