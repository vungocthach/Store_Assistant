using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreAssitant.StoreAssistant_Authenticater
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();

            btn_Submit.Click += Btn_Submit_Click;
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            using (DatabaseController databaseController = new DatabaseController())
            {
                UserInfo userInfo = new UserInfo() { UserName = txt_PassCurrent.Text.Trim(), Pass = txt_PassNew.Text };
            }
        }
    }
}
