using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using StoreAssitant.StoreAssistant_Information;

namespace StoreAssitant.StoreAssistant_StatiticsView
{
    public partial class StatiticsView2 : UserControl
    {
        TimePickerForm timePicker;
        DateTime dateMin { get => timePicker.DateMin; set => timePicker.DateMin = value; }
        DateTime dateMax { get => timePicker.DateMax; set => timePicker.DateMax = value; }

        public int ModeStatistics
        {
            get => cbbStatiticsMode.SelectedIndex;
            set
            {
                cbbStatiticsMode.SelectedIndex = value;
            }
        }

        public int ModeChart
        {
            get => cbbChartMode.SelectedIndex;
            set
            {
                cbbChartMode.SelectedIndex = value;
            }
        }

        public StatiticsView2()
        {
            InitializeComponent();

            InitiallizeChart();

            this.splitContainer1.Panel1.SizeChanged += Panel1_SizeChanged;
            this.splitContainer1.Panel2.SizeChanged += Panel2_SizeChanged;

            timePicker = new TimePickerForm();
            timePicker.ClickedSubmitOK += TimePicker_ClickedSubmitOK;

            btnFilter.Click += BtnFilter_Click;

            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            cbbChartMode.SelectedIndexChanged += CbbChartMode_SelectedIndexChanged;
            cbbStatiticsMode.SelectedIndexChanged += CbbStatiticsMode_SelectedIndexChanged;

            this.Load += StatiticsView2_Load;
        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            timePicker.ShowDialog();
        }

        private void Panel2_SizeChanged(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            chart1.Height = panel.Height - (cbbChartMode.Location.Y + cbbChartMode.Height + cbbChartMode.Margin.Bottom) - (chart1.Margin.Top + chart1.Margin.Bottom);
            chart1.Width = panel.Width - chart1.Margin.Left - chart1.Margin.Right;
        }

        private void Panel1_SizeChanged(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            pageSelector1.Location = new Point((panel.Width - pageSelector1.Width) / 2, panel.Height - pageSelector1.Height - pageSelector1.Margin.Bottom);

            dataGridView1.Height = (panel.Height - (groupBox1.Location.Y + groupBox1.Height + groupBox1.Margin.Bottom)
                                                - ((panel.Height - pageSelector1.Location.Y) + pageSelector1.Margin.Top)
                                                - (dataGridView1.Margin.Top + dataGridView1.Margin.Bottom));
            dataGridView1.Width = panel.Width - dataGridView1.Margin.Left - dataGridView1.Margin.Right;
        }

        private void StatiticsView2_Load(object sender, EventArgs e)
        {
            GetData();

            ModeStatistics = 0;
            ModeChart = 0;
        }

        private void CbbStatiticsMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeStatiticsMode(ModeStatistics);
            DataGridView1_SelectionChanged(dataGridView1, null);
        }

        private void CbbChartMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeChartMode(ModeChart);
            DataGridView1_SelectionChanged(dataGridView1, null);
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                if (row == null || row.Tag == null) { return; }
                SaleInfo tag = row.Tag as SaleInfo;
                SaleInfo[] data = tag.Tag as SaleInfo[];
                if (data == null) { throw new NullReferenceException(); }
                if (ModeChart == 0)
                {
                    if (ModeStatistics == 0) { LoadSummaryChart_ByDay(data); }
                    if (ModeStatistics == 1) { LoadSummaryChart_ByMonth(data); }
                }
                else if (ModeChart == 1)
                {
                    if (ModeStatistics == 0) { LoadDetailChart_ByDay(data); }
                    if (ModeStatistics == 1) { LoadDetailChart_ByMonth(data); }
                }
                chart1.Invalidate();
            }
        }

        private void TimePicker_ClickedSubmitOK(object sender, EventArgs e)
        {
            UpdateMaxPage();
        }

        int line_per_page = 10;

        void UpdateMaxPage()
        {
            TimeSpan timeSpan = dateMax - dateMax;
            int max = 0;
            DateTime date = dateMin;
            if (ModeStatistics == 0)
            {
                while (date < dateMax)
                {
                    max++;
                    date = date.AddMonths(1);
                }
            }
            else if (ModeStatistics == 1)
            {
                while (date < dateMax)
                {
                    max++;
                    date = date.AddYears(1);
                }
            }
            pageSelector1.MaximumRange = max / line_per_page + 1;
        }

        private readonly string REVENUE_SERIES_NAME = "Revenue";
        Series seriesRevenue;
        Series[] seriesProducts;
        void InitiallizeChart()
        {
            seriesProducts = new Series[MenuView.ProductsList.Count];
            chart1.Series.Clear();

            chart1.Legends[0].Enabled = false;
            seriesRevenue = chart1.Series.Add(REVENUE_SERIES_NAME);
            seriesRevenue.XValueMember = "Time";
            seriesRevenue.YValueMembers = "Revenue";
            seriesRevenue.ChartType = SeriesChartType.Column;
            seriesRevenue["DrawingStyle"] = "Cylinder";// DrawingStyle=Cylinder

            chart1.ChartAreas[0].AxisY.Title = chart1.ChartAreas[1].AxisY.Title = "DOANH THU";
        }

        void LoadSeriesProducts()
        {
            List<ProductInfo> productInfos = new List<ProductInfo>(MenuView.ProductsList.Count);
            foreach (KeyValuePair<int, ProductInfo> p in MenuView.ProductsList)
            {
                productInfos.Add(p.Value);
            }

            LoadSeriesProducts(productInfos);
        }

        void LoadSeriesProducts(List<ProductInfo> products)
        {
            seriesProducts = new Series[products.Count];

            for (int i = chart1.Series.Count - 1; i > 0; i--) { chart1.Series.RemoveAt(i); }
            
            for(int i = 0; i<products.Count; i++)
            {
                Series series = chart1.Series.Add(products[i].Name.ToString());
                series.XValueMember = "Time";
                series.YValueMembers = "Name";
                series.ChartType = SeriesChartType.StackedColumn;
                series.Legend = chart1.Legends[1].Name;
                series.ChartArea = chart1.ChartAreas[1].Name;
                series["DrawingStyle"] = "Cylinder";

                seriesProducts[i] = series;
            }
        }

        void SetChartData(SaleInfo[] saleInfos)
        {
            seriesRevenue.Points.Clear();

            foreach (SaleInfo s in saleInfos)
            {
                seriesRevenue.Points.Add(s.GetRevenue());
                foreach (Series series in seriesProducts)
                {
                    series.Points.Clear();
                    series.Points.Add(s.Products[series.Name].GetRevenue());
                }
            }
        }

        void ChangeChartMode(int mode)
        {
            chart1.SuspendLayout();
            if (mode == 0)
            {
                // Mode summary
                chart1.Legends[1].Enabled = false;

                chart1.ChartAreas[0].Visible = true;
                chart1.ChartAreas[1].Visible = false;
            }
            else if (mode == 1)
            {
                // Mode detail
                chart1.Legends[1].Enabled = true;

                chart1.ChartAreas[0].Visible = false;
                chart1.ChartAreas[1].Visible = true;
            }
            chart1.ResumeLayout();
        }

        void LoadDetailChart_ByDay(SaleInfo[] saleInfos)
        {
            chart1.ChartAreas[1].AxisX.Title = "NGÀY";
            string x_axis_format = "{0}/{1}";

            foreach (Series s in seriesProducts)
            {
                s.Points.Clear();
            }

            for (int i  = 0; i< saleInfos.Length; i++)
            {
                SaleInfo s = saleInfos[i];
                foreach (Series series in seriesProducts)
                {
                    if (s.Products.ContainsKey(series.Name))
                    {
                        series.Points.AddXY(string.Format(x_axis_format, s.DateMin.Day, s.DateMin.Month), s.Products[series.Name].GetRevenue());
                    }
                    else { series.Points.AddXY(string.Format(x_axis_format, s.DateMin.Day, s.DateMin.Month), 0); }
                }
            }
        }

        void LoadDetailChart_ByMonth(SaleInfo[] saleInfos)
        {
            chart1.ChartAreas[1].AxisX.Title = "THÁNG";

            string x_axis_format = "{0}/{1}";

            foreach (Series s in seriesProducts)
            {
                s.Points.Clear();
            }

            for (int i = 0; i < saleInfos.Length; i++)
            {
                SaleInfo s = saleInfos[i];
                foreach (Series series in seriesProducts)
                {
                    if (s.Products.ContainsKey(series.Name))
                    {
                        series.Points.AddXY(string.Format(x_axis_format, s.DateMin.Month, s.DateMin.Year), s.Products[series.Name].GetRevenue());
                    }
                    else { series.Points.AddXY(string.Format(x_axis_format, s.DateMin.Month, s.DateMin.Year), 0); }
                }
            }
        }

        void LoadSummaryChart_ByDay(SaleInfo[] saleInfos)
        {
            string x_axis_format = "{0}/{1}";
            seriesRevenue.Points.Clear();

            chart1.ChartAreas[0].AxisX.Title = "NGÀY";

            for (int i = 0; i < saleInfos.Length; i++)
            {
                SaleInfo s = saleInfos[i];

                seriesRevenue.Points.AddXY(string.Format(x_axis_format, s.DateMin.Day, s.DateMin.Month), s.GetRevenue());
            }
        }

        void LoadSummaryChart_ByMonth(SaleInfo[] saleInfos)
        {
            string x_axis_format = "{0}/{1}";
            seriesRevenue.Points.Clear();

            chart1.ChartAreas[0].AxisX.Title = "THÁNG";

            for (int i = 0; i < saleInfos.Length; i++)
            {
                SaleInfo s = saleInfos[i];

                seriesRevenue.Points.AddXY(string.Format(x_axis_format, s.DateMin.Month, s.DateMin.Year), s.GetRevenue());
            }
        }

        List<SaleInfo> listSales; // listSale must be sorted by DateTime

        void ChangeStatiticsMode(int mode)
        {
            dataGridView1.Rows.Clear();
            if (listSales == null || listSales.Count < 1) { return; }

            string txtTimeFormat;
            if (mode == -1)
            {
                txtTimeFormat = "Tuần {0} tháng {1}/{2}"; // {0} : week; {1}:month; {2}:year
            }
            else if (mode == 0)
            {

                txtTimeFormat = "Tháng {0}/{1}"; // {0}:month; {1}:year
                DateTime date = new DateTime(dateMin.Year, dateMin.Month, dateMin.Day, 0, 0, 0);
                int stt = 0;
                int k = 0;
                while (date < dateMax)
                {
                    SaleInfo info = new SaleInfo();
                    info.SetMonth(date.Year, date.Month);

                    SaleInfo[] salesInMonth = new SaleInfo[DateTime.DaysInMonth(date.Year, date.Month)];

                    DateTime nextMonth = date.AddMonths(1);
                    while (date < nextMonth)
                    {
                        
                        SaleInfo saleInDay = new SaleInfo(); // Present for sale info in 1-day
                        saleInDay.DateMin = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
                        saleInDay.DateMax = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
                        /*
                        while (listSales[k].DateMin.Year == date.Year && listSales[k].DateMin.Month == date.Month && listSales[k].Key.Day == date.Day)
                        {
                            if (k >= listSales.Count) { break; }
                            
                            if (saleInDay.Products.ContainsKey(listSales[k].Value.ProductName))
                            {
                                // Add number if product sale info already exist
                                saleInDay.Products[listSales[k].Value.ProductName].Number += listSales[k].Value.Number;
                                break;
                            }
                            else
                            {
                                // Not existed -> Add new product sale info
                                saleInDay.Products.Add(listSales[k].Value.ProductName, listSales[k].Value);
                            }
                            
                            k++;
                        }
                        */

                        if (k < listSales.Count && listSales[k].DateMin.Year == date.Year && listSales[k].DateMin.Month == date.Month && listSales[k].DateMin.Day == date.Day)
                        {
                            
                            foreach (KeyValuePair<string, ProductSaleInfo> p in listSales[k].Products)
                            {
                                saleInDay.Products.Add(p.Key, p.Value.Clone());
                            }
                            
                            //saleInDay.Products = listSales[k].Products;
                            k++;
                        }

                        salesInMonth[date.Day - 1] = saleInDay;

                        date = date.AddDays(1);
                    }


                    info.Tag = salesInMonth;
                    long totalRevenue = 0;
                    foreach (SaleInfo s in salesInMonth) { totalRevenue += s.GetRevenue(); }
                    DataGridViewRow row = dataGridView1.Rows[dataGridView1.Rows.Add(stt, string.Format(txtTimeFormat, date.Month, date.Year), totalRevenue)];
                    row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    row.Tag = info;
                    stt++;
                }

            }
            else if (mode == 1)
            {
                txtTimeFormat = "Năm {0}";
                DateTime date = new DateTime(dateMin.Year, 1, 1); // First day of the year
                int stt = 0;
                int k = 0;  
                while (date < dateMax)
                {
                    DateTime nextYear = date.AddYears(1);

                    SaleInfo info = new SaleInfo() { DateMin = date, DateMax = new DateTime(date.Year, 12, 31) };

                    SaleInfo[] salesInYear = new SaleInfo[12];

                    while (date < nextYear)
                    {
                        SaleInfo saleInMonth = new SaleInfo(date.Year, date.Month);

                        while (k < listSales.Count && listSales[k].DateMin.Month == date.Month && listSales[k].DateMin.Year == date.Year)
                        {
                            foreach (KeyValuePair<string, ProductSaleInfo> p in listSales[k].Products)
                            {
                                if (saleInMonth.Products.ContainsKey(p.Key))
                                {
                                    // Add number if product sale info already exist
                                    saleInMonth.Products[p.Key].Number += p.Value.Number;
                                }
                                else
                                {
                                    // Not existed -> Add new product sale info
                                    saleInMonth.Products.Add(p.Key, p.Value.Clone());
                                }
                            }

                            k++;
                        }

                        salesInYear[date.Month - 1] = saleInMonth;

                        date = date.AddMonths(1);
                    }

                    long totalRevenue = 0;
                    foreach (SaleInfo s in salesInYear) { totalRevenue += s.GetRevenue(); }
                    int index = dataGridView1.Rows.Add(stt, string.Format(txtTimeFormat, nextYear.Year - 1), totalRevenue);
                    info.Tag = salesInYear;
                    dataGridView1.Rows[index].Tag = info;
                    dataGridView1.Rows[index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    stt++;
                }

            }

            UpdateMaxPage();
        }

        void GetData()
        {
            // Query data from database base on user's conditions
            // then set data to dataGridView

            // DEBUG zone
            listSales = CreateTestData();
        }

        List<SaleInfo> CreateTestData()
        {
            List<SaleInfo> rs = new List<SaleInfo>();
            int range_prod = 10;

            List<ProductInfo> products = new List<ProductInfo>(range_prod);
            for (int i = 0; i < range_prod; i++)
            {
                products.Add(new ProductInfo() { Name = "test_" + i.ToString(), Price = 10000 }) ;
            }

            LoadSeriesProducts(products);

            dateMin = new DateTime(2018, 1, 1);
            dateMax = new DateTime(2020, 12, 31);

            Random random = new Random((int)DateTime.Now.Ticks);

            DateTime date = dateMin;
            while (date < dateMax)
            {
                SaleInfo saleInDay = new SaleInfo(date.Year, date.Month, date.Day);

                for (int i = 0; i < products.Count; i++)
                {
                    ProductSaleInfo productSaleInfo = new ProductSaleInfo()
                    {
                        ProductName = products[i].Name,
                        Number = random.Next(0, 100),
                        Price = products[i].Price
                    };
                    saleInDay.Products.Add(productSaleInfo.ProductName, productSaleInfo);
                }

                rs.Add(saleInDay);

                date = date.AddDays(1);
            }
            return rs;
        }
    }
}
