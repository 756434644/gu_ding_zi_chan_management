using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;

namespace Exp2
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void registering_Click(object sender, EventArgs e)
        {
            if (UserHelper.Inspecter == "")
                 {
                     new check_login(this).ShowDialog();
                 }
            if (UserHelper.Inspecter != "")
            {
                BLL.User user = new BLL.User();
                string msg = "";
                if (user.Register(username.Text, password.Text, check_passwrod.Text, name.Text, phone.Text, occupation.Text, out msg))
                {
                    MessageBox.Show("注册成功");
                }
                else
                {
                    MessageBox.Show(msg);
                }
            }
            
        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
