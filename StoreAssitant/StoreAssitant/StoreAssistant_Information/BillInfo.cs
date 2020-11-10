using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAssitant.StoreAssistant_Information
{
    class BillInfo
    {
        public List<Products> ProductInTable;
        public int ID { get; set; }

        public int VAT { get; set; }

        public double Vourcher { get; set; }

        public DateTime 
        public BillInfo()
        {
            ProductInTable = new List<Products>();
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
