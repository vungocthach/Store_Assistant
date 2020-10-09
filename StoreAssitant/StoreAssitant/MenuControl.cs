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
        MenuView M;
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
            get => panelImage.BackgroundImage;
            set
            {
                panelImage.BackgroundImage = value;
                Invalidate();
            }
        }
#endregion
        public void SetData(ProductInfo info)
        {
            Infor = info;
            textBoxName.Text = info.Name;
            textBoxPrice.Text = Convert.ToString( info.Price);
            panelImage.BackgroundImage = info.Image;
        }
        
        public MenuControl()
        {
            InitializeComponent();
            this.SizeChanged += MenuControl_SizeChanged;
            panelImage.Click += PanelImage_Click;
            textBoxName.Click += TextBoxName_Click;
            textBoxPrice.Click += TextBoxPrice_Click;
           
        }

        private void TextBoxPrice_Click(object sender, EventArgs e)
        {
            M = new MenuView();
            M.on_add_Product();
        }

        private void TextBoxName_Click(object sender, EventArgs e)
        {
            M = new MenuView();
            M.on_add_Product();
        }

        private void PanelImage_Click(object sender, EventArgs e)
        {
            M = new MenuView();
            M.on_add_Product();
        }

        private void MenuControl_SizeChanged(object sender, EventArgs e)
        {
            panelImage.Location = new Point(0, 0);
            panelImage.Size = new Size(this.Width, Convert.ToInt32(this.Height * 0.9));
            textBoxPrice.Location = new Point(0, panelImage.Height);
            textBoxPrice.Size = new Size(this.Width, this.Height - panelImage.Height - textBoxName.Height);
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
