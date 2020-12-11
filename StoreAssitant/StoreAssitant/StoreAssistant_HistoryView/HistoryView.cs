using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StoreAssitant.Class_Information;

namespace StoreAssitant.StoreAssistant_HistoryView
{
    public partial class HistoryView : UserControl
    {
        double[] columnWeights;
        public double[] ColumnsWeights { get => columnWeights;
            set
            {
                columnWeights = value;

                AutoSizeColumns();
                Invalidate();
            }
        }

        SearchAdvancedForm searchForm;

        public HistoryView()
        {
            InitializeComponent();

            dataGridView1.ContextMenu = new ContextMenu();
            dataGridView1.ContextMenu.MenuItems.Add("Delete").Click += HistoryView_ClickDelete;
            dataGridView1.MouseClick += DataGridView1_MouseClick;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);

            dataGridView1.SortCompare += DataGridView1_SortCompare;
            dataGridView1.Sorted += DataGridView1_Sorted;

            dtp_To.MaxDate = DateTime.Today.AddDays(1);
            dtp_From.Value = DateTime.Today.AddYears(-1);
            dtp_To.Value = DateTime.Now;

            searchForm = new SearchAdvancedForm();
            searchForm.ClickedSubmitOK += SearchForm_ClickedSubmitOK;

            dataGridView1.Location = new Point(dataGridView1.Margin.Left, groupBox1.Location.Y + groupBox1.Height + groupBox1.Margin.Bottom + dataGridView1.Margin.Top);
            columnWeights = new double[] { 0.99d / 13, 3.0d / 13, 3.0d / 13, 3.0d / 13, 3.0d / 13 };
            AutoSizeColumns();

            this.SizeChanged += HistoryView_SizeChanged;
            this.button1.Click += Button1_Click;
            this.btn_Search.Click += Btn_Search_Click;

            pageSelector1.SelectedIndexChanged += PageSelector1_SelectedIndexChanged;

            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;

            dtp_From.ValueChanged += Dtp_From_ValueChanged;
            dtp_To.ValueChanged += Dtp_From_ValueChanged;

            this.Load += HistoryView_Load;
        }

        private void HistoryView_ClickDelete(object sender, EventArgs e)
        {
            if (dataGridView1.ContextMenu.Tag == null) { throw new NullReferenceException(); }
            DataGridViewRow row = dataGridView1.ContextMenu.Tag as DataGridViewRow;
            using (DatabaseController databaseController = new DatabaseController())
            {
                // Delete from database
                databaseController.delete_Bill((row.Tag as BillInfo).ID);
            }
            GetData();
            Console.WriteLine("Clicked delete row : " + row.Index);
        }

        private void DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point cursor = new Point(e.X, e.Y);
                DataGridViewRow row = dataGridView1.Rows[dataGridView1.HitTest(cursor.X, cursor.Y).RowIndex];

                dataGridView1.ContextMenu.Tag = row;
                dataGridView1.ContextMenu.Show(dataGridView1, cursor);
            }
        }

        private void DataGridView1_Sorted(object sender, EventArgs e)
        {
            int temp = GetStartIndex();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = i + temp; 
            }
        }

        private void DataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Index == 2)
            {
                DateTime date1 = (dataGridView1.Rows[e.RowIndex1].Tag as BillInfo).DAY;
                DateTime date2 = (dataGridView1.Rows[e.RowIndex2].Tag as BillInfo).DAY;
                e.SortResult = date1.CompareTo(date2);
                e.Handled = true;
            }
            else if (e.Column.Index == 4)
            {
                long price1 = (dataGridView1.Rows[e.RowIndex1].Tag as BillInfo).TOTAL;
                long price2 = (dataGridView1.Rows[e.RowIndex2].Tag as BillInfo).TOTAL;
                e.SortResult = price1.CompareTo(price2);
                e.Handled = true;
            }
        }

        private void HistoryView_Load(object sender, EventArgs e)
        {
            UpdateTime(false);
            dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Descending);
        }

        private void Dtp_From_ValueChanged(object sender, EventArgs e)
        {
            UpdateTime();
        }

        void UpdateTime(bool needSetData = true)
        {
            using (DatabaseController databaseController = new DatabaseController())
            {
                int c = databaseController.CountBill(GetStartTime(), GetEndTime());
                pageSelector1.MaximumRange = c / row_per_page;
                if (c % row_per_page != 0) { pageSelector1.MaximumRange += 1; }
            }
            pageSelector1.SelectedIndex = 1;
            if (needSetData) { GetData(); }
        }

        private void PageSelector1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Page selected changed");
            GetData();
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Trim() == string.Empty) { UpdateTime();}
            else
            {
                // This is searching

                int id = -1;
                try
                {
                    id = int.Parse(textBox1.Text.Trim());
                }
                catch (FormatException)
                {
                    dataGridView1.Rows.Clear();
                    return;
                }

                List<BillInfo> bills = new List<BillInfo>(1);
                using (DatabaseController databaseController = new DatabaseController())
                {
                    BillInfo billInfo = databaseController.GetOneBillInfo(id);
                    if (billInfo != null)
                    {
                        bills.Add(billInfo);
                    }
                }

                pageSelector1.MaximumRange = 1;
                pageSelector1.SelectedIndex = 1;

                SetData(bills);
            }
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
            BillInfo billInfo = selectedRow.Tag as BillInfo;
            using (DatabaseController databaseController = new DatabaseController())
            {
                billInfo.ProductBills = databaseController.GetDetailBillInfo(billInfo.ID);
            }
                // Show bill
                FormBill formBill = new FormBill(billInfo);
            formBill.ShowDialog();
            Console.WriteLine("Double clicked to bill : " + billInfo.ID.ToString());
        }

        private void SearchForm_ClickedSubmitOK(object sender, EventArgs e)
        {
            // Filter data with
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            searchForm.ShowDialog();
        }

        //public void SetData(List<TableBillInfo>)

        private void HistoryView_SizeChanged(object sender, EventArgs e)
        {
            pageSelector1.Location = new Point((this.Width - pageSelector1.Width) / 2, this.Height - pageSelector1.Margin.Top - pageSelector1.Margin.Bottom - pageSelector1.Height);
            dataGridView1.Height = pageSelector1.Location.Y - dataGridView1.Location.Y - pageSelector1.Margin.Top - dataGridView1.Margin.Bottom;
            dataGridView1.Width = this.Width - dataGridView1.Margin.Left - dataGridView1.Margin.Right;
            AutoSizeColumns();
        }

        void AutoSizeColumns()
        {
            for (int i = 0; i < dataGridView1.Columns.Count; i++) { dataGridView1.Columns[i].Width = (int)(dataGridView1.Width * columnWeights[i]); }
        }

        DateTime GetStartTime()
        {
            return dtp_From.Value;
        }

        DateTime GetEndTime()
        {
            return dtp_To.Value;
        }

        int row_per_page = 20;
        int GetStartIndex() { return (pageSelector1.SelectedIndex - 1) * row_per_page +1; }

        public void GetData()
        {
            Console.WriteLine("HistoryView : GetData()");
            List<BillInfo> bills;

            DateTime fromDate = new DateTime(GetStartTime().Year, GetStartTime().Month, GetStartTime().Day, 0, 0, 0);
            DateTime toDate = new DateTime(GetEndTime().Year, GetEndTime().Month, GetEndTime().Day, 23, 59, 59);
            using (DatabaseController databaseController = new DatabaseController())
            {
                bills = databaseController.GetBillInfo(fromDate, toDate, GetStartIndex(), row_per_page);
            }

            SetData(bills);
        }

        void SetData(List<BillInfo> bills)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.SuspendLayout();
            int startIndex = GetStartIndex();
            for(int i = 0; i < bills.Count; i++)
            {
                BillInfo b = bills[i];
                int index = dataGridView1.Rows.Add(startIndex + i , b.ID, b.DAY.ToString("dd/MM/yyyy"), b.Number_table, string.Format("{0}VND", b.TOTAL.ToString("N0")));
                DataGridViewRow row = dataGridView1.Rows[index];
                row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                row.Tag = b;
                if ( row.Index % 2 == 0) row.DefaultCellStyle.BackColor = Color.LightSkyBlue;
            }
            dataGridView1.ResumeLayout();
        }
    }
}
