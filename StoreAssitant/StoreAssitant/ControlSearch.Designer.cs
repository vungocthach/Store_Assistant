namespace StoreAssitant
{
    partial class ControlSearch
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlSearch));
            this.labelImage = new System.Windows.Forms.Label();
            this.richTextBoxSearch = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // labelImage
            // 
            this.labelImage.Image = ((System.Drawing.Image)(resources.GetObject("labelImage.Image")));
            this.labelImage.Location = new System.Drawing.Point(3, 1);
            this.labelImage.Name = "labelImage";
            this.labelImage.Size = new System.Drawing.Size(26, 34);
            this.labelImage.TabIndex = 1;
            // 
            // richTextBoxSearch
            // 
            this.richTextBoxSearch.EnableAutoDragDrop = true;
            this.richTextBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.richTextBoxSearch.Location = new System.Drawing.Point(32, 1);
            this.richTextBoxSearch.Name = "richTextBoxSearch";
            this.richTextBoxSearch.Size = new System.Drawing.Size(207, 34);
            this.richTextBoxSearch.TabIndex = 2;
            this.richTextBoxSearch.Text = "Search ";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // ControlSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richTextBoxSearch);
            this.Controls.Add(this.labelImage);
            this.Name = "ControlSearch";
            this.Size = new System.Drawing.Size(430, 111);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelImage;
        private System.Windows.Forms.RichTextBox richTextBoxSearch;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}
