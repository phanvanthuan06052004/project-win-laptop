using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entity
{
    public class HoaDon
    {
        [Key]
        [Required(ErrorMessage = "Mã hóa đơn không được để trống")]
        [StringLength(8, MinimumLength = 8)]
        public string MaHD { get; set; }

        [Required(ErrorMessage = "Ngày giờ đặt không được để trống")]
        public DateTime NgayGioDat { get; set; }

        //tên khóa ngoại tham chiếu qua bảng khách hàng
        public string khachHangMaKH { get; set; }
        //tạo mới mqh hệ 1-N giữa Hóa đơn và Khách hàng
        public virtual KhachHang khachHang { get; set; }
        //ten khóa ngoại qua bảng nhân viên
        public string NhanVienMaNV { get; set; }

        // tao mqh  1-n nhanvien
        public virtual NhanVien NhanVien { get; set; }
        //tạo mqh 1-N với bảng ChiTietHD
        public virtual ICollection<ChiTietHD> ChiTietHDs { get; set; }
    }
}
