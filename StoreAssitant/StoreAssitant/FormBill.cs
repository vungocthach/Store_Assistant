using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StoreAssitant.Class_Information;

namespace StoreAssitant
{
    public partial class FormBill : Form, INotifyPropertyChanged
    {
        private bool isReadonly;
        private int moneyPay;
        private double percentDecrease;
        private int exchanged;
        public BillInfo info = null;
        public bool isConfirm;
        public FormBill()
        {
            InitializeComponent();

            Init_Bill();
            btnCashier.Click += BtnCashier_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCashier_Click(object sender, EventArgs e)
        {
            isConfirm = true;
            this.Close();
        }

        public void setData(TableBillInfo table)
        {
            info = new BillInfo();
            if (info ==null)
            {
                MessageBox.Show("Lỗi thông tin món ăn");
                return;
            }
            else
            {
                info.IDTable = table.ID;
                info.DayBill = DateTime.Now;
                info.SaleCode = "###";
                foreach(var i in table.ProductInTable)
                {
                    ProductBill p = new ProductBill();
                    p.Name = i.Name;
                    p.Number = i.NumberProduct;
                    p.SinglePrice = i.Price;
                    info.ProductBills.Add(p);

                    tlpProduct.Controls.Add(new Label() { Text = tlpProduct.RowCount.ToString() }, 0, tlpProduct.RowCount - 1);
                    tlpProduct.Controls.Add(new Label() { Text = p.Name }, 1, tlpProduct.RowCount - 1);
                    tlpProduct.Controls.Add(new Label() { Text = p.Number.ToString() }, 2, tlpProduct.RowCount - 1);
                    tlpProduct.Controls.Add(new Label() { Text = p.SinglePrice.ToString() }, 3, tlpProduct.RowCount - 1);
                    tlpProduct.Controls.Add(new Label() { Text = (p.Number * p.SinglePrice).ToString() }, 4, tlpProduct.RowCount - 1);
                    tlpProduct.RowCount++;
                    tlpProduct.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
                }
                info.PropertyChanged += Info_PropertyChanged;
            }
        }

        private void Info_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            MoneyPay = (int)(info.Price_Bill * (1 + percentDecrease));
            Exchanged = info.Price_Customer - MoneyPay;
        }

        private void Init_Bill()
        {
            textBox1.DataBindings.Add("Text", info, "Price_Bill", true, DataSourceUpdateMode.OnPropertyChanged);
            textBox2.DataBindings.Add("Text", info, "SaleCode", true, DataSourceUpdateMode.OnPropertyChanged);
            textBox3.DataBindings.Add("Text", this, "MoneyPay", true, DataSourceUpdateMode.OnPropertyChanged);
            textBox4.DataBindings.Add("Text", info, "Price_Customer", true, DataSourceUpdateMode.OnPropertyChanged);
            textBox5.DataBindings.Add("Text", this, "Exchanged", true, DataSourceUpdateMode.OnPropertyChanged);
            lbDate.Text = lbDate.Text + DateTime.Now.Day + '/' + DateTime.Now.Month + '/' + DateTime.Now.Year;
        }

        [Category("My properties"), Description("Check can write on bill form")]
        public bool IsReadonly
        {
            get => isReadonly;
            set
            {
                isReadonly = value;
                textBox2.ReadOnly = textBox4.ReadOnly = value;
                if (isReadonly)
                {
                    btnCashier.Visible = false;
                    btnCancel.Text = "Thoát";
                }
                else
                {
                    btnCashier.Visible = true;
                    btnCancel.Text = "Hủy";
                }
            }
        }
        [Category("My properties"), Description("Get money need to pay")]
        public int MoneyPay { 
            get => moneyPay;
            set
            {
                moneyPay = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("Money Pay"));
            }
        }

        public double PercentDecrease { 
            get => percentDecrease;
            set
            {
                if (value < 1)
                {
                    percentDecrease = value;
                }
                else
                {
                    value = 1;
                }
                InvokePropertyChanged(new PropertyChangedEventArgs("Percent Deacreas"));
            }
        }

        public int Exchanged { 
            get => exchanged;
            set
            {
                exchanged = value;
                if (value<0)
                {
                    textBox5.BackColor = Color.Red;
                }
                else
                {
                    textBox5.BackColor = SystemColors.Control;
                }
                InvokePropertyChanged(new PropertyChangedEventArgs("Exchanged"));
            }
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
