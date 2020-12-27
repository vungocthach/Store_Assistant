using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreAssitant
{
    public partial class DBServerForm : Form
    {
        public DBServerForm()
        {
            InitializeComponent();

            SetLanguage();

            btnSave.Click += BtnSave_Click;
            btnDefault.Click += BtnDefault_Click;
        }

        public void SetLanguage()
        {
            Language.InitLanguage(this);

            label1.Text = Language.GetString("ServerName") + ':';
            label2.Text = Language.GetString("User name") + ':';
            label3.Text = Language.GetString("Password") + ':';

            btnSave.Text = Language.GetString("Save");
            btnDefault.Text = Language.GetString("Default");
        }

        private void BtnDefault_Click(object sender, EventArgs e)
        {
            txtPassword.Text = txtserver_Name.Text = txtUsername.Text = "-default-";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string[] data = GetData();
            if ((data[0] == data[1]) && (data[2] == "-default-") && (data[0] == data[2]))
            {
                // Use default
            }
            else
            {
                using (DatabaseController databaseController = new DatabaseController())
                {
                    if (databaseController.CheckServerStructure(data[0], data[1], data[2]))
                    {
                        // Go on
                    }
                    else
                    {
                        MessageBox.Show("SQL Server has wrong format", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            SaveData();
            StoreAssistant_Helper.AppManager.LoadSQLServerInfo(GetData());
            using (DatabaseController databaseController = new DatabaseController())
            {
                databaseController.CreateDefaultValue();
            }
            MessageBox.Show(Language.GetString("msgChangeOK"));
            this.Close();
        }

        internal string[] GetData()
        {
            return new string[] { txtserver_Name.Text, txtUsername.Text, txtPassword.Text };
        }

        string path = $"./Preferences/config_server.txt";
        char breakLineChar = (char) 1;

        public byte[] GetDataKey()
        {
            SHA256Cng sha256 = new SHA256Cng();
            StringBuilder builder = new StringBuilder("matkhau#cucki#ma%nh,mo!t^minhanhcha%phe%t.rah thi cu hack :) :3");
            return sha256.ComputeHash(Encoding.UTF8.GetBytes(builder.ToString()));
        }

        public void LoadData()
        {
            FileInfo fileInfo = new FileInfo(path);
            if (!fileInfo.Exists)
            {
                fileInfo.Create().Close();
                SaveData(new string[] { "-default-", "-default-", "-default-" });
            }
            
            string txt = DecryptBytes(File.ReadAllBytes(fileInfo.FullName), GetDataKey());
            string[] data = GetLines(txt);

            txtserver_Name.Text = data[0];
            txtUsername.Text = data[1];
            txtPassword.Text = data[2];
        }

        void SaveData()
        {
            FileInfo fileInfo = new FileInfo(path);
            if (!fileInfo.Exists) { throw new FileNotFoundException(string.Format("Missing file: {0}", fileInfo.FullName)); }

            string[] data = GetData();

            StringBuilder builder = new StringBuilder();
            foreach (string line in data)
            {
                builder.AppendLine(line);
            }

            byte[] bytes = EncryptString(GetString(data), GetDataKey());
            using (FileStream stream = fileInfo.OpenWrite())
            {
                stream.Write(bytes, 0, bytes.Length);
            }
        }

        public void SaveData(string[] a)
        {
            FileInfo fileInfo = new FileInfo(path);
            if (!fileInfo.Exists) { throw new FileNotFoundException(string.Format("Missing file: {0}", fileInfo.FullName)); }

            string[] data = a;

            StringBuilder builder = new StringBuilder();
            foreach (string line in data)
            {
                builder.AppendLine(line);
            }

            byte[] bytes = EncryptString(GetString(data), GetDataKey());
            using (FileStream stream = fileInfo.OpenWrite())
            {
                stream.Write(bytes, 0, bytes.Length);
            }
        }

        byte[] EncryptString(string input, byte[] key)
        {
            byte[] rs;
            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            rijndaelManaged.KeySize = key.Length * 8;
            rijndaelManaged.Key = key;
            rijndaelManaged.Padding = PaddingMode.Zeros;
            rijndaelManaged.Mode = CipherMode.CBC;
            byte[] keyIV = new byte[rijndaelManaged.BlockSize / 8];
            for (int i = 0; i < keyIV.Length; i++)
            {
                keyIV[i] = key[2 + i];
            }

            using (MemoryStream stream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream(stream, rijndaelManaged.CreateEncryptor(key, keyIV), CryptoStreamMode.Write))
                {
                    using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                    {
                        streamWriter.Write(input);
                    }
                }
                rs = stream.ToArray();
            }
            return rs;
        }

        string DecryptBytes(byte[] input, byte[] key)
        {
            if (input == null || input.Length < 1) { return null; }
            string rs;
            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            rijndaelManaged.KeySize = key.Length * 8;
            rijndaelManaged.Key = key;
            rijndaelManaged.Padding = PaddingMode.Zeros;
            rijndaelManaged.Mode = CipherMode.CBC;
            byte[] keyIV = new byte[rijndaelManaged.BlockSize / 8];
            for (int i = 0; i < keyIV.Length; i++)
            {
                keyIV[i] = key[2 + i];
            }

            using (MemoryStream stream = new MemoryStream(input))
            {
                using (CryptoStream cryptoStream = new CryptoStream(stream, rijndaelManaged.CreateDecryptor(key, keyIV), CryptoStreamMode.Read))
                {
                    using (StreamReader streamReader = new StreamReader(cryptoStream))
                    {
                        rs = streamReader.ReadToEnd();
                    }
                }
            }
            return rs.TrimEnd('\0');
        }

        string[] GetLines(string data)
        {
            List<string> rs = new List<string>(4);

            int temp = 0;
            int i = 0;
            for (; i < data.Length; i++)
            {
                if (data[i] == breakLineChar)
                {
                    if (i == temp) { rs.Add(string.Empty); }
                    else { rs.Add(data.Substring(temp, i - temp)); }
                    temp = i + 1;
                }
            }

            if (temp < i)
            {
                rs.Add(data.Substring(temp, i - temp));
            }

            return rs.ToArray();
        }

        string GetString(string[] data)
        {
            StringBuilder builder = new StringBuilder();
            foreach (string line in data)
            {
                builder.Append(line).Append(breakLineChar);
            }
            return builder.ToString();
        }
    }
}
