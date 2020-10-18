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



        public event EventHandler SignOut;
        void OnSignOut(object sender, EventArgs e) {}

        public Form1()

        {
            InitializeComponent();

            SignOut = new EventHandler(OnSignOut);

            kryptonNavigator1.GotFocus += KryptonNavigator1_GotFocus;

            accountView1.ClickSignOut += AccountView1_ClickSignOut;
        }

        private void AccountView1_ClickSignOut(object sender, EventArgs e)
        {
            this.SignOut(this, null);
        }

        public void LoadUser(UserInfo user)
        {
            this.user = user;
            kryptonNavigator1.SelectedPage = krPage_Cashier;
            kryptonNavigator1.SelectedPageChanged += KryptonNavigator1_SelectedPageChanged;
            cashierView1.LoadDataFromDB();
            if (user.Role == UserInfo.UserRole.Cashier)
            {
                kryptonNavigator1.Pages.Remove(krPage_Compare);
                kryptonNavigator1.Pages.Remove(krPage_Manager);
                kryptonNavigator1.Pages.Remove(krPage_Statistic);
            }
        }

        private void KryptonNavigator1_SelectedPageChanged(object sender, EventArgs e)
        {
            if (kryptonNavigator1.SelectedPage.Name == krPage_Cashier.Name)
            {
                cashierView1.LoadDataFromDB();
            }
            else if (kryptonNavigator1.SelectedPage.Name == krPage_Account.Name)
            {
                accountView1.SetData(user);
            }
            else if (kryptonNavigator1.SelectedPage.Name == krPage_Manager.Name)
            {
                managerModifyView1.LoadDataFromDB();
            }
        }

        private void KryptonNavigator1_GotFocus(object sender, EventArgs e)
        {
            KryptonNavigator navigator = (KryptonNavigator)sender;
            navigator.SelectedPage.Focus();
        }

    }
}
