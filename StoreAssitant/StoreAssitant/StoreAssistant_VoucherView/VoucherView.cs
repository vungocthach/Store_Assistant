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
using System.Reflection;
using StoreAssitant.StoreAssistant_Helper;

namespace StoreAssitant.StoreAssistant_VoucherView
{
    public partial class VoucherView : UserControl, ILoadTheme
    {
        private string lang = "vn";
        string Error = "Lỗi";
        string CodeIsExists = "Mã code tồn tại";
        public VoucherView()
        {
            InitializeComponent();
            if (lang != AppManager.CurrentLanguage)
            {
                lang = AppManager.CurrentLanguage;
                SetLanguage();
            }

            Language.ChangeLanguage += VoucherView_ChangeLanguage;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font.FontFamily, 13, FontStyle.Bold);

            this.Layout += VoucherView_Layout;
            btnAdd.Click += BtnAdd_Click;
            btnRemove.Click += BtnRemove_Click;
            dataGridView1.ColumnHeaderMouseClick += DataGridView1_ColumnHeaderMouseClick;
            dataGridView1.AutoGenerateColumns = true;
        }

        private void DataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                dataGridView1.Rows[0].Selected = true;
                reloadTheme(0);
            }
        }

        private void VoucherView_ChangeLanguage(object sender, string e)
        {
            SetLanguage();
        }

        public void SetLanguage( )
        {
            Language.InitLanguage(this);
            label1.Text = Language.Rm.GetString("YOUR VOUCHER", Language.Culture);
            dataGridView1.Columns[0].HeaderText = Language.Rm.GetString("Voucher code", Language.Culture);
            dataGridView1.Columns[1].HeaderText = Language.Rm.GetString("Expiry date", Language.Culture);
            dataGridView1.Columns[2].HeaderText = Language.Rm.GetString("Value(%)", Language.Culture);
            dataGridView1.Columns[3].HeaderText = Language.Rm.GetString("Quantum", Language.Culture);
            dataGridView1.Columns[4].HeaderText = Language.Rm.GetString("Remain", Language.Culture);
            btnAdd.Text = Language.Rm.GetString("Add", Language.Culture);
            btnRemove.Text = Language.Rm.GetString("Delete", Language.Culture);

            CodeIsExists = Language.Rm.GetString("CodeIsExists", Language.Culture);
            Error = Language.Rm.GetString("Error", Language.Culture);
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                using (DatabaseController data = new DatabaseController())
                {
                    data.RemoveVoucher(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                }
                dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                reloadTheme(index);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddVoucherForm f = new AddVoucherForm();
            f.AddVoucher += eventAddVoucher;
            f.ShowDialog();
        }

        private void eventAddVoucher(object sender, VoucherInfo e)
        {
            foreach (DataGridViewRow name in dataGridView1.Rows)
            {
                if (name.Cells[0].Value.ToString() == e.Code)
                {
                    MessageBox.Show(CodeIsExists, Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            int index = dataGridView1.Rows.Add(e.Code, e.ExpiryDate, e.Value, e.NumberInit, e.NumberRemain);
            Console.WriteLine(index);
            reloadTheme(index);
            using (DatabaseController data = new DatabaseController())
            {
                data.AddVoucher(e);
            }
        }

        private void VoucherView_Layout(object sender, LayoutEventArgs e)
        {
            int space = 10;
            label1.Size = new Size(this.Width, label1.Size.Height);
            btnRemove.Location = new Point(this.Width - btnRemove.Width - space * 2, this.Height - btnRemove.Height - space);
            btnAdd.Location = new Point(btnRemove.Location.X - btnAdd.Width - space, btnRemove.Location.Y);
            dataGridView1.Size = new Size(this.Width <= 1024? this.Width - 20*space : this.Width * 3/5, this.Height - label1.Height - btnAdd.Size.Height - space * 5);
            dataGridView1.Location = new Point((this.Width - dataGridView1.Width)/2, label1.Height);
        }

        internal void LoadDataFromDB()
        {
            dataGridView1.Rows.Clear();
            using (DatabaseController databaseController = new DatabaseController())
            {
                databaseController.ConnectToSQLDatabase();
                List<VoucherInfo> info = databaseController.GetVouchers();
                for (int i = 0; i < info.Count; i++)
                {
                    int index = dataGridView1.Rows.Add(info[i].Code,info[i].ExpiryDate,info[i].Value,info[i].NumberInit,info[i].NumberRemain);
                    DataGridViewRow row = dataGridView1.Rows[index];
                    row.DefaultCellStyle.SelectionBackColor = color_Line_Selection;
                    if (row.Index % 2 != 0) row.DefaultCellStyle.BackColor = color_Line1;
                    else row.DefaultCellStyle.BackColor = color_Line2;
                    row.DefaultCellStyle.ForeColor = dataGridView1.ForeColor;
                }
            }
        }
        Color color_Line1;
        Color color_Line2;
        Color color_Line_Selection;

        public void LoadTheme()
        {
            label1.ForeColor = AppManager.GetColors("Main_Plaintext");

            dataGridView1.ForeColor = label1.ForeColor;
            dataGridView1.BackgroundColor = AppManager.GetColors("Grid_Background");
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = dataGridView1.ForeColor;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = AppManager.GetColors("Grid_Header");
            color_Line_Selection = AppManager.GetColors("Grid_Line_Selection");
            color_Line1 = AppManager.GetColors("Grid_Line1");
            color_Line2 = AppManager.GetColors("Grid_Line2");
        }
        private void reloadTheme(int indexStart)
        {
            for (int i = indexStart; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                row.DefaultCellStyle.SelectionBackColor = color_Line_Selection;
                if (row.Index % 2 != 0) row.DefaultCellStyle.BackColor = color_Line1;
                else row.DefaultCellStyle.BackColor = color_Line2;
                row.DefaultCellStyle.ForeColor = dataGridView1.ForeColor;
            }
        }
    }
}