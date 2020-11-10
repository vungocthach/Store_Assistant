using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAssitant.StoreAssistant_Information
{
    class BillInfo
    {
        public List<Products> ProductInBill;
        public int ID { get; set; }
        public char VAT { get; set; }
        public double Vourcher { get; set; }
        public DateTime DAY { get; set; }
        public int Number_table { get; set; } 
        public int Take { get; set; }
        public int Give { get; set; }
        public int TOTAL { get; set;
        }
        public BillInfo()
        {
            ProductInBill = new List<Products>();
        }
    }
    public class Products : ProductInfo
    {
        public int NumberProduct { get; set; } = 1;
        public Products()
        {
        }
        public Products(ProductInfo product) : base(product.Id, product.Name, product.Price, product.Description, product.Image)
        {
        }
    }

}
