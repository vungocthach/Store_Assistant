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
        #endregion

        public TableBill(TableBillInfo tableinfo, int iD)
        {
            InitializeComponent();
            this.CloseBill = new EventHandler(onCloseBill);
            this.ClickBtnCashier = new EventHandler(onClickBtnCashier);
            this.Layout += TableBill_Layout;
            tableTitle_pnl.Layout += TableBill_Layout;
            btnCashier.Click += BtnCashier_Click;
            tableTitle_lb.Text = "BÀN " + (iD+1);
            setData(tableinfo);
            this.SizeChanged += TableBill_SizeChanged;
            this.MinimumSize = new Size((new TableLine()).MinimumSize.Width, (new TableLine()).MinimumSize.Height);
        }

        private void TableBill_SizeChanged(object sender, EventArgs e)
        {
            tableTitle_lb.Location = new Point((tableTitle_pnl.Size.Width - tableTitle_lb.Size.Width)/2, (tableTitle_pnl.Size.Height - tableTitle_lb.Size.Height)/2);
        }

        #region INIT TABLEBILL
        public void setData(TableBillInfo info)
        {
            if (info == null)
            {
                MessageBox.Show("Dữ liệu của bàn bị lỗi");
            }
            else
            {
                this.Billinfo = info;
                foreach (var product in this.Billinfo.ProductInTable)
                {
                    CreateTableLine(product);
                }
            }
        }
        private void CreateTableLine(Products product)
        {
            TableLine line = new TableLine();
            line.Size = new Size(this.Size.Width, line.Size.Height);
            line.SetData(product);
            flpProductInfo.Controls.Add(line);
            line.Dock = DockStyle.Top;
        }
        public void UploadProduct(ProductInfo product)
        {
            if (!isProductExists(product))
            {
                Products pro = new Products(product);
                Billinfo.ProductInTable.Add(pro);
                CreateTableLine(pro);
            }
        }
        private bool isProductExists(ProductInfo product)
        {
            foreach (Products pro in Billinfo.ProductInTable)
            {
                if (pro.Id == product.Id)
                {
                    TableLine line = new TableLine();
                    line.SetData(pro);
                    foreach(TableLine table in flpProductInfo.Controls)
                    {
                        if (table.IDProduct == line.IDProduct)
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
            flpProductInfo.Height = this.Height - tableTitle_pnl.Location.Y - tableTitle_pnl.Height;
            tableTitle_lb.Location = new Point((this.Size.Width - tableTitle_lb.Size.Width) / 2, 0);
            tableTitle_lb.Size = new Size(tableTitle_lb.Size.Width, tableTitle_pnl.Height);
        }
        private void RemoveZeroNumberProducts()
        {
            for (int i = 0; i < Billinfo.ProductInTable.Count; i++)
            {
                Products product = Billinfo.ProductInTable[i];
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
                while(Billinfo.ProductInTable.Count!=0)
                {
                    Billinfo.ProductInTable.Remove(Billinfo.ProductInTable[Billinfo.ProductInTable.Count - 1]);
                    flpProductInfo.Controls.Remove(flpProductInfo.Controls[flpProductInfo.Controls.Count - 1]);
                }
                MessageBox.Show("Hiện thanh toán...");
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

        private void tableLine1_Load(object sender, EventArgs e)
        {

        }
    }
}
