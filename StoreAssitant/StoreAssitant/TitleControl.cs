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
    public partial class TitleControl : UserControl
    {
        [Category ("My Properties"), Description ("Name of Title")]
        public string NameTitle
        {
            get => labelTitle.Text;
            set
            {
                Name = value;
                Invalidate();
            }
        }
        [Category ("My Properties"), Description ("Image of Title")]
        public Image image
        {
            get { return labelImage.Image; }
            set
            {
                labelImage.Image = value;
                Invalidate();
            }
        }
        public TitleControl()
        {
            InitializeComponent();
            this.SizeChanged += TitleControl_SizeChanged;
        }

        private void TitleControl_SizeChanged(object sender, EventArgs e)
        {
            labelImage.Location = new Point(0, 0);
            labelImage.Size = new Size(Convert.ToInt32(labelImage.Parent.Width*0.2), labelImage.Parent.Height);
            labelTitle.Location = new Point( labelImage.Width, 0);
            labelTitle.Size = new Size(labelImage.Parent.Width - labelImage.Width, labelImage.Height);
        }

    }
}
