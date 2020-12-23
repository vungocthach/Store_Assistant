using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StoreAssitant.StoreAssistant_Helper;

namespace StoreAssitant.StoreAssistant_TableView
{
    public partial class TitelLine : UserControl
    {
        string Lang = "vn";
        public TitelLine()
        {
            InitializeComponent();

            if (Lang != AppManager.CurrentLanguage)
            {
                Lang = AppManager.CurrentLanguage;
                SetLanguage();
            }
            Language.ChangeLanguage += TitleLine_ChangeLanguage;

            this.MinimumSize = new Size((new TableLine()).MinimumSize.Width, (new TableLine()).MinimumSize.Height);
            this.SizeChanged += TitelLine_SizeChanged;
            lbName.Size = new Size(this.Size.Width * 13 / 44, this.Size.Height);
            lbSinglePrice.Size = new Size(this.Size.Width * 10 / 44, this.Size.Height);
            lbNumber.Size = new Size(this.Size.Width * 11 / 44, this.Size.Height);
            lbTotalPrice.Size = new Size(this.Size.Width * 10 / 44, this.Size.Height);
        }

        private void SetLanguage()
        {
            Language.InitLanguage(this);
            lbName.Text = Language.Rm.GetString("Name", Language.Culture);
            lbNumber.Text = Language.Rm.GetString("Quantum", Language.Culture);
            lbSinglePrice.Text = Language.Rm.GetString("Unit price", Language.Culture);
            lbTotalPrice.Text = Language.Rm.GetString("Amount", Language.Culture);
        }
        private void TitleLine_ChangeLanguage(object sender, string e)
        {
            SetLanguage();
        }
        private void TitelLine_SizeChanged(object sender, EventArgs e)
        {
            lbName.Size = new Size(this.Size.Width * 13 / 44, this.Size.Height);
            lbSinglePrice.Size = new Size(this.Size.Width * 10 / 44, this.Size.Height);
            lbNumber.Size = new Size(this.Size.Width * 11 / 44, this.Size.Height);
            lbTotalPrice.Size = new Size(this.Size.Width * 10 / 44, this.Size.Height);

           /* lbSinglePrice.Location = new Point(lbName.Location.X + lbName.Size.Width, 0);
            lbNumber.Location = new Point(lbSinglePrice.Location.X + lbSinglePrice.Size.Width, 0);
            lbTotalPrice.Location = new Point(lbNumber.Location.X + lbNumber.Size.Width, 0);*/
        }
    }
}
