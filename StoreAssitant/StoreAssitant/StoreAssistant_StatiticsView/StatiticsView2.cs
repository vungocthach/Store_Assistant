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
using StoreAssitant.StoreAssistant_Helper;
using StoreAssitant.StoreAssistant_Information;
using StoreAssitant.StoreAssistant_VoucherView;
using StoreAssitant.StoreAssistant_Helper;

namespace StoreAssitant.StoreAssistant_StatiticsView
{
    public partial class StatiticsView2 : UserControl, ILoadTheme
    {
        TimePickerForm timePicker;
        String Lang = "vn";
        string revenue_ = "DOANH THU";
        string day = "Ngày";
        string month = "Tháng";
        string day_ = "Ngày";
        string month_ = "Tháng";
        string year_ = "Năm";
        string week = "Tuần";

        DateTime GetDateMin()
        {
                if (ModeStatistics == 0)
                {
                    return dateMinRange.AddMonths(GetStartIndex() - 1);
                }
                else if (ModeStatistics == 1)
                {
                    return dateMinRange.AddYears(GetStartIndex() - 1);
                }
                else { throw new ArgumentOutOfRangeException(); }
        }
        DateTime GetDateMax()
        {
            if (ModeStatistics == 0)
            {
                DateTime dateTime =  GetDateMin().AddMonths(line_per_page);
                if (dateTime > dateMaxRange) return dateMaxRange;
                else { return dateTime; }
            }
            else if (ModeStatistics == 1)
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

            if (Lang != AppManager.CurrentLanguage)
            {
                SetLanguage();
            }
            Language.ChangeLanguage += VoucherView_ChangeLanguage;

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

        private void VoucherView_ChangeLanguage(object sender, string e)
        {
         
            SetLanguage();
        }

        private void SetLanguage()
        {
            Lang = AppManager.CurrentLanguage;
            Language.InitLanguage(this);
            lbConfig.Text = Language.Rm.GetString("Time", Language.Culture);
            lbChart.Text = Language.Rm.GetString("Chart", Language.Culture);
            label4.Text = Language.Rm.GetString("Unit:", Language.Culture);
            btnFilter.Text = Language.Rm.GetString("Filter", Language.Culture);
            dataGridView1.Columns[0].HeaderText = Language.Rm.GetString("Number", Language.Culture);
            dataGridView1.Columns[1].HeaderText = Language.Rm.GetString("Time", Language.Culture);
            dataGridView1.Columns[2].HeaderText = Language.Rm.GetString("Revenue", Language.Culture);
            label1.Text = Language.Rm.GetString("Stype:", Language.Culture);
            cbbChartMode.Items[1] = Language.Rm.GetString("Detail", Language.Culture);
            cbbChartMode.Items[0] = Language.Rm.GetString("General", Language.Culture);
            cbbStatiticsMode.Items[0] = year_ = Language.Rm.GetString("Year", Language.Culture);
            cbbStatiticsMode.Items[1] = month_ = month = Language.Rm.GetString("Month", Language.Culture);
            chart1.Legends[1].Title = Language.Rm.GetString("Name", Language.Culture);
            day_ = day = chart1.ChartAreas[0].AxisX.Title = Language.Rm.GetString("Day", Language.Culture).ToUpper();
            chart1.ChartAreas[1].AxisX.Title = Language.Rm.GetString("Month", Language.Culture).ToUpper();
            revenue_= chart1.ChartAreas[0].AxisY.Title = chart1.ChartAreas[1].AxisY.Title = Language.Rm.GetString("revenue_", Language.Culture);
            week = Language.Rm.GetString("week", Language.Culture);
        }

        private void PageSelector1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGrid();
        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            timePicker.SetPickMode(ModeStatistics);
            timePicker.ShowDialog();
        }

        private void Panel2_SizeChanged(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            panel2.Size = new Size(panel.Width - panel2.Location.X - panel2.Margin.Right, panel.Height - panel2.Location.Y - panel2.Margin.Bottom);
            chart1.Height = panel2.Height - chart1.Location.Y - (chart1.Margin.Bottom);
            chart1.Width = panel2.Width - chart1.Location.X - chart1.Margin.Right;
        }

        private void Panel1_SizeChanged(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            panel1.Width = panel.Width - panel1.Location.X - panel1.Margin.Right;
            pageSelector1.Location = new Point((panel.Width - pageSelector1.Width) / 2, panel.Height - pageSelector1.Height - pageSelector1.Margin.Bottom);

            dataGridView1.Height = (panel.Height - dataGridView1.Location.Y
                                                - (dataGridView1.Margin.Bottom + pageSelector1.Margin.Top)
                                                - ((panel.Height - pageSelector1.Location.Y)));
            dataGridView1.Width = panel.Width - dataGridView1.Margin.Left - dataGridView1.Margin.Right;
        }

        private void StatiticsView2_Load(object sender, EventArgs e)
        {
            UpdateTime(false);
            ChangeStatiticsMode(cbbStatiticsMode.SelectedIndex);
            ChangeChartMode(cbbChartMode.SelectedIndex);
            DataGridView1_SelectionChanged(dataGridView1, null);
        }

        private void CbbStatiticsMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeStatiticsMode(cbbStatiticsMode.SelectedIndex);
            DataGridView1_SelectionChanged(dataGridView1, null);
        }

        private void CbbChartMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeChartMode(cbbChartMode.SelectedIndex);
            DataGridView1_SelectionChanged(dataGridView1, null);
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                if (row == null || row.Tag == null) { return; }
                KeyValuePair<DateTime, long> tag = (KeyValuePair<DateTime, long>)row.Tag;

                

                if (ModeChart == 0)
                {
                    if (ModeStatistics == 0) { SaleInfo[] data = GetSaleInfo_InMonth(tag.Key.Year, tag.Key.Month); LoadSummaryChart_ByDay(data); }
                    if (ModeStatistics == 1) { SaleInfo[] data = GetSaleInfo_InYear(tag.Key.Year); LoadSummaryChart_ByMonth(data); }
                }
                else if (ModeChart == 1)
                {
                    if (ModeStatistics == 0) { SaleInfo[] data = GetSaleInfo_InMonth(tag.Key.Year, tag.Key.Month); LoadDetailChart_ByDay(data); }
                    if (ModeStatistics == 1) { SaleInfo[] data = GetSaleInfo_InYear(tag.Key.Year); LoadDetailChart_ByMonth(data); }
                }
                chart1.Invalidate();
            }
        }

        SaleInfo[] GetSaleInfo_InMonth(int year, int month)
        {
            int maxDay = DateTime.DaysInMonth(year, month);
            DateTime from = new DateTime(year, month, 1, 0, 0, 0);
            DateTime to = new DateTime(year, month, maxDay, 23, 59, 59);

            SaleInfo[] rs = new SaleInfo[maxDay];
            List<SaleInfo> data = null;
            using (DatabaseController databaseController = new DatabaseController())
            {
                data = databaseController.GetSaleInfos_ByDay(from, to);
            }

            int k = 0;
            for(int i = 1; i<=maxDay; i++)
            {
                rs[i-1] = new SaleInfo(year, month, i);
                if (k < data.Count && data[k].DateMin.Year == year && data[k].DateMin.Month == month && data[k].DateMin.Day == i)
                {
                    rs[i-1].Products = data[k].Products;
                    k++;
                }
            }

            return rs;
        }

        SaleInfo[] GetSaleInfo_InYear(int year)
        {
            DateTime from = new DateTime(year, 1, 1, 0, 0, 0);
            DateTime to = new DateTime(year, 12, 31, 23, 59, 59);

            SaleInfo[] rs = new SaleInfo[12];
            List<SaleInfo> data = null;
            using (DatabaseController databaseController = new DatabaseController())
            {
                data = databaseController.GetSaleInfos_ByMonth(from, to);
            }

            int k = 0;
            for (int i = 1; i <= 12; i++)
            {
                rs[i-1] = new SaleInfo(year, i);
                if (k < data.Count && data[k].DateMin.Year == year && data[k].DateMin.Month == i)
                {
                    rs[i-1].Products = data[k].Products;
                    k++;
                }
            }

            return rs;
        }

        private void TimePicker_ClickedSubmitOK(object sender, EventArgs e)
        {
            (sender as TimePickerForm).Close();
            UpdateTime();
        }

        int line_per_page = 20;
        int GetStartIndex() { return (pageSelector1.SelectedIndex - 1) * line_per_page + 1; }

        void UpdateTime(bool needUpdateDataGrid = true)
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

            UpdateMaxPage(max);

            if (needUpdateDataGrid)
            {
                UpdateDataGrid();
            }
        }

        void UpdateMaxPage(int maxLine)
        {
            pageSelector1.MaximumRange = maxLine / line_per_page;
            if (maxLine % line_per_page > 0) { pageSelector1.MaximumRange++; }
        }

        private readonly string REVENUE_SERIES_NAME = "DOANH THU";
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

            chart1.ChartAreas[0].AxisY.Title = chart1.ChartAreas[1].AxisY.Title = revenue_;

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
            chart1.ChartAreas[1].AxisX.Title = day.ToUpper();
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
            chart1.ChartAreas[1].AxisX.Title = month.ToUpper();

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

            chart1.ChartAreas[0].AxisX.Title = day.ToUpper();

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

            chart1.ChartAreas[0].AxisX.Title = month.ToUpper();

            for (int i = 0; i < saleInfos.Length; i++)
            {
                SaleInfo s = saleInfos[i];

                seriesRevenue.Points.AddXY(string.Format(x_axis_format, s.DateMin.Month, s.DateMin.Year), s.GetRevenue());
            }
        }

        //List<SaleInfo> listSales; // listSale must be sorted by DateTime

        void ChangeStatiticsMode(int mode)
        {
            ModeStatistics = mode;

            timePicker.SetPickMode(0);

            UpdateTime(false);

            pageSelector1.SelectedIndex = 1;
        }

        void UpdateDataGrid()
        {
            int mode = ModeStatistics;
            DateTime dateMin = GetDateMin();
            DateTime dateMax = GetDateMax();


            Console.WriteLine("Update Datagrid from {0} to {1}", dateMin, dateMax);

            dataGridView1.Rows.Clear();

            //GetData(dateMin, dateMax);
            //if (listSales == null ) { throw new NullReferenceException(); }

            string txtTimeFormat;
            if (mode == -1)
            {
                txtTimeFormat = week + " {0} " +month+" {1}/{2}"; // {0} : week; {1}:month; {2}:year
            }
            else if (mode == 0)
            {
                txtTimeFormat = month_+" {0}/{1}"; // {0}:month; {1}:year

                List<KeyValuePair<DateTime, long>> revenue_list = null;
                using (DatabaseController databaseController = new DatabaseController())
                {
                    revenue_list = databaseController.GetRevenue_ByMonth(dateMin, dateMax);
                }

                DateTime month = new DateTime(dateMin.Year, dateMin.Month, 1, 0, 0, 0);
                int stt = GetStartIndex();
                int k = 0;
                while (month < dateMax)
                {
                    long totalRevenue = 0;
                    if (k < revenue_list.Count && month.Year == revenue_list[k].Key.Year && month.Month == revenue_list[k].Key.Month)
                    {
                        totalRevenue = revenue_list[k].Value;
                        k++;
                    }

                    DataGridViewRow row = dataGridView1.Rows[dataGridView1.Rows.Add (stt, string.Format(txtTimeFormat, month.Month, month.Year), string.Format("{0}VND", totalRevenue.ToString("N0")))];  
                    row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    row.Tag = new KeyValuePair<DateTime, long>(month, totalRevenue);
                    row.DefaultCellStyle.SelectionBackColor = color_Line_Selection;
                    if (row.Index % 2 != 0) row.DefaultCellStyle.BackColor = color_Line1;
                    else row.DefaultCellStyle.BackColor = color_Line2;
                    row.DefaultCellStyle.ForeColor = dataGridView1.ForeColor;
                    stt++;
                    month = month.AddMonths(1);
                }

            }
            else if (mode == 1)
            {
                txtTimeFormat = year_+ " {0}";

                List<KeyValuePair<DateTime, long>> revenue_list = null;
                using (DatabaseController databaseController = new DatabaseController())
                {
                    revenue_list = databaseController.GetRevenue_ByYear(dateMin, dateMax);
                }

                DateTime year = new DateTime(dateMin.Year, 1, 1, 0, 0, 0);
                int stt = GetStartIndex();
                int k = 0;
                while (year < dateMax)
                {
                    long totalRevenue = 0;
                    if (k < revenue_list.Count && year.Year == revenue_list[k].Key.Year)
                    {
                        totalRevenue = revenue_list[k].Value;
                        k++;
                    }

                    DataGridViewRow row = dataGridView1.Rows[dataGridView1.Rows.Add(stt, string.Format(txtTimeFormat, year.Year), string.Format("{0}VND", totalRevenue.ToString("N0")))];
                    row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    row.Tag = new KeyValuePair<DateTime, long>(year, totalRevenue);
                    row.DefaultCellStyle.SelectionBackColor = color_Line_Selection;
                    if (row.Index % 2 != 0) row.DefaultCellStyle.BackColor = color_Line1;
                    else row.DefaultCellStyle.BackColor = color_Line2;
                    row.DefaultCellStyle.ForeColor = dataGridView1.ForeColor;
                    stt++;
                    year = year.AddYears(1);
                }
            }
        }

        void GetData(DateTime from, DateTime to)
        {
            // Query data from database base on user's conditions
            // then set data to dataGridView

            Console.WriteLine(string.Format("GetData from ({0}) to ({1})", from.ToString(), to.ToString()));
            ChangeStatiticsMode(cbbStatiticsMode.SelectedIndex);

            /*
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
            */
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

        private void cbbChartMode_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
        Color color_Line1;
        Color color_Line2;
        Color color_Line_Selection;
        public void LoadTheme()
        {
            lbChart.ForeColor = lbConfig.ForeColor = AppManager.GetColors("Title_Force");
            lbChart.BackColor = lbConfig.BackColor = AppManager.GetColors("Title_Background");

            label4.ForeColor = AppManager.GetColors("Main_Plaintext");

            dataGridView1.ForeColor = label4.ForeColor;

            dataGridView1.BackgroundColor = AppManager.GetColors("Grid_Background");
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = dataGridView1.ForeColor;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = AppManager.GetColors("Grid_Header");
            color_Line_Selection = AppManager.GetColors("Grid_Line_Selection");
            color_Line1 = AppManager.GetColors("Grid_Line1");
            color_Line2 = AppManager.GetColors("Grid_Line2");

            chart1.BackColor = panel2.BackColor = AppManager.GetColors("Chart_Background");
            foreach (ChartArea area in chart1.ChartAreas) { area.BackColor = chart1.BackColor; }
        }
    }
}
