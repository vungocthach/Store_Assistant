using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StoreAssitant.Class_Information;
using StoreAssitant.StoreAssistant_Helper;
using StoreAssitant.StoreAssistant_VoucherView;

namespace StoreAssitant
{
    public partial class FormBill : Form, INotifyPropertyChanged
    {
        #region FIELDS

        private bool isReadonly;
        private int percentDecrease;
        public BillInfo info = null;
        public bool isConfirm;
        private string Lang = "vn";
        private string OnlyNumber="Chỉ được phép nhập số";
        private string Error = "Lỗi";
        private string NotEnougnMOney = "Khách chưa đưa đủ tiền";
        private string Out = "Thoát";
        private string Cancel = "Hủy";
        private string ProError= "Lỗi thông tin món ăn";

        #endregion



        public FormBill()
        {
            InitializeComponent();

            if (Lang != AppManager.CurrentLanguage)
            {
                Lang = AppManager.CurrentLanguage;
                SetLanguage();
            }
            Language.ChangeLanguage += VoucherView_ChangeLanguage;

            btnCashier.Click += BtnCashier_Click;
            btnCancel.Click += BtnCancel_Click;
            textBox4.KeyPress += TextBox4_KeyPress;
        }

        private void VoucherView_ChangeLanguage(object sender, string e)
        {
            SetLanguage();
        }

        #region LOAD RANDOM DATA FOR DATABASE
        //
        //create data for database
        //
        public void Test(DateTime date)
        {
            TableBillInfo test = new TableBillInfo();
            //lựa chọn bàn
            test.ID = (new Random((int)DateTime.Now.Ticks.GetHashCode())).Next(1, 13);
            test.ProductInTable = new MyList<Products>();
            List<ProductInfo> item = new List<ProductInfo>(MenuView.ProductsList.Count);
            foreach(KeyValuePair<int,ProductInfo> i in MenuView.ProductsList)
            {
                item.Add(i.Value);
            }
            //Chọn ra số món có trong bàn
            int f = (new Random((int)DateTime.Now.Ticks.GetHashCode())).Next(1, item.Count);
            for (int i = 0; i < f; i++)
            {
                //chọn ngẫu nhiên món
                int r = (new Random((int)DateTime.Now.Ticks.GetHashCode())).Next(0, item.Count);
                var pro = new Products()
                {
                    //chọn ngẫu nhiên số lượng
                    NumberProduct = (new Random((int)DateTime.Now.Ticks.GetHashCode())).Next(1, 7),
                    Id = item[r].Id,
                    Name = item[r].Name,
                    Price = item[r].Price
                };
                if (!test.ProductInTable.Exists(x=>x.Id==pro.Id)) test.ProductInTable.Add(pro);
            }
            setData(test);
            info.DAY = date;
            //chọn ngẫu nhiên số tiền khách đưa
            info.Take = info.TOTAL + (new Random((int)DateTime.Now.Ticks.GetHashCode())).Next(0, 500000);
            BtnCashier_Click(this, new EventArgs());
        }
        #endregion

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            using (DatabaseController data = new DatabaseController())
            {
                percentDecrease = data.UseVoucher(textBox2.Text);
            }
        }

        public FormBill(BillInfo bill)
        {
            InitializeComponent();
            setData(bill);
            IsReadonly = true;
            btnCashier.Click += BtnCashier_Click;
            btnCancel.Click += BtnCancel_Click;
            textBox4.KeyPress += TextBox4_KeyPress;

            if (Lang != AppManager.CurrentLanguage)
            {
                Lang = AppManager.CurrentLanguage;
                SetLanguage();
            }
            Language.ChangeLanguage += VoucherView_ChangeLanguage;
        }

        private void TextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.End && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.Handled == true)
            {
                MessageBox.Show(OnlyNumber, Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        #region INIT FORM

        public void setData(TableBillInfo table)
        {
            //
            //Gán giá trị ban đầu khi mở form lên
            //
            info = new BillInfo();
            if (info ==null)
            {
                MessageBox.Show(ProError, Error);
                return;
            }
            else
            {
                info.Number_table = table.ID;
                info.DAY = DateTime.Now;
                info.Voucher = "#####";
                //Thêm product vào trong bảng thanh toán

                foreach(var i in table.ProductInTable)
                {
                    info.ProductBills.Add(i);
                    tlpProduct.Controls.Add(new Label() { Text = (tlpProduct.RowCount - 1).ToString(), TextAlign = ContentAlignment.MiddleCenter }, 0, tlpProduct.RowCount - 1);
                    tlpProduct.Controls.Add(new Label() { Text = i.Name, TextAlign = ContentAlignment.MiddleLeft }, 1, tlpProduct.RowCount - 1);
                    tlpProduct.Controls.Add(new Label() { Text = i.NumberProduct.ToString(), TextAlign = ContentAlignment.MiddleCenter }, 2, tlpProduct.RowCount - 1);
                    tlpProduct.Controls.Add(new Label() { Text = i.Price.ToString("N0") + "VND", TextAlign = ContentAlignment.MiddleLeft }, 3, tlpProduct.RowCount - 1);
                    tlpProduct.Controls.Add(new Label() { Text = (i.NumberProduct * i.Price).ToString("N0") + "VND", TextAlign = ContentAlignment.MiddleLeft }, 4, tlpProduct.RowCount - 1);
                    tlpProduct.RowCount++;
                    tlpProduct.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
                }
                Info_PropertyChanged(this, new PropertyChangedEventArgs("Init bill"));
                info.PropertyChanged += Info_PropertyChanged;
                Init_Bill();
            }
        }

        void SetLanguage()
        {
            Language.InitLanguage(this);
            lbCashier_Form.Text = Language.Rm.GetString("PAY BILL", Language.Culture);
            lbTableName.Text = Language.Rm.GetString("Table:", Language.Culture);
            lbDate.Text = Language.Rm.GetString("Time:", Language.Culture);
            lbSTT.Text = Language.Rm.GetString("Number", Language.Culture);
            lbNameProduct.Text = Language.Rm.GetString("Product name", Language.Culture);
            lbNumber.Text = Language.Rm.GetString("Qty", Language.Culture);
            lbSinglePrice.Text = Language.Rm.GetString("Unit price", Language.Culture);
            lbSumPrice.Text = Language.Rm.GetString("Amount", Language.Culture);
            lbPrice_Bill.Text = Language.Rm.GetString("Total", Language.Culture);
            lbSale.Text = Language.Rm.GetString("Voucher", Language.Culture);
            lbMoney_Customer.Text = Language.Rm.GetString("Take", Language.Culture);
            lbExchange.Text = Language.Rm.GetString("Give", Language.Culture);
            lbPay.Text = Language.Rm.GetString("Pay", Language.Culture);
            btnCancel.Text = Language.Rm.GetString("Cancel", Language.Culture);
            btnCashier.Text = Language.Rm.GetString("Pay", Language.Culture);
            this.Text = Language.Rm.GetString("Pay", Language.Culture);
            OnlyNumber = Language.Rm.GetString("OnlyNumber", Language.Culture); 
            Error = Language.Rm.GetString("Error", Language.Culture);
            NotEnougnMOney = Language.Rm.GetString("NotEnougnMOney", Language.Culture);
            Out = Language.Rm.GetString("Out", Language.Culture);
            Cancel = Language.Rm.GetString("Cancel", Language.Culture);
            ProError = Language.Rm.GetString("ProError", Language.Culture);
    }
        public void setData(BillInfo table)
        {
            //
            //Gán giá trị ban đầu khi mở form lên
            //
            info = table;
            info.Price_Bill = info.ProductBills.Sum(i => i.NumberProduct * i.Price);
            info.Give = info.Take - info.TOTAL;
            if (info == null)
            {
                MessageBox.Show(ProError);
                return;
            }
            else
            {
                //Thêm product vào trong bảng thanh toán

                foreach (Products i in table.ProductBills)
                {
                    tlpProduct.Controls.Add(new Label() { Text = (tlpProduct.RowCount - 1).ToString() }, 0, tlpProduct.RowCount - 1);
                    tlpProduct.Controls.Add(new Label() { Text = i.Name }, 1, tlpProduct.RowCount - 1);
                    tlpProduct.Controls.Add(new Label() { Text = i.NumberProduct.ToString() }, 2, tlpProduct.RowCount - 1);
                    tlpProduct.Controls.Add(new Label() { Text = i.Price.ToString() }, 3, tlpProduct.RowCount - 1);
                    tlpProduct.Controls.Add(new Label() { Text = (i.NumberProduct * i.Price).ToString() }, 4, tlpProduct.RowCount - 1);
                    tlpProduct.RowCount++;
                    tlpProduct.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
                }
                //Info_PropertyChanged(this, new PropertyChangedEventArgs("init bill"));
                Init_Bill();
            }
        }

        private void Info_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            info.TOTAL = (int)(info.Price_Bill * (100 - percentDecrease)/100);
            info.Give = info.Take - info.TOTAL;            
            if (info.Give < 0)
            {
                textBox5.BackColor = Color.OrangeRed;
            }
            else textBox5.BackColor = System.Drawing.SystemColors.Control;
        }

        private void Init_Bill()
        {
            //
            //Thực hiện binding các textbox với giá trị info
            //
            textBox1.DataBindings.Add("Text", info, "Price_Bill", true, DataSourceUpdateMode.OnPropertyChanged);
            textBox2.DataBindings.Add("Text", info, "Voucher", true, DataSourceUpdateMode.OnPropertyChanged);
            textBox3.DataBindings.Add("Text", info, "TOTAL", true, DataSourceUpdateMode.OnPropertyChanged);
            textBox4.DataBindings.Add("Text", info, "Take", true, DataSourceUpdateMode.OnPropertyChanged);
            textBox5.DataBindings.Add("Text", info, "Give", true, DataSourceUpdateMode.OnPropertyChanged);
            lbTableName.Text += info.Number_table.ToString();
            lbDate.Text = lbDate.Text + info.DAY.ToString(" dd/MM/yyyy HH:mm:ss");
        }

        #endregion


        #region EVENT BUTTON CLICK

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCashier_Click(object sender, EventArgs e)
        {
            if (info.Give<0)
            {
                MessageBox.Show(NotEnougnMOney);
                return;
            }
            isConfirm = true;
            PrintPDF.Instance.createBill(info);
            this.Close();
            DatabaseController.Insert_Bill(info);
        }

        #endregion


        #region PROPERTIES

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
                    btnCancel.Text = Out;
                }
                else
                {
                    btnCashier.Visible = true;
                    btnCancel.Text = Cancel;
                }
            }
        }

        [Category("My properties"), Description("Get percent decrease of discount")]
        public int PercentDecrease { 
            get => percentDecrease;
            set
            {
                percentDecrease = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("Percent Deacreas"));
            }
        }

        #endregion


        #region Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        #endregion
    }
}
