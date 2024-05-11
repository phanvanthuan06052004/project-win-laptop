using DAL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class HoaDonService
    {
        /// <summary>
        /// hàm tự động thêm hóa đơn
        /// </summary>
        /// <param name="hd"></param>
        public void AddAutoHoaDon(HoaDon hd)
        {
            using (var context = new ManagementContext())
            {
                context.HoaDons.Add(hd);
                context.SaveChanges();
            }
        }
    }
}
