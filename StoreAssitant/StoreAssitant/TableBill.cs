﻿using System;
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
        [Category("My Event"),Description("When bill control is closed")]
        public event EventHandler CloseBill;
        private void onCloseBill(object sender,EventArgs e) { }
        [Category("My Event"), Description("When button Cashier is clicked")]
        public event EventHandler ClickBtnCashier;
        private void onClickBtnCashier(object s, EventArgs e) { }


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

        private void BtnCashier_Click(object sender, EventArgs e)
        {
            this.ClickBtnCashier(this, e);
            if (Billinfo!=null)
            {
                while(Billinfo.ProductInTable.Count!=0)
                {
                    Billinfo.ProductInTable.Remove(Billinfo.ProductInTable[0]);
                    flpProductInfo.Controls.Remove(flpProductInfo.Controls[0]);
                }
                MessageBox.Show("Hiện thanh toán...");
            }
        }

        private void TableBill_Layout(object sender, LayoutEventArgs e)
        {
            flpProductInfo.Height = this.Height - tableTitle_pnl.Location.Y - tableTitle_pnl.Height;
            tableTitle_lb.Location = new Point((this.Size.Width - tableTitle_lb.Size.Width) / 2, 0);
            tableTitle_lb.Size = new Size(tableTitle_lb.Size.Width, tableTitle_pnl.Height);
        }

        public TableBillInfo Billinfo { get; set; }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.CloseBill(sender, e);
            RemoveZeroNumberProducts();
            this.Dispose(true);
        }
        private void RemoveZeroNumberProducts()
        {
            for (int i=0;i<Billinfo.ProductInTable.Count;i++)
            {
                Products product = Billinfo.ProductInTable[i];
                if (product.NumberProduct == 0)
                {
                    Billinfo.ProductInTable.Remove(product);
                    i--;
                }
            }
        }

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
            line.SetData(product);
            flpProductInfo.Controls.Add(line);
        }
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
    }
}
