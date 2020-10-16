using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace StoreAssitant
{
    public partial class LogInView : UserControl
    {
        public event EventHandler _Click;

        private void on_CLick(object sender, EventArgs e)
        {

        }
        public LogInView()
        {
            InitializeComponent();

            _Click += on_CLick;

            Btn_Login.Click += Btn_Login_Click;
            this.Size = new Size(423, 502);
            
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            _Click(this, e);
        }
    }
}
