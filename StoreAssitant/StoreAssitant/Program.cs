﻿using StoreAssitant.StoreAssistant_HistoryView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreAssitant
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            StoreAssistant_Helper.AppManager.LoadPreferences();
            LoginForm form = new LoginForm();
            
            form.Click_Login += Form_Click_Login;

            Application.Run(form);
            
            //Test();
            //test2();
            //tesst3();
            // Test4();
            //Test5();
        }

        private static void Test5()
        {
            var font = StoreAssistant_Helper.AppManager.PrivateFont;
            var family = font.Families[0];
            Form form = new Form();
            TextBox textBox = new TextBox();
            textBox.Width = form.Width;
            textBox.Font = new System.Drawing.Font(family, 20, System.Drawing.FontStyle.Bold);
            textBox.Text = "This is sample text fff";
            textBox.Location = new System.Drawing.Point(0, 0);
            form.Controls.Add(textBox);
            Application.Run(form);
        }

        static void Test4()
        {
            using (DatabaseController da = new DatabaseController())
            {
                da.delete_Bill(4);
            }
        }
        static void tesst3()
        {
            using (DatabaseController da = new DatabaseController())
            {
                MessageBox.Show(da.GetOneBillInfo(3).USER_Name);
            }
        }
        static void test2()
        {
            using (DatabaseController database = new DatabaseController())
            {
                MessageBox.Show(database.CountBill(new DateTime(2000, 1, 1), new DateTime(2020, 12, 31)).ToString());
            }
        }

        static void Test()
        {
            DBServerForm test_form = new DBServerForm();
            System.IO.FileInfo fileInfo = new System.IO.FileInfo("./Preferences/config_server.txt");
            if (System.IO.File.ReadAllText(fileInfo.FullName) == string.Empty)
            {
                test_form.SaveData(new string[] { "-default-", "-default-", "-default-" });
            }
            test_form.ShowInTaskbar = true;
            test_form.LoadData();
            Application.Run(test_form);
        }

        static System.Drawing.Color GetAverage(System.Drawing.Color color1, System.Drawing.Color color2)
        {
            return System.Drawing.Color.FromArgb((color1.A + color2.A) / 2, (color1.R + color2.R) / 2, (color1.G + color2.G) / 2, (color1.B + color2.B) / 2);
        }

        private static void Form_Click_Login(object sender, UserInfo e)
        {
            if (!DatabaseController.IsOnline())
            {
                MessageBox.Show("Không có kết nối mạng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Form login_form = (Form)sender;
            InternetServiceHandler.Instance.Run();
            if (StoreAssistant_Authenticater.Authenticator.Login(ref e))
            {
                Form1 main_form = new Form1();
                main_form.LoadTheme();
                main_form.LoadFont();
                InternetServiceHandler.Instance.OfflineModeDetected = new EventHandler((s, evt) =>
                {
                    Application.Restart();
                });
                /*
                main_form.SignOut += new EventHandler((object obj, EventArgs etc) =>
                {
                    login_form.Show();
                    main_form.Close();
                });
                */
                main_form.FormClosed += new FormClosedEventHandler((object obj, FormClosedEventArgs target) =>
                {
                    if (login_form.Visible == false)
                    {
                        login_form.Close();
                    }
                    else
                    {
                        Application.Restart();
                    }
                });
                main_form.LoadUser();
                main_form.LoadWindowSize();
                main_form.Show();
                login_form.Hide();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
