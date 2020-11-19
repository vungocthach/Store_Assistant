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
    public partial class FormBill : Form
    {
        private bool isReadonly;
        public BillInfo info = null;
        public FormBill()
        {
            InitializeComponent();

/*            info = new BillInfo();
            info.IDTable = 1;
            info.DayBill = DateTime.Now;
            info.Price_Bill = 1000;
            info.SaleCode = "###";
            ProductBill p = new ProductBill();
            p.Name = "ok";
            p.Number = 5;
            p.SinglePrice = 1000;
            info.ProductBills.Add(p);
            IsReadonly = true;*/

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
            info.Price_Bill += 1000;
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
                info.Price_Bill = table.ProductInTable.Sum(i => i.Price * i.NumberProduct);
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
                
            }
        }
        private void Init_Bill()
        {
            textBox1.DataBindings.Add("Text", info, "Price_Bill", true, DataSourceUpdateMode.OnPropertyChanged);
            textBox2.DataBindings.Add("Text", info, "SaleCode", true, DataSourceUpdateMode.OnPropertyChanged);
            //textBox3.DataBindings.Add("Text", info, , true, DataSourceUpdateMode.OnPropertyChanged);
            textBox4.DataBindings.Add("Text", info, "Price_Customer", true, DataSourceUpdateMode.OnPropertyChanged);
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
    }
}
