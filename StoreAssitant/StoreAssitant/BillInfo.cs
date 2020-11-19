using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace StoreAssitant
{
    public class BillInfo: INotifyPropertyChanged
    {
        private int iDTable;
        private DateTime dayBill;
        private int price_Bill;
        private string saleCode;
        private List<ProductBill> productBills;
        private int price_Customer;
        public int IDTable { get => iDTable; set => iDTable = value; }
        public DateTime DayBill { get => dayBill; set => dayBill = value; }
        public int Price_Bill { 
            get => price_Bill; 
            set
            {
                price_Bill = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("Price_Bill"));
            }
        }
        public string SaleCode { 
            get => saleCode;
            set
            {
                saleCode = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("Price_Bill"));
            }
        }
        internal List<ProductBill> ProductBills { get => productBills; set => productBills = value; }
        public int Price_Customer { 
            get => price_Customer;
            set
            {
                price_Customer = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("Price_Bill"));
            }
        }


        public BillInfo() { productBills = new List<ProductBill>(); }
        public BillInfo(int id, DateTime day, int price, string code, List<ProductBill> productBills)
        {
            iDTable = id;
            dayBill = day;
            price_Bill = price;
            saleCode = code;
            this.productBills = productBills;
        }

        #region Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        #endregion
    }
    public class ProductBill
    {
        private string name;
        private int number;
        private int singlePrice;
        public string Name { get => name; set => name = value; }
        public int Number { get => number; set => number = value; }
        public int SinglePrice { get => singlePrice; set => singlePrice = value; }

        public ProductBill() { }
        public ProductBill(string name, int number, int price)
        {
            this.name = name;
            this.number = number;
            this.singlePrice = price;
        }
    }
}
