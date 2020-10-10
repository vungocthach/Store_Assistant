using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreAssitant
{
    public partial class TableLine : UserControl
    {
        public TableLine()
        {
            InitializeComponent();
            this.SizeChanged += TableLine_SizeChanged;
            this.MinimumSize = new Size(348, 23);
            btnAdd.Click += BtnAdd_Click;
            btnRemove.Click += BtnRemove_Click;
            lbNumber.TextChanged += LbNumber_TextChanged;
            lbSinglePrice.TextChanged += LbSinglePrice_TextChanged;
        }

        private void LbSinglePrice_TextChanged(object sender, EventArgs e)
        {
            lbTotalPrice.Text = TotalPrice();
        }
        private void LbNumber_TextChanged(object sender, EventArgs e)
        {
            lbTotalPrice.Text = TotalPrice();
        }
        private string TotalPrice()
        {
            return (int.Parse(lbSinglePrice.Text) * int.Parse(lbNumber.Text)).ToString();
        }

        private void SetData(ProductInfo product, int number = 1)
        {
            Name = product.Name;
            SinglePrice = product.Price.ToString();
            Number = number.ToString();
            lbTotalPrice.Text = TotalPrice();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            lbNumber.Text = (int.Parse(lbNumber.Text) - 1).ToString();
            if (0 == int.Parse(lbNumber.Text))
            {
                MessageBox.Show("Thực hiện xóa dòng này");
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            lbNumber.Text = (int.Parse(lbNumber.Text) + 1).ToString();
        }

        private void TableLine_SizeChanged(object sender, EventArgs e)
        {
            lbName.Size = new Size(this.Size.Width * 13 / 44, this.Size.Height);
            lbTotalPrice.Size = lbSinglePrice.Size = new Size(this.Size.Width * 10 / 44, this.Size.Height);
            pnlNumber.Size = new Size(this.Size.Width * 11 / 44, this.Size.Height);

            lbSinglePrice.Location = new Point(lbName.Size.Width, 0);
            pnlNumber.Location = new Point(lbSinglePrice.Location.X + lbSinglePrice.Size.Width, 0);
            lbTotalPrice.Location = new Point(pnlNumber.Location.X + pnlNumber.Size.Width, 0);

            lbNumber.Location = new Point((lbNumber.Parent.Width - lbNumber.Size.Width) / 2, (lbNumber.Parent.Height - lbNumber.Size.Height) / 2 - 1);
            btnAdd.Location = new Point((lbNumber.Location.X - btnAdd.Size.Width) / 2, (btnAdd.Parent.Size.Height - btnAdd.Size.Height)/2 - 1);
            btnRemove.Location = new Point(lbNumber.Parent.Width - btnAdd.Location.X - btnAdd.Size.Width, (btnRemove.Parent.Size.Height - btnRemove.Size.Height) / 2 - 1);
        }
        [Category("MyProperties"),Description("Name of product")]
        public string Name
        {
            get => lbName.Text;
            set
            {
                lbName.Text = value;
                Invalidate();
            }
        }
        [Category("MyProperties"),Description("Price of product")]
        public string SinglePrice
        {
            get => lbSinglePrice.Text;
            set
            {
                lbSinglePrice.Text = value;
                Invalidate();
            }
        }
        [Category("MyProperties"),Description("Number product")]
        public string Number
        {
            get => lbNumber.Text;
            set
            {
                if (int.Parse(value) < 0)
                {
                    MessageBox.Show("Số lượng phải là số dương", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                lbNumber.Text = value;
                Invalidate();
            }
        }
    }
}
