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

namespace StoreAssitant.StoreAssistant_SettingView
{
    public partial class StoreInformationSettingForm : Form
    {
        string Lang = "vn";
        string illegalPhonenumber= "Số điện thoại không hợp lệ";
        string ErorFormat= "Lỗi định dạng";
        string SaveChange = "Bạn có muốn lưu thay đổi?";
        string Save = "Lưu";
        string InfoSrore = "Thông tin cửa hàng";

        public StoreInformationSettingForm()
        {
            InitializeComponent();

            if (Lang != AppManager.CurrentLanguage)
            {
                Lang = AppManager.CurrentLanguage;
                SetLanguage();
            }

            Language.ChangeLanguage += Language_ChangeLanguage;

            btnSave.Click += BtnSave_Click;
            btnClose.Click += BtnClose_Click;
        }

        private void Language_ChangeLanguage(object sender, string e)
        {
            SetLanguage();
        }

        private void SetLanguage()
        {
            illegalPhonenumber = Language.Rm.GetString("illegalPhonenumber", Language.Culture);
            ErorFormat = Language.Rm.GetString("ErorFormat", Language.Culture);
            SaveChange = Language.Rm.GetString("SaveChange", Language.Culture);
            Save = Language.Rm.GetString("Save", Language.Culture);
            label1.Text = Language.Rm.GetString("Namestore:", Language.Culture);
            label2.Text = Language.Rm.GetString("Phone:", Language.Culture);
            label3.Text = Language.Rm.GetString("Website:", Language.Culture);
            this.Text = Language.Rm.GetString("InfoSrore", Language.Culture);
            btnSave.Text = Language.Rm.GetString("Save", Language.Culture);
            btnClose.Text = Language.Rm.GetString("Out", Language.Culture);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!CheckNumeric(txtStore_Phone.Text.Trim()))
            {
                MessageBox.Show(illegalPhonenumber, ErorFormat, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtStore_Phone.SelectAll();
                return;
            }

            DialogResult dialogResult = MessageBox.Show(SaveChange,Save, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                AppManager.StoreInformation = new StoreInformation()
                {
                    Name = txtStore_Name.Text.Trim(),
                    PhoneNumber = txtStore_Phone.Text.Trim(),
                    WebAddress = txtStore_Web.Text.Trim()
                };
            }
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
