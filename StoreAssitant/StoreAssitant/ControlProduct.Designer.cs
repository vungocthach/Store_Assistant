namespace StoreAssitant
{
    partial class ControlProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlProduct));
            this.labelImage = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelImage
            // 
            this.labelImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelImage.Image = ((System.Drawing.Image)(resources.GetObject("labelImage.Image")));
            this.labelImage.Location = new System.Drawing.Point(4, 3);
            this.labelImage.MinimumSize = new System.Drawing.Size(146, 140);
            this.labelImage.Name = "labelImage";
            this.labelImage.Size = new System.Drawing.Size(146, 140);
            this.labelImage.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelImage);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(153, 143);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // ControlProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ControlProduct";
            this.Size = new System.Drawing.Size(277, 236);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelImage;
        private System.Windows.Forms.Panel panel1;
    }
}
