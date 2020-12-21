using StoreAssitant.StoreAssistant_HistoryView;
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
            
            LoginForm form = new LoginForm();
            form.Click_Login += Form_Click_Login;

            Application.Run(form);
            
            //Test();
            //test2();
            //tesst3();
            // Test4();
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
            Form test_form = new Form();
            test_form.Size = new System.Drawing.Size(1080, 500);
            StoreAssistant_Helper.AppManager.LoadPreferences();
            var view = new StoreAssistant_SettingView.ToolView();
            StoreAssistant_Helper.AppManager.ChangeTheme(StoreAssistant_SettingView.ThemeMode.Dark, false);
            view.Dock = DockStyle.Top;

            test_form.BackColor = StoreAssistant_Helper.AppManager.GetColors("Main_Background");
            view.BackColor = StoreAssistant_Helper.AppManager.GetColors("Toolbar_Background");
            view.LoadTheme();
            test_form.Controls.Add(view);
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
                //e.Role = UserInfo.UserRole.Cashier;
                main_form.LoadUser();
                StoreAssistant_Helper.AppManager.LoadPreferences();
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
