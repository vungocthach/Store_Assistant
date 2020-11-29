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

namespace StoreAssitant.StoreAssistant_VoucherView
{
    public partial class VoucherView : UserControl
    {
        BindingList<VoucherInfo> info;
        public VoucherView()
        {
            InitializeComponent();
            this.Layout += VoucherView_Layout;
            btnAdd.Click += BtnAdd_Click;
            btnRemove.Click += BtnRemove_Click;

            dataGridView1.AutoGenerateColumns = true;
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
                MessageBox.Show(info.Count.ToString());
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
        }

        internal void LoadDataFromDB()
        {
            using (DatabaseController databaseController = new DatabaseController())
            {
                databaseController.ConnectToSQLDatabase();
                dataGridView1.DataSource = info = databaseController.GetVouchers();                
            }
        }
    }
}
