using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entity
{
    public class LoaiLinhKien
    {
        [Key]
        [Required(ErrorMessage = "Mã loại không được để trống")]
        [StringLength(8, MinimumLength = 8)]
        public string MaLoai { get; set; }

        [Required(ErrorMessage = "Tên loại không được để trống")]
        [MaxLength(50, ErrorMessage = "Tên loại không dài quá 50 kí tự")]
        public string TenLoai { get; set; }

        [Required(ErrorMessage = "Mô Tả không được để trống")]
        [MaxLength(100, ErrorMessage = "Mô tả không dài quá 100 kí tự")]
        public string MoTa { get; set; }

        //mqh 1-N với linh kiện
        public virtual ICollection<LinhKien> linhkien { get; set; }
    }
}
