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
        #region Create Properties
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
            get => image;
            set
            {
                image = value;
                Invalidate();
            }
        }
        #endregion
        List<ProductInfo> Menu;
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
        Size itemSize;

        public MenuView()
        {

            InitializeComponent();
            this.SizeChanged += MenuView_SizeChanged;
            ControlTitle.Layout += new LayoutEventHandler((object sender, LayoutEventArgs e) =>
            {
                SetLocationY_bottom_control(controlSearch, ControlTitle);
            });
            itemSize = new Size(100, 100);
            //  flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            //  flowLayoutPanel1.WrapContents = false;
            //  flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            //  flowLayoutPanel1.AutoScroll = true;
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
