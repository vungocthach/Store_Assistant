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
        DateTime GetDateMin()
        {
                if (ModeChart == 0)
                {
                    return dateMinRange.AddMonths(GetStartIndex() - 1);
                }
                else if (ModeChart == 1)
                {
                    return dateMinRange.AddYears(GetStartIndex() - 1);
                }
                else { throw new ArgumentOutOfRangeException(); }
        }
        DateTime GetDateMax()
        {
            if (ModeChart == 0)
            {
                DateTime dateTime =  GetDateMin().AddMonths(line_per_page);
                if (dateTime > dateMaxRange) return dateMaxRange;
                else { return dateTime; }
            }
            else if (ModeChart == 1)
            {
                DateTime dateTime = GetDateMin().AddYears(line_per_page);
                if (dateTime > dateMaxRange) return dateMaxRange;
                else { return dateTime; }
            }
            else { throw new ArgumentOutOfRangeException(); }
        }

        DateTime dateMinRange { get => timePicker.DateMin; set => timePicker.DateMin = value; }
        DateTime dateMaxRange { get => timePicker.DateMax; set => timePicker.DateMax = value; }

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

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);

            cbbStatiticsMode.SelectedIndex = cbbChartMode.SelectedIndex = 0;

            InitiallizeChart();

            this.splitContainer1.Panel1.SizeChanged += Panel1_SizeChanged;
            this.splitContainer1.Panel2.SizeChanged += Panel2_SizeChanged;

            timePicker = new TimePickerForm();
            timePicker.ClickedSubmitOK += TimePicker_ClickedSubmitOK;

            btnFilter.Click += BtnFilter_Click;

            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            cbbChartMode.SelectedIndexChanged += CbbChartMode_SelectedIndexChanged;
            cbbStatiticsMode.SelectedIndexChanged += CbbStatiticsMode_SelectedIndexChanged;

            pageSelector1.SelectedIndexChanged += PageSelector1_SelectedIndexChanged;

            this.Load += StatiticsView2_Load;
        }

        private void PageSelector1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeStatiticsMode(ModeStatistics);
        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            timePicker.SetPickMode(ModeStatistics);
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
            UpdateTime();
            ChangeStatiticsMode(cbbStatiticsMode.SelectedIndex);
            ChangeChartMode(cbbChartMode.SelectedIndex);
            DataGridView1_SelectionChanged(dataGridView1, null);
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
            (sender as TimePickerForm).Close();
            UpdateTime();
        }

        int line_per_page = 10;
        int GetStartIndex() { return (pageSelector1.SelectedIndex - 1) * line_per_page + 1; }

        void UpdateTime()
        {
            //Console.WriteLine("MinRange = " + dateMinRange.ToString());
            //Console.WriteLine("MaxRange = " + dateMaxRange.ToString());
            TimeSpan timeSpan = dateMaxRange - dateMinRange;
            int max = 0;
            DateTime date = dateMinRange;
            if (ModeStatistics == 0)
            {
                while (date < dateMaxRange)
                {
                    max++;
                    date = date.AddMonths(1);
                }
            }
            else if (ModeStatistics == 1)
            {
                while (date < dateMaxRange)
                {
                    max++;
                    date = date.AddYears(1);
                }
            }
            pageSelector1.MaximumRange = max / line_per_page;
            if (max % line_per_page > 0) { pageSelector1.MaximumRange++; }

            ChangeStatiticsMode(ModeStatistics);
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

            LoadSeriesProducts();
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
            DateTime dateMin = GetDateMin();
            DateTime dateMax = GetDateMax();
            dataGridView1.Rows.Clear();

            GetData(dateMin, dateMax);
            if (listSales == null ) { throw new NullReferenceException(); }

            string txtTimeFormat;
            if (mode == -1)
            {
                txtTimeFormat = "Tuần {0} tháng {1}/{2}"; // {0} : week; {1}:month; {2}:year
            }
            else if (mode == 0)
            {
                txtTimeFormat = "Tháng {0}/{1}"; // {0}:month; {1}:year
                DateTime date = new DateTime(dateMin.Year, dateMin.Month, 1, 0, 0, 0);
                int stt = GetStartIndex();
                int k = 0;
                while (date < dateMax)
                {
                    
                    SaleInfo info = new SaleInfo();
                    info.SetMonth(date.Year, date.Month);

                    SaleInfo[] salesInMonth = new SaleInfo[DateTime.DaysInMonth(date.Year, date.Month)];

                    DateTime nextMonth = date.AddMonths(1);
                    while (date < nextMonth)
                    {
                        
                        SaleInfo saleInDay = new SaleInfo(date.Year, date.Month, date.Day); // Present for sale info in 1-day

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

                    nextMonth = nextMonth.AddMonths(-1);
                    info.Tag = salesInMonth;
                    long totalRevenue = 0;
                    foreach (SaleInfo s in salesInMonth) { totalRevenue += s.GetRevenue(); }
                    DataGridViewRow row = dataGridView1.Rows[dataGridView1.Rows.Add(stt, string.Format(txtTimeFormat, nextMonth.Month, nextMonth.Year), string.Format("{0}VND", totalRevenue.ToString("N0")))];
                    row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    row.Tag = info;
                    stt++;
                }

            }
            else if (mode == 1)
            {
                txtTimeFormat = "Năm {0}";
                DateTime date = new DateTime(dateMin.Year, 1, 1, 0, 0, 0); // First day of the year
                int stt = GetStartIndex();
                int k = 0;  
                while (date < dateMax)
                {
                    DateTime nextYear = date.AddYears(1);

                    SaleInfo info = new SaleInfo() { DateMin = date, DateMax = new DateTime(date.Year, 12, 31) };

                    SaleInfo[] salesInYear = new SaleInfo[12];

                    while (date < nextYear)
                    {
                        SaleInfo saleInMonth = new SaleInfo(date.Year, date.Month);

                        if (k < listSales.Count && listSales[k].DateMin.Month == date.Month && listSales[k].DateMin.Year == date.Year)
                        {
                            foreach (KeyValuePair<string, ProductSaleInfo> p in listSales[k].Products)
                            {
                                saleInMonth.Products.Add(p.Key, p.Value);
                            }

                            k++;
                        }

                        salesInYear[date.Month - 1] = saleInMonth;

                        date = date.AddMonths(1);
                    }

                    nextYear = nextYear.AddYears(-1);
                    long totalRevenue = 0;
                    foreach (SaleInfo s in salesInYear) { totalRevenue += s.GetRevenue(); }
                    int index = dataGridView1.Rows.Add(stt, string.Format(txtTimeFormat, nextYear.Year), string.Format("{0}VND",totalRevenue.ToString("N0")));
                    info.Tag = salesInYear;
                    dataGridView1.Rows[index].Tag = info;
                    dataGridView1.Rows[index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    stt++;
                }

            }

        }

        void GetData(DateTime from, DateTime to)
        {
            // Query data from database base on user's conditions
            // then set data to dataGridView

            Console.WriteLine(string.Format("GetData from ({0}) to ({1})", from.ToString(), to.ToString()));
            if (ModeStatistics == 0)
            {
                from = new DateTime(from.Year, from.Month, 1, 0, 0, 0);
                to = new DateTime(to.Year, to.Month, DateTime.DaysInMonth(to.Year, to.Month), 23, 59, 59);
                using (DatabaseController databaseController = new DatabaseController())
                {
                    listSales = databaseController.GetSaleInfos_ByDay(from, to);
                }
            }
            else if (ModeStatistics == 1)
            {
                from = new DateTime(from.Year, 1, 1, 0, 0, 0);
                to = new DateTime(to.Year, 12, 31, 23, 59, 59);
                using (DatabaseController databaseController = new DatabaseController())
                {
                    listSales = databaseController.GetSaleInfos_ByMonth(from, to);
                }
            }
            else { throw new NullReferenceException(); }
            Console.WriteLine("count = " + listSales.Count);
            // DEBUG zone
            //listSales = CreateTestData();
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

            dateMinRange = new DateTime(2018, 1, 1);
            dateMaxRange = new DateTime(2020, 12, 31);

            Random random = new Random((int)DateTime.Now.Ticks);

            DateTime date = GetDateMin();
            DateTime dateMax = GetDateMax();
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
