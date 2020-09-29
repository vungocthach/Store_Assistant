namespace StoreAssitant
{
    partial class TitleControl
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
            this.labelImage = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelImage
            // 
            this.labelImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelImage.Image = global::StoreAssitant.Properties.Resources._120427285_648274679154155_8374726593261554204_n;
            this.labelImage.Location = new System.Drawing.Point(64, 27);
            this.labelImage.Name = "labelImage";
            this.labelImage.Size = new System.Drawing.Size(58, 38);
            this.labelImage.TabIndex = 2;
            // 
            // labelTitle
            // 
            this.labelTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelTitle.Location = new System.Drawing.Point(121, 27);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(212, 38);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "Menu";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TitleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelImage);
            this.Name = "TitleControl";
            this.Size = new System.Drawing.Size(390, 72);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelImage;
        private System.Windows.Forms.Label labelTitle;
    }
}
