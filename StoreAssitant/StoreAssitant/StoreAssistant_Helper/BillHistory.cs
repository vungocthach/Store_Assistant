using StoreAssitant.Class_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAssitant.StoreAssistant_Helper
{
    public class BillHistory
    {
        public TableBillInfo[] GetBills(DateTime from, DateTime to)
        {
            List<TableBillInfo> rs = new List<TableBillInfo>();
            //
            // write code here
            //
            return rs.ToArray();
        }
    }
}
