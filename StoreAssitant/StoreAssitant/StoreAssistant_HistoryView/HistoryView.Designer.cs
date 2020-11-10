namespace StoreAssitant.StoreAssistant_HistoryView
{
    partial class HistoryView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableParent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_From = new System.Windows.Forms.DateTimePicker();
            this.dtp_To = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.pageSelector1 = new StoreAssitant.StoreAssistant_HistoryView.PageSelector();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.order,
            this.billId,
            this.createTime,
            this.tableParent,
            this.total});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(3, 84);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1077, 371);
            this.dataGridView1.TabIndex = 0;
            // 
            // order
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.order.DefaultCellStyle = dataGridViewCellStyle3;
            this.order.DividerWidth = 2;
            this.order.FillWeight = 1F;
            this.order.HeaderText = "STT";
            this.order.MinimumWidth = 50;
            this.order.Name = "order";
            this.order.ReadOnly = true;
            this.order.Width = 80;
            // 
            // billId
            // 
            this.billId.DividerWidth = 2;
            this.billId.FillWeight = 3F;
            this.billId.HeaderText = "Mã Hóa Đơn";
            this.billId.MinimumWidth = 150;
            this.billId.Name = "billId";
            this.billId.ReadOnly = true;
            this.billId.Width = 150;
            // 
            // createTime
            // 
            this.createTime.DividerWidth = 2;
            this.createTime.FillWeight = 3F;
            this.createTime.HeaderText = "Ngày Thanh Toán";
            this.createTime.MinimumWidth = 200;
            this.createTime.Name = "createTime";
            this.createTime.ReadOnly = true;
            this.createTime.Width = 250;
            // 
            // tableParent
            // 
            this.tableParent.DividerWidth = 2;
            this.tableParent.FillWeight = 3F;
            this.tableParent.HeaderText = "Bàn Thanh Toán";
            this.tableParent.MinimumWidth = 200;
            this.tableParent.Name = "tableParent";
            this.tableParent.ReadOnly = true;
            this.tableParent.Width = 250;
            // 
            // total
            // 
            this.total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.total.DividerWidth = 2;
            this.total.FillWeight = 3F;
            this.total.HeaderText = "Tổng Cộng";
            this.total.MinimumWidth = 180;
            this.total.Name = "total";
            this.total.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Từ Ngày :";
            // 
            // dtp_From
            // 
            this.dtp_From.CustomFormat = "dd/MM/yyyy";
            this.dtp_From.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_From.Location = new System.Drawing.Point(124, 28);
            this.dtp_From.Name = "dtp_From";
            this.dtp_From.Size = new System.Drawing.Size(133, 29);
            this.dtp_From.TabIndex = 3;
            // 
            // dtp_To
            // 
            this.dtp_To.CustomFormat = "dd/MM/yyyy";
            this.dtp_To.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_To.Location = new System.Drawing.Point(384, 28);
            this.dtp_To.Name = "dtp_To";
            this.dtp_To.Size = new System.Drawing.Size(134, 29);
            this.dtp_To.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Đến Ngày :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtp_From);
            this.groupBox1.Controls.Add(this.dtp_To);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(526, 71);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thời Gian";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.btn_Search);
            this.groupBox2.Location = new System.Drawing.Point(547, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(530, 71);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm Kiếm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 29);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "Mã :";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.Location = new System.Drawing.Point(429, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 29);
            this.button1.TabIndex = 8;
            this.button1.Text = "Nâng Cao";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(70, 29);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(320, 26);
            this.textBox1.TabIndex = 7;
            // 
            // btn_Search
            // 
            this.btn_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Search.AutoSize = true;
            this.btn_Search.FlatAppearance.BorderSize = 0;
            this.btn_Search.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_Search.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Search.Image = global::StoreAssitant.Properties.Resources.iconfinder_sale_lineal_color_cnvrt_18_3827704;
            this.btn_Search.Location = new System.Drawing.Point(387, 27);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(45, 32);
            this.btn_Search.TabIndex = 6;
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // pageSelector1
            // 
            this.pageSelector1.BackColor = System.Drawing.Color.Transparent;
            this.pageSelector1.ButtonFirstMargin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.pageSelector1.ButtonLastMargin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.pageSelector1.ButtonNextMargin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.pageSelector1.ButtonPreviousMargin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.pageSelector1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pageSelector1.Location = new System.Drawing.Point(403, 459);
            this.pageSelector1.Name = "pageSelector1";
            this.pageSelector1.PageBoxFont = new System.Drawing.Font("Microsoft YaHei Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pageSelector1.PageBoxMargin = new System.Windows.Forms.Padding(3);
            this.pageSelector1.PageBoxSize = new System.Drawing.Size(100, 29);
            this.pageSelector1.SelectedIndex = 1;
            this.pageSelector1.Size = new System.Drawing.Size(251, 38);
            this.pageSelector1.TabIndex = 7;
            // 
            // HistoryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pageSelector1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HistoryView";
            this.Size = new System.Drawing.Size(1080, 500);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_From;
        private System.Windows.Forms.DateTimePicker dtp_To;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Search;
        private PageSelector pageSelector1;
        private System.Windows.Forms.DataGridViewTextBoxColumn order;
        private System.Windows.Forms.DataGridViewTextBoxColumn billId;
        private System.Windows.Forms.DataGridViewTextBoxColumn createTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableParent;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
    }
}
