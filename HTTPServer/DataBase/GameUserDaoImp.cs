using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace DataBase
{
    public class GameUserDaoImp : GameUserDao
    {
        OracleConnection conn = null;
        OracleCommand comm = null;
        OracleDataReader rdr = null;

        public bool DeleteGameUser(GameUser gameUser)
        {
            try
            {
                conn = OracleBean.GetConnection();
                conn.Open();
                string sql = "delete from GameUser where userId ='" + gameUser.userId + "'";
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

        public GameUser GetAGameUser(string userId)
        {
            try
            {
                string sql = "select * from gameUser where userId ='" + userId + "'";
                GameUser gameUser = new GameUser();
                conn = OracleBean.GetConnection();
                conn.Open();
                comm = new OracleCommand(sql, conn);
                rdr = comm.ExecuteReader();
                if (rdr.Read())
                {
                    gameUser.userId = rdr.GetString(0);
                    gameUser.userPwd = rdr.GetString(1);
                    gameUser.userName = rdr.GetString(2);
                }
                sql = null;
                return gameUser;
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

        public List<GameUser> GetAllGameUser()
        {
            try
            {
                string sql = "select * from gameUser";
                List<GameUser> gameUsers = new List<GameUser>();
                conn = OracleBean.GetConnection();
                conn.Open();
                comm = new OracleCommand(sql, conn);
                rdr = comm.ExecuteReader();
                while (rdr.Read())
                {
                    GameUser gameUser = new GameUser();
                    gameUser.userId = rdr.GetString(0);
                    gameUser.userPwd = rdr.GetString(1);
                    gameUser.userName = rdr.GetString(2);
                    gameUsers.Add(gameUser);
                    gameUser = null;
                }

                sql = null;
                return gameUsers;
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
        public GameUser Login(string userId, string userPwd)
        {
            try
            {
                string sql = "select * from gameUser where userId ='" + userId + "' and userPwd ='" + userPwd  + "'";
                GameUser gameUser = new GameUser();
                conn = OracleBean.GetConnection();
                conn.Open();
                comm = new OracleCommand(sql, conn);
                rdr = comm.ExecuteReader();
                if (rdr.Read())
                {
                    gameUser.userId = rdr.GetString(0);
                    gameUser.userPwd = rdr.GetString(1);
                    gameUser.userName = rdr.GetString(2);
                }
                sql = null;
                return gameUser;
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

        public bool InsertGameUser(GameUser gameUser)
        {
            try
            {
                conn = OracleBean.GetConnection();
                conn.Open();
                string sql =
                    "insert into GameUser values( " +
                    "'" + gameUser.userId + "'," +
                    "'" + gameUser.userPwd + "'," +
                    "'" + gameUser.userName + "')";
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

        public bool UpdateGameUser(GameUser gameUser)
        {
            try
            {
                conn = OracleBean.GetConnection();
                conn.Open();
                string sql =
                    "update GameUser set " +
                    "userPwd ='" + gameUser.userPwd + "' " +
                    "userName = '" + gameUser.userName + " " +
                    "where userId ='" + gameUser.userId + "'";

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
