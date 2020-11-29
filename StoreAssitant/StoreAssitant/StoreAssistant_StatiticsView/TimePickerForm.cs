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
        public DateTime DateMin { get => dtp_From.Value; set => dtp_From.Value = value; }
        public DateTime DateMax { get => dtp_To.Value; set => dtp_To.Value = value; }

        public event EventHandler ClickedSubmitOK;

        public TimePickerForm()
        {
            InitializeComponent();

            ClickedSubmitOK = new EventHandler((s, e) => { });

            this.btnSubmit.Click += Button1_Click;
            this.btnDefault.Click += BtnDefault_Click;

            dtp_From.ValueChanged += Dtp_From_ValueChanged;
            dtp_To.ValueChanged += Dtp_To_ValueChanged;

            dtp_To.Value = DateTime.Today;
            dtp_From.Value = DateTime.Today.AddDays(-1);
        }

        private void Dtp_To_ValueChanged(object sender, EventArgs e)
        {
            dtp_From.MaxDate = dtp_To.Value;
        }

        private void Dtp_From_ValueChanged(object sender, EventArgs e)
        {
            dtp_To.MinDate = dtp_From.Value;
        }

        private void BtnDefault_Click(object sender, EventArgs e)
        {
            dtp_From.Value = DateTime.MinValue;
            dtp_To.Value = DateTime.Today;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ClickedSubmitOK(this, null);
        }
    }
}
