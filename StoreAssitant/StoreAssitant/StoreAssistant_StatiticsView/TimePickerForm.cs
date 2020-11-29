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
