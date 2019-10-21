using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Xml;

namespace DataBase
{
    public class OracleBean
    {

        private static string myXMLFilePath = "config.xml";    //xml文件存储路径


        static string OracleUser = "system";
        static string OraclePassword = "123456";
        static string conString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)" +
                                    "(HOST=localhost)" +
                                    "(PORT=1521))" +
                                    "(CONNECT_DATA=(SID=XE)));" +
                                    "User Id=system;" +
                                    "Password=123456;";
        public static OracleConnection GetConnection()
        {
            OracleConnection conn = null;
            OracleCommand comm = null;
            OracleDataReader rdr = null;
            try
            {
                //XmlDocument xmlDoc = new XmlDocument();
                //xmlDoc.Load(myXMLFilePath);
                ////读取Activity节点下的数据。SelectSingleNode匹配第一个Activity节点  
                //XmlNode root = xmlDoc.SelectSingleNode("//Oracle");//当节点Workflow带有属性是，使用SelectSingleNode无法读取          
                //if (root != null)
                //{
                //    string OracleUser = (root.SelectSingleNode("OracleUser")).InnerText;
                //    string OraclePassword = (root.SelectSingleNode("OraclePassword")).InnerText;
                //    conString += "User Id=" + OracleUser + ";Password=" + OraclePassword + ";";
                //}
                conn = new OracleConnection(conString);//初始化连接
            }
            catch (Exception ex)
            {
                //写入错误日志
            }

            return conn;
        }

        public static void Close(OracleDataReader dr, OracleCommand comm, OracleConnection conn)
        {
            try
            {
                if (dr != null)
                {
                    dr = null;
                }
                if (comm != null)
                {
                    comm = null;
                }
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                    conn = null;
                }
            }
            catch (OracleException ex)
            {
                //写入错误日志
            }

        }
    }
}
