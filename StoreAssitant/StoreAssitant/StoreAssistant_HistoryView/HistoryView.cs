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

            dtp_To.MaxDate = DateTime.Today.AddDays(1);
            dtp_From.Value = dtp_From.MinDate;
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

        private void HistoryView_Load(object sender, EventArgs e)
        {
            UpdateTime(false);
            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
        }

        private void Dtp_From_ValueChanged(object sender, EventArgs e)
        {
            UpdateTime();
        }

        void UpdateTime(bool needSetData = true)
        {
            using (DatabaseController databaseController = new DatabaseController())
            {
                pageSelector1.MaximumRange = databaseController.CountBill(GetStartTime(), GetEndTime())/row_per_page + 1;
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

            if (textBox1.Text.Trim() == string.Empty) { GetData(); }
            else
            {
                // This is searching
                List<BillInfo> bills = new List<BillInfo>(1);
                using (DatabaseController databaseController = new DatabaseController())
                {
                    BillInfo billInfo = databaseController.GetOneBillInfo(id);
                    if (billInfo != null)
                    {
                        bills.Add(billInfo);
                    }
                }

                SetData(bills);
            }
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
            BillInfo billInfo = selectedRow.Tag as BillInfo;
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

        int row_per_page = 10;
        int startIndex { get => (pageSelector1.SelectedIndex - 1) * row_per_page +1; }

        public void GetData()
        {
            Console.WriteLine("HistoryView : GetData()");
            List<BillInfo> bills;
            using (DatabaseController databaseController = new DatabaseController())
            {
                bills = databaseController.GetBillInfo(GetStartTime(), GetEndTime(), startIndex, row_per_page);
            }

            SetData(bills);
        }

        void SetData(List<BillInfo> bills)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.SuspendLayout();
            for(int i = 0; i < bills.Count; i++)
            {
                BillInfo b = bills[i];
                int index = dataGridView1.Rows.Add(i + 1, b.ID, b.DAY.ToString("dd/MM/yyyy"), b.Number_table, b.TOTAL);
                DataGridViewRow row = dataGridView1.Rows[index];
                row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                row.Tag = b;
            }
            dataGridView1.ResumeLayout();
        }
    }
}
