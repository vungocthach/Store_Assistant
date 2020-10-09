using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAssitant
{
    public class TableInfo
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public List<Products> ProductList { get; set; }
        public override string ToString()
        {
            return string.Format("StoreAssistant.TableInfo:( ID = {0}; Name = {1}; )", Id, Name);
        }
    }
    public class Products
    {
        public ProductInfo Product { get; set; }
        public int NumberProduct { get; set; }
        public Products()
        {
            Product = new ProductInfo();
            NumberProduct = 1;
        }
    }
}
