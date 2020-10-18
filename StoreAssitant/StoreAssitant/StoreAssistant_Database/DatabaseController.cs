using System;
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

        string TB_USER;
        string[] COLUMNS_TB_USER;

        public DatabaseController()
        {
            username = "laptrinhtrucquan";
            password = "bangnhucthach@ktpm2019";
            //serverName = "tcp:52.187.161.61,2001";
            serverName = @"tcp:52.187.161.61,5897";
            databaseName = "DBStoreAssistant";

            TB_INTERGER = "TB_INTERGER";
            COLUMNS_TB_INTERGER = new string[2] { "M_KEY", "M_VALUE" };
            TB_IMAGE = "TB_IMAGE";
            COLUMNS_TB_IMAGE = new string[2] { "ID", "M_VALUE" };
            TB_PRODUCT = "TB_PRODUCT";
            COLUMNS_TB_PRODUCT = new string[5] { "ID", "PD_NAME", "PRICE", "DESCRIP", "IMAGE_ID"};
            TB_USER = "TB_USER";
            COLUMNS_TB_USER = new string[3] { "USERNAME", "PASS", "USER_TYPE" };

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

        public void TransactionStart()
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }
            cmd.Transaction = connection.BeginTransaction();
        }

        public void TransactionRollback()
        {
            cmd.Transaction.Rollback();
        }

        public void TransactionCommit()
        {
            cmd.Transaction.Commit();
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

        public List<ProductInfo> GetProductInfos2()
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            List<ProductInfo> rs = null;
            List<int> images_id ;

            cmd.CommandText = string.Format("SELECT {1},{2},{3},{4},{5} FROM {0};",
                TB_PRODUCT, COLUMNS_TB_PRODUCT[0], COLUMNS_TB_PRODUCT[1], COLUMNS_TB_PRODUCT[2], COLUMNS_TB_PRODUCT[3], COLUMNS_TB_PRODUCT[4]);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                rs = new List<ProductInfo>();
                images_id = new List<int>();
                while (reader.Read())
                {
                    images_id.Add(reader.GetInt32(4));
                    rs.Add(new ProductInfo(reader.GetInt16(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3)));
                }
                reader.Close();
            }
            for (int i = 0; i < rs.Count; i++)
            {
                if (images_id[i] != -1)
                {
                    if (rs[i].Image != null) { rs[i].Image.Dispose(); }
                    rs[i].Image = null;
                    rs[i].Image = GetImage(images_id[i]);
                }
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

            TransactionStart();

            productInfo.Id = GetNextId();

            cmd.CommandText = string.Format("INSERT INTO {0}({1},{2},{3},{4},{5}) VALUES(@{1}_,@{2}_,@{3}_,@{4}_,@{5}_)",
                TB_PRODUCT, COLUMNS_TB_PRODUCT[0], COLUMNS_TB_PRODUCT[1], COLUMNS_TB_PRODUCT[2], COLUMNS_TB_PRODUCT[3], COLUMNS_TB_PRODUCT[4]);
            cmd.Parameters.Clear();
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_PRODUCT[0]), SqlDbType.SmallInt).Value = productInfo.Id;
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_PRODUCT[1]), SqlDbType.NVarChar).Value = productInfo.Name;
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_PRODUCT[2]), SqlDbType.Int).Value = productInfo.Price;
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_PRODUCT[3]), SqlDbType.NVarChar).Value = productInfo.Description;

            if (productInfo.Image == null)
            {
                cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_PRODUCT[4]), SqlDbType.Int).Value = -1;
            }
            else
            {
                cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_PRODUCT[4]), SqlDbType.Int).Value = productInfo.Id;
            }

            bool hasError = cmd.ExecuteNonQuery() != 1;
            if (productInfo.Image != null)
            {
                hasError = hasError || !InsertImage(productInfo.Image, productInfo.Id);
            }
            hasError = hasError || !UpdateNextId(productInfo.Id + 1);

            if (hasError)
            {
                TransactionRollback();
                return false;
            }
            else
            {
                TransactionCommit();
                return true;
            }
        }

        public bool InsertImage(Bitmap bitmap, int id)
        {
            if (bitmap == null) { throw new NullReferenceException("Must not insert null image"); }
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            cmd.CommandText = string.Format("INSERT INTO {0}({1},{2}) VALUES(@{1}_, @{2}_);", TB_IMAGE, COLUMNS_TB_IMAGE[0], COLUMNS_TB_IMAGE[1]); cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_IMAGE[0]), SqlDbType.Int).Value = id;

            cmd.Parameters.Clear();
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_IMAGE[0]), SqlDbType.Int).Value = id;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, ImageFormat.Jpeg);
                cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_IMAGE[1]), SqlDbType.VarBinary).Value = memoryStream.ToArray();
            }

            return cmd.ExecuteNonQuery() == 1;
        }

        public bool UpdateTableCount(int count)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            cmd.CommandText = string.Format("UPDATE {0} SET {2} = @{2}_ WHERE {1} = 'tbl_count';", TB_INTERGER, COLUMNS_TB_INTERGER[0], COLUMNS_TB_INTERGER[1]);
            cmd.Parameters.Clear();
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_INTERGER[1]), SqlDbType.Int).Value = count;

            return cmd.ExecuteNonQuery() == 1;
        }

        public bool UpdateNextId(int id)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            cmd.CommandText = string.Format("UPDATE {0} SET {2} = @{2}_ WHERE {1} = 'nxt_id';", TB_INTERGER, COLUMNS_TB_INTERGER[0], COLUMNS_TB_INTERGER[1]);
            cmd.Parameters.Clear();
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_INTERGER[1]), SqlDbType.Int).Value = id;

            return cmd.ExecuteNonQuery() == 1;
        }

        public bool UpdateImage(int id, Bitmap bitmap, bool create_if_not_exist = false)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            cmd.CommandText = string.Format("UPDATE {0} SET {2}=@{2}_ WHERE {1}=@{1}_;", TB_IMAGE, COLUMNS_TB_IMAGE[0], COLUMNS_TB_IMAGE[1]);
            cmd.Parameters.Clear();

            using (MemoryStream memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, ImageFormat.Jpeg);
                cmd.Parameters.Clear();
                cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_IMAGE[0]), SqlDbType.Int).Value = id;
                cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_IMAGE[1]), SqlDbType.VarBinary).Value = memoryStream.ToArray();
            }

            int rs = cmd.ExecuteNonQuery();
            if (rs == 0 && create_if_not_exist) { return InsertImage(bitmap, id); }

            return rs == 1;
        }

        public bool UpdateProduct(ProductInfo productInfo)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            TransactionStart();

            cmd.CommandText = string.Format("UPDATE {0} SET {2}=@{2}_,{3}=@{3}_,{4}=@{4}_,{5}=@{5}_ WHERE {1}=@{1}_",
                TB_PRODUCT, COLUMNS_TB_PRODUCT[0], COLUMNS_TB_PRODUCT[1], COLUMNS_TB_PRODUCT[2], COLUMNS_TB_PRODUCT[3], COLUMNS_TB_PRODUCT[4]);
            cmd.Parameters.Clear();
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_PRODUCT[0]), SqlDbType.SmallInt).Value = productInfo.Id;
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_PRODUCT[1]), SqlDbType.NVarChar).Value = productInfo.Name;
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_PRODUCT[2]), SqlDbType.Int).Value = productInfo.Price;
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_PRODUCT[3]), SqlDbType.NVarChar).Value = productInfo.Description;

            if (productInfo.Image == null)
            {
                cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_PRODUCT[4]), SqlDbType.Int).Value = -1;
            }
            else
            {
                cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_PRODUCT[4]), SqlDbType.Int).Value = productInfo.Id;
            }

            bool hasError = cmd.ExecuteNonQuery() != 1;
            if (productInfo.Image != null)
            {
                hasError = hasError || !UpdateImage(productInfo.Id, productInfo.Image, true);
            }
            else
            {
                DeleteImage(productInfo.Id);
            }

            if (hasError)
            {
                TransactionRollback();
                return false;
            }
            else
            {
                TransactionCommit();
                return true;
            }
        }

        public bool DeleteImage(int id)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            cmd.CommandText = string.Format("DELETE FROM {0} WHERE {1}=@{1}_;",TB_IMAGE, COLUMNS_TB_IMAGE[0]);
            cmd.Parameters.Clear();
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_IMAGE[0]), SqlDbType.Int).Value = id;

            return cmd.ExecuteNonQuery() == 1;
        }

        public bool DeleteProduct(ProductInfo productInfo)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }
            TransactionStart();
            cmd.CommandText = string.Format("DELETE FROM {0} WHERE {1}=@{1}_;", TB_PRODUCT, COLUMNS_TB_PRODUCT[0]);
            cmd.Parameters.Clear();
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_PRODUCT[0]), SqlDbType.Int).Value = productInfo.Id;

            bool rs = (cmd.ExecuteNonQuery() == 1);
            if (productInfo.Image != null) { rs = rs && DeleteImage(productInfo.Id); }
            if (rs) { TransactionCommit(); }
            else { TransactionRollback(); }
            return rs;
        }

        public bool InsertUser(UserInfo userInfo)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            cmd.CommandText = string.Format("INSERT INTO {0}({1},{2},{3}) VALUES(@{1}_,@{2}_,@{3}_);", TB_USER, COLUMNS_TB_USER[0], COLUMNS_TB_USER[1], COLUMNS_TB_USER[2]);
            cmd.Parameters.Clear();
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_USER[0]), SqlDbType.VarChar).Value = userInfo.UserName;
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_USER[1]), SqlDbType.Binary, 32).Value = StoreAssistant_Authenticater.Authenticator.GetPass(userInfo);
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_USER[2]), SqlDbType.SmallInt).Value = (int)userInfo.Role;

            return cmd.ExecuteNonQuery() == 1;
        }

        public bool CheckExistUsername(string user_name)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            cmd.CommandText = string.Format("SELECT {1} FROM {0} WHERE {1}=@{1}_ ;", TB_USER, COLUMNS_TB_USER[0]);
            cmd.Parameters.Clear();
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_USER[0]), SqlDbType.VarChar).Value = user_name;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read() && reader[0] != null)
                {
                    return !reader.Read(); // return false if there's more than 1 return
                }
                return false;
            }
        }

        public bool GetUserRole(ref UserInfo userInfo)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            cmd.CommandText = string.Format("SELECT {3} FROM {0} WHERE {1}=@{1}_ AND {2}=@{2}_;", TB_USER, COLUMNS_TB_USER[0], COLUMNS_TB_USER[1], COLUMNS_TB_USER[2]);
            cmd.Parameters.Clear();
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_USER[0]), SqlDbType.VarChar).Value = userInfo.UserName;
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_USER[1]), SqlDbType.Binary, 32).Value = StoreAssistant_Authenticater.Authenticator.GetPass(userInfo);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read() && reader[0] != null)
                {
                    short rs = reader.GetInt16(0);
                    switch (rs)
                    {
                        case ((int)UserInfo.UserRole.Manager):
                            userInfo.Role = UserInfo.UserRole.Manager;
                            break;
                        case ((int)UserInfo.UserRole.Cashier):
                            userInfo.Role = UserInfo.UserRole.Cashier;
                            break;
                        default:
                            return false;
                    }
                    return !reader.Read(); // return false if there's more than 1 return
                }
                return false;
            }
        }

        public List<UserInfo> GetAllUser(UserInfo.UserRole role)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            cmd.CommandText = string.Format("SELECT {1},{2} FROM {0} WHERE {2}=@{2}_;", TB_USER, COLUMNS_TB_USER[0], COLUMNS_TB_USER[2]);
            cmd.Parameters.Clear();
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_USER[2]), SqlDbType.SmallInt).Value = (int)role;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                List<UserInfo> rs = new List<UserInfo>();
                while (reader.Read())
                {
                    rs.Add(new UserInfo() { UserName = reader.GetString(0), Role = UserInfo.GetUserRole(reader.GetInt16(1)) });
                }

                return rs;
            }
        }

        public bool UpdatePassword(UserInfo userInfo)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            cmd.CommandText = string.Format("UPDATE {0} SET {2}=@{2}_ WHERE {1}=@{1}_;", TB_USER, COLUMNS_TB_USER[0], COLUMNS_TB_USER[1]);
            cmd.Parameters.Clear();
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_USER[0]), SqlDbType.VarChar).Value = userInfo.UserName;
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_USER[1]), SqlDbType.Binary, 32).Value = StoreAssistant_Authenticater.Authenticator.GetPass(userInfo);

            return cmd.ExecuteNonQuery() == 1;
        }

        public bool DeleteUser(UserInfo userInfo)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            cmd.CommandText = string.Format("DELETE FROM {0} WHERE {1}=@{1}_;", TB_USER, COLUMNS_TB_USER[0], COLUMNS_TB_USER[1]);
            cmd.Parameters.Clear();
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_USER[0]), SqlDbType.VarChar).Value = userInfo.UserName;
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_USER[1]), SqlDbType.Binary, 32).Value = StoreAssistant_Authenticater.Authenticator.GetPass(userInfo);

            return cmd.ExecuteNonQuery() == 1;
        }

        public void Dispose()
        {
            Disconnect();
            connection.Dispose();
        }
    }
}
