using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAssitant.StoreAssistant_VoucherView
{
    class VoucherInfo
    {
        private string code;
        private DateTime expiryDate;
        private int value;
        private int numberInit;
        private int numberRemain;

        public VoucherInfo()
        {
            code = null;
            expiryDate = DateTime.Now;
            numberInit  = numberRemain = value = 0;
        }

        public string Code 
        { 
            get => code; 
            set => code = value; 
        }
        public DateTime ExpiryDate 
        { 
            get => expiryDate; 
            set => expiryDate = value; 
        }
        public int Value 
        { 
            get => value;
            set
            {
                this.value = value;
            }
        }
        public int NumberInit 
        { 
            get => numberInit;
            set
            {
                numberInit = value;
            }
        }
        public int NumberRemain 
        { 
            get => numberRemain;
            set
            {
                numberRemain = value;
            }
        }
    }
}
