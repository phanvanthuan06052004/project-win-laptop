using DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace UI
{
    public partial class ComputerComponentsManagementfrm : Form
    {
        private Form curentFormChild;
        public NhanVien nv { get; set; }
        public string role { get; set; }

        public ComputerComponentsManagementfrm()
        {
            InitializeComponent();
        }
        
        private void OpenChildForm(Form childForm)
        {
            if (curentFormChild != null)
            {
                curentFormChild.Close();
            }
            curentFormChild = childForm;
            childForm.Width = 1250;
            childForm.Height = 621;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnManage.Controls.Add(childForm);
            pnManage.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void lblHeader_Click(object sender, EventArgs e)
        {

        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Customerfrm());
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            if (role == "staff")
            {
                MessageBox.Show("Bạn không có quyền!!!");
            }
            else
            {
                OpenChildForm(new Employeefrm());
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            OrderFrm orderFrm = new OrderFrm();
            orderFrm.nv = nv;
            OpenChildForm(orderFrm);
        }

        private void btnComponent_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ProductFrm());
        }

        private void btnOrderdetail_Click(object sender, EventArgs e)
        {
            if (role == "staff")
            {
                MessageBox.Show("Bạn không có quyền!!!");
            }
            else
            {
                OpenChildForm(new OrderDetailFrm());
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn có muốn thoát app này không?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
                LoginFrm login = new LoginFrm();
                login.Show();
            }
        }
    }
}
