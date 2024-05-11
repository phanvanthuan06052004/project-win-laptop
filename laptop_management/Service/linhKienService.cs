using DAL.Entity;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class linhKienService
    {
        /// <summary>
        /// lấy danh sách tất cả linh kiện
        /// </summary>
        /// <returns></returns>
        public List<LinhKien> GetAll()
        {
            using (var context = new ManagementContext())
            {
                var query = context.linhKiens
                                     .Select(n => new
                                     {
                                         n.MaLK,
                                         n.TenLK,
                                         n.Gia,
                                         n.LoaiLinhKienMaLoai
                                     })
                                     .ToList()
                                     .Select(n => new LinhKien
                                     {
                                         MaLK = n.MaLK,
                                         TenLK = n.TenLK,
                                         Gia = n.Gia,
                                         LoaiLinhKienMaLoai = n.LoaiLinhKienMaLoai
                                     })
                                     .ToList();

                return query;
            }
        }

        /// <summary>
        /// tìm kiếm linh kiện theo tên
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<LinhKien> SearchLinhKien(string name)
        {
            using (var context = new ManagementContext())
            {
                var query = context.linhKiens
                                   .Where(n => n.TenLK.Contains(name)) 
                                   .Select(n => new
                                   {
                                       n.MaLK,
                                       n.TenLK,
                                       n.Gia,
                                       n.LoaiLinhKienMaLoai
                                   })
                                   .ToList()
                                   .Select(n => new LinhKien
                                   {
                                       MaLK = n.MaLK,
                                       TenLK = n.TenLK,
                                       Gia = n.Gia,
                                       LoaiLinhKienMaLoai = n.LoaiLinhKienMaLoai
                                   })
                                   .ToList();

                return query;
            }
        }
        /// <summary>
        /// thêm sản phẩm
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool AddProduct(LinhKien product)
        {
            using (var context = new ManagementContext())
            {
                // Kiểm tra xem sản phẩm đã tồn tại trong cơ sở dữ liệu chưa
                var existingProduct = context.linhKiens.Find(product.MaLK);
                if (existingProduct != null)
                {
                    // Nếu sản phẩm đã tồn tại, không thêm mới
                    return false;
                }

                // Thêm sản phẩm mới vào cơ sở dữ liệu
                context.linhKiens.Add(product);
                context.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// xóa sản phẩm
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public bool DeleteProduct(string productId)
        {
            try
            {
                using (var context = new ManagementContext())
                {
                    // Tìm sản phẩm cần xóa trong cơ sở dữ liệu
                    var productToDelete = context.linhKiens.Find(productId);

                    // Nếu sản phẩm không tồn tại, không thực hiện xóa và trả về false
                    if (productToDelete == null)
                    {
                        return false;
                    }

                    // Xóa sản phẩm khỏi cơ sở dữ liệu và lưu thay đổi
                    context.linhKiens.Remove(productToDelete);
                    context.SaveChanges();

                    return true; // Trả về true nếu xóa thành công
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi xảy ra khi xóa sản phẩm
                Console.WriteLine("Lỗi khi xóa sản phẩm: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// sữa sản phẩm
        /// </summary>
        /// <param name="updatedProduct"></param>
        /// <returns></returns>
        public bool UpdateProduct(LinhKien updatedProduct)
        {
            try
            {
                using (var context = new ManagementContext())
                {
                    // Tìm sản phẩm cần cập nhật trong cơ sở dữ liệu
                    var productToUpdate = context.linhKiens.Find(updatedProduct.MaLK);

                    // Nếu sản phẩm không tồn tại, không thực hiện cập nhật và trả về false
                    if (productToUpdate == null)
                    {
                        return false;
                    }

                    // Cập nhật thông tin của sản phẩm
                    productToUpdate.TenLK = updatedProduct.TenLK;
                    productToUpdate.Gia = updatedProduct.Gia;
                    productToUpdate.LoaiLinhKienMaLoai = updatedProduct.LoaiLinhKienMaLoai;

                    // Lưu thay đổi vào cơ sở dữ liệu
                    context.SaveChanges();

                    return true; // Trả về true nếu cập nhật thành công
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi xảy ra khi cập nhật sản phẩm
                Console.WriteLine("Lỗi khi cập nhật sản phẩm: " + ex.Message);
                return false;
            }
        }

    }
}
