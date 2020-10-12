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

namespace StoreAssitant
{
    public partial class MenuView : UserControl
    {
        List<ProductInfo> Menu;
        Size itemSize;
        public event EventHandler ClickAddButton;
        private void onClickAddButton(object sender, EventArgs e)
        {

        }
        public event EventHandler<ProductInfo> ClickAddTableInfo;
        private void onClickAddTableInfo(object sender, ProductInfo e)
        {

        }
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

            ClickAddTableInfo = new EventHandler<ProductInfo>(onClickAddTableInfo);

            ClickAddButton = new EventHandler(onClickAddButton);

            this.SizeChanged += MenuView_SizeChanged;

            ControlTitle.Layout += new LayoutEventHandler((object sender, LayoutEventArgs e) =>
            {
                SetLocationY_bottom_control(controlSearch, ControlTitle);
            });
            itemSize = new Size(100, 100);
            controlProduct._Click += ControlProduct_Click;
        }

        private void ControlProduct_Click(object sender, EventArgs e)
        {
            /**/
            ClickAddButton(this, new EventArgs() {});
        }

        

        private void Product_Click_AddControlProduct(object sender, EventArgs e)
        {
            ClickAddTableInfo(this, ((MenuControl)sender).ProductInfo);
            //MessageBox.Show("Tính năng đang được xây dựng");
        }

        private void SetLocationY_bottom_control(Control target, Control base_control)
        {
            target.Location = new Point(target.Location.X,
            base_control.Location.Y + base_control.Height + base_control.Margin.Bottom + target.Margin.Top);
        }

        private void MenuView_SizeChanged(object sender, EventArgs e)
        {
            controlSearch.Width = this.Width - 15;
            flowLayoutPanelMenu.Height = this.Height - controlSearch.Location.Y - controlSearch.Height - 10;
        }
    }
       
}
