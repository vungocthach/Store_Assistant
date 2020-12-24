
namespace StoreAssitant.StoreAssistant_StatiticsView
{
    partial class StatiticsView2
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatiticsView2));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, "10,0");
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFilter = new System.Windows.Forms.Button();
            this.lbConfig = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbStatiticsMode = new System.Windows.Forms.ComboBox();
            this.pageSelector1 = new StoreAssitant.StoreAssistant_HistoryView.PageSelector();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.namePD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberPD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.revenue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbbChartMode = new System.Windows.Forms.ComboBox();
            this.lbChart = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.pageSelector1);
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2MinSize = 400;
            this.splitContainer1.Size = new System.Drawing.Size(1080, 500);
            this.splitContainer1.SplitterDistance = 422;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnFilter);
            this.panel1.Controls.Add(this.lbConfig);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbbStatiticsMode);
            this.panel1.Location = new System.Drawing.Point(4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(414, 75);
            this.panel1.TabIndex = 11;
            // 
            // btnFilter
            // 
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnFilter.Location = new System.Drawing.Point(337, 35);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(72, 35);
            this.btnFilter.TabIndex = 9;
            this.btnFilter.Text = "Lọc";
            this.btnFilter.UseVisualStyleBackColor = true;
            // 
            // lbConfig
            // 
            this.lbConfig.BackColor = System.Drawing.Color.SkyBlue;
            this.lbConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbConfig.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConfig.Location = new System.Drawing.Point(0, 0);
            this.lbConfig.Name = "lbConfig";
            this.lbConfig.Size = new System.Drawing.Size(412, 32);
            this.lbConfig.TabIndex = 9;
            this.lbConfig.Text = " Thời Gian";
            this.lbConfig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Đơn vị xem :";
            // 
            // cbbStatiticsMode
            // 
            this.cbbStatiticsMode.BackColor = System.Drawing.Color.White;
            this.cbbStatiticsMode.Font = new System.Drawing.Font("Segoe UI Semibold", 13.25F);
            this.cbbStatiticsMode.ForeColor = System.Drawing.Color.Black;
            this.cbbStatiticsMode.Items.AddRange(new object[] {
            "Tháng",
            "Năm"});
            this.cbbStatiticsMode.Location = new System.Drawing.Point(147, 35);
            this.cbbStatiticsMode.Name = "cbbStatiticsMode";
            this.cbbStatiticsMode.Size = new System.Drawing.Size(186, 33);
            this.cbbStatiticsMode.TabIndex = 7;
            // 
            // pageSelector1
            // 
            this.pageSelector1.BackColor = System.Drawing.Color.Transparent;
            this.pageSelector1.ButtonFirstMargin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.pageSelector1.ButtonLastMargin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.pageSelector1.ButtonNextMargin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.pageSelector1.ButtonPreviousMargin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.pageSelector1.ImageFirst = ((System.Drawing.Bitmap)(resources.GetObject("pageSelector1.ImageFirst")));
            this.pageSelector1.ImageLast = ((System.Drawing.Bitmap)(resources.GetObject("pageSelector1.ImageLast")));
            this.pageSelector1.ImageNxt = ((System.Drawing.Bitmap)(resources.GetObject("pageSelector1.ImageNxt")));
            this.pageSelector1.ImagePre = ((System.Drawing.Bitmap)(resources.GetObject("pageSelector1.ImagePre")));
            this.pageSelector1.Location = new System.Drawing.Point(105, 463);
            this.pageSelector1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pageSelector1.MaximumRange = 10;
            this.pageSelector1.Name = "pageSelector1";
            this.pageSelector1.PageBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pageSelector1.PageBoxMargin = new System.Windows.Forms.Padding(3);
            this.pageSelector1.PageBoxSize = new System.Drawing.Size(100, 26);
            this.pageSelector1.SelectedIndex = 1;
            this.pageSelector1.Size = new System.Drawing.Size(210, 34);
            this.pageSelector1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.namePD,
            this.numberPD,
            this.revenue});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.Location = new System.Drawing.Point(4, 85);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(414, 375);
            this.dataGridView1.TabIndex = 6;
            // 
            // namePD
            // 
            this.namePD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.namePD.DefaultCellStyle = dataGridViewCellStyle3;
            this.namePD.DividerWidth = 2;
            this.namePD.HeaderText = "STT";
            this.namePD.MaxInputLength = 20;
            this.namePD.MinimumWidth = 80;
            this.namePD.Name = "namePD";
            this.namePD.ReadOnly = true;
            this.namePD.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.namePD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.namePD.Width = 80;
            // 
            // numberPD
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.numberPD.DefaultCellStyle = dataGridViewCellStyle4;
            this.numberPD.DividerWidth = 2;
            this.numberPD.HeaderText = "Thời Gian";
            this.numberPD.MinimumWidth = 150;
            this.numberPD.Name = "numberPD";
            this.numberPD.ReadOnly = true;
            this.numberPD.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.numberPD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // revenue
            // 
            this.revenue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.revenue.DefaultCellStyle = dataGridViewCellStyle5;
            this.revenue.DividerWidth = 2;
            this.revenue.HeaderText = "Tổng Doanh Thu";
            this.revenue.MinimumWidth = 130;
            this.revenue.Name = "revenue";
            this.revenue.ReadOnly = true;
            this.revenue.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.revenue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cbbChartMode);
            this.panel2.Controls.Add(this.lbChart);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.chart1);
            this.panel2.Location = new System.Drawing.Point(3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(648, 490);
            this.panel2.TabIndex = 12;
            // 
            // cbbChartMode
            // 
            this.cbbChartMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbChartMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbChartMode.Items.AddRange(new object[] {
            "Chung",
            "Chi Tiết"});
            this.cbbChartMode.Location = new System.Drawing.Point(550, 39);
            this.cbbChartMode.Name = "cbbChartMode";
            this.cbbChartMode.Size = new System.Drawing.Size(93, 26);
            this.cbbChartMode.TabIndex = 9;
            this.cbbChartMode.SelectedIndexChanged += new System.EventHandler(this.cbbChartMode_SelectedIndexChanged_1);
            // 
            // lbChart
            // 
            this.lbChart.BackColor = System.Drawing.Color.SkyBlue;
            this.lbChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbChart.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChart.Location = new System.Drawing.Point(0, 0);
            this.lbChart.Name = "lbChart";
            this.lbChart.Size = new System.Drawing.Size(646, 32);
            this.lbChart.TabIndex = 9;
            this.lbChart.Text = " Biểu Đồ";
            this.lbChart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(493, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Kiểu:";
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            chartArea2.Name = "ChartArea2";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.ChartAreas.Add(chartArea2);
            legend1.Enabled = false;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend1.Name = "Legend1";
            legend1.Title = "ádasd";
            legend2.Name = "Legend2";
            legend2.Title = "Tên";
            this.chart1.Legends.Add(legend1);
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(6, 70);
            this.chart1.Margin = new System.Windows.Forms.Padding(5, 2, 5, 5);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series1.ChartArea = "ChartArea1";
            series1.CustomProperties = "DrawingStyle=Cylinder";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            dataPoint1.LegendText = "hi";
            series1.Points.Add(dataPoint1);
            series1.XValueMember = "1";
            series1.YValuesPerPoint = 2;
            series2.ChartArea = "ChartArea2";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series2.Legend = "Legend2";
            series2.Name = "Series2";
            series3.ChartArea = "ChartArea2";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series3.Legend = "Legend1";
            series3.Name = "Series3";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(635, 413);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // StatiticsView2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "StatiticsView2";
            this.Size = new System.Drawing.Size(1080, 500);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private StoreAssistant_HistoryView.PageSelector pageSelector1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox cbbStatiticsMode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.ComboBox cbbChartMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbConfig;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbChart;
        private System.Windows.Forms.DataGridViewTextBoxColumn namePD;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberPD;
        private System.Windows.Forms.DataGridViewTextBoxColumn revenue;
    }
}
