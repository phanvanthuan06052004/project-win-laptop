namespace DAL.Migrations
{
    using DAL.Entity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.ManagementContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DAL.ManagementContext context)
        {
            //  Check if the database has already been seeded
            //if (context.HoaDons.Any() || context.khachHangs.Any() || context.linhKiens.Any()
            //    || context.loaiLinhKiens.Any() || context.nhanViens.Any() || context.taiKhoans.Any())
            //{
            //    return; // Database has been seeded
            //}

            // Seed NhanViens
            context.nhanViens.AddOrUpdate(
                new NhanVien { MaNV = "NV000001", HoTen = "Lê Nam", CCCD = "123456789", Role = "Admin" },
                new NhanVien { MaNV = "NV000002", HoTen = "Trần Thị Màu", CCCD = "987654321", Role = "staff" },
                new NhanVien { MaNV = "NV000003", HoTen = "Nguyễn Minh Đạo", CCCD = "111222333", Role = "staff" },
                new NhanVien { MaNV = "NV000004", HoTen = "Trần Thị Sơn", CCCD = "444555666", Role = "staff" }
               );

            context.taiKhoans.AddOrUpdate(
                new taiKhoan { Username = "nam", Password = "1234", NhanVienId = "NV000001" },
                new taiKhoan { Username = "mau", Password = "123", NhanVienId = "NV000002" },
                new taiKhoan { Username = "dao", Password = "123", NhanVienId = "NV000003" },
                new taiKhoan { Username = "son", Password = "123", NhanVienId = "NV000004" }
            );





            //// Seed KhachHangs
            context.khachHangs.AddOrUpdate(
                new KhachHang { MaKH = "KH000001", TenKH = "Phan Văn Thuận", SoDT = "12345678" },
                new KhachHang { MaKH = "KH000002", TenKH = "Lê Chí Nghĩa", SoDT = "87654321" },
                new KhachHang { MaKH = "KH000003", TenKH = "Lê Quốc Nam", SoDT = "11111111" },
                new KhachHang { MaKH = "KH000004", TenKH = "Nguyễn An Thành Phát", SoDT = "22222222" }
            );


            //// Seed HoaDons
            context.HoaDons.AddOrUpdate(
                new HoaDon { MaHD = "HD000001", NgayGioDat = DateTime.Now.AddDays(-3), NhanVienMaNV = "NV000001", khachHangMaKH = "KH000001" },
                new HoaDon { MaHD = "HD000002", NgayGioDat = DateTime.Now.AddDays(-2), NhanVienMaNV = "NV000002", khachHangMaKH = "KH000002" },
                new HoaDon { MaHD = "HD000003", NgayGioDat = DateTime.Now.AddDays(-1), NhanVienMaNV = "NV000003", khachHangMaKH = "KH000003" },
                new HoaDon { MaHD = "HD000004", NgayGioDat = DateTime.Now, NhanVienMaNV = "NV000004", khachHangMaKH = "KH000004" }
            );



            // Seed LoaiLinhKiens
            context.loaiLinhKiens.AddOrUpdate(
                new LoaiLinhKien { MaLoai = "LLK00001", TenLoai = "Bộ nhớ", MoTa = "Đây là các thành phần quan trọng trong việc lưu trữ và truy xuất dữ liệu trong máy tính." },
                new LoaiLinhKien { MaLoai = "LLK00002", TenLoai = "GPU", MoTa = "Bộ xử lý đồ họa, chịu trách nhiệm xử lý các tác vụ liên quan đến đồ họa và video trên máy tính." },
                new LoaiLinhKien { MaLoai = "LLK00003", TenLoai = "Case", MoTa = "Bộ khung chứa các thành phần khác của máy tính." },
                new LoaiLinhKien { MaLoai = "LLK00004", TenLoai = "Âm Thanh", MoTa = "Bao gồm loa, card âm thanh và các linh kiện khác liên quan" }
            );




            // Seed LinhKiens
            context.linhKiens.AddOrUpdate(
                new LinhKien { MaLK = "LK000001", TenLK = "SSD 512GB", Gia = 100, LoaiLinhKienMaLoai = "LLK00001" },
                new LinhKien { MaLK = "LK000002", TenLK = "NVIDIA GeForce RTX 3080", Gia = 200, LoaiLinhKienMaLoai = "LLK00002" },
                new LinhKien { MaLK = "LK000003", TenLK = "Corsair Carbide Series 275R", Gia = 150, LoaiLinhKienMaLoai = "LLK00003" },
                new LinhKien { MaLK = "LK000004", TenLK = "Loa JBL", Gia = 300, LoaiLinhKienMaLoai = "LLK00004" }
            );



            // Seed ChiTietHDs
            context.ChiTietHDs.AddOrUpdate(
                new ChiTietHD { HoaDonMaHD = "HD000001", LinhKienMaLK = "LK000001", SoLuong = 2, TriGia = 200 },
                new ChiTietHD { HoaDonMaHD = "HD000002", LinhKienMaLK = "LK000002", SoLuong = 1, TriGia = 200 },
                new ChiTietHD { HoaDonMaHD = "HD000003", LinhKienMaLK = "LK000003", SoLuong = 3, TriGia = 450 },
                new ChiTietHD { HoaDonMaHD = "HD000004", LinhKienMaLK = "LK000004", SoLuong = 2, TriGia = 600 }
            );

            // Save changes to database
            context.SaveChanges();

        }
    }
}
