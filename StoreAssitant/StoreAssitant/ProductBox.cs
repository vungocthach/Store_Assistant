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

        [Category("My Properties"), Description("Image of product")]
        public Image PDImage
        {
            get { return label_Image.Image; }
            set
            {
                label_Image.Image = value;
                ResizeImage();
                Invalidate();
            }
        }

        [Category("My Properties"), Description("Image of product")]
        public int PDPrice
        {
            get { return int.Parse(txtb_Price.Text.Trim()); }
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
        public string PDName
        {
            get { return GetPDName(); }
            set { SetPDName(value); }
        }


        /// <summary>
        /// Get name of the product item
        /// </summary>
        public string GetPDName() { return txtb_Name.Text; }

        /// <exception cref = "InvalidNameException">Thrown when string-name contains invalid character</exception>
        /// <summary>
        /// Set name of the product item
        /// </summary>
        public void SetPDName(string value)
        {
            txtb_Name.Text = value.Trim();
            Invalidate();
        }

        public ProductBox()
        {
            InitializeComponent();

            label_Image.Click += new EventHandler((object sender, EventArgs e) => {
                string path = GetPath();
                if (path != null && File.Exists(path))
                {
                    this.PDImage = Image.FromFile(path);
                }
            });

            txtb_Name.TextChanged += Name_UpdateChanged;
            txtb_Name.LostFocus += Txtb_CheckEmpty;
            txtb_Price.TextChanged += Price_UpdateChanged;
            txtb_Price.LostFocus += Txtb_CheckEmpty;

        }

        private void Txtb_CheckEmpty(object sender, EventArgs e)
        {
            TextBox txtb = (TextBox)sender;
            if (txtb.Text == string.Empty)
            {
                MessageBox.Show("Đây là thông tin bắt buộc");
                txtb.SelectAll();
            }
        }

        private void Name_UpdateChanged(object sender, EventArgs e)
        {
            TextBox txtb = (TextBox)sender;
            if (TSRuleManager.HasInvalidCharacter(txtb.Text))
            {
                MessageBox.Show("Vui lòng không nhập các kí tự đặc biệt");
                txtb.SelectAll();
            }
            if (txtb.Text.Length > 50)
            {
                MessageBox.Show("Vui lòng nhập tên có độ dài ngắn hơn 50 kí tự");
                txtb.SelectAll();
            }
        }

        private void Price_UpdateChanged(object sender, EventArgs e)
        {
            TextBox txtb = (TextBox)sender;
            try
            {
                int.Parse(txtb.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng chỉ nhập số nguyên dương");
                txtb.SelectAll();
            }
            catch (OverflowException)
            {
                MessageBox.Show(string.Format("Vui lòng nhập giá trị từ 0 đến {0}", int.MaxValue));
                txtb.SelectAll();
            }
        }

        private void ResizeImage()
        {
            if (label_Image.Image != null )
            {
                label_Image.Text = string.Empty;
                Bitmap bmp = new Bitmap(label_Image.Image, label_Image.Size);
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
        public InvalidNameException() : base() { }
        public InvalidNameException(string message) : base(message)
        {
            Console.WriteLine(string.Format("Invalid Name Exception {0}Message : {1} {0}Source : {2}", Environment.NewLine, message, this.Source));
        }
    }
}
