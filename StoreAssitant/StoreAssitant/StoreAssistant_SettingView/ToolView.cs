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

namespace StoreAssitant.StoreAssistant_SettingView
{
    public partial class ToolView : UserControl
    {
        public ToolView()
        {
            InitializeComponent();
            InitializeEventHandler();

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

        private void InitializeEventHandler()
        {
            itemChangePass.Click += ItemChangePass_Click;
            itemEmployee.Click += ItemEmployee_Click;
            itemLogOut.Click += ItemLogOut_Click;

            btnQuit.Click += BtnQuit_Click;

            itemStoreInfo.Click += ItemStoreInfo_Click;

            toolStrip1.SizeChanged += ToolStrip1_SizeChanged;
        }

        private void ToolStrip1_SizeChanged(object sender, EventArgs e)
        {
            this.Size = new Size(toolStrip1.Width, toolStrip1.Height - 3);
        }

        private void ItemStoreInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Công trình đang thi công!", "404 Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn muốn đóng ứng dụng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                AppManager.Exit();
            }
        }

        private void ItemLogOut_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn muốn đăng xuất tài khoản?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
            MessageBox.Show("Đổi mật khẩu thành công!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
