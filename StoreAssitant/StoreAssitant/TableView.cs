﻿using System;
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
            this.MinimumSize = new Size(tableTitle_lb.Location.X + tableTitle_lb.Size.Width, tableTitle_pnl.Height + tableControl1.MinimumSize.Height);

            this.SizeChanged += TableView_SizeChanged;
            tableTitle_pnl.SizeChanged += TableView_SizeChanged;

            //event button add table click
            tableAdd_pnl.MouseClick += Panel_Add_MouseClick;
            tableAdd_pnl.MouseDown += TableAdd_pnl_MouseDown;
            tableAdd_pnl.MouseUp += TableAdd_pnl_MouseUp;
            tableAdd_pnl.MouseEnter += TableAdd_pnl_MouseEnter;
            tableAdd_pnl.MouseLeave += TableAdd_pnl_MouseLeave;
        }
        public void setData(TableViewInfor Infor)
        {
            tableTitle_lb.Text = Infor.TableView_nameCashier;
            tableIcon_pnl.BackgroundImage = Infor.TableView_imageCashier;
            //tableinfo = Infor.tableinfo;
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
            tableGUI_pnl.Controls.Remove(tableAdd_pnl);
            tableGUI_pnl.Controls.Add(new TableControl() { Size = ItemSize, nameTable = "BÀN " + (tableGUI_pnl.Controls.Count+1) });
            tableGUI_pnl.Controls.Add(tableAdd_pnl);
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
            get { return tableTitle_pnl.Height; }
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
        #endregion
    }
    public class TableViewInfor
    {
        //public List<TableInfo> tableinfo;
        public string TableView_nameCashier;
        public Image TableView_imageCashier;
    }
}
