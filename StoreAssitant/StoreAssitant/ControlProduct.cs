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
            panelImage.MouseHover += ControlProduct_MouseHover;
            panelImage.MouseLeave += PanelImage_MouseLeave;
        }

        private void PanelImage_MouseLeave(object sender, EventArgs e)
        {
            panelImage.BackColor = SystemColors.Control;
            panelImage.BorderStyle = BorderStyle.None;
        }

        private void ControlProduct_MouseHover(object sender, EventArgs e)
        {
            panelImage.BackColor =  SystemColors.ActiveCaption;
            panelImage.BorderStyle = BorderStyle.Fixed3D;
        }

        private void ControlProduct_SizeChanged(object sender, EventArgs e)
        {
            panelImage.Location = new Point(0, 0);
            panelImage.Size = new Size (panelImage.Parent.Width, panelImage.Parent.Height);
        }

        private void panelImage_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
