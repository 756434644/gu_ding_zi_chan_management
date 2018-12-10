using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IUser
    {
        //判断用户名、密码是否正确
        bool Login(string userName, string userPassword);
    }
}
