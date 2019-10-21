using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
namespace DataBase
{
    public interface GameUserDao
    {
        List<GameUser> GetAllGameUser();
        GameUser GetAGameUser(string userId);
        GameUser Login(string userId, string userPwd);
        bool InsertGameUser(GameUser gameUser);
        bool DeleteGameUser(GameUser gameUser);
        bool UpdateGameUser(GameUser gameUser);

    }
}
