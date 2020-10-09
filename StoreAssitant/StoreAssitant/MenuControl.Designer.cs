namespace StoreAssitant
{
    partial class MenuControl
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
            this.panelImage = new System.Windows.Forms.Panel();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // panelImage
            // 
            this.panelImage.Location = new System.Drawing.Point(1, 3);
            this.panelImage.Name = "panelImage";
            this.panelImage.Size = new System.Drawing.Size(148, 104);
            this.panelImage.TabIndex = 0;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Enabled = false;
            this.textBoxPrice.Location = new System.Drawing.Point(-1, 109);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(150, 20);
            this.textBoxPrice.TabIndex = 1;
            this.textBoxPrice.Tag = "";
            this.textBoxPrice.Text = "Giá";
            this.textBoxPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPrice.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // textBoxName
            // 
            this.textBoxName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxName.Location = new System.Drawing.Point(0, 130);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(150, 20);
            this.textBoxName.TabIndex = 2;
            this.textBoxName.Text = "Tên";
            this.textBoxName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // MenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.panelImage);
            this.Name = "MenuControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelImage;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.TextBox textBoxName;
    }
}
