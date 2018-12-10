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
    public partial class change_scrap : Form
    {
        Model.Contact model = new Model.Contact();

        public change_scrap()
        {
            InitializeComponent();
        }


       
        private void button1_Click(object sender, EventArgs e)
        {
              if (UserHelper.Inspecter == "")
            {
                new check_login(this).ShowDialog();
                agree.Text = UserHelper.Inspecter;
            }
              if (UserHelper.Inspecter != "")
              {
                  model.Id = textBox1.Text;
                  model.Old_name = textBox2.Text;
                  model.Old_money = textBox3.Text;
                  model.Old_date = textBox4.Text;
                  model.Old_start_time = textBox13.Text;
                  model.Name = textBox6.Text;
                  model.Buy_price = textBox7.Text;
                  model.Buy_date = textBox4.Text;
                  model.Scrap_date = textBox9.Text;
                  model.Recorder = Recorder.Text;
                  model.Inspecter = agree.Text;
                  model.Reason = textBox12.Text;

                  BLL.Contact bll = new BLL.Contact();
                  string msg = "";
                  if (bll.Modify(model,out msg))
                  {
                      MessageBox.Show("修改成功！");
                      this.Hide();
                  }
                  else
                  {
                      MessageBox.Show(msg);
                  }
                  UserHelper.Inspecter = "";
              }

        }

        private void change_department_Load(object sender, EventArgs e)
        {
            agree.Enabled = false;
            agree.Text = "";
            Recorder.Enabled = false;
            Recorder.Text = UserHelper.Recorder;
            model.Table = "scrap";
            textBox5.Enabled = false;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox5.Text = textBox1.Text;
        }
    }
}
