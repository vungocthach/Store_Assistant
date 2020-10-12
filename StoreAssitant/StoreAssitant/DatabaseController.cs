﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data.SqlTypes;
using System.Data;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace StoreAssitant
{
    class DatabaseController :IDisposable
    {
        SqlConnection connection;
        SqlCommand cmd;

        string username;
        string password ;
        string serverName ;
        string databaseName;

        string TB_INTERGER ;
        string[] COLUMNS_TB_INTERGER;

        string TB_IMAGE;
        string[] COLUMNS_TB_IMAGE;

        string TB_PRODUCT;
        string[] COLUMNS_TB_PRODUCT;

        public DatabaseController()
        {
            username = "laptrinhtrucquan";
            password = "bangnhucthach@ktpm2019";
            serverName = "tcp:52.187.161.61,2001";
            databaseName = "DBStoreAssistant";

            TB_INTERGER = "TB_INTERGER";
            COLUMNS_TB_INTERGER = new string[2] { "M_KEY", "M_VALUE" };
            TB_IMAGE = "TB_IMAGE";
            COLUMNS_TB_IMAGE = new string[2] { "ID", "M_VALUE" };
            TB_PRODUCT = "TB_PRODUCT";
            COLUMNS_TB_PRODUCT = new string[4] { "ID", "PD_NAME", "PRICE", "DESCRIP"};

            connection = new SqlConnection(SQLStatementManager.GetConnectionString(username, password, serverName, databaseName));
            cmd = new SqlCommand();
            cmd.Connection = connection;
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

        public int GetTableCount()
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            int rs;
            cmd.CommandText = string.Format("SELECT {2} FROM {0} WHERE {1} = 'tbl_count';", TB_INTERGER, COLUMNS_TB_INTERGER[0], COLUMNS_TB_INTERGER[1]);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                reader.Read();
                rs = reader.GetInt32(0);
                reader.Close();
            }
            return rs;
        }

        public int GetNextId()
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            int rs;
            cmd.CommandText = string.Format("SELECT {2} FROM {0} WHERE {1} = 'nxt_id';", TB_INTERGER, COLUMNS_TB_INTERGER[0], COLUMNS_TB_INTERGER[1]);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                reader.Read();
                rs = reader.GetInt32(0);
                reader.Close();
            }
            return rs;
        }

        public List<ProductInfo> GetProductInfos()
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            List<ProductInfo> rs = null;

            cmd.CommandText = string.Format("SELECT {0}.{1},{0}.{2},{0}.{3},{0}.{4},{5}.{7} FROM {0} LEFT JOIN {5} ON {0}.{1} = {5}.{6}",
                TB_PRODUCT, COLUMNS_TB_PRODUCT[0], COLUMNS_TB_PRODUCT[1], COLUMNS_TB_PRODUCT[2], COLUMNS_TB_PRODUCT[3],
                TB_IMAGE, COLUMNS_TB_IMAGE[0], COLUMNS_TB_IMAGE[1]);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                rs = new List<ProductInfo>();
                while (reader.Read())
                {
                    ProductInfo info = new ProductInfo(reader.GetInt16(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3));
                    if (!reader.IsDBNull(4))
                    {
                        using (MemoryStream memoryStream = new MemoryStream(reader.GetSqlBinary(4).Value))
                        {
                            if (memoryStream.Length > 0)
                            {
                                info.Image = new Bitmap(memoryStream);
                            }
                        }
                    }
                    rs.Add(info);
                }
                reader.Close();
            }
            return rs;
        }

        public Bitmap GetImage(int id)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            Bitmap rs = null;

            cmd.CommandText = string.Format("SELECT {2} FROM {0} WHERE {1} = @id_;", TB_IMAGE, COLUMNS_TB_IMAGE[0], COLUMNS_TB_IMAGE[1], id.ToString());
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@id_", SqlDbType.Int).Value = id;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                reader.Read();
                using (MemoryStream memoryStream = new MemoryStream(reader.GetSqlBinary(0).Value))
                {
                    if (memoryStream.Length > 0)
                    {
                        rs = new Bitmap(memoryStream);
                    }
                }
                reader.Close();
            }

            return rs;
        }

        public bool InsertProduct(ProductInfo productInfo)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }
            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                bool hasError = false;
                cmd.Transaction = transaction;
                productInfo.Id = GetNextId();
                cmd.CommandText = string.Format("INSERT INTO {0}({1},{2},{3},{4}) VALUES(@{1}_,@{2}_,@{3}_,@{4}_)",
                    TB_PRODUCT, COLUMNS_TB_PRODUCT[0], COLUMNS_TB_PRODUCT[1], COLUMNS_TB_PRODUCT[2], COLUMNS_TB_PRODUCT[3]);
                cmd.Parameters.Clear();
                cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_PRODUCT[0]), SqlDbType.SmallInt).Value = productInfo.Id;
                cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_PRODUCT[1]), SqlDbType.VarChar).Value = productInfo.Name;
                cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_PRODUCT[2]), SqlDbType.Int).Value = productInfo.Price;
                cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_PRODUCT[3]), SqlDbType.VarChar).Value = productInfo.Description;

                hasError = cmd.ExecuteNonQuery() != 1;
                if (productInfo.Image != null)
                {
                    hasError = hasError || !InsertImage(productInfo.Image, productInfo.Id);

                }
                hasError = hasError || !UpdateNextId(productInfo.Id + 1);

                if (hasError) { transaction.Rollback(); return false; }
                else { transaction.Commit(); return true; }
            }
        }

        public bool InsertImage(Bitmap bitmap, int id)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            cmd.CommandText = string.Format("INSERT INTO {0}({1},{2}) VALUES(@{1}_, @{2}_);", TB_IMAGE, COLUMNS_TB_IMAGE[0], COLUMNS_TB_IMAGE[1]); cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_IMAGE[0]), SqlDbType.Int).Value = id;
            
            using (MemoryStream memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, ImageFormat.Jpeg);
                cmd.Parameters.Clear();
                cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_IMAGE[0]), SqlDbType.Int).Value = id;
                cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_IMAGE[1]), SqlDbType.VarBinary).Value = memoryStream.ToArray();
            }
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool UpdateTableCount(int count)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            cmd.CommandText = string.Format("UPDATE {0} SET {2} = @{2}_ WHERE {1} = 'tbl_count';", TB_INTERGER, COLUMNS_TB_INTERGER[0], COLUMNS_TB_INTERGER[1]);
            cmd.Parameters.Clear();
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_INTERGER[1]), SqlDbType.Int).Value = count;

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool UpdateNextId(int id)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            cmd.CommandText = string.Format("UPDATE {0} SET {2} = @{2}_ WHERE {1} = 'nxt_id';", TB_INTERGER, COLUMNS_TB_INTERGER[0], COLUMNS_TB_INTERGER[1]);
            cmd.Parameters.Clear();
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_INTERGER[1]), SqlDbType.Int).Value = id;

            return cmd.ExecuteNonQuery() > 0;
        }

        public void Dispose()
        {
            Disconnect();
            connection.Dispose();
        }
    }
}
