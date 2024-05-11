using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entity
{
    public class KhachHang
    {
        public KhachHang() 
        {
            hoaDons = new HashSet<HoaDon>();
        }  
        [Key]
        [Required(ErrorMessage = "Mã khách hàng không được để trống")]
        [StringLength(8, MinimumLength = 8)]
        public string MaKH { get; set; }

        [Required(ErrorMessage = "Tên khách hàng không được để trống")]
        [MaxLength(30, ErrorMessage = "Tên khách hàng không dài quá 30 kí tự")]
        public string TenKH { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Số điện thoại chỉ được chứa các chữ số")]
        [StringLength(10, MinimumLength = 10)]
        public string SoDT { get; set; }

        // tạo mqh 1-N với bảng khách hàng
        public virtual ICollection<HoaDon> hoaDons { get; set; }
    }
}
