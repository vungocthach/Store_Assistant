using StoreAssitant.StoreAssistant_Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreAssitant.StoreAssistant_AccountView
{
    public partial class AccountManamentForm : Form
    {
        string Lang = "vn";

        string Define = "Xác nhận";
        string CheckLogOut = "Bạn muốn đăng xuất tài khoản?";

        public AccountManamentForm()
        {
            InitializeComponent();
            if (Lang != AppManager.CurrentLanguage)
            {
                Lang = AppManager.CurrentLanguage;
                SetLanguage();
            }

            accountView1.ClickSignOut += AccountView1_Click;
            Language.ChangeLanguage += Language_ChangeLanguage;
            accountView1.SetData();
        }

        private void AccountView1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(CheckLogOut, Define, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                AppManager.Restart();
            }
        }

        public void SetLanguage()
        {
            Language.InitLanguage(this);
            this.Text = Language.Rm.GetString("Human Resource Management", Language.Culture);

            Define = Language.Rm.GetString("Define", Language.Culture);
            CheckLogOut = Language.Rm.GetString("CheckLogOut", Language.Culture);
        }
        private void Language_ChangeLanguage(object sender, string e)
        {
            SetLanguage();
        }
    }
}
