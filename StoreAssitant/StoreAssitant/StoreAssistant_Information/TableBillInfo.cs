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
        public MyList<Products> ProductInTable;
        public int ID { get; set; }
        public TableBillInfo()
        {
            ProductInTable = new MyList<Products>();
        }
    }
    public class Products : ProductInfo
    {
        public EventHandler onChanged ;
        private int numberProduct = 1;
        public int NumberProduct
        {
            get => numberProduct;
            set
            {
                if (value!=numberProduct)
                {
                    numberProduct = value;
                    onChanged(this, new EventArgs());
                }
            }
        }
        public Products()
        {
            onChanged = new EventHandler((s, e) => { });
        }
        public Products(ProductInfo product):base(product.Id,product.Name,product.Price,product.Description,product.Image)
        {
            onChanged = new EventHandler((s, e) => { });
        }
    }
    public class MyList<T> : List<T>
    {

        public event EventHandler OnAdded;// = new EventHandler((s,e)=> { });
        public event EventHandler OnRemoved;// = new EventHandler((s, e) => { });

        public new void Add(T item) // "new" to avoid compiler-warnings, because we're hiding a method from base-class
        {
            base.Add(item);
            OnAdded?.Invoke(this, null);
        }
        public new void Removed(T item) // "new" to avoid compiler-warnings, because we're hiding a method from base-class
        {
            base.Remove(item);
            OnRemoved?.Invoke(this, null);
        }
    }

}
