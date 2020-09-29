using System.Drawing;

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
            this.Table_Name = new System.Windows.Forms.Label();
            this.Table_Image = new System.Windows.Forms.Panel();
            this.SuspendLayout();
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
            // Table_Image
            // 
            this.Table_Image.BackgroundImage = global::StoreAssitant.Properties.Resources.Artboard_1;
            this.Table_Image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Table_Image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Table_Image.Location = new System.Drawing.Point(0, 0);
            this.Table_Image.Name = "Table_Image";
            this.Table_Image.Size = new System.Drawing.Size(150, 110);
            this.Table_Image.TabIndex = 0;
            // 
            // TableControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.Table_Name);
            this.Controls.Add(this.Table_Image);
            this.Name = "TableControl";
            this.Size = new System.Drawing.Size(148, 148);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Table_Image;
        private System.Windows.Forms.Label Table_Name;
    }
}
