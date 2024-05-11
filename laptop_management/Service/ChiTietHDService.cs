using DAL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ChiTietHDService
    {
        /// <summary>
        /// lấy danh sách chi tiết hóa đơn
        /// </summary>
        /// <returns></returns>
        public List<ChiTietHDViewModel> GetAll()
        {
            using (var context = new ManagementContext())
            {
                var query = (from chiTietHD in context.ChiTietHDs
                             join linhKien in context.linhKiens on chiTietHD.LinhKienMaLK equals linhKien.MaLK
                             join hoaDon in context.HoaDons on chiTietHD.HoaDonMaHD equals hoaDon.MaHD
                             select new ChiTietHDViewModel
                             {
                                 MaHD = hoaDon.MaHD,
                                 TenLK = linhKien.TenLK,
                                 SoLuong = chiTietHD.SoLuong,
                                 TriGia = chiTietHD.TriGia,
                                 NgayDatHang = hoaDon.NgayGioDat
                             }).ToList();

                return query;
            }
        }

        // ViewModel để lưu thông tin cần lấy từ các bảng
        public class ChiTietHDViewModel
        {
            public string MaHD { get; set; }
            public string TenLK { get; set; }
            public int SoLuong { get; set; }
            public decimal TriGia { get; set; }
            public DateTime NgayDatHang { get; set; }
        }

        // Hàm tìm kiếm chi tiết hóa đơn theo mã hóa đơn
        public List<ChiTietHDViewModel> SearchByMaHD(string maHD)
        {
            using (var context = new ManagementContext())
            {
                var query = (from chiTietHD in context.ChiTietHDs
                             join linhKien in context.linhKiens on chiTietHD.LinhKienMaLK equals linhKien.MaLK
                             join hoaDon in context.HoaDons on chiTietHD.HoaDonMaHD equals hoaDon.MaHD
                             where chiTietHD.HoaDonMaHD == maHD
                             select new ChiTietHDViewModel
                             {
                                 MaHD = hoaDon.MaHD,
                                 TenLK = linhKien.TenLK,
                                 SoLuong = chiTietHD.SoLuong,
                                 TriGia = chiTietHD.TriGia,
                                 NgayDatHang = hoaDon.NgayGioDat
                             }).ToList();

                return query;
            }
        }

        /// <summary>
        /// hàm thêm chi tiết hóa đơn
        /// </summary>
        public void AddChiTietHoaDon(ChiTietHD chiTietHD)
        {
            using (var context = new ManagementContext())
            {
                context.ChiTietHDs.Add(chiTietHD);
                context.SaveChanges();
            }
        }
    }
}
