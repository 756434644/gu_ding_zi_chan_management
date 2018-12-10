using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
namespace Exp2
{
    public partial class user_login : Form
    {
        public user_login()
        {
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
                if (user.Login(userName, password))
                {
                    UserHelper.Recorder = user.GetName(userName, password, "Recorder");
                    UserHelper.userName = txtUserName.Text.Trim();
                    UserHelper.password = txtUserPassword.Text.Trim();
                    this.Hide();
                    MainForm f = new MainForm();
                    f.Show();
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

        private void txtUserPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void user_login_Load(object sender, EventArgs e)
        {
            txtUserPassword.PasswordChar = '*';
        }
        
    }
}
