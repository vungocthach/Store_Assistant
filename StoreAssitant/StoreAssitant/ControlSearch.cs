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
        }

        private void ControlSearch_SizeChanged(object sender, EventArgs e)
        {
            textBoxSearch.Location = new Point(0, 0);
            textBoxSearch.Size = new Size  (Convert.ToInt32(textBoxSearch.Parent.Width * 0.8), (textBoxSearch.Parent.Height) );
            buttonSearch.Size = new Size(Convert.ToInt32(textBoxSearch.Parent.Width - textBoxSearch.Width), textBoxSearch.Height);
            buttonSearch.Location = new Point(textBoxSearch.Width,0 );
           
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
