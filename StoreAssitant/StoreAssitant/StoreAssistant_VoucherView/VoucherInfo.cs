using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace StoreAssitant.StoreAssistant_VoucherView
{
    public class VoucherInfo: INotifyPropertyChanged
    {
        private string code;
        private DateTime expiryDate;
        private int value;
        private int numberInit;
        private int numberRemain;
        public event PropertyChangedEventHandler PropertyChanged;

        public VoucherInfo()
        {
            code = null;
            expiryDate = DateTime.Now;
            numberInit  = numberRemain = value = 0;
        }

        public string Code 
        { 
            get => code;
            set
            {
                code = value;
                //InvokePropertyChanged(new PropertyChangedEventArgs("Code Voucher"));
            }
        }
        public DateTime ExpiryDate 
        { 
            get => expiryDate;
            set
            {
                expiryDate = value;
                //InvokePropertyChanged(new PropertyChangedEventArgs("Expiry Date"));
            }
        }
        public int Value 
        { 
            get => value;
            set
            {
                this.value = value;
                //InvokePropertyChanged(new PropertyChangedEventArgs("Value(%) of Voucher"));
            }
        }
        public int NumberInit 
        { 
            get => numberInit;
            set
            {
                numberInit = value;
                //InvokePropertyChanged(new PropertyChangedEventArgs("Number start of Voucher"));
            }
        }
        public int NumberRemain 
        { 
            get => numberRemain;
            set
            {
                numberRemain = value;
                //InvokePropertyChanged(new PropertyChangedEventArgs("Number remain of Voucher"));
            }
        }

        public void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
    }
}
