using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAssitant.Class_Information
{
    public class TableBillInfo
    {
        public List<Products> ProductInTable;
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
