namespace StoreAssitant
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.kryptonNavigator1 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.list_Icons = new System.Windows.Forms.ImageList(this.components);
            this.kryptonPage1 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.krPage_Manager = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.krPage_Statistic = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.krPage_Compare = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.krPage_Setting = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.krPage_Account = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.krPage_Cashier = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.split_Cashier = new System.Windows.Forms.SplitContainer();
            this.cashierView1 = new StoreAssitant.StoreAssistant_CashierView.CashierView();
            this.managerModifyView1 = new StoreAssitant.ManagerModifyView();
            this.accountView1 = new StoreAssitant.StoreAssistant_AccountView.AccountView();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).BeginInit();
            this.kryptonNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).BeginInit();
            this.kryptonPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.krPage_Manager)).BeginInit();
            this.krPage_Manager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.krPage_Statistic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.krPage_Compare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.krPage_Setting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.krPage_Account)).BeginInit();
            this.krPage_Account.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.krPage_Cashier)).BeginInit();
            this.krPage_Cashier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_Cashier)).BeginInit();
            this.split_Cashier.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonNavigator1
            // 
            this.kryptonNavigator1.Bar.BarFirstItemInset = 10;
            this.kryptonNavigator1.Bar.BarMapImage = ComponentFactory.Krypton.Navigator.MapKryptonPageImage.Medium;
            this.kryptonNavigator1.Bar.BarMapText = ComponentFactory.Krypton.Navigator.MapKryptonPageText.Text;
            this.kryptonNavigator1.Bar.BarMinimumHeight = 30;
            this.kryptonNavigator1.Bar.ItemMinimumSize = new System.Drawing.Size(20, 50);
            this.kryptonNavigator1.Bar.ItemSizing = ComponentFactory.Krypton.Navigator.BarItemSizing.SameWidthAndHeight;
            this.kryptonNavigator1.Bar.TabBorderStyle = ComponentFactory.Krypton.Toolkit.TabBorderStyle.RoundedEqualMedium;
            this.kryptonNavigator1.Button.ButtonDisplayLogic = ComponentFactory.Krypton.Navigator.ButtonDisplayLogic.None;
            this.kryptonNavigator1.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonNavigator1.Group.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.ControlRibbon;
            this.kryptonNavigator1.Location = new System.Drawing.Point(0, 0);
            this.kryptonNavigator1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonNavigator1.Name = "kryptonNavigator1";
            this.kryptonNavigator1.NavigatorMode = ComponentFactory.Krypton.Navigator.NavigatorMode.BarRibbonTabGroup;
            this.kryptonNavigator1.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.kryptonPage1,
            this.krPage_Manager,
            this.krPage_Statistic,
            this.krPage_Compare,
            this.krPage_Setting,
            this.krPage_Account});
            this.kryptonNavigator1.SelectedIndex = 0;
            this.kryptonNavigator1.Size = new System.Drawing.Size(1182, 642);
            this.kryptonNavigator1.TabIndex = 0;
            this.kryptonNavigator1.Text = "kryptonNavigator1";
            this.kryptonNavigator1.ToolTips.AllowButtonSpecToolTips = true;
            // 
            // list_Icons
            // 
            this.list_Icons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.list_Icons.ImageSize = new System.Drawing.Size(48, 48);
            this.list_Icons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // kryptonPage1
            // 
            this.kryptonPage1.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage1.Controls.Add(this.cashierView1);
            this.kryptonPage1.Flags = 65534;
            this.kryptonPage1.ImageMedium = global::StoreAssitant.Properties.Resources.iconfinder_shopping_shop_buy_discount_18_4038845;
            this.kryptonPage1.LastVisibleSet = true;
            this.kryptonPage1.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage1.Name = "kryptonPage1";
            this.kryptonPage1.Size = new System.Drawing.Size(1178, 581);
            this.kryptonPage1.Text = "Thu Ngân";
            this.kryptonPage1.TextTitle = "Thu Ngân";
            this.kryptonPage1.ToolTipTitle = "Page ToolTip";
            this.kryptonPage1.UniqueName = "2D873126D12143AEF684413B153FC94F";
            // 
            // krPage_Manager
            // 
            this.krPage_Manager.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.krPage_Manager.Controls.Add(this.managerModifyView1);
            this.krPage_Manager.Flags = 65534;
            this.krPage_Manager.ImageMedium = ((System.Drawing.Image)(resources.GetObject("krPage_Manager.ImageMedium")));
            this.krPage_Manager.LastVisibleSet = true;
            this.krPage_Manager.Margin = new System.Windows.Forms.Padding(2);
            this.krPage_Manager.MinimumSize = new System.Drawing.Size(38, 41);
            this.krPage_Manager.Name = "krPage_Manager";
            this.krPage_Manager.Size = new System.Drawing.Size(1178, 581);
            this.krPage_Manager.Text = "Quản Lý";
            this.krPage_Manager.TextTitle = "Quản Lý";
            this.krPage_Manager.ToolTipTitle = "Page ToolTip";
            this.krPage_Manager.UniqueName = "FA578BA728E9497C71A0C6237C4FD78D";
            // 
            // krPage_Statistic
            // 
            this.krPage_Statistic.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.krPage_Statistic.Flags = 65534;
            this.krPage_Statistic.ImageMedium = ((System.Drawing.Image)(resources.GetObject("krPage_Statistic.ImageMedium")));
            this.krPage_Statistic.LastVisibleSet = true;
            this.krPage_Statistic.Margin = new System.Windows.Forms.Padding(2);
            this.krPage_Statistic.MinimumSize = new System.Drawing.Size(38, 41);
            this.krPage_Statistic.Name = "krPage_Statistic";
            this.krPage_Statistic.Size = new System.Drawing.Size(1178, 581);
            this.krPage_Statistic.Text = "Thống Kê";
            this.krPage_Statistic.TextTitle = "Thống Kê";
            this.krPage_Statistic.ToolTipTitle = "Page ToolTip";
            this.krPage_Statistic.UniqueName = "63A53B984CEF407D80BF22DD37C86130";
            // 
            // krPage_Compare
            // 
            this.krPage_Compare.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.krPage_Compare.Flags = 65534;
            this.krPage_Compare.ImageMedium = ((System.Drawing.Image)(resources.GetObject("krPage_Compare.ImageMedium")));
            this.krPage_Compare.LastVisibleSet = true;
            this.krPage_Compare.MinimumSize = new System.Drawing.Size(50, 50);
            this.krPage_Compare.Name = "krPage_Compare";
            this.krPage_Compare.Size = new System.Drawing.Size(1178, 581);
            this.krPage_Compare.Text = "So Sánh";
            this.krPage_Compare.TextTitle = "So Sánh";
            this.krPage_Compare.ToolTipTitle = "Page ToolTip";
            this.krPage_Compare.UniqueName = "70E04151CD72421574B935D9BFB02EA1";
            // 
            // krPage_Setting
            // 
            this.krPage_Setting.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.krPage_Setting.Flags = 65534;
            this.krPage_Setting.ImageMedium = ((System.Drawing.Image)(resources.GetObject("krPage_Setting.ImageMedium")));
            this.krPage_Setting.LastVisibleSet = true;
            this.krPage_Setting.Margin = new System.Windows.Forms.Padding(2);
            this.krPage_Setting.MinimumSize = new System.Drawing.Size(38, 41);
            this.krPage_Setting.Name = "krPage_Setting";
            this.krPage_Setting.Size = new System.Drawing.Size(1178, 581);
            this.krPage_Setting.Text = "Cài Đặt";
            this.krPage_Setting.TextTitle = "Cài Đặt";
            this.krPage_Setting.ToolTipTitle = "Page ToolTip";
            this.krPage_Setting.UniqueName = "E78AB1709FA246255796E09FE4A65912";
            // 
            // krPage_Account
            // 
            this.krPage_Account.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.krPage_Account.Controls.Add(this.accountView1);
            this.krPage_Account.Flags = 65534;
            this.krPage_Account.ImageMedium = ((System.Drawing.Image)(resources.GetObject("krPage_Account.ImageMedium")));
            this.krPage_Account.LastVisibleSet = true;
            this.krPage_Account.Margin = new System.Windows.Forms.Padding(2);
            this.krPage_Account.MinimumSize = new System.Drawing.Size(38, 41);
            this.krPage_Account.Name = "krPage_Account";
            this.krPage_Account.Size = new System.Drawing.Size(1178, 581);
            this.krPage_Account.Text = "Tài Khoản";
            this.krPage_Account.TextTitle = "Tài Khoản";
            this.krPage_Account.ToolTipTitle = "Page ToolTip";
            this.krPage_Account.UniqueName = "29A1A40B666C4707C98FE0D28B7F49DD";
            // 
            // krPage_Cashier
            // 
            this.krPage_Cashier.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.krPage_Cashier.Controls.Add(this.split_Cashier);
            this.krPage_Cashier.Flags = 65534;
            this.krPage_Cashier.ImageMedium = ((System.Drawing.Image)(resources.GetObject("krPage_Cashier.ImageMedium")));
            this.krPage_Cashier.LastVisibleSet = true;
            this.krPage_Cashier.Margin = new System.Windows.Forms.Padding(2);
            this.krPage_Cashier.MinimumSize = new System.Drawing.Size(38, 41);
            this.krPage_Cashier.Name = "krPage_Cashier";
            this.krPage_Cashier.OverrideFocus.CheckButton.Back.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.krPage_Cashier.OverrideFocus.CheckButton.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.krPage_Cashier.OverrideFocus.CheckButton.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.krPage_Cashier.OverrideFocus.CheckButton.Content.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.krPage_Cashier.OverrideFocus.CheckButton.Content.DrawFocus = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.krPage_Cashier.Size = new System.Drawing.Size(1178, 581);
            this.krPage_Cashier.Text = "Thu Ngân";
            this.krPage_Cashier.TextDescription = "Description";
            this.krPage_Cashier.TextTitle = "Thu Ngân";
            this.krPage_Cashier.ToolTipTitle = "Page ToolTip";
            this.krPage_Cashier.UniqueName = "50165A26273E487B188BD3856A73B9DA";
            // 
            // split_Cashier
            // 
            this.split_Cashier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_Cashier.Location = new System.Drawing.Point(0, 0);
            this.split_Cashier.Name = "split_Cashier";
            // 
            // split_Cashier.Panel1
            // 
            this.split_Cashier.Panel1.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            // 
            // split_Cashier.Panel2
            // 
            this.split_Cashier.Panel2.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.split_Cashier.Size = new System.Drawing.Size(1178, 581);
            this.split_Cashier.SplitterDistance = 572;
            this.split_Cashier.SplitterWidth = 5;
            this.split_Cashier.TabIndex = 0;
            // 
            // cashierView1
            // 
            this.cashierView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cashierView1.Location = new System.Drawing.Point(0, 0);
            this.cashierView1.Name = "cashierView1";
            this.cashierView1.Size = new System.Drawing.Size(1178, 581);
            this.cashierView1.TabIndex = 0;
            // 
            // managerModifyView1
            // 
            this.managerModifyView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.managerModifyView1.Location = new System.Drawing.Point(0, 0);
            this.managerModifyView1.Name = "managerModifyView1";
            this.managerModifyView1.Size = new System.Drawing.Size(1178, 581);
            this.managerModifyView1.TabIndex = 0;
            // 
            // accountView1
            // 
            this.accountView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accountView1.Location = new System.Drawing.Point(0, 0);
            this.accountView1.Name = "accountView1";
            this.accountView1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.accountView1.Size = new System.Drawing.Size(1178, 581);
            this.accountView1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.kryptonNavigator1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Store Assistant";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).EndInit();
            this.kryptonNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).EndInit();
            this.kryptonPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.krPage_Manager)).EndInit();
            this.krPage_Manager.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.krPage_Statistic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.krPage_Compare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.krPage_Setting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.krPage_Account)).EndInit();
            this.krPage_Account.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.krPage_Cashier)).EndInit();
            this.krPage_Cashier.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_Cashier)).EndInit();
            this.split_Cashier.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Navigator.KryptonNavigator kryptonNavigator1;
        private ComponentFactory.Krypton.Navigator.KryptonPage krPage_Manager;
        private ComponentFactory.Krypton.Navigator.KryptonPage krPage_Statistic;
        private ComponentFactory.Krypton.Navigator.KryptonPage krPage_Setting;
        private ComponentFactory.Krypton.Navigator.KryptonPage krPage_Compare;
        private ComponentFactory.Krypton.Navigator.KryptonPage krPage_Account;
        private System.Windows.Forms.ImageList list_Icons;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage1;
        private ComponentFactory.Krypton.Navigator.KryptonPage krPage_Cashier;
        private System.Windows.Forms.SplitContainer split_Cashier;
        private StoreAssistant_CashierView.CashierView cashierView1;
        private ManagerModifyView managerModifyView1;
        private StoreAssistant_AccountView.AccountView accountView1;
    }
}

