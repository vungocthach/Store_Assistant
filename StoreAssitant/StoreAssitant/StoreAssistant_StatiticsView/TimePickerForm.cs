using StoreAssitant.StoreAssistant_Helper;
using StoreAssitant.StoreAssistant_VoucherView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreAssitant.StoreAssistant_StatiticsView
{
    public partial class TimePickerForm : Form
    {
        string Lang ="vn";
        string ChosseTime = "Chọn thời gian";
        public DateTime DateMin { get => dtp_From.Value; set => dtp_From.Value = value; }
        public DateTime DateMax { get => dtp_To.Value; set => dtp_To.Value = value; }

        public event EventHandler ClickedSubmitOK;

        public TimePickerForm()
        {
            InitializeComponent();

            Language.ChangeLanguage += VoucherView_ChangeLanguage;
            if (Lang != AppManager.CurrentLanguage)
            {
                Lang = AppManager.CurrentLanguage;
                SetLanguage();
            }

            ClickedSubmitOK = new EventHandler((s, e) => { });

            this.btnSubmit.Click += Button1_Click;
            this.btnDefault.Click += BtnDefault_Click;

            dtp_From.ValueChanged += Dtp_From_ValueChanged;
            dtp_To.ValueChanged += Dtp_To_ValueChanged;

            BtnDefault_Click(btnDefault, null);
          
        }

        private void VoucherView_ChangeLanguage(object sender, string e)
        {
            SetLanguage();
        }

        private void SetLanguage()
        {
            Language.InitLanguage(this);
            label1.Text = Language.Rm.GetString("From:", Language.Culture);
            label2.Text = Language.Rm.GetString("To:", Language.Culture);
            btnSubmit.Text = Language.Rm.GetString("Confirm", Language.Culture);
            btnDefault.Text = Language.Rm.GetString("Default", Language.Culture);
            this.Text = Language.Rm.GetString("ChosseTime", Language.Culture);
        }
        private void Dtp_To_ValueChanged(object sender, EventArgs e)
        {
            dtp_From.MaxDate = dtp_To.Value.AddDays(-1);
        }

        private void Dtp_From_ValueChanged(object sender, EventArgs e)
        {
            dtp_To.MinDate = dtp_From.Value.AddDays(1);
        }

        private void BtnDefault_Click(object sender, EventArgs e)
        {
            //dtp_From.Value = DateTime.Today.AddYears(-1);
            dtp_From.Value = new DateTime(DateTime.Now.Year - 1, 1, 1);
            dtp_To.Value = new DateTime(DateTime.Now.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month), 23, 59, 59);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ClickedSubmitOK(this, null);
        }

        public void SetPickMode(int mode)
        {
            if (mode == 0)
            {
                /*label1.Text = "Từ Tháng:";
                label2.Text = "Đến Tháng:";*/
                dtp_From.Value = new DateTime(dtp_From.Value.Year, dtp_From.Value.Month, 1, 0, 0, 0);
                dtp_To.Value = new DateTime(dtp_To.Value.Year, dtp_To.Value.Month, 28, 23, 59, 59);
                dtp_From.CustomFormat = dtp_To.CustomFormat = "MM/yyyy";
                dtp_From.ShowUpDown = dtp_To.ShowUpDown = true;
            }
            else if (mode == 1)
            {
                /*label1.Text = "Từ Năm:";
                label2.Text = "Đến Năm:";*/
                dtp_From.Value = new DateTime(dtp_From.Value.Year, 1, 1, 0, 0, 0);
                dtp_To.Value = new DateTime(dtp_To.Value.Year, 12, 1, 23, 59, 59);
                dtp_From.CustomFormat = dtp_To.CustomFormat = "yyyy";
                dtp_From.ShowUpDown = dtp_To.ShowUpDown = true;
            }
        }
    }
}
