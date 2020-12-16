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
using StoreAssitant.StoreAssistant_VoucherView;
using StoreAssitant.StoreAssistant_Helper;

namespace StoreAssitant
{
    public partial class Form1 : Form
    {
        StoreAssistant_CashierView.CashierView cashierView;
        ManagerModifyView managerModifyView;
        StoreAssistant_AccountView.AccountView accountView;
        StoreAssistant_HistoryView.HistoryView historyView;
        StoreAssistant_StatiticsView.StatiticsView2 statiticsView;
        StoreAssistant_VoucherView.VoucherView voucherView;
        StoreAssistant_SettingView.SettingView settingView;

        public event EventHandler SignOut;
        void OnSignOut(object sender, EventArgs e) {}

        public Form1()
        {
            InitializeComponent();

            this.Name = "mainForm";

            toolView1.SizeChanged += ToolView1_SizeChanged;
            toolView1.ReloadData();

            pnlMenu.BackColor = Color.FromArgb(200, 240, 128, 24);

            SignOut = new EventHandler(OnSignOut);

            tabSelector1.SelectedTabChanged += TabSelector1_SelectedTabChanged;
            TabSelector1_SelectedTabChanged(tabSelector1, EventArgs.Empty);
            this.SizeChanged += Form1_SizeChanged;
            Form1_SizeChanged(this, null);
        }

        public void LoadWindowSize()
        {
            switch (AppManager.CurrentWindowSize)
            {
                case StoreAssistant_SettingView.SizeMode._1024x768:
                    this.WindowState = FormWindowState.Normal;
                    this.Width = 1024;
                    this.Height = 768;
                    break;
                case StoreAssistant_SettingView.SizeMode._1366x768:
                    this.WindowState = FormWindowState.Normal;
                    this.Width = 1366;
                    this.Height = 768;
                    break;
                case StoreAssistant_SettingView.SizeMode._1680x1050:
                    this.WindowState = FormWindowState.Normal;
                    this.Width = 1680;
                    this.Height = 1050;
                    break;
                case StoreAssistant_SettingView.SizeMode.FullScreen:
                    this.WindowState = FormWindowState.Maximized;
                    break;
            }
        }

        private void ToolView1_SizeChanged(object sender, EventArgs e)
        {
            toolView1.Location = new Point(this.Width - toolView1.Width - toolView1.Margin.Right, toolView1.Location.Y);
        }

        private void TabSelector1_SelectedTabChanged(object sender, EventArgs e)
        {
            if (tabSelector1.SelectedTabKey == "btnCashier")
            {
                if (cashierView == null)
                {
                    cashierView = new StoreAssistant_CashierView.CashierView();
                }
                cashierView.LoadDataFromDB();
                SelectTab(cashierView);
            }
            else if (tabSelector1.SelectedTabKey == "btnAccount")
            {
                if (accountView == null)
                {
                    accountView = new StoreAssistant_AccountView.AccountView();
                    accountView.ClickSignOut += AccountView1_ClickSignOut;
                }
                accountView.SetData();
                SelectTab(accountView);
            }
            else if (tabSelector1.SelectedTabKey == "btnManager")
            {
                if (managerModifyView == null)
                {
                    managerModifyView = new ManagerModifyView();
                }
                managerModifyView.LoadDataFromDB();
                SelectTab(managerModifyView);
            }
            else if (tabSelector1.SelectedTabKey == "btnHistory")
            {
                if (historyView == null)
                {
                    historyView = new StoreAssistant_HistoryView.HistoryView();
                }
                historyView.GetData();
                SelectTab(historyView);
            }
            else if (tabSelector1.SelectedTabKey == "btnSetting")
            {
                if (settingView == null)
                {
                    settingView = new StoreAssistant_SettingView.SettingView();
                }
                settingView.ReloadData();
                SelectTab(settingView);
            }
            else if (tabSelector1.SelectedTabKey == "btnStatistic")
            {
                if (statiticsView == null)
                {
                    statiticsView = new StoreAssistant_StatiticsView.StatiticsView2();
                }
                SelectTab(statiticsView);
            }
            else if (tabSelector1.SelectedTabKey == "btnVoucher")
            {
                //something wrong here
                if (voucherView == null)
                {
                    voucherView = new VoucherView();
                }
                voucherView.LoadDataFromDB();
                SelectTab(voucherView);
            }
            else
            {

            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            panel1.Height = this.ClientSize.Height - pnlMenu.Height;
        }

        private void AccountView1_ClickSignOut(object sender, EventArgs e)
        {
            this.SignOut(this, null);
        }

        public void LoadUser()
        {
            if (Authenticator.CurrentUser == null) { throw new AuthenticationException("Current user's account must not be null"); }
            /*
            kryptonNavigator1.SelectedPage = krPage_Cashier;
            kryptonNavigator1.SelectedPageChanged += KryptonNavigator1_SelectedPageChanged;
            KryptonNavigator1_SelectedPageChanged(kryptonNavigator1, new EventArgs());
            if (Authenticator.CurrentUser.Role == UserInfo.UserRole.Cashier)
            {
                kryptonNavigator1.Pages.Remove(krPage_History);
                kryptonNavigator1.Pages.Remove(krPage_Manager);
                kryptonNavigator1.Pages.Remove(krPage_Statistic);
                kryptonNavigator1.Pages.Remove(krPage_Voucher);
            }
            */
        }

        void SelectTab(Control tab)
        {
            panel1.Controls.Clear();
            tab.Dock = DockStyle.Fill;
            panel1.Controls.Add(tab);
        }

        private void KryptonNavigator1_SelectedPageChanged(object sender, EventArgs e)
        {
            
        }

        private void KryptonNavigator1_GotFocus(object sender, EventArgs e)
        {
            KryptonNavigator navigator = (KryptonNavigator)sender;
            navigator.SelectedPage.Focus();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
