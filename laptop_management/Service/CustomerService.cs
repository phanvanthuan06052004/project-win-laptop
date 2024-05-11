using DAL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Service
{
    public class CustomerService
    {
        /// <summary>
        /// lấy danh sách khách hàng
        /// </summary>
        /// <returns></returns>
        public List<KhachHang> GetAll()
        {
            using (var context = new ManagementContext())
            {
                var query = context.khachHangs
                                   .Select(n => new
                                   {
                                       n.MaKH,
                                       n.TenKH,
                                       n.SoDT
                                   })
                                   .ToList()
                                   .Select(n => new KhachHang
                                   {
                                       MaKH = n.MaKH,
                                       TenKH = n.TenKH,
                                       SoDT = n.SoDT

                                   })
                                   .ToList();

                return query;
            }
        }

        /// <summary>
        /// tìm kiếm thông tin khách hàng
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<KhachHang> SearchCustomer(string name)
        {
            using (var context = new ManagementContext())
            {
                var query = context.khachHangs
                                   .Where(n => n.TenKH.Contains(name)) // Tìm những nhân viên có tên chứa chuỗi name
                                   .Select(n => new
                                   {
                                       n.MaKH,
                                       n.TenKH,
                                       n.SoDT
                                   })
                                   .ToList()
                                   .Select(n => new KhachHang
                                   {
                                       MaKH = n.MaKH,
                                       TenKH = n.TenKH,
                                       SoDT = n.SoDT
                                   })
                                   .ToList();

                return query;
            }
        }

        /// <summary>
        /// Hàm này thêm dữ liệu cho khách hàng khi order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddCustomer(KhachHang kh)
        {
            using (var context = new ManagementContext())
            {
                try
                {
                    context.khachHangs.Add(kh);
                    context.SaveChanges();

                }
                catch (Exception ex)
                {
                    return;
                }


            }
        }
        /// <summary>
        /// hàm này để tìm xem có tồn tại khách hàng với id truyền vào ko
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool TimKhachHang(string id)
        {
            using (var context = new ManagementContext())
            {
                var query = context.khachHangs.Any(kh => kh.MaKH == id);
                return query;
            }
        }
        /// <summary>
        /// thêm hóa đơn khách hàng
        /// </summary>
        /// <param name="kh"></param>
        /// <param name="hoaDonKH"></param>
        public void AddHoaDonKH(KhachHang kh, HoaDon hoaDonKH)
        {
            using (var context = new ManagementContext())
            {
               
                // Lấy khách hàng từ cơ sở dữ liệu
                var existingKhachHang = context.khachHangs.FirstOrDefault(k => k.MaKH == kh.MaKH);

                // Kiểm tra xem khách hàng có tồn tại không
                if (existingKhachHang != null)
                {
                    // Thêm hóa đơn mới vào danh sách hóa đơn của khách hàng
                    existingKhachHang.hoaDons.Add(hoaDonKH);

                    // Lưu thay đổi vào cơ sở dữ liệu
                    context.SaveChanges();
                }
            }
        }
    }
}

