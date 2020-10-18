﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreAssitant.StoreAssistant_AccountView
{
    public partial class AccountView : UserControl
    {
        public event EventHandler ClickSignOut;
        void OnClickSignOut(object sender, EventArgs e) { }

        UserInfo user;

        public AccountView()
        {
            InitializeComponent();
            InitializeEventHandler();

            ClickSignOut = new EventHandler(OnClickSignOut);
            gr_manager.Visible = false;

            dataGridView1.Font = new Font(dataGridView1.Font.FontFamily, 11f);
        }

        internal void SetData(UserInfo userInfo)
        {
            user = userInfo;
            txt_username.Text = user.UserName;
            string[] roles = new string[2] { "Quản Lý", "Nhân viên" };
            lb_role.Text = string.Format("Phân quyền : {0}", roles[(int)user.Role]);
            if (user.Role == UserInfo.UserRole.Manager)
            {
                gr_manager.Visible = true;
                using (DatabaseController databaseController = new DatabaseController())
                {
                    SetGridViewData(databaseController.GetAllUser(UserInfo.UserRole.Cashier));
                }
                Invalidate();
            }
        }

        void SetGridViewData(List<UserInfo> list_User)
        {
            dataGridView1.Rows.Clear();
            if (list_User == null) { return; }
            string[] roles = new string[2] { "Quản Lý", "Nhân viên" };
            foreach (UserInfo userInfo in list_User)
            {
                dataGridView1.Rows.Add(userInfo.UserName, roles[(int)userInfo.Role]);
            }
        }

        void InitializeEventHandler()
        {
            this.SizeChanged += AccountView_SizeChanged;
            gr_user.SizeChanged += Gr_user_SizeChanged;
            gr_manager.SizeChanged += Gr_manager_SizeChanged;

            btn_SignOut.Click += Btn_SignOut_Click;
        }

        private void Btn_SignOut_Click(object sender, EventArgs e)
        {
            ClickSignOut(this, null);
        }

        private void Gr_manager_SizeChanged(object sender, EventArgs e)
        {
            dataGridView1.Height = gr_manager.Height - dataGridView1.Location.Y - (gr_manager.Height - btn_AddAccount.Location.Y) - dataGridView1.Margin.Bottom - btn_AddAccount.Margin.Top;
        }

        private void Gr_user_SizeChanged(object sender, EventArgs e)
        {
            txt_username.Width = gr_user.Width - txt_username.Location.X - (gr_user.Width - btn_ResetPass.Location.X) - txt_username.Margin.Right - btn_ResetPass.Margin.Left;
        }

        private void AccountView_SizeChanged(object sender, EventArgs e)
        {
            
            gr_manager.Height = this.Height - gr_manager.Location.Y - gr_manager.Margin.Bottom;
            gr_user.Width = this.Width;
            gr_manager.Width = this.Width;
            CenterInParent_Horizontal(gr_user);
            CenterInParent_Horizontal(gr_manager);
        }

        void CenterInParent_Horizontal(Control target)
        {
            target.Location = new Point((target.Parent.Width - target.Width) / 2, target.Location.Y);
        }
    }
}