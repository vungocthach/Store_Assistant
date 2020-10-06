using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace StoreAssitant
{
    public partial class TableView : UserControl
    {
        public TableView()
        {
            InitializeComponent();
            this.SizeChanged += TableView_SizeChanged;
            Table_Cashier.SizeChanged += TableView_SizeChanged;
            panel_Add.MouseClick += Panel_Add_MouseClick;
        }

        private void TableView_SizeChanged(object sender, EventArgs e)
        {
            Table_TableControl.Height = this.Height - Table_Cashier.Location.Y - Table_Cashier.Height;
            TableCashier_name.Location = new Point(TableCashier_image.Location.X + TableCashier_image.Width + (this.Width - TableCashier_image.Location.X - TableCashier_image.Width - TableCashier_name.Width)/ 2, TableCashier_name.Location.Y);
        }

        private int numberTable = 1;

        private void Panel_Add_MouseClick(object sender, MouseEventArgs e)
        {
            Table_TableControl.Controls.Remove(panel_Add);
            Table_TableControl.Controls.Add(new TableControl() { Size = ItemSize }) ;
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
        [Category("My Properties"), Description("Height of title in pixel")]
        public int TitleHeight
        {
            get { return Table_Cashier.Height; }
            set
            {
                if (value > 40)
                {
                    Table_Cashier.Height = value;
                    Invalidate();
                }
                else { Debug.WriteLine("StoreAssistanct.MenuView.TittleHeight : Set height failed Value lower than minimum height"); }
            }
        }
        [Category("My Properties"), Description("Height of title bar in pixel")]
        public Size ItemSize
        {
            get
            {
                if (Table_TableControl.Controls == null || Table_TableControl.Controls.Count < 1) { return System.Drawing.Size.Empty; }
                else
                {
                    return Table_TableControl.Controls[0].Size;
                }
            }
            set
            {
                foreach (Control control in Table_TableControl.Controls)
                {
                    control.Size = value;
                }
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
