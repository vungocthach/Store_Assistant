
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, "10,0");
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.namePD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberPD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.revenue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.cbbStatiticsMode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupChart = new System.Windows.Forms.GroupBox();
            this.cbbChartMode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pageSelector1 = new StoreAssitant.StoreAssistant_HistoryView.PageSelector();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupChart.SuspendLayout();
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
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.splitContainer1.Panel1.Controls.Add(this.pageSelector1);
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1MinSize = 400;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.groupChart);
            this.splitContainer1.Panel2MinSize = 400;
            this.splitContainer1.Size = new System.Drawing.Size(1080, 500);
            this.splitContainer1.SplitterDistance = 513;
            this.splitContainer1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.namePD,
            this.numberPD,
            this.revenue});
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.Location = new System.Drawing.Point(4, 77);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(505, 376);
            this.dataGridView1.TabIndex = 6;
            // 
            // namePD
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.namePD.DefaultCellStyle = dataGridViewCellStyle17;
            this.namePD.DividerWidth = 2;
            this.namePD.HeaderText = "STT";
            this.namePD.MinimumWidth = 80;
            this.namePD.Name = "namePD";
            this.namePD.ReadOnly = true;
            this.namePD.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // numberPD
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.numberPD.DefaultCellStyle = dataGridViewCellStyle18;
            this.numberPD.DividerWidth = 2;
            this.numberPD.HeaderText = "Thời Gian";
            this.numberPD.MinimumWidth = 150;
            this.numberPD.Name = "numberPD";
            this.numberPD.ReadOnly = true;
            this.numberPD.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // revenue
            // 
            this.revenue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.revenue.DefaultCellStyle = dataGridViewCellStyle19;
            this.revenue.DividerWidth = 2;
            this.revenue.HeaderText = "Tổng Doanh Thu";
            this.revenue.MinimumWidth = 130;
            this.revenue.Name = "revenue";
            this.revenue.ReadOnly = true;
            this.revenue.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.btnFilter);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbbStatiticsMode);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(331, 63);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách";
            // 
            // btnFilter
            // 
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnFilter.Location = new System.Drawing.Point(277, 21);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(48, 29);
            this.btnFilter.TabIndex = 9;
            this.btnFilter.Text = "Lọc";
            this.btnFilter.UseVisualStyleBackColor = true;
            // 
            // cbbStatiticsMode
            // 
            this.cbbStatiticsMode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbbStatiticsMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbStatiticsMode.Items.AddRange(new object[] {
            "Tháng",
            "Năm"});
            this.cbbStatiticsMode.Location = new System.Drawing.Point(123, 28);
            this.cbbStatiticsMode.Name = "cbbStatiticsMode";
            this.cbbStatiticsMode.Size = new System.Drawing.Size(116, 26);
            this.cbbStatiticsMode.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Đơn vị xem :";
            // 
            // groupChart
            // 
            this.groupChart.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupChart.Controls.Add(this.label1);
            this.groupChart.Controls.Add(this.chart1);
            this.groupChart.Controls.Add(this.cbbChartMode);
            this.groupChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupChart.Location = new System.Drawing.Point(0, 0);
            this.groupChart.Name = "groupChart";
            this.groupChart.Size = new System.Drawing.Size(563, 500);
            this.groupChart.TabIndex = 0;
            this.groupChart.TabStop = false;
            this.groupChart.Text = "Biểu Đồ";
            // 
            // cbbChartMode
            // 
            this.cbbChartMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbChartMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbChartMode.Items.AddRange(new object[] {
            "Chung",
            "Chi Tiết"});
            this.cbbChartMode.Location = new System.Drawing.Point(446, 21);
            this.cbbChartMode.Name = "cbbChartMode";
            this.cbbChartMode.Size = new System.Drawing.Size(93, 26);
            this.cbbChartMode.TabIndex = 9;
            this.cbbChartMode.SelectedIndexChanged += new System.EventHandler(this.cbbChartMode_SelectedIndexChanged_1);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(392, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Kiểu :";
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            chartArea5.Name = "ChartArea1";
            chartArea6.Name = "ChartArea2";
            this.chart1.ChartAreas.Add(chartArea5);
            this.chart1.ChartAreas.Add(chartArea6);
            legend5.Enabled = false;
            legend5.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend5.Name = "Legend1";
            legend5.Title = "ádasd";
            legend6.Name = "Legend2";
            legend6.Title = "Tên";
            this.chart1.Legends.Add(legend5);
            this.chart1.Legends.Add(legend6);
            this.chart1.Location = new System.Drawing.Point(5, 49);
            this.chart1.Margin = new System.Windows.Forms.Padding(5, 2, 5, 5);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series7.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series7.ChartArea = "ChartArea1";
            series7.CustomProperties = "DrawingStyle=Cylinder";
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            dataPoint3.LegendText = "hi";
            series7.Points.Add(dataPoint3);
            series7.XValueMember = "1";
            series7.YValuesPerPoint = 2;
            series8.ChartArea = "ChartArea2";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series8.Legend = "Legend2";
            series8.Name = "Series2";
            series9.ChartArea = "ChartArea2";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series9.Legend = "Legend1";
            series9.Name = "Series3";
            this.chart1.Series.Add(series7);
            this.chart1.Series.Add(series8);
            this.chart1.Series.Add(series9);
            this.chart1.Size = new System.Drawing.Size(553, 443);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // pageSelector1
            // 
            this.pageSelector1.BackColor = System.Drawing.Color.Transparent;
            this.pageSelector1.ButtonFirstMargin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.pageSelector1.ButtonLastMargin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.pageSelector1.ButtonNextMargin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.pageSelector1.ButtonPreviousMargin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.pageSelector1.Location = new System.Drawing.Point(146, 460);
            this.pageSelector1.MaximumRange = 10;
            this.pageSelector1.Name = "pageSelector1";
            this.pageSelector1.PageBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pageSelector1.PageBoxMargin = new System.Windows.Forms.Padding(3);
            this.pageSelector1.PageBoxSize = new System.Drawing.Size(100, 26);
            this.pageSelector1.SelectedIndex = 1;
            this.pageSelector1.Size = new System.Drawing.Size(210, 34);
            this.pageSelector1.TabIndex = 0;
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupChart.ResumeLayout(false);
            this.groupChart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private StoreAssistant_HistoryView.PageSelector pageSelector1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataGridViewTextBoxColumn namePD;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberPD;
        private System.Windows.Forms.DataGridViewTextBoxColumn revenue;
        private System.Windows.Forms.ComboBox cbbStatiticsMode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.ComboBox cbbChartMode;
        private System.Windows.Forms.Label label1;
    }
}
