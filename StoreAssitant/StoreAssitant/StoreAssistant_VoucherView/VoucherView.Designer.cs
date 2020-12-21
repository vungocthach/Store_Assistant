﻿namespace StoreAssitant.StoreAssistant_VoucherView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.VoucherCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpiryDate = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewDateTimePickerColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberUse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.cbx_Language = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Snap ITC", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1122, 84);
            this.label1.TabIndex = 4;
            this.label1.Text = "MÃ GIẢM GIÁ CỦA BẠN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VoucherCode,
            this.ExpiryDate,
            this.Value,
            this.NumberUse,
            this.Remain});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(0, 84);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1125, 617);
            this.dataGridView1.TabIndex = 0;
            // 
            // VoucherCode
            // 
            this.VoucherCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.VoucherCode.DataPropertyName = "Code";
            this.VoucherCode.DividerWidth = 2;
            this.VoucherCode.HeaderText = "Mã giảm giá";
            this.VoucherCode.Name = "VoucherCode";
            this.VoucherCode.ReadOnly = true;
            // 
            // ExpiryDate
            // 
            this.ExpiryDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ExpiryDate.Checked = false;
            this.ExpiryDate.CustomFormat = "dd/MM/yyyy  HH:mm:ss";
            this.ExpiryDate.DataPropertyName = "ExpiryDate";
            dataGridViewCellStyle2.NullValue = null;
            this.ExpiryDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.ExpiryDate.DividerWidth = 2;
            this.ExpiryDate.FillWeight = 80F;
            this.ExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ExpiryDate.HeaderText = "Hạn sử dụng";
            this.ExpiryDate.MinDate = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            this.ExpiryDate.Name = "ExpiryDate";
            this.ExpiryDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ExpiryDate.Width = 268;
            // 
            // Value
            // 
            this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Value.DataPropertyName = "Value";
            this.Value.DividerWidth = 2;
            this.Value.HeaderText = "Giá trị (%)";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            // 
            // NumberUse
            // 
            this.NumberUse.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.NumberUse.DataPropertyName = "numberInit";
            this.NumberUse.DividerWidth = 2;
            this.NumberUse.HeaderText = "Số lượng";
            this.NumberUse.Name = "NumberUse";
            this.NumberUse.ReadOnly = true;
            this.NumberUse.Width = 99;
            // 
            // Remain
            // 
            this.Remain.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Remain.DataPropertyName = "numberRemain";
            this.Remain.DividerWidth = 2;
            this.Remain.HeaderText = "Còn lại";
            this.Remain.Name = "Remain";
            this.Remain.Width = 84;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdd.Location = new System.Drawing.Point(818, 725);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(104, 39);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRemove.Location = new System.Drawing.Point(950, 725);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(104, 39);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Xóa";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click_1);
            // 
            // cbx_Language
            // 
            this.cbx_Language.FormattingEnabled = true;
            this.cbx_Language.Items.AddRange(new object[] {
            "vn",
            "en"});
            this.cbx_Language.Location = new System.Drawing.Point(175, 34);
            this.cbx_Language.Name = "cbx_Language";
            this.cbx_Language.Size = new System.Drawing.Size(121, 28);
            this.cbx_Language.TabIndex = 5;
            // 
            // VoucherView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Orange;
            this.Controls.Add(this.cbx_Language);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(750, 462);
            this.Name = "VoucherView";
            this.Size = new System.Drawing.Size(1125, 769);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn VoucherCode;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewDateTimePickerColumn ExpiryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberUse;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remain;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ComboBox cbx_Language;
    }
}
