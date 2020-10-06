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
          //  flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
          //  flowLayoutPanel1.WrapContents = false;
          //  flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
          //  flowLayoutPanel1.AutoScroll = true;
        }

        private void MenuView_SizeChanged(object sender, EventArgs e)
        {
            ControlTitle.Location = new Point(0, 0);
            ControlTitle.Size = new Size(this.Width, Convert.ToInt32(this.Height * 0.1));
            controlSearch.Location = new Point(0, Convert.ToInt32(this.Height * 0.12));
            controlSearch.Size = new Size(Convert.ToInt32(this.Width * 0.8), Convert.ToInt32(this.Height * 0.07));
            controlProduct.Location = new Point(Convert.ToInt32(this.Width * 0.02), Convert.ToInt32(this.Height * 0.20));
            flowLayoutPanel1.Location = new Point(0, Convert.ToInt32(this.Height*0.19));
            flowLayoutPanel1.Size = new Size(this.Width -10, 10000);
            
        }

        private void titleControl1_Load(object sender, EventArgs e)
        {

        }

        private void controlProduct_Load(object sender, EventArgs e)
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }
    }

    internal class MenuViewInfo
    {
    }
}
