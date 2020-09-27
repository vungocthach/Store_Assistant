namespace StoreAssitant
{
    partial class MenuView
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
            this.controlSearch1 = new StoreAssitant.ControlSearch();
            this.controlProduct1 = new StoreAssitant.ControlProduct();
            this.SuspendLayout();
            // 
            // controlSearch1
            // 
            this.controlSearch1.Location = new System.Drawing.Point(3, 3);
            this.controlSearch1.Name = "controlSearch1";
            this.controlSearch1.Size = new System.Drawing.Size(350, 35);
            this.controlSearch1.TabIndex = 2;
            // 
            // controlProduct1
            // 
            this.controlProduct1.Location = new System.Drawing.Point(26, 44);
            this.controlProduct1.Name = "controlProduct1";
            this.controlProduct1.Size = new System.Drawing.Size(160, 151);
            this.controlProduct1.TabIndex = 1;
            // 
            // MenuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.controlSearch1);
            this.Controls.Add(this.controlProduct1);
            this.Name = "MenuView";
            this.Size = new System.Drawing.Size(825, 439);
            this.ResumeLayout(false);

        }

        #endregion
        private ControlProduct controlProduct1;
        private ControlSearch controlSearch1;
    }
}
