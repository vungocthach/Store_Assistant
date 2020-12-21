using StoreAssitant.StoreAssistant_VoucherView;
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
        String Lang = "vn";
        String Error = "Lỗi";
        String illegal = "Tồn tại thông tin chưa hợp lệ";

        public AddProductForm()
        {
            InitializeComponent();
            ClickSubmitOK = new EventHandler<ProductInfo>(OnSubmitOK);
            this.btn_Submit.Click += Btn_Submit_Click;
            this.btn_Cancel.Click += Btn_Cancel_Click;

            if (Lang != Language.CultureName)
            {
                Lang = Language.CultureName;
                SetLanguage();
            }
            VoucherView.ChangeLanguage += VoucherView_ChangeLanguage;

        }

        int id_temp = -1;
        public AddProductForm(ProductInfo info)
        {
            InitializeComponent();
            ClickSubmitOK = new EventHandler<ProductInfo>(OnSubmitOK);
            this.btn_Submit.Click += Btn_Submit_Click;
            this.btn_Cancel.Click += Btn_Cancel_Click;

            if (Lang != Language.CultureName)
            {
                Lang = Language.CultureName;
                SetLanguage();
            }
            VoucherView.ChangeLanguage += VoucherView_ChangeLanguage;

            SetData(info);
            this.Text = "Thay đổi thông tin món ăn";
            productBox1.IsReadOnlyPDName = true;
          
        }

        private void VoucherView_ChangeLanguage(object sender, string e)
        {
            SetLanguage();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (!productBox1.FullCheck())
            {
                MessageBox.Show(illegal, Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ProductInfo productInfo = new ProductInfo()
            {
                Id = id_temp,
                Image = productBox1.PDImage,
                Name = productBox1.PDName,
                Price = productBox1.PDPrice,
                Description = productBox1.PDDescription,
            };
            return productInfo;
        }

        public void SetData(ProductInfo info)
        {
            id_temp = info.Id;
            productBox1.PDImage = info.Image;
            productBox1.PDName = info.Name;
            productBox1.PDPrice = info.Price;
            productBox1.PDDescription = info.Description;
        }
        public void SetLanguage()
        {
            Language.InitLanguage(this);
            btn_Cancel.Text = Language.Rm.GetString("Cancel", Language.Culture);
            btn_Submit.Text = Language.Rm.GetString("Confirm", Language.Culture);
            Error = Language.Rm.GetString("Error", Language.Culture);
            illegal = Language.Rm.GetString("illegal", Language.Culture);
            this.Text = Language.Rm.GetString("AddPro", Language.Culture);
        }
    }
}
