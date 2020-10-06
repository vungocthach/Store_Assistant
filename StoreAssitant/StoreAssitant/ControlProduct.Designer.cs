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
            this.panelImage = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelImage
            // 
            this.panelImage.BackColor = System.Drawing.SystemColors.Control;
            this.panelImage.BackgroundImage = global::StoreAssitant.Properties.Resources._120277592_792943121463048_8392671413067062045_n;
            this.panelImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelImage.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelImage.Location = new System.Drawing.Point(0, 1);
            this.panelImage.MinimumSize = new System.Drawing.Size(165, 145);
            this.panelImage.Name = "panelImage";
            this.panelImage.Size = new System.Drawing.Size(165, 145);
            this.panelImage.TabIndex = 1;
            this.panelImage.Paint += new System.Windows.Forms.PaintEventHandler(this.panelImage_Paint);
            // 
            // ControlProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.Controls.Add(this.panelImage);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.MinimumSize = new System.Drawing.Size(165, 145);
            this.Name = "ControlProduct";
            this.Size = new System.Drawing.Size(165, 145);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelImage;
    }
}
