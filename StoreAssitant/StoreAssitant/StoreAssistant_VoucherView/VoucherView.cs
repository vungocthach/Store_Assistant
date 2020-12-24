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
    public partial class VoucherView : UserControl
    {
        BindingList<VoucherInfo> info;
        private string lang = "vn";
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

            dataGridView1.AutoGenerateColumns = true;
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
            
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                using (DatabaseController data = new DatabaseController())
                {
                    data.RemoveVoucher(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                }
                dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
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
                    MessageBox.Show("Mã code này đã tồn tại");
                    return;
                }
            }
            info.Add(e);
            using (DatabaseController data = new DatabaseController())
            {
                data.AddVoucher(e);
            }
            Invalidate();
        }

        private void VoucherView_Layout(object sender, LayoutEventArgs e)
        {
            int space = 10;
            btnRemove.Location = new Point(this.Width - btnRemove.Width - space, this.Height - btnRemove.Height - space);
            btnAdd.Location = new Point(this.Width - btnAdd.Width - btnRemove.Width - space*2, btnRemove.Location.Y);
            dataGridView1.Size = new Size(this.Width, this.Height*3/4);
            dataGridView1.Location = new Point(0, (this.Height-dataGridView1.Height)/2);
            label1.Size = new Size(this.Width,dataGridView1.Location.Y);
        }

        internal void LoadDataFromDB()
        {
            using (DatabaseController databaseController = new DatabaseController())
            {
                databaseController.ConnectToSQLDatabase();
                dataGridView1.DataSource = info = databaseController.GetVouchers();                
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRemove_Click_1(object sender, EventArgs e)
        {

        }
    }
}
