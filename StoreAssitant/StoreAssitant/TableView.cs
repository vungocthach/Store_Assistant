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
    public partial class TableView : UserControl
    {
        public TableView()
        {
            InitializeComponent();
            panel_Add.MouseClick += Panel_Add_MouseClick;
        }

        private int numberTable = 1;

        private void Panel_Add_MouseClick(object sender, MouseEventArgs e)
        {
            Table_TableControl.Controls.Remove(panel_Add);
            Table_TableControl.Controls.Add(new TableControl());
            Table_TableControl.Controls.Add(panel_Add);
            numberTable++;
        }

        public void setData(TableViewInfor Infor)
        {
            TableCashier_name.Text = Infor.TableView_nameCashier;
            TableCashier_image.BackgroundImage = Infor.TableView_imageCashier;
            numberTable = Infor.TableView_numberTable;
        }



        [Category("My properties"), Description("Change main name of the view Table")]
        public string nameCashierTable
        {
            get => TableCashier_name.Text;
            set
            {
                TableCashier_name.Text = value;
                Invalidate();
            }
        }
        [Category("My properties"), Description("Change image icon of the view Table")]
        public Image imageCashierTable
        {
            get => TableCashier_image.BackgroundImage;
            set
            {
                TableCashier_image.BackgroundImage = value;
                Invalidate();
            }
        }
    }
    public class TableViewInfor
    {
        public string TableView_nameCashier;
        public Image TableView_imageCashier;
        public int TableView_numberTable;
    }
}
