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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.controlProduct = new StoreAssitant.ControlProduct();
            this.controlSearch = new StoreAssitant.ControlSearch();
            this.ControlTitle = new StoreAssitant.TitleControl();
            this.kryptonContextMenu1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenu();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.controlProduct);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 62);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(427, 377);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // controlProduct
            // 
            this.controlProduct.BackColor = System.Drawing.SystemColors.Control;
            this.controlProduct.ForeColor = System.Drawing.SystemColors.Control;
            this.controlProduct.Location = new System.Drawing.Point(4, 4);
            this.controlProduct.Margin = new System.Windows.Forms.Padding(4);
            this.controlProduct.MinimumSize = new System.Drawing.Size(11, 13);
            this.controlProduct.Name = "controlProduct";
            this.controlProduct.Size = new System.Drawing.Size(165, 145);
            this.controlProduct.TabIndex = 0;
            // 
            // controlSearch
            // 
            this.controlSearch.Location = new System.Drawing.Point(0, 31);
            this.controlSearch.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.controlSearch.Name = "controlSearch";
            this.controlSearch.Size = new System.Drawing.Size(419, 29);
            this.controlSearch.TabIndex = 2;
            // 
            // ControlTitle
            // 
            this.ControlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.ControlTitle.Location = new System.Drawing.Point(0, 0);
            this.ControlTitle.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.ControlTitle.MinimumSize = new System.Drawing.Size(0, 32);
            this.ControlTitle.Name = "ControlTitle";
            this.ControlTitle.NameTitle = "Menu";
            this.ControlTitle.Size = new System.Drawing.Size(427, 32);
            this.ControlTitle.TabIndex = 0;
            // 
            // MenuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.controlSearch);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.ControlTitle);
            this.Name = "MenuView";
            this.Size = new System.Drawing.Size(427, 439);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TitleControl ControlTitle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ControlProduct controlProduct;
        private ControlSearch controlSearch;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenu kryptonContextMenu1;
    }
}
