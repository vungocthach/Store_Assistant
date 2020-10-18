using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreAssitant.StoreAssistant_Authenticater
{
    public partial class SignUpForm : Form
    {
        public event EventHandler<UserInfo> SignUpOK;
        void OnSignUpOK(object sender, UserInfo info) { this.Close(); }
        public SignUpForm()
        {
            InitializeComponent();

            SignUpOK = new EventHandler<UserInfo>(OnSignUpOK);

            btn_Submit.Click += Btn_Submit_Click;
            btn_Close.Click += Btn_Close_Click;
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (txt_PassNew.Text != txt_PassNew2.Text)
            {
                MessageBox.Show("Nhập lại mật khẩu không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UserInfo userInfo = new UserInfo() { UserName = txt_PassCurrent.Text, Pass = txt_PassNew.Text, Role = UserInfo.UserRole.Cashier };
            if (!Authenticator.RegistUser(userInfo))
            {
                txt_PassCurrent.SelectAll();
            }
            else
            {
                SignUpOK(this, userInfo);
            }
        }
    }
}
