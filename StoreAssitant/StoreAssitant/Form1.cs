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
     
        public Form1()

        {
            InitializeComponent();
            kryptonNavigator1.GotFocus += KryptonNavigator1_GotFocus;
            this.SizeChanged += Form1_SizeChanged;
            menuView1.ClickAddButton += MenuView1_ClickAddButton;
            menuView1.ClickAddTableInfo += MenuView1_ClickAddTableInfo;
            /*
            try
            {
                using (DatabaseController databaseController = new DatabaseController())
                {
                    databaseController.ConnectToSQLDatabase();
                    tableView1.SetData(databaseController.GetTableCount());
                    menuView1.SetData(databaseController.GetProductInfos());
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message, "SQL Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error); }*/
        }

        private void MenuView1_ClickAddTableInfo(object sender, EventArgs e)
        {
            MessageBox.Show("CLICK AddTableInfo");
        }

        private void MenuView1_ClickAddButton(object sender, EventArgs e)
        {
            OpenAddProductDialog();
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
                    menuView1.AddMenuControl(info);
                });
                form.ShowDialog();
            }
        }

        private void KryptonNavigator1_GotFocus(object sender, EventArgs e)
        {
            KryptonNavigator navigator = (KryptonNavigator)sender;
            navigator.SelectedPage.Focus();
        }

      
    }
}
