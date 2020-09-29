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
            ControlTitle.Size = new Size(this.Width, Convert.ToInt32(this.Height * 0.1));
            controlSearch.Location = new Point(0, Convert.ToInt32(this.Height * 0.12));
            controlSearch.Size = new Size(Convert.ToInt32(this.Width * 0.8), Convert.ToInt32(this.Height * 0.07));
            controlProduct.Location = new Point(Convert.ToInt32(this.Width * 0.02), Convert.ToInt32(this.Height * 0.20));
            //controlProduct.Size = new Size();
        }

        private void titleControl1_Load(object sender, EventArgs e)
        {

        }

        private void controlProduct_Load(object sender, EventArgs e)
        {

        }
    }

    internal class MenuViewInfo
    {
    }
}
