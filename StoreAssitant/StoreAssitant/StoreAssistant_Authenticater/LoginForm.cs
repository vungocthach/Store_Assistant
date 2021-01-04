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

            DBServerForm dB = new DBServerForm();
            dB.LoadData();
            StoreAssistant_Helper.AppManager.LoadSQLServerInfo(dB.GetData());

            this.Icon = new Icon($"./Icons/main.ico");

            Click_Login += on_Click_Login;

            logInView._Click += LogInView__Click;
            logInView.Click_SignUp += LogInView_Click_SignUp;
            lbDB.Click += LbDB_Click;

            this.Text = Language.Rm.GetString("Login", Language.Culture);
        }

        private void LbDB_Click(object sender, EventArgs e)
        {
            DBServerForm dB = new DBServerForm();
            dB.LoadData();
            dB.ShowDialog();
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
