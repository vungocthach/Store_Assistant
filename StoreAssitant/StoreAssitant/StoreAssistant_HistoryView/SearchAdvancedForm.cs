using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreAssitant.StoreAssistant_HistoryView
{
    public partial class SearchAdvancedForm : Form
    {
        public event EventHandler ClickedSubmitOK;
        public SearchAdvancedForm()
        {
            InitializeComponent();
            InitializeEventHandler();
        }

        void InitializeEventHandler()
        {
            this.ClickedSubmitOK = new EventHandler((s, e) => { });

            this.button1.Click += Button1_Click;
            this.numPriceMin.ValueChanged += NumPriceMin_ValueChanged;
            numPriceMax.ValueChanged += NumPriceMax_ValueChanged;
        }

        private void NumPriceMax_ValueChanged(object sender, EventArgs e)
        {
            if (numPriceMax.Value < numPriceMin.Value) { numPriceMin.Value = numPriceMax.Value; }
        }

        private void NumPriceMin_ValueChanged(object sender, EventArgs e)
        {
            if (numPriceMin.Value > numPriceMax.Value) { numPriceMax.Value = numPriceMin.Value; }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ClickedSubmitOK(this, null);
        }

        public int PriceRangeMin
        {
            set { numPriceMin.Minimum = numPriceMax.Minimum = value; }
        }

        public int PriceRangeMax
        {
            set { numPriceMin.Maximum = numPriceMax.Maximum = value; }
        }

        public int DataPriceMin
        {
            get { return (int)numPriceMin.Value; }
        }

        public int DataPriceMax
        {
            get { return (int)numPriceMax.Value; }
        }

        public int DataTableId
        {
            get { return (int)numTable.Value; }
        }
    }
}
