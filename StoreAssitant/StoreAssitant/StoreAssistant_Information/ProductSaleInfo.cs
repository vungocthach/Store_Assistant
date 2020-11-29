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

        public int GetRenvenue()
        {
            return Price * Number;
        }
    }
}
