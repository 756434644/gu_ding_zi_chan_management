using System.Data;
using SQLDAL;
using Common;

namespace BLL
{
    public class Contact
    {
        //针对Contact表的业务处理逻辑类
        //把表示层的数据转发给数据访问层
        SQLDAL.Contact dal = new SQLDAL.Contact();
        SQLDAL.Change ch = new SQLDAL.Change();

        //显示数据函数
        public DataTable GetList(string strWhere, Model.Contact model)
        {
            return dal.GetList(strWhere,model);
        }
        //判断信息是否符合规范
        public bool CheckModel(Model.Contact model, out string msg)
        {
            bool check = true;
            msg = "资产编号不存在";
            if (model.Table == "summary")
            {
                msg = "资产编号已存在";
                if (Utility.Check(model.Price) || Utility.Check(model.Name) ||  Utility.Check(model.Id))
                {
                    msg = "记录不能为空";
                    check = false;
                    return check;
                }
                if (!Utility.CheckId(model.Id))
                {
                    msg = "资产编号只能为数字";
                    check = false;
                    return check;
                }
                if (!Utility.CheckTime(model.Buy_time))
                {
                    msg = "时间格式不正确";
                    check = false;
                    return check;
                }
                if (!Utility.CheckTime(model.Discard_time))
                {
                    msg = "时间格式不正确";
                    check = false;
                    return check;
                }
                if (!Utility.CheckMoney(model.Price))
                {
                    msg = "金额格式不正确";
                    check = false;
                    return check;
                }
            }
            if (model.Table == "department")
            {
                if (Utility.Check(model.Id) || Utility.Check(model.Departments))
                {
                    msg = "记录不能为空";
                    check = false;
                    return check;
                }
                if (!Utility.CheckId(model.Id))
                {
                    msg = "资产编号只能为数字";
                    check = false;
                    return check;
                }
                if (!Utility.CheckTime(model.scrap_date))
                {
                    msg = "时间格式不正确";
                    check = false;
                    return check;
                }


            }
            if (model.Table == "repair")
            {
                if (Utility.Check(model.Money) || Utility.Check(model.Id) || Utility.Check(model.Repair_reason))
                {
                    msg = "记录不能为空";
                    check = false;
                    return check;
                }
                if (!Utility.CheckId(model.Id))
                {
                    msg = "资产编号只能为数字";
                    check = false;
                    return check;
                }
                if (!Utility.CheckTime(model.scrap_date))
                {
                    msg = "时间格式不正确";
                    check = false;
                    return check;
                }
                if (!Utility.CheckMoney(model.Money))
                {
                    msg = "金额格式不正确";
                    check = false;
                    return check;
                }

            } 
            if (model.Table == "accumulated_depreciation")
            {
                if (Utility.Check(model.Sum) || Utility.Check(model.Id))
                {
                    msg = "记录不能为空";
                    check = false;
                    return check;
                }
                if (!Utility.CheckId(model.Id))
                {
                    msg = "资产编号只能为数字";
                    check = false;
                    return check;
                }
                if (!Utility.CheckTime(model.Date))
                {
                    msg = "时间格式不正确";
                    check = false;
                    return check;
                }
                if (!Utility.CheckMoney(model.Now))
                {
                    msg = "金额格式不正确";
                    check = false;
                    return check;
                }
            }
            if (model.Table == "value_decrease")
            {
                if (Utility.Check(model.Buy_price) || Utility.Check(model.Id))
                {
                    msg = "记录不能为空";
                    check = false;
                    return check;
                }
                if (!Utility.CheckId(model.Id))
                {
                    msg = "资产编号只能为数字";
                    check = false;
                    return check;
                }
                if (!Utility.CheckTime(model.Date))
                {
                    msg = "时间格式不正确";
                    check = false;
                    return check;
                }
                if (!Utility.CheckMoney(model.Sum))
                {
                    msg = "金额格式不正确";
                    check = false;
                    return check;
                }
            }
            if (model.Table == "scrap")
            {
                if (Utility.Check(model.Name) || Utility.Check(model.Id) || Utility.Check(model.Buy_price))
                {
                    msg = "记录不能为空";
                    check = false;
                    return check;
                }
                if (!Utility.CheckId(model.Id))
                {
                    msg = "资产编号只能为数字";
                    check = false;
                    return check;
                }
                if (!Utility.CheckTime(model.Buy_date))
                {
                    msg = "时间格式不正确";
                    check = false;
                    return check;
                }
                if (!Utility.CheckTime(model.Scrap_date))
                {
                    msg = "时间格式不正确";
                    check = false;
                    return check;
                }
                if (!Utility.CheckMoney(model.Buy_price))
                {
                    msg = "金额格式不正确";
                    check = false;
                    return check;
                }
            } 
            if (model.Table == "rent")
            {
                if (Utility.Check(model.Tenant) || Utility.Check(model.Id))
                {
                    msg = "记录不能为空";
                    check = false;
                    return check;
                }
                if (!Utility.CheckId(model.Id))
                {
                    msg = "资产编号只能为数字";
                    check = false;
                    return check;
                }
                if (!Utility.CheckTime(model.scrap_date))
                {
                    msg = "时间格式不正确";
                    check = false;
                    return check;
                }

            }
            
            return check;
        }

        public bool CheckModify(Model.Contact model, out string msg){
            bool check = true;
            msg = "需要修改的记录不存在";

            if (model.Table == "department")
            {
                if (Utility.Check(model.Id) || Utility.Check(model.Old_departments) || Utility.Check(model.Old_start_time) || Utility.Check(model.Departments) || Utility.Check(model.scrap_date) || Utility.Check(model.End_time) || Utility.Check(model.Recorder) || Utility.Check(model.Inspecter) || Utility.Check(model.Reason))
                {
                    msg = "记录不能为空";
                    check = false;
                    return check;
                }
                if (!Utility.CheckId(model.Id))
                {
                    msg = "资产编号只能为数字";
                    check = false;
                    return check;
                }
                if (!Utility.CheckTime(model.scrap_date))
                {
                    msg = "时间格式不正确";
                    check = false;
                    return check;
                }
                if (!Utility.CheckTime(model.End_time))
                {
                    msg = "时间格式不正确";
                    check = false;
                    return check;
                }

            }
            if (model.Table == "rent")
            {
                if (Utility.Check(model.Id) || Utility.Check(model.Old_tenant) || Utility.Check(model.Old_start_time) || Utility.Check(model.Tenant) || Utility.Check(model.scrap_date) || Utility.Check(model.End_time) || Utility.Check(model.Recorder) || Utility.Check(model.Inspecter) || Utility.Check(model.Reason))
                {
                    msg = "记录不能为空";
                    check = false;
                    return check;
                }
                if (!Utility.CheckId(model.Id))
                {
                    msg = "资产编号只能为数字";
                    check = false;
                    return check;
                }
                if (!Utility.CheckTime(model.scrap_date))
                {
                    msg = "时间格式不正确";
                    check = false;
                    return check;
                }
                if (!Utility.CheckTime(model.End_time))
                {
                    msg = "时间格式不正确";
                    check = false;
                    return check;
                }

            }
            if (model.Table == "repair")
            {
                if (Utility.Check(model.Id) || Utility.Check(model.Old_money) || Utility.Check(model.Old_start_time) || Utility.Check(model.Money) || Utility.Check(model.scrap_date) || Utility.Check(model.End_time) || Utility.Check(model.Recorder) || Utility.Check(model.Inspecter) || Utility.Check(model.Reason) || Utility.Check(model.Repair_reason))
                {
                    msg = "记录不能为空";
                    check = false;
                    return check;
                }
                if (!Utility.CheckId(model.Id))
                {
                    msg = "资产编号只能为数字";
                    check = false;
                    return check;
                }
                if (!Utility.CheckTime(model.scrap_date))
                {
                    msg = "时间格式不正确";
                    check = false;
                    return check;
                }
                if (!Utility.CheckTime(model.End_time))
                {
                    msg = "时间格式不正确";
                    check = false;
                    return check;
                }
                if (!Utility.CheckMoney(model.Old_money))
                {
                    msg = "金额格式不正确";
                    check = false;
                    return check;
                }
                if (!Utility.CheckMoney(model.Money))
                {
                    msg = "金额格式不正确";
                    check = false;
                    return check;
                }
            }

            if (model.Table == "scrap")
            {
                if (Utility.Check(model.Id) || Utility.Check(model.Old_name) || Utility.Check(model.Buy_price) || Utility.Check(model.Buy_date) || Utility.Check(model.Scrap_date) || Utility.Check(model.Name) || Utility.Check(model.Old_date) || Utility.Check(model.Old_start_time) || Utility.Check(model.Money) || Utility.Check(model.Recorder) || Utility.Check(model.Inspecter) || Utility.Check(model.Reason) )
                {
                    msg = "记录不能为空";
                    check = false;
                    return check;
                }
                if (!Utility.CheckId(model.Id))
                {
                    msg = "资产编号只能为数字";
                    check = false;
                    return check;
                }
                if (!Utility.CheckTime(model.Buy_date))
                {
                    msg = "时间格式不正确";
                    check = false;
                    return check;
                }

                if (!Utility.CheckTime(model.Scrap_date))
                {
                    msg = "时间格式不正确";
                    check = false;
                    return check;
                }
                if (!Utility.CheckMoney(model.Buy_price))
                {
                    msg = "金额格式不正确";
                    check = false;
                    return check;
                }
                if (!Utility.CheckMoney(model.Old_money))
                {
                    msg = "金额格式不正确";
                    check = false;
                    return check;
                }
              
            }
            if (model.Table == "acuumulated_depreciation")
            {
                if (Utility.Check(model.Id) || Utility.Check(model.Old_money) || Utility.Check(model.Old_date) || Utility.Check(model.Now) || Utility.Check(model.Date) || Utility.Check(model.Recorder) || Utility.Check(model.Inspecter) || Utility.Check(model.Reason))
                {
                    msg = "记录不能为空";
                    check = false;
                    return check;
                }
                if (!Utility.CheckId(model.Id))
                {
                    msg = "资产编号只能为数字";
                    check = false;
                    return check;
                }
                if (!Utility.CheckTime(model.Date))
                {
                    msg = "时间格式不正确";
                    check = false;
                    return check;
                }
                if (!Utility.CheckMoney(model.Old_money))
                {
                    msg = "金额格式不正确";
                    check = false;
                    return check;
                }
                if (!Utility.CheckMoney(model.Now))
                {
                    msg = "金额格式不正确";
                    check = false;
                    return check;
                }
            }

            if (model.Table == "value_decrease")
            {
                if (Utility.Check(model.Id) || Utility.Check(model.Old_money) || Utility.Check(model.Old_date) || Utility.Check(model.Sum) || Utility.Check(model.Date) || Utility.Check(model.Recorder) || Utility.Check(model.Inspecter) || Utility.Check(model.Reason))
                {
                    msg = "记录不能为空";
                    check = false;
                    return check;
                }
                if (!Utility.CheckId(model.Id))
                {
                    msg = "资产编号只能为数字";
                    check = false;
                    return check;
                }
                if (!Utility.CheckTime(model.Date))
                {
                    msg = "时间格式不正确";
                    check = false;
                    return check;
                }
                if (!Utility.CheckMoney(model.Old_money))
                {
                    msg = "金额格式不正确";
                    check = false;
                    return check;
                }
                if (!Utility.CheckMoney(model.Sum))
                {
                    msg = "金额格式不正确";
                    check = false;
                    return check;
                }
            }
            return check;
        }
        
        //添加记录函数
        public bool Update(Model.Contact model,out string msg)
        {
            if (!CheckModel(model, out msg))
            {
                return false;
            }
            else
            {
                return dal.Update(model);
            }
        }

        //修改记录函数
        public bool Modify(Model.Contact model, out string msg)
        {
            if (!CheckModify(model, out msg))
            {
                return false;
            }
            else
            {
                return dal.Modify(model);
            }
        }
        
    }
}
