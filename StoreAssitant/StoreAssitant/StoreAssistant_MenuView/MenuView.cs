﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace StoreAssitant
{
    public partial class MenuView : UserControl
    {
        List<ProductInfo> Menu;

        Size itemSize;

        #region Create event
        public event EventHandler ClickAddButton;
        private void onClickAddButton(object sender, EventArgs e)
        {

        }
        public event EventHandler<ProductInfo> ClickAddTableInfo;
        private void onClickAddTableInfo(object sender, ProductInfo e)
        {

        }
        #endregion
        #region Create Properties
        [Category("My Properties"), Description("Height of title bar in pixel")]
        public int TitleHeight
        {
            get { return ControlTitle.Height; }
            set
            {
                ControlTitle.Height = value;
                Invalidate();
            }
        }

        [Category("My Properties"), Description("Height of title bar in pixel")]
        public Size ItemSize
        {
            get
            {
                if (flowLayoutPanelMenu.Controls == null || flowLayoutPanelMenu.Controls.Count < 1) { return System.Drawing.Size.Empty; }
                else
                {
                    return flowLayoutPanelMenu.Controls[0].Size;
                }
            }
            set
            {
                foreach (Control control in flowLayoutPanelMenu.Controls)
                {
                    control.Size = value;
                }
                Invalidate();
            }
        }
        [Category("My Properties"), Description("Name of Title")]
        public string NameTitle
        {
            get => ControlTitle.Name;
            set
            {
                Name = value;
                Invalidate();
            }
        }
        [Category("My Properties"), Description("Inmage of Menu title ")]
        public Image image
        {
            get => ControlTitle.image;
            set
            {
                ControlTitle.image = value;
                Invalidate();
            }
        }
        [Category("My Properties"), Description("Define is the maneger ")]

        public bool IsManeger
        {
            get => controlProduct.Visible;
            set
            {
                controlProduct.Visible = value;
                Invalidate();
            }
        }
        #endregion
        public void AddMenuControl(ProductInfo Infor)
        {
            MenuControl Product = new MenuControl();
            Product.SetData(Infor);
            Product.Size = ItemSize;
            flowLayoutPanelMenu.Controls.Remove(controlProduct);
            flowLayoutPanelMenu.Controls.Add(Product);
            flowLayoutPanelMenu.Controls.Add(controlProduct);
            Product.Click_AddControlProduct += Product_Click_AddControlProduct;
            Product.Click_EditProductInfo += Product_Click_EditProductInfo;
        }

        private void Product_Click_EditProductInfo(object sender, ProductInfo e)
        {
            MessageBox.Show(e.ToString());
        }

        public void SetData(List<ProductInfo> Pro)
        {
            foreach (ProductInfo P in Pro)
            {
                AddMenuControl(P);
                //Menu.Add(P);
            }
        }
       
        public MenuView()
        {

            InitializeComponent();

            controlProduct.BackColor = Color.Transparent;

            ClickAddTableInfo = new EventHandler<ProductInfo>(onClickAddTableInfo);

            ClickAddButton = new EventHandler(onClickAddButton);


            ControlTitle.Layout += new LayoutEventHandler((object sender, LayoutEventArgs e) =>
            {
                SetLocationY_bottom_control(controlSearch, ControlTitle);
            });


            itemSize = new Size(100, 100);

            this.Layout += MenuView_SizeChanged;

            controlProduct._Click += ControlProduct_Click;


        }

     
        private void ControlProduct_Click(object sender, EventArgs e)
        {
            ClickAddButton(this, e);
        }

        

        private void Product_Click_AddControlProduct(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Left)
            {
                ClickAddTableInfo(this, ((MenuControl)sender).ProductInfo);
              //MessageBox.Show("Tính năng đang được xây dựng");
            }

        }

        private void SetLocationY_bottom_control(Control target, Control base_control)
        {
            target.Location = new Point(target.Location.X,
            base_control.Location.Y + base_control.Height + base_control.Margin.Bottom + target.Margin.Top);
        }

        private void MenuView_SizeChanged(object sender, EventArgs e)
        {
            controlSearch.Width = this.Width - 15;
            flowLayoutPanelMenu.Location = new Point(0, Convert.ToInt32(controlSearch.Location.Y * 2.5));
            flowLayoutPanelMenu.Height = this.Height - controlSearch.Location.Y - controlSearch.Height - 5;
        }
    }
       
}