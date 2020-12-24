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

            Language.ChangeLanguage += Language_ChangeLanguage;

            this.Name = "mainForm";
            this.Icon = new Icon($"./Icons/main.ico");

            toolView1.SizeChanged += ToolView1_SizeChanged;
            toolView1.CheckUser();
            toolView1.ReloadData();
            SetLanguage();

            pnlMenu.BackColor = Color.FromArgb(200, 240, 128, 24);

            SignOut = new EventHandler(OnSignOut);

            tabSelector1.CheckUser();
            tabSelector1.SelectedTabChanged += TabSelector1_SelectedTabChanged;
            this.SizeChanged += Form1_SizeChanged;
            Form1_SizeChanged(this, null);

            CreateView();

            TabSelector1_SelectedTabChanged(tabSelector1, EventArgs.Empty);
        }

        void CreateView()
        {
            cashierView = new StoreAssistant_CashierView.CashierView();
            managerModifyView = new ManagerModifyView();
            historyView = new StoreAssistant_HistoryView.HistoryView();
            statiticsView = new StoreAssistant_StatiticsView.StatiticsView2();
            voucherView = new VoucherView();
        }

        private void Language_ChangeLanguage(object sender, string e)
        {
            SetLanguage();
        }

        public void SetLanguage()
        {
            toolView1.SetLanguge();
            tabSelector1.SetLanguage();
            /*
            string cul = "VI";
            if (AppManager._CurrentLanguage == StoreAssistant_SettingView.LanguageMode.VN) { cul = "VI"; }
            else if (AppManager._CurrentLanguage == StoreAssistant_SettingView.LanguageMode.EN) { cul = "EN"; }
            
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(cul);
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;
            Application.CurrentCulture = System.Threading.Thread.CurrentThread.CurrentCulture;
            */

        }

        public void LoadTheme()
        {
            pnlMenu.BackColor = AppManager.GetColors("Toolbar_Background");
            panel1.BackColor = AppManager.GetColors("Main_Background");
            tabSelector1.LoadTheme();
            toolView1.LoadTheme();
            if (cashierView != null) { cashierView.LoadTheme(); }
            if (managerModifyView != null) { managerModifyView.LoadTheme(); }
            if (historyView != null) { historyView.LoadTheme(); }
            if (statiticsView != null) { statiticsView.LoadTheme(); }
            if (voucherView != null) { voucherView.LoadTheme(); }
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
                    System.Drawing.Rectangle screen = System.Windows.Forms.Screen.FromControl(this).WorkingArea;
                    this.Size = screen.Size;
                    this.DesktopLocation = new Point(0, 0);
                    break;
            }
        }

        const int WS_MINIMIZEBOX = 0x20000;
        const int CS_DBLCLKS = 0x8;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= WS_MINIMIZEBOX;
                cp.ClassStyle |= CS_DBLCLKS;
                return cp;
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
                cashierView.LoadTheme();
                cashierView.LoadDataFromDB();
                SelectTab(cashierView);
            }
            else if (tabSelector1.SelectedTabKey == "btnManager")
            {
                if (managerModifyView == null)
                {
                    managerModifyView = new ManagerModifyView();
                }
                managerModifyView.LoadTheme();
                managerModifyView.LoadDataFromDB();
                SelectTab(managerModifyView);
            }
            else if (tabSelector1.SelectedTabKey == "btnHistory")
            {
                if (historyView == null)
                {
                    historyView = new StoreAssistant_HistoryView.HistoryView();
                }
                historyView.LoadTheme();
                historyView.GetData();
                SelectTab(historyView);
            }
            else if (tabSelector1.SelectedTabKey == "btnStatistic")
            {
                if (statiticsView == null)
                {
                    statiticsView = new StoreAssistant_StatiticsView.StatiticsView2();
                }
                statiticsView.LoadTheme();
                SelectTab(statiticsView);
            }
            else if (tabSelector1.SelectedTabKey == "btnVoucher")
            {
                if (voucherView == null)
                {
                    voucherView = new VoucherView();
                }
                voucherView.LoadTheme();
                voucherView.LoadDataFromDB();
                SelectTab(voucherView);
            }
            else
            {
                //something wrong here
            }
        }

        internal void LoadFont()
        {
            toolView1.LoadFont();
            tabSelector1.LoadFont();
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
            tab.BackColor = Color.Transparent;
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
