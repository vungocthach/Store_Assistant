using StoreAssitant.StoreAssistant_Helper;
using StoreAssitant.StoreAssistant_VoucherView;
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
        private string Lang = "vn";
        string Error = "Lỗi";
        string ErrorAgainPass = "Nhập lại mật khẩu không đúng";
        string ErrorNowPass = "Nhập mật khẩu hiện tại không đúng";
        string NewLikeOld = "Mật khẩu mới trùng với mật khẩu hiện tại";

        void OnChangePasswordOK(object sender, EventArgs e) { this.Close(); }

        public ChangePasswordForm()
        {
            InitializeComponent();

            if (Lang != AppManager.CurrentLanguage)
            {
                Lang = AppManager.CurrentLanguage;
                SetLanguage();
            }
            Language.ChangeLanguage += VoucherView_ChangeLanguage;

            if (Authenticator.CurrentUser == null) { throw new AuthenticationException("Current user's account must not be null"); }

            ChangePasswordOK = new EventHandler(OnChangePasswordOK);

            btn_Submit.Click += Btn_Submit_Click;
            btn_Close.Click += Btn_Close_Click;
        }

        private void VoucherView_ChangeLanguage(object sender, string e)
        {
            SetLanguage();
        }

        private void SetLanguage()
        {
            Language.InitLanguage(this);
            label1.Text = Language.Rm.GetString("Old password", Language.Culture);
            label2.Text = Language.Rm.GetString("New password", Language.Culture);
            label3.Text = Language.Rm.GetString("Re-enter new password", Language.Culture);
            this.Text = btn_Submit.Text = Language.Rm.GetString("Change password", Language.Culture);
            btn_Close.Text = Language.Rm.GetString("Cancel", Language.Culture);
            Error = Language.Rm.GetString("Error", Language.Culture);
            NewLikeOld = Language.Rm.GetString("NewLikeOld", Language.Culture);
            ErrorAgainPass = Language.Rm.GetString("ErrorAgainPass", Language.Culture);
            ErrorNowPass = Language.Rm.GetString("ErrorNowPass", Language.Culture);

        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (txt_PassNew.Text != txt_PassNew2.Text)
            {
                MessageBox.Show(ErrorAgainPass, Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_PassNew2.SelectAll();
                return;
            }

            if (txt_PassNew.Text.Trim() != Authenticator.CurrentUser.Pass)
            {
                MessageBox.Show("Mật khẩu không thể trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_PassNew.SelectAll();
                return;
            }

            if (txt_PassCurrent.Text != Authenticator.CurrentUser.Pass)
            {
                MessageBox.Show(ErrorNowPass, Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_PassCurrent.SelectAll();
                return;
            }

            if (txt_PassCurrent.Text == txt_PassNew.Text)
            {
                MessageBox.Show(NewLikeOld, Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
