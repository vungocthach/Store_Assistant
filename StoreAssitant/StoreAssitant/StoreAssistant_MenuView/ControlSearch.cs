using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting.Channels;

namespace StoreAssitant
{
    public partial class ControlSearch : UserControl
    {
        public List<MenuControl> control;
        public List<String> name_Pro = new List<string>();
       
        #region Properties Control
        [Category("My properties"), Description("List product of Menu")]

        public List<MenuControl> Control
        {
            get => control;
            set
            {
                control = value;
                Invalidate();
            }
        }
        [Category("My properties"), Description("Text of control search")]

        public string Text
        {
            get => cbx_Search.Text;
            set
            {
                cbx_Search.Text = value;
                Invalidate();
            }
        }
        #endregion

        #region Event Add_ProductTable
        public event EventHandler Add_ProductTable;

        public void on_Add_ProductTable(object sender, EventArgs e)
        {

        }
        public event EventHandler Click_SearchBar;

        public void on_CLick_SearchBar(object sender, EventArgs e)
        {

        }
        #endregion
        public ControlSearch()
        {
            InitializeComponent();
            Add_ProductTable = new EventHandler(on_Add_ProductTable);
            Click_SearchBar = new EventHandler(on_CLick_SearchBar);

            this.SizeChanged += ControlSearch_SizeChanged;
            cbx_Search.TextChanged += cbx_Search_TextChanged;
           // cbx_Search.KeyPress += cbx_Search_KeyPress;
        }
        private void cbx_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                cbx_Search_TextChanged(sender, new EventArgs());
        }
        private void cbx_Search_TextChanged(object sender, EventArgs e)
        {
            Click_SearchBar(sender, e);
           
        }
        private void ControlSearch_SizeChanged(object sender, EventArgs e)
        {
            cbx_Search.Width = this.Width - buttonSearch.Width - cbx_Search.Margin.Right - buttonSearch.Margin.Left;
        }

    }
}
