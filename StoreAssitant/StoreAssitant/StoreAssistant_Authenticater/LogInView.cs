using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace StoreAssitant
{
    public partial class LogInView : UserControl
    {
        public UserInfo u;

        #region Create event

        public event EventHandler _Click;

        public event EventHandler CLick_FogotPass;

        public event EventHandler Click_SignUp;

        private void on_CLick(object sender, EventArgs e)
        {

        }

        private void on_FogotPass (object sender, EventArgs e)
        {

        }

        private void on_SignUp (object sender, EventArgs e)
        {

        }
        #endregion
        public void SetData()
        {
            u.UserName = tb_User.Text;
            u.Pass = tb_Password.Text ;
        }
        public void Init_Event()
        {
            _Click += on_CLick;
            Click_SignUp += on_SignUp;
            CLick_FogotPass += on_FogotPass;
        }
        public void Load_Event()
        {
            Btn_Login.Click += Btn_Login_Click;
            Lb_ForgotPass.Click += Lb_ForgotPass_Click;
            Lb_SignUp.Click += Lb_SignUp_Click;
            tb_Password.GotFocus += Tb_Password_GotFocus;
            tb_User.GotFocus += Tb__User_GotFocus;
        }
        public void InitializeField()
        {
            u = new UserInfo();

            this.Size = new Size(423, 502);

            tb_Password.ForeColor = Color.Gray;
            tb_User.ForeColor = Color.Gray;
        }
            public LogInView()
        {
            InitializeComponent();

            InitializeField();

            Init_Event();

            Load_Event();

            
        }


        private void Tb__User_GotFocus(object sender, EventArgs e)
        {
           if (tb_User.Text == "Tên đăng nhập")
            {
                tb_User.ForeColor = Color.Black;
                tb_User.Text = "";
            }
          // else 
                if(tb_Password.Text =="")
            {
                tb_Password.PasswordChar = '\0';
                tb_Password.ForeColor = Color.Gray;
                tb_Password.Text = "Mật khẩu";
            }           
        }

        private void Tb_Password_GotFocus(object sender, EventArgs e)
        {
            if (tb_Password.Text == "Mật khẩu")
            {
                tb_Password.PasswordChar = '*'; 
                tb_Password.ForeColor = Color.Black;
                tb_Password.Text = "";
            }
         //   else
                if (tb_User.Text == "")
            {
                tb_User.ForeColor = Color.Gray;
                tb_User.Text = "Tên đăng nhập";
            }
        }

        private void Lb_SignUp_Click(object sender, EventArgs e)
        {
            Click_SignUp(this, e);
            MessageBox.Show("Liên hệ với đội ngũ lập trình viên để được hỗ trợ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Lb_ForgotPass_Click(object sender, EventArgs e)
        {
            CLick_FogotPass(this, e);
            MessageBox.Show("Liên hệ với đội ngũ lập trình viên để được hỗ trợ", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            SetData();
            _Click(this, e);
        }

        
    }
}
