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

namespace StoreAssitant.StoreAssistant_AccountView
{
    public partial class AccountView : UserControl
    {
        public event EventHandler ClickSignOut;
        void OnClickSignOut(object sender, EventArgs e) { }

        string[] roles ;

        public AccountView()
        {
            InitializeComponent();
            InitializeEventHandler();

            roles = new string[2] { "Quản Lý", "Nhân viên" };

            ClickSignOut = new EventHandler(OnClickSignOut);
            gr_manager.Visible = false;

            dataGridView1.Font = new Font(dataGridView1.Font.FontFamily, 11f);
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
            lb_role.Text = string.Format("Phân quyền : {0}", roles[(int)Authenticator.CurrentUser.Role]);
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
            string msg = string.Format("Thao tác sẽ không thể phục hồi{0}Bạn chắc chắn muỗn xóa tài khoản này?", Environment.NewLine);
            DialogResult rs = MessageBox.Show(msg, "Xóa tài khoản", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rs == DialogResult.Yes)
            {
                using (DatabaseController databaseController = new DatabaseController())
                {
                    if (databaseController.DeleteUser(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()))
                    {
                        MessageBox.Show("Xóa tài khoản thành công");
                        dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                    }
                    else
                    {
                        MessageBox.Show("Xóa tài khoản thất bại", "Lỗi không xác định", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void SignUpForm_SignUpOK(object sender, UserInfo e)
        {
            MessageBox.Show("Tạo tài khoản nhân viên thành công!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
            AddUserToGrid(e);
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
        }

        private void Btn_AddAccount_Click(object sender, EventArgs e)
        {
            SignUp signUpForm = new SignUp();
            signUpForm.SignUpOK += SignUpForm_SignUpOK;
            signUpForm.StartPosition = FormStartPosition.CenterScreen;
            signUpForm.ShowDialog();
            signUpForm.Dispose();
        }

        void AddUserToGrid(UserInfo userInfo)
        {
           
            int index = dataGridView1.Rows.Add(userInfo.UserName, roles[(int)userInfo.Role]);
            DataGridViewRow row = dataGridView1.Rows[index];
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
            MessageBox.Show("Đổi mật khẩu thành công!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            labelTitile.Width = dataGridView1.Width;
            CenterInParent_Horizontal(gr_user);
            CenterInParent_Horizontal(gr_manager);
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
