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
            MessageBox.Show(e.UserName + " | " + e.Pass);
        }
    }
}
