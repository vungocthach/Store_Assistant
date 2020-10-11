using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreAssitant
{
    public partial class AddProductForm : Form
    {
        public event EventHandler<ProductInfo> ClickSubmitOK;

        public AddProductForm()
        {
            InitializeComponent();
            ClickSubmitOK = new EventHandler<ProductInfo>(OnSubmitOK);
            this.btn_Submit.Click += Btn_Submit_Click;
            this.btn_Cancel.Click += Btn_Cancel_Click;
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (!productBox1.FullCheck())
            {
                MessageBox.Show("Tồn tại thông tin chưa hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ClickSubmitOK(this, GetProductInfo());
            }
        }

        private void OnSubmitOK(object sender, ProductInfo info)
        {
            this.Close();
        }

        public ProductInfo GetProductInfo()
        {
            ProductInfo productInfo = new ProductInfo();
            productInfo.Image = productBox1.PDImage;
            productInfo.Name = productBox1.PDName;
            productInfo.Price = productBox1.PDPrice;
            productInfo.Description = productBox1.PDDescription;

            return productInfo;
        }

        public void SetProductInfo(ProductInfo info)
        {
            productBox1.PDImage = info.Image;
            productBox1.PDName = info.Name;
            productBox1.PDPrice = info.Price;
            productBox1.PDDescription = info.Description;
        }
    }
}
