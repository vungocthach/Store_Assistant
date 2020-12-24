namespace StoreAssitant
{
    partial class FormBill
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
            this.lbCashier_Form = new System.Windows.Forms.Label();
            this.btnCashier = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbPay = new System.Windows.Forms.Label();
            this.lbTableName = new System.Windows.Forms.Label();
            this.lbDate = new System.Windows.Forms.Label();
            this.tlpProduct = new System.Windows.Forms.TableLayoutPanel();
            this.lbSTT = new System.Windows.Forms.Label();
            this.lbNumber = new System.Windows.Forms.Label();
            this.lbSinglePrice = new System.Windows.Forms.Label();
            this.lbSumPrice = new System.Windows.Forms.Label();
            this.lbNameProduct = new System.Windows.Forms.Label();
            this.lbNameStore = new System.Windows.Forms.Label();
            this.tlpPayMoney = new System.Windows.Forms.TableLayoutPanel();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lbPrice_Bill = new System.Windows.Forms.Label();
            this.lbSale = new System.Windows.Forms.Label();
            this.lbMoney_Customer = new System.Windows.Forms.Label();
            this.lbExchange = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tlpProduct.SuspendLayout();
            this.tlpPayMoney.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbCashier_Form
            // 
            this.lbCashier_Form.AutoSize = true;
            this.lbCashier_Form.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbCashier_Form.Location = new System.Drawing.Point(171, 51);
            this.lbCashier_Form.Name = "lbCashier_Form";
            this.lbCashier_Form.Size = new System.Drawing.Size(189, 20);
            this.lbCashier_Form.TabIndex = 0;
            this.lbCashier_Form.Text = "HÓA ĐƠN THANH TOÁN";
            // 
            // btnCashier
            // 
            this.btnCashier.AutoSize = true;
            this.btnCashier.BackColor = System.Drawing.Color.Tomato;
            this.btnCashier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCashier.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnCashier.Location = new System.Drawing.Point(327, 516);
            this.btnCashier.Name = "btnCashier";
            this.btnCashier.Size = new System.Drawing.Size(94, 30);
            this.btnCashier.TabIndex = 1;
            this.btnCashier.Text = "Thanh toán";
            this.btnCashier.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnCancel.Location = new System.Drawing.Point(445, 516);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // lbPay
            // 
            this.lbPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPay.AutoSize = true;
            this.lbPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPay.Location = new System.Drawing.Point(5, 59);
            this.lbPay.Name = "lbPay";
            this.lbPay.Size = new System.Drawing.Size(333, 18);
            this.lbPay.TabIndex = 4;
            this.lbPay.Text = "Thanh toán";
            // 
            // lbTableName
            // 
            this.lbTableName.AutoSize = true;
            this.lbTableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTableName.Location = new System.Drawing.Point(51, 81);
            this.lbTableName.Name = "lbTableName";
            this.lbTableName.Size = new System.Drawing.Size(42, 20);
            this.lbTableName.TabIndex = 6;
            this.lbTableName.Text = "Bàn:";
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDate.Location = new System.Drawing.Point(293, 81);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(77, 20);
            this.lbDate.TabIndex = 7;
            this.lbDate.Text = "Thời gian:";
            // 
            // tlpProduct
            // 
            this.tlpProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpProduct.AutoScroll = true;
            this.tlpProduct.AutoScrollMargin = new System.Drawing.Size(1, 0);
            this.tlpProduct.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpProduct.ColumnCount = 5;
            this.tlpProduct.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpProduct.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpProduct.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpProduct.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpProduct.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpProduct.Controls.Add(this.lbSTT, 0, 0);
            this.tlpProduct.Controls.Add(this.lbNumber, 2, 0);
            this.tlpProduct.Controls.Add(this.lbSinglePrice, 3, 0);
            this.tlpProduct.Controls.Add(this.lbSumPrice, 4, 0);
            this.tlpProduct.Controls.Add(this.lbNameProduct, 1, 0);
            this.tlpProduct.Location = new System.Drawing.Point(27, 119);
            this.tlpProduct.Name = "tlpProduct";
            this.tlpProduct.RowCount = 2;
            this.tlpProduct.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpProduct.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpProduct.Size = new System.Drawing.Size(500, 240);
            this.tlpProduct.TabIndex = 8;
            // 
            // lbSTT
            // 
            this.lbSTT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSTT.AutoSize = true;
            this.lbSTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSTT.Location = new System.Drawing.Point(5, 9);
            this.lbSTT.Name = "lbSTT";
            this.lbSTT.Size = new System.Drawing.Size(39, 16);
            this.lbSTT.TabIndex = 0;
            this.lbSTT.Text = "STT";
            this.lbSTT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbNumber
            // 
            this.lbNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNumber.AutoSize = true;
            this.lbNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumber.Location = new System.Drawing.Point(204, 9);
            this.lbNumber.Name = "lbNumber";
            this.lbNumber.Size = new System.Drawing.Size(34, 16);
            this.lbNumber.TabIndex = 2;
            this.lbNumber.Text = "SL";
            this.lbNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSinglePrice
            // 
            this.lbSinglePrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSinglePrice.AutoSize = true;
            this.lbSinglePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSinglePrice.Location = new System.Drawing.Point(246, 9);
            this.lbSinglePrice.Name = "lbSinglePrice";
            this.lbSinglePrice.Size = new System.Drawing.Size(94, 16);
            this.lbSinglePrice.TabIndex = 3;
            this.lbSinglePrice.Text = "Đơn giá";
            this.lbSinglePrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSumPrice
            // 
            this.lbSumPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSumPrice.AutoSize = true;
            this.lbSumPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSumPrice.Location = new System.Drawing.Point(348, 9);
            this.lbSumPrice.Name = "lbSumPrice";
            this.lbSumPrice.Size = new System.Drawing.Size(147, 16);
            this.lbSumPrice.TabIndex = 4;
            this.lbSumPrice.Text = "Thành tiền";
            this.lbSumPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbNameProduct
            // 
            this.lbNameProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNameProduct.AutoSize = true;
            this.lbNameProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNameProduct.Location = new System.Drawing.Point(52, 9);
            this.lbNameProduct.Name = "lbNameProduct";
            this.lbNameProduct.Size = new System.Drawing.Size(144, 16);
            this.lbNameProduct.TabIndex = 1;
            this.lbNameProduct.Text = "Tên món";
            this.lbNameProduct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbNameStore
            // 
            this.lbNameStore.AutoSize = true;
            this.lbNameStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNameStore.Location = new System.Drawing.Point(191, 9);
            this.lbNameStore.Name = "lbNameStore";
            this.lbNameStore.Size = new System.Drawing.Size(163, 31);
            this.lbNameStore.TabIndex = 5;
            this.lbNameStore.Text = "NTB QUÁN";
            // 
            // tlpPayMoney
            // 
            this.tlpPayMoney.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpPayMoney.ColumnCount = 2;
            this.tlpPayMoney.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPayMoney.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.tlpPayMoney.Controls.Add(this.textBox5, 1, 4);
            this.tlpPayMoney.Controls.Add(this.textBox4, 1, 3);
            this.tlpPayMoney.Controls.Add(this.textBox3, 1, 2);
            this.tlpPayMoney.Controls.Add(this.textBox2, 1, 1);
            this.tlpPayMoney.Controls.Add(this.lbPay, 0, 2);
            this.tlpPayMoney.Controls.Add(this.lbPrice_Bill, 0, 0);
            this.tlpPayMoney.Controls.Add(this.lbSale, 0, 1);
            this.tlpPayMoney.Controls.Add(this.lbMoney_Customer, 0, 3);
            this.tlpPayMoney.Controls.Add(this.lbExchange, 0, 4);
            this.tlpPayMoney.Controls.Add(this.textBox1, 1, 0);
            this.tlpPayMoney.Location = new System.Drawing.Point(27, 366);
            this.tlpPayMoney.Name = "tlpPayMoney";
            this.tlpPayMoney.RowCount = 5;
            this.tlpPayMoney.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpPayMoney.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpPayMoney.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpPayMoney.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpPayMoney.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpPayMoney.Size = new System.Drawing.Size(500, 145);
            this.tlpPayMoney.TabIndex = 9;
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.BackColor = System.Drawing.SystemColors.Control;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(346, 119);
            this.textBox5.MaxLength = 10000000;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(149, 15);
            this.textBox5.TabIndex = 13;
            this.textBox5.Text = "0";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(346, 88);
            this.textBox4.MaxLength = 10000000;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(149, 15);
            this.textBox4.TabIndex = 12;
            this.textBox4.Text = "0";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(346, 61);
            this.textBox3.MaxLength = 10000000;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(149, 15);
            this.textBox3.TabIndex = 11;
            this.textBox3.Text = "0";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(346, 34);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(149, 15);
            this.textBox2.TabIndex = 10;
            this.textBox2.Text = "#######";
            // 
            // lbPrice_Bill
            // 
            this.lbPrice_Bill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPrice_Bill.AutoSize = true;
            this.lbPrice_Bill.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrice_Bill.Location = new System.Drawing.Point(5, 5);
            this.lbPrice_Bill.Name = "lbPrice_Bill";
            this.lbPrice_Bill.Size = new System.Drawing.Size(333, 18);
            this.lbPrice_Bill.TabIndex = 5;
            this.lbPrice_Bill.Text = "Tổng cộng";
            // 
            // lbSale
            // 
            this.lbSale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSale.AutoSize = true;
            this.lbSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSale.Location = new System.Drawing.Point(5, 32);
            this.lbSale.Name = "lbSale";
            this.lbSale.Size = new System.Drawing.Size(333, 18);
            this.lbSale.TabIndex = 6;
            this.lbSale.Text = "Mã giảm giá";
            // 
            // lbMoney_Customer
            // 
            this.lbMoney_Customer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMoney_Customer.AutoSize = true;
            this.lbMoney_Customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMoney_Customer.Location = new System.Drawing.Point(5, 86);
            this.lbMoney_Customer.Name = "lbMoney_Customer";
            this.lbMoney_Customer.Size = new System.Drawing.Size(333, 18);
            this.lbMoney_Customer.TabIndex = 7;
            this.lbMoney_Customer.Text = "Tiền khách đưa";
            // 
            // lbExchange
            // 
            this.lbExchange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbExchange.AutoSize = true;
            this.lbExchange.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExchange.Location = new System.Drawing.Point(5, 117);
            this.lbExchange.Name = "lbExchange";
            this.lbExchange.Size = new System.Drawing.Size(333, 18);
            this.lbExchange.TabIndex = 8;
            this.lbExchange.Text = "Tiền trả lại";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(346, 7);
            this.textBox1.MaxLength = 10000000;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(149, 15);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "0";
            // 
            // FormBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(552, 549);
            this.ControlBox = false;
            this.Controls.Add(this.tlpPayMoney);
            this.Controls.Add(this.tlpProduct);
            this.Controls.Add(this.lbDate);
            this.Controls.Add(this.lbTableName);
            this.Controls.Add(this.lbNameStore);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCashier);
            this.Controls.Add(this.lbCashier_Form);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormBill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thanh toán";
            this.tlpProduct.ResumeLayout(false);
            this.tlpProduct.PerformLayout();
            this.tlpPayMoney.ResumeLayout(false);
            this.tlpPayMoney.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCashier_Form;
        private System.Windows.Forms.Button btnCashier;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbPay;
        private System.Windows.Forms.Label lbTableName;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.TableLayoutPanel tlpProduct;
        private System.Windows.Forms.Label lbSTT;
        private System.Windows.Forms.Label lbNameProduct;
        private System.Windows.Forms.Label lbNumber;
        private System.Windows.Forms.Label lbSinglePrice;
        private System.Windows.Forms.Label lbSumPrice;
        private System.Windows.Forms.Label lbNameStore;
        private System.Windows.Forms.TableLayoutPanel tlpPayMoney;
        private System.Windows.Forms.Label lbPrice_Bill;
        private System.Windows.Forms.Label lbSale;
        private System.Windows.Forms.Label lbMoney_Customer;
        private System.Windows.Forms.Label lbExchange;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
    }
}