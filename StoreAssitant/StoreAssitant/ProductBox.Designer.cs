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
            this.label1 = new System.Windows.Forms.Label();
            this.txtb_Name = new System.Windows.Forms.TextBox();
            this.txtb_Price = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtb_Tag = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtb_Description = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label_Image = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên sản phẩm :";
            // 
            // txtb_Name
            // 
            this.txtb_Name.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_Name.Location = new System.Drawing.Point(179, 194);
            this.txtb_Name.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtb_Name.Name = "txtb_Name";
            this.txtb_Name.Size = new System.Drawing.Size(272, 30);
            this.txtb_Name.TabIndex = 1;
            // 
            // txtb_Price
            // 
            this.txtb_Price.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_Price.Location = new System.Drawing.Point(179, 237);
            this.txtb_Price.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtb_Price.Name = "txtb_Price";
            this.txtb_Price.Size = new System.Drawing.Size(272, 30);
            this.txtb_Price.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Giá bán : ";
            // 
            // txtb_Tag
            // 
            this.txtb_Tag.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_Tag.Location = new System.Drawing.Point(179, 280);
            this.txtb_Tag.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtb_Tag.Name = "txtb_Tag";
            this.txtb_Tag.Size = new System.Drawing.Size(272, 30);
            this.txtb_Tag.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tag : ";
            // 
            // txtb_Description
            // 
            this.txtb_Description.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_Description.Location = new System.Drawing.Point(43, 364);
            this.txtb_Description.Multiline = true;
            this.txtb_Description.Name = "txtb_Description";
            this.txtb_Description.Size = new System.Drawing.Size(408, 210);
            this.txtb_Description.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(44, 330);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mô tả chi tiết:";
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
            // ProductBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_Image);
            this.Controls.Add(this.txtb_Description);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtb_Tag);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtb_Price);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtb_Name);
            this.Controls.Add(this.label1);
            this.Name = "ProductBox";
            this.Size = new System.Drawing.Size(500, 600);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtb_Name;
        private System.Windows.Forms.TextBox txtb_Price;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtb_Tag;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtb_Description;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_Image;
    }
}
