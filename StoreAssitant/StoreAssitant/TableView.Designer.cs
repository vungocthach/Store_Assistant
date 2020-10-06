namespace StoreAssitant
{
    partial class TableView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableView));
            this.table_cashier_pnl = new System.Windows.Forms.FlowLayoutPanel();
            this.tableControl1 = new StoreAssitant.TableControl();
            this.tableAdd_pnl = new System.Windows.Forms.Panel();
            this.tableTitle_lb = new System.Windows.Forms.Label();
            this.tableCashier_pnl = new System.Windows.Forms.Panel();
            this.tableCashier_image = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.table_cashier_pnl.SuspendLayout();
            this.tableCashier_pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // table_cashier_pnl
            // 
            this.table_cashier_pnl.AutoScroll = true;
            this.table_cashier_pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.table_cashier_pnl.Controls.Add(this.tableControl1);
            this.table_cashier_pnl.Controls.Add(this.tableAdd_pnl);
            this.table_cashier_pnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.table_cashier_pnl.Location = new System.Drawing.Point(0, 49);
            this.table_cashier_pnl.Margin = new System.Windows.Forms.Padding(2);
            this.table_cashier_pnl.Name = "table_cashier_pnl";
            this.table_cashier_pnl.Size = new System.Drawing.Size(416, 520);
            this.table_cashier_pnl.TabIndex = 0;
            // 
            // tableControl1
            // 
            this.tableControl1.BackColor = System.Drawing.Color.PapayaWhip;
            this.tableControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableControl1.imageTable = ((System.Drawing.Image)(resources.GetObject("tableControl1.imageTable")));
            this.tableControl1.Location = new System.Drawing.Point(2, 2);
            this.tableControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableControl1.MinimumSize = new System.Drawing.Size(76, 56);
            this.tableControl1.Name = "tableControl1";
            this.tableControl1.nameTable = "Name of Table";
            this.tableControl1.Size = new System.Drawing.Size(112, 121);
            this.tableControl1.TabIndex = 0;
            // 
            // tableAdd_pnl
            // 
            this.tableAdd_pnl.BackgroundImage = global::StoreAssitant.Properties.Resources.button_add;
            this.tableAdd_pnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableAdd_pnl.Location = new System.Drawing.Point(118, 2);
            this.tableAdd_pnl.Margin = new System.Windows.Forms.Padding(2);
            this.tableAdd_pnl.Name = "tableAdd_pnl";
            this.tableAdd_pnl.Size = new System.Drawing.Size(113, 122);
            this.tableAdd_pnl.TabIndex = 1;
            // 
            // tableTitle_lb
            // 
            this.tableTitle_lb.AutoSize = true;
            this.tableTitle_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableTitle_lb.Location = new System.Drawing.Point(73, 7);
            this.tableTitle_lb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tableTitle_lb.Name = "tableTitle_lb";
            this.tableTitle_lb.Size = new System.Drawing.Size(287, 35);
            this.tableTitle_lb.TabIndex = 2;
            this.tableTitle_lb.Text = "THANH TOÁN BÀN";
            // 
            // tableCashier_pnl
            // 
            this.tableCashier_pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableCashier_pnl.Controls.Add(this.tableCashier_image);
            this.tableCashier_pnl.Controls.Add(this.tableTitle_lb);
            this.tableCashier_pnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableCashier_pnl.Location = new System.Drawing.Point(0, 0);
            this.tableCashier_pnl.Margin = new System.Windows.Forms.Padding(2);
            this.tableCashier_pnl.Name = "tableCashier_pnl";
            this.tableCashier_pnl.Size = new System.Drawing.Size(416, 45);
            this.tableCashier_pnl.TabIndex = 3;
            // 
            // tableCashier_image
            // 
            this.tableCashier_image.BackgroundImage = global::StoreAssitant.Properties.Resources.thu_ngân;
            this.tableCashier_image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableCashier_image.Location = new System.Drawing.Point(2, 2);
            this.tableCashier_image.Margin = new System.Windows.Forms.Padding(2);
            this.tableCashier_image.Name = "tableCashier_image";
            this.tableCashier_image.Size = new System.Drawing.Size(49, 41);
            this.tableCashier_image.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // TableView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableCashier_pnl);
            this.Controls.Add(this.table_cashier_pnl);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TableView";
            this.Size = new System.Drawing.Size(416, 569);
            this.table_cashier_pnl.ResumeLayout(false);
            this.tableCashier_pnl.ResumeLayout(false);
            this.tableCashier_pnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel table_cashier_pnl;
        private System.Windows.Forms.Label tableTitle_lb;
        private System.Windows.Forms.Panel tableCashier_pnl;
        private System.Windows.Forms.Panel tableCashier_image;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private TableControl tableControl1;
        private System.Windows.Forms.Panel tableAdd_pnl;
    }
}
