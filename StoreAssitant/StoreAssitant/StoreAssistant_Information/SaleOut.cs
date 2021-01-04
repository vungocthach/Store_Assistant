using System;

namespace StoreAssitant.StoreAssistant_Information
{
    public class SaleOutInfo
    {
        TimeSpan timeSpan;
        public TimeSpan Duration { get => timeSpan; }
        public int GetRevenue() { return NumberOfProduct * MenuView.ProductsList[ProductID].Price; } 
        public int NumberOfProduct { set; get; }
        public int ProductID { get; set; }
        public object Tag;

        public SaleOutInfo(TimeSpan duration)
        {
            this.timeSpan = duration;
        }
    }
}
