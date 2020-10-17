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

        public Form1()

        {
            InitializeComponent();

            kryptonNavigator1.GotFocus += KryptonNavigator1_GotFocus;
        }

        public void LoadUser(UserInfo user)
        {
            if (user.Role == UserInfo.UserRole.Cashier)
            {
                krPage_Account.Enabled = false;
                krPage_Compare.Enabled = false;
                krPage_Manager.Enabled = false;
                krPage_Setting.Enabled = false;
                krPage_Statistic.Enabled = false;
            }
        }

        private void KryptonNavigator1_GotFocus(object sender, EventArgs e)
        {
            KryptonNavigator navigator = (KryptonNavigator)sender;
            navigator.SelectedPage.Focus();
        }

    }
}
