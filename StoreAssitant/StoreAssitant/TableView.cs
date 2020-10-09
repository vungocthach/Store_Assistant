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
        public event EventHandler btnAddClick;
        public event EventHandler btnTableClick;
        List<TableInfo> tableinfo;
        #endregion

        public TableView()
        {
            InitializeComponent();
            this.MinimumSize = new Size(tableTitle_lb.Location.X + tableTitle_lb.Size.Width, tableTitle_pnl.Height + tableAdd_btn.MinimumSize.Height);

            this.SizeChanged += TableView_SizeChanged;
            tableTitle_pnl.SizeChanged += TableView_SizeChanged;
            this.btnTableClick += TableView_btnTableClick;
            tableAdd_btn.Click += TableAdd_btn_Click;

            //event button add table click
            tableAdd_btn.MouseDown += TableAdd_pnl_MouseDown;
            tableAdd_btn.MouseUp += TableAdd_pnl_MouseUp;
            tableAdd_btn.MouseEnter += TableAdd_pnl_MouseEnter;
            tableAdd_btn.MouseLeave += TableAdd_pnl_MouseLeave;

            itemImage = Properties.Resources.Artboard_1;
            SetData(null);
        }

        private void TableAdd_btn_Click(object sender, EventArgs e)
        {
            TableInfo table = new TableInfo();
            table.Id = tableGUI_pnl.Controls.Count;
            table.Name = "BÀN " + table.Id;
            table.ProductList = new List<Products>();
            tableinfo.Add(table);

            TableControl newtable = new TableControl() { Size = ItemSize, nameTable = table.Name, ID = table.Id, ImageTable = itemImage };
            tableGUI_pnl.Controls.Remove(tableAdd_btn);
            tableGUI_pnl.Controls.Add(newtable);
            tableGUI_pnl.Controls.Add(tableAdd_btn);
            on_btnAddClick();
        }

        public void SetData(List<TableInfo> infor)
        {
            if (infor != null) this.tableinfo = infor;
            else this.tableinfo = new List<TableInfo>();
            Load_Tables();
        }


        private void Load_Tables()
        {
            TableControl newtable = new TableControl() { Size = ItemSize};
            tableGUI_pnl.Controls.Remove(tableAdd_btn);
            foreach (TableInfo table in tableinfo)
            {
                newtable.nameTable = table.Name;
                newtable.ID = table.Id;
                tableGUI_pnl.Controls.Add(newtable);
            }
            tableGUI_pnl.Controls.Add(tableAdd_btn);
        }



        private void TableView_btnTableClick(object sender, EventArgs e)
        {
            MessageBox.Show("Thể hiện TableInfor");
        }

        private void TableView_SizeChanged(object sender, EventArgs e)
        {
            tableGUI_pnl.Height = this.Height - tableTitle_pnl.Location.Y - tableTitle_pnl.Height;
            tableTitle_lb.Location = new Point(tableIcon_pnl.Location.X + tableIcon_pnl.Width + (this.Width - tableIcon_pnl.Location.X - tableIcon_pnl.Width - tableTitle_lb.Width)/ 2, tableTitle_lb.Location.Y);
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
