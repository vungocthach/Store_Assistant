using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreAssitant.StoreAssistant_HistoryView
{
    public partial class HistoryView : UserControl
    {
        double[] columnWeights;
        public double[] ColumnsWeights { get => columnWeights;
            set
            {
                columnWeights = value;

                AutoSizeColumns();
                Invalidate();
            }
        }
        public HistoryView()
        {
            InitializeComponent();

            dataGridView1.Location = new Point(dataGridView1.Margin.Left, groupBox1.Location.Y + groupBox1.Height + groupBox1.Margin.Bottom + dataGridView1.Margin.Top);
            columnWeights = new double[] { 0.99d / 13, 3.0d / 13, 3.0d / 13, 3.0d / 13, 3.0d / 13 };
            AutoSizeColumns();

            this.SizeChanged += HistoryView_SizeChanged;
        }

        private void HistoryView_SizeChanged(object sender, EventArgs e)
        {
            pageSelector1.Location = new Point((this.Width - pageSelector1.Width) / 2, this.Height - pageSelector1.Margin.Top - pageSelector1.Margin.Bottom - pageSelector1.Height);
            dataGridView1.Height = pageSelector1.Location.Y - dataGridView1.Location.Y - pageSelector1.Margin.Top - dataGridView1.Margin.Bottom;
            dataGridView1.Width = this.Width - dataGridView1.Margin.Left - dataGridView1.Margin.Right;
            AutoSizeColumns();
        }

        void AutoSizeColumns()
        {
            for (int i = 0; i < dataGridView1.Columns.Count; i++) { dataGridView1.Columns[i].Width = (int)(dataGridView1.Width * columnWeights[i]); }
        }

        DateTime GetStartTime()
        {
            return dtp_From.Value;
        }

        DateTime GetEndTime()
        {
            return dtp_To.Value;
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {

        }
    }
}
