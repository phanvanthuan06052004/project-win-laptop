using DAL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        /// <summary>
        /// lây role theo username
        /// </summary>
        /// <returns></returns>
        public string GetRole(string username)
        {
            using (var context = new ManagementContext())
            {
                var query = (from nv in context.nhanViens
                             join tk in context.taiKhoans on nv.MaNV equals tk.NhanVienId into nvTk
                             from tk in nvTk.DefaultIfEmpty()
                             where tk != null && tk.Username.Contains(username)
                             select nv.Role).FirstOrDefault();

                return query;
            }
        }

    }
}
