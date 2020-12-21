using System;
using System.Drawing;
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
                    MessageBox.Show("Ứng dụng sẽ khởi động lại để đổi theme");
                    Application.Restart();
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

        public void CheckUser()
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

            btnAccount.Text = string.Format("Xin chào, {0}", Authenticator.CurrentUser.UserName);
        }

        public void LoadTheme()
        {
            toolStrip1.Renderer = new ToolStripProfessionalRenderer(new CustomProfessionalColors());
            toolStrip1.ForeColor = AppManager.GetColors("Main_Plaintext");
            foreach (ToolStripItem item in toolStrip1.Items)
            {
                if (item is ToolStripDropDownItem drop)
                {
                    ChangeForeColor(drop, toolStrip1.ForeColor);
                }
                else
                {
                    item.ForeColor = toolStrip1.ForeColor;
                }
            }
        }

        void ChangeForeColor(ToolStripDropDownItem control, Color color)
        {
            control.ForeColor = color;
            foreach (ToolStripDropDownItem child in control.DropDownItems)
            {
                if (child.DropDownItems.Count > 0) { ChangeForeColor(child, color); }
                else { child.ForeColor = color; }
            }
        }
    }

    class CustomProfessionalColors : ProfessionalColorTable
    {
        public override Color ToolStripDropDownBackground => AppManager.GetColors("Menuitem_Background");

        public override Color ImageMarginGradientBegin => ToolStripDropDownBackground;
        public override Color ImageMarginGradientMiddle => ToolStripDropDownBackground;
        public override Color ImageMarginGradientEnd => ToolStripDropDownBackground;

        public override Color MenuItemSelected => AppManager.GetColors("Menuitem_Selected");
        public override Color MenuItemBorder => MenuItemSelected;
        public override Color ButtonSelectedBorder => MenuItemSelected;

        public override Color MenuItemPressedGradientBegin => MenuItemSelected;
        public override Color MenuItemPressedGradientMiddle => MenuItemSelected;
        public override Color MenuItemPressedGradientEnd => AppManager.GetColors("Toolbar_Background");

        public override Color ButtonSelectedHighlight => MenuItemSelected;
        public override Color ButtonSelectedGradientBegin => MenuItemSelected;
        public override Color ButtonSelectedGradientMiddle => MenuItemSelected;
        public override Color ButtonSelectedGradientEnd => MenuItemSelected;
    }
}
