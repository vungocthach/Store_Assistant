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
using System.Windows.Forms.DataVisualization.Charting;

namespace StoreAssitant.StoreAssistant_StatiticsView
{
    public partial class StatiticsView : UserControl
    {
        //Dictionary<int, SaleOutInfo> saleInfos; // Key is Product's id
        int line_per_page = 50;

        public StatiticsView()
        {
            InitializeComponent();
            InitializeEventHandler();

            numTop.Value = 6;
            //this.saleInfos = new Dictionary<int, SaleOutInfo>(line_per_page+1);
            this.splitContainer1.Panel1MinSize = groupBox1.Width + groupBox1.Margin.Left + groupBox1.Margin.Right;
            this.splitContainer1.Panel2MinSize = 500;

            SetupDataGridView();

            InitializeChart();
        }


        void InitializeEventHandler()
        {
            //dataGridView1.Location = new Point(dataGridView1.Margin.Left, dataGridView1.Location.Y);
            this.splitContainer1.Panel1.SizeChanged += Panel1_SizeChanged;
            this.splitContainer1.Panel2.SizeChanged += Panel2_SizeChanged;

            this.dateMin.ValueChanged += DateMin_ValueChanged;
            this.dateMax.ValueChanged += DateMin_ValueChanged;

            this.numTop.ValueChanged += NumTop_ValueChanged;
        }

        private void NumTop_ValueChanged(object sender, EventArgs e)
        {
            DrawToChart();
        }

        void SetupDataGridView()
        {
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
        }

        private void DateMin_ValueChanged(object sender, EventArgs e)
        {
            UpdateTimeSpan();
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

        private void UpdateTimeSpan()
        {
            TimeSpan duration = dateMax.Value - dateMin.Value;

            using (DatabaseController databaseController = new DatabaseController())
            {
                // Query data from database
            }

            {   // Test
                List<SaleOutInfo> testList = new List<SaleOutInfo>();
                Random ran = new Random();
                foreach (KeyValuePair<int, ProductInfo> p in MenuView.ProductsList)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        testList.Add(new SaleOutInfo(duration) { ProductID = p.Value.Id, NumberOfProduct = ran.Next(1, 100) });
                    }
                }
                SetDataToGrid(testList);
            }

            DrawToChart();
        }

        void InitializeChart()
        {
            chart1.Series.Clear();
            Series s = chart1.Series.Add("Revenue");
            //chart1.Series.Add("hello");

            s.XValueMember = "Revenues";
            s.YValueMembers = "ProductName";

            s.XValueType = ChartValueType.Int64;
            s.YValueType = ChartValueType.String;

            s.XAxisType = AxisType.Secondary;
            s.YAxisType = AxisType.Primary;

            s.CustomProperties = "DrawingStyle=Cylinder";

            s.ChartType = SeriesChartType.Bar;

            s.LabelBackColor = Color.White;
            //s.IsValueShownAsLabel = true;

            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart1.Legends[s.Legend].Enabled = false;

        }

        private void DrawToChart()
        {
            int top = (int)numTop.Value;
            top = (dataGridView1.Rows.Count < top) ? dataGridView1.Rows.Count : top;

            string[] titles = new string[top];
            int[] values = new int[top];
            DataGridViewRowCollection rows = dataGridView1.Rows;

            Series s = chart1.Series[0];
            s.Points.Clear();
            for (int i = 0; i < top; i++)
            {
                SaleOutInfo sale = rows[i].Tag as SaleOutInfo;
                string name = rows[i].Cells[0].Value.ToString();
                s.Points.AddXY(name, sale.GetRevenue());
                s.Points[i].Label = NumberToStringWithSuffix(sale.GetRevenue());
            }
        }

        private void SetDataToGrid(List<SaleOutInfo> saleOutInfos)
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < saleOutInfos.Count; i++)
            {
                SaleOutInfo s = saleOutInfos[i];
                int index = dataGridView1.Rows.Add(MenuView.ProductsList[s.ProductID].Name + i.ToString(), s.NumberOfProduct, s.GetRevenue());
                dataGridView1.Rows[index].Tag = s;
                dataGridView1.Rows[index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
               
            }

            numTop.Maximum = dataGridView1.Rows.Count;
        }

        public static String NumberToStringWithSuffix(long count)
        {
            if (count < 1000) { return "" + count; }

            int exp = (int)(Math.Log10(count) / Math.Log10(1000));
            return String.Format("{0} {1}",
                                 string.Format("{0:0.#}", Math.Round(((double)count / Math.Pow(1000, exp)), 1)),
                                 "kMGTPE"[exp - 1]);
        }
    }
}
