using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAssitant.StoreAssistant_Information
{
    public class ProductSaleInfo
    {
        public object Tag;
        public string ProductName;
        public int Price;
        public int Number = 0;

        public int GetRevenue()
        {
            return Price * Number;
        }

        public ProductSaleInfo Clone()
        {
            return new ProductSaleInfo()
            {
                Tag = this.Tag,
                ProductName = this.ProductName,
                Price = this.Price,
                Number = this.Number
            };
        }
    }
}
