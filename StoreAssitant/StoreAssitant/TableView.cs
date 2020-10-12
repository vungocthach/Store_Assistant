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
        [Category("My Event"), Description("When button add has been click")]
        public event EventHandler ClickButtonAdd;
        void OnClickButtonAdd(object s, EventArgs e) { }
        public event EventHandler ClickButtonTable;
        void OnClickButtonTable(object s, EventArgs e) { }
        private int numberTable;
        #endregion

        public TableView()
        {
            InitializeComponent();

            this.ClickButtonAdd = new EventHandler(OnClickButtonAdd);
            this.ClickButtonTable = new EventHandler(OnClickButtonTable);

            this.MinimumSize = new Size(tableTitle_lb.Location.X + tableTitle_lb.Size.Width, tableTitle_pnl.Height + tableAdd_btn.MinimumSize.Height);

            this.Layout += TableView_Layout;
            tableTitle_pnl.Layout += TableView_Layout;

            tableAdd_btn.Click += TableAdd_btn_Click;

            //event button add table click
            tableAdd_btn.MouseDown += TableAdd_pnl_MouseDown;
            tableAdd_btn.MouseUp += TableAdd_pnl_MouseUp;
            tableAdd_btn.MouseEnter += TableAdd_pnl_MouseEnter;
            tableAdd_btn.MouseLeave += TableAdd_pnl_MouseLeave;

            itemImage = Properties.Resources.Artboard_1;

        }

        private void TableView_Layout(object sender, LayoutEventArgs e)
        {
            tableGUI_pnl.Height = this.Height - tableTitle_pnl.Location.Y - tableTitle_pnl.Height;
            tableTitle_lb.Location = new Point(tableIcon_pnl.Location.X + tableIcon_pnl.Width + (this.Width - tableIcon_pnl.Location.X - tableIcon_pnl.Width - tableTitle_lb.Width) / 2, tableTitle_lb.Location.Y);
            tableIcon_pnl.Size = new Size(tableIcon_pnl.Size.Height, tableIcon_pnl.Size.Height);
            tableTitle_lb.Location = new Point(tableTitle_lb.Location.X, (tableTitle_pnl.Height - tableTitle_lb.Size.Height) / 2);
        }

        private void TableAdd_btn_Click(object sender, EventArgs e)
        {
            Create_Table();
            tableGUI_pnl.Controls.Remove(tableAdd_btn);
            tableGUI_pnl.Controls.Add(tableAdd_btn);
            this.ClickButtonAdd(this, null);
        }

        private void Newtable_ClickTableControl(object sender, EventArgs e)
        {
            this.ClickButtonTable(this, e);
            
            TableBill tbbill = new TableBill(((TableControl)sender).Info);
            MessageBox.Show("ok");
            tbbill.Size = new Size(tableGUI_pnl.Size.Width, tableGUI_pnl.Size.Height);
            tbbill.Location = new Point(tableGUI_pnl.Location.X, tableGUI_pnl.Location.Y);
            this.tableGUI_pnl.Controls.RemoveAt(0);
            this.tableGUI_pnl.Controls.RemoveAt(0);
            //tbbill.Dock = DockStyle.Fill;
            this.tableGUI_pnl.Controls.Add(tbbill);
            tbbill.BringToFront();
        }

        public void SetData(int numberTable)
        {
            this.numberTable = numberTable;
            for (int i = 0; i < numberTable; i++) Create_Table();
            tableGUI_pnl.Controls.Remove(tableAdd_btn);
            tableGUI_pnl.Controls.Add(tableAdd_btn);
        }

        private void Create_Table()
        {
            TableControl newtable = new TableControl() { Size = ItemSize, nameTable = "BÀN " + (tableGUI_pnl.Controls.Count + 1), ImageTable = itemImage };
            tableGUI_pnl.Controls.Add(newtable);
            newtable.ClickTableControl += Newtable_ClickTableControl;
        }


        #region BUTTON ADD TABLE EVENT
        private void TableAdd_pnl_MouseLeave(object sender, EventArgs e)
        {
            tableAdd_btn.BackColor = SystemColors.Control;
            tableAdd_btn.BorderStyle = BorderStyle.None;
        }

        private void TableAdd_pnl_MouseEnter(object sender, EventArgs e)
        {
            tableAdd_btn.BackColor = SystemColors.ActiveCaption;
            tableAdd_btn.BorderStyle = BorderStyle.Fixed3D;
        }

        private void TableAdd_pnl_MouseUp(object sender, MouseEventArgs e)
        {
            tableAdd_btn.BorderStyle = BorderStyle.Fixed3D;
        }

        private void TableAdd_pnl_MouseDown(object sender, MouseEventArgs e)
        {
            tableAdd_btn.BorderStyle = BorderStyle.None;
        }
        #endregion

        #region CREATE EVENT CLICK

        #endregion

        #region SETTING PROPERTIES
        [Category("My properties"), Description("Change main name of the view Table")]
        public string NameCashierTable
        {
            get => tableTitle_lb.Text;
            set
            {
                tableTitle_lb.Text = value;
                Invalidate();
            }
        }
        [Category("My properties"), Description("Change image icon of the view Table")]
        public Image ImageCashierTable
        {
            get => tableIcon_pnl.BackgroundImage;
            set
            {
                tableIcon_pnl.BackgroundImage = value;
                Invalidate();
            }
        }
        [Category("My Properties"), Description("Height of title in pixel")]
        public int TitleHeight
        {
            get
            {
                return tableTitle_pnl.Height;
            }
            set
            {
                if (value > 40)
                {
                    tableTitle_pnl.Height = value;
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
                if (tableGUI_pnl.Controls == null || tableGUI_pnl.Controls.Count == 0) { return System.Drawing.Size.Empty; }
                else
                {
                    return tableGUI_pnl.Controls[tableGUI_pnl.Controls.Count-1].Size;
                }
            }
            set
            {
                foreach (Control control in tableGUI_pnl.Controls)
                {
                    control.Size = value;
                }
                Invalidate();
            }
        }

        Image itemImage;
        [Category("My Properties"), Description("Image of table control")]
        public Image ItemImage
        {
            get
            {
                return itemImage;
            }
            set
            {
                this.itemImage = value;
                foreach (Control control in tableGUI_pnl.Controls)
                {
                    if (control is TableControl tbControl)
                    {
                        tbControl.ImageTable = itemImage;
                    }
                }
                Invalidate();
            }
        }
        #endregion
    }
}
