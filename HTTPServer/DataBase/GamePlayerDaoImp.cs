using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
namespace DataBase
{
    public class GamePlayerDaoImp : GamePlayerDao
    {
        OracleConnection conn = null;
        OracleCommand comm = null;
        OracleDataReader rdr = null;

        public bool DeleteGamePlayer(string playerId)
        {
            try
            {
                conn = OracleBean.GetConnection();
                conn.Open();
                string sql = "delete from GamePlayer where playerId ='" + playerId + "'";
                comm = new OracleCommand(sql, conn);
                sql = null;
                return comm.ExecuteNonQuery() > 0;
            }
            catch (OracleException ex)
            {
                //写入错误日志
            }
            finally
            {
                OracleBean.Close(rdr, comm, conn);
            }
            return false;
        }

        public GamePlayer GetAGamePlayer(string userId)
        {
            try
            {
                string sql = "select * from GamePlayer where userId ='" + userId + "'";
                GamePlayer gamePlayer = new GamePlayer();
                conn = OracleBean.GetConnection();
                conn.Open();
                comm = new OracleCommand(sql, conn);
                rdr = comm.ExecuteReader();
                if (rdr.Read())
                {
                    gamePlayer.userId = rdr.GetString(0);
                    gamePlayer.userServer = rdr.GetString(1);
                    gamePlayer.playerId = rdr.GetString(2);
                    gamePlayer.playerPrefabName = rdr.GetString(3);
                    gamePlayer.playerName = rdr.GetString(4);
                    gamePlayer.playerLevel = rdr.GetInt32(5);
                    gamePlayer.playerNowExp = rdr.GetInt32(6);
                    gamePlayer.playerUpExp = rdr.GetInt32(7);
                    gamePlayer.playerNowHP = rdr.GetInt32(8);
                    gamePlayer.playerNowMP = rdr.GetInt32(9);
                    gamePlayer.playerMoveSpeed = rdr.GetFloat(10);
                    gamePlayer.playerRunSpeed = rdr.GetFloat(11);
                    gamePlayer.playerElement = rdr.GetString(12);
                    gamePlayer.playerMaxHP = rdr.GetInt32(13);
                    gamePlayer.playerMaxMP = rdr.GetInt32(14);
                    gamePlayer.playerAttack = rdr.GetInt32(15);
                    gamePlayer.playerElementHurt = rdr.GetInt32(16);
                    gamePlayer.playerAttackHit = rdr.GetInt32(17);
                    gamePlayer.playerAttackCrit = rdr.GetInt32(18);
                    gamePlayer.playerCritHurt = rdr.GetFloat(19);
                    gamePlayer.playerDefend = rdr.GetInt32(20);
                    gamePlayer.playerAgility = rdr.GetInt32(21);
                    gamePlayer.playerMagicDefend = rdr.GetInt32(22);
                    gamePlayer.playerGCoins = rdr.GetInt32(23);
                    gamePlayer.playerSCoins = rdr.GetInt32(24);
                }
                sql = null;
                return gamePlayer;
            }
            catch (OracleException ex)
            {
                //写入错误日志
            }
            finally
            {
                OracleBean.Close(rdr, comm, conn);
            }
            return null;
        }

        public bool IsExistPlayerName(string playerName)
        {
            try
            {
                string sql = "select * from GamePlayer where playerName ='" + playerName + "'";
                GamePlayer gamePlayer = new GamePlayer();
                conn = OracleBean.GetConnection();
                conn.Open();
                comm = new OracleCommand(sql, conn);
                rdr = comm.ExecuteReader();
                if (rdr.Read())
                {
                    return true;
                }
            }
            catch (OracleException ex)
            {
                //写入错误日志
            }
            finally
            {
                OracleBean.Close(rdr, comm, conn);
            }
            return false;
        }

        public List<GamePlayer> GetServerGamePlayer(string userId)
        {
            try
            {
                string sql = "select * from GamePlayer where userId ='" + userId + "'";
                List<GamePlayer> gamePlayers = new List<GamePlayer>();
                conn = OracleBean.GetConnection();
                conn.Open();
                comm = new OracleCommand(sql, conn);
                rdr = comm.ExecuteReader();
                while (rdr.Read())
                {
                    GamePlayer gamePlayer = new GamePlayer();
                    gamePlayer.userId = rdr.GetString(0);
                    gamePlayer.userServer = rdr.GetString(1);
                    gamePlayer.playerId = rdr.GetString(2);
                    gamePlayer.playerPrefabName = rdr.GetString(3);
                    gamePlayer.playerName = rdr.GetString(4);
                    gamePlayer.playerLevel = rdr.GetInt32(5);
                    gamePlayer.playerNowExp = rdr.GetInt32(6);
                    gamePlayer.playerUpExp = rdr.GetInt32(7);
                    gamePlayer.playerNowHP = rdr.GetInt32(8);
                    gamePlayer.playerNowMP = rdr.GetInt32(9);
                    gamePlayer.playerMoveSpeed = rdr.GetFloat(10);
                    gamePlayer.playerRunSpeed = rdr.GetFloat(11);
                    gamePlayer.playerElement = rdr.GetString(12);
                    gamePlayer.playerMaxHP = rdr.GetInt32(13);
                    gamePlayer.playerMaxMP = rdr.GetInt32(14);
                    gamePlayer.playerAttack = rdr.GetInt32(15);
                    gamePlayer.playerElementHurt = rdr.GetInt32(16);
                    gamePlayer.playerAttackHit = rdr.GetInt32(17);
                    gamePlayer.playerAttackCrit = rdr.GetInt32(18);
                    gamePlayer.playerCritHurt = rdr.GetFloat(19);
                    gamePlayer.playerDefend = rdr.GetInt32(20);
                    gamePlayer.playerAgility = rdr.GetInt32(21);
                    gamePlayer.playerMagicDefend = rdr.GetInt32(22);
                    gamePlayer.playerGCoins = rdr.GetInt32(23);
                    gamePlayer.playerSCoins = rdr.GetInt32(24);
                    gamePlayers.Add(gamePlayer);
                    gamePlayer = null;
                }

                sql = null;
                return gamePlayers;
            }
            catch (OracleException ex)
            {
                //写入错误日志
            }
            finally
            {
                OracleBean.Close(rdr, comm, conn);
            }

            return null;
        }

        public List<GamePlayer> GetAllGamePlayer()
        {
            try
            {
                string sql = "select * from GamePlayer";
                List<GamePlayer> gamePlayers = new List<GamePlayer>();
                conn = OracleBean.GetConnection();
                conn.Open();
                comm = new OracleCommand(sql, conn);
                rdr = comm.ExecuteReader();
                while (rdr.Read())
                {
                    GamePlayer gamePlayer = new GamePlayer();
                    gamePlayer.userId = rdr.GetString(0);
                    gamePlayer.userServer = rdr.GetString(1);
                    gamePlayer.playerId = rdr.GetString(2);
                    gamePlayer.playerPrefabName = rdr.GetString(3);
                    gamePlayer.playerName = rdr.GetString(4);
                    gamePlayer.playerLevel = rdr.GetInt32(5);
                    gamePlayer.playerNowExp = rdr.GetInt32(6);
                    gamePlayer.playerUpExp = rdr.GetInt32(7);
                    gamePlayer.playerNowHP = rdr.GetInt32(8);
                    gamePlayer.playerNowMP = rdr.GetInt32(9);
                    gamePlayer.playerMoveSpeed = rdr.GetFloat(10);
                    gamePlayer.playerRunSpeed = rdr.GetFloat(11);
                    gamePlayer.playerElement = rdr.GetString(12);
                    gamePlayer.playerMaxHP = rdr.GetInt32(13);
                    gamePlayer.playerMaxMP = rdr.GetInt32(14);
                    gamePlayer.playerAttack = rdr.GetInt32(15);
                    gamePlayer.playerElementHurt = rdr.GetInt32(16);
                    gamePlayer.playerAttackHit = rdr.GetInt32(17);
                    gamePlayer.playerAttackCrit = rdr.GetInt32(18);
                    gamePlayer.playerCritHurt = rdr.GetFloat(19);
                    gamePlayer.playerDefend = rdr.GetInt32(20);
                    gamePlayer.playerAgility = rdr.GetInt32(21);
                    gamePlayer.playerMagicDefend = rdr.GetInt32(22);
                    gamePlayer.playerGCoins = rdr.GetInt32(23);
                    gamePlayer.playerSCoins = rdr.GetInt32(24);
                    gamePlayers.Add(gamePlayer);
                    gamePlayer = null;
                }

                sql = null;
                return gamePlayers;
            }
            catch (OracleException ex)
            {
                //写入错误日志
            }
            finally
            {
                OracleBean.Close(rdr, comm, conn);
            }

            return null;
        }

        public bool InsertGamePlayer(GamePlayer gamePlayer)
        {
            try
            {
                conn = OracleBean.GetConnection();
                conn.Open();
                string sql =
                    "insert into GamePlayer values(" +
                    "'" + gamePlayer.userId + "'," +
                    "'" + gamePlayer.userServer + "'," +
                    "'" + gamePlayer.playerId + "'," +
                    "'" + gamePlayer.playerPrefabName + "'," +
                    "'" + gamePlayer.playerName + "'," +
                    "'" + gamePlayer.playerLevel + "'," +
                    "'" + gamePlayer.playerNowExp + "'," +
                    "'" + gamePlayer.playerUpExp + "'," +
                    "'" + gamePlayer.playerNowHP + "'," +
                    "'" + gamePlayer.playerNowMP + "'," +
                    "'" + gamePlayer.playerMoveSpeed + "'," +
                    "'" + gamePlayer.playerRunSpeed + "'," +
                    "'" + gamePlayer.playerElement + "'," +
                    "'" + gamePlayer.playerMaxHP + "'," +
                    "'" + gamePlayer.playerMaxMP + "'," +
                    "'" + gamePlayer.playerAttack + "'," +
                    "'" + gamePlayer.playerElementHurt + "'," +
                    "'" + gamePlayer.playerAttackHit + "'," +
                    "'" + gamePlayer.playerAttackCrit + "'," +
                    "'" + gamePlayer.playerCritHurt + "'," +
                    "'" + gamePlayer.playerDefend + "'," +
                    "'" + gamePlayer.playerAgility + "'," +
                    "'" + gamePlayer.playerMagicDefend + "'," +
                    "'" + gamePlayer.playerGCoins + "'," +
                    "'" + gamePlayer.playerSCoins + "')";

                comm = new OracleCommand(sql, conn);
                sql = null;

                return comm.ExecuteNonQuery() > 0;
            }
            catch (OracleException ex)
            {
                //写入错误日志
            }
            finally
            {
                OracleBean.Close(rdr, comm, conn);
            }
            return false;
        }

        public bool UpdateGamePlayer(GamePlayer gamePlayer)
        {
            try
            {
                conn = OracleBean.GetConnection();
                conn.Open();
                string sql =
                    "update GamePlayer set " +
                    "userId ='" + gamePlayer.userId + "', " +
                    "userServer ='" + gamePlayer.userServer + "', " +
                    "playerPrefab ='" + gamePlayer.playerPrefabName + "', " +
                    "playerName ='" + gamePlayer.playerName + "', " +
                    "playerLevel ='" + gamePlayer.playerLevel + "', " +
                    "playerNowExp ='" + gamePlayer.playerNowExp + "', " +
                    "playerUpExp ='" + gamePlayer.playerUpExp + "', " +
                    "playerNowHP ='" + gamePlayer.playerNowHP + "', " +
                    "playerNowMP ='" + gamePlayer.playerNowMP + "', " +
                    "playerMoveSpeed ='" + gamePlayer.playerMoveSpeed + "', " +
                    "playerRunSpeed ='" + gamePlayer.playerRunSpeed + "', " +
                    "playerElement ='" + gamePlayer.playerElement + "', " +
                    "playerMaxHP ='" + gamePlayer.playerMaxHP + "', " +
                    "playerMaxMP ='" + gamePlayer.playerMaxMP + "', " +
                    "playerAttack ='" + gamePlayer.playerAttack + "', " +
                    "playerElementHurt ='" + gamePlayer.playerElementHurt + "', " +
                    "playerAttackHit ='" + gamePlayer.playerAttackHit + "', " +
                    "playerAttackCrit ='" + gamePlayer.playerAttackCrit + "', " +
                    "playerCritHurt ='" + gamePlayer.playerCritHurt + "', " +
                    "playerDefend ='" + gamePlayer.playerDefend + "', " +
                    "playerAgility ='" + gamePlayer.playerAgility + "', " +
                    "playerMagicDefend ='" + gamePlayer.playerMagicDefend + "' " +
                    "playerGCoins ='" + gamePlayer.playerGCoins + "' " +
                    "playerSCoins ='" + gamePlayer.playerSCoins + "' " +
                    "where playerId ='" + gamePlayer.playerId + "'";
                Console.WriteLine(sql);

                comm = new OracleCommand(sql, conn);
                sql = null;
                return comm.ExecuteNonQuery() > 0;
            }
            catch (OracleException ex)
            {
                //写入错误日志
            }
            finally
            {
                OracleBean.Close(rdr, comm, conn);
            }
            return false;
        }
    }
}
