using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreAssitant.StoreAssistant_VoucherView
{
    public partial class VoucherView : UserControl
    {
        List<VoucherInfo> info;
        public VoucherView()
        {
            InitializeComponent();
            this.Layout += VoucherView_Layout;
            this.SizeChanged += VoucherView_SizeChanged;

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = info;
        }

        private void VoucherView_Layout(object sender, LayoutEventArgs e)
        {
            int space = 10;
            button2.Location = new Point(this.Width - button2.Width - space, this.Height - button2.Height - space);
            button1.Location = new Point(this.Width - button1.Width - button2.Width - space*2, button2.Location.Y);
            dataGridView1.Size = new Size(this.Width, dataGridView1.Height);
            dataGridView1.Location = new Point(0, button2.Location.Y - space*2 - dataGridView1.Height);
        }

        private void VoucherView_SizeChanged(object sender, EventArgs e)
        {
            /*button2.Location = new Point(this.Width - button2.Width - 5, this.Height - button2.Height - 5);
            button1.Location = new Point(this.Width - button1.Width - button2.Width - 10, button2.Location.Y);*/
        }

        internal void LoadDataFromDB()
        {
            using (DatabaseController databaseController = new DatabaseController())
            {
                databaseController.ConnectToSQLDatabase();
                //do something here
            }
        }
    }
}
