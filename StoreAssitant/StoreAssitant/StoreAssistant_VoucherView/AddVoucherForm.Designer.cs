namespace StoreAssitant.StoreAssistant_VoucherView
{
    partial class AddVoucherForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbCode = new System.Windows.Forms.Label();
            this.lbExpiryDate = new System.Windows.Forms.Label();
            this.lbNumberInit = new System.Windows.Forms.Label();
            this.lbValue = new System.Windows.Forms.Label();
            this.dtpExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.tbNumberInit = new System.Windows.Forms.TextBox();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbCode
            // 
            this.lbCode.AutoSize = true;
            this.lbCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCode.Location = new System.Drawing.Point(20, 29);
            this.lbCode.Name = "lbCode";
            this.lbCode.Size = new System.Drawing.Size(94, 20);
            this.lbCode.TabIndex = 0;
            this.lbCode.Text = "Mã giảm giá";
            // 
            // lbExpiryDate
            // 
            this.lbExpiryDate.AutoSize = true;
            this.lbExpiryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExpiryDate.Location = new System.Drawing.Point(20, 73);
            this.lbExpiryDate.Name = "lbExpiryDate";
            this.lbExpiryDate.Size = new System.Drawing.Size(100, 20);
            this.lbExpiryDate.TabIndex = 1;
            this.lbExpiryDate.Text = "Hạn sử dụng";
            // 
            // lbNumberInit
            // 
            this.lbNumberInit.AutoSize = true;
            this.lbNumberInit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumberInit.Location = new System.Drawing.Point(20, 119);
            this.lbNumberInit.Name = "lbNumberInit";
            this.lbNumberInit.Size = new System.Drawing.Size(172, 20);
            this.lbNumberInit.TabIndex = 2;
            this.lbNumberInit.Text = "Số lượng được sử dụng";
            // 
            // lbValue
            // 
            this.lbValue.AutoSize = true;
            this.lbValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbValue.Location = new System.Drawing.Point(20, 164);
            this.lbValue.Name = "lbValue";
            this.lbValue.Size = new System.Drawing.Size(79, 20);
            this.lbValue.TabIndex = 3;
            this.lbValue.Text = "Giá trị (%)";
            // 
            // dtpExpiryDate
            // 
            this.dtpExpiryDate.Location = new System.Drawing.Point(198, 73);
            this.dtpExpiryDate.Name = "dtpExpiryDate";
            this.dtpExpiryDate.Size = new System.Drawing.Size(200, 20);
            this.dtpExpiryDate.TabIndex = 5;
            this.dtpExpiryDate.Tag = "";
            this.dtpExpiryDate.Value = new System.DateTime(2020, 11, 29, 14, 26, 44, 0);
            // 
            // tbCode
            // 
            this.tbCode.Location = new System.Drawing.Point(198, 28);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(200, 20);
            this.tbCode.TabIndex = 6;
            this.tbCode.Tag = "";
            // 
            // tbNumberInit
            // 
            this.tbNumberInit.Location = new System.Drawing.Point(198, 118);
            this.tbNumberInit.Name = "tbNumberInit";
            this.tbNumberInit.Size = new System.Drawing.Size(200, 20);
            this.tbNumberInit.TabIndex = 7;
            this.tbNumberInit.Tag = "";
            this.tbNumberInit.Text = "0";
            // 
            // tbValue
            // 
            this.tbValue.Location = new System.Drawing.Point(198, 164);
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(200, 20);
            this.tbValue.TabIndex = 8;
            this.tbValue.Tag = "";
            this.tbValue.Text = "0";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(222, 209);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(90, 30);
            this.btnConfirm.TabIndex = 9;
            this.btnConfirm.Text = "Xác nhận";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(338, 209);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // AddVoucherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 263);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.tbValue);
            this.Controls.Add(this.tbNumberInit);
            this.Controls.Add(this.tbCode);
            this.Controls.Add(this.dtpExpiryDate);
            this.Controls.Add(this.lbValue);
            this.Controls.Add(this.lbNumberInit);
            this.Controls.Add(this.lbExpiryDate);
            this.Controls.Add(this.lbCode);
            this.Name = "AddVoucherForm";
            this.Text = "Thêm chương trình giảm giá";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCode;
        private System.Windows.Forms.Label lbExpiryDate;
        private System.Windows.Forms.Label lbNumberInit;
        private System.Windows.Forms.Label lbValue;
        private System.Windows.Forms.DateTimePicker dtpExpiryDate;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.TextBox tbNumberInit;
        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
    }
}