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
    public partial class ComputerComponentsManagementfrm : Form
    {
        public ComputerComponentsManagementfrm()
        {
            InitializeComponent();
            OpenChildForm(new OrderFrm());
        }
        private Form curentFormChild;
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
            OpenChildForm(new Employeefrm());
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            OpenChildForm(new OrderFrm());
        }

        private void btnComponent_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ProductFrm());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new OrderDetailFrm());
        }
    }
}
