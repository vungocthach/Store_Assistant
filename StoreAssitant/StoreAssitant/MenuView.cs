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
                if (flowLayoutPanel1.Controls == null || flowLayoutPanel1.Controls.Count < 1) { return System.Drawing.Size.Empty; }
                else
                {
                    return flowLayoutPanel1.Controls[0].Size;
                }
            }
            set
            {
                foreach (Control control in flowLayoutPanel1.Controls)
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
        #region Create even add_ControlProduct
        private event EventHandler add_ControlProduct;
        public event EventHandler Add_ControlProduct
        {
            add
            {
                add_ControlProduct += value;
            }
            remove
            {
                add_ControlProduct -= value;
            }
        }
        public void Onclick()
        {
            if (add_ControlProduct != null)
                add_ControlProduct(this, new EventArgs());
        }
        #endregion
        #region Create even add_Product
        private event EventHandler add_Product;
        public event EventHandler Add_Product
        {
            add
            {
                add_ControlProduct += value;
            }
            remove
            {
                add_ControlProduct -= value;
            }
        }
        public void on_add_Product()
        {
            if (add_Product != null)
                add_Product(this, new EventArgs());
        }
        #endregion
        public void AddMenuControl(ProductInfo Infor)
        {
            MenuControl M = new MenuControl();
            M.SetData(Infor);
            M.Show();
        }
        public void SetData(List<ProductInfo> Pro)
        {
            foreach (ProductInfo P in Pro)
            {
                AddMenuControl(P);
                Menu.Add(P);
            }
        }
        
       
        public MenuView()
        {

            InitializeComponent();
            this.SizeChanged += MenuView_SizeChanged;
            ControlTitle.Layout += new LayoutEventHandler((object sender, LayoutEventArgs e) =>
            {
                SetLocationY_bottom_control(controlSearch, ControlTitle);
            });
            itemSize = new Size(100, 100);
            this.Add_ControlProduct += MenuView_Add_ControlProduct;
            this.Add_Product += MenuView_Add_Product;
           
            //  flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            //  flowLayoutPanel1.WrapContents = false;
            //  flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            //  flowLayoutPanel1.AutoScroll = true;
        }

        private void MenuView_Add_Product(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng đang được xây dựng");
        }
        private void MenuView_Add_ControlProduct(object sender, EventArgs e)
        {

            MessageBox.Show("Tính năng đang được xây dựng"); 
        }

        private void SetLocationY_bottom_control(Control target, Control base_control)
        {
            target.Location = new Point(target.Location.X,
            base_control.Location.Y + base_control.Height + base_control.Margin.Bottom + target.Margin.Top);
        }

        private void MenuView_SizeChanged(object sender, EventArgs e)
        {
            /* ControlTitle.Location = new Point(0, 0);
             ControlTitle.Size = new Size(this.Width, Convert.ToInt32(this.Height * 0.1));
             controlSearch.Location = new Point(0, Convert.ToInt32(this.Height * 0.12));
             controlSearch.Size = new Size(Convert.ToInt32(this.Width * 0.8), Convert.ToInt32(this.Height * 0.07));
             controlProduct.Location = new Point(Convert.ToInt32(this.Width * 0.02), Convert.ToInt32(this.Height * 0.20));
             flowLayoutPanel1.Location = new Point(0, Convert.ToInt32(this.Height*0.19));
             flowLayoutPanel1.Size = new Size(this.Width -10, 10000);*/


            controlSearch.Width = this.Width - 15;
            flowLayoutPanel1.Height = this.Height - controlSearch.Location.Y - controlSearch.Height - 10;
        }
    }
       
}
