using DAL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class EmployeeService
    {

        /// <summary>
        /// Lấy danh sách tất cả nhân viên
        /// </summary>
        /// <returns></returns>
        public List<NhanVien> GetAll()
        {
            using (var context = new ManagementContext())
            {
                var query = context.nhanViens
                                   .Select(n => new
                                   {
                                       n.MaNV,
                                       n.HoTen,
                                       n.CCCD,
                                       n.Role
                                   })
                                   .ToList()
                                   .Select(n => new NhanVien
                                   {
                                       MaNV = n.MaNV,
                                       HoTen = n.HoTen,
                                       CCCD = n.CCCD,
                                       Role = n.Role
                                   })
                                   .ToList();

                return query;
            }
        }


    }
}
