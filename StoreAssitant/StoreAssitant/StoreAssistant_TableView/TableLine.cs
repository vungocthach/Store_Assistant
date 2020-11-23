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

namespace StoreAssitant
{
    public partial class TableLine : UserControl
    {
        #region CREATE EVENTS
        [Category("My Event"),Description("When information of product is changed")]
        public event EventHandler InfoChanged;
        private void onInfoChanged(object sender, EventArgs e) 
        {
            lbName.Text = product.Name;
            lbNumber.Text = product.NumberProduct.ToString();
            lbSinglePrice.Text = product.Price.ToString();
            lbTotalPrice.Text = TotalPrice().ToString();
        }
        #endregion

        #region FIELDS
        private Class_Information.Products product = null;
        #endregion

        public TableLine()
        {
            InitializeComponent();
            this.Layout += TableLine_Layout;
            this.InfoChanged = new EventHandler(onInfoChanged);

            this.MinimumSize = new Size(348, 23);
            btnAdd.Click += BtnAdd_Click;
            btnRemove.Click += BtnRemove_Click;
        }

        private int TotalPrice()
        {
            return product.Price*product.NumberProduct;
        }

        public void SetData(Class_Information.Products product)
        {
            if (product != null)
            {
                this.product = product;
                lbNumber.DataBindings.Add("Text", product, "NumberProduct", true, DataSourceUpdateMode.OnValidation);
                onInfoChanged(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Không thể truy cập dữ liệu món ăn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            Number--;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Number++;
        }

        private void TableLine_Layout(object sender, EventArgs e)
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
        #region PROPERTIES
        [Category("MyProperties"),Description("Name of product")]
        public string Name
        {
            get => product.Name;
            set
            {
                if (product == null)
                {
                    lbName.Text = value;
                }
                else
                {
                    product.Name = value;
                    onInfoChanged(this, new EventArgs());
                }
                Invalidate();
            }
        }
        [Category("MyProperties"),Description("Price of product")]
        public int SinglePrice
        {
            get => product.Price;
            set
            {
                if (product == null)
                {
                    lbSinglePrice.Text = value.ToString();
                }
                else
                {
                    product.Price = value;
                    onInfoChanged(this, new EventArgs());
                }
                Invalidate();
            }
        }
        [Category("MyProperties"),Description("Number product")]
        public int Number
        {
            get => product.NumberProduct;
            set
            {
                if (product == null)
                {
                    lbNumber.Text = value.ToString();
                }
                else
                {
                    if (value == 0)
                    {
                        btnRemove.Enabled = false;
                        btnRemove.BackColor = Color.Gray;
                    }
                    else
                    {
                        btnRemove.Enabled = true;
                        btnRemove.BackColor = System.Drawing.Color.DeepSkyBlue;
                    }
                    product.NumberProduct = value;
                    onInfoChanged(this, new EventArgs());
                }
                Invalidate();
            }
        }
        [Category("MyProperties"), Description("Id product")]
        public int IDProduct
        {
            get => product.Id;
        }
        #endregion
    }
}
