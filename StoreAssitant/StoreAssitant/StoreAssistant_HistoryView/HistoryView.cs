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
            columnWeights = new double[] { 1.0d / 13, 3.0d / 13, 3.0d / 13, 3.0d / 13, 3.0d / 13 };
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
    }
}
