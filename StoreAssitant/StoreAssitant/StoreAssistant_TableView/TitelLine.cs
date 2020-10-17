using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreAssitant.StoreAssistant_TableView
{
    public partial class TitelLine : UserControl
    {
        public TitelLine()
        {
            InitializeComponent();
            this.MinimumSize = new Size((new TableLine()).MinimumSize.Width, (new TableLine()).MinimumSize.Height);
            this.SizeChanged += TitelLine_SizeChanged;
        }

        private void TitelLine_SizeChanged(object sender, EventArgs e)
        {
            lbName.Size = new Size(this.Size.Width * 13 / 4, this.Size.Height);
            lbNumber.Size = new Size(this.Size.Width * 10 / 4, this.Size.Height);
            lbSinglePrice.Size = new Size(this.Size.Width * 11 / 4, this.Size.Height);
            lbTotalPrice.Size = new Size(this.Size.Width * 10 / 4, this.Size.Height);
        }
    }
}
