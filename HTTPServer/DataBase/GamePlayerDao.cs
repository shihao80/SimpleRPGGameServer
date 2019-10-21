using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public interface GamePlayerDao
    {
        List<GamePlayer> GetAllGamePlayer();
        GamePlayer GetAGamePlayer(string userID);
        List<GamePlayer> GetServerGamePlayer(string userID);
        bool InsertGamePlayer(GamePlayer userId);
        bool DeleteGamePlayer(string playerId);
        bool UpdateGamePlayer(GamePlayer gamePlayer);
    }
}
