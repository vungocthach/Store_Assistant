using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreAssitant.StoreAssistant_VoucherView
{
    public partial class VoucherView : UserControl
    {
        public VoucherView()
        {
            InitializeComponent();
        }
        internal void LoadDataFromDB()
        {
            using (DatabaseController databaseController = new DatabaseController())
            {
                databaseController.ConnectToSQLDatabase();
                //do something
            }
        }

    }
}
