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
    public partial class MenuView : UserControl
    {
        void SetData(MenuViewInfo info)
        {

        }

        public MenuView()
        {
            
            InitializeComponent();
            this.SizeChanged += MenuView_SizeChanged;
        }

        private void MenuView_SizeChanged(object sender, EventArgs e)
        {
            ControlTitle.Location = new Point(0, 0);
            ControlTitle.Size = new Size(this.Width, Convert.ToInt32(this.Height * 0.125));
            controlSearch.Location = new Point(0, Convert.ToInt32(this.Height * 0.1));
            controlSearch.Size = new Size(Convert.ToInt32(this.Width * 0.4), Convert.ToInt32(this.Height * 0.09));
        }

        private void titleControl1_Load(object sender, EventArgs e)
        {

        }

        private void controlProduct1_Load(object sender, EventArgs e)
        {

        }
    }

    internal class MenuViewInfo
    {
    }
}
