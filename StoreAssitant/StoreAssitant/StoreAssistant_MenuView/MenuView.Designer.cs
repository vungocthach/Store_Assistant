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
<<<<<<< Updated upstream
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuView));
=======
>>>>>>> Stashed changes
            this.flowLayoutPanelMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.titleControl1 = new StoreAssitant.TitleControl();
            this.controlSearch = new StoreAssitant.ControlSearch();
            this.controlProduct = new StoreAssitant.ControlProduct();
<<<<<<< Updated upstream
            this.controlSearch = new StoreAssitant.ControlSearch();
            this.ControlTitle = new StoreAssitant.TitleControl();
            this.flowLayoutPanelMenu.SuspendLayout();
            this.SuspendLayout();
            //
=======
            this.flowLayoutPanelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
>>>>>>> Stashed changes
            // flowLayoutPanelMenu
            //
            this.flowLayoutPanelMenu.AutoScroll = true;
            this.flowLayoutPanelMenu.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.flowLayoutPanelMenu.Controls.Add(this.controlProduct);
            this.flowLayoutPanelMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanelMenu.Location = new System.Drawing.Point(0, 79);
            this.flowLayoutPanelMenu.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.flowLayoutPanelMenu.Name = "flowLayoutPanelMenu";
            this.flowLayoutPanelMenu.Size = new System.Drawing.Size(425, 355);
            this.flowLayoutPanelMenu.TabIndex = 1;
<<<<<<< Updated upstream
            //
            // controlProduct
            //
            this.controlProduct.BackColor = System.Drawing.Color.Azure;
            this.controlProduct.ForeColor = System.Drawing.SystemColors.Control;
            this.controlProduct.Location = new System.Drawing.Point(3, 3);
            this.controlProduct.MinimumSize = new System.Drawing.Size(15, 16);
            this.controlProduct.Name = "controlProduct";
            this.controlProduct.Size = new System.Drawing.Size(143, 152);
            this.controlProduct.TabIndex = 0;
            //
            // controlSearch
            //
            this.controlSearch.Location = new System.Drawing.Point(0, 36);
            this.controlSearch.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.controlSearch.Name = "controlSearch";
            this.controlSearch.Size = new System.Drawing.Size(426, 29);
            this.controlSearch.TabIndex = 2;
            //
=======
            // 
            // titleControl1
            // 
            this.titleControl1.BackColor = System.Drawing.Color.Orange;
            this.titleControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleControl1.image = global::StoreAssitant.Properties.Resources.iconfinder_food_and_restaurant_print_products_choose_menus_coffee_shop_menu_bar_paper_restaurant_food_4848456;
            this.titleControl1.Location = new System.Drawing.Point(0, 0);
            this.titleControl1.Name = "titleControl1";
            this.titleControl1.NameTitle = "Menu";
            this.titleControl1.Size = new System.Drawing.Size(425, 42);
            this.titleControl1.TabIndex = 3;
            // 
            // controlSearch
            // 
            this.controlSearch.Control = null;
            this.controlSearch.Location = new System.Drawing.Point(0, 45);
            this.controlSearch.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.controlSearch.Name = "controlSearch";
            this.controlSearch.Size = new System.Drawing.Size(426, 34);
            this.controlSearch.TabIndex = 2;
            this.controlSearch.Load += new System.EventHandler(this.controlSearch_Load);
            // 
>>>>>>> Stashed changes
            // controlProduct
            //
            this.controlProduct.BackColor = System.Drawing.Color.Azure;
            this.controlProduct.ForeColor = System.Drawing.SystemColors.Control;
            this.controlProduct.Location = new System.Drawing.Point(3, 3);
            this.controlProduct.MinimumSize = new System.Drawing.Size(15, 16);
            this.controlProduct.Name = "controlProduct";
            this.controlProduct.Size = new System.Drawing.Size(143, 152);
            this.controlProduct.TabIndex = 0;
<<<<<<< Updated upstream
            //
            // ControlTitle
            //
            this.ControlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.ControlTitle.image = ((System.Drawing.Image)(resources.GetObject("ControlTitle.image")));
            this.ControlTitle.Location = new System.Drawing.Point(0, 0);
            this.ControlTitle.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.ControlTitle.MinimumSize = new System.Drawing.Size(0, 32);
            this.ControlTitle.Name = "ControlTitle";
            this.ControlTitle.NameTitle = "Menu";
            this.ControlTitle.Size = new System.Drawing.Size(425, 32);
            this.ControlTitle.TabIndex = 0;
            //
=======
            // 
>>>>>>> Stashed changes
            // MenuView
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.titleControl1);
            this.Controls.Add(this.controlSearch);
            this.Controls.Add(this.flowLayoutPanelMenu);
            this.Name = "MenuView";
            this.Size = new System.Drawing.Size(425, 434);
            this.flowLayoutPanelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ControlSearch controlSearch;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMenu;
        private ControlProduct controlProduct;
        private TitleControl titleControl1;
    }
}
