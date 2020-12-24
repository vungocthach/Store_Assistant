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

namespace StoreAssitant.StoreAssistant_SettingView
{
    public partial class SettingView : UserControl
    {
        public SettingView()
        {
            InitializeComponent();
            InitializeEventHandler();

            foreach (var e in Enum.GetValues(typeof(LanguageMode)))
            {
                cbbLanguage.Items.Add(e.ToString());
            }
            foreach (var e in Enum.GetValues(typeof(ThemeMode)))
            {
                cbbTheme.Items.Add(e.ToString());
            }
            foreach (var e in Enum.GetValues(typeof(SizeMode)))
            {
                cbbWindowSize.Items.Add(e.ToString());
            }

            btnEdit.Enabled = true;
            btnSave.Enabled = false;
        }

        private void InitializeEventHandler()
        {
            cbbLanguage.SelectedIndexChanged += CbbLanguage_SelectedIndexChanged;
            cbbTheme.SelectedIndexChanged += CbbTheme_SelectedIndexChanged;
            cbbWindowSize.SelectedIndexChanged += CbbWindowSize_SelectedIndexChanged;

            btnEdit.Click += BtnEdit_Click;
            btnSave.EnabledChanged += BtnSave_EnabledChanged;
            btnSave.Click += BtnSave_Click;

            this.Load += SettingView_Load;
        }

        private void SettingView_Load(object sender, EventArgs e)
        {
            if (StoreAssistant_Authenticater.Authenticator.CurrentUser.Role != UserInfo.UserRole.Manager)
            {
                btnEdit.Enabled = false;
            }
        }

        private void BtnSave_EnabledChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = txtStore_Name.ReadOnly = txtStore_Phone.ReadOnly = txtStore_Web.ReadOnly = !(sender as Control).Enabled;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!CheckNumeric(txtStore_Phone.Text.Trim()))
            {
                MessageBox.Show("Số điện thoại không hợp lệ", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtStore_Phone.SelectAll();
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có muốn lưu thay đổi?", "Lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                AppManager.StoreInformation = new StoreInformation()
                {
                    Name = txtStore_Name.Text.Trim(),
                    PhoneNumber = txtStore_Phone.Text.Trim(),
                    WebAddress = txtStore_Web.Text.Trim()
                };
            }

            btnSave.Enabled = false;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void CbbWindowSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppManager.ChangeWindowSize((SizeMode)(sender as ComboBox).SelectedIndex);
        }

        private void CbbTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppManager.ChangeTheme((ThemeMode)(sender as ComboBox).SelectedIndex);
        }

        private void CbbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppManager.ChangeLanguage((LanguageMode)(sender as ComboBox).SelectedIndex);
        }

        public void ReloadData()
        {
            AppManager.LoadPreferences();
            SetData(AppManager.StoreInformation, (int)AppManager._CurrentLanguage, (int)AppManager.CurrentTheme, (int)AppManager.CurrentWindowSize);
        }

        public void SetData(StoreInformation storeInformation, int language, int theme, int windowSize)
        {
            txtStore_Name.Text = storeInformation.Name;
            txtStore_Phone.Text = storeInformation.PhoneNumber;
            txtStore_Web.Text = storeInformation.WebAddress;

            cbbLanguage.SelectedIndex = language;
            cbbTheme.SelectedIndex = theme;
            cbbWindowSize.SelectedIndex = windowSize;
        }

        bool CheckNumeric(string str)
        {
            string filter = "0123456789";
            foreach (char c in str)
            {
                if (!filter.Contains(c)) { return false; }
            }
            return true;
        }
    }
}
