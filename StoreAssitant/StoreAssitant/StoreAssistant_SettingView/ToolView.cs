using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StoreAssitant.StoreAssistant_Helper;
using StoreAssitant.StoreAssistant_Authenticater;
using StoreAssitant.StoreAssistant_AccountView;
using StoreAssitant.StoreAssistant_VoucherView;

namespace StoreAssitant.StoreAssistant_SettingView
{
    public partial class ToolView : UserControl
    {
        string Lang = "vn";
        string hi = "Xin chào";
        string CloseApp = "Bạn muốn đóng ứng dụng?";
        string Define = "Xác nhận";
        string DelAcc = "Bạn muốn đăng xuất tài khoản?";
        string Project_ing = "Công trình đang thi công!";
        string Error404 = "404 Not Found";
        string SuccessChangePass = "Đổi mật khẩu thành công";

        private static void onChangeLanguage(object sender, string typelang)
        {

        }

        public static event EventHandler<string> ChangeLanguage = new EventHandler<string>(onChangeLanguage);

        public ToolView()
        {
            InitializeComponent();
            InitializeEventHandler();

            tiếngViệtToolStripMenuItem.Click += TiếngViệtToolStripMenuItem_Click;
            englishToolStripMenuItem.Click += EnglishToolStripMenuItem_Click;

            if ( Lang != Language.CultureName)
            {
                Lang = Language.CultureName;
                SetLangugage();
            }
            ToolView.ChangeLanguage += ToolView_ChangeLanguage;

            itemLanguage.DropDownItems.Clear();
            foreach (LanguageMode e in Enum.GetValues(typeof(LanguageMode)))
            {
                string text = e.ToString();
                var item = AddItem_Checkable(itemLanguage, text, text);
                item.Click += (s, arg) =>
                {
                    AppManager.ChangeLanguage(e);
                };
            }
            itemTheme.DropDownItems.Clear();
            foreach (ThemeMode e in Enum.GetValues(typeof(ThemeMode)))
            {
                string text = e.ToString();
                var item = AddItem_Checkable(itemTheme, text, text);
                item.Click += (s, arg) =>
                {
                    AppManager.ChangeTheme(e);
                };
            }
            itemWindowSize.DropDownItems.Clear();
            foreach (SizeMode e in Enum.GetValues(typeof(SizeMode)))
            {
                string text = e.ToString();
                var item = AddItem_Checkable(itemWindowSize, text, text);
                item.Click += (s, arg) =>
                {
                    AppManager.ChangeWindowSize(e);
                };
            }

        }

        private void EnglishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Language.CultureName = "en";
            MessageBox.Show("en");
            ChangeLanguage(sender, "en");
        }

        private void TiếngViệtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Language.CultureName = "vn";
            MessageBox.Show("vn");
            ChangeLanguage(sender, "vn");
        }

        private void ToolView_ChangeLanguage(object sender, string e)
        {
            SetLangugage();
        }

        public void SetLangugage()
        {
            Language.InitLanguage(this);
            btnAccount.Text = Language.Rm.GetString("Hi", Language.Culture) + " " + StoreAssistant_Authenticater.Authenticator.CurrentUser.UserName;
            btnSetting.Text = Language.Rm.GetString("Setting", Language.Culture);
            btnAccount.DropDownItems[1].Text = Language.Rm.GetString("Change password", Language.Culture);
            btnAccount.DropDownItems[0].Text = Language.Rm.GetString("Human Resource Management", Language.Culture);
            btnAccount.DropDownItems[2].Text = Language.Rm.GetString("Sign out", Language.Culture);
            btnSetting.DropDownItems[0].Text = Language.Rm.GetString("Language", Language.Culture);
            btnSetting.DropDownItems[2].Text = Language.Rm.GetString("Doorsize", Language.Culture);
            btnSetting.DropDownItems[3].Text = Language.Rm.GetString("StoreInfo", Language.Culture);
            CloseApp = Language.Rm.GetString("CloseApp", Language.Culture);
            Define = Language.Rm.GetString("Define", Language.Culture);
            DelAcc = Language.Rm.GetString("DelAcc", Language.Culture);
            Project_ing = Language.Rm.GetString("Project_ing", Language.Culture);
            SuccessChangePass = Language.Rm.GetString("SuccessChangePass", Language.Culture);
        }

            private void InitializeEventHandler()
        {
            itemChangePass.Click += ItemChangePass_Click;
            itemEmployee.Click += ItemEmployee_Click;
            itemLogOut.Click += ItemLogOut_Click;

            btnQuit.Click += BtnQuit_Click;

            itemStoreInfo.Click += ItemStoreInfo_Click;

            toolStrip1.SizeChanged += ToolStrip1_SizeChanged;

            this.Load += ToolView_Load;
        }

        private void ToolView_Load(object sender, EventArgs e)
        {
            if (Authenticator.CurrentUser.Role != UserInfo.UserRole.Manager)
            {
                itemEmployee.Enabled = false;
                itemStoreInfo.Enabled = false;
            }
        }

        private void ToolStrip1_SizeChanged(object sender, EventArgs e)
        {
            this.Size = new Size(toolStrip1.Width, toolStrip1.Height - 3);
        }

        private void ItemStoreInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Project_ing,Error404 , MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(CloseApp, Define , MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                AppManager.Exit();
            }
        }

        private void ItemLogOut_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(DelAcc, Define, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                AppManager.Restart();
            }
        }

        private void ItemEmployee_Click(object sender, EventArgs e)
        {
            AccountManamentForm form = new AccountManamentForm();
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void ItemChangePass_Click(object sender, EventArgs e)
        {
            ChangePasswordForm changePasswordForm = new ChangePasswordForm();
            changePasswordForm.ChangePasswordOK += ChangePasswordForm_ChangePasswordOK;
            changePasswordForm.StartPosition = FormStartPosition.CenterScreen;
            changePasswordForm.ShowDialog();
            changePasswordForm.Dispose();
        }

        private void ChangePasswordForm_ChangePasswordOK(object sender, EventArgs e)
        {
            MessageBox.Show(SuccessChangePass, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        ToolStripMenuItem AddItem_Checkable(ToolStripMenuItem parent, string name, string text)
        {
            ToolStripMenuItem rs = new ToolStripMenuItem();
            rs.Name = name;
            rs.Text = text;
            rs.Click += (s, e) =>
            {
                foreach (ToolStripMenuItem child in parent.DropDownItems)
                {
                    child.Image = null;
                }
                rs.Image = Properties.Resources.iconfinder_f_check_256_282474_20x20;
            };
            parent.DropDownItems.Add(rs);
            return rs;
        }

        public void ReloadData()
        {
            AppManager.LoadPreferences();
            itemLanguage.DropDownItems[AppManager.CurrentLanguage.ToString()].Image = Properties.Resources.iconfinder_f_check_256_282474_20x20;

            itemTheme.DropDownItems[AppManager.CurrentTheme.ToString()].Image = Properties.Resources.iconfinder_f_check_256_282474_20x20;

            itemWindowSize.DropDownItems[AppManager.CurrentWindowSize.ToString()].Image = Properties.Resources.iconfinder_f_check_256_282474_20x20;

            btnAccount.Text = string.Format("Xin chào, {0}", StoreAssistant_Authenticater.Authenticator.CurrentUser.UserName);
            //ToolStrip1_SizeChanged(toolStrip1, null);
        }
    }
}
