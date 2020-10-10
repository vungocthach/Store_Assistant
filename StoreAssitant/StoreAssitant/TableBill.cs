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
        private List<TableLine> listTableLine;
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
                MessageBox.Show("SetData của TableBill");
                foreach (var product in this.info.ProductList)
                {
                    
                }
            }
        }
    }
}
