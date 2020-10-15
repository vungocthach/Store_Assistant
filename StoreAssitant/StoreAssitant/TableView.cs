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
        #region CREATE EVENT CLICK
        [Category("My Event"), Description("When button add has been click")]
        public event EventHandler ClickButtonAdd;
        void OnClickButtonAdd(object s, EventArgs e) { }
        [Category("My Event"), Description("When button table has been click")]
        public event EventHandler ClickButtonTable;
        void OnClickButtonTable(object s, EventArgs e) { }
        [Category("My Event"), Description("When the table is added")]
        public event EventHandler TableAdded;
        void OnTableAdded(object s, EventArgs e) { }
        [Category("My Event"), Description("When the table is removed out of flowlayer panel")]
        public event EventHandler TableRemoved;
        void OnTableRemoved(object s, EventArgs e) 
        {
            NumberTable--;
            TableControl table = (TableControl)tableGUI_pnl.Controls[tableGUI_pnl.Controls.Count - 2];
            tableGUI_pnl.Controls.Remove(table);
        }
        [Category("My Event"), Description("When the table selected is changed")]
        public event EventHandler TableSelectedChanged;
        void OnTableSelectedChanged(object s, EventArgs e) { }
        #endregion

        #region SETTING FIELDS
        private int numberTable;
        private int indexSelectedTable;
        private bool isManager;
        Image itemImage;
        #endregion

        public TableView()
        {
            InitializeComponent();

            this.ClickButtonAdd = new EventHandler(OnClickButtonAdd);
            this.ClickButtonTable = new EventHandler(OnClickButtonTable);

            this.TableAdded = new EventHandler(OnTableAdded);
            this.TableRemoved = new EventHandler(OnTableRemoved);

            this.TableSelectedChanged = new EventHandler(OnTableSelectedChanged);

            this.MinimumSize = new Size(tableTitle_lb.Location.X + tableTitle_lb.Size.Width, tableTitle_pnl.Height + tableAdd_btn.MinimumSize.Height);

            this.Layout += TableView_Layout;
            tableTitle_pnl.Layout += TableView_Layout;

            //event button add table click
            tableAdd_btn.Click += TableAdd_btn_Click;
            tableAdd_btn.MouseDown += TableAdd_pnl_MouseDown;
            tableAdd_btn.MouseUp += TableAdd_pnl_MouseUp;
            tableAdd_btn.MouseEnter += TableAdd_pnl_MouseEnter;
            tableAdd_btn.MouseLeave += TableAdd_pnl_MouseLeave;

            itemImage = Properties.Resources.Artboard_1;
        }
        public void SetData(int numberTable)
        {
            this.numberTable = numberTable;
            for (int i = 0; i < numberTable; i++) Create_Table();
            tableGUI_pnl.Controls.Remove(tableAdd_btn);
            tableGUI_pnl.Controls.Add(tableAdd_btn);
        }

        private void TableView_Layout(object sender, LayoutEventArgs e)
        {
            tableGUI_pnl.Height = this.Height - tableTitle_pnl.Location.Y - tableTitle_pnl.Height - 5;
            tableTitle_lb.Location = new Point(tableIcon_pnl.Location.X + tableIcon_pnl.Width + (this.Width - tableIcon_pnl.Location.X - tableIcon_pnl.Width - tableTitle_lb.Width) / 2, tableTitle_lb.Location.Y);
            tableIcon_pnl.Size = new Size(tableIcon_pnl.Size.Height, tableIcon_pnl.Size.Height);
            tableTitle_lb.Location = new Point(tableTitle_lb.Location.X, (tableTitle_pnl.Height - tableTitle_lb.Size.Height) / 2);
        }

        #region TABLE BILL SETTING
        private void Show_TableBill()
        {
            TableBill tbbill = new TableBill(((TableControl)tableGUI_pnl.Controls[indexSelectedTable]).Info, indexSelectedTable);
            tbbill.Size = new Size(tableGUI_pnl.Size.Width, tableGUI_pnl.Size.Height - tableGUI_pnl.AutoScrollMargin.Width);
            tbbill.Location = new Point(tableGUI_pnl.Location.X, tableGUI_pnl.Location.Y);
            tbbill.CloseBill += Tbbill_CloseBill;
            tableGUI_pnl.Hide();
            this.Controls.Add(tbbill);
            tbbill.Show();
        }

        private void Tbbill_CloseBill(object sender, EventArgs e)
        {
            tableGUI_pnl.Show();
        }
        #endregion

        private void Create_Table()
        {
            TableControl newtable = new TableControl() { Size = ItemSize, nameTable = "BÀN " + tableGUI_pnl.Controls.Count, ImageTable = itemImage };
            tableGUI_pnl.Controls.Add(newtable);

            newtable.ClickTableControl += Newtable_ClickTableControl;
            newtable.TableRemoved += Newtable_TableRemoved;
        }

        #region BUTTON TABLE EVENT
        private void Newtable_ClickTableControl(object sender, EventArgs e)
        {
            this.ClickButtonTable(this, e);
            indexSelectedTable = tableGUI_pnl.Controls.IndexOf((TableControl)sender);
            Show_TableBill();
        }

        private void Newtable_TableRemoved(object sender, EventArgs e)
        {
            this.TableRemoved(this, e);
        }
        #endregion

        #region BUTTON ADD TABLE MOUSE EVENT
        private void TableAdd_btn_Click(object sender, EventArgs e)
        {
            Create_Table();
            this.TableAdded(this, e);
            this.NumberTable++;
            tableGUI_pnl.Controls.Remove(tableAdd_btn);
            tableGUI_pnl.Controls.Add(tableAdd_btn);
            this.ClickButtonAdd(this, null);
        }

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
                if (tableIcon_pnl.BackgroundImage != null) tableIcon_pnl.BackgroundImage.Dispose();
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
        [Category("My Properties"), Description("Image of table control")]
        public Image ItemImage
        {
            get
            {
                return itemImage;
            }
            set
            {
                if (this.itemImage != null) this.itemImage.Dispose();
                this.itemImage = value;
                foreach (Control control in tableGUI_pnl.Controls)
                {
                    if (control is TableControl tbControl)
                    {
                        if (tbControl.ImageTable != null) tbControl.ImageTable.Dispose();
                        tbControl.ImageTable = itemImage;
                    }
                }
                Invalidate();
            }
        }
        public int SelectedTable
        {
            get => indexSelectedTable;
            private set
            {
                indexSelectedTable = value;
                this.TableSelectedChanged(this,new EventArgs());
                Invalidate();
            }
        }
        [Category("My Properties"), Description("Check is manager?")]
        public bool IsManager
        {
            get => isManager;
            set
            {
                isManager = value;
                if (isManager == false)
                {
                    tableAdd_btn.Visible = false;
                }
                else
                {
                    tableAdd_btn.Visible = true;
                }
                Invalidate();
            }
        }
        [Category("My Properties"), Description("Number of table")]
        public int NumberTable
        {
            get => numberTable;
            private set
            {
                numberTable = value;
                Invalidate();
            }
        }
        #endregion
    }
}
