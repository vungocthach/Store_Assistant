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
            this.panelImage = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelImage
            // 
            this.panelImage.BackColor = System.Drawing.SystemColors.Control;
            this.panelImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelImage.BackgroundImage")));
            this.panelImage.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelImage.Location = new System.Drawing.Point(31, 34);
            this.panelImage.MinimumSize = new System.Drawing.Size(165, 145);
            this.panelImage.Name = "panelImage";
            this.panelImage.Size = new System.Drawing.Size(165, 145);
            this.panelImage.TabIndex = 1;
            // 
            // ControlProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.Controls.Add(this.panelImage);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "ControlProduct";
            this.Size = new System.Drawing.Size(277, 236);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelImage;
    }
}
