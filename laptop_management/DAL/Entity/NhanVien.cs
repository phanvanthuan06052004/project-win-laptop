using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class NhanVien
    {
        public NhanVien() 
        {
            hoaDons = new HashSet<HoaDon>();
        }
        [Required(ErrorMessage = "Vai trò không được để trống")]
        [StringLength(30, ErrorMessage = "Vai trò không dài quá 30 kí tự")]

        public string Role { get; set; }

        [Key]
        [StringLength(8, MinimumLength = 8)]
        [Required(ErrorMessage = "Mã nhân viên không được để trống")]
        public string MaNV { get; set; }

        [Required(ErrorMessage = "Họ và tên không được để trống")]
        [MaxLength(50, ErrorMessage = "Họ và tên không dài quá 50 kí tự")]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "CCCD không được để trống")]
        [RegularExpression(@"^[0-9]{9}$", ErrorMessage = "CCCD phải có 9 chữ số")]
        public string CCCD { get; set; }

        public virtual taiKhoan taiKhoans { get; set; }
        public virtual ICollection<HoaDon> hoaDons { get; set; }
    }
}
