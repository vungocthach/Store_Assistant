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
    public partial class ControlSearch : UserControl
    {

        public ControlSearch()
        {
            InitializeComponent();
            this.SizeChanged += ControlSearch_SizeChanged;
           richTextBoxSearch.Click +=richTextBoxSearch_Click;
           
        }

        private void ControlSearch_SizeChanged(object sender, EventArgs e)
        {
            labelImage.Location = new Point(0, 0);
            labelImage.Width = Convert.ToInt32(labelImage.Parent.Width * 0.1);
            labelImage.Height =labelImage.Parent.Height;
           richTextBoxSearch.Location = new Point(labelImage.Width,0 );
           richTextBoxSearch.Width = Convert.ToInt32(labelImage.Parent.Width - labelImage.Width);
           richTextBoxSearch.Height = labelImage.Height;

        }

        private void richTextBoxSearch_Click(object sender, EventArgs e)
        {
            if (richTextBoxSearch.Text == "Search")richTextBoxSearch.Text = "";
            if (richTextBoxSearch.Text == "")richTextBoxSearch.Text = "Search";
        }
    }
}
