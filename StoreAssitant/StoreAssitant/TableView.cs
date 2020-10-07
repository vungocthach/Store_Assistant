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

            //event button add table click
            tableAdd_btn.MouseClick += Panel_Add_MouseClick;
            tableAdd_btn.MouseDown += TableAdd_pnl_MouseDown;
            tableAdd_btn.MouseUp += TableAdd_pnl_MouseUp;
            tableAdd_btn.MouseEnter += TableAdd_pnl_MouseEnter;
            tableAdd_btn.MouseLeave += TableAdd_pnl_MouseLeave;
        }

        public void SetData(List<TableInfo> infor)
        {
            this.tableinfo = infor;
            foreach (TableInfo table in infor)
            {
                Add_Table(table);
            }
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

        private void Add_Table(TableInfo table)
        {
            tableGUI_pnl.Controls.Remove(tableAdd_btn);
            tableGUI_pnl.Controls.Add(new TableControl() { Size = ItemSize, nameTable = table.Name , ID = table.Id});
            tableGUI_pnl.Controls.Add(tableAdd_btn);
        }
        private void Panel_Add_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Đang mở rộng tính năng");
            on_btnAddClick();
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
                if (tableGUI_pnl.Controls == null || tableGUI_pnl.Controls.Count < 1) { return System.Drawing.Size.Empty; }
                else
                {
                    return tableGUI_pnl.Controls[0].Size;
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
                if (tableGUI_pnl.Controls == null || tableGUI_pnl.Controls.Count < 2)
                {
                    return null;
                }
                else
                {
                    return (tableGUI_pnl.Controls[0] as TableControl).ImageTable; 
                }
            }
            set
            {
                foreach (Control control in tableGUI_pnl.Controls)
                {
                    if (control != tableAdd_btn)
                    control.BackgroundImage = value;
                }
                Invalidate();
            }
        }
        #endregion
    }
}
