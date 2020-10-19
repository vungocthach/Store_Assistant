using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreAssitant.StoreAssistant_CashierView
{
    public partial class CashierView : UserControl
    {
        public CashierView()
        {
            InitializeComponent();
            InitializeEventHandler();

            split_Cashier.Panel1MinSize = tableView1.MinimumSize.Width;
            split_Cashier.Panel2MinSize = menuView1.MinimumSize.Width;
        }

        internal void LoadDataFromDB()
        {
            using (DatabaseController databaseController = new DatabaseController())
            {
                databaseController.ConnectToSQLDatabase();
                tableView1.SetData(databaseController.GetTableCount());
                menuView1.SetData(databaseController.GetProductInfos2());
            }
        }

        void InitializeEventHandler()
        {
            menuView1.ClickAddTableInfo += MenuView1_ClickAddTableInfo1;
        }

        
        private void MenuView1_ClickAddTableInfo1(object sender, ProductInfo e)
        {
            if (tableView1.SelectedTable != -1)
            {
                tableView1.AddProductInfo(e);
            }
        }

    }
}
