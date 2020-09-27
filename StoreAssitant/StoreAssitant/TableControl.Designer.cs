namespace StoreAssitant
{
    partial class TableControl
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
            this.Table_Image = new System.Windows.Forms.Panel();
            this.Table_Name = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Table_Image
            // 
            this.Table_Image.BackgroundImage = global::StoreAssitant.Properties.Resources.Artboard_1;
            this.Table_Image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Table_Image.Location = new System.Drawing.Point(0, 0);
            this.Table_Image.Name = "Table_Image";
            this.Table_Image.Size = new System.Drawing.Size(150, 110);
            this.Table_Image.TabIndex = 0;
            // 
            // Table_Name
            // 
            this.Table_Name.AutoSize = true;
            this.Table_Name.Location = new System.Drawing.Point(24, 120);
            this.Table_Name.Name = "Table_Name";
            this.Table_Name.Size = new System.Drawing.Size(101, 17);
            this.Table_Name.TabIndex = 1;
            this.Table_Name.Text = "Name of Table";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::StoreAssitant.Properties.Resources.Artboard_1;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 110);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name of Table";
            // 
            // TableControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Table_Name);
            this.Controls.Add(this.Table_Image);
            this.Name = "TableControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel Table_Image;
        private System.Windows.Forms.Label Table_Name;
    }
}
