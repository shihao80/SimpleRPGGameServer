using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace DataBase
{
    public class GameGoodDaoImp : GameGoodDao
    {
        OracleConnection conn = null;
        OracleCommand comm = null;
        OracleDataReader rdr = null;

        public bool DeleteGameGood(string playerId)
        {
            try
            {
                conn = OracleBean.GetConnection();
                conn.Open();
                string sql = "delete from GameGood where playerId ='" + playerId + "'";
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


        public bool DeleteGameGood(string playerId, int goodId)
        {
            try
            {
                conn = OracleBean.GetConnection();
                conn.Open();
                string sql = "delete from GameGood where playerId ='"+ playerId + "' and goodId =" + goodId ;
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

        public GameGood GetAGameGood(string playerId, int goodId)
        {
            try
            {
                string sql = "select * from GameGood where playerId ='" + playerId + "' and goodId =" + goodId;

                GameGood gameGood = new GameGood();
                conn = OracleBean.GetConnection();
                conn.Open();
                comm = new OracleCommand(sql, conn);
                rdr = comm.ExecuteReader();
                if (rdr.Read())
                {
                    gameGood.playerId = rdr.GetString(0);
                    gameGood.goodId = rdr.GetInt32(1);
                    gameGood.goodName = rdr.GetString(2);
                    gameGood.goodDescrip = rdr.GetString(3);
                    gameGood.goodBuyPrice = rdr.GetInt32(4);
                    gameGood.goodSellPrice = rdr.GetInt32(5);
                    gameGood.goodIconPath = rdr.GetString(6);
                    gameGood.goodItemType = rdr.GetString(7);
                    gameGood.goodCount = rdr.GetInt32(8);
                    gameGood.goodType = rdr.GetString(9);
                    gameGood.goodEquip = rdr.GetString(10);
                    gameGood.ArmorBlood = rdr.GetInt32(11);
                    gameGood.ArmorDefend = rdr.GetInt32(12);
                    gameGood.ArmorAgility = rdr.GetInt32(13);
                    gameGood.ConsumableBcakHP = rdr.GetInt32(14);
                    gameGood.ConsumableBcakMP = rdr.GetInt32(15);
                    gameGood.WeaponDamage = rdr.GetInt32(16);
                    gameGood.WeaponMP = rdr.GetInt32(17);
                }
                sql = null;
                return gameGood;
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

        public List<GameGood> GetAllGameGood()
        {
            try
            {
                string sql = "select * from GameGood";
                List<GameGood> gameGoods = new List<GameGood>();
                conn = OracleBean.GetConnection();
                conn.Open();
                comm = new OracleCommand(sql, conn);
                rdr = comm.ExecuteReader();
                while (rdr.Read())
                {
                    GameGood gameGood = new GameGood();
                    gameGood.playerId = rdr.GetString(0);
                    gameGood.goodId = rdr.GetInt32(1);
                    gameGood.goodName = rdr.GetString(2);
                    gameGood.goodDescrip = rdr.GetString(3);
                    gameGood.goodBuyPrice = rdr.GetInt32(4);
                    gameGood.goodSellPrice = rdr.GetInt32(5);
                    gameGood.goodIconPath = rdr.GetString(6);
                    gameGood.goodItemType = rdr.GetString(7);
                    gameGood.goodCount = rdr.GetInt32(8);
                    gameGood.goodType = rdr.GetString(9);
                    gameGood.goodEquip = rdr.GetString(10);
                    gameGood.ArmorBlood = rdr.GetInt32(11);
                    gameGood.ArmorDefend = rdr.GetInt32(12);
                    gameGood.ArmorAgility = rdr.GetInt32(13);
                    gameGood.ConsumableBcakHP = rdr.GetInt32(14);
                    gameGood.ConsumableBcakMP = rdr.GetInt32(15);
                    gameGood.WeaponDamage = rdr.GetInt32(16);
                    gameGood.WeaponMP = rdr.GetInt32(17);
                    gameGoods.Add(gameGood);
                    gameGood = null;
                }

                sql = null;
                return gameGoods;
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

        public List<GameGood> GetAllGamePlayerGameGood(string playerId)
        {
            try
            {
                string sql = "select * from GameGood where playerId ='" + playerId + "'";
                List<GameGood> gameGoods = new List<GameGood>();
                conn = OracleBean.GetConnection();
                conn.Open();
                comm = new OracleCommand(sql, conn);
                rdr = comm.ExecuteReader();
                while (rdr.Read())
                {
                    GameGood gameGood = new GameGood();
                    gameGood.playerId = rdr.GetString(0);
                    gameGood.goodId = rdr.GetInt32(1);
                    gameGood.goodName = rdr.GetString(2);
                    gameGood.goodDescrip = rdr.GetString(3);
                    gameGood.goodBuyPrice = rdr.GetInt32(4);
                    gameGood.goodSellPrice = rdr.GetInt32(5);
                    gameGood.goodIconPath = rdr.GetString(6);
                    gameGood.goodItemType = rdr.GetString(7);
                    gameGood.goodCount = rdr.GetInt32(8);
                    gameGood.goodType = rdr.GetString(9);
                    gameGood.goodEquip = rdr.GetString(10);
                    gameGood.ArmorBlood = rdr.GetInt32(11);
                    gameGood.ArmorDefend = rdr.GetInt32(12);
                    gameGood.ArmorAgility = rdr.GetInt32(13);
                    gameGood.ConsumableBcakHP = rdr.GetInt32(14);
                    gameGood.ConsumableBcakMP = rdr.GetInt32(15);
                    gameGood.WeaponDamage = rdr.GetInt32(16);
                    gameGood.WeaponMP = rdr.GetInt32(17);
                    gameGoods.Add(gameGood);
                    gameGood = null;
                }

                sql = null;
                return gameGoods;
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

        public bool InsertGameGood(GameGood gameGood)
        {
            try
            {
                conn = OracleBean.GetConnection();
                conn.Open();
                string sql =
                    "insert into GameGood values(" +
                    "'" + gameGood.playerId + "'," +
                    "'" + gameGood.goodId + "'," +
                    "'" + gameGood.goodName + "'," +
                    "'" + gameGood.goodDescrip + "'," +
                    "'" + gameGood.goodBuyPrice + "'," +
                    "'" + gameGood.goodSellPrice + "'," +
                    "'" + gameGood.goodIconPath + "'," +
                    "'" + gameGood.goodItemType + "'," +
                    "'" + gameGood.goodCount + "'," +
                    "'" + gameGood.goodType + "'," +
                    "'" + gameGood.goodEquip + "'," +
                    "'" + gameGood.ArmorBlood + "'," +
                    "'" + gameGood.ArmorDefend + "'," +
                    "'" + gameGood.ArmorAgility + "'," +
                    "'" + gameGood.ConsumableBcakHP + "'," +
                    "'" + gameGood.ConsumableBcakMP + "'," +
                    "'" + gameGood.WeaponDamage + "'," +
                    "'" + gameGood.WeaponMP + "')";

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

        public bool UpdateGameGood(GameGood gameGood)
        {
            try
            {
                conn = OracleBean.GetConnection();
                conn.Open();
                string sql =
                    "update GameGood set " +
                    "goodName ='" + gameGood.goodName + "', " +
                    "goodDescrip ='" + gameGood.goodDescrip + "', " +
                    "goodBuyPrice ='" + gameGood.goodBuyPrice + "', " +
                    "goodSellPrice ='" + gameGood.goodSellPrice + "', " +
                    "goodIconPath ='" + gameGood.goodIconPath + "', " +
                    "goodItemType ='" + gameGood.goodItemType + "', " +
                    "goodCount ='" + gameGood.goodCount + "', " +
                    "goodType ='" + gameGood.goodType + "', " +
                    "goodEquip ='" + gameGood.goodEquip + "', " +
                    "ArmorBlood ='" + gameGood.ArmorBlood + "', " +
                    "ArmorDefend ='" + gameGood.ArmorDefend + "', " +
                    "ArmorAgility ='" + gameGood.ArmorAgility + "', " +
                    "ConsumableBcakHP ='" + gameGood.ConsumableBcakHP + "', " +
                    "ConsumableBcakMP ='" + gameGood.ConsumableBcakMP + "', " +
                    "WeaponDamage ='" + gameGood.WeaponDamage + "', " +
                    "WeaponMP ='" + gameGood.WeaponMP + "', " +
                    "where playerId = '" + gameGood.playerId + "' and goodId = " + gameGood.goodId;

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
