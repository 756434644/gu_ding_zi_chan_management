using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SQLDAL
{
    //操作Contact表的类   
    public class Contact
    {
        public Contact()
        { }

        #region Method

       
        //修改数据库显示属性名
        public DataSet change_name(DataSet myds, string table) { 
            switch(table){
                case "summary":                     myds.Tables[table].Columns[0].ColumnName = "资产编号";
                                                    myds.Tables[table].Columns[0].ColumnName = "资产编号";
                                                    myds.Tables[table].Columns[1].ColumnName = "资产名称";
                                                    myds.Tables[table].Columns[2].ColumnName = "归属部门";
                                                    myds.Tables[table].Columns[3].ColumnName = "使用状态";
                                                    myds.Tables[table].Columns[4].ColumnName = "修理记录";
                                                    myds.Tables[table].Columns[5].ColumnName = "购入时间";
                                                    myds.Tables[table].Columns[6].ColumnName = "购入价格";
                                                    myds.Tables[table].Columns[7].ColumnName = "资产减值";
                                                    myds.Tables[table].Columns[8].ColumnName = "累计折旧";
                                                    myds.Tables[table].Columns[9].ColumnName = "剩余价值";
                                                    myds.Tables[table].Columns[10].ColumnName = "报废时间";
                                                    myds.Tables[table].Columns[11].ColumnName = "初始记录人员";
                                                    break;
                case "department":                  myds.Tables[table].Columns[0].ColumnName = "资产编号";
                                                    myds.Tables[table].Columns[1].ColumnName = "归属部门";
                                                    myds.Tables[table].Columns[2].ColumnName = "开始时间";
                                                    myds.Tables[table].Columns[3].ColumnName = "结束时间";
                                                    myds.Tables[table].Columns[4].ColumnName = "记录人员";
                                                    myds.Tables[table].Columns[5].ColumnName = "批准人员";
                                                    myds.Tables[table].Columns[6].ColumnName = "修改原因";
                                                    break;
               case "repair":                       myds.Tables[table].Columns[0].ColumnName = "资产编号";
                                                    myds.Tables[table].Columns[1].ColumnName = "维修金额";
                                                    myds.Tables[table].Columns[2].ColumnName = "开始时间";
                                                    myds.Tables[table].Columns[3].ColumnName = "结束时间";
                                                    myds.Tables[table].Columns[4].ColumnName = "记录人员";
                                                    myds.Tables[table].Columns[5].ColumnName = "批准人员";
                                                    myds.Tables[table].Columns[6].ColumnName = "修理原因";
                                                    myds.Tables[table].Columns[7].ColumnName = "修改原因";
                                                    break;
                case "accumulated_depreciation":    myds.Tables[table].Columns[0].ColumnName = "资产编号";
                                                    myds.Tables[table].Columns[1].ColumnName = "当前折旧金额";
                                                    myds.Tables[table].Columns[2].ColumnName = "记录日期";
                                                    myds.Tables[table].Columns[3].ColumnName = "记录人员";
                                                    myds.Tables[table].Columns[4].ColumnName = "批准人员";
                                                    myds.Tables[table].Columns[5].ColumnName = "修改原因";
                                                    break;
                case "value_decrease":              myds.Tables[table].Columns[0].ColumnName = "资产编号";
                                                    myds.Tables[table].Columns[1].ColumnName = "减值额";
                                                    myds.Tables[table].Columns[2].ColumnName = "记录日期";
                                                    myds.Tables[table].Columns[3].ColumnName = "记录人员";
                                                    myds.Tables[table].Columns[4].ColumnName = "批注人员";
                                                    myds.Tables[table].Columns[5].ColumnName = "修改原因";
                                                    break;
                case "scrap":                       myds.Tables[table].Columns[0].ColumnName = "资产编号";
                                                    myds.Tables[table].Columns[1].ColumnName = "资产名称";
                                                    myds.Tables[table].Columns[2].ColumnName = "购入价格";
                                                    myds.Tables[table].Columns[3].ColumnName = "购入时间";
                                                    myds.Tables[table].Columns[4].ColumnName = "报废时间";
                                                    myds.Tables[table].Columns[5].ColumnName = "记录人员";
                                                    myds.Tables[table].Columns[6].ColumnName = "批准人员";
                                                    myds.Tables[table].Columns[7].ColumnName = "修改原因";
                                                    break;
                case "rent":                        myds.Tables[table].Columns[0].ColumnName = "资产编号";
                                                    myds.Tables[table].Columns[1].ColumnName = "租赁人";
                                                    myds.Tables[table].Columns[2].ColumnName = "开始时间";
                                                    myds.Tables[table].Columns[3].ColumnName = "结束时间";
                                                    myds.Tables[table].Columns[4].ColumnName = "记录人员";
                                                    myds.Tables[table].Columns[5].ColumnName = "批准人员";
                                                    myds.Tables[table].Columns[6].ColumnName = "修改原因";
                                                    break;
            }
            return myds;
        }


        //根据查询条件，获取列表    
        public DataTable GetList(string strWhere, Model.Contact model)
        {
            string str = "Server=.;database=asset_management_system;Integrated Security=sspi";
            string Myquery1;
            SqlConnection myconn = new SqlConnection(str);
            Myquery1 = "select * from " + model.Table + " where " + strWhere;
            SqlCommand mycmd1 = new SqlCommand(Myquery1, myconn);
            SqlDataAdapter Adpclass = new SqlDataAdapter();
            DataSet myds = new DataSet();
            Adpclass.SelectCommand = mycmd1;
            Adpclass.Fill(myds, model.Table);
            change_name(myds, model.Table);
            return myds.Tables[model.Table];
        }

        //增加一条记录
        public bool Update(Model.Contact model)
             {
                string str = "Server=.;database=asset_management_system;Integrated Security=sspi";
                string Myquery1="";
                SqlConnection myconn = new SqlConnection(str);

                myconn.Open();
                if (model.Table != "summary")
                {
                    Myquery1 = "select * from summary where id = '" + model.Id + "'";
                    SqlCommand mycmd1 = new SqlCommand(Myquery1, myconn);
                    SqlDataReader result = mycmd1.ExecuteReader();
                    result.Read();
                    if (result.HasRows)
                    {
                        myconn.Close();
                        switch (model.Table)
                        {
                            //case "summary": Myquery1 = "insert into " + model.Table + " values ('" + model.Id + "','" + model.Name + "','" + "待定" + "','" + "空闲" + "','" + "0" + "','" + model.Buy_time + "','" + model.Price + "','" + "0" + "','" + "0" + "','" + model.Price + "','" + model.Discard_time + "','" + model.Initial_recorder + "')"; break;
                            case "department": Myquery1 = "insert into " + model.Table + " values ('" + model.Id + "','" + model.Departments + "','" + model.scrap_date + "','" + model.End_time + "','" + model.Recorder + "','" + model.Inspecter + "','" + "无" + "')"; break;
                            case "repair": Myquery1 = "insert into " + model.Table + " values ('" + model.Id + "','" + model.Money + "','" + model.scrap_date + "','" + model.End_time + "','" + model.Recorder + "','" + model.Inspecter + "','" + model.Repair_reason + "','无')"; break;
                            case "accumulated_depreciation": Myquery1 = "insert into " + model.Table + " values ('" + model.Id + "','" + model.Now + "','" + model.Date + "','" + model.Recorder + "','" + model.Inspecter + "','无')"; break;
                            case "value_decrease": Myquery1 = "insert into " + model.Table + " values ('" + model.Id + "','" + model.Sum + "','" + model.Date + "','" + model.Recorder + "','" + model.Inspecter + "','无')"; break;
                            case "scrap": Myquery1 = "insert into " + model.Table + " values ('" + model.Id + "','" + model.Name + "','" + model.Buy_price + "','" + model.Buy_date + "','" + model.Scrap_date + "','" + model.Recorder + "','" + model.Inspecter + "','无')"; break;
                            case "rent": Myquery1 = "insert into " + model.Table + " values ('" + model.Id + "','" + model.Tenant + "','" + model.scrap_date + "','" + model.End_time + "','" + model.Recorder + "','" + model.Inspecter + "','无')"; break;
                        }
                        myconn.Open();
                        SqlCommand mycmd2 = new SqlCommand(Myquery1, myconn);
                        try
                        {
                            mycmd2.ExecuteNonQuery();
                            return true;
                        }
                        catch
                        {
                            return false;
                        }
                    }
                    else return false;
                }
                else {
                    Myquery1 = "insert into " + model.Table + " values ('" + model.Id + "','" + model.Name + "','" + "待定" + "','" + "空闲" + "','" + "无" + "','" + model.Buy_time + "','" + model.Price + "','" + "0" + "','" + "0" + "','" + model.Price + "','" + model.Discard_time + "','" + model.Initial_recorder + "')";
                    SqlCommand mycmd3 = new SqlCommand(Myquery1, myconn);
                    try
                    {
                        mycmd3.ExecuteNonQuery();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
             }

        //修改一条记录
        public bool Modify(Model.Contact model)
             {
                 string str = "Server=.;database=asset_management_system;Integrated Security=sspi";
                 string Myquery1 = "";
                 SqlConnection myconn = new SqlConnection(str);
                 myconn.Open();
                 switch (model.Table)
                 {
                     case "department": Myquery1 = "update " + model.Table + " set id = '" + model.Id + "', department = '" + model.Departments + "', start_time = '" + model.scrap_date + "', end_time = '" + model.End_time + "', recorder = '" + model.Recorder + "', inspecter = '" + model.Inspecter + "', reason  = '" + model.Reason + "' where id = '" + model.Id + "' and department = '" + model.Old_departments + "' and start_time = '" + model.Old_start_time + "' and end_time = '" + model.Old_end_time + "'"; break;
                     case "repair": Myquery1 = "update " + model.Table + " set id = '" + model.Id + "', money = '" + model.Money + "', start_time = '" + model.scrap_date + "', end_time = '" + model.End_time + "', recorder = '" + model.Recorder + "', inspecter = '" + model.Inspecter + "', repair_reason  = '" + model.Repair_reason + "', reason  = '" + model.Reason + "' where id = '" + model.Id + "' and money = '" + model.Old_money + "' and start_time = '" + model.Old_start_time + "' and end_time = '" + model.Old_end_time + "'"; break;
                     case "accumulated_depreciation": Myquery1 = "update " + model.Table + " set id = '" + model.Id + "', now = '" + model.Now + "', date = '" + model.Date + "', recorder = '" + model.Recorder + "', inspecter = '" + model.Inspecter + "', reason  = '" + model.Reason + "' where id = '" + model.Id + "' and now = '" + model.Old_money + "' and date = '" + model.Old_date + "'"; break;
                     case "value_decrease": Myquery1 = "update " + model.Table + " set id = '" + model.Id + "', sum = '" + model.Sum + "', date = '" + model.Date + "', recorder = '" + model.Recorder + "', inspecter = '" + model.Inspecter + "', reason  = '" + model.Reason + "' where id = '" + model.Id + "' and sum = '" + model.Old_money + "' and date = '" + model.Old_date + "'"; break;
                     case "scrap": Myquery1 = "update " + model.Table + " set id = '" + model.Id + "', name = '" + model.Name + "', buy_price = '" + model.Buy_price + "', buy_date = '" + model.Buy_date + "', scrap_date = '" + model.Scrap_date + "', recorder = '" + model.Recorder + "', inspecter  = '" + model.Inspecter + "', reason  = '" + model.Reason + "' where id = '" + model.Id + "' and name = '" + model.Old_name + "' and buy_price = '" + model.Old_money + "' and buy_date = '" + model.Old_date + "' and scrap_date = '" + model.Old_start_time + "'"; break;
                     case "rent": Myquery1 = "update " + model.Table + " set id = '" + model.Id + "', tenant = '" + model.Tenant + "', start_time = '" + model.scrap_date + "', end_time = '" + model.End_time + "', recorder = '" + model.Recorder + "', inspecter = '" + model.Inspecter + "', reason  = '" + model.Reason + "' where id = '" + model.Id + "' and tenant = '" + model.Old_tenant + "' and start_time = '" + model.Old_start_time + "' and end_time = '" + model.Old_end_time + "'"; break;
                 }
                 SqlCommand mycmd1 = new SqlCommand(Myquery1, myconn);
                 int result = mycmd1.ExecuteNonQuery();
                 if (result == 0)
                 {
                     return false;
                 }
                 else return true;
            }

        #endregion Method
        }
    }

