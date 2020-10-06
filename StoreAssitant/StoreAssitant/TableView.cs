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
        #region SETTING FIELDS
        private int numberTable = 1;
        public event EventHandler btnAddClick;
        public event EventHandler btnTableClick;
        #endregion
        public TableView()
        {
            InitializeComponent();
            this.SizeChanged += TableView_SizeChanged;
            tableCashier_pnl.SizeChanged += TableView_SizeChanged;

            //event button add table click
            tableAdd_pnl.MouseClick += Panel_Add_MouseClick;
            tableAdd_pnl.MouseDown += TableAdd_pnl_MouseDown;
            tableAdd_pnl.MouseUp += TableAdd_pnl_MouseUp;
            tableAdd_pnl.MouseEnter += TableAdd_pnl_MouseEnter;
            tableAdd_pnl.MouseLeave += TableAdd_pnl_MouseLeave;
        }

        #region BUTTON ADD TABLE EVENT
        private void TableAdd_pnl_MouseLeave(object sender, EventArgs e)
        {
            tableAdd_pnl.BackColor = SystemColors.Control;
            tableAdd_pnl.BorderStyle = BorderStyle.None;
        }

        private void TableAdd_pnl_MouseEnter(object sender, EventArgs e)
        {
            tableAdd_pnl.BackColor = SystemColors.ActiveCaption;
            tableAdd_pnl.BorderStyle = BorderStyle.Fixed3D;
        }

        private void TableAdd_pnl_MouseUp(object sender, MouseEventArgs e)
        {
            tableAdd_pnl.BorderStyle = BorderStyle.Fixed3D;
        }

        private void TableAdd_pnl_MouseDown(object sender, MouseEventArgs e)
        {
            tableAdd_pnl.BorderStyle = BorderStyle.None;
        }
        #endregion

        private void Panel_Add_MouseClick(object sender, MouseEventArgs e)
        {
            /*table_cashier_pnl.Controls.Remove(tableAdd_pnl);
            table_cashier_pnl.Controls.Add(new TableControl() { Size = ItemSize }) ;
            table_cashier_pnl.Controls.Add(tableAdd_pnl);
            numberTable++;*/
            on_btnAddClick();
        }

        private void TableView_btnTableClick(object sender, EventArgs e)
        {
            MessageBox.Show("Thể hiện TableInfor");
        }

        private void TableView_SizeChanged(object sender, EventArgs e)
        {
            table_cashier_pnl.Height = this.Height - tableCashier_pnl.Location.Y - tableCashier_pnl.Height;
            tableTitle_lb.Location = new Point(tableCashier_image.Location.X + tableCashier_image.Width + (this.Width - tableCashier_image.Location.X - tableCashier_image.Width - tableTitle_lb.Width)/ 2, tableTitle_lb.Location.Y);
        }

        public void on_btnTableClick()
        {
            if (btnTableClick != null)
            {
                btnTableClick(this, new EventArgs());
            }
        }
        public void on_btnAddClick()
        {
            if (btnAddClick != null)
            {
                btnAddClick(this, new EventArgs());
            }
        }


        public void setData(TableViewInfor Infor)
        {
            tableTitle_lb.Text = Infor.TableView_nameCashier;
            tableCashier_image.BackgroundImage = Infor.TableView_imageCashier;
            numberTable = Infor.TableView_numberTable;
        }


        #region SETTING PROPERTIES
        [Category("My properties"), Description("Change main name of the view Table")]
        public string nameCashierTable
        {
            get => tableTitle_lb.Text;
            set
            {
                tableTitle_lb.Text = value;
                Invalidate();
            }
        }
        [Category("My properties"), Description("Change image icon of the view Table")]
        public Image imageCashierTable
        {
            get => tableCashier_image.BackgroundImage;
            set
            {
                tableCashier_image.BackgroundImage = value;
                Invalidate();
            }
        }
        [Category("My Properties"), Description("Height of title in pixel")]
        public int TitleHeight
        {
            get { return tableCashier_pnl.Height; }
            set
            {
                if (value > 40)
                {
                    tableCashier_pnl.Height = value;
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
                if (table_cashier_pnl.Controls == null || table_cashier_pnl.Controls.Count < 1) { return System.Drawing.Size.Empty; }
                else
                {
                    return table_cashier_pnl.Controls[0].Size;
                }
            }
            set
            {
                foreach (Control control in table_cashier_pnl.Controls)
                {
                    control.Size = value;
                }
                Invalidate();
            }
        }
        #endregion
    }
    public class TableViewInfor
    {
        public string TableView_nameCashier;
        public Image TableView_imageCashier;
        public int TableView_numberTable;
    }
}
