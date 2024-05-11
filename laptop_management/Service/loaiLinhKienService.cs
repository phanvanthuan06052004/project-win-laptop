using DAL.Entity;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class loaiLinhKienService
    {
        /// <summary>
        /// lấy loại linh kiện
        /// </summary>
        /// <returns></returns>
        public List<LoaiLinhKien> GetType()
        {
            using (var context = new ManagementContext())
            {
                var query = context.loaiLinhKiens
                                     .Select(n => new
                                     {
                                         n.MaLoai,
                                         n.TenLoai
                                     })
                                     .ToList()
                                     .Select(n => new LoaiLinhKien
                                     {
                                         MaLoai = n.MaLoai,
                                         TenLoai = n.TenLoai    
                                     })
                                     .ToList();
                return query;
            }
        }

       
    }
}
