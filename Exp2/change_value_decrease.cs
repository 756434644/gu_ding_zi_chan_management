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
    public partial class change_value_decrease : Form
    {
        Model.Contact model = new Model.Contact();
        public change_value_decrease()
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
                  model.Old_money = textBox2.Text;
                  model.Old_date = textBox3.Text;
                  model.Sum = textBox6.Text;
                  model.Date = textBox7.Text;
                  model.Recorder = Recorder.Text;
                  model.Inspecter = agree.Text;
                  model.Reason = textBox10.Text;
                  model.Now = textBox6.Text;

                  BLL.Contact bll = new BLL.Contact();
                  BLL.Change ch = new BLL.Change();
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
                  ch.change_dc_state_change(model);
                  ch.change_remain_state_change(model);
                  UserHelper.Inspecter = "";
              }
        }

        private void change_department_Load(object sender, EventArgs e)
        {
            agree.Enabled = false;
            agree.Text = "";
            Recorder.Enabled = false;
            Recorder.Text = UserHelper.Recorder; 
            model.Table = "value_decrease";
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
