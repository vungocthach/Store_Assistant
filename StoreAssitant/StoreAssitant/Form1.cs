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
using StoreAssitant.StoreAssistant_Authenticater;
using System.Security.Authentication;

namespace StoreAssitant
{
    public partial class Form1 : Form
    {

        StoreAssistant_CashierView.CashierView cashierView;
        ManagerModifyView managerModifyView;
        StoreAssistant_AccountView.AccountView accountView;
        StoreAssistant_StatiticsView.StatiticsView statiticsView;

        public event EventHandler SignOut;
        void OnSignOut(object sender, EventArgs e) {}

        public Form1()

        {
            InitializeComponent();

            SignOut = new EventHandler(OnSignOut);

            kryptonNavigator1.GotFocus += KryptonNavigator1_GotFocus;
            this.SizeChanged += Form1_SizeChanged;

            Form1_SizeChanged(this, null);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            panel1.Height = this.ClientSize.Height - kryptonNavigator1.Height;
        }

        private void AccountView1_ClickSignOut(object sender, EventArgs e)
        {
            this.SignOut(this, null);
        }

        public void LoadUser()
        {
            if (Authenticator.CurrentUser == null) { throw new AuthenticationException("Current user's account must not be null"); }
            kryptonNavigator1.SelectedPage = krPage_Cashier;
            kryptonNavigator1.SelectedPageChanged += KryptonNavigator1_SelectedPageChanged;
            KryptonNavigator1_SelectedPageChanged(kryptonNavigator1, new EventArgs());
            if (Authenticator.CurrentUser.Role == UserInfo.UserRole.Cashier)
            {
                kryptonNavigator1.Pages.Remove(krPage_Compare);
                kryptonNavigator1.Pages.Remove(krPage_Manager);
                kryptonNavigator1.Pages.Remove(krPage_Statistic);
                kryptonNavigator1.Pages.Remove(krPage_Voucher);
            }
        }

        void SelectTab(Control tab)
        {
            panel1.Controls.Clear();
            tab.Dock = DockStyle.Fill;
            panel1.Controls.Add(tab);
        }

        private void KryptonNavigator1_SelectedPageChanged(object sender, EventArgs e)
        {
            if (kryptonNavigator1.SelectedPage.Name == krPage_Cashier.Name)
            {
                if (cashierView == null)
                {
                    cashierView = new StoreAssistant_CashierView.CashierView();
                }
                cashierView.LoadDataFromDB();
                SelectTab(cashierView);
            }
            else if (kryptonNavigator1.SelectedPage.Name == krPage_Account.Name)
            {
                if (accountView == null)
                {
                    accountView = new StoreAssistant_AccountView.AccountView();
                    accountView.ClickSignOut += AccountView1_ClickSignOut;
                }
                accountView.SetData();
                SelectTab(accountView);
            }
            else if (kryptonNavigator1.SelectedPage.Name == krPage_Manager.Name)
            {
                if (managerModifyView == null)
                {
                    managerModifyView = new ManagerModifyView();
                }
                managerModifyView.LoadDataFromDB();
                SelectTab(managerModifyView);
            }
            else if (kryptonNavigator1.SelectedPage.Name == krPage_Compare.Name)
            {
                MessageBox.Show("Tính năng đang phát triển", "Công trình đang thi công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panel1.Controls.Clear();
            }
            else if (kryptonNavigator1.SelectedPage.Name == krPage_Setting.Name)
            {
                MessageBox.Show("Tính năng đang phát triển", "Công trình đang thi công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panel1.Controls.Clear();
            }
            else if (kryptonNavigator1.SelectedPage.Name == krPage_Statistic.Name)
            {
                if (statiticsView == null)
                {
                    statiticsView = new StoreAssistant_StatiticsView.StatiticsView();
                }
                SelectTab(statiticsView);
            }
            else
            {
                MessageBox.Show("Invalid tab", "Unknow error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panel1.Controls.Clear();
            }
        }

        private void KryptonNavigator1_GotFocus(object sender, EventArgs e)
        {
            KryptonNavigator navigator = (KryptonNavigator)sender;
            navigator.SelectedPage.Focus();
        }

    }
}
