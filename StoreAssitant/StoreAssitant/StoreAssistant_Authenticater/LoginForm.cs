using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreAssitant
{
    public partial class LoginForm : Form
    {
        public UserInfo u;

        public event EventHandler<UserInfo> Click_Login;

        private void on_Click_Login(object sender, UserInfo e)
        {

        }
        public LoginForm()
        {
            InitializeComponent();

            Click_Login += on_Click_Login;

            logInView._Click += LogInView__Click;
            logInView.Click_SignUp += LogInView_Click_SignUp;

            this.Text = Language.Rm.GetString("Login", Language.Culture);
        }

        private void LogInView_Click_SignUp(object sender, EventArgs e)
        {
            SignUp_form sign = new SignUp_form();
            sign.ShowDialog();
        }

        private void LogInView__Click(object sender, EventArgs e)
        {
            u = logInView.u;

            Click_Login(this, u);
        }
        
    }
}
