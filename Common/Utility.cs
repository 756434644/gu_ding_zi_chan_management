using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Common
{
    public class Utility
    {
        //检查是否为空
        public static bool CheckTime(string msg)
        {
            if (Regex.IsMatch(msg, @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$"))
            {
                return true;
            }
            return false;
            
        }

        public static bool CheckMoney(string msg) {
            if (Regex.IsMatch(msg, @"^\d+(\.\d+)?$"))
            {
                return true;
            }
            else return false;
        }

        public static bool CheckId(string msg)
        {
            if (Regex.IsMatch(msg, @"^[0-9]*[1-9][0-9]*$"))
            {
                return true;
            }
            else return false;
        }

        public static bool Check(string msg) {
            if (msg == "")
            {
                return true;
            }
            return false;
        }
    }
}
