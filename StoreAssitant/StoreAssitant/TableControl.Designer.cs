using System.Drawing;

namespace StoreAssitant
{
    partial class TableControl
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
            this.tableName_lb = new System.Windows.Forms.Label();
            this.cmsTableControl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tableImage_pnl = new System.Windows.Forms.Panel();
            this.tsInformation = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsTableControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableName_lb
            // 
            this.tableName_lb.ContextMenuStrip = this.cmsTableControl;
            this.tableName_lb.Location = new System.Drawing.Point(18, 98);
            this.tableName_lb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tableName_lb.Name = "tableName_lb";
            this.tableName_lb.Size = new System.Drawing.Size(77, 13);
            this.tableName_lb.TabIndex = 1;
            this.tableName_lb.Text = "Name of Table";
            this.tableName_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmsTableControl
            // 
            this.cmsTableControl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsTableControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsInformation,
            this.tsDelete});
            this.cmsTableControl.Name = "contextMenuStrip1";
            this.cmsTableControl.Size = new System.Drawing.Size(138, 48);
            // 
            // tsDelete
            // 
            this.tsDelete.Name = "tsDelete";
            this.tsDelete.Size = new System.Drawing.Size(137, 22);
            this.tsDelete.Text = "Delete";
            // 
            // tableImage_pnl
            // 
            this.tableImage_pnl.BackgroundImage = global::StoreAssitant.Properties.Resources.Artboard_1;
            this.tableImage_pnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableImage_pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableImage_pnl.ContextMenuStrip = this.cmsTableControl;
            this.tableImage_pnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableImage_pnl.Location = new System.Drawing.Point(0, 0);
            this.tableImage_pnl.Margin = new System.Windows.Forms.Padding(2);
            this.tableImage_pnl.Name = "tableImage_pnl";
            this.tableImage_pnl.Size = new System.Drawing.Size(111, 90);
            this.tableImage_pnl.TabIndex = 0;
            // 
            // tsInformation
            // 
            this.tsInformation.Name = "tsInformation";
            this.tsInformation.Size = new System.Drawing.Size(137, 22);
            this.tsInformation.Text = "Information";
            // 
            // TableControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContextMenuStrip = this.cmsTableControl;
            this.Controls.Add(this.tableName_lb);
            this.Controls.Add(this.tableImage_pnl);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TableControl";
            this.Size = new System.Drawing.Size(111, 120);
            this.cmsTableControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel tableImage_pnl;
        private System.Windows.Forms.Label tableName_lb;
        private System.Windows.Forms.ContextMenuStrip cmsTableControl;
        private System.Windows.Forms.ToolStripMenuItem tsDelete;
        private System.Windows.Forms.ToolStripMenuItem tsInformation;
    }
}
