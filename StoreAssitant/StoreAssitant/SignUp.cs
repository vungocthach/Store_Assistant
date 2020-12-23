using StoreAssitant.StoreAssistant_Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreAssitant
{
    public partial class SignUp_form : Form
    {
        private UserInfo user;
        public UserInfo User { get => User; set => User = value; }

        string Lang = "vn";

        public void SetLanguage()
        {
            Language.InitLanguage(this);
            lb_Name.Text = Language.Rm.GetString("Name:", Language.Culture);
            lb_Pass.Text = Language.Rm.GetString("Password:", Language.Culture);
            lb_Phone.Text = Language.Rm.GetString("Phone:", Language.Culture);
            lb_UserName.Text = Language.Rm.GetString("User name:", Language.Culture);
            lb_ConfirmPassq.Text = Language.Rm.GetString("Confirm password:", Language.Culture);
            lb_Gender.Text = Language.Rm.GetString("Gender:",Language.Culture);
            lb_Birth.Text = Language.Rm.GetString("Date of birth:", Language.Culture);
            this.Text = btn_SignUp.Text =Language.Rm.GetString("Sign Up", Language.Culture);
        }
        private void SignUp_ChangeLanguage(object sender, string e)
        {
            SetLanguage();
        }

        public bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText);
        }

        public event EventHandler<UserInfo> SignUpOK;
        public SignUp_form()
        {
            InitializeComponent();

            if (Lang != AppManager.CurrentLanguage)
            {
                this.Lang = AppManager.CurrentLanguage;
                SetLanguage();
            }
            Language.ChangeLanguage += SignUp_ChangeLanguage;

            SignUpOK = new EventHandler<UserInfo>((s,e)=> { });
            this.btn_SignUp.Click += Btn_SignUp_Click;
        }

        private void Btn_SignUp_Click(object sender, EventArgs e)
        {
            if (txb_Name.Text == ""|| txb_Pass.Text == ""|| TxB_IdentityPass.Text == "" || cbx_Sex.Text == "" || txb_Phone.Text == ""|| txtUserName.Text =="")
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (txb_Pass.Text != TxB_IdentityPass.Text)
            {
                MessageBox.Show("Bạn nhập sai mật khẩu xác nhận!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (dateTimeBirth.Value > DateTime.Now)
            {
                MessageBox.Show("Nhập ngày sinh nhỏ hơn hôm nay", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (!IsNumber(txb_Phone.Text))
            {
                txb_Phone.BackColor = Color.Red;
                MessageBox.Show("Sai định dạng", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            txb_Phone.BackColor = Color.White;

            UserInfo userInfo = new UserInfo()
            {
                UserName = txtUserName.Text.Trim(),
                FullName = txb_Name.Text,
                Pass = txb_Pass.Text,
                Sex = cbx_Sex.SelectedItem.ToString(),
                Phone = txb_Phone.Text,
                Birth = dateTimeBirth.Value,
                Role = UserInfo.UserRole.Cashier
            };

            if (!StoreAssistant_Authenticater.Authenticator.RegistUser(userInfo))
            {
                //MessageBox.Show("Đăng ký thất bại. Vui lòng thử lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SignUpOK(this, userInfo);

                this.Close();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
