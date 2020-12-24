using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;
using StoreAssitant.Class_Information;
using StoreAssitant.StoreAssistant_Helper;

namespace StoreAssitant
{
    public class BillInfo : INotifyPropertyChanged
    {
        public int ID;
        private int number_table;
        private long total;
        private long give;
        private DateTime day;
        private long price_Bill;
        private string voucher;
        private MyList<Products> productBills;
        private long take;
        private string Lang = "vn";
        private string Notify = "Thông báo";
        private string ErrorBigger100M = "Không được vượt quá 100 triệu";

        //public event PropertyChangedEventHandler PropertyChanged;

        public long TOTAL
        {
            get => total;
            set
            {
                total = value;
                //InvokePropertyChanged(new PropertyChangedEventArgs("Total money"));
            }
        }
        public long Give
        {
            get => give;
            set
            {
                give = value;
                //InvokePropertyChanged(new PropertyChangedEventArgs("Give money"));
            }
        }
        public int Number_table { get => number_table; set => number_table = value; }
        public DateTime DAY { get => day; set => day = value; }
        public string USER_Name { get; set; }
        public long Price_Bill {
            get
            {
                return price_Bill;
            }
            set
            {
                if (value > 100000000)
                {
                    MessageBox.Show(ErrorBigger100M, Notify, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                price_Bill = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("Price_Bill"));
            }
        }
        public string Voucher {
            get => voucher;
            set
            {
                voucher = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("SaleCode"));
                //PropertiesChanged(this, new EventArgs());
            }
        }
        public MyList<Products> ProductBills {
            get => productBills;
            set
            {
                productBills = value;
                //InvokePropertyChanged(new PropertyChangedEventArgs("Price Customer"));
            }
        }
        public long Take {
            get => take;
            set
            {
                if (value > 100000000)
                {
                    MessageBox.Show(ErrorBigger100M, Notify, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                take = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("Price Customer"));
            }
        }


        public BillInfo() {
            productBills = new MyList<Products>();

            if (Lang != AppManager.CurrentLanguage)
            {
                Lang = AppManager.CurrentLanguage;
                SetLanguage();
            }
            Language.ChangeLanguage += BillInfo_ChangeLanguage;

            PropertyChanged = new PropertyChangedEventHandler((s, e) => { });
            productBills.OnAdded += new EventHandler((s, e) => { Price_Bill = ProductBills.Sum(i => i.Price * i.NumberProduct); });
            productBills.OnRemoved += new EventHandler((s, e) => { Price_Bill = ProductBills.Sum(i => i.Price * i.NumberProduct); });
        }

        private void SetLanguage()
        {
            Language.InitLanguage(this);
            Notify = Language.Rm.GetString("Notify", Language.Culture);
            ErrorBigger100M = Language.Rm.GetString("ErrorBigger100M", Language.Culture);
        }
    
        public void BillInfo_ChangeLanguage(object sender, string e)
        {
            this.SetLanguage();
        }

        public BillInfo(int id, DateTime day, int price, string code, MyList<Products> productBills)
        {
            number_table = id;
            this.day = day;
            price_Bill = price;
            voucher = code;
            this.productBills = productBills;
            PropertyChanged = new PropertyChangedEventHandler((s, e) => { });
        }

        #region Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        #endregion
    }
}
