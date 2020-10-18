using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting.Messaging;

namespace StoreAssitant
{
    public partial class MenuControl : UserControl
    {
        ProductInfo Infor;
        public ContextMenuStrip contextMenustrip;

        Color color_MouseEnter = System.Drawing.Color.PapayaWhip;
        Color color_Default = System.Drawing.Color.PapayaWhip;
        #region create event Click_AddControlProduct, Click_Delete

        public ProductInfo ProductInfo { get { return Infor; } }



        public event EventHandler Click_AddControlProduct;

        private void on_Click_AddControlProduct(object sender, EventArgs e)
        { }

        public event EventHandler<ProductInfo> Click_EditProductInfo;

        private void on_Click_EditProductInfo (object sender, ProductInfo Info)
        {

        }
        public event EventHandler<ProductInfo> CLick_DeleteProductInfo;

        private void on_Click_DeleteProductInfo(object sender, ProductInfo Info )
        { }
        #endregion
        #region Create properties
        [Category("My Properties"), Description("Name of Title")]
        public string NameTitle
        {
            get => textBoxName.Text;
            set
            {
                textBoxName.Text = value;
                Invalidate();
            }
        }

        public Bitmap PDImage
        {
            get { return (Bitmap)pictureBox.Image; }
            set
            {
                if (pictureBox.Image != null) { pictureBox.Image.Dispose(); }
                /*
                double percent_Y = pictureBox.Height / (double)value.Height;
                double percent_X = pictureBox.Width / (double)value.Width;
                double percent = (percent_X < percent_Y) ? percent_X : percent_Y;
                Size nSize = new Size((int)(value.Width * percent), (int)(value.Height * percent));
                pictureBox.Image = new Bitmap(value, nSize);
                value.Dispose();*/
                pictureBox.Image = value;
                Invalidate();
            }
        }

        [Category("My Properties"), Description("Inmage of Menu title ")]
        public Image image
        {
            get => pictureBox.BackgroundImage;
            set
            {
                pictureBox.BackgroundImage = value;
                Invalidate();
            }
        }

        int price = 1000;
        [Category("My Properties"), Description("Price of product")]
        public int Price
        {
            get { return price; }
            set
            {
                price = value;
                textBoxPrice.Text = string.Format("{0}VND", price.ToString("N0"));
                Invalidate();
            }
        }
        [Category("My Propperties"), Description("Define is Maneger")]

        bool ismaneger;
        public bool IsManeger
        {
            get => ismaneger;

            set
            {
                ismaneger = deletetoolStripMenuItem.Visible = editToolStripMenuItem.Visible = value;
                Invalidate();
            }
        }
        #endregion
        public void SetData(ProductInfo info)
        {
            Infor = info;
            NameTitle = info.Name;
            Price = info.Price;
            PDImage = info.Image;
        }

        public MenuControl()
        {
            InitializeComponent();

            // this.MinimumSize = new Size(125, 140);

            Click_AddControlProduct = new EventHandler(on_Click_AddControlProduct);

            Click_EditProductInfo = new EventHandler<ProductInfo> (on_Click_EditProductInfo);

            CLick_DeleteProductInfo = new EventHandler<ProductInfo>(on_Click_DeleteProductInfo);

            this.contextMenustrip = contextMenuStrip1;

            this.Layout += MenuControl_Layout;

            this.Click += MenuControl_Click;

            editToolStripMenuItem.Click += EditToolStripMenuItem_Click;

            deletetoolStripMenuItem.Click += DeletetoolStripMenuItem_Click;

            #region MouseClick_Control

            pictureBox.MouseClick += _MouseClick;
            textBoxName.MouseClick += _MouseClick;
            textBoxPrice.MouseClick += _MouseClick;
            #endregion

            #region Click_Control
            pictureBox.Click += pictureBox_Click;
            textBoxName.Click += TextBoxName_Click;
            textBoxPrice.Click += TextBoxPrice_Click;
            #endregion

            #region MouseEnter_Control

            pictureBox.MouseEnter += MenuControl_MouseEnter;
            textBoxName.MouseEnter += MenuControl_MouseEnter;
            textBoxPrice.MouseEnter += MenuControl_MouseEnter;
            #endregion

            #region MouseLeave_Control

            this.MouseLeave += MenuControl_MouseLeave;
            pictureBox.MouseLeave += MenuControl_MouseLeave;
            textBoxPrice.MouseLeave += MenuControl_MouseLeave;
            textBoxName.MouseLeave += MenuControl_MouseLeave;
            #endregion
        }

        private void DeletetoolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            CLick_DeleteProductInfo(this, Infor);
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Click_EditProductInfo(this, Infor);
        }


        private void _MouseClick(object sender, MouseEventArgs e)
        {
            if ( e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(this, new Point(e.X, e.Y));
            }
        }

        private void MenuControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = color_MouseEnter;
            textBoxName.Size -= new Size (0, 2);
            this.BorderStyle = BorderStyle.Fixed3D;
        }

        private void MenuControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = color_Default;
            textBoxName.Size += new Size(0, 2);
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        private void MenuControl_Click(object sender, EventArgs e)
        {
            this.BorderStyle = BorderStyle.None;
        }

        private void TextBoxPrice_Click(object sender, EventArgs e)
        {
            Click_AddControlProduct(this, e);
        }

        private void TextBoxName_Click(object sender, EventArgs e)
        {
            Click_AddControlProduct(this, e);
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            Click_AddControlProduct(this, e);
        }

        private void MenuControl_Layout(object sender, EventArgs e)
        {
            pictureBox.Size = new Size(this.Width, Convert.ToInt32(this.Height * 0.8));
            //PDImage = (Bitmap)pictureBox.Image;
            //textBoxPrice.Location = new Point(0, pictureBox.Height);
            //textBoxName.Location = new Point(0, pictureBox.Height + textBoxPrice.Height);
            //textBoxName.Size = textBoxPrice.Size = new Size(this.Width, (this.Height - pictureBox.Height)/2);
            textBoxPrice.Location = new Point(this.Width - textBoxPrice.Width, pictureBox.Height - textBoxPrice.Height);
            textBoxName.Location = new Point((this.Width - textBoxName.Width) / 2, pictureBox.Height + (this.Height - pictureBox.Height - textBoxName.Height) / 2);
        }

      
    }
}
