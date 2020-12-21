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
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Cancel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btn_Cancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Cancel.Location = new System.Drawing.Point(187, 412);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(118, 31);
            this.btn_Cancel.TabIndex = 4;
            this.btn_Cancel.Text = "Hủy";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            // 
            // btn_Submit
            // 
            this.btn_Submit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Submit.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btn_Submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btn_Submit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Submit.Location = new System.Drawing.Point(40, 411);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(118, 31);
            this.btn_Submit.TabIndex = 3;
            this.btn_Submit.Text = "Xác nhận";
            this.btn_Submit.UseVisualStyleBackColor = false;
            // 
            // productBox1
            // 
            this.productBox1.BackColor = System.Drawing.Color.White;
            this.productBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.productBox1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.productBox1.IsReadOnlyPDName = false;
            this.productBox1.IsReadOnlyPDPrice = false;
            this.productBox1.Location = new System.Drawing.Point(0, 0);
            this.productBox1.Margin = new System.Windows.Forms.Padding(2);
            this.productBox1.MinimumSize = new System.Drawing.Size(300, 400);
            this.productBox1.Name = "productBox1";
            this.productBox1.PDDescription = "";
            this.productBox1.PDImage = null;
            this.productBox1.PDName = "";
            this.productBox1.PDPrice = 0;
            this.productBox1.Size = new System.Drawing.Size(338, 407);
            this.productBox1.TabIndex = 5;
            // 
            // AddProductForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(338, 449);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.productBox1);
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