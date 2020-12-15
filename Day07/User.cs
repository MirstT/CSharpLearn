using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    class User
    {
        //字段
        private string loginId;

        //属性
        public string LoginId
        {
            get
            {
                return this.loginId;
            }
            set
            {
                this.loginId = value;
            }
        }

        //自动属性 包含一个字段 两个方法
        public string Password { get; set; }

        //构造函数
        public User()
        {
        }
        public User(string loginId,string pwd)
        {
            this.LoginId = loginId;
            this.Password = pwd;
        }

        //方法
        public void PrintUser()
        {
            Console.WriteLine("账号:{0},密码:{1}",LoginId,Password);
        }
    }
}
