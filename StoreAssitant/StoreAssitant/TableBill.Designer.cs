namespace StoreAssitant
{
    partial class TableBill
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
            this.tableTitle_pnl = new System.Windows.Forms.Panel();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.tableIcon_pnl = new System.Windows.Forms.Panel();
            this.tableTitle_lb = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.STT_column = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Name_Column = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SinglePrice_Column = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Number_Column = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TotalPrice_Column = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableTitle_pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableTitle_pnl
            // 
            this.tableTitle_pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableTitle_pnl.Controls.Add(this.btn_Cancel);
            this.tableTitle_pnl.Controls.Add(this.tableIcon_pnl);
            this.tableTitle_pnl.Controls.Add(this.tableTitle_lb);
            this.tableTitle_pnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableTitle_pnl.Location = new System.Drawing.Point(0, 0);
            this.tableTitle_pnl.Margin = new System.Windows.Forms.Padding(2);
            this.tableTitle_pnl.Name = "tableTitle_pnl";
            this.tableTitle_pnl.Size = new System.Drawing.Size(420, 50);
            this.tableTitle_pnl.TabIndex = 4;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.AutoSize = true;
            this.btn_Cancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_Cancel.BackColor = System.Drawing.Color.Red;
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(395, 26);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(24, 23);
            this.btn_Cancel.TabIndex = 5;
            this.btn_Cancel.Text = "X";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // tableIcon_pnl
            // 
            this.tableIcon_pnl.BackgroundImage = global::StoreAssitant.Properties.Resources.thu_ngân;
            this.tableIcon_pnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableIcon_pnl.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableIcon_pnl.Location = new System.Drawing.Point(0, 0);
            this.tableIcon_pnl.Margin = new System.Windows.Forms.Padding(2);
            this.tableIcon_pnl.Name = "tableIcon_pnl";
            this.tableIcon_pnl.Size = new System.Drawing.Size(50, 48);
            this.tableIcon_pnl.TabIndex = 3;
            // 
            // tableTitle_lb
            // 
            this.tableTitle_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableTitle_lb.Location = new System.Drawing.Point(73, 7);
            this.tableTitle_lb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tableTitle_lb.Name = "tableTitle_lb";
            this.tableTitle_lb.Size = new System.Drawing.Size(287, 35);
            this.tableTitle_lb.TabIndex = 2;
            this.tableTitle_lb.Text = "BÀN";
            this.tableTitle_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.STT_column,
            this.Name_Column,
            this.SinglePrice_Column,
            this.Number_Column,
            this.TotalPrice_Column});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 54);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(420, 516);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // STT_column
            // 
            this.STT_column.Text = "STT";
            this.STT_column.Width = 35;
            // 
            // Name_Column
            // 
            this.Name_Column.Text = "Tên món";
            this.Name_Column.Width = 168;
            // 
            // SinglePrice_Column
            // 
            this.SinglePrice_Column.Text = "Đơn giá";
            this.SinglePrice_Column.Width = 69;
            // 
            // Number_Column
            // 
            this.Number_Column.Text = "Số lượng";
            this.Number_Column.Width = 54;
            // 
            // TotalPrice_Column
            // 
            this.TotalPrice_Column.Text = "Thành tiền";
            this.TotalPrice_Column.Width = 101;
            // 
            // TableBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.tableTitle_pnl);
            this.Name = "TableBill";
            this.Size = new System.Drawing.Size(420, 570);
            this.tableTitle_pnl.ResumeLayout(false);
            this.tableTitle_pnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel tableTitle_pnl;
        private System.Windows.Forms.Panel tableIcon_pnl;
        private System.Windows.Forms.Label tableTitle_lb;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader STT_column;
        private System.Windows.Forms.ColumnHeader Name_Column;
        private System.Windows.Forms.ColumnHeader SinglePrice_Column;
        private System.Windows.Forms.ColumnHeader Number_Column;
        private System.Windows.Forms.ColumnHeader TotalPrice_Column;
        private System.Windows.Forms.Button btn_Cancel;
    }
}
