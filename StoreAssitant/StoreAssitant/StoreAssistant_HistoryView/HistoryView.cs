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
using StoreAssitant.StoreAssistant_VoucherView;
using StoreAssitant.StoreAssistant_Helper;

namespace StoreAssitant.StoreAssistant_HistoryView
{
    public partial class HistoryView : UserControl, ILoadTheme
    {
        double[] columnWeights;
        string Lang = "vn";
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

            if (Lang != AppManager.CurrentLanguage)
            {
                Lang = AppManager.CurrentLanguage;
                SetLanguge();
            }
            Language.ChangeLanguage += VoucherView_ChangeLanguage;

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

            //dataGridView1.Location = new Point(dataGridView1.Margin.Left, dataGridView1.Location.Y);
            columnWeights = new double[] { 0.99d / 13, 3.0d / 13, 3.0d / 13, 3.0d / 13, 3.0d / 13 };
            AutoSizeColumns();

            this.SizeChanged += HistoryView_SizeChanged;
            this.btn_Search.Click += Btn_Search_Click;

            pageSelector1.SelectedIndexChanged += PageSelector1_SelectedIndexChanged;

            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            //dataGridView1.ColumnSortModeChanged += DataGridView1_ColumnSortModeChanged;

            dtp_From.ValueChanged += Dtp_From_ValueChanged;
            dtp_To.ValueChanged += Dtp_From_ValueChanged;
            
            this.Load += HistoryView_Load;

            textBox1.KeyDown += TextBox1_KeyDown;
        }

        private void DataGridView1_ColumnSortModeChanged(object sender, DataGridViewColumnEventArgs e)
        {
            Console.WriteLine("got it");
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { Btn_Search_Click(btn_Search, EventArgs.Empty); }
        }

        private void VoucherView_ChangeLanguage(object sender, string e)
        {
            SetLanguge();
        }

        private void SetLanguge()
        {
            Language.InitLanguage(this);
            lbTime.Text = Language.Rm.GetString("Time", Language.Culture);
            lbSearch.Text = Language.Rm.GetString("Search", Language.Culture);
            label1.Text = Language.Rm.GetString("From:", Language.Culture);
            label2.Text = Language.Rm.GetString("To:", Language.Culture);
            label3.Text = Language.Rm.GetString("Code:", Language.Culture);
            dataGridView1.Columns[0].HeaderText = Language.Rm.GetString("Number", Language.Culture);
            dataGridView1.Columns[1].HeaderText = Language.Rm.GetString("Bill code", Language.Culture);
            dataGridView1.Columns[2].HeaderText = Language.Rm.GetString("Date", Language.Culture);
            dataGridView1.Columns[3].HeaderText = Language.Rm.GetString("Table", Language.Culture);
            dataGridView1.Columns[4].HeaderText = Language.Rm.GetString("Total", Language.Culture);
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
                int index = dataGridView1.HitTest(cursor.X, cursor.Y).RowIndex;

                if (index == -1) return;
                DataGridViewRow row = dataGridView1.Rows[index];
                dataGridView1.ContextMenu.Tag = row;
                dataGridView1.ContextMenu.Show(dataGridView1, cursor);
            }
            /*
            if (e.Button == MouseButtons.Left)
            {
                Point cursor = new Point(e.X, e.Y);
                int index = dataGridView1.HitTest(cursor.X, cursor.Y).RowIndex;

                if (index == -1)
                {
                    DataGridViewColumn col = dataGridView1.Columns[dataGridView1.HitTest(cursor.X, cursor.Y).ColumnIndex];
                    Console.WriteLine("Hit sort with mode: {0}", dataGridView1.sort);
                }
            }*/
        }

        private void DataGridView1_Sorted(object sender, EventArgs e)
        {
            dataGridView1.SuspendLayout();
            /*
            int temp = GetStartIndex();
            DataGridViewRow row;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                row = dataGridView1.Rows[i];
                row.Cells[0].Value = i + temp;
                if (i % 2 != 0) row.DefaultCellStyle.BackColor = color_Line1;
                else row.DefaultCellStyle.BackColor = color_Line2;
            }
            */
            if (dataGridView1.SortedColumn.Index == 2 || dataGridView1.SortedColumn.Index == 1)
            {
                this.modeSort = 2;
            }
            else if (dataGridView1.SortedColumn.Index == 3)
            {
                this.modeSort = 3;
            }
            else if(dataGridView1.SortedColumn.Index == 4)
            {
                this.modeSort = 4;
            }

            this.direction = (dataGridView1.SortOrder == SortOrder.Ascending) ? "ASC" : "DESC";
            GetData();
            dataGridView1.ResumeLayout();
        }
        private void DataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Index == 2 || e.Column.Index == 3 || e.Column.Index == 4)
            {
                e.Handled = true;
            }
        }

        private void HistoryView_Load(object sender, EventArgs e)
        {
            UpdateTime(false);
            //dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Descending);
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
            if (e.RowIndex == -1) { return; } // Click on header-cell
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
            panel1.Width = this.Width - panel1.Location.X - panel1.Margin.Right;
            pageSelector1.Location = new Point((this.Width - pageSelector1.Width) / 2, this.Height - pageSelector1.Margin.Top - pageSelector1.Margin.Bottom - pageSelector1.Height - dataGridView1.Margin.Bottom);
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

        int modeSort = 0;
        string direction = "DESC";
        public void GetData()
        {
            Console.WriteLine("HistoryView : GetData()");
            List<BillInfo> bills;

            DateTime fromDate = new DateTime(GetStartTime().Year, GetStartTime().Month, GetStartTime().Day, 0, 0, 0);
            DateTime toDate = new DateTime(GetEndTime().Year, GetEndTime().Month, GetEndTime().Day, 23, 59, 59);
            using (DatabaseController databaseController = new DatabaseController())
            {
                bills = databaseController.GetBillInfo(fromDate, toDate, GetStartIndex(), row_per_page, modeSort, direction);
            }

            SetData(bills);
        }
        Color color_Line1;
        Color color_Line2;
        Color color_Line_Selection;
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
                row.DefaultCellStyle.SelectionBackColor = color_Line_Selection;
                if ( row.Index % 2 != 0) row.DefaultCellStyle.BackColor = color_Line1;
                else row.DefaultCellStyle.BackColor = color_Line2;
                row.DefaultCellStyle.ForeColor = dataGridView1.ForeColor;
            }
            dataGridView1.ResumeLayout();
        }

        public void LoadTheme()
        {
            panel1.ForeColor = AppManager.GetColors("Main_Plaintext");
            foreach (Control control in panel1.Controls) { control.ForeColor = panel1.ForeColor; }
            panel2.ForeColor = panel1.ForeColor;
            foreach (Control control in panel2.Controls) { control.ForeColor = panel2.ForeColor; }
            panel1.BackColor = panel2.BackColor = textBox1.BackColor = AppManager.GetColors("Main_Background");

            dataGridView1.ForeColor = panel2.ForeColor;
            dataGridView1.BackgroundColor = AppManager.GetColors("Grid_Background");
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = dataGridView1.ForeColor;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = AppManager.GetColors("Grid_Header");
            color_Line_Selection = AppManager.GetColors("Grid_Line_Selection");
            color_Line1 = AppManager.GetColors("Grid_Line1");
            color_Line2 = AppManager.GetColors("Grid_Line2");

            lbSearch.BackColor = lbTime.BackColor = AppManager.GetColors("Title_Background");
            lbSearch.ForeColor = lbTime.ForeColor = AppManager.GetColors("Title_Force");
        }

        private void lbSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
