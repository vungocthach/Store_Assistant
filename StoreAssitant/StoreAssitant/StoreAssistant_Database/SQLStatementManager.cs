using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAssitant
{
    public class SQLStatementManager
    {
        string username;
        string password;
        string serverName;
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
            this.username = username;
            this.password = password;
            this.serverName = servername;
            this.databaseName = databasename;
        }

        public SQLStatementManager(string servername, string databasename, string username, string password, int port)
        {
            this.username = username;
            this.password = password;
            this.serverName = servername;
            this.databaseName = databasename;
            this.port = port;
        }

        public string GetConnectionString()
        {
            return string.Format("User id = {0}; password = {1}; server = {2}:{3},{4}; Initial Catalog = {5}; connection timeout = 30;",
                                    username, password, protocol, serverName, port, databaseName);
        }

        public string GetInsertStringWithParams(string tableName, string[] columns, out SqlParameter[] sqlParameters)
        {
            if (columns.Length == columns.Length)
            {
                sqlParameters = new SqlParameter[columns.Length];
                StringBuilder buider = new StringBuilder("INSERT INTO ");
                buider.Append(tableName).Append("('");
                foreach (string col in columns)
                {
                    buider.Append(col).Append("','");
                }
                buider.Remove(buider.Length - 2, 2);
                buider.Append(") VALUES('");
                for(int i = 0; i < columns.Length; i++)
                {
                    sqlParameters[i] = new SqlParameter() { ParameterName = ('@' + columns[i])};
                    buider.Append(sqlParameters[i].ParameterName).Append("','");
                    
                }
                buider.Remove(buider.Length - 2, 2);
                buider.Append(");");

                return buider.ToString();
            }
            else
            {
                throw new ArgumentException("Length of values not fill the size of comlumns");
            }
        }

        public static string GetConnectionString(string username, string password, string serverName, string databaseName)
        {
            return string.Format("User id = {0}; password = {1}; server = {2}; Initial Catalog = {3}; Connect Timeout=3;",
                                    username, password, serverName, databaseName);
        }

        public static string GetConnectionString(string username, string password, string serverName, int port, string databaseName)
        {
            return string.Format("User id = {0}; password = {1}; server = tcp:{2},{3}; Initial Catalog = {4}; ConnectTimeout=3;",
                                    username, password, serverName, port.ToString(), databaseName);
        }
    }
}
