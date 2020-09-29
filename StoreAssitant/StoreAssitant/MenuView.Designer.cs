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
            this.controlProduct = new StoreAssitant.ControlProduct();
            this.controlSearch = new StoreAssitant.ControlSearch();
            this.ControlTitle = new StoreAssitant.TitleControl();
            this.SuspendLayout();
            // 
            // controlProduct
            // 
            this.controlProduct.BackColor = System.Drawing.SystemColors.Control;
            this.controlProduct.ForeColor = System.Drawing.SystemColors.Control;
            this.controlProduct.Location = new System.Drawing.Point(19, 124);
            this.controlProduct.MinimumSize = new System.Drawing.Size(165, 145);
            this.controlProduct.Name = "controlProduct";
            this.controlProduct.Size = new System.Drawing.Size(165, 145);
            this.controlProduct.TabIndex = 6;
            // 
            // controlSearch
            // 
            this.controlSearch.Location = new System.Drawing.Point(0, 69);
            this.controlSearch.Name = "controlSearch";
            this.controlSearch.Size = new System.Drawing.Size(344, 29);
            this.controlSearch.TabIndex = 4;
            // 
            // ControlTitle
            // 
            this.ControlTitle.Location = new System.Drawing.Point(0, 4);
            this.ControlTitle.Name = "ControlTitle";
            this.ControlTitle.Size = new System.Drawing.Size(634, 54);
            this.ControlTitle.TabIndex = 7;
            // 
            // MenuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ControlTitle);
            this.Controls.Add(this.controlProduct);
            this.Controls.Add(this.controlSearch);
            this.Name = "MenuView";
            this.Size = new System.Drawing.Size(635, 439);
            this.ResumeLayout(false);

        }

        #endregion
        private ControlSearch controlSearch;
        private ControlProduct controlProduct;
        private TitleControl ControlTitle;
    }
}
