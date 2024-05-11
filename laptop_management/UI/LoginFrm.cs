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
    public partial class LoginFrm : Form
    {
        LoginService loginService;
        EmployeeService employeeService;
        public LoginFrm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
                string PassWord = txtPassword.Text;
                string UserName = txtUserName.Text;
                if (string.IsNullOrEmpty(UserName))
                {
                    MessageBox.Show("Chưa nhập Username");
                    return;
                }
                if (string.IsNullOrEmpty(PassWord))
                {
                    MessageBox.Show("Chưa nhập Password");
                    return;
                }

                loginService = new LoginService(); // Tạo một thể hiện của lớp LoginService
                bool ktr = loginService.checkLogin(UserName, PassWord); // Gọi phương thức checkLogin từ thể hiện đã tạo

                if (ktr)
                {
                    employeeService = new EmployeeService();
                    NhanVien nv = employeeService.TimNhanVien(UserName);
                    loginService = new LoginService();
                    ComputerComponentsManagementfrm mainfrm = new ComputerComponentsManagementfrm();
                    mainfrm.nv = nv;
                    string tmp = loginService.GetRole(UserName);
                    mainfrm.role = tmp;
                    this.Hide();
                    mainfrm.Show();
                }
                else
                {
                    MessageBox.Show("Sai Username hoặc password, Vui lòng nhập lại!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Text = ""; // Xóa trường mật khẩu
                    txtUserName.Text = ""; // Xóa trường tên đăng nhập
                }
        }

    }
}
