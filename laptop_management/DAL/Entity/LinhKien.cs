using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entity
{
    public class LinhKien
    {
        public LinhKien() 
        {
            ChiTietHDs = new HashSet<ChiTietHD>();
        }

        [Key]
        [Required(ErrorMessage = "Mã linh kiện không được để trống")]
        public string MaLK { get; set; }

        [Required(ErrorMessage = "Tên linh kiện không được để trống")]
        [MaxLength(100, ErrorMessage = "Tên linh kiện không dài quá 100 kí tự")]
        public string TenLK { get; set; }

        [Required(ErrorMessage = "Giá linh kiện không được để trống")]
        public decimal Gia { get; set; }
        //tên khóa ngoại tham chiếu qua bảng mã loại linh kiện
        public string LoaiLinhKienMaLoai { get; set; }
        //tạo mqh 1-N với loại linh kiện 
        public virtual LoaiLinhKien LoaiLinhKien { get; set; }

        public virtual ICollection<ChiTietHD> ChiTietHDs { get; set; }
    }
}
