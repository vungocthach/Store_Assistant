#define SAVE_TO_DB
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
using StoreAssitant.StoreAssistant_Information;

namespace StoreAssitant
{
    class DatabaseController : IDisposable
    {
        SqlConnection connection;
        SqlCommand cmd;

        string username;
        string password;
        string serverName;
        string databaseName;

        string TB_INTERGER;
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
            serverName = @"tcp:laptrinhtrucquan.southeastasia.cloudapp.azure.com";
            databaseName = "DBStoreAssistant";

            TB_INTERGER = "TB_INTERGER";
            COLUMNS_TB_INTERGER = new string[2] { "M_KEY", "M_VALUE" };
            TB_IMAGE = "TB_IMAGE";
            COLUMNS_TB_IMAGE = new string[2] { "ID", "M_VALUE" };
            TB_PRODUCT = "TB_PRODUCT";
            COLUMNS_TB_PRODUCT = new string[5] { "ID", "PD_NAME", "PRICE", "DESCRIP", "IMAGE_ID" };
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
#if DEBUG
                MessageBox.Show("StoreAssistant.DatabaseController.ConnectToSQLDatabase() error : " + e.Message);
#else
                MessageBox.Show("Không thể kết nối đến máy chủ","Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /*
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
        */
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

            cmd.CommandText = string.Format("INSERT INTO {0}({1},{2},{3}) VALUES(@{1}_,@{2}_,@{3}_);", TB_USER, COLUMNS_TB_USER[0], COLUMNS_TB_USER[1], COLUMNS_TB_USER[2]);
            cmd.Parameters.Clear();
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_USER[0]), SqlDbType.VarChar).Value = userInfo.UserName;
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_USER[1]), SqlDbType.Binary, 32).Value = StoreAssistant_Authenticater.Authenticator.GetPass(userInfo);
            cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_USER[2]), SqlDbType.SmallInt).Value = (int)userInfo.Role;

            return cmd.ExecuteNonQuery() == 1;
#else
            return true;
#endif
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
                cmd.Parameters.AddWithValue(string.Format("@Amount_Pr"), productBills[i].NumberProduct);
                cmd.Parameters.AddWithValue(string.Format("@BIll_ID"), t);
                cmd.ExecuteNonQuery();
            }
        }
        public void delete_Bill(BillInfo bill)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }
            cmd.CommandText = string.Format("delete from BILL where  BILL_ID = " + bill.ID);
            cmd.CommandText = string.Format("delete from detailBill where Bill_ID = " + bill.ID);
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
        public List<BillInfo> GetBillInfo(DateTime from, DateTime to, int start, int lenght, int totalMin = -1, int totalMax = 1000000000)
        {
            List<BillInfo> bills = new List<BillInfo>();
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }
            cmd.CommandText = string.Format("select * from(select ROW_NUMBER() over(order by Bill_ID) as [STT], BILL_ID, Number_TB, ID_User, Vourcher, Total, Take, Give, Time  from BILL) as foo where STT >= @start and STT <= @end and Time >= @from and TIME <= @to and ToTal>=@totalMin and ToTal <= @totalMax");
                                          // select* from(select ROW_NUMBER() over(order by Bill_ID) as [STT], Number_TB, ID_User, Vourcher, Total, Take, Give, Time from BILL) as foo where STT >= 1 and STT <= 5  and Time >= '2001/11/08' and TIME<= '2090/10/19'
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@start", SqlDbType.Int).Value = start;
            cmd.Parameters.Add("@end", SqlDbType.Int).Value = start + lenght;
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

       /* public List<SaleInfo> GetSaleInfos (DateTime MinDate, DateTime MaxDate)
        {
            List<SaleInfo> saleInfos = new List<SaleInfo>();
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }
            cmd.CommandText = string.Fomat("")

        }*/
        public void Dispose()
        {
            Disconnect();
            connection.Dispose();
        }
    }
}
