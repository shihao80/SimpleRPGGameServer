using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTTPServerLib;
using System.IO;
using DataBase;

namespace HttpServer
{
    public class ExampleServer : HTTPServerLib.HttpServer
    {
        private static string path = "D:\\HttpServer-master\\Log.txt";

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ipAddress">IP地址</param>
        /// <param name="port">端口号</param>
        public ExampleServer(string ipAddress, int port)
            : base(ipAddress, port)
        {
        }

        public override void OnPost(HttpRequest request, HttpResponse response)
        {

            int statusCode = 400;
            statusCode++;
            string requestType = "";
            string content = "";
            if (request == null)
            {
                Log("null");
                return;
            }

            // try
            //{
            //获取客户端传递的参数
            requestType = request.Params[@"requestType"];
            // 设置返回信息

            if (requestType != null && requestType != "")
            {
                switch (requestType)
                {
                    case "GetAGameUser":
                        {
                            string userId = request.Params["userId"];
                            string userPwd = request.Params["userPwd"];
                            if (userId != null && userId != "" && userPwd != null && userPwd != "")
                            {
                                GameUser gameUser = DaoFactory.GetGameUserDaoImp().Login(userId, userPwd);
                                if (gameUser != null && gameUser.userId != null && gameUser.userId != "")
                                {
                                    content = gameUser.userId + "@@@" + gameUser.userName + "@@@" + gameUser.userPwd;
                                }
                            }
                        }
                        break;

                    case "GetAGamePlayer":
                        {
                            string userId = request.Params["userId"];
                            if (userId != null && userId != "")
                            {
                                GamePlayer gamePlayer = DaoFactory.GetGamePlayerDaoImp().GetAGamePlayer(userId);
                                if (gamePlayer != null)
                                {
                                    content = gamePlayer.userId + "@@@" +
                                    gamePlayer.userServer + "@@@" +
                                    gamePlayer.playerId + "@@@" +
                                    gamePlayer.playerName + "@@@" +
                                    gamePlayer.playerLevel + "@@@" +
                                    gamePlayer.playerNowExp + "@@@" +
                                    gamePlayer.playerUpExp + "@@@" +
                                    gamePlayer.playerNowHP + "@@@" +
                                    gamePlayer.playerNowMP + "@@@" +
                                    gamePlayer.playerMoveSpeed + "@@@" +
                                    gamePlayer.playerRunSpeed + "@@@" +
                                    gamePlayer.playerElement + "@@@" +
                                    gamePlayer.playerMaxHP + "@@@" +
                                    gamePlayer.playerMaxMP + "@@@" +
                                    gamePlayer.playerAttack + "@@@" +
                                    gamePlayer.playerElementHurt + "@@@" +
                                    gamePlayer.playerAttackHit + "@@@" +
                                    gamePlayer.playerAttackCrit + "@@@" +
                                    gamePlayer.playerCritHurt + "@@@" +
                                    gamePlayer.playerDefend + "@@@" +
                                    gamePlayer.playerAgility + "@@@" +
                                    gamePlayer.playerMagicDefend;
                                }
                            }
                        }
                        break;

                    default:
                        Log("参数解析错误");
                        break;
                }
            }
            //构造响应报文
            response.SetContent(content);
            response.Content_Encoding = "utf-8";
            response.StatusCode = statusCode.ToString();
            response.Content_Type = "text/html; charset=UTF-8";
            response.Headers["Server"] = "ExampleServer";

            //发送响应
            response.Send();
            statusCode++;
            //}
            //catch (Exception ex)
            //{
            //    Log(ex);
            //}
            //finally
            //{

            //}
        }

        public override void OnGet(HttpRequest request, HttpResponse response)
        {
            int statusCode = 400;
            string requestType = "";
            string content = "";

            try
            {
                //获取客户端传递的参数
                requestType = request.Params["requestType"];
                // 设置返回信息

                if (requestType != null && requestType != "")
                {
                    switch (requestType)
                    {
                        case "LinkServer":
                            {
                                string link = request.Params["link"];
                                if (link != null && link == "link")
                                {
                                    content = "LinkServer Success";
                                }
                                else
                                {
                                    content = "LinkServer Failed";
                                }
                            }
                            break;

                        case "Login":
                            {
                                string userId = request.Params["userId"];
                                string userPwd = request.Params["userPwd"];
                                if (userId != null && userId != "" && userPwd != null && userPwd != "")
                                {
                                    GameUser gameUser = DaoFactory.GetGameUserDaoImp().Login(userId, userPwd);
                                    if (gameUser != null && gameUser.userId != null)
                                    {
                                        if (gameUser.userId != "")
                                            content = gameUser.userId + "@@@" + gameUser.userPwd + "@@@" + gameUser.userName;
                                        else
                                        {
                                            content = "Login Failed";
                                        }
                                    }
                                    else
                                    {
                                        content = "Login Failed";
                                    }
                                }
                            }
                            break;

                        case "InsertGameUser":
                            {
                                string userId = request.Params["userId"];
                                string userPwd = request.Params["userPwd"];
                                if (userId != null && userId != "" && userPwd != null && userPwd != "")
                                {
                                    GameUser gameUser = new GameUser(userId, userPwd, "默认名字");
                                    bool isInsert = DaoFactory.GetGameUserDaoImp().InsertGameUser(gameUser);
                                    if (isInsert)
                                    {
                                        content = "InsertGameUser Success";
                                    }
                                    else
                                    {
                                        content = "InsertGameUser Failed";
                                    }
                                }
                                else
                                {
                                    content = "InsertGameUser Failed";
                                }
                            }
                            break;

                        case "GetAGamePlayer":
                            {
                                string userId = request.Params["userId"];
                                if (userId != null && userId != "")
                                {
                                    GamePlayer gamePlayer = DaoFactory.GetGamePlayerDaoImp().GetAGamePlayer(userId);
                                    if (gamePlayer != null && gamePlayer.userId != null)
                                    {
                                        if (gamePlayer.userId != "")
                                        {
                                            content = gamePlayer.userId + "@@@" +
                                            gamePlayer.userServer + "@@@" +
                                            gamePlayer.playerId + "@@@" +
                                            gamePlayer.playerPrefabName + "@@@" +
                                            gamePlayer.playerName + "@@@" +
                                            gamePlayer.playerLevel + "@@@" +
                                            gamePlayer.playerNowExp + "@@@" +
                                            gamePlayer.playerUpExp + "@@@" +
                                            gamePlayer.playerNowHP + "@@@" +
                                            gamePlayer.playerNowMP + "@@@" +
                                            gamePlayer.playerMoveSpeed + "@@@" +
                                            gamePlayer.playerRunSpeed + "@@@" +
                                            gamePlayer.playerElement + "@@@" +
                                            gamePlayer.playerMaxHP + "@@@" +
                                            gamePlayer.playerMaxMP + "@@@" +
                                            gamePlayer.playerAttack + "@@@" +
                                            gamePlayer.playerElementHurt + "@@@" +
                                            gamePlayer.playerAttackHit + "@@@" +
                                            gamePlayer.playerAttackCrit + "@@@" +
                                            gamePlayer.playerCritHurt + "@@@" +
                                            gamePlayer.playerDefend + "@@@" +
                                            gamePlayer.playerAgility + "@@@" +
                                            gamePlayer.playerMagicDefend;
                                        }
                                        else
                                        {
                                            content = "GetAGamePlayer Failed";
                                        }
                                    }
                                    else
                                    {
                                        content = "GetAGamePlayer Failed";
                                    }
                                }
                            }
                            break;

                        case "GetGamePlayers":
                            {
                                string userId = request.Params["userId"];
                                if (userId != null && userId != "")
                                {
                                    List<GamePlayer> gamePlayers = DaoFactory.GetGamePlayerDaoImp().GetServerGamePlayer(userId);
                                    GamePlayer gamePlayer = DaoFactory.GetGamePlayerDaoImp().GetAGamePlayer(userId);
                                    if (gamePlayer != null && gamePlayer.userId != null)
                                    {
                                        if (gamePlayer.userId != "")
                                        {
                                            content = gamePlayer.userId + "@@@" +
                                            gamePlayer.userServer + "@@@" +
                                            gamePlayer.playerId + "@@@" +
                                            gamePlayer.playerPrefabName + "@@@" +
                                            gamePlayer.playerName + "@@@" +
                                            gamePlayer.playerLevel + "@@@" +
                                            gamePlayer.playerNowExp + "@@@" +
                                            gamePlayer.playerUpExp + "@@@" +
                                            gamePlayer.playerNowHP + "@@@" +
                                            gamePlayer.playerNowMP + "@@@" +
                                            gamePlayer.playerMoveSpeed + "@@@" +
                                            gamePlayer.playerRunSpeed + "@@@" +
                                            gamePlayer.playerElement + "@@@" +
                                            gamePlayer.playerMaxHP + "@@@" +
                                            gamePlayer.playerMaxMP + "@@@" +
                                            gamePlayer.playerAttack + "@@@" +
                                            gamePlayer.playerElementHurt + "@@@" +
                                            gamePlayer.playerAttackHit + "@@@" +
                                            gamePlayer.playerAttackCrit + "@@@" +
                                            gamePlayer.playerCritHurt + "@@@" +
                                            gamePlayer.playerDefend + "@@@" +
                                            gamePlayer.playerAgility + "@@@" +
                                            gamePlayer.playerMagicDefend;
                                        }
                                        else
                                        {
                                            content = "GetAGamePlayer Failed";
                                        }
                                    }
                                    else
                                    {
                                        content = "GetAGamePlayer Failed";
                                    }
                                }
                            }
                            break;
                        case "GetServerGamePlayer":
                            {
                                string userId = request.Params["userId"];
                                if (userId != null && userId != "")
                                {
                                    List<GamePlayer> gamePlayers = DaoFactory.GetGamePlayerDaoImp().GetServerGamePlayer(userId);
                                    if (gamePlayers.Count > 0)
                                    {
                                        for (int i = 0; i < gamePlayers.Count; i++)
                                        {
                                            content += gamePlayers[i].userId + "@@@" +
                                                gamePlayers[i].userServer + "@@@" +
                                                gamePlayers[i].playerId + "@@@" +
                                                gamePlayers[i].playerPrefabName + "@@@" +
                                                gamePlayers[i].playerName + "@@@" +
                                                gamePlayers[i].playerLevel + "@@@" +
                                                gamePlayers[i].playerNowExp + "@@@" +
                                                gamePlayers[i].playerUpExp + "@@@" +
                                                gamePlayers[i].playerNowHP + "@@@" +
                                                gamePlayers[i].playerNowMP + "@@@" +
                                                gamePlayers[i].playerMoveSpeed + "@@@" +
                                                gamePlayers[i].playerRunSpeed + "@@@" +
                                                gamePlayers[i].playerElement + "@@@" +
                                                gamePlayers[i].playerMaxHP + "@@@" +
                                                gamePlayers[i].playerMaxMP + "@@@" +
                                                gamePlayers[i].playerAttack + "@@@" +
                                                gamePlayers[i].playerElementHurt + "@@@" +
                                                gamePlayers[i].playerAttackHit + "@@@" +
                                                gamePlayers[i].playerAttackCrit + "@@@" +
                                                gamePlayers[i].playerCritHurt + "@@@" +
                                                gamePlayers[i].playerDefend + "@@@" +
                                                gamePlayers[i].playerAgility + "@@@" +
                                                gamePlayers[i].playerMagicDefend + "@@@" +
                                                gamePlayers[i].playerGCoins + "@@@" +
                                                gamePlayers[i].playerSCoins + "@@@";
                                        }
                                        content += gamePlayers.Count.ToString();
                                    }
                                    else
                                    {
                                        content = "GetServerGamePlayer Failed";
                                    }
                                }
                            }
                            break;
                        case "InsertGamePlayer":
                            {
                                string userId = request.Params["userId"];
                                string userServer = request.Params["userServer"];
                                string playerId = request.Params["playerId"];
                                string playerPrefabName = request.Params["playerPrefabName"];
                                string playerName = request.Params["playerName"];

                                if (DaoFactory.GetGamePlayerDaoImp().IsExistPlayerName(playerName)){
                                    content = "Duplicate PlayerName";
                                    break;
                                }

                                GamePlayer gamePlayer = null;
                                switch (playerPrefabName)
                                {
                                    case "Eri":
                                    case "Naoko":
                                    case "Riko":
                                        gamePlayer = new GamePlayer(userId, userServer, playerId, playerPrefabName, playerName,
                                          PlayerBasicData.playerLevel,
                                          PlayerBasicData.playerNowExp,
                                          PlayerBasicData.playerUpExp,
                                          PlayerBasicData.playerNowHP,
                                          (int)(PlayerBasicData.playerNowMP * PlayerBasicData.SwordBsic),
                                          PlayerBasicData.playerMoveSpeed,
                                          PlayerBasicData.playerRunSpeed,
                                          PlayerBasicData.playerElement,
                                          PlayerBasicData.playerMaxHP,
                                          (int)(PlayerBasicData.playerMaxMP * PlayerBasicData.SwordBsic),
                                          PlayerBasicData.playerAttack,
                                          PlayerBasicData.playerElementHurt,
                                          PlayerBasicData.playerAttackHit,
                                          PlayerBasicData.playerAttackCrit,
                                          PlayerBasicData.playerCritHurt,
                                          PlayerBasicData.playerDefend,
                                          PlayerBasicData.playerAgility,
                                          PlayerBasicData.playerMagicDefend,
                                          PlayerBasicData.playerGCoins,
                                          PlayerBasicData.playerSCoins);
                                        break;

                                    case "BladeM":
                                    case "BladeW":
                                        gamePlayer = new GamePlayer(userId, userServer, playerId, playerPrefabName, playerName,
                                          PlayerBasicData.playerLevel,
                                          PlayerBasicData.playerNowExp,
                                          PlayerBasicData.playerUpExp,
                                          (int)(PlayerBasicData.playerNowHP * PlayerBasicData.SwordBsic),
                                          PlayerBasicData.playerNowMP,
                                          PlayerBasicData.playerMoveSpeed,
                                          PlayerBasicData.playerRunSpeed,
                                          PlayerBasicData.playerElement,
                                          (int)(PlayerBasicData.playerMaxHP * PlayerBasicData.SwordBsic),
                                          PlayerBasicData.playerMaxMP,
                                          PlayerBasicData.playerAttack,
                                          PlayerBasicData.playerElementHurt,
                                          PlayerBasicData.playerAttackHit,
                                          PlayerBasicData.playerAttackCrit,
                                          PlayerBasicData.playerCritHurt,
                                          (int)(PlayerBasicData.playerDefend * PlayerBasicData.SwordBsic),
                                          (int)(PlayerBasicData.playerAgility * PlayerBasicData.SwordBsic),
                                          PlayerBasicData.playerMagicDefend,
                                          PlayerBasicData.playerGCoins,
                                          PlayerBasicData.playerSCoins);
                                        break;
                                }

                                if (userId != null && userId != "")
                                {
                                    if (gamePlayer != null)
                                    {
                                        DaoFactory.GetGamePlayerDaoImp().InsertGamePlayer(gamePlayer);
                                        if (gamePlayer.playerId != null && gamePlayer.playerId != "")
                                        {
                                            content = "InsertGamePlayer Success";

                                            switch (playerPrefabName)
                                            {
                                                case "Eri":
                                                case "Naoko":
                                                case "Riko":
                                                    DaoFactory.GetGameGoodDaoImp().InsertGameGood(GoodBasicData.GetGood_Magic_Weapon_武器(playerId, 0));

                                                    break;

                                                case "BladeM":
                                                case "BladeW":
                                                    DaoFactory.GetGameGoodDaoImp().InsertGameGood(GoodBasicData.GetGood_Sword_Weapon_武器(playerId, 0));

                                                    break;
                                            }
                                            DaoFactory.GetGameGoodDaoImp().InsertGameGood(GoodBasicData.GetGood_Weapon_首饰(playerId, 1));
                                            DaoFactory.GetGameGoodDaoImp().InsertGameGood(GoodBasicData.GetGood_Consumable_HP(playerId, 2));
                                            DaoFactory.GetGameGoodDaoImp().InsertGameGood(GoodBasicData.GetGood_Consumable_MP(playerId, 3));
                                            DaoFactory.GetGameGoodDaoImp().InsertGameGood(GoodBasicData.GetGood_Armor_上衣(playerId, 4));
                                        }
                                        else
                                        {
                                            content = "InsertGamePlayer Failed";
                                        }
                                    }
                                    else
                                    {
                                        content = "InsertGamePlayer Failed";
                                    }
                                }
                            }
                            break;

                        case "DeleteGamePlayer":
                            {
                                string playerId = request.Params["playerId"];

                                if (playerId != null && playerId != "")
                                {
                                    bool isDelete = DaoFactory.GetGamePlayerDaoImp().DeleteGamePlayer(playerId);
                                    if (isDelete)
                                    {
                                        content = "DeleteGamePlayer Success";
                                        DaoFactory.GetGameGoodDaoImp().DeleteGameGood(playerId);
                                    }
                                    else
                                    {
                                        content = "DeleteGamePlayer Failed";
                                    }
                                }
                            }
                            break;

                        case "GetAllGamePlayerGameGood":
                            {
                                string playerId = request.Params["playerId"];
                                List<GameGood> gameGoods = DaoFactory.GetGameGoodDaoImp().GetAllGamePlayerGameGood(playerId);
                                if (playerId != null && playerId != "")
                                {
                                    if (gameGoods != null && gameGoods.Count >= 0)
                                    {
                                        for (int i = 0; i < gameGoods.Count; i++)
                                        {
                                            content +=
                                                  gameGoods[i].goodId + "@@@" +
                                                  gameGoods[i].goodName + "@@@" +
                                                  gameGoods[i].goodDescrip + "@@@" +
                                                  gameGoods[i].goodBuyPrice + "@@@" +
                                                  gameGoods[i].goodSellPrice + "@@@" +
                                                  gameGoods[i].goodIconPath + "@@@" +
                                                  gameGoods[i].goodItemType + "@@@" +
                                                  gameGoods[i].goodCount + "@@@" +
                                                  gameGoods[i].goodType + "@@@" +
                                                  gameGoods[i].goodEquip + "@@@" +
                                                  gameGoods[i].ArmorBlood + "@@@" +
                                                  gameGoods[i].ArmorDefend + "@@@" +
                                                  gameGoods[i].ArmorAgility + "@@@" +
                                                  gameGoods[i].ConsumableBcakHP + "@@@" +
                                                  gameGoods[i].ConsumableBcakMP + "@@@" +
                                                  gameGoods[i].WeaponDamage + "@@@";
                                            if (i == gameGoods.Count - 1)
                                            {
                                                content += gameGoods[i].WeaponMP;
                                            }
                                            else
                                            {
                                                content += gameGoods[i].WeaponMP + "@@@";
                                            }

                                        }
                                    }
                                    else
                                    {
                                        content = "GetAllGamePlayerGameGood Failed";
                                    }
                                }
                                else
                                {
                                    content = "GetAllGamePlayerGameGood Failed";
                                }
                            }
                            break;

                        default:
                            Log("参数解析错误");
                            break;
                    }
                }

                StreamWriter sw = new StreamWriter(path, true);
                sw.WriteLine("[" + DateTime.Now + "] request: " + requestType + " response: " + content);
                sw.Close();

                //构造响应报文
                response.SetContent(content);
                response.Content_Encoding = "utf-8";
                response.StatusCode = statusCode.ToString();
                response.Content_Type = "text/html; charset=UTF-8";
                response.Headers["Server"] = "ExampleServer";
                //发送响应
                response.Send();

            }
            catch (Exception ex)
            {
                Log(ex);
            }
            finally
            {
                statusCode++;
                requestType = "";
                content = "";
            }
        }

        public override void OnDefault(HttpRequest request, HttpResponse response)
        {

        }
    }
}
