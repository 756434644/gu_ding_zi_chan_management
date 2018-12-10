using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace SQLDAL
{
    public class Change
    {
        public Change() { 
        
        }
        static string state;
        //修改summary表的使用状态
        public static void change_state(Model.Contact model)
        {

            switch (model.Table)
            {
                case "rent": state = "租赁"; break;
                case "department": state = "使用"; break;
                case "repair": state = "维修"; break;
                case "scrap": state = "报废"; break;
            }
            string str = "Server=.;database=asset_management_system;Integrated Security=sspi";
            String Myquery1;
            SqlConnection myconn = new SqlConnection(str);
            myconn.Open();
            Myquery1 = "update summary set situation = '" + state + "' where id = '" + model.Id + "'";
            SqlCommand mycmd1 = new SqlCommand(Myquery1, myconn);
            int result = mycmd1.ExecuteNonQuery();
            myconn.Close();
        }

        //修改summary表的归属部门
        public static void change_dp(Model.Contact model)
        {
            string str = "Server=.;database=asset_management_system;Integrated Security=sspi";
            String Myquery1;
            SqlConnection myconn = new SqlConnection(str);
            myconn.Open();
            Myquery1 = "update summary set departments = '" + model.Departments + "' where id = '" + model.Id + "'";
            SqlCommand mycmd1 = new SqlCommand(Myquery1, myconn);
            int result = mycmd1.ExecuteNonQuery();
            myconn.Close();
        }

        //修改summary表维修记录
        public static void change_repair_state(Model.Contact model)
        {
            string str = "Server=.;database=asset_management_system;Integrated Security=sspi";
            String Myquery1;
            SqlConnection myconn = new SqlConnection(str);
            myconn.Open();
            Myquery1 = "update summary set repair_report = '有' where id = '" + model.Id + "'";
            SqlCommand mycmd1 = new SqlCommand(Myquery1, myconn);
            int result = mycmd1.ExecuteNonQuery();
            myconn.Close();
        }

        //修改summary表的累计折旧金额
        public static void change_ad_state(Model.Contact model)
        {
            string str = "Server=.;database=asset_management_system;Integrated Security=sspi";
            String Myquery1;
            SqlConnection myconn = new SqlConnection(str);
            myconn.Open();
            Myquery1 = "update summary set accumulated_depreciation= accumulated_depreciation + " + model.Now + " where id = '" + model.Id + "'";
            SqlCommand mycmd1 = new SqlCommand(Myquery1, myconn);
            int result = mycmd1.ExecuteNonQuery();
            myconn.Close();
        }

        //修改summary表的累计折旧金额（当修改累计折旧记录的时候调用，新金额-旧金额）
        public static void change_ad_state_change(Model.Contact model)
        {
            string str = "Server=.;database=asset_management_system;Integrated Security=sspi";
            String Myquery1;
            SqlConnection myconn = new SqlConnection(str);
            myconn.Open();
            Myquery1 = "update summary set accumulated_depreciation= accumulated_depreciation - " + model.Old_money + " + " + model.Now + " where id = '" + model.Id+ "'";
            SqlCommand mycmd1 = new SqlCommand(Myquery1, myconn);
            int result = mycmd1.ExecuteNonQuery();
            myconn.Close();
        }

        //修改summary表的减值金额
        public static void change_dc_state(Model.Contact model)
        {
            string str = "Server=.;database=asset_management_system;Integrated Security=sspi";
            String Myquery1;
            SqlConnection myconn = new SqlConnection(str);
            myconn.Open();
            Myquery1 = "update summary set decrease_sum= decrease_sum + " + model.Sum + " where id = '" + model.Id + "'";
            SqlCommand mycmd1 = new SqlCommand(Myquery1, myconn);
            int result = mycmd1.ExecuteNonQuery();
            myconn.Close();
        }

        //修改summary表的减值金额（当修改减值表的时候调用，新金额-旧金额）
        public static void change_dc_state_change(Model.Contact model)
        {
            string str = "Server=.;database=asset_management_system;Integrated Security=sspi";
            String Myquery1;
            SqlConnection myconn = new SqlConnection(str);
            myconn.Open();
            Myquery1 = "update summary set decrease_sum= decrease_sum - " + model.Old_money + " + " + model.Sum + " where id = '" + model.Id + "'";
            SqlCommand mycmd1 = new SqlCommand(Myquery1, myconn);
            int result = mycmd1.ExecuteNonQuery();
            myconn.Close();
        }

        //修改summary表的剩余价值
        public static void change_remain_state(Model.Contact model)
        {
            string str = "Server=.;database=asset_management_system;Integrated Security=sspi";
            String Myquery1;
            SqlConnection myconn = new SqlConnection(str);
            myconn.Open();
            Myquery1 = "update summary set surplus_value= surplus_value - " + model.Now + " where id = '" + model.Id + "'";
            SqlCommand mycmd1 = new SqlCommand(Myquery1, myconn);
            int result = mycmd1.ExecuteNonQuery();
            myconn.Close(); 
            ///gai 
            myconn.Open(); 
            String Myquery2;
            Myquery2 = "select * from summary where id='"+model.Id+"'and surplus_value=0";
            SqlCommand mycmd2 = new SqlCommand(Myquery2, myconn);
            SqlDataReader result1 = mycmd2.ExecuteReader();
            if (result1.HasRows) {
                myconn.Close();
                String Myquery3;
                Myquery3 = "update summary set situation='" + "报废" + "'"+ " where id = '" + model.Id + "'";
                myconn.Open();
                SqlCommand mycmd3 = new SqlCommand(Myquery3, myconn);
                mycmd3.ExecuteNonQuery();
                String Myquery4 = "update summary set discard_time='" + model.Date + "'" + " where id = '" + model.Id + "'";
                SqlCommand mycmd4 = new SqlCommand(Myquery4, myconn);
                mycmd4.ExecuteNonQuery();
            }
            myconn.Close(); 

            
           
        }

        //修改summary表的剩余价值（当修改减值表或者累计折扣表）
        public static void change_remain_state_change(Model.Contact model)
        {
            string str = "Server=.;database=asset_management_system;Integrated Security=sspi";
            String Myquery1;
            SqlConnection myconn = new SqlConnection(str);
            myconn.Open();
            Myquery1 = "update summary set surplus_value= surplus_value + " + model.Old_money + " - " + model.Now + " where id = '" + model.Id+ "'";
            SqlCommand mycmd1 = new SqlCommand(Myquery1, myconn);
            int result = mycmd1.ExecuteNonQuery();
            myconn.Close();
        }

        //修改summary表的报废状态
        public static void change_scrap_state(Model.Contact model)
        {
            string str = "Server=.;database=asset_management_system;Integrated Security=sspi";
            String Myquery1;
            SqlConnection myconn = new SqlConnection(str);
            myconn.Open();
            Myquery1 = "update summary set discard_time = '" + model.Scrap_date + "' where id = '" + model.Id + "'";
            SqlCommand mycmd1 = new SqlCommand(Myquery1, myconn);
            int result = mycmd1.ExecuteNonQuery();
            myconn.Close();
        }

        //添加报废表之后将部门表的结束时间改变
        public static void change_scrap_time(Model.Contact model)
        {
            string str = "Server=.;database=asset_management_system;Integrated Security=sspi";
            String Myquery1;
            SqlConnection myconn = new SqlConnection(str);
            myconn.Open();
            Myquery1 = "select * from summary where id = '" + model.Id + "'";
            SqlCommand mycmd1 = new SqlCommand(Myquery1, myconn);
            mycmd1.ExecuteNonQuery();
            SqlDataAdapter Adpclass = new SqlDataAdapter();
            DataSet myds = new DataSet();
            Adpclass.SelectCommand = mycmd1;
            Adpclass.Fill(myds, "summary");
            string situation = myds.Tables["summary"].Rows[0]["situation"].ToString().Trim();
            myconn.Close();
            if (situation == "使用")
            {
                myconn.Open();
                Myquery1 = "SELECT TOP 1 * FROM department where id = " + model.Id + " order by start_time desc ";
                SqlCommand mycmd2 = new SqlCommand(Myquery1, myconn);
                mycmd2.ExecuteNonQuery();
                SqlDataAdapter Adpclass1 = new SqlDataAdapter();
                Adpclass1.SelectCommand = mycmd2;
                Adpclass1.Fill(myds, "department");
                string strat_time = myds.Tables["department"].Rows[0]["start_time"].ToString().Trim();
                myconn.Close();
                myconn.Open();
                Myquery1 = "update department set end_time = '" + model.Scrap_date + "' where start_time = '" + strat_time + "'";
                Console.WriteLine(Myquery1);
                SqlCommand mycmd3 = new SqlCommand(Myquery1, myconn);
                mycmd3.ExecuteNonQuery();
            }
        }


        public static void change_end_time(Model.Contact model) {
            string str = "Server=.;database=asset_management_system;Integrated Security=sspi";
            String Myquery1;
            SqlConnection myconn = new SqlConnection(str);
            myconn.Open();
            Myquery1 = "select * from summary where id = '" + model.Id + "'";
            SqlCommand mycmd1 = new SqlCommand(Myquery1, myconn);
            mycmd1.ExecuteNonQuery();
            SqlDataAdapter Adpclass = new SqlDataAdapter();
            DataSet myds = new DataSet();
            Adpclass.SelectCommand = mycmd1;
            Adpclass.Fill(myds, "summary");
            string situation = myds.Tables["summary"].Rows[0]["situation"].ToString().Trim();
            myconn.Close();
            if (situation == "使用" || situation == "报废") {
                myconn.Open();
                Myquery1 = "SELECT TOP 1 * FROM department where id = " + model.Id + " order by start_time desc ";
                SqlCommand mycmd2 = new SqlCommand(Myquery1, myconn);
                mycmd2.ExecuteNonQuery();
                SqlDataAdapter Adpclass1 = new SqlDataAdapter();
                Adpclass1.SelectCommand = mycmd2;
                Adpclass1.Fill(myds, "department");
                string strat_time = myds.Tables["department"].Rows[0]["start_time"].ToString().Trim();
                myconn.Close();
                myconn.Open();
                Myquery1 = "update department set end_time = '" + model.scrap_date + "' where start_time = '" + strat_time + "'";
                Console.WriteLine(Myquery1);
                SqlCommand mycmd3 = new SqlCommand(Myquery1, myconn);
                mycmd3.ExecuteNonQuery();
            }
            else if (situation == "租赁")
            {
                myconn.Open();
                Myquery1 = "SELECT TOP 1 * FROM rent where id = " + model.Id + " order by start_time desc ";
                SqlCommand mycmd2 = new SqlCommand(Myquery1, myconn);
                mycmd2.ExecuteNonQuery();
                SqlDataAdapter Adpclass1 = new SqlDataAdapter();
                Adpclass1.SelectCommand = mycmd2;
                Adpclass1.Fill(myds, "rent");
                string strat_time = myds.Tables["rent"].Rows[0]["start_time"].ToString().Trim();
                myconn.Close();
                myconn.Open();
                Myquery1 = "update rent set end_time = '" + model.scrap_date + "' where start_time = '" + strat_time + "'";
                Console.WriteLine(Myquery1);
                SqlCommand mycmd3 = new SqlCommand(Myquery1, myconn);
                mycmd3.ExecuteNonQuery();
            }
            else if (situation == "维修")
            {
                myconn.Open();
                Myquery1 = "SELECT TOP 1 * FROM repair where id = " + model.Id + " order by start_time desc ";
                SqlCommand mycmd2 = new SqlCommand(Myquery1, myconn);
                mycmd2.ExecuteNonQuery();
                SqlDataAdapter Adpclass1 = new SqlDataAdapter();
                Adpclass1.SelectCommand = mycmd2;
                Adpclass1.Fill(myds, "repair");
                string strat_time = myds.Tables["repair"].Rows[0]["start_time"].ToString().Trim();
                myconn.Close();
                myconn.Open();
                Myquery1 = "update repair set end_time = '" + model.scrap_date + "' where start_time = '" + strat_time + "'";
                Console.WriteLine(Myquery1);
                SqlCommand mycmd3 = new SqlCommand(Myquery1, myconn);
                mycmd3.ExecuteNonQuery();
            }
            myconn.Close();
            
        }

    }
}
