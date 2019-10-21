using System.Net;
using System.Net.Sockets;
using System.Threading;
using System;
using DataBase;
using System.IO;
using System.Collections.Generic;

namespace SocketServer
{
    public class SocketServ
    {
        private static byte[] result = new byte[1024 * 1024];
        private static int port = 8765;
        private static string IpStr = "127.0.0.1";
        private static Socket serverSocket;


        private static string path = "D:\\HttpServer-master\\Log.txt";


        public SocketServ()
        {
            IPAddress ip = IPAddress.Parse(IpStr);
            IPEndPoint ip_end_point = new IPEndPoint(ip, port);
            //创建服务器Socket对象，并设置相关属性
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //绑定ip和端口
            serverSocket.Bind(ip_end_point);
            //设置最长的连接请求队列长度
            serverSocket.Listen(10);
            Console.WriteLine("RPG游戏Socket服务器启动成功:{0}", serverSocket.LocalEndPoint.ToString());
            //在新线程中监听客户端的连接
            Thread thread = new Thread(ClientConnectListen);
            thread.Start();
        }

        public SocketServ(int putPort)
        {
            port = putPort;

            IPAddress ip = IPAddress.Parse(IpStr);
            IPEndPoint ip_end_point = new IPEndPoint(ip, port);
            //创建服务器Socket对象，并设置相关属性
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //绑定ip和端口
            serverSocket.Bind(ip_end_point);
            //设置最长的连接请求队列长度
            serverSocket.Listen(10);
            Console.WriteLine("RPG游戏Socket服务器启动成功:{0}", serverSocket.LocalEndPoint.ToString());
            //在新线程中监听客户端的连接
            Thread thread = new Thread(ClientConnectListen);
            thread.Start();
        }

        public SocketServ(string putIp, int putPort)
        {
            IpStr = putIp;
            port = putPort;

            IPAddress ip = IPAddress.Parse(IpStr);
            IPEndPoint ip_end_point = new IPEndPoint(ip, port);
            //创建服务器Socket对象，并设置相关属性
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //绑定ip和端口
            serverSocket.Bind(ip_end_point);
            //设置最长的连接请求队列长度
            serverSocket.Listen(10);
            Console.WriteLine("RPG游戏Socket服务器启动成功:{0}", serverSocket.LocalEndPoint.ToString());
            //在新线程中监听客户端的连接
            Thread thread = new Thread(ClientConnectListen);
            thread.Start();
        }

        /// <summary>
        /// 客户端连接请求监听
        /// </summary>
        private static void ClientConnectListen()
        {
            while (true)
            {
                //为新的客户端连接创建一个Socket对象
                Socket clientSocket = serverSocket.Accept();
                //每个客户端连接创建一个线程来接受该客户端发送的消息
                Thread thread = new Thread(RecieveMessage);
                thread.Start(clientSocket);
            }
        }

        /// <summary>
        /// 向客户端发送信息
        /// </summary>
        private static void SendClientMessage(Socket clientSocket, string data)
        {
            //向连接的客户端发送连接成功的数据
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteString(data);
            clientSocket.Send(WriteMessage(buffer.ToBytes()));
        }

        /// <summary>
        /// 数据转换，网络发送需要两部分数据，一是数据长度，二是主体数据
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private static byte[] WriteMessage(byte[] message)
        {
            MemoryStream ms = null;
            using (ms = new MemoryStream())
            {
                ms.Position = 0;
                BinaryWriter writer = new BinaryWriter(ms);
                ushort msglen = (ushort)message.Length;
                writer.Write(msglen);
                writer.Write(message);
                writer.Flush();
                return ms.ToArray();
            }
        }

        /// <summary>
        /// 接收指定客户端Socket的消息
        /// </summary>
        /// <param name="clientSocket"></param>
        private static void RecieveMessage(object clientSocket)
        {
            Socket mClientSocket = (Socket)clientSocket;
            string[] data = null;
            string requestType = "";
            string content = "";

            while (true)
            {
                try
                {
                    int receiveNumber = mClientSocket.Receive(result);
                    ByteBuffer buff = new ByteBuffer(result);
                    int len = buff.ReadShort();
                    string receiveData = buff.ReadString();
                    Console.WriteLine("[{0}]{1}", mClientSocket.RemoteEndPoint.ToString(), receiveData);
                    data = System.Text.RegularExpressions.Regex.Split(receiveData, "@@@");

                    // 设置返回信息
                    requestType = data[0];
                    if (requestType != null && requestType != "")
                    {
                        switch (requestType)
                        {
                            case "LinkServer":
                                {
                                    string link = data[1];
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
                                    string userId = data[1];
                                    string userPwd = data[2];
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
                                    string userId = data[1];
                                    string userPwd = data[2];
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
                                    string userId = data[1];
                                    if (userId != null && userId != "")
                                    {
                                        GamePlayer gamePlayer = DaoFactory.GetGamePlayerDaoImp().GetAGamePlayer(userId);
                                        if (gamePlayer != null && gamePlayer.userId != null && gamePlayer.userId != "")
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
                                }
                                break;
                            case "GetServerGamePlayer":
                                {
                                    string userId = data[1];
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
                                    string userId = data[1];
                                    string userServer = data[2];
                                    string playerId = data[3];
                                    string playerPrefabName = data[4];
                                    string playerName = data[5];
                                    if (DaoFactory.GetGamePlayerDaoImp().IsExistPlayerName(playerName))
                                    {
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
                                    string playerId = data[1];

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
                                    string playerId = data[1];
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

                                break;
                        }


                        StreamWriter sw = new StreamWriter(path, true);
                        sw.WriteLine("[" + DateTime.Now + "] [" + mClientSocket.RemoteEndPoint.ToString() + "] request: " + requestType + " response: " + content);
                        sw.Close();

                        SendClientMessage(mClientSocket, content);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    mClientSocket.Shutdown(SocketShutdown.Both);
                    mClientSocket.Close();
                    break;
                }
                finally
                {
                    content = "";
                    data = null;
                    requestType = "";
                }
            }
        }
    }
}
