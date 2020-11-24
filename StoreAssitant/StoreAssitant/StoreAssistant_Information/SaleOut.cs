using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAssitant.StoreAssistant_Information
{
    public class SaleOutInfo
    {
        TimeSpan timeSpan;
        public TimeSpan Duration { get => timeSpan; }
        public int Revenue { get; set; }
        public int NumberOfProduct { set; get; }
        public ProductInfo Product;
        public object Tag;

        public SaleOutInfo(TimeSpan duration)
        {
            this.timeSpan = duration;
        }
    }
}
