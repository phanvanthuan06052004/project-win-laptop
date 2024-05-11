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
    public partial class Customerfrm : Form
    {
        CustomerService customerService;
        public Customerfrm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// load form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Customerfrm_Load(object sender, EventArgs e)
        {
            customerService = new CustomerService();
            dgvCustomer.AutoGenerateColumns = false; // Tắt tự động tạo cột
            try
            {
                // Đặt tên cột và liên kết với tên cột tương ứng trong DataTable
                dgvCustomer.AutoGenerateColumns = false;
                dgvCustomer.Columns.Add("CustomerId", "Customer Id");
                dgvCustomer.Columns["CustomerId"].DataPropertyName = "MaKH"; // Liên kết với cột MaKH trong DataTable
                dgvCustomer.Columns["CustomerId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Tự động lấp đầy

                dgvCustomer.Columns.Add("CustomerName", "Customer Name");
                dgvCustomer.Columns["CustomerName"].DataPropertyName = "TenKH"; // Liên kết với cột TenKH trong DataTable
                dgvCustomer.Columns["CustomerName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Tự động lấp đầy

                dgvCustomer.Columns.Add("Phone", "Phone");
                dgvCustomer.Columns["Phone"].DataPropertyName = "SoDT"; // Liên kết với cột SoDT trong DataTable
                dgvCustomer.Columns["Phone"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Tự động lấp đầy

                dgvCustomer.DataSource = customerService.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// tìm kiếm khách hàng theo tên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            customerService = new CustomerService();
            dgvCustomer.DataSource = null;
            dgvCustomer.AutoGenerateColumns = false; // Tắt tự động tạo cột
            try
            {

                dgvCustomer.DataSource = customerService.SearchCustomer(txtSearch.Text);
                if (!(dgvCustomer.DataSource != null))
                {
                    MessageBox.Show("Không tìm thấy khách hàng!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// load lại data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReload_Click(object sender, EventArgs e)
        {
            dgvCustomer.DataSource = customerService.GetAll();
        }
    }
}
