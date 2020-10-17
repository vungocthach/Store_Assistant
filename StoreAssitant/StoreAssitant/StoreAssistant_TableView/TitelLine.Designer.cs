namespace StoreAssitant.StoreAssistant_TableView
{
    partial class TitelLine
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
            this.lbName = new System.Windows.Forms.Label();
            this.lbNumber = new System.Windows.Forms.Label();
            this.lbSinglePrice = new System.Windows.Forms.Label();
            this.lbTotalPrice = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbName.Location = new System.Drawing.Point(0, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(49, 21);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Tên món";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbNumber
            // 
            this.lbNumber.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbNumber.Location = new System.Drawing.Point(49, 0);
            this.lbNumber.Name = "lbNumber";
            this.lbNumber.Size = new System.Drawing.Size(49, 21);
            this.lbNumber.TabIndex = 1;
            this.lbNumber.Text = "Số lượng";
            this.lbNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbSinglePrice
            // 
            this.lbSinglePrice.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbSinglePrice.Location = new System.Drawing.Point(98, 0);
            this.lbSinglePrice.Name = "lbSinglePrice";
            this.lbSinglePrice.Size = new System.Drawing.Size(44, 21);
            this.lbSinglePrice.TabIndex = 2;
            this.lbSinglePrice.Text = "Đơn giá";
            this.lbSinglePrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTotalPrice
            // 
            this.lbTotalPrice.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbTotalPrice.Location = new System.Drawing.Point(142, 0);
            this.lbTotalPrice.Name = "lbTotalPrice";
            this.lbTotalPrice.Size = new System.Drawing.Size(58, 21);
            this.lbTotalPrice.TabIndex = 3;
            this.lbTotalPrice.Text = "Thành tiền";
            this.lbTotalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TitelLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbTotalPrice);
            this.Controls.Add(this.lbSinglePrice);
            this.Controls.Add(this.lbNumber);
            this.Controls.Add(this.lbName);
            this.Name = "TitelLine";
            this.Size = new System.Drawing.Size(211, 21);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbNumber;
        private System.Windows.Forms.Label lbSinglePrice;
        private System.Windows.Forms.Label lbTotalPrice;
    }
}
