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
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelImage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.Color.Orange;
            this.labelTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTitle.Font = new System.Drawing.Font("Snap ITC", 24F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelTitle.Location = new System.Drawing.Point(58, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(329, 40);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "Menu";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelImage
            // 
            this.labelImage.BackColor = System.Drawing.Color.Orange;
            this.labelImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelImage.Image = global::StoreAssitant.Properties.Resources._120427285_648274679154155_8374726593261554204_n;
            this.labelImage.Location = new System.Drawing.Point(3, 0);
            this.labelImage.Name = "labelImage";
            this.labelImage.Size = new System.Drawing.Size(60, 40);
            this.labelImage.TabIndex = 2;
            // 
            // TitleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelImage);
            this.Name = "TitleControl";
            this.Size = new System.Drawing.Size(390, 42);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelImage;
        private System.Windows.Forms.Label labelTitle;
    }
}
