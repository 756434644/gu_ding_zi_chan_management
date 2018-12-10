using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace Exp2
{
    public partial class scrap : Form
    {
        Model.Contact model = new Model.Contact();
        BLL.Contact bll = new BLL.Contact();

        public scrap()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            agree.Enabled = false;
            agree.Text = "";
            Recorder.Enabled = false;
            Recorder.Text = UserHelper.Recorder; 
            model.Table = "scrap";
            dataGridView1.DataSource = bll.GetList("1=1", model);
            dataGridView1.AutoResizeColumns();
        }

        public void Fill()
        {
            string Myquery1 = "";
            if (model.Id != "")
            {
                Myquery1 = Myquery1 + " id = '" + model.Id + "' and";
            }
            if (model.Old_money != "")
            {
                Myquery1 = Myquery1 + " buy_price >= '" + model.Old_money + "' and";
            }
            if (model.Money != "")
            {
                Myquery1 = Myquery1 + " buy_price <= '" + model.Money + "' and";
            }
            Myquery1 = Myquery1 + " 1=1";

            dataGridView1.DataSource = bll.GetList(Myquery1, model);
            dataGridView1.AutoResizeColumns();
        }


   

        private void button1_Click_1(object sender, EventArgs e)
        {
            model.Id = textBox1.Text;
            model.Old_money = textBox2.Text;
            model.Money = textBox10.Text;
            Fill();
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("请确认添加！", "添加提示", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                
                    model.Id = textBox3.Text.Trim();
                    model.Name = textBox4.Text.Trim();
                    model.Buy_price = textBox5.Text.Trim();
                    model.Buy_date = textBox6.Text.Trim();
                    model.Scrap_date = textBox7.Text.Trim();
                    model.Recorder = Recorder.Text.Trim();
                    model.Inspecter = agree.Text.Trim();

                    BLL.Contact bll = new BLL.Contact();
                    BLL.Change ch = new BLL.Change();
                    string msg = "";
                    if (bll.Update(model, out msg))
                    {
                        MessageBox.Show("添加成功！");
                    }
                    else
                    {
                        MessageBox.Show(msg);
                    }
                    dataGridView1.DataSource = bll.GetList("1=1", model);
                    dataGridView1.AutoResizeColumns();
                    ch.change_scrap_time(model);
                    ch.change_state(model);
                    ch.change_scrap_state(model);
                    UserHelper.Inspecter = "";
                }
            
            else
            {
                MessageBox.Show("添加取消！");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bll.GetList("1=1", model);
            dataGridView1.AutoResizeColumns();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new change_scrap().Show();
        }
    }
}
