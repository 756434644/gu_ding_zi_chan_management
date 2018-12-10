using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Exp2
{
    public partial class change_password : Form
    {
        public change_password()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BLL.User user = new BLL.User();
            string msg = "";
            if (user.ChangePassword(username.Text, oldp.Text, newp.Text, out msg))
            {
                MessageBox.Show("修改成功");
            }
            else
            {
                MessageBox.Show(msg);
            }
        }
    }
}
