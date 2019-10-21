using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public interface GameGoodDao
    {
        List<GameGood> GetAllGameGood();
        List<GameGood> GetAllGamePlayerGameGood(string playerId);
        GameGood GetAGameGood(string playerId, int goodId);
        bool InsertGameGood(GameGood gameGood);
        bool DeleteGameGood(string playerId);
        bool DeleteGameGood(string playerId, int goodId);
        bool UpdateGameGood(GameGood gameGood);
    }
}
