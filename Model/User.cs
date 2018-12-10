using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public partial class User
    {
        public User()
        { }
        #region Model

        private string _username;
        private string _password;
        //用户名
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        //密码
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }

        #endregion Model
    }
}

