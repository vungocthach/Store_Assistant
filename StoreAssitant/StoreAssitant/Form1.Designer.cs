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
            this.kryptonNavigator1 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.krPage_Cashier = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.krSplit_Cashier = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.krPage_Manager = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.krSplit_Manager = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.krPage_Statistic = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.krPage_Setting = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.krPage_Compare = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.krPage_Account = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.btn_Test = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).BeginInit();
            this.kryptonNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.krPage_Cashier)).BeginInit();
            this.krPage_Cashier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.krSplit_Cashier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.krSplit_Cashier.Panel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.krSplit_Cashier.Panel2)).BeginInit();
            this.krSplit_Cashier.Panel2.SuspendLayout();
            this.krSplit_Cashier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.krPage_Manager)).BeginInit();
            this.krPage_Manager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.krSplit_Manager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.krSplit_Manager.Panel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.krSplit_Manager.Panel2)).BeginInit();
            this.krSplit_Manager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.krPage_Statistic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.krPage_Setting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.krPage_Compare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.krPage_Account)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonNavigator1
            // 
            this.kryptonNavigator1.Bar.BarFirstItemInset = 10;
            this.kryptonNavigator1.Bar.BarMapExtraText = ComponentFactory.Krypton.Navigator.MapKryptonPageText.None;
            this.kryptonNavigator1.Bar.BarMapImage = ComponentFactory.Krypton.Navigator.MapKryptonPageImage.Medium;
            this.kryptonNavigator1.Bar.BarMapText = ComponentFactory.Krypton.Navigator.MapKryptonPageText.Title;
            this.kryptonNavigator1.Bar.CheckButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Standalone;
            this.kryptonNavigator1.Bar.ItemMinimumSize = new System.Drawing.Size(20, 50);
            this.kryptonNavigator1.Bar.ItemSizing = ComponentFactory.Krypton.Navigator.BarItemSizing.SameWidthAndHeight;
            this.kryptonNavigator1.Bar.TabBorderStyle = ComponentFactory.Krypton.Toolkit.TabBorderStyle.RoundedEqualMedium;
            this.kryptonNavigator1.Bar.TabStyle = ComponentFactory.Krypton.Toolkit.TabStyle.HighProfile;
            this.kryptonNavigator1.Button.ButtonDisplayLogic = ComponentFactory.Krypton.Navigator.ButtonDisplayLogic.None;
            this.kryptonNavigator1.Button.CloseButtonAction = ComponentFactory.Krypton.Navigator.CloseButtonAction.RemovePageAndDispose;
            this.kryptonNavigator1.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator1.Button.ContextButtonAction = ComponentFactory.Krypton.Navigator.ContextButtonAction.SelectPage;
            this.kryptonNavigator1.Button.ContextButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Logic;
            this.kryptonNavigator1.Button.ContextMenuMapImage = ComponentFactory.Krypton.Navigator.MapKryptonPageImage.Small;
            this.kryptonNavigator1.Button.ContextMenuMapText = ComponentFactory.Krypton.Navigator.MapKryptonPageText.TextTitle;
            this.kryptonNavigator1.Button.NextButtonAction = ComponentFactory.Krypton.Navigator.DirectionButtonAction.ModeAppropriateAction;
            this.kryptonNavigator1.Button.NextButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Logic;
            this.kryptonNavigator1.Button.PreviousButtonAction = ComponentFactory.Krypton.Navigator.DirectionButtonAction.ModeAppropriateAction;
            this.kryptonNavigator1.Button.PreviousButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Logic;
            this.kryptonNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNavigator1.Group.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlClient;
            this.kryptonNavigator1.Group.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.ControlRibbon;
            this.kryptonNavigator1.Header.HeaderStyleBar = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary;
            this.kryptonNavigator1.Header.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Primary;
            this.kryptonNavigator1.Header.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary;
            this.kryptonNavigator1.Location = new System.Drawing.Point(0, 0);
            this.kryptonNavigator1.Name = "kryptonNavigator1";
            this.kryptonNavigator1.NavigatorMode = ComponentFactory.Krypton.Navigator.NavigatorMode.BarRibbonTabGroup;
            this.kryptonNavigator1.PageBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlClient;
            this.kryptonNavigator1.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.krPage_Cashier,
            this.krPage_Manager,
            this.krPage_Statistic,
            this.krPage_Setting,
            this.krPage_Compare,
            this.krPage_Account});
            this.kryptonNavigator1.Panel.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.PanelClient;
            this.kryptonNavigator1.SelectedIndex = 0;
            this.kryptonNavigator1.Size = new System.Drawing.Size(1082, 833);
            this.kryptonNavigator1.TabIndex = 0;
            this.kryptonNavigator1.Text = "kryptonNavigator1";
            this.kryptonNavigator1.ToolTips.AllowButtonSpecToolTips = true;
            this.kryptonNavigator1.ToolTips.MapExtraText = ComponentFactory.Krypton.Navigator.MapKryptonPageText.ToolTipBody;
            this.kryptonNavigator1.ToolTips.MapImage = ComponentFactory.Krypton.Navigator.MapKryptonPageImage.ToolTip;
            this.kryptonNavigator1.ToolTips.MapText = ComponentFactory.Krypton.Navigator.MapKryptonPageText.ToolTipTitle;
            // 
            // krPage_Cashier
            // 
            this.krPage_Cashier.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.krPage_Cashier.Controls.Add(this.krSplit_Cashier);
            this.krPage_Cashier.Flags = 65534;
            this.krPage_Cashier.ImageMedium = global::StoreAssitant.Properties.Resources.iconfinder_shopping_shop_buy_discount_18_4038845;
            this.krPage_Cashier.LastVisibleSet = true;
            this.krPage_Cashier.MinimumSize = new System.Drawing.Size(50, 50);
            this.krPage_Cashier.Name = "krPage_Cashier";
            this.krPage_Cashier.OverrideFocus.CheckButton.Back.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.krPage_Cashier.OverrideFocus.CheckButton.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.krPage_Cashier.OverrideFocus.CheckButton.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.krPage_Cashier.OverrideFocus.CheckButton.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.krPage_Cashier.OverrideFocus.CheckButton.Border.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.krPage_Cashier.OverrideFocus.CheckButton.Content.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.krPage_Cashier.OverrideFocus.CheckButton.Content.DrawFocus = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.krPage_Cashier.Size = new System.Drawing.Size(1078, 772);
            this.krPage_Cashier.Text = "Thu Ngân";
            this.krPage_Cashier.TextDescription = "Description";
            this.krPage_Cashier.TextTitle = "Thu Ngân";
            this.krPage_Cashier.ToolTipStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.ToolTip;
            this.krPage_Cashier.ToolTipTitle = "Page ToolTip";
            this.krPage_Cashier.UniqueName = "50165A26273E487B188BD3856A73B9DA";
            // 
            // krSplit_Cashier
            // 
            this.krSplit_Cashier.Cursor = System.Windows.Forms.Cursors.Default;
            this.krSplit_Cashier.Location = new System.Drawing.Point(0, 0);
            this.krSplit_Cashier.Name = "krSplit_Cashier";
            // 
            // krSplit_Cashier.Panel2
            // 
            this.krSplit_Cashier.Panel2.Controls.Add(this.btn_Test);
            this.krSplit_Cashier.Size = new System.Drawing.Size(1078, 772);
            this.krSplit_Cashier.SplitterDistance = 584;
            this.krSplit_Cashier.TabIndex = 0;
            // 
            // krPage_Manager
            // 
            this.krPage_Manager.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.krPage_Manager.Controls.Add(this.krSplit_Manager);
            this.krPage_Manager.Flags = 65534;
            this.krPage_Manager.ImageMedium = global::StoreAssitant.Properties.Resources.iconfinder_45_Account_Google_Product_Logo_Brand_57642621;
            this.krPage_Manager.LastVisibleSet = true;
            this.krPage_Manager.MinimumSize = new System.Drawing.Size(50, 50);
            this.krPage_Manager.Name = "krPage_Manager";
            this.krPage_Manager.Size = new System.Drawing.Size(1078, 772);
            this.krPage_Manager.Text = "Quản Lý";
            this.krPage_Manager.TextTitle = "Quản Lý";
            this.krPage_Manager.ToolTipStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.ToolTip;
            this.krPage_Manager.ToolTipTitle = "Page ToolTip";
            this.krPage_Manager.UniqueName = "FA578BA728E9497C71A0C6237C4FD78D";
            // 
            // krSplit_Manager
            // 
            this.krSplit_Manager.Cursor = System.Windows.Forms.Cursors.Default;
            this.krSplit_Manager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.krSplit_Manager.Location = new System.Drawing.Point(0, 0);
            this.krSplit_Manager.Name = "krSplit_Manager";
            this.krSplit_Manager.Size = new System.Drawing.Size(1078, 772);
            this.krSplit_Manager.SplitterDistance = 512;
            this.krSplit_Manager.TabIndex = 0;
            // 
            // krPage_Statistic
            // 
            this.krPage_Statistic.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.krPage_Statistic.Flags = 65534;
            this.krPage_Statistic.ImageMedium = global::StoreAssitant.Properties.Resources.iconfinder_13_3319631;
            this.krPage_Statistic.LastVisibleSet = true;
            this.krPage_Statistic.MinimumSize = new System.Drawing.Size(50, 50);
            this.krPage_Statistic.Name = "krPage_Statistic";
            this.krPage_Statistic.Size = new System.Drawing.Size(1078, 772);
            this.krPage_Statistic.Text = "Thống Kê";
            this.krPage_Statistic.TextTitle = "Thống Kê";
            this.krPage_Statistic.ToolTipStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.ToolTip;
            this.krPage_Statistic.ToolTipTitle = "Page ToolTip";
            this.krPage_Statistic.UniqueName = "63A53B984CEF407D80BF22DD37C86130";
            // 
            // krPage_Compare
            // 
            this.krPage_Compare.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.krPage_Compare.Flags = 65534;
            this.krPage_Compare.ImageMedium = global::StoreAssitant.Properties.Resources.iconfinder_51_5027845;
            this.krPage_Compare.LastVisibleSet = true;
            this.krPage_Compare.MinimumSize = new System.Drawing.Size(50, 50);
            this.krPage_Compare.Name = "krPage_Compare";
            this.krPage_Compare.Size = new System.Drawing.Size(1078, 772);
            this.krPage_Compare.Text = "So Sánh";
            this.krPage_Compare.TextTitle = "So Sánh";
            this.krPage_Compare.ToolTipStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.ToolTip;
            this.krPage_Compare.ToolTipTitle = "Page ToolTip";
            this.krPage_Compare.UniqueName = "70E04151CD72421574B935D9BFB02EA1";
            // 
            // krPage_Setting
            // 
            this.krPage_Setting.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.krPage_Setting.Flags = 65534;
            this.krPage_Setting.ImageMedium = global::StoreAssitant.Properties.Resources.iconfinder_21_4698594;
            this.krPage_Setting.LastVisibleSet = true;
            this.krPage_Setting.MinimumSize = new System.Drawing.Size(50, 50);
            this.krPage_Setting.Name = "krPage_Setting";
            this.krPage_Setting.Size = new System.Drawing.Size(1078, 772);
            this.krPage_Setting.Text = "Cài Đặt";
            this.krPage_Setting.TextTitle = "Cài Đặt";
            this.krPage_Setting.ToolTipStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.ToolTip;
            this.krPage_Setting.ToolTipTitle = "Page ToolTip";
            this.krPage_Setting.UniqueName = "E78AB1709FA246255796E09FE4A65912";
            // 
            // krPage_Account
            // 
            this.krPage_Account.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.krPage_Account.Flags = 65534;
            this.krPage_Account.ImageMedium = global::StoreAssitant.Properties.Resources.iconfinder_humans_1216581;
            this.krPage_Account.LastVisibleSet = true;
            this.krPage_Account.MinimumSize = new System.Drawing.Size(50, 50);
            this.krPage_Account.Name = "krPage_Account";
            this.krPage_Account.Size = new System.Drawing.Size(1078, 772);
            this.krPage_Account.Text = "Tài Khoản";
            this.krPage_Account.TextTitle = "Tài Khoản";
            this.krPage_Account.ToolTipStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.ToolTip;
            this.krPage_Account.ToolTipTitle = "Page ToolTip";
            this.krPage_Account.UniqueName = "29A1A40B666C4707C98FE0D28B7F49DD";
            // 
            // btn_Test
            // 
            this.btn_Test.Location = new System.Drawing.Point(24, 27);
            this.btn_Test.Name = "btn_Test";
            this.btn_Test.Size = new System.Drawing.Size(427, 324);
            this.btn_Test.TabIndex = 0;
            this.btn_Test.Text = "Giả Sử\r\nĐây là nút thêm Món\r\n<Bấm vào để thêm món>";
            this.btn_Test.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1082, 833);
            this.Controls.Add(this.kryptonNavigator1);
            this.Name = "Form1";
            this.Text = "Store Assistant";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).EndInit();
            this.kryptonNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.krPage_Cashier)).EndInit();
            this.krPage_Cashier.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.krSplit_Cashier.Panel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.krSplit_Cashier.Panel2)).EndInit();
            this.krSplit_Cashier.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.krSplit_Cashier)).EndInit();
            this.krSplit_Cashier.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.krPage_Manager)).EndInit();
            this.krPage_Manager.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.krSplit_Manager.Panel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.krSplit_Manager.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.krSplit_Manager)).EndInit();
            this.krSplit_Manager.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.krPage_Statistic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.krPage_Setting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.krPage_Compare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.krPage_Account)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Navigator.KryptonNavigator kryptonNavigator1;
        private ComponentFactory.Krypton.Navigator.KryptonPage krPage_Cashier;
        private ComponentFactory.Krypton.Navigator.KryptonPage krPage_Manager;
        private ComponentFactory.Krypton.Navigator.KryptonPage krPage_Statistic;
        private ComponentFactory.Krypton.Navigator.KryptonPage krPage_Compare;
        private ComponentFactory.Krypton.Navigator.KryptonPage krPage_Setting;
        private ComponentFactory.Krypton.Navigator.KryptonPage krPage_Account;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer krSplit_Cashier;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer krSplit_Manager;
        private System.Windows.Forms.Button btn_Test;
    }
}

