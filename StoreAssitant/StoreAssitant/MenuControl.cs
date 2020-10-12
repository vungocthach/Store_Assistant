using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreAssitant
{
    public partial class MenuControl : UserControl
    {
        ProductInfo Infor;

        public event EventHandler Click_AddControlProduct;


        private void on_Click_AddControlProduct(object sender, EventArgs e)
        { }
        #region Create properties
        [Category("My Properties"), Description("Name of Title")]
        public string NameTitle
        {
            get => textBoxName.Name;
            set
            {
                Name = value;
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
#endregion
        public void SetData(ProductInfo info)
        {
            Infor = info;
            textBoxName.Text = info.Name;
            textBoxPrice.Text = Convert.ToString( info.Price);
            pictureBox.BackgroundImage = info.Image;
        }
        
        public MenuControl()
        {
            InitializeComponent();

            Click_AddControlProduct = new EventHandler(on_Click_AddControlProduct);

            this.Layout += MenuControl_Layout;

            pictureBox.Click += pictureBox_Click;
            textBoxName.Click += TextBoxName_Click;
            textBoxPrice.Click += TextBoxPrice_Click;

            this.Click += MenuControl_Click;

            pictureBox.MouseHover += MenuControl_MouseHover;
            textBoxName.MouseHover += MenuControl_MouseHover;
            textBoxPrice.MouseHover += MenuControl_MouseHover;

            pictureBox.MouseLeave += MenuControl_MouseLeave;
            textBoxPrice.MouseLeave += MenuControl_MouseLeave;
            textBoxName.MouseLeave += MenuControl_MouseLeave;
           
        }

        private void MenuControl_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.BorderStyle = BorderStyle.Fixed3D;
        }

        private void MenuControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.Control;
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        private void MenuControl_Click(object sender, EventArgs e)
        {
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        private void TextBoxPrice_Click(object sender, EventArgs e)
        {
            Click_AddControlProduct(this, new EventArgs());
        }

        private void TextBoxName_Click(object sender, EventArgs e)
        {
            Click_AddControlProduct(this, new EventArgs());
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            Click_AddControlProduct(this, new EventArgs());
            pictureBox.BorderStyle = BorderStyle.FixedSingle;  
        }

        private void MenuControl_Layout(object sender, EventArgs e)
        {
            //pictureBox.Size = new Size(this.Width, Convert.ToInt32(this.Height * 0.8));
            textBoxPrice.Location = new Point(0, pictureBox.Height);
            //textBoxPrice.Size = new Size(this.Width, this.Height - pictureBox.Height - textBoxName.Height);
        }

    }
}
