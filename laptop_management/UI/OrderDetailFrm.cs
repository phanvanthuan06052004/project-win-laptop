using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class OrderDetailFrm : Form
    {
        ChiTietHDService chiTietHDService;
        public OrderDetailFrm()
        {
            InitializeComponent();
        }

        private void OrderDetailFrm_Load(object sender, EventArgs e)
        {
            chiTietHDService = new ChiTietHDService();  
            dgvOrderDetail.AutoGenerateColumns = false; // Tắt tự động tạo cột
            try
            {
                // Đặt tên cột và liên kết với tên cột tương ứng trong DataTable
                dgvOrderDetail.AutoGenerateColumns = false;
                dgvOrderDetail.Columns.Add("MaHD", "Mã Hóa Đơn");
                dgvOrderDetail.Columns["MaHD"].DataPropertyName = "MaHD"; // Liên kết với cột MaKH trong DataTable
                dgvOrderDetail.Columns["MaHD"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Tự động lấp đầy

                dgvOrderDetail.Columns.Add("TenLK", "Tên Linh Kiện");
                dgvOrderDetail.Columns["TenLK"].DataPropertyName = "TenLK"; // Liên kết với cột TenKH trong DataTable
                dgvOrderDetail.Columns["TenLK"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Tự động lấp đầy

                dgvOrderDetail.Columns.Add("SoLuong", "Số Lượng");
                dgvOrderDetail.Columns["SoLuong"].DataPropertyName = "SoLuong"; // Liên kết với cột SoDT trong DataTable
                dgvOrderDetail.Columns["SoLuong"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Tự động lấp đầy

                dgvOrderDetail.Columns.Add("TriGia", "Trị Giá");
                dgvOrderDetail.Columns["TriGia"].DataPropertyName = "TriGia"; // Liên kết với cột SoDT trong DataTable
                dgvOrderDetail.Columns["TriGia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Tự động lấp đầy

                dgvOrderDetail.Columns.Add("NgayDatHang", "Ngày Đặt");
                dgvOrderDetail.Columns["NgayDatHang"].DataPropertyName = "NgayDatHang"; // Liên kết với cột SoDT trong DataTable
                dgvOrderDetail.Columns["NgayDatHang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Tự động lấp đầy



                dgvOrderDetail.DataSource = chiTietHDService.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            dgvOrderDetail.DataSource = chiTietHDService.GetAll();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            chiTietHDService = new ChiTietHDService();
            dgvOrderDetail.DataSource = null;
            dgvOrderDetail.AutoGenerateColumns = false; // Tắt tự động tạo cột
            try
            {

                dgvOrderDetail.DataSource = chiTietHDService.SearchByMaHD(txtSearch.Text);
                if (!(dgvOrderDetail.DataSource != null))
                {
                    MessageBox.Show("Không tìm thấy thông tin chi tiết hóa đơn!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
