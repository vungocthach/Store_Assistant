using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StoreAssitant.StoreAssistant_Authenticater;
using System.Collections;
using System.Security.Authentication;
using StoreAssitant.StoreAssistant_Helper;

namespace StoreAssitant.StoreAssistant_AccountView
{
    public partial class AccountView : UserControl
    {
        public event EventHandler ClickSignOut;
        string Lang = "vn";
        string Cannotrehibilitate = "Thao tác sẽ không thể phục hồi";
        string Areusure = " Bạn chắc chắn muốn xóa tài khoản này?";
        string DelAcc = "Xóa tài khoản";
        string SuccessDel = "Xóa tài khoản thành công";
        string failDel = "Xóa tài khoản thất bại";
        string Nondefine = "Lỗi không xác định";
        string SuccessChangePass = "Đổi mật khẩu thành công!";
        string SuccessCreateAcc ="Tạo tài khoản nhân viên thành công!";
        void OnClickSignOut(object sender, EventArgs e) { }

        string[] roles = new string[2] { "Quản Lý", "Nhân viên" };

        public void SetLanguage()
        {
            Language.InitLanguage(this);
            gr_user.Text = Language.Rm.GetString("Account infomation", Language.Culture);
            dataGridView1.Columns[0].HeaderText = Language.Rm.GetString("User name", Language.Culture);
            dataGridView1.Columns[1].HeaderText = Language.Rm.GetString("Full name", Language.Culture);
            dataGridView1.Columns[2].HeaderText = Language.Rm.GetString("Position", Language.Culture);
            btn_AddAccount.Text = Language.Rm.GetString("Add", Language.Culture);
            btn_DeleteAccount.Text = Language.Rm.GetString("Delete", Language.Culture);
            btn_ResetPass.Text = Language.Rm.GetString("Change password", Language.Culture);
            btn_SignOut.Text = Language.Rm.GetString("Sign out", Language.Culture);
            labelTitile.Text = Language.Rm.GetString("Staff infomation", Language.Culture);
            lb_username.Text = Language.Rm.GetString("User name:", Language.Culture);
            roles[0] = Language.Rm.GetString("Manage", Language.Culture);
            roles[1] = Language.Rm.GetString("Staff", Language.Culture);
            lb_role.Text = Language.Rm.GetString("Position:", Language.Culture);
            Cannotrehibilitate = Language.Rm.GetString("Cannotrehibilitate", Language.Culture);
            Areusure = Language.Rm.GetString("Areusure", Language.Culture);
            DelAcc = Language.Rm.GetString("DelAcc", Language.Culture);
            SuccessDel = Language.Rm.GetString("SuccessDel", Language.Culture);
            failDel = Language.Rm.GetString("failDel", Language.Culture);
            Nondefine = Language.Rm.GetString("Nonedefine", Language.Culture);
            SuccessChangePass = Language.Rm.GetString("SuccessChangePass", Language.Culture);
            SuccessCreateAcc = Language.Rm.GetString("SuccessCreateAcc", Language.Culture);
           
        }
        public AccountView()
        {
            InitializeComponent();
            if (Lang != AppManager.CurrentLanguage)
            {
                Lang = AppManager.CurrentLanguage;
                SetLanguage();
            }
            InitializeEventHandler();


            ClickSignOut = new EventHandler(OnClickSignOut);
            //gr_manager.Visible = true;

            //dataGridView1.Font = new Font(dataGridView1.Font.FontFamily, 11f);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.Font.FontFamily, dataGridView1.Font.Size + 1, FontStyle.Bold);
            dataGridView1.DoubleClick += DataGridView1_DoubleClick;
            Language.ChangeLanguage += VoucherView_ChangeLanguage;
        }

        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                SignUp_form form = new SignUp_form();
                form.StartPosition = FormStartPosition.CenterScreen;
                using (DatabaseController databaseController = new DatabaseController())
                {
                    form.ShowUserInfo(databaseController.GetUser((dataGridView1.CurrentRow.Tag as UserInfo).UserName));
                }
                form.ShowDialog();
            }
        }

        private void VoucherView_ChangeLanguage(object sender, string e)
        {
            //MessageBox.Show("changelanguage", e);
            SetLanguage();
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1) { btn_DeleteAccount.Enabled = false; }
            else if (!btn_DeleteAccount.Enabled) { btn_DeleteAccount.Enabled = true; }
        }

        internal void SetData()
        {
            if (Authenticator.CurrentUser == null) { throw new AuthenticationException("Current user's account must not be null"); }
            txt_username.Text = Authenticator.CurrentUser.UserName;
            txb_role.Text = string.Format("{0}", roles[(int)Authenticator.CurrentUser.Role]);
            if (Authenticator.CurrentUser.Role == UserInfo.UserRole.Manager)
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
            foreach (UserInfo userInfo in list_User)
            {
                AddUserToGrid(userInfo);              
            }

            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
        }

        private void Btn_DeleteAccount_Click(object sender, EventArgs e)
        {
            string msg = string.Format(Cannotrehibilitate + "{0}" + Areusure, Environment.NewLine);
            DialogResult rs = MessageBox.Show(msg, DelAcc, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rs == DialogResult.Yes)
            {
                using (DatabaseController databaseController = new DatabaseController())
                {
                    if (databaseController.DeleteUser(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()))
                    {
                        MessageBox.Show(SuccessDel);
                        dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                    }
                    else
                    {
                        MessageBox.Show(failDel, Nondefine, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void SignUpForm_SignUpOK(object sender, UserInfo e)
        {
            MessageBox.Show(SuccessCreateAcc , string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
            AddUserToGrid(e);
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
        }

        private void Btn_AddAccount_Click(object sender, EventArgs e)
        {
            SignUp_form signUpForm = new SignUp_form();
            signUpForm.SignUpOK += SignUpForm_SignUpOK;
            signUpForm.StartPosition = FormStartPosition.CenterScreen;
            signUpForm.ShowDialog();
            signUpForm.Dispose();
        }

        void AddUserToGrid(UserInfo userInfo)
        {
            int index = dataGridView1.Rows.Add(userInfo.UserName, userInfo.FullName, roles[(int)userInfo.Role]);
            DataGridViewRow row = dataGridView1.Rows[index];
            row.Tag = userInfo;
            if (row.Index % 2 == 0) row.DefaultCellStyle.BackColor = Color.LightSkyBlue;
        }

        void InitializeEventHandler()
        {
            this.SizeChanged += AccountView_SizeChanged;
            gr_user.SizeChanged += Gr_user_SizeChanged;
            gr_manager.SizeChanged += Gr_manager_SizeChanged;

            btn_SignOut.Click += Btn_SignOut_Click;
            btn_ResetPass.Click += Btn_ResetPass_Click;

            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;

            btn_AddAccount.Click += Btn_AddAccount_Click;
            btn_DeleteAccount.Click += Btn_DeleteAccount_Click;
        }

        private void Btn_ResetPass_Click(object sender, EventArgs e)
        {
            ChangePasswordForm changePasswordForm = new ChangePasswordForm();
            changePasswordForm.ChangePasswordOK += ChangePasswordForm_ChangePasswordOK;
            changePasswordForm.StartPosition = FormStartPosition.CenterScreen;
            changePasswordForm.ShowDialog();
            changePasswordForm.Dispose();
        }

        private void ChangePasswordForm_ChangePasswordOK(object sender, EventArgs e)
        {
            MessageBox.Show(SuccessChangePass, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Btn_SignOut_Click(object sender, EventArgs e)
        {
            ClickSignOut(this, null);
        }

        private void Gr_manager_SizeChanged(object sender, EventArgs e)
        {
            dataGridView1.Height = gr_manager.Height - dataGridView1.Location.Y - (gr_manager.Height - btn_AddAccount.Location.Y) - dataGridView1.Margin.Bottom - btn_AddAccount.Margin.Top;
            dataGridView1.Width = gr_manager.Width - dataGridView1.Location.X - dataGridView1.Margin.Right;
        }
        private void Gr_user_SizeChanged(object sender, EventArgs e)
        {
            txt_username.Width = gr_user.Width - txt_username.Location.X - (gr_user.Width - btn_ResetPass.Location.X) - txt_username.Margin.Right - btn_ResetPass.Margin.Left;
        }

        private void AccountView_SizeChanged(object sender, EventArgs e)
        {
            dataGridView1.Width = this.Width;
            gr_manager.Height = this.Height - gr_manager.Location.Y - gr_manager.Margin.Bottom;
            //gr_user.Width = this.Width;
            gr_manager.Width = this.Width - gr_manager.Location.X - gr_manager.Margin.Right - 5;
            labelTitile.Width = gr_manager.Width;
            CenterInParent_Horizontal(gr_user);
            //CenterInParent_Horizontal(gr_manager);
            labelTitile.Location = new Point(gr_manager.Location.X, gr_manager.Location.Y - labelTitile.Height); ;
        }

        void CenterInParent_Horizontal(Control target)
        {
            target.Location = new Point((target.Parent.Width - target.Width) / 2, target.Location.Y);
        }

        private void btn_ResetPass_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
