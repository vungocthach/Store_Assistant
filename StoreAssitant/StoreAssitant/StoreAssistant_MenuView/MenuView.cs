using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using StoreAssitant.Class_Information;
using System.Text.RegularExpressions;

namespace StoreAssitant
{
    public partial class MenuView : UserControl
    {
        private static Dictionary<int, ProductInfo> productsList = null;
        public static Dictionary<int, ProductInfo> ProductsList
        {
            get
            {
                if (productsList == null)
                {
                    ReloadProductList();
                }
                return productsList;
            }
        }
        private static void ReloadProductList()
        {
            using (DatabaseController databaseController = new DatabaseController())
            {
                // Get from database
                /*
                List<ProductInfo> l = databaseController.GetProductInfos();
                productsList = new Dictionary<int, ProductInfo>(l.Count);
                foreach (ProductInfo product in l) { productsList.Add(product.Id, product); }
                */
                productsList = databaseController.GetProductInfos();
            }
        }

        //public List<ProductInfo> Menu;
        public List<MenuControl> Control = new List<MenuControl> ();
        
        Size itemSize;

        #region Create event
        public event EventHandler ClickAddButton;
        private void onClickAddButton(object sender, EventArgs e)
        {
            OpenAddProductDialog();
        }
        private void OpenAddProductDialog()
        {
            using (AddProductForm form = new AddProductForm())
            {
                form.ClickSubmitOK += new EventHandler<ProductInfo>((object sender, ProductInfo info) =>
                {
                    using (DatabaseController databaseController = new DatabaseController())
                    {
                        databaseController.InsertProduct(info);
                        //MessageBox.Show("Click On a product" + Environment.NewLine + info.ToString());
                    }
                    AddMenuControl(info);
                    MenuView.ReloadProductList();
                });
                form.ShowDialog();
            }
        }
        public event EventHandler<ProductInfo> ClickAddTableInfo;
        private void onClickAddTableInfo(object sender, ProductInfo e)
        {

        }
        public event EventHandler <ProductInfo> Click_EditProduct;

        private void on_CLick_EditProduct(object sender, ProductInfo p)
        {
            OpenEditProductDialog(p, (MenuControl)sender);
        }
        private void OpenEditProductDialog(ProductInfo info, MenuControl target)
        {
            using (AddProductForm form = new AddProductForm(info))
            {
                form.ClickSubmitOK += new EventHandler<ProductInfo>((object sender, ProductInfo info2) =>
                {
                    using (DatabaseController databaseController = new DatabaseController())
                    {
                        databaseController.UpdateProduct(info2);

                        //MessageBox.Show("Click On a product" + Environment.NewLine + info.ToString());
                    }
                    MenuView.ReloadProductList();
                    target.SetData(info2);
                });
                form.ShowDialog();
            }
        }

        public event EventHandler<ProductInfo> CLick_DeleteProduct;

        private void on_CLick_DeleteProduct(object sender, ProductInfo p)
        {
            using (DatabaseController databaseController = new DatabaseController())
            {
                databaseController.DeleteProduct(p);
            }
            ReloadProductList();
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
                this.MinimumSize = new Size(2 * (value.Width + 10), this.MinimumSize.Height);
                Invalidate();
            }
        }
        [Category("My Properties"), Description("Name of Title")]
        public string NameTitle
        {
            get => ControlTitle.NameTitle;
            set
            {
                ControlTitle.NameTitle = value;
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
        bool ismaneger;
        public bool IsManeger
        {
            get =>ismaneger;
            set
            {
                ismaneger = controlProduct.Visible = value;

                foreach (var i in flowLayoutPanelMenu.Controls)
                {
                    if (i is MenuControl) ((MenuControl)i).IsManeger = value;
                }    
                Invalidate();
            }
        }
        #endregion
        public void AddMenuControl(ProductInfo Infor)
        {
            MenuControl Product = new MenuControl();

            Product.SetData(Infor);
            Product.Size = ItemSize;
            Product.IsManeger = this.ismaneger;


            flowLayoutPanelMenu.Controls.Remove(controlProduct);
            flowLayoutPanelMenu.Controls.Add(Product);
            flowLayoutPanelMenu.Controls.Add(controlProduct);

           
            Product.Click_AddControlProduct += Product_Click_AddControlProduct;
            Product.Click_EditProductInfo += Product_Click_EditProductInfo;
            Product.CLick_DeleteProductInfo += Product_CLick_DeleteProductInfo;

            controlSearch.Click_SearchBar += ControlSearch_Click_SearchBar;

            Control.Add(Product);

        }

        public static string convertToUnSign3(string s)
        {
            string S = s.ToUpper();
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = S.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        private void ControlSearch_Click_SearchBar(object sender, EventArgs e)
        {
            foreach( Control t in flowLayoutPanelMenu.Controls)
            {
                if (t is MenuControl)
                {
                    MenuControl T = t as MenuControl;
                    if (!convertToUnSign3(T.NameTitle).Contains(convertToUnSign3(controlSearch.Text))) T.Visible = false;
                    else T.Visible = true;
                }
            }    
        }

        private void Product_CLick_DeleteProductInfo(object sender, ProductInfo e)
        {
            Control.Remove(sender as MenuControl);
            CLick_DeleteProduct(sender, e);
        }

        private void Product_Click_EditProductInfo(object sender, ProductInfo e)
        {
            Click_EditProduct(sender, e);
        }
     
        public void ClearData()
        {
            flowLayoutPanelMenu.Controls.Clear();
            flowLayoutPanelMenu.Controls.Add(controlProduct);
        }

        public void SetData()
        {
            ClearData();
            foreach (KeyValuePair<int, ProductInfo> P in ProductsList)
            {
                AddMenuControl(P.Value);
            }
        }

        public MenuView()
        {

            InitializeComponent();


            controlProduct.BackColor = Color.Transparent;

            ClickAddTableInfo = new EventHandler<ProductInfo>(onClickAddTableInfo);

            ClickAddButton = new EventHandler(onClickAddButton);

            Click_EditProduct = new EventHandler<ProductInfo>(on_CLick_EditProduct);

            CLick_DeleteProduct = new EventHandler<ProductInfo>(on_CLick_DeleteProduct);

            ControlTitle.Layout += new LayoutEventHandler((object sender, LayoutEventArgs e) =>
            {
                SetLocationY_bottom_control(controlSearch, ControlTitle);
            });

            controlSearch.Control = Control;

            itemSize = new Size(100, 100);

            this.Layout += MenuView_SizeChanged;

            controlProduct._Click += ControlProduct_Click;


            //controlSearch.Click_SearchBar += ControlSearch_Click_SearchBar;

        }

        /*private void ControlSearch_Click_SearchBar(object sender, EventArgs e)
        {
            controlSearch.Control = Control;
        }*/


        private void ControlProduct_Click(object sender, EventArgs e)
        {
           /* BillInfo bill = new BillInfo();
            bill.ProductInBill = new List<Class_Information.Products>();
            bill.ProductInBill.Add(new Class_Information.Products(new ProductInfo(90, "trà sữa", 20000, "thơm ngon")));
            bill.Give = 10000;
            bill.Take = 500;
            bill.Number_table = 3;
            bill.USER_Name = "admin";
            bill.Voucher ="AVXFX";
            bill.TOTAL = 130000;*/

/*            DatabaseController t = new DatabaseController();
            t.insert_Bill(bill);*/
            ClickAddButton(this, e);           
        }
        private void Product_Click_AddControlProduct(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Left)
            {
                ClickAddTableInfo(this, ((MenuControl)sender).ProductInfo);
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
