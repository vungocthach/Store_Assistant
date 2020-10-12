namespace StoreAssitant
{
    partial class AddProductForm
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
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.productBox1 = new StoreAssitant.ProductBox();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.Location = new System.Drawing.Point(274, 506);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(118, 31);
            this.btn_Cancel.TabIndex = 4;
            this.btn_Cancel.Text = "Hủy";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // btn_Submit
            // 
            this.btn_Submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Submit.Location = new System.Drawing.Point(98, 506);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(118, 31);
            this.btn_Submit.TabIndex = 3;
            this.btn_Submit.Text = "Xác nhận";
            this.btn_Submit.UseVisualStyleBackColor = true;
            // 
            // productBox1
            // 
            this.productBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.productBox1.Location = new System.Drawing.Point(0, 0);
            this.productBox1.MinimumSize = new System.Drawing.Size(400, 500);
            this.productBox1.Name = "productBox1";
            this.productBox1.PDDescription = "";
            this.productBox1.PDImage = null;
            this.productBox1.PDName = "";
            this.productBox1.PDPrice = 1200;
            this.productBox1.Size = new System.Drawing.Size(489, 500);
            this.productBox1.TabIndex = 5;
            // 
            // AddProductForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(489, 546);
            this.ControlBox = false;
            this.Controls.Add(this.productBox1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Submit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddProductForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm mặt hàng";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Submit;
        private ProductBox productBox1;
    }
}