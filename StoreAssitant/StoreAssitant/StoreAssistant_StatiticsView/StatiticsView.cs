using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StoreAssitant.StoreAssistant_Information;

namespace StoreAssitant.StoreAssistant_StatiticsView
{
    public partial class StatiticsView : UserControl
    {
        Dictionary<int, SaleOutInfo> saleInfos; // Key is Product's id

        public StatiticsView()
        {
            InitializeComponent();
            InitializeEventHandler();

            this.splitContainer1.Panel1MinSize = groupBox1.Width + groupBox1.Margin.Left + groupBox1.Margin.Right;
            this.splitContainer1.Panel2MinSize = 500;
        }


        void InitializeEventHandler()
        {
            //dataGridView1.Location = new Point(dataGridView1.Margin.Left, dataGridView1.Location.Y);
            this.splitContainer1.Panel1.SizeChanged += Panel1_SizeChanged;
            this.splitContainer1.Panel2.SizeChanged += Panel2_SizeChanged;
        }

        private void Panel2_SizeChanged(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            chart1.Height = panel.Height - (numTop.Location.Y + numTop.Height + numTop.Margin.Bottom) - (chart1.Margin.Top + chart1.Margin.Bottom);
            chart1.Width = panel.Width - chart1.Margin.Left - chart1.Margin.Right;
        }

        private void Panel1_SizeChanged(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            pageSelector1.Location = new Point((panel.Width - pageSelector1.Width)/2, panel.Height - pageSelector1.Height - pageSelector1.Margin.Bottom);

            dataGridView1.Height = (panel.Height - (groupBox1.Location.Y + groupBox1.Height + groupBox1.Margin.Bottom) 
                                                - ((panel.Height - pageSelector1.Location.Y) + pageSelector1.Margin.Top) 
                                                - (dataGridView1.Margin.Top - dataGridView1.Margin.Bottom));
            dataGridView1.Width = panel.Width - dataGridView1.Margin.Left - dataGridView1.Margin.Right;
        }

    }
}
