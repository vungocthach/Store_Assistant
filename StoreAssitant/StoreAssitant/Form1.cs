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
            InitializeEventHandler();

            kryptonNavigator1.GotFocus += KryptonNavigator1_GotFocus;
            
            using (DatabaseController databaseController = new DatabaseController())
            {
                databaseController.ConnectToSQLDatabase();
                tableView1.SetData(databaseController.GetTableCount());
                menuView1.SetData(databaseController.GetProductInfos2());
            }
        }

        void InitializeEventHandler()
        {
            this.SizeChanged += Form1_SizeChanged;
            menuView1.ClickAddButton += MenuView1_ClickAddButton;
            menuView1.ClickAddTableInfo += MenuView1_ClickAddTableInfo1;
            tableView1.TableRemoved += TableView1_UpdateNumber;
            tableView1.TableAdded += TableView1_UpdateNumber;
        }

        private void TableView1_UpdateNumber(object sender, EventArgs e)
        {
            TableView tableView = (TableView)sender;
            this.Text = tableView.NumberTable.ToString();
            using (DatabaseController databaseController = new DatabaseController())
            {
                databaseController.ConnectToSQLDatabase();
                databaseController.UpdateTableCount(tableView.NumberTable);
                
            }
        }

        private void MenuView1_ClickAddTableInfo1(object sender, ProductInfo e)
        {
            MessageBox.Show("Click On a product" + Environment.NewLine + e.ToString());
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
                //form.ClientSize = new Size(490, 500);
                form.ClickSubmitOK += new EventHandler<ProductInfo>((object sender, ProductInfo info) =>
                {
                    using (DatabaseController databaseController = new DatabaseController())
                    {
                        databaseController.InsertProduct(info);
                        menuView1.AddMenuControl(info);
                        MessageBox.Show("Click On a product" + Environment.NewLine + info.ToString());
                    }
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
