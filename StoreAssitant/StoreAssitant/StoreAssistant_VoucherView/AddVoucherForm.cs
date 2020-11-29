using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreAssitant.StoreAssistant_VoucherView
{
    public partial class AddVoucherForm : Form
    {
        public event EventHandler<VoucherInfo> AddVoucher;
        private int valueVoucher;
        private int numberInitVoucher;
        private DateTime expiryDateVoucher;
        private string codeVoucher;

        public int ValueVoucher 
        { 
            get => valueVoucher;
            set
            {
                if (value != valueVoucher)
                {
                    valueVoucher = value;
                    tbValue.Text = string.Format("{0}", value.ToString("N0"));
                    tbValue.Select(tbValue.TextLength, 0);
                    Invalidate();
                }
            }
        }
        public int NumberInitVoucher 
        { 
            get => numberInitVoucher;
            set
            {
                if (value != numberInitVoucher)
                {
                    numberInitVoucher = value;
                    tbNumberInit.Text = string.Format("{0}", value.ToString("N0"));
                    tbNumberInit.Select(tbNumberInit.TextLength, 0);
                    Invalidate();
                }
            }
        }
        public DateTime ExpiryDateVoucher 
        { 
            get => expiryDateVoucher;
            set
            {
                if (value != expiryDateVoucher)
                {
                    if (value < DateTime.Now.Date)
                    {
                        MessageBox.Show("Ngày hết hạn phải lớn hơn ngày hôm nay");
                        return;
                    }
                    expiryDateVoucher = value;
                    Invalidate();
                }
            }
        }
        public string CodeVoucher 
        { 
            get => codeVoucher;
            set
            {
                codeVoucher = value;
            }
        }

        public AddVoucherForm()
        {
            InitializeComponent();

            btnConfirm.Click += BtnConfirm_Click;
            btnCancel.Click += BtnCancel_Click;

            tbValue.TextChanged += TbValue_TextChanged;
            tbNumberInit.TextChanged += TbNumberInit_TextChanged;
            dtpExpiryDate.ValueChanged += DtpExpiryDate_ValueChanged;
            tbCode.TextChanged += TbCode_TextChanged;
            tbNumberInit.KeyPress += KeyPressNumber;
            tbValue.KeyPress += KeyPressNumber;


            AddVoucher = new EventHandler<VoucherInfo>((s,e)=> { });

            //ExpiryDateVoucher = DateTime.Now;
            dtpExpiryDate.Value = DateTime.Now.Date;
        }
        private void KeyPressNumber(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > (char)Keys.D9 || e.KeyChar < (char)Keys.D0) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            //Edit: Alternative
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.Handled == true)
            {
                MessageBox.Show("Chỉ được phép nhập số nguyên");
            }
        }

        private void TbCode_TextChanged(object sender, EventArgs e)
        {
            codeVoucher = ((TextBox)sender).Text;
        }

        private void DtpExpiryDate_ValueChanged(object sender, EventArgs e)
        {
            var date = ((DateTimePicker)sender).Value;
            ExpiryDateVoucher = date;
        }

        private void TbNumberInit_TextChanged(object sender, EventArgs e)
        {
            TextBox txtb = (TextBox)sender;
                if (txtb.Text.Trim() == "")
                {
                    NumberInitVoucher = 0;
                }
                else
                {
                    NumberInitVoucher = Convert.ToInt32(txtb.Text);
                    if (NumberInitVoucher > 10000)
                    {
                        NumberInitVoucher = 10000;
                        MessageBox.Show("Vui lòng nhập giá trị trong khoảng 0 đến 10000");
                    }
                    else if (NumberInitVoucher < 0)
                    {
                        NumberInitVoucher = 0;
                        MessageBox.Show("Vui lòng nhập giá trị trong khoảng 0 đến 10000");
                    }
                }
        }

        private void TbValue_TextChanged(object sender, EventArgs e)
        {
            TextBox txtb = (TextBox)sender;
                if (txtb.Text.Trim() == "")
                {
                    ValueVoucher = 0;
                }
                else
                {
                    ValueVoucher = int.Parse(txtb.Text);
                    if (ValueVoucher>100)
                    {
                        ValueVoucher = 100;
                        MessageBox.Show("Vui lòng nhập giá trị từ 0 đến 100");
                    }
                    else if (ValueVoucher<0)
                    {
                        ValueVoucher = 0;
                        MessageBox.Show("Vui lòng nhập giá trị từ 0 đến 100");
                    }
                }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            VoucherInfo info = new VoucherInfo();
            if (string.IsNullOrEmpty(tbCode.Text) || string.IsNullOrEmpty(tbNumberInit.Text) || string.IsNullOrEmpty(tbValue.Text))
            {
                MessageBox.Show("Không được để trống");
                return;
            }
            if (valueVoucher == 0 || numberInitVoucher == 0)
            {
                MessageBox.Show("Các giá trị phải lớn hơn 0");
                return;
            }
            if (expiryDateVoucher < DateTime.Now)
            {
                MessageBox.Show("Thời hạn phải lớn hơn ngày hiện tại");
                return;
            }
            info.Code = CodeVoucher;
            info.ExpiryDate = ExpiryDateVoucher;
            info.NumberInit = info.NumberRemain = numberInitVoucher;
            info.Value = valueVoucher;
            AddVoucher(this, info);
            this.Close();
        }
    }
}
