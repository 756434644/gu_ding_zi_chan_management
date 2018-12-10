using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Exp2
{
    public partial class MainForm : Form
    {
        Model.Contact model = new Model.Contact();
        BLL.Contact bll = new BLL.Contact();

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Recorder.Enabled = false;
            Recorder.Text = UserHelper.Recorder;
            model.Table = "summary";
            dataGridView1.DataSource = bll.GetList("1=1", model);
            dataGridView1.AutoResizeColumns();
           
        }

        private string string2string(string time)
        {
            string[] list = time.Split('/');
            return list[0] + "-" +list[1] +"-" + list[2];

        }

        public void Fill()
        {
            string Myquery1 = "";
            if (model.Id != "")
            {
                Myquery1 = Myquery1 + " id = '" + model.Id + "' and";
            }
            if (model.Departments != "")
            {
                Myquery1 = Myquery1 + " departments = '" + model.Departments + "' and";
            }
            if (model.scrap_date != "")
            {
                Myquery1 = Myquery1 + " buy_time >= '" + model.scrap_date + "' and";
            }
            if (model.End_time != "")
            {
                Myquery1 = Myquery1 + " buy_time <= '" + model.End_time + "' and";
            }
            if (model.Scrap_state == "已报废")
            {
                Myquery1 = Myquery1 + " discard_time <= '" + string2string(model.Now) + "' and";
            }
            else if (model.Scrap_state == "未报废")
            {
                Myquery1 = Myquery1 + " discard_time > '" + string2string(model.Now) + "' and";
            }
            Myquery1 = Myquery1 + " 1=1";

            dataGridView1.DataSource = bll.GetList(Myquery1,model);
            dataGridView1.AutoResizeColumns();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            model.Id = textBox1.Text;
            model.Departments = textBox2.Text;
            model.scrap_date = textBox3.Text;
            model.End_time = textBox4.Text;
            model.Scrap_state = comboBox1.Text;
            model.Now = DateTime.Now.ToShortDateString().ToString();
            Fill();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new department().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new repair().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bll.GetList("1=1", model);
            dataGridView1.AutoResizeColumns();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            new accumulated_depreciation().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new value_decrease().Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new scrap().Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new rent().Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            model.Id = textBox5.Text.Trim();
            model.Name = textBox6.Text.Trim();
            model.Buy_time = textBox7.Text.Trim();
            model.Price = textBox8.Text.Trim();
            model.Discard_time = textBox9.Text.Trim();
            model.Initial_recorder = Recorder.Text.Trim();
            DialogResult dr = MessageBox.Show("请确认添加！", "添加提示", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                BLL.Contact bll = new BLL.Contact();
                string msg = "";
                if (bll.Update(model, out msg))
                {
                    MessageBox.Show("添加成功！");
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                }
                else
                {
                    MessageBox.Show(msg);
                }

                dataGridView1.DataSource = bll.GetList("1=1", model);
                dataGridView1.AutoResizeColumns();
            }
            else
            {
                MessageBox.Show("添加取消！");

            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void 用户注册ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new register().Show();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new change_password().Show();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new about().Show();
        }
    }
}
