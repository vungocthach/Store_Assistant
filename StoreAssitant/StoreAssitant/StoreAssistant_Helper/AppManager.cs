using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAssitant.StoreAssistant_Helper
{
    public class AppManager
    {
        static StoreInformation storeInformation;
        public static StoreInformation Information
        {
            get
            {
                if (storeInformation == null)
                {
                    storeInformation = new StoreInformation();

                }
                return storeInformation;
            }
        }
    }
}
