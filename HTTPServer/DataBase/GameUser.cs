using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
namespace DataBase
{
    public class GameUser
    {

        public string userId { get; set; }
        public string userPwd { get; set; }
        public string userName { get; set; }

        public GameUser()
        {

        }
        public GameUser(string userId, string userPwd, string userName)
        {
            this.userId = userId;
            this.userPwd = userPwd;
            this.userName = userName;
        }
    }
}
