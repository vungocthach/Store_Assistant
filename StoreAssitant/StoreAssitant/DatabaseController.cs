using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;

namespace StoreAssitant
{
    class DatabaseController
    {
        SqlConnection connection;
        public DatabaseController()
        {

        }

        bool ConnectToSQLServer(string username, string password, string serverName, string databaseName)
        {
            connection = new SqlConnection(SQLStatementManager.GetConnectionString(username, password, serverName, databaseName));
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine("StoreAssistant.DatabaseController.ConnectToSQLDatabase error : " + e.Message);
                return false;
            }
        }

        bool ConnectToSQLServer(string username, string password, string serverName, string databaseName, int port)
        {
            connection = new SqlConnection(SQLStatementManager.GetConnectionString(username, password, serverName, port, databaseName));
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine("StoreAssistant.DatabaseController.ConnectToSQLDatabase error : " + e.Message);
                return false;
            }
        }
    }
}
