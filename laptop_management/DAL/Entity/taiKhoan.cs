using DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class taiKhoan
    {
        [Key]
        [ForeignKey("nhanvien")]
        [StringLength(8, MinimumLength = 8)]
        public string NhanVienId { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        [MaxLength(30)]
        public string Username { get; set; }

        [MaxLength(30, ErrorMessage ="Mật khẩu không dài quá 30 kí tự")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string Password { get; set; }

        public virtual NhanVien nhanvien { get; set; }
    }
}
