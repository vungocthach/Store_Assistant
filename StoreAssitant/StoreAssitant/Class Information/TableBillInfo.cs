using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreAssitant.Class_Information
{
    public class TableBillInfo
    {
        public List<Products> ProductInTable;
        public int ID { get; set; }
        public TableBillInfo()
        {
            ProductInTable = new List<Products>();
        }
    }
    public class Products : ProductInfo
    {
        public int NumberProduct { get; set; }
        public Products()
        {
            NumberProduct = 1;
        }
    }
}
