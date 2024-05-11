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
    public partial class OrderFrm : Form
    {
        linhKienService linhKienService;
        CustomerService customerService;
        ChiTietHDService chiTietHDService;
        public NhanVien nv { get; set; }
        public OrderFrm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void OrderFrm_Load(object sender, EventArgs e)
        {
            linhKienService = new linhKienService();
            dgvProduct.AutoGenerateColumns = false; // Tắt tự động tạo cột
            try
            {
                // Đặt tên cột và liên kết với tên cột tương ứng trong DataTable
                dgvProduct.AutoGenerateColumns = false;
                dgvProduct.Columns.Add("LinhKienId", "Ma Linh Kien");
                dgvProduct.Columns["LinhKienId"].DataPropertyName = "MaLK"; // Liên kết với cột MaLK trong DataTable
                dgvProduct.Columns["LinhKienId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Tự động lấp đầy

                dgvProduct.Columns.Add("LinhKienName", "Ten linh kien");
                dgvProduct.Columns["LinhKienName"].DataPropertyName = "TenLK"; // Liên kết với cột TenLK trong DataTable
                dgvProduct.Columns["LinhKienName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Tự động lấp đầy

                dgvProduct.Columns.Add("Gia", "Gia");
                dgvProduct.Columns["Gia"].DataPropertyName = "Gia"; // Liên kết với cột Gia trong DataTable
                dgvProduct.Columns["Gia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Tự động lấp đầy

                dgvProduct.Columns.Add("MaLoaiLK", "Ma Loai");
                dgvProduct.Columns["MaLoaiLK"].DataPropertyName = "LoaiLinhKienMaLoai"; // Liên kết với cột LoaiLinhKienMaLoai trong DataTable
                dgvProduct.Columns["MaLoaiLK"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Tự động lấp đầy

                dgvProduct.DataSource = linhKienService.GetAll();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Hàm load lại số linh kiện 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReload_Click(object sender, EventArgs e)
        {
            dgvProduct.DataSource = linhKienService.GetAll();
        }
        /// <summary>
        /// hàm khi ấn 1 linh kiện bên trong bảng sản phẩm thì sẽ đc thêm vào bảng hóa đơn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
           // Lấy thông tin của dòng được chọn từ dgvProduct
           DataGridViewRow selectedRow = dgvProduct.Rows[e.RowIndex];
            string id = selectedRow.Cells["LinhKienId"].Value.ToString();
            string name = selectedRow.Cells["LinhKienName"].Value.ToString();
            int quantity = 1; // Số lượng mặc định là 1
            double price = double.Parse(selectedRow.Cells["Gia"].Value.ToString());
            double totalPrice = quantity * price;
            string typeId = selectedRow.Cells["MaLoaiLK"].Value.ToString();
            //MessageBox.Show(id + " "+name+" "+quantity+" "+price+" "+totalPrice);
            // Kiểm tra xem sản phẩm đã tồn tại trong dgvOrder hay chưa
            int soHang = dgvOrderDetal.RowCount;
            if (soHang == 1)
            {
                dgvOrderDetal.Rows.Add(dgvOrderDetal.Rows.Count , id, name, typeId, quantity, price, totalPrice);
                return;
            }

            bool isExist = false;
            //DataGridViewRow row = dgvOrderDetal.Rows[0];
            //MessageBox.Show(row.Cells["dgvID"].Value.ToString());
            for(int i = 0;i < soHang-1;i++)
            {
                DataGridViewRow row = dgvOrderDetal.Rows[i];

                if (row.Cells["dgvID"].Value.ToString() == id)
                {
                    // Nếu sản phẩm đã tồn tại, tăng số lượng và cập nhật thành tiền
                    int currentQuantity = int.Parse(row.Cells["dgvSl"].Value.ToString());
                    double currentTotalPrice = double.Parse(row.Cells["dgvThanhTien"].Value.ToString());
                    currentQuantity++;
                    currentTotalPrice += price;
                    row.Cells["dgvSl"].Value = currentQuantity;
                    row.Cells["dgvThanhTien"].Value = currentTotalPrice;
                    isExist = true;
                    break;
                }
            }

            // Nếu sản phẩm chưa tồn tại, thêm sản phẩm mới vào dgvOrder
            if (!isExist)
                dgvOrderDetal.Rows.Add(dgvOrderDetal.Rows.Count, id, name, typeId, quantity, price, totalPrice);


            //// Cập nhật tổng thành tiền
            UpdateTotalPrice();
        }
        /// <summary>
        /// Hàm cập nhập tổng giá tiền cho hoas đơn
        /// </summary>
        private void UpdateTotalPrice()
        {
            double total = 0;
            foreach (DataGridViewRow row in dgvOrderDetal.Rows)
            {
                // Kiểm tra xem ô "dgvThanhTien" có giá trị không
                if (row.Cells["dgvThanhTien"].Value != null)
                {
                    double totalPrice;
                    // Kiểm tra xem giá trị của ô "dgvThanhTien" có thể chuyển đổi sang kiểu double không
                    if (double.TryParse(row.Cells["dgvThanhTien"].Value.ToString(), out totalPrice))
                        total += totalPrice;
                    
                 
                }
               
            }
            lblTong.Text = total.ToString();
        }
        /// <summary>
        /// Hàm sẽ xóa tất cả những sản phẩm mà khách hàng định mua nếu họ dổi ý
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            dgvOrderDetal.DataSource = null;
            dgvOrderDetal.Rows.Clear(); // Xóa tất cả các dòng
            txtCusstomerName.Text = null;
            txtCustomerID.Text = null;  
            txtCustomerPhone.Text = null;
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            chiTietHDService =new ChiTietHDService();
            //MessageBox.Show(nv.HoTen.ToString());
            try
            {
                KhachHang kh = new KhachHang();
                HoaDon hoaDon = new HoaDon();
                HoaDon.stt++;

                string s = "";
                for (int i = 1; i <= 6 - HoaDon.stt.ToString().Length; i++)
                    s = s + '0';
                hoaDon.MaHD = "HD" + s + HoaDon.stt.ToString(); ;
                hoaDon.NgayGioDat = DateTime.Now;
                hoaDon.NhanVienMaNV = nv.MaNV;
                List<ChiTietHD> chiTietHDs = new List<ChiTietHD>();
                if (string.IsNullOrWhiteSpace(txtCustomerID.Text) || string.IsNullOrWhiteSpace(txtCusstomerName.Text) || string.IsNullOrWhiteSpace(txtCustomerPhone.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin khách hàng");
                    return;
                }
                kh.MaKH = txtCustomerID.Text;
                kh.TenKH = txtCusstomerName.Text;
                kh.SoDT = txtCustomerPhone.Text;
                hoaDon.khachHangMaKH = kh.MaKH;
                customerService = new CustomerService();
                if (customerService.TimKhachHang(txtCustomerID.Text.ToString()) == false)
                {
                    customerService.AddCustomer(kh);
                    customerService.AddHoaDonKH(kh, hoaDon);
                }
                else
                    customerService.AddHoaDonKH(kh, hoaDon);
                int soHang = dgvOrderDetal.RowCount;
                for (int i = 0; i < soHang - 1; i++)
                {
                    DataGridViewRow row = dgvOrderDetal.Rows[i];
                    // Tạo một đối tượng ChiTietHD mới từ dữ liệu của dòng hiện tại
                    ChiTietHD chiTietHD = new ChiTietHD();
                    chiTietHD.LinhKienMaLK = row.Cells["dgvID"].Value.ToString();
                    chiTietHD.HoaDonMaHD = hoaDon.MaHD;
                    chiTietHD.SoLuong = Convert.ToInt32(row.Cells["dgvSl"].Value); // Lấy số lượng từ cột dgvSl
                    chiTietHD.TriGia = Convert.ToDecimal(row.Cells["dgvThanhTien"].Value); // Lấy đơn giá từ cột dgvDonGia
                    // Thêm đối tượng ChiTietHD mới vào danh sách
                    chiTietHDService.AddChiTietHoaDon(chiTietHD);
                }
                MessageBox.Show("Thêm hóa đơn thành công");
                // Gọi sự kiện btnCancel_Click để xóa danh sách sản phẩm trong giỏ hàng
                btnCancel_Click(sender, e); // Gọi sự kiện btnCancel_Click khi thanh toán thành công

            }
            catch
            {
                MessageBox.Show("Ko thêm đc hóa đơn");
            }
        }
    }
}
