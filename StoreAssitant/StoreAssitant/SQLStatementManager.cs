using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAssitant
{
    public class SQLStatementManager
    {
        string username;
        string password;
        string serverMame;
        string databaseName;
        int port = 1433;
        string protocol = "TCP";

        string[] tableNames;
        public string[] Tables
        {
            get { return tableNames; }
            set { tableNames = value; }
        }
        public SQLStatementManager(string servername, string databasename, string username, string password)
        {

        }

        public static string GetConnectionString(string username, string password, string serverName, string databaseName)
        {
            return string.Format("User id = {0}; password = {1}; server = {2}; Initial Catalog = {3}; connection timeout = 30;",
                                    username, password, serverName, databaseName);
        }

        public static string GetConnectionString(string username, string password, string serverName, int port, string databaseName)
        {
            return string.Format("User id = {0}; password = {1}; server = tcp:{2},{3}; Initial Catalog = {4}; connection timeout = 30;",
                                    username, password, serverName, port.ToString(), databaseName);
        }
    }
}
