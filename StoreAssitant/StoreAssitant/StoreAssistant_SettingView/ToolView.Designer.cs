
namespace StoreAssitant.StoreAssistant_SettingView
{
    partial class ToolView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAccount = new System.Windows.Forms.ToolStripDropDownButton();
            this.itemEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.itemChangePass = new System.Windows.Forms.ToolStripMenuItem();
            this.itemLogOut = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSetting = new System.Windows.Forms.ToolStripDropDownButton();
            this.itemLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.tiếngViệtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemTheme = new System.Windows.Forms.ToolStripMenuItem();
            this.lightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemWindowSize = new System.Windows.Forms.ToolStripMenuItem();
            this.itemStoreInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.btnQuit = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Font = new System.Drawing.Font("Gentium Book Basic", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAccount,
            this.btnSetting,
            this.btnQuit});
            this.toolStrip1.Location = new System.Drawing.Point(-6, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(374, 39);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAccount
            // 
            this.btnAccount.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemEmployee,
            this.itemChangePass,
            this.itemLogOut});
            this.btnAccount.Image = global::StoreAssitant.Properties.Resources.iconfinder_humans_1216581;
            this.btnAccount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(193, 36);
            this.btnAccount.Text = "Xin chào, testing";
            // 
            // itemEmployee
            // 
            this.itemEmployee.BackColor = System.Drawing.SystemColors.Control;
            this.itemEmployee.Name = "itemEmployee";
            this.itemEmployee.Size = new System.Drawing.Size(206, 26);
            this.itemEmployee.Text = "Quản lý nhân sự";
            // 
            // itemChangePass
            // 
            this.itemChangePass.BackColor = System.Drawing.SystemColors.Control;
            this.itemChangePass.Name = "itemChangePass";
            this.itemChangePass.Size = new System.Drawing.Size(206, 26);
            this.itemChangePass.Text = "Đổi mật khẩu";
            // 
            // itemLogOut
            // 
            this.itemLogOut.BackColor = System.Drawing.SystemColors.Control;
            this.itemLogOut.Name = "itemLogOut";
            this.itemLogOut.Size = new System.Drawing.Size(206, 26);
            this.itemLogOut.Text = "Đăng xuất";
            // 
            // btnSetting
            // 
            this.btnSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemLanguage,
            this.itemTheme,
            this.itemWindowSize,
            this.itemStoreInfo});
            this.btnSetting.Font = new System.Drawing.Font("Gentium Book Basic", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnSetting.Image = global::StoreAssitant.Properties.Resources.iconfinder_21_4698594;
            this.btnSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(102, 36);
            this.btnSetting.Text = "Cài Đặt";
            // 
            // itemLanguage
            // 
            this.itemLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tiếngViệtToolStripMenuItem,
            this.englishToolStripMenuItem});
            this.itemLanguage.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemLanguage.Name = "itemLanguage";
            this.itemLanguage.Size = new System.Drawing.Size(211, 22);
            this.itemLanguage.Text = "Ngôn ngữ";
            // 
            // tiếngViệtToolStripMenuItem
            // 
            this.tiếngViệtToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tiếngViệtToolStripMenuItem.CheckOnClick = true;
            this.tiếngViệtToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiếngViệtToolStripMenuItem.Image = global::StoreAssitant.Properties.Resources.iconfinder_f_check_256_282474_20x20;
            this.tiếngViệtToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tiếngViệtToolStripMenuItem.Name = "tiếngViệtToolStripMenuItem";
            this.tiếngViệtToolStripMenuItem.Size = new System.Drawing.Size(189, 32);
            this.tiếngViệtToolStripMenuItem.Text = "Tiếng Việt";
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Checked = true;
            this.englishToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.englishToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(189, 32);
            this.englishToolStripMenuItem.Text = "English";
            // 
            // itemTheme
            // 
            this.itemTheme.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lightToolStripMenuItem,
            this.darkToolStripMenuItem});
            this.itemTheme.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemTheme.Name = "itemTheme";
            this.itemTheme.Size = new System.Drawing.Size(211, 22);
            this.itemTheme.Text = "Theme";
            // 
            // lightToolStripMenuItem
            // 
            this.lightToolStripMenuItem.Font = new System.Drawing.Font("Gentium Book Basic", 11F, System.Drawing.FontStyle.Bold);
            this.lightToolStripMenuItem.Name = "lightToolStripMenuItem";
            this.lightToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.lightToolStripMenuItem.Text = "Light";
            // 
            // darkToolStripMenuItem
            // 
            this.darkToolStripMenuItem.Font = new System.Drawing.Font("Gentium Book Basic", 11F, System.Drawing.FontStyle.Bold);
            this.darkToolStripMenuItem.Name = "darkToolStripMenuItem";
            this.darkToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.darkToolStripMenuItem.Text = "Dark";
            // 
            // itemWindowSize
            // 
            this.itemWindowSize.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.itemWindowSize.Name = "itemWindowSize";
            this.itemWindowSize.Size = new System.Drawing.Size(211, 22);
            this.itemWindowSize.Text = "Kích Thước Cửa Sổ";
            // 
            // itemStoreInfo
            // 
            this.itemStoreInfo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemStoreInfo.Name = "itemStoreInfo";
            this.itemStoreInfo.Size = new System.Drawing.Size(211, 22);
            this.itemStoreInfo.Text = "Thông tin Cửa Hàng";
            // 
            // btnQuit
            // 
            this.btnQuit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnQuit.Image = global::StoreAssitant.Properties.Resources.iconfinder_exit_38999_32x32;
            this.btnQuit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(36, 36);
            this.btnQuit.Text = "toolStripButton1";
            this.btnQuit.ToolTipText = "Thoát";
            // 
            // ToolView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.toolStrip1);
            this.Name = "ToolView";
            this.Size = new System.Drawing.Size(428, 72);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton btnAccount;
        private System.Windows.Forms.ToolStripMenuItem itemEmployee;
        private System.Windows.Forms.ToolStripMenuItem itemChangePass;
        private System.Windows.Forms.ToolStripMenuItem itemLogOut;
        private System.Windows.Forms.ToolStripDropDownButton btnSetting;
        private System.Windows.Forms.ToolStripMenuItem itemLanguage;
        private System.Windows.Forms.ToolStripMenuItem tiếngViệtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemTheme;
        private System.Windows.Forms.ToolStripMenuItem lightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemStoreInfo;
        private System.Windows.Forms.ToolStripButton btnQuit;
        private System.Windows.Forms.ToolStripMenuItem itemWindowSize;
    }
}
