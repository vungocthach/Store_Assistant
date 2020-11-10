using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreAssitant.StoreAssistant_Authenticater
{
    public partial class ChangePasswordForm : Form
    {
        public event EventHandler ChangePasswordOK;
        void OnChangePasswordOK(object sender, EventArgs e) { this.Close(); }

        public ChangePasswordForm()
        {
            InitializeComponent();

            if (Authenticator.CurrentUser == null) { throw new AuthenticationException("Current user's account must not be null"); }

            ChangePasswordOK = new EventHandler(OnChangePasswordOK);

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
                txt_PassNew2.SelectAll();
                return;
            }

            if (txt_PassCurrent.Text != Authenticator.CurrentUser.Pass)
            {
                MessageBox.Show("Mật khẩu hiện tại không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_PassCurrent.SelectAll();
                return;
            }

            if (txt_PassCurrent.Text == txt_PassNew.Text)
            {
                MessageBox.Show("Mật khẩu mới trùng với mật khẩu hiện tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_PassNew.SelectAll();
                return;
            }

            if (Authenticator.ChangeCurrentPassword(txt_PassNew.Text))
            {
                ChangePasswordOK(this, new EventArgs());
            }
        }
    }
}
