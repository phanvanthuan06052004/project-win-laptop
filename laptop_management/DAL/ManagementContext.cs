using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ManagementContext : DbContext
    {
        public ManagementContext():base("name=ConnectionString")
        {
            var initializer = new MigrateDatabaseToLatestVersion<ManagementContext, Migrations.Configuration>();
            Database.SetInitializer(initializer);
        }
        public DbSet<ChiTietHD> ChiTietHDs { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<KhachHang> khachHangs { get; set; }
        public DbSet<LinhKien> linhKiens { get; set; }
        public DbSet<LoaiLinhKien> loaiLinhKiens { get; set; }
        public DbSet<NhanVien> nhanViens { get; set; }
        public DbSet<taiKhoan> taiKhoans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Mối quan hệ một-nhiều: NhanVien - TaiKhoan
            //modelBuilder.Entity<taiKhoan>()
            //    .HasOptional(tk => tk.nhanvien)
            //    .WithMany(nv => nv.taiKhoans)
            //    .HasForeignKey(tk => tk.MaNV)
            //    .WillCascadeOnDelete(false);

            // Tạo mối quan hệ 1-n nhân viên hóa đơn
            modelBuilder.Entity<HoaDon>()
                .HasRequired<NhanVien>(e => e.NhanVien)
                .WithMany(p => p.hoaDons)
                .HasForeignKey<string>(e => e.NhanVienMaNV)
                .WillCascadeOnDelete(true); // Delete cascade

            // Tạo mối quan hệ 1-n khách hàng hóa đơn
            modelBuilder.Entity<HoaDon>()
                        .HasRequired<KhachHang>(e => e.khachHang)
                        .WithMany(p => p.hoaDons)
                        .HasForeignKey<string>(e => e.khachHangMaKH)
                        .WillCascadeOnDelete(true); // Delete cascade

            // Tạo mối quan hệ hóa đơn với chi tiết hóa đơn
            modelBuilder.Entity<ChiTietHD>()
                        .HasRequired<HoaDon>(e => e.HoaDon)
                        .WithMany(p => p.ChiTietHDs)
                        .HasForeignKey<string>(e => e.HoaDonMaHD)
                        .WillCascadeOnDelete(true); // Delete cascade

            // Tạo mối quan hệ linh kiện với chi tiết hóa đơn
            modelBuilder.Entity<ChiTietHD>()
                        .HasRequired<LinhKien>(e => e.LinhKien)
                        .WithMany(p => p.ChiTietHDs)
                        .HasForeignKey<string>(e => e.LinhKienMaLK)
                        .WillCascadeOnDelete(true); // Delete cascade

            // Tạo mối quan hệ 1-n linh kiện với loại linh kiện
            modelBuilder.Entity<LinhKien>()
                .HasRequired<LoaiLinhKien>(e => e.LoaiLinhKien)
                .WithMany(p => p.linhkien)
                .HasForeignKey<string>(e => e.LoaiLinhKienMaLoai)
                .WillCascadeOnDelete(true); // Delete cascade
        }

    }
}

 