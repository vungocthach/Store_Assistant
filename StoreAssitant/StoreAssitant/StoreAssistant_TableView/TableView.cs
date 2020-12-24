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
using StoreAssitant.StoreAssistant_VoucherView;

namespace StoreAssitant
{
    public partial class TableView : UserControl, StoreAssistant_Helper.ILoadTheme
    {
        #region CREATE EVENT
        [Category("My Event"), Description("When button add has been click")]
        public event EventHandler ClickButtonAdd;
        void OnClickButtonAdd(object s, EventArgs e) { }
        [Category("My Event"), Description("When button table has been click")]
        public event EventHandler ClickButtonTable;
        void OnClickButtonTable(object s, EventArgs e) { }
        [Category("My Event"), Description("When the table is added")]
        public event EventHandler TableAdded;
        void OnTableAdded(object s, EventArgs e) { }
        [Category("My Event"), Description("When the table is removed")]
        public event EventHandler TableRemoved;
        void OnTableRemoved(object s, EventArgs e) 
        {
            NumberTable--;
            TableControl table = (TableControl)tableGUI_pnl.Controls[numberTable];
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
        TableBill tbBill;
        string Lang = "vn";
        string table = "BÀN";
        #endregion


        public TableView()
        {
            InitializeComponent();

            if ( Lang != Language.CultureName)
            {
                Lang = Language.CultureName;
                SetLanguge();
            }
            else VoucherView.ChangeLanguage += VoucherView_ChangeLanguage;

            Init_Event_Customize();

            Init_Event_BtnAddTable();

            Init_TableTakeHome();

            Init_Default_Value();

            this.Layout += TableView_Layout;

        }

        private void VoucherView_ChangeLanguage(object sender, string e)
        {
            Lang = Language.CultureName;
            SetLanguge();
        }

        private void SetLanguge()
        {
                Language.InitLanguage(this);
                tableTitle_lb.Text = Language.Rm.GetString("List table", Language.Culture);
                table = Language.Rm.GetString("Table", Language.Culture).ToUpper();
                tableTakeHome.NameTable = Language.Rm.GetString("Take home", Language.Culture);
        }
        /// <summary>
        /// Init the form value when creating
        /// </summary>
        #region Init Form
        private void Init_Event_Customize()
        {
            this.ClickButtonAdd = new EventHandler(OnClickButtonAdd);
            this.ClickButtonTable = new EventHandler(OnClickButtonTable);

            this.TableAdded = new EventHandler(OnTableAdded);
            this.TableRemoved = new EventHandler(OnTableRemoved);

            this.TableSelectedChanged = new EventHandler(OnTableSelectedChanged);
        }
        private void Init_Event_BtnAddTable()
        {
            tableAdd_btn.Click += TableAdd_btn_Click;
            tableAdd_btn.MouseDown += TableAdd_pnl_MouseDown;
            tableAdd_btn.MouseUp += TableAdd_pnl_MouseUp;
            tableAdd_btn.MouseEnter += TableAdd_pnl_MouseEnter;
            tableAdd_btn.MouseLeave += TableAdd_pnl_MouseLeave;
        }
        private void Init_TableTakeHome()
        {
            tableTakeHome.ClickTableControl += Newtable_ClickTableControl;
        }
        private void Init_Default_Value()
        {
            this.MinimumSize = new Size(tableTitle_lb.Location.X + tableTitle_lb.Size.Width, tableTitle_pnl.Height + tableAdd_btn.MinimumSize.Height);
            itemImage = Properties.Resources.Artboard_1;
            SelectedTable = -1;
            numberTable = 0;
        }
        #endregion


        /// <summary>
        /// SETTING SPECIFIC FUNCTION OF FORM
        /// </summary>
        #region Public function
        public void SetData(int numberTable)
        {
            int number = this.numberTable;
            if (number<=numberTable)
            {
                for (int i = number; i < numberTable; i++) Create_Table();
                Add_TableTakeHome_ButtonAddTable();
            }
            else
            {
                for (int i = 0; i < number - numberTable; i++) TableRemoved(this, new EventArgs());
            }
        }
        private void TableView_Layout(object sender, LayoutEventArgs e)
        {
            tableGUI_pnl.Height = this.Height - tableTitle_pnl.Location.Y - tableTitle_pnl.Height - 5;
            tableTitle_lb.Location = new Point(tableIcon_pnl.Location.X + tableIcon_pnl.Width + (this.Width - tableIcon_pnl.Location.X - tableIcon_pnl.Width - tableTitle_lb.Width) / 2, tableTitle_lb.Location.Y);
            tableIcon_pnl.Size = new Size(tableIcon_pnl.Size.Height, tableIcon_pnl.Size.Height);
            //tableTitle_lb.Location = new Point(tableTitle_lb.Location.X, (tableTitle_pnl.Height - tableTitle_lb.Size.Height) / 2);
            if (tbBill != null)
            {
                tbBill.Size = new Size(this.Size.Width - tableGUI_pnl.AutoScrollMargin.Width, tableGUI_pnl.Size.Height);
            }
        }
        private void Create_Table()
        {
            numberTable++;
            TableControl newtable = new TableControl() { Size = ItemSize, NameTable = table + " " + numberTable, ImageTable = itemImage };
            newtable.IsManager = this.isManager;
            newtable.Info.ID = numberTable;
            tableGUI_pnl.Controls.Add(newtable);
            newtable.ClickTableControl += Newtable_ClickTableControl;
            newtable.TableRemoved += Newtable_TableRemoved;
        }
        private void Add_TableTakeHome_ButtonAddTable()
        {
            tableGUI_pnl.Controls.Remove(tableAdd_btn);
            tableGUI_pnl.Controls.Remove(tableTakeHome);
            tableGUI_pnl.Controls.Add(tableTakeHome);
            tableGUI_pnl.Controls.Add(tableAdd_btn);
        }
        #endregion


        #region INIT TABLE BILL
        private void Show_TableBill()
        {
            tbBill = new TableBill();
            //tbBill.Size = new Size(tableGUI_pnl.Size.Width, tableGUI_pnl.Size.Height - tableGUI_pnl.AutoScrollMargin.Width);
            tbBill.Location = new Point(tableGUI_pnl.Location.X, tableGUI_pnl.Location.Y);
            tbBill.Dock = DockStyle.Bottom;
            tbBill.setData(((TableControl)tableGUI_pnl.Controls[SelectedTable]).Info);

            tbBill.CloseBill += Tbbill_CloseBill;
            tableGUI_pnl.Hide();
            this.Controls.Add(tbBill);
            tbBill.Show();
        }
        private void Tbbill_CloseBill(object sender, EventArgs e)
        {
            tableGUI_pnl.Show();
            TableControl table = (TableControl)tableGUI_pnl.Controls[SelectedTable];
            if (table.Info.ProductInTable.Count != 0) table.Status = status.Using;
            else table.Status = status.Empty;
            SelectedTable = -1;
        }
        public void AddProductInfo(ProductInfo product)
        {
            if (SelectedTable != -1) tbBill.UploadProduct(product);
        }
        #endregion


        #region BUTTON TABLE EVENT
        private void Newtable_ClickTableControl(object sender, EventArgs e)
        {
            this.ClickButtonTable(this, e);
            SelectedTable = tableGUI_pnl.Controls.IndexOf((TableControl)sender);
            if(!isManager) Show_TableBill();
        }
        private void Newtable_TableRemoved(object sender, EventArgs e)
        {
            this.TableRemoved(this, e);
        }
        #endregion


        #region EVENT OF BUTTON ADD TABLE
        private void TableAdd_btn_Click(object sender, EventArgs e)
        {
            this.ClickButtonAdd(this, null);
            Create_Table();
            Add_TableTakeHome_ButtonAddTable();
            this.TableAdded(this, e);
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

        public void LoadTheme()
        {
            tableTitle_pnl.BackColor = StoreAssistant_Helper.AppManager.GetColors("Title_Background");
            tableTitle_lb.ForeColor = StoreAssistant_Helper.AppManager.GetColors("Title_Force");
        }
        #endregion


        #region PROPERTIES
        [Category("My properties"), Description("Change main name of the view Table")]
        public string NameCashierTable
        {
            get => tableTitle_lb.Text;
            set
            {
                tableTitle_lb.Text = value;
                this.MinimumSize = new Size(tableTitle_lb.Location.X + tableTitle_lb.Size.Width, tableTitle_pnl.Height + tableAdd_btn.MinimumSize.Height);
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
            get => tableTitle_pnl.Height;
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
        [Category("My Properties"), Description("The number of table is choosing")]
        public int SelectedTable
        {
            get => indexSelectedTable;
            private set
            {
                if (value != indexSelectedTable)
                {
                    indexSelectedTable = value;
                    this.TableSelectedChanged(this, new EventArgs());
                    //Invalidate();
                }
            }
        }
        [Category("My Properties"), Description("Check is manager?")]
        public bool IsManager
        {
            get => isManager;
            set
            {
                isManager = value;
                tableAdd_btn.Visible = value;
                foreach(Control table in tableGUI_pnl.Controls)
                {
                    if (table is TableControl table1)
                    {
                        table1.IsManager = value;
                    }
                }
                Invalidate();
            }
        }
        [Category("My Properties"), Description("Number of table is display in view")]
        public int NumberTable
        {
            get => numberTable;
            private set
            {
                numberTable = value;
                //Invalidate();
            }
        }
        #endregion
    }
}
