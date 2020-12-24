﻿//#define SAVE_TO_DB

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StoreAssitant.StoreAssistant_Helper;

namespace StoreAssitant
{
    public partial class ManagerModifyView : UserControl, ILoadTheme
    {
        string Lang = "vn";
        public ManagerModifyView()
        {
            InitializeComponent();
            InitializeEventHandler();

            split_Cashier.Panel1MinSize = tableView1.MinimumSize.Width;
            split_Cashier.Panel2MinSize = menuView1.MinimumSize.Width;

            if (Lang != AppManager.CurrentLanguage)
            {
                Lang = AppManager.CurrentLanguage;
                SetLanguge();
            }
            Language.ChangeLanguage += Language_ChangeLanguage;


        }

        private void Language_ChangeLanguage(object sender, string e)
        {
            SetLanguge();
        }

        public void SetLanguge()
        {
            Language.InitLanguage(this);
            tableView1.NameCashierTable = Language.Rm.GetString("List table", Language.Culture);
        }

        internal void LoadDataFromDB()
        {
            using (DatabaseController databaseController = new DatabaseController())
            {
                databaseController.ConnectToSQLDatabase();
                tableView1.SetData(databaseController.GetTableCount());
                menuView1.SetData();
            }
        }

        void InitializeEventHandler()
        {
            menuView1.ClickAddButton += MenuView1_ClickAddButton;
            menuView1.CLick_DeleteProduct += menuView_ProductDeleted;
            menuView1.Click_EditProduct += menuView_ProductEditing;
            
            tableView1.TableRemoved += TableView1_UpdateNumber;
            tableView1.TableAdded += TableView1_UpdateNumber;
        }

        void menuView_ProductDeleted(object sender, ProductInfo info)
        {
            /*
            using (DatabaseController databaseController = new DatabaseController())
            {
                databaseController.DeleteProduct(info);
            }
            */
        }

        void menuView_ProductEditing(object sender, ProductInfo info)
        {
            //OpenEditProductDialog(info, (MenuControl)sender);
        }

        private void TableView1_UpdateNumber(object sender, EventArgs e)
        {
            TableView tableView = (TableView)sender;
            using (DatabaseController databaseController = new DatabaseController())
            {
                databaseController.UpdateTableCount(tableView.NumberTable);
                //tableView.NameCashierTable = tableView.NumberTable.ToString();
            }
        }

        private void MenuView1_ClickAddButton(object sender, EventArgs e)
        {
            //OpenAddProductDialog();
        }

        private void OpenAddProductDialog()
        {
            using (AddProductForm form = new AddProductForm())
            {
                form.ClickSubmitOK += new EventHandler<ProductInfo>((object sender, ProductInfo info) =>
                {
                    using (DatabaseController databaseController = new DatabaseController())
                    {
                        databaseController.InsertProduct(info);
                        //MessageBox.Show("Click On a product" + Environment.NewLine + info.ToString());
                    }
                    menuView1.AddMenuControl(info);
                });
                form.ShowDialog();
            }
        }

        private void OpenEditProductDialog(ProductInfo info, MenuControl target)
        {
            using (AddProductForm form = new AddProductForm(info))
            {
                form.ClickSubmitOK += new EventHandler<ProductInfo>((object sender, ProductInfo info2) =>
                {
                    using (DatabaseController databaseController = new DatabaseController())
                    {
                        databaseController.UpdateProduct(info2);
                        
                        //MessageBox.Show("Click On a product" + Environment.NewLine + info.ToString());
                    }
                    target.SetData(info2);
                });
                form.ShowDialog();
            }
        }

        public void LoadTheme()
        {
            menuView1.LoadTheme();
            tableView1.LoadTheme();
        }
    }
}
