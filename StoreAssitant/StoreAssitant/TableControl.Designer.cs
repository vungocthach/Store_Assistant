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
            this.table_Name = new System.Windows.Forms.Label();
            this.table_Image = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // table_Name
            // 
            this.table_Name.Location = new System.Drawing.Point(18, 98);
            this.table_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.table_Name.Name = "table_Name";
            this.table_Name.Size = new System.Drawing.Size(77, 13);
            this.table_Name.TabIndex = 1;
            this.table_Name.Text = "Name of Table";
            this.table_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // table_Image
            // 
            this.table_Image.BackgroundImage = global::StoreAssitant.Properties.Resources.Artboard_1;
            this.table_Image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.table_Image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.table_Image.Dock = System.Windows.Forms.DockStyle.Top;
            this.table_Image.Location = new System.Drawing.Point(0, 0);
            this.table_Image.Margin = new System.Windows.Forms.Padding(2);
            this.table_Image.Name = "table_Image";
            this.table_Image.Size = new System.Drawing.Size(111, 90);
            this.table_Image.TabIndex = 0;
            // 
            // TableControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.table_Name);
            this.Controls.Add(this.table_Image);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TableControl";
            this.Size = new System.Drawing.Size(111, 120);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel table_Image;
        private System.Windows.Forms.Label table_Name;
    }
}
