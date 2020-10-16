using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreAssitant
{
    public partial class LogInView : UserControl
    {
       // public event EventHandler 
        public LogInView()
        {
            InitializeComponent();

            this.SizeChanged += LogInView_SizeChanged;
        }

        private void LogInView_SizeChanged(object sender, EventArgs e)
        {
            tb__User.Location = new Point(Convert.ToInt32(this.Width * 0.65), Convert.ToInt32(this.Height * 0.1));
            tb__User.Size = tb_Password.Size = Btn_Login.Size = new Size(Convert.ToInt32(this.Width * 0.73), Convert.ToInt32(this.Height*0.05));
            tb_Password.Location = new Point(tb__User.Location.X, Convert.ToInt32(this.Width * 0.68));
            Btn_Login.Location = new Point(tb__User.Location.X, Convert.ToInt32(this.Width * 0.78));
            Lb_ForgotPass.Location = new Point(tb__User.Location.X, Convert.ToInt32(this.Width * 0.84));
            Lb_SignUp.Location = new Point(Convert.ToInt32(this.Width * 0.43), Lb_ForgotPass.Location.Y);
            Lb_ForgotPass.Size = new Size(Convert.ToInt32(this.Width * 0.25), Convert.ToInt32(this.Height * 0.04));
            Lb_SignUp.Size = new Size(Convert.ToInt32(this.Width * 0.4), Lb_ForgotPass.Size.Height);

        }
    }
}
