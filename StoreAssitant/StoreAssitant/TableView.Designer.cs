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
            this.Table_TableControl = new System.Windows.Forms.FlowLayoutPanel();
            this.pay_Table = new System.Windows.Forms.Panel();
            this.TableCashier_name = new System.Windows.Forms.Label();
            this.Table_Cashier = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TableCashier_image = new System.Windows.Forms.Panel();
            this.tableControl1 = new StoreAssitant.TableControl();
            this.panel_Add = new System.Windows.Forms.Panel();
            this.Table_TableControl.SuspendLayout();
            this.Table_Cashier.SuspendLayout();
            this.SuspendLayout();
            // 
            // Table_TableControl
            // 
            this.Table_TableControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Table_TableControl.Controls.Add(this.tableControl1);
            this.Table_TableControl.Controls.Add(this.panel_Add);
            this.Table_TableControl.Location = new System.Drawing.Point(0, 57);
            this.Table_TableControl.Name = "Table_TableControl";
            this.Table_TableControl.Size = new System.Drawing.Size(555, 600);
            this.Table_TableControl.TabIndex = 0;
            // 
            // pay_Table
            // 
            this.pay_Table.Location = new System.Drawing.Point(0, 655);
            this.pay_Table.Name = "pay_Table";
            this.pay_Table.Size = new System.Drawing.Size(555, 45);
            this.pay_Table.TabIndex = 1;
            // 
            // TableCashier_name
            // 
            this.TableCashier_name.AutoSize = true;
            this.TableCashier_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TableCashier_name.Location = new System.Drawing.Point(99, 6);
            this.TableCashier_name.Name = "TableCashier_name";
            this.TableCashier_name.Size = new System.Drawing.Size(351, 44);
            this.TableCashier_name.TabIndex = 2;
            this.TableCashier_name.Text = "THANH TOÁN BÀN";
            // 
            // Table_Cashier
            // 
            this.Table_Cashier.Controls.Add(this.TableCashier_image);
            this.Table_Cashier.Controls.Add(this.TableCashier_name);
            this.Table_Cashier.Location = new System.Drawing.Point(0, 0);
            this.Table_Cashier.Name = "Table_Cashier";
            this.Table_Cashier.Size = new System.Drawing.Size(555, 55);
            this.Table_Cashier.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // TableCashier_image
            // 
            this.TableCashier_image.BackgroundImage = global::StoreAssitant.Properties.Resources.thu_ngân;
            this.TableCashier_image.Location = new System.Drawing.Point(2, 2);
            this.TableCashier_image.Name = "TableCashier_image";
            this.TableCashier_image.Size = new System.Drawing.Size(65, 50);
            this.TableCashier_image.TabIndex = 3;
            // 
            // tableControl1
            // 
            this.tableControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableControl1.imageTable = ((System.Drawing.Image)(resources.GetObject("tableControl1.imageTable")));
            this.tableControl1.Location = new System.Drawing.Point(3, 3);
            this.tableControl1.MinimumSize = new System.Drawing.Size(101, 68);
            this.tableControl1.Name = "tableControl1";
            this.tableControl1.nameTable = "Name of Table";
            this.tableControl1.Size = new System.Drawing.Size(148, 148);
            this.tableControl1.TabIndex = 0;
            // 
            // panel_Add
            // 
            this.panel_Add.BackgroundImage = global::StoreAssitant.Properties.Resources.button_add;
            this.panel_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_Add.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Add.Location = new System.Drawing.Point(157, 3);
            this.panel_Add.Name = "panel_Add";
            this.panel_Add.Size = new System.Drawing.Size(150, 150);
            this.panel_Add.TabIndex = 1;
            // 
            // TableView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Table_Cashier);
            this.Controls.Add(this.pay_Table);
            this.Controls.Add(this.Table_TableControl);
            this.Name = "TableView";
            this.Size = new System.Drawing.Size(555, 700);
            this.Table_TableControl.ResumeLayout(false);
            this.Table_Cashier.ResumeLayout(false);
            this.Table_Cashier.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel Table_TableControl;
        private System.Windows.Forms.Panel pay_Table;
        private System.Windows.Forms.Label TableCashier_name;
        private System.Windows.Forms.Panel Table_Cashier;
        private System.Windows.Forms.Panel TableCashier_image;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private TableControl tableControl1;
        private System.Windows.Forms.Panel panel_Add;
    }
}
