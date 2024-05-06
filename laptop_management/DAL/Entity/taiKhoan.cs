using DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class taiKhoan
    {
        [Key]
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        [StringLength(8, MinimumLength = 8)]
        public string Username { get; set; }

        [MaxLength(30, ErrorMessage ="Mật khẩu không dài quá 30 kí tự")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string Password { get; set; }

        [MaxLength(30, ErrorMessage = "Role không dài quá 30 kí tự")]
        [Required(ErrorMessage = "Vai trò không được để trống")]
        public string Role { get; set; }

        public virtual NhanVien nhanvien { get; set; }
    }
}
