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
        #region FIELDS

        private bool isReadonly;
        private int percentDecrease;
        public BillInfo info = null;
        public bool isConfirm;

        #endregion



        public FormBill()
        {
            InitializeComponent();

            btnCashier.Click += BtnCashier_Click;
            btnCancel.Click += BtnCancel_Click;
            textBox4.KeyPress += TextBox4_KeyPress;
            textBox2.TextChanged += TextBox2_TextChanged;
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
        }

        private void TextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > (char)Keys.D9 || e.KeyChar < (char)Keys.D0) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            //Edit: Alternative
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.Handled==true)
            {
                MessageBox.Show("Chỉ được phép nhập số");
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
                MessageBox.Show("Lỗi thông tin món ăn");
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
/*                    Products p = new Products();
                    p.Name = i.Name;
                    p.NumberProduct = i.NumberProduct;
                    p.Price = i.Price;*/
                    info.ProductBills.Add(i);
                    tlpProduct.Controls.Add(new Label() { Text = (tlpProduct.RowCount - 1).ToString(), TextAlign = ContentAlignment.MiddleCenter }, 0, tlpProduct.RowCount - 1);
                    tlpProduct.Controls.Add(new Label() { Text = i.Name, TextAlign = ContentAlignment.MiddleLeft }, 1, tlpProduct.RowCount - 1);
                    tlpProduct.Controls.Add(new Label() { Text = i.NumberProduct.ToString(), TextAlign = ContentAlignment.MiddleCenter }, 2, tlpProduct.RowCount - 1);
                    tlpProduct.Controls.Add(new Label() { Text = i.Price.ToString("N0") + "VND", TextAlign = ContentAlignment.MiddleLeft }, 3, tlpProduct.RowCount - 1);
                    tlpProduct.Controls.Add(new Label() { Text = (i.NumberProduct * i.Price).ToString("N0") + "VND", TextAlign = ContentAlignment.MiddleLeft }, 4, tlpProduct.RowCount - 1);
                    tlpProduct.RowCount++;
                    tlpProduct.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
                }
                Info_PropertyChanged(this, new PropertyChangedEventArgs("init bill"));
                info.PropertyChanged += Info_PropertyChanged;
                Init_Bill();
            }
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
                MessageBox.Show("Lỗi thông tin món ăn");
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
            /*lbDate.Text = lbDate.Text + info.DAY.Day + '/' + info.DAY.Month + '/' + info.DAY.Year + " " +
                          info.DAY.Hour + ":" + info.DAY.Minute + ":" + info.DAY.Second;*/
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
                MessageBox.Show("Khách chưa đưa đủ tiền");
                return;
            }
            isConfirm = true;
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
                    btnCancel.Text = "Thoát";
                }
                else
                {
                    btnCashier.Visible = true;
                    btnCancel.Text = "Hủy";
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
