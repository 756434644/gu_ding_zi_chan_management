using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
namespace BLL
{
    public class User
    {
        SQLDAL.User user = new SQLDAL.User();

        public bool CheckOne(string userName, string userPassword,string check_password, string name, string phone, string occupation ,out string msg)
        {
            msg = "用户名已存在";
            bool check = true;
            if (Utility.Check(userName) || Utility.Check(userPassword) || Utility.Check(phone) || Utility.Check(occupation) || Utility.Check(name))
            {
                msg = "信息填写不完整";
                check = false;
                return check;
                }
            if (!Utility.CheckId(phone))
            {
                msg = "手机号码只能为数字";
                check = false;
                return check;
            }
            if (userPassword!=check_password)
            {
                msg = "两次输入的密码需一致";
                check = false;
                return check;
            }
            return check;
         }

        public bool CheckTwo(string username, string oldp, string newp, out string msg) {
            msg = "用户名或密码错误";
            bool check = true;
            if (Utility.Check(username) || Utility.Check(oldp) || Utility.Check(newp))
            {
                msg = "信息填写不完整";
                check = false;
                return check;
            }
            return check;
        }

        public bool Login(string userName, string userPassword)
        {
            return user.Login(userName, userPassword);
        }
        public bool Check_login(string userName, string userPassword)
        {
            return user.Check_login(userName, userPassword);
        }
        public string GetName(string userName, string userPassword,string type) {
            return user.GetName(userName, userPassword, type);
        }
        public bool Register(string userName, string userPassword, string check_password ,string name, string phone, string occupation, out string msg)
        {
            if (!CheckOne(userName, userPassword ,check_password , name, phone, occupation, out msg))
            {
                return false;
            }
            else
            {
                return user.Register(userName, userPassword, name, phone, occupation);
            }
        }
        public bool ChangePassword(string username, string oldp, string newp, out string msg)
        {
            if (!CheckTwo(username, oldp, newp, out msg))
            {
                return false;
            }
            else
            {
                return user.ChangePassword(username, oldp, newp);
            }
        }
    }
}

