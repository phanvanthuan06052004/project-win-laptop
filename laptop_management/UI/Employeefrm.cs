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
    public partial class Employeefrm : Form
    {
        EmployeeService employee;
        public Employeefrm()
        {
            employee = new EmployeeService();
            InitializeComponent();
            List<string> roles = employee.GetAllRoles();
            cmbRole.DataSource = roles;
        }

        private void Employeefrm_Load(object sender, EventArgs e)
        {
            employee = new EmployeeService();
            dgvEmployee.AutoGenerateColumns = false; // Tắt tự động tạo cột
            try
            {
                // Đặt tên cột và liên kết với tên cột tương ứng trong DataTable
                dgvEmployee.Columns.Add("EmployeeId", "Employee Id");
                dgvEmployee.Columns["EmployeeId"].DataPropertyName = "MaNV"; // Liên kết với thuộc tính MaNV trong đối tượng NhanVien
                dgvEmployee.Columns["EmployeeId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Tự động lấp đầy

                dgvEmployee.Columns.Add("EmployeeName", "Employee Name");
                dgvEmployee.Columns["EmployeeName"].DataPropertyName = "HoTen"; // Liên kết với thuộc tính HoTen trong đối tượng NhanVien
                dgvEmployee.Columns["EmployeeName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Tự động lấp đầy

                dgvEmployee.Columns.Add("CCCD", "CCCD");
                dgvEmployee.Columns["CCCD"].DataPropertyName = "CCCD"; // Liên kết với thuộc tính CCCD trong đối tượng NhanVien
                dgvEmployee.Columns["CCCD"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Tự động lấp đầy

                dgvEmployee.Columns.Add("Role", "Role");
                dgvEmployee.Columns["Role"].DataPropertyName = "Role"; // Liên kết với thuộc tính Role trong đối tượng NhanVien
                dgvEmployee.Columns["Role"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Tự động lấp đầy

                dgvEmployee.Columns.Add("Username", "Username");
                dgvEmployee.Columns["Username"].DataPropertyName = "Username"; // Liên kết với thuộc tính Username trong đối tượng NhanVien
                dgvEmployee.Columns["Username"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Tự động lấp đầy

                dgvEmployee.Columns.Add("Password", "Password");
                dgvEmployee.Columns["Password"].DataPropertyName = "Password"; // Liên kết với thuộc tính Password trong đối tượng NhanVien
                dgvEmployee.Columns["Password"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Tự động lấp đầy

                dgvEmployee.DataSource = employee.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnSearch_Click(object sender, EventArgs e)
        {
            employee = new EmployeeService();
            dgvEmployee.DataSource = null;
            dgvEmployee.AutoGenerateColumns = false; // Tắt tự động tạo cột
            try
            {
               
                dgvEmployee.DataSource = employee.GetNhanViens(txtSearch.Text);
                if(!(dgvEmployee.DataSource != null))
                {
                    MessageBox.Show("Không tìm thấy nhân viên!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// hàm reload lại danh sách nhân viên khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReload_Click(object sender, EventArgs e)
        {
            dgvEmployee.DataSource = employee.GetAll();
        }

        /// <summary>
        /// Hàm này thêm dữ liệu cho nhân viên và tài khoản
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                taiKhoan t = new taiKhoan();
                NhanVien n = new NhanVien();
                if (string.IsNullOrWhiteSpace(txtID.Text) || string.IsNullOrWhiteSpace(txtCCCD.Text) || string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(cmbRole.Text) ||
             string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(txtPassWord.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin nhân viên và tài khoản.");
                    return; // Kết thúc phương thức nếu thông tin không đầy đủ
                }
                n.MaNV = txtID.Text;
                n.CCCD = txtCCCD.Text;
                n.HoTen = txtName.Text;
               // n.Role = txtRole.Text;
             
                t.NhanVienId = txtID.Text;
                t.Username = txtUserName.Text;
                t.Password = txtPassWord.Text;
                t.nhanvien = n;
                n.taiKhoans = t;
                employee = new EmployeeService();
                bool ktr = employee.AddEmployee(n, t);
                if (ktr)
                {
                    MessageBox.Show("Thêm  thành công!");
                    dgvEmployee.DataSource = employee.GetAll();
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Thêm không thành công!");
            }
        }

        /// <summary>
        /// hàm này hiện thị dữ liệu của nhân viên đổ lên form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvEmployee.CurrentCell.RowIndex;
            txtID.Text = dgvEmployee.Rows[r].Cells[0].Value.ToString();
            txtName.Text = dgvEmployee.Rows[r].Cells[1].Value.ToString();
            txtCCCD.Text = dgvEmployee.Rows[r].Cells[2].Value.ToString();
            cmbRole.Text = dgvEmployee.Rows[r].Cells[3].Value.ToString();
            txtUserName.Text = dgvEmployee.Rows[r].Cells[4].Value.ToString();
            txtPassWord.Text = dgvEmployee.Rows[r].Cells[5].Value.ToString();
        }

        /// <summary>
        /// Hàm này xóa dữ liệu cho nhân viên và tài khoản
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEmployee.SelectedRows.Count == 0) // Kiểm tra xem có dòng nào được chọn trong DataGridView không
                {
                    MessageBox.Show("Vui lòng chọn nhân viên trong bảng bên trái để xóa");
                    return;
                }
        

                NhanVien n = dgvEmployee.SelectedRows[0].DataBoundItem as NhanVien; // Lấy đối tượng nhân viên từ dòng được chọn
                if (n == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin nhân viên!");
                    return;
                }
                employee = new EmployeeService();
                bool ktr = employee.DeleteEmployee(n);
                if (ktr)
                {
                    MessageBox.Show("Xóa thành công!");
                    dgvEmployee.DataSource = null;
                    dgvEmployee.DataSource = employee.GetAll();
                }
                else
                    MessageBox.Show("Xóa không thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa không thành công: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            NhanVien nv  = new NhanVien();
            nv.MaNV = txtID.Text;
            nv.HoTen = txtName.Text;
            nv.CCCD = txtCCCD.Text;
           // nv.Role = txtRole.Text; 

            employee = new EmployeeService();
            bool ktr = employee.UpdateEmplyee(nv);
            if (ktr)
            {
                MessageBox.Show("Update thành công!");
                dgvEmployee.DataSource = null;
                dgvEmployee.DataSource = employee.GetAll();
            }
            else
                MessageBox.Show("Update không thành công!");
        }
    }
}

