namespace StoreAssitant
{
    partial class ProductBox
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtb_Name = new System.Windows.Forms.TextBox();
            this.txtb_Price = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtb_Description = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label_Image = new System.Windows.Forms.Label();
            this.toolTip_Name = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_Price = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_Des = new System.Windows.Forms.ToolTip(this.components);
            this.pb_Err_Des = new System.Windows.Forms.PictureBox();
            this.pb_Err_Price = new System.Windows.Forms.PictureBox();
            this.pb_Err_Name = new System.Windows.Forms.PictureBox();
            this.lb_currency = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Err_Des)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Err_Price)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Err_Name)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên sản phẩm :";
            // 
            // txtb_Name
            // 
            this.txtb_Name.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_Name.Location = new System.Drawing.Point(138, 194);
            this.txtb_Name.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtb_Name.MaxLength = 50;
            this.txtb_Name.Name = "txtb_Name";
            this.txtb_Name.Size = new System.Drawing.Size(288, 30);
            this.txtb_Name.TabIndex = 1;
            // 
            // txtb_Price
            // 
            this.txtb_Price.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_Price.Location = new System.Drawing.Point(138, 237);
            this.txtb_Price.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtb_Price.MaxLength = 20;
            this.txtb_Price.Name = "txtb_Price";
            this.txtb_Price.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtb_Price.Size = new System.Drawing.Size(236, 30);
            this.txtb_Price.TabIndex = 3;
            this.txtb_Price.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Giá bán : ";
            // 
            // txtb_Description
            // 
            this.txtb_Description.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_Description.Location = new System.Drawing.Point(15, 315);
            this.txtb_Description.Multiline = true;
            this.txtb_Description.Name = "txtb_Description";
            this.txtb_Description.Size = new System.Drawing.Size(423, 191);
            this.txtb_Description.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mô tả chi tiết :";
            // 
            // label_Image
            // 
            this.label_Image.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Image.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Image.Location = new System.Drawing.Point(149, 22);
            this.label_Image.Name = "label_Image";
            this.label_Image.Size = new System.Drawing.Size(200, 150);
            this.label_Image.TabIndex = 8;
            this.label_Image.Text = "Thêm hình ảnh\r\n(+)";
            this.label_Image.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pb_Err_Des
            // 
            this.pb_Err_Des.Image = global::StoreAssitant.Properties.Resources.iconfinder_caution_1055096;
            this.pb_Err_Des.Location = new System.Drawing.Point(124, 273);
            this.pb_Err_Des.Name = "pb_Err_Des";
            this.pb_Err_Des.Size = new System.Drawing.Size(36, 36);
            this.pb_Err_Des.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb_Err_Des.TabIndex = 16;
            this.pb_Err_Des.TabStop = false;
            this.pb_Err_Des.Visible = false;
            // 
            // pb_Err_Price
            // 
            this.pb_Err_Price.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_Err_Price.Image = global::StoreAssitant.Properties.Resources.iconfinder_caution_1055096;
            this.pb_Err_Price.Location = new System.Drawing.Point(431, 231);
            this.pb_Err_Price.Name = "pb_Err_Price";
            this.pb_Err_Price.Size = new System.Drawing.Size(36, 36);
            this.pb_Err_Price.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb_Err_Price.TabIndex = 14;
            this.pb_Err_Price.TabStop = false;
            this.pb_Err_Price.Visible = false;
            // 
            // pb_Err_Name
            // 
            this.pb_Err_Name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_Err_Name.Image = global::StoreAssitant.Properties.Resources.iconfinder_caution_1055096;
            this.pb_Err_Name.Location = new System.Drawing.Point(430, 192);
            this.pb_Err_Name.Name = "pb_Err_Name";
            this.pb_Err_Name.Size = new System.Drawing.Size(36, 36);
            this.pb_Err_Name.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb_Err_Name.TabIndex = 13;
            this.pb_Err_Name.TabStop = false;
            this.pb_Err_Name.Visible = false;
            // 
            // lb_currency
            // 
            this.lb_currency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_currency.AutoSize = true;
            this.lb_currency.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_currency.Location = new System.Drawing.Point(380, 241);
            this.lb_currency.Name = "lb_currency";
            this.lb_currency.Size = new System.Drawing.Size(45, 20);
            this.lb_currency.TabIndex = 17;
            this.lb_currency.Text = "VND";
            // 
            // ProductBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pb_Err_Price);
            this.Controls.Add(this.lb_currency);
            this.Controls.Add(this.pb_Err_Des);
            this.Controls.Add(this.pb_Err_Name);
            this.Controls.Add(this.label_Image);
            this.Controls.Add(this.txtb_Description);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtb_Price);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtb_Name);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(400, 500);
            this.Name = "ProductBox";
            this.Size = new System.Drawing.Size(467, 511);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Err_Des)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Err_Price)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Err_Name)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtb_Name;
        private System.Windows.Forms.TextBox txtb_Price;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtb_Description;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_Image;
        private System.Windows.Forms.ToolTip toolTip_Name;
        private System.Windows.Forms.ToolTip toolTip_Price;
        private System.Windows.Forms.ToolTip toolTip_Des;
        private System.Windows.Forms.PictureBox pb_Err_Name;
        private System.Windows.Forms.PictureBox pb_Err_Price;
        private System.Windows.Forms.PictureBox pb_Err_Des;
        private System.Windows.Forms.Label lb_currency;
    }
}
