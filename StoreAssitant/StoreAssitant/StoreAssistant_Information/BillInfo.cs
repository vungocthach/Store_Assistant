using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreAssitant.Class_Information;

namespace StoreAssitant.Backup
{
    public class BillInfo
    {
        public List<Class_Information.Products> ProductInBill;
        public int ID { get; set; }
        public string Voucher { get; set; }
        public DateTime DAY { get; set; }
        public int Number_table { get; set; } 
        public int Take { get; set; }
        public int Give { get; set; }
     
        public int TOTAL { get; set;}
        public string USER_Name { get; set; }
        public BillInfo()
        {
            ProductInBill = new List<Class_Information.Products>();
            DAY = DateTime.Now;
        }
    }
/*    public class Product : ProductInfo
    {
        public int NumberProduct { get; set; } = 1;

        public Product()
        {
        }
        public Product(ProductInfo product) : base(product.Id, product.Name, product.Price, product.Description, product.Image)
        {
        }
    }*/

}
