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
        }

        private static void Form_Click_Login(object sender, UserInfo e)
        {
            Form login_form = (Form)sender;
            if (StoreAssistant_Authenticater.Authenticator.CheckLogin(ref e))
            {
                Form1 main_form = new Form1();
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
