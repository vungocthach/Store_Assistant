using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.CodeDom;
using System.Reflection;

namespace StoreAssitant
{
    public partial class ControlProduct : UserControl
    {
        public event EventHandler _Click;

        void on_Click(object sender, EventArgs e )
        { }

        public ControlProduct()
        {
            InitializeComponent();

            _Click = new EventHandler(on_Click);

            this.SizeChanged += ControlProduct_SizeChanged;
            panelImage.MouseEnter += ControlProduct_MouseHover;
            panelImage.MouseLeave += PanelImage_MouseLeave;
            panelImage.Click += PanelImage_Click;
           
        }


        private void PanelImage_Click(object sender, EventArgs e)
        {
            _Click(this, e);
            panelImage.BorderStyle = BorderStyle.None;
        }

        private void PanelImage_MouseLeave(object sender, EventArgs e)
        {
            panelImage.BackColor = SystemColors.Control;
            panelImage.BorderStyle = BorderStyle.None;
            Invalidate();
        }

        private void ControlProduct_MouseHover(object sender, EventArgs e)
        {
            panelImage.BackColor =  SystemColors.ActiveCaption;
            panelImage.BorderStyle = BorderStyle.Fixed3D;
            Invalidate();
        }

        private void ControlProduct_SizeChanged(object sender, EventArgs e)
        {
            panelImage.Location = new Point((panelImage.Parent.Width - panelImage.Width) / 2, (panelImage.Parent.Height - panelImage.Height) / 2);
        }

        private void panelImage_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
