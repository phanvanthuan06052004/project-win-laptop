using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entity
{
    public class ChiTietHD
    {
        //tên khóa ngoại qua bảng link kiện
        [Key, Column(Order = 0)]
        [StringLength(8, MinimumLength = 8)]
        public string LinhKienMaLK { get; set; }

        //tên khóa ngoiaj qua bảng hóa đơn
        [Key, Column(Order = 1)]
        [StringLength(8, MinimumLength = 8)]
        public string HoaDonMaHD { get; set; }
        [Required(ErrorMessage = "Trị giá không được để trống")]
        public decimal TriGia { get; set; }

        [Required(ErrorMessage = "Số lượng không được để trống")]
        public int SoLuong { get; set; }

        // Khóa ngoại đến bảng LinhKien
        public virtual LinhKien LinhKien { get; set; }

        // Khóa ngoại đến bảng HoaDon
        public virtual HoaDon HoaDon { get; set; }
    }
}
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace DAL.Entity
//{
//    public class ChiTietHD
//    {
//        [Key]
//        [Column(Order = 0)]
//        [ForeignKey("LinhKien")]
//        public int LinhKienMaLK { get; set; }

//        [Key]
//        [Column(Order = 1)]
//        [ForeignKey("HoaDon")]
//        public int HoaDonMaHD { get; set; }

//        [Required(ErrorMessage = "Trị giá không được để trống")]
//        public decimal TriGia { get; set; }

//        [Required(ErrorMessage = "Số lượng không được để trống")]
//        public int SoLuong { get; set; }

//        // Khóa ngoại đến bảng LinhKien
//        public virtual LinhKien LinhKien { get; set; }

//        // Khóa ngoại đến bảng HoaDon
//        public virtual HoaDon HoaDon { get; set; }
//    }
//}
