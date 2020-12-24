using StoreAssitant.StoreAssistant_Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreAssitant.StoreAssistant_AccountView
{
    public partial class AccountManamentForm : Form
    {
        string Lang = "vn";
        
        public AccountManamentForm()
        {

            InitializeComponent();
            if (Lang != AppManager.CurrentLanguage)
            {
                Lang = AppManager.CurrentLanguage;
                SetLanguage();
            }

            Language.ChangeLanguage += Language_ChangeLanguage;
            accountView1.SetData();
        }

        public void SetLanguage()
        {
            Language.InitLanguage(this);
            this.Text = Language.Rm.GetString("Human Resource Management", Language.Culture);
        }
        private void Language_ChangeLanguage(object sender, string e)
        {
            SetLanguage();
        }
    }
}
