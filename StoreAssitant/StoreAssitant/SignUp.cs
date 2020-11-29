using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreAssitant
{
    public partial class SignUp : Form
    {
        private UserInfo User;

        public UserInfo user { get => User; set => User = value; }

        public bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText);
        }
        public SignUp()
        {
            InitializeComponent();
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
            }
            txb_Phone.BackColor = Color.White;
            using (DatabaseController database = new DatabaseController())
            {
                database.InsertUser(new UserInfo(txb_Name.Text, txb_Pass.Text, cbx_Sex.Text, dateTimeBirth.Value, txb_Phone.Text));
            }

        }
    }
}
