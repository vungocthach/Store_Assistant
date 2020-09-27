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
    public partial class TableControl : UserControl
    {
        public TableControl()
        {
            InitializeComponent();
            this.SizeChanged += TableControl_SizeChanged;
            this.MinimumSize = new Size(Table_Name.Size.Width, Table_Name.Size.Height * 4);
        }

        private void TableControl_SizeChanged(object sender, EventArgs e)
        {
            Table_Image.Size = new Size(this.Size.Width, this.Size.Height * 3 / 4);
            Table_Name.Location = new Point((this.Size.Width - Table_Name.Size.Width)/2, (this.Size.Height + Table_Image.Height - Table_Name.Size.Height) / 2);
        }
    }
}
