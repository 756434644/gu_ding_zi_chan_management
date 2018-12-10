using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Change
    {
        //修改summary表的使用状态
        public void change_state(Model.Contact model)
        {
            SQLDAL.Change.change_state(model);
        }
        //修改summary表的归属部门
        public void change_dp(Model.Contact model)
        {
            SQLDAL.Change.change_dp(model);
        }
        //修改summary表维修记录
        public void change_repair_state(Model.Contact model)
        {
            SQLDAL.Change.change_repair_state(model);
        }
        //修改summary表的累计折旧金额
        public void change_ad_state(Model.Contact model)
        {
            SQLDAL.Change.change_ad_state(model);
        }
        //修改summary表的累计折旧金额（当修改累计折旧记录的时候调用，新金额-旧金额）
        public void change_ad_state_change(Model.Contact model)
        {
            SQLDAL.Change.change_ad_state_change(model);
        }
        //修改summary表的减值金额
        public void change_dc_state(Model.Contact model)
        {
            SQLDAL.Change.change_dc_state(model);
        }
        //修改summary表的减值金额（当修改减值表的时候调用，新金额-旧金额）
        public void change_dc_state_change(Model.Contact model)
        {
            SQLDAL.Change.change_dc_state_change(model);
        }
        //修改summary表的剩余价值
        public void change_remain_state(Model.Contact model)
        {
            SQLDAL.Change.change_remain_state(model);
        }
        //修改summary表的剩余价值（当修改减值表或者累计折扣表）
        public void change_remain_state_change(Model.Contact model)
        {
            SQLDAL.Change.change_remain_state_change(model);
        }
        //修改summary表的报废状态
        public void change_scrap_state(Model.Contact model)
        {
            SQLDAL.Change.change_scrap_state(model);
        }
        //根据当前记录的开始时间修改自动更新上一条的结束时间
        public void change_end_time(Model.Contact model)
        {
            SQLDAL.Change.change_end_time(model);
        }
        public void change_scrap_time(Model.Contact model)
        {
            SQLDAL.Change.change_scrap_time(model);
        }
    }
}
