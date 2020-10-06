using ComponentFactory.Krypton.Navigator;
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
    public partial class Form1 : Form
    {
        ProductInfo productInfo;
        public Form1()
        {
            InitializeComponent();
            kryptonNavigator1.GotFocus += KryptonNavigator1_GotFocus;
            btn_Test.Click += Btn_Test_Click;
        }

        private void Btn_Test_Click(object sender, EventArgs e)
        {
            OpenAddProductDialog();
        }

        private void OpenAddProductDialog()
        {
            AddProductForm form = new AddProductForm();
            form.ClickSubmitOK += new EventHandler<ProductInfo>((object sender, ProductInfo info) =>
            {
                this.productInfo = info;
                btn_Test.Text = productInfo.ToString();
            });
            form.ShowDialog();
        }

        private void KryptonNavigator1_GotFocus(object sender, EventArgs e)
        {
            KryptonNavigator navigator = (KryptonNavigator)sender;
            navigator.SelectedPage.Focus();
        }
    }
}
