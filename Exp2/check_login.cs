using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Exp2
{
    public partial class check_login : Form
    {
        Form f;

        public check_login(Form f1)
        {
            f = f1;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string password = txtUserPassword.Text.Trim();
            if (userName == "" || password == "")
            {
                MessageBox.Show("用户名或密码不能为空！");
                txtUserName.Focus();
                return;
            }
            else
            {
                BLL.User user = new BLL.User();
                if (user.Check_login(userName, password))
                {
                    UserHelper.Inspecter = user.GetName(userName, password, "Inspecter");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误，请重新输入！", "错误");
                    txtUserName.Text = "";
                    txtUserPassword.Text = "";
                    txtUserName.Focus();
                }
            }

        }

        private void check_login_Load(object sender, EventArgs e)
        {
            txtUserPassword.PasswordChar = '*';
        }
    }
}
