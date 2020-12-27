﻿#define SAVE_TO_DB
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
using StoreAssitant.Class_Information;
using StoreAssitant.StoreAssistant_VoucherView;
using StoreAssitant.StoreAssistant_Information;
using System.ComponentModel;
using System.Net;
using System.Net.NetworkInformation;

namespace StoreAssitant
{
    class DatabaseController : IDisposable
    {
        SqlConnection connection;
        SqlCommand cmd;

        static string username = "laptrinhtrucquan";
        static string password = "bangnhucthach@ktpm2019";
        static string serverName = @"tcp:laptrinhtrucquan.southeastasia.cloudapp.azure.com";

        string databaseName = "DBStoreAssistant";

        public static void LoadServerConfig(string _serverName, string _userName, string _pass)
        {
            username = _userName;
            serverName = _serverName;
            password = _pass;
        }

        string TB_INTERGER;
        string[] COLUMNS_TB_INTERGER;

        string TB_IMAGE;
        string[] COLUMNS_TB_IMAGE;

        string TB_PRODUCT;
        string[] COLUMNS_TB_PRODUCT;

        string TB_USER;
        string[] COLUMNS_TB_USER;

        string TB_STRING100;
        string[] COLUMNS_TB_STRING100; 

        public DatabaseController()
        {
            TB_INTERGER = "TB_INTERGER";
            COLUMNS_TB_INTERGER = new string[2] { "M_KEY", "M_VALUE" };
            TB_IMAGE = "TB_IMAGE";
            COLUMNS_TB_IMAGE = new string[2] { "ID", "M_VALUE" };
            TB_PRODUCT = "TB_PRODUCT";
            COLUMNS_TB_PRODUCT = new string[5] { "ID", "PD_NAME", "PRICE", "DESCRIP", "IMAGE_ID" };
            TB_USER = "TB_USER";
            COLUMNS_TB_USER = new string[7] { "USERNAME", "PASS", "USER_TYPE", "sex", "Phone", "Birth" , "FullName"};
            TB_STRING100 = "TB_STRING100";
            COLUMNS_TB_STRING100 = new string[2] { "S_KEY", "S_VALUE" };

            connection = new SqlConnection(SQLStatementManager.GetConnectionString(username, password, serverName, databaseName));
            cmd = new SqlCommand();
            cmd.Connection = connection;
        }

        public static bool IsOnline()
        {
            try
            {
                using (var client = new MyWebClient())
                {
                    using (client.OpenRead("http://google.com/generate_204")) return true;
                }
            }
            catch (WebException)
            {
                return false;
            }
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
#if DEBUG
                throw e;
#else
                MessageBox.Show("Cannot connect to SQL Server. Error detail: " + Environment.NewLine + e.Message);
                Application.Restart();
#endif
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

        public void TransactionRollback(bool needDispose = true)
        {
            cmd.Transaction.Rollback();
            if (needDispose) { cmd.Transaction.Dispose(); }
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
        public Dictionary<int, ProductInfo> GetProductInfos()
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            // Key is Product's id and Value is Product
            Dictionary<int, ProductInfo> rs = null;

            // Key is Product's id and Value is Image's id
            Dictionary<int, int> images_id;

            cmd.CommandText = string.Format("SELECT {1},{2},{3},{4},{5} FROM {0};",
                TB_PRODUCT, COLUMNS_TB_PRODUCT[0], COLUMNS_TB_PRODUCT[1], COLUMNS_TB_PRODUCT[2], COLUMNS_TB_PRODUCT[3], COLUMNS_TB_PRODUCT[4]);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                rs = new Dictionary<int, ProductInfo>();
                images_id = new Dictionary<int, int>();
                ProductInfo product;
                while (reader.Read())
                {
                    product = new ProductInfo(reader.GetInt16(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3));
                    images_id.Add(product.Id, reader.GetInt32(4));

                    rs.Add(product.Id, product);
                }
                reader.Close();
            }
            foreach (KeyValuePair<int, ProductInfo> p in rs)
            {
                if (images_id[p.Key] != -1)
                {
                    ProductInfo product = p.Value;
                    if (product.Image != null) { product.Image.Dispose(); }
                    product.Image = null;
                    product.Image = GetImage(images_id[p.Key]);
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
#if SAVE_TO_DB
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
#else
            return true;
#endif
        }

        public bool InsertImage(Bitmap bitmap, int id)
        {
#if SAVE_TO_DB
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
#else
            return true;
#endif
        }

        public bool UpdateTableCount(int count)
        {
#if SAVE_TO_DB
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            cmd.CommandText = string.Format("UPDATE {0} SET {2} = @{2}_ WHERE {1} = 'tbl_count';", TB_INTERGER, COLUMNS_TB_INTERGER[0], COLUMNS_TB_INTERGER[1]);
            cmd.Parameters.Clear();
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_INTERGER[1]), SqlDbType.Int).Value = count;

            return cmd.ExecuteNonQuery() == 1;
#else
            return true;
#endif
        }

        public bool UpdateNextId(int id)
        {
#if SAVE_TO_DB
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            cmd.CommandText = string.Format("UPDATE {0} SET {2} = @{2}_ WHERE {1} = 'nxt_id';", TB_INTERGER, COLUMNS_TB_INTERGER[0], COLUMNS_TB_INTERGER[1]);
            cmd.Parameters.Clear();
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_INTERGER[1]), SqlDbType.Int).Value = id;

            return cmd.ExecuteNonQuery() == 1;
#else
            return true;
#endif
        }

        public bool UpdateImage(int id, Bitmap bitmap, bool create_if_not_exist = false)
        {
#if SAVE_TO_DB
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
#else
            return true;
#endif
        }

        public bool UpdateProduct(ProductInfo productInfo)
        {
#if SAVE_TO_DB
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
#else
            return true;
#endif
        }

        public bool DeleteImage(int id)
        {
#if SAVE_TO_DB
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            cmd.CommandText = string.Format("DELETE FROM {0} WHERE {1}=@{1}_;", TB_IMAGE, COLUMNS_TB_IMAGE[0]);
            cmd.Parameters.Clear();
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_IMAGE[0]), SqlDbType.Int).Value = id;

            return cmd.ExecuteNonQuery() == 1;
#else
            return true;
#endif
        }

        public bool DeleteProduct(ProductInfo productInfo)
        {
#if SAVE_TO_DB
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
#else
            return true;
#endif
        }

        public bool InsertUser(UserInfo userInfo)
        {
#if SAVE_TO_DB
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            cmd.CommandText = string.Format("INSERT INTO {0}({1},{2},{3}, {4}, {5}, {6}, {7}) VALUES(@{1}_,@{2}_,@{3}_, @{4}_, @{5}_, @{6}_,@{7}_);", TB_USER, COLUMNS_TB_USER[0], COLUMNS_TB_USER[1], COLUMNS_TB_USER[2], COLUMNS_TB_USER[3], COLUMNS_TB_USER[4], COLUMNS_TB_USER[5], COLUMNS_TB_USER[6]);
            cmd.Parameters.Clear();
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_USER[0]), SqlDbType.VarChar).Value = userInfo.UserName;
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_USER[1]), SqlDbType.Binary, 32).Value = StoreAssistant_Authenticater.Authenticator.GetPass(userInfo);
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_USER[2]), SqlDbType.SmallInt).Value = (int)userInfo.Role;
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_USER[3]), SqlDbType.Char).Value = userInfo.Sex;
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_USER[4]), SqlDbType.Char).Value = userInfo.Phone;
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_USER[5]), SqlDbType.DateTime).Value = userInfo.Birth;
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_USER[6]), SqlDbType.VarChar).Value = userInfo.FullName;

            return cmd.ExecuteNonQuery() == 1;
#else
            return true;
#endif
        }

        public UserInfo GetUser(string username)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            cmd.CommandText = string.Format("SELECT {1}, {4}, {5}, {6},{7} FROM {0} WHERE {1} = @{1}_;", TB_USER, COLUMNS_TB_USER[0], COLUMNS_TB_USER[1], COLUMNS_TB_USER[2], COLUMNS_TB_USER[3], COLUMNS_TB_USER[4], COLUMNS_TB_USER[5], COLUMNS_TB_USER[6]);
            cmd.Parameters.Clear();
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_USER[0]), SqlDbType.VarChar).Value = username;

            UserInfo rs = new UserInfo();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    rs.UserName = reader.GetString(0);
                    rs.Sex = reader.GetString(1);
                    rs.Phone = reader.GetString(2);
                    rs.Birth = reader.GetDateTime(3);
                    rs.FullName = reader.GetString(4);
                }
            }

            return rs;
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

            cmd.CommandText = string.Format("SELECT {1},{2},{3} FROM {0} WHERE {2}=@{2}_;", TB_USER, COLUMNS_TB_USER[0], COLUMNS_TB_USER[2], COLUMNS_TB_USER[6]);
            cmd.Parameters.Clear();
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_USER[2]), SqlDbType.SmallInt).Value = (int)role;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                List<UserInfo> rs = new List<UserInfo>();
                while (reader.Read())
                {
                    rs.Add(new UserInfo() { UserName = reader.GetString(0), Role = UserInfo.GetUserRole(reader.GetInt16(1)), FullName = reader.GetString(2) });
                }

                return rs;
            }
        }

        public bool UpdatePassword(UserInfo userInfo)
        {
#if SAVE_TO_DB
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            cmd.CommandText = string.Format("UPDATE {0} SET {2}=@{2}_ WHERE {1}=@{1}_;", TB_USER, COLUMNS_TB_USER[0], COLUMNS_TB_USER[1]);
            cmd.Parameters.Clear();
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_USER[0]), SqlDbType.VarChar).Value = userInfo.UserName;
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_USER[1]), SqlDbType.Binary, 32).Value = StoreAssistant_Authenticater.Authenticator.GetPass(userInfo);

            return cmd.ExecuteNonQuery() == 1;
#else
            return true;
#endif
        }

        public bool DeleteUser(string userName)
        {
#if SAVE_TO_DB
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            cmd.CommandText = string.Format("DELETE FROM {0} WHERE {1}=@{1}_;", TB_USER, COLUMNS_TB_USER[0], COLUMNS_TB_USER[1]);
            cmd.Parameters.Clear();
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_USER[0]), SqlDbType.VarChar).Value = userName;

            return cmd.ExecuteNonQuery() == 1;
#else
            return true;
#endif
        }
        /* public List<string> Get_Name_Product(string Name)
         {
             if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

             cmd.CommandText = string.Format("select PD_Name from TB_product ");
             cmd.Connection = connection;

             using (SqlDataReader reader = cmd.ExecuteReader())
             {
                 int i = 0;
                 List<string> Product = new List<string>();
                 List<string> ConsultPro = new List<string>();
                 while (reader.Read())
                 {
                     object tmp = reader["PD_Name"];
                     if (tmp != DBNull.Value)
                     {
                         ProductAddWithValue(reader["PD_Name"].ToString());
                     }
                     ++i;
                 }
                 ConsultPro = Product.FindAll(s => { return (s.Contains(Name)); });
                 return ConsultPro;
             }
         }*/
        public void insert_Bill(BillInfo bill)
        {

            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }
            cmd.CommandText = string.Format("insert into BILL (Number_TB, ID_User, Vourcher, Total, Take, Give, Time) values (@Number_Tb, @Id_User,@Vourcher, @total, @Take, @Give, @Time)");
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue(string.Format("@Number_Tb"), bill.Number_table);
            cmd.Parameters.AddWithValue(string.Format("@Id_User"), "admin");
            cmd.Parameters.AddWithValue(string.Format("@Vourcher"), bill.Voucher);
            cmd.Parameters.AddWithValue(string.Format("@Total"), bill.TOTAL);
            cmd.Parameters.AddWithValue(string.Format("@Take"), bill.Take);
            cmd.Parameters.AddWithValue(string.Format("@Give"), bill.Give);
            cmd.Parameters.AddWithValue(string.Format("@Time"), bill.DAY);
            cmd.ExecuteNonQuery();

        }

        public int Get_Max_ID()
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }
            cmd.CommandText = string.Format("select Max (Bill_ID) as SL from BILL");
            cmd.Parameters.Clear();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                reader.Read();
                return (int)(reader["SL"]);
            }
        }
        public void Insert_Detail_Bill(MyList<Products> productBills)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }
            int t = Get_Max_ID();
            for (int i = 0; i < productBills.Count; ++i)
            {
                cmd.CommandText = string.Format("insert into Detail_Bill (Name_PR, Price_Pr,Amount_Pr, Bill_ID) values (@Name_Pr, @Price_Pr, @Amount_Pr, @Bill_ID)");
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue(string.Format("@Name_Pr"), productBills[i].Name);
                cmd.Parameters.AddWithValue(string.Format("@Price_Pr"), productBills[i].Price);
                cmd.Parameters.AddWithValue(string.Format("@BIll_ID"), t);
                cmd.Parameters.AddWithValue(string.Format("@Amount_Pr"), productBills[i].NumberProduct);
                cmd.ExecuteNonQuery();
            }
        }
        public void delete_Bill(int ID)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }
            cmd.CommandText = string.Format("delete from detail_Bill where Bill_ID = " + ID);
            cmd.ExecuteNonQuery();
            cmd.CommandText = string.Format("delete from BILL where  BILL_ID = " + ID);
            cmd.ExecuteNonQuery();
        }

        static public void Insert_Bill(BillInfo bill)
        {
            using (DatabaseController database = new DatabaseController())
            {
                database.insert_Bill(bill);
                database.Insert_Detail_Bill(bill.ProductBills);
            }
        }
        public MyList<Products> GetDetailBillInfo(int ID)
        {
            MyList<Products> products = new MyList<Products>();
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }
            cmd.CommandText = string.Format("Select * from Detail_Bill where BILL_ID =" + ID);
            cmd.Parameters.Clear();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                int i = 0;
                while (reader.Read())
                {
                    products.Add(new Products());
                    products[i].Name = (string)reader["Name_PR"];
                    products[i].Price = (int)reader["Price_PR"];
                    products[i].NumberProduct = (int)reader["Amount_PR"];
                    products[i].Id = (int)reader["Bill_ID"];
                    ++i;
                }
            }
            return products;
        }
        public List<BillInfo> GetBillInfo(DateTime from, DateTime to, int start, int lenght, int totalMin , int totalMax)
        {
            List<BillInfo> bills = new List<BillInfo>();
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }
            cmd.CommandText = string.Format("select * from(select ROW_NUMBER() over(order by Bill_ID) as [STT], BILL_ID, Number_TB, ID_User, Vourcher, Total, Take, Give, Time  from BILL where Time >= @from and TIME <= @to and ToTal>=@totalMin and ToTal <= @totalMax) as foo where STT >= @start and STT <= @end");
                                          // select* from(select ROW_NUMBER() over(order by Bill_ID) as [STT], Number_TB, ID_User, Vourcher, Total, Take, Give, Time from BILL) as foo where STT >= 1 and STT <= 5  and Time >= '2001/11/08' and TIME<= '2090/10/19'
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@start", SqlDbType.Int).Value = start;
            cmd.Parameters.Add("@end", SqlDbType.Int).Value = start + lenght - 1;
            cmd.Parameters.Add("@from", SqlDbType.DateTime).Value = from;
            cmd.Parameters.Add("@to", SqlDbType.DateTime).Value = to;
            cmd.Parameters.Add("@totalMin", SqlDbType.Int).Value = totalMin;
            cmd.Parameters.Add("@totalMax", SqlDbType.Int).Value = totalMax;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                int i = 0;
                while (reader.Read())
                {
                    bills.Add(new BillInfo());
                    bills[i].Number_table = (int)reader["Number_TB"];
                    bills[i].USER_Name = (string)reader["ID_User"];
                    bills[i].Voucher = (string)reader["Vourcher"];
                    bills[i].Take = (int)reader["TaKe"];
                    bills[i].DAY = (DateTime)reader["Time"];
                    bills[i].ID = (int)reader["BILL_ID"];
                    bills[i].Price_Bill = (long)reader["Total"];
                    //bills[i].ProductBills = GetDetailBillInfo((int)reader["BILL_ID"]);
                    ++i;
                }
            }

            foreach (BillInfo b in bills)
            {
                b.ProductBills = GetDetailBillInfo(b.ID);
            }

            return bills;

        }

        public List<BillInfo> GetBillInfo(DateTime from, DateTime to, int start, int lenght, int sortMode = 0, string direction = "DESC")
        {
            string sort;
            switch (sortMode)
            {
                case 4:
                    sort = string.Format("Total {0}, TIME {0}", direction);
                    break;
                case 3:
                    sort = string.Format("Number_TB {0}, TIME {0}", direction);
                    break;
                default: 
                    sort = string.Format("Time {0}", direction);
                    break;
            }

;           List<BillInfo> bills = new List<BillInfo>();
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }
            cmd.CommandText = string.Format("select * from(select ROW_NUMBER() over(order by {0}) as [STT], BILL_ID, Number_TB, ID_User, Vourcher, Total, Take, Give, Time  from BILL where Time >= @from and TIME <= @to) as foo where STT >= @start and STT <= @end order by foo.stt;", sort);
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@start", SqlDbType.Int).Value = start;
            cmd.Parameters.Add("@end", SqlDbType.Int).Value = start + lenght - 1;
            cmd.Parameters.Add("@from", SqlDbType.DateTime).Value = from;
            cmd.Parameters.Add("@to", SqlDbType.DateTime).Value = to;
            BillInfo bill;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    bill = new BillInfo();
                    bill.Number_table = (int)reader["Number_TB"];
                    bill.USER_Name = (string)reader["ID_User"];
                    bill.Voucher = (string)reader["Vourcher"];
                    bill.Take = (int)reader["TaKe"];
                    bill.DAY = (DateTime)reader["Time"];
                    bill.ID = (int)reader["BILL_ID"];
                    bill.TOTAL = (long)reader["Total"];
                    bills.Add(bill);
                }
            }
            return bills;

        }


        public List<BillInfo> GetListBillInFo(int from, int to = -1)
        {
            List<BillInfo> bills = new List<BillInfo>();
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }
            cmd.CommandText = string.Format("select * from(select ROW_NUMBER() over(order by Bill_ID) as [STT],Number_TB, ID_User, Vourcher, Total, Take, Give, Time  from BILL) " +
                "as foo where STT >=" + from + " and STT <=" + to);
            cmd.Parameters.Clear();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                int i = 0;
                while (reader.Read())
                {
                    bills.Add(new BillInfo());
                    bills[i].Number_table = (int)reader["Number_TB"];
                    bills[i].USER_Name = (string)reader["ID"];
                    bills[i].Voucher = (string)reader["Voucher"];
                    bills[i].Take = (int)reader["TaKe"];
                    bills[i].DAY = (DateTime)reader["Day"];
                    bills[i].ProductBills = GetDetailBillInfo((int)reader["ID"]);
                    ++i;
                }
            }


            return (bills);

        }
        public BillInfo GetOneBillInfo(int bill_id)
        {
            BillInfo bills = new BillInfo();
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }
            cmd.CommandText = string.Format("select * from Bill where Bill_ID = @ID");
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = bill_id;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    bills.Number_table = (int)reader["Number_TB"];
                    bills.USER_Name = (string)reader["ID_User"];
                    bills.Voucher = (string)reader["Vourcher"];
                    bills.Take = (int)reader["TaKe"];
                    bills.DAY = (DateTime)reader["Time"];
                    bills.ID = (int)reader["BILL_ID"];
                    bills.TOTAL = (long)reader["Total"];
                }
                else return null;

            }
            bills.ProductBills = GetDetailBillInfo(bills.ID);

            return bills;

        }

        public int CountBill(DateTime from, DateTime to)
        {
            int Amount = 0;
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }
            cmd.CommandText = string.Format("select count(*) as SL from Bill where Time >= @from and  Time <= @to");
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@from", SqlDbType.DateTime).Value = from;
            cmd.Parameters.Add("@to", SqlDbType.DateTime).Value = to;
            using ( SqlDataReader reader = cmd.ExecuteReader())
            {
                reader.Read();
                Amount = (int) reader["SL"];
            }
            return Amount;
        }
        /* public List<SaleInfo> GetSaleInfos (DateTime MinDate, DateTime MaxDate)
         {
             List<SaleInfo> saleInfos = new List<SaleInfo>();
             if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }
             cmd.CommandText = string.Fomat("")

         }*/

        /*public void Insert_UserInfor  (UserInfo user)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }
            cmd.CommandText = string.Format("Insert into TB_USER (USERNAME, Pass, User_Type, sex, birth, phone) values (@Name, @Pass, @Type, @Sex,  @birth, @phone)");
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = user.UserName;
            cmd.Parameters.Add("@Pass", SqlDbType.Char).Value = user.Pass;
            cmd.Parameters.Add("@Type", SqlDbType.SmallInt).Value = 1;
            cmd.Parameters.Add("@Sex", SqlDbType.TinyInt).Value = user.Sex;
            cmd.Parameters.Add("@Birth", SqlDbType.DateTime).Value = user.Birth;
            cmd.Parameters.Add("@phone", SqlDbType.Char).Value = user.Phone;
            cmd.ExecuteNonQuery();
        }*/

        public List<KeyValuePair<DateTime, long>> GetRevenue_ByYear(DateTime fromDate, DateTime toDate)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            cmd.CommandText = "SELECT sum(ALL CAST((dt.[AMOUNT_PR] * dt.[PRICE_PR]) as BIGINT) ) revenue, YEAR(BILL.TIME) y "
                                + "FROM Detail_Bill dt LEFT JOIN BILL on dt.BILL_ID = BILL.BILL_ID "
                                + "WHERE BILL.TIME >= @fromDate AND BILL.TIME <= @toDate "
                                  + "GROUP BY YEAR(BILL.TIME) ORDER BY YEAR(BILL.TIME) ASC;";

            cmd.Parameters.Clear();
            cmd.Parameters.Add("@fromDate", SqlDbType.DateTime).Value = fromDate;
            cmd.Parameters.Add("@toDate", SqlDbType.DateTime).Value = toDate;

            List<KeyValuePair<DateTime, long>> rs = new List<KeyValuePair<DateTime, long>>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int y = reader.GetInt32(1);
                    DateTime date = new DateTime(y, 1, 1, 0, 0, 0);
                    long revenue = reader.GetInt64(0);
                    rs.Add(new KeyValuePair<DateTime, long>(date, revenue));
                }
            }

            return rs;

        }

        public List<SaleInfo> GetSaleInfos_ByDay(DateTime fromDate, DateTime toDate)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            cmd.CommandText = "SELECT dt.[NAME_PR], dt.[PRICE_PR], sum(ALL dt.[AMOUNT_PR]) number, YEAR(BILL.TIME) y, MONTH(BILL.TIME) m, DAY(BILL.TIME) d "
                                + "FROM Detail_Bill dt LEFT JOIN BILL on dt.BILL_ID = BILL.BILL_ID "
                                + "WHERE BILL.TIME >= @fromDate AND BILL.TIME <= @toDate "
                                  + "GROUP BY YEAR(BILL.TIME), MONTH(BILL.TIME), DAY(BILL.TIME), dt.NAME_PR, dt.[PRICE_PR]  ORDER BY YEAR(BILL.TIME), MONTH(BILL.TIME) , DAY(BILL.TIME);";

            cmd.Parameters.Clear();
            cmd.Parameters.Add("@fromDate", SqlDbType.DateTime).Value = fromDate;
            cmd.Parameters.Add("@toDate", SqlDbType.DateTime).Value = toDate;

            List<SaleInfo> rs = new List<SaleInfo>();
            SaleInfo last = null;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int y = reader.GetInt32(3);
                    int m = reader.GetInt32(4);
                    int d = reader.GetInt32(5);
                    if (last == null || !(last.DateMin.Year == y && last.DateMin.Month == m && last.DateMin.Day == d))
                    {
                        last = new SaleInfo(y, m, d);
                        rs.Add(last);
                    }
                    string productName = reader.GetString(0);
                    int i = 1;
                    while (last.Products.ContainsKey(productName))
                    {
                        productName = string.Format("{0} ({1})", reader.GetString(0), i.ToString());
                        i++;
                    }
                    ProductSaleInfo productSaleInfo = new ProductSaleInfo();
                    productSaleInfo.ProductName = productName;
                    productSaleInfo.Number = reader.GetInt32(2);
                    productSaleInfo.Price = reader.GetInt32(1);
                    last.Products.Add(productName, productSaleInfo);
                }
            }

            return rs;
        }

        public List<KeyValuePair<DateTime, long>> GetRevenue_ByMonth(DateTime fromDate, DateTime toDate)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            cmd.CommandText = "SELECT sum(ALL CAST((dt.[AMOUNT_PR] * dt.[PRICE_PR]) as BIGINT) ) revenue, YEAR(BILL.TIME) y, MONTH(BILL.TIME) m "
                                + "FROM Detail_Bill dt LEFT JOIN BILL on dt.BILL_ID = BILL.BILL_ID "
                                + "WHERE BILL.TIME >= @fromDate AND BILL.TIME <= @toDate "
                                  + "GROUP BY YEAR(BILL.TIME), MONTH(BILL.TIME) ORDER BY YEAR(BILL.TIME) ASC, MONTH(BILL.TIME) ASC";

            cmd.Parameters.Clear();
            cmd.Parameters.Add("@fromDate", SqlDbType.DateTime).Value = fromDate;
            cmd.Parameters.Add("@toDate", SqlDbType.DateTime).Value = toDate;

            List<KeyValuePair<DateTime, long>> rs = new List<KeyValuePair<DateTime, long>>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int y = reader.GetInt32(1);
                    int m = reader.GetInt32(2);
                    DateTime date = new DateTime(y, m, 1, 0, 0, 0);
                    long revenue = reader.GetInt64(0);
                    rs.Add(new KeyValuePair<DateTime, long>(date, revenue));
                }
            }

            return rs;
        }

        public List<SaleInfo> GetSaleInfos_ByMonth(DateTime fromDate, DateTime toDate)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            cmd.CommandText = "SELECT dt.[NAME_PR], dt.[PRICE_PR],sum(ALL dt.[AMOUNT_PR]) number, YEAR(BILL.TIME) y, MONTH(BILL.TIME) m "
                                + "FROM Detail_Bill dt LEFT JOIN BILL on dt.BILL_ID = BILL.BILL_ID "
                                + "WHERE BILL.TIME >= @fromDate AND BILL.TIME <= @toDate "
                                  + "GROUP BY YEAR(BILL.TIME), MONTH(BILL.TIME), dt.NAME_PR, dt.[PRICE_PR] ORDER BY YEAR(BILL.TIME), MONTH(BILL.TIME);";

            cmd.Parameters.Clear();
            cmd.Parameters.Add("@fromDate", SqlDbType.DateTime).Value = fromDate;
            cmd.Parameters.Add("@toDate", SqlDbType.DateTime).Value = toDate;

            List<SaleInfo> rs = new List<SaleInfo>();
            SaleInfo last = null;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int y = reader.GetInt32(3);
                    int m = reader.GetInt32(4);
                    if (last == null || !(last.DateMin.Year == y && last.DateMin.Month == m ))
                    {
                        last = new SaleInfo(y, m);
                        rs.Add(last);
                    }
                    string productName = reader.GetString(0);
                    int i = 1;
                    while (last.Products.ContainsKey(productName))
                    {
                        productName = string.Format("{0} ({1})", reader.GetString(0), i.ToString());
                        i++;
                    }
                    ProductSaleInfo productSaleInfo = new ProductSaleInfo();
                    productSaleInfo.ProductName = productName;
                    productSaleInfo.Number = reader.GetInt32(2);
                    productSaleInfo.Price = reader.GetInt32(1);
                    last.Products.Add(productName, productSaleInfo);
                }
            }

            return rs;
        }

        public List<VoucherInfo> GetVouchers()
        {
            var Vouchers = new List<VoucherInfo>();
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }
            cmd.CommandText = string.Format("select * from Voucher");
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    VoucherInfo item = new VoucherInfo();
                    item.Code = (string)reader["Code"];
                    item.ExpiryDate = (DateTime)reader["Expiry"];
                    item.NumberInit = (int)reader["NumberInit"];
                    item.NumberRemain = (int)reader["NumberRemain"];
                    item.Value = (int)reader["Decrease"];
                    Vouchers.Add(item);
                }
            }
            return Vouchers;
        }
        public int UseVoucher(string Code)
        {
            int value = 0;
            bool isExistsCode = false;
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }
            cmd.CommandText = string.Format("select NumberRemain, Expiry, Decrease from Voucher where Code = @Code", Code);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Code", Code);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    isExistsCode = true;
                    if ((int)reader["NumberRemain"] == 0)
                    {
                        MessageBox.Show("Đã hết số lần sử dụng thẻ voucher");
                        return 0;
                    }
                    if ((DateTime)reader["Expiry"] < DateTime.Now)
                    {
                        MessageBox.Show("Hết thời hạn");
                        return 0;
                    }
                    value = (int)reader["Decrease"];
                }
            }
            if (isExistsCode)
            {
                cmd.CommandText = string.Format("update Voucher set NumberRemain = NumberRemain - 1 where Code = @Code ", Code);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Code", Code);
                cmd.ExecuteNonQuery();
            }
            return value;
        }
        public void AddVoucher(VoucherInfo voucher)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }
            cmd.CommandText = string.Format("insert Voucher(Code,Expiry,Decrease,NumberInit,NumberRemain) values(@Code,@Expiry,@Value,@NumberInit,@NumberRemain)");
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue(string.Format("@Code"), voucher.Code);
            cmd.Parameters.AddWithValue(string.Format("@Expiry"), voucher.ExpiryDate);
            cmd.Parameters.AddWithValue(string.Format("@Value"), voucher.Value);
            cmd.Parameters.AddWithValue(string.Format("@NumberInit"), voucher.NumberInit);
            cmd.Parameters.AddWithValue(string.Format("@NumberRemain"), voucher.NumberRemain);
            cmd.ExecuteNonQuery();
            /*if ( cmd.ExecuteNonQuery() != 1)
            {
                MessageBox.Show("Lỗi khi thêm voucher vào database");
            }*/
        }
        public void RemoveVoucher(string name)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }
            cmd.CommandText = string.Format("delete from Voucher where Code = @name", name);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@name", name);
            cmd.ExecuteNonQuery();
        }

        const string KEY_STRING100_STORE_NAME = "_name";
        const string KEY_STRING100_STORE_PHONE = "_phone";
        const string KEY_STRING100_STORE_WEBSITE = "_web";
        public string GetString100 (string key)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }
            cmd.CommandText = string.Format("SELECT {2} FROM {0} WHERE {1}=@{1}_;", TB_STRING100, COLUMNS_TB_STRING100[0], COLUMNS_TB_STRING100[1]);
            cmd.Parameters.Clear();
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_STRING100[0]), SqlDbType.VarChar).Value = key;
            string rs;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    rs = reader.GetString(0);
                }
                else { throw new Exception("Database has wrong format"); }
            }

            return rs;
        }
        public bool UpdateString100(string key, string value)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }
            cmd.CommandText = string.Format("UPDATE {0} SET {2} = @{2}_ WHERE {1} = @{1}_", TB_STRING100, COLUMNS_TB_STRING100[0], COLUMNS_TB_STRING100[1]);
            cmd.Parameters.Clear();
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_STRING100[0]), SqlDbType.VarChar).Value = key;
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_STRING100[1]), SqlDbType.NVarChar).Value = value;

            if (cmd.ExecuteNonQuery() == 1) { return true; }

            return false;
        }

        public string GetStore_Name()
        {
            return GetString100(KEY_STRING100_STORE_NAME);
        }

        public string GetStore_Phone()
        {
            return GetString100(KEY_STRING100_STORE_PHONE);
        }

        public string GetStore_Website()
        {
            return GetString100(KEY_STRING100_STORE_WEBSITE);
        }

        public StoreInformation GetStoreInformation()
        {
            StoreInformation rs = new StoreInformation()
            {
                Name = GetStore_Name(),
                PhoneNumber = GetStore_Phone(),
                WebAddress = GetStore_Website()
            };
            return rs;
        }

        public bool UpdateStoreInfo(StoreInformation info)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }
            bool rs = false;
            TransactionStart();
            if (UpdateString100(KEY_STRING100_STORE_NAME, info.Name) 
                && UpdateString100(KEY_STRING100_STORE_PHONE, info.PhoneNumber)
                && UpdateString100(KEY_STRING100_STORE_WEBSITE, info.WebAddress))
            {
                TransactionCommit();
                rs = true;
            }
            else
            {
                TransactionRollback();
                rs = false;
            }
            
            return rs;
        }

        public void Dispose()
        {
            Disconnect();
            connection.Dispose();
        }

        public bool CheckServerStructure(string _serverName, string _userName, string _pass)
        {
            SqlConnection sqlConnection2 = new SqlConnection();
            sqlConnection2.ConnectionString = SQLStatementManager.GetConnectionString(_userName, _pass, _serverName, databaseName);
            try
            {
                sqlConnection2.Open();

            }
            catch (Exception e) { throw new Exception("Cannot connect to SQL Server. Error detail: " + Environment.NewLine + e.Message); }

            SqlCommand cmd2 = sqlConnection2.CreateCommand();
                cmd2.CommandText = "select * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME != 'sysdiagrams' and TABLE_CATALOG = 'DBStoreAssistant' order by TABLE_NAME ASC, COLUMN_NAME ASC;";
            try
            {
                using (SqlDataReader reader2 = cmd2.ExecuteReader())
                {
                    if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }
                    cmd.Parameters.Clear();
                    cmd.CommandText = cmd2.CommandText;

                    object[] cells = new object[reader2.FieldCount];
                    object[] cells2 = new object[cells.Length];
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() && reader2.Read())
                        {
                            reader.GetValues(cells);
                            reader2.GetValues(cells2);
                            while (IsEqual(cells, cells2))
                            {
                                if (reader2.Read())
                                {
                                    reader2.GetValues(cells2);
                                }
                                else { break; }
                            }
                        }

                        return !reader.Read();
                    }
                }
            }
            catch (Exception e) { throw new Exception("SQL Server has wrong format"); }
        }

        bool IsEqual(object[] A, object[] B)
        {
            bool rs = A.Length == B.Length;
            int i = 0;
            while (rs && i < A.Length)
            {
                rs = (A[i] == B[i]);
                i++;
            }

            return rs;
        }

        internal void CreateDefaultValue()
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            StringBuilder builder = new StringBuilder();
            builder.Append("IF NOT EXISTS(SELECT S_KEY FROM TB_STRING100 WHERE S_KEY = '_name') BEGIN INSERT INTO TB_STRING100(S_KEY, S_VALUE) VALUES('_name', 'NTB Quán'); END ");
            builder.Append("IF NOT EXISTS(SELECT S_KEY FROM TB_STRING100 WHERE S_KEY = '_phone') BEGIN INSERT INTO TB_STRING100(S_KEY, S_VALUE) VALUES ('_phone', '0965903108'); END ");
            builder.Append("IF NOT EXISTS(SELECT S_KEY FROM TB_STRING100 WHERE S_KEY = '_web') BEGIN INSERT INTO TB_STRING100(S_KEY, S_VALUE) VALUES ('_web', 'https://github.com/vungocthach/Store_Assistant'); END ");
            builder.Append("IF NOT EXISTS(SELECT M_KEY FROM TB_INTERGER WHERE M_KEY = 'tbl_count') BEGIN INSERT INTO TB_INTERGER(M_KEY, M_VALUE) VALUES('tbl_count', 1); END ");
            builder.Append("IF NOT EXISTS(SELECT M_KEY FROM TB_INTERGER WHERE M_KEY = 'nxt_id') BEGIN INSERT INTO TB_INTERGER(M_KEY, M_VALUE) VALUES('nxt_id', 1); END ");
            builder.Append("IF NOT EXISTS(SELECT USERNAME FROM TB_USER WHERE USERNAME = 'admin') BEGIN INSERT INTO TB_USER(USERNAME, PASS, USER_TYPE) VALUES('admin', 0x7523C62ABDB7628C5A9DAD8F97D8D8C5C040EDE36535E531A8A3748B6CAE7E00, 0); END ");

            cmd.CommandText = builder.ToString();
            cmd.Parameters.Clear();

            cmd.ExecuteNonQuery();
        }
    }
}
