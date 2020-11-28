namespace StoreAssitant.StoreAssistant_VoucherView
{
    partial class VoucherView
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.VoucherCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpiryDate = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewDateTimePickerColumn();
            this.NumberUse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VoucherCode,
            this.ExpiryDate,
            this.NumberUse,
            this.Value});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 81);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dataGridView1.Size = new System.Drawing.Size(752, 399);
            this.dataGridView1.TabIndex = 0;
            // 
            // VoucherCode
            // 
            this.VoucherCode.HeaderText = "Mã giảm giá";
            this.VoucherCode.Name = "VoucherCode";
            this.VoucherCode.ReadOnly = true;
            // 
            // ExpiryDate
            // 
            this.ExpiryDate.Checked = false;
            this.ExpiryDate.HeaderText = "Hạn sử dụng";
            this.ExpiryDate.Name = "ExpiryDate";
            this.ExpiryDate.ReadOnly = true;
            this.ExpiryDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ExpiryDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ExpiryDate.Width = 188;
            // 
            // NumberUse
            // 
            this.NumberUse.HeaderText = "Số lượng";
            this.NumberUse.Name = "NumberUse";
            this.NumberUse.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.HeaderText = "Giá trị";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            // 
            // VoucherView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Name = "VoucherView";
            this.Size = new System.Drawing.Size(752, 480);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn VoucherCode;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewDateTimePickerColumn ExpiryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberUse;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
    }
}
