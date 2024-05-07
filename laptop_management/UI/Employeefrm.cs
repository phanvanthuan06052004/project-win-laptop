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
            InitializeComponent();
        }

        private void Employeefrm_Load(object sender, EventArgs e)
        {
            employee = new EmployeeService();
            dgvEmployee.DataSource = null;
            dgvEmployee.DataSource = employee.GetAll();
        }
    }
}
