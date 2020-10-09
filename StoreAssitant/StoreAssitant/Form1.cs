﻿using ComponentFactory.Krypton.Navigator;
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
        public Form1()
        {
            InitializeComponent();
            kryptonNavigator1.GotFocus += KryptonNavigator1_GotFocus;
            this.SizeChanged += Form1_SizeChanged;

            
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            
        }

        private void OpenAddProductDialog()
        {
            using (AddProductForm form = new AddProductForm())
            {
                form.ClickSubmitOK += new EventHandler<ProductInfo>((object sender, ProductInfo info) =>
                {
                    // Do something with ProductInfo
                });
                form.ShowDialog();
            }
        }

        private void KryptonNavigator1_GotFocus(object sender, EventArgs e)
        {
            KryptonNavigator navigator = (KryptonNavigator)sender;
            navigator.SelectedPage.Focus();
        }

        private void krSplit_Cashier_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
