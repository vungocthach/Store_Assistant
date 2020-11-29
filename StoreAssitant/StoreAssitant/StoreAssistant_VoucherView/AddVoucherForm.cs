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


            AddVoucher = new EventHandler<VoucherInfo>((s,e)=> { });

            dtpExpiryDate.Value = DateTime.Now;
        }

        private void TbCode_TextChanged(object sender, EventArgs e)
        {
            codeVoucher = ((TextBox)sender).Text;
        }

        private void DtpExpiryDate_ValueChanged(object sender, EventArgs e)
        {
            var date = ((DateTimePicker)sender).Value;
            if (DateTime.Now > date)
            {
                MessageBox.Show("Ngày hết hạn phải lớn hơn ngày hiện tại");
            }
            else
            {
                ExpiryDateVoucher = date;
            }
        }

        private void TbNumberInit_TextChanged(object sender, EventArgs e)
        {
            TextBox txtb = (TextBox)sender;
            try
            {

                if (txtb.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Đây là thông tin bắt buộc");
                }
                else
                {
                    NumberInitVoucher = int.Parse(txtb.Text, System.Globalization.NumberStyles.AllowThousands);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng chỉ nhập số nguyên dương");
            }
            catch (OverflowException)
            {
                MessageBox.Show(string.Format("Vui lòng nhập giá trị từ 0 đến {0}", int.MaxValue.ToString("N0")));
            }
        }

        private void TbValue_TextChanged(object sender, EventArgs e)
        {
            TextBox txtb = (TextBox)sender;
            try
            {

                if (txtb.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Đây là thông tin bắt buộc");
                }
                else
                {
                    ValueVoucher = int.Parse(txtb.Text, System.Globalization.NumberStyles.AllowThousands);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng chỉ nhập số nguyên dương");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Vui lòng nhập giá trị từ 0 đến 100", int.MaxValue.ToString("N0"));
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            VoucherInfo info = new VoucherInfo();
            try
            {
                if (string.IsNullOrEmpty(CodeVoucher))
                {
                    MessageBox.Show("Không được để trống mã giảm giá");
                    return;
                }
                info.Code = CodeVoucher;
                info.ExpiryDate = expiryDateVoucher;
                info.NumberInit = info.NumberRemain = numberInitVoucher;
                info.Value = valueVoucher;
            }
            catch(FormatException f)
            {
                MessageBox.Show("Lỗi không được ghi chữ hoặc ký tự đặc biệt vào ô số");
                return;
            }
            catch(OverflowException f)
            {
                MessageBox.Show(string.Format("Vui lòng nhập giá trị từ 0 đến {0}", int.MaxValue.ToString("N0")));
            }
            AddVoucher(this, info);
            this.Close();
        }
    }
}
