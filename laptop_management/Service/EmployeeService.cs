using DAL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class EmployeeService
    {

        public class NhanVienWithTaiKhoan
        {
            public string MaNV { get; set; }
            public string HoTen { get; set; }
            public string CCCD { get; set; }
            public string Role { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }
        /// <summary>
        /// lấy danh sách nhân viên và tài khoản
        /// </summary>
        /// <returns></returns>
        public List<NhanVienWithTaiKhoan> GetAll()
        {
            using (var context = new ManagementContext())
            {
                var query = (from nv in context.nhanViens
                             join tk in context.taiKhoans on nv.MaNV equals tk.NhanVienId into nvTk
                             from tk in nvTk.DefaultIfEmpty()
                             select new NhanVienWithTaiKhoan
                             {
                                 MaNV = nv.MaNV,
                                 HoTen = nv.HoTen,
                                 CCCD = nv.CCCD,
                                 Role = nv.Role,
                                 Username = tk != null ? tk.Username : null,
                                 Password = tk != null ? tk.Password : null
                             }).ToList();

                return query;
            }
        }


        /// <summary>
        /// tìm kiếm nhan viên theo tên
        /// </summary>
        /// <returns></returns>
        public List<NhanVien> GetNhanViens(string name)
        {
            using (var context = new ManagementContext())
            {
                var query = context.nhanViens
                                   .Where(n => n.HoTen.Contains(name)) // Tìm những nhân viên có tên chứa chuỗi name
                                   .Select(n => new
                                   {
                                       n.MaNV,
                                       n.HoTen,
                                       n.CCCD,
                                       n.Role
                                   })
                                   .ToList()
                                   .Select(n => new NhanVien
                                   {
                                       MaNV = n.MaNV,
                                       HoTen = n.HoTen,
                                       CCCD = n.CCCD,
                                       Role = n.Role
                                   })
                                   .ToList();

                return query;
            }
        }
        /// <summary>
        /// tìm kiếm nhan viên theo username
        /// </summary>
        /// <returns></returns>
        public NhanVien TimNhanVien(string name)
        {
            using (var context = new ManagementContext())
            {
               var query = context.nhanViens.FirstOrDefault(nv => nv.taiKhoans.Username == name);
               
                return query;
            }
        }

        /// <summary>
        /// thêm nhân viên
        /// </summary>
        /// <param name="n"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool AddEmployee(NhanVien n, taiKhoan t)
        {
            using (var context = new ManagementContext())
            { 
                try
                {
                    context.nhanViens.Add(n);
                    context.taiKhoans.Add(t);
                    context.SaveChanges();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
                

            }
        }

        /// <summary>
        /// xóa nhân viên
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool DeleteEmployee(NhanVien n)
        {
            using (var context = new ManagementContext())
            {
                try
                {
                    var existingNhanVien = context.nhanViens.FirstOrDefault(item => item.MaNV == n.MaNV);
                    string tmp = n.MaNV;
                    var existing = context.taiKhoans.First(c => c.NhanVienId.Equals(tmp));
                    if (existingNhanVien != null)
                    {
                        context.taiKhoans.Remove(existing);
                        context.SaveChanges();
                        context.nhanViens.Remove(existingNhanVien);             
                        context.SaveChanges();
                        
                        return true;
                    }
                    else
                    {
                        return false; // Không tìm thấy đối tượng trong cơ sở dữ liệu
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ
                   
                    return false;
                }
            }
        }

        /// <summary>
        /// sữa nhân viên
        /// </summary>
        /// <param name="nv"></param>
        /// <returns></returns>
        public bool UpdateEmplyee(NhanVien nv)
        {
            using (var context = new ManagementContext())
            {
                try
                {
                    string tmp = nv.MaNV;
                    
                    var existing = context.nhanViens.First(c => c.MaNV.Equals(tmp));
                    if (existing != null)
                    {
                        context.nhanViens.AddOrUpdate(existing, nv);
                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false; // Không tìm thấy đối tượng trong cơ sở dữ liệu
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ
                    return false;
                }
            }
        }

        /// <summary>
        /// Lấy danh sách tất cả các vai trò của nhân viên
        /// </summary>
        /// <returns>Danh sách các vai trò</returns>
        public List<string> GetAllRoles()
        {
            using (var context = new ManagementContext())
            {
                var roles = context.nhanViens
                                   .Select(nv => nv.Role) // Chọn thuộc tính Role của tất cả nhân viên
                                   .Distinct() // Lọc ra các giá trị duy nhất
                                   .ToList();

                return roles;
            }
        }

    }
}
