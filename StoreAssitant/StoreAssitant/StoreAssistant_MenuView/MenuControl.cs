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
        Color color_MouseEnter = System.Drawing.Color.PapayaWhip;
        Color color_Default = System.Drawing.Color.PapayaWhip;
        #region create event Click_AddControlProduct, Click_Delete

        public event EventHandler CLick_Delete;
        private void onCLick_Delete(object sender, EventArgs e)
        {

        }

        public ProductInfo ProductInfo { get { return Infor; } }

        

        public event EventHandler Click_AddControlProduct;

        private void on_Click_AddControlProduct(object sender, EventArgs e)
        { }

        public event EventHandler<ProductInfo> Click_EditProductInfo;

        private void on_Click_EditProductInfo (object sender, ProductInfo Info)
        {

        }
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

            CLick_Delete += new EventHandler(onCLick_Delete);

            Click_AddControlProduct = new EventHandler(on_Click_AddControlProduct);

            Click_EditProductInfo += new EventHandler<ProductInfo> (on_Click_EditProductInfo);

            this.Layout += MenuControl_Layout;

            this.Click += MenuControl_Click;

            editToolStripMenuItem.Click += EditToolStripMenuItem_Click;

            toolStripMenuItem1.Click += ToolStripMenuItem1_Click;
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

            #region MouseHover_Control

            this.MouseEnter += MenuControl_MouseHover;
            pictureBox.MouseEnter += MenuControl_MouseHover;
            textBoxName.MouseEnter += MenuControl_MouseHover;
            textBoxPrice.MouseEnter += MenuControl_MouseHover;
            #endregion

            #region MouseLeave_Control

            this.MouseLeave += MenuControl_MouseLeave;
            pictureBox.MouseLeave += MenuControl_MouseLeave;
            textBoxPrice.MouseLeave += MenuControl_MouseLeave;
            textBoxName.MouseLeave += MenuControl_MouseLeave;
            #endregion
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Click_EditProductInfo(this, Infor);
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CLick_Delete(this, e);
        }

        private void _MouseClick(object sender, MouseEventArgs e)
        {
            if ( e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(this, new Point(e.X, e.Y));
            }
        }

        private void MenuControl_MouseHover(object sender, EventArgs e)
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

        private void textBoxName_Click_1(object sender, EventArgs e)
        {

        }

        private void textBoxPrice_Click_1(object sender, EventArgs e)
        {

        }

        private void MenuControl_Load(object sender, EventArgs e)
        {

        }
    }
}
