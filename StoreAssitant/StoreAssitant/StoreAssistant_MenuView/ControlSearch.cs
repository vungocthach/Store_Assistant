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
       public  List<MenuControl> Control = new List<MenuControl>();

        #region Event Add_ProductTable
        public event EventHandler Add_ProductTable;

        public void on_Add_ProductTable (object sender, EventArgs e)
        {

        }
        public event EventHandler Get_Control_Product;
      
        public void onGet_Control_Product(object sender, EventArgs e)
        {

        }
        #endregion
        public ControlSearch()
        {
            InitializeComponent();


            Add_ProductTable = new EventHandler(on_Add_ProductTable);
            Get_Control_Product = new EventHandler(onGet_Control_Product);

            cbx_Search.SelectedIndexChanged += Cbx_Search_SelectedValueChanged;

            this.SizeChanged += ControlSearch_SizeChanged;
            cbx_Search.Click += Cbx_Search_Click;
            cbx_Search.TextChanged += cbx_Search_TextChanged;
            cbx_Search.KeyPress += cbx_Search_KeyPress;
        }

        private void Cbx_Search_Click(object sender, EventArgs e)
        {
            Get_Control_Product(sender, new EventArgs());
        }

        private void Cbx_Search_SelectedValueChanged(object sender, EventArgs e)
        {
            Add_ProductTable(sender, e);
            MessageBox.Show("Đang phát triển");
        }

        private void cbx_Search_KeyPress(object sender, KeyPressEventArgs e)
         {
             if (e.KeyChar == (char)Keys.Enter)
                 cbx_Search_TextChanged(sender, new EventArgs());
         }
         private void cbx_Search_TextChanged(object sender, EventArgs e)
         {
             cbx_Search.Items.Clear();
             DatabaseController d = new DatabaseController();
             List<string> consultproduct = d.Get_Name_Product(cbx_Search.Text);
             foreach (string t in d.Get_Name_Product(" ")) 
             {
                 if (t.Contains(cbx_Search.Text)) cbx_Search.Items.Add(t);
             }
             cbx_Search.DroppedDown = true;
             cbx_Search.SelectionStart = cbx_Search.Text.Length;
         }
       private void ControlSearch_SizeChanged(object sender, EventArgs e)
        {
            cbx_Search.Width = this.Width - buttonSearch.Width - cbx_Search.Margin.Right - buttonSearch.Margin.Left;
        }

    }
}
