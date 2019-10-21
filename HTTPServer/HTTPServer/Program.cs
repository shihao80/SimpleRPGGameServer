using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTTPServerLib;
using HttpServer;
using DataBase;
using SocketServer;

namespace HTTPServerLib
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Console.WriteLine(DaoFactory.GetGameGoodDaoImp().GetAllGamePlayerGameGood("a1")[0].goodName);


            ExampleServer server = new ExampleServer("100.64.129.99", 4051);
            server.SetRoot(@"D:\HttpServer-master\public");
            server.Logger = new ConsoleLogger();
            server.Start();

            //SocketServ server = new SocketServ(8765);
            //SocketServ server = new SocketServ("100.64.129.99", 8765);
        }
    }
}
