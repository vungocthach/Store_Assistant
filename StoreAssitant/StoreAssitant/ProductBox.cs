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
    public partial class ProductBox : UserControl
    {
        ProductInfo info;
        public ProductBox()
        {
            InitializeComponent();
            info = new ProductInfo();

            label_Image.Click += new EventHandler((object sender, EventArgs e) => {

            });
        }

        private string GetPath()
        {
            string rs = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.img;*.bmp;*.jpg";
            openFileDialog.FileOk += new CancelEventHandler((object sender, CancelEventArgs e) =>
            {
                if (openFileDialog.CheckFileExists)
                {
                    rs = openFileDialog.FileName;
                }
            });
            return rs;
        }

        
    }

    public class ProductInfo
    {
        public string Image_Path { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string[] Tags { get; set; }
        public string Description { get; set; }
    }
}
