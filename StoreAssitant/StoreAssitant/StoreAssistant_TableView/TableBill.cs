using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StoreAssitant.Class_Information;
using System.Threading;

namespace StoreAssitant
{
    public partial class TableBill : UserControl
    {
        #region EVENTS
        [Category("My Event"),Description("When bill control is closed")]
        public event EventHandler CloseBill;
        private void onCloseBill(object sender,EventArgs e) { }
        [Category("My Event"), Description("When button Cashier is clicked")]
        public event EventHandler ClickBtnCashier;
        private void onClickBtnCashier(object s, EventArgs e) { }
        #endregion

        #region FIELDS
        public TableBillInfo Billinfo { get; set; }
        private const int Space_lbSumPrice_pnCashier = 3;
        private SumPrice TotalPrice;
        #endregion

        public TableBill()
        {
            InitializeComponent();
            this.CloseBill = new EventHandler(onCloseBill);
            this.ClickBtnCashier = new EventHandler(onClickBtnCashier);

            this.Layout += TableBill_Layout;
            tableTitle_pnl.Layout += TableBill_Layout;

            btnCashier.Click += BtnCashier_Click;
            TotalPrice = new SumPrice();

            lbPrice.DataBindings.Add("Text", TotalPrice, "Price", true, DataSourceUpdateMode.OnPropertyChanged);
            this.MinimumSize = new Size((new TableLine()).MinimumSize.Width, (new TableLine()).MinimumSize.Height + tableTitle_pnl.MinimumSize.Height + titelLine1.MinimumSize.Height + lbSumPrice.Size.Height + Space_lbSumPrice_pnCashier*2);
        }

        private void Billinfo_ChangedInfo(object sender, EventArgs e)
        {
            TotalPrice.Price = Billinfo.ProductInTable.Sum(p => p.Price * p.NumberProduct);
        }

        #region INIT TABLEBILL
        public void setData(TableBillInfo info)
        {
            tableTitle_lb.Text = "BÀN " + info.ID;
            if (info == null)
            {
                MessageBox.Show("Dữ liệu của bàn bị lỗi");
            }
            else
            {
                this.Billinfo = info;
                Billinfo_ChangedInfo(this, new EventArgs());
                Billinfo.ProductInTable.OnAdded += Billinfo_ChangedInfo;
                Billinfo.ProductInTable.OnRemoved += Billinfo_ChangedInfo;
                foreach (var product in this.Billinfo.ProductInTable)
                {
                    CreateTableLine(product);
                    product.onChanged += Billinfo_ChangedInfo;
                }
            }
        }
        private void CreateTableLine(Class_Information.Products product)
        {
            TableLine line = new TableLine();
            line.Size = new Size(this.Size.Width, line.Size.Height);
            line.SetData(product);
            flpProductInfo.Controls.Add(line);
        }
        public void UploadProduct(ProductInfo product)
        {
            if (!isProductExists(product))
            {
                Products pro = new Products(product);
                pro.onChanged += Billinfo_ChangedInfo;
                Billinfo.ProductInTable.Add(pro);
                CreateTableLine(pro);
            }
        }
        private bool isProductExists(ProductInfo product)
        {
            foreach (Class_Information.Products pro in Billinfo.ProductInTable)
            {
                if (pro.Id == product.Id)
                {
                    foreach(TableLine table in flpProductInfo.Controls)
                    {
                        if (table.IDProduct == pro.Id)
                        {
                            table.Number++;
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private void TableBill_Layout(object sender, LayoutEventArgs e)
        {
            flpProductInfo.Height = this.Height - tableTitle_pnl.Height - titelLine1.Height - pnlCashier.Height - lbSumPrice.Size.Height - Space_lbSumPrice_pnCashier*2;
            tableTitle_lb.Location = new Point((tableTitle_pnl.Size.Width - tableTitle_lb.Size.Width) / 2, (tableTitle_pnl.Size.Height - tableTitle_lb.Size.Height) / 2);
            tableTitle_lb.Size = new Size(tableTitle_lb.Size.Width, tableTitle_pnl.Height);
            lbSumPrice.Location = new Point(0, pnlCashier.Location.Y - lbSumPrice.Size.Height - Space_lbSumPrice_pnCashier);
            lbPrice.Location = new Point(this.Width * 34 /44, lbSumPrice.Location.Y);
            foreach(TableLine line in flpProductInfo.Controls)
            {
                line.Size = new Size(this.Size.Width, line.Size.Height);
            }
        }
        private void RemoveZeroNumberProducts()
        {
            for (int i = 0; i < Billinfo.ProductInTable.Count; i++)
            {
                Class_Information.Products product = Billinfo.ProductInTable[i];
                if (product.NumberProduct == 0)
                {
                    Billinfo.ProductInTable.Remove(product);
                    i--;
                }
            }
        }
        #endregion

        #region EVENTS
        private void BtnCashier_Click(object sender, EventArgs e)
        {
            this.ClickBtnCashier(this, e);
            if (Billinfo!=null)
            {
                if (TotalPrice.Price > 0)
                {
                    FormBill f = new FormBill();

                    //
                    //setting something
                    //
                    for (int i = Billinfo.ProductInTable.Count - 1;i>=0;i--)
                    {
                        if (Billinfo.ProductInTable[i].NumberProduct == 0) Billinfo.ProductInTable.RemoveAt(i);
                    }
                    f.setData(Billinfo);
                    f.ShowDialog();
                    //BẤM XÁC NHẬN THÌ MỚI XÓA
                    if (f.isConfirm)
                    {
                        while (Billinfo.ProductInTable.Count != 0)
                        {
                            Billinfo.ProductInTable.Remove(Billinfo.ProductInTable[Billinfo.ProductInTable.Count - 1]);
                            flpProductInfo.Controls.Remove(flpProductInfo.Controls[flpProductInfo.Controls.Count - 1]);
                        }
                        TotalPrice.Price = 0;
                    }
                    /*
                    DateTime start = new DateTime(2018,1,1);
                    int range = (DateTime.Today - start).Days;
                    for (int i=0;i<range;i++)
                    {
                        int r = (new Random((int)DateTime.Today.Ticks.GetHashCode())).Next(1, 4);
                        for (int j = 0; j < r; j++)
                        {
                            FormBill f = new FormBill();
                            f.Test(start.AddDays(i));
                        }
                    }
                    MessageBox.Show("Thêm hóa đơn thành công");
                    */
                }
                else
                {
                    MessageBox.Show("Bàn này còn trống, chưa có sản phẩm");
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.CloseBill(sender, e);
            RemoveZeroNumberProducts();
            this.Dispose(true);
        }
        #endregion

        #region PROPERTIES
        [Category("My Properties"), Description("Name of the table selected")]
        public string Name
        {
            get => tableTitle_lb.Text;
            set
            {
                tableTitle_lb.Text = value;
                Invalidate();
            }
        }
        #endregion
    }
    class SumPrice : INotifyPropertyChanged
    {
        private int price;
        public int Price
        {
            get => price;
            set
            {
                price = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("Price"));
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
