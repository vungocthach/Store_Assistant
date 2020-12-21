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
        private string Lang = "vn";
        string PlusChar = "Vui lòng chỉ nhập số dương";
        string From0to10000 = "Vui lòng nhập giá trị trong khoảng 0 đến 10000";
        string From0to100 = "Vui lòng nhập giá trị trong khoảng 0 đến 100";
        string NoEmpty = "Không để trống";
        string BiggerNow = "Thời hạn phải lớn hơn ngày hiện tại";

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
                        MessageBox.Show(BiggerNow);
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

            if ( Lang != Language.CultureName)
            {
                Lang = Language.CultureName;
                SetLanguage();
            }    
        }

        private void SetLanguage()
        {
            Language.InitLanguage(this);
            lbCode.Text = Language.Rm.GetString("Voucher code", Language.Culture);
            lbExpiryDate.Text = Language.Rm.GetString("Expiry date", Language.Culture);
            lbNumberInit.Text = Language.Rm.GetString("Amount be used", Language.Culture);
            lbValue.Text = Language.Rm.GetString("Value(%)", Language.Culture);
            btnConfirm.Text = Language.Rm.GetString("Confirm", Language.Culture);
            btnCancel.Text = Language.Rm.GetString("Cancel", Language.Culture);
            this.Text = Language.Rm.GetString("AddVoucher", Language.Culture);
            PlusChar = Language.Rm.GetString("PlusChar", Language.Culture);
            From0to10000 = Language.Rm.GetString("From0to10000", Language.Culture);
            From0to100 = Language.Rm.GetString("From0to100 ", Language.Culture);
            NoEmpty = Language.Rm.GetString(" NoEmpty", Language.Culture);
            BiggerNow = Language.Rm.GetString("BiggerNow", Language.Culture);

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
                MessageBox.Show(PlusChar);
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
                        MessageBox.Show(From0to10000);
                    }
                    else if (NumberInitVoucher < 0)
                    {
                        NumberInitVoucher = 0;
                        MessageBox.Show(From0to10000);
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
                        MessageBox.Show(From0to100);
                    }
                    else if (ValueVoucher<0)
                    {
                        ValueVoucher = 0;
                        MessageBox.Show(From0to100);
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
                MessageBox.Show(NoEmpty);
                return;
            }
            if (valueVoucher == 0 || numberInitVoucher == 0)
            {
                MessageBox.Show(PlusChar);
                return;
            }
            if (expiryDateVoucher < DateTime.Now)
            {
                MessageBox.Show(BiggerNow);
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
