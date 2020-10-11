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

        public int GetTableInfos()
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            int rs;

            using (SqlCommand cmd = new SqlCommand(string.Format("SELECT {2} FROM {0} WHERE {1} = 'tbl_count';", TB_INTERGER, COLUMNS_TB_INTERGER[0], COLUMNS_TB_INTERGER[1]), connection))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                rs = reader.GetInt32(0);
                reader.Close();
                return rs;
            }

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
                    ProductInfo info = new ProductInfo(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3));
                    int id_img = reader.GetInt32(4);
                    if (id_img != null)
                    {
                        info.Image = GetImage(id_img);
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

            using (SqlCommand cmd = new SqlCommand(string.Format("SELECT {2} FROM {0} WHERE {1} = @id_;",
                TB_IMAGE, COLUMNS_TB_IMAGE[0], COLUMNS_TB_IMAGE[1], id.ToString()), connection))
            {
                cmd.Parameters.Add("@id_", SqlDbType.Int).Value = id;
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
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

        public Bitmap GetImage2(int id)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            Bitmap rs = null;

            

            using (SqlCommand cmd = new SqlCommand(string.Format("SELECT {2} FROM {0} WHERE {1} = @id_;",
                TB_IMAGE, COLUMNS_TB_IMAGE[0], COLUMNS_TB_IMAGE[1], id.ToString(), connection)))
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                cmd.Parameters.Add("@id_", SqlDbType.Int).Value = id;
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
                MessageBox.Show("Read ok");
                reader.Read();
                using (MemoryStream memoryStream = new MemoryStream(reader.GetSqlBinary(0).Value))
                {
                    rs = new Bitmap(memoryStream);
                }
                //reader.Close();
            }

            return rs;
        }

        public bool InsertTable(int table_count)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            using (SqlCommand cmd = new SqlCommand(string.Format("INSERT INTO {0}({1},{2}) VALUES('tbl_count', @{2}_);", TB_INTERGER, COLUMNS_TB_INTERGER[0], COLUMNS_TB_INTERGER[1]), connection))
            {
                cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_INTERGER[1]), SqlDbType.Int).Value = table_count;

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
                if (productInfo.Image == null)
                {
                    cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_PRODUCT[4]), SqlDbType.Int).Value = -1;
                }
                else
                {
                    InsertImage(productInfo.Image, productInfo.Id);
                    cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_PRODUCT[4]), SqlDbType.Int).Value = productInfo.Id;
                }
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool InsertImage(Bitmap bitmap, int id)
        {
            if (connection.State != ConnectionState.Open) { ConnectToSQLDatabase(); }

            using (SqlCommand cmd = new SqlCommand(string.Format("INSERT INTO {0}({1},{2}) VALUES(@{1}_, @{2}_);", TB_IMAGE, COLUMNS_TB_IMAGE[0], COLUMNS_TB_IMAGE[1]), connection))
            {
                cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_IMAGE[0]), SqlDbType.Int).Value = id;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    bitmap.Save(memoryStream, ImageFormat.Jpeg);
                    cmd.Parameters.Add(string.Format("@{0}_", COLUMNS_TB_IMAGE[1]), SqlDbType.VarBinary).Value = memoryStream.ToArray();
                }
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public void Dispose()
        {
            Disconnect();
            connection.Dispose();
        }
    }
}
