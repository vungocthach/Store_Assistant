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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbCode
            // 
            this.lbCode.AutoSize = true;
            this.lbCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCode.Location = new System.Drawing.Point(20, 29);
            this.lbCode.Name = "lbCode";
            this.lbCode.Size = new System.Drawing.Size(105, 20);
            this.lbCode.TabIndex = 0;
            this.lbCode.Text = "Mã giảm giá";
            // 
            // lbExpiryDate
            // 
            this.lbExpiryDate.AutoSize = true;
            this.lbExpiryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExpiryDate.Location = new System.Drawing.Point(20, 73);
            this.lbExpiryDate.Name = "lbExpiryDate";
            this.lbExpiryDate.Size = new System.Drawing.Size(111, 20);
            this.lbExpiryDate.TabIndex = 1;
            this.lbExpiryDate.Text = "Hạn sử dụng";
            // 
            // lbNumberInit
            // 
            this.lbNumberInit.AutoSize = true;
            this.lbNumberInit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumberInit.Location = new System.Drawing.Point(20, 119);
            this.lbNumberInit.Name = "lbNumberInit";
            this.lbNumberInit.Size = new System.Drawing.Size(193, 20);
            this.lbNumberInit.TabIndex = 2;
            this.lbNumberInit.Text = "Số lượng được sử dụng";
            // 
            // lbValue
            // 
            this.lbValue.AutoSize = true;
            this.lbValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbValue.Location = new System.Drawing.Point(20, 164);
            this.lbValue.Name = "lbValue";
            this.lbValue.Size = new System.Drawing.Size(90, 20);
            this.lbValue.TabIndex = 3;
            this.lbValue.Text = "Giá trị (%)";
            // 
            // dtpExpiryDate
            // 
            this.dtpExpiryDate.CustomFormat = "dd/MM/yyyy  HH:mm:ss ";
            this.dtpExpiryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExpiryDate.Location = new System.Drawing.Point(223, 72);
            this.dtpExpiryDate.Name = "dtpExpiryDate";
            this.dtpExpiryDate.Size = new System.Drawing.Size(200, 26);
            this.dtpExpiryDate.TabIndex = 5;
            this.dtpExpiryDate.Tag = "";
            this.dtpExpiryDate.Value = new System.DateTime(2020, 11, 29, 14, 26, 44, 0);
            // 
            // tbCode
            // 
            this.tbCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCode.Location = new System.Drawing.Point(223, 30);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(200, 19);
            this.tbCode.TabIndex = 6;
            this.tbCode.Tag = "";
            // 
            // tbNumberInit
            // 
            this.tbNumberInit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbNumberInit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNumberInit.Location = new System.Drawing.Point(223, 117);
            this.tbNumberInit.Name = "tbNumberInit";
            this.tbNumberInit.Size = new System.Drawing.Size(200, 19);
            this.tbNumberInit.TabIndex = 7;
            this.tbNumberInit.Tag = "";
            this.tbNumberInit.Text = "0";
            // 
            // tbValue
            // 
            this.tbValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbValue.Location = new System.Drawing.Point(223, 163);
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(200, 19);
            this.tbValue.TabIndex = 8;
            this.tbValue.Tag = "";
            this.tbValue.Text = "0";
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.Orange;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnConfirm.Location = new System.Drawing.Point(222, 209);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(90, 30);
            this.btnConfirm.TabIndex = 9;
            this.btnConfirm.Text = "Xác nhận";
            this.btnConfirm.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Orange;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancel.Location = new System.Drawing.Point(338, 209);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label1.Location = new System.Drawing.Point(222, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "_________________________________________________________________________________" +
    "________________________________________________________________________";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label2.Location = new System.Drawing.Point(220, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "_________________________________________________________________________________" +
    "_____________________________________________________________________________";
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label3.Location = new System.Drawing.Point(223, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "_________________________________________________________________________________" +
    "________________________________________________________________________";
            // 
            // AddVoucherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(449, 263);
            this.ControlBox = false;
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
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Name = "AddVoucherForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THÊM MÃ GIẢM GIÁ";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}