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
            labelImage.MouseMove += LabelImage_MouseMove;
            this.SizeChanged += ControlProduct_SizeChanged;
        }

        private void ControlProduct_SizeChanged(object sender, EventArgs e)
        {
            labelImage.Location = new Point(0, 0);
            labelImage.Height = labelImage.Parent.Height;
            labelImage.Width = labelImage.Parent.Width;
        }

        private void LabelImage_MouseMove(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void labelImage_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
