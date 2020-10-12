using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StoreAssitant.Class_Information;

namespace StoreAssitant
{
    public partial class TableBill : UserControl
    {
        public event EventHandler CloseBill;
        private void onCloseBill(object sender,EventArgs e)
        {

        }
        public TableBill(TableBillInfo tableinfo, int iD)
        {
            InitializeComponent();
            this.CloseBill = new EventHandler(onCloseBill);
            this.Layout += TableBill_Layout;
            tableTitle_pnl.Layout += TableBill_Layout;
            tableTitle_lb.Text = "BÀN " + (iD+1);
            setData(tableinfo);
        }
        private void TableBill_Layout(object sender, LayoutEventArgs e)
        {
            flpProductInfo.Height = this.Height - tableTitle_pnl.Location.Y - tableTitle_pnl.Height;
            tableTitle_lb.Location = new Point((this.Size.Width - tableTitle_lb.Size.Width) / 2, 0);
            tableTitle_lb.Size = new Size(tableTitle_lb.Size.Width, tableTitle_pnl.Height);
        }

        public TableBillInfo Billinfo { get; set; }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.CloseBill(sender, e);
            this.Dispose();
        }

        public void setData(TableBillInfo info)
        {
            if (info == null)
            {
                MessageBox.Show("Dữ liệu của bàn bị lỗi");
            }
            else
            {
                this.Billinfo = info;
                foreach (var product in this.Billinfo.ProductInTable)
                {
                    TableLine line = new TableLine();
                    line.SetData(product);
                    flpProductInfo.Controls.Add(line);
                }
            }
        }
        [Category("My Properties"), Description("Name of the table selected")]
        public string Name
        {
            get => tableTitle_lb.Text;
            set
            {
                tableTitle_lb.Text = value;
                Invalidate();
            }
        }
    }
}
