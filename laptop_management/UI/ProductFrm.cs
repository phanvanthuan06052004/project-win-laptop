using DAL;
using DAL.Entity;
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
    public partial class ProductFrm : Form
    {
        linhKienService linhKienService;
        loaiLinhKienService loaiLinhKienService;
        public ProductFrm()
        {
            loaiLinhKienService = new loaiLinhKienService();
            InitializeComponent();
            cmbType.DataSource = loaiLinhKienService.GetType();
            cmbType.DisplayMember = "TenLoai";
            cmbType.ValueMember = "MaLoai";
        }

        private void ProductFrm_Load(object sender, EventArgs e)
        {
            linhKienService = new linhKienService();
            dgvProduct.AutoGenerateColumns = false; // Tắt tự động tạo cột
            try
            {
                // Đặt tên cột và liên kết với tên cột tương ứng trong DataTable
                dgvProduct.AutoGenerateColumns = false;
                dgvProduct.Columns.Add("MaLK", "Ma Linh Kien");
                dgvProduct.Columns["MaLK"].DataPropertyName = "MaLK"; // Liên kết với cột MaLK trong DataTable
                dgvProduct.Columns["MaLK"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Tự động lấp đầy

                dgvProduct.Columns.Add("TenLK", "Tên Linh Kiện");
                dgvProduct.Columns["TenLK"].DataPropertyName = "TenLK"; // Liên kết với cột TenKH trong DataTable
                dgvProduct.Columns["TenLK"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Tự động lấp đầy

                dgvProduct.Columns.Add("price", "Gia");
                dgvProduct.Columns["price"].DataPropertyName = "Gia"; // Liên kết với cột Gia trong DataTable
                dgvProduct.Columns["price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Tự động lấp đầy

                dgvProduct.Columns.Add("MaLLK", "Ma Loai LK");
                dgvProduct.Columns["MaLLK"].DataPropertyName = "LoaiLinhKienMaLoai"; // Liên kết với cột LoaiLinhKienMaLoai trong DataTable
                dgvProduct.Columns["MaLLK"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Tự động lấp đầy

                dgvProduct.DataSource = linhKienService.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                if (rowIndex >= 0 && rowIndex < dgvProduct.Rows.Count)
                {
                    DataGridViewRow selectedRow = dgvProduct.Rows[rowIndex];
                    txtID.Text = selectedRow.Cells["MaLK"].Value.ToString();
                    txtName.Text = selectedRow.Cells["TenLK"].Value.ToString();
                    txtPrice.Text = selectedRow.Cells["price"].Value.ToString();
                    string maLoaiSP = selectedRow.Cells["MaLLK"].Value.ToString();

                    // Tìm và chọn loại sản phẩm tương ứng trong ComboBox
                    foreach (var item in cmbType.Items)
                    {
                        if (item is LoaiLinhKien loaiLinhKien && loaiLinhKien.MaLoai == maLoaiSP)
                        {
                            cmbType.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            linhKienService = new linhKienService();
            dgvProduct.DataSource = null;
            dgvProduct.AutoGenerateColumns = false; // Tắt tự động tạo cột
            try
            {

                dgvProduct.DataSource = linhKienService.SearchLinhKien(txtSearch.Text);
                if (!(dgvProduct.DataSource != null))
                {
                    MessageBox.Show("Không tìm thấy linh kiện!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            dgvProduct.DataSource = linhKienService.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo một đối tượng LinhKien từ dữ liệu nhập vào từ giao diện người dùng
                LinhKien newProduct = new LinhKien
                {
                    MaLK = txtID.Text,
                    TenLK = txtName.Text,
                    Gia = decimal.Parse(txtPrice.Text),
                    LoaiLinhKienMaLoai = cmbType.SelectedValue.ToString()
                };

                // Khởi tạo một đối tượng của lớp linhKienService
                linhKienService = new linhKienService();

                // Gọi phương thức AddProduct từ lớp linhKienService và chuyển đối tượng LinhKien vào
                bool isSuccess = linhKienService.AddProduct(newProduct);

                if (isSuccess)
                {
                    MessageBox.Show("Thêm sản phẩm thành công!");
                    dgvProduct.DataSource = linhKienService.GetAll(); // Reload DataGridView để hiển thị sản phẩm mới
                }
                else
                {
                    MessageBox.Show("Thêm sản phẩm không thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm sản phẩm không thành công! Lỗi: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string productId = txtID.Text; // Lấy mã sản phẩm cần xóa từ TextBox
                linhKienService = new linhKienService();

                bool isSuccess = linhKienService.DeleteProduct(productId);
                if (isSuccess)
                {
                    MessageBox.Show("Xóa sản phẩm thành công!");
                    dgvProduct.DataSource = linhKienService.GetAll(); // Reload DataGridView để cập nhật danh sách sản phẩm
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm cần xóa hoặc có lỗi xảy ra khi xóa!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa sản phẩm không thành công! Lỗi: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo một đối tượng LinhKien từ dữ liệu nhập vào từ giao diện người dùng
                LinhKien updatedProduct = new LinhKien
                {
                    MaLK = txtID.Text,
                    TenLK = txtName.Text,
                    Gia = decimal.Parse(txtPrice.Text),
                    LoaiLinhKienMaLoai = cmbType.SelectedValue.ToString()
                };

                // Khởi tạo một đối tượng của lớp linhKienService
                linhKienService = new linhKienService();

                // Gọi phương thức UpdateProduct từ lớp linhKienService và chuyển đối tượng LinhKien đã cập nhật vào
                bool isSuccess = linhKienService.UpdateProduct(updatedProduct);

                if (isSuccess)
                {
                    MessageBox.Show("Cập nhật sản phẩm thành công!");
                    dgvProduct.DataSource = linhKienService.GetAll(); // Reload DataGridView để hiển thị sản phẩm đã cập nhật
                }
                else
                {
                    MessageBox.Show("Cập nhật sản phẩm không thành công hoặc không tìm thấy sản phẩm!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật sản phẩm không thành công! Lỗi: " + ex.Message);
            }
        }

    }
}
