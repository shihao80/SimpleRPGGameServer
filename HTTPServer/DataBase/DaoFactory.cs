using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class DaoFactory
    {
        public static GameUserDaoImp GetGameUserDaoImp()
        {
            return new GameUserDaoImp();
        }
        public static GamePlayerDaoImp GetGamePlayerDaoImp()
        {
            return new GamePlayerDaoImp();
        }
        public static GameGoodDaoImp GetGameGoodDaoImp()
        {
            return new GameGoodDaoImp();
        }
    }
}
