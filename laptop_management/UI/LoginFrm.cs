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
        public LoginFrm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string PassWord = txtPassword.Text;
            string UserName = txtUserName.Text;
            if (UserName == null || UserName.Equals(""))
            {
                MessageBox.Show("Chưa nhập Username");
                return;
            }
            if (PassWord == null || PassWord.Equals(""))
            {
                MessageBox.Show("Chưa nhập Password");
                return;
            }
        }
    }
}
