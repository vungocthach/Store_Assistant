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
            this.textBoxPrice = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPrice.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.textBoxPrice.Location = new System.Drawing.Point(0, 159);
            this.textBoxPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(197, 23);
            this.textBoxPrice.TabIndex = 1;
            this.textBoxPrice.Text = "Giá";
            this.textBoxPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxName
            // 
            this.textBoxName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.textBoxName.Location = new System.Drawing.Point(0, 136);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(197, 23);
            this.textBoxName.TabIndex = 2;
            this.textBoxName.Text = "Tên";
            this.textBoxName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.textBoxName.Click += new System.EventHandler(this.textBoxName_Click_1);
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox.Image = global::StoreAssitant.Properties.Resources._120427285_648274679154155_8374726593261554204_n;
            this.pictureBox.InitialImage = global::StoreAssitant.Properties.Resources._120427285_648274679154155_8374726593261554204_n;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(246, 155);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // MenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxPrice);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MenuControl";
            this.Size = new System.Drawing.Size(197, 182);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label textBoxPrice;
        private System.Windows.Forms.PictureBox pictureBox;
        protected System.Windows.Forms.Label textBoxName;
    }
}
