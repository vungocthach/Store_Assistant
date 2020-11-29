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
        }

        static void Test()
        {

            Form test_form = new Form();
            test_form.Size = new System.Drawing.Size(1100, 600);
            test_form.Controls.Add(new StoreAssistant_StatiticsView.StatiticsView2() { Dock = DockStyle.Fill });
            Application.Run(test_form);
        }

        private static void Form_Click_Login(object sender, UserInfo e)
        {
            Form login_form = (Form)sender;
            if (StoreAssistant_Authenticater.Authenticator.Login(ref e))
            {
                Form1 main_form = new Form1();
                main_form.SignOut += new EventHandler((object obj, EventArgs etc) =>
                {
                    login_form.Show();
                    main_form.Close();
                });
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
