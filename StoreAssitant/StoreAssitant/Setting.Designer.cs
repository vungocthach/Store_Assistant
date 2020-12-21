namespace StoreAssitant
{
    partial class Setting
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
            this.cbx_Language = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbx_Language
            // 
            this.cbx_Language.FormattingEnabled = true;
            this.cbx_Language.Items.AddRange(new object[] {
            "VietNam",
            "England"});
            this.cbx_Language.Location = new System.Drawing.Point(129, 89);
            this.cbx_Language.Name = "cbx_Language";
            this.cbx_Language.Size = new System.Drawing.Size(121, 21);
            this.cbx_Language.TabIndex = 0;
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbx_Language);
            this.Name = "Setting";
            this.Size = new System.Drawing.Size(453, 372);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbx_Language;
    }
}
