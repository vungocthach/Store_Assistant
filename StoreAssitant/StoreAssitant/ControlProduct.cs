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
    public partial class ControlProduct : UserControl
    {
        public ControlProduct()
        {
            InitializeComponent();
            this.SizeChanged += ControlProduct_SizeChanged;
        }

        private void ControlProduct_SizeChanged(object sender, EventArgs e)
        {
            panelImage.Location = new Point(0, 0);
            panelImage.Size = new Size (panelImage.Parent.Width, panelImage.Parent.Height);
        }

       
    }
}
