using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SQLDAL
{
        //访问并操作数据表user的类
        public class User
        {
            public User()
            { }
            //注册用户
            public bool Register(string username, string password, string name, string phone, string occupation) {
                string str = "Server=.;database=asset_management_system;Integrated Security=sspi";
                String Myquery1;

                //创建连接对象
                SqlConnection myconn = new SqlConnection(str);
                myconn.Open();

                if (occupation == "管理人员") {
                    occupation = "0";
                }
                else if (occupation == "基层人员")
                {
                    occupation = "1";
                }

                try
                {
                    Myquery1 = "insert into users values ('" + username + "','" + password + "','" + name + "','" + occupation + "','" + phone + "')";
                    SqlCommand mycmd1 = new SqlCommand(Myquery1, myconn);
                    mycmd1.ExecuteNonQuery();
                    return true;
                }
                catch {
                    return false;
                }
            }

            public bool ChangePassword(string username, string oldp, string newp)
            {
                string str = "Server=.;database=asset_management_system;Integrated Security=sspi";
                String Myquery1;

                //创建连接对象
                SqlConnection myconn = new SqlConnection(str);
                myconn.Open();
                try
                {
                    Myquery1 = "update users set password = '" + newp + "' where user_id = '" + username + "' and password = '" + oldp+ "'"; 
                    SqlCommand mycmd1 = new SqlCommand(Myquery1, myconn);
                    int count = mycmd1.ExecuteNonQuery();
                    if (count != 0)
                    {
                        return true;
                    }
                    else return false;
                }
                catch
                {
                    return false;
                }
            }

            //判断用户名，密码是否正确
            public bool Login(string userName, string userPassword)
            {
                string str = "Server=.;database=asset_management_system;Integrated Security=sspi";
                String Myquery1;

                //创建连接对象
                SqlConnection myconn = new SqlConnection(str);
                myconn.Open();
                Myquery1 = "select * from users where user_id = '" + userName + "' and password = '" + userPassword + "' and occupation = 1";

                //创建命令对象(参数为命令字符串,连接对象)
                SqlCommand mycmd1 = new SqlCommand(Myquery1, myconn);
                mycmd1.ExecuteNonQuery();

                //为class表创建一个 SqlDataAdapter
                SqlDataAdapter Adpclass = new SqlDataAdapter();

                //创建一个数据集
                DataSet myds = new DataSet();
                Adpclass.SelectCommand = mycmd1;

                //填充数据到数据集中

                Adpclass.Fill(myds, "users");

                try
                {
                    string id = myds.Tables["users"].Rows[0]["user_id"].ToString().Trim();
                    string pwd = myds.Tables["users"].Rows[0]["password"].ToString().Trim();

                    if (id == userName && pwd == userPassword)
                    {
                        return true;
                    }
                    else return false;
                }
                catch
                {
                    return false;
                }
            }

            public string GetName(string userName, string userPassword, string type)
            { 
                string str = "Server=.;database=asset_management_system;Integrated Security=sspi";
                String Myquery1="";
                //创建连接对象
                SqlConnection myconn = new SqlConnection(str);
                myconn.Open();
                switch (type)
                {
                    case "Recorder": Myquery1 = Myquery1 = "select * from users where user_id = '" + userName + "' and password = '" + userPassword + "' and occupation = 1"; break;
                    case "Inspecter": Myquery1 = Myquery1 = "select * from users where user_id = '" + userName + "' and password = '" + userPassword + "' and occupation = 0"; break;
                } 
                SqlCommand mycmd1 = new SqlCommand(Myquery1, myconn);
                mycmd1.ExecuteNonQuery();
                SqlDataAdapter Adpclass = new SqlDataAdapter();
                DataSet myds = new DataSet();
                Adpclass.SelectCommand = mycmd1;
                Adpclass.Fill(myds, "check_users");
                string name = myds.Tables["check_users"].Rows[0]["name"].ToString().Trim();
                return name;
            }
            public bool Check_login(string userName, string userPassword)
            {
                string str = "Server=.;database=asset_management_system;Integrated Security=sspi";
                String Myquery1;

                //创建连接对象
                SqlConnection myconn = new SqlConnection(str);
                myconn.Open();
                Myquery1 = Myquery1 = "select * from users where user_id = '" + userName + "' and password = '" + userPassword + "' and occupation = 0";

                //创建命令对象(参数为命令字符串,连接对象)
                SqlCommand mycmd1 = new SqlCommand(Myquery1, myconn);
                mycmd1.ExecuteNonQuery();

                //为class表创建一个 SqlDataAdapter
                SqlDataAdapter Adpclass = new SqlDataAdapter();

                //创建一个数据集
                DataSet myds = new DataSet();
                Adpclass.SelectCommand = mycmd1;

                //填充数据到数据集中

                Adpclass.Fill(myds, "check_users");

                try
                {
                    string id = myds.Tables["check_users"].Rows[0]["user_id"].ToString().Trim();
                    string pwd = myds.Tables["check_users"].Rows[0]["password"].ToString().Trim();
                    string name = myds.Tables["check_users"].Rows[0]["name"].ToString().Trim();
                    if (id == userName && pwd == userPassword)
                    {
                        return true;
                    }
                    else return false;
                }
                catch
                {
                    return false;
                }
            }

        }
    
}
