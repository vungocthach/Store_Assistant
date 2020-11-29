using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAssitant.StoreAssistant_Information
{
    public class SaleInfo
    {
        public DateTime DateMin;
        public DateTime DateMax;

        public void SetDay(int year, int month, int day)
        {
            DateMin = new DateTime(year, month, day, 0, 0, 0);
            DateMax = new DateTime(year, month, day, 23, 59, 59);
        }

        public void SetMonth(int year, int month)
        {
            DateMin = new DateTime(year, month, 1, 0, 0, 0);
            DateMax = new DateTime(year, month, DateTime.DaysInMonth(year, month), 23, 59, 59);
        }

        public void SetYear(int year)
        {
            DateMin = new DateTime(year, 1, 1, 0, 0, 0);
            DateMax = new DateTime(year, 12, 31, 23, 59, 59);
        }

        // key is product's name
        public Dictionary<string, ProductSaleInfo> Products;

        public object Tag;

        public long GetRevenue()
        {
            long rs = 0;
            foreach (KeyValuePair<string, ProductSaleInfo> p in Products) { rs += p.Value.GetRevenue(); }
            return rs;
        }

        public SaleInfo()
        {
            Products = new Dictionary<string, ProductSaleInfo>();
            DateMax = DateTime.Now;
            DateMin = DateMax.AddDays(-1);
        }

        public SaleInfo(int year)
        {
            Products = new Dictionary<string, ProductSaleInfo>();
            SetYear(year);
        }

        public SaleInfo(int year, int month)
        {
            Products = new Dictionary<string, ProductSaleInfo>();
            SetMonth(year, month);
        }

        public SaleInfo(int year, int month, int day)
        {
            Products = new Dictionary<string, ProductSaleInfo>();
            SetDay(year, month, day);
        }

    }
}
