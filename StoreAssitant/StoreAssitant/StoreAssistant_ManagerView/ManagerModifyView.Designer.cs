namespace StoreAssitant
{
    partial class ManagerModifyView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagerModifyView));
            this.split_Cashier = new System.Windows.Forms.SplitContainer();
            this.tableView1 = new StoreAssitant.TableView();
            this.menuView1 = new StoreAssitant.MenuView();
            ((System.ComponentModel.ISupportInitialize)(this.split_Cashier)).BeginInit();
            this.split_Cashier.Panel1.SuspendLayout();
            this.split_Cashier.Panel2.SuspendLayout();
            this.split_Cashier.SuspendLayout();
            this.SuspendLayout();
            // 
            // split_Cashier
            // 
            this.split_Cashier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_Cashier.Location = new System.Drawing.Point(0, 0);
            this.split_Cashier.Name = "split_Cashier";
            // 
            // split_Cashier.Panel1
            // 
            this.split_Cashier.Panel1.Controls.Add(this.tableView1);
            this.split_Cashier.Panel1.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            // 
            // split_Cashier.Panel2
            // 
            this.split_Cashier.Panel2.Controls.Add(this.menuView1);
            this.split_Cashier.Panel2.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.split_Cashier.Size = new System.Drawing.Size(1100, 590);
            this.split_Cashier.SplitterDistance = 499;
            this.split_Cashier.SplitterWidth = 5;
            this.split_Cashier.TabIndex = 2;
            // 
            // tableView1
            // 
            this.tableView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableView1.ImageCashierTable = ((System.Drawing.Image)(resources.GetObject("tableView1.ImageCashierTable")));
            this.tableView1.IsManager = true;
            this.tableView1.ItemImage = global::StoreAssitant.Properties.Resources.Artboard_1;
            this.tableView1.ItemSize = new System.Drawing.Size(120, 120);
            this.tableView1.Location = new System.Drawing.Point(0, 0);
            this.tableView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableView1.MinimumSize = new System.Drawing.Size(376, 50);
            this.tableView1.Name = "tableView1";
            this.tableView1.NameCashierTable = "DANH SÁCH BÀN";
            this.tableView1.Size = new System.Drawing.Size(499, 590);
            this.tableView1.TabIndex = 0;
            this.tableView1.TitleHeight = 50;
            // 
            // menuView1
            // 
            this.menuView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.menuView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuView1.image = global::StoreAssitant.Properties.Resources._120427285_648274679154155_8374726593261554204_n;
            this.menuView1.IsManeger = true;
            this.menuView1.ItemSize = new System.Drawing.Size(200, 150);
            this.menuView1.Location = new System.Drawing.Point(0, 0);
            this.menuView1.Margin = new System.Windows.Forms.Padding(4);
            this.menuView1.Name = "menuView1";
            this.menuView1.NameTitle = "Menu";
            this.menuView1.Size = new System.Drawing.Size(596, 590);
            this.menuView1.TabIndex = 0;
            this.menuView1.TitleHeight = 50;
            // 
            // ManagerModifyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.split_Cashier);
            this.Name = "ManagerModifyView";
            this.Size = new System.Drawing.Size(1100, 590);
            this.split_Cashier.Panel1.ResumeLayout(false);
            this.split_Cashier.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_Cashier)).EndInit();
            this.split_Cashier.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer split_Cashier;
        private TableView tableView1;
        private MenuView menuView1;
    }
}
