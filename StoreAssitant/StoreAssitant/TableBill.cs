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
        public TableBill(TableBillInfo tableinfo)
        {
            InitializeComponent();
            this.Layout += TableBill_Layout;
            tableTitle_pnl.Layout += TableBill_Layout;
            Products item = new Products();
            item.Name = "thạch";
            item.Id = 1000;
            item.Price = 1000;
            item.NumberProduct = 2;
            tableinfo.ProductInTable.Add(item);
            setData(tableinfo);
        }
        private void TableBill_Layout(object sender, LayoutEventArgs e)
        {
            flpProductInfo.Height = this.Height - tableTitle_pnl.Location.Y - tableTitle_pnl.Height;
            tableTitle_lb.Location = new Point(tableIcon_pnl.Location.X + tableIcon_pnl.Width + (this.Width - tableIcon_pnl.Location.X - tableIcon_pnl.Width - tableTitle_lb.Width) / 2, tableTitle_lb.Location.Y);
            tableIcon_pnl.Size = new Size(tableIcon_pnl.Size.Height, tableIcon_pnl.Size.Height);
            tableTitle_lb.Location = new Point(tableTitle_lb.Location.X, (tableTitle_pnl.Height - tableTitle_lb.Size.Height) / 2);
        }

        public TableBillInfo Billinfo { get; set; }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
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
    }
}
