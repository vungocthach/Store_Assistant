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
    public partial class TableBill : UserControl
    {
        private TableInfo info;
        public TableBill(TableInfo table = null)
        {
            InitializeComponent();

            setData(table);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void setData(TableInfo info)
        {
            if (info == null) this.info = new TableInfo();
            else
            {
                this.info = info;
                int STT = 1;
                foreach (var product in this.info.ProductList)
                {
                    ListViewItem item = new ListViewItem(STT++.ToString());
                    item.SubItems.Add(product.Product.Name);
                    item.SubItems.Add(product.Product.Price.ToString());
                    item.SubItems.Add(product.NumberProduct.ToString());
                    item.SubItems.Add((product.Product.Price * product.NumberProduct).ToString());
                    tableListView.Items.Add(item);
                }
            }
        }
    }
}
