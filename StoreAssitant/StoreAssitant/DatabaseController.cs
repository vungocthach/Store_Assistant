using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data.SqlTypes;
using System.Data;

namespace StoreAssitant
{
    class DatabaseController
    {
        SqlConnection connection;

        string username = "laptrnihtrucquan";
        string password = "bangnhucthach@ktpm2019";
        string serverName = "tcp:52.187.161.61,2001";
        string databaseName = "DBStoreAssistant";

        string TB_TABLE = "TB_TABLE";
        string[] TB_TABLE_COLUMNS = new string[2] { "ID", "TB_NAME" };

        string TB_PRODUCT = "TB_PRODUCT";
        string[] TB_PRODUCT_COLUMNS = new string[5] { "ID", "PD_NAME", "PRICE", "DESCRIP", "IMAGE_ID"};

        public DatabaseController()
        {
            connection = new SqlConnection(SQLStatementManager.GetConnectionString(username, password, serverName, databaseName));
        }

        bool ConnectToSQLDatabase()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine("StoreAssistant.DatabaseController.ConnectToSQLDatabase() error : " + e.Message);
                return false;
            }
        }

        public List<TableInfo> GetTableInfos()
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            List<TableInfo> rs = null;

            using (SqlCommand cmd = new SqlCommand(string.Format("SELECT {1},{2} FROM {0}", TB_TABLE, TB_TABLE_COLUMNS[0], TB_TABLE_COLUMNS[1]), connection))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                rs = new List<TableInfo>();
                while (reader.Read())
                {
                    rs.Add(new TableInfo(reader.GetInt16(0), reader.GetString(1)));
                }
                reader.Close();
            }

            return rs;
        }

        public List<ProductInfo> GetProductInfos()
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            List<ProductInfo> rs = null;

            using (SqlCommand cmd = new SqlCommand(string.Format("SELECT {1},{2},{3},{4},{5} FROM {0}", 
                TB_PRODUCT, TB_PRODUCT_COLUMNS[0], TB_PRODUCT_COLUMNS[1], TB_PRODUCT_COLUMNS[2], TB_PRODUCT_COLUMNS[3], TB_PRODUCT_COLUMNS[4]), connection))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                rs = new List<ProductInfo>();
                while (reader.Read())
                {
                    int img_id = reader.GetInt32(4);
                    rs.Add(new ProductInfo(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3)));
                }
                reader.Close();
            }

            return rs;
        }
    }
}
