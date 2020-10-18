using ComponentFactory.Krypton.Navigator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreAssitant
{
    public partial class Form1 : Form
    {
        UserInfo user;

        public Form1()

        {
            InitializeComponent();

            kryptonNavigator1.GotFocus += KryptonNavigator1_GotFocus;

            cashierView1.LoadDataFromDB();
            managerModifyView1.LoadDataFromDB();
        }

        public void LoadUser(UserInfo user)
        {
            this.user = user;
            kryptonNavigator1.SelectedPageChanged += KryptonNavigator1_SelectedPageChanged;
            /*
            if (user.Role == UserInfo.UserRole.Cashier)
            {
                krPage_Account.Enabled = false;
                krPage_Compare.Enabled = false;
                krPage_Manager.Enabled = false;
                krPage_Setting.Enabled = false;
                krPage_Statistic.Enabled = false;
            }
            */
        }

        private void KryptonNavigator1_SelectedPageChanged(object sender, EventArgs e)
        {
            if (kryptonNavigator1.SelectedIndex > 0 && user.Role == UserInfo.UserRole.Cashier)
            {
                kryptonNavigator1.SelectedPage.Controls.Clear();
                MessageBox.Show("Bạn cần dùng tài khoản cấp Manager để truy cập", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                switch (kryptonNavigator1.SelectedIndex)
                {
                    case 0:
                        cashierView1.LoadDataFromDB();
                        break;
                    case 1:
                        managerModifyView1.LoadDataFromDB();
                        break;
                }
            }
        }

        private void KryptonNavigator1_GotFocus(object sender, EventArgs e)
        {
            KryptonNavigator navigator = (KryptonNavigator)sender;
            navigator.SelectedPage.Focus();
        }

    }
}
