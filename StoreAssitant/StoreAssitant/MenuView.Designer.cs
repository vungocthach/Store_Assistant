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
            this.ControlTitle = new StoreAssitant.TitleControl();
            this.controlSearch = new StoreAssitant.ControlSearch();
            this.controlProduct = new StoreAssitant.ControlProduct();
            this.SuspendLayout();
            // 
            // ControlTitle
            // 
            this.ControlTitle.Location = new System.Drawing.Point(0, 0);
            this.ControlTitle.Name = "ControlTitle";
            this.ControlTitle.Size = new System.Drawing.Size(825, 50);
            this.ControlTitle.TabIndex = 5;
            this.ControlTitle.Load += new System.EventHandler(this.titleControl1_Load);
            // 
            // controlSearch
            // 
            this.controlSearch.Location = new System.Drawing.Point(0, 69);
            this.controlSearch.Name = "controlSearch";
            this.controlSearch.Size = new System.Drawing.Size(324, 29);
            this.controlSearch.TabIndex = 4;
            // 
            // controlProduct
            // 
            this.controlProduct.Location = new System.Drawing.Point(14, 116);
            this.controlProduct.MinimumSize = new System.Drawing.Size(125, 127);
            this.controlProduct.Name = "controlProduct";
            this.controlProduct.Size = new System.Drawing.Size(125, 127);
            this.controlProduct.TabIndex = 3;
            this.controlProduct.Load += new System.EventHandler(this.controlProduct1_Load);
            // 
            // MenuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ControlTitle);
            this.Controls.Add(this.controlSearch);
            this.Controls.Add(this.controlProduct);
            this.Name = "MenuView";
            this.Size = new System.Drawing.Size(825, 439);
            this.ResumeLayout(false);

        }

        #endregion
        private ControlProduct controlProduct;
        private ControlSearch controlSearch;
        private TitleControl ControlTitle;
    }
}
