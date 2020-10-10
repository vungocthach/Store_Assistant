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
    class DatabaseController :IDisposable
    {
        SqlConnection connection;

        string username;
        string password ;
        string serverName ;
        string databaseName;

        string TB_TABLE ;
        string[] COLUMNS_TB_TABLE;

        string TB_PRODUCT;
        string[] COLUMNS_TB_PRODUCT;

        public DatabaseController()
        {
            username = "laptrinhtrucquan";
            password = "bangnhucthach@ktpm2019";
            serverName = "tcp:52.187.161.61,2001";
            databaseName = "DBStoreAssistant";

            TB_TABLE = "TB_TABLE";
            COLUMNS_TB_TABLE = new string[2] { "ID", "TB_NAME" };
            TB_PRODUCT = "TB_PRODUCT";
            COLUMNS_TB_PRODUCT = new string[5] { "ID", "PD_NAME", "PRICE", "DESCRIP", "IMAGE_ID" };

            connection = new SqlConnection(SQLStatementManager.GetConnectionString(username, password, serverName, databaseName));
        }

        public bool ConnectToSQLDatabase()
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

        public void Disconnect()
        {
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        public List<TableInfo> GetTableInfos()
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            List<TableInfo> rs = null;

            using (SqlCommand cmd = new SqlCommand(string.Format("SELECT {1},{2} FROM {0}", TB_TABLE, COLUMNS_TB_TABLE[0], COLUMNS_TB_TABLE[1]), connection))
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
                TB_PRODUCT, COLUMNS_TB_PRODUCT[0], COLUMNS_TB_PRODUCT[1], COLUMNS_TB_PRODUCT[2], COLUMNS_TB_PRODUCT[3], COLUMNS_TB_PRODUCT[4]), connection))
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

        public bool InsertTable(TableInfo tableInfo)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            using (SqlCommand cmd = new SqlCommand(string.Format("INSERT INTO {0}({1},{2}) VALUES(@{1}_, @2_);", TB_TABLE, COLUMNS_TB_TABLE[0], COLUMNS_TB_TABLE[1]), connection))
            {
                SqlParameter param_id = new SqlParameter();
                param_id.ParameterName = string.Format("@{0}_", COLUMNS_TB_TABLE[0]);
                param_id.SqlDbType = SqlDbType.SmallInt;
                param_id.Value = tableInfo.Id;

                SqlParameter param_name = new SqlParameter();
                param_name.ParameterName = string.Format("@{0}_", COLUMNS_TB_TABLE[1]);
                param_name.SqlDbType = SqlDbType.VarChar;
                param_name.Value = tableInfo.Name;

                cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_TABLE[0]), SqlDbType.SmallInt).Value = tableInfo.Id;
                cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_TABLE[1]), SqlDbType.VarChar).Value = tableInfo.Name;

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool InsertProduct(ProductInfo productInfo)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            using (SqlCommand cmd = new SqlCommand(string.Format("INSERT INTO {0}({1},{2},{3},{4},{5}) VALUES(@{1}_,@{2}_,@{3}_,@{4}_,@{5}_)",
                TB_PRODUCT, COLUMNS_TB_PRODUCT[0], COLUMNS_TB_PRODUCT[1], COLUMNS_TB_PRODUCT[2], COLUMNS_TB_PRODUCT[3], COLUMNS_TB_PRODUCT[4]), connection))
            {
                cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_PRODUCT[0]), SqlDbType.SmallInt).Value = productInfo.Id;
                cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_PRODUCT[1]), SqlDbType.VarChar).Value = productInfo.Name;
                cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_PRODUCT[2]), SqlDbType.SmallInt).Value = productInfo.Price;
                cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_PRODUCT[3]), SqlDbType.VarChar).Value = productInfo.Description;
                cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_PRODUCT[4]), SqlDbType.Int).Value = null;

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public void Dispose()
        {
            Disconnect();
        }
    }
}
