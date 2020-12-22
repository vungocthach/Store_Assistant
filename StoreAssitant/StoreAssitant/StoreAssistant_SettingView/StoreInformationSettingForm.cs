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
        public StoreInformationSettingForm()
        {
            InitializeComponent();

            btnSave.Click += BtnSave_Click;
            btnClose.Click += BtnClose_Click;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
