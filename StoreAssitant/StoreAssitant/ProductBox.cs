using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Markup;

namespace StoreAssitant
{
    public partial class ProductBox : UserControl
    {
        ProductInfo info;

        /*
        private RectangleF imgRectFMaximum;
        private Margins imgMargin;
        private Padding imgPadding;
        */

        [Category("My Properties"), Description("Image of product")]
        public Image ProductImage
        {
            get { return info.Image; }
            set
            {
                info.Image = value;
                DrawImage();
                Invalidate();
            }
        }

        [Category("My Properties"), Description("Image of product")]
        public int ProductPrice
        {
            get { return info.Price; }
            set
            {
                txtb_Price.Text = value.ToString();
                Invalidate();
            }
        }

        /// <summary>
        /// Should use SetCustomProductName/GetCustomProductName instead
        /// </summary>
        [Category("My Properties"), Description("Name of product")]
        public string CustomProductName
        {
            get { return GetCustomProductName(); }
            set { SetCustomProductName(value); }
        }

        /// <summary>
        /// Get name of the product item
        /// </summary>
        public string GetCustomProductName() { return info.Name; }

        /// <exception cref = "InvalidNameException">Thrown when string-name contains invalid character</exception>
        /// <summary>
        /// Set name of the product item
        /// </summary>
        public void SetCustomProductName(string value)
        {
            string filter = (@",./;'[]-=<>?:{ }_+|~!@#$%^&*()""`");
            foreach (char c in filter)
            {
                if (value.Contains(c)) { throw new InvalidNameException(string.Format("Name must not contain any of characters below : {0}", filter)); }
            }
            info.Name = value.Trim();
            txtb_Name.Text = info.Name;
            Invalidate();
        }

        public ProductBox()
        {
            InitializeComponent();
            info = new ProductInfo();
            /*
            imgMargin = new Margins(0,0,0,0);
            imgPadding = new Padding(0, 0, 0, 0);

            imgRectFMaximum = new RectangleF(imgPadding.Left + imgMargin.Left, imgMargin.Top + imgPadding.Top, this.Width - imgMargin.Right - imgPadding.Right, txtb_Name.Location.Y - imgMargin.Bottom - imgPadding.Bottom);
            */
            label_Image.Click += new EventHandler((object sender, EventArgs e) => {
                string path = GetPath();
                if (path != null && File.Exists(path))
                {
                    this.ProductImage = Image.FromFile(path);
                }
            });

            txtb_Name.LostFocus += Txtb_Name_LostFocus;
        }

        private void Txtb_Name_LostFocus(object sender, EventArgs e)
        {
            try
            {
                SetCustomProductName(txtb_Name.Text);
            }
            catch (InvalidNameException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DrawImage()
        {
            if (info.Image != null )
            {
                label_Image.Text = string.Empty;
                Bitmap bmp = new Bitmap(info.Image, label_Image.Size);
                label_Image.Image = bmp;
            }
            else
            {
                // Draw default image
                label_Image.Text = "Chọn hình ảnh" + Environment.NewLine + "(+)";
            }
        }
        private string GetPath()
        {
            string rs = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn ảnh";
            openFileDialog.Filter = "Image File (*.img, *.bmp, *.jpg)|*.img;*.bmp;*.jpg";
            openFileDialog.FileOk += new CancelEventHandler((object sender, CancelEventArgs e) =>
            {
                if (openFileDialog.CheckFileExists)
                {
                    rs = openFileDialog.FileName;
                }
            });
            openFileDialog.ShowDialog();
            return rs;
        }

        
    }

    public class ProductInfo
    {
        public Image Image { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string[] Tags { get; set; }
        public string Description { get; set; }
    }

    public class InvalidNameException : Exception
    {
        public InvalidNameException(string message)
        {
            Console.WriteLine(string.Format("Invalid Name Exception {0}Message : {1} {0}Source : {2}", Environment.NewLine, message, this.Source));
        }
    }
}
